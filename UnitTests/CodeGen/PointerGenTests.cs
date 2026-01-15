using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PointerGenTests
{

}

internal static partial class PointerMethods
{
	[StructLayout(LayoutKind.Sequential)]
	public struct P
	{
		public int X;
		public int Y;
	}

	public partial struct S
	{
		public StructPointer<P> p1;
		public unsafe P* p2;
	}

	public static void Method([In, Optional] StructPointer<P> p) { }

	public static void Method(in P? p)
	{
		Method(StructPointer.Make(p, out var _));
	}

	public static unsafe void UnsafeMethod([In, Optional] P* p) { }

	public static void UnsafeMethod(in P? p)
	{
		unsafe
		{
			UnsafeMethod(StructPointer.Make(p, out var _));
		}
	}

	public static bool CertVerifyCRLRevocation(CorrespondingAction dwCertEncodingType, in BOOL pCertId, uint cCrlInfo, StructPointer<SIZE_T>[]? rgpCrlInfo) => true;

	public static bool CertVerifyCRLRevocation(CorrespondingAction dwCertEncodingType, in BOOL pCertId, SIZE_T[]? rgpCrlInfo)
	{
		StructPointer<SIZE_T>[]? __rgpCrlInfo = rgpCrlInfo is null ? null : Array.ConvertAll(rgpCrlInfo, ci => StructPointer.Make<SIZE_T>(ci, out var _));
		return CertVerifyCRLRevocation(dwCertEncodingType, pCertId, (uint?)rgpCrlInfo?.Length ?? 0, __rgpCrlInfo);
	}

	public static bool SizeDefPtrMethod([SizeDef(nameof(cb))] IntPtr buf, uint cb) => true;

	public static bool SizeDefPtrMethod(Span<byte> buf)
	{
		unsafe
		{
			fixed (byte* pBuf = buf)
			{
				return SizeDefPtrMethod((IntPtr)pBuf, (uint)buf.Length);
			}
		}
	}

	public static int SizeDefPtrMethod2([Out, SizeDef(nameof(cb))] IntPtr buf, uint cb) => 10;

	public static int SizeDefPtrMethods(out Span<byte> buf)
	{
		var _sz = SizeDefPtrMethod2(default, 0);
		var __buf = new byte[_sz];
		_sz = SizeDefPtrMethod2(global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__buf, 0), (uint)__buf.Length);
		buf = __buf;
		return _sz;
	}

	public static void Test()
	{
		byte[] data = [1, 2, 3, 4, 5];
		SizeDefPtrMethod(data);

		SafeCoTaskMemHandle h = new(10254);
		SizeDefPtrMethod(h);
	}
}

	#nullable enable
#pragma warning disable 1591
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Test64
{
	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef01(string? p1)
	{
		int p2 = (int)Convert.ChangeType(p1?.Capacity ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef01(p1, p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef02(string? p1)
	{
		int p2 = (int)Convert.ChangeType(p1?.Capacity ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef02(p1, p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef03(string? p1)
	{
		int __sz3 = (int)Convert.ChangeType(p1?.Capacity ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef03(p1);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef04([In] string? p1)
	{
		int p2 = (int)Convert.ChangeType(p1?.Length ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef04(p1, p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef05(int[]? p1)
	{
		p1 = default;
		int p2 = (int)Convert.ChangeType(p1?.Length ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef05(global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__out6, 0), p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef06(string? p1)
	{
		int p2 = (int)Convert.ChangeType(p1?.Capacity ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef06(p1, p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <param name = "p2">The p2.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef07(string? p1)
	{
		int __sz8 = (int)Convert.ChangeType(p1?.Capacity ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef07(p1);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef08([In] string? p1)
	{
		int p2 = (int)Convert.ChangeType(p1?.Length ?? 0, typeof(int));
		bool __ret = Test64.GoodSizeDef08(p1, p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef09(Span<byte> p1)
	{
		p1 = [];
		int p2 = (int)Convert.ChangeType(p1.Length, typeof(int));
		bool __ret = Test64.GoodSizeDef09(global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__out11, 0), p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef10(Span<byte>)
	{

		= [];
		int p2 = (int)Convert.ChangeType( .Length, typeof(int));
		bool __ret = Test64.GoodSizeDef10(global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__out12, 0), p2);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <param name = "p2">The p2.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef11(Span<byte> p1)
	{
		p1 = [];
		int __sz13 = (int)Convert.ChangeType(p1.Length, typeof(int));
		bool __ret = Test64.GoodSizeDef11(global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__out14, 0));
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}

	/// <summary>Gets the object.</summary>
	/// <param name = "p1">The p1.</param>
	/// <param name = "p2">The p2.</param>
	/// <returns>The ret.</returns>
	public static bool GoodSizeDef12([In] Span<byte> p1)
	{
		int __sz15 = (int)Convert.ChangeType(p1.Length, typeof(int));
		bool __ret = Test64.GoodSizeDef12(global::Vanara.Extensions.InteropExtensions.UnsafeAddrOfPinnedSpanElement(p1, 0));
		if (global::Vanara.PInvoke.FailedHelper.FAILED(__ret, false))
			return __ret;
		return __ret;
	}
}
