using System.Collections.Generic;
using System.Linq;
using Vanara.PInvoke.Collections;

namespace Vanara.PInvoke;

/// <summary>Functions, constants, and structures for Extended Linguistic Services.</summary>
public static partial class ElsCore
{
	/// <summary>{CF7E00B1-909B-4d95-A8F4-611F7C377702}</summary>
	public static readonly Guid ELS_GUID_LANGUAGE_DETECTION = new(0xCF7E00B1, 0x909B, 0x4D95, 0xA8, 0xF4, 0x61, 0x1F, 0x7C, 0x37, 0x77, 0x02);

	/// <summary>{2D64B439-6CAF-4f6b-B688-E5D0F4FAA7D7}</summary>
	public static readonly Guid ELS_GUID_SCRIPT_DETECTION = new(0x2D64B439, 0x6CAF, 0x4F6B, 0xB6, 0x88, 0xE5, 0xD0, 0xF4, 0xFA, 0xA7, 0xD7);

	/// <summary>{F4DFD825-91A4-489f-855E-9AD9BEE55727}</summary>
	public static readonly Guid ELS_GUID_TRANSLITERATION_BENGALI_TO_LATIN = new(0xF4DFD825, 0x91A4, 0x489f, 0x85, 0x5E, 0x9A, 0xD9, 0xBE, 0xE5, 0x57, 0x27);

	/// <summary>{3DD12A98-5AFD-4903-A13F-E17E6C0BFE01}</summary>
	public static readonly Guid ELS_GUID_TRANSLITERATION_CYRILLIC_TO_LATIN = new(0x3DD12A98, 0x5AFD, 0x4903, 0xA1, 0x3F, 0xE1, 0x7E, 0x6C, 0x0B, 0xFE, 0x01);

	/// <summary>{C4A4DCFE-2661-4d02-9835-F48187109803}</summary>
	public static readonly Guid ELS_GUID_TRANSLITERATION_DEVANAGARI_TO_LATIN = new(0xC4A4DCFE, 0x2661, 0x4d02, 0x98, 0x35, 0xF4, 0x81, 0x87, 0x10, 0x98, 0x03);

	/// <summary>{4BA2A721-E43D-41b7-B330-536AE1E48863}</summary>
	public static readonly Guid ELS_GUID_TRANSLITERATION_HANGUL_DECOMPOSITION = new(0x4BA2A721, 0xE43D, 0x41b7, 0xB3, 0x30, 0x53, 0x6A, 0xE1, 0xE4, 0x88, 0x63);

	/// <summary>{3CACCDC8-5590-42dc-9A7B-B5A6B5B3B63B}</summary>
	public static readonly Guid ELS_GUID_TRANSLITERATION_HANS_TO_HANT = new(0x3CACCDC8, 0x5590, 0x42dc, 0x9A, 0x7B, 0xB5, 0xA6, 0xB5, 0xB3, 0xB6, 0x3B);

	/// <summary>{A3A8333B-F4FC-42f6-A0C4-0462FE7317CB}</summary>
	public static readonly Guid ELS_GUID_TRANSLITERATION_HANT_TO_HANS = new(0xA3A8333B, 0xF4FC, 0x42f6, 0xA0, 0xC4, 0x04, 0x62, 0xFE, 0x73, 0x17, 0xCB);

	/// <summary>{D8B983B1-F8BF-4a2b-BCD5-5B5EA20613E1}</summary>
	public static readonly Guid ELS_GUID_TRANSLITERATION_MALAYALAM_TO_LATIN = new(0xD8B983B1, 0xF8BF, 0x4a2b, 0xBC, 0xD5, 0x5B, 0x5E, 0xA2, 0x06, 0x13, 0xE1);

	private const string Lib_Elscore = "elscore.dll";

	/// <summary>
	/// An application-defined callback function that asynchronously processes data produced by the MappingRecognizeText function. The
	/// <c>MAPPINGCALLBACKPROC</c> type defines a pointer to this callback function. <c>MappingCallbackProc</c> is a placeholder for the
	/// application-defined function name.
	/// </summary>
	/// <param name="pBag">Pointer to a MAPPING_PROPERTY_BAG structure containing the results of the call to MappingRecognizeText.</param>
	/// <param name="data">
	/// Pointer to private application data. This pointer is the same as that passed in the <c>pRecognizeCallerData</c> member of the
	/// MAPPING_OPTIONS structure.
	/// </param>
	/// <param name="dwDataSize">
	/// Size, in bytes, of the private application data. This size is the same as that passed in the <c>dwRecognizeCallerDataSize</c> member
	/// of the MAPPING_OPTIONS structure when the application calls MappingRecognizeText asynchronously.
	/// </param>
	/// <param name="Result">
	/// Return code from MappingRecognizeText. The return code is S_OK if the function succeeded, or an error code otherwise.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// A <c>MappingCallbackProc</c> function consumes the results retrieved by MappingRecognizeText. The application registers the callback
	/// function by passing its address to MappingRecognizeText in a MAPPING_OPTIONS structure.
	/// </para>
	/// <para>
	/// The application should check the <c>Result</c> parameter before using the data in the <c>pBag</c> parameter. When it is done using
	/// the data from the property bag, the application must call MappingFreePropertyBag because the property bag can contain pointers into
	/// the original text. For more information about the property bag, see the remarks for the MAPPING_PROPERTY_BAG structure.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nc-elscore-pfn_mappingcallbackproc PFN_MAPPINGCALLBACKPROC
	// PfnMappingcallbackproc; void PfnMappingcallbackproc( [in] _MAPPING_PROPERTY_BAG *pBag, [in] LPVOID data, [in] DWORD dwDataSize, [in]
	// HRESULT Result ) {...}
	[PInvokeData("elscore.h", MSDNShortId = "NC:elscore.PFN_MAPPINGCALLBACKPROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false, CharSet = CharSet.Unicode)]
	public delegate void PFN_MAPPINGCALLBACKPROC(in MAPPING_PROPERTY_BAG pBag, [In] IntPtr data, uint dwDataSize, [In] HRESULT Result);

	/// <summary>Online service constants used in MAPPING_ENUM_OPTIONS (OnlineService field)</summary>
	[PInvokeData("elscore.h", MSDNShortId = "NS:elscore._MAPPING_ENUM_OPTIONS")]
	public enum ELS_ONLINE_SVC : byte
	{
		/// <summary/>
		ALL_SERVICES = 0,

		/// <summary/>
		ONLINE_SERVICES = 1,

		/// <summary/>
		OFFLINE_SERVICES = 2,
	}

	/// <summary>Service types constants used in MAPPING_ENUM_OPTIONS (ServiceType field)</summary>
	[PInvokeData("elscore.h", MSDNShortId = "NS:elscore._MAPPING_ENUM_OPTIONS")]
	public enum ELS_SVC_TYPE : byte
	{
		/// <summary/>
		ALL_SERVICE_TYPES = 0,

		/// <summary/>
		HIGHLEVEL_SERVICE_TYPES = 1,

		/// <summary/>
		LOWLEVEL_SERVICE_TYPES = 2,
	}

	/// <summary>
	/// Causes an ELS service to perform an action after text recognition has occurred. For example, a phone dialer service first must
	/// recognize phone numbers and then can perform the "action" of dialing a number.
	/// </summary>
	/// <param name="pBag">
	/// Pointer to a MAPPING_PROPERTY_BAG structure containing the results of a previous call to MappingRecognizeText. This parameter cannot
	/// be set to <c>NULL</c>.
	/// </param>
	/// <param name="dwRangeIndex">
	/// A starting index inside the text recognition results for a recognized text range. This value should be between 0 and the range count.
	/// </param>
	/// <param name="pszActionId">Pointer to the identifier of the action to perform. This parameter cannot be set to <c>NULL</c>.</param>
	/// <returns>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</returns>
	/// <remarks>
	/// <para>The application must precede the call to <c>MappingDoAction</c> with a call to MappingRecognizeText.</para>
	/// <para><c>Warning</c>  The data referred to by the <c>pszText</c> and <c>pOptions</c> arguments passed to MappingRecognizeText
	/// <para>must remain valid until the property bag structure passed by <c>pBag</c> is freed via</para>
	/// <para>MappingFreePropertyBag. This is because both synchronous and asynchronous calls to</para>
	/// <para><c>MappingRecognizeText</c> and <c>MappingDoAction</c> will attempt to use the data passed to the initial</para>
	/// <para>call to <c>MappingRecognizeText</c>.</para>
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappingdoaction HRESULT MappingDoAction( [in, out]
	// PMAPPING_PROPERTY_BAG pBag, [in] DWORD dwRangeIndex, [in] LPCWSTR pszActionId );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingDoAction")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingDoAction(ref MAPPING_PROPERTY_BAG pBag, uint dwRangeIndex, [MarshalAs(UnmanagedType.LPWStr)] string pszActionId);

	/// <summary>Frees memory and resources allocated during an ELS text recognition operation.</summary>
	/// <param name="pBag">
	/// Pointer to a MAPPING_PROPERTY_BAG structure containing the properties for which to free resources. This parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <returns>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</returns>
	/// <remarks>
	/// <para>
	/// An ELS service allocates memory and resources for data retrieved from application calls to MappingRecognizeText. The
	/// <c>MappingFreePropertyBag</c> function releases these resources.
	/// </para>
	/// <para><c>Caution</c>  Services should not be freed before freeing the property bags produced by those services.</para>
	/// <para></para>
	/// <para>
	/// <c>Caution</c>  The application must call this function only once for each call to MappingRecognizeText when the property bag is no
	/// longer needed. Not calling <c>MappingFreePropertyBag</c> after each call to <c>MappingRecognizeText</c> causes a resource leak. For
	/// more information about memory allocation for the property bag, see the remarks for the MAPPING_PROPERTY_BAG structure.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappingfreepropertybag HRESULT MappingFreePropertyBag( [in]
	// PMAPPING_PROPERTY_BAG pBag );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingFreePropertyBag")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingFreePropertyBag(in MAPPING_PROPERTY_BAG pBag);

	/// <summary>Frees memory and resources allocated during an ELS text recognition operation.</summary>
	/// <param name="pBag">
	/// Pointer to a MAPPING_PROPERTY_BAG structure containing the properties for which to free resources. This parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <returns>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</returns>
	/// <remarks>
	/// <para>
	/// An ELS service allocates memory and resources for data retrieved from application calls to MappingRecognizeText. The
	/// <c>MappingFreePropertyBag</c> function releases these resources.
	/// </para>
	/// <para><c>Caution</c>  Services should not be freed before freeing the property bags produced by those services.</para>
	/// <para></para>
	/// <para>
	/// <c>Caution</c>  The application must call this function only once for each call to MappingRecognizeText when the property bag is no
	/// longer needed. Not calling <c>MappingFreePropertyBag</c> after each call to <c>MappingRecognizeText</c> causes a resource leak. For
	/// more information about memory allocation for the property bag, see the remarks for the MAPPING_PROPERTY_BAG structure.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappingfreepropertybag HRESULT MappingFreePropertyBag( [in]
	// PMAPPING_PROPERTY_BAG pBag );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingFreePropertyBag")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingFreePropertyBag(IntPtr pBag);

	/// <summary>
	/// Frees memory and resources allocated for the application to interact with one or more ELS services. The memory and resources are
	/// allocated in an application call to MappingGetServices.
	/// </summary>
	/// <param name="pServiceInfo">
	/// Pointer to an array of MAPPING_SERVICE_INFO structures containing service descriptions retrieved by a prior call to
	/// MappingGetServices. This parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <returns>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</returns>
	/// <remarks>
	/// <para><c>Caution</c>  Services should not be freed before freeing the property bags produced by those services.</para>
	/// <para></para>
	/// <para>
	/// Since all services currently run in the application process, the ELS platform does not unload the service DLLs when the services are
	/// released. The operating system unloads the DLLs automatically when the application terminates.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappingfreeservices HRESULT MappingFreeServices( [in]
	// PMAPPING_SERVICE_INFO pServiceInfo );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingFreeServices")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingFreeServices([In] IntPtr pServiceInfo);

	/// <summary>
	/// Retrieves a list of available ELS platform-supported services, along with associated information, according to application-specified criteria.
	/// </summary>
	/// <param name="pOptions">
	/// Pointer to a MAPPING_ENUM_OPTIONS structure containing criteria to use during enumeration of services. The application specifies
	/// <c>NULL</c> for this parameter to retrieve all installed services.
	/// </param>
	/// <param name="prgServices">
	/// Address of a pointer to an array of MAPPING_SERVICE_INFO structures containing service information matching the criteria supplied in
	/// the <c>pOptions</c> parameter.
	/// </param>
	/// <param name="pdwServicesCount">Pointer to a DWORD variable in which this function retrieves the number of retrieved services.</param>
	/// <returns>
	/// <para>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</para>
	/// <para><c>Note</c>  The application must test for any failure before proceeding with further operations.</para>
	/// <para></para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The ELS application can either retrieve all services or filter the services according to specified options. For an associated
	/// procedure and code sample, see Enumerating and Freeing Services.
	/// </para>
	/// <para>To avoid resource leaks, the application must free the pointer indicated by <c>prgServices</c> with a call to MappingFreeServices.</para>
	/// <para>
	/// For performance reasons, it is recommended to retrieve services infrequently. For example, if the application needs a specific
	/// service, by GUID, it can be enumerated when needed and cached for future use.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappinggetservices HRESULT MappingGetServices( [in, optional]
	// PMAPPING_ENUM_OPTIONS pOptions, [out] PMAPPING_SERVICE_INFO *prgServices, [out] DWORD *pdwServicesCount );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingGetServices")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingGetServices(in MAPPING_ENUM_OPTIONS pOptions, out IntPtr prgServices, out uint pdwServicesCount);

	/// <summary>
	/// Retrieves a list of available ELS platform-supported services, along with associated information, according to application-specified criteria.
	/// </summary>
	/// <param name="pOptions">
	/// Pointer to a MAPPING_ENUM_OPTIONS structure containing criteria to use during enumeration of services. The application specifies
	/// <c>NULL</c> for this parameter to retrieve all installed services.
	/// </param>
	/// <param name="prgServices">
	/// Address of a pointer to an array of MAPPING_SERVICE_INFO structures containing service information matching the criteria supplied in
	/// the <c>pOptions</c> parameter.
	/// </param>
	/// <param name="pdwServicesCount">Pointer to a DWORD variable in which this function retrieves the number of retrieved services.</param>
	/// <returns>
	/// <para>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</para>
	/// <para><c>Note</c>  The application must test for any failure before proceeding with further operations.</para>
	/// <para></para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The ELS application can either retrieve all services or filter the services according to specified options. For an associated
	/// procedure and code sample, see Enumerating and Freeing Services.
	/// </para>
	/// <para>To avoid resource leaks, the application must free the pointer indicated by <c>prgServices</c> with a call to MappingFreeServices.</para>
	/// <para>
	/// For performance reasons, it is recommended to retrieve services infrequently. For example, if the application needs a specific
	/// service, by GUID, it can be enumerated when needed and cached for future use.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappinggetservices HRESULT MappingGetServices( [in, optional]
	// PMAPPING_ENUM_OPTIONS pOptions, [out] PMAPPING_SERVICE_INFO *prgServices, [out] DWORD *pdwServicesCount );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingGetServices")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingGetServices([In, Optional] IntPtr pOptions, out IntPtr prgServices, out uint pdwServicesCount);

	/// <summary>
	/// Retrieves a list of available ELS platform-supported services, along with associated information, according to application-specified criteria.
	/// </summary>
	/// <param name="pOptions">Pointer to a MAPPING_ENUM_OPTIONS structure containing criteria to use during enumeration of services.</param>
	/// <param name="prgServices">
	/// A safe array of MAPPING_SERVICE_INFO structures containing service information matching the criteria supplied in the <c>pOptions</c> parameter.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</para>
	/// <para><c>Note</c>  The application must test for any failure before proceeding with further operations.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The ELS application can either retrieve all services or filter the services according to specified options. For an associated
	/// procedure and code sample, see Enumerating and Freeing Services.
	/// </para>
	/// <para>
	/// For performance reasons, it is recommended to retrieve services infrequently. For example, if the application needs a specific
	/// service, by GUID, it can be enumerated when needed and cached for future use.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappinggetservices HRESULT MappingGetServices( [in, optional]
	// PMAPPING_ENUM_OPTIONS pOptions, [out] PMAPPING_SERVICE_INFO *prgServices, [out] DWORD *pdwServicesCount );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingGetServices")]
	public static HRESULT MappingGetServices(in MAPPING_ENUM_OPTIONS pOptions, out SafeMAPPING_SERVICE_INFOArray prgServices)
	{
		var hr = MappingGetServices(in pOptions, out var p, out var pdwServicesCount);
		prgServices = hr.Failed ? new(default, 0) : new(p, (int)pdwServicesCount);
		return hr;
	}

	/// <summary>
	/// Retrieves a list of available ELS platform-supported services, along with associated information, according to application-specified criteria.
	/// </summary>
	/// <param name="prgServices">
	/// A safe array of MAPPING_SERVICE_INFO structures containing service information matching the criteria supplied in the <c>pOptions</c> parameter.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</para>
	/// <para><c>Note</c>  The application must test for any failure before proceeding with further operations.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The ELS application can either retrieve all services or filter the services according to specified options. For an associated
	/// procedure and code sample, see Enumerating and Freeing Services.
	/// </para>
	/// <para>
	/// For performance reasons, it is recommended to retrieve services infrequently. For example, if the application needs a specific
	/// service, by GUID, it can be enumerated when needed and cached for future use.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappinggetservices HRESULT MappingGetServices( [in, optional]
	// PMAPPING_ENUM_OPTIONS pOptions, [out] PMAPPING_SERVICE_INFO *prgServices, [out] DWORD *pdwServicesCount );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingGetServices")]
	public static HRESULT MappingGetServices(out SafeMAPPING_SERVICE_INFOArray prgServices)
	{
		var hr = MappingGetServices(default, out var p, out var pdwServicesCount);
		prgServices = hr.Failed ? new(default, 0) : new(p, (int)pdwServicesCount);
		return hr;
	}

	/// <summary>
	/// Calls upon an ELS service to recognize text. For example, the Microsoft Language Detection service will attempt to recognize the
	/// language in which the input text is written.
	/// </summary>
	/// <param name="pServiceInfo">
	/// Pointer to a MAPPING_SERVICE_INFO structure containing information about the service to use in text recognition. The structure must
	/// be one of the structures retrieved by a previous call to MappingGetServices. This parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <param name="pszText">
	/// Pointer to the text to recognize. The text must be UTF-16, but some services have additional requirements for the input format. This
	/// parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <param name="dwLength">Length, in characters, of the text specified in <c>pszText</c>.</param>
	/// <param name="dwIndex">
	/// Index inside the specified text to be used by the service. This value should be between 0 and <c>dwLength</c>-1. If the application
	/// wants to process the entire text, it should set this parameter to 0.
	/// </param>
	/// <param name="pOptions">
	/// Pointer to a MAPPING_OPTIONS structure containing options that affect the result and behavior of text recognition. The application
	/// does not have to specify values for all structure members. This parameter can be set to <c>NULL</c> to use the default mapping options.
	/// </param>
	/// <param name="pbag">
	/// Pointer to a MAPPING_PROPERTY_BAG structure in which the service stores its results. On input, the application passes a structure
	/// with only the size provided, and the other members set to 0. On output, the structure is filled with information produced by the
	/// service during text recognition. This parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <returns>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</returns>
	/// <remarks>
	/// <para>
	/// The type of text to recognize depends on the service type used by the application. For more information, see Requesting Text Recognition.
	/// </para>
	/// <para>
	/// <c>Warning</c>  The data referred to by <c>pszText</c> and <c>pOptions</c> must remain valid until the property bag structure passed
	/// by <c>pBag</c> is freed via
	/// <para>MappingFreePropertyBag. This is because both synchronous and asynchronous calls to</para>
	/// <para><c>MappingRecognizeText</c> and MappingDoAction will attempt to use the data passed to the initial</para>
	/// <para>call to <c>MappingRecognizeText</c>.</para>
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappingrecognizetext HRESULT MappingRecognizeText( [in]
	// PMAPPING_SERVICE_INFO pServiceInfo, [in] LPCWSTR pszText, [in] DWORD dwLength, [in] DWORD dwIndex, [in, optional] PMAPPING_OPTIONS
	// pOptions, [in, out] PMAPPING_PROPERTY_BAG pbag );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingRecognizeText")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingRecognizeText(in MAPPING_SERVICE_INFO pServiceInfo, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int dwLength, uint dwIndex,
		[In, Optional] IntPtr pOptions, ref MAPPING_PROPERTY_BAG pbag);

	/// <summary>
	/// Calls upon an ELS service to recognize text. For example, the Microsoft Language Detection service will attempt to recognize the
	/// language in which the input text is written.
	/// </summary>
	/// <param name="pServiceInfo">
	/// Pointer to a MAPPING_SERVICE_INFO structure containing information about the service to use in text recognition. The structure must
	/// be one of the structures retrieved by a previous call to MappingGetServices. This parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <param name="pszText">
	/// Pointer to the text to recognize. The text must be UTF-16, but some services have additional requirements for the input format. This
	/// parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <param name="dwLength">Length, in characters, of the text specified in <c>pszText</c>.</param>
	/// <param name="dwIndex">
	/// Index inside the specified text to be used by the service. This value should be between 0 and <c>dwLength</c>-1. If the application
	/// wants to process the entire text, it should set this parameter to 0.
	/// </param>
	/// <param name="pOptions">
	/// Pointer to a MAPPING_OPTIONS structure containing options that affect the result and behavior of text recognition. The application
	/// does not have to specify values for all structure members. This parameter can be set to <c>NULL</c> to use the default mapping options.
	/// </param>
	/// <param name="pbag">
	/// Pointer to a MAPPING_PROPERTY_BAG structure in which the service stores its results. On input, the application passes a structure
	/// with only the size provided, and the other members set to 0. On output, the structure is filled with information produced by the
	/// service during text recognition. This parameter cannot be set to <c>NULL</c>.
	/// </param>
	/// <returns>Returns S_OK if successful. The function returns an error HRESULT value if it does not succeed.</returns>
	/// <remarks>
	/// <para>
	/// The type of text to recognize depends on the service type used by the application. For more information, see Requesting Text Recognition.
	/// </para>
	/// <para>
	/// <c>Warning</c>  The data referred to by <c>pszText</c> and <c>pOptions</c> must remain valid until the property bag structure passed
	/// by <c>pBag</c> is freed via
	/// <para>MappingFreePropertyBag. This is because both synchronous and asynchronous calls to</para>
	/// <para><c>MappingRecognizeText</c> and MappingDoAction will attempt to use the data passed to the initial</para>
	/// <para>call to <c>MappingRecognizeText</c>.</para>
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/nf-elscore-mappingrecognizetext HRESULT MappingRecognizeText( [in]
	// PMAPPING_SERVICE_INFO pServiceInfo, [in] LPCWSTR pszText, [in] DWORD dwLength, [in] DWORD dwIndex, [in, optional] PMAPPING_OPTIONS
	// pOptions, [in, out] PMAPPING_PROPERTY_BAG pbag );
	[PInvokeData("elscore.h", MSDNShortId = "NF:elscore.MappingRecognizeText")]
	[DllImport(Lib_Elscore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MappingRecognizeText(in MAPPING_SERVICE_INFO pServiceInfo, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int dwLength, uint dwIndex,
		in MAPPING_OPTIONS pOptions, ref MAPPING_PROPERTY_BAG pbag);

	/// <summary>
	/// Contains text recognition results for a recognized text subrange. An array of structures of this type is retrieved by an Extended
	/// Linguistic Services (ELS) service in a MAPPING_PROPERTY_BAG structure.
	/// </summary>
	/// <remarks>
	/// <para><c>Note</c>  The application should not alter any of the members of this data structure.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/ns-elscore-mapping_data_range typedef struct _MAPPING_DATA_RANGE { DWORD
	// dwStartIndex; DWORD dwEndIndex; LPWSTR pszDescription; DWORD dwDescriptionLength; LPVOID pData; DWORD dwDataSize; LPWSTR
	// pszContentType; LPWSTR *prgActionIds; DWORD dwActionsCount; LPWSTR *prgActionDisplayNames; } MAPPING_DATA_RANGE, *PMAPPING_DATA_RANGE;
	[PInvokeData("elscore.h", MSDNShortId = "NS:elscore._MAPPING_DATA_RANGE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MAPPING_DATA_RANGE
	{
		/// <summary>
		/// Index of the beginning of the subrange in the text, where 0 indicates the character at the pointer passed to
		/// MappingRecognizeText, instead of an offset to the index passed to the function in the <c>dwIndex</c> parameter. The value should
		/// be less than the entire length of the text.
		/// </summary>
		public uint dwStartIndex;

		/// <summary>
		/// Index of the end of the subrange in the text, where 0 indicates the character at the pointer passed to MappingRecognizeText,
		/// instead of an offset to the index passed to the function in the <c>dwIndex</c> parameter. The value should be less than the
		/// entire length of the text.
		/// </summary>
		public uint dwEndIndex;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszDescription;

		/// <summary>Reserved.</summary>
		public uint dwDescriptionLength;

		/// <summary>
		/// Pointer to data retrieved as service output associated with the subrange. This data must be of the format indicated by the
		/// content type supplied in the <c>pszContentType</c> member.
		/// </summary>
		public IntPtr pData;

		/// <summary>
		/// Size, in bytes, of the data specified in <c>pData</c>. Each service is required to report its output data size in bytes.
		/// </summary>
		public uint dwDataSize;

		/// <summary>
		/// <para>
		/// Optional. Pointer to a string specifying the MIME content type of the data indicated by <c>pData</c>. Examples of content types
		/// are "text/plain", "text/html", and "text/css".
		/// </para>
		/// <para>
		/// <c>Note</c>  In Windows 7, the ELS services support only the content type "text/plain". A content type specification can be found
		/// at Text Media Types.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszContentType;

		/// <summary>
		/// <para>Available action Ids for this subrange. They are usable for calling MappingDoAction.</para>
		/// <para><c>Note</c>  In Windows 7, the ELS services do not expose any actions.</para>
		/// </summary>
		public ArrayPointer<LPWSTR> prgActionIds;

		/// <summary>
		/// <para>Available action Ids for this subrange. They are usable for calling MappingDoAction.</para>
		/// <para><c>Note</c>  In Windows 7, the ELS services do not expose any actions.</para>
		/// </summary>
		public readonly string?[]? rgActionIds => dwActionsCount == 0 ? null : Array.ConvertAll(prgActionIds.ToArray((int)dwActionsCount), p => (string?)p);

		/// <summary>
		/// <para>The number of available actions for this subrange.</para>
		/// <para><c>Note</c>  In Windows 7, the ELS services do not expose any actions.</para>
		/// </summary>
		public uint dwActionsCount;

		/// <summary>
		/// <para>Action display names for this subrange. These strings can be localized.</para>
		/// <para><c>Note</c>  In Windows 7, the ELS services do not expose any actions.</para>
		/// </summary>
		public ArrayPointer<LPWSTR> prgActionDisplayNames;

		/// <summary>
		/// <para>Action display names for this subrange. These strings can be localized.</para>
		/// <para><c>Note</c>  In Windows 7, the ELS services do not expose any actions.</para>
		/// </summary>
		public readonly string?[]? rgActionDisplayNames => dwActionsCount == 0 ? null : Array.ConvertAll(prgActionDisplayNames.ToArray((int)dwActionsCount), p => (string?)p);
	}

	/// <summary>Contains options used by the MappingGetServices function to enumerate ELS services.</summary>
	/// <remarks>
	/// The <c>Size</c> member is the only required member of this structure. All the other members are optional. The application can set any
	/// of the members that it needs for search criteria.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/ns-elscore-mapping_enum_options typedef struct _MAPPING_ENUM_OPTIONS {
	// size_t Size; LPWSTR pszCategory; LPWSTR pszInputLanguage; LPWSTR pszOutputLanguage; LPWSTR pszInputScript; LPWSTR pszOutputScript;
	// LPWSTR pszInputContentType; LPWSTR pszOutputContentType; GUID *pGuid; unsigned OnlineService : 2; unsigned ServiceType : 2; }
	// MAPPING_ENUM_OPTIONS, *PMAPPING_ENUM_OPTIONS;
	[PInvokeData("elscore.h", MSDNShortId = "NS:elscore._MAPPING_ENUM_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MAPPING_ENUM_OPTIONS
	{
		/// <summary>Size of the structure, used to validate the structure version. This value is required.</summary>
		public SIZE_T Size;

		/// <summary>
		/// Optional. Pointer to a service category, for example, "Language Detection". The application must set this member to <c>NULL</c>
		/// if the service category is not a search criterion.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszCategory;

		/// <summary>
		/// Optional. Pointer to an input language string, following the IETF naming convention, that identifies the input language that
		/// services should accept. The application can set this member to <c>NULL</c> if the supported input language is not a search criterion.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszInputLanguage;

		/// <summary>
		/// Optional. Pointer to an output language string, following the IETF naming convention, that identifies the output language that
		/// services use to retrieve results. The application can set this member to <c>NULL</c> if the output language is not a search criterion.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszOutputLanguage;

		/// <summary>
		/// Optional. Pointer to a standard Unicode script name that can be accepted by services. The application set this member to
		/// <c>NULL</c> if the input script is not a search criterion.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszInputScript;

		/// <summary>
		/// Optional. Pointer to a standard Unicode script name used by services. The application can set this member to <c>NULL</c> if the
		/// output script is not a search criterion.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszOutputScript;

		/// <summary>
		/// <para>
		/// Optional. Pointer to a string, following the format of the MIME content types, that identifies the format that the services
		/// should be able to interpret when the application passes data. Examples of content types are "text/plain", "text/html", and
		/// "text/css". The application can set this member to <c>NULL</c> if the input content type is not a search criterion.
		/// </para>
		/// <para>
		/// <c>Note</c>  In Windows 7, the ELS services support only the content type "text/plain". A content type specification can be found
		/// at Text Media Types.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszInputContentType;

		/// <summary>
		/// Optional. Pointer to a string, following the format of the MIME content types, that identifies the format in which the services
		/// retrieve data. The application can set this member to <c>NULL</c> if the output content type is not a search criterion.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszOutputContentType;

		/// <summary>
		/// Optional. Pointer to a globally unique identifier (GUID) structure for a specific service. The application must set this member
		/// to <c>NULL</c> if the GUID is not a search criterion.
		/// </summary>
		public GuidPtr pGuid;

		private byte flags;

		/// <summary>Reserved for future use. Must be set to 0.</summary>
		public ELS_ONLINE_SVC OnlineService { readonly get => (ELS_ONLINE_SVC)BitHelper.GetBits(flags, 0, 2); set => BitHelper.SetBits(ref flags, 0, 2, (byte)value); }

		/// <summary>Reserved for future use. Must be set to 0.</summary>
		public ELS_SVC_TYPE ServiceType { readonly get => (ELS_SVC_TYPE)BitHelper.GetBits(flags, 2, 2); set => BitHelper.SetBits(ref flags, 2, 2, (byte)value); }
	}

	/// <summary>
	/// Contains options for text recognition. The values stored in this structure affect the behavior and results of <see
	/// cref="MappingRecognizeText(in MAPPING_SERVICE_INFO, string, int, uint, in MAPPING_OPTIONS, ref MAPPING_PROPERTY_BAG)"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The application does not have to fill in all members of this structure, as services treat <c>NULL</c> members as default values. All
	/// unused members must be set to 0.
	/// </para>
	/// <note type="warning">The data passed in this structure to <see cref="MappingRecognizeText(in MAPPING_SERVICE_INFO, string, int, uint,
	/// in MAPPING_OPTIONS, ref MAPPING_PROPERTY_BAG)"/>, as well as data referred to by the pszText argumentin that call, must remain valid
	/// until the property bag structure passed by pBag is freed via <see cref="MappingFreePropertyBag(in MAPPING_PROPERTY_BAG)"/>. This is
	/// because both synchronous and asynchronous calls to <c>MappingRecognizeText</c> and <see cref="MappingDoAction"/> will attempt to use
	/// the data passed to the initial call to <c>MappingRecognizeText</c>.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/ns-elscore-mapping_options typedef struct _MAPPING_OPTIONS { size_t Size;
	// LPWSTR pszInputLanguage; LPWSTR pszOutputLanguage; LPWSTR pszInputScript; LPWSTR pszOutputScript; LPWSTR pszInputContentType; LPWSTR
	// pszOutputContentType; LPWSTR pszUILanguage; PFN_MAPPINGCALLBACKPROC pfnRecognizeCallback; LPVOID pRecognizeCallerData; DWORD
	// dwRecognizeCallerDataSize; PFN_MAPPINGCALLBACKPROC pfnActionCallback; LPVOID pActionCallerData; DWORD dwActionCallerDataSize; DWORD
	// dwServiceFlag; unsigned GetActionDisplayName : 1; } MAPPING_OPTIONS, *PMAPPING_OPTIONS;
	[PInvokeData("elscore.h", MSDNShortId = "NS:elscore._MAPPING_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MAPPING_OPTIONS
	{
		/// <summary>Size of the structure, used to validate the structure version. This value is required.</summary>
		public SIZE_T Size = Marshal.SizeOf(typeof(MAPPING_OPTIONS));

		/// <summary>
		/// Optional. Pointer to an input language string, following the IETF naming convention, that identifies the input language that the
		/// service should be able to accept. The application can set this member to <c>NULL</c> to indicate that the service is free to
		/// interpret the input as any input language it supports.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszInputLanguage;

		/// <summary>
		/// Optional. Pointer to an output language string, following the IETF naming convention, that identifies the output language that
		/// the service should be able to use to produce results. The application can set this member to <c>NULL</c> if the service should
		/// decide the output language.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszOutputLanguage;

		/// <summary>
		/// Optional. Pointer to a standard Unicode script name that should be accepted by the service. The application can set this member
		/// to <c>NULL</c> to let the service decide how handle the input.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszInputScript;

		/// <summary>
		/// Optional. Pointer to a standard Unicode script name that the service should use to retrieve results. The application can set this
		/// member to <c>NULL</c> to let the service decide the output script.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszOutputScript;

		/// <summary>
		/// <para>
		/// Optional. Pointer to a string, following the format of the MIME content types, that identifies the format that the service should
		/// be able to interpret when the application passes data. Examples of content types are "text/plain", "text/html", and "text/css".
		/// The application can set this member to <c>NULL</c> to indicate the "text/plain" content type.
		/// </para>
		/// <para>
		/// <c>Note</c>  In Windows 7, the ELS services support only the content type "text/plain". A content type specification can be found
		/// at Text Media Types.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszInputContentType;

		/// <summary>
		/// Optional. Pointer to a string, following the format of the MIME content types, that identifies the format in which the service
		/// should retrieve data. The application can set this member to <c>NULL</c> to let the service decide the output content type.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszOutputContentType;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszUILanguage;

		/// <summary>
		/// Optional. Pointer to an application callback function to receive callbacks with the results from the MappingRecognizeText
		/// function. If a callback function is specified, text recognition is executed in asynchronous mode and the application obtains
		/// results through the callback function. The application must set this member to <c>NULL</c> if text recognition is to be synchronous.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_MAPPINGCALLBACKPROC? pfnRecognizeCallback;

		/// <summary>
		/// Optional. Pointer to private application data passed to the callback function by a service after text recognition is complete.
		/// The application must set this member to <c>NULL</c> to indicate no private application data.
		/// </summary>
		public IntPtr pRecognizeCallerData;

		/// <summary>Optional. Size, in bytes, of any private application data indicated by the <c>pRecognizeCallerData</c> member.</summary>
		public uint dwRecognizeCallerDataSize;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_MAPPINGCALLBACKPROC? pfnActionCallback;

		/// <summary>Reserved.</summary>
		public IntPtr pActionCallerData;

		/// <summary>Reserved.</summary>
		public uint dwActionCallerDataSize;

		/// <summary>
		/// <para>
		/// Optional. Private flag that a service provider defines to affect service behavior. Services can interpret this flag as they require.
		/// </para>
		/// <para><c>Note</c>  For Windows 7, none of the available ELS services support flags.</para>
		/// <para></para>
		/// </summary>
		public uint dwServiceFlag;

		/// <summary>Reserved.</summary>
		public byte GetActionDisplayName;

		/// <summary>Initializes a new instance of the <see cref="MAPPING_OPTIONS"/> struct.</summary>
		public MAPPING_OPTIONS()
		{ }

		/// <summary>Initializes a new instance of the <see cref="MAPPING_OPTIONS"/> struct.</summary>
		/// <param name="recognizeCallback">
		/// An application callback function to receive callbacks with the results from the MappingRecognizeText function.
		/// </param>
		/// <param name="callbackData">
		/// Optional. Pointer to private application data passed to the callback function by a service after text recognition is complete.
		/// </param>
		public MAPPING_OPTIONS(PFN_MAPPINGCALLBACKPROC? recognizeCallback, SafeAllocatedMemoryHandle? callbackData) :
			this(recognizeCallback, callbackData?.DangerousGetHandle() ?? default, callbackData?.Size ?? 0)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="MAPPING_OPTIONS"/> struct.</summary>
		/// <param name="recognizeCallback">
		/// An application callback function to receive callbacks with the results from the MappingRecognizeText function.
		/// </param>
		/// <param name="callbackData">
		/// Optional. Pointer to private application data passed to the callback function by a service after text recognition is complete.
		/// </param>
		/// <param name="dataSize">Size of the data pointed to by <paramref name="callbackData"/>.</param>
		public MAPPING_OPTIONS(PFN_MAPPINGCALLBACKPROC? recognizeCallback, IntPtr callbackData = default, int dataSize = default) : this()
		{
			pfnRecognizeCallback = recognizeCallback;
			pRecognizeCallerData = callbackData;
			dwRecognizeCallerDataSize = (uint)dataSize;
		}
	}

	/// <summary>Contains the text recognition data properties retrieved by MappingRecognizeText.</summary>
	/// <remarks>
	/// The memory for the property bag structure itself is managed by the application. The ELS platform and its services only manage the
	/// data pointers that they store in the property bag.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/ns-elscore-mapping_property_bag typedef struct _MAPPING_PROPERTY_BAG {
	// size_t Size; PMAPPING_DATA_RANGE prgResultRanges; DWORD dwRangesCount; LPVOID pServiceData; DWORD dwServiceDataSize; LPVOID
	// pCallerData; DWORD dwCallerDataSize; LPVOID pContext; } MAPPING_PROPERTY_BAG, *PMAPPING_PROPERTY_BAG;
	[PInvokeData("elscore.h", MSDNShortId = "NS:elscore._MAPPING_PROPERTY_BAG")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MAPPING_PROPERTY_BAG
	{
		/// <summary>Size of the structure, used to verify the structure version. This value is required.</summary>
		public SIZE_T Size = Marshal.SizeOf(typeof(MAPPING_PROPERTY_BAG));

		/// <summary>
		/// Pointer to an array of MAPPING_DATA_RANGE structures containing all recognized text range results. This member is populated by MappingRecognizeText.
		/// </summary>
		public IntPtr prgResultRanges;

		/// <summary>
		/// The array of MAPPING_DATA_RANGE structures containing all recognized text range results. This member is populated by MappingRecognizeText.
		/// </summary>
		public readonly MAPPING_DATA_RANGE[]? rgResultRanges => prgResultRanges.ToArray<MAPPING_DATA_RANGE>((int)dwRangesCount);

		/// <summary>Number of items in the array indicated by <c>prgResultRanges</c>. This member is populated by MappingRecognizeText.</summary>
		public uint dwRangesCount;

		/// <summary>
		/// Pointer to private service data. The service can document the format of this data so that the application can use it. The service
		/// also manages the memory for this data. This member is populated by MappingRecognizeText.
		/// </summary>
		public IntPtr pServiceData;

		/// <summary>
		/// Size, in bytes, of the private service data specified by <c>pServiceData</c>. The size is set to 0 if there is no private data.
		/// This member is populated by MappingRecognizeText.
		/// </summary>
		public uint dwServiceDataSize;

		/// <summary>Pointer to private application data to pass to the service. The application manages the memory for this data.</summary>
		public IntPtr pCallerData;

		/// <summary>
		/// Size, in bytes, of the private application data indicated in <c>pCallerData</c>. This member is set to 0 if there is no private data.
		/// </summary>
		public uint dwCallerDataSize;

		/// <summary>Reserved for internal use.</summary>
		public IntPtr pContext;

		/// <summary>Initializes a new instance of the <see cref="MAPPING_PROPERTY_BAG"/> struct.</summary>
		public MAPPING_PROPERTY_BAG()
		{ }
	}

	/// <summary>Contains information about an ELS service.</summary>
	/// <remarks>Structures of this type are created in an application call to MappingGetServices.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/elscore/ns-elscore-mapping_service_info typedef struct _MAPPING_SERVICE_INFO {
	// size_t Size; LPWSTR pszCopyright; WORD wMajorVersion; WORD wMinorVersion; WORD wBuildVersion; WORD wStepVersion; DWORD
	// dwInputContentTypesCount; LPWSTR *prgInputContentTypes; DWORD dwOutputContentTypesCount; LPWSTR *prgOutputContentTypes; DWORD
	// dwInputLanguagesCount; LPWSTR *prgInputLanguages; DWORD dwOutputLanguagesCount; LPWSTR *prgOutputLanguages; DWORD dwInputScriptsCount;
	// LPWSTR *prgInputScripts; DWORD dwOutputScriptsCount; LPWSTR *prgOutputScripts; GUID guid; LPWSTR pszCategory; LPWSTR pszDescription;
	// DWORD dwPrivateDataSize; LPVOID pPrivateData; LPVOID pContext; unsigned IsOneToOneLanguageMapping : 1; unsigned HasSubservices : 1;
	// unsigned OnlineOnly : 1; unsigned ServiceType : 2; } MAPPING_SERVICE_INFO, *PMAPPING_SERVICE_INFO;
	[PInvokeData("elscore.h", MSDNShortId = "NS:elscore._MAPPING_SERVICE_INFO")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MAPPING_SERVICE_INFO
	{
		/// <summary>Size of the structure, used to validate the structure version. This value is required.</summary>
		public SIZE_T Size;

		/// <summary>Pointer to copyright information about the service.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszCopyright;

		/// <summary>Major version number that is used to track changes to the service.</summary>
		public ushort wMajorVersion;

		/// <summary>Minor version number that is used to track changes to the service.</summary>
		public ushort wMinorVersion;

		/// <summary>Build version that is used to track changes to the service.</summary>
		public ushort wBuildVersion;

		/// <summary>Step version that is used to track changes to the service.</summary>
		public ushort wStepVersion;

		/// <summary>Number of content types that the service can receive.</summary>
		public uint dwInputContentTypesCount;

		/// <summary>
		/// <para>
		/// Optional. Pointer to an array of input content types, following the format of the MIME content types, that identify the format
		/// that the service interprets when the application passes data. Examples of content types are "text/plain", "text/html" and "text/css".
		/// </para>
		/// <para>
		/// <c>Note</c>  In Windows 7, the ELS services support only the content type "text/plain". A content types specification can be
		/// found at Text Media Types.
		/// </para>
		/// </summary>
		public ArrayPointer<LPWSTR> prgInputContentTypes;

		/// <summary>
		/// <para>
		/// Optional. The array of input content types, following the format of the MIME content types, that identify the format that the
		/// service interprets when the application passes data. Examples of content types are "text/plain", "text/html" and "text/css".
		/// </para>
		/// <para>
		/// <c>Note</c>  In Windows 7, the ELS services support only the content type "text/plain". A content types specification can be
		/// found at Text Media Types.
		/// </para>
		/// </summary>
		public readonly string?[]? rgInputContentTypes => dwInputContentTypesCount == 0 ? null : Array.ConvertAll(prgInputContentTypes.ToArray((int)dwInputContentTypesCount), p => (string?)p);

		/// <summary>Number of content types in which the service can format results.</summary>
		public uint dwOutputContentTypesCount;

		/// <summary>
		/// Optional. Pointer to an array of output content types, following the format of the MIME content types, that identify the format
		/// in which the service retrieves data.
		/// </summary>
		public ArrayPointer<LPWSTR> prgOutputContentTypes;

		/// <summary>
		/// Optional. The array of output content types, following the format of the MIME content types, that identify the format in which
		/// the service retrieves data.
		/// </summary>
		public readonly string?[]? rgOutputContentTypes => dwOutputContentTypesCount == 0 ? null : Array.ConvertAll(prgOutputContentTypes.ToArray((int)dwOutputContentTypesCount), p => (string?)p);

		/// <summary>
		/// Number of input languages supported by the service. This member is set to 0 if the service can accept data in any language.
		/// </summary>
		public uint dwInputLanguagesCount;

		/// <summary>
		/// Pointer to an array of the input languages, following the IETF naming convention, that the service accepts. This member is set to
		/// <c>NULL</c> if the service can work with any input language.
		/// </summary>
		public ArrayPointer<LPWSTR> prgInputLanguages;

		/// <summary>
		/// The array of the input languages, following the IETF naming convention, that the service accepts. This member is set to
		/// <c>NULL</c> if the service can work with any input language.
		/// </summary>
		public readonly string?[]? rgInputLanguages => dwInputLanguagesCount == 0 ? null : Array.ConvertAll(prgInputLanguages.ToArray((int)dwInputLanguagesCount), p => (string?)p);

		/// <summary>
		/// Number of output languages supported by the service. This member is set to 0 if the service can retrieve data in any language, or
		/// if the service ignores the output language.
		/// </summary>
		public uint dwOutputLanguagesCount;

		/// <summary>
		/// Pointer to an array of output languages, following the IETF naming convention, in which the service can retrieve results. This
		/// member is set to <c>NULL</c> if the service can retrieve results in any language, or if the service ignores the output language.
		/// </summary>
		public ArrayPointer<LPWSTR> prgOutputLanguages;

		/// <summary>
		/// The array of output languages, following the IETF naming convention, in which the service can retrieve results. This member is
		/// set to <c>NULL</c> if the service can retrieve results in any language, or if the service ignores the output language.
		/// </summary>
		public readonly string?[]? rgOutputLanguages => dwOutputLanguagesCount == 0 ? null : Array.ConvertAll(prgOutputLanguages.ToArray((int)dwOutputLanguagesCount), p => (string?)p);

		/// <summary>Number of input scripts supported by the service. This member is set to 0 if the service can accept data in any script.</summary>
		public uint dwInputScriptsCount;

		/// <summary>
		/// Pointer to an array of input scripts, with Unicode standard script names, that are supported by the service. This member is set
		/// to <c>NULL</c> if the service can work with any scripts, or if the service ignores the input scripts.
		/// </summary>
		public ArrayPointer<LPWSTR> prgInputScripts;

		/// <summary>
		/// The array of input scripts, with Unicode standard script names, that are supported by the service. This member is set to
		/// <c>NULL</c> if the service can work with any scripts, or if the service ignores the input scripts.
		/// </summary>
		public readonly string?[]? rgInputScripts => dwInputScriptsCount == 0 ? null : Array.ConvertAll(prgInputScripts.ToArray((int)dwInputScriptsCount), p => (string?)p);

		/// <summary>
		/// Number of output scripts supported by the service. This member is set to 0 if the service can retrieve data in any script, or if
		/// the service ignores the output scripts.
		/// </summary>
		public uint dwOutputScriptsCount;

		/// <summary>
		/// Pointer to an array of output scripts supported by the service. This member is set to <c>NULL</c> if the service can work with
		/// any scripts, or the service ignores the output scripts.
		/// </summary>
		public ArrayPointer<LPWSTR> prgOutputScripts;

		/// <summary>
		/// The array of output scripts supported by the service. This member is set to <c>NULL</c> if the service can work with any scripts,
		/// or the service ignores the output scripts.
		/// </summary>
		public readonly string?[]? rgOutputScripts => dwOutputScriptsCount == 0 ? null : Array.ConvertAll(prgOutputScripts.ToArray((int)dwOutputScriptsCount), p => (string?)p);

		/// <summary>Globally unique identifier (GUID) for the service.</summary>
		public Guid guid;

		/// <summary>Pointer to the service category for the service, for example, "Language Detection".</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszCategory;

		/// <summary>Pointer to the service description. This text can be localized.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszDescription;

		/// <summary>Size, in bytes, of the private data for the service. This member is set to 0 if there is no private data.</summary>
		public uint dwPrivateDataSize;

		/// <summary>
		/// Pointer to private data that the service can expose. This information is static and updated during installation of the service.
		/// </summary>
		public IntPtr pPrivateData;

		/// <summary>Reserved for internal use.</summary>
		public IntPtr pContext;

		private byte flags;

		/// <summary>
		/// <para>
		/// Flag indicating the language mapping between input language and output language that is supported by the service. Possible values
		/// are shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>
		/// The input and output languages are not paired and the service can receive data in any of the input languages and render data in
		/// any of the output languages.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>
		/// The arrays of the input and output languages for the service are paired. In other words, given a particular input language, the
		/// service retrieves results in the paired language defined in the output language array. Use of the language pairing can be useful,
		/// for example, in bilingual dictionary scenarios.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public bool IsOneToOneLanguageMapping { readonly get => BitHelper.GetBit(flags, 0); set => BitHelper.SetBit(ref flags, 0, value); }

		/// <summary>
		/// <para>
		/// Flag indicating if the service has subservices, that is, other services that plug into the service. This flag is used in service
		/// enumeration to determine if the parent service must be called to get a list of subservices. Possible values are shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>The service is a regular service that stands alone and has no subservices.</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>The service acts as a parent for subservices.</description>
		/// </item>
		/// </list>
		/// </summary>
		public bool HasSubservices { readonly get => BitHelper.GetBit(flags, 1); set => BitHelper.SetBit(ref flags, 1, value); }

		/// <summary>Reserved for future use.</summary>
		public bool OnlineOnly { readonly get => BitHelper.GetBit(flags, 2); set => BitHelper.SetBit(ref flags, 2, value); }

		/// <summary>Reserved for future use.</summary>
		public byte ServiceType { readonly get => BitHelper.GetBits(flags, 3, 2); set => BitHelper.SetBits(ref flags, 3, 2, value); }
	}

	/// <summary>
	/// Managed pointer to an array of <see cref="MAPPING_SERVICE_INFO"/> structures. This value is returned by <see
	/// cref="MappingGetServices(in MAPPING_ENUM_OPTIONS, out SafeMAPPING_SERVICE_INFOArray)"/>. It is disposed by calling <see cref="MappingFreeServices(IntPtr)"/>.
	/// </summary>
	/// <seealso cref="IReadOnlyList{T}"/>
	public class SafeMAPPING_SERVICE_INFOArray : SafeHANDLE, IReadOnlyList<MAPPING_SERVICE_INFO>
	{
		private static readonly SIZE_T elemSize = Marshal.SizeOf(typeof(MAPPING_SERVICE_INFO));

		internal SafeMAPPING_SERVICE_INFOArray(IntPtr ptr, int count) : base(IntPtr.Zero, true)
		{
			SetHandle(ptr);
			Count = count;
		}

		/// <inheritdoc/>
		public int Count { get; private set; }

		/// <inheritdoc/>
		public override bool IsInvalid => handle == IntPtr.Zero;

		/// <inheritdoc/>
		public MAPPING_SERVICE_INFO this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException(nameof(index));
				return IsClosed || IsInvalid
					? throw new InvalidOperationException("Invalid memory pointer.")
					: handle.Offset(elemSize * index).ToStructure<MAPPING_SERVICE_INFO>();
			}
		}

		/// <inheritdoc/>
		public IEnumerator<MAPPING_SERVICE_INFO> GetEnumerator() => new NativeMemoryEnumerator<MAPPING_SERVICE_INFO>(handle, Count);

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => MappingFreeServices(handle).Succeeded;
	}
}