using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Generic functions to help with standard function patterns like getting a string from a method.</summary>
public static class FunctionHelper
{
	internal static readonly List<HRESULT> buffErrs = [Win32Error.ERROR_MORE_DATA, Win32Error.ERROR_INSUFFICIENT_BUFFER, Win32Error.ERROR_BUFFER_OVERFLOW, HRESULT.TYPE_E_BUFFERTOOSMALL];

#nullable disable
	/// <summary>Delegate for functions that use an IID to retrieve an object.</summary>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="riid">The IID of the requested interface.</param>
	/// <param name="ppv">The resulting interface.</param>
	/// <returns>The error code for the function.</returns>
	public delegate TErr IidFunc<out TErr>(in Guid riid, out object ppv) where TErr : IErrorProvider;

	/// <summary>Delegate for functions that use an IID to retrieve an object.</summary>
	/// <param name="riid">The IID of the requested interface.</param>
	/// <param name="ppv">The resulting interface.</param>
	public delegate void IidFunc(in Guid riid, out object ppv);

	/// <summary>Delegate for functions that use an IID to retrieve an object.</summary>
	/// <typeparam name="TIn1">The type of the first parameter.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="p1">The first parameter.</param>
	/// <param name="riid">The IID of the requested interface.</param>
	/// <param name="ppv">The resulting interface.</param>
	/// <returns>The error code for the function.</returns>
	public delegate TErr IidFunc1<TIn1, out TErr>(TIn1 p1, in Guid riid, out object ppv) where TErr : IErrorProvider;

	/// <summary>Delegate for functions that use an IID to retrieve an object.</summary>
	/// <typeparam name="TIn1">The type of the first parameter.</typeparam>
	/// <param name="p1">The first parameter.</param>
	/// <param name="riid">The IID of the requested interface.</param>
	/// <param name="ppv">The resulting interface.</param>
	public delegate void IidFunc1<TIn1>(TIn1 p1, in Guid riid, out object ppv);

	/// <summary>Delegate for functions that use an IID to retrieve an object.</summary>
	/// <typeparam name="TIn1">The type of the first parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second parameter.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="p1">The first parameter.</param>
	/// <param name="p2">The second parameter.</param>
	/// <param name="riid">The IID of the requested interface.</param>
	/// <param name="ppv">The resulting interface.</param>
	/// <returns>The error code for the function.</returns>
	public delegate TErr IidFunc2<TIn1, TIn2, out TErr>(TIn1 p1, TIn2 p2, in Guid riid, out object ppv) where TErr : IErrorProvider;

	/// <summary>Delegate for functions that use an IID to retrieve an object.</summary>
	/// <typeparam name="TIn1">The type of the first parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second parameter.</typeparam>
	/// <param name="p1">The first parameter.</param>
	/// <param name="p2">The second parameter.</param>
	/// <param name="riid">The IID of the requested interface.</param>
	/// <param name="ppv">The resulting interface.</param>
	public delegate void IidFunc2<TIn1, TIn2>(TIn1 p1, TIn2 p2, in Guid riid, out object ppv);
#nullable restore

	/// <summary>Delegate to get the size of memory allocated to a pointer.</summary>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <param name="ptr">The pointer to the memory in question.</param>
	/// <param name="sz">The resulting size.</param>
	/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
	public delegate Win32Error PtrFunc<TSize>(IntPtr ptr, ref TSize sz) where TSize : struct, IConvertible;

	/// <summary>Delegate to get the size of memory allocated to a pointer.</summary>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="ptr">The pointer to the memory in question.</param>
	/// <param name="sz">The resulting size.</param>
	/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
	public delegate TErr PtrFunc<TSize, out TErr>(IntPtr ptr, ref TSize sz) where TSize : struct, IConvertible where TErr : struct, IErrorProvider;

	/// <summary>Delegate that takes and StringBuilder and initial size and returns a result.</summary>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TRet">The return type.</typeparam>
	/// <param name="sb">The <see cref="StringBuilder"/> value.</param>
	/// <param name="sz">On input, the size of the <paramref name="sb"/> capacity. On output, the number of characters written.</param>
	/// <returns>The return value. Often this is an error.</returns>
	public delegate TRet SBFunc<TSize, TRet>(StringBuilder? sb, ref TSize sz) where TSize : struct, IConvertible;

	/// <summary>Delegate that takes and StringBuilder and initial size and returns a result.</summary>
	/// <typeparam name="T1">The type of the first parameter.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TRet">The return type.</typeparam>
	/// <param name="arg1">The first parameter.</param>
	/// <param name="sb">The <see cref="StringBuilder"/> value.</param>
	/// <param name="sz">On input, the size of the <paramref name="sb"/> capacity. On output, the number of characters written.</param>
	/// <returns>The return value. Often this is an error.</returns>
	public delegate TRet SBFunc<in T1, TSize, TRet>(T1 arg1, StringBuilder? sb, ref TSize sz) where TSize : struct, IConvertible;

	/// <summary>Delegate that takes and StringBuilder and initial size and returns a result.</summary>
	/// <typeparam name="T1">The type of the first parameter.</typeparam>
	/// <typeparam name="T2">The type of the second parameter.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TRet">The return type.</typeparam>
	/// <param name="arg1">The first parameter.</param>
	/// <param name="arg2">The second parameter.</param>
	/// <param name="sb">The <see cref="StringBuilder"/> value.</param>
	/// <param name="sz">On input, the size of the <paramref name="sb"/> capacity. On output, the number of characters written.</param>
	/// <returns>The return value. Often this is an error.</returns>
	public delegate TRet SBFunc<in T1, in T2, TSize, TRet>(T1 arg1, T2 arg2, StringBuilder? sb, ref TSize sz) where TSize : struct, IConvertible;

	/// <summary>Gets a size and returns an error.</summary>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="sz">On input, the size of the capacity. On output, the number of characters written.</param>
	/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
	public delegate TErr SizeFunc<TSize, out TErr>(ref TSize sz) where TSize : struct, IConvertible where TErr : struct, IErrorProvider;

	/// <summary>Gets a size and returns an error.</summary>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <param name="sz">On input, the size of the capacity. On output, the number of characters written.</param>
	/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
	public delegate Win32Error SizeFunc<TSize>(ref TSize sz) where TSize : struct, IConvertible;

	/// <summary>Converts a bool to a Win32Error.</summary>
	/// <param name="result">Result state.</param>
	/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
	public static Win32Error BoolToLastErr(bool result) => result ? Win32Error.ERROR_SUCCESS : Win32Error.GetLastError();

	/// <summary>Calls a method with <see cref="StringBuilder"/> and gets the resulting string or error.</summary>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TRet">The return type.</typeparam>
	/// <param name="method">The lambda or method to call into.</param>
	/// <param name="result">The resulting string value.</param>
	/// <param name="gotGoodSize">An optional method to determine if a valid size was retrieved by <paramref name="method"/>.</param>
	/// <returns>The return value of <paramref name="method"/>.</returns>
	public static TRet CallMethodWithStrBuf<TSize, TRet>(SBFunc<TSize, TRet> method, out string? result, Func<TSize, TRet, bool>? gotGoodSize = null) where TSize : struct, IConvertible
	{
		TSize sz = default;
		var ret0 = method(null, ref sz);
		if (!(gotGoodSize ?? IsNotDef)(sz, ret0))
		{
			result = null;
			return ret0;
		}
		var len = sz.ToInt32(null) + 1;
		var sb = new StringBuilder(len, len);
		sz = (TSize)Convert.ChangeType(len, typeof(TSize));
		var ret = method(sb, ref sz);
		result = sb.ToString();
		return ret;
	}

	/// <summary>Calls a method with <see cref="StringBuilder"/> and gets the resulting string or error.</summary>
	/// <typeparam name="T1">The type of the first parameter.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TRet">The return type.</typeparam>
	/// <param name="method">The lambda or method to call into.</param>
	/// <param name="arg1">The first parameter.</param>
	/// <param name="result">The resulting string value.</param>
	/// <param name="gotGoodSize">An optional method to determine if a valid size was retrieved by <paramref name="method"/>.</param>
	/// <returns>The return value of <paramref name="method"/>.</returns>
	public static TRet CallMethodWithStrBuf<T1, TSize, TRet>(SBFunc<T1, TSize, TRet> method, T1 arg1, out string? result,
		Func<TSize, TRet, bool>? gotGoodSize = null) where TSize : struct, IConvertible
	{
		TSize sz = default;
		var ret0 = method(arg1, null, ref sz);
		if (!(gotGoodSize ?? IsNotDef)(sz, ret0))
		{
			result = null;
			return ret0;
		}
		var len = sz.ToInt32(null) + 1;
		var sb = new StringBuilder(len, len);
		sz = (TSize)Convert.ChangeType(len, typeof(TSize));
		var ret = method(arg1, sb, ref sz);
		result = sb.ToString();
		return ret;
	}

	/// <summary>Calls a method with <see cref="StringBuilder"/> and gets the resulting string or error.</summary>
	/// <typeparam name="T1">The type of the first parameter.</typeparam>
	/// <typeparam name="T2">The type of the second parameter.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TRet">The return type.</typeparam>
	/// <param name="method">The lambda or method to call into.</param>
	/// <param name="arg1">The first parameter.</param>
	/// <param name="arg2">The second parameter.</param>
	/// <param name="result">The resulting string value.</param>
	/// <param name="gotGoodSize">An optional method to determine if a valid size was retrieved by <paramref name="method"/>.</param>
	/// <returns>The return value of <paramref name="method"/>.</returns>
	public static TRet CallMethodWithStrBuf<T1, T2, TSize, TRet>(SBFunc<T1, T2, TSize, TRet> method, T1 arg1, T2 arg2, out string? result,
		Func<TSize, TRet, bool>? gotGoodSize = null) where TSize : struct, IConvertible
	{
		TSize sz = default;
		var ret0 = method(arg1, arg2, null, ref sz);
		if (!(gotGoodSize ?? IsNotDef)(sz, ret0))
		{
			result = null;
			return ret0;
		}
		var len = sz.ToInt32(null) + 1;
		var sb = new StringBuilder(len, len);
		sz = (TSize)Convert.ChangeType(len, typeof(TSize));
		var ret = method(arg1, arg2, sb, ref sz);
		result = sb.ToString();
		return ret;
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
		var len = bufSz.ToInt32(null) + 1;
		var sb = new StringBuilder(len, len);
		var ret = method(sb, bufSz);
		result = sb.ToString();
		return ret;
	}

	/*/// <summary>Calls a method with buffer for a type and gets the result or error.</summary>
	/// <typeparam name="TOut">The return type.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <param name="getSize">Method to get the size of the buffer.</param>
	/// <param name="method">The lambda or method to call into.</param>
	/// <param name="result">The resulting value of <typeparamref name="TOut"/>.</param>
	/// <param name="outConverter">
	/// An optional method to convert the pointer to the type specified by <typeparamref name="TOut"/>. By default, this will marshal the
	/// pointer to the structure.
	/// </param>
	/// <param name="bufErr">
	/// The optional error <paramref name="method"/> returns when the buffer size is insufficient. If left <see langword="null"/>, then a
	/// list of well known errors will be used.
	/// </param>
	/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
	public static Win32Error CallMethodWithTypedBuf<TOut, TSize>(SizeFunc<TSize>? getSize, PtrFunc<TSize> method, out TOut? result,
		Func<IntPtr, TSize, TOut?>? outConverter = null, Win32Error? bufErr = null) where TSize : struct, IConvertible =>
		CallMethodWithTypedBuf<TOut, TSize, Win32Error>(getSize is null ? null : (ref TSize sz) => getSize(ref sz), (IntPtr p, ref TSize s) => method(p, ref s), out result, outConverter, bufErr);*/

	/// <summary>Calls a method with buffer for a type and gets the result or error.</summary>
	/// <typeparam name="TOut">The return type.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="getSize">Method to get the size of the buffer.</param>
	/// <param name="method">The lambda or method to call into.</param>
	/// <param name="result">The resulting value of <typeparamref name="TOut"/>.</param>
	/// <param name="outConverter">
	/// An optional method to convert the pointer to the type specified by <typeparamref name="TOut"/>. By default, this will marshal the
	/// pointer to the structure.
	/// </param>
	/// <param name="bufErr">
	/// The optional error <paramref name="method"/> returns when the buffer size is insufficient. If left <see langword="null"/>, then a
	/// list of well known errors will be used.
	/// </param>
	/// <returns>Resulting error or <see cref="Win32Error.ERROR_SUCCESS"/> on success.</returns>
	public static TErr CallMethodWithTypedBuf<TOut, TSize, TErr>(SizeFunc<TSize, TErr>? getSize, PtrFunc<TSize, TErr> method, out TOut? result,
		Func<IntPtr, TSize, TOut?>? outConverter = null, TErr? bufErr = null) where TSize : struct, IConvertible where TErr : struct, IErrorProvider
	{
		TSize sz = default;
		result = default;
		var err = (getSize ?? GetSize)(ref sz);
		if (err.Failed && (bufErr == null || !EqualityComparer<TErr>.Default.Equals(bufErr.Value, err)) && !buffErrs.Contains(err.ToHRESULT())) return err;
		using SafeHGlobalHandle buf = new(sz.ToInt32(null));
		err = method(buf.DangerousGetHandle(), ref sz);
		if (err.Succeeded)
			result = (outConverter ?? Conv)(buf.DangerousGetHandle(), sz);
		return err;

		TErr GetSize(ref TSize sz1) => method(IntPtr.Zero, ref sz1);

		static TOut? Conv(IntPtr p, TSize s) => p == IntPtr.Zero ? default : p.Convert<TOut>(Convert.ToUInt32(s));
	}

	/*/// <summary>Calls a method with buffer for a type and gets the result or error.</summary>
	/// <typeparam name="TOut">The return type.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <param name="method">The lambda or method to call into.</param>
	/// <param name="getSize">Method to get the size of the buffer.</param>
	/// <param name="outConverter">
	/// An optional method to convert the pointer to the type specified by <typeparamref name="TOut"/>. By default, this will marshal the
	/// pointer to the structure.
	/// </param>
	/// <param name="bufErr">
	/// The optional error <paramref name="method"/> returns when the buffer size is insufficient. If left <see langword="null"/>, then a
	/// list of well known errors will be used.
	/// </param>
	/// <returns>The resulting value of <typeparamref name="TOut"/>.</returns>
	public static TOut? CallMethodWithTypedBuf<TOut, TSize>(PtrFunc<TSize> method, SizeFunc<TSize>? getSize = null,
		Func<IntPtr, TSize, TOut>? outConverter = null, Win32Error? bufErr = null) where TSize : struct, IConvertible
	{
		CallMethodWithTypedBuf(getSize, method, out var res, outConverter, bufErr).ThrowIfFailed();
		return res;
	}*/

	/// <summary>Calls a method with buffer for a type and gets the result or error.</summary>
	/// <typeparam name="TOut">The return type.</typeparam>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="method">The lambda or method to call into.</param>
	/// <param name="getSize">Method to get the size of the buffer.</param>
	/// <param name="outConverter">
	/// An optional method to convert the pointer to the type specified by <typeparamref name="TOut"/>. By default, this will marshal the
	/// pointer to the structure.
	/// </param>
	/// <param name="bufErr">
	/// The optional error <paramref name="method"/> returns when the buffer size is insufficient. If left <see langword="null"/>, then a
	/// list of well known errors will be used.
	/// </param>
	/// <returns>The resulting value of <typeparamref name="TOut"/>.</returns>
	public static TOut? CallMethodWithTypedBuf<TOut, TSize, TErr>(PtrFunc<TSize, TErr> method, SizeFunc<TSize, TErr>? getSize = null,
		Func<IntPtr, TSize, TOut>? outConverter = null, TErr? bufErr = null) where TSize : struct, IConvertible where TErr : struct, IErrorProvider
	{
		CallMethodWithTypedBuf(getSize, method, out var res, outConverter, bufErr).ThrowIfFailed();
		return res;
	}

	/// <summary>Checks to see if size is not 0 and if the error is requesting a larger buffer.</summary>
	/// <typeparam name="TSize">The type of the size result. This is usually <see cref="int"/> or <see cref="uint"/>.</typeparam>
	/// <typeparam name="TRet">The error provider return type.</typeparam>
	/// <param name="sz">On input, the size of the capacity. On output, the number of characters written.</param>
	/// <param name="err">The error.</param>
	/// <returns><c>true</c> if buffer size is good; otherwise <c>false</c>.</returns>
	public static bool ChkGoodBuf<TSize, TRet>(TSize sz, TRet err) where TSize : struct where TRet : IErrorProvider, IConvertible =>
		!sz.Equals(default(TSize)) && buffErrs.ConvertAll(e => (HRESULT)e).Contains(err.ToHRESULT());

#nullable disable
	/// <summary>Helper function for functions that retrieve an object based on an IID.</summary>
	/// <typeparam name="T">The type of the object to retrieve.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="f">The function.</param>
	/// <param name="throwOnError">If set to <see langword="true"/>, throw an exception on error. Otherwise, just return <see langword="null"/>.</param>
	/// <returns>
	/// The returned object case to <typeparamref name="T"/>, or <see langword="null"/> on failure and <paramref name="throwOnError"/> is
	/// <see langword="true"/>.
	/// </returns>
	public static T IidGetObj<T, TErr>(IidFunc<TErr> f, bool throwOnError = true) where T : class where TErr : IErrorProvider
	{
		TErr hr = IidGetObj(f, out T ppv);
		if (hr.Failed && throwOnError)
			throw hr.GetException()!;
		return ppv;
	}

	/// <summary>Helper function for functions that retrieve an object based on an IID.</summary>
	/// <typeparam name="T">The type of the object to retrieve.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="f">The function.</param>
	/// <param name="ppv">The returned object case to <typeparamref name="T" />, or <see langword="null" /> on failure.</param>
	/// <returns>The error returned by <paramref name="f"/>.</returns>
	public static TErr IidGetObj<T, TErr>(IidFunc<TErr> f, out T ppv) where T : class where TErr : IErrorProvider
	{
		var hr = f(typeof(T).GUID, out var pv);
		ppv = hr.Succeeded ? (T)pv : default;
		return hr;
	}

	/// <summary>Helper function for functions that retrieve an object based on an IID.</summary>
	/// <typeparam name="T">The type of the object to retrieve.</typeparam>
	/// <param name="f">The function.</param>
	/// <param name="ppv">The returned object case to <typeparamref name="T" />, or <see langword="null" /> on failure.</param>
	/// <returns>The error returned by <paramref name="f"/>.</returns>
	public static void IidGetObj<T>(IidFunc f, out T ppv) where T : class
	{
		f(typeof(T).GUID, out var pv);
		ppv = (T)pv;
	}

	/// <summary>Helper function for functions that retrieve an object based on an IID.</summary>
	/// <typeparam name="T">The type of the object to retrieve.</typeparam>
	/// <typeparam name="TIn1">The type of the first parameter.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="f">The function.</param>
	/// <param name="p1">The first parameter.</param>
	/// <param name="throwOnError">If set to <see langword="true" />, throw an exception on error. Otherwise, just return <see langword="null" />.</param>
	/// <returns>
	/// The returned object case to <typeparamref name="T" />, or <see langword="null" /> on failure and <paramref name="throwOnError" /> is
	/// <see langword="true" />.
	/// </returns>
	public static T IidGetObj<T, TIn1, TErr>(IidFunc1<TIn1, TErr> f, TIn1 p1, bool throwOnError = true) where T : class where TErr : IErrorProvider
	{
		TErr hr = IidGetObj(f, p1, out T ppv);
		if (hr.Failed && throwOnError)
			throw hr.GetException()!;
		return ppv;
	}

	/// <summary>Helper function for functions that retrieve an object based on an IID.</summary>
	/// <typeparam name="T">The type of the object to retrieve.</typeparam>
	/// <typeparam name="TIn1">The type of the first parameter.</typeparam>
	/// <typeparam name="TErr">The type of the error.</typeparam>
	/// <param name="f">The function.</param>
	/// <param name="p1">The first parameter.</param>
	/// <param name="ppv">The returned object case to <typeparamref name="T" />, or <see langword="null" /> on failure.</param>
	/// <returns>The error returned by <paramref name="f"/>.</returns>
	public static TErr IidGetObj<T, TIn1, TErr>(IidFunc1<TIn1, TErr> f, TIn1 p1, out T ppv) where T : class where TErr : IErrorProvider
	{
		var hr = f(p1, typeof(T).GUID, out var pv);
		ppv = hr.Succeeded ? (T)pv : default;
		return hr;
	}

	/// <summary>Helper function for functions that retrieve an object based on an IID.</summary>
	/// <typeparam name="T">The type of the object to retrieve.</typeparam>
	/// <typeparam name="TIn1">The type of the first parameter.</typeparam>
	/// <param name="f">The function.</param>
	/// <param name="p1">The first parameter.</param>
	/// <param name="ppv">The returned object case to <typeparamref name="T" />, or <see langword="null" /> on failure.</param>
	/// <returns>The error returned by <paramref name="f"/>.</returns>
	public static void IidGetObj<T, TIn1>(IidFunc1<TIn1> f, TIn1 p1, out T ppv) where T : class
	{
		f(p1, typeof(T).GUID, out var pv);
		ppv = (T)pv;
	}
#nullable restore

	private static bool IsNotDef<TSize, TRet>(TSize _sz, TRet _ret) where TSize : struct, IConvertible => !_sz.Equals(default(TSize));
}