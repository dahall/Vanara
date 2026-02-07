#pragma warning disable CA1401 // P/Invokes should not be visible
/*
 * Ref generated object
 * IUnk tests
 * SuppressAutoGen tests
 * Ignore parameter tests
 * SizeDef tests
*/

// Raw code *****************************************************
using System.ComponentModel.DataAnnotations;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace Vanara.PInvoke
{
	public interface IUnkHolderIgnore
	{
		[PreserveSig]
		HRESULT SkipIIUnk(object? p1, in Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
	}
	public static partial class Test32
	{
		[MarshalAs(UnmanagedType.Bool)]
		public static readonly bool field1;

		public interface IUnkHolder
		{
			/// <summary>Gets the object.</summary>
			/// <param name="p1">The p1.</param>
			/// <param name="p2">The p2.</param>
			/// <param name="p3">The p3.</param>
			/// <param name="p4">The p4.</param>
			/// <param name="p5">The p5.</param>
			/// <returns>The ret.</returns>
			[PreserveSig]
			HRESULT GoodIIUnk1(object? p1, in Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3, ref DateTime p4, out long p5);
			/// <summary>Gets the obj2.</summary>
			/// <param name="p1">The p1.</param>
			/// <param name="p2">The p2.</param>
			/// <param name="p3">The p3.</param>
			void GoodIIUnk2(float p1, in Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
			HRESULT SkipIIUnk1(object? p1, in Guid p2, [MarshalAs(UnmanagedType.IUnknown)] object? p3);
			HRESULT SkipIIUnk2(object? p1, in Guid p2, [MarshalAs(UnmanagedType.IUnknown)] out object? p3);
			HRESULT SkipI([MarshalAs(UnmanagedType.LPArray)] int[] p3);
			[SuppressAutoGen]
			void SkipIIUnk3(float p1, in Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);

			/// <summary>Gets the object.</summary>
			/// <param name="p1">The p1.</param>
			/// <param name="p2">The p2.</param>
			/// <param name="p3">The p3.</param>
			/// <param name="p4">The p4.</param>
			/// <param name="p5">The p5.</param>
			/// <param name="p6">The p6.</param>
			/// <returns>The ret.</returns>
			int BadIIUnkIgnoreSizeDef([AddAsMember] HTEST p1, [Out, SizeDef(nameof(p3), SizingMethod.Query | SizingMethod.QueryResultInReturn)] StringBuilder? p2,
				uint p3, in Guid p4, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? p5, [Optional, Ignore] uint p6);

			/// <summary>Gets the object.</summary>
			/// <param name="p1">The p1.</param>
			/// <param name="p2">The p2.</param>
			/// <param name="p3">The p3.</param>
			/// <param name="p4">The p4.</param>
			/// <param name="p5">The p5.</param>
			/// <returns>The ret.</returns>
			int GoodIIUnkIgnoreSizeDef([Optional, Ignore] uint p1, [Out, SizeDef(nameof(p3), SizingMethod.Query | SizingMethod.QueryResultInReturn)] StringBuilder? p2,
				uint p3, in Guid p4, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? p5);
		}

		/// <summary>Gets the object.</summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <param name="p3">The p3.</param>
		[DllImport("test32.dll", CharSet = CharSet.Unicode)]
		public static extern bool GoodIgnore([Ignore] int p1, string p2, [Ignore] out string p3);

		/// <summary>Gets the object.</summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <param name="p3">The p3.</param>
		/// <param name="p4">The p4.</param>
		/// <param name="p5">The p5.</param>
		/// <param name="p6">The p6.</param>
		/// <returns>The ret.</returns>
		[DllImport("test32.dll", CharSet = CharSet.Unicode)]
		public static extern int GoodIUnkIgnoreSizeDef([AddAsMember] HTEST p1, [Out, SizeDef(nameof(p3), SizingMethod.Query | SizingMethod.QueryResultInReturn)] StringBuilder? p2,
			uint p3, in Guid p4, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? p5, [Optional, Ignore] uint p6);

		/// <summary>Gets the object.</summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <param name="p3">The p3.</param>
		/// <returns>The ret.</returns>
		[DllImport("test32.dll")]
		public static extern HRESULT GoodIUnk(object? p1, in Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);

		[DllImport("test32.dll")]
		public static extern bool GoodSizeDef01([SizeDef("sz", SizingMethod.Count /* default */)] StringBuilder? p1, [System.ComponentModel.DataAnnotations.Range(0, 50)] int len);
		[DllImport("test32.dll")]
		public static extern bool GoodSizeDef02([SizeDef("sz", SizingMethod.Bytes)] StringBuilder? p1, [System.ComponentModel.DataAnnotations.Range(0, 50)] int len);
		[DllImport("test32.dll", CharSet = CharSet.Unicode)]
		public static extern bool GoodSizeDef03([SizeDef("sz", SizingMethod.InclNullTerm)] StringBuilder? p1, [System.ComponentModel.DataAnnotations.Range(0, 50)] int len);
		[DllImport("test32.dll")]
		public static extern bool GoodSizeDef04([SizeDef("sz", SizingMethod.Bytes | SizingMethod.InclNullTerm)] StringBuilder? p1, [System.ComponentModel.DataAnnotations.Range(0, 50)] int len);
		[DllImport("test32.dll")]
		public static extern bool GoodSizeDef05([SizeDef("sz", SizingMethod.Query)] StringBuilder? sb, [System.ComponentModel.DataAnnotations.Range(0, 50)] ref int len);
		[DllImport("test32.dll")]
		public static extern int GoodSizeDef06([SizeDef("sz", SizingMethod.QueryResultInReturn)] StringBuilder? sb, int len);
		[DllImport("test32.dll")]
		public static extern Win32Error GoodSizeDef07([SizeDef("sz", SizingMethod.CheckLastError)] StringBuilder? sb, [System.ComponentModel.DataAnnotations.Range(0, 50)] ref int len);
		[DllImport("test32.dll")]
		public static extern int GoodSizeDef08([SizeDef("sz", SizingMethod.CheckLastError)] StringBuilder? sb, [System.ComponentModel.DataAnnotations.Range(0, 50)] ref int len);
		[DllImport("test32.dll")]
		public static extern int GoodSizeDef09([SizeDef(50)] StringBuilder? sb);

		public static void GoodSizeDef11([SizeDef("sz")] int[]? arr, [Range(0, 50)] int sz);
		//public static void GoodSizeDef8([SizeDef("sz", SizingMethod.Count | SizingMethod.Bytes)] int[]? arr, [Range(0, 50)] int sz);
		public static void GoodSizeDef11([SizeDef("sz", SizingMethod.Query)] int[]? arr, [Range(0, 50)] ref int sz);
		//public static void GoodSizeDef12([SizeDef("sz", SizingMethod.Query | SizingMethod.Bytes)] int[]? arr, [Range(0, 50)] ref int sz);
		//public static void GoodSizeDef13([SizeDef("sz", SizingMethod.Query, OutVarName = "lenReq")] int[]? arr, [Range(0, 50)] int sz, out int lenReq);

		/// <summary>Gets the object.</summary>
		/// <param name="p1">The p1.</param>
		/// <param name="p2">The p2.</param>
		/// <param name="p3">The p3.</param>
		/// <returns>The ret.</returns>
		[DllImport("test32.dll")]
		public static extern bool GoodLPArray(object? p1, uint p2, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] p3);
	}
}

// Generated code *****************************************************

// File generated code
namespace Vanara.PInvoke
{
	public partial class Test32
	{
		public partial struct HTEST { private IntPtr handle; public static implicit operator HTEST(IntPtr h) => new() { handle = h }; }
		[DeferAutoMethodFrom(typeof(HTEST))]
		public partial class SafeHTEST : SafeHANDLE
		{
			public static implicit operator HTEST(SafeHTEST h) => h.handle;
			protected override bool InternalReleaseHandle() => true;
		}
	}
}
// Attr generated code
namespace Vanara.PInvoke
{
	// Get param types and attribute values for parameter and return values
	// Initialize out params
	// Setup parameter values
	// Call method for query
	// Return on query failure
	// Assign variables after query
	// Call method for real
	// Return on failure
	// Get out params
	// Return
	public partial class Test32
	{
		public static bool GoodIgnore(string p2)
		{
			return GoodIgnore(default, p2, out _);
		}
		public static HRESULT GoodIUnk<__TIUnk>(object? p1, out __TIUnk? p3) where __TIUnk : class
		{
			// Call method for real
			var __ret = GoodIUnk(p1, typeof(__TIUnk).GUID, out var __ppv);
			// Get out params
			p3 = __ppv as __TIUnk;
			// Return
			return __ret;
		}
		public static int GoodIIUnkIgnoreSizeDef<__TIUnk>(this IUnkHolder __baseInterface, out string? p2, out __TIUnk? p5)
		{
			Type p3Type = typeof(uint); // TODO: get from parameter type
			// Initialize out params
			p2 = default;
			p5 = default;
			// Call method for query
			var __ret = __baseInterface.GoodIIUnkIgnoreSizeDef(default, default, default, typeof(__TIUnk).GUID, out _);
			// Handle failures
			if (FAILED(__ret))
				return __ret;
			// Assign variables after query
			var __p3 = (uint)Convert.ChangeType(__ret, p3Type); // TODO: convert to parameter type
			var __p2 = new StringBuilder(Convert.ToInt32(__p3));
			// Call method for real
			__ret = __baseInterface.GoodIIUnkIgnoreSizeDef(default, __p2, __p3, typeof(__TIUnk).GUID, out var ppv);
			// Get out params
			p2 = __p2.ToString();
			p5 = (__TIUnk?)ppv;
			// Return
			return __ret;
		}
		public static int GoodIUnkIgnoreSizeDef<__TIUnk>([AddAsMember] HTEST p1, out string? p2, out __TIUnk? p5)
		{
			Type p3Type = typeof(uint); // TODO: get from parameter type
			// Initialize out params
			p2 = default;
			p5 = default;
			// Call method for query
			var __ret = GoodIUnkIgnoreSizeDef(p1, default, default, typeof(__TIUnk).GUID, out _);
			// Handle failures
			if (FAILED(__ret))
				return __ret;
			// Assign variables after query
			var __p3 = (uint)Convert.ChangeType(__ret, p3Type); // TODO: convert to parameter type
			var __p2 = new StringBuilder(Convert.ToInt32(__p3));
			// Call method for real
			__ret = GoodIUnkIgnoreSizeDef(p1, __p2, __p3, typeof(__TIUnk).GUID, out var ppv);
			// Get out params
			p2 = __p2.ToString();
			p5 = (__TIUnk?)ppv;
			// Return
			return __ret;
		}
		public static bool GoodSizeDef01(out string? p1) // Count
		{
			// Get param types and attribute values for parameter and return values
			var __charSet = CharSet.Auto; // Get from DllImport CharSet
			var __conv2Bytes = true; // Determine if byte conversion is needed from SizingMethod
			var __isNullTerm = false; // Determine if null terminator is needed from SizingMethod
			// Initialize out params
			p1 = default;
			// Setup parameter values
			int sz = 50; // Type from param type, value from from Range attribute max or type max value
			if (__isNullTerm) sz -= 1; // Adjust for null terminator
			if (__conv2Bytes) sz /= StringHelper.GetCharSize(__charSet); // Adjust for char size
			StringBuilder sb = new(Convert.ToInt32(sz));
			// Call method for real
			var ret = GoodSizeDef01(sb, sz);
			// Return on failure
			if (Vanara.PInvoke.FailedHelper.FAILED(ret)) return ret;
			// Get out params
			p1 = sb.ToString();
			// Return
			return ret;
		}
		public static bool GoodSizeDef02(out string? p1) // Count
		{
			// Get param types and attribute values for parameter and return values
			var __charSet = CharSet.Auto; // Get from DllImport CharSet
			var __conv2Bytes = true; // Determine if byte conversion is needed from SizingMethod
			var __isNullTerm = false; // Determine if null terminator is needed from SizingMethod
			// Initialize out params
			p1 = default;
			// Setup parameter values
			int sz = 50; // Type from param type, value from from Range attribute max or type max value
			if (__isNullTerm) sz -= 1; // Adjust for null terminator
			if (__conv2Bytes) sz /= StringHelper.GetCharSize(__charSet); // Adjust for char size
			StringBuilder sb = new(Convert.ToInt32(sz));
			// Call method for real
			var ret = GoodSizeDef01(sb, sz);
			// Return on failure
			if (Vanara.PInvoke.FailedHelper.FAILED(ret)) return ret;
			// Get out params
			p1 = sb.ToString();
			// Return
			return ret;
		}
		public static bool GoodSizeDef05(out string? p1) // Query
		{
			// Get param types and attribute values for parameter and return values
			var __charSet = CharSet.Auto; // Get from DllImport CharSet
			var __conv2Bytes = true; // Determine if byte conversion is needed from SizingMethod
			var __isNullTerm = false; // Determine if null terminator is needed from SizingMethod
			var __checkLastErr = false; // Determine if checking last error is needed from SizingMethod
			// Initialize out params
			p1 = default;
			// Setup parameter values
			int sz = default; // Type from param type
			// Call method for query
			var ret = GoodSizeDef05(default, ref sz);
			// Return on query failure
			if (FAILED(ret, __checkLastErr))
				return ret;
			// Assign variables after query
			if (__isNullTerm) sz -= 1; // Adjust for null terminator
			if (__conv2Bytes) sz /= StringHelper.GetCharSize(__charSet); // Adjust for char size
			StringBuilder sb = new(Convert.ToInt32(sz));
			// Call method for real
			ret = GoodSizeDef05(sb, ref sz);
			// Return on failure
			if (FAILED(ret))
				return ret;
			// Get out params
			p1 = sb.ToString();
			// Return
			return ret;
		}

		public static int GoodSizeDef06(out string? p1) // QueryResultInReturn
		{
			// Get param types and attribute values for parameter and return values
			var __charSet = CharSet.Auto; // Get from DllImport CharSet
			var __conv2Bytes = true; // Determine if byte conversion is needed from SizingMethod
			var __isNullTerm = false; // Determine if null terminator is needed from SizingMethod
			var __checkLastErr = false; // Determine if checking last error is needed from SizingMethod
			// Initialize out params
			p1 = default;
			// Setup parameter values
			int sz = default; // Type from param type
			// Call method for query
			var ret = GoodSizeDef06(default, sz);
			// Return on query failure
			if (FAILED(ret, __checkLastErr))
				return ret;
			// Assign variables after query
			sz = ret;
			if (__isNullTerm) sz -= 1; // Adjust for null terminator
			if (__conv2Bytes) sz /= StringHelper.GetCharSize(__charSet); // Adjust for char size
			StringBuilder sb = new(Convert.ToInt32(sz));
			// Call method for real
			ret = GoodSizeDef06(sb, sz);
			// Return on failure
			if (FAILED(ret))
				return ret;
			// Get out params
			p1 = sb.ToString();
			// Return
			return ret;
		}

		public static int GoodSizeDef07(out string? p1) // QueryResultInReturn
		{
			// Get param types and attribute values for parameter and return values
			var __charSet = CharSet.Auto; // Get from DllImport CharSet
			var __conv2Bytes = true; // Determine if byte conversion is needed from SizingMethod
			var __isNullTerm = false; // Determine if null terminator is needed from SizingMethod
			var __checkLastErr = false; // Determine if checking last error is needed from SizingMethod
			// Initialize out params
			p1 = default;
			// Setup parameter values
			szVarType p2 = default; // Type from param type
			// Call method for query
			var __qret = GoodSizeDef07(default, ref p2);
			// Return on query failure
			if (FAILED(__qret, __checkLastErr))
				return __qret;
			// Assign variables after query
			int __cElem = Convert.ToInt32(__qret);
			if (__conv2Bytes) __cElem /= SizeOfElem(__charSet); // Adjust for char size
			if (__isNullTerm) __cElem -= 1; // Adjust for null terminator
			StringBuilder __out = new(__cElem); // OR outType[]? __out = new outType[__cElem];
			// Call method for real
			var __ret = GoodSizeDef07(sb, ref p2);
			// Return on failure
			if (FAILED(__ret))
				return __ret;
			// Get out params
			p1 = __out.ToString(); // OR = __out;
			// Return
			return __ret;
		}

		public static int GoodSizeDef09(out string? sb)
		{
			// Initialize out params
			sb = default;
			// Setup parameter values
			StringBuilder __sb = new(50); // Size from SizeDef fixed size
			// Call method for real
			var ret = GoodSizeDef09(__sb);
			// Return on failure
			if (Vanara.PInvoke.FailedHelper.FAILED(ret)) return ret;
			// Get out params
			sb = __sb.ToString();
			// Return
			return ret;
		}
		public static bool GoodSizeDef11(out int[]? p1) // Count array
		{
			// Get param types and attribute values for parameter and return values
			var __conv2Bytes = true; // Determine if byte conversion is needed from SizingMethod
			var __checkLastErr = false; // Determine if checking last error is needed from SizingMethod
			var __isNullable = false; // Determine if array type is nullable
			// Initialize out params
			p1 = __isNullable ? default : [];
			// Setup parameter values
			int sz = hint; // Type from param type, value from from Range attribute max or type max value
			// Assign variables after query
			elemType[] __p1 = new[Convert.ToInt32(__conv2Bytes ? sz / (szType)Marshal.SizeOf<elemType>() : sz)];
			// Call method for real
			var ret = GoodSizeDef11(sb, sz);
			// Return on failure
			if (FAILED(ret))
				return ret;
			// Get out params
			p1 = __p1;
			// Return
			return ret;
		}
		public static bool GoodSizeDef13(out int[]? p1) // Query
		{
			// Get param types and attribute values for parameter and return values
			var __conv2Bytes = true; // Determine if byte conversion is needed from SizingMethod
			var __checkLastErr = false; // Determine if checking last error is needed from SizingMethod
			var __isNullable = false; // Determine if array type is nullable
			// Initialize out params
			p1 = __isNullable ? default : [];
			// Setup parameter values
			int sz = default; // Type from param type, value from from Range attribute max or type max value
			// Call method for query
			var qret = GoodSizeDef13(p1, ref sz);
			// Return on query failure
			if (FAILED(qret, __checkLastErr))
				return qret;
			// Assign variables after query
			elemType[] __p1 = new[Convert.ToInt32(__conv2Bytes ? sz / (szType)Marshal.SizeOf<elemType>() : sz)];
			// Call method for real
			var ret = GoodSizeDef13(sb, ref sz);
			// Return on failure
			if (FAILED(ret))
				return ret;
			// Get out params
			p1 = __p1;
			// Return
			return ret;
		}
		public static bool GoodLPArray(object? p1, long[] p3)
		{
			var ret = GoodLPArray(p1, Convert.ChangeType(p3?.Length ?? 0, typeof(uint)), p3);
			return ret;
		}

		public partial struct HTEST
		{
			public readonly int GoodIUnkIgnoreSizeDef<__TIUnk>(out string? p2, out __TIUnk? p5) => Test32.GoodIUnkIgnoreSizeDef(this, out p2, out p5);
		}

		public partial class SafeHTEST
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
			public int GoodIUnkIgnoreSizeDef<__TIUnk>(out string? p2, out __TIUnk? p5) => ((HTEST)this).GoodIUnkIgnoreSizeDef(out p2, out p5);
		}
	}
}