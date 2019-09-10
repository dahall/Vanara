using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from oleaut.h</summary>
	public static partial class OleAut32
	{
		/// <summary>Creates an instance of a generic error object.</summary>
		/// <param name="pperrinfo">A system-implemented generic error object.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Could not create the error object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function returns a pointer to a generic error object, which you can use with <c>QueryInterface</c> on ICreateErrorInfo to
		/// set its contents. You can then pass the resulting object to SetErrorInfo. The generic error object implements both
		/// <c>ICreateErrorInfo</c> and IErrorInfo.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-createerrorinfo HRESULT CreateErrorInfo( ICreateErrorInfo
		// **pperrinfo );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "6a9dd862-754a-48e3-8be5-d1fbd1d38f2b")]
		public static extern HRESULT CreateErrorInfo(out Ole32.ICreateErrorInfo pperrinfo);

		/// <summary>Obtains the error information pointer set by the previous call to SetErrorInfo in the current logical thread.</summary>
		/// <param name="dwReserved">Reserved for future use. Must be zero.</param>
		/// <param name="pperrinfo">An error object.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>There was no error object to return.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function returns a pointer to the most recently set IErrorInfo pointer in the current logical thread. It transfers ownership
		/// of the error object to the caller, and clears the error state for the thread.
		/// </para>
		/// <para>
		/// Making a COM call that goes through a proxy-stub will clear any existing error object for the calling thread. A called object
		/// should not make any such calls after calling SetErrorInfo and before returning. The caller should not make any such calls after
		/// the call returns and before calling <c>GetErrorInfo</c>. As a rule of thumb, an interface method should return as soon as
		/// possible after calling <c>SetErrorInfo</c>, and the caller should call <c>GetErrorInfo</c> as soon as possible after the call returns.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-geterrorinfo HRESULT GetErrorInfo( ULONG dwReserved,
		// IErrorInfo **pperrinfo );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "03317526-8c4f-4173-bc10-110c8112676a")]
		public static extern HRESULT GetErrorInfo([Optional] uint dwReserved, out Ole32.IErrorInfo pperrinfo);

		/// <summary>Sets the error information object for the current logical thread of execution.</summary>
		/// <param name="dwReserved">Reserved for future use. Must be zero.</param>
		/// <param name="perrinfo">An error object.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// This function releases the existing error information object, if one exists, and sets the pointer to perrinfo. Use this function
		/// after creating an error object that associates the object with the current logical thread of execution.
		/// </para>
		/// <para>
		/// If the property or method that calls <c>SetErrorInfo</c> is called by DispInvoke, then <c>DispInvoke</c> will fill the EXCEPINFO
		/// parameter with the values specified in the error information object. <c>DispInvoke</c> will return DISP_E_EXCEPTION when the
		/// property or method returns a failure return value for <c>DispInvoke</c>
		/// </para>
		/// <para>
		/// Virtual function table (VTBL) binding controllers that do not use IDispatch::Invoke can get the error information object by using
		/// GetErrorInfo. This allows an object that supports a dual interface to use <c>SetErrorInfo</c>, regardless of whether the client
		/// uses VTBL binding or IDispatch.
		/// </para>
		/// <para>When a cross apartment call is made COM clears out any error object.</para>
		/// <para>
		/// Making a COM call that goes through a proxy-stub will clear any existing error object for the calling thread. A called object
		/// should not make any such calls after calling <c>SetErrorInfo</c> and before returning. The caller should not make any such calls
		/// after the call returns and before calling GetErrorInfo. As a rule of thumb, an interface method should return as soon as possible
		/// after calling <c>SetErrorInfo</c>, and the caller should call <c>GetErrorInfo</c> as soon as possible after the call returns.
		/// </para>
		/// <para>
		/// Entering the COM modal message loop will clear any existing error object. A called object should not enter a message loop after
		/// calling <c>SetErrorInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-seterrorinfo HRESULT SetErrorInfo( ULONG dwReserved,
		// IErrorInfo *perrinfo );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "8eaacfac-fc37-4eaa-870b-10b99d598d66")]
		public static extern HRESULT SetErrorInfo([Optional] uint dwReserved, Ole32.IErrorInfo perrinfo);

		/// <summary>Clears a variant.</summary>
		/// <param name="pvarg">The variant to clear.</param>
		/// <returns>S_OK on success.</returns>
		[DllImport(Lib.OleAut32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221165")]
		public static extern HRESULT VariantClear(IntPtr pvarg);
	}
}