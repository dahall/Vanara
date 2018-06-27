using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		public enum TMCHARSET : byte
		{
			/// <summary>The ANSI CHARSET</summary>
			ANSI_CHARSET = 0,

			/// <summary>The DEFAULT CHARSET</summary>
			DEFAULT_CHARSET = 1,

			/// <summary>The SYMBOL CHARSET</summary>
			SYMBOL_CHARSET = 2,

			/// <summary>The SHIFTJIS_ CHARSET</summary>
			SHIFTJIS_CHARSET = 128,

			/// <summary>The HANGEUL CHARSET</summary>
			HANGEUL_CHARSET = 129,

			/// <summary>The HANGUL CHARSET</summary>
			HANGUL_CHARSET = 129,

			/// <summary>The G B2312 CHARSET</summary>
			GB2312_CHARSET = 134,

			/// <summary>The CHINESEBIG5 CHARSET</summary>
			CHINESEBIG5_CHARSET = 136,

			/// <summary>The OEM CHARSET</summary>
			OEM_CHARSET = 255,

			/// <summary>The JOHAB_CHARSET</summary>
			JOHAB_CHARSET = 130,

			/// <summary>The HEBREW_CHARSET</summary>
			HEBREW_CHARSET = 177,

			/// <summary>The ARABIC_CHARSET</summary>
			ARABIC_CHARSET = 178,

			/// <summary>The GREEK_CHARSET</summary>
			GREEK_CHARSET = 161,

			/// <summary>The TURKISH_CHARSET</summary>
			TURKISH_CHARSET = 162,

			/// <summary>The VIETNAMESE_CHARSET</summary>
			VIETNAMESE_CHARSET = 163,

			/// <summary>The THAI_CHARSET</summary>
			THAI_CHARSET = 222,

			/// <summary>The EASTEUROPE_CHARSET</summary>
			EASTEUROPE_CHARSET = 238,

			/// <summary>The RUSSIAN_CHARSET</summary>
			RUSSIAN_CHARSET = 204,

			/// <summary>The MAC_CHARSET</summary>
			MAC_CHARSET = 77,

			/// <summary>The BALTIC_CHARSET</summary>
			BALTIC_CHARSET = 186,
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TEXTMETRIC
		{
			public int tmHeight;
			public int tmAscent;
			public int tmDescent;
			public int tmInternalLeading;
			public int tmExternalLeading;
			public int tmAveCharWidth;
			public int tmMaxCharWidth;
			public int tmWeight;
			public int tmOverhang;
			public int tmDigitizedAspectX;
			public int tmDigitizedAspectY;
			public char tmFirstChar;
			public char tmLastChar;
			public char tmDefaultChar;
			public char tmBreakChar;
			public byte tmItalic;
			public byte tmUnderlined;
			public byte tmStruckOut;
			public byte tmPitchAndFamily;
			public TMCHARSET tmCharSet;
		}
	}
}