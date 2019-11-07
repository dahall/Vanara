using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class OleAut32
	{
		/// <summary>
		/// VARIANTARG describes arguments passed within DISPPARAMS, and VARIANT to specify variant data that cannot be passed by reference.
		/// <para>
		/// When a variant refers to another variant by using the VT_VARIANT | VT_BYREF vartype, the variant being referred to cannot also be
		/// of type VT_VARIANT | VT_BYREF.VARIANTs can be passed by value, even if VARIANTARGs cannot.
		/// </para>
		/// </summary>
		[PInvokeData("oaidl.h")]
		[StructLayout(LayoutKind.Explicit)]
		[System.Security.SecurityCritical]
		public struct VARIANT
		{
			/// <summary>The type of data in the union.</summary>
			[FieldOffset(0)] public VARTYPE vt;

			/// <summary>Reserved.</summary>
			[FieldOffset(2)] public ushort wReserved1;

			/// <summary>Reserved.</summary>
			[FieldOffset(4)] public ushort wReserved2;

			/// <summary>Reserved.</summary>
			[FieldOffset(6)] public ushort wReserved3;

			/// <summary>A generic value.</summary>
			[FieldOffset(8)] public IntPtr byref;

			// ensures correct size
			[FieldOffset(8)] private Record _rec;

			// use for easy primitive casts
			[FieldOffset(8)] internal ulong _ulong;

			/// <summary>A decimal value.</summary>
			[FieldOffset(0)] public decimal decVal;

			[StructLayout(LayoutKind.Sequential)]
			private struct Record
			{
				private IntPtr _record;
				private IntPtr _recordInfo;
			}
		}
	}
}