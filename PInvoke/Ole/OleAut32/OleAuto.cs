using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;
using DISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;
using SYSKIND = System.Runtime.InteropServices.ComTypes.SYSKIND;

namespace Vanara.PInvoke;

/// <summary>Platform invokable enumerated types, constants and functions from oleaut.h</summary>
public static partial class OleAut32
{
	/// <summary>Flags describing the context of the call.</summary>
	[PInvokeData("oleauto.h", MSDNShortId = "69b89e5c-2a04-4a6a-beb0-18e68f8866ac")]
	[Flags]
	public enum DispInvokeFlags : ushort
	{
		/// <summary>
		/// The member is invoked as a method. If a property has the same name, both this and the DISPATCH_PROPERTYGET flag can be set.
		/// </summary>
		DISPATCH_METHOD = 0x1,

		/// <summary>The member is retrieved as a property or data member.</summary>
		DISPATCH_PROPERTYGET = 0x2,

		/// <summary>The member is changed as a property or data member.</summary>
		DISPATCH_PROPERTYPUT = 0x4,

		/// <summary>
		/// The member is changed by a reference assignment, rather than a value assignment. This flag is valid only when the property
		/// accepts a reference to an object.
		/// </summary>
		DISPATCH_PROPERTYPUTREF = 0x8,
	}

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
	public static extern HRESULT CreateStdDispatch([MarshalAs(UnmanagedType.IUnknown)] object punkOuter, IntPtr pvThis, ITypeInfo ptinfo,
		[MarshalAs(UnmanagedType.IUnknown)] out object? ppunkStdDisp);

	/// <summary>Provides access to a new object instance that supports the ICreateTypeLib interface.</summary>
	/// <param name="syskind">The target operating system for which to create a type library.</param>
	/// <param name="szFile">The name of the file to create.</param>
	/// <param name="ppctlib">The ICreateTypeLib interface.</param>
	/// <returns>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>STG_E_INSUFFICIENTMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not create the file.</term>
	/// </item>
	/// </list>
	/// <para>This method can also return the FACILITY_STORAGE errors.</para>
	/// </returns>
	/// <remarks>
	/// <c>CreateTypeLib</c> sets its output parameter (ppctlib) to point to a newly created object that supports the ICreateTypeLib interface.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-createtypelib HRESULT CreateTypeLib( SYSKIND syskind,
	// LPCOLESTR szFile, ICreateTypeLib **ppctlib );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "c7a94d5b-7ac5-4b7c-8aed-ead23de9ea75")]
	public static extern HRESULT CreateTypeLib(SYSKIND syskind, [MarshalAs(UnmanagedType.LPWStr)] string szFile, out ICreateTypeLib ppctlib);

	/// <summary>
	/// <para>Creates a type library in the current file format.</para>
	/// <para>
	/// The file and in-memory format for the current version of Automation makes use of memory-mapped files. The CreateTypeLib function
	/// is still available for creating a type library in the older format.
	/// </para>
	/// </summary>
	/// <param name="syskind">The target operating system for which to create a type library.</param>
	/// <param name="szFile">The name of the file to create.</param>
	/// <param name="ppctlib">The ICreateTypeLib2 interface.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-createtypelib2 HRESULT CreateTypeLib2( SYSKIND syskind,
	// LPCOLESTR szFile, ICreateTypeLib2 **ppctlib );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "73df6ef2-fae1-4cfb-ba59-3812e3a2e3b9")]
	public static extern HRESULT CreateTypeLib2(SYSKIND syskind, [MarshalAs(UnmanagedType.LPWStr)] string szFile, out ICreateTypeLib2 ppctlib);

	/// <summary>Low-level helper for Invoke that provides machine independence for customized <c>Invoke</c>.</summary>
	/// <param name="pvInstance">An instance of the interface described by this type description.</param>
	/// <param name="oVft">For FUNC_VIRTUAL functions, specifies the offset in the VTBL.</param>
	/// <param name="cc">The calling convention. One of the CALLCONV values, such as CC_STDCALL.</param>
	/// <param name="vtReturn">The variant type of the function return value. Use VT_EMPTY to represent void.</param>
	/// <param name="cActuals">The number of function parameters.</param>
	/// <param name="prgvt">An array of variant types of the function parameters.</param>
	/// <param name="prgpvarg">The function parameters.</param>
	/// <param name="pvargResult">The function result.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dispcallfunc HRESULT DispCallFunc( void *pvInstance,
	// ULONG_PTR oVft, CALLCONV cc, VARTYPE vtReturn, UINT cActuals, VARTYPE *prgvt, VARIANTARG **prgpvarg, VARIANT *pvargResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "9a16d4e4-a03d-459d-a2ec-3258499f6932")]
	public static extern HRESULT DispCallFunc([Optional] IntPtr pvInstance, UIntPtr oVft, CALLCONV cc, VARTYPE vtReturn, uint cActuals,
		[In] VARTYPE[] prgvt, [In] IntPtr[] prgpvarg, out object pvargResult);

	/// <summary>Low-level helper for Invoke that provides machine independence for customized <c>Invoke</c>.</summary>
	/// <param name="ptinfo">
	/// The type information for an interface. This type information is specific to one interface and language code, so it is not
	/// necessary to pass an interface identifier (IID) or LCID to this function.
	/// </param>
	/// <param name="rgszNames">
	/// An array of name strings that can be the same array passed to DispInvoke in the DISPPARAMS structure. If cNames is greater than
	/// 1, the first name is interpreted as a method name, and subsequent names are interpreted as parameters to that method.
	/// </param>
	/// <param name="cNames">The number of elements in rgszNames.</param>
	/// <param name="rgdispid">
	/// An array of DISPIDs to be filled in by this function. The first ID corresponds to the method name. Subsequent IDs are
	/// interpreted as parameters to the method.
	/// </param>
	/// <returns>
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
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_UNKNOWNNAME</term>
	/// <term>
	/// One or more of the specified names were not known. The returned array of DISPIDs contains DISPID_UNKNOWN for each entry that
	/// corresponds to an unknown name.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Any of the <c>ITypeInfo::Invoke</c> errors can also be returned.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dispgetidsofnames HRESULT DispGetIDsOfNames( ITypeInfo
	// *ptinfo, LPOLESTR *rgszNames, UINT cNames, DISPID *rgdispid );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "720a0237-9c68-4252-9f66-43610d4be106")]
	public static extern HRESULT DispGetIDsOfNames(ITypeInfo ptinfo, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] rgszNames,
		uint cNames, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] rgdispid);

	/// <summary>
	/// Retrieves a parameter from the DISPPARAMS structure, checking both named parameters and positional parameters, and coerces the
	/// parameter to the specified type.
	/// </summary>
	/// <param name="pdispparams">The parameters passed to Invoke.</param>
	/// <param name="position">
	/// The position of the parameter in the parameter list. <c>DispGetParam</c> starts at the end of the array, so if position is 0,
	/// the last parameter in the array is returned.
	/// </param>
	/// <param name="vtTarg">The type the argument should be coerced to.</param>
	/// <param name="pvarResult">the variant to pass the parameter into.</param>
	/// <param name="puArgErr">
	/// On return, the index of the argument that caused a DISP_E_TYPEMISMATCH error. This pointer is returned to Invoke to indicate the
	/// position of the argument in DISPPARAMS that caused the error.
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
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The variant type vtTarg is not supported.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The retrieved parameter could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_PARAMNOTFOUND</term>
	/// <term>The parameter indicated by position could not be found.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The output parameter pvarResult must be a valid variant. Any existing contents are released in the standard way. The contents of
	/// the variant are freed with <c>VariantFree</c>.
	/// </para>
	/// <para>
	/// If you have used <c>DispGetParam</c> to get the right side of a property put operation, the second parameter should be
	/// DISPID_PROPERTYPUT. For example:
	/// </para>
	/// <para>Named parameters cannot be accessed positionally, and vice versa.</para>
	/// <para>Examples</para>
	/// <para>The following example uses <c>DispGetParam</c> to set X and Y properties.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dispgetparam HRESULT DispGetParam( DISPPARAMS *pdispparams,
	// UINT position, VARTYPE vtTarg, VARIANT *pvarResult, UINT *puArgErr );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "72cdb768-4791-4606-8e5d-72cd003e854a")]
	public static extern HRESULT DispGetParam(in DISPPARAMS pdispparams, uint position, VARTYPE vtTarg, out object pvarResult, out uint puArgErr);

	/// <summary>
	/// Automatically calls member functions on an interface, given the type information for the interface. You can describe an
	/// interface with type information and implement Invoke for the interface using this single call.
	/// </summary>
	/// <param name="_this">An implementation of the IDispatch interface described by ptinfo.</param>
	/// <param name="ptinfo">The type information that describes the interface.</param>
	/// <param name="dispidMember">The member to be invoked. Use GetIDsOfNames or the object's documentation to obtain the DISPID.</param>
	/// <param name="wFlags">
	/// <para>Flags describing the context of the Invoke call.</para>
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
	/// <term>The member is changed as a property or data member.</term>
	/// </item>
	/// <item>
	/// <term>DISPATCH_PROPERTYPUTREF</term>
	/// <term>
	/// The member is changed by a reference assignment, rather than a value assignment. This flag is valid only when the property
	/// accepts a reference to an object.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pparams">
	/// Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for number
	/// of elements in the arrays.
	/// </param>
	/// <param name="pvarResult">
	/// Pointer to where the result is to be stored, or Null if the caller expects no result. This argument is ignored if
	/// DISPATCH_PROPERTYPUT or DISPATCH_PROPERTYPUTREF is specified.
	/// </param>
	/// <param name="pexcepinfo">
	/// Pointer to a structure containing exception information. This structure should be filled in if DISP_E_EXCEPTION is returned.
	/// </param>
	/// <param name="puArgErr">
	/// The index within rgvarg of the first argument that has an error. Arguments are stored in pdispparams-&gt;rgvarg in reverse
	/// order, so the first argument is the one with the highest index in the array. This parameter is returned only when the resulting
	/// return value is DISP_E_TYPEMISMATCH or DISP_E_PARAMNOTFOUND.
	/// </param>
	/// <returns>
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
	/// <term>DISP_E_BADPARAMCOUNT</term>
	/// <term>The number of elements provided to DISPPARAMS is different from the number of arguments accepted by the method or property.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>One of the arguments in DISPPARAMS is not a valid variant type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_EXCEPTION</term>
	/// <term>The application needs to raise an exception. In this case, the structure passed in pexcepinfo should be filled in.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_MEMBERNOTFOUND</term>
	/// <term>The requested member does not exist.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_NONAMEDARGS</term>
	/// <term>This implementation of IDispatch does not support named arguments.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>One of the arguments in DISPPARAMS could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_PARAMNOTFOUND</term>
	/// <term>
	/// One of the parameter IDs does not correspond to a parameter on the method. In this case, puArgErr is set to the first argument
	/// that contains the error.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DISP_E_PARAMNOTOPTIONAL</term>
	/// <term>A required parameter was omitted.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>
	/// One or more of the arguments could not be coerced. The index of the first parameter with the incorrect type within rgvarg is
	/// returned in puArgErr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// <para>Any of the <c>ITypeInfo::Invoke</c> errors can also be returned.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The parameter _this is a pointer to an implementation of the interface that is being deferred to. <c>DispInvoke</c> builds a
	/// stack frame, coerces parameters using standard coercion rules, pushes them on the stack, and then calls the correct member
	/// function in the VTBL.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code from the Lines sample file Lines.cpp implements Invoke using <c>DispInvoke</c>. This implementation relies on
	/// <c>DispInvoke</c> to validate input arguments. To help minimize security risks, include code that performs more robust
	/// validation of the input arguments.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dispinvoke HRESULT DispInvoke( void *_this, ITypeInfo
	// *ptinfo, DISPID dispidMember, WORD wFlags, DISPPARAMS *pparams, VARIANT *pvarResult, EXCEPINFO *pexcepinfo, UINT *puArgErr );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "69b89e5c-2a04-4a6a-beb0-18e68f8866ac")]
	public static extern HRESULT DispInvoke(IntPtr _this, ITypeInfo ptinfo, int dispidMember, DispInvokeFlags wFlags, in DISPPARAMS pparams,
		[MarshalAs(UnmanagedType.Struct)] out object pvarResult, out EXCEPINFO pexcepinfo, out uint puArgErr);

	/// <summary>
	/// Automatically calls member functions on an interface, given the type information for the interface. You can describe an
	/// interface with type information and implement Invoke for the interface using this single call.
	/// </summary>
	/// <param name="_this">An implementation of the IDispatch interface described by ptinfo.</param>
	/// <param name="ptinfo">The type information that describes the interface.</param>
	/// <param name="dispidMember">The member to be invoked. Use GetIDsOfNames or the object's documentation to obtain the DISPID.</param>
	/// <param name="wFlags">
	/// <para>Flags describing the context of the Invoke call.</para>
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
	/// <term>The member is changed as a property or data member.</term>
	/// </item>
	/// <item>
	/// <term>DISPATCH_PROPERTYPUTREF</term>
	/// <term>
	/// The member is changed by a reference assignment, rather than a value assignment. This flag is valid only when the property
	/// accepts a reference to an object.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pparams">
	/// Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for number
	/// of elements in the arrays.
	/// </param>
	/// <param name="pvarResult">
	/// Pointer to where the result is to be stored, or Null if the caller expects no result. This argument is ignored if
	/// DISPATCH_PROPERTYPUT or DISPATCH_PROPERTYPUTREF is specified.
	/// </param>
	/// <param name="pexcepinfo">
	/// Pointer to a structure containing exception information. This structure should be filled in if DISP_E_EXCEPTION is returned.
	/// </param>
	/// <param name="puArgErr">
	/// The index within rgvarg of the first argument that has an error. Arguments are stored in pdispparams-&gt;rgvarg in reverse
	/// order, so the first argument is the one with the highest index in the array. This parameter is returned only when the resulting
	/// return value is DISP_E_TYPEMISMATCH or DISP_E_PARAMNOTFOUND.
	/// </param>
	/// <returns>
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
	/// <term>DISP_E_BADPARAMCOUNT</term>
	/// <term>The number of elements provided to DISPPARAMS is different from the number of arguments accepted by the method or property.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>One of the arguments in DISPPARAMS is not a valid variant type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_EXCEPTION</term>
	/// <term>The application needs to raise an exception. In this case, the structure passed in pexcepinfo should be filled in.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_MEMBERNOTFOUND</term>
	/// <term>The requested member does not exist.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_NONAMEDARGS</term>
	/// <term>This implementation of IDispatch does not support named arguments.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>One of the arguments in DISPPARAMS could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_PARAMNOTFOUND</term>
	/// <term>
	/// One of the parameter IDs does not correspond to a parameter on the method. In this case, puArgErr is set to the first argument
	/// that contains the error.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DISP_E_PARAMNOTOPTIONAL</term>
	/// <term>A required parameter was omitted.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>
	/// One or more of the arguments could not be coerced. The index of the first parameter with the incorrect type within rgvarg is
	/// returned in puArgErr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// <para>Any of the <c>ITypeInfo::Invoke</c> errors can also be returned.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The parameter _this is a pointer to an implementation of the interface that is being deferred to. <c>DispInvoke</c> builds a
	/// stack frame, coerces parameters using standard coercion rules, pushes them on the stack, and then calls the correct member
	/// function in the VTBL.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code from the Lines sample file Lines.cpp implements Invoke using <c>DispInvoke</c>. This implementation relies on
	/// <c>DispInvoke</c> to validate input arguments. To help minimize security risks, include code that performs more robust
	/// validation of the input arguments.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dispinvoke HRESULT DispInvoke( void *_this, ITypeInfo
	// *ptinfo, DISPID dispidMember, WORD wFlags, DISPPARAMS *pparams, VARIANT *pvarResult, EXCEPINFO *pexcepinfo, UINT *puArgErr );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "69b89e5c-2a04-4a6a-beb0-18e68f8866ac")]
	public static extern HRESULT DispInvoke(IntPtr _this, ITypeInfo ptinfo, int dispidMember, DispInvokeFlags wFlags, in DISPPARAMS pparams,
		[Optional] IntPtr pvarResult, out EXCEPINFO pexcepinfo, out uint puArgErr);

	/// <summary>Converts the MS-DOS representation of time to the date and time representation stored in a variant.</summary>
	/// <param name="wDosDate">
	/// The MS-DOS date to convert. The valid range of MS-DOS dates is January 1, 1980, to December 31, 2099, inclusive.
	/// </param>
	/// <param name="wDosTime">The MS-DOS time to convert.</param>
	/// <param name="pvtime">The converted time.</param>
	/// <returns>The function returns TRUE on success and FALSE otherwise.</returns>
	/// <remarks>
	/// <para>MS-DOS records file dates and times as packed 16-bit values. An MS-DOS date has the following format.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Bits</term>
	/// <term>Contents</term>
	/// </listheader>
	/// <item>
	/// <term>0–4</term>
	/// <term>Day of the month (1–31).</term>
	/// </item>
	/// <item>
	/// <term>5–8</term>
	/// <term>Month (1 = January, 2 = February, and so on).</term>
	/// </item>
	/// <item>
	/// <term>9–15</term>
	/// <term>Year offset from 1980 (add 1980 to get the actual year).</term>
	/// </item>
	/// </list>
	/// <para>An MS-DOS time has the following format.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Bits</term>
	/// <term>Contents</term>
	/// </listheader>
	/// <item>
	/// <term>0–4</term>
	/// <term>Second divided by 2.</term>
	/// </item>
	/// <item>
	/// <term>5–10</term>
	/// <term>Minute (0–59).</term>
	/// </item>
	/// <item>
	/// <term>11–15</term>
	/// <term>Hour (0– 23 on a 24-hour clock).</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>DosDateTimeToVariantTime</c> function will accept invalid dates and try to fix them when resolving to a VARIANT time. For
	/// example, an invalid date such as 2/29/2001 will resolve to 3/1/2001. Only days are fixed, so invalid month values result in an
	/// error being returned. Days are checked to be between 1 and 31. Negative days and days greater than 31 results in an error. A day
	/// less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month. A day
	/// equal to zero resolves as the last day of the previous month. For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-dosdatetimetovarianttime INT DosDateTimeToVariantTime(
	// USHORT wDosDate, USHORT wDosTime, DOUBLE *pvtime );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "61b029cb-8b60-400a-a6bb-a3f6839dc9d2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DosDateTimeToVariantTime(ushort wDosDate, ushort wDosTime, out double pvtime);

	/// <summary>Retrieves a pointer to a running object that has been registered with OLE.</summary>
	/// <param name="rclsid">The class identifier (CLSID) of the active object from the OLE registration database.</param>
	/// <param name="pvReserved">Reserved for future use. Must be null.</param>
	/// <param name="ppunk">The requested active object.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-getactiveobject HRESULT GetActiveObject( REFCLSID rclsid,
	// void *pvReserved, IUnknown **ppunk );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "a276e30c-6a7f-4cde-9639-21a9f5170b62")]
	public static extern HRESULT GetActiveObject(in Guid rclsid, [Optional] IntPtr pvReserved, [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

	/// <summary>Retrieves the secondary (alternate) month names.</summary>
	/// <param name="lcid">The locale identifier to be used in retrieving the alternate month names.</param>
	/// <param name="prgp">An array of pointers to strings containing the alternate month names.</param>
	/// <returns>The function returns TRUE on success and FALSE otherwise.</returns>
	/// <remarks>Useful for Hijri, Polish and Russian alternate month names.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-getaltmonthnames HRESULT GetAltMonthNames( LCID lcid,
	// LPOLESTR **prgp );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "dfde73f2-edb9-4ab9-9394-d859e61a6db8")]
	public static extern HRESULT GetAltMonthNames(LCID lcid, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler))] out string[] prgp);

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

	/// <summary>
	/// Returns a pointer to the IRecordInfo interface for a UDT by passing the GUID of the type information without having to load the
	/// type library.
	/// </summary>
	/// <param name="rGuidTypeLib">The GUID of the type library containing the UDT.</param>
	/// <param name="uVerMajor">The major version number of the type library of the UDT.</param>
	/// <param name="uVerMinor">The minor version number of the type library of the UDT.</param>
	/// <param name="lcid">The locale ID of the caller.</param>
	/// <param name="rGuidTypeInfo">The GUID of the typeinfo that describes the UDT.</param>
	/// <param name="ppRecInfo">The IRecordInfo interface.</param>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// A pointer to IRecordInfo can be serialized by writing out the GUIDs and version numbers and deserialized by loading the
	/// information and passing it to <c>GetRecordInfoFromGuids</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-getrecordinfofromguids HRESULT GetRecordInfoFromGuids(
	// REFGUID rGuidTypeLib, ULONG uVerMajor, ULONG uVerMinor, LCID lcid, REFGUID rGuidTypeInfo, IRecordInfo **ppRecInfo );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "0f132a13-ebcd-4886-b842-e6852d6fb2c8")]
	public static extern HRESULT GetRecordInfoFromGuids(in Guid rGuidTypeLib, uint uVerMajor, uint uVerMinor, LCID lcid, in Guid rGuidTypeInfo, out IRecordInfo ppRecInfo);

	/// <summary>
	/// Returns a pointer to the IRecordInfo interface of the UDT by passing its type information. The given ITypeInfo interface is used
	/// to create a RecordInfo object.
	/// </summary>
	/// <param name="pTypeInfo">The type information of a record.</param>
	/// <param name="ppRecInfo">The IRecordInfo interface.</param>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_UNSUPFORMAT</term>
	/// <term>The type is not an interface.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-getrecordinfofromtypeinfo HRESULT
	// GetRecordInfoFromTypeInfo( ITypeInfo *pTypeInfo, IRecordInfo **ppRecInfo );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "9bf2803f-7a6c-4574-80d2-4069f5b81057")]
	public static extern HRESULT GetRecordInfoFromTypeInfo(ITypeInfo pTypeInfo, out IRecordInfo ppRecInfo);

	/// <summary>Computes a hash value for a name.</summary>
	/// <param name="lcid">The LCID for the string.</param>
	/// <param name="szName">The string whose hash value is to be computed.</param>
	/// <returns>A hash value that represents the passed-in name.</returns>
	/// <remarks>
	/// <para>
	/// This function is equivalent to LHashValOfNameSys. The header file OleAuto.h contains macros that define <c>LHashValOfName</c> as
	/// <c>LHashValOfNameSys</c>, with the target operating system (syskind) based on the build preprocessor flags.
	/// </para>
	/// <para>
	/// <c>LHashValOfName</c> computes a 32-bit hash value for a name that can be passed to ITypeComp::Bind, ITypeComp::BindType,
	/// ITypeLib::FindName, or ITypeLib::IsName. The returned hash value is independent of the case of the characters in szName, as long
	/// as the language of the name is one of the languages supported by the OLE National Language Specification API. Any two strings
	/// that match when a case-insensitive comparison is done using any language produce the same hash value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-lhashvalofname void LHashValOfName( lcid, szName );
	[PInvokeData("oleauto.h", MSDNShortId = "7cd401dc-95d0-4628-88f9-d00969228ea8")]
	public static uint LHashValOfName(LCID lcid, string szName) => LHashValOfNameSys(SYSKIND.SYS_WIN32, lcid, szName);

	/// <summary>Computes a hash value for a name.</summary>
	/// <param name="syskind">The SYSKIND of the target operating system.</param>
	/// <param name="lcid">The LCID for the string.</param>
	/// <param name="szName">The string whose hash value is to be computed.</param>
	/// <returns>A hash value that represents the passed-in name.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-lhashvalofnamesys ULONG LHashValOfNameSys( SYSKIND syskind,
	// LCID lcid, const OLECHAR *szName );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "929c2307-8e73-4576-a705-1cde1f728ba4")]
	public static extern uint LHashValOfNameSys(SYSKIND syskind, LCID lcid, [MarshalAs(UnmanagedType.LPWStr)] string szName);

	/// <summary>Computes a hash value for the specified name.</summary>
	/// <param name="syskind">The SYSKIND of the target operating system.</param>
	/// <param name="lcid">The LCID for the string.</param>
	/// <param name="szName">The string whose hash value is to be computed.</param>
	/// <returns>A hash value that represents the specified name.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-lhashvalofnamesysa ULONG LHashValOfNameSysA( SYSKIND
	// syskind, LCID lcid, LPCSTR szName );
	[DllImport(Lib.OleAut32, SetLastError = false, CharSet = CharSet.Ansi)]
	[PInvokeData("oleauto.h", MSDNShortId = "8a879533-c842-4ff7-b739-3f862281acaf")]
	public static extern uint LHashValOfNameSysA(SYSKIND syskind, LCID lcid, [MarshalAs(UnmanagedType.LPStr)] string szName);

	/// <summary>Uses registry information to load a type library.</summary>
	/// <param name="rguid">The GUID of the library.</param>
	/// <param name="wVerMajor">The major version of the library.</param>
	/// <param name="wVerMinor">The minor version of the library.</param>
	/// <param name="lcid">The national language code of the library.</param>
	/// <param name="pptlib">The loaded type library.</param>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not write to the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVALIDSTATE</term>
	/// <term>The type library could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVDATAREAD</term>
	/// <term>The function could not read from the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_UNSUPFORMAT</term>
	/// <term>The type library has an older format.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_UNKNOWNLCID</term>
	/// <term>The LCID could not be found in the OLE-supported DLLs.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_CANTLOADLIBRARY</term>
	/// <term>The type library or DLL could not be loaded.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The function <c>LoadRegTypeLib</c> defers to LoadTypeLib to load the file.</para>
	/// <para>
	/// <c>LoadRegTypeLib</c> compares the requested version numbers against those found in the system registry, and takes one of the
	/// following actions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If one of the registered libraries exactly matches both the requested major and minor version numbers, then that type library is loaded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If one or more registered type libraries exactly match the requested major version number, and has a greater minor version
	/// number than that requested, the one with the greatest minor version number is loaded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If none of the registered type libraries exactly match the requested major version number (or if none of those that do exactly
	/// match the major version number also have a minor version number greater than or equal to the requested minor version number),
	/// then <c>LoadRegTypeLib</c> returns an error.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-loadregtypelib HRESULT LoadRegTypeLib( REFGUID rguid, WORD
	// wVerMajor, WORD wVerMinor, LCID lcid, ITypeLib **pptlib );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "444b7768-2a4e-4de3-9f28-ef63ac23e8bc")]
	public static extern HRESULT LoadRegTypeLib(in Guid rguid, ushort wVerMajor, ushort wVerMinor, LCID lcid, out ITypeLib pptlib);

	/// <summary>Loads and registers a type library.</summary>
	/// <param name="szFile">The name of the file from which the method should attempt to load a type library.</param>
	/// <param name="pptlib">The loaded type library.</param>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not write to the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVALIDSTATE</term>
	/// <term>The type library could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVDATAREAD</term>
	/// <term>The function could not read from the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_UNSUPFORMAT</term>
	/// <term>The type library has an older format.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_UNKNOWNLCID</term>
	/// <term>The LCID could not be found in the OLE-supported DLLs.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_CANTLOADLIBRARY</term>
	/// <term>The type library or DLL could not be loaded.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function <c>LoadTypeLib</c> loads a type library (usually created with MkTypLib) that is stored in the specified file. If
	/// szFile specifies only a file name without any path, <c>LoadTypeLib</c> searches for the file and proceeds as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If the file is a stand-alone type library implemented by Typelib.dll, the library is loaded directly.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the file is a DLL or an executable file, it is loaded. By default, the type library is extracted from the first resource of
	/// type ITypeLib. To load a different type of library resource, append an integer index to szFile. For example:
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the file is none of the above, the file name is parsed into a moniker (an object that represents a file-based link source),
	/// and then bound to the moniker. This approach allows <c>LoadTypeLib</c> to be used on foreign type libraries, including in-memory
	/// type libraries. Foreign type libraries cannot reside in a DLL or an executable file. For more information on monikers, see the
	/// COM Programmer's Reference.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the type library is already loaded, <c>LoadTypeLib</c> increments the type library's reference count and returns a pointer to
	/// the type library.
	/// </para>
	/// <para>
	/// For backward compatibility, <c>LoadTypeLib</c> will register the type library if the path is not specified in the szFile
	/// parameter. <c>LoadTypeLib</c> will not register the type library if the path of the type library is specified. It is recommended
	/// that RegisterTypeLib be used to register a type library.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-loadtypelib HRESULT LoadTypeLib( LPCOLESTR szFile, ITypeLib
	// **pptlib );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "155b48e5-5438-409e-9342-630a6a500f60")]
	public static extern HRESULT LoadTypeLib([MarshalAs(UnmanagedType.LPWStr)] string szFile, out ITypeLib pptlib);

	/// <summary>Loads a type library and (optionally) registers it in the system registry.</summary>
	/// <param name="szFile">The type library file.</param>
	/// <param name="regkind">
	/// Identifies the kind of registration to perform for the type library based on the following flags: DEFAULT, REGISTER and NONE.
	/// REGKIND_DEFAULT simply calls LoadTypeLib and registration occurs based on the LoadTypeLib registration rules. REGKIND_NONE calls
	/// <c>LoadTypeLib</c> without the registration process enabled. REGKIND_REGISTER calls <c>LoadTypeLib</c> followed by
	/// RegisterTypeLib, which registers the type library. To unregister the type library, use UnRegisterTypeLib.
	/// </param>
	/// <param name="pptlib">The type library.</param>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not write to the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_REGISTRYACCESS</term>
	/// <term>The system registration database could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVALIDSTATE</term>
	/// <term>The type library could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_CANTLOADLIBRARY</term>
	/// <term>The type library or DLL could not be loaded.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Enables programmers to specify whether or not the type library should be loaded.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-loadtypelibex HRESULT LoadTypeLibEx( LPCOLESTR szFile,
	// REGKIND regkind, ITypeLib **pptlib );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "56a7f9e1-810b-4a42-aa4d-691f4304f5ef")]
	public static extern HRESULT LoadTypeLibEx([MarshalAs(UnmanagedType.LPWStr)] string szFile, REGKIND regkind, out ITypeLib pptlib);

	/// <summary>Retrieves the build version of OLE Automation.</summary>
	/// <returns>The build number.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-oabuildversion ULONG OaBuildVersion( );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "e7466457-1025-4f1b-8b29-01cdf2358217")]
	public static extern uint OaBuildVersion();

	/// <summary>
	/// Enables the RegisterTypeLib function to override default registry mappings under Windows Vista Service Pack 1 (SP1), Windows
	/// Server 2008, and later operating system versions.
	/// </summary>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// Consider the following scenario: You are running an application on a computer that is running Windows Vista SP1 or later. In
	/// your application, you have overridden the HKEY_CLASSES_ROOT registry subtree and mapped it to another registry subtree. (For
	/// example, perhaps you mapped HKEY_CLASSES_ROOT to HKEY_CURRENT_USER.) You then attempt to register a type library by calling
	/// RegisterTypeLib, and you receive an "access denied" error message. Additionally, <c>RegisterTypeLib</c> returns the
	/// TYPE_E_REGISTRYACCESS (0x8002801c) value.
	/// </para>
	/// <para>This problem occurs if User Account Control (UAC) is enabled, and the application is running under a limited user account.</para>
	/// <para>You can resolve this problem in one of two ways:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Use the <c>OaEnablePerUserTLibRegistration</c> function. Before your application calls RegisterTypeLib, it should call
	/// <c>OaEnablePerUserTLibRegistration</c>. This enables <c>RegisterTypeLib</c> to accept the registry override mapping. The
	/// <c>OaEnablePerUserTLibRegistration</c> function is exported from the Oleaut32.dll file. You must reference this file by using
	/// run-time dynamic linking and the GetProcAddress function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Set the OAPERUSERTLIBREG environment variable. RegisterTypeLib will check the value of this variable. If the value of
	/// OAPERUSERTLIBREG is 1, <c>RegisterTypeLib</c> will use the appropriate override mapping. Because this environment variable is
	/// read during the initialization of the <c>DLLMain</c> function, you must set the variable before you run your application. To do
	/// this, run one of the following commands at a command prompt: <c>start cmd.exe /c "set OAPERUSERTLIBREG=1 &amp;&amp;</c>
	/// MyApp.exe <c>"</c>
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// When using run-time dynamic linking it should be noted that the setting to enable per-user type library registration is a global
	/// setting in oleaut32.dll, so if oleaut32.dll is unloaded then this setting is lost.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-oaenableperusertlibregistration void
	// OaEnablePerUserTLibRegistration( );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "356af9a9-77f9-4699-abc3-ab3ff1db2915")]
	public static extern void OaEnablePerUserTLibRegistration();

	/// <summary>Retrieves the path of a registered type library.</summary>
	/// <param name="guid">The GUID of the library.</param>
	/// <param name="wMaj">The major version number of the library.</param>
	/// <param name="wMin">The minor version number of the library.</param>
	/// <param name="lcid">The national language code for the library.</param>
	/// <param name="lpbstrPathName">The type library name.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// Returns the fully qualified file name that is specified for the type library in the registry. The caller allocates the BSTR that
	/// is passed in, and must free it after use.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-querypathofregtypelib HRESULT QueryPathOfRegTypeLib(
	// REFGUID guid, USHORT wMaj, USHORT wMin, LCID lcid, LPBSTR lpbstrPathName );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "a71dc182-2fbf-48bd-9c9a-c662b9b0a6ec")]
	public static extern HRESULT QueryPathOfRegTypeLib(in Guid guid, ushort wMaj, ushort wMin, LCID lcid, [MarshalAs(UnmanagedType.BStr)] out string lpbstrPathName);

	/// <summary>Registers an object as the active object for its class.</summary>
	/// <param name="punk">The active object.</param>
	/// <param name="rclsid">The CLSID of the active object.</param>
	/// <param name="dwFlags">Flags controlling registration of the object. Possible values are ACTIVEOBJECT_STRONG and ACTIVEOBJECT_WEAK.</param>
	/// <param name="pdwRegister">Receives a handle. This handle must be passed to RevokeActiveObject to end the object's active status.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// The <c>RegisterActiveObject</c> function registers the object to which punk points as the active object for the class denoted by
	/// rclsid. Registration causes the object to be listed in the running object table (ROT) of OLE, a globally accessible lookup table
	/// that keeps track of objects that are currently running on the computer. (For more information about the running object table,
	/// see the COM Programmer's Reference.) The dwFlags parameter specifies the strength or weakness of the registration, which affects
	/// the way the object is shut down.
	/// </para>
	/// <para>In general, ActiveX objects should behave in the following manner:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the object is visible, it should shut down only in response to an explicit user command (such as the <c>Exit</c> command on
	/// the <c>File</c> menu), or to the equivalent command from an ActiveX client (invoking the <c>Quit</c> or <c>Exit</c> method on
	/// the Application object).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the object is not visible, it should shut down only when the last external connection to it is gone.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Strong registration performs an <c>AddRef</c> on the object, incrementing the reference count of the object (and its associated
	/// stub) in the running object table. A strongly registered object must be explicitly revoked from the table with
	/// RevokeActiveObject. The default is strong registration (ACTIVEOBJECT_STRONG).
	/// </para>
	/// <para>
	/// Weak registration keeps a pointer to the object in the running object table, but does not increment the reference count.
	/// Consequently, when the last external connection to a weakly registered object disappears, OLE releases the object's stub, and
	/// the object itself is no longer available.
	/// </para>
	/// <para>To ensure the desired behavior, consider not only the default actions of OLE, but also the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Even though code can create an invisible object, the object may become visible at some later time. Once the object is visible,
	/// it should remain visible and active until it receives an explicit command to shut down. This can occur after references from the
	/// code disappear.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Other ActiveX clients may be using the object. If so, the code should not force the object to shut down.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To avoid possible conflicts, you should always register ActiveX objects with ACTIVEOBJECT_WEAK, and call
	/// <c>CoLockObjectExternal</c>, when necessary, to guarantee the object remains active. <c>CoLockObjectExternal</c> adds a strong
	/// lock, thereby preventing the object's reference count from reaching zero. For detailed information about this function, refer to
	/// the COM Programmer's Reference.
	/// </para>
	/// <para>
	/// Most commonly, objects need to call <c>CoLockObjectExternal</c> when they become visible, so they remain active until the user
	/// requests the object to shut down. The following procedure lists the steps your code should follow to shut down an object correctly.
	/// </para>
	/// <para><c>To shut down an active object:</c></para>
	/// <list type="number">
	/// <item>
	/// <term>When the object becomes visible, make the following call to add a lock for user:</term>
	/// </item>
	/// <item>
	/// <term>When the user requests the object to be shut down, call <c>CoLockObjectExternal</c> again to free the lock, as follows:</term>
	/// </item>
	/// <item>
	/// <term>Call <c>RevokeActiveObject</c> to make the object inactive.</term>
	/// </item>
	/// <item>
	/// <term>To end all connections from remote processes, call <c>CoDisconnectObject</c> as follows:</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-registeractiveobject HRESULT RegisterActiveObject( IUnknown
	// *punk, REFCLSID rclsid, DWORD dwFlags, DWORD *pdwRegister );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "ba15bb69-7b65-47ea-b938-f235e3d9f9ee")]
	public static extern HRESULT RegisterActiveObject([MarshalAs(UnmanagedType.IUnknown)] object punk, in Guid rclsid, uint dwFlags, out uint pdwRegister);

	/// <summary>Adds information about a type library to the system registry.</summary>
	/// <param name="ptlib">The type library.</param>
	/// <param name="szFullPath">The fully qualified path specification for the type library.</param>
	/// <param name="szHelpDir">
	/// The directory in which the Help file for the library being registered can be found. This parameter can be null.
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not write to the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_REGISTRYACCESS</term>
	/// <term>The system registration database could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVALIDSTATE</term>
	/// <term>The type library could not be opened.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function can be used during application initialization to register the application's type library correctly. When
	/// <c>RegisterTypeLib</c> is called to register a type library, both the minor and major version numbers are registered in hexadecimal.
	/// </para>
	/// <para>
	/// In addition to filling in a complete registry entry under the type library key, <c>RegisterTypeLib</c> adds entries for each of
	/// the dispinterfaces and Automation-compatible interfaces, including dual interfaces. This information is required to create
	/// instances of these interfaces. Coclasses are not registered (that is, <c>RegisterTypeLib</c> does not write any values to the
	/// CLSID key of the coclass).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-registertypelib HRESULT RegisterTypeLib( ITypeLib *ptlib,
	// LPCOLESTR szFullPath, LPCOLESTR szHelpDir );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "d0559a57-b1a4-4036-97ed-024d775cb595")]
	public static extern HRESULT RegisterTypeLib(ITypeLib ptlib, [MarshalAs(UnmanagedType.LPWStr)] string szFullPath, [MarshalAs(UnmanagedType.LPWStr), Optional] string? szHelpDir);

	/// <summary>Registers a type library for use by the calling user.</summary>
	/// <param name="ptlib">The type library.</param>
	/// <param name="szFullPath">The fully qualified path specification for the type library.</param>
	/// <param name="szHelpDir">
	/// The directory in which the Help file for the library being registered can be found. This parameter can be null.
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not write to the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_REGISTRYACCESS</term>
	/// <term>The system registration database could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVALIDSTATE</term>
	/// <term>The type library could not be opened.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>RegisterTypeLibForUser</c> has functionality identical to RegisterTypeLib except that type library is registered for use only
	/// by the calling user identity.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-registertypelibforuser HRESULT RegisterTypeLibForUser(
	// ITypeLib *ptlib, OLECHAR *szFullPath, OLECHAR *szHelpDir );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "ca8ae169-f849-4df2-8537-095d65ad6a08")]
	public static extern HRESULT RegisterTypeLibForUser(ITypeLib ptlib, [MarshalAs(UnmanagedType.LPWStr)] string szFullPath, [MarshalAs(UnmanagedType.LPWStr), Optional] string? szHelpDir);

	/// <summary>Ends an object's status as active.</summary>
	/// <param name="dwRegister">A handle previously returned by RegisterActiveObject.</param>
	/// <param name="pvReserved">Reserved for future use. Must be null.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-revokeactiveobject HRESULT RevokeActiveObject( DWORD
	// dwRegister, void *pvReserved );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "47e7b47b-dddc-445d-918f-02b1b6a37075")]
	public static extern HRESULT RevokeActiveObject(uint dwRegister, IntPtr pvReserved = default);

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

	/// <summary>
	/// The string for which the pinning reference count should increase. While that count remains greater than 0, the memory for the
	/// string is prevented from being freed by calls to the SysFreeString function.
	/// </summary>
	/// <param name="bstrString">
	/// The string for which the pinning reference count should increase. While that count remains greater than 0, the memory for the
	/// string is prevented from being freed by calls to the SysFreeString function.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// Strings with the <c>BSTR</c> data type have not traditionally had a reference count. All existing usage of these strings will
	/// continue to work with no changes. The <c>SysAddRefString</c> and SysReleaseString functions add the ability to use reference
	/// counting to pin the string into memory before calling from an untrusted script into an IDispatch method that may not expect the
	/// script to free that memory before the method returns, so that the script cannot force the code for that method into accessing
	/// memory that has been freed. After such a method safely returns, the pinning references should be released by calling <c>SysReleaseString</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysaddrefstring HRESULT SysAddRefString( BSTR bstrString );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "9AE274F1-1517-4D55-B9AE-D75169404880")]
	public static extern HRESULT SysAddRefString(SafeBSTR bstrString);

	/// <summary>Allocates a new string and copies the passed string into it.</summary>
	/// <param name="psz">The string to copy.</param>
	/// <returns>
	/// If successful, returns the string. If psz is a zero-length string, returns a zero-length <c>BSTR</c>. If psz is NULL or
	/// insufficient memory exists, returns NULL.
	/// </returns>
	/// <remarks>You can free strings created with <c>SysAllocString</c> using SysFreeString.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysallocstring BSTR SysAllocString( const OLECHAR *psz );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "9e0437a2-9b4a-4576-88b0-5cb9d08ca29b")]
	public static extern SafeBSTR SysAllocString([MarshalAs(UnmanagedType.LPWStr)] string psz);

	/// <summary>
	/// Takes an ANSI string as input, and returns a BSTR that contains an ANSI string. Does not perform any ANSI-to-Unicode translation.
	/// </summary>
	/// <param name="psz">The string to copy, or NULL to keep the string uninitialized.</param>
	/// <param name="len">
	/// The number of bytes to copy. A null character is placed afterwards, allocating a total of len plus the size of <c>OLECHAR</c> bytes.
	/// </param>
	/// <returns>A copy of the string, or NULL if there is insufficient memory to complete the operation.</returns>
	/// <remarks>
	/// <para>
	/// This function is provided to create BSTRs that contain binary data. You can use this type of BSTR only in situations where it
	/// will not be translated from ANSI to Unicode, or vice versa.
	/// </para>
	/// <para>
	/// For example, do not use these BSTRs between a 16-bit and a 32-bit application running on a 32-bit Windows system. The OLE 16-bit
	/// to 32-bit (and 32-bit to 16-bit) interoperability layer will translate the BSTR and corrupt the binary data. The preferred
	/// method of passing binary data is to use a SAFEARRAY of VT_UI1, which will not be translated by OLE.
	/// </para>
	/// <para>
	/// If psz is Null, a string of the requested length is allocated, but not initialized. The string psz can contain embedded null
	/// characters, and does not need to end with a Null. Free the returned string later with SysFreeString.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysallocstringbytelen BSTR SysAllocStringByteLen( LPCSTR
	// psz, UINT len );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "e7f49441-eff1-4c00-b61f-8522c4e250ef")]
	public static extern SafeBSTR SysAllocStringByteLen(byte[] psz, uint len);

	/// <summary>
	/// Takes an ANSI string as input, and returns a BSTR that contains an ANSI string. Does not perform any ANSI-to-Unicode translation.
	/// </summary>
	/// <param name="psz">The string to copy, or NULL to keep the string uninitialized.</param>
	/// <param name="len">
	/// The number of bytes to copy. A null character is placed afterwards, allocating a total of len plus the size of <c>OLECHAR</c> bytes.
	/// </param>
	/// <returns>A copy of the string, or NULL if there is insufficient memory to complete the operation.</returns>
	/// <remarks>
	/// <para>
	/// This function is provided to create BSTRs that contain binary data. You can use this type of BSTR only in situations where it
	/// will not be translated from ANSI to Unicode, or vice versa.
	/// </para>
	/// <para>
	/// For example, do not use these BSTRs between a 16-bit and a 32-bit application running on a 32-bit Windows system. The OLE 16-bit
	/// to 32-bit (and 32-bit to 16-bit) interoperability layer will translate the BSTR and corrupt the binary data. The preferred
	/// method of passing binary data is to use a SAFEARRAY of VT_UI1, which will not be translated by OLE.
	/// </para>
	/// <para>
	/// If psz is Null, a string of the requested length is allocated, but not initialized. The string psz can contain embedded null
	/// characters, and does not need to end with a Null. Free the returned string later with SysFreeString.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysallocstringbytelen BSTR SysAllocStringByteLen( LPCSTR
	// psz, UINT len );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "e7f49441-eff1-4c00-b61f-8522c4e250ef")]
	public static extern SafeBSTR SysAllocStringByteLen([MarshalAs(UnmanagedType.LPStr), Optional] string? psz, uint len);

	/// <summary>
	/// Allocates a new string, copies the specified number of characters from the passed string, and appends a null-terminating character.
	/// </summary>
	/// <param name="strIn">The input string.</param>
	/// <param name="ui">
	/// The number of characters to copy. A null character is placed afterwards, allocating a total of ui plus one characters.
	/// </param>
	/// <returns>A copy of the string, or <c>NULL</c> if there is insufficient memory to complete the operation.</returns>
	/// <remarks>
	/// <para>
	/// The string can contain embedded null characters and does not need to end with a <c>NULL</c>. Free the returned string later with
	/// SysFreeString. If strIn is not <c>NULL</c>, then the memory allocated to strIn must be at least ui characters long.
	/// </para>
	/// <para><c>Note</c> This function does not convert a <c>char *</c> string into a Unicode <c>BSTR</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysallocstringlen BSTR SysAllocStringLen( const OLECHAR
	// *strIn, UINT ui );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "f98bff39-bc5f-4a81-85d7-d5228e20fbc8")]
	public static extern SafeBSTR SysAllocStringLen([MarshalAs(UnmanagedType.LPWStr), Optional] string? strIn, uint ui);

	/// <summary>
	/// Deallocates a string allocated previously by SysAllocString, SysAllocStringByteLen, SysReAllocString, SysAllocStringLen, or SysReAllocStringLen.
	/// </summary>
	/// <param name="bstrString">The previously allocated string. If this parameter is <c>NULL</c>, the function simply returns.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysfreestring void SysFreeString( BSTR bstrString );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "8f230ee3-5f6e-4cb9-a910-9c90b754dcd3")]
	public static extern void SysFreeString([In, Optional] IntPtr bstrString);

	/// <summary>
	/// Reallocates a previously allocated string to be the size of a second string and copies the second string into the reallocated memory.
	/// </summary>
	/// <param name="pbstr">The previously allocated string.</param>
	/// <param name="psz">The string to copy.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The string is reallocated successfully.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>Insufficient memory exists.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The address passed in psz cannot be part of the string passed in pbstr, or unexpected results may occur.</para>
	/// <para>
	/// If pbstr is NULL, there will be an access violation and the program will crash. It is your responsibility to protect this
	/// function against NULL pointers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysreallocstring INT SysReAllocString( BSTR *pbstr, const
	// OLECHAR *psz );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "0207c33b-c065-42bb-8d70-ccdc3fddb338")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SysReAllocString(IntPtr pbstr, [MarshalAs(UnmanagedType.LPWStr), Optional] string? psz);

	/// <summary>Creates a new BSTR containing a specified number of characters from an old BSTR, and frees the old BSTR.</summary>
	/// <param name="pbstr">The previously allocated string.</param>
	/// <param name="psz">The string from which to copy len characters, or NULL to keep the string uninitialized.</param>
	/// <param name="len">
	/// The number of characters to copy. A null character is placed afterward, allocating a total of len plus one characters.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The string is reallocated successfully.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>Insufficient memory exists.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Allocates a new string, copies len characters from the passed string into it, and then appends a null character. Frees the BSTR
	/// referenced currently by pbstr, and resets pbstr to point to the new BSTR. If psz is null, a string of length len is allocated
	/// but not initialized.
	/// </para>
	/// <para>The psz string can contain embedded null characters and does not need to end with a null.</para>
	/// <para>
	/// If this function is passed a NULL pointer, there will be an access violation and the program will crash. It is your
	/// responsibility to protect this function against NULL pointers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysreallocstringlen INT SysReAllocStringLen( BSTR *pbstr,
	// const OLECHAR *psz, unsigned int len );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "d134cff1-7cc8-4284-a216-3819615e3017")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SysReAllocStringLen(IntPtr pbstr, [MarshalAs(UnmanagedType.LPWStr), Optional] string? psz, uint len);

	/// <summary>The string for which the pinning reference count should decrease.</summary>
	/// <param name="bstrString">The string for which the pinning reference count should decrease.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>A call to the <c>SysReleaseString</c> function should match every previous call to the SysAddRefString function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysreleasestring void SysReleaseString( BSTR bstrString );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "D4905794-A4EA-4925-A4B2-92C8BF6EDFD0")]
	public static extern void SysReleaseString(SafeBSTR bstrString);

	/// <summary>Returns the length (in bytes) of a BSTR.</summary>
	/// <param name="bstr">A previously allocated string.</param>
	/// <returns>The number of bytes in bstr, not including the terminating null character. If bstr is null the return value is zero.</returns>
	/// <remarks>
	/// The returned value may be different from <c>strlen</c>(bstr) if the BSTR contains embedded null characters. This function always
	/// returns the number of bytes specified in the len parameter of the SysAllocStringByteLen function used to allocate the BSTR.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysstringbytelen UINT SysStringByteLen( BSTR bstr );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "2a150503-f474-41b8-90dd-fbbc955bea99")]
	public static extern uint SysStringByteLen(SafeBSTR bstr);

	/// <summary>Returns the length of a BSTR.</summary>
	/// <param name="pbstr">A previously allocated string.</param>
	/// <returns>
	/// The number of characters in bstr, not including the terminating null character. If bstr is null the return value is zero.
	/// </returns>
	/// <remarks>
	/// The returned value may be different from <c>strlen</c>(bstr) if the BSTR contains embedded Null characters. This function always
	/// returns the number of characters specified in the cch parameter of the SysAllocStringLen function used to allocate the BSTR.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-sysstringlen UINT SysStringLen( BSTR pbstr );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "65e792af-f8a8-4cdc-a279-494bba59394a")]
	public static extern uint SysStringLen(SafeBSTR pbstr);

	/// <summary>Converts a system time to a variant representation.</summary>
	/// <param name="lpSystemTime">The system time.</param>
	/// <param name="pvtime">The variant time.</param>
	/// <returns>The function returns TRUE on success and FALSE otherwise.</returns>
	/// <remarks>
	/// <para>
	/// A variant time is stored as an 8-byte real value ( <c>double</c>), representing a date between January 1, 100 and December 31,
	/// 9999, inclusive. The value 2.0 represents January 1, 1900; 3.0 represents January 2, 1900, and so on. Adding 1 to the value
	/// increments the date by a day. The fractional part of the value represents the time of day. Therefore, 2.5 represents noon on
	/// January 1, 1900; 3.25 represents 6:00 A.M. on January 2, 1900, and so on. Negative numbers represent dates prior to December 30, 1899.
	/// </para>
	/// <para>The variant time resolves to one second. Any milliseconds in the input date are ignored.</para>
	/// <para>The SYSTEMTIME structure is useful for the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>It spans all time/date periods. MS-DOS date/time is limited to representing only those dates between 1/1/1980 and 12/31/2107.</term>
	/// </item>
	/// <item>
	/// <term>The date/time elements are all easily accessible without needing to do any bit decoding.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The National Data Support data and time formatting functions GetDateFormat and GetTimeFormat take an LPSYSTEMTIME value as input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>It is the default time/date data format supported by Windows.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>SystemTimeToVariantTime</c> function will accept invalid dates and try to fix them when resolving to a VARIANT time. For
	/// example, an invalid date such as 2/29/2001 will resolve to 3/1/2001. Only days are fixed, so invalid month values result in an
	/// error being returned. Days are checked to be between 1 and 31. Negative days and days greater than 31 results in an error. A day
	/// less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month. A day
	/// equal to zero resolves as the last day of the previous month. For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-systemtimetovarianttime INT SystemTimeToVariantTime(
	// LPSYSTEMTIME lpSystemTime, DOUBLE *pvtime );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "d9d69521-9b33-4fc5-8a1c-929f216db450")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SystemTimeToVariantTime(in SYSTEMTIME lpSystemTime, out double pvtime);

	/// <summary>
	/// Removes type library information from the system registry. Use this API to allow applications to properly uninstall themselves.
	/// </summary>
	/// <param name="libID">The GUID of the type library.</param>
	/// <param name="wVerMajor">The major version of the type library.</param>
	/// <param name="wVerMinor">The minor version of the type library.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="syskind">The target operating system.</param>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not write to the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_REGISTRYACCESS</term>
	/// <term>The system registration database could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVALIDSTATE</term>
	/// <term>The type library could not be opened.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>In-process objects typically call this API from <c>DllUnregisterServer</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-unregistertypelib HRESULT UnRegisterTypeLib( REFGUID libID,
	// WORD wVerMajor, WORD wVerMinor, LCID lcid, SYSKIND syskind );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "36c763f0-562c-4fc8-9449-b37e993d5f5c")]
	public static extern HRESULT UnRegisterTypeLib(in Guid libID, ushort wVerMajor, ushort wVerMinor, LCID lcid, SYSKIND syskind);

	/// <summary>Removes type library information that was registered by using RegisterTypeLibForUser.</summary>
	/// <param name="libID">The GUID of the library.</param>
	/// <param name="wMajorVerNum">The major version of the type library.</param>
	/// <param name="wMinorVerNum">The minor version of the type library.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="syskind">The target operating system.</param>
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
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_IOERROR</term>
	/// <term>The function could not write to the file.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_REGISTRYACCESS</term>
	/// <term>The system registration database could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_INVALIDSTATE</term>
	/// <term>The type library could not be opened.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Use <c>UnRegisterTypeLibForUser</c> to remove type library information for type libraries that were registered using the
	/// RegisterTypeLibForUser function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-unregistertypelibforuser HRESULT UnRegisterTypeLibForUser(
	// REFGUID libID, WORD wMajorVerNum, WORD wMinorVerNum, LCID lcid, SYSKIND syskind );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "2d88f97b-b1f6-4682-abf5-304ee752e2ae")]
	public static extern HRESULT UnRegisterTypeLibForUser(in Guid libID, ushort wMajorVerNum, ushort wMinorVerNum, LCID lcid, SYSKIND syskind);

	/// <summary>Clears a variant.</summary>
	/// <param name="pvarg">The variant to clear.</param>
	/// <returns>S_OK on success.</returns>
	[DllImport(Lib.OleAut32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("OleAuto.h", MSDNShortId = "ms221165")]
	public static extern HRESULT VariantClear(IntPtr pvarg);

	/// <summary>Clears a variant.</summary>
	/// <param name="pvarg">The variant to clear.</param>
	/// <returns>S_OK on success.</returns>
	[DllImport(Lib.OleAut32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("OleAuto.h", MSDNShortId = "ms221165")]
	public static extern HRESULT VariantClear(ref VARIANT pvarg);

	/// <summary>Converts the variant representation of a date and time to MS-DOS date and time values.</summary>
	/// <param name="vtime">The variant time to convert.</param>
	/// <param name="pwDosDate">Receives the converted MS-DOS date.</param>
	/// <param name="pwDosTime">Receives the converted MS-DOS time</param>
	/// <returns>The function returns TRUE on success and FALSE otherwise.</returns>
	/// <remarks>
	/// <para>
	/// A variant time is stored as an 8-byte real value ( <c>double</c>), representing a date between January 1, 100 and December 31,
	/// 9999, inclusive. The value 2.0 represents January 1, 1900; 3.0 represents January 2, 1900, and so on. Adding 1 to the value
	/// increments the date by a day. The fractional part of the value represents the time of day. Therefore, 2.5 represents noon on
	/// January 1, 1900; 3.25 represents 6:00 A.M. on January 2, 1900, and so on. Negative numbers represent the dates prior to December
	/// 30, 1899.
	/// </para>
	/// <para>For a description of the MS-DOS date and time formats, see DosDateTimeToVariantTime.</para>
	/// <para>
	/// The <c>VariantTimeToDosDateTime</c> function will accept invalid dates and try to fix them when resolving to a VARIANT time. For
	/// example, an invalid date such as 2/29/2001 will resolve to 3/1/2001. Only days are fixed, so invalid month values result in an
	/// error being returned. Days are checked to be between 1 and 31. Negative days and days greater than 31 results in an error. A day
	/// less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month. A day
	/// equal to zero resolves as the last day of the previous month. For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varianttimetodosdatetime INT VariantTimeToDosDateTime(
	// DOUBLE vtime, USHORT *pwDosDate, USHORT *pwDosTime );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "62307266-2434-4b06-9135-8854f4624c5c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool VariantTimeToDosDateTime(double vtime, out ushort pwDosDate, out ushort pwDosTime);

	/// <summary>Converts the variant representation of time to system time values.</summary>
	/// <param name="vtime">The variant time to convert.</param>
	/// <param name="lpSystemTime">Receives the system time.</param>
	/// <returns>The function returns TRUE on success and FALSE otherwise.</returns>
	/// <remarks>
	/// <para>
	/// A variant time is stored as an 8-byte real value ( <c>double</c>), representing a date between January 1, 100 and December 31,
	/// 9999, inclusive. The value 2.0 represents January 1, 1900; 3.0 represents January 2, 1900, and so on. Adding 1 to the value
	/// increments the date by a day. The fractional part of the value represents the time of day. Therefore, 2.5 represents noon on
	/// January 1, 1900; 3.25 represents 6:00 A.M. on January 2, 1900, and so on. Negative numbers represent the dates prior to December
	/// 30, 1899.
	/// </para>
	/// <para>Using the SYSTEMTIME structure is useful because:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>It spans all time/date periods. MS-DOS date/time is limited to representing only those dates between 1/1/1980 and 12/31/2107.</term>
	/// </item>
	/// <item>
	/// <term>The date/time elements are all easily accessible without needing to do any bit decoding.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The National Language Support data and time formatting functions <c>GetDateFormat</c> and <c>GetTimeFormat</c> take a SYSTEMTIME
	/// value as input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>It is the default Win32 time and date data format supported by Windows NT and Windows 95.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>VariantTimeToSystemTime</c> function will accept invalid dates and try to fix them when resolving to a VARIANT time. For
	/// example, an invalid date such as 2/29/2001 will resolve to 3/1/2001. Only days are fixed, so invalid month values result in an
	/// error being returned. Days are checked to be between 1 and 31. Negative days and days greater than 31 results in an error. A day
	/// less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month. A day
	/// equal to zero resolves as the last day of the previous month. For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varianttimetosystemtime INT VariantTimeToSystemTime( DOUBLE
	// vtime, LPSYSTEMTIME lpSystemTime );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "954eb6f3-f9f0-4586-9dd7-1632ebc6ef58")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool VariantTimeToSystemTime(double vtime, out SYSTEMTIME lpSystemTime);

	/// <summary>Returns a vector, assigning each character in the BSTR to an element of the vector.</summary>
	/// <param name="bstr">The BSTR to be converted to a vector.</param>
	/// <param name="ppsa">A one-dimensional safearray containing the characters in the BSTR.</param>
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
	/// <term>The bstr parameter is null.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vectorfrombstr HRESULT VectorFromBstr( BSTR bstr, SAFEARRAY
	// **ppsa );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "46cde8da-f6c8-4b29-b4ef-eda30b0fa3f1")]
	public static extern HRESULT VectorFromBstr(SafeBSTR bstr, out SafeSAFEARRAY ppsa);

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
		public VARTYPE vtReturn;
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
		public VARTYPE vt;
	}

	/// <summary>Represents an unpacked date.</summary>
	[PInvokeData("oleauto.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UDATE
	{
		/// <summary/>
		public SYSTEMTIME st;

		/// <summary/>
		public ushort wDayOfYear;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for a BSTR that is disposed using <see cref="SysFreeString"/>.</summary>
	public class SafeBSTR : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeBSTR"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeBSTR(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeBSTR"/> class.</summary>
		private SafeBSTR() : base() { }

		/// <summary>Gets the length of the string.</summary>
		/// <value>The length in characters.</value>
		public int Length => (int)SysStringLen(this);

		/// <summary>Performs an implicit conversion from <see cref="System.String"/> to <see cref="SafeBSTR"/>.</summary>
		/// <param name="s">The string value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeBSTR(string s) => SysAllocString(s);

		/// <summary>Performs an implicit conversion from <see cref="SafeBSTR"/> to <see cref="string"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(SafeBSTR h) => Marshal.PtrToStringBSTR(h.handle);

		/// <summary>
		/// Reallocates a previously allocated string to be the size of a second string and copies the second string into the
		/// reallocated memory.
		/// </summary>
		/// <param name="value">The string to copy.</param>
		public void ReAlloc(string value) => SysReAllocString(handle, value);

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { SysFreeString(handle); return true; }
	}
}