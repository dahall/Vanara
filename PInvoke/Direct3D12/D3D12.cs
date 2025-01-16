global using static Vanara.PInvoke.D3DCompiler;
global using static Vanara.PInvoke.DXGI;
global using D3D12_BOX = Vanara.PInvoke.DXGI.D3D10_BOX;
global using D3D12_GPU_VIRTUAL_ADDRESS = System.UInt64;
global using D3D12_RECT = Vanara.PInvoke.RECT;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary/>
	public const uint D3D12_16BIT_INDEX_STRIP_CUT_VALUE = 0xffff;

	/// <summary/>
	public const uint D3D12_32BIT_INDEX_STRIP_CUT_VALUE = 0xffffffff;

	/// <summary/>
	public const uint D3D12_8BIT_INDEX_STRIP_CUT_VALUE = 0xff;

	/// <summary/>
	public const uint D3D12_APPEND_ALIGNED_ELEMENT = 0xffffffff;

	/// <summary/>
	public const int D3D12_ARRAY_AXIS_ADDRESS_RANGE_BIT_COUNT = 9;

	/// <summary/>
	public const int D3D12_CLIP_OR_CULL_DISTANCE_COUNT = 8;

	/// <summary/>
	public const int D3D12_CLIP_OR_CULL_DISTANCE_ELEMENT_COUNT = 2;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT = 14;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_HW_SLOT_COUNT = 15;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_PARTIAL_UPDATE_EXTENTS_BYTE_ALIGNMENT = 16;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_REGISTER_COUNT = 15;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_CONSTANT_BUFFER_REGISTER_READS_PER_INST = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_FLOWCONTROL_NESTING_LIMIT = 64;

	/// <summary/>
	public const int D3D12_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_IMMEDIATE_CONSTANT_BUFFER_REGISTER_READS_PER_INST = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_IMMEDIATE_VALUE_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_COMMONSHADER_INPUT_RESOURCE_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_INPUT_RESOURCE_REGISTER_COUNT = 128;

	/// <summary/>
	public const int D3D12_COMMONSHADER_INPUT_RESOURCE_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_INPUT_RESOURCE_REGISTER_READS_PER_INST = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT = 128;

	/// <summary/>
	public const int D3D12_COMMONSHADER_SAMPLER_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_SAMPLER_REGISTER_COUNT = 16;

	/// <summary/>
	public const int D3D12_COMMONSHADER_SAMPLER_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_SAMPLER_REGISTER_READS_PER_INST = 1;

	/// <summary/>
	public const int D3D12_COMMONSHADER_SAMPLER_SLOT_COUNT = 16;

	/// <summary/>
	public const int D3D12_COMMONSHADER_SUBROUTINE_NESTING_LIMIT = 32;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEMP_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEMP_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEMP_REGISTER_COUNT = 4096;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEMP_REGISTER_READ_PORTS = 3;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEMP_REGISTER_READS_PER_INST = 3;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEXCOORD_RANGE_REDUCTION_MAX = 10;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEXCOORD_RANGE_REDUCTION_MIN = -10;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEXEL_OFFSET_MAX_NEGATIVE = -8;

	/// <summary/>
	public const int D3D12_COMMONSHADER_TEXEL_OFFSET_MAX_POSITIVE = 7;

	/// <summary/>
	public const int D3D12_CONSTANT_BUFFER_DATA_PLACEMENT_ALIGNMENT = 256;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET00_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 256;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET00_MAX_NUM_THREADS_PER_GROUP = 64;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET01_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 240;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET01_MAX_NUM_THREADS_PER_GROUP = 68;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET02_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 224;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET02_MAX_NUM_THREADS_PER_GROUP = 72;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET03_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 208;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET03_MAX_NUM_THREADS_PER_GROUP = 76;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET04_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 192;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET04_MAX_NUM_THREADS_PER_GROUP = 84;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET05_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 176;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET05_MAX_NUM_THREADS_PER_GROUP = 92;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET06_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 160;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET06_MAX_NUM_THREADS_PER_GROUP = 100;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET07_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 144;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET07_MAX_NUM_THREADS_PER_GROUP = 112;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET08_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 128;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET08_MAX_NUM_THREADS_PER_GROUP = 128;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET09_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 112;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET09_MAX_NUM_THREADS_PER_GROUP = 144;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET10_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 96;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET10_MAX_NUM_THREADS_PER_GROUP = 168;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET11_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 80;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET11_MAX_NUM_THREADS_PER_GROUP = 204;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET12_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 64;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET12_MAX_NUM_THREADS_PER_GROUP = 256;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET13_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 48;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET13_MAX_NUM_THREADS_PER_GROUP = 340;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET14_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 32;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET14_MAX_NUM_THREADS_PER_GROUP = 512;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET15_MAX_BYTES_TGSM_WRITABLE_PER_THREAD = 16;

	/// <summary/>
	public const int D3D12_CS_4_X_BUCKET15_MAX_NUM_THREADS_PER_GROUP = 768;

	/// <summary/>
	public const int D3D12_CS_4_X_DISPATCH_MAX_THREAD_GROUPS_IN_Z_DIMENSION = 1;

	/// <summary/>
	public const int D3D12_CS_4_X_RAW_UAV_BYTE_ALIGNMENT = 256;

	/// <summary/>
	public const int D3D12_CS_4_X_THREAD_GROUP_MAX_THREADS_PER_GROUP = 768;

	/// <summary/>
	public const int D3D12_CS_4_X_THREAD_GROUP_MAX_X = 768;

	/// <summary/>
	public const int D3D12_CS_4_X_THREAD_GROUP_MAX_Y = 768;

	/// <summary/>
	public const int D3D12_CS_4_X_UAV_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION = 65535;

	/// <summary/>
	public const int D3D12_CS_TGSM_REGISTER_COUNT = 8192;

	/// <summary/>
	public const int D3D12_CS_TGSM_REGISTER_READS_PER_INST = 1;

	/// <summary/>
	public const int D3D12_CS_TGSM_RESOURCE_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_CS_TGSM_RESOURCE_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_CS_THREAD_GROUP_MAX_THREADS_PER_GROUP = 1024;

	/// <summary/>
	public const int D3D12_CS_THREAD_GROUP_MAX_X = 1024;

	/// <summary/>
	public const int D3D12_CS_THREAD_GROUP_MAX_Y = 1024;

	/// <summary/>
	public const int D3D12_CS_THREAD_GROUP_MAX_Z = 64;

	/// <summary/>
	public const int D3D12_CS_THREAD_GROUP_MIN_X = 1;

	/// <summary/>
	public const int D3D12_CS_THREAD_GROUP_MIN_Y = 1;

	/// <summary/>
	public const int D3D12_CS_THREAD_GROUP_MIN_Z = 1;

	/// <summary/>
	public const int D3D12_CS_THREAD_LOCAL_TEMP_REGISTER_POOL = 16384;

	/// <summary/>
	public const int D3D12_CS_THREADGROUPID_REGISTER_COMPONENTS = 3;

	/// <summary/>
	public const int D3D12_CS_THREADGROUPID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_CS_THREADID_REGISTER_COMPONENTS = 3;

	/// <summary/>
	public const int D3D12_CS_THREADID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_CS_THREADIDINGROUP_REGISTER_COMPONENTS = 3;

	/// <summary/>
	public const int D3D12_CS_THREADIDINGROUP_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_CS_THREADIDINGROUPFLATTENED_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_CS_THREADIDINGROUPFLATTENED_REGISTER_COUNT = 1;

	/// <summary/>
	public const float D3D12_DEFAULT_BLEND_FACTOR_ALPHA = 1.0f;

	/// <summary/>
	public const float D3D12_DEFAULT_BLEND_FACTOR_BLUE = 1.0f;

	/// <summary/>
	public const float D3D12_DEFAULT_BLEND_FACTOR_GREEN = 1.0f;

	/// <summary/>
	public const float D3D12_DEFAULT_BLEND_FACTOR_RED = 1.0f;

	/// <summary/>
	public const float D3D12_DEFAULT_BORDER_COLOR_COMPONENT = 0.0f;

	/// <summary/>
	public const int D3D12_DEFAULT_DEPTH_BIAS = 0;

	/// <summary/>
	public const float D3D12_DEFAULT_DEPTH_BIAS_CLAMP = 0.0f;

	/// <summary/>
	public const int D3D12_DEFAULT_MAX_ANISOTROPY = 16;

	/// <summary/>
	public const float D3D12_DEFAULT_MIP_LOD_BIAS = 0.0f;

	/// <summary/>
	public const int D3D12_DEFAULT_MSAA_RESOURCE_PLACEMENT_ALIGNMENT = 4194304;

	/// <summary/>
	public const int D3D12_DEFAULT_RENDER_TARGET_ARRAY_INDEX = 0;

	/// <summary/>
	public const int D3D12_DEFAULT_RESOURCE_PLACEMENT_ALIGNMENT = 65536;

	/// <summary/>
	public const uint D3D12_DEFAULT_SAMPLE_MASK = 0xffffffff;

	/// <summary/>
	public const int D3D12_DEFAULT_SCISSOR_ENDX = 0;

	/// <summary/>
	public const int D3D12_DEFAULT_SCISSOR_ENDY = 0;

	/// <summary/>
	public const int D3D12_DEFAULT_SCISSOR_STARTX = 0;

	/// <summary/>
	public const int D3D12_DEFAULT_SCISSOR_STARTY = 0;

	/// <summary/>
	public const float D3D12_DEFAULT_SLOPE_SCALED_DEPTH_BIAS = 0.0f;

	/// <summary/>
	public const byte D3D12_DEFAULT_STENCIL_READ_MASK = 0xff;

	/// <summary/>
	public const int D3D12_DEFAULT_STENCIL_REFERENCE = 0;

	/// <summary/>
	public const byte D3D12_DEFAULT_STENCIL_WRITE_MASK = 0xff;

	/// <summary/>
	public const int D3D12_DEFAULT_VIEWPORT_AND_SCISSORRECT_INDEX = 0;

	/// <summary/>
	public const int D3D12_DEFAULT_VIEWPORT_HEIGHT = 0;

	/// <summary/>
	public const float D3D12_DEFAULT_VIEWPORT_MAX_DEPTH = 0.0f;

	/// <summary/>
	public const float D3D12_DEFAULT_VIEWPORT_MIN_DEPTH = 0.0f;

	/// <summary/>
	public const int D3D12_DEFAULT_VIEWPORT_TOPLEFTX = 0;

	/// <summary/>
	public const int D3D12_DEFAULT_VIEWPORT_TOPLEFTY = 0;

	/// <summary/>
	public const int D3D12_DEFAULT_VIEWPORT_WIDTH = 0;

	/// <summary/>
	public const uint D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND = 0xffffffff;

	/// <summary/>
	public const uint D3D12_DRIVER_RESERVED_REGISTER_SPACE_VALUES_END = 0xfffffff7;

	/// <summary/>
	public const uint D3D12_DRIVER_RESERVED_REGISTER_SPACE_VALUES_START = 0xfffffff0;

	/// <summary/>
	public const int D3D12_DS_INPUT_CONTROL_POINT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_DS_INPUT_CONTROL_POINT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_DS_INPUT_CONTROL_POINT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_DS_INPUT_CONTROL_POINT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_DS_INPUT_CONTROL_POINT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_DS_INPUT_CONTROL_POINTS_MAX_TOTAL_SCALARS = 3968;

	/// <summary/>
	public const int D3D12_DS_INPUT_DOMAIN_POINT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_DS_INPUT_DOMAIN_POINT_REGISTER_COMPONENTS = 3;

	/// <summary/>
	public const int D3D12_DS_INPUT_DOMAIN_POINT_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_DS_INPUT_DOMAIN_POINT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_DS_INPUT_DOMAIN_POINT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_DS_INPUT_PATCH_CONSTANT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_DS_INPUT_PATCH_CONSTANT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_DS_INPUT_PATCH_CONSTANT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_DS_INPUT_PATCH_CONSTANT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_DS_INPUT_PATCH_CONSTANT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_DS_INPUT_PRIMITIVE_ID_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_DS_INPUT_PRIMITIVE_ID_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_DS_INPUT_PRIMITIVE_ID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_DS_INPUT_PRIMITIVE_ID_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_DS_INPUT_PRIMITIVE_ID_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_DS_OUTPUT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_DS_OUTPUT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_DS_OUTPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const float D3D12_FLOAT_TO_SRGB_EXPONENT_DENOMINATOR = 2.4f;

	/// <summary/>
	public const float D3D12_FLOAT_TO_SRGB_EXPONENT_NUMERATOR = 1.0f;

	/// <summary/>
	public const float D3D12_FLOAT_TO_SRGB_OFFSET = 0.055f;

	/// <summary/>
	public const float D3D12_FLOAT_TO_SRGB_SCALE_1 = 12.92f;

	/// <summary/>
	public const float D3D12_FLOAT_TO_SRGB_SCALE_2 = 1.055f;

	/// <summary/>
	public const float D3D12_FLOAT_TO_SRGB_THRESHOLD = 0.0031308f;

	/// <summary/>
	public const float D3D12_FLOAT16_FUSED_TOLERANCE_IN_ULP = 0.6f;

	/// <summary/>
	public const float D3D12_FLOAT32_MAX = 3.402823466e+38f;

	/// <summary/>
	public const float D3D12_FLOAT32_TO_INTEGER_TOLERANCE_IN_ULP = 0.6f;

	/// <summary/>
	public const float D3D12_FTOI_INSTRUCTION_MAX_INPUT = 2147483647.999f;

	/// <summary/>
	public const float D3D12_FTOI_INSTRUCTION_MIN_INPUT = -2147483648.999f;

	/// <summary/>
	public const float D3D12_FTOU_INSTRUCTION_MAX_INPUT = 4294967295.999f;

	/// <summary/>
	public const float D3D12_FTOU_INSTRUCTION_MIN_INPUT = 0.0f;

	/// <summary/>
	public const int D3D12_GS_INPUT_INSTANCE_ID_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_GS_INPUT_INSTANCE_ID_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_GS_INPUT_INSTANCE_ID_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_GS_INPUT_INSTANCE_ID_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_GS_INPUT_INSTANCE_ID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_GS_INPUT_PRIM_CONST_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_GS_INPUT_PRIM_CONST_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_GS_INPUT_PRIM_CONST_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_GS_INPUT_PRIM_CONST_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_GS_INPUT_PRIM_CONST_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_GS_INPUT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_GS_INPUT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_GS_INPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_GS_INPUT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_GS_INPUT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_GS_INPUT_REGISTER_VERTICES = 32;

	/// <summary/>
	public const int D3D12_GS_MAX_INSTANCE_COUNT = 32;

	/// <summary/>
	public const int D3D12_GS_MAX_OUTPUT_VERTEX_COUNT_ACROSS_INSTANCES = 1024;

	/// <summary/>
	public const int D3D12_GS_OUTPUT_ELEMENTS = 32;

	/// <summary/>
	public const int D3D12_GS_OUTPUT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_GS_OUTPUT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_GS_OUTPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_CONTROL_POINT_PHASE_INPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_CONTROL_POINT_PHASE_OUTPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_CONTROL_POINT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_CONTROL_POINT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_HS_CONTROL_POINT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_HS_CONTROL_POINT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const uint D3D12_HS_FORK_PHASE_INSTANCE_COUNT_UPPER_BOUND = 0xffffffff;

	/// <summary/>
	public const int D3D12_HS_INPUT_FORK_INSTANCE_ID_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_INPUT_FORK_INSTANCE_ID_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_FORK_INSTANCE_ID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_FORK_INSTANCE_ID_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_FORK_INSTANCE_ID_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_HS_INPUT_JOIN_INSTANCE_ID_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_INPUT_JOIN_INSTANCE_ID_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_JOIN_INSTANCE_ID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_JOIN_INSTANCE_ID_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_JOIN_INSTANCE_ID_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_HS_INPUT_PRIMITIVE_ID_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_INPUT_PRIMITIVE_ID_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_PRIMITIVE_ID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_PRIMITIVE_ID_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_HS_INPUT_PRIMITIVE_ID_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const uint D3D12_HS_JOIN_PHASE_INSTANCE_COUNT_UPPER_BOUND = 0xffffffff;

	/// <summary/>
	public const float D3D12_HS_MAXTESSFACTOR_LOWER_BOUND = 1.0f;

	/// <summary/>
	public const float D3D12_HS_MAXTESSFACTOR_UPPER_BOUND = 64.0f;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_CONTROL_POINT_ID_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_CONTROL_POINT_ID_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_CONTROL_POINT_ID_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_CONTROL_POINT_ID_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_CONTROL_POINT_ID_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_CONTROL_POINTS_MAX_TOTAL_SCALARS = 3968;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_PATCH_CONSTANT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_PATCH_CONSTANT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_PATCH_CONSTANT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_PATCH_CONSTANT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_PATCH_CONSTANT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_HS_OUTPUT_PATCH_CONSTANT_REGISTER_SCALAR_COMPONENTS = 128;

	/// <summary/>
	public const int D3D12_IA_DEFAULT_INDEX_BUFFER_OFFSET_IN_BYTES = 0;

	/// <summary/>
	public const int D3D12_IA_DEFAULT_PRIMITIVE_TOPOLOGY = 0;

	/// <summary/>
	public const int D3D12_IA_DEFAULT_VERTEX_BUFFER_OFFSET_IN_BYTES = 0;

	/// <summary/>
	public const int D3D12_IA_INDEX_INPUT_RESOURCE_SLOT_COUNT = 1;

	/// <summary/>
	public const int D3D12_IA_INSTANCE_ID_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_IA_INTEGER_ARITHMETIC_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_IA_PATCH_MAX_CONTROL_POINT_COUNT = 32;

	/// <summary/>
	public const int D3D12_IA_PRIMITIVE_ID_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_IA_VERTEX_ID_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT = 32;

	/// <summary/>
	public const int D3D12_IA_VERTEX_INPUT_STRUCTURE_ELEMENT_COUNT = 32;

	/// <summary/>
	public const int D3D12_IA_VERTEX_INPUT_STRUCTURE_ELEMENTS_COMPONENTS = 128;

	/// <summary/>
	public const uint D3D12_INTEGER_DIVIDE_BY_ZERO_QUOTIENT = 0xffffffff;

	/// <summary/>
	public const uint D3D12_INTEGER_DIVIDE_BY_ZERO_REMAINDER = 0xffffffff;

	/// <summary/>
	public const uint D3D12_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL = 0xffffffff;

	/// <summary/>
	public const uint D3D12_KEEP_UNORDERED_ACCESS_VIEWS = 0xffffffff;

	/// <summary/>
	public const float D3D12_LINEAR_GAMMA = 1.0f;

	/// <summary/>
	public const int D3D12_MAJOR_VERSION = 12;

	/// <summary/>
	public const float D3D12_MAX_BORDER_COLOR_COMPONENT = 1.0f;

	/// <summary/>
	public const float D3D12_MAX_DEPTH = 1.0f;

	/// <summary/>
	public const int D3D12_MAX_LIVE_STATIC_SAMPLERS = 2032;

	/// <summary/>
	public const int D3D12_MAX_MAXANISOTROPY = 16;

	/// <summary/>
	public const int D3D12_MAX_MULTISAMPLE_SAMPLE_COUNT = 32;

	/// <summary/>
	public const float D3D12_MAX_POSITION_VALUE = 3.402823466e+34f;

	/// <summary/>
	public const int D3D12_MAX_ROOT_COST = 64;

	/// <summary/>
	public const int D3D12_MAX_SHADER_VISIBLE_DESCRIPTOR_HEAP_SIZE_TIER_1 = 1000000;

	/// <summary/>
	public const int D3D12_MAX_SHADER_VISIBLE_DESCRIPTOR_HEAP_SIZE_TIER_2 = 1000000;

	/// <summary/>
	public const int D3D12_MAX_SHADER_VISIBLE_SAMPLER_HEAP_SIZE = 2048;

	/// <summary/>
	public const int D3D12_MAX_TEXTURE_DIMENSION_2_TO_EXP = 17;

	/// <summary/>
	public const int D3D12_MAX_VIEW_INSTANCE_COUNT = 4;

	/// <summary/>
	public const float D3D12_MIN_BORDER_COLOR_COMPONENT = 0.0f;

	/// <summary/>
	public const float D3D12_MIN_DEPTH = 0.0f;

	/// <summary/>
	public const int D3D12_MIN_MAXANISOTROPY = 0;

	/// <summary/>
	public const int D3D12_MINOR_VERSION = 0;

	/// <summary/>
	public const float D3D12_MIP_LOD_BIAS_MAX = 15.99f;

	/// <summary/>
	public const float D3D12_MIP_LOD_BIAS_MIN = -16.0f;

	/// <summary/>
	public const int D3D12_MIP_LOD_FRACTIONAL_BIT_COUNT = 8;

	/// <summary/>
	public const int D3D12_MIP_LOD_RANGE_BIT_COUNT = 8;

	/// <summary/>
	public const float D3D12_MULTISAMPLE_ANTIALIAS_LINE_WIDTH = 1.4f;

	/// <summary/>
	public const int D3D12_NONSAMPLE_FETCH_OUT_OF_RANGE_ACCESS_RESULT = 0;

	/// <summary/>
	public const uint D3D12_OS_RESERVED_REGISTER_SPACE_VALUES_END = 0xffffffff;

	/// <summary/>
	public const uint D3D12_OS_RESERVED_REGISTER_SPACE_VALUES_START = 0xfffffff8;

	/// <summary/>
	public const uint D3D12_PACKED_TILE = 0xffffffff;

	/// <summary/>
	public const int D3D12_PIXEL_ADDRESS_RANGE_BIT_COUNT = 15;

	/// <summary/>
	public const int D3D12_PRE_SCISSOR_PIXEL_ADDRESS_RANGE_BIT_COUNT = 16;

	/// <summary/>
	public const int D3D12_PREVIEW_SDK_VERSION = 713;

	/// <summary/>
	public const int D3D12_PS_CS_UAV_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_PS_CS_UAV_REGISTER_COUNT = 8;

	/// <summary/>
	public const int D3D12_PS_CS_UAV_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_PS_CS_UAV_REGISTER_READS_PER_INST = 1;

	/// <summary/>
	public const uint D3D12_PS_FRONTFACING_DEFAULT_VALUE = 0xffffffff;

	/// <summary/>
	public const int D3D12_PS_FRONTFACING_FALSE_VALUE = 0;

	/// <summary/>
	public const uint D3D12_PS_FRONTFACING_TRUE_VALUE = 0xffffffff;

	/// <summary/>
	public const int D3D12_PS_INPUT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_PS_INPUT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_PS_INPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_PS_INPUT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_PS_INPUT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const float D3D12_PS_LEGACY_PIXEL_CENTER_FRACTIONAL_COMPONENT = 0.0f;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_DEPTH_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_DEPTH_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_DEPTH_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_MASK_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_MASK_REGISTER_COMPONENTS = 1;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_MASK_REGISTER_COUNT = 1;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_PS_OUTPUT_REGISTER_COUNT = 8;

	/// <summary/>
	public const float D3D12_PS_PIXEL_CENTER_FRACTIONAL_COMPONENT = 0.5f;

	/// <summary/>
	public const int D3D12_RAW_UAV_SRV_BYTE_ALIGNMENT = 16;

	/// <summary/>
	public const int D3D12_RAYTRACING_AABB_BYTE_ALIGNMENT = 8;

	/// <summary/>
	public const int D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BYTE_ALIGNMENT = 256;

	/// <summary/>
	public const int D3D12_RAYTRACING_INSTANCE_DESCS_BYTE_ALIGNMENT = 16;

	/// <summary/>
	public const int D3D12_RAYTRACING_MAX_ATTRIBUTE_SIZE_IN_BYTES = 32;

	/// <summary/>
	public const int D3D12_RAYTRACING_MAX_DECLARABLE_TRACE_RECURSION_DEPTH = 31;

	/// <summary/>
	public const int D3D12_RAYTRACING_MAX_GEOMETRIES_PER_BOTTOM_LEVEL_ACCELERATION_STRUCTURE = 16777216;

	/// <summary/>
	public const int D3D12_RAYTRACING_MAX_INSTANCES_PER_TOP_LEVEL_ACCELERATION_STRUCTURE = 16777216;

	/// <summary/>
	public const int D3D12_RAYTRACING_MAX_PRIMITIVES_PER_BOTTOM_LEVEL_ACCELERATION_STRUCTURE = 536870912;

	/// <summary/>
	public const int D3D12_RAYTRACING_MAX_RAY_GENERATION_SHADER_THREADS = 1073741824;

	/// <summary/>
	public const int D3D12_RAYTRACING_MAX_SHADER_RECORD_STRIDE = 4096;

	/// <summary/>
	public const int D3D12_RAYTRACING_SHADER_RECORD_BYTE_ALIGNMENT = 32;

	/// <summary/>
	public const int D3D12_RAYTRACING_SHADER_TABLE_BYTE_ALIGNMENT = 64;

	/// <summary/>
	public const int D3D12_RAYTRACING_TRANSFORM3X4_BYTE_ALIGNMENT = 16;

	/// <summary/>
	public const int D3D12_REQ_BLEND_OBJECT_COUNT_PER_DEVICE = 4096;

	/// <summary/>
	public const int D3D12_REQ_BUFFER_RESOURCE_TEXEL_COUNT_2_TO_EXP = 27;

	/// <summary/>
	public const int D3D12_REQ_CONSTANT_BUFFER_ELEMENT_COUNT = 4096;

	/// <summary/>
	public const int D3D12_REQ_DEPTH_STENCIL_OBJECT_COUNT_PER_DEVICE = 4096;

	/// <summary/>
	public const int D3D12_REQ_DRAW_VERTEX_COUNT_2_TO_EXP = 32;

	/// <summary/>
	public const int D3D12_REQ_DRAWINDEXED_INDEX_COUNT_2_TO_EXP = 32;

	/// <summary/>
	public const int D3D12_REQ_FILTERING_HW_ADDRESSABLE_RESOURCE_DIMENSION = 16384;

	/// <summary/>
	public const int D3D12_REQ_GS_INVOCATION_32BIT_OUTPUT_COMPONENT_LIMIT = 1024;

	/// <summary/>
	public const int D3D12_REQ_IMMEDIATE_CONSTANT_BUFFER_ELEMENT_COUNT = 4096;

	/// <summary/>
	public const int D3D12_REQ_MAXANISOTROPY = 16;

	/// <summary/>
	public const int D3D12_REQ_MIP_LEVELS = 15;

	/// <summary/>
	public const int D3D12_REQ_MULTI_ELEMENT_STRUCTURE_SIZE_IN_BYTES = 2048;

	/// <summary/>
	public const int D3D12_REQ_RASTERIZER_OBJECT_COUNT_PER_DEVICE = 4096;

	/// <summary/>
	public const int D3D12_REQ_RENDER_TO_BUFFER_WINDOW_WIDTH = 16384;

	/// <summary/>
	public const int D3D12_REQ_RESOURCE_SIZE_IN_MEGABYTES_EXPRESSION_A_TERM = 128;

	/// <summary/>
	public const float D3D12_REQ_RESOURCE_SIZE_IN_MEGABYTES_EXPRESSION_B_TERM = 0.25f;

	/// <summary/>
	public const int D3D12_REQ_RESOURCE_SIZE_IN_MEGABYTES_EXPRESSION_C_TERM = 2048;

	/// <summary/>
	public const int D3D12_REQ_RESOURCE_VIEW_COUNT_PER_DEVICE_2_TO_EXP = 20;

	/// <summary/>
	public const int D3D12_REQ_SAMPLER_OBJECT_COUNT_PER_DEVICE = 4096;

	/// <summary/>
	public const int D3D12_REQ_SUBRESOURCES = 30720;

	/// <summary/>
	public const int D3D12_REQ_TEXTURE1D_ARRAY_AXIS_DIMENSION = 2048;

	/// <summary/>
	public const int D3D12_REQ_TEXTURE1D_U_DIMENSION = 16384;

	/// <summary/>
	public const int D3D12_REQ_TEXTURE2D_ARRAY_AXIS_DIMENSION = 2048;

	/// <summary/>
	public const int D3D12_REQ_TEXTURE2D_U_OR_V_DIMENSION = 16384;

	/// <summary/>
	public const int D3D12_REQ_TEXTURE3D_U_V_OR_W_DIMENSION = 2048;

	/// <summary/>
	public const int D3D12_REQ_TEXTURECUBE_DIMENSION = 16384;

	/// <summary/>
	public const int D3D12_RESINFO_INSTRUCTION_MISSING_COMPONENT_RETVAL = 0;

	/// <summary/>
	public const uint D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES = 0xffffffff;

	/// <summary/>
	public const int D3D12_RS_SET_SHADING_RATE_COMBINER_COUNT = 2;

	/// <summary/>
	public const int D3D12_SDK_VERSION = 612;

	/// <summary/>
	public const int D3D12_SHADER_IDENTIFIER_SIZE_IN_BYTES = 32;

	/// <summary/>
	public const int D3D12_SHADER_MAJOR_VERSION = 5;

	/// <summary/>
	public const int D3D12_SHADER_MAX_INSTANCES = 65535;

	/// <summary/>
	public const int D3D12_SHADER_MAX_INTERFACE_CALL_SITES = 4096;

	/// <summary/>
	public const int D3D12_SHADER_MAX_INTERFACES = 253;

	/// <summary/>
	public const int D3D12_SHADER_MAX_TYPES = 65535;

	/// <summary/>
	public const int D3D12_SHADER_MINOR_VERSION = 1;

	/// <summary/>
	public const int D3D12_SHIFT_INSTRUCTION_PAD_VALUE = 0;

	/// <summary/>
	public const int D3D12_SHIFT_INSTRUCTION_SHIFT_VALUE_BIT_COUNT = 5;

	/// <summary/>
	public const int D3D12_SIMULTANEOUS_RENDER_TARGET_COUNT = 8;

	/// <summary/>
	public const int D3D12_SMALL_MSAA_RESOURCE_PLACEMENT_ALIGNMENT = 65536;

	/// <summary/>
	public const int D3D12_SMALL_RESOURCE_PLACEMENT_ALIGNMENT = 4096;

	/// <summary/>
	public const int D3D12_SO_BUFFER_MAX_STRIDE_IN_BYTES = 2048;

	/// <summary/>
	public const int D3D12_SO_BUFFER_MAX_WRITE_WINDOW_IN_BYTES = 512;

	/// <summary/>
	public const int D3D12_SO_BUFFER_SLOT_COUNT = 4;

	/// <summary/>
	public const uint D3D12_SO_DDI_REGISTER_INDEX_DENOTING_GAP = 0xffffffff;

	/// <summary/>
	public const uint D3D12_SO_NO_RASTERIZED_STREAM = 0xffffffff;

	/// <summary/>
	public const int D3D12_SO_OUTPUT_COMPONENT_COUNT = 128;

	/// <summary/>
	public const int D3D12_SO_STREAM_COUNT = 4;

	/// <summary/>
	public const int D3D12_SPEC_DATE_DAY = 14;

	/// <summary/>
	public const int D3D12_SPEC_DATE_MONTH = 11;

	/// <summary/>
	public const int D3D12_SPEC_DATE_YEAR = 2014;

	/// <summary/>
	public const float D3D12_SPEC_VERSION = 1.16f;

	/// <summary/>
	public const float D3D12_SRGB_GAMMA = 2.2f;

	/// <summary/>
	public const float D3D12_SRGB_TO_FLOAT_DENOMINATOR_1 = 12.92f;

	/// <summary/>
	public const float D3D12_SRGB_TO_FLOAT_DENOMINATOR_2 = 1.055f;

	/// <summary/>
	public const float D3D12_SRGB_TO_FLOAT_EXPONENT = 2.4f;

	/// <summary/>
	public const float D3D12_SRGB_TO_FLOAT_OFFSET = 0.055f;

	/// <summary/>
	public const float D3D12_SRGB_TO_FLOAT_THRESHOLD = 0.04045f;

	/// <summary/>
	public const float D3D12_SRGB_TO_FLOAT_TOLERANCE_IN_ULP = 0.5f;

	/// <summary/>
	public const int D3D12_STANDARD_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_STANDARD_COMPONENT_BIT_COUNT_DOUBLED = 64;

	/// <summary/>
	public const int D3D12_STANDARD_MAXIMUM_ELEMENT_ALIGNMENT_BYTE_MULTIPLE = 4;

	/// <summary/>
	public const int D3D12_STANDARD_PIXEL_COMPONENT_COUNT = 128;

	/// <summary/>
	public const int D3D12_STANDARD_PIXEL_ELEMENT_COUNT = 32;

	/// <summary/>
	public const int D3D12_STANDARD_VECTOR_SIZE = 4;

	/// <summary/>
	public const int D3D12_STANDARD_VERTEX_ELEMENT_COUNT = 32;

	/// <summary/>
	public const int D3D12_STANDARD_VERTEX_TOTAL_COMPONENT_COUNT = 64;

	/// <summary/>
	public const int D3D12_SUBPIXEL_FRACTIONAL_BIT_COUNT = 8;

	/// <summary/>
	public const int D3D12_SUBTEXEL_FRACTIONAL_BIT_COUNT = 8;

	/// <summary/>
	public const uint D3D12_SYSTEM_RESERVED_REGISTER_SPACE_VALUES_END = 0xffffffff;

	/// <summary/>
	public const uint D3D12_SYSTEM_RESERVED_REGISTER_SPACE_VALUES_START = 0xfffffff0;

	/// <summary/>
	public const int D3D12_TESSELLATOR_MAX_EVEN_TESSELLATION_FACTOR = 64;

	/// <summary/>
	public const int D3D12_TESSELLATOR_MAX_ISOLINE_DENSITY_TESSELLATION_FACTOR = 64;

	/// <summary/>
	public const int D3D12_TESSELLATOR_MAX_ODD_TESSELLATION_FACTOR = 63;

	/// <summary/>
	public const int D3D12_TESSELLATOR_MAX_TESSELLATION_FACTOR = 64;

	/// <summary/>
	public const int D3D12_TESSELLATOR_MIN_EVEN_TESSELLATION_FACTOR = 2;

	/// <summary/>
	public const int D3D12_TESSELLATOR_MIN_ISOLINE_DENSITY_TESSELLATION_FACTOR = 1;

	/// <summary/>
	public const int D3D12_TESSELLATOR_MIN_ODD_TESSELLATION_FACTOR = 1;

	/// <summary/>
	public const int D3D12_TEXEL_ADDRESS_RANGE_BIT_COUNT = 16;

	/// <summary/>
	public const int D3D12_TEXTURE_DATA_PITCH_ALIGNMENT = 256;

	/// <summary/>
	public const int D3D12_TEXTURE_DATA_PLACEMENT_ALIGNMENT = 512;

	/// <summary/>
	public const int D3D12_TILED_RESOURCE_TILE_SIZE_IN_BYTES = 65536;

	/// <summary/>
	public const int D3D12_TRACKED_WORKLOAD_MAX_INSTANCES = 32;

	/// <summary/>
	public const int D3D12_UAV_COUNTER_PLACEMENT_ALIGNMENT = 4096;

	/// <summary/>
	public const int D3D12_UAV_SLOT_COUNT = 64;

	/// <summary/>
	public const int D3D12_UNBOUND_MEMORY_ACCESS_RESULT = 0;

	/// <summary/>
	public const int D3D12_VIDEO_DECODE_MAX_ARGUMENTS = 10;

	/// <summary/>
	public const int D3D12_VIDEO_DECODE_MAX_HISTOGRAM_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_VIDEO_DECODE_MIN_BITSTREAM_OFFSET_ALIGNMENT = 256;

	/// <summary/>
	public const int D3D12_VIDEO_DECODE_MIN_HISTOGRAM_OFFSET_ALIGNMENT = 256;

	/// <summary/>
	public const uint D3D12_VIDEO_DECODE_STATUS_MACROBLOCKS_AFFECTED_UNKNOWN = 0xffffffff;

	/// <summary/>
	public const uint D3D12_VIDEO_ENCODER_AV1_INVALID_DPB_RESOURCE_INDEX = 0xff;

	/// <summary/>
	public const int D3D12_VIDEO_ENCODER_AV1_MAX_TILE_COLS = 64;

	/// <summary/>
	public const int D3D12_VIDEO_ENCODER_AV1_MAX_TILE_ROWS = 64;

	/// <summary/>
	public const int D3D12_VIDEO_ENCODER_AV1_SUPERRES_DENOM_MIN = 9;

	/// <summary/>
	public const int D3D12_VIDEO_ENCODER_AV1_SUPERRES_NUM = 8;

	/// <summary/>
	public const int D3D12_VIDEO_PROCESS_MAX_FILTERS = 32;

	/// <summary/>
	public const int D3D12_VIDEO_PROCESS_STEREO_VIEWS = 2;

	/// <summary/>
	public const int D3D12_VIEWPORT_AND_SCISSORRECT_MAX_INDEX = 15;

	/// <summary/>
	public const int D3D12_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE = 16;

	/// <summary/>
	public const int D3D12_VIEWPORT_BOUNDS_MAX = 32767;

	/// <summary/>
	public const int D3D12_VIEWPORT_BOUNDS_MIN = -32768;

	/// <summary/>
	public const int D3D12_VS_INPUT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_VS_INPUT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_VS_INPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_VS_INPUT_REGISTER_READ_PORTS = 1;

	/// <summary/>
	public const int D3D12_VS_INPUT_REGISTER_READS_PER_INST = 2;

	/// <summary/>
	public const int D3D12_VS_OUTPUT_REGISTER_COMPONENT_BIT_COUNT = 32;

	/// <summary/>
	public const int D3D12_VS_OUTPUT_REGISTER_COMPONENTS = 4;

	/// <summary/>
	public const int D3D12_VS_OUTPUT_REGISTER_COUNT = 32;

	/// <summary/>
	public const int D3D12_WHQL_CONTEXT_COUNT_FOR_RESOURCE_LIMIT = 10;

	/// <summary/>
	public const int D3D12_WHQL_DRAW_VERTEX_COUNT_2_TO_EXP = 25;

	/// <summary/>
	public const int D3D12_WHQL_DRAWINDEXED_INDEX_COUNT_2_TO_EXP = 25;

	/// <summary/>
	public const int D3D12_WORK_GRAPHS_MAX_NODE_DEPTH = 32;

	private const int D3D12_ANISOTROPIC_FILTERING_BIT = 0x40;
	private const int D3D12_FILTER_REDUCTION_TYPE_MASK = 0x3;
	private const int D3D12_FILTER_REDUCTION_TYPE_SHIFT = 7;
	private const int D3D12_FILTER_TYPE_MASK = 0x3;
	private const int D3D12_MAG_FILTER_SHIFT = 2;
	private const int D3D12_MIN_FILTER_SHIFT = 4;
	private const int D3D12_MIP_FILTER_SHIFT = 0;
	private const int D3D12_SHADER_COMPONENT_MAPPING_ALWAYS_SET_BIT_AVOIDING_ZEROMEM_MISTAKES = 1 << (D3D12_SHADER_COMPONENT_MAPPING_SHIFT * 4);
	private const int D3D12_SHADER_COMPONENT_MAPPING_MASK = 0x7;
	private const int D3D12_SHADER_COMPONENT_MAPPING_SHIFT = 3;
	private const int D3D12_SHADING_RATE_VALID_MASK = 3;
	private const int D3D12_SHADING_RATE_X_AXIS_SHIFT = 2;
	private const string Lib_D3D12 = "d3d12.dll";

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_FILTER_REDUCTION_TYPE D3D12_DECODE_FILTER_REDUCTION(D3D12_FILTER D3D12Filter) =>
		(D3D12_FILTER_REDUCTION_TYPE)(((uint)D3D12Filter >> unchecked(D3D12_FILTER_REDUCTION_TYPE_SHIFT)) & D3D12_FILTER_REDUCTION_TYPE_MASK);

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static bool D3D12_DECODE_IS_ANISOTROPIC_FILTER(D3D12_FILTER D3D12Filter) => ((uint)D3D12Filter & D3D12_ANISOTROPIC_FILTERING_BIT) != 0
			&& D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MIN_FILTER(D3D12Filter)
			&& D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MAG_FILTER(D3D12Filter)
			&& D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MIP_FILTER(D3D12Filter);

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static bool D3D12_DECODE_IS_COMPARISON_FILTER(D3D12_FILTER D3D12Filter) =>
		D3D12_DECODE_FILTER_REDUCTION(D3D12Filter) == D3D12_FILTER_REDUCTION_TYPE.D3D12_FILTER_REDUCTION_TYPE_COMPARISON;

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_FILTER_TYPE D3D12_DECODE_MAG_FILTER(D3D12_FILTER D3D12Filter) =>
		(D3D12_FILTER_TYPE)(((uint)D3D12Filter >> unchecked(D3D12_MAG_FILTER_SHIFT)) & D3D12_FILTER_TYPE_MASK);

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_FILTER_TYPE D3D12_DECODE_MIN_FILTER(D3D12_FILTER D3D12Filter) =>
		(D3D12_FILTER_TYPE)(((uint)D3D12Filter >> unchecked(D3D12_MIN_FILTER_SHIFT)) & D3D12_FILTER_TYPE_MASK);

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_FILTER_TYPE D3D12_DECODE_MIP_FILTER(D3D12_FILTER D3D12Filter) =>
		(D3D12_FILTER_TYPE)(((uint)D3D12Filter >> unchecked(D3D12_MIP_FILTER_SHIFT)) & D3D12_FILTER_TYPE_MASK);

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_SHADER_COMPONENT_MAPPING D3D12_DECODE_SHADER_4_COMPONENT_MAPPING(int ComponentToExtract, uint Mapping) =>
		(D3D12_SHADER_COMPONENT_MAPPING)((Mapping >> (unchecked(D3D12_SHADER_COMPONENT_MAPPING_SHIFT) * ComponentToExtract)) & D3D12_SHADER_COMPONENT_MAPPING_MASK);

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_FILTER D3D12_ENCODE_ANISOTROPIC_FILTER(D3D12_FILTER_REDUCTION_TYPE reduction) =>
		(D3D12_FILTER)(D3D12_ANISOTROPIC_FILTERING_BIT | (uint)D3D12_ENCODE_BASIC_FILTER(D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR,
			D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR, D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR, reduction));

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_FILTER D3D12_ENCODE_BASIC_FILTER(D3D12_FILTER_TYPE min, D3D12_FILTER_TYPE mag, D3D12_FILTER_TYPE mip,
		D3D12_FILTER_REDUCTION_TYPE reduction) => (D3D12_FILTER)((((uint)min & D3D12_FILTER_TYPE_MASK) << unchecked(D3D12_MIN_FILTER_SHIFT))
							| (((uint)mag & D3D12_FILTER_TYPE_MASK) << unchecked(D3D12_MAG_FILTER_SHIFT))
							| (((uint)mip & D3D12_FILTER_TYPE_MASK) << unchecked(D3D12_MIP_FILTER_SHIFT))
							| (((uint)reduction & D3D12_FILTER_REDUCTION_TYPE_MASK) << unchecked(D3D12_FILTER_REDUCTION_TYPE_SHIFT)));

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static D3D12_FILTER D3D12_ENCODE_MIN_MAG_ANISOTROPIC_MIP_POINT_FILTER(D3D12_FILTER_REDUCTION_TYPE reduction) =>
		(D3D12_FILTER)D3D12_ANISOTROPIC_FILTERING_BIT | D3D12_ENCODE_BASIC_FILTER(D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR,
			D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_LINEAR, D3D12_FILTER_TYPE.D3D12_FILTER_TYPE_POINT, reduction);

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static uint D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING(D3D12_SHADER_COMPONENT_MAPPING Src0, D3D12_SHADER_COMPONENT_MAPPING Src1,
		D3D12_SHADER_COMPONENT_MAPPING Src2, D3D12_SHADER_COMPONENT_MAPPING Src3) => ((uint)Src0 & D3D12_SHADER_COMPONENT_MAPPING_MASK)
			| (((uint)Src1 & D3D12_SHADER_COMPONENT_MAPPING_MASK) << unchecked(D3D12_SHADER_COMPONENT_MAPPING_SHIFT))
			| (((uint)Src2 & D3D12_SHADER_COMPONENT_MAPPING_MASK) << (unchecked(D3D12_SHADER_COMPONENT_MAPPING_SHIFT) * 2))
			| (((uint)Src3 & D3D12_SHADER_COMPONENT_MAPPING_MASK) << (unchecked(D3D12_SHADER_COMPONENT_MAPPING_SHIFT) * 3))
			| D3D12_SHADER_COMPONENT_MAPPING_ALWAYS_SET_BIT_AVOIDING_ZEROMEM_MISTAKES;

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static uint D3D12_GET_COARSE_SHADING_RATE_X_AXIS(uint x) => (x >> unchecked(D3D12_SHADING_RATE_X_AXIS_SHIFT)) & D3D12_SHADING_RATE_VALID_MASK;

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static uint D3D12_GET_COARSE_SHADING_RATE_Y_AXIS(uint y) => y & D3D12_SHADING_RATE_VALID_MASK;

	/// <summary/>
	[PInvokeData("d3d12.h")]
	public static uint D3D12_MAKE_COARSE_SHADING_RATE(uint x, uint y) => (x << unchecked(D3D12_SHADING_RATE_X_AXIS_SHIFT)) | y;

	/// <summary>Creates a device that represents the display adapter.</summary>
	/// <param name="pAdapter">
	/// <para>Type: <b>IUnknown*</b></para>
	/// <para>
	/// A pointer to the video adapter to use when creating a <c>device</c>. Pass <b>NULL</b> to use the default adapter, which is the first
	/// adapter that is enumerated by <c>IDXGIFactory1::EnumAdapters</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  Don't mix the use of DXGI 1.0 ( <c>IDXGIFactory</c>) and DXGI 1.1 ( <c>IDXGIFactory1</c>) in an application. Use
	/// <b>IDXGIFactory</b> or <b>IDXGIFactory1</b>, but not both in an application.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="MinimumFeatureLevel">
	/// <para>Type: <b><c>D3D_FEATURE_LEVEL</c></b></para>
	/// <para>The minimum <c>D3D_FEATURE_LEVEL</c> required for successful device creation.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <b><b>REFIID</b></b></para>
	/// <para>
	/// The globally unique identifier ( <b>GUID</b>) for the device interface. This parameter, and <i>ppDevice</i>, can be addressed with
	/// the single macro <c>IID_PPV_ARGS</c>.
	/// </para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <b><b>void</b>**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the device. Pass <b>NULL</b> to test if device creation would succeed, but to
	/// not actually create the device. If <b>NULL</b> is passed and device creation would succeed, <b>S_FALSE</b> is returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>This method can return one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// <para>Possible return values include those documented for <c>CreateDXGIFactory1</c> and <c>IDXGIFactory::EnumAdapters</c>.</para>
	/// <para>If <b>ppDevice</b> is <b>NULL</b> and the function succeeds, <b>S_FALSE</b> is returned, rather than <b>S_OK</b>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Direct3D 12 devices are singletons per adapter. If a Direct3D 12 device already exists in the current process for a given adapter,
	/// then a subsequent call to <b>D3D12CreateDevice</b> returns the existing device. If the current Direct3D 12 device is in a removed
	/// state (that is, <c>ID3D12Device::GetDeviceRemovedReason</c> returns a failing HRESULT), then <b>D3D12CreateDevice</b> fails instead
	/// of returning the existing device. The sameness of two adapters (that is, they have the same identity) is determined by comparing
	/// their LUIDs, not their pointers.
	/// </para>
	/// <para>In order to be sure to pick up the first adapter that supports D3D12, use the following code.</para>
	/// <para>
	/// <c>void GetHardwareAdapter(IDXGIFactory4* pFactory, IDXGIAdapter1** ppAdapter) { *ppAdapter = nullptr; for (UINT adapterIndex = 0; ;
	/// ++adapterIndex) { IDXGIAdapter1* pAdapter = nullptr; if (DXGI_ERROR_NOT_FOUND == pFactory-&gt;EnumAdapters1(adapterIndex,
	/// &amp;pAdapter)) { // No more adapters to enumerate. break; } // Check to see if the adapter supports Direct3D 12, but don't create
	/// the // actual device yet. if (SUCCEEDED(D3D12CreateDevice(pAdapter, D3D_FEATURE_LEVEL_11_0, _uuidof(ID3D12Device), nullptr))) {
	/// *ppAdapter = pAdapter; return; } pAdapter-&gt;Release(); } }</c>
	/// </para>
	/// <para>
	/// The function signature PFN_D3D12_CREATE_DEVICE is provided as a typedef, so that you can use dynamic linking techniques (
	/// <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// <para>
	/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to a device can be obtained by using the <c>__uuidof()</c> macro. For example,
	/// <c>__uuidof</c>( <c>ID3D12Device</c>) will get the <b>GUID</b> of the interface to a device.
	/// </para>
	/// <para>Examples</para>
	/// <para>Create a hardware based device, unless instructed to create a WARP software device.</para>
	/// <para>
	/// <c>ComPtr&lt;IDXGIFactory4&gt; factory; ThrowIfFailed(CreateDXGIFactory1(IID_PPV_ARGS(&amp;factory))); if (m_useWarpDevice) {
	/// ComPtr&lt;IDXGIAdapter&gt; warpAdapter; ThrowIfFailed(factory-&gt;EnumWarpAdapter(IID_PPV_ARGS(&amp;warpAdapter)));
	/// ThrowIfFailed(D3D12CreateDevice( warpAdapter.Get(), D3D_FEATURE_LEVEL_11_0, IID_PPV_ARGS(&amp;m_device) )); } else {
	/// ComPtr&lt;IDXGIAdapter1&gt; hardwareAdapter; GetHardwareAdapter(factory.Get(), &amp;hardwareAdapter);
	/// ThrowIfFailed(D3D12CreateDevice( hardwareAdapter.Get(), D3D_FEATURE_LEVEL_11_0, IID_PPV_ARGS(&amp;m_device) )); }</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12createdevice HRESULT D3D12CreateDevice( [in, optional]
	// IUnknown *pAdapter, D3D_FEATURE_LEVEL MinimumFeatureLevel, [in] REFIID riid, [out, optional] void **ppDevice );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12CreateDevice")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D12CreateDevice([In, Optional, MarshalAs(UnmanagedType.Interface)] object? pAdapter,
		D3D_FEATURE_LEVEL MinimumFeatureLevel, in Guid riid, [Out, Optional] IntPtr ppDevice);

	/// <summary>Creates a device that represents the display adapter.</summary>
	/// <param name="pAdapter">
	/// <para>Type: <b>IUnknown*</b></para>
	/// <para>
	/// A pointer to the video adapter to use when creating a <c>device</c>. Pass <b>NULL</b> to use the default adapter, which is the first
	/// adapter that is enumerated by <c>IDXGIFactory1::EnumAdapters</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  Don't mix the use of DXGI 1.0 ( <c>IDXGIFactory</c>) and DXGI 1.1 ( <c>IDXGIFactory1</c>) in an application. Use
	/// <b>IDXGIFactory</b> or <b>IDXGIFactory1</b>, but not both in an application.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="MinimumFeatureLevel">
	/// <para>Type: <b><c>D3D_FEATURE_LEVEL</c></b></para>
	/// <para>The minimum <c>D3D_FEATURE_LEVEL</c> required for successful device creation.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <b><b>REFIID</b></b></para>
	/// <para>
	/// The globally unique identifier ( <b>GUID</b>) for the device interface. This parameter, and <i>ppDevice</i>, can be addressed with
	/// the single macro <c>IID_PPV_ARGS</c>.
	/// </para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <b><b>void</b>**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the device. Pass <b>NULL</b> to test if device creation would succeed, but to
	/// not actually create the device. If <b>NULL</b> is passed and device creation would succeed, <b>S_FALSE</b> is returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>This method can return one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// <para>Possible return values include those documented for <c>CreateDXGIFactory1</c> and <c>IDXGIFactory::EnumAdapters</c>.</para>
	/// <para>If <b>ppDevice</b> is <b>NULL</b> and the function succeeds, <b>S_FALSE</b> is returned, rather than <b>S_OK</b>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Direct3D 12 devices are singletons per adapter. If a Direct3D 12 device already exists in the current process for a given adapter,
	/// then a subsequent call to <b>D3D12CreateDevice</b> returns the existing device. If the current Direct3D 12 device is in a removed
	/// state (that is, <c>ID3D12Device::GetDeviceRemovedReason</c> returns a failing HRESULT), then <b>D3D12CreateDevice</b> fails instead
	/// of returning the existing device. The sameness of two adapters (that is, they have the same identity) is determined by comparing
	/// their LUIDs, not their pointers.
	/// </para>
	/// <para>In order to be sure to pick up the first adapter that supports D3D12, use the following code.</para>
	/// <para>
	/// <c>void GetHardwareAdapter(IDXGIFactory4* pFactory, IDXGIAdapter1** ppAdapter) { *ppAdapter = nullptr; for (UINT adapterIndex = 0; ;
	/// ++adapterIndex) { IDXGIAdapter1* pAdapter = nullptr; if (DXGI_ERROR_NOT_FOUND == pFactory-&gt;EnumAdapters1(adapterIndex,
	/// &amp;pAdapter)) { // No more adapters to enumerate. break; } // Check to see if the adapter supports Direct3D 12, but don't create
	/// the // actual device yet. if (SUCCEEDED(D3D12CreateDevice(pAdapter, D3D_FEATURE_LEVEL_11_0, _uuidof(ID3D12Device), nullptr))) {
	/// *ppAdapter = pAdapter; return; } pAdapter-&gt;Release(); } }</c>
	/// </para>
	/// <para>
	/// The function signature PFN_D3D12_CREATE_DEVICE is provided as a typedef, so that you can use dynamic linking techniques (
	/// <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// <para>
	/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to a device can be obtained by using the <c>__uuidof()</c> macro. For example,
	/// <c>__uuidof</c>( <c>ID3D12Device</c>) will get the <b>GUID</b> of the interface to a device.
	/// </para>
	/// <para>Examples</para>
	/// <para>Create a hardware based device, unless instructed to create a WARP software device.</para>
	/// <para>
	/// <c>ComPtr&lt;IDXGIFactory4&gt; factory; ThrowIfFailed(CreateDXGIFactory1(IID_PPV_ARGS(&amp;factory))); if (m_useWarpDevice) {
	/// ComPtr&lt;IDXGIAdapter&gt; warpAdapter; ThrowIfFailed(factory-&gt;EnumWarpAdapter(IID_PPV_ARGS(&amp;warpAdapter)));
	/// ThrowIfFailed(D3D12CreateDevice( warpAdapter.Get(), D3D_FEATURE_LEVEL_11_0, IID_PPV_ARGS(&amp;m_device) )); } else {
	/// ComPtr&lt;IDXGIAdapter1&gt; hardwareAdapter; GetHardwareAdapter(factory.Get(), &amp;hardwareAdapter);
	/// ThrowIfFailed(D3D12CreateDevice( hardwareAdapter.Get(), D3D_FEATURE_LEVEL_11_0, IID_PPV_ARGS(&amp;m_device) )); }</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12createdevice HRESULT D3D12CreateDevice( [in, optional]
	// IUnknown *pAdapter, D3D_FEATURE_LEVEL MinimumFeatureLevel, [in] REFIID riid, [out, optional] void **ppDevice );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12CreateDevice")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D12CreateDevice([In, Optional, MarshalAs(UnmanagedType.Interface)] object? pAdapter,
		D3D_FEATURE_LEVEL MinimumFeatureLevel, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppDevice);

	/// <summary>Creates a device that represents the display adapter.</summary>
	/// <typeparam name="T">The type of the device interface to return.</typeparam>
	/// <param name="MinimumFeatureLevel">
	/// <para>Type: <b><c>D3D_FEATURE_LEVEL</c></b></para>
	/// <para>The minimum <c>D3D_FEATURE_LEVEL</c> required for successful device creation.</para>
	/// </param>
	/// <param name="pAdapter">
	/// <para>Type: <b>IUnknown*</b></para>
	/// <para>
	/// A pointer to the video adapter to use when creating a <c>device</c>. Pass <b>NULL</b> to use the default adapter, which is the first
	/// adapter that is enumerated by <c>IDXGIFactory1::EnumAdapters</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  Don't mix the use of DXGI 1.0 ( <c>IDXGIFactory</c>) and DXGI 1.1 ( <c>IDXGIFactory1</c>) in an application. Use
	/// <b>IDXGIFactory</b> or <b>IDXGIFactory1</b>, but not both in an application.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <b><b>void</b>**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the device. Pass <b>NULL</b> to test if device creation would succeed, but to
	/// not actually create the device. If <b>NULL</b> is passed and device creation would succeed, <b>S_FALSE</b> is returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>This method can return one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// <para>Possible return values include those documented for <c>CreateDXGIFactory1</c> and <c>IDXGIFactory::EnumAdapters</c>.</para>
	/// <para>If <b>ppDevice</b> is <b>NULL</b> and the function succeeds, <b>S_FALSE</b> is returned, rather than <b>S_OK</b>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Direct3D 12 devices are singletons per adapter. If a Direct3D 12 device already exists in the current process for a given adapter,
	/// then a subsequent call to <b>D3D12CreateDevice</b> returns the existing device. If the current Direct3D 12 device is in a removed
	/// state (that is, <c>ID3D12Device::GetDeviceRemovedReason</c> returns a failing HRESULT), then <b>D3D12CreateDevice</b> fails instead
	/// of returning the existing device. The sameness of two adapters (that is, they have the same identity) is determined by comparing
	/// their LUIDs, not their pointers.
	/// </para>
	/// <para>In order to be sure to pick up the first adapter that supports D3D12, use the following code.</para>
	/// <para>
	/// <c>void GetHardwareAdapter(IDXGIFactory4* pFactory, IDXGIAdapter1** ppAdapter) { *ppAdapter = nullptr; for (UINT adapterIndex = 0; ;
	/// ++adapterIndex) { IDXGIAdapter1* pAdapter = nullptr; if (DXGI_ERROR_NOT_FOUND == pFactory-&gt;EnumAdapters1(adapterIndex,
	/// &amp;pAdapter)) { // No more adapters to enumerate. break; } // Check to see if the adapter supports Direct3D 12, but don't create
	/// the // actual device yet. if (SUCCEEDED(D3D12CreateDevice(pAdapter, D3D_FEATURE_LEVEL_11_0, _uuidof(ID3D12Device), nullptr))) {
	/// *ppAdapter = pAdapter; return; } pAdapter-&gt;Release(); } }</c>
	/// </para>
	/// <para>
	/// The function signature PFN_D3D12_CREATE_DEVICE is provided as a typedef, so that you can use dynamic linking techniques (
	/// <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// <para>
	/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to a device can be obtained by using the <c>__uuidof()</c> macro. For example,
	/// <c>__uuidof</c>( <c>ID3D12Device</c>) will get the <b>GUID</b> of the interface to a device.
	/// </para>
	/// <para>Examples</para>
	/// <para>Create a hardware based device, unless instructed to create a WARP software device.</para>
	/// <para>
	/// <c>ComPtr&lt;IDXGIFactory4&gt; factory; ThrowIfFailed(CreateDXGIFactory1(IID_PPV_ARGS(&amp;factory))); if (m_useWarpDevice) {
	/// ComPtr&lt;IDXGIAdapter&gt; warpAdapter; ThrowIfFailed(factory-&gt;EnumWarpAdapter(IID_PPV_ARGS(&amp;warpAdapter)));
	/// ThrowIfFailed(D3D12CreateDevice( warpAdapter.Get(), D3D_FEATURE_LEVEL_11_0, IID_PPV_ARGS(&amp;m_device) )); } else {
	/// ComPtr&lt;IDXGIAdapter1&gt; hardwareAdapter; GetHardwareAdapter(factory.Get(), &amp;hardwareAdapter);
	/// ThrowIfFailed(D3D12CreateDevice( hardwareAdapter.Get(), D3D_FEATURE_LEVEL_11_0, IID_PPV_ARGS(&amp;m_device) )); }</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12createdevice HRESULT D3D12CreateDevice( [in, optional]
	// IUnknown *pAdapter, D3D_FEATURE_LEVEL MinimumFeatureLevel, [in] REFIID riid, [out, optional] void **ppDevice );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12CreateDevice")]
	public static HRESULT D3D12CreateDevice<T>(D3D_FEATURE_LEVEL MinimumFeatureLevel, [Optional] object? pAdapter, out T? ppDevice) where T : class
	{
		var hr = D3D12CreateDevice(pAdapter, MinimumFeatureLevel, typeof(T).GUID, out object? ptr);
		ppDevice = hr.Succeeded ? (T)ptr! : null;
		return hr;
	}

	/// <summary>Creates a device that represents the display adapter.</summary>
	/// <param name="MinimumFeatureLevel">The minimum <c>D3D_FEATURE_LEVEL</c> required for successful device creation.</param>
	/// <param name="pAdapter">
	/// <para>
	/// A pointer to the video adapter to use when creating a <c>device</c>. Pass <b>NULL</b> to use the default adapter, which is the first
	/// adapter that is enumerated by <c>IDXGIFactory1::EnumAdapters</c>.
	/// </para>
	/// <note>Don't mix the use of DXGI 1.0 ( <c>IDXGIFactory</c>) and DXGI 1.1 ( <c>IDXGIFactory1</c>) in an application. Use
	/// <b>IDXGIFactory</b> or <b>IDXGIFactory1</b>, but not both in an application.</note>
	/// </param>
	/// <returns>A pointer to the device.</returns>
	/// <remarks>
	/// Direct3D 12 devices are singletons per adapter. If a Direct3D 12 device already exists in the current process for a given adapter,
	/// then a subsequent call to <b>D3D12CreateDevice</b> returns the existing device. If the current Direct3D 12 device is in a removed
	/// state (that is, <c>ID3D12Device::GetDeviceRemovedReason</c> returns a failing HRESULT), then <b>D3D12CreateDevice</b> fails instead
	/// of returning the existing device. The sameness of two adapters (that is, they have the same identity) is determined by comparing
	/// their LUIDs, not their pointers.
	/// </remarks>
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12CreateDevice")]
	public static ID3D12Device? D3D12CreateDevice(D3D_FEATURE_LEVEL MinimumFeatureLevel = D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_0, [In] object? pAdapter = null) =>
		D3D12CreateDevice(pAdapter, MinimumFeatureLevel, typeof(ID3D12Device).GUID, out var ptr).Succeeded ? (ID3D12Device?)ptr : null;

	/// <summary>Deserializes a root signature so you can determine the layout definition ( <c>D3D12_ROOT_SIGNATURE_DESC</c>).</summary>
	/// <param name="pSrcData">
	/// <para>Type: <b>LPCVOID</b></para>
	/// <para>A pointer to the source data for the serialized root signature.</para>
	/// </param>
	/// <param name="SrcDataSizeInBytes">
	/// <para>Type: <b><c>SIZE_T</c></b></para>
	/// <para>The size, in bytes, of the block of memory that <i>pSrcData</i> points to.</para>
	/// </param>
	/// <param name="pRootSignatureDeserializerInterface">
	/// <para>Type: <b><b>REFIID</b></b></para>
	/// <para>The globally unique identifier ( <b>GUID</b>) for the root signature deserializer interface. See remarks.</para>
	/// </param>
	/// <param name="ppRootSignatureDeserializer">
	/// <para>Type: <b><b>void</b>**</b></para>
	/// <para>A pointer to a memory block that receives a pointer to the root signature deserializer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function has been superceded by <c>D3D12CreateVersionedRootSignatureDeserializer</c>.</para>
	/// <para>
	/// If an application has a serialized root signature already or has a compiled shader that contains a root signature and wants to
	/// determine the layout definition, it can call <b>D3D12CreateRootSignatureDeserializer</b> to generate a
	/// <c>ID3D12RootSignatureDeserializer</c> interface. <c>ID3D12RootSignatureDeserializer::GetRootSignature</c> can return the
	/// deserialized data structure ( <c>D3D12_ROOT_SIGNATURE_DESC</c>). <b>ID3D12RootSignatureDeserializer</b> just owns the lifetime of
	/// the memory for the deserialized data structure.
	/// </para>
	/// <para>
	/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the root signature deserializer can be obtained by using the __uuidof()
	/// macro. For example, __uuidof( <c>ID3D12RootSignatureDeserializer</c>) will get the <b>GUID</b> of the interface to a root signature deserializer.
	/// </para>
	/// <para>
	/// The function signature PFN_D3D12_CREATE_ROOT_SIGNATURE_DESERIALIZER is provided as a typedef, so that you can use dynamic linking
	/// techniques ( <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12createrootsignaturedeserializer HRESULT
	// D3D12CreateRootSignatureDeserializer( [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSizeInBytes, [in] REFIID
	// pRootSignatureDeserializerInterface, [out] void **ppRootSignatureDeserializer );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12CreateRootSignatureDeserializer")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true), Obsolete("This function has been superceded by D3D12CreateVersionedRootSignatureDeserializer.")]
	public static extern HRESULT D3D12CreateRootSignatureDeserializer([In] IntPtr pSrcData, [In] SizeT SrcDataSizeInBytes,
		in Guid pRootSignatureDeserializerInterface, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppRootSignatureDeserializer);

	/// <summary>Generates an interface that can return the deserialized data structure, via <c>GetUnconvertedRootSignatureDesc</c>.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <b>LPCVOID</b></para>
	/// <para>A pointer to the source data for the serialized root signature.</para>
	/// </param>
	/// <param name="SrcDataSizeInBytes">
	/// <para>Type: <b>SIZE_T</b></para>
	/// <para>The size, in bytes, of the block of memory that <i>pSrcData</i> points to.</para>
	/// </param>
	/// <param name="pRootSignatureDeserializerInterface">
	/// <para>Type: <b>REFIID</b></para>
	/// <para>The globally unique identifier ( <b>GUID</b>) for the root signature deserializer interface. See remarks.</para>
	/// </param>
	/// <param name="ppRootSignatureDeserializer">
	/// <para>Type: <b>void**</b></para>
	/// <para>A pointer to a memory block that receives a pointer to the root signature deserializer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If an application has a serialized root signature already or has a compiled shader that contains a root signature and wants to
	/// determine the layout definition, it can call <b>D3D12CreateVersionedRootSignatureDeserializer</b> to generate a
	/// <c>ID3D12VersionedRootSignatureDeserializer</c> interface.
	/// <c>ID3D12VersionedRootSignatureDeserializer::GetRootSignatureDescAtVersion</c> can return the deserialized data structure (
	/// <c>D3D12_ROOT_SIGNATURE_DESC1</c>). <b>ID3D12VersionedRootSignatureDeserializer</b> just owns the lifetime of the memory for the
	/// deserialized data structure.
	/// </para>
	/// <para>
	/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the root signature deserializer can be obtained by using the __uuidof()
	/// macro. For example, __uuidof( <c>ID3D12VersionedRootSignatureDeserializer</c>) will get the <b>GUID</b> of the interface to a root
	/// signature deserializer.
	/// </para>
	/// <para>
	/// The function signature PFN_D3D12_CREATE_ROOT_SIGNATURE_DESERIALIZER is provided as a typedef, so that you can use dynamic linking
	/// techniques ( <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// <para>This function supercedes <c>D3D12CreateRootSignatureDeserializer</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12createversionedrootsignaturedeserializer HRESULT
	// D3D12CreateVersionedRootSignatureDeserializer( [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSizeInBytes, [in] REFIID
	// pRootSignatureDeserializerInterface, [out] void **ppRootSignatureDeserializer );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12CreateVersionedRootSignatureDeserializer")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D12CreateVersionedRootSignatureDeserializer([In] IntPtr pSrcData, [In] SizeT SrcDataSizeInBytes,
		in Guid pRootSignatureDeserializerInterface, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppRootSignatureDeserializer);

	/// <summary>Generates an interface that can return the deserialized data structure, via <c>GetUnconvertedRootSignatureDesc</c>.</summary>
	/// <param name="pSrcData">A pointer to the source data for the serialized root signature.</param>
	/// <param name="SrcDataSizeInBytes">The size, in bytes, of the block of memory that <i>pSrcData</i> points to.</param>
	/// <returns>A pointer to the root signature deserializer.</returns>
	/// <remarks>
	/// <para>
	/// If an application has a serialized root signature already or has a compiled shader that contains a root signature and wants to
	/// determine the layout definition, it can call <b>D3D12CreateVersionedRootSignatureDeserializer</b> to generate a
	/// <c>ID3D12VersionedRootSignatureDeserializer</c> interface.
	/// <c>ID3D12VersionedRootSignatureDeserializer::GetRootSignatureDescAtVersion</c> can return the deserialized data structure (
	/// <c>D3D12_ROOT_SIGNATURE_DESC1</c>). <b>ID3D12VersionedRootSignatureDeserializer</b> just owns the lifetime of the memory for the
	/// deserialized data structure.
	/// </para>
	/// <para>This function supercedes <c>D3D12CreateRootSignatureDeserializer</c>.</para>
	/// </remarks>
	public static ID3D12VersionedRootSignatureDeserializer? D3D12CreateVersionedRootSignatureDeserializer([In] IntPtr pSrcData, [In] SizeT SrcDataSizeInBytes) =>
		D3D12CreateVersionedRootSignatureDeserializer(pSrcData, SrcDataSizeInBytes, typeof(ID3D12VersionedRootSignatureDeserializer).GUID, out var ptr).Succeeded ? (ID3D12VersionedRootSignatureDeserializer?)ptr : null;

	/// <summary>Enables a list of experimental features.</summary>
	/// <param name="NumFeatures">
	/// <para>Type: <b>UINT</b></para>
	/// <para>The number of experimental features to enable.</para>
	/// </param>
	/// <param name="pIIDs">
	/// <para>Type: <b>const IID*</b></para>
	/// <para><c>SAL</c>: <c>__in_ecount(NumFeatures)</c></para>
	/// <para>A pointer to an array of IDs that specify which of the available experimental features to enable.</para>
	/// </param>
	/// <param name="pConfigurationStructs">
	/// <para>Type: <b>void*</b></para>
	/// <para><c>SAL</c>: <c>__in_ecount(NumFeatures)</c></para>
	/// <para>Structures that contain additional configuration details that some experimental features might need to be enabled.</para>
	/// </param>
	/// <param name="pConfigurationStructSizes">
	/// <para>Type: <b>UINT*</b></para>
	/// <para><c>SAL</c>: <c>__in_ecount(NumFeatures)</c></para>
	/// <para>The sizes of any configuration structs passed in pConfigurationStructs parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>
	/// This method returns an HRESULT success or error code that can include E_NOINTERFACE if an unrecognized feature is specified or
	/// Developer Mode is not enabled, or E_INVALIDARG if the configuration of a feature is in correct, the experimental features specified
	/// are not compatible, or other errors.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Call this function before device creation.</para>
	/// <para>
	/// Because the set of experimental features will change over time, and because these features may not be stable, they are intended for
	/// development and experimentation only. This is enforced by requiring Developer Mode to be active before any experimental features can
	/// be enabled.
	/// </para>
	/// <para>
	/// The set of experimental features that are currently supported can be found in the D3D12.h header, near the definition of the
	/// D3D12EnableExperimentalFeatures function; because experimental features are only made available infrequently, its typical to find
	/// that no experimental features are currently supported.
	/// </para>
	/// <para>
	/// Some experimental features might be identified by using an IID as the GUID. For these features, you can use D3D12GetDebugInterface,
	/// passing an IID as a parameter, to retrieve the interface for manipulating that feature.
	/// </para>
	/// <para>
	/// If this function is called again with a different list of features to enable, all current D3D12 devices are set to the
	/// DEVICE_REMOVED state.
	/// </para>
	/// <para>Examples</para>
	/// <para>This example shows what an experimental feature definition looks like.</para>
	/// <para>
	/// <c>//
	/// -------------------------------------------------------------------------------------------------------------------------------- //
	/// Experimental Feature: D3D12ExperimentalShaderModels // // Use with D3D12EnableExperimentalFeatures to enable experimental shader
	/// model support, // meaning shader models that haven't been finalized for use in retail. // // Enabling D3D12ExperimentalShaderModels
	/// needs no configuration struct, pass NULL in the pConfigurationStructs array. // //
	/// --------------------------------------------------------------------------------------------------------------------------------
	/// static const UUID D3D12ExperimentalShaderModels = { /* 76f5573e-f13a-40f5-b297-81ce9e18933f */ 0x76f5573e, 0xf13a, 0x40f5, { 0xb2,
	/// 0x97, 0x81, 0xce, 0x9e, 0x18, 0x93, 0x3f } };</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12enableexperimentalfeatures HRESULT
	// D3D12EnableExperimentalFeatures( UINT NumFeatures, [in] const IID *pIIDs, [in] void *pConfigurationStructs, [in] UINT
	// *pConfigurationStructSizes );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12EnableExperimentalFeatures")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D12EnableExperimentalFeatures(uint NumFeatures, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[]? pIIDs,
		[In, Optional] IntPtr pConfigurationStructs, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[]? pConfigurationStructSizes);

	/// <summary>
	/// <para>Gets a debug interface.</para>
	/// <para>Use <c>D3D12GetInterface</c> to directly access newer interfaces, especially downlevel.</para>
	/// </summary>
	/// <param name="riid">
	/// <para>Type: <b>REFIID</b></para>
	/// <para>
	/// The globally unique identifier ( <b>GUID</b>) for the debug interface. The <b>REFIID</b>, or <b>GUID</b>, of the debug interface can
	/// be obtained by using the __uuidof() macro. For example, __uuidof( <c>ID3D12Debug</c>) will get the <b>GUID</b> of the debug interface.
	/// </para>
	/// </param>
	/// <param name="ppvDebug">
	/// <para>Type: <b>void**</b></para>
	/// <para>The debug interface, as a pointer to pointer to void. See <c>ID3D12Debug</c> and <c>ID3D12DebugDevice</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function signature PFN_D3D12_GET_DEBUG_INTERFACE is provided as a typedef, so that you can use dynamic linking techniques (
	/// <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// <para>Examples</para>
	/// <para>Enable the D3D12 debug layer.</para>
	/// <para>
	/// <c>// Enable the D3D12 debug layer. { ComPtr&lt;ID3D12Debug&gt; debugController; if
	/// (SUCCEEDED(D3D12GetDebugInterface(IID_PPV_ARGS(&amp;debugController)))) { debugController-&gt;EnableDebugLayer(); } }</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12getdebuginterface HRESULT D3D12GetDebugInterface( [in] REFIID
	// riid, [out, optional] void **ppvDebug );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12GetDebugInterface")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D12GetDebugInterface(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDebug);

	/// <summary>
	/// <para>Gets a debug interface.</para>
	/// <para>Use <c>D3D12GetInterface</c> to directly access newer interfaces, especially downlevel.</para>
	/// </summary>
	/// <typeparam name="T">The type of the debug interface.</typeparam>
	/// <returns>The debug interface. See <c>ID3D12Debug</c> and <c>ID3D12DebugDevice</c>.</returns>
	/// <remarks>Refer to the <c>Example Code in the D3D12 Reference</c>.</remarks>
	public static T? D3D12GetDebugInterface<T>() where T : class => D3D12GetDebugInterface(typeof(T).GUID, out var ptr).Succeeded ? (T?)ptr : null;

	/// <summary>
	/// Selects an SDK version at runtime when the system is in Windows Developer Mode. Supports debug, tools, <c>DRED</c>, and SDK
	/// configuration interfaces.
	/// </summary>
	/// <param name="rclsid">
	/// <para>Type: _In_ <b><c>REFCLSID</c></b></para>
	/// <para>The CLSID associated with the data and code that will be used to create the object.</para>
	/// <para>The following CLSIDs are defined.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>DEFINE_GUID(CLSID_D3D12Debug, 0xf2352aeb, 0xdd84, 0x49fe, 0xb9, 0x7b, 0xa9, 0xdc, 0xfd, 0xcc, 0x1b, 0x4f);</description>
	/// </item>
	/// <item>
	/// <description>DEFINE_GUID(CLSID_D3D12Tools, 0xe38216b1, 0x3c8c, 0x4833, 0xaa, 0x09, 0x0a, 0x06, 0xb6, 0x5d, 0x96, 0xc8);</description>
	/// </item>
	/// <item>
	/// <description>
	/// DEFINE_GUID(CLSID_D3D12DeviceRemovedExtendedData, 0x4a75bbc4, 0x9ff4, 0x4ad8, 0x9f, 0x18, 0xab, 0xae, 0x84, 0xdc, 0x5f, 0xf2);
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// DEFINE_GUID(CLSID_D3D12SDKConfiguration, 0x7cda6aca, 0xa03e, 0x49c8, 0x94, 0x58, 0x03, 0x34, 0xd2, 0x0e, 0x07, 0xce);
	/// </description>
	/// </item>
	/// </list>
	/// <para>They correspond, respectively, to the following interfaces.</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12Debug interface</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Tools interface</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12DeviceRemovedExtendedDataSettings interface</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12SDKConfiguration interface</c></description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="riid">
	/// <para>Type: _In_ <b><c>REFIID</c></b></para>
	/// <para>
	/// The globally unique identifier ( <b>GUID</b>) for the SDK configuration interface. The <b>REFIID</b>, or <b>GUID</b>, of the
	/// interface can be obtained by using the <c>__uuidof</c> macro. For example, <c>__uuidof(ID3D12SDKConfiguration)</c> will retrieve the
	/// <b>GUID</b> of the debug interface.
	/// </para>
	/// </param>
	/// <param name="ppvDebug">
	/// <para>Type: _COM_Outptr_opt_ <b><c>void</c>**</b></para>
	/// <para>
	/// The <c>out</c> parameter that contains the requested interface on return (for example, the SDK configuration interface), as a
	/// pointer to pointer to void. See <c>ID3D12SDKConfiguration</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, then it returns <b>S_OK</b>. Otherwise, it returns one of the <c>Direct3D 12 return codes</c>.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12getinterface HRESULT D3D12GetInterface( REFCLSID rclsid,
	// REFIID riid, void **ppvDebug );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12GetInterface")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D12GetInterface(in Guid rclsid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvDebug);

	/// <summary>
	/// Selects an SDK version at runtime when the system is in Windows Developer Mode. Supports debug, tools, <c>DRED</c>, and SDK
	/// configuration interfaces.
	/// </summary>
	/// <typeparam name="T">The type of the interface.</typeparam>
	/// <returns>The requested interface on return (for example, the SDK configuration interface).</returns>
	/// <exception cref="System.ArgumentException">The interface type must have a CoClassAttribute.</exception>
	public static T? D3D12GetInterface<T>() where T : class
	{
		var clsType = (typeof(T).GetCustomAttributes<CoClassAttribute>().FirstOrDefault()?.CoClass) ?? throw new ArgumentException("The interface type must have a CoClassAttribute.");
		return D3D12GetInterface(clsType.GUID, typeof(T).GUID, out var ptr).Succeeded ? ptr as T : null;
	}

	/// <summary>Serializes a root signature version 1.0 that can be passed to <c>ID3D12Device::CreateRootSignature</c>.</summary>
	/// <param name="pRootSignature">
	/// <para>Type: <b>const <c>D3D12_ROOT_SIGNATURE_DESC</c>*</b></para>
	/// <para>The description of the root signature, as a pointer to a <c>D3D12_ROOT_SIGNATURE_DESC</c> structure.</para>
	/// </param>
	/// <param name="Version">
	/// <para>Type: <b><c>D3D_ROOT_SIGNATURE_VERSION</c></b></para>
	/// <para>A <c>D3D_ROOT_SIGNATURE_VERSION</c>-typed value that specifies the version of root signature.</para>
	/// </param>
	/// <param name="ppBlob">
	/// <para>Type: <b><c>ID3DBlob</c>**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the <c>ID3DBlob</c> interface that you can use to access the serialized root signature.
	/// </para>
	/// </param>
	/// <param name="ppErrorBlob">
	/// <para>Type: <b><c>ID3DBlob</c>**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the <c>ID3DBlob</c> interface that you can use to access serializer error
	/// messages, or <b>NULL</b> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function has been superceded by <c>D3D12SerializeVersionedRootSignature</c> as of the Windows 10 Anniversary Update (14393).</para>
	/// <para>
	/// If an application procedurally generates a <c>D3D12_ROOT_SIGNATURE_DESC</c> data structure, it must pass a pointer to this
	/// <b>D3D12_ROOT_SIGNATURE_DESC</b> in a call to <b>D3D12SerializeRootSignature</b> to make the serialized form. The application then
	/// passes the serialized form to which <i>ppBlob</i> points into <c>ID3D12Device::CreateRootSignature</c>.
	/// </para>
	/// <para>
	/// If a shader has been authored with a root signature in it, the compiled shader will contain a serialized root signature in it
	/// already. In this case, pass the compiled shader blob to <c>ID3D12Device::CreateRootSignature</c> to obtain the runtime root
	/// signature object.
	/// </para>
	/// <para>
	/// The function signature PFN_D3D12_SERIALIZE_ROOT_SIGNATURE is provided as a typedef, so that you can use dynamic linking techniques (
	/// <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// <para>Examples</para>
	/// <para>Create an empty root signature.</para>
	/// <para>
	/// <c>CD3DX12_ROOT_SIGNATURE_DESC rootSignatureDesc; rootSignatureDesc.Init(0, nullptr, 0, nullptr,
	/// D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT); ComPtr&lt;ID3DBlob&gt; signature; ComPtr&lt;ID3DBlob&gt; error;
	/// ThrowIfFailed(D3D12SerializeRootSignature(&amp;rootSignatureDesc, D3D_ROOT_SIGNATURE_VERSION_1, &amp;signature, &amp;error));
	/// ThrowIfFailed(m_device-&gt;CreateRootSignature(0, signature-&gt;GetBufferPointer(), signature-&gt;GetBufferSize(), IID_PPV_ARGS(&amp;m_rootSignature)));</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12serializerootsignature HRESULT D3D12SerializeRootSignature(
	// [in] const D3D12_ROOT_SIGNATURE_DESC *pRootSignature, [in] D3D_ROOT_SIGNATURE_VERSION Version, [out] ID3DBlob **ppBlob, [out,
	// optional] ID3DBlob **ppErrorBlob );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12SerializeRootSignature")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true), Obsolete("This function has been superceded by D3D12SerializeVersionedRootSignature as of the Windows 10 Anniversary Update (14393).")]
	public static extern HRESULT D3D12SerializeRootSignature(in D3D12_ROOT_SIGNATURE_DESC pRootSignature,
		[In] D3D_ROOT_SIGNATURE_VERSION Version, out ID3DBlob ppBlob, [Out, Optional] IUnknownPointer<ID3DBlob> ppErrorBlob);

	/// <summary>Serializes a root signature of any version that can be passed to <c>ID3D12Device::CreateRootSignature</c>.</summary>
	/// <param name="pRootSignature">
	/// <para>Type: <b>const <c>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</c>*</b></para>
	/// <para>Specifies a <c>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</c> that contains a description of any version of a root signature.</para>
	/// </param>
	/// <param name="ppBlob">
	/// <para>Type: <b>ID3DBlob**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the <c>ID3DBlob</c> interface that you can use to access the serialized root signature.
	/// </para>
	/// </param>
	/// <param name="ppErrorBlob">
	/// <para>Type: <b>ID3DBlob**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the <c>ID3DBlob</c> interface that you can use to access serializer error
	/// messages, or <b>NULL</b> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If an application procedurally generates a <c>D3D12_ROOT_SIGNATURE_DESC1</c> data structure, it must pass a pointer to this
	/// <b>D3D12_ROOT_SIGNATURE_DESC1</b> in a call to <b>D3D12SerializeVersionedRootSignature</b> to make the serialized form. The
	/// application then passes the serialized form to which <i>ppBlob</i> points into <c>ID3D12Device::CreateRootSignature</c>.
	/// </para>
	/// <para>
	/// If a shader has been authored with a root signature in it, the compiled shader will contain a serialized root signature in it
	/// already. In this case, pass the compiled shader blob to <c>ID3D12Device::CreateRootSignature</c> to obtain the runtime root
	/// signature object.
	/// </para>
	/// <para>
	/// <para>Note that for Xbox developers, use of HLSL-authored root signatures is strongly recommended.</para>
	/// </para>
	/// <para>
	/// The function signature PFN_D3D12_SERIALIZE_VERSIONED_ROOT_SIGNATURE is provided as a typedef, so that you can use dynamic linking
	/// techniques ( <c>GetProcAddress</c>) instead of statically linking.
	/// </para>
	/// <para>This function was released with the Windows 10 Anniversary Update (14393) and supersedes <c>D3D12SerializeRootSignature</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-d3d12serializeversionedrootsignature HRESULT
	// D3D12SerializeVersionedRootSignature( [in] const D3D12_VERSIONED_ROOT_SIGNATURE_DESC *pRootSignature, [out] ID3DBlob **ppBlob, [out,
	// optional] ID3DBlob **ppErrorBlob );
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.D3D12SerializeVersionedRootSignature")]
	[DllImport(Lib_D3D12, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D12SerializeVersionedRootSignature(in D3D12_VERSIONED_ROOT_SIGNATURE_DESC pRootSignature,
		out ID3DBlob ppBlob, [Out, Optional] IUnknownPointer<ID3DBlob> ppErrorBlob);

	/// <summary>
	/// Helps enable root signature 1.1 features when they are available, and does not require maintaining two code paths for building root
	/// signatures. This helper method reconstructs a version 1.0 root signature when version 1.1 is not supported.
	/// </summary>
	/// <param name="pRootSignatureDesc">
	/// <para>Type: <b>const D3D12_VERSIONED_ROOT_SIGNATURE_DESC*</b></para>
	/// <para>Specifies a <c><b>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</b></c> that contains a description of any version of a root signature.</para>
	/// </param>
	/// <param name="MaxVersion">
	/// <para>Type: <b>D3D_ROOT_SIGNATURE_VERSION</b></para>
	/// <para>Specifies the maximum supported <c><b>D3D_ROOT_SIGNATURE_VERSION</b></c>.</para>
	/// </param>
	/// <param name="ppBlob">
	/// <para>Type: <b>ID3DBlob**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the <c><b>ID3DBlob</b></c> interface that you can use to access the
	/// serialized root signature.
	/// </para>
	/// </param>
	/// <param name="ppErrorBlob">
	/// <para>Type: <b>ID3DBlob**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the <c><b>ID3DBlob</b></c> interface that you can use to access serializer
	/// error messages, or <b>NULL</b> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c><b>HRESULT</b></c></b></para>
	/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// </returns>
	/// <remarks>
	/// This function was released to coincide with the Windows 10 Anniversary Update (14393). In order to support Windows 10 versions prior
	/// to this, use of this function requires d3d12.lib be set up for delay loading.
	/// </remarks>
	[PInvokeData("D3dx12.h")]
	public static HRESULT D3DX12SerializeVersionedRootSignature(in D3D12_VERSIONED_ROOT_SIGNATURE_DESC pRootSignatureDesc,
		D3D_ROOT_SIGNATURE_VERSION MaxVersion, out ID3DBlob? ppBlob, out ID3DBlob? ppErrorBlob)
	{
		unsafe
		{
			IntPtr err = IntPtr.Zero;
			HRESULT hr = D3DX12SerializeVersionedRootSignature(pRootSignatureDesc, MaxVersion, out ppBlob, (IntPtr)(void*)&err);
			ppErrorBlob = err != IntPtr.Zero ? (ID3DBlob)Marshal.GetObjectForIUnknown(err) : null;
			return hr;
		}
	}

	/// <summary>
	/// Helps enable root signature 1.1 features when they are available, and does not require maintaining two code paths for building root
	/// signatures. This helper method reconstructs a version 1.0 root signature when version 1.1 is not supported.
	/// </summary>
	/// <param name="pRootSignatureDesc">
	/// <para>Type: <b>const D3D12_VERSIONED_ROOT_SIGNATURE_DESC*</b></para>
	/// <para>Specifies a <c><b>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</b></c> that contains a description of any version of a root signature.</para>
	/// </param>
	/// <param name="MaxVersion">
	/// <para>Type: <b>D3D_ROOT_SIGNATURE_VERSION</b></para>
	/// <para>Specifies the maximum supported <c><b>D3D_ROOT_SIGNATURE_VERSION</b></c>.</para>
	/// </param>
	/// <param name="ppBlob">
	/// <para>Type: <b>ID3DBlob**</b></para>
	/// <para>
	/// A pointer to a memory block that receives a pointer to the <c><b>ID3DBlob</b></c> interface that you can use to access the
	/// serialized root signature.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c><b>HRESULT</b></c></b></para>
	/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
	/// </returns>
	/// <remarks>
	/// This function was released to coincide with the Windows 10 Anniversary Update (14393). In order to support Windows 10 versions prior
	/// to this, use of this function requires d3d12.lib be set up for delay loading.
	/// </remarks>
	[PInvokeData("D3dx12.h")]
	public static HRESULT D3DX12SerializeVersionedRootSignature(in D3D12_VERSIONED_ROOT_SIGNATURE_DESC pRootSignatureDesc,
		D3D_ROOT_SIGNATURE_VERSION MaxVersion, out ID3DBlob? ppBlob) => D3DX12SerializeVersionedRootSignature(pRootSignatureDesc, MaxVersion, out ppBlob, default);

	private static HRESULT D3DX12SerializeVersionedRootSignature(in D3D12_VERSIONED_ROOT_SIGNATURE_DESC pRootSignatureDesc,
		D3D_ROOT_SIGNATURE_VERSION MaxVersion, out ID3DBlob? ppBlob, [Out] IntPtr ppErrorBlob)
	{
		ppBlob = null;
		switch (MaxVersion)
		{
			case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_0:
				switch (pRootSignatureDesc.Version)
				{
					case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_0:
						return D3D12SerializeRootSignature(pRootSignatureDesc.Desc_1_0, D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1, out ppBlob, ppErrorBlob);

					case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_1:
					case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_2:
						{
							HRESULT hr = HRESULT.S_OK;
							D3D12_ROOT_SIGNATURE_DESC1 desc_1_1 = pRootSignatureDesc.Desc_1_1;

							SizeT ParametersSize = Marshal.SizeOf(typeof(D3D12_ROOT_PARAMETER)) * desc_1_1.NumParameters;
							SafeHeapBlock pParameters = (ParametersSize > 0) ? HeapAlloc(GetProcessHeap(), 0, ParametersSize) : SafeHeapBlock.Null;
							if (ParametersSize > 0 && pParameters.IsInvalid)
							{
								hr = HRESULT.E_OUTOFMEMORY;
							}

							var pParameters_1_0 = pParameters.AsSpan<D3D12_ROOT_PARAMETER>((int)desc_1_1.NumParameters);

							if (hr.Succeeded)
							{
								for (int n = 0; n < desc_1_1.NumParameters; n++)
								{
									pParameters_1_0[n].ParameterType = desc_1_1.pParameters[n].ParameterType;
									pParameters_1_0[n].ShaderVisibility = desc_1_1.pParameters[n].ShaderVisibility;

									switch (desc_1_1.pParameters[n].ParameterType)
									{
										case D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS:
											pParameters_1_0[n].Constants = desc_1_1.pParameters[n].Constants;
											break;

										case D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_CBV:
										case D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_SRV:
										case D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_UAV:
											pParameters_1_0[n].Descriptor = desc_1_1.pParameters[n].Descriptor;
											break;

										case D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE:
											{
												D3D12_ROOT_DESCRIPTOR_TABLE1 table_1_1 = desc_1_1.pParameters[n].DescriptorTable;

												SizeT DescriptorRangesSize = Marshal.SizeOf(typeof(D3D12_DESCRIPTOR_RANGE)) * table_1_1.NumDescriptorRanges;
												SafeHeapBlock pDescriptorRanges = (DescriptorRangesSize > 0 && hr.Succeeded) ? HeapAlloc(GetProcessHeap(), 0, DescriptorRangesSize) : SafeHeapBlock.Null;
												if (DescriptorRangesSize > 0 && pDescriptorRanges.IsInvalid)
												{
													hr = HRESULT.E_OUTOFMEMORY;
												}
												var pDescriptorRanges_1_0 = pDescriptorRanges.AsSpan<D3D12_DESCRIPTOR_RANGE>((int)table_1_1.NumDescriptorRanges);

												if (hr.Succeeded)
												{
													for (int x = 0; x < table_1_1.NumDescriptorRanges; x++)
													{
														pDescriptorRanges_1_0[x] = table_1_1.pDescriptorRanges[x];
													}
												}

												D3D12_ROOT_DESCRIPTOR_TABLE table_1_0 = pParameters_1_0[n].DescriptorTable;
												table_1_0.NumDescriptorRanges = table_1_1.NumDescriptorRanges;
												table_1_0.pDescriptorRanges = pDescriptorRanges; // _1_0;
											}
											break;

										default:
											break;
									}
								}
							}

							Span<D3D12_STATIC_SAMPLER_DESC> pStaticSamplers = default;
							SafeHeapBlock ppSamplers = SafeHeapBlock.Null;
							if (desc_1_1.NumStaticSamplers > 0 && pRootSignatureDesc.Version == D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_2)
							{
								SizeT SamplersSize = Marshal.SizeOf(typeof(D3D12_STATIC_SAMPLER_DESC)) * desc_1_1.NumStaticSamplers;
								ppSamplers = HeapAlloc(GetProcessHeap(), 0, SamplersSize);

								if (ppSamplers.IsInvalid)
								{
									hr = HRESULT.E_OUTOFMEMORY;
								}
								else
								{
									pStaticSamplers = ppSamplers.AsSpan<D3D12_STATIC_SAMPLER_DESC>((int)desc_1_1.NumStaticSamplers);
									D3D12_ROOT_SIGNATURE_DESC2 desc_1_2 = pRootSignatureDesc.Desc_1_2;
									for (int n = 0; n < desc_1_1.NumStaticSamplers; ++n)
									{
										if ((desc_1_2.pStaticSamplers[n].Flags & ~D3D12_SAMPLER_FLAGS.D3D12_SAMPLER_FLAG_UINT_BORDER_COLOR) != 0)
										{
											hr = HRESULT.E_INVALIDARG;
											break;
										}
										pStaticSamplers[n] = desc_1_2.pStaticSamplers[n];
									}
								}
							}

							if (hr.Succeeded)
							{
								D3D12_ROOT_SIGNATURE_DESC desc_1_0 = new(desc_1_1.NumParameters, pParameters, desc_1_1.NumStaticSamplers, pStaticSamplers == default ? (IntPtr)desc_1_1.pStaticSamplers : ppSamplers, desc_1_1.Flags);
								hr = D3D12SerializeRootSignature(desc_1_0, D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1, out ppBlob, ppErrorBlob);
							}

							return hr;
						}

					default:
						break;
				}
				break;

			case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_1:
				switch (pRootSignatureDesc.Version)
				{
					case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_0:
					case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_1:
						return D3D12SerializeVersionedRootSignature(pRootSignatureDesc, out ppBlob, ppErrorBlob);

					case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_2:
						{
							HRESULT hr = HRESULT.S_OK;
							D3D12_ROOT_SIGNATURE_DESC1 desc_1_1 = pRootSignatureDesc.Desc_1_1;

							Span<D3D12_STATIC_SAMPLER_DESC> pStaticSamplers = default;
							SafeHeapBlock ppStaticSamplers = SafeHeapBlock.Null;
							if (desc_1_1.NumStaticSamplers > 0)
							{
								SizeT SamplersSize = Marshal.SizeOf(typeof(D3D12_STATIC_SAMPLER_DESC)) * desc_1_1.NumStaticSamplers;
								ppStaticSamplers = HeapAlloc(GetProcessHeap(), 0, SamplersSize);

								if (ppStaticSamplers.IsInvalid)
								{
									hr = HRESULT.E_OUTOFMEMORY;
								}
								else
								{
									pStaticSamplers = ppStaticSamplers.AsSpan<D3D12_STATIC_SAMPLER_DESC>((int)desc_1_1.NumStaticSamplers);
									D3D12_ROOT_SIGNATURE_DESC2 desc_1_2 = pRootSignatureDesc.Desc_1_2;
									for (int n = 0; n < desc_1_1.NumStaticSamplers; ++n)
									{
										if ((desc_1_2.pStaticSamplers[n].Flags & ~D3D12_SAMPLER_FLAGS.D3D12_SAMPLER_FLAG_UINT_BORDER_COLOR) != 0)
										{
											hr = HRESULT.E_INVALIDARG;
											break;
										}
										pStaticSamplers[n] = desc_1_2.pStaticSamplers[n];
									}
								}
							}

							if (hr.Succeeded)
							{
								D3D12_VERSIONED_ROOT_SIGNATURE_DESC desc = new(desc_1_1);
								if (pStaticSamplers != default) desc.Desc_1_1.pStaticSamplers = ppStaticSamplers;
								hr = D3D12SerializeVersionedRootSignature(desc, out ppBlob, ppErrorBlob);
							}

							return hr;
						}

					default:
						break;
				}
				break;

			case D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_2:
			default:
				return D3D12SerializeVersionedRootSignature(pRootSignatureDesc, out ppBlob, ppErrorBlob);
		}

		return HRESULT.E_INVALIDARG;
	}

	/// <summary>CLSID_D3D12Debug</summary>
	[ComImport, Guid("f2352aeb-dd84-49fe-b97b-a9dcfdcc1b4f"), ClassInterface(ClassInterfaceType.None)]
	public class D3D12Debug { }

	/// <summary>CLSID_D3D12DeviceRemovedExtendedData</summary>
	[ComImport, Guid("4a75bbc4-9ff4-4ad8-9f18-abae84dc5ff2"), ClassInterface(ClassInterfaceType.None)]
	public class D3D12DeviceRemovedExtendedData { }

	/// <summary>CLSID_D3D12SDKConfiguration</summary>
	[ComImport, Guid("7cda6aca-a03e-49c8-9458-0334d20e07ce"), ClassInterface(ClassInterfaceType.None)]
	public class D3D12SDKConfiguration { }

	/// <summary>CLSID_D3D12Tools</summary>
	[ComImport, Guid("e38216b1-3c8c-4833-aa09-0a06b65d96c8"), ClassInterface(ClassInterfaceType.None)]
	public class D3D12Tools { }
}