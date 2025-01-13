#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Diagnostics;

namespace Vanara.PInvoke;

public static partial class D3D12
{
	private const int MAP_ALIGN_REQUIREMENT = 16; // Map is required to return 16-byte aligned addresses

	public static class D3D12_PROPERTY_LAYOUT_FORMAT_TABLE
	{
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _FIXED_2_8 = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_BIASED_FIXED_2_8;
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _FLOAT = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_FLOAT;
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _SINT = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_SINT;
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _SNORM = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_SNORM;
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _TYPELESS = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_TYPELESS;
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _UINT = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_UINT;
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _UNORM = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_UNORM;
		private const D3D_FORMAT_COMPONENT_INTERPRETATION _UNORM_SRGB = D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_UNORM_SRGB;
		private const D3D_FORMAT_COMPONENT_NAME A = D3D_FORMAT_COMPONENT_NAME.D3DFCN_A;
		private const D3D_FORMAT_COMPONENT_NAME B = D3D_FORMAT_COMPONENT_NAME.D3DFCN_B;
		private const D3D_FORMAT_COMPONENT_NAME D = D3D_FORMAT_COMPONENT_NAME.D3DFCN_D;
		private const D3D_FORMAT_COMPONENT_NAME G = D3D_FORMAT_COMPONENT_NAME.D3DFCN_G;
		private const D3D_FORMAT_COMPONENT_NAME R = D3D_FORMAT_COMPONENT_NAME.D3DFCN_R;
		private const D3D_FORMAT_COMPONENT_NAME S = D3D_FORMAT_COMPONENT_NAME.D3DFCN_S;
		private const D3D_FORMAT_COMPONENT_NAME X = D3D_FORMAT_COMPONENT_NAME.D3DFCN_X;
		private const D3D_FORMAT_LAYOUT _CUSTOM = D3D_FORMAT_LAYOUT.D3DFL_CUSTOM;
		private const D3D_FORMAT_LAYOUT _STANDARD = D3D_FORMAT_LAYOUT.D3DFL_STANDARD;
		private const D3D_FORMAT_TYPE_LEVEL _FULL = D3D_FORMAT_TYPE_LEVEL.D3DFTL_FULL_TYPE;
		private const D3D_FORMAT_TYPE_LEVEL _NO_TYPE = D3D_FORMAT_TYPE_LEVEL.D3DFTL_NO_TYPE;
		private const D3D_FORMAT_TYPE_LEVEL _PARTIAL = D3D_FORMAT_TYPE_LEVEL.D3DFTL_PARTIAL_TYPE;
		private const DXGI_FORMAT _BADFMT = (DXGI_FORMAT)uint.MaxValue;
		private const int INTSAFE_E_ARITHMETIC_OVERFLOW = unchecked((int)0x80070216);

		private static readonly DXGI_FORMAT[] D3DFCS_420_OPAQUE =
		[
			DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_A4B4G4R4 =
		[
			DXGI_FORMAT.DXGI_FORMAT_A4B4G4R4_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_A8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_A8_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_A8P8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_A8P8,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_AI44 =
		[
			DXGI_FORMAT.DXGI_FORMAT_AI44,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_AYUV =
		[
			DXGI_FORMAT.DXGI_FORMAT_AYUV,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_B4G4R4A4 =
		[
			DXGI_FORMAT.DXGI_FORMAT_B4G4R4A4_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_B5G5R5A1 =
		[
			DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_B5G6R5 =
		[
			DXGI_FORMAT.DXGI_FORMAT_B5G6R5_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_B8G8R8A8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_B8G8R8X8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_BC1 =
		[
			DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_BC2 =
		[
			DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_BC3 =
		[
			DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_BC4 =
		[
			DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_BC5 =
		[
			DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_BC6H =
		[
			DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16,
			DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_BC7 =
		[
			DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_G8R8_G8B8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_IA44 =
		[
			DXGI_FORMAT.DXGI_FORMAT_IA44,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_NV11 =
		[
			DXGI_FORMAT.DXGI_FORMAT_NV11,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_NV12 =
		[
			DXGI_FORMAT.DXGI_FORMAT_NV12,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_P010 =
		[
			DXGI_FORMAT.DXGI_FORMAT_P010,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_P016 =
		[
			DXGI_FORMAT.DXGI_FORMAT_P016,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_P208 =
		[
			DXGI_FORMAT.DXGI_FORMAT_P208,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_P8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_P8,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R1 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R1_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R10G10B10A2 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R11G11B10 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R11G11B10_FLOAT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R16 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R16_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_D16_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R16_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R16_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R16_SNORM,
			DXGI_FORMAT.DXGI_FORMAT_R16_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R16G16 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R16G16_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R16G16_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R16G16_SNORM,
			DXGI_FORMAT.DXGI_FORMAT_R16G16_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R16G16B16A16 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM,
			DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R24G8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R24_UNORM_X8_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_X24_TYPELESS_G8_UINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R32 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_R32_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R32_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R32G32 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R32G32B32 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R32G32B32A32 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT,
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R32G8X24 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_X32_TYPELESS_G8X24_UINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R8_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R8_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R8_SNORM,
			DXGI_FORMAT.DXGI_FORMAT_R8_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R8G8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R8G8_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R8G8_SNORM,
			DXGI_FORMAT.DXGI_FORMAT_R8G8_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R8G8_B8G8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R8G8B8A8 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS,
			DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM,
			DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,
			DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT,
			DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SNORM,
			DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_R9G9B9E5 =
		[
			DXGI_FORMAT.DXGI_FORMAT_R9G9B9E5_SHAREDEXP,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_UNKNOWN = [ ];

		private static readonly DXGI_FORMAT[] D3DFCS_V208 =
		[
			DXGI_FORMAT.DXGI_FORMAT_V208,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_V408 =
		[
			DXGI_FORMAT.DXGI_FORMAT_V408,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_Y210 =
		[
			DXGI_FORMAT.DXGI_FORMAT_Y210,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_Y216 =
		[
			DXGI_FORMAT.DXGI_FORMAT_Y216,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_Y410 =
		[
			DXGI_FORMAT.DXGI_FORMAT_Y410,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_Y416 =
		[
			DXGI_FORMAT.DXGI_FORMAT_Y416,
		];

		private static readonly DXGI_FORMAT[] D3DFCS_YUY2 =
		[
			DXGI_FORMAT.DXGI_FORMAT_YUY2,
		];

		private static readonly FORMAT_DETAIL[] s_FormatDetail =
		[
			new( DXGI_FORMAT.DXGI_FORMAT_UNKNOWN                              ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          true,                   false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS                ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS,        D3DFCS_R32G32B32A32,  [32,32,32,32],  128,            false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT                   ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS,        D3DFCS_R32G32B32A32,  [32,32,32,32],  128,            false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _FLOAT, _FLOAT, _FLOAT, _FLOAT,                      true,                   false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT                    ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS,        D3DFCS_R32G32B32A32,  [32,32,32,32],  128,            false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UINT, _UINT, _UINT, _UINT,                          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT                    ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_TYPELESS,        D3DFCS_R32G32B32A32,  [32,32,32,32],  128,            false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _SINT, _SINT, _SINT, _SINT,                          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS                   ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS,           D3DFCS_R32G32B32,     [32,32,32,0],   96,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,B,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT                      ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS,           D3DFCS_R32G32B32,     [32,32,32,0],   96,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,X,         _FLOAT, _FLOAT, _FLOAT, _TYPELESS,                   true,                   false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT                       ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS,           D3DFCS_R32G32B32,     [32,32,32,0],   96,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,X,         _UINT, _UINT, _UINT, _TYPELESS,                      false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT                       ,DXGI_FORMAT.DXGI_FORMAT_R32G32B32_TYPELESS,           D3DFCS_R32G32B32,     [32,32,32,0],   96,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,X,         _SINT, _SINT, _SINT, _TYPELESS,                      false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS                ,DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS,        D3DFCS_R16G16B16A16,  [16,16,16,16],  64,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT                   ,DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS,        D3DFCS_R16G16B16A16,  [16,16,16,16],  64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _FLOAT, _FLOAT, _FLOAT, _FLOAT,                      true,                   false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM                   ,DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS,        D3DFCS_R16G16B16A16,  [16,16,16,16],  64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      true,                   true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT                    ,DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS,        D3DFCS_R16G16B16A16,  [16,16,16,16],  64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UINT, _UINT, _UINT, _UINT,                          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM                   ,DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS,        D3DFCS_R16G16B16A16,  [16,16,16,16],  64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _SNORM, _SNORM, _SNORM, _SNORM,                      true,                   false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT                    ,DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_TYPELESS,        D3DFCS_R16G16B16A16,  [16,16,16,16],  64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _SINT, _SINT, _SINT, _SINT,                          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS                      ,DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS,              D3DFCS_R32G32,        [32,32,0,0],    64,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT                         ,DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS,              D3DFCS_R32G32,        [32,32,0,0],    64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _FLOAT, _FLOAT, _TYPELESS, _TYPELESS,                true,                   false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT                          ,DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS,              D3DFCS_R32G32,        [32,32,0,0],    64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _UINT, _UINT, _TYPELESS, _TYPELESS,                  false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT                          ,DXGI_FORMAT.DXGI_FORMAT_R32G32_TYPELESS,              D3DFCS_R32G32,        [32,32,0,0],    64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _SINT, _SINT, _TYPELESS, _TYPELESS,                  false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS                    ,DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS,            D3DFCS_R32G8X24,      [32,8,24,0],    64,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT                 ,DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS,            D3DFCS_R32G8X24,      [32,8,24,0],    64,             false, 1,              1,               1,                _STANDARD,   _FULL,     D,S,X,X,         _FLOAT,_UINT,_TYPELESS,_TYPELESS,                    false,                  false,               false,            true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS             ,DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS,            D3DFCS_R32G8X24,      [32,8,24,0],    64,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _FLOAT,_TYPELESS,_TYPELESS,_TYPELESS,                false,                  false,               true,             true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_X32_TYPELESS_G8X24_UINT              ,DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS,            D3DFCS_R32G8X24,      [32,8,24,0],    64,             false, 1,              1,               1,                _STANDARD,   _FULL,     X,G,X,X,         _TYPELESS,_UINT,_TYPELESS,_TYPELESS,                 false,                  false,               false,            true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS                 ,DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS,         D3DFCS_R10G10B10A2,   [10,10,10,2],   32,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  true,                   false),
			new( DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM                    ,DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS,         D3DFCS_R10G10B10A2,   [10,10,10,2],   32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                true,             false,   false,  true,                   false),
			new( DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UINT                     ,DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS,         D3DFCS_R10G10B10A2,   [10,10,10,2],   32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UINT, _UINT, _UINT, _UINT,                          false,                  false,               false,            false,   false,  true,                   false),
			new( DXGI_FORMAT.DXGI_FORMAT_R11G11B10_FLOAT                      ,DXGI_FORMAT.DXGI_FORMAT_R11G11B10_FLOAT,              D3DFCS_R11G11B10,     [11,11,10,0],   32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,X,         _FLOAT, _FLOAT, _FLOAT, _TYPELESS,                   false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS                    ,DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS,            D3DFCS_R8G8B8A8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM                       ,DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS,            D3DFCS_R8G8B8A8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      true,                   true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB                  ,DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS,            D3DFCS_R8G8B8A8,      [8,8,8,8],      32,             true,  1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB,  false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT                        ,DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS,            D3DFCS_R8G8B8A8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _UINT, _UINT, _UINT, _UINT,                          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SNORM                       ,DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS,            D3DFCS_R8G8B8A8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _SNORM, _SNORM, _SNORM, _SNORM,                      false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT                        ,DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS,            D3DFCS_R8G8B8A8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _SINT, _SINT, _SINT, _SINT,                          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS                      ,DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS,              D3DFCS_R16G16,        [16,16,0,0],    32,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16_FLOAT                         ,DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS,              D3DFCS_R16G16,        [16,16,0,0],    32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _FLOAT, _FLOAT, _TYPELESS, _TYPELESS,                true,                   true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM                         ,DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS,              D3DFCS_R16G16,        [16,16,0,0],    32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _UNORM, _UNORM, _TYPELESS, _TYPELESS,                true,                   true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16_UINT                          ,DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS,              D3DFCS_R16G16,        [16,16,0,0],    32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _UINT, _UINT, _TYPELESS, _TYPELESS,                  false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16_SNORM                         ,DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS,              D3DFCS_R16G16,        [16,16,0,0],    32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _SNORM, _SNORM, _TYPELESS, _TYPELESS,                true,                   true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16G16_SINT                          ,DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS,              D3DFCS_R16G16,        [16,16,0,0],    32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _SINT, _SINT, _TYPELESS, _TYPELESS,                  false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS,                 D3DFCS_R32,           [32,0,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT                            ,DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS,                 D3DFCS_R32,           [32,0,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _FULL,     D,X,X,X,         _FLOAT, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT                            ,DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS,                 D3DFCS_R32,           [32,0,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _FLOAT, _TYPELESS, _TYPELESS, _TYPELESS,             true,                   true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32_UINT                             ,DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS,                 D3DFCS_R32,           [32,0,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _UINT, _TYPELESS, _TYPELESS, _TYPELESS,              false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R32_SINT                             ,DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS,                 D3DFCS_R32,           [32,0,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _SINT, _TYPELESS, _TYPELESS, _TYPELESS,              false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS                       ,DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS,               D3DFCS_R24G8,         [24,8,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT                    ,DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS,               D3DFCS_R24G8,         [24,8,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _FULL,     D,S,X,X,         _UNORM,_UINT,_TYPELESS,_TYPELESS,                    false,                  true,                false,            true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R24_UNORM_X8_TYPELESS                ,DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS,               D3DFCS_R24G8,         [24,8,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _UNORM,_TYPELESS,_TYPELESS,_TYPELESS,                false,                  false,               true,             true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_X24_TYPELESS_G8_UINT                 ,DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS,               D3DFCS_R24G8,         [24,8,0,0],     32,             false, 1,              1,               1,                _STANDARD,   _FULL,     X,G,X,X,         _TYPELESS,_UINT,_TYPELESS,_TYPELESS,                 false,                  false,               false,            true,    false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS                        ,DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS,                D3DFCS_R8G8,          [8,8,0,0],      16,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,G,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM                           ,DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS,                D3DFCS_R8G8,          [8,8,0,0],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _UNORM, _UNORM, _TYPELESS, _TYPELESS,                false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8_UINT                            ,DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS,                D3DFCS_R8G8,          [8,8,0,0],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _UINT, _UINT, _TYPELESS, _TYPELESS,                  false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8_SNORM                           ,DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS,                D3DFCS_R8G8,          [8,8,0,0],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _SNORM, _SNORM, _TYPELESS, _TYPELESS,                false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8_SINT                            ,DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS,                D3DFCS_R8G8,          [8,8,0,0],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,X,X,         _SINT, _SINT, _TYPELESS, _TYPELESS,                  false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,                 D3DFCS_R16,           [16,0,0,0],     16,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16_FLOAT                            ,DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,                 D3DFCS_R16,           [16,0,0,0],     16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _FLOAT, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_D16_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,                 D3DFCS_R16,           [16,0,0,0],     16,             false, 1,              1,               1,                _STANDARD,   _FULL,     D,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,                 D3DFCS_R16,           [16,0,0,0],     16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16_UINT                             ,DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,                 D3DFCS_R16,           [16,0,0,0],     16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _UINT, _TYPELESS, _TYPELESS, _TYPELESS,              false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16_SNORM                            ,DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,                 D3DFCS_R16,           [16,0,0,0],     16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _SNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R16_SINT                             ,DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS,                 D3DFCS_R16,           [16,0,0,0],     16,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _SINT, _TYPELESS, _TYPELESS, _TYPELESS,              false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS                          ,DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS,                  D3DFCS_R8,            [8,0,0,0],      8,              false, 1,              1,               1,                _STANDARD,   _PARTIAL,  R,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8_UNORM                             ,DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS,                  D3DFCS_R8,            [8,0,0,0],      8,              false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8_UINT                              ,DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS,                  D3DFCS_R8,            [8,0,0,0],      8,              false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _UINT, _TYPELESS, _TYPELESS, _TYPELESS,              false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8_SNORM                             ,DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS,                  D3DFCS_R8,            [8,0,0,0],      8,              false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _SNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8_SINT                              ,DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS,                  D3DFCS_R8,            [8,0,0,0],      8,              false, 1,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _SINT, _TYPELESS, _TYPELESS, _TYPELESS,              false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_A8_UNORM                             ,DXGI_FORMAT.DXGI_FORMAT_A8_UNORM,                     D3DFCS_A8,            [0,0,0,8],      8,              false, 1,              1,               1,                _STANDARD,   _FULL,     X,X,X,A,         _TYPELESS, _TYPELESS, _TYPELESS, _UNORM,             false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R1_UNORM                             ,DXGI_FORMAT.DXGI_FORMAT_R1_UNORM,                     D3DFCS_R1,            [1,0,0,0],      1,              false, 8,              1,               1,                _STANDARD,   _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R9G9B9E5_SHAREDEXP                   ,DXGI_FORMAT.DXGI_FORMAT_R9G9B9E5_SHAREDEXP,           D3DFCS_R9G9B9E5,      [0,0,0,0],      32,             false, 1,              1,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _FLOAT, _FLOAT, _FLOAT, _FLOAT,                      false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM                      ,DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM,              D3DFCS_R8G8_B8G8,     [0,0,0,0],      16,             false, 2,              1,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _UNORM, _UNORM, _UNORM, _TYPELESS,                   false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM                      ,DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM,              D3DFCS_G8R8_G8B8,     [0,0,0,0],      16,             false, 2,              1,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _UNORM, _UNORM, _UNORM, _TYPELESS,                   false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS,                 D3DFCS_BC1,           [0,0,0,0],      64,             false, 4,              4,               1,                _CUSTOM,     _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  true,                false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS,                 D3DFCS_BC1,           [0,0,0,0],      64,             false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB                       ,DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS,                 D3DFCS_BC1,           [0,0,0,0],      64,             true,  4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB, _UNORM,       false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS,                 D3DFCS_BC2,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  true,                false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS,                 D3DFCS_BC2,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM_SRGB                       ,DXGI_FORMAT.DXGI_FORMAT_BC2_TYPELESS,                 D3DFCS_BC2,           [0,0,0,0],      128,            true,  4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB, _UNORM,       false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS,                 D3DFCS_BC3,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS,                 D3DFCS_BC3,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM_SRGB                       ,DXGI_FORMAT.DXGI_FORMAT_BC3_TYPELESS,                 D3DFCS_BC3,           [0,0,0,0],      128,            true,  4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB, _UNORM,       false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS,                 D3DFCS_BC4,           [0,0,0,0],      64,             false, 4,              4,               1,                _CUSTOM,     _PARTIAL,  R,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS,                 D3DFCS_BC4,           [0,0,0,0],      64,             false, 4,              4,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS,                 D3DFCS_BC4,           [0,0,0,0],      64,             false, 4,              4,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _SNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS,                 D3DFCS_BC5,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _PARTIAL,  R,G,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS,                 D3DFCS_BC5,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,X,X,         _UNORM, _UNORM, _TYPELESS, _TYPELESS,                false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC5_TYPELESS,                 D3DFCS_BC5,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,X,X,         _SNORM, _SNORM, _TYPELESS, _TYPELESS,                false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B5G6R5_UNORM                         ,DXGI_FORMAT.DXGI_FORMAT_B5G6R5_UNORM,                 D3DFCS_B5G6R5,        [5,6,5,0],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,X,         _UNORM, _UNORM, _UNORM, _TYPELESS,                   false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM                       ,DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM,               D3DFCS_B5G5R5A1,      [5,5,5,1],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM                       ,DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS,            D3DFCS_B8G8R8A8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM                       ,DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS,            D3DFCS_B8G8R8X8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,X,         _UNORM, _UNORM, _UNORM, _TYPELESS,                   false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM           ,DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS,         D3DFCS_R10G10B10A2,   [10,10,10,2],   32,             false, 1,              1,               1,                _STANDARD,   _FULL,     R,G,B,A,         _FIXED_2_8, _FIXED_2_8, _FIXED_2_8, _UNORM,          false,                  true,                false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS                    ,DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS,            D3DFCS_B8G8R8A8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  B,G,R,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  true,                false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB                  ,DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS,            D3DFCS_B8G8R8A8,      [8,8,8,8],      32,             true,  1,              1,               1,                _STANDARD,   _FULL,     B,G,R,A,         _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB,  false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS                    ,DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS,            D3DFCS_B8G8R8X8,      [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _PARTIAL,  B,G,R,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  true,                false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_UNORM_SRGB                  ,DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS,            D3DFCS_B8G8R8X8,      [8,8,8,8],      32,             true,  1,              1,               1,                _STANDARD,   _FULL,     B,G,R,X,         _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB, _TYPELESS,    false,                  true,                true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS                        ,DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS,                D3DFCS_BC6H,          [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _PARTIAL,  R,G,B,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC6H_UF16                            ,DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS,                D3DFCS_BC6H,          [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _FLOAT, _FLOAT, _FLOAT, _TYPELESS,                   false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC6H_SF16                            ,DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS,                D3DFCS_BC6H,          [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _FLOAT, _FLOAT, _FLOAT, _TYPELESS,                   false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS                         ,DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS,                 D3DFCS_BC7,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _PARTIAL,  R,G,B,A,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM                            ,DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS,                 D3DFCS_BC7,           [0,0,0,0],      128,            false, 4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  false,               true,             false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB                       ,DXGI_FORMAT.DXGI_FORMAT_BC7_TYPELESS,                 D3DFCS_BC7,           [0,0,0,0],      128,            true,  4,              4,               1,                _CUSTOM,     _FULL,     R,G,B,A,         _UNORM_SRGB, _UNORM_SRGB, _UNORM_SRGB, _UNORM,       false,                  false,               true,             false,   false,  false,                  false),
			// YUV 4:4:4 formats
			new( DXGI_FORMAT.DXGI_FORMAT_AYUV                                 ,DXGI_FORMAT.DXGI_FORMAT_AYUV,                         D3DFCS_AYUV,          [8,8,8,8],      32,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_Y410                                 ,DXGI_FORMAT.DXGI_FORMAT_Y410,                         D3DFCS_Y410,          [10,10,10,2],   32,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  false,               false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_Y416                                 ,DXGI_FORMAT.DXGI_FORMAT_Y416,                         D3DFCS_Y416,          [16,16,16,16],  64,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  false,               false,            false,   true,   false,                  false),
			// YUV 4:2:0 formats
			new( DXGI_FORMAT.DXGI_FORMAT_NV12                                 ,DXGI_FORMAT.DXGI_FORMAT_NV12,                         D3DFCS_NV12,          [0,0,0,0],      8,              false, 2,              2,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            true,    true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_P010                                 ,DXGI_FORMAT.DXGI_FORMAT_P010,                         D3DFCS_P010,          [0,0,0,0],      16,             false, 2,              2,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               false,            true,    true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_P016                                 ,DXGI_FORMAT.DXGI_FORMAT_P016,                         D3DFCS_P016,          [0,0,0,0],      16,             false, 2,              2,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               false,            true,    true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE                           ,DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE,                   D3DFCS_420_OPAQUE,    [0,0,0,0],      8,              false, 2,              2,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            true,    true,   false,                  false),
			// YUV 4:2:2 formats
			new( DXGI_FORMAT.DXGI_FORMAT_YUY2                                 ,DXGI_FORMAT.DXGI_FORMAT_YUY2,                         D3DFCS_YUY2,          [0,0,0,0],      16,             false, 2,              1,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _UNORM, _UNORM, _UNORM, _TYPELESS,                   false,                  true,                false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_Y210                                 ,DXGI_FORMAT.DXGI_FORMAT_Y210,                         D3DFCS_Y210,          [0,0,0,0],      32,             false, 2,              1,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _UNORM, _UNORM, _UNORM, _TYPELESS,                   false,                  false,               false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_Y216                                 ,DXGI_FORMAT.DXGI_FORMAT_Y216,                         D3DFCS_Y216,          [0,0,0,0],      32,             false, 2,              1,               1,                _CUSTOM,     _FULL,     R,G,B,X,         _UNORM, _UNORM, _UNORM, _TYPELESS,                   false,                  false,               false,            false,   true,   false,                  false),
			// YUV 4:1:1 formats
			new( DXGI_FORMAT.DXGI_FORMAT_NV11                                 ,DXGI_FORMAT.DXGI_FORMAT_NV11,                         D3DFCS_NV11,          [0,0,0,0],      8,              false, 4,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            true,    true,   false,                  false),
			// Legacy substream formats
			new( DXGI_FORMAT.DXGI_FORMAT_AI44                                 ,DXGI_FORMAT.DXGI_FORMAT_AI44,                         D3DFCS_AI44,          [0,0,0,0],      8,              false, 1,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_IA44                                 ,DXGI_FORMAT.DXGI_FORMAT_IA44,                         D3DFCS_IA44,          [0,0,0,0],      8,              false, 1,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_P8                                   ,DXGI_FORMAT.DXGI_FORMAT_P8,                           D3DFCS_P8,            [0,0,0,0],      8,              false, 1,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_A8P8                                 ,DXGI_FORMAT.DXGI_FORMAT_A8P8,                         D3DFCS_A8P8,          [0,0,0,0],      16,             false, 1,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            false,   true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_B4G4R4A4_UNORM                       ,DXGI_FORMAT.DXGI_FORMAT_B4G4R4A4_UNORM,               D3DFCS_B4G4R4A4,      [4,4,4,4],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     B,G,R,A,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  true,                true,             false,   false,  false,                  false),
			new( (DXGI_FORMAT)116                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)117                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)118                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)119                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)120                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)121                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)122                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)123                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)124                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)125                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)126                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)127                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)128                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)129                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( DXGI_FORMAT.DXGI_FORMAT_P208                                 ,DXGI_FORMAT.DXGI_FORMAT_P208,                         D3DFCS_P208,          [0,0,0,0],      8,              false, 2,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            true,    true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_V208                                 ,DXGI_FORMAT.DXGI_FORMAT_V208,                         D3DFCS_V208,          [0,0,0,0],      8,              false, 1,              2,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            true,    true,   false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_V408                                 ,DXGI_FORMAT.DXGI_FORMAT_V408,                         D3DFCS_V408,          [0,0,0,0],      8,              false, 1,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  true,                false,            true,    true,   false,                  false),
			new( (DXGI_FORMAT)133                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)134                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)135                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)136                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)137                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)138                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)139                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)140                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)141                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)142                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)143                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)144                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)145                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)146                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)147                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)148                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)149                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)150                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)151                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)152                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)153                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)154                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)155                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)156                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)157                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)158                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)159                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)160                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)161                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)162                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)163                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)164                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)165                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)166                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)167                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)168                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)169                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)170                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)171                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)172                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)173                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)174                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)175                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)176                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)177                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)178                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)179                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)180                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)181                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)182                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)183                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)184                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)185                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)186                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)187                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( (DXGI_FORMAT)188                                             ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      0,              false, 1,              1,               1,                _CUSTOM,     _NO_TYPE,  X,X,X,X,         _TYPELESS, _TYPELESS, _TYPELESS, _TYPELESS,          false,                  false,               false,            false,   false,  false,                  true),
			new( DXGI_FORMAT.DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE      ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                      D3DFCS_UNKNOWN,       [0,0,0,0],      8,              false, 1,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE ,DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,                   D3DFCS_UNKNOWN,       [0,0,0,0],      8,              false, 1,              1,               1,                _CUSTOM,     _FULL,     R,X,X,X,         _UNORM, _TYPELESS, _TYPELESS, _TYPELESS,             false,                  false,               false,            false,   false,  false,                  false),
			new( DXGI_FORMAT.DXGI_FORMAT_A4B4G4R4_UNORM                       ,DXGI_FORMAT.DXGI_FORMAT_A4B4G4R4_UNORM,               D3DFCS_A4B4G4R4,      [4,4,4,4],      16,             false, 1,              1,               1,                _STANDARD,   _FULL,     A,B,G,R,         _UNORM, _UNORM, _UNORM, _UNORM,                      false,                  false,               false,            false,   false,  false,                  false),
		];

		private static readonly string[] s_FormatNames = [
			// Name
			"UNKNOWN",
			"R32G32B32A32_TYPELESS",
				"R32G32B32A32_FLOAT",
				"R32G32B32A32_UINT",
				"R32G32B32A32_SINT",
			"R32G32B32_TYPELESS",
				"R32G32B32_FLOAT",
				"R32G32B32_UINT",
				"R32G32B32_SINT",
			"R16G16B16A16_TYPELESS",
				"R16G16B16A16_FLOAT",
				"R16G16B16A16_UNORM",
				"R16G16B16A16_UINT",
				"R16G16B16A16_SNORM",
				"R16G16B16A16_SINT",
			"R32G32_TYPELESS",
				"R32G32_FLOAT",
				"R32G32_UINT",
				"R32G32_SINT",
			"R32G8X24_TYPELESS",
				"D32_FLOAT_S8X24_UINT",
				"R32_FLOAT_X8X24_TYPELESS",
				"X32_TYPELESS_G8X24_UINT",
			"R10G10B10A2_TYPELESS",
				"R10G10B10A2_UNORM",
				"R10G10B10A2_UINT",
			"R11G11B10_FLOAT",
			"R8G8B8A8_TYPELESS",
				"R8G8B8A8_UNORM",
				"R8G8B8A8_UNORM_SRGB",
				"R8G8B8A8_UINT",
				"R8G8B8A8_SNORM",
				"R8G8B8A8_SINT",
			"R16G16_TYPELESS",
				"R16G16_FLOAT",
				"R16G16_UNORM",
				"R16G16_UINT",
				"R16G16_SNORM",
				"R16G16_SINT",
			"R32_TYPELESS",
				"D32_FLOAT",
				"R32_FLOAT",
				"R32_UINT",
				"R32_SINT",
			"R24G8_TYPELESS",
				"D24_UNORM_S8_UINT",
				"R24_UNORM_X8_TYPELESS",
				"X24_TYPELESS_G8_UINT",
			"R8G8_TYPELESS",
				"R8G8_UNORM",
				"R8G8_UINT",
				"R8G8_SNORM",
				"R8G8_SINT",
			"R16_TYPELESS",
				"R16_FLOAT",
				"D16_UNORM",
				"R16_UNORM",
				"R16_UINT",
				"R16_SNORM",
				"R16_SINT",
			"R8_TYPELESS",
				"R8_UNORM",
				"R8_UINT",
				"R8_SNORM",
				"R8_SINT",
			"A8_UNORM",
			"R1_UNORM",
			"R9G9B9E5_SHAREDEXP",
			"R8G8_B8G8_UNORM",
			"G8R8_G8B8_UNORM",
			"BC1_TYPELESS",
				"BC1_UNORM",
				"BC1_UNORM_SRGB",
			"BC2_TYPELESS",
				"BC2_UNORM",
				"BC2_UNORM_SRGB",
			"BC3_TYPELESS",
				"BC3_UNORM",
				"BC3_UNORM_SRGB",
			"BC4_TYPELESS",
				"BC4_UNORM",
				"BC4_SNORM",
			"BC5_TYPELESS",
				"BC5_UNORM",
				"BC5_SNORM",
			"B5G6R5_UNORM",
			"B5G5R5A1_UNORM",
			"B8G8R8A8_UNORM",
			"B8G8R8X8_UNORM",
			"R10G10B10_XR_BIAS_A2_UNORM",
			"B8G8R8A8_TYPELESS",
			   "B8G8R8A8_UNORM_SRGB",
			"B8G8R8X8_TYPELESS",
			   "B8G8R8X8_UNORM_SRGB",
			"BC6H_TYPELESS",
			   "BC6H_UF16",
			   "BC6H_SF16",
			"BC7_TYPELESS",
			   "BC7_UNORM",
			   "BC7_UNORM_SRGB",
			 "AYUV",
			 "Y410",
			 "Y416",
			 "NV12",
			 "P010",
			 "P016",
			 "420_OPAQUE",
			 "YUY2",
			 "Y210",
			 "Y216",
			 "NV11",
			 "AI44",
			 "IA44",
			 "P8",
			 "A8P8",
		];

		private static readonly int s_NumFormats = s_FormatNames.Length;

		public static HRESULT CalculateExtraPlanarRows(DXGI_FORMAT format, uint plane0Height, out uint totalHeight)
		{
			if (!Planar(format))
			{
				totalHeight = plane0Height;
				return HRESULT.S_OK;
			}

			totalHeight = 0;

			// blockWidth, blockHeight, and blockSize only reflect the size of plane 0. Each planar format has additonal planes that must be
			// counted. Each format increases size by another 0.5x, 1x, or 2x. Grab the number of "half allocation" increments so integer
			// math can be used to calculate the extra size.
			uint extraHalfHeight;
			uint round;

			switch (GetParentFormat(format))
			{
				case DXGI_FORMAT.DXGI_FORMAT_NV12:
				case DXGI_FORMAT.DXGI_FORMAT_P010:
				case DXGI_FORMAT.DXGI_FORMAT_P016:
				case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:
					extraHalfHeight = 1;
					round = 1;
					break;

				case DXGI_FORMAT.DXGI_FORMAT_NV11:
				case DXGI_FORMAT.DXGI_FORMAT_P208:
					extraHalfHeight = 2;
					round = 0;
					break;

				case DXGI_FORMAT.DXGI_FORMAT_V208:
					extraHalfHeight = 2;
					round = 1;
					break;

				case DXGI_FORMAT.DXGI_FORMAT_V408:
					extraHalfHeight = 4;
					round = 0;
					break;

				case DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS:
				case DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS:
					totalHeight = plane0Height;
					return HRESULT.S_OK;

				default:
					Debug.Assert(false);
					return HRESULT.S_OK;
			}

			return Safe_UIntMult(plane0Height, extraHalfHeight, out uint extraPlaneHeight).Failed
				|| Safe_UIntAdd(extraPlaneHeight, round, out extraPlaneHeight).Failed
				|| Safe_UIntAdd(plane0Height, extraPlaneHeight >> 1, out totalHeight).Failed
				? (HRESULT)INTSAFE_E_ARITHMETIC_OVERFLOW
				: (HRESULT)HRESULT.S_OK;
		}

		public static HRESULT CalculateMinimumRowMajorRowPitch(DXGI_FORMAT Format, uint Width, out uint RowPitch)
		{
			// Early out for DXGI_FORMAT_UNKNOWN special case.
			if (Format == DXGI_FORMAT.DXGI_FORMAT_UNKNOWN)
			{
				RowPitch = Width;
				return HRESULT.S_OK;
			}
			RowPitch = 0;

			uint WidthAlignment = GetWidthAlignment(Format);

			uint NumUnits;
			if (IsBlockCompressFormat(Format))
			{
				// This function calculates the minimum stride needed for a block row when the format is block compressed.The GetBitsPerUnit
				// value stored in the format table indicates the size of a compressed block for block compressed formats.
				Debug.Assert(WidthAlignment != 0);
				if (DivideAndRoundUp(Width, WidthAlignment, out NumUnits).Failed)
				{
					return INTSAFE_E_ARITHMETIC_OVERFLOW;
				}
			}
			else
			{
				// All other formats must have strides aligned to their width alignment requirements. The Width may not be aligned to the
				// WidthAlignment. This is not an error for this function as we expect to allow formats like NV12 to have odd dimensions in
				// the future.

				// The following alignement code expects only pow2 alignment requirements. Only block compressed formats currently have
				// non-pow2 alignment requriements.
				Debug.Assert(IsPow2(WidthAlignment));

				uint Mask = WidthAlignment - 1;
				if (Safe_UIntAdd(Width, Mask, out NumUnits).Failed)
				{
					return INTSAFE_E_ARITHMETIC_OVERFLOW;
				}

				NumUnits &= ~Mask;
			}

			if (Safe_UIntMult(NumUnits, GetBitsPerUnit(Format), out RowPitch).Failed)
			{
				return INTSAFE_E_ARITHMETIC_OVERFLOW;
			}

			// This must to always be Byte aligned.
			Debug.Assert((RowPitch & 7) == 0);
			RowPitch >>= 3;

			return HRESULT.S_OK;
		}

		public static HRESULT CalculateMinimumRowMajorSlicePitch(DXGI_FORMAT Format, uint TightRowPitch, uint Height, out uint SlicePitch)
		{
			SlicePitch = 0;
			if (Planar(Format))
			{
				return CalculateExtraPlanarRows(Format, Height, out var PlanarHeight).Failed
					? (HRESULT)INTSAFE_E_ARITHMETIC_OVERFLOW
					: Safe_UIntMult(TightRowPitch, PlanarHeight, out SlicePitch);
			}
			else if (Format == DXGI_FORMAT.DXGI_FORMAT_UNKNOWN)
			{
				return Safe_UIntMult(TightRowPitch, Height, out SlicePitch);
			}

			uint HeightAlignment = GetHeightAlignment(Format);

			// Caution Debug.Assert to make sure that no new format breaks this assumption that all HeightAlignment formats are BC or
			// Planar. This is to make sure that Height handled correctly for this calculation.
			Debug.Assert(HeightAlignment == 1 || IsBlockCompressFormat(Format));

			return DivideAndRoundUp(Height, HeightAlignment, out var HeightOfPacked).Failed || Safe_UIntMult(HeightOfPacked, TightRowPitch, out SlicePitch).Failed
				? (HRESULT)INTSAFE_E_ARITHMETIC_OVERFLOW : (HRESULT)HRESULT.S_OK;
		}

		public static HRESULT CalculateResourceSize(uint width, uint height, uint depth, DXGI_FORMAT format, uint mipLevels, uint subresources, out SizeT totalByteSize, [Out] D3D12_MEMCPY_DEST[]? pDst = null)
		{
			totalByteSize = 0;

			uint tableIndex = GetDetailTableIndexNoThrow(format);
			if (tableIndex == uint.MaxValue)
				return HRESULT.E_INVALIDARG;

			FORMAT_DETAIL formatDetail = s_FormatDetail[tableIndex];

			bool fIsBlockCompressedFormat = IsBlockCompressFormat(format);

			// No format currently requires depth alignment.
			Debug.Assert(formatDetail.DepthAlignment == 1);

			uint subWidth = width;
			uint subHeight = height;
			uint subDepth = depth;

			for (uint s = 0, iM = 0; s < subresources; ++s)
			{
				if (DivideAndRoundUp(subWidth, formatDetail.WidthAlignment, out var blockWidth).Failed)
				{
					return INTSAFE_E_ARITHMETIC_OVERFLOW;
				}

				uint blockSize, blockHeight;
				if (fIsBlockCompressedFormat)
				{
					if (DivideAndRoundUp(subHeight, formatDetail.HeightAlignment, out blockHeight).Failed)
					{
						return INTSAFE_E_ARITHMETIC_OVERFLOW;
					}

					// Block Compressed formats use BitsPerUnit as block size.
					blockSize = formatDetail.BitsPerUnit;
				}
				else
				{
					// The height ref must ref not be aligned to HeightAlign. As there is no plane pitch/stride, the expectation is that the
					// 2nd plane begins immediately after the first. The only formats with HeightAlignment other than 1 are planar or block
					// compressed, and block compressed is handled above.
					Debug.Assert(formatDetail.bPlanar || formatDetail.HeightAlignment == 1);
					blockHeight = subHeight;

					// Combined with the division os subWidth by the width alignment above, this helps achieve rounding the stride up to an
					// even multiple of block width. This is especially important for formats like NV12 and P208 whose chroma plane is wider
					// than the luma.
					blockSize = formatDetail.BitsPerUnit * formatDetail.WidthAlignment;
				}

				if (DXGI_FORMAT.DXGI_FORMAT_UNKNOWN == formatDetail.DXGIFormat)
				{
					blockSize = 8;
				}

				// Convert block width size to bytes.
				Debug.Assert((blockSize & 0x7) == 0);
				blockSize >>= 3;

				if (formatDetail.bPlanar && CalculateExtraPlanarRows(format, blockHeight, out blockHeight).Failed)
				{
					return INTSAFE_E_ARITHMETIC_OVERFLOW;
				}

				// Calculate rowPitch, depthPitch, and total subresource size.
				if (Safe_UIntMult(blockWidth, blockSize, out var rowPitch).Failed || Safe_UIntMult(blockHeight, rowPitch, out var depthPitch).Failed)
				{
					return INTSAFE_E_ARITHMETIC_OVERFLOW;
				}
				SizeT subresourceByteSize = (ulong)subDepth * depthPitch;

				if (pDst is not null)
				{
					D3D12_MEMCPY_DEST dst = pDst[s];

					// This data will be returned straight from the API to satisfy Map. So, strides/ alignment must be API-correct.
					dst.pData = (IntPtr)(long)totalByteSize;
					Debug.Assert(s != 0 || dst.pData == default);

					dst.RowPitch = rowPitch;
					dst.SlicePitch = depthPitch;
				}

				// Align the subresource size.
				Debug.Assert((MAP_ALIGN_REQUIREMENT & (MAP_ALIGN_REQUIREMENT - 1)) == 0, "This code expects MAP_ALIGN_REQUIREMENT to be a power of 2.");

				SizeT subresourceByteSizeAligned = subresourceByteSize + MAP_ALIGN_REQUIREMENT - 1;
				subresourceByteSizeAligned &= ~(MAP_ALIGN_REQUIREMENT - 1);
				totalByteSize += subresourceByteSizeAligned;

				// Iterate over mip levels and array elements
				if (++iM >= mipLevels)
				{
					iM = 0;

					subWidth = width;
					subHeight = height;
					subDepth = depth;
				}
				else
				{
					subWidth /= 1 == subWidth ? 1u : 2u;
					subHeight /= 1 == subHeight ? 1u : 2u;
					subDepth /= 1 == subDepth ? 1u : 2u;
				}
			}
			return HRESULT.S_OK;
		}

		public static bool CanBeCastEvenFullyTyped(DXGI_FORMAT Format, D3D_FEATURE_LEVEL fl) =>
			//SRGB can be cast away/back, and XR_BIAS can be cast to/from UNORM
			fl is not D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_1_0_GENERIC and not D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_1_0_CORE
&& Format switch
{
	DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM or DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB or
		DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM or DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM_SRGB => true,
	DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM or DXGI_FORMAT.DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM =>
		fl >= D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0,
	_ => false,
};

		public static bool DecodeHistogramAllowedForOutputFormatSupport(DXGI_FORMAT Format) =>

				   /* YUV 4:2:0 */
				   Format is DXGI_FORMAT.DXGI_FORMAT_NV12
				or DXGI_FORMAT.DXGI_FORMAT_P010
				or DXGI_FORMAT.DXGI_FORMAT_P016
				/* YUV 4:2:2 */
				or DXGI_FORMAT.DXGI_FORMAT_YUY2
				or DXGI_FORMAT.DXGI_FORMAT_Y210
				or DXGI_FORMAT.DXGI_FORMAT_Y216
				/* YUV 4:4:4 */
				or DXGI_FORMAT.DXGI_FORMAT_AYUV
				or DXGI_FORMAT.DXGI_FORMAT_Y410
				or DXGI_FORMAT.DXGI_FORMAT_Y416
			;

		public static bool DepthOnlyFormat(DXGI_FORMAT format) => format is DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT or DXGI_FORMAT.DXGI_FORMAT_D16_UNORM;

		public static bool DX9TextureFormat(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexThrow(Format)].bDX9TextureFormat;

		public static bool DX9VertexOrIndexFormat(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexThrow(Format)].bDX9VertexOrIndexFormat;

		public static bool FamilySupportsStencil(DXGI_FORMAT Format) => GetParentFormat(Format) is DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS or DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS;

		public static bool FloatAndNotFloatFormats(DXGI_FORMAT FormatA, DXGI_FORMAT FormatB)
		{
			uint NumComponents = Math.Min(GetNumComponentsInFormat(FormatA), GetNumComponentsInFormat(FormatB));
			for (uint c = 0; c < NumComponents; c++)
			{
				D3D_FORMAT_COMPONENT_INTERPRETATION fciA = GetFormatComponentInterpretation(FormatA, c);
				D3D_FORMAT_COMPONENT_INTERPRETATION fciB = GetFormatComponentInterpretation(FormatB, c);
				if (fciA != fciB && (fciA == D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_FLOAT || fciB == D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_FLOAT))
				{
					return true;
				}
			}
			return false;
		}

		public static bool FloatNormTextureFormat(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexThrow(Format)].bFloatNormFormat;

		public static bool FormatExists(DXGI_FORMAT Format) => GetFormat((uint)Format) != _BADFMT;

		public static bool FormatExistsInHeader(DXGI_FORMAT Format, bool bExternalHeader = true) => !(GetDetailTableIndex(Format) == (uint)_BADFMT || bExternalHeader && GetFormatDetail(Format)!.bInternal);

		public static void Get4KTileShape(ref D3D12_TILE_SHAPE pTileShape, DXGI_FORMAT Format, D3D12_RESOURCE_DIMENSION Dimension, uint SampleCount)
		{
			uint BPU = GetBitsPerUnit(Format);

			switch (Dimension)
			{
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_UNKNOWN:
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER:
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE1D:
					Debug.Assert(!IsBlockCompressFormat(Format));
					pTileShape.WidthInTexels = (BPU == 0) ? 4096 : 4096 * 8 / BPU;
					pTileShape.HeightInTexels = 1;
					pTileShape.DepthInTexels = 1;
					break;

				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE2D:
					pTileShape.DepthInTexels = 1;
					if (IsBlockCompressFormat(Format))
					{
						// Currently only supported block sizes are 64 and 128. These equations calculate the size in texels for a tile. It
						// relies on the fact that 16*16*16 blocks fit in a tile if the block size is 128 bits.
						Debug.Assert(BPU is 64 or 128);
						pTileShape.WidthInTexels = 16 * GetWidthAlignment(Format);
						pTileShape.HeightInTexels = 16 * GetHeightAlignment(Format);
						if (BPU == 64)
						{
							// If bits per block are 64 we double width so it takes up the full tile size. This is only true for BC1 and BC4
							Debug.Assert(Format is >= DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB or
								   >= DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM);
							pTileShape.WidthInTexels *= 2;
						}
					}
					else
					{
						if (BPU <= 8)
						{
							pTileShape.WidthInTexels = 64;
							pTileShape.HeightInTexels = 64;
						}
						else if (BPU <= 16)
						{
							pTileShape.WidthInTexels = 64;
							pTileShape.HeightInTexels = 32;
						}
						else if (BPU <= 32)
						{
							pTileShape.WidthInTexels = 32;
							pTileShape.HeightInTexels = 32;
						}
						else if (BPU <= 64)
						{
							pTileShape.WidthInTexels = 32;
							pTileShape.HeightInTexels = 16;
						}
						else if (BPU <= 128)
						{
							pTileShape.WidthInTexels = 16;
							pTileShape.HeightInTexels = 16;
						}
						else
						{
							Debug.Assert(false);
						}

						if (SampleCount <= 1)
						{ /* Do nothing */ }
						else if (SampleCount <= 2)
						{
							pTileShape.WidthInTexels /= 2;
							pTileShape.HeightInTexels /= 1;
						}
						else if (SampleCount <= 4)
						{
							pTileShape.WidthInTexels /= 2;
							pTileShape.HeightInTexels /= 2;
						}
						else if (SampleCount <= 8)
						{
							pTileShape.WidthInTexels /= 4;
							pTileShape.HeightInTexels /= 2;
						}
						else if (SampleCount <= 16)
						{
							pTileShape.WidthInTexels /= 4;
							pTileShape.HeightInTexels /= 4;
						}
						else
						{
							Debug.Assert(false);
						}

						Debug.Assert(GetWidthAlignment(Format) == 1);
						Debug.Assert(GetHeightAlignment(Format) == 1);
						Debug.Assert(GetDepthAlignment(Format) == 1);
					}

					break;

				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D:
					if (IsBlockCompressFormat(Format))
					{
						// Currently only supported block sizes are 64 and 128. These equations calculate the size in texels for a tile. It
						// relies on the fact that 16*16*16 blocks fit in a tile if the block size is 128 bits.
						Debug.Assert(BPU is 64 or 128);
						pTileShape.WidthInTexels = 8 * GetWidthAlignment(Format);
						pTileShape.HeightInTexels = 8 * GetHeightAlignment(Format);
						pTileShape.DepthInTexels = 4;
						if (BPU == 64)
						{
							// If bits per block are 64 we double width so it takes up the full tile size. This is only true for BC1 and BC4
							Debug.Assert(Format is >= DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB or
								   >= DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM);
							pTileShape.DepthInTexels *= 2;
						}
					}
					else
					{
						if (BPU <= 8)
						{
							pTileShape.WidthInTexels = 16;
							pTileShape.HeightInTexels = 16;
							pTileShape.DepthInTexels = 16;
						}
						else if (BPU <= 16)
						{
							pTileShape.WidthInTexels = 16;
							pTileShape.HeightInTexels = 16;
							pTileShape.DepthInTexels = 8;
						}
						else if (BPU <= 32)
						{
							pTileShape.WidthInTexels = 16;
							pTileShape.HeightInTexels = 8;
							pTileShape.DepthInTexels = 8;
						}
						else if (BPU <= 64)
						{
							pTileShape.WidthInTexels = 8;
							pTileShape.HeightInTexels = 8;
							pTileShape.DepthInTexels = 8;
						}
						else if (BPU <= 128)
						{
							pTileShape.WidthInTexels = 8;
							pTileShape.HeightInTexels = 8;
							pTileShape.DepthInTexels = 4;
						}
						else
						{
							Debug.Assert(false);
						}

						Debug.Assert(GetWidthAlignment(Format) == 1);
						Debug.Assert(GetHeightAlignment(Format) == 1);
						Debug.Assert(GetDepthAlignment(Format) == 1);
					}
					break;
			}
		}

		public static byte GetAddressingBitsPerAlignedSize(DXGI_FORMAT Format) => GetByteAlignment(Format) switch
		{
			1 => 0,
			2 => 1,
			4 => 2,
			8 => 3,
			16 => 4,
			// The format is not supported
			_ => byte.MaxValue,
		};

		public static uint GetBitsPerComponent(DXGI_FORMAT Format, uint AbsoluteComponentIndex) => AbsoluteComponentIndex <= 3
				? s_FormatDetail[GetDetailTableIndexNoThrow(Format)].BitsPerComponent?[AbsoluteComponentIndex] ?? 0
				: throw new ArgumentException("", nameof(AbsoluteComponentIndex));

		public static uint GetBitsPerElement(DXGI_FORMAT Format) => throw new NotSupportedException();

		public static uint GetBitsPerStencil(DXGI_FORMAT Format)
		{
			uint Index = GetDetailTableIndexThrow(Format);
			if (s_FormatDetail[Index].TypeLevel is not D3D_FORMAT_TYPE_LEVEL.D3DFTL_PARTIAL_TYPE and
				not D3D_FORMAT_TYPE_LEVEL.D3DFTL_FULL_TYPE)
			{
				return 0;
			}
			for (uint comp = 0; comp < 4; comp++)
			{
				var name = comp switch
				{
					0 => s_FormatDetail[Index].ComponentName0,
					1 => s_FormatDetail[Index].ComponentName1,
					2 => s_FormatDetail[Index].ComponentName2,
					3 => s_FormatDetail[Index].ComponentName3,
					_ => D3D_FORMAT_COMPONENT_NAME.D3DFCN_D,
				};
				if (name == D3D_FORMAT_COMPONENT_NAME.D3DFCN_S)
				{
					return s_FormatDetail[Index].BitsPerComponent?[comp] ?? 0;
				}
			}
			return 0;
		}

		public static uint GetBitsPerUnit(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].BitsPerUnit;

		public static uint GetBitsPerUnitThrow(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexThrow(Format)].BitsPerUnit;

		public static uint GetByteAlignment(DXGI_FORMAT Format)
		{
			var bits = GetBitsPerUnit(Format);
			if (!IsBlockCompressFormat(Format))
				bits *= GetWidthAlignment(Format) * GetHeightAlignment(Format) * GetDepthAlignment(Format);
			Debug.Assert((bits & 0x7) == 0);
			return bits >> 3;
		}

		public static D3D_FORMAT_COMPONENT_NAME GetComponentName(DXGI_FORMAT Format, uint AbsoluteComponentIndex) => AbsoluteComponentIndex switch
		{
			0 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentName0,
			1 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentName1,
			2 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentName2,
			3 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentName3,
			_ => throw new ArgumentException("", nameof(AbsoluteComponentIndex)),
		};

		public static uint GetDepthAlignment(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].DepthAlignment;

		public static uint GetDetailTableIndex(DXGI_FORMAT Format)
		{
			if ((uint)Format < s_FormatDetail.Length)
			{
				Debug.Assert(s_FormatDetail[(uint)Format].DXGIFormat == Format);
				return (uint)Format;
			}
			return (uint)_BADFMT;
		}

		public static uint GetDetailTableIndexNoThrow(DXGI_FORMAT Format)
		{
			uint Index = GetDetailTableIndex(Format);
			Debug.Assert(uint.MaxValue != Index);
			return Index;
		}

		public static uint GetDetailTableIndexThrow(DXGI_FORMAT Format)
		{
			uint Index = GetDetailTableIndex(Format);
			return uint.MaxValue != Index ? Index : throw new ArgumentException("", nameof(Format));
		}

		public static DXGI_FORMAT GetFormat(SizeT Index) => Index < s_NumFormats ? s_FormatDetail[Index].DXGIFormat : _BADFMT;

		public static DXGI_FORMAT[]? GetFormatCastSet(DXGI_FORMAT Format) => s_FormatDetail[(uint)Format].pDefaultFormatCastSet;

		public static D3D_FORMAT_COMPONENT_INTERPRETATION GetFormatComponentInterpretation(DXGI_FORMAT Format, uint AbsoluteComponentIndex) => AbsoluteComponentIndex switch
		{
			0 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentInterpretation0,
			1 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentInterpretation1,
			2 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentInterpretation2,
			3 => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].ComponentInterpretation3,
			_ => throw new ArgumentException("", nameof(AbsoluteComponentIndex)),
		};

		public static void GetFormatReturnTypes(DXGI_FORMAT Format, out D3D_FORMAT_COMPONENT_INTERPRETATION[] pInterpretations)
		{
			uint Index = GetDetailTableIndexThrow(Format);
			pInterpretations = [ s_FormatDetail[Index].ComponentInterpretation0, s_FormatDetail[Index].ComponentInterpretation1,
				s_FormatDetail[Index].ComponentInterpretation2, s_FormatDetail[Index].ComponentInterpretation3];
		}

		public static FORMAT_DETAIL[] GetFormatTable() => s_FormatDetail;

		public static uint GetHeightAlignment(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].HeightAlignment;

		public static D3D_FEATURE_LEVEL GetHighestDefinedFeatureLevel() => D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_2;

		public static D3D_FORMAT_LAYOUT GetLayout(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].Layout;

		public static void GetMipDimensions(byte mipSlice, ref ulong pWidth, [Optional] ref ulong? pHeight, [Optional] ref ulong? pDepth)
		{
			uint denominator = (uint)(1 << mipSlice); // 2 ^ subresource
			ulong mipWidth = pWidth / denominator;
			ulong mipHeight = pHeight.HasValue ? pHeight.Value / denominator : 1;
			ulong mipDepth = pDepth.HasValue ? pDepth.Value / denominator : 1;

			// Adjust dimensions for degenerate mips
			if (mipHeight == 0)
				mipHeight = 1;
			if (mipWidth == 0)
				mipWidth = 1;
			if (mipDepth == 0)
				mipDepth = 1;

			pWidth = mipWidth;
			if (pHeight.HasValue) pHeight = mipHeight;
			if (pDepth.HasValue) pDepth = mipDepth;
		}

		public static string GetName(DXGI_FORMAT Format, bool bHideInternalFormats = true) =>
			(uint)_BADFMT == GetDetailTableIndex(Format) || bHideInternalFormats && GetFormatDetail(Format)!.bInternal ? "Unrecognized" : s_FormatNames[GetDetailTableIndex(Format)];

		public static uint GetNumComponentsInFormat(DXGI_FORMAT Format)
		{
			uint n = 0;
			uint Index = GetDetailTableIndexThrow(Format);
			for (uint comp = 0; comp < 4; comp++)
			{
				var name = comp switch
				{
					0 => s_FormatDetail[Index].ComponentName0,
					1 => s_FormatDetail[Index].ComponentName1,
					2 => s_FormatDetail[Index].ComponentName2,
					3 => s_FormatDetail[Index].ComponentName3,
					_ => D3D_FORMAT_COMPONENT_NAME.D3DFCN_D,
				};
				if (name != D3D_FORMAT_COMPONENT_NAME.D3DFCN_X)
				{
					n++;
				}
			}
			return n;
		}

		public static int GetNumFormats() => s_NumFormats;

		public static DXGI_FORMAT GetParentFormat(DXGI_FORMAT Format) => s_FormatDetail[(uint)Format].ParentFormat;

		public static byte GetPlaneCount(DXGI_FORMAT Format) => GetParentFormat(Format) switch
		{
			DXGI_FORMAT.DXGI_FORMAT_NV12 or DXGI_FORMAT.DXGI_FORMAT_NV11 or DXGI_FORMAT.DXGI_FORMAT_P208 or DXGI_FORMAT.DXGI_FORMAT_P016 or DXGI_FORMAT.DXGI_FORMAT_P010 or DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS or DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS => 2,
			DXGI_FORMAT.DXGI_FORMAT_V208 or DXGI_FORMAT.DXGI_FORMAT_V408 => 3,
			_ => 1,
		};

		public static byte GetPlaneSliceFromViewFormat(DXGI_FORMAT ResourceFormat, DXGI_FORMAT ViewFormat)
		{
			switch (GetParentFormat(ResourceFormat))
			{
				case DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS:
					switch (ViewFormat)
					{
						case DXGI_FORMAT.DXGI_FORMAT_R24_UNORM_X8_TYPELESS:
							return 0;

						case DXGI_FORMAT.DXGI_FORMAT_X24_TYPELESS_G8_UINT:
							return 1;

						default:
							Debug.Assert(false);
							break;
					}
					break;

				case DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS:
					switch (ViewFormat)
					{
						case DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS:
							return 0;

						case DXGI_FORMAT.DXGI_FORMAT_X32_TYPELESS_G8X24_UINT:
							return 1;

						default:
							Debug.Assert(false);
							break;
					}
					break;

				case DXGI_FORMAT.DXGI_FORMAT_NV12:
				case DXGI_FORMAT.DXGI_FORMAT_NV11:
				case DXGI_FORMAT.DXGI_FORMAT_P208:
					switch (ViewFormat)
					{
						case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
						case DXGI_FORMAT.DXGI_FORMAT_R8_UINT:
							return 0;

						case DXGI_FORMAT.DXGI_FORMAT_R8G8_UNORM:
						case DXGI_FORMAT.DXGI_FORMAT_R8G8_UINT:
							return 1;

						default:
							Debug.Assert(false);
							break;
					}
					break;

				case DXGI_FORMAT.DXGI_FORMAT_P016:
				case DXGI_FORMAT.DXGI_FORMAT_P010:
					switch (ViewFormat)
					{
						case DXGI_FORMAT.DXGI_FORMAT_R16_UNORM:
						case DXGI_FORMAT.DXGI_FORMAT_R16_UINT:
							return 0;

						case DXGI_FORMAT.DXGI_FORMAT_R16G16_UNORM:
						case DXGI_FORMAT.DXGI_FORMAT_R16G16_UINT:
						case DXGI_FORMAT.DXGI_FORMAT_R32_UINT:
							return 1;

						default:
							Debug.Assert(false);
							break;
					}
					break;

				default:
					break;
			}
			return 0;
		}

		public static void GetPlaneSubsampledSizeAndFormatForCopyableLayout(uint PlaneSlice, DXGI_FORMAT Format, uint Width, uint Height,
			out DXGI_FORMAT PlaneFormat, out uint MinPlanePitchWidth, out uint PlaneWidth, out uint PlaneHeight)
		{
			DXGI_FORMAT ParentFormat = GetParentFormat(Format);
			MinPlanePitchWidth = PlaneHeight = PlaneWidth = 0;
			PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN;

			if (Planar(ParentFormat))
			{
				switch (ParentFormat)
				{
					// YCbCr 4:2:0
					case DXGI_FORMAT.DXGI_FORMAT_NV12:
						switch (PlaneSlice)
						{
							case 0:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS;
								PlaneWidth = Width;
								PlaneHeight = Height;
								break;

							case 1:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS;
								PlaneWidth = (Width + 1) >> 1;
								PlaneHeight = (Height + 1) >> 1;
								break;

							default:
								Debug.Assert(false); break;
						};

						MinPlanePitchWidth = PlaneWidth;
						break;

					case DXGI_FORMAT.DXGI_FORMAT_P010:
					case DXGI_FORMAT.DXGI_FORMAT_P016:
						switch (PlaneSlice)
						{
							case 0:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R16_TYPELESS;
								PlaneWidth = Width;
								PlaneHeight = Height;
								break;

							case 1:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS;
								PlaneWidth = (Width + 1) >> 1;
								PlaneHeight = (Height + 1) >> 1;
								break;

							default:
								Debug.Assert(false); break;
						};

						MinPlanePitchWidth = PlaneWidth;
						break;

					// YCbCr 4:2:2
					case DXGI_FORMAT.DXGI_FORMAT_P208:
						switch (PlaneSlice)
						{
							case 0:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS;
								PlaneWidth = Width;
								PlaneHeight = Height;
								break;

							case 1:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS;
								PlaneWidth = (Width + 1) >> 1;
								PlaneHeight = Height;
								break;

							default:
								Debug.Assert(false); break;
						};

						MinPlanePitchWidth = PlaneWidth;
						break;

					// YCbCr 4:4:0
					case DXGI_FORMAT.DXGI_FORMAT_V208:
						PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS;
						switch (PlaneSlice)
						{
							case 0:
								PlaneWidth = Width;
								PlaneHeight = Height;
								break;

							case 1:
							case 2:
								PlaneWidth = Width;
								PlaneHeight = (Height + 1) >> 1;
								break;

							default:
								Debug.Assert(false); break;
						};

						MinPlanePitchWidth = PlaneWidth;
						break;

					// YCbCr 4:4:4
					case DXGI_FORMAT.DXGI_FORMAT_V408:

						switch (PlaneSlice)
						{
							case 0:
							case 1:
							case 2:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS;
								PlaneWidth = Width;
								PlaneHeight = Height;
								MinPlanePitchWidth = PlaneWidth;
								break;

							default:
								Debug.Assert(false); break;
						};
						break;

					// YCbCr 4:1:1
					case DXGI_FORMAT.DXGI_FORMAT_NV11:
						switch (PlaneSlice)
						{
							case 0:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS;
								PlaneWidth = Width;
								PlaneHeight = Height;
								MinPlanePitchWidth = Width;
								break;

							case 1:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8G8_TYPELESS;
								PlaneWidth = (Width + 3) >> 2;
								PlaneHeight = Height;

								// NV11 has unused padding to the right of the chroma plane in the RowMajor (linear) copyable layout.
								MinPlanePitchWidth = (Width + 1) >> 1;
								break;

							default:
								Debug.Assert(false); break;
						};

						break;

					case DXGI_FORMAT.DXGI_FORMAT_R32G8X24_TYPELESS:
					case DXGI_FORMAT.DXGI_FORMAT_R24G8_TYPELESS:
						switch (PlaneSlice)
						{
							case 0:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS;
								PlaneWidth = Width;
								PlaneHeight = Height;
								MinPlanePitchWidth = Width;
								break;

							case 1:
								PlaneFormat = DXGI_FORMAT.DXGI_FORMAT_R8_TYPELESS;
								PlaneWidth = Width;
								PlaneHeight = Height;
								MinPlanePitchWidth = Width;
								break;

							default:
								Debug.Assert(false); break;
						};
						break;

					default:
						Debug.Assert(false); break;
				};
			}
			else
			{
				Debug.Assert(PlaneSlice == 0);
				PlaneFormat = Format;
				PlaneWidth = Width;
				PlaneHeight = Height;
				MinPlanePitchWidth = PlaneWidth;
			}
		}

		public static void GetTileShape(ref D3D12_TILE_SHAPE pTileShape, DXGI_FORMAT Format, D3D12_RESOURCE_DIMENSION Dimension, uint SampleCount)
		{
			uint BPU = GetBitsPerUnit(Format);

			switch (Dimension)
			{
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_UNKNOWN:
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER:
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE1D:
					Debug.Assert(!IsBlockCompressFormat(Format));
					pTileShape.WidthInTexels = (BPU == 0) ? D3D12_TILED_RESOURCE_TILE_SIZE_IN_BYTES : D3D12_TILED_RESOURCE_TILE_SIZE_IN_BYTES * 8 / BPU;
					pTileShape.HeightInTexels = 1;
					pTileShape.DepthInTexels = 1;
					break;

				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE2D:
					if (IsBlockCompressFormat(Format))
					{
						// Currently only supported block sizes are 64 and 128. These equations calculate the size in texels for a tile. It
						// relies on the fact that ref 64 64 blocks fit in a tile if the block size is 128 bits.
						Debug.Assert(BPU is 64 or 128);
						pTileShape.WidthInTexels = 64 * GetWidthAlignment(Format);
						pTileShape.HeightInTexels = 64 * GetHeightAlignment(Format);
						pTileShape.DepthInTexels = 1;
						if (BPU == 64)
						{
							// If bits per block are 64 we double width so it takes up the full tile size. This is only true for BC1 and BC4
							Debug.Assert(Format is >= DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB or
								>= DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM);
							pTileShape.WidthInTexels *= 2;
						}
					}
					else
					{
						pTileShape.DepthInTexels = 1;
						if (BPU <= 8)
						{
							pTileShape.WidthInTexels = 256;
							pTileShape.HeightInTexels = 256;
						}
						else if (BPU <= 16)
						{
							pTileShape.WidthInTexels = 256;
							pTileShape.HeightInTexels = 128;
						}
						else if (BPU <= 32)
						{
							pTileShape.WidthInTexels = 128;
							pTileShape.HeightInTexels = 128;
						}
						else if (BPU <= 64)
						{
							pTileShape.WidthInTexels = 128;
							pTileShape.HeightInTexels = 64;
						}
						else if (BPU <= 128)
						{
							pTileShape.WidthInTexels = 64;
							pTileShape.HeightInTexels = 64;
						}
						else
						{
							Debug.Assert(false);
						}

						if (SampleCount <= 1)
						{ }
						else if (SampleCount <= 2)
						{
							pTileShape.WidthInTexels /= 2;
							pTileShape.HeightInTexels /= 1;
						}
						else if (SampleCount <= 4)
						{
							pTileShape.WidthInTexels /= 2;
							pTileShape.HeightInTexels /= 2;
						}
						else if (SampleCount <= 8)
						{
							pTileShape.WidthInTexels /= 4;
							pTileShape.HeightInTexels /= 2;
						}
						else if (SampleCount <= 16)
						{
							pTileShape.WidthInTexels /= 4;
							pTileShape.HeightInTexels /= 4;
						}
						else
						{
							Debug.Assert(false);
						}
					}
					break;

				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D:
					if (IsBlockCompressFormat(Format))
					{
						// Currently only supported block sizes are 64 and 128. These equations calculate the size in texels for a tile. It
						// relies on the fact that ref 16 ref 16 16 blocks fit in a tile if the block size is 128 bits.
						Debug.Assert(BPU is 64 or 128);
						pTileShape.WidthInTexels = 16 * GetWidthAlignment(Format);
						pTileShape.HeightInTexels = 16 * GetHeightAlignment(Format);
						pTileShape.DepthInTexels = 16 * GetDepthAlignment(Format);
						if (BPU == 64)
						{
							// If bits per block are 64 we double width so it takes up the full tile size. This is only true for BC1 and BC4
							Debug.Assert(Format is >= DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB or
								>= DXGI_FORMAT.DXGI_FORMAT_BC4_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC4_SNORM);
							pTileShape.WidthInTexels *= 2;
						}
					}
					else if (Format is DXGI_FORMAT.DXGI_FORMAT_R8G8_B8G8_UNORM or DXGI_FORMAT.DXGI_FORMAT_G8R8_G8B8_UNORM)
					{
						//RGBG and GRGB are treated as 2x1 block format
						pTileShape.WidthInTexels = 64;
						pTileShape.HeightInTexels = 32;
						pTileShape.DepthInTexels = 16;
					}
					else
					{
						// Not a block format so BPU is bits per pixel.
						Debug.Assert(GetWidthAlignment(Format) == 1 && GetHeightAlignment(Format) == 1 && GetDepthAlignment(Format) != 0);
						switch (BPU)
						{
							case 8:
								pTileShape.WidthInTexels = 64;
								pTileShape.HeightInTexels = 32;
								pTileShape.DepthInTexels = 32;
								break;

							case 16:
								pTileShape.WidthInTexels = 32;
								pTileShape.HeightInTexels = 32;
								pTileShape.DepthInTexels = 32;
								break;

							case 32:
								pTileShape.WidthInTexels = 32;
								pTileShape.HeightInTexels = 32;
								pTileShape.DepthInTexels = 16;
								break;

							case 64:
								pTileShape.WidthInTexels = 32;
								pTileShape.HeightInTexels = 16;
								pTileShape.DepthInTexels = 16;
								break;

							case 128:
								pTileShape.WidthInTexels = 16;
								pTileShape.HeightInTexels = 16;
								pTileShape.DepthInTexels = 16;
								break;
						}
					}
					break;
			}
		}

		public static D3D_FORMAT_TYPE_LEVEL GetTypeLevel(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].TypeLevel;

		public static uint GetWidthAlignment(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].WidthAlignment;

		public static void GetYCbCrChromaSubsampling(DXGI_FORMAT Format, out uint HorizontalSubsampling, out uint VerticalSubsampling)
		{
			switch (Format)
			{
				// YCbCr 4:2:0
				case DXGI_FORMAT.DXGI_FORMAT_NV12:
				case DXGI_FORMAT.DXGI_FORMAT_P010:
				case DXGI_FORMAT.DXGI_FORMAT_P016:
				case DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE:
					HorizontalSubsampling = 2;
					VerticalSubsampling = 2;
					break;

				// YCbCr 4:2:2
				case DXGI_FORMAT.DXGI_FORMAT_P208:
				case DXGI_FORMAT.DXGI_FORMAT_YUY2:
				case DXGI_FORMAT.DXGI_FORMAT_Y210:
					HorizontalSubsampling = 2;
					VerticalSubsampling = 1;
					break;

				// YCbCr 4:4:0
				case DXGI_FORMAT.DXGI_FORMAT_V208:
					HorizontalSubsampling = 1;
					VerticalSubsampling = 2;
					break;

				// YCbCr 4:4:4
				case DXGI_FORMAT.DXGI_FORMAT_AYUV:
				case DXGI_FORMAT.DXGI_FORMAT_V408:
				case DXGI_FORMAT.DXGI_FORMAT_Y410:
				case DXGI_FORMAT.DXGI_FORMAT_Y416:
				// Fallthrough

				// YCbCr palletized 4:4:4:
				case DXGI_FORMAT.DXGI_FORMAT_AI44:
				case DXGI_FORMAT.DXGI_FORMAT_IA44:
				case DXGI_FORMAT.DXGI_FORMAT_P8:
				case DXGI_FORMAT.DXGI_FORMAT_A8P8:
					HorizontalSubsampling = 1;
					VerticalSubsampling = 1;
					break;

				// YCbCr 4:1:1
				case DXGI_FORMAT.DXGI_FORMAT_NV11:
					HorizontalSubsampling = 4;
					VerticalSubsampling = 1;
					break;

				default:
					// All YCbCr formats should be in this list.
					Debug.Assert(!YUV(Format));
					HorizontalSubsampling = 1;
					VerticalSubsampling = 1;
					break;
			};
		}

		public static bool IsBlockCompressFormat(DXGI_FORMAT Format) => Format is >= DXGI_FORMAT.DXGI_FORMAT_BC1_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC5_SNORM or
																			>= DXGI_FORMAT.DXGI_FORMAT_BC6H_TYPELESS and <= DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB;

		public static bool IsSRGBFormat(DXGI_FORMAT Format)
		{
			uint Index = GetDetailTableIndex(Format);
			return (uint)_BADFMT != Index && s_FormatDetail[Index].SRGBFormat;
		}

		public static bool IsSupportedTextureDisplayableFormat(DXGI_FORMAT Format, bool bMediaFormatOnly) => bMediaFormatOnly
				? false || Format == DXGI_FORMAT.DXGI_FORMAT_NV12 || Format == DXGI_FORMAT.DXGI_FORMAT_YUY2
				: false // eases evolution
					|| Format == DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM
						|| Format == DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM
						|| Format == DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT
						|| Format == DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_UNORM
						|| Format == DXGI_FORMAT.DXGI_FORMAT_NV12
						|| Format == DXGI_FORMAT.DXGI_FORMAT_YUY2;

		public static bool MotionEstimatorAllowedInputFormat(DXGI_FORMAT Format) => Format == DXGI_FORMAT.DXGI_FORMAT_NV12;

		public static bool NonOpaquePlanar(DXGI_FORMAT Format) => Planar(Format) && !Opaque(Format);

		public static uint NonOpaquePlaneCount(DXGI_FORMAT Format)
		{
			if (NonOpaquePlanar(Format))
			{
				// V208 and V408 are the only 3-plane formats.
				return (Format is DXGI_FORMAT.DXGI_FORMAT_V208 or DXGI_FORMAT.DXGI_FORMAT_V408) ? 3u : 2u;
			}
			return 1;
		}

		public static bool Opaque(DXGI_FORMAT Format) => Format == DXGI_FORMAT.DXGI_FORMAT_420_OPAQUE;

		// Legacy function used to support D3D10on9 only. Do not use.
		public static bool Planar(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].bPlanar;

		public static uint Sequential2AbsoluteComponentIndex(DXGI_FORMAT Format, uint SequentialComponentIndex)
		{
			uint n = 0;
			uint Index = GetDetailTableIndexThrow(Format);
			for (uint comp = 0; comp < 4; comp++)
			{
				var name = comp switch
				{
					0 => s_FormatDetail[Index].ComponentName0,
					1 => s_FormatDetail[Index].ComponentName1,
					2 => s_FormatDetail[Index].ComponentName2,
					3 => s_FormatDetail[Index].ComponentName3,
					_ => D3D_FORMAT_COMPONENT_NAME.D3DFCN_D,
				};
				if (name != D3D_FORMAT_COMPONENT_NAME.D3DFCN_X)
				{
					if (SequentialComponentIndex == n)
					{
						return comp;
					}
					n++;
				}
			}
			return uint.MaxValue;
		}

		public static bool SNORMAndUNORMFormats(DXGI_FORMAT FormatA, DXGI_FORMAT FormatB)
		{
			uint NumComponents = Math.Min(GetNumComponentsInFormat(FormatA), GetNumComponentsInFormat(FormatB));
			for (uint c = 0; c < NumComponents; c++)
			{
				D3D_FORMAT_COMPONENT_INTERPRETATION fciA = GetFormatComponentInterpretation(FormatA, c);
				D3D_FORMAT_COMPONENT_INTERPRETATION fciB = GetFormatComponentInterpretation(FormatB, c);
				if (fciA == D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_SNORM && fciB == D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_UNORM ||
					fciB == D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_SNORM && fciA == D3D_FORMAT_COMPONENT_INTERPRETATION.D3DFCI_UNORM)
				{
					return true;
				}
			}
			return false;
		}

		public static bool SupportsSamplerFeedback(DXGI_FORMAT Format) => Format is DXGI_FORMAT.DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE or DXGI_FORMAT.DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE;

		public static bool ValidCastToR32UAV(DXGI_FORMAT from, DXGI_FORMAT to) =>
			// Allow casting of 32 bit formats to R32_*
			to is DXGI_FORMAT.DXGI_FORMAT_R32_UINT or DXGI_FORMAT.DXGI_FORMAT_R32_SINT or DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT
				&& from is
					DXGI_FORMAT.DXGI_FORMAT_R10G10B10A2_TYPELESS or
					DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_TYPELESS or
					DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_TYPELESS or
					DXGI_FORMAT.DXGI_FORMAT_B8G8R8X8_TYPELESS or
					DXGI_FORMAT.DXGI_FORMAT_R16G16_TYPELESS or
					DXGI_FORMAT.DXGI_FORMAT_R32_TYPELESS
				;

		public static bool YUV(DXGI_FORMAT Format) => s_FormatDetail[GetDetailTableIndexNoThrow(Format)].bYUV;

		private static HRESULT DivideAndRoundUp(uint dividend, uint divisor, out uint result)
		{
			HRESULT hr = Safe_UIntAdd(dividend, divisor - 1, out var adjustedDividend);
			result = hr.Succeeded ? (adjustedDividend / divisor) : 0;
			return hr;
		}

		private static FORMAT_DETAIL? GetFormatDetail(DXGI_FORMAT Format)
		{
			var Index = GetDetailTableIndex(Format);
			return Index == uint.MaxValue ? default : s_FormatDetail[Index];
		}

		private static bool IsPow2(uint Val) => 0 == (Val & (Val - 1));

		private static HRESULT Safe_UIntAdd(uint uAugend, uint uAddend, out uint puResult)
		{
			if (uAugend + uAddend >= uAugend)
			{
				puResult = uAugend + uAddend;
				return HRESULT.S_OK;
			}
			puResult = uint.MaxValue;
			return HRESULT.E_FAIL;
		}

		// uint multiplication
		private static HRESULT Safe_UIntMult(uint uMultiplicand, uint uMultiplier, out uint puResult)
		{
			ulong ull64Result = uMultiplicand * (ulong)uMultiplier;

			if (ull64Result <= uint.MaxValue)
			{
				puResult = (uint)ull64Result;
				return HRESULT.S_OK;
			}
			puResult = uint.MaxValue;
			return HRESULT.E_FAIL;
		}

		public class FORMAT_DETAIL(DXGI.DXGI_FORMAT DXGIFormat, DXGI.DXGI_FORMAT ParentFormat, DXGI.DXGI_FORMAT[]? pDefaultFormatCastSet, byte[]? BitsPerComponent,
																																																																																																																																							byte BitsPerUnit, bool SRGBFormat, uint WidthAlignment, uint HeightAlignment, uint DepthAlignment, DXGI.D3D_FORMAT_LAYOUT Layout,
			DXGI.D3D_FORMAT_TYPE_LEVEL TypeLevel, DXGI.D3D_FORMAT_COMPONENT_NAME ComponentName0, DXGI.D3D_FORMAT_COMPONENT_NAME ComponentName1,
			DXGI.D3D_FORMAT_COMPONENT_NAME ComponentName2, DXGI.D3D_FORMAT_COMPONENT_NAME ComponentName3, DXGI.D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation0,
			DXGI.D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation1, DXGI.D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation2,
			DXGI.D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation3, bool bDX9VertexOrIndexFormat, bool bDX9TextureFormat, bool bFloatNormFormat,
			bool bPlanar, bool bYUV, bool bDependantFormatCastSet, bool bInternal)
		{
			public bool bDependantFormatCastSet = bDependantFormatCastSet;
			public bool bDX9TextureFormat = bDX9TextureFormat;
			public bool bDX9VertexOrIndexFormat = bDX9VertexOrIndexFormat;
			public bool bFloatNormFormat = bFloatNormFormat;

			// This indicates that the format cast set is dependent on FL/driver version
			public bool bInternal = bInternal;

			public byte[]? BitsPerComponent = BitsPerComponent;

			// only used for D3DFTL_PARTIAL_TYPE or FULL_TYPE
			public byte BitsPerUnit = BitsPerUnit;

			public bool bPlanar = bPlanar;
			public bool bYUV = bYUV;
			public D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation0 = ComponentInterpretation0;

			// only used for D3DFTL_FULL_TYPE
			public D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation1 = ComponentInterpretation1;

			// only used for D3DFTL_FULL_TYPE
			public D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation2 = ComponentInterpretation2;

			// only used for D3DFTL_FULL_TYPE
			public D3D_FORMAT_COMPONENT_INTERPRETATION ComponentInterpretation3 = ComponentInterpretation3;

			public D3D_FORMAT_COMPONENT_NAME ComponentName0 = ComponentName0;

			// RED ... only used for D3DFTL_PARTIAL_TYPE or FULL_TYPE
			public D3D_FORMAT_COMPONENT_NAME ComponentName1 = ComponentName1;

			// GREEN ... only used for D3DFTL_PARTIAL_TYPE or FULL_TYPE
			public D3D_FORMAT_COMPONENT_NAME ComponentName2 = ComponentName2;

			// BLUE ... only used for D3DFTL_PARTIAL_TYPE or FULL_TYPE
			public D3D_FORMAT_COMPONENT_NAME ComponentName3 = ComponentName3;

			public uint DepthAlignment = DepthAlignment;
			public DXGI_FORMAT DXGIFormat = DXGIFormat;
			public uint HeightAlignment = HeightAlignment;

			// Top level dimensions must be a multiple of these values.
			public D3D_FORMAT_LAYOUT Layout = Layout;

			public DXGI_FORMAT ParentFormat = ParentFormat;
			public DXGI_FORMAT[]? pDefaultFormatCastSet = pDefaultFormatCastSet; // This is dependent on FL/driver version, but is here to save a lot of space
			public bool SRGBFormat = SRGBFormat;
			public D3D_FORMAT_TYPE_LEVEL TypeLevel = TypeLevel;
			public uint WidthAlignment = WidthAlignment; // number of texels to align to in a mip level.
														 // ALPHA ... only used for D3DFTL_PARTIAL_TYPE or FULL_TYPE only used for D3DFTL_FULL_TYPE
		}
	};
}