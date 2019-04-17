using System;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Generic functions to help with standard function patterns like getting a string from a method.</summary>
	public static class FunctionHelper
	{
		/// <summary>Delegate to get the size of memory allocated to a pointer.</summary>
		/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
		/// <param name="ptr">The pointer to the memory in question.</param>
		/// <param name="sz">The resulting size.</param>
		/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
		public delegate Win32Error PtrFunc<TSize>(IntPtr ptr, ref TSize sz) where TSize : struct, IConvertible;

		/// <summary>
		/// Delegate that takes and StringBuilder and initial size and returns a result.
		/// </summary>
		/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
		/// <typeparam name="TRet">The return type.</typeparam>
		/// <param name="sb">The <see cref="StringBuilder"/> value.</param>
		/// <param name="sz">On input, the size of the <paramref name="sb"/> capacity. On output, the number of characters written.</param>
		/// <returns>The return value. Often this is an error.</returns>
		public delegate TRet SBFunc<TSize, TRet>(StringBuilder sb, ref TSize sz) where TSize : struct, IConvertible;

		/// <summary>Gets a size and returns an error.</summary>
		/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
		/// <param name="sz">On input, the size of the capacity. On output, the number of characters written.</param>
		/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
		public delegate Win32Error SizeFunc<TSize>(ref TSize sz) where TSize : struct, IConvertible;

		/// <summary>Converts a bool to a Win32Error.</summary>
		/// <param name="result">Result state.</param>
		/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
		public static Win32Error BoolToLastErr(bool result) => result ? Win32Error.ERROR_SUCCESS : Win32Error.GetLastError();

		/// <summary>
		/// Checks to see if size is not 0 and if the error is requesting a larger buffer.
		/// </summary>
		/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
		/// <typeparam name="TRet">The error provider return type.</typeparam>
		/// <param name="sz">On input, the size of the capacity. On output, the number of characters written.</param>
		/// <param name="err">The error.</param>
		/// <returns><c>true</c> if buffer size is good; otherwise <c>false</c>.</returns>
		public static bool ChkGoodBuf<TSize, TRet>(TSize sz, TRet err) where TSize : struct where TRet : IErrorProvider, IConvertible => !sz.Equals(default(TSize)) && (err.ToHRESULT() == (HRESULT)(Win32Error)Win32Error.ERROR_MORE_DATA || err.ToHRESULT() == (HRESULT)(Win32Error)Win32Error.ERROR_INSUFFICIENT_BUFFER);

		/// <summary>Calls a method with <see cref="StringBuilder"/> and gets the resulting string or error.</summary>
		/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
		/// <typeparam name="TRet">The return type.</typeparam>
		/// <param name="method">The lambda or method to call into.</param>
		/// <param name="result">The resulting string value.</param>
		/// <param name="gotGoodSize">An optional method to determine if a valid size was retrieved by <paramref name="method"/>.</param>
		/// <returns>The return value of <paramref name="method"/>.</returns>
		public static TRet CallMethodWithStrBuf<TSize, TRet>(SBFunc<TSize, TRet> method, out string result, Func<TSize, TRet, bool> gotGoodSize = null) where TSize : struct, IConvertible
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

		/// <summary>Calls a method with <see cref="StringBuilder"/> and gets the resulting string or error.</summary>
		/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
		/// <typeparam name="TRet">The return type.</typeparam>
		/// <param name="method">The lambda or method to call into.</param>
		/// <param name="bufSz">The size value to pass into <paramref name="method"/>.</param>
		/// <param name="result">The resulting string value.</param>
		/// <returns>The return value of <paramref name="method"/>.</returns>
		public static TRet CallMethodWithStrBuf<TSize, TRet>(Func<StringBuilder, TSize, TRet> method, TSize bufSz, out string result) where TSize : IConvertible
		{
			var len = bufSz.ToInt32(null);
			var sb = new StringBuilder(len, len);
			var ret = method(sb, bufSz);
			result = sb.ToString();
			return ret;
		}

		/// <summary>Calls a method with buffer for a type and gets the result or error.</summary>
		/// <typeparam name="TOut">The return type.</typeparam>
		/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
		/// <param name="getSize">Method to get the size of the buffer.</param>
		/// <param name="method">The lambda or method to call into.</param>
		/// <param name="result">The resulting value of <typeparamref name="TOut"/>.</param>
		/// <param name="outConverter">An optional method to convert the pointer to the type specified by <typeparamref name="TOut"/>. By default, this will marshal the pointer to the structure.</param>
		/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
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