using System;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static class FunctionHelper
	{
		public delegate Win32Error PtrFunc<TSize>(IntPtr ptr, ref TSize sz) where TSize : struct, IConvertible;

		public delegate TRet SBFunc<TSize, TRet>(StringBuilder sb, ref TSize sz) where TSize : struct, IConvertible;

		public delegate Win32Error SizeFunc<TSize>(ref TSize sz) where TSize : struct, IConvertible;

		public static Win32Error BoolToLastErr(bool result) => result ? Win32Error.ERROR_SUCCESS : Win32Error.GetLastError();

		public static bool ChkGoodBuf<TSize, TRet>(TSize sz, TRet err) where TSize : struct where TRet : IErrorProvider, IConvertible => !sz.Equals(default(TSize)) && (err.ToHRESULT() == (HRESULT)(Win32Error)Win32Error.ERROR_MORE_DATA || err.ToHRESULT() == (HRESULT)(Win32Error)Win32Error.ERROR_INSUFFICIENT_BUFFER);

		public static TRet CallMethodWithStrBuf<TSize, TRet>(SBFunc<TSize, TRet> method, out string result, Func<TSize, TRet, bool> gotGoodSize = null) where TSize : struct, IConvertible where TRet : IErrorProvider
		{
			TSize sz = default;
			var ret0 = method(null, ref sz);
			if (!(gotGoodSize ?? IsNotDef)(sz, ret0))
			{
				result = null;
				return ret0;
			}
			var len = sz.ToInt32(null);
			var sb = new StringBuilder(len, len);
			var ret = method(sb, ref sz);
			result = sb.ToString();
			return ret;

			bool IsNotDef(TSize _sz, TRet _ret) => !_sz.Equals(default(TSize));
		}

		public static TRet CallMethodWithStrBuf<TSize, TRet>(Func<StringBuilder, TSize, TRet> method, TSize bufSz, out string result) where TSize : IConvertible
		{
			var len = bufSz.ToInt32(null);
			var sb = new StringBuilder(len, len);
			var ret = method(sb, bufSz);
			result = sb.ToString();
			return ret;
		}

		public static Win32Error CallMethodWithTypedBuf<TOut, TSize>(SizeFunc<TSize> getSize, PtrFunc<TSize> method, out TOut result, Func<IntPtr, TSize, TOut> outConverter = null) where TSize : struct, IConvertible
		{
			TSize sz = default;
			result = default;
			var err = getSize(ref sz);
			if (err.Failed) return err;
			var len = sz.ToInt32(null);
			using (var buf = new SafeHGlobalHandle(len))
			{
				var ret = method(buf.DangerousGetHandle(), ref sz);
				result = (outConverter ?? Conv)(buf.DangerousGetHandle(), sz);
				return ret;
			}

			TOut Conv(IntPtr p, TSize s) => p.ToStructure<TOut>();
		}
	}
}