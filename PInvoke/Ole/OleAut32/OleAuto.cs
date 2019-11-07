using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from oleaut.h</summary>
	public static partial class OleAut32
	{
		/// <summary>Controls how a type library is registered.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/ne-oleauto-regkind typedef enum tagREGKIND { REGKIND_DEFAULT,
		// REGKIND_REGISTER, REGKIND_NONE } REGKIND;
		[PInvokeData("oleauto.h", MSDNShortId = "2ca13d58-59d2-4e5d-8094-9f1c03bf463c")]
		public enum REGKIND
		{
			/// <summary>Use default register behavior.</summary>
			REGKIND_DEFAULT,

			/// <summary>Register this type library.</summary>
			REGKIND_REGISTER,

			/// <summary>Do not register this type library.</summary>
			REGKIND_NONE,
		}

		/// <summary>Returns a BSTR, assigning each element of the vector to a character in the BSTR.</summary>
		/// <param name="psa">The vector to be converted to a BSTR.</param>
		/// <param name="pbstr">A BSTR, each character of which is assigned to an element from the vector.</param>
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
		/// <term>Out of memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The psa parameter is null.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_TYPEMISMATCH</term>
		/// <term>The argument psa is not a vector (not an array of bytes).</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-bstrfromvector HRESULT BstrFromVector( SAFEARRAY *psa, BSTR
		// *pbstr );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "26955616-698b-4f63-b652-af7dfaa23e43")]
		public static extern HRESULT BstrFromVector(in SAFEARRAY psa, [MarshalAs(UnmanagedType.BStr)] out string pbstr);

		/// <summary>Releases memory used to hold the custom data item.</summary>
		/// <param name="pCustData">The custom data item to be released.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-clearcustdata void ClearCustData( LPCUSTDATA pCustData );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "14556107-3b22-48c8-b480-280b9dee9b17")]
		public static extern void ClearCustData(ref CUSTDATA pCustData);

		/// <summary>Creates simplified type information for use in an implementation of IDispatch.</summary>
		/// <param name="pidata">The interface description that this type information describes.</param>
		/// <param name="lcid">The locale identifier for the names used in the type information.</param>
		/// <param name="pptinfo">On return, pointer to a type information implementation for use in DispGetIDsOfNames and DispInvoke.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The interface is supported.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Either the interface description or the LCID is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can construct type information at run time by using <c>CreateDispTypeInfo</c> and an INTERFACEDATA structure that describes
		/// the object being exposed.
		/// </para>
		/// <para>
		/// The type information returned by this function is primarily designed to automate the implementation of IDispatch.
		/// <c>CreateDispTypeInfo</c> does not return all of the type information described in Type Description Interfaces. The argument
		/// pidata is not a complete description of an interface. It does not include Help information, comments, optional parameters, and
		/// other type information that is useful in different contexts.
		/// </para>
		/// <para>
		/// Accordingly, the recommended method for providing type information about an object is to describe the object using the Object
		/// Description Language (ODL), and to compile the object description into a type library using the Microsoft Interface Definition
		/// Language (MIDL) compiler.
		/// </para>
		/// <para>
		/// To use type information from a type library, use the LoadTypeLib and GetTypeInfoOfGuid functions instead of
		/// <c>CreateDispTypeInfo</c>. For more information Type Description Interfaces.
		/// </para>
		/// <para>Examples</para>
		/// <para>The code that follows creates type information from INTERFACEDATA to expose the CCalc object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-createdisptypeinfo HRESULT CreateDispTypeInfo(
		// INTERFACEDATA *pidata, LCID lcid, ITypeInfo **pptinfo );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "603e00e8-0370-4ebf-b9d2-85e6e58c2b3a")]
		public static extern HRESULT CreateDispTypeInfo(ref INTERFACEDATA pidata, LCID lcid, out ITypeInfo pptinfo);

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
		public static extern HRESULT CreateErrorInfo(out ICreateErrorInfo pperrinfo);

		/// <summary>
		/// Creates a standard implementation of the IDispatch interface through a single function call. This simplifies exposing objects
		/// through Automation.
		/// </summary>
		/// <param name="punkOuter">The object's <c>IUnknown</c> implementation.</param>
		/// <param name="pvThis">The object to expose.</param>
		/// <param name="ptinfo">The type information that describes the exposed object.</param>
		/// <param name="ppunkStdDisp">
		/// The private unknown for the object that implements the IDispatch interface QueryInterface call. This pointer is null if the
		/// function fails.
		/// </param>
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
		/// <term>E_INVALIDARG</term>
		/// <term>One of the first three arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There was insufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can use <c>CreateStdDispatch</c> when creating an object instead of implementing the IDispatch member functions for the
		/// object. However, the implementation that <c>CreateStdDispatch</c> creates has these limitations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Supports only one national language.</term>
		/// </item>
		/// <item>
		/// <term>Supports only dispatch-defined exception codes returned from Invoke.</term>
		/// </item>
		/// </list>
		/// <para>
		/// LoadTypeLib, GetTypeInfoOfGuid, and <c>CreateStdDispatch</c> comprise the minimum set of functions that you need to call to
		/// expose an object using a type library. For more information on <c>LoadTypeLib</c> and <c>GetTypeInfoOfGuid</c>, see Type
		/// Description Interfaces.
		/// </para>
		/// <para>
		/// CreateDispTypeInfo and <c>CreateStdDispatch</c> comprise the minimum set of dispatch components you need to call to expose an
		/// object using type information provided by the INTERFACEDATA structure.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code implements the <c>IDispatch</c> interface for the <c>CCalc</c> class using <c>CreateStdDispatch</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-createstddispatch HRESULT CreateStdDispatch( IUnknown
		// *punkOuter, void *pvThis, ITypeInfo *ptinfo, IUnknown **ppunkStdDisp );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "45a59243-df93-41ca-ac60-354cb1165004")]
		public static extern HRESULT CreateStdDispatch([MarshalAs(UnmanagedType.IUnknown)] object punkOuter, IntPtr pvThis, ITypeInfo ptinfo, [MarshalAs(UnmanagedType.IUnknown)] out object ppunkStdDisp);

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
		/// This function returns a pointer to the most recently set IErrorInfo pointer in the current logical thread. It transfers
		/// ownership of the error object to the caller, and clears the error state for the thread.
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
		public static extern HRESULT GetErrorInfo([Optional] uint dwReserved, out IErrorInfo pperrinfo);

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
		/// Virtual function table (VTBL) binding controllers that do not use IDispatch::Invoke can get the error information object by
		/// using GetErrorInfo. This allows an object that supports a dual interface to use <c>SetErrorInfo</c>, regardless of whether the
		/// client uses VTBL binding or IDispatch.
		/// </para>
		/// <para>When a cross apartment call is made COM clears out any error object.</para>
		/// <para>
		/// Making a COM call that goes through a proxy-stub will clear any existing error object for the calling thread. A called object
		/// should not make any such calls after calling <c>SetErrorInfo</c> and before returning. The caller should not make any such calls
		/// after the call returns and before calling GetErrorInfo. As a rule of thumb, an interface method should return as soon as
		/// possible after calling <c>SetErrorInfo</c>, and the caller should call <c>GetErrorInfo</c> as soon as possible after the call returns.
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
		public static extern HRESULT SetErrorInfo([Optional] uint dwReserved, IErrorInfo perrinfo);

		/// <summary>Clears a variant.</summary>
		/// <param name="pvarg">The variant to clear.</param>
		/// <returns>S_OK on success.</returns>
		[DllImport(Lib.OleAut32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221165")]
		public static extern HRESULT VariantClear(IntPtr pvarg);

		/// <summary>Describes the object's properties and methods.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/ns-oleauto-interfacedata typedef struct tagINTERFACEDATA { METHODDATA
		// *pmethdata; UINT cMembers; } INTERFACEDATA, *LPINTERFACEDATA;
		[PInvokeData("oleauto.h", MSDNShortId = "3eafe5ba-45d9-4b0d-b3f8-68f5e99df5bb")]
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERFACEDATA
		{
			/// <summary>An array of METHODDATA structures.</summary>
			public IntPtr pmethdata;

			/// <summary>The count of members.</summary>
			public uint cMembers;
		}

		/// <summary>Describes a method or property.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/ns-oleauto-methoddata typedef struct tagMETHODDATA { OLECHAR *szName;
		// PARAMDATA *ppdata; DISPID dispid; UINT iMeth; CALLCONV cc; UINT cArgs; WORD wFlags; VARTYPE vtReturn; } METHODDATA, *LPMETHODDATA;
		[PInvokeData("oleauto.h", MSDNShortId = "85fd7121-3eed-4a83-9ba2-caa81fa1e048")]
		[StructLayout(LayoutKind.Sequential)]
		public struct METHODDATA
		{
			/// <summary>The method name.</summary>
			public StrPtrUni szName;

			/// <summary>An array of method parameters.</summary>
			public IntPtr ppdata;

			/// <summary>The ID of the method, as used in IDispatch.</summary>
			public int dispid;

			/// <summary>The index of the method in the VTBL of the interface, starting with 0.</summary>
			public uint iMeth;

			/// <summary>
			/// The calling convention. The CDECL and Pascal calling conventions are supported by the dispatch interface creation functions,
			/// such as CreateStdDispatch.
			/// </summary>
			public CALLCONV cc;

			/// <summary>The number of arguments.</summary>
			public uint cArgs;

			/// <summary>
			/// <para>Invoke flags.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DISPATCH_METHOD</term>
			/// <term>
			/// The member is invoked as a method. If a property has the same name, both this and the DISPATCH_PROPERTYGET flag can be set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DISPATCH_PROPERTYGET</term>
			/// <term>The member is retrieved as a property or data member.</term>
			/// </item>
			/// <item>
			/// <term>DISPATCH_PROPERTYPUT</term>
			/// <term>The member is set as a property or data member.</term>
			/// </item>
			/// <item>
			/// <term>DISPATCH_PROPERTYPUTREF</term>
			/// <term>
			/// The member is changed by a reference assignment, rather than a value assignment. This flag is valid only when the property
			/// accepts a reference to an object.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort wFlags;

			/// <summary>The return type for the method.</summary>
			public Ole32.VARTYPE vtReturn;
		}

		/// <summary>Specifies numeric parsing information.</summary>
		/// <remarks>
		/// <para>The following apply only to decimal numbers:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>nPwr10</c> sets the decimal point position by giving the power of 10 of the least significant digit.</term>
		/// </item>
		/// <item>
		/// <term>If the number is negative, <c>NUMPRS_NEG</c> will be set in <c>dwOutFlags</c>.</term>
		/// </item>
		/// <item>
		/// <term>If there are more non-zero decimal digits than will fit into the digit array, the NUMPRS_INEXACT flag will be set.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/ns-oleauto-numparse typedef struct { INT cDig; ULONG dwInFlags; ULONG
		// dwOutFlags; INT cchUsed; INT nBaseShift; INT nPwr10; } NUMPARSE;
		[PInvokeData("oleauto.h", MSDNShortId = "d55034ff-4407-40ba-bee3-8e82cd5c497e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NUMPARSE
		{
			/// <summary>On input, the size of the array. On output, the number of items written to the rgbDig array.</summary>
			public int cDig;

			/// <summary>
			/// <para>Input flags.</para>
			/// <para>NUMPRS_CURRENCY (0x0400)</para>
			/// <para>NUMPRS_DECIMAL (0x0100)</para>
			/// <para>NUMPRS_EXPONENT (0x0800)</para>
			/// <para>NUMPRS_HEX_OCT (0x0040)</para>
			/// <para>NUMPRS_LEADING_MINUS (0x0100)</para>
			/// <para>NUMPRS_LEADING_PLUS (0x0004)</para>
			/// <para>NUMPRS_LEADING_WHITE (0x0001)</para>
			/// <para>NUMPRS_PARENS (0x0080)</para>
			/// <para>NUMPRS_STD (0x1FFF)</para>
			/// <para>NUMPRS_THOUSANDS (0x0200)</para>
			/// <para>NUMPRS_TRAILING_MINUS (0x0020)</para>
			/// <para>NUMPRS_TRAILING_PLUS (0x0008)</para>
			/// <para>NUMPRS_TRAILING_WHITE (0x0002)</para>
			/// <para>NUMPRS_USE_ALL (0x1000)</para>
			/// </summary>
			public uint dwInFlags;

			/// <summary>
			/// <para>Output flags. Includes all the values for <c>dwInFlags</c>, plus the following values.</para>
			/// <para>NUMPRS_INEXACT (0x20000)</para>
			/// <para>NUMPRS_NEG (0x10000)</para>
			/// </summary>
			public uint dwOutFlags;

			/// <summary>Receives the number of characters (from the beginning of the string) that were successfully parsed.</summary>
			public int cchUsed;

			/// <summary>The number of bits per digit (3 or 4 for octal and hexadecimal numbers, and zero for decimal).</summary>
			public int nBaseShift;

			/// <summary>The decimal point position.</summary>
			public int nPwr10;
		}

		/// <summary>Describes a parameter accepted by a method or property.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/ns-oleauto-paramdata typedef struct tagPARAMDATA { OLECHAR *szName;
		// VARTYPE vt; } PARAMDATA, *LPPARAMDATA;
		[PInvokeData("oleauto.h", MSDNShortId = "3166eac0-7e07-47e1-9bca-60b15cbdf971")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PARAMDATA
		{
			/// <summary>
			/// The parameter name. Names should follow standard conventions for programming language access; that is, no embedded spaces or
			/// control characters, and 32 or fewer characters. The name should be localized because each type description provides names
			/// for a particular locale.
			/// </summary>
			public StrPtrUni szName;

			/// <summary>The parameter type. If more than one parameter type is accepted, VT_VARIANT should be specified.</summary>
			public Ole32.VARTYPE vt;
		}

		/*
		CreateTypeLib
		CreateTypeLib2
		DispCallFunc
		DispGetIDsOfNames
		DispGetParam
		DispInvoke
		DosDateTimeToVariantTime
		GetActiveObject
		GetAltMonthNames
		GetRecordInfoFromGuids
		GetRecordInfoFromTypeInfo
		LHashValOfName
		LHashValOfNameSys
		LHashValOfNameSysA
		LoadRegTypeLib
		LoadTypeLib
		LoadTypeLibEx
		OaBuildVersion
		OaEnablePerUserTLibRegistration
		QueryPathOfRegTypeLib
		RegisterActiveObject
		RegisterTypeLib
		RegisterTypeLibForUser
		RevokeActiveObject
		SafeArrayAccessData
		SafeArrayAddRef
		SafeArrayAllocData
		SafeArrayAllocDescriptor
		SafeArrayAllocDescriptorEx
		SafeArrayCopy
		SafeArrayCopyData
		SafeArrayCreate
		SafeArrayCreateEx
		SafeArrayCreateVector
		SafeArrayCreateVectorEx
		SafeArrayDestroy
		SafeArrayDestroyData
		SafeArrayDestroyDescriptor
		SafeArrayGetDim
		SafeArrayGetElement
		SafeArrayGetElemsize
		SafeArrayGetIID
		SafeArrayGetLBound
		SafeArrayGetRecordInfo
		SafeArrayGetUBound
		SafeArrayGetVartype
		SafeArrayLock
		SafeArrayPtrOfIndex
		SafeArrayPutElement
		SafeArrayRedim
		SafeArrayReleaseData
		SafeArrayReleaseDescriptor
		SafeArraySetIID
		SafeArraySetRecordInfo
		SafeArrayUnaccessData
		SafeArrayUnlock
		SysAddRefString
		SysAllocString
		SysAllocStringByteLen
		SysAllocStringLen
		SysFreeString
		SysReAllocString
		SysReAllocStringLen
		SysReleaseString
		SysStringByteLen
		SysStringLen
		SystemTimeToVariantTime
		UnRegisterTypeLib
		UnRegisterTypeLibForUser
		VarAbs
		VarAdd
		VarAnd
		VarBoolFromCy
		VarBoolFromDate
		VarBoolFromDec
		VarBoolFromDisp
		VarBoolFromI1
		VarBoolFromI2
		VarBoolFromI4
		VarBoolFromI8
		VarBoolFromR4
		VarBoolFromR8
		VarBoolFromStr
		VarBoolFromUI1
		VarBoolFromUI2
		VarBoolFromUI4
		VarBoolFromUI8
		VarBstrCat
		VarBstrCmp
		VarBstrFromBool
		VarBstrFromCy
		VarBstrFromDate
		VarBstrFromDec
		VarBstrFromDisp
		VarBstrFromI1
		VarBstrFromI2
		VarBstrFromI4
		VarBstrFromI8
		VarBstrFromR4
		VarBstrFromR8
		VarBstrFromUI1
		VarBstrFromUI2
		VarBstrFromUI4
		VarBstrFromUI8
		VarCat
		VarCmp
		VarCyAbs
		VarCyAdd
		VarCyCmp
		VarCyCmpR8
		VarCyFix
		VarCyFromBool
		VarCyFromDate
		VarCyFromDec
		VarCyFromDisp
		VarCyFromI1
		VarCyFromI2
		VarCyFromI4
		VarCyFromI8
		VarCyFromR4
		VarCyFromR8
		VarCyFromStr
		VarCyFromUI1
		VarCyFromUI2
		VarCyFromUI4
		VarCyFromUI8
		VarCyInt
		VarCyMul
		VarCyMulI4
		VarCyMulI8
		VarCyNeg
		VarCyRound
		VarCySub
		VarDateFromBool
		VarDateFromCy
		VarDateFromDec
		VarDateFromDisp
		VarDateFromI1
		VarDateFromI2
		VarDateFromI4
		VarDateFromI8
		VarDateFromR4
		VarDateFromR8
		VarDateFromStr
		VarDateFromUdate
		VarDateFromUdateEx
		VarDateFromUI1
		VarDateFromUI2
		VarDateFromUI4
		VarDateFromUI8
		VarDecAbs
		VarDecAdd
		VarDecCmp
		VarDecCmpR8
		VarDecDiv
		VarDecFix
		VarDecFromBool
		VarDecFromCy
		VarDecFromDate
		VarDecFromDisp
		VarDecFromI1
		VarDecFromI2
		VarDecFromI4
		VarDecFromI8
		VarDecFromR4
		VarDecFromR8
		VarDecFromStr
		VarDecFromUI1
		VarDecFromUI2
		VarDecFromUI4
		VarDecFromUI8
		VarDecInt
		VarDecMul
		VarDecNeg
		VarDecRound
		VarDecSub
		VarDiv
		VarEqv
		VarFix
		VarFormat
		VarFormatCurrency
		VarFormatDateTime
		VarFormatFromTokens
		VarFormatNumber
		VarFormatPercent
		VarI1FromBool
		VarI1FromCy
		VarI1FromDate
		VarI1FromDec
		VarI1FromDisp
		VarI1FromI2
		VarI1FromI4
		VarI1FromI8
		VarI1FromR4
		VarI1FromR8
		VarI1FromStr
		VarI1FromUI1
		VarI1FromUI2
		VarI1FromUI4
		VarI1FromUI8
		VarI2FromBool
		VarI2FromCy
		VarI2FromDate
		VarI2FromDec
		VarI2FromDisp
		VarI2FromI1
		VarI2FromI4
		VarI2FromI8
		VarI2FromR4
		VarI2FromR8
		VarI2FromStr
		VarI2FromUI1
		VarI2FromUI2
		VarI2FromUI4
		VarI2FromUI8
		VarI4FromBool
		VarI4FromCy
		VarI4FromDate
		VarI4FromDec
		VarI4FromDisp
		VarI4FromI1
		VarI4FromI2
		VarI4FromI4
		VarI4FromI8
		VarI4FromR4
		VarI4FromR8
		VarI4FromStr
		VarI4FromUI1
		VarI4FromUI2
		VarI4FromUI4
		VarI4FromUI8
		VarI8FromBool
		VarI8FromCy
		VarI8FromDate
		VarI8FromDec
		VarI8FromDisp
		VarI8FromI1
		VarI8FromI2
		VarI8FromR4
		VarI8FromR8
		VarI8FromStr
		VarI8FromUI1
		VarI8FromUI2
		VarI8FromUI4
		VarI8FromUI8
		VariantChangeType
		VariantChangeTypeEx
		VariantCopy
		VariantCopyInd
		VariantInit
		VariantTimeToDosDateTime
		VariantTimeToSystemTime
		VarIdiv
		VarImp
		VarInt
		VarMod
		VarMonthName
		VarMul
		VarNeg
		VarNot
		VarNumFromParseNum
		VarOr
		VarParseNumFromStr
		VarPow
		VarR4CmpR8
		VarR4FromBool
		VarR4FromCy
		VarR4FromDate
		VarR4FromDec
		VarR4FromDisp
		VarR4FromI1
		VarR4FromI2
		VarR4FromI4
		VarR4FromI8
		VarR4FromR8
		VarR4FromStr
		VarR4FromUI1
		VarR4FromUI2
		VarR4FromUI4
		VarR4FromUI8
		VarR8FromBool
		VarR8FromCy
		VarR8FromDate
		VarR8FromDec
		VarR8FromDisp
		VarR8FromI1
		VarR8FromI2
		VarR8FromI4
		VarR8FromI8
		VarR8FromR4
		VarR8FromStr
		VarR8FromUI1
		VarR8FromUI2
		VarR8FromUI4
		VarR8FromUI8
		VarR8Pow
		VarR8Round
		VarRound
		VarSub
		VarTokenizeFormatString
		VarUdateFromDate
		VarUI1FromBool
		VarUI1FromCy
		VarUI1FromDate
		VarUI1FromDec
		VarUI1FromDisp
		VarUI1FromI1
		VarUI1FromI2
		VarUI1FromI4
		VarUI1FromI8
		VarUI1FromR4
		VarUI1FromR8
		VarUI1FromStr
		VarUI1FromUI2
		VarUI1FromUI4
		VarUI1FromUI8
		VarUI2FromBool
		VarUI2FromCy
		VarUI2FromDate
		VarUI2FromDec
		VarUI2FromDisp
		VarUI2FromI1
		VarUI2FromI2
		VarUI2FromI4
		VarUI2FromI8
		VarUI2FromR4
		VarUI2FromR8
		VarUI2FromStr
		VarUI2FromUI1
		VarUI2FromUI4
		VarUI2FromUI8
		VarUI4FromBool
		VarUI4FromCy
		VarUI4FromDate
		VarUI4FromDec
		VarUI4FromDisp
		VarUI4FromI1
		VarUI4FromI2
		VarUI4FromI4
		VarUI4FromI8
		VarUI4FromR4
		VarUI4FromR8
		VarUI4FromStr
		VarUI4FromUI1
		VarUI4FromUI2
		VarUI4FromUI8
		VarUI8FromBool
		VarUI8FromCy
		VarUI8FromDate
		VarUI8FromDec
		VarUI8FromDisp
		VarUI8FromI1
		VarUI8FromI2
		VarUI8FromI8
		VarUI8FromR4
		VarUI8FromR8
		VarUI8FromStr
		VarUI8FromUI1
		VarUI8FromUI2
		VarUI8FromUI4
		VarWeekdayName
		VarXor
		VectorFromBstr
		*/
	}
}