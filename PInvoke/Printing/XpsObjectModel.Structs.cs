using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class XpsObjectModel
{
	/// <summary>The contents of the XPS_COLOR structure when the colorType is <c>XPS_COLOR_TYPE_CONTEXT</c>.</summary>
	/// <remarks>For information about how to interpret or apply the values in this structure's members, see the XML Paper Specification.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_color typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0024 { XPS_COLOR_TYPE colorType; union { struct { UINT8 alpha; UINT8 red; UINT8 green;
	// UINT8 blue; } sRGB; struct { FLOAT alpha; FLOAT red; FLOAT green; FLOAT blue; } scRGB; struct { UINT8 channelCount; FLOAT
	// channels[9]; } context; } value; __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0028 __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0028;
	// } XPS_COLOR;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "76dcabb0-2407-4877-9f52-100883746695")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 44)]
	public struct XPS_COLOR
	{
		/// <summary/>
		[FieldOffset(0)]
		public XPS_COLOR_TYPE colorType;

		/// <summary>The contents of the <c>XPS_COLOR</c> structure when the colorType is <c>XPS_COLOR_TYPE_SRGB</c>.</summary>
		[FieldOffset(4)]
		public XPS_COLOR_TYPE_SRGB sRGB;

		/// <summary>The contents of the <c>XPS_COLOR</c> structure when the colorType is <c>XPS_COLOR_TYPE_SCRGB</c>.</summary>
		[FieldOffset(4)]
		public XPS_COLOR_TYPE_SCRGB scRGB;

		/// <summary>The contents of the XPS_COLOR structure when the colorType is XPS_COLOR_TYPE_CONTEXT.</summary>
		[FieldOffset(4)]
		public XPS_COLOR_TYPE_CONTEXT context;

		/// <summary>The contents of the <c>XPS_COLOR</c> structure when the colorType is <c>XPS_COLOR_TYPE_SCRGB</c>.</summary>
		/// <remarks>For information about how to interpret or apply the values of this structure's members, see the XML Paper Specification.</remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/dd372943(v=vs.85)
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct XPS_COLOR_TYPE_SCRGB
		{
			/// <summary>The floating-point value of the alpha (transparency) channel.</summary>
			public float alpha;

			/// <summary>The floating-point value of the red color channel.</summary>
			public float red;

			/// <summary>The floating-point value of the greeen color channel.</summary>
			public float green;

			/// <summary>The floating-point value of the blue color channel.</summary>
			public float blue;
		}

		/// <summary>The contents of the XPS_COLOR structure when the colorType is XPS_COLOR_TYPE_CONTEXT.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct XPS_COLOR_TYPE_CONTEXT
		{
			/// <summary>The number of color channels, including the alpha channel.</summary>
			public byte channelCount;

			private float channel0;
			private float channel1;
			private float channel2;
			private float channel3;
			private float channel4;
			private float channel5;
			private float channel6;
			private float channel7;
			private float channel8;

			/// <summary>An array of floating-point color values for up to nine color channels, including the alpha channel.</summary>
			/// <value>
			/// The first element in the array, channels[0], contains the value for the alpha channel.The remaining elements in the
			/// array have context-specific color channel values.
			/// </value>
			public float[] channel
			{
				get
				{
					var ret = new float[channelCount];
					unsafe
					{
						fixed (void* ptr = &this)
						fixed (float* pRet = ret)
						{
							float* fptr = (float*)((byte*)ptr + 4);
							for (int i = 0; i < channelCount; i++)
								*(pRet + i) = *(fptr + i);
						}
					}
					return ret;
				}
				set
				{
					if (value is null) value = new float[0];
					if (value.Length > 9) throw new InvalidOperationException("Only 9 channels can be set.");
					channelCount = (byte)value.Length;
					unsafe
					{
						fixed (void* ptr = &this)
						fixed (float* pVal = value)
						{
							float* fptr = (float*)((byte*)ptr + 4);
							for (int i = 0; i < channelCount; i++)
								*(fptr + i) = *(pVal + i);
						}
					}
				}
			}
		}

		/// <summary>The contents of the <c>XPS_COLOR</c> structure when the colorType is <c>XPS_COLOR_TYPE_SRGB</c>.</summary>
		/// <remarks>For information about how to interpret or apply the values of this structure's members, see the XML Paper Specification.</remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/dd372944(v=vs.85)
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct XPS_COLOR_TYPE_SRGB
		{
			/// <summary>The 8-bit value of the alpha (transparency) channel.</summary>
			public byte alpha;

			/// <summary>The 8-bit value of the red color channel.</summary>
			public byte red;

			/// <summary>The 8-bit value of the green color channel.</summary>
			public byte green;

			/// <summary>The 8-bit value of the blue color channel.</summary>
			public byte blue;
		}
	}

	/// <summary>This structure describes a dash element of a path.</summary>
	/// <remarks>
	/// <para>The length must be non-negative and is measured in multiples of the path's stroke thickness.</para>
	/// <para>Values of <c>length</c> do not include the end caps of the visible segments.</para>
	/// <para>The shape of the end caps of the visible segments is determined by the XPS_DASH_CAP value.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_dash typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0020 { FLOAT length; FLOAT gap; } XPS_DASH;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "c8f43f91-eefb-4025-8042-c2601e89d315")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_DASH
	{
		/// <summary>Length of the visible segment of the dash element.</summary>
		public float length;

		/// <summary>Length of the space between the visible segments of the dash sequence.</summary>
		public float gap;
	}

	/// <summary>Describes the placement and location of a glyph.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_glyph_index typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0021 { LONG index; FLOAT advanceWidth; FLOAT horizontalOffset; FLOAT verticalOffset; } XPS_GLYPH_INDEX;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "0ea30e0f-f32b-4a38-9591-27cb1fe7f234")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_GLYPH_INDEX
	{
		/// <summary>The index of a glyph in the physical font.</summary>
		public int index;

		/// <summary>
		/// Indicates the placement of the glyph that follows, relative to the origin of the current glyph. Measured in hundredths of
		/// the font's em-size.
		/// </summary>
		public float advanceWidth;

		/// <summary>
		/// The horizontal distance, in the effective coordinate space, by which to move the glyph from the glyph's origin. Measured in
		/// hundredths of the font's em-size.
		/// </summary>
		public float horizontalOffset;

		/// <summary>
		/// The vertical distance, in the effective coordinate space, by which to move the glyph from the glyph's origin. Measured in
		/// hundredths of the font's em-size.
		/// </summary>
		public float verticalOffset;
	}

	/// <summary>Describes a glyph-to-index mapping.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_glyph_mapping typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0022 { UINT32 unicodeStringStart; UINT16 unicodeStringLength; UINT32
	// glyphIndicesStart; UINT16 glyphIndicesLength; } XPS_GLYPH_MAPPING;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "5cc76cba-66e4-4853-969b-a99ec7bb22f3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_GLYPH_MAPPING
	{
		/// <summary>Index of the first Unicode character in the mapping string.</summary>
		public uint unicodeStringStart;

		/// <summary>Number of characters in the mapping string.</summary>
		public ushort unicodeStringLength;

		/// <summary>The glyph array's first index that corresponds to <c>unicodeStringStart</c>.</summary>
		public uint glyphIndicesStart;

		/// <summary>Length of index mapping.</summary>
		public ushort glyphIndicesLength;
	}

	/// <summary>Describes the left two columns of a 3-by-3 matrix.</summary>
	/// <remarks>
	/// <para>The values in the third column of the matrix are assumed to be 0, 0, 1.</para>
	/// <para>The following table shows the entire matrix.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>m11</term>
	/// <term>m12</term>
	/// <term>0</term>
	/// </listheader>
	/// <item>
	/// <term>m21</term>
	/// <term>m22</term>
	/// <term>0</term>
	/// </item>
	/// <item>
	/// <term>m31</term>
	/// <term>m32</term>
	/// <term>1</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_matrix typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0023 { FLOAT m11; FLOAT m12; FLOAT m21; FLOAT m22; FLOAT m31; FLOAT m32; } XPS_MATRIX;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "0df75410-0e34-4962-8499-879d5153d9af")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_MATRIX
	{
		/// <summary>The value in the left column of the first row of the matrix.</summary>
		public float m11;

		/// <summary>The value in the center column of the first row of the matrix.</summary>
		public float m12;

		/// <summary>The value in the left column of the second row of the matrix.</summary>
		public float m21;

		/// <summary>The value in the center column of the second row of the matrix.</summary>
		public float m22;

		/// <summary>The value in the left column of the third row of the matrix. This value is also the x-offset.</summary>
		public float m31;

		/// <summary>The value in the center column of the third row of the matrix. This value is also the y-offset.</summary>
		public float m32;
	}
}