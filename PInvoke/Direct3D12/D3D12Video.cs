#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>
	/// Specifies a bitstream encryption type. This enumeration is used by the <c>D3D12_VIDEO_DECODE_CONFIGURATION</c> which describes the
	/// configuration for a video decoder.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_bitstream_encryption_type typedef enum
	// D3D12_BITSTREAM_ENCRYPTION_TYPE { D3D12_BITSTREAM_ENCRYPTION_TYPE_NONE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_BITSTREAM_ENCRYPTION_TYPE")]
	public enum D3D12_BITSTREAM_ENCRYPTION_TYPE
	{
		/// <summary>The bistream is not encrypted.</summary>
		D3D12_BITSTREAM_ENCRYPTION_TYPE_NONE,
	}

	/// <summary>
	/// Specifies a Direct3D 12 video feature or feature set to query about. When you want to query for the level to which an adapter
	/// supports a feature, pass one of these values to <c>ID3D12VideoDevice::CheckFeatureSupport</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_feature_video typedef enum D3D12_FEATURE_VIDEO {
	// D3D12_FEATURE_VIDEO_DECODE_SUPPORT, D3D12_FEATURE_VIDEO_DECODE_PROFILES, D3D12_FEATURE_VIDEO_DECODE_FORMATS,
	// D3D12_FEATURE_VIDEO_DECODE_CONVERSION_SUPPORT, D3D12_FEATURE_VIDEO_PROCESS_SUPPORT, D3D12_FEATURE_VIDEO_PROCESS_MAX_INPUT_STREAMS,
	// D3D12_FEATURE_VIDEO_PROCESS_REFERENCE_INFO, D3D12_FEATURE_VIDEO_DECODER_HEAP_SIZE, D3D12_FEATURE_VIDEO_PROCESSOR_SIZE,
	// D3D12_FEATURE_VIDEO_DECODE_PROFILE_COUNT, D3D12_FEATURE_VIDEO_DECODE_FORMAT_COUNT, D3D12_FEATURE_VIDEO_ARCHITECTURE,
	// D3D12_FEATURE_VIDEO_DECODE_HISTOGRAM, D3D12_FEATURE_VIDEO_FEATURE_AREA_SUPPORT, D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR = 20,
	// D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR_SIZE = 21, D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_COUNT = 22,
	// D3D12_FEATURE_VIDEO_EXTENSION_COMMANDS = 23, D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT = 24,
	// D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS = 25, D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_SUPPORT = 26,
	// D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_SIZE = 27, D3D12_FEATURE_VIDEO_DECODE_PROTECTED_RESOURCES,
	// D3D12_FEATURE_VIDEO_PROCESS_PROTECTED_RESOURCES, D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES = 30,
	// D3D12_FEATURE_VIDEO_DECODER_HEAP_SIZE1, D3D12_FEATURE_VIDEO_PROCESSOR_SIZE1, D3D12_FEATURE_VIDEO_ENCODER_CODEC,
	// D3D12_FEATURE_VIDEO_ENCODER_PROFILE_LEVEL, D3D12_FEATURE_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT,
	// D3D12_FEATURE_VIDEO_ENCODER_OUTPUT_RESOLUTION, D3D12_FEATURE_VIDEO_ENCODER_INPUT_FORMAT,
	// D3D12_FEATURE_VIDEO_ENCODER_RATE_CONTROL_MODE, D3D12_FEATURE_VIDEO_ENCODER_INTRA_REFRESH_MODE,
	// D3D12_FEATURE_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE, D3D12_FEATURE_VIDEO_ENCODER_HEAP_SIZE,
	// D3D12_FEATURE_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT, D3D12_FEATURE_VIDEO_ENCODER_SUPPORT,
	// D3D12_FEATURE_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT, D3D12_FEATURE_VIDEO_ENCODER_RESOURCE_REQUIREMENTS,
	// D3D12_FEATURE_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_CONFIG, D3D12_FEATURE_VIDEO_ENCODER_SUPPORT1 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_FEATURE_VIDEO")]
	public enum D3D12_FEATURE_VIDEO
	{
		/// <summary>
		/// <para>
		/// Check if a decode profile, bitstream encryption, resolution, and format are supported. The result is a D3D12_VIDEO_DECODE_TIER
		/// indicating the level of support. The associated data structure is D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODE_SUPPORT,

		/// <summary>
		/// <para>
		/// Retrieve the list of decode profiles supported by the adapter. Call CheckFeatureSupport specifying the feature
		/// D3D12_FEATURE_VIDEO_DECODE_PROFILE_COUNT to get the number of profiles before calling CheckFeatureSupport for the
		/// D3D12_FEATURE_VIDEO_DECODE_PROFILES feature. The associated data structure is D3D12_FEATURE_DATA_VIDEO_DECODE_PROFILES.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODE_PROFILES,

		/// <summary>
		/// <para>
		/// Retrieves the list of supported decode formats for a D3D12_VIDEO_DECODE_CONFIGURATION. Call CheckFeatureSupport specifying the
		/// feature D3D12_FEATURE_VIDEO_DECODE_FORMAT_COUNT to get the number of profiles before calling CheckFeatureSupport for the
		/// D3D12_FEATURE_VIDEO_DECODE_PROFILES feature.The associated data structure is D3D12_FEATURE_DATA_VIDEO_DECODE_FORMATS.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODE_FORMATS,

		/// <summary>
		/// <para>Check if a colorspace conversion, format conversion, and scale are supported. The associated data structure is D3D12_FEATURE_DATA_VIDEO_DECODE_CONVERSION_SUPPORT.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODE_CONVERSION_SUPPORT,

		/// <summary>
		/// <para>Retrieves the video processor capabilities. The associated data structure is D3D12_FEATURE_DATA_VIDEO_PROCESS_SUPPORT.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_PROCESS_SUPPORT = 5,

		/// <summary>
		/// <para>Retrieves the maximum number of streams that can be enabled at the same time. The associated data structure is D3D12_FEATURE_DATA_VIDEO_PROCESS_MAX_INPUT_STREAMS.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_PROCESS_MAX_INPUT_STREAMS,

		/// <summary>
		/// <para>
		/// Retrieves the number of past and future frames required for a given deinterlace mode, filters, frame rate conversion, and
		/// features. The associated data structure is D3D12_FEATURE_DATA_VIDEO_PROCESS_REFERENCE_INFO.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_PROCESS_REFERENCE_INFO,

		/// <summary>
		/// <para>
		/// Checks the allocation size of a video decoder heap. The associated data structure is D3D12_FEATURE_DATA_VIDEO_DECODER_HEAP_SIZE.
		/// For information on residency budgeting for heaps, see Residency.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODER_HEAP_SIZE,

		/// <summary>
		/// <para>
		/// Checks the allocation size of a video processor heap. The associated data structure is D3D12_FEATURE_DATA_VIDEO_PROCESSOR_SIZE.
		/// For information on residency budgeting for heaps, see Residency.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_PROCESSOR_SIZE,

		/// <summary>
		/// <para>Retrieves the number of supported decoder profiles. The returned count is used when querying for D3D12_FEATURE_VIDEO_DECODE_PROFILES.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODE_PROFILE_COUNT,

		/// <summary>
		/// <para>Retrieves the number of supported decoder profiles. The returned count is used when querying for D3D12_FEATURE_VIDEO_DECODE_FORMATS.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODE_FORMAT_COUNT,

		/// <summary>Indicates if the video engine is IO coherent with the CPU.</summary>
		D3D12_FEATURE_VIDEO_ARCHITECTURE = 17,

		/// <summary>
		/// <para>
		/// Retrieves the supported components, bin count, and counter bit depth for the a decode histogram with the specified decode
		/// profile, resolution, and format. The associated data structure is D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_DECODE_HISTOGRAM,

		/// <summary/>
		D3D12_FEATURE_VIDEO_FEATURE_AREA_SUPPORT,

		/// <summary>
		/// <para>
		/// Value: 20 Retrieves the supported resolutions, search block sizes, and precision for motion estimation. The associated data
		/// structure is D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR,

		/// <summary>
		/// <para>Value: 21 Checks the allocation size of a motion estimator heap. The associated data structure is D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_SIZE.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR_SIZE,

		/// <summary>
		/// <para>Value: 22 Retrieves the supported number of video extension commands. The associated data structure is D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_COUNT.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_COUNT,

		/// <summary>
		/// <para>
		/// Value: 23 Retrieves a list of D3D12_VIDEO_EXTENSION_COMMAND_INFO structures describing video extension commands. The associated
		///        data structure is D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_COUNT.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_EXTENSION_COMMANDS,

		/// <summary>
		/// <para>Value: 24 Retrieves the parameter count for the specified parameter stage. The associated data structure is D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT,

		/// <summary>
		/// <para>
		/// Value: 25 Retrieves a list of D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO structures describing video extension command
		/// parameters for the specified parameter stage. The associated data structure is D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETERS.
		/// </para>
		/// </summary>
		D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS,

		/// <summary>
		/// <para>Value: 26 Queries for command-defined support information. The associated data structure is D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SUPPORT.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_SUPPORT,

		/// <summary>
		/// <para>Value: 27 Checks the allocation size of a video extension command. The associated data structure is D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SIZE.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_SIZE,

		/// <summary/>
		D3D12_FEATURE_VIDEO_DECODE_PROTECTED_RESOURCES,

		/// <summary/>
		D3D12_FEATURE_VIDEO_PROCESS_PROTECTED_RESOURCES,

		/// <summary>
		/// <para>Value: 30 Checks support for motion estimation with protected resources. The associated data structure is D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES.</para>
		/// </summary>
		D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES,

		/// <summary/>
		D3D12_FEATURE_VIDEO_DECODER_HEAP_SIZE1,

		/// <summary/>
		D3D12_FEATURE_VIDEO_PROCESSOR_SIZE1,

		/// <summary>Checks support for a given codec. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_CODEC,

		/// <summary>
		/// Checks support for a given profile and returns the supported levels range for that profile. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_PROFILE_LEVEL</c>.
		/// </summary>
		D3D12_FEATURE_VIDEO_ENCODER_PROFILE_LEVEL,

		/// <summary>Checks support for the number of resolution ratios available. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT,

		/// <summary>Checks support for the rules that resolutions must meet. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_OUTPUT_RESOLUTION,

		/// <summary>Checks support for a given input format. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_INPUT_FORMAT</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_INPUT_FORMAT,

		/// <summary>Checks support for a given rate control mode. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RATE_CONTROL_MODE</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_RATE_CONTROL_MODE,

		/// <summary>Checks support for a given intra refresh mode. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_INTRA_REFRESH_MODE</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_INTRA_REFRESH_MODE,

		/// <summary>Checks support for a given subregion layout mode. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE,

		/// <summary>
		/// Retrieves the memory requirements of a video encoder heap created with the given encoder heap properties. The associated data
		/// structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_HEAP_SIZE</c>.
		/// </summary>
		D3D12_FEATURE_VIDEO_ENCODER_HEAP_SIZE,

		/// <summary>Retrieves a set of codec specific configuration limits. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT,

		/// <summary>Retrieves the feature support details on the requested configuration. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_SUPPORT,

		/// <summary>
		/// Retrieves the codec specific capabilities related to the reference picture management limitations. The associated data structure
		/// is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT</c>.
		/// </summary>
		D3D12_FEATURE_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT,

		/// <summary>Retrieves the requirements for alignment for resource access. The associated data structure is <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOURCE_REQUIREMENTS</c>.</summary>
		D3D12_FEATURE_VIDEO_ENCODER_RESOURCE_REQUIREMENTS,

		/// <summary/>
		D3D12_FEATURE_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_CONFIG,

		/// <summary/>
		D3D12_FEATURE_VIDEO_ENCODER_SUPPORT1
	}

	/// <summary>Specifies the argument type of a <c>D3D12_VIDEO_DECODE_FRAME_ARGUMENT</c>.</summary>
	/// <remarks>The values used with the argument type are defined by the DXVA specification for a given codec.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_argument_type typedef enum
	// D3D12_VIDEO_DECODE_ARGUMENT_TYPE { D3D12_VIDEO_DECODE_ARGUMENT_TYPE_PICTURE_PARAMETERS,
	// D3D12_VIDEO_DECODE_ARGUMENT_TYPE_INVERSE_QUANTIZATION_MATRIX, D3D12_VIDEO_DECODE_ARGUMENT_TYPE_SLICE_CONTROL,
	// D3D12_VIDEO_DECODE_ARGUMENT_TYPE_HUFFMAN_TABLE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_ARGUMENT_TYPE")]
	public enum D3D12_VIDEO_DECODE_ARGUMENT_TYPE
	{
		/// <summary>The argument is a picture decoding parameter buffer.</summary>
		D3D12_VIDEO_DECODE_ARGUMENT_TYPE_PICTURE_PARAMETERS,

		/// <summary>The argument is an inverse quantization matrix buffer.</summary>
		D3D12_VIDEO_DECODE_ARGUMENT_TYPE_INVERSE_QUANTIZATION_MATRIX,

		/// <summary>The argument is a slice control buffer.</summary>
		D3D12_VIDEO_DECODE_ARGUMENT_TYPE_SLICE_CONTROL,

		/// <summary>The argument is a huffman table.</summary>
		D3D12_VIDEO_DECODE_ARGUMENT_TYPE_HUFFMAN_TABLE
	}

	/// <summary>Specifies the configuration for video decoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_configuration_flags typedef enum
	// D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS { D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_NONE,
	// D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_HEIGHT_ALIGNMENT_MULTIPLE_32_REQUIRED,
	// D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_POST_PROCESSING_SUPPORTED,
	// D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED,
	// D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_ALLOW_RESOLUTION_CHANGE_ON_NON_KEY_FRAME } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS
	{
		/// <summary>No configuration flags.</summary>
		D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_NONE = 0x0,

		/// <summary>The height of the output decoded surfaces must be a multiple of 32.</summary>
		D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_HEIGHT_ALIGNMENT_MULTIPLE_32_REQUIRED = 0x1,

		/// <summary>
		/// <para>
		/// The driver supports post processing. If this flag is set, the host decoder can set up post-processing by using the conversion
		/// flags in the D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS.
		/// </para>
		/// </summary>
		D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_POST_PROCESSING_SUPPORTED = 0x2,

		/// <summary>
		/// <para>
		/// Reference resources must be allocated with the D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY resource flag. References
		/// textures must be separate from output textures, similar to performing a format conversion or downscale. This flag must not be
		/// set for D3D12_VIDEO_DECODE_TIER_3 or greater.
		/// </para>
		/// </summary>
		D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED = 0x4,

		/// <summary>The decode resolution can be changed on a non-key frame.</summary>
		D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_ALLOW_RESOLUTION_CHANGE_ON_NON_KEY_FRAME = 0x8,
	}

	/// <summary>Specifies whether a video decode conversion operation is supported.</summary>
	/// <remarks>This enumeration is used by the <c>D3D12_FEATURE_DATA_VIDEO_DECODE_CONVERSION_SUPPORT</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_conversion_support_flags typedef enum
	// D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAGS { D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAG_NONE,
	// D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAG_SUPPORTED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAGS
	{
		/// <summary>The video decode conversion operation isn't supported.</summary>
		D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAG_NONE = 0x0,

		/// <summary>The video decode conversion operation is supported.</summary>
		D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAG_SUPPORTED = 0x1,
	}

	/// <summary>Specifies indices for arrays of per component histogram information.</summary>
	/// <remarks>
	/// The <c>D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAGS</c> is the flags enumeration used by
	/// <c>D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM</c> to allow you to specify one or more components for which histogram data is queried.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_histogram_component typedef enum
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT { D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_Y, D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_U,
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_V, D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_R, D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_G,
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_B, D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_A } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT")]
	public enum D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT
	{
		/// <summary>If the format is a YUV format, indicates a histogram for the Y component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_Y = 0,

		/// <summary>If the format is a YUV format, indicates a histogram for the U component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_U,

		/// <summary>If the format is a YUV format, indicates a histogram for the V component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_V,

		/// <summary>If the format is an RGB/BGR format, indicates a histogram for the R component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_R = 0,

		/// <summary>If the format is an RGB/BGR format, indicates a histogram for the G component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_G,

		/// <summary>If the format is an RGB/BGR format, indicates a histogram for the B component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_B,

		/// <summary>If the format has an alpha channel, indicates a histogram for the A component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_A,
	}

	/// <summary>
	/// Flags for indicating a subset of components used with video decode histogram. This enumeration is used by the
	/// <c>D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM</c> structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_histogram_component_flags typedef
	// enum D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAGS { D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_NONE,
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_Y, D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_U,
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_V, D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_R,
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_G, D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_B,
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_A } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAGS")]
	public enum D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAGS
	{
		/// <summary>No associated component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_NONE = 0,

		/// <summary>If the format is a YUV format, indicates the Y component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_Y = 1 << D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_Y,

		/// <summary>If the format is a YUV format, indicates the U component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_U = 1 << D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_U,

		/// <summary>If the format is a YUV format, indicates the V component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_V = 1 << D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_V,

		/// <summary>If the format is an RGB/BGR format, indicates the R component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_R = 1 << D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_R,

		/// <summary>If the format is an RGB/BGR format, indicates the G component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_G = 1 << D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_G,

		/// <summary>If the format is an RGB/BGR format, indicates the B component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_B = 1 << D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_B,

		/// <summary>If the format is an RGB/BGR format, indicates the A component.</summary>
		D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAG_A = 1 << D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT.D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_A,
	}

	/// <summary>
	/// Specifies the status of a video decode operation. This enumeration is used in the status field of a <c>D3D12_VIDEO_DECODE_STATUS</c> structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_status typedef enum
	// D3D12_VIDEO_DECODE_STATUS { D3D12_VIDEO_DECODE_STATUS_OK, D3D12_VIDEO_DECODE_STATUS_CONTINUE,
	// D3D12_VIDEO_DECODE_STATUS_CONTINUE_SKIP_DISPLAY, D3D12_VIDEO_DECODE_STATUS_RESTART, D3D12_VIDEO_DECODE_STATUS_RATE_EXCEEDED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_STATUS")]
	public enum D3D12_VIDEO_DECODE_STATUS
	{
		/// <summary>The operation succeeded.</summary>
		D3D12_VIDEO_DECODE_STATUS_OK,

		/// <summary>There was a minor problem in the data format, but the host decoder should continue processing.</summary>
		D3D12_VIDEO_DECODE_STATUS_CONTINUE,

		/// <summary>
		/// There was a significant problem in the data format. The host decoder should continue processing, but should skip display.
		/// </summary>
		D3D12_VIDEO_DECODE_STATUS_CONTINUE_SKIP_DISPLAY,

		/// <summary>
		/// There was a severe problem in the data format. The host decoder should restart the entire decoding process, starting at a
		/// sequence or random-access entry point.
		/// </summary>
		D3D12_VIDEO_DECODE_STATUS_RESTART,

		/// <summary/>
		D3D12_VIDEO_DECODE_STATUS_RATE_EXCEEDED
	}

	/// <summary>Specifies whether a video decoding operation is supported.</summary>
	/// <remarks>This enumeration is used by the <c>D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_support_flags typedef enum
	// D3D12_VIDEO_DECODE_SUPPORT_FLAGS { D3D12_VIDEO_DECODE_SUPPORT_FLAG_NONE, D3D12_VIDEO_DECODE_SUPPORT_FLAG_SUPPORTED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_DECODE_SUPPORT_FLAGS
	{
		/// <summary>The video decoding operation isn't supported.</summary>
		D3D12_VIDEO_DECODE_SUPPORT_FLAG_NONE = 0x0,

		/// <summary>The video decoding operation is supported.</summary>
		D3D12_VIDEO_DECODE_SUPPORT_FLAG_SUPPORTED = 0x1,
	}

	/// <summary>
	/// Specifies the decoding tier of a hardware video decoder, which determines the required format of application-defined textures and buffers.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_decode_tier typedef enum
	// D3D12_VIDEO_DECODE_TIER { D3D12_VIDEO_DECODE_TIER_NOT_SUPPORTED, D3D12_VIDEO_DECODE_TIER_1, D3D12_VIDEO_DECODE_TIER_2,
	// D3D12_VIDEO_DECODE_TIER_3 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_DECODE_TIER")]
	public enum D3D12_VIDEO_DECODE_TIER
	{
		/// <summary>Video decoding is not supported.</summary>
		D3D12_VIDEO_DECODE_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>
		/// In tier 1, the hardware decoder requires that the application allocate reference textures as a texture array. This is to
		/// accommodate hardware requirements that the textures be "close" in address space because the hardware doesn't support a full size
		/// pointer for each individual picture buffer. Instead it has one pointer and a more limited bit offset. For more information on
		/// texture arrays, see
		/// </para>
		/// <para>Introduction To Textures in Direct3D 11</para>
		/// <para>.</para>
		/// <para>
		/// If the decoder hardware requires a unique memory layout that is not supported for operations on other engines or different video
		/// operations, the decoder may set the D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED configuration flag
		/// in the D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT structure when queried for profile support. This flag indicates that the
		/// application must allocate references with the D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY flag. The application should use
		/// the D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS structure to set a reference-only output if the output is needed as a future
		/// reference frame. The output frame passed to
		/// </para>
		/// <para>ID3D12VideoCommandList::DecodeFrame</para>
		/// <para>
		/// is a D3D12 resource that can be consumed by other portions of the pipeline and must not have the
		/// D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY flag.
		/// </para>
		/// <para>#### Tier 1 requirements for compressed input buffers</para>
		/// <para>
		/// - All slices for a given frame must be placed in order and must be contiguous, i.e. there must be no gaps between slices. Slice
		/// control buffers must specify offset and size parameters that meet this requirement.
		/// </para>
		/// <para>
		/// - The first slice must begin on a 128 Byte boundary. The offset set in the D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM structure
		///   must be a multiple of 128 Bytes.
		/// </para>
		/// <para>
		/// - Decoding is supported from buffers allocated with D3D12_MEMORY_POOL_L0. This is always system memory, but still a D3D12 buffer.
		/// </para>
		/// <para>
		/// - Decoding is supported from buffers allocated with D3D12_MEMORY_POOL_L1, the default pool, including those allocated with D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE.
		/// </para>
		/// </summary>
		D3D12_VIDEO_DECODE_TIER_1,

		/// <summary>
		/// <para>
		/// In decode tier 2, textures can be referenced as a texture array or as an array of separate texture 2D resources (each resource
		/// having array size of 1). This is more flexible for the caller and is important in scenarios where the resolution changes
		/// frequently such as in streaming video, because a texture array can only be allocated and deallocated as a single unit, but
		/// separate texture 2D resources can be allocated and deallocated individually.
		/// </para>
		/// <para>
		/// If decode hardware requires a unique tiling format that is not supported for operations on other engines or different video
		/// operations, the decoder may set the D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED configuration flag
		/// in the D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT structure when queried for profile support. This flag indicates that the
		/// application must allocate references with the D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY flag. The application should use
		/// the D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS structure to set a reference only output if the output is needed as a future
		/// reference frame. The output frame passed to
		/// </para>
		/// <para>ID3D12VideoCommandList::DecodeFrame</para>
		/// <para>
		/// is a D3D12 resource that can be consumed by other portions of the pipeline and must not have the
		/// D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY flag.
		/// </para>
		/// <para>#### Tier 2 requirements for compressed input buffers</para>
		/// <para>These requirements are identical to the tier 1 requirements.</para>
		/// <para>
		/// - All slices for a given frame must be placed in order and must be contiguous, i.e. there must be no gaps between slices. Slice
		/// control buffers must specify offset and size parameters that meet this requirement.
		/// </para>
		/// <para>
		/// - The first slice must begin on a 128 Byte boundary. The offset set in the D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM structure
		///   must be a multiple of 128 Bytes.
		/// </para>
		/// <para>
		/// - Decoding is supported from buffers allocated with D3D12_MEMORY_POOL_L0. This is always system memory, but still a D3D12 buffer.
		/// </para>
		/// <para>
		/// - Decoding is supported from buffers allocated with D3D12_MEMORY_POOL_L1, the default pool, including those allocated with D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE.
		/// </para>
		/// <para>-</para>
		/// </summary>
		D3D12_VIDEO_DECODE_TIER_2,

		/// <summary>This field is reserved.</summary>
		D3D12_VIDEO_DECODE_TIER_3,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	public enum D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE
	{
		/// <summary>Indicates that all inter blocks will use single prediction. Equivalent to AV1 syntax reference_select equal to 0.</summary>
		D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE_SINGLE_REFERENCE = 0,

		/// <summary>
		/// Indicates that the mode info for inter blocks contains the syntax element comp_mode that indicates whether to use single or
		/// compound reference prediction. Equivalent to AV1 syntax reference_select equal to 1.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE_COMPOUND_REFERENCE = 1,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAGS : uint
	{
		/// <summary/>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_NONE = 0,

		/// <summary>Indicates if support is available for 128x128 Superblocks.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_128x128_SUPERBLOCK = 0x1,

		/// <summary>Indicates if support is available for Intra prediction filter.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_FILTER_INTRA = 0x2,

		/// <summary>Indicates if support is available for intra edge filtering process.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_INTRA_EDGE_FILTER = 0x4,

		/// <summary>
		/// Indicates if support is available for interintra, where the mode info for inter blocks may contain the syntax element
		/// interintra. Equal to 0 specifies that the syntax element interintra will not be present.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_INTERINTRA_COMPOUND = 0x8,

		/// <summary>
		/// Indicates if support is available for masked compound, where the mode info for inter blocks may contain the syntax element
		/// compound_type. Equal to 0 specifies that the syntax element compound_type will not be present.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_MASKED_COMPOUND = 0x10,

		/// <summary>
		/// Equal to 1 indicates that the syntax element motion_mode may be present. If equal to 0 indicates that the syntax element
		/// motion_mode will not be present (this means that LOCALWARP cannot be signaled if this flag is equal to 0).
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_WARPED_MOTION = 0x20,

		/// <summary>
		/// Indicates if support is available for dual filter mode, where the inter prediction filter type may be specified independently in
		/// the horizontal and vertical directions. If the flag is equal to 0, only one filter type may be specified, which is then used in
		/// both directions.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_DUAL_FILTER = 0x40,

		/// <summary>Indicates if support is available for the scenario where distance weights process may be used for inter prediction.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_JNT_COMP = 0x80,

		/// <summary>Indicates if support is available for using the syntax element force_integer_mv.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_FORCED_INTEGER_MOTION_VECTORS = 0x100,

		/// <summary>Indicates if support is available for super resolution.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_SUPER_RESOLUTION = 0x200,

		/// <summary>Indicates if support is available for loop restoration filtering.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_LOOP_RESTORATION_FILTER = 0x400,

		/// <summary>
		/// Indicates if support is available for frame level control on palette encoding; Equal to 0 indicates that palette encoding is
		/// never used.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_PALETTE_ENCODING = 0x800,

		/// <summary>Indicates if support is available for constrained directional enhancement filtering.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_CDEF_FILTERING = 0x1000,

		/// <summary>Indicates if intra block copy is supported or not at frame level. Same syntax as AV1 spec.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_INTRA_BLOCK_COPY = 0x2000,

		/// <summary>
		/// Indicates if support is available for use_ref_frame_mvs to be configured on a per frame basis. Equal to 0 specifies that
		/// use_ref_frame_mvs syntax element will not be used.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_FRAME_REFERENCE_MOTION_VECTORS = 0x4000,

		/// <summary>
		/// Indicates if support is available for usage of tools based on the values of order hints. Equal to 0 indicates that tools based
		/// on order hints are not supported and can’t be enabled.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_ORDER_HINT_TOOLS = 0x8000,

		/// <summary>
		/// Indicates if the driver can perform segmentation without API Client input and return segmentation_params() information in
		/// D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES. Driver will write the segment map in the compressed bitstream.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_AUTO_SEGMENTATION = 0x10000,

		/// <summary>
		/// Indicates if the driver supports the API Client passing customized segmentation segmentation_params() as well as the segment map
		/// and driver will honor exactly.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_CUSTOM_SEGMENTATION = 0x20000,

		/// <summary>Indicates if the driver supports use of loop filter deltas. Related to loop_filter_delta_enabled AV1 syntax in loop_filter_params().</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_LOOP_FILTER_DELTAS = 0x40000,

		/// <summary>Indicates if the driver supports use of quantization delta syntax.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_QUANTIZATION_DELTAS = 0x80000,

		/// <summary>Indicates if the driver supports use of quantization matrix syntax.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_QUANTIZATION_MATRIX = 0x100000,

		/// <summary>Indicates if driver supports setting reduced_tx_set in the frame header or must be always set to zero.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_REDUCED_TX_SET = 0x200000,

		/// <summary>Indicates if driver supports setting is_motion_mode_switchable in the frame header or must be always set to zero.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_MOTION_MODE_SWITCHABLE = 0x400000,

		/// <summary>Indicates if driver supports setting allow_high_precision_mv in the frame header or must be always set to zero.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_ALLOW_HIGH_PRECISION_MV = 0x800000,

		/// <summary>Indicates if driver supports setting skip_mode_present in the frame header or must be always set to zero.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_SKIP_MODE_PRESENT = 0x1000000,

		/// <summary>Indicates if the driver supports use of loop filter delta params syntax. Related to delta_lf_params() AV1 syntax.</summary>
		D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_DELTA_LF_PARAMS = 0x2000000
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAGS
	{
		/// <summary>No flags.</summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_NONE = 0x0,

		/// <summary>
		/// When this flag is set, indicates that the requested tiles configuration is not supported due to a reason not specified by any of
		/// the other flag categories.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_NOT_SPECIFIED = 0x1,

		/// <summary>
		/// When this flag is set, indicates that the requested tiles configuration is not supported due to codec constraints. An example on
		/// this for AV1 would be D3D12_FEATURE_DATA_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_CONFIG.Level.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_CODEC_CONSTRAINT = 0x2,

		/// <summary>When this flag is set, indicates that the requested tiles configuration is not supported due to hardware constraints.</summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_HARDWARE_CONSTRAINT = 0x4,

		/// <summary>When this flag is set, indicates that the number of tile rows requested is not supported.</summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_ROWS_COUNT = 0x8,

		/// <summary>When this flag is set, indicates that the number of tile columns requested is not supported.</summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_COLS_COUNT = 0x10,

		/// <summary>When this flag is set, indicates that one or more tiles widths in the requested configuration is not supported.</summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_WIDTH = 0x20,

		/// <summary>When this flag is set, indicates that one or more tiles areas in the requested configuration is not supported.</summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_AREA = 0x40,

		/// <summary>
		/// When this flag is set, indicates that the total number of tiles in the requested partition exceeds the total supported tiles
		/// count. Please see D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.MaxSubregionsNumber.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAG_TOTAL_TILES = 0x80,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT")]
	public enum D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE
	{
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_KEY_FRAME = 0,
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_INTER_FRAME = 1,
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_INTRA_ONLY_FRAME = 2,
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_SWITCH_FRAME = 3,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_FLAGS
	{
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_FLAG_NONE = 0x0,
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_FLAG_KEY_FRAME = 1 << D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE.D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_KEY_FRAME,
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_FLAG_INTER_FRAME = 1 << D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE.D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_INTER_FRAME,
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_FLAG_INTRA_ONLY_FRAME = 1 << D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE.D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_INTRA_ONLY_FRAME,
		D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_FLAG_SWITCH_FRAME = 1 << D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE.D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_SWITCH_FRAME,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	public enum D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS
	{
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_EIGHTTAP = 0,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_EIGHTTAP_SMOOTH = 1,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_EIGHTTAP_SHARP = 2,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_BILINEAR = 3,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_SWITCHABLE = 4,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAGS
	{
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAG_NONE = 0,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAG_EIGHTTAP = 1 << D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS.D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_EIGHTTAP,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAG_EIGHTTAP_SMOOTH = 1 << D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS.D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_EIGHTTAP_SMOOTH,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAG_EIGHTTAP_SHARP = 1 << D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS.D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_EIGHTTAP_SHARP,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAG_BILINEAR = 1 << D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS.D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_BILINEAR,
		D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAG_SWITCHABLE = 1 << D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS.D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_SWITCHABLE
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_LEVEL_SETTING")]
	public enum D3D12_VIDEO_ENCODER_AV1_LEVELS
	{
		D3D12_VIDEO_ENCODER_AV1_LEVELS_2_0 = 0,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_2_1 = 1,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_2_2 = 2,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_2_3 = 3,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_3_0 = 4,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_3_1 = 5,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_3_2 = 6,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_3_3 = 7,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_4_0 = 8,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_4_1 = 9,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_4_2 = 10,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_4_3 = 11,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_5_0 = 12,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_5_1 = 13,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_5_2 = 14,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_5_3 = 15,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_6_0 = 16,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_6_1 = 17,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_6_2 = 18,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_6_3 = 19,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_7_0 = 20,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_7_1 = 21,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_7_2 = 22,
		D3D12_VIDEO_ENCODER_AV1_LEVELS_7_3 = 23,
	}

	/// <summary>Defines the set of flags for the codec-specific picture control properties.</summary>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAGS
	{
		/// <summary>No flags</summary>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAG_NONE = 0x0,

		/// <summary>Related to error_resilient_mode AV1 syntax in frame header.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_ERROR_RESILIENT_MODE = 0x1,

		/// <summary>Related to AV1 syntax for disable_cdf_update.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_DISABLE_CDF_UPDATE = 0x2,

		/// <summary>Enables the usage of palette encoding for this frame.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_PALETTE_ENCODING = 0x4,

		/// <summary>
		/// Related to AV1 syntax skip_mode_present. skip_mode element will be present for this frame if this flag is set. Please check
		/// support in AV1 query caps before enabling this feature.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_SKIP_MODE = 0x8,

		/// <summary>
		/// Related to AV1 syntax use_ref_frame_mvs. Equal to 1 specifies that motion vector information from a previous frame can be used
		/// when encoding the current frame. use_ref_frame_mvs equal to 0 specifies that this information will not be used.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_FRAME_REFERENCE_MOTION_VECTORS = 0x10,

		/// <summary>
		/// Equal to 1 specifies that force_integer_mv may be enabled on a per frame basis. Equal to 0 specifies that force_integer_mv
		/// syntax element will not be used. Please check support in AV1 query caps before enabling this feature.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_FORCE_INTEGER_MOTION_VECTORS = 0x20,

		/// <summary>Indicates if intra block copy is supported or not at per frame basis. Related to allow_intrabc syntax in AV1 spec.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ALLOW_INTRA_BLOCK_COPY = 0x40,

		/// <summary>Related to AV1 syntax use_superres.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_USE_SUPER_RESOLUTION = 0x80,

		/// <summary>Related to AV1 syntax disable_frame_end_update_cdf.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_DISABLE_FRAME_END_UPDATE_CDF = 0x100,

		/// <summary>
		/// Enables automatic (performed by driver without API Client input) segmentation for the current frame. Requires
		/// D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_AUTO_SEGMENTATION. This flag must not be combined with D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_CUSTOM.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_AUTO = 0x200,

		/// <summary>
		/// Enables customized segmentation with the API Client sending the driver segmentation config and segment map. Requires
		/// D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_CUSTOM_SEGMENTATION. This flag must not be combined with D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_AUTO.
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_CUSTOM = 0x400,

		/// <summary>Related to AV1 syntax allow_warped_motion to be coded in the frame header. Requires D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_WARPED_MOTION.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_WARPED_MOTION = 0x800,

		/// <summary>Related to AV1 syntax reduced_tx_set. Requires D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_REDUCED_TX_SET.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_REDUCED_TX_SET = 0x1000,

		/// <summary>Related to AV1 syntax is_motion_mode_switchable. Requires D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_MOTION_MODE_SWITCHABLE.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_MOTION_MODE_SWITCHABLE = 0x2000,

		/// <summary>Related to AV1 syntax allow_high_precision_mv. Requires D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_ALLOW_HIGH_PRECISION_MV.</summary>
		D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ALLOW_HIGH_PRECISION_MV = 0x4000,
	}

	/// <summary>
	/// <para>
	/// Specifies for which AV1 encoding features, the underlying encoder is able to override (partially or totally) the associated AV1
	/// syntax values or honor API Client exact configuration input otherwise.
	/// </para>
	/// <para>
	/// When the bitflag is SET for a given feature, the driver receives the related API Client input and is able to override all or certain
	/// parameters of the associated structure with the given reported flag, which will then write back in
	/// D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES with the final values for the API Client to re-pack the AV1 headers accordingly. API
	/// Client can compare this to the associated input structure to determine the driver changes (if any).
	/// </para>
	/// <para>
	/// When the bitflag is NOT SET for a given feature, the driver honors the related API Client input exactly and copies the input values
	/// in D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES. This way the client can always copy the post encode values to pack the headers directly.
	/// </para>
	/// </summary>
	[PInvokeData("d3d12video.h")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAGS
	{
		/// <summary/>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_NONE = 0,

		/// <summary>Related to D3D12VIDEO_ENCODER_CODEC_AV1_QUANTIZATION_CONFIG values. Used to code _quantization_params().</summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_QUANTIZATION = 0x1,

		/// <summary>Related to D3D12VIDEO_ENCODER_CODEC_AV1_QUANTIZATION_DELTA_CONFIG values. Used to code _delta_q_params().</summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_QUANTIZATION_DELTA = 0x2,

		/// <summary>Related to D3D12VIDEO_ENCODER_CODEC_AV1_LOOP_FILTER_CONFIG values. Used to code AV1 syntax _loop_filter_params().</summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_LOOP_FILTER = 0x4,

		/// <summary>Related to D3D12VIDEO_ENCODER_CODEC_AV1_LOOP_FILTER_DELTA_CONFIG values. Used to code AV1 syntax _delta_lf_params().</summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_LOOP_FILTER_DELTA = 0x8,

		/// <summary>Related to D3D12VIDEO_ENCODER_AV1_CDEF_CONFIG values. Used to code AV1 syntax _cdef_params().</summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_CDEF_DATA = 0x10,

		/// <summary>
		/// Related to ContextUpdateTileId element in D3D12VIDEO_ENCODER_AV1_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_TILES. Used to code AV1
		/// element syntax _context_update_tile_id in tile_info().
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_CONTEXT_UPDATE_TILE_ID = 0x20,

		/// <summary>Related to D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE values.</summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// When API Client selects D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE_COMPOUND_REFERENCE and this flag is set, the driver will
		/// return D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE in post encode values. The returned value must be used to code
		/// reference_select = 0 (SINGLE) or reference_select = 1 (COMPOUND) syntax accordingly.
		/// </item>
		/// <item>
		/// When API Client selects D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE_COMPOUND_SINGLE and this flag is set, the driver will
		/// return D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE_COMPOUND_SINGLE and reference_select must be coded as 0 (SINGLE).
		/// </item>
		/// </list>
		/// </remarks>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_COMPOUND_PREDICTION_MODE = 0x40,

		/// <summary>
		/// Related to PrimaryRefFrame element in D3D12VIDEO_ENCODER_AV1_PICTURE_CONTROL_CODEC_DATA. Used to code AV1 element syntax
		/// _primary_ref_frame in uncompressed_header().
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_PRIMARY_REF_FRAME = 0x80,

		/// <summary>
		/// <para>
		/// When the flag is reported by the driver, the driver may reorder/remap (but not change the number of references) of the
		/// D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES.ReferenceIndices array output, based on the user input
		/// D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_CODEC_DATA.ReferenceIndices. Otherwise, driver must copy each array entry of this post
		/// encode output parameter as-is from D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_CODEC_DATA.ReferenceIndices.
		/// </para>
		/// <para>API Client will write the picture header ref_frame_idx AV1 syntax from this output parameter.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_REFERENCE_INDICES = 0x100
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PROFILE_DESC")]
	public enum D3D12_VIDEO_ENCODER_AV1_PROFILE
	{
		D3D12_VIDEO_ENCODER_AV1_PROFILE_MAIN = 0,
		D3D12_VIDEO_ENCODER_AV1_PROFILE_HIGH = 1,
		D3D12_VIDEO_ENCODER_AV1_PROFILE_PROFESSIONAL = 2
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	public enum D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION
	{
		/// <summary>Identity transformation. 0 parameters in D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_WARPED_MOTION_INFO.</summary>
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_IDENTITY = 0,

		/// <summary>Translational motion. 2 parameters in D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_WARPED_MOTION_INFO.</summary>
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_TRANSLATION = 1,

		/// <summary>Simplified affine with rotation with zoom. 4 parameters in D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_WARPED_MOTION_INFO.</summary>
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_ROTZOOM = 2,

		/// <summary>Affine transform. 6 parameters in D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_WARPED_MOTION_INFO.</summary>
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_AFFINE = 3,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_FLAGS
	{
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_FLAG_NONE = 0,
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_FLAG_IDENTITY = 1 << D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION.D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_IDENTITY,
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_FLAG_TRANSLATION = 1 << D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION.D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_TRANSLATION,
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_FLAG_ROTZOOM = 1 << D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION.D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_ROTZOOM,
		D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_FLAG_AFFINE = 1 << D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION.D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_AFFINE,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAGS : uint
	{
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAG_NOT_SUPPORTED = 0,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAG_32x32 = 0x1,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAG_64x64 = 0x2,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAG_128x128 = 0x4,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAG_256x256 = 0x8
	}

	/// <summary>
	/// Corresponds to the the size of loop restoration units in units of samples in the current plane. The enum values are based on
	/// lr_unit_shift and lr_uv_shift in lr_params() AV1 syntax and the RESTORATION_TILESIZE_MAX(256) AV1 spec constant.
	/// </summary>
	[PInvokeData("d3d12video.h")]
	public enum D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE
	{
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE_DISABLED = 0,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE_32x32 = 1,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE_64x64 = 2,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE_128x128 = 3,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE_256x256 = 4,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	public enum D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE
	{
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE_DISABLED = 0,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE_SWITCHABLE = 1,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE_WIENER = 2,
		D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE_SGRPROJ = 3,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	public enum D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_BLOCK_SIZE
	{
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_BLOCK_SIZE_4x4 = 0,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_BLOCK_SIZE_8x8 = 1,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_BLOCK_SIZE_16x16 = 2,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_BLOCK_SIZE_32x32 = 3,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_BLOCK_SIZE_64x64 = 4
	}

	public enum D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE
	{
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_DISABLED = 0,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_Q = 1,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_Y_V = 2,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_Y_H = 3,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_U = 4,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_V = 5,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_REF_FRAME = 6,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_SKIP = 7,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_GLOBALMV = 8,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAGS
	{
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_NONE = 0,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_DISABLED = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_DISABLED,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_ALT_Q = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_Q,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_ALT_LF_Y_V = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_Y_V,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_ALT_LF_Y_H = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_Y_H,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_ALT_LF_U = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_U,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_ALT_LF_V = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_LF_V,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_REF_FRAME = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_REF_FRAME,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_ALT_SKIP = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_SKIP,
		D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAG_ALT_GLOBALMV = 1 << D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE.D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_ALT_GLOBALMV
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_LEVEL_SETTING")]
	public enum D3D12_VIDEO_ENCODER_AV1_TIER
	{
		D3D12_VIDEO_ENCODER_AV1_TIER_MAIN = 0,
		D3D12_VIDEO_ENCODER_AV1_TIER_HIGH = 1,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	public enum D3D12_VIDEO_ENCODER_AV1_TX_MODE
	{
		D3D12_VIDEO_ENCODER_AV1_TX_MODE_ONLY4x4 = 0,
		D3D12_VIDEO_ENCODER_AV1_TX_MODE_LARGEST = 1,
		D3D12_VIDEO_ENCODER_AV1_TX_MODE_SELECT = 2,
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_AV1_TX_MODE_FLAGS
	{
		D3D12_VIDEO_ENCODER_AV1_TX_MODE_FLAG_NONE = 0,
		D3D12_VIDEO_ENCODER_AV1_TX_MODE_FLAG_ONLY4x4 = 1 << D3D12_VIDEO_ENCODER_AV1_TX_MODE.D3D12_VIDEO_ENCODER_AV1_TX_MODE_ONLY4x4,
		D3D12_VIDEO_ENCODER_AV1_TX_MODE_FLAG_LARGEST = 1 << D3D12_VIDEO_ENCODER_AV1_TX_MODE.D3D12_VIDEO_ENCODER_AV1_TX_MODE_LARGEST,
		D3D12_VIDEO_ENCODER_AV1_TX_MODE_FLAG_SELECT = 1 << D3D12_VIDEO_ENCODER_AV1_TX_MODE.D3D12_VIDEO_ENCODER_AV1_TX_MODE_SELECT
	}

	/// <summary>Specifies codecs for Direct3D 12 video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec typedef enum
	// D3D12_VIDEO_ENCODER_CODEC { D3D12_VIDEO_ENCODER_CODEC_H264, D3D12_VIDEO_ENCODER_CODEC_HEVC, D3D12_VIDEO_ENCODER_CODEC_AV1 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC")]
	public enum D3D12_VIDEO_ENCODER_CODEC
	{
		/// <summary>H.264 video</summary>
		D3D12_VIDEO_ENCODER_CODEC_H264,

		/// <summary>High Efficiency Video Coding (HEVC) video</summary>
		D3D12_VIDEO_ENCODER_CODEC_HEVC,

		/// <summary/>
		D3D12_VIDEO_ENCODER_CODEC_AV1
	}

	/// <summary>Specifies direct modes for H.264 video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_h264_direct_modes
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES {
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES_DISABLED,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES_TEMPORAL, D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES_SPATIAL
	// } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES")]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES
	{
		/// <summary>Direct modes disabled.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES_DISABLED,

		/// <summary>
		/// <para>Enables Direct temporal mode. Please check for support in D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_FLAGS_H264_DIRECT_TEMPORAL_ENCODING_SUPPORT.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES_TEMPORAL,

		/// <summary>
		/// <para>Enables Direct spatial mode. Please check for support in D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_FLAGS_H264_DIRECT_SPATIAL_ENCODING_SUPPORT.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES_SPATIAL,
	}

	/// <summary>Specifies configuration flags for H.264 video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_h264_flags
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAGS { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_USE_CONSTRAINED_INTRAPREDICTION,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_USE_ADAPTIVE_8x8_TRANSFORM,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_ENABLE_CABAC_ENCODING,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_ALLOW_REQUEST_INTRA_CONSTRAINED_SLICES } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>
		/// Forces the encoding of each intra-coded block with residual data only from other intra-coded blocks, i.e. not from inter-coded
		/// blocks, in the frame. Check for support in
		/// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_CONSTRAINED_INTRAPREDICTION_SUPPORT. This refers to
		/// constrained_intra_pred_flag in the picture parameter set (PPS).
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_USE_CONSTRAINED_INTRAPREDICTION = 0x1,

		/// <summary>
		/// <para>Enables the usage of adaptive 8x8 transform. Please check for support in D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_ADAPTIVE_8x8_TRANSFORM_ENCODING_SUPPORT.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_USE_ADAPTIVE_8x8_TRANSFORM = 0x2,

		/// <summary>
		/// <para>Enables CABAC entropy coding. If turned off, will use CAVLC. Please check for support in D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_CABAC_ENCODING_SUPPORT.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_ENABLE_CABAC_ENCODING = 0x4,

		/// <summary>
		/// Allows the caller to request for each frame with a special flag in the picture control structure that the slices of such frame
		/// are coded independently from each other. This mode restricts the motion vector search range to the region box of the current
		/// slice, i.e. motion vectors outside the slice boundary can't be used.
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_ALLOW_REQUEST_INTRA_CONSTRAINED_SLICES = 0x8,
	}

	/// <summary>
	/// A flags enumeration allowing bitwise OR combinations of values from the
	/// <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES</c> which specifies the slice deblocking mode as defined by
	/// the disable_deblocking_filter_idc syntax in the H.264 specification.
	/// </summary>
	/// <remarks>
	/// Values from this enumeration are used by the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264</c> structure for checking
	/// feature support.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_h264_slices_deblocking_mode_flags
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAGS {
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_0_ALL_LUMA_CHROMA_SLICE_BLOCK_EDGES_ALWAYS_FILTERED,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_1_DISABLE_ALL_SLICE_BLOCK_EDGES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_2_DISABLE_SLICE_BOUNDARIES_BLOCKS,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_3_USE_TWO_STAGE_DEBLOCKING,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_4_DISABLE_CHROMA_BLOCK_EDGES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_5_DISABLE_CHROMA_BLOCK_EDGES_AND_LUMA_BOUNDARIES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_6_DISABLE_CHROMA_BLOCK_EDGES_AND_USE_LUMA_TWO_STAGE_DEBLOCKING
	// } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>value of 0. All luma and chroma block edges of the slice are filtered.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_0_ALL_LUMA_CHROMA_SLICE_BLOCK_EDGES_ALWAYS_FILTERED =
			1 << D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_0_ALL_LUMA_CHROMA_SLICE_BLOCK_EDGES_ALWAYS_FILTERED,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>value of 1. Deblocking is disabled for all block edges of the slice.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_1_DISABLE_ALL_SLICE_BLOCK_EDGES =
			1 << D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_1_DISABLE_ALL_SLICE_BLOCK_EDGES,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// value of 2. All luma and chroma block edges of the slice are filtered with exception of the block edges that coincide with slice boundaries
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_2_DISABLE_SLICE_BOUNDARIES_BLOCKS =
			1 << D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_2_DISABLE_SLICE_BOUNDARIES_BLOCKS,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// value of 3. A two stage deblocking filter process for the slice: After filtering all block luma and chroma block edges that do
		/// not coincide with slice boundaries (as if disable_deblocking_filter_idc were equal to 2), the luma and chroma block edges that
		/// coincide with slice boundaries are filtered.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_3_USE_TWO_STAGE_DEBLOCKING =
			1 << D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_3_USE_TWO_STAGE_DEBLOCKING,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>value of 4. All luma block edges of the slice are filtered, but the Rec. ITU-T H.264 (06/2019) 477</para>
		/// <para>deblocking of the chroma block edges is disabled.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_4_DISABLE_CHROMA_BLOCK_EDGES =
			1 << D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_4_DISABLE_CHROMA_BLOCK_EDGES,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// value of 5. All luma block edges of the slice are filtered with exception of the block edges that coincide with slice boundaries
		/// (as if disable_deblocking_filter_idc were equal to 2), and that deblocking for chroma block edges of the slice is disabled. 5
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_5_DISABLE_CHROMA_BLOCK_EDGES_AND_LUMA_BOUNDARIES =
			1 << D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_5_DISABLE_CHROMA_BLOCK_EDGES_AND_LUMA_BOUNDARIES,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// of 6. The deblocking for chroma block edges is disabled and that the two stage deblocking filter process is used for luma block
		/// edges of the slice: After filtering all block luma block edges that do not coincide with slice boundaries (as if
		/// disable_deblocking_filter_idc were equal to 2), the luma block edges that coincide
		/// </para>
		/// <para>with slice boundaries are filtered.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAG_6_DISABLE_CHROMA_BLOCK_EDGES_AND_USE_LUMA_TWO_STAGE_DEBLOCKING =
			1 << D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_6_DISABLE_CHROMA_BLOCK_EDGES_AND_USE_LUMA_TWO_STAGE_DEBLOCKING,
	}

	/// <summary>Specifies the slice deblocking mode as defined by the disable_deblocking_filter_idc syntax in the H.264 specification.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_h264_slices_deblocking_modes
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES {
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_0_ALL_LUMA_CHROMA_SLICE_BLOCK_EDGES_ALWAYS_FILTERED,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_1_DISABLE_ALL_SLICE_BLOCK_EDGES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_2_DISABLE_SLICE_BOUNDARIES_BLOCKS,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_3_USE_TWO_STAGE_DEBLOCKING,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_4_DISABLE_CHROMA_BLOCK_EDGES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_5_DISABLE_CHROMA_BLOCK_EDGES_AND_LUMA_BOUNDARIES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_6_DISABLE_CHROMA_BLOCK_EDGES_AND_USE_LUMA_TWO_STAGE_DEBLOCKING } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES")]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES
	{
		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>value of 0. All luma and chroma block edges of the slice are filtered.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_0_ALL_LUMA_CHROMA_SLICE_BLOCK_EDGES_ALWAYS_FILTERED,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>value of 1. Deblocking is disabled for all block edges of the slice.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_1_DISABLE_ALL_SLICE_BLOCK_EDGES,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// value of 2. All luma and chroma block edges of the slice are filtered with exception of the block edges that coincide with slice boundaries.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_2_DISABLE_SLICE_BOUNDARIES_BLOCKS,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// value of 3. A two stage deblocking filter process for the slice: After filtering all block luma and chroma block edges that do
		/// not coincide with slice boundaries (as if disable_deblocking_filter_idc were equal to 2), the luma and chroma block edges that
		/// coincide with slice boundaries are filtered.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_3_USE_TWO_STAGE_DEBLOCKING,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>value of 4. All luma block edges of the slice are filtered, but the Rec. ITU-T H.264 (06/2019) 477</para>
		/// <para>deblocking of the chroma block edges is disabled.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_4_DISABLE_CHROMA_BLOCK_EDGES,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// value of 5. All luma block edges of the slice are filtered with exception of the block edges that coincide with slice boundaries
		/// (as if disable_deblocking_filter_idc were equal to 2), and that deblocking for chroma block edges of the slice is disabled. 5
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_5_DISABLE_CHROMA_BLOCK_EDGES_AND_LUMA_BOUNDARIES,

		/// <summary>
		/// <para>disable_deblocking_filter_idc</para>
		/// <para>
		/// of 6. The deblocking for chroma block edges is disabled and that the two stage deblocking filter process is used for luma block
		/// edges of the slice: After filtering all block luma block edges that do not coincide with slice boundaries (as if
		/// disable_deblocking_filter_idc were equal to 2), the luma block edges that coincide
		/// </para>
		/// <para>with slice boundaries are filtered.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_6_DISABLE_CHROMA_BLOCK_EDGES_AND_USE_LUMA_TWO_STAGE_DEBLOCKING,
	}

	/// <summary>Specifies possible values for luma coding block sizes for HEVC.</summary>
	/// <remarks>These values can be used to express HEVC variables such as MinCbSizeY, CtbLog2SizeY.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_hevc_cusize
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_8x8,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_16x16, D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_32x32,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_64x64 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE")]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE
	{
		/// <summary>Luma coding block of pixel size 8.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_8x8,

		/// <summary>Luma coding block of pixel size 16.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_16x16,

		/// <summary>Luma coding block of pixel size 32.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_32x32,

		/// <summary>Luma coding block of pixel size 64.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_64x64,
	}

	/// <summary>Specifies configuration flags for HEVC video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_hevc_flags
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAGS { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_DISABLE_LOOP_FILTER_ACROSS_SLICES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ALLOW_REQUEST_INTRA_CONSTRAINED_SLICES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_SAO_FILTER,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_LONG_TERM_REFERENCES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_USE_ASYMETRIC_MOTION_PARTITION,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_TRANSFORM_SKIPPING,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_USE_CONSTRAINED_INTRAPREDICTION } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_NONE = 0x0,

		/// <summary>Disables loop filtering across slices.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_DISABLE_LOOP_FILTER_ACROSS_SLICES = 0x1,

		/// <summary>
		/// Allows the usage of the intra constrained slices flag in picture control. This mode restricts the motion vector search range to
		/// the region box of the current slice, i.e. motion vectors outside the slice boundary can't be used.
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ALLOW_REQUEST_INTRA_CONSTRAINED_SLICES = 0x2,

		/// <summary>Enables the sample adaptive offset filter.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_SAO_FILTER = 0x4,

		/// <summary>Enables the usage of long term references in the picture reference management structures for HEVC.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_LONG_TERM_REFERENCES = 0x8,

		/// <summary>
		/// <para>Enables asymetric motion partitioning.</para>
		/// <note>If D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_ASYMETRIC_MOTION_PARTITION_REQUIRED was reported, this flag
		/// must be enabled.</note>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_USE_ASYMETRIC_MOTION_PARTITION = 0x10,

		/// <summary>Enables transform skipping.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_TRANSFORM_SKIPPING = 0x20,

		/// <summary>Enables constrained intra prediction. This refers to constrained_intra_pred_flag in the PPS.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_USE_CONSTRAINED_INTRAPREDICTION = 0x40,
	}

	/// <summary>Specifies possible values for luma transform block sizes for HEVC.</summary>
	/// <remarks>These values can then be used to express HEVC variables such as MinTbLog2SizeY, MaxTbLog2SizeY.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_hevc_tusize
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_4x4,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_8x8, D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_16x16,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_32x32 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE")]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE
	{
		/// <summary>Indicates a luma transform block of pixel size 4.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_4x4,

		/// <summary>Indicates a luma transform block of pixel size 8.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_8x8,

		/// <summary>Indicates a luma transform block of pixel size 16.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_16x16,

		/// <summary>Indicates a luma transform block of pixel size 32.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_32x32,
	}

	/// <summary>Specifies configuration support flags for H.264 video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_support_h264_flags
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAGS {
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_CABAC_ENCODING_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_INTRA_SLICE_CONSTRAINED_ENCODING_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_BFRAME_LTR_COMBINED_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_ADAPTIVE_8x8_TRANSFORM_ENCODING_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_DIRECT_SPATIAL_ENCODING_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_DIRECT_TEMPORAL_ENCODING_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_CONSTRAINED_INTRAPREDICTION_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE_SUPPORT } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_NONE = 0x0,

		/// <summary>Support for context-adaptive binary arithmetic coding (CABAC) encoding.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_CABAC_ENCODING_SUPPORT = 0x1,

		/// <summary>
		/// Support for slice constrained encoding in which every slice in a frame is encoded independently from other slices in the same
		/// frame. This mode restricts the motion vector search range to the region box of the current slice, e.g. motion vectors outside
		/// the slice boundary can't be used.
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_INTRA_SLICE_CONSTRAINED_ENCODING_SUPPORT = 0x2,

		/// <summary>Support for using B-frames and long term references at the same time.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_BFRAME_LTR_COMBINED_SUPPORT = 0x4,

		/// <summary>Support for using adaptive 8x8 transforms when encoding.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_ADAPTIVE_8x8_TRANSFORM_ENCODING_SUPPORT = 0x8,

		/// <summary>Support for spatial direct mode.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_DIRECT_SPATIAL_ENCODING_SUPPORT = 0x10,

		/// <summary>Support for temporal direct mode.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_DIRECT_TEMPORAL_ENCODING_SUPPORT = 0x20,

		/// <summary>
		/// Support for constrained intraprediction, that if activated will force the encoding of each intra-coded block with residual data
		/// only from other intra-coded blocks, e.g. not from inter-coded blocks. This refers to constrained_intra_pred_flag in the picture
		/// parameter set (PPS).
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_CONSTRAINED_INTRAPREDICTION_SUPPORT = 0x40,

		/// <summary/>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAG_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE_SUPPORT = 0x80
	}

	/// <summary>Specifies configuration support flags for HEVC video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_codec_configuration_support_hevc_flags
	// typedef enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAGS {
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_BFRAME_LTR_COMBINED_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_INTRA_SLICE_CONSTRAINED_ENCODING_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_CONSTRAINED_INTRAPREDICTION_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_SAO_FILTER_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_ASYMETRIC_MOTION_PARTITION_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_ASYMETRIC_MOTION_PARTITION_REQUIRED,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_TRANSFORM_SKIP_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_DISABLING_LOOP_FILTER_ACROSS_SLICES_SUPPORT,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_P_FRAMES_IMPLEMENTED_AS_LOW_DELAY_B_FRAMES,
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE_SUPPORT } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_NONE = 0x0,

		/// <summary>Support for usage of B frames and long term references frames simultaneously.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_BFRAME_LTR_COMBINED_SUPPORT = 0x1,

		/// <summary>
		/// Support for slice-contrained encoding, in which every slice in a frame is encoded independently from other slices in the same
		/// frame. This mode restricts the motion vector search range to the region box of the current slice, e.g. motion vectors outside
		/// the slice boundary can't be used.
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_INTRA_SLICE_CONSTRAINED_ENCODING_SUPPORT = 0x2,

		/// <summary>
		/// Support for constrained intraprediction, that if activated will force the encoding of each intra-coded block with residual data
		/// only from other intra-coded blocks, e.g. not from inter-coded blocks. This refers to constrained_intra_pred_flag in the picture
		/// parameter set (PPS).
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_CONSTRAINED_INTRAPREDICTION_SUPPORT = 0x4,

		/// <summary>Support for sample adaptive offset.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_SAO_FILTER_SUPPORT = 0x8,

		/// <summary>Support for asymmetric motion partition.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_ASYMETRIC_MOTION_PARTITION_SUPPORT = 0x10,

		/// <summary>
		/// Asymmetric motion partition must be always enabled. If this flag is set,
		/// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_ASYMETRIC_MOTION_PARTITION_SUPPORT must also be set.
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_ASYMETRIC_MOTION_PARTITION_REQUIRED = 0x20,

		/// <summary>Support for transform skip.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_TRANSFORM_SKIP_SUPPORT = 0x40,

		/// <summary>Support for disabling loop filter across slices.</summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_DISABLING_LOOP_FILTER_ACROSS_SLICES_SUPPORT = 0x80,

		/// <summary>
		/// <para>
		/// When this flag is set, indicates that when encoding frames with type D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_P_FRAME , they will be
		/// written as low delay B-Frames in the compressed bitstream. When this flag is not set, indicates that P frames will be written in
		/// the compressed bitstream. Note When operating under this mode, it is the caller's responsibility to code the correct frame type
		/// in AUD_NUT and other parts of the HEVC bitstream, taking into account that P frames will be treated as generalized B frames with
		/// only references to past frames in POC order.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_P_FRAMES_IMPLEMENTED_AS_LOW_DELAY_B_FRAMES = 0x100,

		/// <summary/>
		D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE_SUPPORT = 0x200
	}

	/// <summary>Specifies errors encountered during the <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c> operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_encode_error_flags typedef enum
	// D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAGS { D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_NO_ERROR,
	// D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_CODEC_PICTURE_CONTROL_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_SUBREGION_LAYOUT_CONFIGURATION_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_INVALID_REFERENCE_PICTURES,
	// D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_RECONFIGURATION_REQUEST_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_INVALID_METADATA_BUFFER_SOURCE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAGS
	{
		/// <summary>No error.</summary>
		D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_NO_ERROR = 0x0,

		/// <summary>Specified codec picture control not supported.</summary>
		D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_CODEC_PICTURE_CONTROL_NOT_SUPPORTED = 0x1,

		/// <summary>Specified subregion layout subregion not supported.</summary>
		D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_SUBREGION_LAYOUT_CONFIGURATION_NOT_SUPPORTED = 0x2,

		/// <summary>Invalid reference pictures provided.</summary>
		D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_INVALID_REFERENCE_PICTURES = 0x4,

		/// <summary>Reconfiguration request is unsupported.</summary>
		D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_RECONFIGURATION_REQUEST_NOT_SUPPORTED = 0x8,

		/// <summary>Invalid metadata buffer source.</summary>
		D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG_INVALID_METADATA_BUFFER_SOURCE = 0x10,
	}

	/// <summary>Specifies flags for video encoder creation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_flags typedef enum
	// D3D12_VIDEO_ENCODER_FLAGS { D3D12_VIDEO_ENCODER_FLAG_NONE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_FLAG_NONE,
	}

	/// <summary>Specifies video encoder frame subregion layout modes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_frame_subregion_layout_mode typedef
	// enum D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE { D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_FULL_FRAME,
	// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_BYTES_PER_SUBREGION,
	// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_SQUARE_UNITS_PER_SUBREGION_ROW_UNALIGNED,
	// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_ROWS_PER_SUBREGION,
	// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_SUBREGIONS_PER_FRAME,
	// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_GRID_PARTITION,
	// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_CONFIGURABLE_GRID_PARTITION } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE")]
	public enum D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE
	{
		/// <summary>Full frame output support.</summary>
		D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_FULL_FRAME,

		/// <summary>Frame subregions are set as a number of bytes per subregion.</summary>
		D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_BYTES_PER_SUBREGION,

		/// <summary>
		/// Frame subregions are set as a number of squared blocks per subregion. The number of squared blocks does not need to be multiple
		/// of a row size in squared blocks (e.g. if the subregions don't need to be row-aligned). To set row-aligned number of squared
		/// blocks per subregion, use the D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_ROWS_PER_SUBREGION or
		/// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_SUBREGIONS_PER_FRAME mode.
		/// </summary>
		D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_SQUARE_UNITS_PER_SUBREGION_ROW_UNALIGNED,

		/// <summary>
		/// <para>
		/// Frames are divided into a number of slices determined by the number of rows per slice. The size in pixels of the rows can be
		/// calculated using the current resolution and
		/// </para>
		/// <para>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.SubregionBlockPixelsSize</para>
		/// <para>for the current frame resolution.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_ROWS_PER_SUBREGION,

		/// <summary>Frames are divided into the specified number of slices.</summary>
		D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_SUBREGIONS_PER_FRAME,

		/// <summary/>
		D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_GRID_PARTITION,

		/// <summary/>
		D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_CONFIGURABLE_GRID_PARTITION
	}

	/// <summary>Specifies the type of an H.264 video frame.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_frame_type_h264 typedef enum
	// D3D12_VIDEO_ENCODER_FRAME_TYPE_H264 { D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_I_FRAME, D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_P_FRAME,
	// D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_B_FRAME, D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_IDR_FRAME } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_FRAME_TYPE_H264")]
	public enum D3D12_VIDEO_ENCODER_FRAME_TYPE_H264
	{
		/// <summary>I-Frame. Completely intra-coded frame.</summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_I_FRAME,

		/// <summary>P-Frame. Allows references to past frames.</summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_P_FRAME,

		/// <summary>B-Frame. Allows references to both past and future (in display order) frames.</summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_B_FRAME,

		/// <summary>
		/// Instantaneous decode refresh frame. Special type of I-frame where no frame after it can reference any frame before it.
		/// </summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_IDR_FRAME,
	}

	/// <summary>Specifies the type of an HEVC video frame.</summary>
	/// <remarks>
	/// <para>The following table lists the expected HEVC header frame type for each HEVC frame type value.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Syntax element</description>
	/// <description>Expected default value</description>
	/// </listheader>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_I_FRAME</description>
	/// <description>nal_unit_type = CRA_NUT</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_P_FRAME</description>
	/// <description>nal_unit_type = TRAIL_R</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_B_FRAME</description>
	/// <description>nal_unit_type = TRAIL_R</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_IDR_FRAME</description>
	/// <description>nal_unit_type = IDR_W_RADL</description>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAG_P_FRAMES_IMPLEMENTED_AS_LOW_DELAY_B_FRAMES</c> is set, it informs
	/// the caller that when encoding frames with type <b>D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_P_FRAME</b>, they will be written as low delay
	/// B-Frames in the compressed bitstream. If bit is not set, it informs the caller P frames will be written in the compressed bitstream.
	/// Note that When operating under this mode, is the caller's responsibility to code the correct frame type in AUD_NUT and other parts
	/// of the HEVC bitstream, taking into account that P frames will be treated as generalized B frames with only references to past frames
	/// in POC order.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_frame_type_hevc typedef enum
	// D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC { D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_I_FRAME, D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_P_FRAME,
	// D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_B_FRAME, D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_IDR_FRAME } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC")]
	public enum D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC
	{
		/// <summary>I-Frame. Completely intra-coded frame.</summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_I_FRAME,

		/// <summary>P-Frame. Allows references to past frames.</summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_P_FRAME,

		/// <summary>B-Frame. Allows references to both past and future (in display order) frames.</summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_B_FRAME,

		/// <summary>
		/// Instantaneous decode refresh frame. A special type of I-frame where no frame after it can reference any frame before it.
		/// </summary>
		D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC_IDR_FRAME,
	}

	/// <summary>Specifies heap options for video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_heap_flags typedef enum
	// D3D12_VIDEO_ENCODER_HEAP_FLAGS { D3D12_VIDEO_ENCODER_HEAP_FLAG_NONE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_HEAP_FLAGS")]
	public enum D3D12_VIDEO_ENCODER_HEAP_FLAGS
	{
		/// <summary>No flags.</summary>
		D3D12_VIDEO_ENCODER_HEAP_FLAG_NONE,
	}

	/// <summary>Specifies video encoder intra refresh modes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_intra_refresh_mode typedef enum
	// D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE { D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE_NONE,
	// D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE_ROW_BASED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE")]
	public enum D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE
	{
		/// <summary>The encoder does not use intra refresh.</summary>
		D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE_NONE,

		/// <summary>Row-based intra refresh mode.</summary>
		D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE_ROW_BASED,
	}

	/// <summary>Specifies the encoder levels for H.264 encoding.</summary>
	/// <remarks>Use this enumeration to specify the encoder level in a <c>D3D12_VIDEO_ENCODER_LEVEL_SETTING</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_levels_h264 typedef enum
	// D3D12_VIDEO_ENCODER_LEVELS_H264 { D3D12_VIDEO_ENCODER_LEVELS_H264_1, D3D12_VIDEO_ENCODER_LEVELS_H264_1b,
	// D3D12_VIDEO_ENCODER_LEVELS_H264_11, D3D12_VIDEO_ENCODER_LEVELS_H264_12, D3D12_VIDEO_ENCODER_LEVELS_H264_13,
	// D3D12_VIDEO_ENCODER_LEVELS_H264_2, D3D12_VIDEO_ENCODER_LEVELS_H264_21, D3D12_VIDEO_ENCODER_LEVELS_H264_22,
	// D3D12_VIDEO_ENCODER_LEVELS_H264_3, D3D12_VIDEO_ENCODER_LEVELS_H264_31, D3D12_VIDEO_ENCODER_LEVELS_H264_32,
	// D3D12_VIDEO_ENCODER_LEVELS_H264_4, D3D12_VIDEO_ENCODER_LEVELS_H264_41, D3D12_VIDEO_ENCODER_LEVELS_H264_42,
	// D3D12_VIDEO_ENCODER_LEVELS_H264_5, D3D12_VIDEO_ENCODER_LEVELS_H264_51, D3D12_VIDEO_ENCODER_LEVELS_H264_52,
	// D3D12_VIDEO_ENCODER_LEVELS_H264_6, D3D12_VIDEO_ENCODER_LEVELS_H264_61, D3D12_VIDEO_ENCODER_LEVELS_H264_62 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_LEVELS_H264")]
	public enum D3D12_VIDEO_ENCODER_LEVELS_H264
	{
		/// <summary>Level 1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_1,

		/// <summary>Level 1b.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_1b,

		/// <summary>Level 1.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_11,

		/// <summary>Level 1.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_12,

		/// <summary>Level 1.3.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_13,

		/// <summary>Level 2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_2,

		/// <summary>Level 2.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_21,

		/// <summary>Level 2.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_22,

		/// <summary>Level 3.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_3,

		/// <summary>Level 3.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_31,

		/// <summary>Level 3.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_32,

		/// <summary>Level 4.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_4,

		/// <summary>Level 4.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_41,

		/// <summary>Level 4.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_42,

		/// <summary>Level 5.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_5,

		/// <summary>Level 5.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_51,

		/// <summary>Level 5.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_52,

		/// <summary>Level 6.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_6,

		/// <summary>Level 6.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_61,

		/// <summary>Level 6.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_H264_62,
	}

	/// <summary>Specifies the encoder levels for High Efficiency Video Coding (HEVC) encoding.</summary>
	/// <remarks>Use this enumeration to specify the encoder tier in a <c>D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_levels_hevc typedef enum
	// D3D12_VIDEO_ENCODER_LEVELS_HEVC { D3D12_VIDEO_ENCODER_LEVELS_HEVC_1, D3D12_VIDEO_ENCODER_LEVELS_HEVC_2,
	// D3D12_VIDEO_ENCODER_LEVELS_HEVC_21, D3D12_VIDEO_ENCODER_LEVELS_HEVC_3, D3D12_VIDEO_ENCODER_LEVELS_HEVC_31,
	// D3D12_VIDEO_ENCODER_LEVELS_HEVC_4, D3D12_VIDEO_ENCODER_LEVELS_HEVC_41, D3D12_VIDEO_ENCODER_LEVELS_HEVC_5,
	// D3D12_VIDEO_ENCODER_LEVELS_HEVC_51, D3D12_VIDEO_ENCODER_LEVELS_HEVC_52, D3D12_VIDEO_ENCODER_LEVELS_HEVC_6,
	// D3D12_VIDEO_ENCODER_LEVELS_HEVC_61, D3D12_VIDEO_ENCODER_LEVELS_HEVC_62 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_LEVELS_HEVC")]
	public enum D3D12_VIDEO_ENCODER_LEVELS_HEVC
	{
		/// <summary>Level 1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_1,

		/// <summary>Level 2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_2,

		/// <summary>Level 2.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_21,

		/// <summary>Level 3.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_3,

		/// <summary>Level 3.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_31,

		/// <summary>Level 4.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_4,

		/// <summary>Level 4.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_41,

		/// <summary>Level 5.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_5,

		/// <summary>Level 5.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_51,

		/// <summary>Level 5.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_52,

		/// <summary>Level 6.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_6,

		/// <summary>Level 6.1.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_61,

		/// <summary>Level 6.2.</summary>
		D3D12_VIDEO_ENCODER_LEVELS_HEVC_62,
	}

	/// <summary>Specifies motion estimation precision modes for video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_motion_estimation_precision_mode
	// typedef enum D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE { D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_MAXIMUM,
	// D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_FULL_PIXEL, D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_HALF_PIXEL,
	// D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_QUARTER_PIXEL, D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_EIGHTH_PIXEL
	// } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE")]
	public enum D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE
	{
		/// <summary>
		/// No limit in the precision for motion estimation vectors. This mode allows the maximum precision supported by the driver.
		/// </summary>
		D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_MAXIMUM,

		/// <summary>The precision for motion estimation vectors has to be at most full pixel.</summary>
		D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_FULL_PIXEL,

		/// <summary>The precision for motion estimation vectors has to be at most half pixel.</summary>
		D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_HALF_PIXEL,

		/// <summary>The precision for motion estimation vectors has to be at most quarter pixel.</summary>
		D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_QUARTER_PIXEL,

		/// <summary>The precision for motion estimation vectors has to be at most eigths pixel.</summary>
		D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE_EIGHTH_PIXEL
	}

	/// <summary>Specifies flags for the H.264-specific picture control properties.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_picture_control_codec_data_h264_flags
	// typedef enum D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAGS {
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAG_REQUEST_INTRA_CONSTRAINED_SLICES,
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAG_REQUEST_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>
		/// Requests slice-constrained encoding for a frame, in which every slice in the frame is encoded independently from other slices in
		/// the same frame. Check for support in
		/// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_FLAGS_H264_INTRA_SLICE_CONSTRAINED_ENCODING_SUPPORT . This mode restricts the
		/// motion vector search range to the region box of the current slice, i.e. motion vectors outside the slice boundary can't be used.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAG_REQUEST_INTRA_CONSTRAINED_SLICES = 0x1,

		/// <summary/>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAG_REQUEST_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE = 0x2
	}

	/// <summary>Specifies flags for the HEVC-specific picture control properties.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_picture_control_codec_data_hevc_flags
	// typedef enum D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAGS {
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAG_REQUEST_INTRA_CONSTRAINED_SLICES,
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAG_REQUEST_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>
		/// Requests slice constrained encoding for a frame, in which every slice in the frame is encoded independently from other slices in
		/// the same frame. Please check for support in
		/// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_FLAGS_HEVC_INTRA_SLICE_CONSTRAINED_ENCODING_SUPPORT . This mode restricts the
		/// motion vector search range to the region box of the current slice, i.e. motion vectors outside the slice boundary can't be used.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAG_REQUEST_INTRA_CONSTRAINED_SLICES = 0x1,

		/// <summary/>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAG_REQUEST_NUM_REF_IDX_ACTIVE_OVERRIDE_FLAG_SLICE = 0x2
	}

	/// <summary>Specifies video encoder picture control flags.</summary>
	/// <remarks>
	/// <para>Values from this enumeration are used by <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC</c>.</para>
	/// <para>
	/// If this flag is not set, the <c>D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE.pReconstructedPicture</c> can be nullptr in the associated
	/// call to <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_picture_control_flags typedef enum
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAGS { D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAG_USED_AS_REFERENCE_PICTURE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>
		/// The associated frame will be used as a reference frame in future encode commands. Indicates that the reconstructed picture along
		/// with the bitstream should be output for the host to place it in future calls in the reconstructed pictures reference list.
		/// </para>
		/// <para>
		/// Note that there might be limitations for some frame types to be marked as references. Check feature support before setting this value.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAG_USED_AS_REFERENCE_PICTURE = 0x1,
	}

	/// <summary>Specifies the encoder profiles for H.264 encoding.</summary>
	/// <remarks>Use this enumeration to specify the encoder profile in a <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_profile_h264 typedef enum
	// D3D12_VIDEO_ENCODER_PROFILE_H264 { D3D12_VIDEO_ENCODER_PROFILE_H264_MAIN, D3D12_VIDEO_ENCODER_PROFILE_H264_HIGH,
	// D3D12_VIDEO_ENCODER_PROFILE_H264_HIGH_10 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_PROFILE_H264")]
	public enum D3D12_VIDEO_ENCODER_PROFILE_H264
	{
		/// <summary>Main profile.</summary>
		D3D12_VIDEO_ENCODER_PROFILE_H264_MAIN,

		/// <summary>High profile.</summary>
		D3D12_VIDEO_ENCODER_PROFILE_H264_HIGH,

		/// <summary>High 10 profile.</summary>
		D3D12_VIDEO_ENCODER_PROFILE_H264_HIGH_10,
	}

	/// <summary>Specifies the encoder profiles for High Efficiency Video Coding (HEVC) encoding.</summary>
	/// <remarks>Use this enumeration to specify the encoder profile in a <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_profile_hevc typedef enum
	// D3D12_VIDEO_ENCODER_PROFILE_HEVC { D3D12_VIDEO_ENCODER_PROFILE_HEVC_MAIN, D3D12_VIDEO_ENCODER_PROFILE_HEVC_MAIN10 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_PROFILE_HEVC")]
	public enum D3D12_VIDEO_ENCODER_PROFILE_HEVC
	{
		/// <summary>Main profile.</summary>
		D3D12_VIDEO_ENCODER_PROFILE_HEVC_MAIN,

		/// <summary>Main 10 profile.</summary>
		D3D12_VIDEO_ENCODER_PROFILE_HEVC_MAIN10,
	}

	/// <summary>Specifies flags for a <c>D3D12_VIDEO_ENCODER_RATE_CONTROL</c> structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_rate_control_flags typedef enum
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAGS { D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_DELTA_QP, D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_FRAME_ANALYSIS,
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE, D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_INITIAL_QP,
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_MAX_FRAME_SIZE, D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_VBV_SIZES,
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_EXTENSION1_SUPPORT, D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QUALITY_VS_SPEED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>
		/// If the selected rate control is D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_ABSOLUTE_QP_MAP , this flag has no effect since the QP
		/// values in
		/// </para>
		/// <para>D3D12_VIDEO_ENCODER_RATE_CONTROL.pRateControlQPMap</para>
		/// <para>field are used as absolute QP values.</para>
		/// <para>For the other rate control modes, this flag enables the usage of</para>
		/// <para>D3D12_VIDEO_ENCODER_RATE_CONTROL.pRateControlQPMap</para>
		/// <para>
		/// to be interpreted as a delta QP map to be used for the current frame encode operation. The values provided in the map are
		/// incremented/decremented on top of the QP values decided by the rate control algorithm or the baseline QP constant set in CQP
		/// mode. Note Using delta QP adjustment along with some active rate control modes may violate bitrate constraints as it's
		/// explicitly altering the QP values that were selected by rate control budgeting algorithm.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_DELTA_QP = 0x1,

		/// <summary>
		/// <para>
		/// If D3D12_VIDEO_ENCODER_SUPPORT_FLAGS is supported, Enables the rate control algorithm to optimize bitrate usage by selecting QP
		/// values based on statistics collected by doing frame analysis on a first pass.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_FRAME_ANALYSIS = 0x2,

		/// <summary>The MinQp/MaxQP values are used as a range for the rate control algorithm.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE = 0x4,

		/// <summary>The InitialQP values are used as a range for the rate control algorithm.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_INITIAL_QP = 0x8,

		/// <summary>
		/// <para>
		/// When D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_MAX_FRAME_SIZE is supported, the rate control algorithm will limit the
		/// maximum size per frame to the specified parameter in the rate control configuration.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_MAX_FRAME_SIZE = 0x10,

		/// <summary>Enables the usage of VBVCapacity and InitialVBVFullness.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_VBV_SIZES = 0x20,

		/// <summary/>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_EXTENSION1_SUPPORT = 0x40,

		/// <summary/>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QUALITY_VS_SPEED = 0x80
	}

	/// <summary>Specifies video encoder rate control modes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_rate_control_mode typedef enum
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE { D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_ABSOLUTE_QP_MAP,
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_CQP, D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_CBR, D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_VBR,
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_QVBR } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE")]
	public enum D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE
	{
		/// <summary>
		/// <para>
		/// No rate control budgeting. Each EncodeFrame call will interpret the the QP values in the pRateControlQPMap field of the
		/// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264 or D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC structure as a map of
		/// absolute QP values.
		/// </para>
		/// </summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_ABSOLUTE_QP_MAP,

		/// <summary>Constant quantization parameter rate control mode.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_CQP,

		/// <summary>Constant bit rate rate control mode.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_CBR,

		/// <summary>Variable bit rate control mode.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_VBR,

		/// <summary>Constant quality target rate variable rate control mode.</summary>
		D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_QVBR,
	}

	/// <summary>Specifies flags for video encoder sequence control properties.</summary>
	/// <remarks>
	/// Note that depending on the codec, a request for reconfiguration might need to insert an IDR in the bitstream and new SPS headers.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_sequence_control_flags typedef enum
	// D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAGS { D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_RESOLUTION_CHANGE, D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_RATE_CONTROL_CHANGE,
	// D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_SUBREGION_LAYOUT_CHANGE, D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_REQUEST_INTRA_REFRESH,
	// D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_GOP_SEQUENCE_CHANGE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Indicates a change in</para>
		/// <para>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC.PictureTargetResolution</para>
		/// <para>.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_RESOLUTION_CHANGE = 0x1,

		/// <summary>Indicates a change in [D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC.RateControl]((ns-d3d12video-d3d12_video_encoder_sequence_control_desc.md).</summary>
		D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_RATE_CONTROL_CHANGE = 0x2,

		/// <summary>
		/// <para>Indicates a change in</para>
		/// <para>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC.SelectedLayoutMode or D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC.pFrameSubregionsLayoutData</para>
		/// <para>.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_SUBREGION_LAYOUT_CHANGE = 0x4,

		/// <summary>
		/// <para>Starts an intra-refresh session starting at this frame using the configuration in</para>
		/// <para>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC.IntraRefreshConfig</para>
		/// <para>.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_REQUEST_INTRA_REFRESH = 0x8,

		/// <summary>
		/// <para>Indicates a change in</para>
		/// <para>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC.CodecGOPSequence</para>
		/// <para>.</para>
		/// </summary>
		D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_GOP_SEQUENCE_CHANGE = 0x10,
	}

	/// <summary>Specifies flags for video encoder features.</summary>
	/// <remarks>
	/// <para>
	/// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_GENERAL_SUPPORT_OK indicates that whether there is general support. The rest of the flags can be
	/// combined to convey further information.
	/// </para>
	/// <para>General support always expected.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// There is support for all buffers to be allocated with <c>D3D12_MEMORY_POOL_L0</c>. This is always system memory, but still a D3D12 buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// There is support for all buffers to be allocated with <c>D3D12_MEMORY_POOL_L1</c>), the default pool, including those allocated with <c>D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE</c>.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_support_flags typedef enum
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAGS { D3D12_VIDEO_ENCODER_SUPPORT_FLAG_NONE, D3D12_VIDEO_ENCODER_SUPPORT_FLAG_GENERAL_SUPPORT_OK,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_RECONFIGURATION_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RESOLUTION_RECONFIGURATION_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_VBV_SIZE_CONFIG_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_FRAME_ANALYSIS_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RECONSTRUCTED_FRAMES_REQUIRE_TEXTURE_ARRAYS,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_DELTA_QP_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_SUBREGION_LAYOUT_RECONFIGURATION_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_ADJUSTABLE_QP_RANGE_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_INITIAL_QP_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_MAX_FRAME_SIZE_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_SEQUENCE_GOP_RECONFIGURATION_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_MOTION_ESTIMATION_PRECISION_MODE_LIMIT_AVAILABLE,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_EXTENSION1_SUPPORT,
	// D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_QUALITY_VS_SPEED_AVAILABLE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_SUPPORT_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_NONE = 0x0,

		/// <summary>
		/// Indicates whether the given configuration is supported by the encoder in combination with the rest of the flags to convey
		/// certain limitations or no general support. The Direct3D 12 Debug layer can provide further information.
		/// </summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_GENERAL_SUPPORT_OK = 0x1,

		/// <summary>Support for changing the rate control in the middle of the encoding session.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_RECONFIGURATION_AVAILABLE = 0x2,

		/// <summary>Support for changing the resolution in the middle of the encoding session.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RESOLUTION_RECONFIGURATION_AVAILABLE = 0x4,

		/// <summary>Support for configuring the VBV Initial fullness and capacity for rate control algorithms.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_VBV_SIZE_CONFIG_AVAILABLE = 0x8,

		/// <summary>
		/// Support for rate control modes that involve frame analysis to optimize the bitrate usage at the cost of a slower performance.
		/// </summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_FRAME_ANALYSIS_AVAILABLE = 0x10,

		/// <summary>
		/// When this flag is set, textures referring reconstructed pictures can only be referenced as a texture array, as opposed to an
		/// array of separate texture 2D resources with each resource having array size of 1. When this capability is not required, there is
		/// more flexibility for the host. This is important for scenarios where the resolution changes frequently and the DPB needs to be
		/// flushed for an IDR frame, because a texture array can only be allocated and deallocated as an single unit, but separate texture
		/// 2D resources can be allocated and deallocated individually.
		/// </summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RECONSTRUCTED_FRAMES_REQUIRE_TEXTURE_ARRAYS = 0x20,

		/// <summary>Support for Delta QP usage in rate control</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_DELTA_QP_AVAILABLE = 0x40,

		/// <summary>Support for dynamic subregion layout changes during an encoding session.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_SUBREGION_LAYOUT_RECONFIGURATION_AVAILABLE = 0x80,

		/// <summary>Support for adjustable QP range in rate control.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_ADJUSTABLE_QP_RANGE_AVAILABLE = 0x100,

		/// <summary>Support for adjustable initial QP in rate control.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_INITIAL_QP_AVAILABLE = 0x200,

		/// <summary>Ssupport for setting a maximum cap in the bitrate algorithm per each encoded frame.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_MAX_FRAME_SIZE_AVAILABLE = 0x400,

		/// <summary>Support for dynamic GOP changes during an encode session.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_SEQUENCE_GOP_RECONFIGURATION_AVAILABLE = 0x800,

		/// <summary>Support for the caller to limit the precision used for motion search on frame encode.</summary>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_MOTION_ESTIMATION_PRECISION_MODE_LIMIT_AVAILABLE = 0x1000,

		/// <summary/>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_EXTENSION1_SUPPORT = 0x2000,

		/// <summary/>
		D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_QUALITY_VS_SPEED_AVAILABLE = 0x4000
	}

	/// <summary>Specifies the encoder tiers for High Efficiency Video Coding (HEVC) encoding.</summary>
	/// <remarks>Use this enumeration to specify the encoder tier in a <c>D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_tier_hevc typedef enum
	// D3D12_VIDEO_ENCODER_TIER_HEVC { D3D12_VIDEO_ENCODER_TIER_HEVC_MAIN, D3D12_VIDEO_ENCODER_TIER_HEVC_HIGH } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_TIER_HEVC")]
	public enum D3D12_VIDEO_ENCODER_TIER_HEVC
	{
		/// <summary>Main tier.</summary>
		D3D12_VIDEO_ENCODER_TIER_HEVC_MAIN,

		/// <summary>High tier.</summary>
		D3D12_VIDEO_ENCODER_TIER_HEVC_HIGH,
	}

	/// <summary>
	/// Specifies flags returned in the ValidationFlags field of the <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT</c> structure passed into a
	/// call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is <c>D3D12_FEATURE_VIDEO_ENCODER_SUPPORT</c>. The
	/// returned flags indicate the features that are not supported.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_encoder_validation_flags typedef enum
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAGS { D3D12_VIDEO_ENCODER_VALIDATION_FLAG_NONE,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_CODEC_NOT_SUPPORTED, D3D12_VIDEO_ENCODER_VALIDATION_FLAG_INPUT_FORMAT_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_CODEC_CONFIGURATION_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_RATE_CONTROL_MODE_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_RATE_CONTROL_CONFIGURATION_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_INTRA_REFRESH_MODE_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_SUBREGION_LAYOUT_MODE_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_RESOLUTION_NOT_SUPPORTED_IN_LIST,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_GOP_STRUCTURE_NOT_SUPPORTED,
	// D3D12_VIDEO_ENCODER_VALIDATION_FLAG_SUBREGION_LAYOUT_DATA_NOT_SUPPORTED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_ENCODER_VALIDATION_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_ENCODER_VALIDATION_FLAGS
	{
		/// <summary>None.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_NONE = 0x0,

		/// <summary>The specified codec is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_CODEC_NOT_SUPPORTED = 0x1,

		/// <summary>The specified input format is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_INPUT_FORMAT_NOT_SUPPORTED = 0x8,

		/// <summary>The specified codec configuration is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_CODEC_CONFIGURATION_NOT_SUPPORTED = 0x10,

		/// <summary>The specified rate control mode is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_RATE_CONTROL_MODE_NOT_SUPPORTED = 0x20,

		/// <summary>The specified rate control configuration is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_RATE_CONTROL_CONFIGURATION_NOT_SUPPORTED = 0x40,

		/// <summary>The specified intra refresh mode is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_INTRA_REFRESH_MODE_NOT_SUPPORTED = 0x80,

		/// <summary>The specified subregion layout mode is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_SUBREGION_LAYOUT_MODE_NOT_SUPPORTED = 0x100,

		/// <summary>The specified resolution is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_RESOLUTION_NOT_SUPPORTED_IN_LIST = 0x200,

		/// <summary>The specified GOP structure is not supported.</summary>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_GOP_STRUCTURE_NOT_SUPPORTED = 0x800,

		/// <summary/>
		D3D12_VIDEO_ENCODER_VALIDATION_FLAG_SUBREGION_LAYOUT_DATA_NOT_SUPPORTED = 0x1000
	}

	/// <summary>Specifies the usage of the associated video extension command parameter.</summary>
	/// <remarks>Values from this enumeration are used by the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_extension_command_parameter_flags typedef
	// enum D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAGS { D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAG_NONE = 0,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAG_READ = 0x1, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAG_WRITE = 0x2 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 None. Set for simple data type parameters.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>
		/// Value: 0x1 The resource parameter is read. This flag is for ID3D12Resource only and is not valid for simple data type parameters.
		/// </para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAG_READ = 0x1,

		/// <summary>
		/// <para>
		/// Value: 0x2 The resource parameter is written. This flag is for ID3D12Resource only and is not valid for simple data type parameters.
		/// </para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAG_WRITE = 0x2,
	}

	/// <summary>Specifies the parameter stages for video extension commands.</summary>
	/// <remarks>
	/// Values from this enumeration are used when querying for video extension parameter information with calls to
	/// <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature specified as <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c>
	/// or <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT</c>. The results of these parameter queries may be different for
	/// different parameter stages.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_extension_command_parameter_stage typedef
	// enum D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE { D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CREATION = 0,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION = 1, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION = 2,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CAPS_INPUT = 3, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CAPS_OUTPUT = 4,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_DEVICE_EXECUTE_INPUT = 5,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_DEVICE_EXECUTE_OUTPUT = 6 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE")]
	public enum D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE
	{
		/// <summary>
		/// <para>Value: 0 The parameter stage is in video extension command creation.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CREATION,

		/// <summary>
		/// <para>Value: 1 The parameter stage is in video extension command initialization.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION,

		/// <summary>
		/// <para>Value: 2 The parameter stage is in video extension command execution.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION,

		/// <summary>
		/// <para>Value: 3 The parameter stage is input parameters passed to capabilities queries.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CAPS_INPUT,

		/// <summary>
		/// <para>Value: 4 The parameter stage is output parameters passed to capabilities queries.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CAPS_OUTPUT,

		/// <summary>
		/// <para>Value: 5 The parameter stage is device execution input.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_DEVICE_EXECUTE_INPUT,

		/// <summary>
		/// <para>Value: 6 The parameter stage is device execution output.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_DEVICE_EXECUTE_OUTPUT,
	}

	/// <summary>Specifies the types of parameters for video extension commands.</summary>
	/// <remarks>Values from this enumeration are used by the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_extension_command_parameter_type typedef
	// enum D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE { D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT8 = 0,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT16 = 1, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT32 = 2,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT64 = 3, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT8 = 4,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT16 = 5, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT32 = 6,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT64 = 7, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_FLOAT = 8,
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_DOUBLE = 9, D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_RESOURCE = 10 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE")]
	public enum D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Unsigned 8-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT8,

		/// <summary>
		/// <para>Value: 1 Unsigned 16-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT16,

		/// <summary>
		/// <para>Value: 2 Unsigned 32-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT32,

		/// <summary>
		/// <para>Value: 3 Unsigned 64-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_UINT64,

		/// <summary>
		/// <para>Value: 4 Signed 8-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT8,

		/// <summary>
		/// <para>Value: 5 Signed 16-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT16,

		/// <summary>
		/// <para>Value: 6 Signed 32-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT32,

		/// <summary>
		/// <para>Value: 7 Signed 64-bit integer.</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_SINT64,

		/// <summary>
		/// <para>Value: 8 IEEE 32-bit floating point number</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_FLOAT,

		/// <summary>
		/// <para>Value: 9 IEEE 64-bit floating point number</para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_DOUBLE,

		/// <summary>
		/// <para>
		/// Value: 10 A D3D12DDI_HRESOURCE handle. The caller must use resource barriers to transition to the state appropriate for the parameter.
		/// </para>
		/// </summary>
		D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE_RESOURCE,
	}

	/// <summary>Specifies how a video frame is interlaced.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_field_type typedef enum
	// D3D12_VIDEO_FIELD_TYPE { D3D12_VIDEO_FIELD_TYPE_NONE, D3D12_VIDEO_FIELD_TYPE_INTERLACED_TOP_FIELD_FIRST,
	// D3D12_VIDEO_FIELD_TYPE_INTERLACED_BOTTOM_FIELD_FIRST } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_FIELD_TYPE")]
	public enum D3D12_VIDEO_FIELD_TYPE
	{
		/// <summary>The frame is progressive.</summary>
		D3D12_VIDEO_FIELD_TYPE_NONE,

		/// <summary>The frame is interlaced. The top field of each frame is displayed first.</summary>
		D3D12_VIDEO_FIELD_TYPE_INTERLACED_TOP_FIELD_FIRST,

		/// <summary>The frame is interlaced. The bottom field of each frame is displayed first.</summary>
		D3D12_VIDEO_FIELD_TYPE_INTERLACED_BOTTOM_FIELD_FIRST,
	}

	/// <summary>Specifies the interlace type of coded video frames.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_frame_coded_interlace_type typedef enum
	// D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE { D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE_NONE,
	// D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE_FIELD_BASED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE")]
	public enum D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE
	{
		/// <summary>The coded frames are not interlaced, often referred to as "progressive".</summary>
		D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE_NONE,

		/// <summary>The coded frames may be interlaced.</summary>
		D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE_FIELD_BASED,
	}

	/// <summary>
	/// Defines the layout in memory of a stereo 3D video frame. All drivers that support stereo must support all of the defined formats.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_frame_stereo_format typedef enum
	// D3D12_VIDEO_FRAME_STEREO_FORMAT { D3D12_VIDEO_FRAME_STEREO_FORMAT_NONE, D3D12_VIDEO_FRAME_STEREO_FORMAT_MONO,
	// D3D12_VIDEO_FRAME_STEREO_FORMAT_HORIZONTAL, D3D12_VIDEO_FRAME_STEREO_FORMAT_VERTICAL, D3D12_VIDEO_FRAME_STEREO_FORMAT_SEPARATE } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_FRAME_STEREO_FORMAT")]
	public enum D3D12_VIDEO_FRAME_STEREO_FORMAT
	{
		/// <summary>No stereo format is specified.</summary>
		D3D12_VIDEO_FRAME_STEREO_FORMAT_NONE,

		/// <summary>The sample does not contain stereo data. If the stereo format is not specified, this value is the default.</summary>
		D3D12_VIDEO_FRAME_STEREO_FORMAT_MONO,

		/// <summary>Frame 0 and frame 1 are packed side-by-side, as shown in the following diagram.</summary>
		D3D12_VIDEO_FRAME_STEREO_FORMAT_HORIZONTAL,

		/// <summary>Frame 0 and frame 1 are packed top-to-bottom, as shown in the following diagram.</summary>
		D3D12_VIDEO_FRAME_STEREO_FORMAT_VERTICAL,

		/// <summary>Frame 0 and frame 1 are placed in separate resources</summary>
		D3D12_VIDEO_FRAME_STEREO_FORMAT_SEPARATE,
	}

	/// <summary>Defines search block sizes for video motion estimation.</summary>
	/// <remarks>
	/// <para>
	/// Query for supported block sizes by calling <c>ID3D12VideoDevice::CheckFeatureSupport</c> and specifying the feature value of <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR</c>.
	/// </para>
	/// <para>Set the desired block size for video motion estimation with the <c>D3D12_VIDEO_MOTION_ESTIMATOR_DESC</c> passed into <c>ID3D12VideoDevice1::CreateVideoMotionEstimator</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_motion_estimator_search_block_size typedef
	// enum D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE { D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_8X8 = 0,
	// D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_16X16 = 1 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE")]
	public enum D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE
	{
		/// <summary>
		/// <para>Value: 0 The search block size is 8x8 pixels.</para>
		/// </summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_8X8,

		/// <summary>
		/// <para>Value: 1 The search block size is 16x16 pixels.</para>
		/// </summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_16X16,
	}

	/// <summary>Specifies the motion estimation search block sizes that a video encoder supports.</summary>
	/// <remarks>
	/// Query for supported block sizes by calling <c>ID3D12VideoDevice::CheckFeatureSupport</c> and specifying the feature value of <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_motion_estimator_search_block_size_flags
	// typedef enum D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAGS { D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAG_NONE = 0,
	// D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAG_8X8, D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAG_16X16 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Search block size is not supported by the encoder.</para>
		/// </summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAG_NONE = 0x0,

		/// <summary>The encoder supports a search block size of 8x8 pixels.</summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAG_8X8 = 0x1,

		/// <summary>The encoder supports a search block size of 16x16 pixels.</summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAG_16X16 = 0x2,
	}

	/// <summary>Defines vector precision values for video motion estimation.</summary>
	/// <remarks>
	/// <para>
	/// Query for supported vector precision values by calling <c>ID3D12VideoDevice::CheckFeatureSupport</c> and specifying the feature
	/// value of <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR</c>.
	/// </para>
	/// <para>
	/// Set the desired vector precision for video motion estimation with the <c>D3D12_VIDEO_MOTION_ESTIMATOR_DESC</c> passed into <c>ID3D12VideoDevice1::CreateVideoMotionEstimator</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_motion_estimator_vector_precision typedef
	// enum D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION { D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_QUARTER_PEL = 0 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION")]
	public enum D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION
	{
		/// <summary>
		/// <para>Value: 0 The vector precision is quarter-pixel motion.</para>
		/// </summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_QUARTER_PEL,
	}

	/// <summary>Specifies the motion estimation vector precision that a video encoder supports.</summary>
	/// <remarks>
	/// Query for supported vector precision values by calling <c>ID3D12VideoDevice::CheckFeatureSupport</c> and specifying the feature
	/// value of <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_motion_estimator_vector_precision_flags
	// typedef enum D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAGS { D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAG_NONE = 0,
	// D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAG_QUARTER_PEL } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Vector precision is not supported by the encoder.</para>
		/// </summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAG_NONE = 0x0,

		/// <summary>The vector precision is quarter-pixel motion.</summary>
		D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAG_QUARTER_PEL = 0x1,
	}

	/// <summary>
	/// Specifies the alpha fill mode for video processing. This value is used by the <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC</c> structure.
	/// </summary>
	/// <remarks>
	/// <b>D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_OPAQUE</b> must be always supported. The background, destination, and source stream modes are
	/// only supported when the driver reports <c>D3D12_VIDEO_PROCESS_FEATURE_FLAG_ALPHA_FILL</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_alpha_fill_mode typedef enum
	// D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE { D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_OPAQUE, D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_BACKGROUND,
	// D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_DESTINATION, D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_SOURCE_STREAM } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE")]
	public enum D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE
	{
		/// <summary>Alpha values inside the target rectangle are set to opaque.</summary>
		D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_OPAQUE,

		/// <summary>Alpha values inside the target rectangle are set to the alpha value specified in the background color.</summary>
		D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_BACKGROUND,

		/// <summary>Existing alpha values remain unchanged in the output surface.</summary>
		D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_DESTINATION,

		/// <summary>
		/// <para>
		/// Alpha values are taken from an input stream, scaled, and copied to the corresponding destination rectangle for that stream. The
		/// input stream is specified in the AlphaFillModeSourceStreamIndex member of D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS.
		/// </para>
		/// <para>
		/// If the input stream does not have alpha data, the video processor sets the alpha values in the target rectangle to opaque. If
		/// the input stream is disabled or the source rectangle is empty, the alpha values in the target rectangle are not modified.
		/// </para>
		/// </summary>
		D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_SOURCE_STREAM,
	}

	/// <summary>Specifies the automatic processing features that a video processor can support.</summary>
	/// <remarks>This enumeration is used by the <c>D3D12_FEATURE_DATA_VIDEO_PROCESS_SUPPORT</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_auto_processing_flags typedef enum
	// D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAGS { D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_NONE,
	// D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_DENOISE, D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_DERINGING,
	// D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_EDGE_ENHANCEMENT, D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_COLOR_CORRECTION,
	// D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_FLESH_TONE_MAPPING, D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_IMAGE_STABILIZATION,
	// D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_SUPER_RESOLUTION, D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_ANAMORPHIC_SCALING,
	// D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_CUSTOM } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAGS : uint
	{
		/// <summary>No automatic processing features are supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_NONE = 0x0,

		/// <summary>Denoise is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_DENOISE = 0x1,

		/// <summary>Deringing is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_DERINGING = 0x2,

		/// <summary>Edge enhancement is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_EDGE_ENHANCEMENT = 0x4,

		/// <summary>Color correction is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_COLOR_CORRECTION = 0x8,

		/// <summary>Flesh tone mapping is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_FLESH_TONE_MAPPING = 0x10,

		/// <summary>Image stabilization is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_IMAGE_STABILIZATION = 0x20,

		/// <summary>Enhanced image resolution is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_SUPER_RESOLUTION = 0x40,

		/// <summary>Anamorphic scaling is supported.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_ANAMORPHIC_SCALING = 0x80,

		/// <summary>Additional processing features, not described by the other flags, are available.</summary>
		D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAG_CUSTOM = 0x80000000,
	}

	/// <summary>Specifies the deinterlacing video processor capabilities.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_deinterlace_flags typedef enum
	// D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS { D3D12_VIDEO_PROCESS_DEINTERLACE_FLAG_NONE, D3D12_VIDEO_PROCESS_DEINTERLACE_FLAG_BOB,
	// D3D12_VIDEO_PROCESS_DEINTERLACE_FLAG_CUSTOM } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS : uint
	{
		/// <summary>No deinterlacing capabilities are available.</summary>
		D3D12_VIDEO_PROCESS_DEINTERLACE_FLAG_NONE = 0x0,

		/// <summary>
		/// The video processor can perform bob deinterlacing. In bob deinterlacing, missing field lines are interpolated from the lines
		/// above and below. Bob deinterlacing does not require reference frames.
		/// </summary>
		D3D12_VIDEO_PROCESS_DEINTERLACE_FLAG_BOB = 0x1,

		/// <summary>
		/// <para>
		/// The video processor can perform a custom high-quality deinterlacing, which requires the number of reference frames indicated in
		/// PastFrames and FutureFrames output fields of the D3D12_FEATURE_DATA_VIDEO_PROCESS_REFERENCE_INFO populated by a call to
		/// </para>
		/// <para>ID3D12VideoDevice::CheckFeatureSupport</para>
		/// <para>
		/// when the feature specified is D3D12_FEATURE_VIDEO_PROCESS_REFERENCE_INFO. If the video processor doesn’t have the necessary
		/// number of reference frames, it falls back to bob deinterlacing.
		/// </para>
		/// </summary>
		D3D12_VIDEO_PROCESS_DEINTERLACE_FLAG_CUSTOM = 0x80000000,
	}

	/// <summary>Specifies the features that a video processor can support.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_feature_flags typedef enum
	// D3D12_VIDEO_PROCESS_FEATURE_FLAGS { D3D12_VIDEO_PROCESS_FEATURE_FLAG_NONE, D3D12_VIDEO_PROCESS_FEATURE_FLAG_ALPHA_FILL,
	// D3D12_VIDEO_PROCESS_FEATURE_FLAG_LUMA_KEY, D3D12_VIDEO_PROCESS_FEATURE_FLAG_STEREO, D3D12_VIDEO_PROCESS_FEATURE_FLAG_ROTATION,
	// D3D12_VIDEO_PROCESS_FEATURE_FLAG_FLIP, D3D12_VIDEO_PROCESS_FEATURE_FLAG_ALPHA_BLENDING,
	// D3D12_VIDEO_PROCESS_FEATURE_FLAG_PIXEL_ASPECT_RATIO } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_FEATURE_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_PROCESS_FEATURE_FLAGS
	{
		/// <summary>No features are supported.</summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>
		/// The video processor can set alpha values on the output pixels. The alpha fill mode is used in
		/// D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC. D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_OPAQUE must be always supported. The background,
		/// destination, and source stream modes are only supported when the driver reports D3D12_VIDEO_PROCESS_FEATURE_FLAG_ALPHA_FILL.
		/// </para>
		/// </summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_ALPHA_FILL = 0x1,

		/// <summary>
		/// <para>
		/// The video processor can perform luma keying. Luma keying is configured via the D3D12_VIDEO_PROCESS_LUMA_KEY member of the
		/// D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS structure. For more information see &lt;a href=ns-d3d12video-d3d12_video_process_luma_key""&gt;D3D12_VIDEO_PROCESS_LUMA_KEY.
		/// </para>
		/// </summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_LUMA_KEY = 0x2,

		/// <summary>
		/// <para>The video processor can support 3D stereo video. For more information, see D3D12_VIDEO_FRAME_STEREO_FORMAT.</para>
		/// <para>
		/// All drivers setting this capability must support the following stereo formats: D3D12_VIDEO_PROCESS_STEREO_FORMAT_HORIZONTAL,
		/// D3D12_VIDEO_PROCESS_STEREO_FORMAT_VERTICAL, and D3D12_VIDEO_PROCESS_STEREO_FORMAT_SEPARATE.
		/// </para>
		/// </summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_STEREO = 0x4,

		/// <summary>The driver can rotate the input data either 90, 180, or 270 degrees clockwise as part of the video processing operation.</summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_ROTATION = 0x8,

		/// <summary>The driver can flip the input data horizontally or vertically, together or separately with a video rotation operation.</summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_FLIP = 0x10,

		/// <summary>
		/// <para>
		/// Alpha blending and a planar alpha may be set in the AlphaBlending member of the D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS
		/// structure. For more information see D3D12_VIDEO_PROCESS_ALPHA_BLENDING.
		/// </para>
		/// </summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_ALPHA_BLENDING = 0x20,

		/// <summary>
		/// <para>
		/// The driver supports changing the pixel aspect ratio. If the driver does not report this capability, then the SourceAspectRatio
		/// and DestinationAspectRatio members of D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS structure must indicate a 1:1 aspect ratio.
		/// </para>
		/// </summary>
		D3D12_VIDEO_PROCESS_FEATURE_FLAG_PIXEL_ASPECT_RATIO = 0x40,
	}

	/// <summary>Specifies support for the image filters.</summary>
	/// <remarks>See <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC</c> for information on applying a particular filter.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_filter_flags typedef enum
	// D3D12_VIDEO_PROCESS_FILTER_FLAGS { D3D12_VIDEO_PROCESS_FILTER_FLAG_NONE, D3D12_VIDEO_PROCESS_FILTER_FLAG_BRIGHTNESS,
	// D3D12_VIDEO_PROCESS_FILTER_FLAG_CONTRAST, D3D12_VIDEO_PROCESS_FILTER_FLAG_HUE, D3D12_VIDEO_PROCESS_FILTER_FLAG_SATURATION,
	// D3D12_VIDEO_PROCESS_FILTER_FLAG_NOISE_REDUCTION, D3D12_VIDEO_PROCESS_FILTER_FLAG_EDGE_ENHANCEMENT,
	// D3D12_VIDEO_PROCESS_FILTER_FLAG_ANAMORPHIC_SCALING, D3D12_VIDEO_PROCESS_FILTER_FLAG_STEREO_ADJUSTMENT } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_FILTER_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_PROCESS_FILTER_FLAGS
	{
		/// <summary>The video processor doesn't support any filters.</summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_NONE = 0x0,

		/// <summary>The video processor can adjust the brightness level.</summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_BRIGHTNESS = 0x1,

		/// <summary>The video processor can adjust the contrast level.</summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_CONTRAST = 0x2,

		/// <summary>The video processor can adjust hue.</summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_HUE = 0x4,

		/// <summary>The video processor can adjust the saturation level.</summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_SATURATION = 0x8,

		/// <summary>The video processor can perform noise reduction.</summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_NOISE_REDUCTION = 0x10,

		/// <summary>The video processor can perform edge enhancement.</summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_EDGE_ENHANCEMENT = 0x20,

		/// <summary>
		/// The video processor can perform anamorphic scaling. Anamorphic scaling can be used to stretch 4:3 content to a widescreen 16:9
		/// aspect ratio.
		/// </summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_ANAMORPHIC_SCALING = 0x40,

		/// <summary>
		/// For stereo 3D video, the video processor can adjust the offset between the left and right views, allowing the user to reduce
		/// potential eye strain.
		/// </summary>
		D3D12_VIDEO_PROCESS_FILTER_FLAG_STEREO_ADJUSTMENT = 0x80,
	}

	/// <summary>Specifies flags for video processing input streams. Used by the <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS</c> structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_input_stream_flags typedef enum
	// D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS { D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAG_NONE,
	// D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAG_FRAME_DISCONTINUITY, D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAG_FRAME_REPEAT } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS
	{
		/// <summary>No flags specified.</summary>
		D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAG_NONE = 0x0,

		/// <summary>Set this flag when not processing frames in order, such as seeking between frames</summary>
		D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAG_FRAME_DISCONTINUITY = 0x1,

		/// <summary>Set this flag when applying video process operation to the same set of inputs.</summary>
		D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAG_FRAME_REPEAT = 0x2,
	}

	/// <summary>Specifies an orientation operation to be performed by a video processor.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_orientation typedef enum
	// D3D12_VIDEO_PROCESS_ORIENTATION { D3D12_VIDEO_PROCESS_ORIENTATION_DEFAULT, D3D12_VIDEO_PROCESS_ORIENTATION_FLIP_HORIZONTAL,
	// D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_90, D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_90_FLIP_HORIZONTAL,
	// D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_180, D3D12_VIDEO_PROCESS_ORIENTATION_FLIP_VERTICAL,
	// D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_270, D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_270_FLIP_HORIZONTAL } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_ORIENTATION")]
	public enum D3D12_VIDEO_PROCESS_ORIENTATION
	{
		/// <summary>No change in orientation. 0 degrees.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_DEFAULT,

		/// <summary>The image is flipped horizontally.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_FLIP_HORIZONTAL,

		/// <summary>The image is rotated 90 degrees clockwise.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_90,

		/// <summary>The image is rotated 90 degrees clockwise and then flipped horizontally.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_90_FLIP_HORIZONTAL,

		/// <summary>The image is rotated 180 degrees clockwise.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_180,

		/// <summary>The image is flipped vertically.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_FLIP_VERTICAL,

		/// <summary>The image is rotated 270 degrees clockwise.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_270,

		/// <summary>The image is rotated 270 degrees clockwise and then flipped horizontally.</summary>
		D3D12_VIDEO_PROCESS_ORIENTATION_CLOCKWISE_270_FLIP_HORIZONTAL,
	}

	/// <summary>Specifies whether a video format and colorspace conversion operation is supported.</summary>
	/// <remarks>This enumeration is used by the <c>D3D12_FEATURE_DATA_VIDEO_PROCESS_SUPPORT</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_process_support_flags typedef enum
	// D3D12_VIDEO_PROCESS_SUPPORT_FLAGS { D3D12_VIDEO_PROCESS_SUPPORT_FLAG_NONE, D3D12_VIDEO_PROCESS_SUPPORT_FLAG_SUPPORTED } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROCESS_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_PROCESS_SUPPORT_FLAGS
	{
		/// <summary>The conversion from the source format and colorspace to destination format and colorspace are not supported.</summary>
		D3D12_VIDEO_PROCESS_SUPPORT_FLAG_NONE = 0x0,

		/// <summary>The conversion from the source format and colorspace to destination format and colorspace are supported.</summary>
		D3D12_VIDEO_PROCESS_SUPPORT_FLAG_SUPPORTED = 0x1,
	}

	/// <summary>Specifies support for protected resources in video operations.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_protected_resource_support_flags typedef
	// enum D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAGS { D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAG_NONE = 0,
	// D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAG_SUPPORTED = 0x1 } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Protected resources are not supported.</para>
		/// </summary>
		D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 Protected resources are supported.</para>
		/// </summary>
		D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAG_SUPPORTED = 0x1,
	}

	/// <summary>Specifies the scaling capabilities of the video scaler.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ne-d3d12video-d3d12_video_scale_support_flags typedef enum
	// D3D12_VIDEO_SCALE_SUPPORT_FLAGS { D3D12_VIDEO_SCALE_SUPPORT_FLAG_NONE, D3D12_VIDEO_SCALE_SUPPORT_FLAG_POW2_ONLY,
	// D3D12_VIDEO_SCALE_SUPPORT_FLAG_EVEN_DIMENSIONS_ONLY } ;
	[PInvokeData("d3d12video.h", MSDNShortId = "NE:d3d12video.D3D12_VIDEO_SCALE_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_VIDEO_SCALE_SUPPORT_FLAGS
	{
		/// <summary>
		/// All possible output size width/height combinations that exist between the maximum size and minimum size for the extent,
		/// inclusive, are supported.
		/// </summary>
		D3D12_VIDEO_SCALE_SUPPORT_FLAG_NONE = 0x0,

		/// <summary>
		/// The scaler only supports output sizes at a power of two scale factors within the range. The x and y scale factors must be the
		/// same for both dimensions when this flag is set.
		/// </summary>
		D3D12_VIDEO_SCALE_SUPPORT_FLAG_POW2_ONLY = 0x1,

		/// <summary>The scaler only supports output sizes with even output dimensions.</summary>
		D3D12_VIDEO_SCALE_SUPPORT_FLAG_EVEN_DIMENSIONS_ONLY = 0x2,
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_DECODE_CONVERSION_SUPPORT</c>. Retrieves the list of supported profiles. Check if a colorspace conversion,
	/// format conversion, and scale are supported.
	/// </summary>
	/// <remarks>
	/// If the colorspace and format conversion is supported, ScaleFlags will have the <c>D3D12_VIDEO_SCALE_SUPPORT_FLAGS</c> set. Callers
	/// should check the <c>D3D12_VIDEO_SIZE_RANGE</c> field to determine if the requested scale is supported.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_decode_conversion_support
	// typedef struct D3D12_FEATURE_DATA_VIDEO_DECODE_CONVERSION_SUPPORT { UINT NodeIndex; D3D12_VIDEO_DECODE_CONFIGURATION Configuration;
	// D3D12_VIDEO_SAMPLE DecodeSample; D3D12_VIDEO_FORMAT OutputFormat; DXGI_RATIONAL FrameRate; UINT BitRate;
	// D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAGS SupportFlags; D3D12_VIDEO_SCALE_SUPPORT ScaleSupport; } D3D12_FEATURE_DATA_VIDEO_DECODE_CONVERSION_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_DECODE_CONVERSION_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_DECODE_CONVERSION_SUPPORT
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeIndex;

		/// <summary>A <c>D3D12_VIDEO_DECODE_CONFIGURATION</c> structure describing the decode configuration.</summary>
		public D3D12_VIDEO_DECODE_CONFIGURATION Configuration;

		/// <summary>A <c>D3D12_VIDEO_SAMPLE</c> structure representing the source decoded as sample description.</summary>
		public D3D12_VIDEO_SAMPLE DecodeSample;

		/// <summary>A <c>D3D12_VIDEO_FORMAT</c> structure containing the output sample description.</summary>
		public D3D12_VIDEO_FORMAT OutputFormat;

		/// <summary>
		/// The frame rate of the video content. This is used by the driver to determine whether the video can be decoded in real-time.
		/// </summary>
		public DXGI_RATIONAL FrameRate;

		/// <summary>
		/// The average bits per second data compression rate for the compressed video stream. This is used by the driver to determine
		/// whether the video can be decoded in real-time.
		/// </summary>
		public uint BitRate;

		/// <summary>
		/// A combination of values from the <c>D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAGS</c> indicating the support for the specified conversion.
		/// </summary>
		public D3D12_VIDEO_DECODE_CONVERSION_SUPPORT_FLAGS SupportFlags;

		/// <summary>A <c>D3D12_VIDEO_SCALE_SUPPORT</c> structure representing the output size range for decode conversion.</summary>
		public D3D12_VIDEO_SCALE_SUPPORT ScaleSupport;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_DECODE_FORMAT</c>. Retrieves the list of supported formats.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_decode_formats typedef struct
	// D3D12_FEATURE_DATA_VIDEO_DECODE_FORMATS { UINT NodeIndex; D3D12_VIDEO_DECODE_CONFIGURATION Configuration; UINT FormatCount;
	// DXGI_FORMAT *pOutputFormats; } D3D12_FEATURE_DATA_VIDEO_DECODE_FORMATS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_DECODE_FORMATS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_DECODE_FORMATS
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeIndex;

		/// <summary>A <c>D3D12_VIDEO_DECODE_CONFIGURATION</c> structure describing the decode configuration for the list of formats.</summary>
		public D3D12_VIDEO_DECODE_CONFIGURATION Configuration;

		/// <summary>
		/// The number of formats to retrieve. This number must match the value returned from a call
		/// <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is <c>D3D12_FEATURE_VIDEO_DECODE_FORMAT_COUNT</c>.
		/// </summary>
		public uint FormatCount;

		/// <summary>A list of <c>DXGI_FORMAT</c> structures representing the supported formats.</summary>
		public ArrayPointer<DXGI_FORMAT> pOutputFormats;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_DECODE_HISTOGRAM</c>. Retrieves the histogram capabilities for the specified decoder configuration.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_decode_histogram typedef struct
	// D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM { UINT NodeIndex; GUID DecodeProfile; UINT Width; UINT Height; DXGI_FORMAT DecodeFormat;
	// D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAGS Components; UINT BinCount; UINT CounterBitDepth; } D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// A GUID representing the decode profile for which histogram capabilities will be queried. Get a list of available profile GUIDs
		/// by calling <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is <c>D3D12_FEATURE_VIDEO_DECODE_PROFILES</c>.
		/// </summary>
		public Guid DecodeProfile;

		/// <summary>The decode width of the source stream.</summary>
		public uint Width;

		/// <summary>The decode height of the source stream.</summary>
		public uint Height;

		/// <summary>The <c>DXGI_FORMAT</c> representing the decode format.</summary>
		public DXGI_FORMAT DecodeFormat;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAGS</c> enumeration specifying the
		/// components of a DXGI_FORMAT for which histogram support will be queried.
		/// </summary>
		public D3D12_VIDEO_DECODE_HISTOGRAM_COMPONENT_FLAGS Components;

		/// <summary>
		/// The number of per component bins supported. This value must be greater than or equal to 64 and must be a power of 2 (e.g. 64,
		/// 128, 256, 512...).
		/// </summary>
		public uint BinCount;

		/// <summary>
		/// The bit depth of the bin counter. The counter is always stored in a 32-bit value and therefore this value must specify 32 bits
		/// or less. The counter is stored in the lower bits of the 32-bit storage. The upper bits are set to zero. If the bin count exceeds
		/// this bit depth, the value is set to the maximum counter value. Valid values for CounterBitDepth are 16, 24, and 32.
		/// </summary>
		public uint CounterBitDepth;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_DECODE_PROFILES</c>. Retrieves the list of supported profiles.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_decode_profiles typedef struct
	// D3D12_FEATURE_DATA_VIDEO_DECODE_PROFILES { UINT NodeIndex; UINT ProfileCount; GUID *pProfiles; } D3D12_FEATURE_DATA_VIDEO_DECODE_PROFILES;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_DECODE_PROFILES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_DECODE_PROFILES
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// The number of profiles to retrieve. This number must match the value returned from a call
		/// <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is <c>D3D12_FEATURE_VIDEO_DECODE_PROFILE_COUNT</c>.
		/// </summary>
		public uint ProfileCount;

		/// <summary>
		/// A list of GUIDs representing the supported profiles. The calling application must allocate storage for the profile list before
		/// calling <b>CheckFeatureSupport</b>.
		/// </summary>
		public ArrayPointer<Guid> pProfiles;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_DECODE_SUPPORT</c>. Retrieves support information for video decoding.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_decode_support typedef struct
	// D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT { UINT NodeIndex; D3D12_VIDEO_DECODE_CONFIGURATION Configuration; UINT Width; UINT Height;
	// DXGI_FORMAT DecodeFormat; DXGI_RATIONAL FrameRate; UINT BitRate; D3D12_VIDEO_DECODE_SUPPORT_FLAGS SupportFlags;
	// D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS ConfigurationFlags; D3D12_VIDEO_DECODE_TIER DecodeTier; } D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// A <c>D3D12_VIDEO_DECODE_CONFIGURATION</c> structure specifying the decode profile, bitstream encryption, and interlace type of
		/// the source stream.
		/// </summary>
		public D3D12_VIDEO_DECODE_CONFIGURATION Configuration;

		/// <summary>The decode width of the source stream.</summary>
		public uint Width;

		/// <summary>The decode height of the source stream</summary>
		public uint Height;

		/// <summary>
		/// The <c>DXGI_FORMAT</c> to use as the decode format. This format is the output format if no decoder conversion is specified.
		/// </summary>
		public DXGI_FORMAT DecodeFormat;

		/// <summary>The frame rate of the video format. A value of 0 means the frame rate is unknown.</summary>
		public DXGI_RATIONAL FrameRate;

		/// <summary>
		/// The average bits per second data compression rate for the compressed video stream. This information is used by the driver to
		/// determine whether the video can be decoded in real-time. A value of 0 means the bit rate is unknown.
		/// </summary>
		public uint BitRate;

		/// <summary>
		/// A combination of values from the <c>D3D12_VIDEO_DECODE_SUPPORT_FLAGS</c> enumeration indicating the support for video decoding.
		/// This value is populated by the call to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_DECODE_SUPPORT_FLAGS SupportFlags;

		/// <summary>
		/// A combination of values from the <c>D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS</c> enumeration describing the video decode
		/// configuration. This value is populated by the call to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS ConfigurationFlags;

		/// <summary>A member of the <c>D3D12_VIDEO_DECODE_TIER</c> enumeration specifying the decoding tier of a hardware video decoder.</summary>
		public D3D12_VIDEO_DECODE_TIER DecodeTier;
	}

	/// <summary>Describes the allocation size of a video decoder heap.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_decoder_heap_size typedef
	// struct D3D12_FEATURE_DATA_VIDEO_DECODER_HEAP_SIZE { D3D12_VIDEO_DECODER_HEAP_DESC VideoDecoderHeapDesc; UINT64 MemoryPoolL0Size;
	// UINT64 MemoryPoolL1Size; } D3D12_FEATURE_DATA_VIDEO_DECODER_HEAP_SIZE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_DECODER_HEAP_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_DECODER_HEAP_SIZE
	{
		/// <summary>A <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> describing a <c>ID3D12VideoDecoderHeap</c>.</summary>
		public D3D12_VIDEO_DECODER_HEAP_DESC VideoDecoderHeapDesc;

		/// <summary>
		/// The allocation size of the video decoder heap in the L0 memory pool. L0 is the physical system memory pool. When the adapter is
		/// discrete/NUMA, this pool has greater bandwidth for the CPU and less bandwidth for the GPU. When the adapter is UMA, this pool is
		/// the only one which is valid. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MemoryPoolL0Size;

		/// <summary>
		/// The allocation size of the video decoder heap in the L1 memory pool. L1 is typically known as the physical video memory pool. L1
		/// is only available when the adapter is discrete/NUMA, and has greater bandwidth for the GPU and cannot even be accessed by the
		/// CPU. When the adapter is UMA, this pool is not available. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MemoryPoolL1Size;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_CODEC</c>. Retrieves a value indicating if the specified codec is supported for video encoding.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_codec typedef struct
	// D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec; BOOL IsSupported; } D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which encoder support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>Receives a boolean value indicating if the specified codec is supported.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT</c>. Retrieves a value indicating if the specified codec configuration
	/// support parameters are supported for the provided HEVC encoding configuration or retrieves the supported configuration for H.264 encoding.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_codec_configuration_support
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC Profile; BOOL IsSupported; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT CodecSupportLimits; } D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which rate control mode support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the profile for which intra refresh mode support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC Profile;

		/// <summary>Receives a boolean value indicating if the specified configuration parameters are supported for the specified codec.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT</c> structure. For HEVC, the caller populates this structure with the
		/// desired encoder configuration. For H.264, the <b>CheckFeatureSupport</b> call populates the structure with the supported configuration.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT CodecSupportLimits;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT</c>. Retrieves the picture control support for the specified codec and profile.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_codec_picture_control_support
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC Profile; BOOL IsSupported; D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT PictureSupport; } D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which picture control support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the profile for which picture control support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC Profile;

		/// <summary>Gets a boolean value indicating if the provided values are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;

		/// <summary>
		/// Receives a <c>D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT</c> structure representing the picture control support for the
		/// provided values.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT PictureSupport;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE</c>. Retrieves a value indicating if the specified frame subregion layout
	/// mode is supported for the specified code, profile, and level.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_frame_subregion_layout_mode
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC Profile; D3D12_VIDEO_ENCODER_LEVEL_SETTING Level; D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE
	// SubregionMode; BOOL IsSupported; } D3D12_FEATURE_DATA_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which frame subregion layout mode support
		/// is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the profile for which frame subregion layout mode support is
		/// being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC Profile;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_LEVEL_SETTING</c> structure specifying the level for which frame subregion layout mode support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_LEVEL_SETTING Level;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE</c> enumeration specifying the frame subregion layout mode
		/// for which support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE SubregionMode;

		/// <summary>
		/// Receives a boolean value indicating if the specified frame subregion layout mode is supported for the specified codec.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_HEAP_SIZE</c>. Retrieves a value indicating if the specified codec is supported for video encoding as
	/// well as the L0 and L1 sizes of the heap object.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_heap_size typedef
	// struct D3D12_FEATURE_DATA_VIDEO_ENCODER_HEAP_SIZE { D3D12_VIDEO_ENCODER_HEAP_DESC HeapDesc; BOOL IsSupported; UINT64
	// MemoryPoolL0Size; UINT64 MemoryPoolL1Size; } D3D12_FEATURE_DATA_VIDEO_ENCODER_HEAP_SIZE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_HEAP_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_HEAP_SIZE
	{
		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC</c> structure specifying the creation properties for a video encoder heap. The
		/// driver should map these creation properties to size and assume the maximum resolution allowed for such heap.
		/// </summary>
		public D3D12_VIDEO_ENCODER_HEAP_DESC HeapDesc;

		/// <summary>Receives a boolean value indicating if the encoder creation properties provided in <b>HeapDesc</b> are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;

		/// <summary>
		/// Receives the L0 size of the heap object. Memory Pool L0 is the memory pool “closest” to the GPU. In the case of UMA adapters,
		/// this is the amount of system memory used. For discrete adapters, this is the amount of discrete memory used.
		/// </summary>
		public ulong MemoryPoolL0Size;

		/// <summary>
		/// Receives the L1 size of the heap object. Memory Pool L1 is the memory pool “second closest” to the GPU. In the case of UMA
		/// adapters, this value is zero. In the case of discrete adapters, this is the amount of system memory used.
		/// </summary>
		public ulong MemoryPoolL1Size;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_INPUT_FORMAT</c>. Retrieves a value indicating if the specified codec, profile, and format are
	/// supported for video encoding.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_input_format typedef
	// struct D3D12_FEATURE_DATA_VIDEO_ENCODER_INPUT_FORMAT { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC Profile; DXGI_FORMAT Format; BOOL IsSupported; } D3D12_FEATURE_DATA_VIDEO_ENCODER_INPUT_FORMAT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_INPUT_FORMAT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_INPUT_FORMAT
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which support is being queried.</summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the profile for which support is being queried.</summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC Profile;

		/// <summary>
		/// <para>
		/// A member of the <c>DXGI_FORMAT</c> enumeration specifying the pixel format for which support is being queried. This format
		/// definition includes the subsampling and bit-depth modes settings for the video encoding session.
		/// </para>
		/// <para>To query encoder support for 4:2:0 with 8 and 10 bitdepth samples using following values for the <b>Format</b> field:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_FORMAT_P010</description>
		/// </item>
		/// <item>
		/// <description>DXGI_FORMAT_NV12</description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>The host is expected to handle the input subsampling and color conversion stages of video encoding.</para>
		/// </para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>Receives a boolean value indicating if the specified codec, profile, and format are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_INTRA_REFRESH_MODE</c>. Retrieves a value indicating if the specified intra refresh mode is supported
	/// for the specified codec, profile, and level.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_intra_refresh_mode
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_INTRA_REFRESH_MODE { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC Profile; D3D12_VIDEO_ENCODER_LEVEL_SETTING Level; D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE
	// IntraRefreshMode; BOOL IsSupported; } D3D12_FEATURE_DATA_VIDEO_ENCODER_INTRA_REFRESH_MODE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_INTRA_REFRESH_MODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_INTRA_REFRESH_MODE
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which intra refresh mode support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the profile for which intra refresh mode support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC Profile;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_LEVEL_SETTING</c> structure specifying the level for which intra refresh mode support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_LEVEL_SETTING Level;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE</c> enumeration specifying the intra refresh mode for which support is
		/// being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE IntraRefreshMode;

		/// <summary>
		/// Receives a boolean value indicating if the specified intra refresh mode is supported for the specified codec, profile, and level.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_OUTPUT_RESOLUTION</c>. Retrieves the list of supported resolutions for the specified codec.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_output_resolution
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec; UINT
	// ResolutionRatiosCount; BOOL IsSupported; D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC MinResolutionSupported;
	// D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC MaxResolutionSupported; UINT ResolutionWidthMultipleRequirement; UINT
	// ResolutionHeightMultipleRequirement; D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_RATIO_DESC *pResolutionRatios; } D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which the supported resolutions are being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>
		/// The number of resolution ratios to retrieve. This number must match the number in the
		/// <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT.ResolutionRatiosCount</c> field returned from a call to
		/// <c>ID3D12VideoDevice::CheckFeatureSupport</c> with <b>D3D12_FEATURE_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT</b> specified
		/// as the feature.
		/// </summary>
		public uint ResolutionRatiosCount;

		/// <summary>Receives a boolean indicating if the query inputs are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;

		/// <summary>Receives the minimum resolution supported for the specified codec.</summary>
		public D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC MinResolutionSupported;

		/// <summary>Receives the maximum resolution supported for the specified codec.</summary>
		public D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC MaxResolutionSupported;

		/// <summary>A UINT specifying a number by which the resolution width component must be divisible.</summary>
		public uint ResolutionWidthMultipleRequirement;

		/// <summary>A UINT specifying a number by which the resolution height component must be divisible.</summary>
		public uint ResolutionHeightMultipleRequirement;

		/// <summary>
		/// Receives a list of <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_RATIO_DESC</c> representing the supported resolution ratios for the
		/// specified codec as irreducible fractions. The caller must allocate the memory for this array based on the
		/// <b>ResolutionRatiosCount</b> field, and assign it to the query struct the call to ID3D12VideoDevice::CheckFeatureSupport.
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_RATIO_DESC> pResolutionRatios;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT</c>. Retrieves the number of supported resolution ratios for the
	/// specified codec.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_output_resolution_ratios_count
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// UINT ResolutionRatiosCount; } D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_OUTPUT_RESOLUTION_RATIOS_COUNT
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which the number of supported resolution
		/// ratios is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>Receives a UINT indicating the number of supported resolution ratios for the specified codec.</summary>
		public uint ResolutionRatiosCount;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_PROFILE_LEVEL</c>. Retrieves a value indicating if the specified profile is supported for video encoding.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_profile_level typedef
	// struct D3D12_FEATURE_DATA_VIDEO_ENCODER_PROFILE_LEVEL { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC Profile; BOOL IsSupported; D3D12_VIDEO_ENCODER_LEVEL_SETTING MinSupportedLevel;
	// D3D12_VIDEO_ENCODER_LEVEL_SETTING MaxSupportedLevel; } D3D12_FEATURE_DATA_VIDEO_ENCODER_PROFILE_LEVEL;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_PROFILE_LEVEL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_PROFILE_LEVEL
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which the supported profile level is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the profile for which support is being queried.</summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC Profile;

		/// <summary>Receives a boolean value indicating if the specified profile is supported for the specified codec.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;

		/// <summary>Output field that receives the minimum supported level for the selected codec and profile if supported.</summary>
		public D3D12_VIDEO_ENCODER_LEVEL_SETTING MinSupportedLevel;

		/// <summary>Output field that receives the maximum supported level for the selected codec and profile if supported.</summary>
		public D3D12_VIDEO_ENCODER_LEVEL_SETTING MaxSupportedLevel;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_RATE_CONTROL_MODE</c>. Retrieves a value indicating if the specified rate control mode is supported
	/// for video encoding with the specified codec.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_rate_control_mode
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_RATE_CONTROL_MODE { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE RateControlMode; BOOL IsSupported; } D3D12_FEATURE_DATA_VIDEO_ENCODER_RATE_CONTROL_MODE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_RATE_CONTROL_MODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_RATE_CONTROL_MODE
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which rate control mode support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE</c> enumeration specifying the rate control mode for which support is
		/// being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE RateControlMode;

		/// <summary>Receives a boolean value indicating if the specified rate control mode is supported for the specified codec.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;
	}

	/// <summary>Represents the video encoder resolution support limits for a <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT</c> structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_resolution_support_limits
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS { UINT MaxSubregionsNumber; UINT
	// MaxIntraRefreshFrameDuration; UINT SubregionBlockPixelsSize; UINT QPMapRegionPixelsSize; } D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS
	{
		/// <summary>
		/// The maximum number of subregions per frame supported by the encoder for the associated resolution. For the mode
		/// <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_BYTES_PER_SUBREGION</c> this value must be the absolute maximum limit of
		/// subregions per frame to be coded.
		/// </summary>
		public uint MaxSubregionsNumber;

		/// <summary>
		/// The maximum number that can be used in <c>D3D12_VIDEO_ENCODER_INTRA_REFRESH.IntraRefreshDuration</c> for the associated resolution.
		/// </summary>
		public uint MaxIntraRefreshFrameDuration;

		/// <summary>
		/// <para>
		/// The size in pixels of the squared regions that will be used to partition the frame for the subregion layout (e.g. slices)
		/// semantics for the associated resolution. The resolution of the frame will be rounded up to be aligned to this value when it's
		/// partitioned in blocks. The configuration of the subregion partitioning will use a number of squared subregions, that have their
		/// size in pixels according to the returned value in this argument.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// For HEVC, this indicates the resolution block alignment for the compressed bitstream. For example: If SubregionBlockPixelsSize =
		/// 32, then SPS.pic_width/height_in_luma_samples must be aligned to this value and SPS.conf_win_*_offset/conformance_window_flag
		/// indicate the difference between this aligned resolution and the current frame resolution indicated by
		/// <c>D3D12_RESOURCE_DESC.Dimension</c> of the input video texture. SubregionBlockPixelsSize must be aligned to
		/// <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC.MinLumaCodingUnitSize</c> (minCUSize), so
		/// SPS.pic_width/height_in_luma_samples ends up aligned to minCUSize as required by the HEVC codec spec.
		/// </para>
		/// </para>
		/// </summary>
		public uint SubregionBlockPixelsSize;

		/// <summary>
		/// The size in pixels of the squared regions for the associated resolution that will be affected by each of the values in the QP
		/// map buffer in absolute or delta QP modes. The resolution of the frame will be rounded up to be aligned to this value when it's
		/// partitioned in blocks for QP maps and the number of QP values in those maps will be the number of blocks of these indicated
		/// pixel size that comprise a full frame.
		/// </summary>
		public uint QPMapRegionPixelsSize;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_RESOURCE_REQUIREMENTS</c>. Retrieves values indicating resource requirements for video encoding with
	/// the specified encoding configuration.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_resource_requirements
	// typedef struct D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOURCE_REQUIREMENTS { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC Profile; DXGI_FORMAT InputFormat; D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC
	// PictureTargetResolution; BOOL IsSupported; UINT CompressedBitstreamBufferAccessAlignment; UINT EncoderMetadataBufferAccessAlignment;
	// UINT MaxEncoderOutputMetadataBufferSize; } D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOURCE_REQUIREMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOURCE_REQUIREMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOURCE_REQUIREMENTS
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which resource requirements are being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the profile for which resource requirements are being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC Profile;

		/// <summary>A <c>DXGI_FORMAT</c> structure representing the input format for which resource requirements are being queried.</summary>
		public DXGI_FORMAT InputFormat;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC</c> structure representing the resolution for which resource requirements are
		/// being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC PictureTargetResolution;

		/// <summary>Receives a boolean value indicating if the specified parameters are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsSupported;

		/// <summary>
		/// Receives a UINT indicating the alignment required in bytes for the resource to be passed in
		/// <c>D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM.pBuffer</c> and <b>D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM.Offset</b>. If no
		/// alignment is required, 1 should is returned to indicate 1 byte (trivial) alignment.
		/// </summary>
		public uint CompressedBitstreamBufferAccessAlignment;

		/// <summary>
		/// Receives a UINT indicating the alignment required in bytes for the resource to be passed in
		/// D3D12_VIDEO_ENCODER_OUTPUT_ARGUMENTS.pEncoderOutputMetadata. If no alignment required, 1 should be reported to convey 1 byte
		/// (trivial) alignment.
		/// </summary>
		public uint EncoderMetadataBufferAccessAlignment;

		/// <summary>
		/// Receives a UINT indicating the maximum size in bytes needed for the <c>ID3D12Resource</c> that will be allocated by the host and
		/// used as output in the <c>EncodeFrame</c> for output encoder metadata based on the input arguments.
		/// </summary>
		public uint MaxEncoderOutputMetadataBufferSize;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_ENCODER_SUPPORT</c>. Retrieves values indicating support for the specified video encoding features and
	/// configuration values.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The support granted or rejected by this query indicates simultaneous support for all the features selected to be used in the same
	/// encoding session. There can be features that are supported individually when queried with individual query calls but not supported simultaneously.
	/// </para>
	/// <para>
	/// For example, there can be support for intra refresh when checking <c>D3D12_FEATURE_VIDEO_ENCODER_INTRA_REFRESH_MODE</c> and there
	/// can be support for B frames when checking <c>D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264.MaxL1ReferencesForB</c> &gt; 0.
	/// But it can be the case that intra refresh and B frames are not supported simultaneously. In this case, querying
	/// <b>D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT</b> with CodecGopSequence containing B frames and intra refresh row-based mode, the
	/// <b>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_GENERAL_SUPPORT_OK</b> flag will be set off.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_encoder_support typedef struct
	// D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT { UINT NodeIndex; D3D12_VIDEO_ENCODER_CODEC Codec; DXGI_FORMAT InputFormat;
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION CodecConfiguration; D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE CodecGopSequence;
	// D3D12_VIDEO_ENCODER_RATE_CONTROL RateControl; D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE IntraRefresh;
	// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE SubregionFrameEncoding; UINT ResolutionsListCount; const
	// D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC *pResolutionList; UINT MaxReferenceFramesInDPB; D3D12_VIDEO_ENCODER_VALIDATION_FLAGS
	// ValidationFlags; D3D12_VIDEO_ENCODER_SUPPORT_FLAGS SupportFlags; D3D12_VIDEO_ENCODER_PROFILE_DESC SuggestedProfile;
	// D3D12_VIDEO_ENCODER_LEVEL_SETTING SuggestedLevel; D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS
	// *pResolutionDependentSupport; } D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>A member of the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specifying the codec for which support is being queried.</summary>
		public D3D12_VIDEO_ENCODER_CODEC Codec;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the profile for which support is being queried.</summary>
		public DXGI_FORMAT InputFormat;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION</c> structure representing the codec configuration for which support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION CodecConfiguration;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE</c> structure representing the GOP structure for which support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE CodecGopSequence;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_RATE_CONTROL</c> representing the rate control settings for which support is being queried.</summary>
		public D3D12_VIDEO_ENCODER_RATE_CONTROL RateControl;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE</c> enumeration specifying the intra refresh mode for which support is
		/// being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE IntraRefresh;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE</c> enumeration, specifying the subregion layout mode for
		/// which support is being queried.
		/// </summary>
		public D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE SubregionFrameEncoding;

		/// <summary>A UINT specifying the number of resolutions provided in the pResolutionList field.</summary>
		public uint ResolutionsListCount;

		/// <summary>
		/// A pointer to an array of <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC</c> specifying the picture resolutions for which support
		/// is being queried.
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC> pResolutionList;

		/// <summary>
		/// A UINT specifying Maximum number of previous reference frames to be used when calling <c>EncodeFrame</c> for inter-frames. This
		/// value is used to calculate the suggested level returned in the SuggestedLevel field.
		/// </summary>
		public uint MaxReferenceFramesInDPB;

		/// <summary>
		/// Receives a bitwise OR combination of flags from the <c>D3D12_VIDEO_ENCODER_VALIDATION_FLAGS</c> enumeration that provide
		/// additional details if the <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_GENERAL_SUPPORT_OK</c> flag is not set in the SupportFlags field.
		/// See <b>Remarks</b> for more information.
		/// </summary>
		public D3D12_VIDEO_ENCODER_VALIDATION_FLAGS ValidationFlags;

		/// <summary>
		/// Receives a bitwise OR combination of flags from the <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAGS</c> enumeration specifying support
		/// details for the specified encoder features and configuration values.
		/// </summary>
		public D3D12_VIDEO_ENCODER_SUPPORT_FLAGS SupportFlags;

		/// <summary>
		/// Receives a <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> specifying the recommended profile for the specified encoder features and
		/// configuration values.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC SuggestedProfile;

		/// <summary>
		/// Receives a <c>D3D12_VIDEO_ENCODER_LEVEL_SETTING</c> specifying the recommended profile for the specified encoder features and
		/// configuration values. The recommended level assumes the maximum resolution from the list provided in pResolutionList.
		/// </summary>
		public D3D12_VIDEO_ENCODER_LEVEL_SETTING SuggestedLevel;

		/// <summary>
		/// Receives a pointer to an array of <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS</c> structures specifying
		/// resolution-dependent support limits corresponding to the resolutions provided in pResolutionList.
		/// </summary>
		public ArrayPointer<D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS> pResolutionDependentSupport;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_COUNT</c>. Retrieves the supported number of video extension commands.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_extension_command_count typedef
	// struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_COUNT { UINT NodeIndex; UINT CommandCount; } D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_COUNT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_COUNT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_COUNT
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>The supported number of video extension commands.</summary>
		public uint CommandCount;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT</c>. Retrieves the number of video extension command parameters for the
	/// specified parameter stage.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_extension_command_parameter_count
	// typedef struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT { GUID CommandId;
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE Stage; UINT ParameterCount; UINT ParameterPacking; } D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT
	{
		/// <summary>The unique identifier for the video extension command for which the parameter count is queried.</summary>
		public Guid CommandId;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE</c> enumeration specifying the parameter stage for which the
		/// parameter count is retrieved.
		/// </summary>
		public D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE Stage;

		/// <summary>Receives the number of parameters in the parameter stage.</summary>
		public uint ParameterCount;

		/// <summary>Receives the parameter packing for the parameter stage.</summary>
		public uint ParameterPacking;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c>. Retrieves the list of video extension command parameters for the specified
	/// parameter stage.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_extension_command_parameters
	// typedef struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETERS { GUID CommandId; D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE
	// Stage; UINT ParameterCount; D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO *pParameterInfos; } D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETERS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETERS
	{
		/// <summary>The unique identifier for the video extension command for which parameters are retrieved.</summary>
		public Guid CommandId;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE</c> enumeration specifying the parameter stage for which the
		/// parameters are retrieved.
		/// </summary>
		public D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE Stage;

		/// <summary>
		/// The supported number of video extension command parameters. This value must be the count returned by a call to
		/// <c>ID3D12VideoDevice::CheckFeatureSupport</c> with <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETER_COUNT</c> specified as the feature.
		/// </summary>
		public uint ParameterCount;

		/// <summary>
		/// Receives a list of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO</c> structures describing video extension command parameters.
		/// </summary>
		public ManagedArrayPointer<D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO> pParameterInfos;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_SIZE</c>. Checks the allocation size of a video extension command.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_extension_command_size typedef
	// struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SIZE { UINT NodeIndex; GUID CommandId; const void *pCreationParameters; SIZE_T
	// CreationParametersSizeInBytes; UINT64 MemoryPoolL0Size; UINT64 MemoryPoolL1Size; } D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SIZE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SIZE
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>The unique identifier for the video extension command for which size is queried.</summary>
		public Guid CommandId;

		/// <summary>
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CREATION</c>.
		/// </summary>
		public IntPtr pCreationParameters;

		/// <summary>The size of the pCreationParameters parameter structure, in bytes.</summary>
		public SizeT CreationParametersSizeInBytes;

		/// <summary>
		/// The allocation size of the video extension command in the L0 memory pool. L0 is the physical system memory pool. When the
		/// adapter is discrete/NUMA, this pool has greater bandwidth for the CPU and less bandwidth for the GPU. When the adapter is UMA,
		/// this pool is the only one which is valid. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MemoryPoolL0Size;

		/// <summary>
		/// The allocation size of the video extension command heap in the L1 memory pool. L1 is typically known as the physical video
		/// memory pool. L1 is only available when the adapter is discrete/NUMA, and has greater bandwidth for the GPU and cannot even be
		/// accessed by the CPU. When the adapter is UMA, this pool is not available. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MemoryPoolL1Size;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_SUPPORT</c>. Retrieves video extension command support using command-defined input and
	/// output structures.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_extension_command_support
	// typedef struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SUPPORT { UINT NodeIndex; GUID CommandId; const void *pInputData; SIZE_T
	// InputDataSizeInBytes; void *pOutputData; SIZE_T OutputDataSizeInBytes; } D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_SUPPORT
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>The unique identifier for the video extension command for which support is queried.</summary>
		public Guid CommandId;

		/// <summary>
		/// Input data for the capability query allocated by the caller with a size of InputDataSizeInBytes. This struct is enumerable as
		/// the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CAPS_INPUT</c> parameter stage.
		/// </summary>
		public IntPtr pInputData;

		/// <summary>The byte size of the input data allocation.</summary>
		public SizeT InputDataSizeInBytes;

		/// <summary>
		/// Output data for the capability query allocated by the caller with a size of OutputDataSizeInBytes. This struct is enumerable as
		/// the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CAPS_OUTPUT</c> parameter stage.
		/// </summary>
		public IntPtr pOutputData;

		/// <summary>The byte size of the output data allocation.</summary>
		public SizeT OutputDataSizeInBytes;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMANDS</c>. Retrieves the list of video extension commands from the driver.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_extension_commands typedef
	// struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMANDS { UINT NodeIndex; UINT CommandCount; D3D12_VIDEO_EXTENSION_COMMAND_INFO
	// *pCommandInfos; } D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMANDS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMANDS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMANDS
	{
		/// <summary>In multi-adapter operation, this indicates which physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// The supported number of video extension commands. This value must be the count returned by a call to
		/// <c>ID3D12VideoDevice::CheckFeatureSupport</c> with <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_COUNT</c> specified as the feature.
		/// </summary>
		public uint CommandCount;

		/// <summary>Receives a list of <c>D3D12_VIDEO_EXTENSION_COMMAND_INFO</c> structures describing video extension commands.</summary>
		public ManagedArrayPointer<D3D12_VIDEO_EXTENSION_COMMAND_INFO> pCommandInfos;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR</c>. Retrieves the motion estimation capabilities for a video encoder.
	/// </summary>
	/// <remarks>
	/// When the format is not supported with motion estimation, BlockSizeFlags will be set to
	/// <c>D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAG_NONE</c>, PrecisionFlags will be set to
	/// <c>D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAG_NONE</c>, and the SizeRange will be set to all zeros.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_motion_estimator typedef struct
	// D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR { UINT NodeIndex; DXGI_FORMAT InputFormat;
	// D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAGS BlockSizeFlags; D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAGS
	// PrecisionFlags; D3D12_VIDEO_SIZE_RANGE SizeRange; } D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR
	{
		/// <summary>In multi-adapter operation, identifies the physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>A <c>DXGI_FORMAT</c> structure specifying the format of the input resources.</summary>
		public DXGI_FORMAT InputFormat;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAGS</c> enumeration specifying
		/// the encoder's supported search block sizes for motion estimation.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE_FLAGS BlockSizeFlags;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAGS</c> enumeration specifying
		/// the encoder's supported vector precision for motion estimation.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION_FLAGS PrecisionFlags;

		/// <summary>
		/// A <c>D3D12_VIDEO_SIZE_RANGE</c> structure representing the minimum and maximum input size supported by the driver. The driver
		/// sets the fields of this structure to zero if motion estimation is unsupported.
		/// </summary>
		public D3D12_VIDEO_SIZE_RANGE SizeRange;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES</c>. Retrieves the protected resources support for video motion estimation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_motion_estimator_protected_resources
	// typedef struct D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES { UINT NodeIndex;
	// D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAGS SupportFlags; } D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_PROTECTED_RESOURCES
	{
		/// <summary>In multi-adapter operation, identifies the physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAGS</c> enumeration specifying support for protected resources.
		/// </summary>
		public D3D12_VIDEO_PROTECTED_RESOURCE_SUPPORT_FLAGS SupportFlags;
	}

	/// <summary>Describes the allocation size of a video motion estimator heap.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_motion_estimator_size typedef
	// struct D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_SIZE { UINT NodeIndex; DXGI_FORMAT InputFormat;
	// D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE BlockSize; D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION Precision;
	// D3D12_VIDEO_SIZE_RANGE SizeRange; BOOL Protected; UINT64 MotionVectorHeapMemoryPoolL0Size; UINT64 MotionVectorHeapMemoryPoolL1Size;
	// UINT64 MotionEstimatorMemoryPoolL0Size; UINT64 MotionEstimatorMemoryPoolL1Size; } D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_SIZE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_MOTION_ESTIMATOR_SIZE
	{
		/// <summary>In multi-adapter operation, identifies the physical adapter of the device this operation applies to.</summary>
		public uint NodeIndex;

		/// <summary>A <c>DXGI_FORMAT</c> structure specifying the format of the input and reference resources.</summary>
		public DXGI_FORMAT InputFormat;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE</c> specifying the search block size for motion estimation.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE BlockSize;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION</c> specifying the search block size for motion estimation.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION Precision;

		/// <summary>
		/// A <c>D3D12_VIDEO_SIZE_RANGE</c> structure representing the minimum and maximum input and reference frame size, in pixels, used
		/// by the motion estimator.
		/// </summary>
		public D3D12_VIDEO_SIZE_RANGE SizeRange;

		/// <summary>TRUE if the motion estimator operates on protected resource input and produces protected output; otherwise, FALSE.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Protected;

		/// <summary>
		/// The allocation size of the motion vector heap in the L0 memory pool. L0 is the physical system memory pool. When the adapter is
		/// discrete/NUMA, this pool has greater bandwidth for the CPU and less bandwidth for the GPU. When the adapter is UMA, this pool is
		/// the only one which is valid. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MotionVectorHeapMemoryPoolL0Size;

		/// <summary>
		/// The allocation size of the motion vector heap in the L1 memory pool. L1 is typically known as the physical video memory pool. L1
		/// is only available when the adapter is discrete/NUMA, and has greater bandwidth for the GPU and cannot even be accessed by the
		/// CPU. When the adapter is UMA, this pool is not available. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MotionVectorHeapMemoryPoolL1Size;

		/// <summary>
		/// The allocation size of the motion estimator heap in the L0 memory pool. L0 is the physical system memory pool. When the adapter
		/// is discrete/NUMA, this pool has greater bandwidth for the CPU and less bandwidth for the GPU. When the adapter is UMA, this pool
		/// is the only one which is valid. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MotionEstimatorMemoryPoolL0Size;

		/// <summary>
		/// The allocation size of the motion estimator heap in the L1 memory pool. L1 is typically known as the physical video memory pool.
		/// L1 is only available when the adapter is discrete/NUMA, and has greater bandwidth for the GPU and cannot even be accessed by the
		/// CPU. When the adapter is UMA, this pool is not available. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MotionEstimatorMemoryPoolL1Size;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_PROCESS_MAX_INPUT_STREAMS</c>. Retrieves the maximum number of enabled input streams supported by the video processor.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_process_max_input_streams
	// typedef struct D3D12_FEATURE_DATA_VIDEO_PROCESS_MAX_INPUT_STREAMS { UINT NodeIndex; UINT MaxInputStreams; } D3D12_FEATURE_DATA_VIDEO_PROCESS_MAX_INPUT_STREAMS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_PROCESS_MAX_INPUT_STREAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_PROCESS_MAX_INPUT_STREAMS
	{
		/// <summary>An integer indicating which physical adapter of the device the operation applies to, in a multi-adapter operation.</summary>
		public uint NodeIndex;

		/// <summary>The maximum number of streams that can be enabled for the video processor at the same time.</summary>
		public uint MaxInputStreams;
	}

	/// <summary>
	/// Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is
	/// <c>D3D12_FEATURE_VIDEO_PROCESS_REFERENCE_INFO</c>. Retrieves the number of past and future reference frames required for the
	/// specified deinterlace mode, filter, rate conversion, or auto processing features.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_process_reference_info typedef
	// struct D3D12_FEATURE_DATA_VIDEO_PROCESS_REFERENCE_INFO { UINT NodeIndex; D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS DeinterlaceMode;
	// D3D12_VIDEO_PROCESS_FILTER_FLAGS Filters; D3D12_VIDEO_PROCESS_FEATURE_FLAGS FeatureSupport; DXGI_RATIONAL InputFrameRate;
	// DXGI_RATIONAL OutputFrameRate; BOOL EnableAutoProcessing; UINT PastFrames; UINT FutureFrames; } D3D12_FEATURE_DATA_VIDEO_PROCESS_REFERENCE_INFO;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_PROCESS_REFERENCE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_PROCESS_REFERENCE_INFO
	{
		/// <summary>An integer indicating which physical adapter of the device the operation applies to, in a multi-adapter operation.</summary>
		public uint NodeIndex;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS</c> enumeration specifying the deinterlacing mode for which the
		/// required past and future reference frame counts are retrieved.
		/// </summary>
		public D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS DeinterlaceMode;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_PROCESS_FILTER_FLAGS</c> enumeration specifying the filters for which
		/// the required past and future reference frame counts are retrieved.
		/// </summary>
		public D3D12_VIDEO_PROCESS_FILTER_FLAGS Filters;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_PROCESS_FEATURE_FLAGS</c> enumeration specifying the features for
		/// which the required past and future reference frame counts are retrieved.
		/// </summary>
		public D3D12_VIDEO_PROCESS_FEATURE_FLAGS FeatureSupport;

		/// <summary>The input frame rate of the stream for which the required past and future reference frame counts are retrieved.</summary>
		public DXGI_RATIONAL InputFrameRate;

		/// <summary>The output frame rate of the stream for which the required past and future reference frame counts are retrieved.</summary>
		public DXGI_RATIONAL OutputFrameRate;

		/// <summary>True if autoprocessing will be used; otherwise, false.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool EnableAutoProcessing;

		/// <summary>The number of past frames required to support the specified processing features.</summary>
		public uint PastFrames;

		/// <summary>The number of future frames required to support the specified processing features.</summary>
		public uint FutureFrames;
	}

	/// <summary>Provides data for calls to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is <c>D3D12_FEATURE_VIDEO_PROCESS_SUPPORT</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_process_support typedef struct
	// D3D12_FEATURE_DATA_VIDEO_PROCESS_SUPPORT { UINT NodeIndex; D3D12_VIDEO_SAMPLE InputSample; D3D12_VIDEO_FIELD_TYPE InputFieldType;
	// D3D12_VIDEO_FRAME_STEREO_FORMAT InputStereoFormat; DXGI_RATIONAL InputFrameRate; D3D12_VIDEO_FORMAT OutputFormat;
	// D3D12_VIDEO_FRAME_STEREO_FORMAT OutputStereoFormat; DXGI_RATIONAL OutputFrameRate; D3D12_VIDEO_PROCESS_SUPPORT_FLAGS SupportFlags;
	// D3D12_VIDEO_SCALE_SUPPORT ScaleSupport; D3D12_VIDEO_PROCESS_FEATURE_FLAGS FeatureSupport; D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS
	// DeinterlaceSupport; D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAGS AutoProcessingSupport; D3D12_VIDEO_PROCESS_FILTER_FLAGS FilterSupport;
	// D3D12_VIDEO_PROCESS_FILTER_RANGE FilterRangeSupport[32]; } D3D12_FEATURE_DATA_VIDEO_PROCESS_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_PROCESS_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_PROCESS_SUPPORT
	{
		/// <summary>An integer indicating which physical adapter of the device the operation applies to, in a multi-adapter operation.</summary>
		public uint NodeIndex;

		/// <summary>A <c>D3D12_VIDEO_SAMPLE</c> structure defining the width, height, and format of the input sample.</summary>
		public D3D12_VIDEO_SAMPLE InputSample;

		/// <summary>A member of the <c>D3D12_VIDEO_FIELD_TYPE</c> enumeration specifying the interlaced field type of the input sample.</summary>
		public D3D12_VIDEO_FIELD_TYPE InputFieldType;

		/// <summary>A member of the <c>D3D12_VIDEO_FRAME_STEREO_FORMAT</c> enumeration specifying the stereo format of the input sample.</summary>
		public D3D12_VIDEO_FRAME_STEREO_FORMAT InputStereoFormat;

		/// <summary>The input frame rate.</summary>
		public DXGI_RATIONAL InputFrameRate;

		/// <summary>A <c>D3D12_VIDEO_FORMAT</c> structure specifying the output DXGI format and color space.</summary>
		public D3D12_VIDEO_FORMAT OutputFormat;

		/// <summary>A member of the <c>D3D12_VIDEO_FRAME_STEREO_FORMAT</c> enumeration specifying the stereo format of the output.</summary>
		public D3D12_VIDEO_FRAME_STEREO_FORMAT OutputStereoFormat;

		/// <summary>The output frame rate.</summary>
		public DXGI_RATIONAL OutputFrameRate;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_PROCESS_SUPPORT_FLAGS</c> indicating whether the requested format and colorspace conversion is
		/// supported. This value is populated by the call to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_PROCESS_SUPPORT_FLAGS SupportFlags;

		/// <summary>
		/// A <c>D3D12_VIDEO_SCALE_SUPPORT</c> structure specifying the supported scaling capabilities. This value is populated by the call
		/// to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_SCALE_SUPPORT ScaleSupport;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_PROCESS_FEATURE_FLAGS</c> enumeration specifying the supported video
		/// processing features. This value is populated by the call to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_PROCESS_FEATURE_FLAGS FeatureSupport;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS</c> enumeration specifying the supported deinterlacing capabilities.
		/// This value is populated by the call to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS DeinterlaceSupport;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAGS</c> specifying the supported automatic processing capabilities.
		/// This value is populated by the call to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_PROCESS_AUTO_PROCESSING_FLAGS AutoProcessingSupport;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_PROCESS_FILTER_FLAGS</c> enumeration specifying the supported video
		/// filtering features. This value is populated by the call to <b>ID3D12Device::CheckFeatureSupport</b>.
		/// </summary>
		public D3D12_VIDEO_PROCESS_FILTER_FLAGS FilterSupport;

		/// <summary>
		/// An array of <c>D3D12_VIDEO_PROCESS_FILTER_RANGE</c> structures representing the filter range values. This value is populated by
		/// the call to <b>ID3D12Device::CheckFeatureSupport</b>. The calling application must allocate the memory for the filter range list
		/// before calling <b>CheckFeatureSupport</b>.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public D3D12_VIDEO_PROCESS_FILTER_RANGE[] FilterRangeSupport;
	}

	/// <summary>Describes the allocation size of a video decoder heap.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_feature_data_video_processor_size typedef struct
	// D3D12_FEATURE_DATA_VIDEO_PROCESSOR_SIZE { UINT NodeMask; const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *pOutputStreamDesc; UINT
	// NumInputStreamDescs; const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs; UINT64 MemoryPoolL0Size; UINT64
	// MemoryPoolL1Size; } D3D12_FEATURE_DATA_VIDEO_PROCESSOR_SIZE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_FEATURE_DATA_VIDEO_PROCESSOR_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_VIDEO_PROCESSOR_SIZE
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// A pointer to a D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_output_stream_desc) structure describing
		/// the output stream.
		/// </summary>
		public ManagedStructPointer<D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC> pOutputStreamDesc;

		/// <summary>The number of input streams provided in the pInputStreamDescs parameter.</summary>
		public uint NumInputStreamDescs;

		/// <summary>
		/// A pointer to a list of D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_input_stream_desc) structures the
		/// input streams.
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC> pInputStreamDescs;

		/// <summary>
		/// The allocation size of the video processor in the L0 memory pool. L0 is the physical system memory pool. When the adapter is
		/// discrete/NUMA, this pool has greater bandwidth for the CPU and less bandwidth for the GPU. When the adapter is UMA, this pool is
		/// the only one which is valid. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MemoryPoolL0Size;

		/// <summary>
		/// The allocation size of the video processor in the L1 memory pool. L1 is typically known as the physical video memory pool. L1 is
		/// only available when the adapter is discrete/NUMA, and has greater bandwidth for the GPU and cannot even be accessed by the CPU.
		/// When the adapter is UMA, this pool is not available. For more information, see <c>Residency</c>.
		/// </summary>
		public ulong MemoryPoolL1Size;
	}

	/// <summary>Represents data for a video decode statistics query invoked by calling <c>ID3D12VideoDecodeCommandList::EndQuery</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_query_data_video_decode_statistics typedef struct
	// D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS { UINT64 Status; UINT64 NumMacroblocksAffected; DXGI_RATIONAL FrameRate; UINT BitRate; } D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS
	{
		/// <summary>A member of the <c>D3D12_VIDEO_DECODE_STATUS</c> enumeration indicating the video decoding status.</summary>
		public ulong Status;

		/// <summary>
		/// If <b>Status</b> is not 0, this member contains the accelerator's estimate of the number of super-blocks in the decoded frame
		/// that were adversely affected by the reported problem. If the accelerator does not provide an estimate, the value is
		/// <b>D3D12_VIDEO_DECODE_MACROBLOCKS_AFFECTED_UNKNOWN</b> (0xFFFFFFFFFFFFFFFF).
		/// </summary>
		public ulong NumMacroblocksAffected;

		/// <summary>The decode frame rate.</summary>
		public DXGI_RATIONAL FrameRate;

		/// <summary>
		/// <para>
		/// When the <b>Status</b> returned is <c>D3D12_VIDEO_DECODE_STATUS_RATE_EXCEEDED</c>, this field reports the bitrate that would
		/// succeed. This value may be used to recreate the decoder and try again. A value of zero here is valid to indicate that the worst
		/// case bit rate should be assumed.
		/// </para>
		/// <para>For all other <b>Status</b> values, <b>BitRate</b> is set to zero.</para>
		/// </summary>
		public uint BitRate;
	}

	/// <summary>Provides input data for calls to <c>ID3D12VideoEncodeCommandList::ResolveMotionVectorHeap</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_resolve_video_motion_vector_heap_input typedef
	// struct D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT { ID3D12VideoMotionVectorHeap *pMotionVectorHeap; UINT PixelWidth; UINT
	// PixelHeight; } D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT
	{
		/// <summary>The <c>ID3D12VideoMotionVectorHeap</c> containing the hardware-dependent data layout of the motion search.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12VideoMotionVectorHeap pMotionVectorHeap;

		/// <summary>
		/// The pixel width of the texture that the motion estimation operation was performed on. The motion estimator heap may be allocated
		/// to support a size range, this parameter informs the size of the last motion estimation operation.
		/// </summary>
		public uint PixelWidth;

		/// <summary>
		/// The pixel height of the texture that the motion estimation operation was performed on. The motion estimator heap may be
		/// allocated to support a size range, this parameter informs the size of the last motion estimation operation.
		/// </summary>
		public uint PixelHeight;
	}

	/// <summary>Receives output data from calls to <c>ID3D12VideoEncodeCommandList::ResolveMotionVectorHeap</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_resolve_video_motion_vector_heap_output typedef
	// struct D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT { ID3D12Resource *pMotionVectorTexture2D; D3D12_RESOURCE_COORDINATE
	// MotionVectorCoordinate; } D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT
	{
		/// <summary>
		/// An <c>ID3D12Resource</c> representing the output resource for resolved motion vectors. Motion vectors are resolved to
		/// <c>DXGI_FORMAT_R16G16_SINT</c> 2D textures. The resolved data is a signed 16-byte integer with quarter PEL units with the X
		/// vector component stored in the R component and the Y vector component stored in the G component. Motion vectors are stored in a
		/// 2D layout that corresponds to the pixel layout of the original input textures.
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pMotionVectorTexture2D;

		/// <summary>
		/// A <c>D3D12_RESOURCE_COORDINATE</c> structure specifying the output origin of the motion vectors. The remaining sub-region must
		/// be large enough to store all motion vectors per block specified by the input pixel with and pixel height and the specified <c>D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE</c>.
		/// </summary>
		public D3D12_RESOURCE_COORDINATE MotionVectorCoordinate;
	}

	/// <summary>Describes the coordinates of a resource.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_resource_coordinate typedef struct
	// D3D12_RESOURCE_COORDINATE { UINT64 X; UINT Y; UINT Z; UINT SubresourceIndex; } D3D12_RESOURCE_COORDINATE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_RESOURCE_COORDINATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOURCE_COORDINATE
	{
		/// <summary>The x-coordinate of the resource.</summary>
		public ulong X;

		/// <summary>The y-coordinate of the resource.</summary>
		public uint Y;

		/// <summary>The z-coordinate of the resource.</summary>
		public uint Z;

		/// <summary>The index of the subresource for the resource.</summary>
		public uint SubresourceIndex;
	}

	/// <summary>Represents a compressed bitstream from which video is decoded.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_compressed_bitstream typedef struct
	// D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM { ID3D12Resource *pBuffer; UINT64 Offset; UINT64 Size; } D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM
	{
		/// <summary>A pointer to an <c>ID3D12Resource</c> representing the source buffer containing the compressed bitstream to decode.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pBuffer;

		/// <summary>
		/// The offset to the beginning of the first slice. This offset has alignment requirements based on the tier value of the video
		/// decoder. For more information on decoding tiers, see <c>D3D12_VIDEO_DECODE_TIER</c>.
		/// </summary>
		public ulong Offset;

		/// <summary>The size of the subregion of pBuffer that contains the bitstream.</summary>
		public ulong Size;
	}

	/// <summary>Describes the configuration for a video decoder.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_configuration typedef struct
	// D3D12_VIDEO_DECODE_CONFIGURATION { GUID DecodeProfile; D3D12_BITSTREAM_ENCRYPTION_TYPE BitstreamEncryption;
	// D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE InterlaceType; } D3D12_VIDEO_DECODE_CONFIGURATION;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_CONFIGURATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_CONFIGURATION
	{
		/// <summary>
		/// A GUID identifying the profile for the decoder, such as D3D12_VIDEO_DECODE_PROFILE_H264 or D3D12_VIDEO_DECODE_PROFILE_HEVC_MAIN.
		/// For a list of supported GUIDs, see <c>Direct3D 12 Video GUIDs</c>.
		/// </summary>
		public Guid DecodeProfile;

		/// <summary>
		/// A member of the <c>D3D12_BITSTREAM_ENCRYPTION_TYPE</c> enumeration specifying the type of bitstream encryption. For no
		/// encryption, use D3D12_BITSTREAM_ENCRYPTION_TYPE_NONE.
		/// </summary>
		public D3D12_BITSTREAM_ENCRYPTION_TYPE BitstreamEncryption;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE</c> enumeration the desired interlace type used by the coded frames.
		/// </summary>
		public D3D12_VIDEO_FRAME_CODED_INTERLACE_TYPE InterlaceType;
	}

	/// <summary>
	/// Specifies the parameters for decode output conversion. <c>D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS1</c> is used for the same purpose,
	/// but provides additional fields for output width and output height.
	/// </summary>
	/// <remarks>
	/// <para>Scaling is specified by the difference between the native decode texture size and the output texture size.</para>
	/// <para>Use <c>D3D12_FEATURE_VIDEO_DECODE_CONVERSION_SUPPORT</c> to determine if a conversion combination is supported.</para>
	/// <para>
	/// The source and destination resolution and format are communicated by the resource properties of decode textures and the output
	/// buffer specified in <c>ID3D12VideoCommandList::DecodeFrame</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_conversion_arguments typedef struct
	// D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS { BOOL Enable; ID3D12Resource *pReferenceTexture2D; UINT ReferenceSubresource;
	// DXGI_COLOR_SPACE_TYPE OutputColorSpace; DXGI_COLOR_SPACE_TYPE DecodeColorSpace; } D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS
	{
		/// <summary>A boolean value indicating whether decode conversion should be used.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Enable;

		/// <summary>
		/// A pointer to an <c>ID3D12Resource</c> containing the native decoding output. When downsampling is enabled, the output at native
		/// decode resolution, color space, and format may be required for future decode submissions (as reference frames, for instance).
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pReferenceTexture2D;

		/// <summary>The subresource index of the resource provided in pDecodeTexture2D to use.</summary>
		public uint ReferenceSubresource;

		/// <summary>A value from the <c>DXGI_COLOR_SPACE_TYPE</c> enumeration specifying the target color space of the output.</summary>
		public DXGI_COLOR_SPACE_TYPE OutputColorSpace;

		/// <summary>A value from the <c>DXGI_COLOR_SPACE_TYPE</c> enumeration specifying the source-decoded color space before conversion.</summary>
		public DXGI_COLOR_SPACE_TYPE DecodeColorSpace;
	}

	/// <summary>
	/// Specifies the parameters for decode output conversion. <c>D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS</c> is used for the same purpose,
	/// but does not contain fields for output width and output height.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_conversion_arguments1 typedef struct
	// D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS1 { BOOL Enable; ID3D12Resource *pReferenceTexture2D; UINT ReferenceSubresource;
	// DXGI_COLOR_SPACE_TYPE OutputColorSpace; DXGI_COLOR_SPACE_TYPE DecodeColorSpace; UINT OutputWidth; UINT OutputHeight; } D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS1;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS1
	{
		/// <summary>A boolean value indicating whether decode conversion should be used.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Enable;

		/// <summary>
		/// A pointer to an <c>ID3D12Resource</c> containing the native decoding output. When downsampling is enabled, the output at native
		/// decode resolution, color space, and format may be required for future decode submissions (as reference frames, for instance).
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pReferenceTexture2D;

		/// <summary>The subresource index of the resource provided in pDecodeTexture2D to use.</summary>
		public uint ReferenceSubresource;

		/// <summary>A value from the <c>DXGI_COLOR_SPACE_TYPE</c> enumeration specifying the target color space of the output.</summary>
		public DXGI_COLOR_SPACE_TYPE OutputColorSpace;

		/// <summary>A value from the <c>DXGI_COLOR_SPACE_TYPE</c> enumeration specifying the source-decoded color space before conversion.</summary>
		public DXGI_COLOR_SPACE_TYPE DecodeColorSpace;

		/// <summary>The output width, in pixels.</summary>
		public uint OutputWidth;

		/// <summary>The output width, in pixels.</summary>
		public uint OutputHeight;
	}

	/// <summary>
	/// Represents the decode parameters for a frame. Parameter definitions are specified by the codec specification for each decode profile.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_frame_argument typedef struct
	// D3D12_VIDEO_DECODE_FRAME_ARGUMENT { D3D12_VIDEO_DECODE_ARGUMENT_TYPE Type; UINT Size; void *pData; } D3D12_VIDEO_DECODE_FRAME_ARGUMENT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_FRAME_ARGUMENT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_FRAME_ARGUMENT
	{
		/// <summary>A member of the <c>D3D12_VIDEO_DECODE_ARGUMENT_TYPE</c> enumeration specifying the type of argument.</summary>
		public D3D12_VIDEO_DECODE_ARGUMENT_TYPE Type;

		/// <summary>The size of the data in pArgument, in bytes.</summary>
		public uint Size;

		/// <summary>A pointer to the argument data.</summary>
		public IntPtr pData;
	}

	/// <summary>Specifies the parameters for the input stream for a video decode operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_input_stream_arguments typedef struct
	// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS { UINT NumFrameArguments; D3D12_VIDEO_DECODE_FRAME_ARGUMENT FrameArguments[10];
	// D3D12_VIDEO_DECODE_REFERENCE_FRAMES ReferenceFrames; D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM CompressedBitstream;
	// ID3D12VideoDecoderHeap *pHeap; } D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS
	{
		/// <summary>The count of frame parameters provided in the FrameArguments field. The maximum number of frame arguments is 10.</summary>
		public uint NumFrameArguments;

		/// <summary>An array of <c>D3D12_VIDEO_DECODE_FRAME_ARGUMENT</c> structures containing the parameters to decode a frame.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public D3D12_VIDEO_DECODE_FRAME_ARGUMENT[] FrameArguments;

		/// <summary>A <c>D3D12_VIDEO_DECODE_REFERENCE_FRAMES</c> structure containing the reference frames needed to decode a frame.</summary>
		public D3D12_VIDEO_DECODE_REFERENCE_FRAMES ReferenceFrames;

		/// <summary>
		/// A <c>D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM</c> structure representing the compressed bitstream in a single continuous buffer.
		/// </summary>
		public D3D12_VIDEO_DECODE_COMPRESSED_BITSTREAM CompressedBitstream;

		/// <summary>An <c>ID3D12VideoDecoderHeap</c> representing a pointer to the heap for the current decode resolution.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12VideoDecoderHeap pHeap;
	}

	/// <summary>Represents the histogram output buffer for a single component.</summary>
	/// <remarks>
	/// <para>Histogram output buffers are provided in the Histograms field of the <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> structure.</para>
	/// <para>The following <c>D3D12_HEAP_FLAGS</c> are allowed when allocating heaps for video decode histograms.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_HEAP_FLAG_SHARED</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_ALLOW_DISPLAY</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_HARDWARE_PROTECTED</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_ALLOW_WRITE_WATCH</description>
	/// </item>
	/// </list>
	/// <para>The following <c>D3D12_HEAP_FLAGS</c> are not allowed when allocating heaps for video decode histograms.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_HEAP_FLAG_DENY_BUFFERS</description>
	/// </item>
	/// </list>
	/// <para>The following <c>D3D12_RESOURCE_FLAGS</c> are allowed when allocating resources for video decode histograms.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_TEXTURE_DATA_INHERITANCE</description>
	/// </item>
	/// </list>
	/// <para>The following <c>D3D12_RESOURCE_FLAGS</c> are not allowed when allocating resources for video decode histograms.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_DENY_SHADER_RESOURCE</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_ONLY_NON_RT_DS_TEXTURE_PLACEMENT</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_ONLY_RT_DS_TEXTURE_PLACEMENT</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_output_histogram typedef struct
	// D3D12_VIDEO_DECODE_OUTPUT_HISTOGRAM { UINT64 Offset; ID3D12Resource *pBuffer; } D3D12_VIDEO_DECODE_OUTPUT_HISTOGRAM;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_OUTPUT_HISTOGRAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_OUTPUT_HISTOGRAM
	{
		/// <summary>
		/// The offset location in pBuffer to write the component histogram. Must be 256-byte aligned. Set to zero when a component is disabled.
		/// </summary>
		public ulong Offset;

		/// <summary>
		/// And <c>ID3D12Resource</c> representing the target buffer for hardware to write the components histogram. Set to a nullptr when
		/// the component histogram is disabled.
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pBuffer;
	}

	/// <summary>
	/// Specifies the parameters for the output stream for a video decode operation. <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> is
	/// used for the same purpose, but provides an additional field for histograms.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_output_stream_arguments typedef
	// struct D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS { ID3D12Resource *pOutputTexture2D; UINT OutputSubresource;
	// D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS ConversionArguments; } D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS
	{
		/// <summary>
		/// An <c>ID3D12Resource</c> representing the output texture. If decode conversion is enabled, this texture will contain the
		/// post-conversion output. If decode conversion is not enabled, this texture will contain the decode output.
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pOutputTexture2D;

		/// <summary>
		/// The index of the output subresource of pOutputTexture2D to use. This allows you to specify array indices if the output is an array.
		/// </summary>
		public uint OutputSubresource;

		/// <summary>An optional <c>D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS</c> structure containing output conversion parameters.</summary>
		public D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS ConversionArguments;
	}

	/// <summary>
	/// Specifies the parameters for the output stream for a video decode operation. <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS</c> is
	/// used for the same purpose, but does not provide a field for histograms.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_output_stream_arguments1 typedef
	// struct D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1 { ID3D12Resource *pOutputTexture2D; UINT OutputSubresource;
	// D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS1 ConversionArguments; D3D12_VIDEO_DECODE_OUTPUT_HISTOGRAM Histograms[4]; } D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1
	{
		/// <summary>
		/// An <c>ID3D12Resource</c> representing the output texture. If decode conversion is enabled, this texture will contain the
		/// post-conversion output. If decode conversion is not enabled, this texture will contain the decode output.
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pOutputTexture2D;

		/// <summary>
		/// The index of the output subresource of pOutputTexture2D to use. This allows you to specify array indices if the output is an array.
		/// </summary>
		public uint OutputSubresource;

		/// <summary>An optional <c>D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS</c> structure containing output conversion parameters.</summary>
		public D3D12_VIDEO_DECODE_CONVERSION_ARGUMENTS1 ConversionArguments;

		/// <summary>
		/// An array of <c>D3D12_VIDEO_DECODE_OUTPUT_HISTOGRAM</c> structures that are populated with histogram data. The maximum size of
		/// the array is 4.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public D3D12_VIDEO_DECODE_OUTPUT_HISTOGRAM Histograms;
	}

	/// <summary>
	/// Contains the list of reference frames for the current decode operation. Either a texture array or an array of textures can be specified.
	/// </summary>
	/// <remarks>
	/// Reference textures may have limitations such as a requirement to allocate reference buffers as a texture array. For information on
	/// the requirements for different decoder configurations, see <c>D3D12_VIDEO_DECODE_TIER</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decode_reference_frames typedef struct
	// D3D12_VIDEO_DECODE_REFERENCE_FRAMES { UINT NumTexture2Ds; ID3D12Resource **ppTexture2Ds; UINT *pSubresources; ID3D12VideoDecoderHeap
	// **ppHeaps; } D3D12_VIDEO_DECODE_REFERENCE_FRAMES;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODE_REFERENCE_FRAMES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODE_REFERENCE_FRAMES
	{
		/// <summary>The number of references specified in the ppTexture2Ds field.</summary>
		public uint NumTexture2Ds;

		/// <summary>
		/// A list of reference textures. When specifying texture arrays, each entry will be point to the same resource. When specifying an
		/// array of textures, each entry will point to a separate resource.
		/// </summary>
		public IntPtr ppTexture2Ds;

		/// <summary>
		/// <para>
		/// An array of subresource indices for the reference textures specified in ppTexture2Ds. NULL indicates that subresource 0 should
		/// be assumed for each resource.
		/// </para>
		/// <para>
		/// With texture arrays within a single resource, the subresource indices point to the array index of the first resource plane. With
		/// an array of textures in individual resources, the subresource index is typically zero.
		/// </para>
		/// <para>
		/// The video device driver uses the "PicEntry" indices defined in the DXVA spec for the codec to dereference this array to find the
		/// subresource index to use with the corresponding resource. For example, in HEVC, the Driver uses
		/// <c>DXVA_PicEntry_HEVC::Index7Bits</c> as an index for this array.
		/// </para>
		/// </summary>
		public ArrayPointer<uint> pSubresources;

		/// <summary>
		/// An array of <c>ID3D12VideoDecoderHeap</c> objects. This field is used with formats that support non-key frame resolution
		/// changes, allowing the caller to pass in the previous resolution's heap, relative to the reference it's being used for, in
		/// addition to the current resolution heap.
		/// </summary>
		public IntPtr ppHeaps;
	}

	/// <summary>
	/// Describes a <c>ID3D12VideoDecoder</c>. Pass this structure into <c>ID3D12VideoDevice::CreateVideoDecoder</c> to create an instance
	/// of <b>ID3D12VideoDecoder</b>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decoder_desc typedef struct
	// D3D12_VIDEO_DECODER_DESC { UINT NodeMask; D3D12_VIDEO_DECODE_CONFIGURATION Configuration; } D3D12_VIDEO_DECODER_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODER_DESC
	{
		/// <summary>
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>A <c>D3D12_VIDEO_DECODE_CONFIGURATION</c> structure specifying the configuration of the video decoder.</summary>
		public D3D12_VIDEO_DECODE_CONFIGURATION Configuration;
	}

	/// <summary>
	/// Describes a <c>ID3D12VideoDecoderHeap</c>. Pass this structure into <c>ID3D12VideoDevice::CreateVideoDecoderHeap</c> to create an
	/// instance of <b>ID3D12VideoDecoderHeap</b>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The BitRate and FrameRate parameters may be used by drivers to inform heuristics such as intermediate allocation sizes. Decoding a
	/// frame may fail if these values are insufficient for the video stream. Use <c>D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS</c> to
	/// determine if the video decode succeeded. If decode fails due to insufficient BitRate and FrameRate parameters, the Status field of
	/// this query is set to <c>D3D12_VIDEO_DECODE_STATUS_RATE_EXCEEDED</c>. This query also returns new BitRate and FrameRate values that
	/// would succeed.
	/// </para>
	/// <para>
	/// The BitRate and FrameRate parameters may also be set to zero. Drivers make worst-case assumptions when these values are used which
	/// may result in higher memory consumption with some adapters.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_decoder_heap_desc typedef struct
	// D3D12_VIDEO_DECODER_HEAP_DESC { UINT NodeMask; D3D12_VIDEO_DECODE_CONFIGURATION Configuration; UINT DecodeWidth; UINT DecodeHeight;
	// DXGI_FORMAT Format; DXGI_RATIONAL FrameRate; UINT BitRate; UINT MaxDecodePictureBufferCount; } D3D12_VIDEO_DECODER_HEAP_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_DECODER_HEAP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_DECODER_HEAP_DESC
	{
		/// <summary>
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>A <c>D3D12_VIDEO_DECODE_CONFIGURATION</c> structure specifying the configuration of the video decoder.</summary>
		public D3D12_VIDEO_DECODE_CONFIGURATION Configuration;

		/// <summary>The decode width of the bitstream to be decoded.</summary>
		public uint DecodeWidth;

		/// <summary>The decode height of the bitstream to be decoded.</summary>
		public uint DecodeHeight;

		/// <summary>A <c>DXGI_FORMAT</c> structure specifying the format of the bitstream to be decoded.</summary>
		public DXGI_FORMAT Format;

		/// <summary>The frame rate of the input video stream. For more information, see the Remarks section.</summary>
		public DXGI_RATIONAL FrameRate;

		/// <summary>
		/// The average bits per second data compression rate for the compressed video stream. For more information, see the Remarks section.
		/// </summary>
		public uint BitRate;

		/// <summary>The maximum number of decode picture buffers this stream can have.</summary>
		public uint MaxDecodePictureBufferCount;
	}

	/// <summary>Represents the reconstructed reference images for an encoding operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encode_reference_frames typedef struct
	// D3D12_VIDEO_ENCODE_REFERENCE_FRAMES { UINT NumTexture2Ds; ID3D12Resource **ppTexture2Ds; UINT *pSubresources; } D3D12_VIDEO_ENCODE_REFERENCE_FRAMES;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODE_REFERENCE_FRAMES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODE_REFERENCE_FRAMES
	{
		/// <summary>The number of textures in the ppTexture2Ds array.</summary>
		public uint NumTexture2Ds;

		/// <summary>An array of <c>ID3D12Resource</c> textures containing the reference images.</summary>
		public IntPtr ppTexture2Ds;

		/// <summary>
		/// An array of subresource indices for the reference textures specified in ppTexture2Ds. NULL indicates that subresource 0 should
		/// be assumed for each resource. With texture arrays within a single resource, the subresource indices point to the array index of
		/// the first resource plane. With an array of textures in individual resources, the subresource index is typically zero.
		/// </summary>
		public ArrayPointer<uint> pSubresources;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_CDEF_CONFIG
	{
		/// <summary>Related to AV1 syntax in cdef_params().</summary>
		public ulong CdefBits;

		/// <summary>Related to AV1 syntax in cdef_params().</summary>
		public ulong CdefDampingMinus3;

		/// <summary>Related to AV1 syntax in cdef_params().</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public ulong[] CdefYPriStrength;

		/// <summary>Related to AV1 syntax in cdef_params().</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public ulong[] CdefUVPriStrength;

		/// <summary>Related to AV1 syntax in cdef_params().</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public ulong[] CdefYSecStrength;

		/// <summary>Related to AV1 syntax in cdef_params().</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public ulong[] CdefUVSecStrength;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION
	{
		/// <summary>
		/// Defines the set of enabled features. Flags can be combined based on the reported capabilities/requirements by the driver.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAGS FeatureFlags;

		/// <summary/>
		public uint OrderHintBitsMinus1;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION_SUPPORT
	{
		/// <summary>
		/// Output param. Indicates which features are supported for the codec. Supported features can be set or not by the API Client.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAGS SupportedFeatureFlags;

		/// <summary>Output param. Indicates which features the driver requires to be set.</summary>
		public D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAGS RequiredFeatureFlags;

		/// <summary>Output parameter. Indicates which values can be selected on input parameters of type D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS.</summary>
		public D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS_FLAGS SupportedInterpolationFilters;

		private unsafe fixed uint srp[9];

		/// <summary>
		/// <para>
		/// Output parameter. Indicates which values can be selected as input parameters for FrameRestorationType and
		/// LoopRestorationPixelSize in D3D12_VIDEO_ENCODER_AV1_RESTORATION_CONFIG.
		/// </para>
		/// <para>
		/// The first array indexing corresponds to the restoration filter type: | Index i in SupportedRestorationParams[i][j] | Filter type
		/// | |————–|————-| | 0 | SWITCHABLE | | 1 | WIENER | | 2 | SGRPROJ |
		/// </para>
		/// <para>Note the indexing of the filter types corresponds to D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE minus 1 (skipping D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE_DISABLED).</para>
		/// <para>
		/// The second array indexing corresponds to the planes: | Index j in SupportedRestorationParams[i][j] | Plane | |————–|————-| | 0 |
		/// Y plane | | 1 | U plane | | 2 | V plane |
		/// </para>
		/// <para>
		/// The value returned in SupportedRestorationParams[i][j] is a bitflag mask indicating whether the i-th filter in the j-th plane is either:
		/// </para>
		/// <list type="number">
		/// <item>Not supported indicated by SupportedRestorationParams[i][j] = D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAG_NOT_SUPPORTED.</item>
		/// <item>Supported with any of the D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE as indicated by the combinable bit flags in SupportedRestorationParams[i][j].</item>
		/// </list>
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAGS[,] SupportedRestorationParams
		{
			get
			{
				var ret = new D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAGS[3, 3];
				unsafe
				{
					fixed (uint* p = srp)
						for (var i = 0; i < 3; i++)
							for (var j = 0; j < 3; j++)
								ret[i, j] = (D3D12_VIDEO_ENCODER_AV1_RESTORATION_SUPPORT_FLAGS)p[i * 3 + j];
				}
				return ret;
			}
			set
			{
				if (value.GetLength(0) != 3 || value.GetLength(1) != 3)
					throw new ArgumentException("Value must be a 3x3 array.", nameof(value));
				unsafe
				{
					fixed (uint* p = srp)
						for (var i = 0; i < 3; i++)
							for (var j = 0; j < 3; j++)
								p[i * 3 + j] = (uint)value[i, j];
				}
			}
		}

		/// <summary>Output parameter. Indicates which segmentation modes can be selected in D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_CONFIG.</summary>
		public D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MODE_FLAGS SupportedSegmentationModes;

		/// <summary>
		/// Output parameter. Indicates which values can be selected on input parameters of type D3D12_VIDEO_ENCODER_AV1_TX_MODE for
		/// different D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE. <note>Driver must support at least 1 mode for each frame type(ie.mask value cannot
		/// be 0).</note>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public D3D12_VIDEO_ENCODER_AV1_TX_MODE_FLAGS[] SupportedTxModes;

		/// <summary>
		/// Output parameter. Indicates the block size for the segment map. This is both the for input blocks in
		/// D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MAP for custom segmentation or the block size of the segment map written in the compressed
		/// bitstream by the driver in auto segmentation.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_BLOCK_SIZE SegmentationBlockSize;

		/// <summary>
		/// Specifies for which AV1 encoding features, the underlying encoder is able to override the associated AV1 syntax values or accept
		/// API Client configurable input exactly.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAGS PostEncodeValuesFlags;

		/// <summary>
		/// Specifies the maximum number of temporal layers that can be supported. The reported values must be in the range
		/// [1..MaxTemporalIdSupported + 1]. A reported value 1, there is no temporal scalability support.
		/// </summary>
		public uint MaxTemporalLayers;

		/// <summary>
		/// Specifies the maximum number of spatial layers that can be supported. The reported values must be in the range
		/// [1..MaxSpatialIdSupported + 1]. A reported value 1, there is no spatial scalability support.
		/// </summary>
		public uint MaxSpatialLayers;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_SUPPORT
	{
		/// <summary>
		/// Input parameter. Indicates if the returned values by the driver in superblock units need to be expressed as 128x128 superblocks.
		/// Otherwise the superblock default size 64x64 must be used.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Use128SuperBlocks;

		/// <summary>Input parameter. Desired tile configuration to check support for.</summary>
		public D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_TILES TilesConfiguration;

		/// <summary>
		/// Output parameter. Indicates more details when D3D12_FEATURE_DATA_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_CONFIG.IsSupported is false.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_FRAME_SUBREGION_LAYOUT_CONFIG_VALIDATION_FLAGS ValidationFlags;

		/// <summary>Output parameter. Minimum number of horizontal partitions.</summary>
		public uint MinTileRows;

		/// <summary>Output parameter. Maximum number of horizontal partitions.</summary>
		public uint MaxTileRows;

		/// <summary>Output parameter. Minimum number of vertical partitions.</summary>
		public uint MinTileCols;

		/// <summary>Output parameter. Maximum number of vertical partitions.</summary>
		public uint MaxTileCols;

		/// <summary>Output parameter. Minimum width of any tile, in superblock units.</summary>
		public uint MinTileWidth;

		/// <summary>Output parameter. Maximum width of any tile, in superblock units.</summary>
		public uint MaxTileWidth;

		/// <summary>Output parameter. Minimum dimension of any tile, in superblock units.</summary>
		public uint MinTileArea;

		/// <summary>Output parameter. Maximum dimension of any tile, in superblock units.</summary>
		public uint MaxTileArea;

		/// <summary>
		/// Output parameter. Specifies the number of bytes needed to code each tile size. Related to the driver writing the
		/// D3D12_VIDEO_ENCODER_FRAME_SUBREGION_METADATA.bSize elements in the resolved metadata. The API Client will write
		/// tile_size_bytes_minus_1 = (TileSizeBytesMinus1) in frame_header_obu/uncompressed_header/tile_info when writing the frame header
		/// OBU, and when writing le(TileSizeBytes) tile_size_minus_1 in tile_group_obu().
		/// </summary>
		public uint TileSizeBytesMinus1;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_LEVEL_SETTING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_AV1_LEVEL_TIER_CONSTRAINTS
	{
		public D3D12_VIDEO_ENCODER_AV1_LEVELS Level;
		public D3D12_VIDEO_ENCODER_AV1_TIER Tier;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_CODEC_DATA
	{
		/// <summary>Configuration flags for this frame to be encoded.</summary>
		public D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAGS Flags;

		/// <summary>Sets the picture type. See D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE values.</summary>
		public D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE FrameType;

		/// <summary>Specifies whether single or compound prediction is used for the given frame. Related to AV1 syntax reference_select.</summary>
		public D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE CompoundPredictionType;

		/// <summary>InterpolationFilter to be used for inter prediction on the current frame, related to syntax interpolation_filter.</summary>
		public D3D12_VIDEO_ENCODER_AV1_INTERPOLATION_FILTERS InterpolationFilter;

		/// <summary>Indicates the restoration config to be used.</summary>
		public D3D12_VIDEO_ENCODER_AV1_RESTORATION_CONFIG FrameRestorationConfig;

		/// <summary></summary>
		public D3D12_VIDEO_ENCODER_AV1_TX_MODE TxMode;

		/// <summary>
		/// Indicates the configuration for super resolution. Has to be greater or equal than D3D12_VIDEO_ENCODER_AV1_SUPERRES_DENOM_MIN
		/// when super resolution is enabled.
		/// </summary>
		public uint SuperResDenominator;

		/// <summary>
		/// Current frame order_hint AV1 syntax. For this API purposes, OrderHint must be always passed even when not coding the order hint
		/// in the AV1 bitstream, and it must reflect the display order of the frame.
		/// </summary>
		public uint OrderHint;

		/// <summary>
		/// <para>
		/// The unique picture index for this frame that will be used to uniquely identify it as a reference for future frames. This
		/// parameter is not related in any way to the AV1 standard syntax, but merely used for API client implementation tracking instead.
		/// </para>
		/// <para>
		/// API Client should initialize this value at 0 for the first D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_KEY_FRAME and increment it by one
		/// on each subsequent frame until the next D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_KEY_FRAME, when it should be reset to zero and follow
		/// the same process.
		/// </para>
		/// <para>
		/// Note: OrderHint cannot be used for this purpose as it has a max range of [0..2^(OrderHintBitsMinus1+1)], which can wrap around
		///       and not work as unique identifier of the frames and their references.
		/// </para>
		/// </summary>
		public uint PictureIndex;

		/// <summary>
		/// Picture temporal layer index plus one. A value of zero indicates temporal scalability not used. This value must be within the
		/// range [0..D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION_SUPPORT.MaxTemporalLayers].
		/// </summary>
		public uint TemporalLayerIndexPlus1;

		/// <summary>
		/// Picture spatial layer index plus one. A value of zero indicates spatial scalability not used. This value must be within the
		/// range [0..D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION_SUPPORT.MaxSpatialLayers].
		/// </summary>
		public uint SpatialLayerIndexPlus1;

		/// <summary>
		/// <para>
		/// Describes the current state snapshot of the complete (ie. including frames that are not used by current frame but used by future
		/// frames, etc) DPB buffer kept in D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames. The reference indices (ie. last,
		/// altref, etc) map from past/future references into this descriptors array. The AV1 codec allows up to 8 references in the DPB.
		/// </para>
		/// <para>
		/// This array of descriptors, in turn, maps a reference picture for this frame into a resource index in the reconstructed pictures
		/// array D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames.
		/// </para>
		/// <para>
		/// The size of this array always matches D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames.NumTextures for the associated
		/// EncodeFrame command.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_DESCRIPTOR[] ReferenceFramesReconPictureDescriptors;

		/// <summary>
		/// <para>
		/// Corresponds to the ref_frame_idx[i] AV1 syntax. For a reference type i, ReferenceIndices[i] indicates an index between [0..7]
		/// into ReferenceFramesReconPictureDescriptors where the current frame i-th reference type is stored in the DPB. In other words
		/// ReferenceFramesReconPictureDescriptors[ReferenceIndices[i]] contains the DPB descriptor for the i-th reference type.
		/// </para>
		/// <para>The i-th entry of ReferenceIndices[] corresponds to each reference type as follows:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Index i</description>
		/// <description>Reference type</description>
		/// <description>ReferenceFramesReconPictureDescriptors[ReferenceIndices[i]]</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>Last</description>
		/// <description>DPB Descriptor for Last</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>Last2</description>
		/// <description>DPB Descriptor for Last2</description>
		/// </item>
		/// <item>
		/// <description>2</description>
		/// <description>Last3</description>
		/// <description>DPB Descriptor for Last3</description>
		/// </item>
		/// <item>
		/// <description>3</description>
		/// <description>Golden</description>
		/// <description>DPB Descriptor for Golden</description>
		/// </item>
		/// <item>
		/// <description>4</description>
		/// <description>Bwdref</description>
		/// <description>DPB Descriptor for Bwdref</description>
		/// </item>
		/// <item>
		/// <description>5</description>
		/// <description>Altref</description>
		/// <description>DPB Descriptor for Altref</description>
		/// </item>
		/// <item>
		/// <description>6</description>
		/// <description>Altref2</description>
		/// <description>DPB Descriptor for Altref2</description>
		/// </item>
		/// </list>
		/// <para><br/></para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
		public uint[] ReferenceIndices;

		/// <summary>
		/// <para>
		/// Corresponds to the AV1 element syntax primary_ref_frame in uncompressed_header(). Specifies which reference frame contains the
		/// CDF values and other state that must be loaded at the start of the frame. The allowed range is [0..7] and the values corresponds
		/// as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>PrimaryRefFrame value</description>
		/// <description>AV1 syntax value (primary_ref_frame)</description>
		/// <description>Reference frame selected</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>0</description>
		/// <description>Last</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>1</description>
		/// <description>Last2</description>
		/// </item>
		/// <item>
		/// <description>2</description>
		/// <description>2</description>
		/// <description>Last3</description>
		/// </item>
		/// <item>
		/// <description>3</description>
		/// <description>3</description>
		/// <description>Golden</description>
		/// </item>
		/// <item>
		/// <description>4</description>
		/// <description>4</description>
		/// <description>Bwdref</description>
		/// </item>
		/// <item>
		/// <description>5</description>
		/// <description>5</description>
		/// <description>Altref</description>
		/// </item>
		/// <item>
		/// <description>6</description>
		/// <description>6</description>
		/// <description>Altref2</description>
		/// </item>
		/// <item>
		/// <description>7</description>
		/// <description>7 (PRIMARY_REF_NONE)</description>
		/// <description>None</description>
		/// </item>
		/// </list>
		/// <para>L</para>
		/// </summary>
		public uint PrimaryRefFrame;

		/// <summary>Corresponds to the refresh_frame_flags AV1 syntax element.</summary>
		public uint RefreshFrameFlags;

		/// <summary>Specifies the loop filter parameters.</summary>
		public D3D12_VIDEO_ENCODER_CODEC_AV1_LOOP_FILTER_CONFIG LoopFilter;

		/// <summary>Specifies the loop filter delta parameters. Related to delta_lf_params AV1 syntax.</summary>
		public D3D12_VIDEO_ENCODER_CODEC_AV1_LOOP_FILTER_DELTA_CONFIG LoopFilterDelta;

		/// <summary>Specifies the quantization parameters.</summary>
		public D3D12_VIDEO_ENCODER_CODEC_AV1_QUANTIZATION_CONFIG Quantization;

		/// <summary>Specifies the quantization delta parameters.</summary>
		public D3D12_VIDEO_ENCODER_CODEC_AV1_QUANTIZATION_DELTA_CONFIG QuantizationDelta;

		/// <summary>Specifies the constrained directional enhancement filtering parameters.</summary>
		public D3D12_VIDEO_ENCODER_AV1_CDEF_CONFIG CDEF;

		/// <summary>The qp map values count</summary>
		public uint QPMapValuesCount;

		/// <summary>
		/// Array containing in row/column scan order, the QP map values to use on each squared region for this frame. The QP map dimensions
		/// can be calculated using the current resolution and
		/// D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.QPMapRegionPixelsSize conveying the squared region sizes. The range
		/// for Delta QP values is [-255;255].
		/// </summary>
		public ArrayPointer<short> pRateControlQPMap;

		/// <summary>
		/// Only used when D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_CUSTOM is set for current frame.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_CONFIG CustomSegmentation;

		/// <summary>
		/// Only used when D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_CUSTOM is set for current frame. Segment
		/// map to be used if CustomSegmentation.UpdateMap is set. Otherwise, the segment map is inherited from ref frame.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MAP SegmentsMap;
	}

	/// <summary><br/></summary>
	/// <remarks>
	/// <para>This operates in different ways using different D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE configurations.</para>
	/// <para>For D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_CONFIGURABLE_GRID_PARTITION,</para>
	/// <list type="bullet">
	/// <item>
	/// Input parameters: RowCount, ColCount, RowHeights, ColWidths within the reported tile caps. The integer values must match the AV1
	/// codec standard expectations (ie. power of two, etc).
	/// </item>
	/// <item>Driver honors exactly and copies the exact same structure after EncodeFrame execution.</item>
	/// </list>
	/// <para>For D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_GRID_PARTITION</para>
	/// <list type="bullet">
	/// <item>
	/// Input parameters: RowCount, ColCount. The integer values must match the AV1 codec standard expectations (ie. power of two, etc).
	/// </item>
	/// <item>Driver copies RowCount/ColCount as passed by API Client, and returns also RowHeights, ColWidths after EncodeFrame execution.</item>
	/// </list>
	/// <para>
	/// For ContextUpdateTileId, is an input parameter from the API Client corresponding to the frame header context_update_tile_id AV1
	/// syntax and if D3D12_VIDEO_ENCODER_AV1_POST_ENCODE_VALUES_FLAG_CONTEXT_UPDATE_TILE_ID was reported then the driver is able to
	/// overwrite the API client input after EncodeFrame execution, otherwise must be copied by the driver from the input to the post encode values.
	/// </para>
	/// </remarks>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_TILES
	{
		/// <summary>Number of tile rows.</summary>
		public ulong RowCount;

		/// <summary>Number of tile cols.</summary>
		public ulong ColCount;

		/// <summary>Heights of tile rows.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public ulong[] RowHeights;

		/// <summary>Widths of tile cols.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public ulong[] ColWidths;

		/// <summary>Related to AV1 syntax context_update_tile_id.</summary>
		public ulong ContextUpdateTileId;
	}

	/// <summary>Related to AV1 syntax lr_params(). The array entries correspond to Y, U, V planes.</summary>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_DESCRIPTOR
	{
		public uint ReconstructedPictureResourceIndex;
		public uint TemporalLayerIndexPlus1;
		public uint SpatialLayerIndexPlus1;
		public D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE FrameType;
		public D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_WARPED_MOTION_INFO WarpedMotionInfo;
		public uint OrderHint;
		public uint PictureIndex;
	}

	/// <summary>Related to warped motion transformation/global motion type. Transform to be applied to motion vectors.</summary>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_WARPED_MOTION_INFO
	{
		public D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION TransformationType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public int[] TransformationMatrix;

		[MarshalAs(UnmanagedType.Bool)]
		public bool InvalidAffineSet;
	}

	/// <summary>Related to AV1 syntax lr_params(). The array entries correspond to Y, U, V planes.</summary>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_RESTORATION_CONFIG
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public D3D12_VIDEO_ENCODER_AV1_RESTORATION_TYPE[] FrameRestorationType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public D3D12_VIDEO_ENCODER_AV1_RESTORATION_TILESIZE[] LoopRestorationPixelSize;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_SEGMENT_DATA
	{
		public ulong EnabledFeatures;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public long[] FeatureValue;
	}

	/// <summary>Related to AV1 syntax segmentation_params()</summary>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_CONFIG
	{
		/// <summary/>
		public ulong UpdateMap;

		/// <summary/>
		public ulong TemporalUpdate;

		/// <summary/>
		public ulong UpdateData;

		/// <summary>
		/// <para>
		/// When using D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_AUTO and the driver writes it back on post
		/// encode values, NumSegments = 0 indicated that segmentation_enabled must be 0 in the frame header. Otherwise, the API client
		/// codes segmentation_params() in the frame header accordingly with the other parameters in this structure.
		/// </para>
		/// <para>
		/// When using D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_FLAG_ENABLE_FRAME_SEGMENTATION_CUSTOM, indicates the input number of segments.
		/// </para>
		/// </summary>
		public ulong NumSegments;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public D3D12_VIDEO_ENCODER_AV1_SEGMENT_DATA[] SegmentsData;
	}

	/// <summary>Related to AV1 syntax segmentation_params()</summary>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_AV1_SEGMENTATION_MAP
	{
		/// <summary>Byte size of pSegmentsMap buffer.</summary>
		public uint SegmentsMapByteSize;

		/// <summary>
		/// In raster order, contains the AV1 syntax segment_id between [0..7] for each block in the frame. The block size is
		/// SegmentationBlockSize as reported by driver in D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION_SUPPORT.
		/// </summary>
		public ArrayPointer<ushort> pSegmentsMap;
	}

	/// <summary>This is a hint to the driver of the GOP being used for rate control purposes only.</summary>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_AV1_SEQUENCE_STRUCTURE
	{
		/// <summary>
		/// Indicates the distance between intra-only frames (or key frames) in the video sequence, or the number of pictures on a sequence
		/// of inter-frame pictures. If set to 0, only the first frame will be an key-frame.
		/// </summary>
		public uint IntraDistance;

		/// <summary>
		/// Indicates the period for inter-frames to be inserted within the inter frame structure. Note that if IntraDistance is set to 0
		/// for infinite inter frame structure, this value must be greater than zero.
		/// </summary>
		public uint InterFramePeriod;
	}

	/// <summary>Related to AV1 syntax loop_filter_params().</summary>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_CODEC_AV1_LOOP_FILTER_CONFIG
	{
		/// <summary>Related to AV1 syntax loop_filter_level[0], loop_filter_level[1]</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public ulong[] LoopFilterLevel;

		/// <summary>Related to AV1 syntax loop_filter_level[2]</summary>
		public ulong LoopFilterLevelU;

		/// <summary>Related to AV1 syntax loop_filter_level[3]</summary>
		public ulong LoopFilterLevelV;

		/// <summary>Related to AV1 syntax loop_filter_sharpness</summary>
		public ulong LoopFilterSharpnessLevel;

		/// <summary>
		/// Related to AV1 syntax loop_filter_delta_enabled. Requires D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_LOOP_FILTER_DELTAS supported/enabled.
		/// </summary>
		public ulong LoopFilterDeltaEnabled;

		/// <summary>Related to AV1 syntax update_ref_delta</summary>
		public ulong UpdateRefDelta;

		/// <summary>Related to AV1 syntax loop_filter_ref_deltas</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public long[] RefDeltas;

		/// <summary>Related to AV1 syntax update_mode_delta</summary>
		public ulong UpdateModeDelta;

		/// <summary>Related to AV1 syntax loop_filter_mode_deltas</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public long[] ModeDeltas;
	}

	/// <summary>Related to AV1 syntax delta_lf_params().</summary>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_CODEC_AV1_LOOP_FILTER_DELTA_CONFIG
	{
		/// <summary>Related to AV1 syntax delta_lf_params(). Requires D3D12_VIDEO_ENCODER_AV1_FEATURE_FLAG_DELTA_LF_PARAMS supported/enabled.</summary>
		public ulong DeltaLFPresent;

		/// <summary>Related to AV1 syntax delta_lf_params()</summary>
		public ulong DeltaLFMulti;

		/// <summary>Related to AV1 syntax delta_lf_params()</summary>
		public ulong DeltaLFRes;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_AV1_PICTURE_CONTROL_SUPPORT
	{
		/// <summary>
		/// Input param. The requested prediction mode to be used. The driver must return the output parameters below assuming a frame will
		/// be encoded using this prediction mode in the picture params structure.
		/// </summary>
		public D3D12_VIDEO_ENCODER_AV1_COMP_PREDICTION_TYPE PredictionMode;

		/// <summary>
		/// Output param. Indicates how many unique reference frames in the DPB can be selected at the same time for a given frame from any
		/// of the reference types (LAST, …, ALTREF, etc) in the picture control parameters from the DPB that the API Client manages. In
		/// other words, the maximum number distinct (and with ReconstructedPictureResourceIndex != 0xFF) entries in
		/// D3D12_VIDEO_ENCODE_REFERENCE_FRAMES.ppTexture2Ds[ReferenceFramesReconPictureDescriptors[ReferenceIndices[i]].ReconstructedPictureResourceIndex]
		/// for i in [0..7].
		/// </summary>
		public uint MaxUniqueReferencesPerFrame;

		/// <summary>Output param. Indicates the supported frame types to be used in D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE.</summary>
		public D3D12_VIDEO_ENCODER_AV1_FRAME_TYPE_FLAGS SupportedFrameTypes;

		/// <summary>Output param. Indicates the supported types to be used in D3D12_VIDEO_ENCODER_AV1_REFERENCE_PICTURE_WARPED_MOTION_INFO.TransformationType.</summary>
		public D3D12_VIDEO_ENCODER_AV1_REFERENCE_WARPED_MOTION_TRANSFORMATION_FLAGS SupportedReferenceWarpedMotionFlags;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_CODEC_AV1_QUANTIZATION_CONFIG
	{
		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public ulong BaseQIndex;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public long YDCDeltaQ;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public long UDCDeltaQ;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public long UACDeltaQ;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public long VDCDeltaQ;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public long VACDeltaQ;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public ulong UsingQMatrix;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public ulong QMY;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public ulong QMU;

		/// <summary>Related to AV1 syntax in quantization_params().</summary>
		public ulong QMV;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_CODEC_AV1_QUANTIZATION_DELTA_CONFIG
	{
		/// <summary>Related to AV1 syntax in delta_q_params().</summary>
		public ulong DeltaQPresent;

		/// <summary>Related to AV1 syntax in delta_q_params().</summary>
		public ulong DeltaQRes;
	}

	/// <summary>Represents a codec configuration structure for video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_configuration typedef struct
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION { UINT DataSize; union { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264 *pH264Config;
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC *pHEVCConfig; D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION *pAV1Config; }; } D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION
	{
		/// <summary>The data size of the provided codec configuration structure.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264</c> structure containing codec configuration parameters for H.264 encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264> pH264Config { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC</c> structure containing codec configuration parameters for HEVC encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC> pHEVCConfig { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION> pAV1Config { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Represents codec configuration for H.264 encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_configuration_h264 typedef
	// struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264 { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAGS ConfigurationFlags;
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES DirectModeConfig;
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES DisableDeblockingFilterConfig; } D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264
	{
		/// <summary>
		/// A bitwise OR combination of flags from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAGS</c> enumeration defining the
		/// set of enabled codec features.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAGS ConfigurationFlags;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES</c> enumeration specifying direct modes.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_DIRECT_MODES DirectModeConfig;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES</c> enumeration specifying
		/// configuration related to the disable_deblocking_filter_idc syntax from the H.264 specification.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODES DisableDeblockingFilterConfig;
	}

	/// <summary>Represents codec configuration for HEVC encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_configuration_hevc typedef
	// struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAGS ConfigurationFlags;
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE MinLumaCodingUnitSize; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE
	// MaxLumaCodingUnitSize; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE MinLumaTransformUnitSize;
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE MaxLumaTransformUnitSize; UCHAR max_transform_hierarchy_depth_inter; UCHAR
	// max_transform_hierarchy_depth_intra; } D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC
	{
		/// <summary>
		/// A bitwise OR combination of flags from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAGS</c> enumeration defining the
		/// set of enabled codec features.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAGS ConfigurationFlags;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE</c> enumeration indicating the minimum luma coding block
		/// size to be used in the encoder. This value matches what the caller will code in SPS.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE MinLumaCodingUnitSize;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE</c> enumeration indicating the maximum luma coding block
		/// size to be used in the encoder. This value matches what the caller will code in SPS.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE MaxLumaCodingUnitSize;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE</c> enumeration indicating the minimum luma transform
		/// block size to be used in the encoder. This value matches the pixel size of what the user will code in SPS.log2_min_luma_transform_block_size_minus2.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE MinLumaTransformUnitSize;

		/// <summary>
		/// <para>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE</para>
		/// <para>
		/// A value from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE</c> enumeration indicating the maximum luma transform
		/// block size to be used in the encoder. This value has to be consistent with the pixel size the user will code in
		/// SPS.log2_diff_max_min_luma_transform_block_size. The variable MaxTbLog2SizeY is set equal to
		/// log2_min_luma_transform_block_size_minus2 + 2 + log2_diff_max_min_luma_transform_block_size.
		/// </para>
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE MaxLumaTransformUnitSize;

		/// <summary>
		/// A UCHAR indicating the maximum hierarchy depth for transform units of coding units coded in inter prediction mode. The value of
		/// max_transform_hierarchy_depth_inter shall be in the range of 0 to CtbLog2SizeY ? MinTbLog2SizeY, inclusive. The value indicated
		/// here must be consistent with the caller-coded SPS headers.
		/// </summary>
		public byte max_transform_hierarchy_depth_inter;

		/// <summary>
		/// A UCHAR indicating the maximum hierarchy depth for transform units of coding units coded in intra prediction mode. The value of
		/// max_transform_hierarchy_depth_intra shall be in the range of 0 to CtbLog2SizeY ? MinTbLog2SizeY, inclusive. The value indicated
		/// here must be consistent with the caller-coded SPS headers.
		/// </summary>
		public byte max_transform_hierarchy_depth_intra;
	}

	/// <summary>Represents a codec configuration support structure for video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_configuration_support typedef
	// struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT { UINT DataSize; union { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264
	// *pH264Support; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC *pHEVCSupport;
	// D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION_SUPPORT *pAV1Support; }; } D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT
	{
		/// <summary>The data size of the provided codec configuration support structure.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264</c> structure containing codec configuration support
		/// parameters for H.264 encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264> pH264Support { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC</c> structure containing codec configuration support
		/// parameters for HEVC encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC> pHEVCSupport { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_AV1_CODEC_CONFIGURATION_SUPPORT> pAV1Support { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Represents encoder codec configuration support for H.264 encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_configuration_support_h264
	// typedef struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264 { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAGS
	// SupportFlags; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAGS DisableDeblockingFilterSupportedModes; } D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264
	{
		/// <summary>
		/// A bitwise OR combination of flags from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAGS</c> specifying which
		/// optional features are supported for the codec.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264_FLAGS SupportFlags;

		/// <summary>
		/// A bitwise OR combination of flags specifying the allowed modes supported for disable_deblocking_filter_idc syntax for H264 spec.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_SLICES_DEBLOCKING_MODE_FLAGS DisableDeblockingFilterSupportedModes;
	}

	/// <summary>Represents encoder codec configuration support for HEVC encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_configuration_support_hevc
	// typedef struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC { D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAGS
	// SupportFlags; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE MinLumaCodingUnitSize;
	// D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE MaxLumaCodingUnitSize; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE
	// MinLumaTransformUnitSize; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE MaxLumaTransformUnitSize; UCHAR
	// max_transform_hierarchy_depth_inter; UCHAR max_transform_hierarchy_depth_intra; } D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC
	{
		/// <summary>
		/// A bitwise OR combination of flags from the <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAGS</c> specifying which
		/// optional features are supported for the codec.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC_FLAGS SupportFlags;

		/// <summary>
		/// The minimum luma coding block size requested. This value must match what the caller will code in the sequence parameter set (SPS).
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE MinLumaCodingUnitSize;

		/// <summary>The maximum luma coding block size requested. This value matches what the user will code in SPS.</summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE MaxLumaCodingUnitSize;

		/// <summary>
		/// The minimum luma transform block size requested. This value matches the pixel size of what the user will code in SPS.log2_min_luma_transform_block_size_minus2.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE MinLumaTransformUnitSize;

		/// <summary>
		/// The maximum luma transform block size requested. This value must be consistent with the pixel size the user will code in
		/// SPS.log2_diff_max_min_luma_transform_block_size. The variable MaxTbLog2SizeY is set equal to
		/// log2_min_luma_transform_block_size_minus2 + 2 + log2_diff_max_min_luma_transform_block_size.
		/// </summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE MaxLumaTransformUnitSize;

		/// <summary>
		/// The maximum hierarchy depth for transform units of coding units coded in inter prediction mode. The value of
		/// max_transform_hierarchy_depth_inter shall be in the range of 0 to CtbLog2SizeY ? MinTbLog2SizeY, inclusive.
		/// </summary>
		public byte max_transform_hierarchy_depth_inter;

		/// <summary>
		/// Specifies the maximum hierarchy depth for transform units of coding units coded in intra prediction mode. The value of
		/// max_transform_hierarchy_depth_intra shall be in the range of 0 to CtbLog2SizeY ? MinTbLog2SizeY, inclusive.
		/// </summary>
		public byte max_transform_hierarchy_depth_intra;
	}

	/// <summary>Represents picture control support structure for multiple codecs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_picture_control_support
	// typedef struct D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT { UINT DataSize; union {
	// D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264 *pH264Support; D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_HEVC
	// *pHEVCSupport; D3D12_VIDEO_ENCODER_CODEC_AV1_PICTURE_CONTROL_SUPPORT *pAV1Support; }; } D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT
	{
		/// <summary>The data size of the provided picture control support structure.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264</c> structure representing the picture control support
		/// structure for H.264 encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264> pH264Support { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_HEVC</c> structure representing the picture control support
		/// structure for HEVC encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_HEVC> pHEVCSupport { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_CODEC_AV1_PICTURE_CONTROL_SUPPORT> pAV1Support { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Represents picture control support settings for H.264 video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_picture_control_support_h264
	// typedef struct D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264 { UINT MaxL0ReferencesForP; UINT MaxL0ReferencesForB; UINT
	// MaxL1ReferencesForB; UINT MaxLongTermReferences; UINT MaxDPBCapacity; } D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_H264
	{
		/// <summary>
		/// The maximum value allowed in the slice headers for (num_ref_idx_l0_active_minus1 +1) when encoding P frames. This is equivalent
		/// to the maximum size of an L0 for a P frame supported.
		/// </summary>
		public uint MaxL0ReferencesForP;

		/// <summary>
		/// The maximum value allowed in the slice headers for (num_ref_idx_l0_active_minus1 +1) when encoding B frames. This is equivalent
		/// to the maximum size of an L0 for a B frame supported.
		/// </summary>
		public uint MaxL0ReferencesForB;

		/// <summary>
		/// The maximum value allowed in the slice headers for (num_ref_idx_l1_active_minus1 +1) when encoding B frames. This is equivalent
		/// to the maximum size of an L1 for a B frame supported.
		/// </summary>
		public uint MaxL1ReferencesForB;

		/// <summary>The maximum number of references used in a frame that can be marked as long term reference.</summary>
		public uint MaxLongTermReferences;

		/// <summary>
		/// The maximum number of unique pictures that can be used from the DPB the caller manages (number of unique indices in L0 union L1)
		/// for a given <c>EncodeFrame</c> command on the underlying hardware.
		/// </summary>
		public uint MaxDPBCapacity;
	}

	/// <summary>Represents picture control support settings for HEVC video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_codec_picture_control_support_hevc
	// typedef struct D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_HEVC { UINT MaxL0ReferencesForP; UINT MaxL0ReferencesForB; UINT
	// MaxL1ReferencesForB; UINT MaxLongTermReferences; UINT MaxDPBCapacity; } D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_HEVC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_HEVC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_CODEC_PICTURE_CONTROL_SUPPORT_HEVC
	{
		/// <summary>
		/// The maximum value allowed in the slice headers for (num_ref_idx_l0_active_minus1 +1) when encoding P frames. This is equivalent
		/// to the maximum size of an L0 for a P frame supported.
		/// </summary>
		public uint MaxL0ReferencesForP;

		/// <summary>
		/// The maximum value allowed in the slice headers for (num_ref_idx_l0_active_minus1 +1) when encoding B frames. This is equivalent
		/// to the maximum size of an L0 for a B frame supported.
		/// </summary>
		public uint MaxL0ReferencesForB;

		/// <summary>
		/// The maximum value allowed in the slice headers for (num_ref_idx_l1_active_minus1 +1) when encoding B frames. This is equivalent
		/// to the maximum size of an L1 for a B frame supported.
		/// </summary>
		public uint MaxL1ReferencesForB;

		/// <summary>The maximum number of references used in a frame that can be marked as long term reference.</summary>
		public uint MaxLongTermReferences;

		/// <summary>
		/// The maximum number of unique pictures that can be used from the DPB the caller manages (number of unique indices in L0 union L1)
		/// for a given <c>EncodeFrame</c> command on the underlying hardware.
		/// </summary>
		public uint MaxDPBCapacity;
	}

	/// <summary>Encapsulates the compressed bitstream output for the encoding operation.</summary>
	/// <remarks>
	/// <para>
	/// The output bitstream is expected to contain the subregion headers, but not the picture, sequence, video or other headers. The host
	/// is responsible for coding those headers and generating the complete bitstream.
	/// </para>
	/// <para>
	/// In subregion frame partitioning, all subregions for a given frame encoding operation output must be placed in top/down, left/right
	/// order and must be contiguous.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_compressed_bitstream typedef struct
	// D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM { ID3D12Resource *pBuffer; UINT64 FrameStartOffset; } D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM
	{
		/// <summary>
		/// A pointer to a <c>ID3D12Resource</c> containing the compressed bitstream buffer. Note that the resource buffer size is not the
		/// available size for this encoding operation because FrameStartOffset needs to be taken into account against this size.
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pBuffer;

		/// <summary>
		/// A UINT64 specifying th offset into the compressed bitstream where the encoder may start adding the current frame output.
		/// </summary>
		public ulong FrameStartOffset;
	}

	/// <summary>
	/// Describes an <c>ID3D12VideoEncoder</c>. Pass this structure into <c>ID3D12VideoDevice3::CreateVideoEncoder</c> to create an instance
	/// of <b>ID3D12VideoEncoder</b>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_desc typedef struct
	// D3D12_VIDEO_ENCODER_DESC { UINT NodeMask; D3D12_VIDEO_ENCODER_FLAGS Flags; D3D12_VIDEO_ENCODER_CODEC EncodeCodec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC EncodeProfile; DXGI_FORMAT InputFormat; D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION CodecConfiguration;
	// D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE MaxMotionEstimationPrecision; } D3D12_VIDEO_ENCODER_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_DESC
	{
		/// <summary>
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>A bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_FLAGS</c> specifying the flags for encoder creation.</summary>
		public D3D12_VIDEO_ENCODER_FLAGS Flags;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_CODEC</c> specifying the desired codec.</summary>
		public D3D12_VIDEO_ENCODER_CODEC EncodeCodec;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure specifying the desired encoding profile.</summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC EncodeProfile;

		/// <summary>A <c>DXGI_FORMAT</c> specifying the format of the source stream.</summary>
		public DXGI_FORMAT InputFormat;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION</c> structure specifying codec configuration parameters.</summary>
		public D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION CodecConfiguration;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE</c> enumeration the maximum number of motion vectors allowed.
		/// </summary>
		public D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE MaxMotionEstimationPrecision;
	}

	/// <summary>Represents a buffer containing metadata about an <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c> operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_encode_operation_metadata_buffer
	// typedef struct D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER { ID3D12Resource *pBuffer; UINT64 Offset; } D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER
	{
		/// <summary>A pointer to an <c>ID3D12Resource</c> representing the metadata buffer.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pBuffer;

		/// <summary>The offset into the associated buffer.</summary>
		public ulong Offset;
	}

	/// <summary>Represents input arguments to <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_encodeframe_input_arguments typedef
	// struct D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS { D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC SequenceControlDesc;
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC PictureControlDesc; ID3D12Resource *pInputFrame; UINT InputFrameSubresource; UINT
	// CurrentFrameBitstreamMetadataSize; } D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS
	{
		/// <summary>A <c>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC</c> specifying the configuration for the video sequence</summary>
		public D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC SequenceControlDesc;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC</c> specifying the configuration for the video picture.</summary>
		public D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC PictureControlDesc;

		/// <summary>An <c>ID3D12Resource</c> representing the frame to encode.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pInputFrame;

		/// <summary>A UINT64 specifying the subresource index for pInputFrame.</summary>
		public uint InputFrameSubresource;

		/// <summary>
		/// A UINT64 specifying the number of bytes added to the final bitstream between the end of the last <b>EncodeFrame</b> compressed
		/// bitstream output and the current call output. This is intended to capture the size of any headers or metadata messages added by
		/// the client to the final bitstream which are used as a hint by the rate control algorithms to keep track of the full bitstream size.
		/// </summary>
		public uint CurrentFrameBitstreamMetadataSize;
	}

	/// <summary>Represents output arguments to <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c>.</summary>
	/// <remarks>The caller must check for alignment requirements for the output resources used for the encoding operation.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_encodeframe_output_arguments typedef
	// struct D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS { D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM Bitstream;
	// D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE ReconstructedPicture; D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER
	// EncoderOutputMetadata; } D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS
	{
		/// <summary>A <c>A D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM</c> containing the result of the encoding operation.</summary>
		public D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM Bitstream;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE</c> representing a reconstructed picture generated from the input frame. This
		/// resource is only needed if the encoded picture is marked to be used as a reference picture in the corresponding picture control
		/// structure for this encode operation, NULL can be set otherwise as the reconstructed picture will not be written in the output.
		/// </summary>
		public D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE ReconstructedPicture;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER</c> representing encoding metadata returned by the encoder in
		/// hardware-specific layout. This data must be resolved into a readable format using <c>ID3D12VIDEOCOMMANDLIST2::ResolveEncoderOutputMetadata</c>.
		/// </summary>
		public D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER EncoderOutputMetadata;
	}

	/// <summary>Represents video encoder frame subregion metadata.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_frame_subregion_metadata typedef
	// struct D3D12_VIDEO_ENCODER_FRAME_SUBREGION_METADATA { UINT64 bSize; UINT64 bStartOffset; UINT64 bHeaderSize; } D3D12_VIDEO_ENCODER_FRAME_SUBREGION_METADATA;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_FRAME_SUBREGION_METADATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_FRAME_SUBREGION_METADATA
	{
		/// <summary>
		/// Output field that receives the sizes in bytes of each subregion. Subregions sizes must include both the subregion initial
		/// padding, the subregion header and the subregion payload.
		/// </summary>
		public ulong bSize;

		/// <summary>
		/// <para>
		/// Output field that receives the padding size in bytes that needs to be skipped at the beginning of every subregion. This padding
		/// size is included in the size reported above.
		/// </para>
		/// <para>
		/// For example, let pFrameSubregionsSizes be an array of bSize for each slice. With this information, along with
		/// pFrameSubregionsSizes, the user can extract individual subregions from the output bitstream buffer by calculating i-th subregion
		/// start offset as <c>pBuffer + FrameStartOffset + sum j = (0, (i-1)){ pFrameSubregionsSizes[j] } +
		/// pFrameSubregionsStartOffsets[i]</c> and reading <c>pFrameSubregionsSizes[i]</c> bytes.
		/// </para>
		/// </summary>
		public ulong bStartOffset;

		/// <summary>
		/// Output parameter that receives the sizes in bits of each subregion header. With this information, in addition to extracting the
		/// full subregion from the bitstream as explained above, the user can extract the subregions payload/headers directly without
		/// needing to parse the full subregion bitstream.
		/// </summary>
		public ulong bHeaderSize;
	}

	/// <summary>
	/// Describes a <c>ID3D12VideoEncoderHeap</c>. Pass this structure into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c> to create an
	/// instance of <b>ID3D12VideoEncoderHeap</b>.
	/// </summary>
	/// <remarks>
	/// If support for resolution dynamic reconfiguration is not supported, specify only one resolution in pResolutionList, denoting the
	/// desired target resolution.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_heap_desc typedef struct
	// D3D12_VIDEO_ENCODER_HEAP_DESC { UINT NodeMask; D3D12_VIDEO_ENCODER_HEAP_FLAGS Flags; D3D12_VIDEO_ENCODER_CODEC EncodeCodec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC EncodeProfile; D3D12_VIDEO_ENCODER_LEVEL_SETTING EncodeLevel; UINT ResolutionsListCount; const
	// D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC *pResolutionList; } D3D12_VIDEO_ENCODER_HEAP_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_HEAP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_HEAP_DESC
	{
		/// <summary>
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// A bitwise or combination of values from the <c>D3D12_VIDEO_ENCODER_HEAP_FLAGS</c> enumeration specifying encoder heap creation options.
		/// </summary>
		public D3D12_VIDEO_ENCODER_HEAP_FLAGS Flags;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_CODEC</c> specifying the codec of the associated encoder object.</summary>
		public D3D12_VIDEO_ENCODER_CODEC EncodeCodec;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> specifying the profile for the selected codec in the associated encoder object.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC EncodeProfile;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_LEVEL_SETTING</c> specifying the level for the selected codec in the associated encoder object.
		/// </summary>
		public D3D12_VIDEO_ENCODER_LEVEL_SETTING EncodeLevel;

		/// <summary>The count of resolutions requested to be supported present in the pResolutionList field.</summary>
		public uint ResolutionsListCount;

		/// <summary>
		/// Pointer to an array of <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC</c> specifying the list of resolutions requested to be supported.
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC> pResolutionList;
	}

	/// <summary>Represents intra refresh settings for video encoding.</summary>
	/// <remarks>
	/// When triggering an intra-refresh session, the host informs the current frame number relative to the [0..IntraRefreshDuration)
	/// session by setting IntraRefreshFrameIndex in the picture control structures.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_intra_refresh typedef struct
	// D3D12_VIDEO_ENCODER_INTRA_REFRESH { D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE Mode; UINT IntraRefreshDuration; } D3D12_VIDEO_ENCODER_INTRA_REFRESH;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_INTRA_REFRESH")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_INTRA_REFRESH
	{
		/// <summary>A value from the <c>D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE</c> enumeration specifying the intra refresh mode.</summary>
		public D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE Mode;

		/// <summary>
		/// A UINT64 specifying the duration of the intra-refresh session, as a number of frames . For
		/// D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE_ROW_BASED, this value and the frame height define the size of the I rows for the duration
		/// of the IR session.
		/// </summary>
		public uint IntraRefreshDuration;
	}

	/// <summary>Represents a video encoder level setting.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_level_setting typedef struct
	// D3D12_VIDEO_ENCODER_LEVEL_SETTING { UINT DataSize; union { D3D12_VIDEO_ENCODER_LEVELS_H264 *pH264LevelSetting;
	// D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC *pHEVCLevelSetting; D3D12_VIDEO_ENCODER_AV1_LEVEL_TIER_CONSTRAINTS *pAV1LevelSetting;
	// }; } D3D12_VIDEO_ENCODER_LEVEL_SETTING;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_LEVEL_SETTING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_LEVEL_SETTING
	{
		/// <summary>The data size of the provided encoder level setting.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>A pointer to a value from the <c>D3D12_VIDEO_ENCODER_LEVELS_H264</c> enumeration specifying an H.264 level.</summary>
		public D3D12_VIDEO_ENCODER_LEVELS_H264 pH264LevelSetting { get => (D3D12_VIDEO_ENCODER_LEVELS_H264)union.ToInt32(); set => union = (IntPtr)(int)value; }

		/// <summary>A pointer to a <c>D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC</c> structure specifying an HEVC profile.</summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC> pHEVCLevelSetting { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_AV1_LEVEL_TIER_CONSTRAINTS> pAV1LevelSetting { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Associates a level and a tier for High Efficiency Video Coding (HEVC) level-setting configuration.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_level_tier_constraints_hevc typedef
	// struct D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC { D3D12_VIDEO_ENCODER_LEVELS_HEVC Level; D3D12_VIDEO_ENCODER_TIER_HEVC Tier; } D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_LEVEL_TIER_CONSTRAINTS_HEVC
	{
		/// <summary>A member of the <c>D3D12_VIDEO_ENCODER_LEVELS_HEVC</c> enumeration specifying the encoder level.</summary>
		public D3D12_VIDEO_ENCODER_LEVELS_HEVC Level;

		/// <summary>A member of the <c>D3D12_VIDEO_ENCODER_TIER_HEVC</c> enumeration specifying the encoder level.</summary>
		public D3D12_VIDEO_ENCODER_TIER_HEVC Tier;
	}

	/// <summary>Represents metadata about an <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c> operation.</summary>
	/// <remarks>
	/// <b>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</b> and its child structures are all aligned to a 64-bit access boundary for use with <c>SetPredication</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_output_metadata typedef struct
	// D3D12_VIDEO_ENCODER_OUTPUT_METADATA { UINT64 EncodeErrorFlags; D3D12_VIDEO_ENCODER_OUTPUT_METADATA_STATISTICS EncodeStats; UINT64
	// EncodedBitstreamWrittenBytesCount; UINT64 WrittenSubregionsCount; } D3D12_VIDEO_ENCODER_OUTPUT_METADATA;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_OUTPUT_METADATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_OUTPUT_METADATA
	{
		/// <summary>
		/// A <b>UINT64</b> representing a bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAG</c>
		/// enumeration specifying information about the encode execution status.
		/// </summary>
		public D3D12_VIDEO_ENCODER_ENCODE_ERROR_FLAGS EncodeErrorFlags;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA_STATISTICS</c> representing statistics for an <b>EncodeFrame</b> operation.</summary>
		public D3D12_VIDEO_ENCODER_OUTPUT_METADATA_STATISTICS EncodeStats;

		/// <summary>
		/// Output field that receives a <b>UINT64</b> indicating how many bytes were into
		/// <c>D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM.pBuffer</c> plus the value of <c>D3D12_VIDEO_ENCODER_COMPRESSED_BITSTREAM.FrameStartOffset</c>.
		/// </summary>
		public ulong EncodedBitstreamWrittenBytesCount;

		/// <summary>
		/// <para>Output field that receives a <b>UINT64</b> indicating the number of subregions used to encode the current frame.</para>
		/// <para>
		/// This value is coherent with the settings specified in
		/// <c>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC.pFrameSubregionsLayoutData</c>. If a number of subregions was specified,
		/// WrittenSubregionsCount should match that value. If another mode was used, this field is how the driver reports the final number
		/// of subregions. If the output is a full frame, then there is only 1 subregion.
		/// </para>
		/// </summary>
		public ulong WrittenSubregionsCount;
	}

	/// <summary>Represents encoding statistics about an <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c> operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_output_metadata_statistics typedef
	// struct D3D12_VIDEO_ENCODER_OUTPUT_METADATA_STATISTICS { UINT64 AverageQP; UINT64 IntraCodingUnitsCount; UINT64 InterCodingUnitsCount;
	// UINT64 SkipCodingUnitsCount; UINT64 AverageMotionEstimationXDirection; UINT64 AverageMotionEstimationYDirection; } D3D12_VIDEO_ENCODER_OUTPUT_METADATA_STATISTICS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_OUTPUT_METADATA_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_OUTPUT_METADATA_STATISTICS
	{
		/// <summary>Output field that receives the average QP value used for encoding this frame.</summary>
		public ulong AverageQP;

		/// <summary>Output field that receives the number of intra-coded coding units used in this frame.</summary>
		public ulong IntraCodingUnitsCount;

		/// <summary>Output field that receives the number of inter-coded coding units used in this frame.</summary>
		public ulong InterCodingUnitsCount;

		/// <summary>Output field that receives the number of skip coding units used in this frame.</summary>
		public ulong SkipCodingUnitsCount;

		/// <summary>Output field that receives the average motion vector shift in X direction.</summary>
		public ulong AverageMotionEstimationXDirection;

		/// <summary>Output field that receives the average motion vector shift in Y direction.</summary>
		public ulong AverageMotionEstimationYDirection;
	}

	/// <summary>Represents the picture level control elements for the associated <c>EncodeFrame</c> command for multiple codecs.</summary>
	/// <remarks>
	/// <para>Slice-level picture reference lists reordering is unsupported.</para>
	/// <para>Weighted inter-prediction is unsupported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_codec_data typedef
	// struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA { UINT DataSize; union { D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264
	// *pH264PicData; D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC *pHEVCPicData; D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_CODEC_DATA
	// *pAV1PicData; }; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA
	{
		/// <summary>The data size of the provided picture level control structure.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264</c> representing the picture level control elements for
		/// H.264 encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264> pH264PicData { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC</c> representing the picture level control elements for
		/// H.264 encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC> pHEVCPicData { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_CODEC_DATA> pAV1PicData { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Represents the picture level control elements for the associated <c>EncodeFrame</c> command for H.264 encoding.</summary>
	/// <remarks>
	/// <para>
	/// Note that if the current frame is marked as a reference picture, the output must contain the reconstructed picture along with the
	/// bitstream for the host to place it in future commands in the reconstructed pictures reference list. Note that there might be
	/// limitations for some frame types to be marked as references, check feature support before setting those values.
	/// </para>
	/// <para>The following tables list the expected SPS and PPS Values for H264 encoding.</para>
	/// <para>Level_idc mappings for H264</para>
	/// <list type="table">
	/// <listheader>
	/// <description>D3D12 Level</description>
	/// <description>Expected level_idc</description>
	/// <description>Notes</description>
	/// </listheader>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_1</description>
	/// <description>10</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_1b</description>
	/// <description>11</description>
	/// <description>SPS.constraint_set3 must be 1</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_11</description>
	/// <description>11</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_12</description>
	/// <description>12</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_13</description>
	/// <description>13</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_2</description>
	/// <description>20</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_21</description>
	/// <description>21</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_22</description>
	/// <description>22</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_3</description>
	/// <description>30</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_31</description>
	/// <description>31</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_32</description>
	/// <description>32</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_4</description>
	/// <description>40</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_41</description>
	/// <description>41</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_42</description>
	/// <description>42</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_5</description>
	/// <description>50</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_51</description>
	/// <description>51</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_52</description>
	/// <description>52</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_6</description>
	/// <description>60</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_61</description>
	/// <description>61</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_H264_62</description>
	/// <description>62</description>
	/// <description>None</description>
	/// </item>
	/// </list>
	/// <para>H264 Sequence Parameter Set expected values</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Syntax element</description>
	/// <description>Expected default value</description>
	/// <description>Notes</description>
	/// </listheader>
	/// <item>
	/// <description>profile_idc</description>
	/// <description>Enum value of H264_PROFILE_MAIN/H264_PROFILE_HIGH/H264_PROFILE_HIGH10</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>constraint_set0_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>constraint_set1_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>constraint_set2_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>constraint_set3_flag</description>
	/// <description>0</description>
	/// <description>1 if using D3D12_VIDEO_ENCODER_LEVELS_H264_1b</description>
	/// </item>
	/// <item>
	/// <description>constraint_set4_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>constraint_set5_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>reserved_zero_2bits</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>level_idc</description>
	/// <description>Please see table above for H264 levels</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>seq_parameter_set_id</description>
	/// <description>User specific</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>chroma_format_idc</description>
	/// <description>1</description>
	/// <description>For usage with P010 or NV12 YUV 4.2.0 formats only</description>
	/// </item>
	/// <item>
	/// <description>bit_depth_luma_minus8</description>
	/// <description>0 for NV12, 2 for P010</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>qpprime_y_zero_transform_bypass_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>seq_scaling_matrix_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>log2_max_frame_num_minus4</description>
	/// <description>Same as in D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pic_order_cnt_type</description>
	/// <description>Same as in D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264</description>
	/// <description>Only modes 0 and 2 supported in this API</description>
	/// </item>
	/// <item>
	/// <description>log2_max_pic_order_cnt_lsb_minus4</description>
	/// <description>Same as in D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264</description>
	/// <description>Only if pic_order_cnt_type == 0</description>
	/// </item>
	/// <item>
	/// <description>max_num_ref_frames</description>
	/// <description>Max number of reference pictures used in encode session</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>gaps_in_frame_num_value_allowed_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pic_width_in_mbs_minus1</description>
	/// <description>std::ceil(sequenceTargetResolution.Width / 16.0)) - 1;</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pic_height_in_map_units_minus1</description>
	/// <description>std::ceil(sequenceTargetResolution.Height / 16.0)) - 1;</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>frame_mbs_only_flag</description>
	/// <description>0</description>
	/// <description>No interlace support</description>
	/// </item>
	/// <item>
	/// <description>direct_8x8_inference_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_USE_ADAPTIVE_8x8_TRANSFORM</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>frame_cropping_flag</description>
	/// <description>0 or 1 depending on encode resolution being 16 aligned or not</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>frame_cropping_rect_left_offset</description>
	/// <description>0</description>
	/// <description>Only if frame_cropping_flag = 1</description>
	/// </item>
	/// <item>
	/// <description>frame_cropping_rect_right_offset</description>
	/// <description>((pic_width_in_mbs_minus1+1) * 16 - sequenceTargetResolution.Width) / 2</description>
	/// <description>Only if frame_cropping_flag = 1</description>
	/// </item>
	/// <item>
	/// <description>frame_cropping_rect_top_offset</description>
	/// <description>((pic_height_in_map_units_minus1+1) * 16 - sequenceTargetResolution.Height) / 2</description>
	/// <description>Only if frame_cropping_flag = 1</description>
	/// </item>
	/// <item>
	/// <description>frame_cropping_rect_bottom_offset</description>
	/// <description>0</description>
	/// <description>Only if frame_cropping_flag = 1</description>
	/// </item>
	/// <item>
	/// <description>vui_paramenters_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// </list>
	/// <para>H264 Picture Parameter Set expected values</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Syntax element</description>
	/// <description>Expected default value</description>
	/// <description>Notes</description>
	/// </listheader>
	/// <item>
	/// <description>pic_parameter_set_id</description>
	/// <description>User specific</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>seq_parameter_set_id</description>
	/// <description>User specific</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>entropy_coding_mode_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_ENABLE_CABAC_ENCODING</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pic_order_present_flag</description>
	/// <description>0</description>
	/// <description>Only support for pic_cnt_type = 0, 2</description>
	/// </item>
	/// <item>
	/// <description>num_slice_groups_minus1</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>num_ref_idx_l1_active_minus1</description>
	/// <description>std::max(static_cast&lt;INT&gt;(pictureControl.List0ReferenceFramesCount) - 1, 0)</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>num_ref_idx_l0_active_minus1</description>
	/// <description>std::max(static_cast&lt;INT&gt;(pictureControl.List1ReferenceFramesCount) - 1, 0)</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>weighted_pred_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>weighted_bipred_idc</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pic_init_qp_minus26</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pic_init_qs_minus26</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>chroma_qp_index_offset</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>deblocking_filter_control_present_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>constrained_intra_pred_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_USE_CONSTRAINED_INTRAPREDICTION</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>redundant_pic_cnt_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>transform_8x8_mode_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_H264_FLAG_USE_ADAPTIVE_8x8_TRANSFORM</description>
	/// <description>Only if using High profiles</description>
	/// </item>
	/// <item>
	/// <description>pic_scaling_matrix_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>second_chroma_qp_index_offset</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_codec_data_h264
	// typedef struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264 { D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAGS Flags;
	// D3D12_VIDEO_ENCODER_FRAME_TYPE_H264 FrameType; UINT pic_parameter_set_id; UINT idr_pic_id; UINT PictureOrderCountNumber; UINT
	// FrameDecodingOrderNumber; UINT TemporalLayerIndex; UINT List0ReferenceFramesCount; UINT *pList0ReferenceFrames; UINT
	// List1ReferenceFramesCount; UINT *pList1ReferenceFrames; UINT ReferenceFramesReconPictureDescriptorsCount;
	// D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_H264 *pReferenceFramesReconPictureDescriptors; UCHAR
	// adaptive_ref_pic_marking_mode_flag; UINT RefPicMarkingOperationsCommandsCount;
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_MARKING_OPERATION *pRefPicMarkingOperationsCommands; UINT
	// List0RefPicModificationsCount; D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION
	// *pList0RefPicModifications; UINT List1RefPicModificationsCount;
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION *pList1RefPicModifications; UINT
	// QPMapValuesCount; INT8 *pRateControlQPMap; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264
	{
		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAGS</c> enumeration
		/// specifying configuration flags for the frame being encoded.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAGS Flags;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_FRAME_TYPE_H264</c> enumeration specifying the picture type. Make sure that the
		/// codec-specific flags support the specified type. This selection must be kept in sync with the GOP structure configuration set by
		/// the host. Note that the GOP is defined in display order and this pic type selection must follow the GOP, but in encode order.
		/// </summary>
		public D3D12_VIDEO_ENCODER_FRAME_TYPE_H264 FrameType;

		/// <summary>A <b>UINT</b> specifying the value to be used in the slice headers of the current frame to reference the PPS.</summary>
		public uint pic_parameter_set_id;

		/// <summary>
		/// When <b>FrameType</b>** is <b>D3D12_VIDEO_ENCODER_FRAME_TYPE_H264_IDR_FRAME</b>, a <b>UINT</b> indicating the identifier of the
		/// IDR frame to be used in all the slices headers present in the frame.
		/// </summary>
		public uint idr_pic_id;

		/// <summary>A <b>UINT</b> specifying the current frame display order.</summary>
		public uint PictureOrderCountNumber;

		/// <summary>
		/// A <b>UINT</b> specifying the frame decode order with semantic as indicated by the slice header frame_num syntax element that
		/// increments after each reference picture.
		/// </summary>
		public uint FrameDecodingOrderNumber;

		/// <summary>
		/// A <b>UINT</b> specifying the picture layer number in temporal hierarchy. Check for the maximum number of layers in <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264</c>.
		/// </summary>
		public uint TemporalLayerIndex;

		/// <summary>
		/// A <b>UINT</b> specifying the number of past frame references to be used for this frame. This value should be coherent with what
		/// was exposed in <b>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264</b>.
		/// </summary>
		public uint List0ReferenceFramesCount;

		/// <summary>
		/// A pointer to a <b>UINT</b> array specifying the list of past frame reference frames to be used for this frame. Each integer
		/// value in this array indices into pReferenceFramesReconPictureDescriptors to reference pictures kept in the DPB.
		/// </summary>
		public ArrayPointer<uint> pList0ReferenceFrames;

		/// <summary>
		/// A <b>UINT</b> specifying the number of future frame references to be used for this frame. This value should be coherent with
		/// what was exposed in <b>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264</b>.
		/// </summary>
		public uint List1ReferenceFramesCount;

		/// <summary>
		/// A pointer to a <b>UINT</b> array specifying the list of future frame reference frames to be used for this frame. Each integer
		/// value in this array indices into pReferenceFramesReconPictureDescriptors to reference pictures kept in the DPB.
		/// </summary>
		public ArrayPointer<uint> pList1ReferenceFrames;

		/// <summary>A <b>UINT</b> specifying the number of entries in pReferenceFramesReconPictureDescriptors.</summary>
		public uint ReferenceFramesReconPictureDescriptorsCount;

		/// <summary>
		/// <para>
		/// A pointer to a <b>UINT</b> array that describes the current state of the DPB buffer kept in
		/// <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames</c>. The pList0ReferenceFrames and pList1ReferenceFrames lists
		/// indices map from past/future references into this descriptors array.
		/// </para>
		/// <para>
		/// This array of descriptors, in turn, maps a reference picture for this frame into a resource index in the reconstructed pictures
		/// array <b>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames</b>. Additionally, for each reference picture it indicates the
		/// encode and display order number and whether it is a long term reference.
		/// </para>
		/// <para>
		/// The size of this array always matches <b>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames.NumTextures</b> for the
		/// associated <b>EncodeFrame</b> command.
		/// </para>
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_H264> pReferenceFramesReconPictureDescriptors;

		/// <summary>
		/// <para>A <b>UCHAR</b> defining a semantic mode for the frame reference handling.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>adaptive_ref_pic_marking_mode_flag value</description>
		/// <description>Reference picture marking mode specified</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>1</description>
		/// </item>
		/// <item>
		/// <description>
		/// Sliding window reference picture marking mode: A marking mode providing a first-in first-out mechanism for short-term reference pictures.
		/// </description>
		/// <description>
		/// Adaptive reference picture marking mode: A reference picture marking mode providing syntax elements to specify marking of
		/// reference pictures as "unused for reference" and to assign long-term frame indices.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public byte adaptive_ref_pic_marking_mode_flag;

		/// <summary>
		/// A <b>UINT</b> specifying the number of reference pictures marking operations associated with the current frame. Requires that
		/// adaptive_ref_pic_marking_mode_flag is set to 1.
		/// </summary>
		public uint RefPicMarkingOperationsCommandsCount;

		/// <summary>
		/// A pointer to an array of <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_MARKING_OPERATION</c>
		/// structures representing the list of reference pictures marking operations associated with the current frame. The operations
		/// described by this list need to be reflected in the DPB descriptors accordingly during the encoding session.
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_MARKING_OPERATION> pRefPicMarkingOperationsCommands;

		/// <summary>A <b>UINT</b> specifying the number of items in pList0RefPicModifications.</summary>
		public uint List0RefPicModificationsCount;

		/// <summary>
		/// A pointer to an array of
		/// <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION</c> structures representing
		/// the list of reference picture list modification operations for the pList0ReferenceFrames list.
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION> pList0RefPicModifications;

		/// <summary>A <b>UINT</b> specifying the number of items in pList1RefPicModifications.</summary>
		public uint List1RefPicModificationsCount;

		/// <summary>
		/// A pointer to an array of
		/// <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION</c> structures representing
		/// the list of reference picture list modification operations for the pList1ReferenceFrames list.
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION> pList1RefPicModifications;

		/// <summary>
		/// A <b>UINT</b> specifying the number of elements present in pRateControlQPMap. This should match the number of coding blocks in
		/// the frame, rounding up the frame resolution to the closest aligned values.
		/// </summary>
		public uint QPMapValuesCount;

		/// <summary>
		/// A pointer to an array of <b>Int8</b> containing, in row/column scan order, the QP map values to use on each squared region for
		/// this frame. The QP map dimensions can be calculated using the current resolution and
		/// <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.QPMapRegionPixelsSize</c> conveying the squared region sizes.
		/// </summary>
		public ArrayPointer<sbyte> pRateControlQPMap;
	}

	/// <summary>Represents a picture list modification operation for H264 video encoding.</summary>
	/// <remarks>
	/// For more information, refer to H264 specification for more details: section 7.4.3.1 "Reference picture list modification semantics". .
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_codec_data_h264_reference_picture_list_modification_operation
	// typedef struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION { UCHAR
	// modification_of_pic_nums_idc; UINT abs_diff_pic_num_minus1; UINT long_term_pic_num; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_LIST_MODIFICATION_OPERATION
	{
		/// <summary>Together with abs_diff_pic_num_minus1 or long_term_pic_num specifies which of the reference pictures are re-mapped.</summary>
		public byte modification_of_pic_nums_idc;

		/// <summary>
		/// Specifies the absolute difference between the picture number of the picture being moved to the current index in the list and the
		/// picture number prediction value.
		/// </summary>
		public uint abs_diff_pic_num_minus1;

		/// <summary>Specifies the long-term picture number of the picture being moved to the current index in the list.</summary>
		public uint long_term_pic_num;
	}

	/// <summary>
	/// Describes changes in the reference pictures as memory operations as a tuple of an operation identifier and associated parameters
	/// needed for the operation.
	/// </summary>
	/// <remarks>
	/// <para>
	/// For more information, refer to H264 specification for more details: section 8.2.5.4 "Adaptive memory control decoded reference
	/// picture marking process".
	/// </para>
	/// <para>The variable MaxLongTermFrameIdx is derived as follows:</para>
	/// <para>
	/// – If <b>max_long_term_frame_idx_plus1</b> is equal to 0, MaxLongTermFrameIdx is set equal to "no long-term frame indices". –
	/// Otherwise ( <b>max_long_term_frame_idx_plus1</b> is greater than 0), MaxLongTermFrameIdx is set equal to
	/// max_long_term_frame_idx_plus1 ? 1.
	/// </para>
	/// <para>
	/// The operation of marking the current frame as a short-term reference is given by a flag present in the
	/// <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_FLAGS</c> structure with its corresponding <b>PictureOrderCountNumber</b> and
	/// <b>FrameDecodingOrderNumber</b> values indicated in the associated picture control structure.
	/// </para>
	/// <para>The variable max_num_ref_frames is indicated in this API by the maximum DPB capacity reported.</para>
	/// <para>
	/// Note that for marking an IDR frame as long-term reference, the proposed explicit mechanism is to mark it as short term reference
	/// first, by setting <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAG_USED_AS_REFERENCE_PICTURE</c> when calling <c>EncodeFrame</c> for the
	/// IDR frame, and later promoting it to be a long-term reference frame using memory management operation '3' to mark a short-term
	/// reference picture as "used for long-term reference" and assign a long-term frame index to it.
	/// </para>
	/// <para>
	/// Alternatively, if encoding an IDR frame and setting <b>adaptive_ref_pic_marking_mode_flag</b> = 1, the driver will assume that the
	/// client is attempting to set the H264 slice header <b>long_term_reference_flag</b> and will do so in the output bitstream for the
	/// <b>EncodeFrame</b> call.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_codec_data_h264_reference_picture_marking_operation
	// typedef struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_MARKING_OPERATION { UCHAR
	// memory_management_control_operation; UINT difference_of_pic_nums_minus1; UINT long_term_pic_num; UINT long_term_frame_idx; UINT
	// max_long_term_frame_idx_plus1; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_MARKING_OPERATION;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_MARKING_OPERATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_H264_REFERENCE_PICTURE_MARKING_OPERATION
	{
		/// <summary>The control operation to be applied to affect the reference picture marking state.</summary>
		public byte memory_management_control_operation;

		/// <summary>
		/// Used with <b>memory_management_control_operation</b> equal to 3 or 1 to assign a long-term frame index to a short-term reference
		/// picture or to mark a short-term reference picture as "unused for reference".
		/// </summary>
		public uint difference_of_pic_nums_minus1;

		/// <summary>
		/// Used with <b>memory_management_control_operation</b> equal to 2 to mark a long-term reference picture as "unused for reference".
		/// </summary>
		public uint long_term_pic_num;

		/// <summary>Used with <b>memory_management_control_operation</b> equal to 3 or 6 to assign a long-term frame index to a picture.</summary>
		public uint long_term_frame_idx;

		/// <summary>
		/// The value minus 1 specifies the maximum value of long-term frame index allowed for long-term reference pictures (until receipt
		/// of another value of <b>max_long_term_frame_idx_plus1</b>).
		/// </summary>
		public uint max_long_term_frame_idx_plus1;
	}

	/// <summary>Represents the picture level control elements for the associated <c>EncodeFrame</c> command for HEVC encoding.</summary>
	/// <remarks>
	/// <para>The following tables list the expected VPS, SPS and PPS Values for HEVC encoding.</para>
	/// <para>Level_idc mappings for HEVC</para>
	/// <list type="table">
	/// <listheader>
	/// <description>D3D12 Level</description>
	/// <description>Expected general_level_idc</description>
	/// <description>Notes</description>
	/// </listheader>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_1</description>
	/// <description>30</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (10)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_2</description>
	/// <description>60</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (20)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_21</description>
	/// <description>63</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (21)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_3</description>
	/// <description>90</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (30)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_31</description>
	/// <description>93</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (31)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_4 1</description>
	/// <description>20</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (40)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_41 1</description>
	/// <description>23</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (41)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_5 1</description>
	/// <description>50</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (50)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_51 1</description>
	/// <description>53</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (51)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_52 1</description>
	/// <description>56</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (52)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_6 1</description>
	/// <description>80</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (60)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_61 1</description>
	/// <description>83</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (61)</description>
	/// </item>
	/// <item>
	/// <description>D3D12_VIDEO_ENCODER_LEVELS_HEVC_62 1</description>
	/// <description>86</description>
	/// <description>Corresponds to 3 * enum level 2 digit suffix (62)</description>
	/// </item>
	/// </list>
	/// <para>HEVC Video Parameter Set expected values</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Syntax element</description>
	/// <description>Expected default value</description>
	/// <description>Notes</description>
	/// </listheader>
	/// <item>
	/// <description>vps_video_parameter_set_id</description>
	/// <description>User specific</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_base_layer_internal_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_base_layer_available_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_max_layers_minus1</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_max_sub_layers_minus1</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_temporal_id_nesting_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_reserved_ffff_16bits</description>
	/// <description>0xFFFF</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_profile_space</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_tier_flag</description>
	/// <description>1 for High tier, 0 for Main tier</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_profile_idc</description>
	/// <description>D3D12_VIDEO_ENCODER_PROFILE_HEVC enum value + 1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_profile_compatibility_flag[general_profile_space]</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_progressive_source_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_interlaced_source_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_non_packed_constraint_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_frame_only_constraint_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_reserved_zero_44bits</description>
	/// <description>44 bit zeroes</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>general_level_idc</description>
	/// <description>Please see table above</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_sub_layer_ordering_info_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_max_dec_pic_buffering_minus1[0]</description>
	/// <description>
	/// (MaxReferenceFramesInDPB/ <c>previous reference frames</c>/ + 1 / <c>additional current frame recon pic</c>/) - 1/* <c>minus1 for header</c>/;
	/// </description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_max_num_reorder_pics[0]</description>
	/// <description>0 if no B frames. vps_max_dec_pic_buffering_minus1 otherwise.</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_max_latency_increase_plus1[0]</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_max_layer_id</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_num_layer_sets_minus1</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_timing_info_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>vps_extension_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// </list>
	/// <para>HEVC Sequence Parameter Set expected values</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Syntax element</description>
	/// <description>Expected default value</description>
	/// <description>Notes</description>
	/// <description/>
	/// </listheader>
	/// <item>
	/// <description>sps_video_parameter_set_id</description>
	/// <description>User specific</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_max_sub_layers_minus1</description>
	/// <description>Same as in associated VPS</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_temporal_id_nesting_flag</description>
	/// <description>Same as in associated VPS</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_profile_space</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_tier_flag</description>
	/// <description>1 for High tier, 0 for Main tier</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_profile_idc</description>
	/// <description>D3D12_VIDEO_ENCODER_PROFILE_HEVC enum value + 1</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_profile_compatibility_flag[general_profile_space]</description>
	/// <description>1</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_progressive_source_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_interlaced_source_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_non_packed_constraint_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_frame_only_constraint_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_reserved_zero_44bits</description>
	/// <description>44 bit zeroes</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>general_level_idc</description>
	/// <description>Please see table above</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>chroma_format_idc</description>
	/// <description>1</description>
	/// <description>4.2.0 for NV12 and P010</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>pic_width_in_luma_samples</description>
	/// <description>std::ceil(sequenceTargetResolution.Width / SubregionBlockPixelsSize)) * SubregionBlockPixelsSize</description>
	/// <description>Use current frame resolution for D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.SubregionBlockPixelsSize</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>pic_height_in_luma_samples</description>
	/// <description>std::ceil(sequenceTargetResolution.Height / SubregionBlockPixelsSize)) * SubregionBlockPixelsSize</description>
	/// <description>Use current frame resolution for D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.SubregionBlockPixelsSize</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>conformance_window_flag</description>
	/// <description>0 if resolution is aligned to SubregionBlockPixelsSize, 1 otherwise</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>conf_win_left_offset</description>
	/// <description>0</description>
	/// <description>Only if conformance_windows_flag = 1</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>conf_win_right_offset</description>
	/// <description>(sps.pic_width_in_luma_samples - encodeResolution.Width) &gt;&gt; 1</description>
	/// <description>Only if conformance_windows_flag = 1</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>conf_win_top_offset</description>
	/// <description>0</description>
	/// <description>Only if conformance_windows_flag = 1</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>conf_win_bottom_offset</description>
	/// <description>(sps.pic_height_in_luma_samples - encodeResolution.Height) &gt;&gt; 1</description>
	/// <description>Only if conformance_windows_flag = 1</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>bit_depth_luma_minus8</description>
	/// <description>0 for NV12, 2 for P010</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>bit_depth_luma_minus8</description>
	/// <description>0 for NV12, 2 for P010</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>log2_max_pic_order_cnt_lsb_minus4</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_sub_layer_ordering_info_present_flag</description>
	/// <description>Same as in associated VPS</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_max_dec_pic_buffering_minus1</description>
	/// <description>Same as in associated VPS</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_max_num_reorder_pics</description>
	/// <description>Same as in associated VPS</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_max_latency_increase_plus1</description>
	/// <description>Same as in associated VPS</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>log2_min_luma_coding_block_size_minus3</description>
	/// <description>std::log2(minCuSize) - 3)</description>
	/// <description>For example MinCUSize=8 for D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_8x8</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>log2_diff_max_min_luma_coding_block_size</description>
	/// <description>std::log2(maxCuSize) - std::log2(minCuSize))</description>
	/// <description>For example MaxCUSize=16 for D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_CUSIZE_16x16</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>log2_min_transform_block_size_minus2</description>
	/// <description>std::log2(minTuSize) - 2)</description>
	/// <description>For example MinTuSize=4 for D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_4x4</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>log2_diff_max_min_transform_block_size</description>
	/// <description>std::log2(maxTuSize) - std::log2(minTuSize))</description>
	/// <description>For example MaxTuSize=16 for D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_TUSIZE_16x16</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>max_transform_hierarchy_depth_inter</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>max_transform_hierarchy_depth_inter</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>scaling_list_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>amp_enabled_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_USE_ASYMETRIC_MOTION_PARTITION</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sample_adaptive_offset_enabled_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_SAO_FILTER</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>pcm_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>num_short_term_ref_pic_sets</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>long_term_ref_pics_present_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_LONG_TERM_REFERENCES</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>num_long_term_ref_pics_sps</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_temporal_mvp_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>strong_intra_smoothing_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>vui_parameters_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>sps_extension_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// <description/>
	/// </item>
	/// </list>
	/// <para>HEVC Picture Parameter Set expected values</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Syntax element</description>
	/// <description>Expected default value</description>
	/// <description>Notes</description>
	/// </listheader>
	/// <item>
	/// <description>pps_pic_parameter_set_id</description>
	/// <description>User specific</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_seq_parameter_set_id</description>
	/// <description>User specific</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>dependent_slice_segments_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>output_flag_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>num_extra_slice_header_bits</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>sign_data_hiding_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>cabac_init_present_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>num_ref_idx_lx_default_active_minus1[0]</description>
	/// <description>std::max(static_cast&lt;INT&gt;(pictureControl.List0ReferenceFramesCount) - 1, 0))</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>num_ref_idx_lx_default_active_minus1[1]</description>
	/// <description>std::max(static_cast&lt;INT&gt;(pictureControl.List1ReferenceFramesCount) - 1, 0))</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>init_qp_minus26</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>constrained_intra_pred_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_USE_CONSTRAINED_INTRAPREDICTION</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>transform_skip_enabled_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_ENABLE_TRANSFORM_SKIPPING</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>cu_qp_delta_enabled_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>diff_cu_qp_delta_depth</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_cb_qp_offset</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_cr_qp_offset</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_slice_chroma_qp_offsets_present_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>weighted_pred_flag</description>
	/// <description>0</description>
	/// <description>No support for weighted prediction in the API</description>
	/// </item>
	/// <item>
	/// <description>weighted_bipred_flag</description>
	/// <description>0</description>
	/// <description>No support for weighted prediction in the API</description>
	/// </item>
	/// <item>
	/// <description>transquant_bypass_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>tiles_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>entropy_coding_sync_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_loop_filter_across_slices_enabled_flag</description>
	/// <description>Based on D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_HEVC_FLAG_DISABLE_LOOP_FILTER_ACROSS_SLICES</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>deblocking_filter_control_present_flag</description>
	/// <description>1</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>deblocking_filter_override_enabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_deblocking_filter_disabled_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_beta_offset_div2</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_tc_offset_div2</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_scaling_list_data_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>lists_modification_present_flag</description>
	/// <description>
	/// 1 if sending down D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC lists modifications. Otherwise set as 0.
	/// </description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>log2_parallel_merge_level_minus2</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>slice_segment_header_extension_present_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// <item>
	/// <description>pps_extension_flag</description>
	/// <description>0</description>
	/// <description>None</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_codec_data_hevc
	// typedef struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC { D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAGS Flags;
	// D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC FrameType; UINT slice_pic_parameter_set_id; UINT PictureOrderCountNumber; UINT
	// TemporalLayerIndex; UINT List0ReferenceFramesCount; UINT *pList0ReferenceFrames; UINT List1ReferenceFramesCount; UINT
	// *pList1ReferenceFrames; UINT ReferenceFramesReconPictureDescriptorsCount; D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_HEVC
	// *pReferenceFramesReconPictureDescriptors; UINT List0RefPicModificationsCount; UINT *pList0RefPicModifications; UINT
	// List1RefPicModificationsCount; UINT *pList1RefPicModifications; UINT QPMapValuesCount; INT8 *pRateControlQPMap; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC
	{
		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAGS</c> enumeration
		/// specifying configuration flags for the frame being encoded.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA_HEVC_FLAGS Flags;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC</c> enumeration specifying the picture type. Make sure that the
		/// codec-specific flags support the specified type. This selection must be kept in sync with the GOP structure configuration set by
		/// the host. Note that the GOP is defined in display order and this pic type selection must follow the GOP, but in encode order.
		/// </summary>
		public D3D12_VIDEO_ENCODER_FRAME_TYPE_HEVC FrameType;

		/// <summary>A <b>UINT</b> specifying the value to be used in the slice headers of the current frame to reference the PPS.</summary>
		public uint slice_pic_parameter_set_id;

		/// <summary>A <b>UINT</b> specifying the current frame display order.</summary>
		public uint PictureOrderCountNumber;

		/// <summary>
		/// A <b>UINT</b> specifying the picture layer number in temporal hierarchy. Check for the maximum number of layers in <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC</c>.
		/// </summary>
		public uint TemporalLayerIndex;

		/// <summary>
		/// A <b>UINT</b> specifying the number of past frame references to be used for this frame. This value should be coherent with what
		/// was exposed in <b>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC</b>.
		/// </summary>
		public uint List0ReferenceFramesCount;

		/// <summary>
		/// A pointer to a <b>UINT</b> array specifying the list of past frame reference frames to be used for this frame. Each integer
		/// value in this array indices into pReferenceFramesReconPictureDescriptors to reference pictures kept in the DPB.
		/// </summary>
		public ArrayPointer<uint> pList0ReferenceFrames;

		/// <summary>
		/// A <b>UINT</b> specifying the number of future frame references to be used for this frame. This value should be coherent with
		/// what was exposed in <b>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_HEVC</b>.
		/// </summary>
		public uint List1ReferenceFramesCount;

		/// <summary>
		/// A pointer to a <b>UINT</b> array specifying the list of future frame reference frames to be used for this frame. Each integer
		/// value in this array indices into pReferenceFramesReconPictureDescriptors to reference pictures kept in the DPB.
		/// </summary>
		public ArrayPointer<uint> pList1ReferenceFrames;

		/// <summary>A <b>UINT</b> specifying the number of entries in pReferenceFramesReconPictureDescriptors.</summary>
		public uint ReferenceFramesReconPictureDescriptorsCount;

		/// <summary>
		/// <para>
		/// A pointer to a <b>UINT</b> array that describes the current state of the DPB buffer kept in
		/// <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames</c>. The pList0ReferenceFrames and pList1ReferenceFrames lists
		/// indices map from past/future references into this descriptors array.
		/// </para>
		/// <para>
		/// This array of descriptors, in turn, maps a reference picture for this frame into a resource index in the reconstructed pictures
		/// array <b>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames</b>. Additionally, for each reference picture it indicates the
		/// encode and display order number and whether it is a long term reference.
		/// </para>
		/// <para>
		/// The size of this array always matches <b>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames.NumTextures</b> for the
		/// associated <b>EncodeFrame</b> command.
		/// </para>
		/// </summary>
		public ArrayPointer<D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_HEVC> pReferenceFramesReconPictureDescriptors;

		/// <summary>A <b>UINT</b> specifying the number of items in pList0RefPicModifications.</summary>
		public uint List0RefPicModificationsCount;

		/// <summary>A pointer to a <b>UINT</b> array containing modification commands for the L0 list.</summary>
		public ArrayPointer<uint> pList0RefPicModifications;

		/// <summary>A <b>UINT</b> specifying the number of items in pList1RefPicModifications.</summary>
		public uint List1RefPicModificationsCount;

		/// <summary>A pointer to a <b>UINT</b> array containing modification commands for the L1 list.</summary>
		public ArrayPointer<uint> pList1RefPicModifications;

		/// <summary>
		/// A <b>UINT</b> specifying the number of elements present in pRateControlQPMap. This should match the number of coding blocks in
		/// the frame, rounding up the frame resolution to the closest aligned values.
		/// </summary>
		public uint QPMapValuesCount;

		/// <summary>
		/// A pointer to an array of <b>Int8</b> containing, in row/column scan order, the QP map values to use on each squared region for
		/// this frame. The QP map dimensions can be calculated using the current resolution and
		/// <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.QPMapRegionPixelsSize</c> conveying the squared region sizes.
		/// </summary>
		public ArrayPointer<sbyte> pRateControlQPMap;
	}

	/// <summary>Describes a video encoder picture control.</summary>
	/// <remarks>
	/// <para>The following remarks provide guidance for frame management.</para>
	/// <para>
	/// The host calls <c>EncodeFrame</c> in encode order based in the picture type periodic sequence configured in the codec GOP structure
	/// after doing the B-frame reordering by POC if needed. Different codecs will use their own ways of indexing this structure and keeping
	/// their state metadata. Refer to the codec picture parameters also passed in the <b>EncodeFrame</b> operation that contain such details.
	/// </para>
	/// <para>
	/// <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RECONSTRUCTED_FRAMES_REQUIRE_TEXTURE_ARRAYS</c> specifies the requirement of texture arrays for
	/// the ppTexture2Ds and pSubresources fields of the <b>D3D12_VIDEO_ENCODE_REFERENCE_FRAMES</b> structure.
	/// </para>
	/// <para>
	/// The output of the encode operation for a given frame must also return the reconstructed picture if marked as used as reference for
	/// future usage in next frames, the client passes the reconstructed pictures in future <b>EncodeFrame</b> commands.
	/// </para>
	/// <para>
	/// If coding temporal layers, a picture can only use as references pictures on lower TemporalLayerIndex than its own. The temporal
	/// layer indices are specified in the picture control structure and in the reference picture descriptors.
	/// </para>
	/// <para>
	/// The HW limitations for the number of reference pictures are expressed in terms of the maximum number of elements present in L0
	/// (MaxL0ReferencesForP/MaxL0ReferencesForB) and L1 (MaxL1ReferencesForB) lists and limiting by MaxDPBCapacity the maximum number of
	/// unique indices in (L0 union L1) that map into the value of pReferenceFramesReconPictureDescriptors provided in <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA</c>.
	/// </para>
	/// <para>
	/// There's no limitation to the number of DPB entries being passed in pReferenceFramesReconPictureDescriptors, but instead in the
	/// number of entries on that array being references by the L0 and L1 lists. This allows the user to track the state of a DPB in
	/// pReferenceFramesReconPictureDescriptors within the restrictions defined by the codec standard limitations and only use a subset
	/// restricted by the hardware limitations when calling <b>EncodeFrame</b>. For example, for HEVC encoding, the caller could keep track
	/// of the latest 15 encoded pictures in pReferenceFramesReconPictureDescriptors but only use a subset of the pictures that falls within
	/// the hardware restrictions, by assigning a limited number of unique indices in the L0 and L1 lists.
	/// </para>
	/// <para>
	/// Note that a request for an IDR frame will act as a barrier between frame references and the DPB buffer and its state might need to
	/// be flushed accordingly by the host.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_desc typedef struct
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC { UINT IntraRefreshFrameIndex; D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAGS Flags;
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA PictureControlCodecData; D3D12_VIDEO_ENCODE_REFERENCE_FRAMES ReferenceFrames; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC
	{
		/// <summary>
		/// When requesting an intra-refresh wave for IntraRefreshFramesDuration frames by specifying the
		/// <c>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAG_REQUEST_INTRA_REFRESH</c> flag, this value indicates, for the current picture, the
		/// index of the frame in the intra-refresh wave. The value range is set by the host between 0 and <c>IntraRefreshFramesDuration</c>
		/// to hint the status of the intra-refresh session to the driver.
		/// </summary>
		public uint IntraRefreshFrameIndex;

		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAGS</c> enumeration specifying the picture
		/// control descriptor flags.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PICTURE_CONTROL_FLAGS Flags;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA</c> structure containing codec-specific picture control data. Depending of
		/// the selected rate control mode the QP values are interpreted differently.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PICTURE_CONTROL_CODEC_DATA PictureControlCodecData;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODE_REFERENCE_FRAMES</c> structure containing the reconstructed pictures from the past encoding operations outputs.
		/// </summary>
		public D3D12_VIDEO_ENCODE_REFERENCE_FRAMES ReferenceFrames;
	}

	/// <summary>Defines picture control subregions as slices for multiple codecs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_subregions_layout_data
	// typedef struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA { UINT DataSize; union { const
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES *pSlicesPartition_H264; const
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES *pSlicesPartition_HEVC; const
	// D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_TILES *pTilesPartition_AV1; }; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA
	{
		/// <summary>The data size of the provided picture control subregions layout structure.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES</c> Defines subregions as slices for H.264 encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES> pSlicesPartition_H264 { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES</c> Defines subregions as slices for HEVC encoding.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES> pSlicesPartition_HEVC { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_AV1_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_TILES> pTilesPartition_AV1 { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Defines subregions as slices for codecs that support this partitioning mode.</summary>
	/// <remarks>
	/// For modes that imply a fixed number of slices, the number of slices selected must be less than indicated by
	/// <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.MaxSubregionsNumber</c> and the selected resolution.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_control_subregions_layout_data_slices
	// typedef struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES { union { UINT MaxBytesPerSlice; UINT
	// NumberOfCodingUnitsPerSlice; UINT NumberOfRowsPerSlice; UINT NumberOfSlicesPerFrame; }; } D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA_SLICES
	{
		/// <summary>The maximum number of bytes per slice to be used. This field is used exclusively with <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_BYTES_PER_SUBREGION</c>.</summary>
		[FieldOffset(0)]
		public uint MaxBytesPerSlice;

		/// <summary>
		/// The number of squared blocks to be used per slice. The size in pixels of the squared regions can be calculated using the current
		/// resolution and <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.SubregionBlockPixelsSize</c> for the current frame
		/// resolution. This field is used exclusively with <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_SQUARE_UNITS_PER_SUBREGION_ROW_UNALIGNED</c>.
		/// </summary>
		[FieldOffset(0)]
		public uint NumberOfCodingUnitsPerSlice;

		/// <summary>
		/// The number of squared blocks rows per slice for the frame to be divided into. The size in pixels of the squared regions can be
		/// calculated using the current resolution and
		/// <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_RESOLUTION_SUPPORT_LIMITS.SubregionBlockPixelsSize</c> for the current frame resolution.
		/// This field is used exclusively with <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_ROWS_PER_SUBREGION</c>.
		/// </summary>
		[FieldOffset(0)]
		public uint NumberOfRowsPerSlice;

		/// <summary>The number of slices to divide the frame into. This field is used exclusively with <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE_UNIFORM_PARTITIONING_SUBREGIONS_PER_FRAME</c>.</summary>
		[FieldOffset(0)]
		public uint NumberOfSlicesPerFrame;
	}

	/// <summary>Defines a video encoder picture resolution.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_resolution_desc typedef
	// struct D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC { UINT Width; UINT Height; } D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC
	{
		/// <summary>The resolution width, in pixels.</summary>
		public uint Width;

		/// <summary>The resolution height, in pixels.</summary>
		public uint Height;
	}

	/// <summary>Defines a video encoder picture resolution ratio as an irreducible fraction.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_picture_resolution_ratio_desc
	// typedef struct D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_RATIO_DESC { UINT WidthRatio; UINT HeightRatio; } D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_RATIO_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_RATIO_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_RATIO_DESC
	{
		/// <summary>The resolution ratio numerator.</summary>
		public uint WidthRatio;

		/// <summary>The resolution ratio denominator.</summary>
		public uint HeightRatio;
	}

	/// <summary>Describes an encoder profile.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_profile_desc typedef struct
	// D3D12_VIDEO_ENCODER_PROFILE_DESC { UINT DataSize; union { D3D12_VIDEO_ENCODER_PROFILE_H264 *pH264Profile;
	// D3D12_VIDEO_ENCODER_PROFILE_HEVC *pHEVCProfile; D3D12_VIDEO_ENCODER_AV1_PROFILE *pAV1Profile; }; } D3D12_VIDEO_ENCODER_PROFILE_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_PROFILE_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_VIDEO_ENCODER_PROFILE_DESC
	{
		/// <summary>The data size of the provided encoder profile value.</summary>
		[FieldOffset(0)]
		public uint DataSize;

		/// <summary>A pointer to a value from the <c>D3D12_VIDEO_ENCODER_PROFILE_H264</c> enumeration specifying an H.264 profile.</summary>
		[FieldOffset(4)]
		public D3D12_VIDEO_ENCODER_PROFILE_H264 pH264Profile;

		/// <summary>A pointer to a value from the <c>D3D12_VIDEO_ENCODER_PROFILE_HEVC</c> enumeration specifying an HEVC profile.</summary>
		[FieldOffset(4)]
		public D3D12_VIDEO_ENCODER_PROFILE_HEVC pHEVCProfile;

		/// <summary/>
		[FieldOffset(4)]
		public D3D12_VIDEO_ENCODER_AV1_PROFILE pAV1Profile;
	}

	/// <summary>Represents a video encoder rate control configuration.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_rate_control typedef struct
	// D3D12_VIDEO_ENCODER_RATE_CONTROL { D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE Mode; D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAGS Flags;
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS ConfigParams; DXGI_RATIONAL TargetFrameRate; } D3D12_VIDEO_ENCODER_RATE_CONTROL;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL
	{
		/// <summary>A value from the <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE</c> enumeration specifying the rate control mode.</summary>
		public D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE Mode;

		/// <summary>A bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAGS</c> enumeration.</summary>
		public D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAGS Flags;

		/// <summary>
		/// <para>
		/// A <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS</c> structure representing rate control configuration parameters
		/// corresponding to the specified Mode. Note that for absolute QP matrix mode, the configuration arguments are provided per
		/// EncodeFrame basis.
		/// </para>
		/// <para>
		/// If the selected rate control mode is <b>D3D12_VIDEO_ENCODER_RATE_CONTROL_MODE_ABSOLUTE_QP_MAP</b>, the QP values in
		/// pRateControlQPMap are treated as absolute QP values.
		/// </para>
		/// <para>
		/// For the other rate control modes, the QP values in pRateControlQPMap are interpreted as a delta QP map to be used for the
		/// current frame encode operation. The values provided in the map are incremented/decremented on top of the QP values decided by
		/// the rate control algorithm or the baseline QP constant set in CQP mode.
		/// </para>
		/// </summary>
		public D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS ConfigParams;

		/// <summary>
		/// A <c>DXGI_RATIONAL</c> specifying the target frame rate for the encoded stream. This value is a hint for the rate control
		/// budgeting algorithm.
		/// </summary>
		public DXGI_RATIONAL TargetFrameRate;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_ABSOLUTE_QP_MAP
	{
		public uint QualityVsSpeed;
	}

	/// <summary>Represents a rate control structure definition for constant bitrate mode.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_rate_control_cbr typedef struct
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR { UINT InitialQP; UINT MinQP; UINT MaxQP; UINT64 MaxFrameBitSize; UINT64 TargetBitRate; UINT64
	// VBVCapacity; UINT64 InitialVBVFullness; } D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR
	{
		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_INITIAL_QP</c> is enabled, allows the Initial QP to be used by the rate
		/// control algorithm.
		/// </summary>
		public uint InitialQP;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE</c> is enabled, limits QP range of the rate control algorithm.
		/// </summary>
		public uint MinQP;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE</c> is enabled, limits QP range of the rate control algorithm.
		/// </summary>
		public uint MaxQP;

		/// <summary>
		/// Maximum size in bits for each frame to be coded. When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_MAX_FRAME_SIZE</c> is
		/// enabled, limits each frame maximum size in the rate control algorithm.
		/// </summary>
		public ulong MaxFrameBitSize;

		/// <summary>Specifies the constant bitrate to be used in bits/second.</summary>
		public ulong TargetBitRate;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_VBV_SIZE_CONFIG_AVAILABLE</c> is enabled, specifies the capacity in bits
		/// of the Video Buffer Verifier to be used in the rate control algorithm.
		/// </summary>
		public ulong VBVCapacity;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_VBV_SIZE_CONFIG_AVAILABLE</c> is enabled, specifies the initial fullness
		/// in bits of the Video Buffer Verifier to be used in the rate control algorithm.
		/// </summary>
		public ulong InitialVBVFullness;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR1
	{
		public uint InitialQP;
		public uint MinQP;
		public uint MaxQP;
		public ulong MaxFrameBitSize;
		public ulong TargetBitRate;
		public ulong VBVCapacity;
		public ulong InitialVBVFullness;
		public uint QualityVsSpeed;
	}

	/// <summary>Represents video encoder rate control structure definitions for a <c>D3D12_VIDEO_ENCODER_RATE_CONTROL</c> structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_rate_control_configuration_params
	// typedef struct D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS { UINT DataSize; union { const
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP *pConfiguration_CQP; const D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR *pConfiguration_CBR; const
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR *pConfiguration_VBR; const D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR *pConfiguration_QVBR; const
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP1 *pConfiguration_CQP1; const D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR1 *pConfiguration_CBR1; const
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR1 *pConfiguration_VBR1; const D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR1 *pConfiguration_QVBR1; const
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_ABSOLUTE_QP_MAP *pConfiguration_AbsoluteQPMap; }; } D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS
	{
		/// <summary>The data size of the provided rate control structure.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP</c> structure representing the rate control structure definition for constant
		/// quantization parameter mode.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP> pConfiguration_CQP { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR</c> structure representing the rate control structure definition for constant bitrate mode.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR> pConfiguration_CBR { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR</c> structure representing the rate control structure definition for variable bitrate mode.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR> pConfiguration_VBR { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR</c> structure representing the rate control structure definition for constant quality
		/// target with constrained bitrate mode.
		/// </summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR> pConfiguration_QVBR { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP1> pConfiguration_CQP1 { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_CBR1> pConfiguration_CBR1 { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR1> pConfiguration_VBR1 { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR1> pConfiguration_QVBR1 { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_RATE_CONTROL_ABSOLUTE_QP_MAP> pConfiguration_AbsoluteQPMap { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Represents a rate control structure definition for constant quantization parameter mode.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_rate_control_cqp typedef struct
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP { UINT ConstantQP_FullIntracodedFrame; UINT ConstantQP_InterPredictedFrame_PrevRefOnly; UINT
	// ConstantQP_InterPredictedFrame_BiDirectionalRef; } D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP
	{
		/// <summary>A UINT64 specifying the quantization parameter that should be used for each fully intra-encoded frame.</summary>
		public uint ConstantQP_FullIntracodedFrame;

		/// <summary>
		/// A UINT64 specifying the quantization parameter that should be used for each encoded frame that has inter-picture references to
		/// pictures (in display order) before the current one.
		/// </summary>
		public uint ConstantQP_InterPredictedFrame_PrevRefOnly;

		/// <summary>
		/// A UINT64 specifying the quantization parameter that should be used for each encoded frame that has inter-picture references to
		/// pictures (in display order) both from previous and next frames.
		/// </summary>
		public uint ConstantQP_InterPredictedFrame_BiDirectionalRef;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_CQP1
	{
		public uint ConstantQP_FullIntracodedFrame;
		public uint ConstantQP_InterPredictedFrame_PrevRefOnly;
		public uint ConstantQP_InterPredictedFrame_BiDirectionalRef;
		public uint QualityVsSpeed;
	}

	/// <summary>Represents a rate control structure definition for constant quality target with constrained bitrate.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_rate_control_qvbr typedef struct
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR { UINT InitialQP; UINT MinQP; UINT MaxQP; UINT64 MaxFrameBitSize; UINT64 TargetAvgBitRate;
	// UINT64 PeakBitRate; UINT ConstantQualityTarget; } D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR
	{
		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_INITIAL_QP</c> is enabled, allows the Initial QP to be used by the rate
		/// control algorithm.
		/// </summary>
		public uint InitialQP;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE</c> is enabled, limits QP range of the rate control algorithm.
		/// </summary>
		public uint MinQP;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE</c> is enabled, limits QP range of the rate control algorithm.
		/// </summary>
		public uint MaxQP;

		/// <summary>
		/// Maximum size in bits for each frame to be coded. When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_MAX_FRAME_SIZE</c> is
		/// enabled, limits each frame maximum size in the rate control algorithm.
		/// </summary>
		public ulong MaxFrameBitSize;

		/// <summary>Indicates the target average bit rate, in bits/second.</summary>
		public ulong TargetAvgBitRate;

		/// <summary>Indicates the maximum bit rate that can be reached in bits/second while using this rate control mode.</summary>
		public ulong PeakBitRate;

		/// <summary>The quality level target. The values are codec-specific as each standard defines the range for this argument.</summary>
		public uint ConstantQualityTarget;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_QVBR1
	{
		public uint InitialQP;
		public uint MinQP;
		public uint MaxQP;
		public ulong MaxFrameBitSize;
		public ulong TargetAvgBitRate;
		public ulong PeakBitRate;
		public ulong VBVCapacity;
		public ulong InitialVBVFullness;
		public uint ConstantQualityTarget;
		public uint QualityVsSpeed;
	}

	/// <summary>Represents a rate control structure definition for variable bitrate mode.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_rate_control_vbr typedef struct
	// D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR { UINT InitialQP; UINT MinQP; UINT MaxQP; UINT64 MaxFrameBitSize; UINT64 TargetAvgBitRate;
	// UINT64 PeakBitRate; UINT64 VBVCapacity; UINT64 InitialVBVFullness; } D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR
	{
		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_INITIAL_QP</c> is enabled, allows the Initial QP to be used by the rate
		/// control algorithm.
		/// </summary>
		public uint InitialQP;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE</c> is enabled, limits QP range of the rate control algorithm.
		/// </summary>
		public uint MinQP;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_QP_RANGE</c> is enabled, limits QP range of the rate control algorithm.
		/// </summary>
		public uint MaxQP;

		/// <summary>
		/// The maximum size, in bits, for each frame to be coded. When <c>D3D12_VIDEO_ENCODER_RATE_CONTROL_FLAG_ENABLE_MAX_FRAME_SIZE</c>
		/// is enabled, limits each frame maximum size in the rate control algorithm.
		/// </summary>
		public ulong MaxFrameBitSize;

		/// <summary>Average bitrate to be used, in bits/second.</summary>
		public ulong TargetAvgBitRate;

		/// <summary>The maximum bit rate that can be reached in bits/second.</summary>
		public ulong PeakBitRate;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_VBV_SIZE_CONFIG_AVAILABLE</c> is enabled, specifies the capacity in bits
		/// of the Video Buffer Verifier to be used in the rate control algorithm.
		/// </summary>
		public ulong VBVCapacity;

		/// <summary>
		/// When <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_VBV_SIZE_CONFIG_AVAILABLE</c> is enabled, specifies the initial fullness
		/// in bits of the Video Buffer Verifier to be used in the rate control algorithm.
		/// </summary>
		public ulong InitialVBVFullness;
	}

	/// <summary/>
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RATE_CONTROL_CONFIGURATION_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RATE_CONTROL_VBR1
	{
		public uint InitialQP;
		public uint MinQP;
		public uint MaxQP;
		public ulong MaxFrameBitSize;
		public ulong TargetAvgBitRate;
		public ulong PeakBitRate;
		public ulong VBVCapacity;
		public ulong InitialVBVFullness;
		public uint QualityVsSpeed;
	}

	/// <summary>Represents the reconstructed picture generated from the input frame passed to the encode operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_reconstructed_picture typedef struct
	// D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE { ID3D12Resource *pReconstructedPicture; UINT ReconstructedPictureSubresource; } D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RECONSTRUCTED_PICTURE
	{
		/// <summary>A <c>ID3D12Resource</c> representing the reconstructed picture generated from the input frame.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pReconstructedPicture;

		/// <summary>A UINT64 specifying the subresource index for pReconstructedPicture.</summary>
		public uint ReconstructedPictureSubresource;
	}

	/// <summary>Represents a reference picture descriptor for H.264 video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_reference_picture_descriptor_h264
	// typedef struct D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_H264 { UINT ReconstructedPictureResourceIndex; BOOL
	// IsLongTermReference; UINT LongTermPictureIdx; UINT PictureOrderCountNumber; UINT FrameDecodingOrderNumber; UINT TemporalLayerIndex; } D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_H264;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_H264")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_H264
	{
		/// <summary>
		/// Maps the current reference picture described by this structure to a resource in the
		/// <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames</c> array.
		/// </summary>
		public uint ReconstructedPictureResourceIndex;

		/// <summary>Set when the described reference frame is being used as a long-term reference picture.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsLongTermReference;

		/// <summary>If used as a long term reference, indicates the long-term reference index number.</summary>
		public uint LongTermPictureIdx;

		/// <summary>The described reference frame display order.</summary>
		public uint PictureOrderCountNumber;

		/// <summary>
		/// The frame decode order with semantic as indicated by the slice header frame_num syntax element associated with the encoded
		/// reference picture.
		/// </summary>
		public uint FrameDecodingOrderNumber;

		/// <summary>Picture layer number in temporal hierarchy. Please check for maximum number of layers in <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264</c>.</summary>
		public uint TemporalLayerIndex;
	}

	/// <summary>Represents a reference picture descriptor for HEVC video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_reference_picture_descriptor_hevc
	// typedef struct D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_HEVC { UINT ReconstructedPictureResourceIndex; BOOL
	// IsRefUsedByCurrentPic; BOOL IsLongTermReference; UINT PictureOrderCountNumber; UINT TemporalLayerIndex; } D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_HEVC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_HEVC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_REFERENCE_PICTURE_DESCRIPTOR_HEVC
	{
		/// <summary>
		/// A <b>UINT</b> that maps the current reference picture described by this structure to a resource in the
		/// <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_DESC.ReferenceFrames</c> array.
		/// </summary>
		public uint ReconstructedPictureResourceIndex;

		/// <summary>
		/// A <b>BOOL</b> indicating whether this descriptor entry is being used by the current picture by being indexed from either L0
		/// and/or L1 lists.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsRefUsedByCurrentPic;

		/// <summary>A <b>BOOL</b> that is set to true when the described reference frame is being used as a long-term reference picture.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool IsLongTermReference;

		/// <summary>A <b>UINT</b> specifying the described reference frame display order.</summary>
		public uint PictureOrderCountNumber;

		/// <summary>A <b>UINT</b> specifying the picture layer number in temporal hierarchy. Check for maximum number of layers in <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION_SUPPORT_H264</c>.</summary>
		public uint TemporalLayerIndex;
	}

	/// <summary>Represents input arguments for a call to <c>ID3D12VideoEncodeCommandList2::ResolveEncoderOutputMetadata</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_resolve_metadata_input_arguments
	// typedef struct D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS { D3D12_VIDEO_ENCODER_CODEC EncoderCodec;
	// D3D12_VIDEO_ENCODER_PROFILE_DESC EncoderProfile; DXGI_FORMAT EncoderInputFormat; D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC
	// EncodedPictureEffectiveResolution; D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER HWLayoutMetadata; } D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS
	{
		/// <summary>A <c>D3D12_VIDEO_ENCODER_CODEC</c> specifying the codec of the associated encode operation.</summary>
		public D3D12_VIDEO_ENCODER_CODEC EncoderCodec;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> specifying the profile for the selected codec in the associated encode operation.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PROFILE_DESC EncoderProfile;

		/// <summary>A <c>DXGI_FORMAT</c> specifying the input format of the associated encode operation.</summary>
		public DXGI_FORMAT EncoderInputFormat;

		/// <summary>A <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC</c> structure describing the resolution used for the encoding operation.</summary>
		public D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC EncodedPictureEffectiveResolution;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER</c> representing the associated opaque metadata buffer received from <c>EncodeFrame</c>.
		/// </summary>
		public D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER HWLayoutMetadata;
	}

	/// <summary>Represents output arguments for a call to <c>ID3D12VideoEncodeCommandList2::ResolveEncoderOutputMetadata</c>.</summary>
	/// <remarks>The following diagram illustrates the resolved metadata memory layout in an ID3D12Resource.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_resolve_metadata_output_arguments
	// typedef struct D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS { D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER
	// ResolvedLayoutMetadata; } D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS
	{
		/// <summary>
		/// <para>A <c>D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER</c> representing the resolved metadata buffer.</para>
		/// <para>
		/// This buffer must be read back to the CPU by the caller and cast to a <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</c> structure. The
		/// remaining data in the buffer, corresponds to <b>D3D12_VIDEO_ENCODER_OUTPUT_METADATA.WrittenSubregionsCount</b> packed entries of
		/// type <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_METADATA</c>.
		/// </para>
		/// </summary>
		public D3D12_VIDEO_ENCODER_ENCODE_OPERATION_METADATA_BUFFER ResolvedLayoutMetadata;
	}

	/// <summary>Represents parameters for the input of the video encoding operation at a sequence level.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_sequence_control_desc typedef struct
	// D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC { D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAGS Flags; D3D12_VIDEO_ENCODER_INTRA_REFRESH
	// IntraRefreshConfig; D3D12_VIDEO_ENCODER_RATE_CONTROL RateControl; D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC
	// PictureTargetResolution; D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE SelectedLayoutMode;
	// D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA FrameSubregionsLayoutData; D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE
	// CodecGopSequence; } D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_DESC
	{
		/// <summary>
		/// A bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAGS</c> enumeration specifying the
		/// sequence control descriptor flags for the current operation.
		/// </summary>
		public D3D12_VIDEO_ENCODER_SEQUENCE_CONTROL_FLAGS Flags;

		/// <summary>
		/// <para>
		/// A <c>D3D12_VIDEO_ENCODER_INTRA_REFRESH</c> structure specifying the parameters for the intra-refresh mode that should be used
		/// when triggering intra-refresh sessions.
		/// </para>
		/// <para>
		/// The use of bidirectional reference frames (B Frames) is mutually exclusive with intra-refresh. Callers should verify that the
		/// GOP structure doesn't contain B frames if intra-refresh modes are active. When querying for
		/// <c>D3D12_FEATURE_DATA_VIDEO_ENCODER_SUPPORT</c> with an intra-refresh mode other than
		/// <c>D3D12_VIDEO_ENCODER_INTRA_REFRESH_MODE_NONE</c>, the specified <c>D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE</c> set must not
		/// contain B frames, or the query will return no support.
		/// </para>
		/// <para>
		/// The usage of infinite intra-refresh is possible by requesting periodically a new wave of intra-refresh after each of them finishes.
		/// </para>
		/// <para>
		/// When starting an intra-refresh of N frames of duration, the hosts sets the corresponding picture control flag to start
		/// intra-refresh and controls the frame index between [0..N) also in the picture control structure to hint the driver about the
		/// progress about the intra refresh session.
		/// </para>
		/// <para>Expected behaviour when explicitly requesting an intra refresh wave with duration N frames:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>
		/// If the request for intra-refresh happens at the beginning of a GOP, the intra refresh ocurrs for N frames and then a new GOP is
		/// started with an I frame.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// If the request for intra-refresh happens in the middle of a GOP, the group of pictures will be ended until the last
		/// <b>EncodeFrame</b> command submitted and restarted after the intra-refresh session with a new GOP starting with an I frame. For
		/// example, when the GOP is IPPPP...IPPPP..., if the intra-refresh start is requested at the "IPP" partial submission of the GOP,
		/// the last two P frames of that GOP will be ignored, the intra-refresh session will be issued for the N next frames and then a new
		/// key-frame that restarts the GOP structure is expected.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// For row-based intra-refresh, the configured GOP structure will have to be reconfigured to Infinite IPPP...P... GOP (GOPLength =
		/// 0u and PPicturePeriod = 1u) for the duration of the intra refresh session. It can then be reconfigured again after the IR wave finished.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// For row based intra-refresh, the configured subregion partitioning mode will be reconfigured to correspond with N uniform slices
		/// partitioning per frame for a duration of N <b>EncodeFrame</b> commands. This is particularly important for when the subregion
		/// partitioning is set to an incompatible mode with IR requirements, for example when the row of intra coded units in a slice will
		/// disrupt the limitation set to bytes per slice. The expectation for row-based intra refresh is that the resulting frame contains
		/// N slices, all P slices, except the current intra refresh row slice, which has to be an I slice.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public D3D12_VIDEO_ENCODER_INTRA_REFRESH IntraRefreshConfig;

		/// <summary>
		/// <para>A <c>D3D12_VIDEO_ENCODER_RATE_CONTROL</c> structure specifying the rate control configuration.</para>
		/// <para>
		/// Check support for rate control dynamic reconfiguration in
		/// <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RATE_CONTROL_RECONFIGURATION_AVAILABLE</c>. If rate control dynamic reconfiguration is
		/// allowed, by modifying RateControl, the rate control algorithm is restarted with the new configuration starting from the
		/// execution of the associated <b>EncodeFrame</b>. Otherwise this should be set at the beginning of the encoding session and not
		/// changed after.
		/// </para>
		/// </summary>
		public D3D12_VIDEO_ENCODER_RATE_CONTROL RateControl;

		/// <summary>
		/// <para>A <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC</c> structure describing the resolution to use when encoding this frame.</para>
		/// <para>
		/// Check support for resolution dynamic reconfiguration in
		/// <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_RESOLUTION_RECONFIGURATION_AVAILABLE</c>. If no support is given for this,
		/// PictureTargetResolution indicates the target resolution of the full encoding session and must not be changed during the encoding
		/// session. Otherwise this indicates the resolution used for the associated <b>EncodeFrame</b> command.
		/// </para>
		/// <para>The target must be set based on the list of resolutions specified when creating the associated encoder heap for this operation.</para>
		/// <para>
		/// For some codecs, A change in resolution in the middle of the encoding session might require a GOP to be reset with a potential
		/// force IDR/Key frame request, and also might require resetting the DPB buffer/frame management algorithms.
		/// </para>
		/// </summary>
		public D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC PictureTargetResolution;

		/// <summary>
		/// <para>
		/// A value from the <c>D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE</c> enumeration specifying which layout mode is being used
		/// and therefore which union members to use in pFrameSubregionsLayoutData.
		/// </para>
		/// <para>
		/// Check support for subregion dynamic reconfiguration in
		/// [D3D12_VIDEO_ENCODER_SUPPORT_FLAG_SUBREGION_LAYOUT_RECONFIGURATION_AVAILABLE]((ne-d3d12video-d3d12_video_encoder_support_flags.md).
		/// If no support is given for this, this indicates the target subregion mode of the full encoding session and must not be changed
		/// during the encoding session. Otherwise this indicates the subregion partitioning mode used for the associated <b>EncodeFrame</b> command.
		/// </para>
		/// </summary>
		public D3D12_VIDEO_ENCODER_FRAME_SUBREGION_LAYOUT_MODE SelectedLayoutMode;

		/// <summary>
		/// A <c>D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA</c> structure specifying picture subregions layout optional
		/// codec-specific data. If the specified SelectedLayoutMode value indicates that such that there are no subregions, null is expected.
		/// </summary>
		public D3D12_VIDEO_ENCODER_PICTURE_CONTROL_SUBREGIONS_LAYOUT_DATA FrameSubregionsLayoutData;

		/// <summary>
		/// <para>
		/// A <c>D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE</c> structure specifying the current GOP used in the video sequence, in display
		/// order. Calls to <c>EncodeFrame</c> must follow this GOP but in encode order after B-Frames reordering.
		/// </para>
		/// <para>
		/// Check support for GOP dynamic reconfiguration in <c>D3D12_VIDEO_ENCODER_SUPPORT_FLAG_SEQUENCE_GOP_RECONFIGURATION_AVAILABLE</c>.
		/// If no support is given for this, CodecGopSequence indicates the target GOP pattern (in display order) of the full encoding
		/// session and must not be changed during the encoding session. Otherwise this indicates the new GOP subregion mode used starting
		/// at the associated <b>EncodeFrame</b> command.
		/// </para>
		/// </summary>
		public D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE CodecGopSequence;
	}

	/// <summary>Represents the GOP structure for multiple video codecs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_sequence_gop_structure typedef
	// struct D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE { UINT DataSize; union { D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264
	// *pH264GroupOfPictures; D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC *pHEVCGroupOfPictures;
	// D3D12_VIDEO_ENCODER_AV1_SEQUENCE_STRUCTURE *pAV1SequenceStructure; }; } D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE
	{
		/// <summary>The data size of the provided encoder GOP structure.</summary>
		public uint DataSize;

		private IntPtr union;

		/// <summary>A pointer to a <c>D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264</c> representing the GOP structure for H.264 encoding.</summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264> pH264GroupOfPictures { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary>A pointer to a <c>D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC</c> representing the GOP structure for H.264 encoding.</summary>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC> pHEVCGroupOfPictures { get => new(union, false); set => union = value.DangerousGetHandle(); }

		/// <summary/>
		public SafeCoTaskMemStruct<D3D12_VIDEO_ENCODER_AV1_SEQUENCE_STRUCTURE> pAV1SequenceStructure { get => new(union, false); set => union = value.DangerousGetHandle(); }
	}

	/// <summary>Represents the GOP structure for H.264 video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_sequence_gop_structure_h264 typedef
	// struct D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264 { UINT GOPLength; UINT PPicturePeriod; UCHAR pic_order_cnt_type; UCHAR
	// log2_max_frame_num_minus4; UCHAR log2_max_pic_order_cnt_lsb_minus4; } D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_H264
	{
		/// <summary>
		/// The distance between I-frames in the sequence, or the number of pictures on a GOP. If set to 0, only the first frame will be an
		/// I frame (infinite GOP).
		/// </summary>
		public uint GOPLength;

		/// <summary>
		/// <para>
		/// The period for P-frames to be inserted within the GOP. Note that if GOPLength is set to 0 for infinite GOP, this value must be
		/// greater than zero.
		/// </para>
		/// <para>Example usage; Let A=GOPLength; B=PPictureInterval</para>
		/// <list type="bullet">
		/// <item>
		/// <description>A=0; B=1 =&gt; IPPPPPPPP...</description>
		/// </item>
		/// <item>
		/// <description>A=0; B=2 =&gt; IBPBPBPBP...</description>
		/// </item>
		/// <item>
		/// <description>A=0; B=3 =&gt; IBBPBBPBB...</description>
		/// </item>
		/// <item>
		/// <description>A=1; B=0 =&gt; IIIIIIIII...</description>
		/// </item>
		/// <item>
		/// <description>A=2; B=1 =&gt; IPIPIPIPI...</description>
		/// </item>
		/// <item>
		/// <description>A=3; B=1 =&gt; IPPIPPIPP...</description>
		/// </item>
		/// <item>
		/// <description>A=3; B=2 =&gt; IBPIBPIBP...</description>
		/// </item>
		/// <item>
		/// <description>A=4; B=3 =&gt; IBBPIBBPIBBP...</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint PPicturePeriod;

		/// <summary>
		/// Specifies the picture order count type filter mode as defined in the H264 standard under pic_order_cnt_type in the sequence
		/// parameter set. The value of pic_order_cnt_type shall be in the range of 0 to 2, inclusive.
		/// </summary>
		public byte pic_order_cnt_type;

		/// <summary>
		/// Specifies the value of the variable MaxFrameNum that is used in frame_num related derivations as follows: MaxFrameNum =
		/// 2^(log2_max_frame_num_minus4 + 4) The value of log2_max_frame_num_minus4 shall be in the range of 0 to 12, inclusive.
		/// </summary>
		public byte log2_max_frame_num_minus4;

		/// <summary>
		/// Specifies the value of the variable MaxPicOrderCntLsb that is used in the decoding process for picture order count as specified
		/// in clause 8.2.1 as follows: MaxPicOrderCntLsb = 2^ (log2_max_pic_order_cnt_lsb_minus4 + 4) The value of
		/// log2_max_pic_order_cnt_lsb_minus4 shall be in the range of 0 to 12, inclusive.
		/// </summary>
		public byte log2_max_pic_order_cnt_lsb_minus4;
	}

	/// <summary>Represents the GOP structure for HEVC video encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_encoder_sequence_gop_structure_hevc typedef
	// struct D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC { UINT GOPLength; UINT PPicturePeriod; UCHAR
	// log2_max_pic_order_cnt_lsb_minus4; } D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_ENCODER_SEQUENCE_GOP_STRUCTURE_HEVC
	{
		/// <summary>
		/// The distance between I-frames in the sequence, or the number of pictures on a GOP. If set to 0, only the first frame will be an
		/// I frame (infinite GOP).
		/// </summary>
		public uint GOPLength;

		/// <summary>
		/// <para>
		/// The period for P-frames to be inserted within the GOP. Note that if GOPLength is set to 0 for infinite GOP, this value must be
		/// greater than zero.
		/// </para>
		/// <para>Example usage; Let A=GOPLength; B=PPictureInterval</para>
		/// <list type="bullet">
		/// <item>
		/// <description>A=0; B=1 =&gt; IPPPPPPPP...</description>
		/// </item>
		/// <item>
		/// <description>A=0; B=2 =&gt; IBPBPBPBP...</description>
		/// </item>
		/// <item>
		/// <description>A=0; B=3 =&gt; IBBPBBPBB...</description>
		/// </item>
		/// <item>
		/// <description>A=1; B=0 =&gt; IIIIIIIII...</description>
		/// </item>
		/// <item>
		/// <description>A=2; B=1 =&gt; IPIPIPIPI...</description>
		/// </item>
		/// <item>
		/// <description>A=3; B=1 =&gt; IPPIPPIPP...</description>
		/// </item>
		/// <item>
		/// <description>A=3; B=2 =&gt; IBPIBPIBP...</description>
		/// </item>
		/// <item>
		/// <description>A=4; B=3 =&gt; IBBPIBBPIBBP...</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint PPicturePeriod;

		/// <summary>
		/// <para>
		/// The value of the variable MaxPicOrderCntLsb that is used in the decoding process for picture order count as specified in clause
		/// 8.2.1 as follows:
		/// </para>
		/// <para>MaxPicOrderCntLsb = 2^ (log2_max_pic_order_cnt_lsb_minus4 + 4)</para>
		/// <para>The value of log2_max_pic_order_cnt_lsb_minus4 shall be in the range of 0 to 12, inclusive.</para>
		/// </summary>
		public byte log2_max_pic_order_cnt_lsb_minus4;
	}

	/// <summary>Describes a video extension command.</summary>
	/// <remarks>Pass this structure to <c>ID3D12VideoDevice2::CreateVideoExtensionCommand</c> to create an instance of <c>ID3D12VideoExtensionCommand</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_extension_command_desc typedef struct
	// D3D12_VIDEO_EXTENSION_COMMAND_DESC { UINT NodeMask; GUID CommandId; } D3D12_VIDEO_EXTENSION_COMMAND_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_EXTENSION_COMMAND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_EXTENSION_COMMAND_DESC
	{
		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>The unique identifier for the video extension command.</summary>
		public Guid CommandId;
	}

	/// <summary>Describes a video extension command.</summary>
	/// <remarks>
	/// An array of this structure is provided in a <c>D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMANDS</c> structure returned from a call to
	/// <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMANDS</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_extension_command_info typedef struct
	// D3D12_VIDEO_EXTENSION_COMMAND_INFO { GUID CommandId; LPCWSTR Name; D3D12_COMMAND_LIST_SUPPORT_FLAGS CommandListSupportFlags; } D3D12_VIDEO_EXTENSION_COMMAND_INFO;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_EXTENSION_COMMAND_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_EXTENSION_COMMAND_INFO
	{
		/// <summary>The unique identifier for the video extension command.</summary>
		public Guid CommandId;

		/// <summary>A pointer to a wide string containing the name of the command.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string Name;

		/// <summary>
		/// A member of the <c>D3D12_COMMAND_LIST_SUPPORT_FLAGS</c> enumeration. Indicates the video command queue that the video extension
		/// targets. Only one value from the enumeration can be set.
		/// </summary>
		public D3D12_COMMAND_LIST_SUPPORT_FLAGS CommandListSupportFlags;
	}

	/// <summary>Describes a video extension command parameter.</summary>
	/// <remarks>
	/// An array of this structure is provided in a <c>D3D12_FEATURE_DATA_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> structure returned from a
	/// call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> when the feature specified is <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_extension_command_parameter_info typedef
	// struct D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO { LPCWSTR Name; D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE Type;
	// D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAGS Flags; } D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_INFO
	{
		/// <summary>A pointer to a wide string containing the name of the command.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string Name;

		/// <summary>A member of the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE</c> specifying the type of the parameter.</summary>
		public D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_TYPE Type;

		/// <summary>A member of the <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAGS</c> enumeration specifying the usage of the parameter.</summary>
		public D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_FLAGS Flags;
	}

	/// <summary>Defines the combination of a pixel format and color space for a resource content description.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_format typedef struct D3D12_VIDEO_FORMAT {
	// DXGI_FORMAT Format; DXGI_COLOR_SPACE_TYPE ColorSpace; } D3D12_VIDEO_FORMAT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_FORMAT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_FORMAT
	{
		/// <summary>A value from the <c>DXGI_FORMAT</c> enumeration, specifying the DXGI format of the data.</summary>
		public DXGI_FORMAT Format;

		/// <summary>A value from the <c>DXGI_COLOR_SPACE_TYPE</c> enumeration, specifying the color space of the data.</summary>
		public DXGI_COLOR_SPACE_TYPE ColorSpace;
	}

	/// <summary>
	/// Describes a <c>ID3D12VideoMotionEstimator</c>. Pass this structure into <c>ID3D12VideoDevice1::CreateVideoMotionEstimator</c> to
	/// create an instance of <b>ID3D12VideoMotionEstimator</b>.
	/// </summary>
	/// <remarks>
	/// Call <c>ID3D12VideoDevice::CheckFeatureSupport</c> and specify <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR</c> as the feature to
	/// determine supported values.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_motion_estimator_desc typedef struct
	// D3D12_VIDEO_MOTION_ESTIMATOR_DESC { UINT NodeMask; DXGI_FORMAT InputFormat; D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE BlockSize;
	// D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION Precision; D3D12_VIDEO_SIZE_RANGE SizeRange; } D3D12_VIDEO_MOTION_ESTIMATOR_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_MOTION_ESTIMATOR_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_MOTION_ESTIMATOR_DESC
	{
		/// <summary>
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>A value from the <c>DXGI_FORMAT</c> enumeration specifying the format of the input and reference frames.</summary>
		public DXGI_FORMAT InputFormat;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE</c> enumeration specifying the search block size the video
		/// motion estimator will use.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE BlockSize;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION</c> enumeration specifying the vector precision the video
		/// motion estimator will use.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION Precision;

		/// <summary>
		/// A <c>D3D12_VIDEO_SIZE_RANGE</c> structure representing the minimum and maximum input and reference frame size, in pixels, that
		/// the motion estimator will accept.
		/// </summary>
		public D3D12_VIDEO_SIZE_RANGE SizeRange;
	}

	/// <summary>Specifies the input parameters for calls to <c>ID3D12VideoEncodeCommandList::EstimateMotion</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_motion_estimator_input typedef struct
	// D3D12_VIDEO_MOTION_ESTIMATOR_INPUT { ID3D12Resource *pInputTexture2D; UINT InputSubresourceIndex; ID3D12Resource
	// *pReferenceTexture2D; UINT ReferenceSubresourceIndex; ID3D12VideoMotionVectorHeap *pHintMotionVectorHeap; } D3D12_VIDEO_MOTION_ESTIMATOR_INPUT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_MOTION_ESTIMATOR_INPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_MOTION_ESTIMATOR_INPUT
	{
		/// <summary>An <c>ID3D12Resource</c> representing the current frame. The motion estimation operation applies to the entire frame.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pInputTexture2D;

		/// <summary>The base plane of the MIP and array slice to use for the input.</summary>
		public uint InputSubresourceIndex;

		/// <summary>An <c>ID3D12Resource</c> representing the reference frame, or past frame, used for motion estimation.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pReferenceTexture2D;

		/// <summary>The base plane of the MIP and array slice to use for the reference.</summary>
		public uint ReferenceSubresourceIndex;

		/// <summary>
		/// An <c>ID3D12VideoMotionVectorHeap</c> representing the buffer containing the hardware-dependent output of the previous motion
		/// estimator operation which may be used for hinting the current operation. This parameter may be NULL, indicating that previous
		/// motion estimator output should not be considered for the current operation.
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12VideoMotionVectorHeap pHintMotionVectorHeap;
	}

	/// <summary>Specifies the output parameters for calls to <c>ID3D12VideoEncodeCommandList::EstimateMotion</c>.</summary>
	/// <remarks>
	/// Call <c>ID3D12VideoEncodeCommandList::ResolveMotionVectorHeap</c> to translate the motion vector output of the <c>EstimateMotion</c>
	/// method from hardware-dependent formats into a consistent format defined by the video motion estimation APIs.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_motion_estimator_output typedef struct
	// D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT { ID3D12VideoMotionVectorHeap *pMotionVectorHeap; } D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT
	{
		/// <summary>
		/// An <c>ID3D12VideoMotionVectorHeap</c> containing the resolved motion estimation vectors. Motion vectors are resolved to a
		/// <c>DXGI_FORMAT_R16G16_SINT</c> 2D texture. The resolved data is a signed 16-byte integer with quarter PEL units with the X
		/// vector component stored in the R component and the Y vector component stored in the G component. Motion vectors are stored in a
		/// 2D layout that corresponds to the pixel layout of the original input textures.
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12VideoMotionVectorHeap pMotionVectorHeap;
	}

	/// <summary>
	/// Describes a <c>ID3D12VideoMotionEstimatorHeap</c>. Pass this structure into <c>ID3D12VideoDevice1::CreateVideoMotionVectorHeap</c>
	/// to create an instance of <b>ID3D12VideoMotionEstimatorHeap</b>.
	/// </summary>
	/// <remarks>
	/// Call <c>ID3D12VideoDevice::CheckFeatureSupport</c> and specify <c>D3D12_FEATURE_VIDEO_MOTION_ESTIMATOR</c> as the feature to
	/// determine supported values.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_motion_vector_heap_desc typedef struct
	// D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC { UINT NodeMask; DXGI_FORMAT InputFormat; D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE
	// BlockSize; D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION Precision; D3D12_VIDEO_SIZE_RANGE SizeRange; } D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC
	{
		/// <summary>
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </summary>
		public uint NodeMask;

		/// <summary>A value from the <c>DXGI_FORMAT</c> enumeration specifying the format of the input and reference frames.</summary>
		public DXGI_FORMAT InputFormat;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE</c> enumeration specifying the search block size the video
		/// motion estimator will use.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_SEARCH_BLOCK_SIZE BlockSize;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION</c> enumeration specifying the vector precision the video
		/// motion estimator will use.
		/// </summary>
		public D3D12_VIDEO_MOTION_ESTIMATOR_VECTOR_PRECISION Precision;

		/// <summary>
		/// A <c>D3D12_VIDEO_SIZE_RANGE</c> structure representing the minimum and maximum input and reference frame size, in pixels, that
		/// the motion estimator will accept.
		/// </summary>
		public D3D12_VIDEO_SIZE_RANGE SizeRange;
	}

	/// <summary>
	/// Specifies alpha blending parameters for video processing. Used by the
	/// [D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS]ns-d3d12video-d3d12_video_process_input_stream_arguments) structure.
	/// </summary>
	/// <remarks>
	/// <para>For each pixel, the destination color value is computed as follows:</para>
	/// <para><c>Cd = Cs * (As * Ap * Ae) + Cd * (1.0 - As * Ap * Ae)</c></para>
	/// <para>where:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Cd = The color value of the destination pixel</description>
	/// </item>
	/// <item>
	/// <description>Cs = The color value of the source pixel</description>
	/// </item>
	/// <item>
	/// <description>As = The per-pixel source alpha</description>
	/// </item>
	/// <item>
	/// <description>Ap = The planar alpha value</description>
	/// </item>
	/// <item>
	/// <description>Ae = The palette-entry alpha value, or 1.0 (palette-entry alpha values apply only to palettized color formats)</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_alpha_blending typedef struct
	// D3D12_VIDEO_PROCESS_ALPHA_BLENDING { BOOL Enable; FLOAT Alpha; } D3D12_VIDEO_PROCESS_ALPHA_BLENDING;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_ALPHA_BLENDING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_ALPHA_BLENDING
	{
		/// <summary>A boolean value specifying whether alpha blending is enabled.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Enable;

		/// <summary>
		/// The planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque). If Enable is FALSe, this parameter is ignored.
		/// </summary>
		public float Alpha;
	}

	/// <summary>Defines the range of supported values for an image filter.</summary>
	/// <remarks>
	/// <para>
	/// The multiplier enables the filter range to have a fractional step value. For example, a hue filter might have an actual range of
	/// [–180.0 ... +180.0] with a step size of 0.25. The device would report the following range and multiplier:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>Minimum: –720</description>
	/// </item>
	/// <item>
	/// <description>Maximum: +720</description>
	/// </item>
	/// <item>
	/// <description>Multiplier: 0.25</description>
	/// </item>
	/// </list>
	/// <para>In this case, a filter value of 2 would be interpreted by the device as 0.50 (or 2 × 0.25).</para>
	/// <para>The device should use a multiplier that can be represented exactly as a base-2 fraction.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_filter_range typedef struct
	// D3D12_VIDEO_PROCESS_FILTER_RANGE { INT Minimum; INT Maximum; INT Default; FLOAT Multiplier; } D3D12_VIDEO_PROCESS_FILTER_RANGE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_FILTER_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_FILTER_RANGE
	{
		/// <summary>The minimum value of the filter.</summary>
		public int Minimum;

		/// <summary>The maximum value of the filter.</summary>
		public int Maximum;

		/// <summary>The default value of the filter.</summary>
		public int Default;

		/// <summary>
		/// A multiplier. Use the following formula to translate the filter setting into the actual filter value: <c>Actual Value = Set
		/// Value × Multiplier.</c>
		/// </summary>
		public float Multiplier;
	}

	/// <summary>Contains input information for the video processor blend functionality.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_input_stream typedef struct
	// D3D12_VIDEO_PROCESS_INPUT_STREAM { ID3D12Resource *pTexture2D; UINT Subresource; D3D12_VIDEO_PROCESS_REFERENCE_SET ReferenceSet; } D3D12_VIDEO_PROCESS_INPUT_STREAM;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_INPUT_STREAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_INPUT_STREAM
	{
		/// <summary>An <c>ID3D12Resource</c> representing the current input field or frame.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pTexture2D;

		/// <summary>The subresource index to use of the pTexture2D argument.</summary>
		public uint Subresource;

		/// <summary>
		/// A <c>D3D12_VIDEO_PROCESS_REFERENCE_SET</c> containing the set of references for video processing. Some video processing
		/// algorithms require forward or backward frame references. For more information, see <c>D3D12_FEATURE_VIDEO_PROCESS_REFERENCE_INFO</c>.
		/// </summary>
		public D3D12_VIDEO_PROCESS_REFERENCE_SET ReferenceSet;
	}

	/// <summary>Specifies input stream arguments for an input stream passed to <c>ID3D12VideoCommandList::ProcessFrames</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_input_stream_arguments typedef
	// struct D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS { D3D12_VIDEO_PROCESS_INPUT_STREAM InputStream[2]; D3D12_VIDEO_PROCESS_TRANSFORM
	// Transform; D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS Flags; D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE RateInfo; INT FilterLevels[32];
	// D3D12_VIDEO_PROCESS_ALPHA_BLENDING AlphaBlending; } D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS
	{
		/// <summary>
		/// An array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM</c> structures containing the set of references for video processing. If the
		/// stereo format is <c>D3D12_VIDEO_PROCESS_STEREO_FORMAT_SEPARATE</c>, then two sets of input streams must be supplied. For all
		/// other stereo formats, the first set of reference must be supplied, and the second should be zero initialized.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public D3D12_VIDEO_PROCESS_INPUT_STREAM InputStream;

		/// <summary>
		/// A <c>D3D12_VIDEO_PROCESS_TRANSFORM</c> structure specifying the flip, rotation, scale and destination translation for the video input.
		/// </summary>
		public D3D12_VIDEO_PROCESS_TRANSFORM Transform;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS</c> enumeration specifying the options for the input stream.
		/// </summary>
		public D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS Flags;

		/// <summary>
		/// A <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE</c> structure specifying the framerate and input and output indices for framerate
		/// conversion and deinterlacing.
		/// </summary>
		public D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE RateInfo;

		/// <summary>
		/// The level to apply for each enabled filter. The filter level is specified in the order that filters appear in the
		/// <c>D3D12_VIDEO_PROCESS_FILTER_FLAGS</c> enumeration. Specify 0 if a filter is not enabled or the filter index is reserved.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public int[] FilterLevels;

		/// <summary>
		/// A <c>D3D12_VIDEO_PROCESS_ALPHA_BLENDING</c> structure specifying the planar alpha for an input stream on the video processor.
		/// </summary>
		public D3D12_VIDEO_PROCESS_ALPHA_BLENDING AlphaBlending;
	}

	/// <summary>
	/// Specifies input stream arguments for an input stream passed to <c>ID3D12VideoProcessCommandList1::ProcessFrames1</c>, which supports
	/// changing the field type for each call.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_input_stream_arguments1 typedef
	// struct D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1 { D3D12_VIDEO_PROCESS_INPUT_STREAM InputStream[2]; D3D12_VIDEO_PROCESS_TRANSFORM
	// Transform; D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS Flags; D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE RateInfo; INT FilterLevels[32];
	// D3D12_VIDEO_PROCESS_ALPHA_BLENDING AlphaBlending; D3D12_VIDEO_FIELD_TYPE FieldType; } D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1
	{
		/// <summary>
		/// An array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM</c> structures containing the set of references for video processing. If the
		/// stereo format is <c>D3D12_VIDEO_PROCESS_STEREO_FORMAT_SEPARATE</c>, then two sets of input streams must be supplied. For all
		/// other stereo formats, the first set of reference must be supplied, and the second should be zero initialized.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public D3D12_VIDEO_PROCESS_INPUT_STREAM InputStream;

		/// <summary>
		/// A <c>D3D12_VIDEO_PROCESS_TRANSFORM</c> structure specifying the flip, rotation, scale and destination translation for the video input.
		/// </summary>
		public D3D12_VIDEO_PROCESS_TRANSFORM Transform;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS</c> enumeration specifying the options for the input stream.
		/// </summary>
		public D3D12_VIDEO_PROCESS_INPUT_STREAM_FLAGS Flags;

		/// <summary>
		/// A <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE</c> structure specifying the framerate and input and output indices for framerate
		/// conversion and deinterlacing.
		/// </summary>
		public D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE RateInfo;

		/// <summary>
		/// The level to apply for each enabled filter. The filter level is specified in the order that filters appear in the
		/// <c>D3D12_VIDEO_PROCESS_FILTER_FLAGS</c> enumeration. Specify 0 if a filter is not enabled or the filter index is reserved.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public int[] FilterLevels;

		/// <summary>
		/// A <c>D3D12_VIDEO_PROCESS_ALPHA_BLENDING</c> structure specifying the planar alpha for an input stream on the video processor.
		/// </summary>
		public D3D12_VIDEO_PROCESS_ALPHA_BLENDING AlphaBlending;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_FIELD_TYPE</c> enumeration specfying the interlaced field type of the input source. When working
		/// with mixed content, use <c>ID3D12VideoProcessCommandList1::ProcessFrames1</c> which supports changing the field type for each call.
		/// </summary>
		public D3D12_VIDEO_FIELD_TYPE FieldType;
	}

	/// <summary>Specifies the parameters for the input stream for a video process operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_input_stream_desc typedef struct
	// D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC { DXGI_FORMAT Format; DXGI_COLOR_SPACE_TYPE ColorSpace; DXGI_RATIONAL SourceAspectRatio;
	// DXGI_RATIONAL DestinationAspectRatio; DXGI_RATIONAL FrameRate; D3D12_VIDEO_SIZE_RANGE SourceSizeRange; D3D12_VIDEO_SIZE_RANGE
	// DestinationSizeRange; BOOL EnableOrientation; D3D12_VIDEO_PROCESS_FILTER_FLAGS FilterFlags; D3D12_VIDEO_FRAME_STEREO_FORMAT
	// StereoFormat; D3D12_VIDEO_FIELD_TYPE FieldType; D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS DeinterlaceMode; BOOL EnableAlphaBlending;
	// D3D12_VIDEO_PROCESS_LUMA_KEY LumaKey; UINT NumPastFrames; UINT NumFutureFrames; BOOL EnableAutoProcessing; } D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC
	{
		/// <summary>
		/// A value from the <c>DXGI_FORMAT</c> enumeration specifying the format of the input stream. In the case of stereo, this format is
		/// the format of both inputs.
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// A value from the <c>DXGI_COLOR_SPACE_TYPE</c> enumeration specifying the color space of the video processor input and reference surfaces.
		/// </summary>
		public DXGI_COLOR_SPACE_TYPE ColorSpace;

		/// <summary>A <c>DXGI_RATIONAL</c> structure specifying the source aspect ratio.</summary>
		public DXGI_RATIONAL SourceAspectRatio;

		/// <summary>A <c>DXGI_RATIONAL</c> structure specifying the destination aspect ratio.</summary>
		public DXGI_RATIONAL DestinationAspectRatio;

		/// <summary>A <c>DXGI_RATIONAL</c> structure specifying the frame rate of the input video stream.</summary>
		public DXGI_RATIONAL FrameRate;

		/// <summary>
		/// A <c>D3D12_VIDEO_SIZE_RANGE</c> structure representing the size of the source rectangle. This argument specifies the input range
		/// size this video processor must support for <c>ProcessFrames</c>. If a source size exceeds the range, the video processor must be recreated.
		/// </summary>
		public D3D12_VIDEO_SIZE_RANGE SourceSizeRange;

		/// <summary>
		/// A <c>D3D12_VIDEO_SIZE_RANGE</c> structure representing the size of the destination rectangle. This argument specifies the
		/// destination range size this video processor must support for <c>ProcessFrames</c>. If a source size exceeds the range, the video
		/// processor must be recreated.
		/// </summary>
		public D3D12_VIDEO_SIZE_RANGE DestinationSizeRange;

		/// <summary>
		/// A boolean value specifying whether the video processor should support all <c>D3D12_VIDEO_PROCESS_ORIENTATION</c> for <c>ProcessFrames</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool EnableOrientation;

		/// <summary>
		/// A bitwise OR combination of one or more flags from the <c>D3D12_VIDEO_PROCESS_FILTER_FLAGS</c> enumeration specifying the
		/// filters to enable.
		/// </summary>
		public D3D12_VIDEO_PROCESS_FILTER_FLAGS FilterFlags;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_FRAME_STEREO_FORMAT</c> enumeration specifies whether the stream is stereo or not. A value of
		/// <b>D3D12_VIDEO_PROCESS_STEREO_FORMAT_SEPARATE</b> indicates that there will be two sets of input textures, and two sets of
		/// references for the stereo interlaced case.
		/// </summary>
		public D3D12_VIDEO_FRAME_STEREO_FORMAT StereoFormat;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_FIELD_TYPE</c> enumeration specfying the interlaced field type of the input source. When working
		/// with mixed content, use <c>ID3D12VideoProcessCommandList1::ProcessFrames1</c> which supports changing the field type for each call.
		/// </summary>
		public D3D12_VIDEO_FIELD_TYPE FieldType;

		/// <summary>A value from the <c>D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS</c> enumeration specifying the deinterlace mode to use.</summary>
		public D3D12_VIDEO_PROCESS_DEINTERLACE_FLAGS DeinterlaceMode;

		/// <summary>
		/// A boolean value specifying whether alpha blending is enabled. Alpha blending settings are provided to <c>ProcessFrames</c> with
		/// AlphaBlending the field of the <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS</c> structure.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool EnableAlphaBlending;

		/// <summary>A <c>D3D12_VIDEO_PROCESS_LUMA_KEY</c> structure specifying the luma key for an input stream on the video processor.</summary>
		public D3D12_VIDEO_PROCESS_LUMA_KEY LumaKey;

		/// <summary>An integer specifying the number of past reference frames.</summary>
		public uint NumPastFrames;

		/// <summary>An integer specifying the number of future reference frames.</summary>
		public uint NumFutureFrames;

		/// <summary>A boolean value specifying wither automatic processing features are enabled for the video processor.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool EnableAutoProcessing;
	}

	/// <summary>Provides information about the stream rate.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_input_stream_rate typedef struct
	// D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE { UINT OutputIndex; UINT InputFrameOrField; } D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_INPUT_STREAM_RATE
	{
		/// <summary>
		/// <para>
		/// The zero-based index number of the output frame. The OutputIndex member is a zero-based cyclic number that indicates the frame
		/// index number of the output. The driver uses this output-index information to perform the video processing in a certain pattern
		/// or cycle, especially when the driver performs deinterlacing or frame-rate conversion. For example, with the following
		/// output-index pattern, the driver performs the indicated video processing:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Progressive format at normal and half rate:</description>
		/// </item>
		/// <item>
		/// <description>OutputInde = 0, 0,...</description>
		/// </item>
		/// <item>
		/// <description>Progressive format at 2/1 custom rate (double frame-rate conversion, OutputFrames=2):</description>
		/// </item>
		/// <item>
		/// <description>OutputInde = 0, 1, 0, 1,...</description>
		/// </item>
		/// <item>
		/// <description>Interlaced format at normal rate:</description>
		/// </item>
		/// <item>
		/// <description>OutputInde = 0, 1, 0, 1,... (0: first field, 1: second field)</description>
		/// </item>
		/// <item>
		/// <description>Interlaced format at half rate:</description>
		/// </item>
		/// <item>
		/// <description>OutputInde = 0, 0,... (for example, first and second fields are blended to one frame)</description>
		/// </item>
		/// <item>
		/// <description>Interlaced at 4/5 custom rate (3:2 inverse telecine, OutputFrames=4):</description>
		/// </item>
		/// <item>
		/// <description>OutputInde = 0, 1, 2, 3, 0, 1, 2, 3,... (0:A, 1:B, 2:C, 3:D film frame)</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint OutputIndex;

		/// <summary>
		/// <para>
		/// The zero-based index number of the input frame or field. The InputFrameOrField member is a zero-based number that indicates the
		/// frame or the field number of the input surface. For example, with the following input-frame-or-field number, the driver can
		/// perform the indicated video processing:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Progressive format and interlaced format at normal rate:</description>
		/// </item>
		/// <item>
		/// <description>Progressive format and interlaced format at half rate:</description>
		/// </item>
		/// <item>
		/// <description>Interlaced format at 4/5 custom rate (3:2 inverse telecine, OutputFrames=4 and InputFrameOrField=10):</description>
		/// </item>
		/// <item>
		/// <description>Interlaced format at 4/15 custom rate (8:7 inverse telecine, OutputFrames=2 and InputFrameOrField=15):</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint InputFrameOrField;
	}

	/// <summary>
	/// Specifies the settings used for luma keying. This value is used with the <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC</c> structure.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The values of Lower and Upper give the lower and upper bounds of the luma key, using a nominal range of [0...1]. Given a format with
	/// n bits per channel, these values are converted to luma values as follows:
	/// </para>
	/// <para><c>val = f * ((1 &lt;&lt; n)-1)</c></para>
	/// <para>
	/// Any pixel whose luma value falls within the upper and lower bounds (inclusive) is treated as transparent. For example, if the pixel
	/// format uses 8-bit luma, the upper bound is calculated as follows:
	/// </para>
	/// <para><c>BYTE Y = BYTE(max(min(1.0, Upper), 0.0) * 255.0)</c></para>
	/// <para>Note that the value is clamped to the range [0...1] before multiplying by 255.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_luma_key typedef struct
	// D3D12_VIDEO_PROCESS_LUMA_KEY { BOOL Enable; FLOAT Lower; FLOAT Upper; } D3D12_VIDEO_PROCESS_LUMA_KEY;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_LUMA_KEY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_LUMA_KEY
	{
		/// <summary>A boolean value specifying whether luma keying is enabled.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Enable;

		/// <summary>The lower bound for the luma key. The valid range is [0…1]. If Enable is FALSE, this parameter is ignored.</summary>
		public float Lower;

		/// <summary>The upper bound for the luma key. The valid range is [0…1]. If Enable is FALSE, this parameter is ignored.</summary>
		public float Upper;
	}

	/// <summary>Represents the output stream for video processing commands. Points to the target surface for the processing operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_output_stream typedef struct
	// D3D12_VIDEO_PROCESS_OUTPUT_STREAM { ID3D12Resource *pTexture2D; UINT Subresource; } D3D12_VIDEO_PROCESS_OUTPUT_STREAM;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_OUTPUT_STREAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_OUTPUT_STREAM
	{
		/// <summary>A pointer to a <c>ID3D12Resource</c> representing the output surfaces for the video process command.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public ID3D12Resource pTexture2D;

		/// <summary>The subresource indices to use within the resource specified pTexture2D resource.</summary>
		public uint Subresource;
	}

	/// <summary>Specifies output stream arguments for the output passed to <c>ID3D12VideoCommandList::ProcessFrames</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_output_stream_arguments typedef
	// struct D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS { D3D12_VIDEO_PROCESS_OUTPUT_STREAM OutputStream[2]; D3D12_RECT TargetRectangle; } D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS
	{
		/// <summary>
		/// An array of <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM</c> structures representing the output surfaces for the video process command.
		/// If stereo output is enabled, index zero contains the left output while index 1 contains the right input. If stereo output is not
		/// enabled, only index 0 is used to specify the output while index 1 should be set to nullptr.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public D3D12_VIDEO_PROCESS_OUTPUT_STREAM[] OutputStream;

		/// <summary>
		/// The target rectangle is the area within the destination surface where the output will be drawn. The target rectangle is given in
		/// pixel coordinates, relative to the destination surface.
		/// </summary>
		public D3D12_RECT TargetRectangle;
	}

	/// <summary>Specifies output stream arguments for the output passed to <c>ID3D12VideoProcessCommandList::ProcessFrames</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_output_stream_desc typedef struct
	// D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC { DXGI_FORMAT Format; DXGI_COLOR_SPACE_TYPE ColorSpace; D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE
	// AlphaFillMode; UINT AlphaFillModeSourceStreamIndex; FLOAT BackgroundColor[4]; DXGI_RATIONAL FrameRate; BOOL EnableStereo; } D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC
	{
		/// <summary>A <c>DXGI_FORMAT</c> structure specifying the format of the output resources.</summary>
		public DXGI_FORMAT Format;

		/// <summary>A <c>DXGI_COLOR_SPACE_TYPE</c> value that specifies the colorspace for the video processor output surface.</summary>
		public DXGI_COLOR_SPACE_TYPE ColorSpace;

		/// <summary>
		/// A value from the <c>D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE</c> enumeration specifying the alpha fill mode for data that the video
		/// processor writes to the render target.
		/// </summary>
		public D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE AlphaFillMode;

		/// <summary>
		/// The zero-based index of an input stream. This parameter is used if AlphaFillMode is
		/// <c>D3D12_VIDEO_PROCESS_ALPHA_FILL_MODE_SOURCE_STREAM</c>. Otherwise, the parameter is ignored.
		/// </summary>
		public uint AlphaFillModeSourceStreamIndex;

		/// <summary>
		/// <para>
		/// The video processor uses the background color to fill areas of the target rectangle that do not contain a video image. Areas
		/// outside the target rectangle are not affected. The meaning of the values are specified by the ColorSpace parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>BackgroundColor</description>
		/// <description>YCbCrA</description>
		/// <description>RGBA</description>
		/// </listheader>
		/// <item>
		/// <description>BackgroundColor[0]</description>
		/// <description>Y</description>
		/// <description>R</description>
		/// </item>
		/// <item>
		/// <description>BackgroundColor[1]</description>
		/// <description>Cb</description>
		/// <description>G</description>
		/// </item>
		/// <item>
		/// <description>BackgroundColor[2]</description>
		/// <description>Cr</description>
		/// <description>B</description>
		/// </item>
		/// <item>
		/// <description>BackgroundColor[3]</description>
		/// <description>A</description>
		/// <description>A</description>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public float[] BackgroundColor;

		/// <summary>A <c>DXGI_RATIONAL</c> structure specifying the frame rate of the output video stream.</summary>
		public DXGI_RATIONAL FrameRate;

		/// <summary>If TRUE, stereo output is enabled. Otherwise, the video processor produces mono video frames.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool EnableStereo;
	}

	/// <summary>Contains the reference frames needed to perform video processing.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_reference_set typedef struct
	// D3D12_VIDEO_PROCESS_REFERENCE_SET { UINT NumPastFrames; ID3D12Resource **ppPastFrames; UINT *pPastSubresources; UINT NumFutureFrames;
	// ID3D12Resource **ppFutureFrames; UINT *pFutureSubresources; } D3D12_VIDEO_PROCESS_REFERENCE_SET;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_REFERENCE_SET")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_REFERENCE_SET
	{
		/// <summary>The number of past reference frames provided in ppPastFrames.</summary>
		public uint NumPastFrames;

		/// <summary>A pointer to an array of <c>ID3D12Resource</c> surfaces. The number of elements in the array is NumPastFrames.</summary>
		public IntPtr ppPastFrames;

		/// <summary>An array of subresource indices for the list of ppPastFrames textures. NULL indicates subresource 0 for each resource.</summary>
		public ArrayPointer<uint> pPastSubresources;

		/// <summary>The number of future reference frames provided in ppPastFrames.</summary>
		public uint NumFutureFrames;

		/// <summary>A pointer to an array of <c>ID3D12Resource</c> surfaces. The number of elements in the array is NumFutureFrames.</summary>
		public IntPtr ppFutureFrames;

		/// <summary>An array of subresource indices for the list of ppFutureFrames textures. NULL indicates subresource 0 for each resource.</summary>
		public ArrayPointer<uint> pFutureSubresources;
	}

	/// <summary>Specifies transform parameters for video processing. Used by the <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS</c> structure.</summary>
	/// <remarks>For stereo formats, the orientation is applied before the stereo format is applied.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_process_transform typedef struct
	// D3D12_VIDEO_PROCESS_TRANSFORM { D3D12_RECT SourceRectangle; D3D12_RECT DestinationRectangle; D3D12_VIDEO_PROCESS_ORIENTATION
	// Orientation; } D3D12_VIDEO_PROCESS_TRANSFORM;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_PROCESS_TRANSFORM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_PROCESS_TRANSFORM
	{
		/// <summary>
		/// Specifies the source rectangle of the transform. This is the portion of the input surface that is blitted to the destination
		/// surface. The source rectangle is given in pixel coordinates, relative to the input surface.
		/// </summary>
		public D3D12_RECT SourceRectangle;

		/// <summary>
		/// Specifies the destination rectangle of the transform. This is the portion of the output surface that receives the blit for this
		/// stream. The destination rectangle is given in pixel coordinates, relative to the output surface.
		/// </summary>
		public D3D12_RECT DestinationRectangle;

		/// <summary>
		/// The rotation and flip operation to apply to the source. Source and Destination rectangles are specified in post orientation coordinates.
		/// </summary>
		public D3D12_VIDEO_PROCESS_ORIENTATION Orientation;
	}

	/// <summary>Describes the width, height, format, and color space of a picture buffer.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_sample typedef struct D3D12_VIDEO_SAMPLE {
	// UINT Width; UINT Height; D3D12_VIDEO_FORMAT Format; } D3D12_VIDEO_SAMPLE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_SAMPLE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_SAMPLE
	{
		/// <summary>The width of the sample.</summary>
		public uint Width;

		/// <summary>The height of the sample.</summary>
		public uint Height;

		/// <summary>A <c>D3D12_VIDEO_FORMAT</c> structure describing the format and colorspace of the sample.</summary>
		public D3D12_VIDEO_FORMAT Format;
	}

	/// <summary>Describes the supported scaling range of output sizes for a video scaler.</summary>
	/// <remarks>
	/// By default, all possible output size combinations that exist between the maximum size and minimum size for the extent, inclusive,
	/// are supported. ScaleSupportFlags may add additional restrictions to the supported scale sizes. When scaling is not supported, the
	/// minimum and maximum sizes should both be set to the input size and no flags should be specified.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_scale_support typedef struct
	// D3D12_VIDEO_SCALE_SUPPORT { D3D12_VIDEO_SIZE_RANGE OutputSizeRange; D3D12_VIDEO_SCALE_SUPPORT_FLAGS Flags; } D3D12_VIDEO_SCALE_SUPPORT;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_SCALE_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_SCALE_SUPPORT
	{
		/// <summary>A <c>D3D12_VIDEO_SIZE_RANGE</c> structure describing the supported output size range for the scaler.</summary>
		public D3D12_VIDEO_SIZE_RANGE OutputSizeRange;

		/// <summary>
		/// A member of the <c>D3D12_VIDEO_SCALE_SUPPORT_FLAGS</c> enumeration specifying the supported scaling capabilities of the scaler.
		/// </summary>
		public D3D12_VIDEO_SCALE_SUPPORT_FLAGS Flags;
	}

	/// <summary>Describes the range of supported sizes for a video scaler.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/ns-d3d12video-d3d12_video_size_range typedef struct
	// D3D12_VIDEO_SIZE_RANGE { UINT MaxWidth; UINT MaxHeight; UINT MinWidth; UINT MinHeight; } D3D12_VIDEO_SIZE_RANGE;
	[PInvokeData("d3d12video.h", MSDNShortId = "NS:d3d12video.D3D12_VIDEO_SIZE_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIDEO_SIZE_RANGE
	{
		/// <summary>
		/// The largest output width to which content can be scaled. The largest value allowed is
		/// <b>D3D12_REQ_TEXTURE2D_U_OR_V_DIMENSION</b> (16384).
		/// </summary>
		public uint MaxWidth;

		/// <summary>
		/// The largest output height to which content can be scaled. The largest value allowed is
		/// <b>D3D12_REQ_TEXTURE2D_U_OR_V_DIMENSION</b> (16384).
		/// </summary>
		public uint MaxHeight;

		/// <summary>The smallest output width to which content can be scaled. The smallest allowed value is 1.</summary>
		public uint MinWidth;

		/// <summary>The smallest output height to which content can be scaled. The smallest allowed value is 1.</summary>
		public uint MinHeight;
	}
}