using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke;

/// <summary>Structures, constants, functions, and interfaces for Windows Active Directory Services.</summary>
public static partial class ActiveDS
{
	private const string Lib_Activeds = "activeds.dll";

	/// <summary>The <c>ADsBuildEnumerator</c> function creates an enumerator object for the specified ADSI container object.</summary>
	/// <param name="pADsContainer">
	/// <para>Type: <c>IADsContainer*</c></para>
	/// <para>Pointer to the IADsContainer interface for the object to enumerate.</para>
	/// </param>
	/// <param name="ppEnumVariant">
	/// <para>Type: <c>IEnumVARIANT**</c></para>
	/// <para>Pointer to an IEnumVARIANT interface pointer that receives the enumerator object created for the specified container object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// This method supports the standard <c>HRESULT</c> return values, including <c>S_OK</c> for a successful operation. For more
	/// information about other return values, see ADSI Error Codes.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ADsBuildEnumerator</c> helper function wraps the calls used to retrieve the IEnumVARIANT interface on the enumerator object.
	/// </para>
	/// <para><c>To enumerate the available objects in a container</c></para>
	/// <list type="number">
	/// <item>
	/// <description>
	/// Call the <c>ADsBuildEnumerator</c> function to create an IEnumVARIANT object that will enumerate the contents of the container.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Call the ADsEnumerateNext function as many times as necessary to retrieve the items from the enumerator object.</description>
	/// </item>
	/// <item>
	/// <description>Call the ADSFreeEnumerator function to release the enumerator object when it is no longer required.</description>
	/// </item>
	/// </list>
	/// <para>
	/// If the server supports paged searches and the client has specified a page size that exceeds the maximum search results allowed by the
	/// server, the <c>ADsBuildEnumerator</c> function will forward errors and results from the server to the user.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how the <c>ADsBuildEnumerator</c>, ADsEnumerateNext, and ADSFreeEnumerator functions can be used to
	/// enumerate the contents of a container.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsbuildenumerator HRESULT ADsBuildEnumerator( [in] IADsContainer
	// *pADsContainer, [out] IEnumVARIANT **ppEnumVariant );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsBuildEnumerator")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsBuildEnumerator([In] IADsContainer pADsContainer, out IEnumVARIANT ppEnumVariant);

	/// <summary>The <c>ADsBuildVarArrayInt</c> function builds a variant array of integers from an array of <c>DWORD</c> values.</summary>
	/// <param name="lpdwObjectTypes">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>Array of <c>DWORD</c> values.</para>
	/// </param>
	/// <param name="dwObjectTypes">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Number of <c>DWORD</c> entries in the given array.</para>
	/// </param>
	/// <param name="pVar">
	/// <para>Type: <c>VARIANT*</c></para>
	/// <para>Pointer to the resulting variant array of integers.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports standard return values.</para>
	/// <para>For more information about other return values, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// Use the <c>ADsBuildVarArrayInt</c> function to convert the integer array into a variant array of the integers. The following code
	/// example shows how to do this.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsbuildvararrayint HRESULT ADsBuildVarArrayInt( [in] LPDWORD
	// lpdwObjectTypes, [in] DWORD dwObjectTypes, [out] VARIANT *pVar );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsBuildVarArrayInt")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsBuildVarArrayInt([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] lpdwObjectTypes, uint dwObjectTypes,
		ref VARIANT pVar);

	/// <summary>The <c>ADsBuildVarArrayStr</c> function builds a variant array from an array of Unicode strings.</summary>
	/// <param name="lppPathNames">
	/// <para>Type: <c>LPWSTR*</c></para>
	/// <para>Array of null-terminated Unicode strings.</para>
	/// </param>
	/// <param name="dwPathNames">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Number of Unicode entries in the given array.</para>
	/// </param>
	/// <param name="pVar">
	/// <para>Type: <c>VARIANT*</c></para>
	/// <para>Pointer to the resulting variant array.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard return values, as well as the following.</para>
	/// <para>For more information about other return values, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>To support Automation, use the <c>ADsBuildVarArrayStr</c> function to convert Unicode strings to a variant array of strings.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to use the <c>ADsBuildVarArrayStr</c> function to convert object class names from Unicode
	/// strings to a variant array of strings.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsbuildvararraystr HRESULT ADsBuildVarArrayStr( [in] LPWSTR
	// *lppPathNames, [in] DWORD dwPathNames, [out] VARIANT *pVar );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsBuildVarArrayStr")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsBuildVarArrayStr([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string?[] lppPathNames,
		uint dwPathNames, ref VARIANT pVar);

	/// <summary>
	/// The <c>ADsEncodeBinaryData</c> function converts a binary large object (BLOB) to the Unicode format suitable to be embedded in a
	/// search filter.
	/// </summary>
	/// <param name="pbSrcData">
	/// <para>Type: <c>PBYTE</c></para>
	/// <para>BLOB to be converted.</para>
	/// </param>
	/// <param name="dwSrcLen">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Size, in bytes, of the BLOB.</para>
	/// </param>
	/// <param name="ppszDestData">
	/// <para>Type: <c>LPWSTR*</c></para>
	/// <para>Pointer to a null-terminated Unicode string that receives the converted data.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard return values, as well as the following.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In ADSI, search filters must be Unicode strings. Sometimes, a filter contains data that is normally represented by an opaque BLOB of
	/// data. For example, you may want to include an object security identifier in a search filter, which is of binary data. In this case,
	/// you must first call the <c>ADsEncodeBinaryData</c> function to convert the binary data to the Unicode string format. When the data is
	/// no longer required, call the FreeADsMem function to free the converted Unicode string; that is, <c>ppszDestData</c>.
	/// </para>
	/// <para>
	/// The <c>ADsEncodeBinaryData</c> function does not encode byte values that represent alpha-numeric characters. It will, instead, place
	/// the character into the string without encoding it. This results in the string containing a mixture of encoded and unencoded
	/// characters. For example, if the binary data is 0x05|0x1A|0x1B|0x43|0x32, the encoded string will contain "\05\1A\1BC2". This has no
	/// effect on the filter and the search filters will work correctly with these types of strings.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to use this function.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsencodebinarydata HRESULT ADsEncodeBinaryData( [in] PBYTE
	// pbSrcData, [in] DWORD dwSrcLen, [out] LPWSTR *ppszDestData );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsEncodeBinaryData")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsEncodeBinaryData([In] IntPtr pbSrcData, uint dwSrcLen, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDestData);

	/// <summary>
	/// The <c>ADsEnumerateNext</c> function enumerates through a specified number of elements from the current cursor position of the
	/// enumerator. When the operation succeeds, the function returns the enumerated set of elements in a variant array. The number of
	/// returned elements can be smaller than the specified number.
	/// </summary>
	/// <param name="pEnumVariant">
	/// <para>Type: <c>IEnumVARIANT*</c></para>
	/// <para>Pointer to the IEnumVARIANT interface on the enumerator object.</para>
	/// </param>
	/// <param name="cElements">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of elements requested.</para>
	/// </param>
	/// <param name="pvar">
	/// <para>Type: <c>VARIANT*</c></para>
	/// <para>Pointer to the array of elements retrieved.</para>
	/// </param>
	/// <param name="pcElementsFetched">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>Actual number of elements retrieved, which can be smaller than the number of elements requested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard return values.</para>
	/// <para>For more information about other return values, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>The general process to enumerate objects in a container involves the following:</para>
	/// <para>First, create an enumerator object on that container.</para>
	/// <para>Second, retrieve the IEnumVARIANT interface pointer.</para>
	/// <para>Third, call the <c>ADsEnumerateNext</c> function to return an enumerated set of elements from the enumerator object.</para>
	/// <para>Fourth, call the ADSFreeEnumerator function to free the enumerator object.</para>
	/// <para>For more information and a code example, see the ADsBuildEnumerator topic.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsenumeratenext HRESULT ADsEnumerateNext( [in] IEnumVARIANT
	// *pEnumVariant, [in] ULONG cElements, [out] VARIANT *pvar, [out] ULONG *pcElementsFetched );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsEnumerateNext")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsEnumerateNext([In] IEnumVARIANT pEnumVariant, uint cElements,
		[Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 3)] object?[] pvar, out uint pcElementsFetched);

	/// <summary>The <c>ADsFreeEnumerator</c> function frees an enumerator object created with the ADsBuildEnumerator function.</summary>
	/// <param name="pEnumVariant">
	/// <para>Type: <c>IEnumVARIANT*</c></para>
	/// <para>Pointer to the IEnumVARIANT interface on the enumerator object to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports standard return values, as well as the following.</para>
	/// </returns>
	/// <remarks>
	/// <para>The general process for enumerating objects in a container is as follows.</para>
	/// <para>First, create an enumerator object on that container.</para>
	/// <para>Second, retrieve the IEnumVARIANT interface pointer.</para>
	/// <para>Third, call the ADsEnumerateNext function to return an enumerated set of elements from the enumerator object.</para>
	/// <para>Fourth, call the <c>ADSFreeEnumerator</c> function to free the enumerator object.</para>
	/// <para>For more information and a code example, see ADsBuildEnumerator.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsfreeenumerator HRESULT ADsFreeEnumerator( [in] IEnumVARIANT
	// *pEnumVariant );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsFreeEnumerator")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsFreeEnumerator([In] IEnumVARIANT pEnumVariant);

	/// <summary>The <c>ADsGetLastError</c> function retrieves the calling thread's last-error code value.</summary>
	/// <param name="lpError">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>Pointer to the location that receives the error code.</para>
	/// </param>
	/// <param name="lpErrorBuf">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>Pointer to the location that receives the null-terminated Unicode string that describes the error.</para>
	/// </param>
	/// <param name="dwErrorBufLen">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Size, in characters, of the <c>lpErrorBuf</c> buffer. If the buffer is too small to receive the error string, the string is
	/// truncated, but still null-terminated. A buffer, of at least 256 bytes, is recommended.
	/// </para>
	/// </param>
	/// <param name="lpNameBuf">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// Pointer to the location that receives the null-terminated Unicode string that describes the name of the provider that raised the error.
	/// </para>
	/// </param>
	/// <param name="dwNameBufLen">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Size, in characters, of the <c>lpNameBuf</c> buffer. If the buffer is too small to receive the name of the provider, the string is
	/// truncated, but still null-terminated.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports standard return values, as well as the following.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// ADSI errors fall into two types according to the values of their facility code. The standard ADSI error codes have a facility code
	/// value of 0x5 and the extended ADSI error codes assume that of FACILITY_WIN32. The error values of the standard and extended ADSI
	/// error codes are of the forms of 0x80005xxx and 0x8007xxxx, respectively. Use the HRESULT_FACILITY(hr) macro to determine the ADSI
	/// error type.
	/// </para>
	/// <para><c>Note</c>  The WinNT ADSI provider does not support <c>ADsGetLastError</c>.</para>
	/// <para></para>
	/// <para>The following code example shows how to get Win32 error codes and their descriptions using <c>ADsGetLastError</c>.</para>
	/// <para>If hr is 80071392, the code example returns the following.</para>
	/// <para><c>Note</c>  The WinNT ADSI provider does not support <c>ADsGetLastError</c>.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsgetlasterror HRESULT ADsGetLastError( [out] LPDWORD lpError,
	// [out] LPWSTR lpErrorBuf, [in] DWORD dwErrorBufLen, [out] LPWSTR lpNameBuf, [in] DWORD dwNameBufLen );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsGetLastError")]
	[DllImport(Lib_Activeds, SetLastError = true, ExactSpelling = true)]
	public static extern HRESULT ADsGetLastError(out Win32Error lpError, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpErrorBuf, int dwErrorBufLen,
		[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpNameBuf, int dwNameBufLen);

	/// <summary>The <c>ADsGetObject</c> function binds to an object given its path and a specified interface identifier.</summary>
	/// <param name="lpszPathName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The null-terminated Unicode string that specifies the path used to bind to the object in the underlying directory service. For more
	/// information and code examples for binding strings for this parameter, see LDAP ADsPath and WinNT ADsPath.
	/// </para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Interface identifier for a specified interface on this object.</para>
	/// </param>
	/// <param name="ppObject">
	/// <para>Type: <c>VOID**</c></para>
	/// <para>Pointer to a pointer to the requested Interface.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard <c>HRESULT</c> return values, as well as the following.</para>
	/// <para>For more information about other return values, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A C/C++ client calls the <c>ADsGetObject</c> helper function to bind to an ADSI object. It is equivalent to a Visual Basic client
	/// calling the GetObject function. They both take an ADsPath as input and returns a pointer to the requested interface. By default the
	/// binding uses ADS_SECURE_AUTHENTICATION option with the security context of the calling thread. However, if the authentication fails,
	/// the secure bind is downgraded to an anonymous bind, for example, a simple bind without user credentials. To securely bind to an ADSI
	/// object, use the ADsOpenObject function instead of the <c>ADsGetObject</c> function.
	/// </para>
	/// <para>For a code example that shows how to use ADsOpenObject, see Binding With GetObject and ADsGetObject.</para>
	/// <para>
	/// It is possible to bind to an ADSI object with a user credential different from that of the currently logged-on user. To perform this
	/// operation, use the ADsOpenObject function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsgetobject HRESULT ADsGetObject( [in] LPCWSTR lpszPathName,
	// [in] REFIID riid, [out] VOID **ppObject );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsGetObject")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsGetObject([MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, in Guid riid,
		[MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object? ppObject);

	/// <summary>The <c>ADsGetObject</c> function binds to an object given its path and a specified interface identifier.</summary>
	/// <typeparam name="T">The type of the interface to retrieve.</typeparam>
	/// <param name="lpszPathName">
	/// The null-terminated Unicode string that specifies the path used to bind to the object in the underlying directory service. For more
	/// information and code examples for binding strings for this parameter, see LDAP ADsPath and WinNT ADsPath.
	/// </param>
	/// <param name="ppObject">The requested Interface.</param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard <c>HRESULT</c> return values, as well as the following.</para>
	/// <para>For more information about other return values, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A C/C++ client calls the <c>ADsGetObject</c> helper function to bind to an ADSI object. It is equivalent to a Visual Basic client
	/// calling the GetObject function. They both take an ADsPath as input and returns a pointer to the requested interface. By default the
	/// binding uses ADS_SECURE_AUTHENTICATION option with the security context of the calling thread. However, if the authentication fails,
	/// the secure bind is downgraded to an anonymous bind, for example, a simple bind without user credentials. To securely bind to an ADSI
	/// object, use the ADsOpenObject function instead of the <c>ADsGetObject</c> function.
	/// </para>
	/// <para>
	/// It is possible to bind to an ADSI object with a user credential different from that of the currently logged-on user. To perform this
	/// operation, use the ADsOpenObject function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsgetobject HRESULT ADsGetObject( [in] LPCWSTR lpszPathName,
	// [in] REFIID riid, [out] VOID **ppObject );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsGetObject")]
	public static HRESULT ADsGetObject<T>(string lpszPathName, out T? ppObject) where T : class
	{
		var hr = ADsGetObject(lpszPathName, typeof(T).GUID, out var o);
		ppObject = hr.Succeeded ? (T)o! : null;
		return hr;
	}

	/// <summary>
	/// The <c>ADsOpenObject</c> function binds to an ADSI object using explicit user name and password credentials. <c>ADsOpenObject</c> is
	/// a wrapper function for IADsOpenDSObject and is equivalent to the IADsOpenDSObject::OpenDsObject method.
	/// </summary>
	/// <param name="lpszPathName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The null-terminated Unicode string that specifies the ADsPath of the ADSI object. For more information and code examples of binding
	/// strings for this parameter, see LDAP ADsPath and WinNT ADsPath.
	/// </para>
	/// </param>
	/// <param name="lpszUserName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The null-terminated Unicode string that specifies the user name to supply to the directory service to use for credentials. This
	/// string should always be in the format "&lt;domain\&gt;&lt;user name&gt;" to avoid ambiguity. For example, if DomainA and DomainB have
	/// a trust relationship and both domains have a user with the name "user1", it is not possible to predict which domain
	/// <c>ADsOpenObject</c> will use to validate "user1".
	/// </para>
	/// </param>
	/// <param name="lpszPassword">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The null-terminated Unicode string that specifies the password to supply to the directory service to use for credentials.</para>
	/// </param>
	/// <param name="dwReserved">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Provider-specific authentication flags used to define the binding options. For more information, see ADS_AUTHENTICATION_ENUM.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Interface identifier for the requested interface on this object.</para>
	/// </param>
	/// <param name="ppObject">
	/// <para>Type: <c>VOID**</c></para>
	/// <para>Pointer to a pointer to the requested interface.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard <c>HRESULT</c> return values, including the following.</para>
	/// <para>For more information, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function should not be used just to validate user credentials.</para>
	/// <para>
	/// A C/C++ client calls the <c>ADsOpenObject</c> helper function to bind to an ADSI object, using the user name and password supplied as
	/// credentials for the appropriate directory service. If <c>lpszUsername</c> and <c>lpszPassword</c> are <c>NULL</c> and
	/// <c>ADS_SECURE_AUTHENTICATION</c> is set, ADSI binds to the object using the security context of the calling thread, which is either
	/// the security context of the user account under which the application is running or of the client user account that the calling thread impersonates.
	/// </para>
	/// <para>
	/// The credentials passed to the <c>ADsOpenObject</c> function are used only with the particular object bound to and do not affect the
	/// security context of the calling thread. This means that, in the example below, the call to <c>ADsOpenObject</c> will use different
	/// credentials than the call to ADsGetObject.
	/// </para>
	/// <para>To work with the WinNT: provider, you can pass in <c>lpszUsername</c> as one of the following strings:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The name of a user account, that is, "jeffsmith".</description>
	/// </item>
	/// <item>
	/// <description>The Windows style user name, that is, "Fabrikam\jeffsmith".</description>
	/// </item>
	/// </list>
	/// <para>With the LDAP provider for Active Directory, you may pass in <c>lpszUsername</c> as one of the following strings:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// The name of a user account, such as "jeffsmith". To use a user name by itself, you must set only the <c>ADS_SECURE_AUTHENTICATION</c>
	/// flag in the <c>dwReserved</c> parameter.
	/// </description>
	/// </item>
	/// <item>
	/// <description>The user path from a previous version of Windows, such as "Fabrikam\jeffsmith".</description>
	/// </item>
	/// <item>
	/// <description>
	/// Distinguished Name, such as "CN=Jeff Smith,OU=Sales,DC=Fabrikam,DC=Com". To use a DN, the <c>dwReserved</c> parameter must be zero or
	/// it must include the <c>ADS_USE_SSL</c> flag.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// User Principal Name (UPN), such as "jeffsmith@Fabrikam.com". To use a UPN, assign the appropriate UPN value for the
	/// <c>userPrincipalName</c> attribute of the target user object.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// If Kerberos authentication is required for the successful completion of a specific directory request using the LDAP provider, the
	/// <c>lpszPathName</c> binding string must use either a serverless ADsPath, such as "LDAP://CN=Jeff Smith,CN=admin,DC=Fabrikam,DC=com",
	/// or it must use an ADsPath with a fully qualified DNS server name, such as "LDAP://central3.corp.Fabrikam.com/CN=Jeff
	/// Smith,CN=admin,DC=Fabrikam,DC=com". Binding to the server using a flat NETBIOS name or a short DNS name, for example, using the short
	/// name "central3" instead of "central3.corp.Fabrikam.com", may or may not yield Kerberos authentication.
	/// </para>
	/// <para>The following code example shows how to bind to a directory service object with the requested user credentials.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsopenobject HRESULT ADsOpenObject( [in] LPCWSTR lpszPathName,
	// [in] LPCWSTR lpszUserName, [in] LPCWSTR lpszPassword, [in] DWORD dwReserved, [in] REFIID riid, [out] void **ppObject );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsOpenObject")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ADsOpenObject([MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, [MarshalAs(UnmanagedType.LPWStr), Optional] string? lpszUserName,
		[MarshalAs(UnmanagedType.LPWStr), Optional] string? lpszPassword, [Optional] ADS_AUTHENTICATION dwReserved, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 4)] out object? ppObject);

	/// <summary>
	/// The <c>ADsOpenObject</c> function binds to an ADSI object using explicit user name and password credentials. <c>ADsOpenObject</c> is
	/// a wrapper function for IADsOpenDSObject and is equivalent to the IADsOpenDSObject::OpenDsObject method.
	/// </summary>
	/// <typeparam name="T">The type of the interface to retrieve.</typeparam>
	/// <param name="lpszPathName">
	/// The null-terminated Unicode string that specifies the ADsPath of the ADSI object. For more information and code examples of binding
	/// strings for this parameter, see LDAP ADsPath and WinNT ADsPath.
	/// </param>
	/// <param name="lpszUserName">
	/// The null-terminated Unicode string that specifies the user name to supply to the directory service to use for credentials. This
	/// string should always be in the format "&lt;domain\&gt;&lt;user name&gt;" to avoid ambiguity. For example, if DomainA and DomainB have
	/// a trust relationship and both domains have a user with the name "user1", it is not possible to predict which domain
	/// <c>ADsOpenObject</c> will use to validate "user1".
	/// </param>
	/// <param name="lpszPassword">
	/// The null-terminated Unicode string that specifies the password to supply to the directory service to use for credentials.
	/// </param>
	/// <param name="ppObject">The requested interface.</param>
	/// <param name="dwReserved">Provider-specific authentication flags used to define the binding options. For more information, see ADS_AUTHENTICATION_ENUM.</param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard <c>HRESULT</c> return values, including the following.</para>
	/// <para>For more information, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function should not be used just to validate user credentials.</para>
	/// <para>
	/// A C/C++ client calls the <c>ADsOpenObject</c> helper function to bind to an ADSI object, using the user name and password supplied as
	/// credentials for the appropriate directory service. If <c>lpszUsername</c> and <c>lpszPassword</c> are <c>NULL</c> and
	/// <c>ADS_SECURE_AUTHENTICATION</c> is set, ADSI binds to the object using the security context of the calling thread, which is either
	/// the security context of the user account under which the application is running or of the client user account that the calling thread impersonates.
	/// </para>
	/// <para>
	/// The credentials passed to the <c>ADsOpenObject</c> function are used only with the particular object bound to and do not affect the
	/// security context of the calling thread. This means that, in the example below, the call to <c>ADsOpenObject</c> will use different
	/// credentials than the call to ADsGetObject.
	/// </para>
	/// <para>To work with the WinNT: provider, you can pass in <c>lpszUsername</c> as one of the following strings:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The name of a user account, that is, "jeffsmith".</description>
	/// </item>
	/// <item>
	/// <description>The Windows style user name, that is, "Fabrikam\jeffsmith".</description>
	/// </item>
	/// </list>
	/// <para>With the LDAP provider for Active Directory, you may pass in <c>lpszUsername</c> as one of the following strings:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// The name of a user account, such as "jeffsmith". To use a user name by itself, you must set only the <c>ADS_SECURE_AUTHENTICATION</c>
	/// flag in the <c>dwReserved</c> parameter.
	/// </description>
	/// </item>
	/// <item>
	/// <description>The user path from a previous version of Windows, such as "Fabrikam\jeffsmith".</description>
	/// </item>
	/// <item>
	/// <description>
	/// Distinguished Name, such as "CN=Jeff Smith,OU=Sales,DC=Fabrikam,DC=Com". To use a DN, the <c>dwReserved</c> parameter must be zero or
	/// it must include the <c>ADS_USE_SSL</c> flag.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// User Principal Name (UPN), such as "jeffsmith@Fabrikam.com". To use a UPN, assign the appropriate UPN value for the
	/// <c>userPrincipalName</c> attribute of the target user object.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// If Kerberos authentication is required for the successful completion of a specific directory request using the LDAP provider, the
	/// <c>lpszPathName</c> binding string must use either a serverless ADsPath, such as "LDAP://CN=Jeff Smith,CN=admin,DC=Fabrikam,DC=com",
	/// or it must use an ADsPath with a fully qualified DNS server name, such as "LDAP://central3.corp.Fabrikam.com/CN=Jeff
	/// Smith,CN=admin,DC=Fabrikam,DC=com". Binding to the server using a flat NETBIOS name or a short DNS name, for example, using the short
	/// name "central3" instead of "central3.corp.Fabrikam.com", may or may not yield Kerberos authentication.
	/// </para>
	/// <para>The following code example shows how to bind to a directory service object with the requested user credentials.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adsopenobject HRESULT ADsOpenObject( [in] LPCWSTR lpszPathName,
	// [in] LPCWSTR lpszUserName, [in] LPCWSTR lpszPassword, [in] DWORD dwReserved, [in] REFIID riid, [out] void **ppObject );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsOpenObject")]
	public static HRESULT ADsOpenObject<T>(string lpszPathName, out T? ppObject, [Optional] ADS_AUTHENTICATION dwReserved, [Optional] string? lpszUserName,
		[Optional] string? lpszPassword) where T : class
	{
		var hr = ADsOpenObject(lpszPathName, lpszUserName, lpszPassword, dwReserved, typeof(T).GUID, out var o);
		ppObject = hr.Succeeded ? (T)o! : null;
		return hr;
	}

	/// <summary>
	/// The <c>ADsSetLastError</c> sets the last-error code value for the calling thread. Directory service providers can use this function
	/// to set extended errors. The function saves the error data in a per-thread data structure. <c>ADsSetLastError</c> operates similar to
	/// the SetLastError function.
	/// </summary>
	/// <param name="dwErr">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The error code that occurred. If this is an error defined by Windows, <c>pszError</c> is ignored. If this is ERROR_EXTENDED_ERROR, it
	/// indicates the provider has a network-specific error to report.
	/// </para>
	/// </param>
	/// <param name="pszError">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>The null-terminated Unicode string that describes the network-specific error.</para>
	/// </param>
	/// <param name="pszProvider">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>The null-terminated Unicode string that names the ADSI provider that raised the error.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>In a custom implementation of an ADSI provider, for example, an LDAP provider, you can set an operation error message as follows.</para>
	/// <para>The user can use the following code example to examine this operation code.</para>
	/// <para>The previous code example produces the following output for the operations error code set above.</para>
	/// <para>
	/// If you use <c>ERROR_DS_OPERATIONS_ERROR</c> without invoking the HRESULT_FROM_WIN32 macro when setting the error, the following
	/// output is returned.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-adssetlasterror void ADsSetLastError( [in] DWORD dwErr, [in]
	// LPCWSTR pszError, [in] LPCWSTR pszProvider );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ADsSetLastError")]
	[DllImport(Lib_Activeds, SetLastError = true, ExactSpelling = true)]
	public static extern void ADsSetLastError(Win32Error dwErr, [MarshalAs(UnmanagedType.LPWStr)] string pszError, [MarshalAs(UnmanagedType.LPWStr)] string pszProvider);

	/// <summary>The <c>AllocADsMem</c> function allocates a block of memory of the specified size.</summary>
	/// <param name="cb">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Contains the size, in bytes, to be allocated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// When successful, the function returns a non- <c>NULL</c> pointer to the allocated memory. The caller must free this memory when it is
	/// no longer required by passing the returned pointer to FreeADsMem.
	/// </para>
	/// <para>
	/// Returns <c>NULL</c> if not successful. Call ADsGetLastError to obtain extended error status. For more information about error code
	/// values, see ADSI Error Codes.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The memory block returned by <c>AllocADsMem</c> is initialized to zero.</para>
	/// <para>For more information and a code example that shows how to use the <c>AllocADsMem</c> function, see ReallocADsMem.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-allocadsmem LPVOID AllocADsMem( [in] DWORD cb );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.AllocADsMem")]
	[DllImport(Lib_Activeds, SetLastError = true, ExactSpelling = true)]
	public static extern IntPtr AllocADsMem(uint cb);

	/// <summary>The <c>AllocADsStr</c> function allocates memory for and copies a specified string.</summary>
	/// <param name="pStr">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>Pointer to a null-terminated Unicode string to be copied.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// When successful, the function returns a non- <c>NULL</c> pointer to the allocated memory. The string in <c>pStr</c> is copied to this
	/// buffer and null-terminated. The caller must free this memory when it is no longer required by passing the returned pointer to FreeADsStr.
	/// </para>
	/// <para>
	/// Returns <c>NULL</c> if not successful. Call ADsGetLastError to obtain the extended error status. For more information about error
	/// code values, see ADSI Error Codes.
	/// </para>
	/// </returns>
	/// <remarks>For more information and a code example that shows how to use the <c>AllocADsStr</c> function, see ReallocADsStr.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-allocadsstr LPWSTR AllocADsStr( [in] LPCWSTR pStr );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.AllocADsStr")]
	[DllImport(Lib_Activeds, SetLastError = true, ExactSpelling = true)]
	public static extern StrPtrUni AllocADsStr([MarshalAs(UnmanagedType.LPWStr)] string pStr);

	/// <summary>The <c>BinarySDToSecurityDescriptor</c> function converts a binary security descriptor to an IADsSecurityDescriptor object.</summary>
	/// <param name="pSecurityDescriptor">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>Address of a SECURITY_DESCRIPTOR structure to convert.</para>
	/// </param>
	/// <param name="pVarsec">
	/// <para>Type: <c>VARIANT*</c></para>
	/// <para>
	/// Address of a VARIANT that receives the object. The <c>VARIANT</c> contains a <c>VT_DISPATCH</c> object that can be queried for the
	/// IADsSecurityDescriptor interface. The caller must release this <c>VARIANT</c> by passing the <c>VARIANT</c> to the VariantClear function.
	/// </para>
	/// </param>
	/// <param name="pszServerName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// A null-terminated Unicode string that provides the name of the server that the security descriptor was retrieved from. This parameter
	/// is optional and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="userName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// A null-terminated Unicode string that provides the user name to be associated with the security descriptor. This parameter is
	/// optional and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="passWord">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// A null-terminated Unicode string that provides the password to be associated with the security descriptor. This parameter is optional
	/// and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Contains authentication flags for the conversion. This can be zero or a combination of one or more of the ADS_AUTHENTICATION_ENUM
	/// enumeration values.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports standard return values, as well as the following:</para>
	/// <para>If the operation fails, an ADSI error code is returned. For more information, see ADSI Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// This function is used for legacy applications that must manually convert security descriptors to binary security descriptors. For new
	/// applications, use the IADsSecurityUtility interface, which does this conversion automatically.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-binarysdtosecuritydescriptor HRESULT
	// BinarySDToSecurityDescriptor( [in] PSECURITY_DESCRIPTOR pSecurityDescriptor, [out] VARIANT *pVarsec, [in] LPCWSTR pszServerName, [in]
	// LPCWSTR userName, [in] LPCWSTR passWord, [in] DWORD dwFlags );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.BinarySDToSecurityDescriptor")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT BinarySDToSecurityDescriptor([In] PSECURITY_DESCRIPTOR pSecurityDescriptor,
		[MarshalAs(UnmanagedType.Struct)] out object pVarsec, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszServerName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? userName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? passWord,
		[Optional] ADS_AUTHENTICATION dwFlags);

	/// <summary>The <c>FreeADsMem</c> function frees the memory allocated by AllocADsMem or ReallocADsMem.</summary>
	/// <param name="pMem">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>Pointer to the memory to be freed. This memory must have been allocated with the AllocADsMem or ReallocADsMem function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>The function returns <c>TRUE</c> if successful, otherwise it returns <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Do not use this function to free memory allocated with the AllocADsStr or ReallocADsStr function. Use the FreeADsStr function to free
	/// memory allocated with these functions.
	/// </para>
	/// <para>For more information and a code example that shows how to use the <c>FreeADsMem</c> function, see ReallocADsMem.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-freeadsmem BOOL FreeADsMem( [in] LPVOID pMem );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.FreeADsMem")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeADsMem([In] IntPtr pMem);

	/// <summary>The <c>FreeADsStr</c> function frees the memory of a string allocated by AllocADsStr or ReallocADsStr.</summary>
	/// <param name="pStr">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>Pointer to the string to be freed. This string must have been allocated with the AllocADsStr or ReallocADsStr function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>The function returns <c>TRUE</c> if the memory is freed. Otherwise, it returns <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Do not use this function to free memory allocated with the AllocADsMem or ReallocADsMem function. Use the FreeADsMem function to free
	/// memory allocated with these functions.
	/// </para>
	/// <para>For more information and a code example that shows how to use the <c>FreeADsStr</c> function, see ReallocADsStr.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-freeadsstr BOOL FreeADsStr( [in] LPWSTR pStr );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.FreeADsStr")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeADsStr(StrPtrUni pStr);

	/// <summary>The <c>ReallocADsMem</c> function reallocates and copies an existing memory block.</summary>
	/// <param name="pOldMem">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// Pointer to the memory to copy. <c>ReallocADsMem</c> will free this memory with FreeADsMem after it has been copied. If additional
	/// memory cannot be allocated, this memory is not freed. This memory must have been allocated with the AllocADsMem, AllocADsStr,
	/// <c>ReallocADsMem</c>, or ReallocADsStr function.
	/// </para>
	/// <para>The caller must free this memory when it is no longer required by passing this pointer to FreeADsMem.</para>
	/// </param>
	/// <param name="cbOld">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Size, in bytes, of the memory to copy.</para>
	/// </param>
	/// <param name="cbNew">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Size, in bytes, of the memory to allocate.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>When successful, the function returns a pointer to the new allocated memory. Otherwise it returns <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>If <c>cbNew</c> is less than <c>cbOld</c>, the existing memory is truncated to fit the new memory size.</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to use <c>ReallocADsMem</c> to enlarge a string.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-reallocadsmem LPVOID ReallocADsMem( [in] LPVOID pOldMem, [in]
	// DWORD cbOld, [in] DWORD cbNew );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ReallocADsMem")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern IntPtr ReallocADsMem([In] IntPtr pOldMem, uint cbOld, uint cbNew);

	/// <summary>The <c>ReallocADsStr</c> function creates a copy of a Unicode string.</summary>
	/// <param name="ppStr">
	/// <para>Type: <c>LPWSTR*</c></para>
	/// <para>
	/// Pointer to null-terminated Unicode string pointer that receives the allocated string. <c>ReallocADsStr</c> will attempt to free this
	/// memory with FreeADsStr before reallocating the string, so this parameter should be initialized to <c>NULL</c> if the memory should
	/// not be freed or was not allocated with the AllocADsMem, AllocADsStr, ReallocADsMem or <c>ReallocADsStr</c> function.
	/// </para>
	/// <para>The caller must free this memory when it is no longer required by passing this pointer to FreeADsStr.</para>
	/// </param>
	/// <param name="pStr">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>Pointer to a null-terminated Unicode string that contains the string to copy.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>The function returns <c>TRUE</c> if successful, otherwise <c>FALSE</c> is returned.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-reallocadsstr BOOL ReallocADsStr( [out] LPWSTR *ppStr, [in]
	// LPWSTR pStr );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.ReallocADsStr")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReallocADsStr(ref StrPtrUni ppStr, [MarshalAs(UnmanagedType.LPWStr)] string pStr);

	/// <summary>
	/// The <c>SecurityDescriptorToBinarySD</c> function converts an IADsSecurityDescriptor object to the binary security descriptor format.
	/// </summary>
	/// <param name="vVarSecDes">
	/// <para>Type: <c>VARIANT</c></para>
	/// <para>
	/// Contains a VARIANT that contains the security descriptor to convert. The <c>VARIANT</c> must contain a <c>VT_DISPATCH</c> that
	/// contains an IADsSecurityDescriptor object.
	/// </para>
	/// </param>
	/// <param name="ppSecurityDescriptor">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR*</c></para>
	/// <para>
	/// Address of a SECURITY_DESCRIPTOR pointer that receives the binary security descriptor data. The caller must free this memory by
	/// passing this pointer to the FreeADsMem function.
	/// </para>
	/// </param>
	/// <param name="pdwSDLength">
	/// <para>Type: <c>PDWORD</c></para>
	/// <para>Address of a <c>DWORD</c> value that receives the length, in bytes of the binary security descriptor data.</para>
	/// </param>
	/// <param name="pszServerName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// A null-terminated Unicode string that specifies the name of the server where the security descriptor is placed. This parameter is
	/// optional and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="userName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// A null-terminated Unicode string that contains the user name that the security descriptor is associated to. This parameter is
	/// optional and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="passWord">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// A null-terminated Unicode string that contains the password that the security descriptor is associated. This parameter is optional
	/// and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Contains authentication flags for the conversion. This can be zero or a combination of one or more of the ADS_AUTHENTICATION_ENUM
	/// enumeration values.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method supports the standard return values, as well as the following.</para>
	/// </returns>
	/// <remarks>
	/// This function is used for legacy applications to manually convert security descriptors to binary security descriptors. For new
	/// applications, use IADsSecurityUtility, which performs this conversion automatically.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/adshlp/nf-adshlp-securitydescriptortobinarysd HRESULT
	// SecurityDescriptorToBinarySD( [in] VARIANT vVarSecDes, [out] PSECURITY_DESCRIPTOR *ppSecurityDescriptor, [out] PDWORD pdwSDLength,
	// [in] LPCWSTR pszServerName, [in] LPCWSTR userName, [in] LPCWSTR passWord, [in] DWORD dwFlags );
	[PInvokeData("adshlp.h", MSDNShortId = "NF:adshlp.SecurityDescriptorToBinarySD")]
	[DllImport(Lib_Activeds, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT SecurityDescriptorToBinarySD([In, MarshalAs(UnmanagedType.Struct)] object? vVarSecDes,
		out PSECURITY_DESCRIPTOR ppSecurityDescriptor, out uint pdwSDLength, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszServerName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? userName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? passWord,
		[Optional] ADS_AUTHENTICATION dwFlags);
}