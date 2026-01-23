using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

/// <summary>Functions and structures from prntvpt.h.</summary>
public static partial class PrntvPt
{
	/// <summary>
	/// Enables users to specify which DEVMODE to use as the source of default values when a print ticket does not specify all possible settings.
	/// </summary>
	/// <remarks>If user defaults are not available when using kUserDefaultDevmode, queue defaults will be used.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/ne-prntvpt-edefaultdevmodetype typedef enum tagEDefaultDevmodeType {
	// kUserDefaultDevmode, kPrinterDefaultDevmode } EDefaultDevmodeType;
	[PInvokeData("prntvpt.h", MSDNShortId = "f3144ff6-1228-4e17-b118-fe70136edeea")]
	public enum EDefaultDevmodeType
	{
		/// <summary>The user's default preferences.</summary>
		kUserDefaultDevmode,

		/// <summary>The print queue's default preferences.</summary>
		kPrinterDefaultDevmode,
	}

	/// <summary>Specifies the scope of a print ticket.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/ne-prntvpt-eprintticketscope typedef enum { kPTPageScope,
	// kPTDocumentScope, kPTJobScope } ;
	[PInvokeData("prntvpt.h", MSDNShortId = "7a817f43-c8da-4df1-91c8-6bb1c93c3abc")]
	public enum EPrintTicketScope
	{
		/// <summary>The print ticket applies only to a single page.</summary>
		kPTPageScope,

		/// <summary>The print ticket applies to the whole document.</summary>
		kPTDocumentScope,

		/// <summary>The print ticket applies to all documents in the print job.</summary>
		kPTJobScope,
	}

	/// <summary>
	/// <para>
	/// [This function is not supported and might be disabled or deleted in future versions of Windows. <c>PTOpenProviderEx</c> provides
	/// equivalent functionality and should be used instead.]
	/// </para>
	/// <para>Opens an instance of a print ticket provider.</para>
	/// </summary>
	/// <param name="pszPrinterName">The full name of a print queue.</param>
	/// <param name="maxVersion">The latest version of the Print Schema that the caller supports.</param>
	/// <param name="prefVersion">The version of the Print Schema requested by the caller.</param>
	/// <param name="phProvider">A pointer to a handle to the print ticket provider.</param>
	/// <param name="usedVersion">The version of the Print Schema that the print ticket provider will use.</param>
	/// <returns>
	/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
	/// COM error codes, see Error Handling.
	/// </returns>
	/// <remarks>Before calling this function, the calling thread must initialize COM by calling <c>CoInitializeEx</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/bindptproviderthunk HRESULT BindPTProviderThunk( _In_ StrPtrAuto
	// pszPrinterName, _In_ INT maxVersion, _In_ INT prefVersion, _Out_ HPTPROVIDER *phProvider, _Out_ INT *usedVersion );
	[DllImport(Lib.PrntvPt, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("prntvpt.h", MSDNShortId = "815cc360-8dcd-4c58-a64d-5d77436a8623")]
	public static extern HRESULT BindPTProviderThunk(string pszPrinterName, int maxVersion, int prefVersion, out SafeHPTPROVIDER phProvider, out int usedVersion);

	/// <summary>
	/// <para>
	/// [This function is not supported and might be disabled or deleted in future versions of Windows.
	/// <c>PTConvertDevModeToPrintTicket</c> provides equivalent functionality and should be used instead.]
	/// </para>
	/// <para>Converts a <c>DEVMODE</c> structure to a print ticket.</para>
	/// </summary>
	/// <param name="hProvider">
	/// A handle to an open print ticket provider. This handle is returned by the <c>BindPTProviderThunk</c> function.
	/// </param>
	/// <param name="pDevmode">A pointer to the <c>DEVMODE</c> to convert.</param>
	/// <param name="cbSize">The size, in bytes, of the <c>DEVMODE</c> passed in pDevmode.</param>
	/// <param name="scope">
	/// A value that specifies the scope of ppPrintTicket. This value can specify a single page, an entire document, or all documents in
	/// the print job. The value of this parameter must be a member of the <c>EPrintTicketScope</c> enumeration, cast as a <c>DWORD</c>.
	/// </param>
	/// <param name="ppPrintTicket">
	/// The address of the buffer that contains a print ticket that represents the <c>DEVMODE</c> passed in pDevmode. This function
	/// calls <c>CoTaskMemAlloc</c> to allocate this buffer. When the buffer is no longer needed, the caller must free it by calling <c>CoTaskMemFree</c>.
	/// </param>
	/// <param name="pcbPrintTicketLength">The size, in bytes, of the print ticket returned in ppPrintTicket.</param>
	/// <returns>
	/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
	/// COM error codes, see Error Handling.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/convertdevmodetoprintticketthunk2 HRESULT
	// ConvertDevModeToPrintTicketThunk2( _In_ HPTPROVIDER hProvider, _In_ BYTE *pDevmode, _In_ ULONG cbSize, _In_ DWORD scope, _Out_
	// BYTE **ppPrintTicket, _Out_ INT *pcbPrintTicketLength );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "c03371f8-a978-4fb7-82cc-f76a65f3904c")]
	public static extern HRESULT ConvertDevModeToPrintTicketThunk2(HPTPROVIDER hProvider, in DEVMODE pDevmode, uint cbSize,
		EPrintTicketScope scope, out SafeCoTaskMemHandle ppPrintTicket, out int pcbPrintTicketLength);

	/// <summary>
	/// <para>
	/// [This function is not supported and might be disabled or deleted in future versions of Windows.
	/// <c>PTConvertPrintTicketToDevMode</c> provides equivalent functionality and should be used instead.]
	/// </para>
	/// <para>Converts a print ticket to a <c>DEVMODE</c> structure.</para>
	/// </summary>
	/// <param name="hProvider">
	/// A handle to an open print ticket provider. This handle is returned by the <c>BindPTProviderThunk</c> function.
	/// </param>
	/// <param name="pPrintTicket">The buffer that contains the print ticket to convert.</param>
	/// <param name="cbSize">The size, in bytes, of the buffer passed in pPrintTicket.</param>
	/// <param name="baseType">
	/// A value indicating whether the user's default <c>DEVMODE</c> or the print queue's default <c>DEVMODE</c> is used to provide
	/// values to the output <c>DEVMODE</c> when pPrintTicket does not specify every possible setting for a <c>DEVMODE</c>. The value of
	/// this parameter must be a member of the <c>EDefaultDevmodeType</c> enumeration, cast as an <c>INT</c>.
	/// </param>
	/// <param name="scope">
	/// A value that specifies the scope of pPrintTicket. This value can specify a single page, an entire document, or all documents in
	/// the print job. The value of this parameter must be a member of the <c>EPrintTicketScope</c> enumeration, cast as a <c>DWORD</c>.
	/// </param>
	/// <param name="ppDevmode">
	/// The address of the newly created <c>DEVMODE</c>. This function calls <c>CoTaskMemAlloc</c> to allocate this buffer. When the
	/// buffer is no longer needed, the caller must free it by calling <c>CoTaskMemFree</c>.
	/// </param>
	/// <param name="pcbDevModeLength">The size, in bytes, of the <c>DEVMODE</c> returned in ppDevmode.</param>
	/// <param name="errMsg">
	/// A pointer to a string that specifies what, if anything, is invalid about the print ticket in pPrintTicket. If it is valid, this
	/// is <c>NULL</c>. If errMsg is not <c>NULL</c> when the function returns, the caller must free the string with <c>SysFreeString</c>.
	/// </param>
	/// <returns>
	/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
	/// COM error codes, see Error Handling.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/convertprinttickettodevmodethunk2 HRESULT
	// ConvertPrintTicketToDevModeThunk2( _In_ HPTPROVIDER hProvider, _In_ BYTE *pPrintTicket, _In_ ULONG cbSize, _In_ INT baseType,
	// _In_ DWORD scope, _Out_ BYTE **ppDevmode, _Out_ ULONG *pcbDevModeLength, _Out_opt_ BSTR *errMsg );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "3b0a6afd-fa9d-434e-a95f-b051296d4567")]
	public static extern HRESULT ConvertPrintTicketToDevModeThunk2(HPTPROVIDER hProvider, [In] IntPtr pPrintTicket, uint cbSize,
		EDefaultDevmodeType baseType, EPrintTicketScope scope, out SafeCoTaskMemHandle ppDevmode, out uint pcbDevModeLength,
		[MarshalAs(UnmanagedType.BStr)] out string? errMsg);

	/// <summary>
	/// <para>
	/// [This function is not supported and might be disabled or deleted in future versions of Windows. <c>PTGetPrintCapabilities</c>
	/// provides equivalent functionality and should be used instead.]
	/// </para>
	/// <para>Retrieves the printer's capabilities formatted in compliance with the XML Print Schema.</para>
	/// </summary>
	/// <param name="hProvider">
	/// A handle to an open print ticket provider. This handle is returned by the <c>BindPTProviderThunk</c> function.
	/// </param>
	/// <param name="pPrintTicket">The buffer that contains the print ticket data, expressed in XML as described in the Print Schema.</param>
	/// <param name="cbPrintTicket">The size, in bytes, of the buffer referenced by pPrintTicket.</param>
	/// <param name="ppbPrintCapabilities">
	/// The address of the buffer that is allocated by this function and contains the valid print capabilities information, encoded as
	/// XML. This function calls <c>CoTaskMemAlloc</c> to allocate this buffer. When the buffer is no longer needed, the caller must
	/// free it by calling <c>CoTaskMemFree</c>.
	/// </param>
	/// <param name="pcbPrintCapabilitiesLength">The size, in bytes, of the buffer referenced by ppbPrintCapabilities.</param>
	/// <param name="pbstrErrorMessage">
	/// A pointer to a string that specifies what, if anything, is invalid about pPrintTicket. If it is valid, this value is
	/// <c>NULL</c>. If pbstrErrorMessage is not <c>NULL</c> when the function returns, the caller must free the string with <c>SysFreeString</c>.
	/// </param>
	/// <returns>
	/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
	/// COM error codes, see Error Handling.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprintcapabilitiesthunk2 HRESULT GetPrintCapabilitiesThunk2( _In_
	// HPTPROVIDER hProvider, _In_ BYTE *pPrintTicket, _In_ INT cbPrintTicket, _Out_ BYTE **ppbPrintCapabilities, _Out_ INT
	// *pcbPrintCapabilitiesLength, _Out_opt_ BSTR *pbstrErrorMessage );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "15219c19-b64c-4c51-9357-15a797557693")]
	public static extern HRESULT GetPrintCapabilitiesThunk2(HPTPROVIDER hProvider, [In] IntPtr pPrintTicket, int cbPrintTicket, out IntPtr ppbPrintCapabilities,
		out int pcbPrintCapabilitiesLength, [MarshalAs(UnmanagedType.BStr)] out string? pbstrErrorMessage);

	/// <summary>
	/// <para>
	/// [This function is not supported and might be disabled or deleted in future versions of Windows.
	/// <c>PTMergeAndValidatePrintTicket</c> provides equivalent functionality and should be used instead.]
	/// </para>
	/// <para>Merges two print tickets and returns a valid, viable print ticket.</para>
	/// </summary>
	/// <param name="hProvider">
	/// A handle to an open print ticket provider. This handle is returned by the <c>BindPTProviderThunk</c> function.
	/// </param>
	/// <param name="pBasePrintTicket">
	/// The buffer that contains the base print ticket data, expressed in XML as described in the Print Schema.
	/// </param>
	/// <param name="basePrintTicketLength">The size, in bytes, of the buffer referenced by pBasePrintTicket.</param>
	/// <param name="pDeltaPrintTicket">
	/// The buffer that contains the print ticket to merge. The print ticket data is expressed in XML as described in the Print Schema.
	/// The value of this parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="deltaPrintTicketLength">The size, in bytes, of the buffer referenced by pDeltaPrintTicket.</param>
	/// <param name="scope">
	/// The value that specifies whether the scope of pDeltaPrintTicket and ppValidatedPrintTicket is a single page, an entire document,
	/// or all documents in the print job. The value of this parameter must be a member of the <c>EPrintTicketScope</c> enumeration,
	/// cast as a <c>DWORD</c>.
	/// </param>
	/// <param name="ppValidatedPrintTicket">
	/// The address of the buffer that contains the merged and validated print ticket. This function calls <c>CoTaskMemAlloc</c> to
	/// allocate this buffer. When the buffer is no longer needed, the caller must free it by calling <c>CoTaskMemFree</c>.
	/// </param>
	/// <param name="pValidatedPrintTicketLength">The size, in bytes, of the buffer referenced by ppValidatedPrintTicket.</param>
	/// <param name="pbstrErrorMessage">
	/// A pointer to a string that specifies what, if anything, is invalid about the print ticket in pBasePrintTicket or
	/// pDeltaPrintTicket. If they are both valid, this value is <c>NULL</c>. If pbstrErrorMessage is not <c>NULL</c> when the function
	/// returns, the caller must free the string with <c>SysFreeString</c>.
	/// </param>
	/// <returns>
	/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
	/// COM error codes, see Error Handling.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/mergeandvalidateprintticketthunk2 HRESULT
	// MergeAndValidatePrintTicketThunk2( _In_ HPTPROVIDER hProvider, _In_ BYTE *pBasePrintTicket, _In_ INT basePrintTicketLength,
	// _In_opt_ BYTE *pDeltaPrintTicket, _In_ INT deltaPrintTicketLength, _In_ DWORD scope, _Out_ BYTE **ppValidatedPrintTicket, _Out_
	// INT *pValidatedPrintTicketLength, _Out_opt_ BSTR *pbstrErrorMessage );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "4aa7b9de-abf2-4781-942e-0b992a6bffed")]
	public static extern HRESULT MergeAndValidatePrintTicketThunk2(HPTPROVIDER hProvider, [In] IntPtr pBasePrintTicket, int basePrintTicketLength,
		[In, Optional] IntPtr pDeltaPrintTicket, int deltaPrintTicketLength, EPrintTicketScope scope, out SafeCoTaskMemHandle ppValidatedPrintTicket,
		out int pValidatedPrintTicketLength, [MarshalAs(UnmanagedType.BStr)] out string? pbstrErrorMessage);

	/// <summary>Closes a print ticket provider handle.</summary>
	/// <param name="hProvider">A handle to the provider. This handle is returned by the PTOpenProvider or PTOpenProviderEx function.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> contains an error code.</para>
	/// <para>If hProvider was opened in a different thread, the <c>HRESULT</c> is E_INVALIDARG.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// The hProvider parameter must be a handle that was opened in the same thread as the thread in which it is used for this function.
	/// </para>
	/// <para>A handle cannot be used after it is closed.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptcloseprovider HRESULT PTCloseProvider( HPTPROVIDER
	// hProvider );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "28e85b53-fd0c-4210-ae2b-794efaf65bd4")]
	public static extern HRESULT PTCloseProvider(HPTPROVIDER hProvider);

	/// <summary>Converts a DEVMODE structure to a print ticket inside an IStream.</summary>
	/// <param name="hProvider">
	/// A handle to an open print ticket provider. This handle is returned by the PTOpenProvider or the PTOpenProviderEx function.
	/// </param>
	/// <param name="cbDevmode">The size of the DEVMODE in bytes.</param>
	/// <param name="pDevmode">A pointer to the DEVMODE.</param>
	/// <param name="scope">
	/// A value that specifies the scope of pPrintTicket. This value can specify a single page, an entire document, or all documents in
	/// the print job. Settings in pDevmode that are outside the specified scope will not be included in pPrintTicket. See Remarks.
	/// </param>
	/// <param name="pPrintTicket">A pointer to an IStream with its seek position at the beginning of the print ticket.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> contains an error code.</para>
	/// <para>If hProvider was opened in a different thread, the <c>HRESULT</c> is E_INVALIDARG.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>hProvider must be a handle that was opened in the same thread as the thread in which it is used for this function.</para>
	/// <para>If the pDevmode points to a different printer, its settings may be lost and replaced with defaults.</para>
	/// <para>
	/// Settings in pDevmode that are outside the scope are not included in pPrintTicket. For example, if the scope is a single page,
	/// then job-wide settings and document-wide settings are not included. A job scope includes document scope and page scope. A
	/// document scope includes page scope.
	/// </para>
	/// <para>
	/// <c>PTConvertDevModeToPrintTicket</c> writes the print ticket to the IStream referenced by pPrintTicket starting at the stream's
	/// current seek point. After <c>PTConvertDevModeToPrintTicket</c> returns, the caller must reset the seek point to the initial seek
	/// point to read the print ticket returned by the function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptconvertdevmodetoprintticket HRESULT
	// PTConvertDevModeToPrintTicket( HPTPROVIDER hProvider, ULONG cbDevmode, PDEVMODE pDevmode, EPrintTicketScope scope, IStream
	// *pPrintTicket );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "22ebb9e7-10c6-4512-b749-d61f74bc82ed")]
	public static extern HRESULT PTConvertDevModeToPrintTicket(HPTPROVIDER hProvider, uint cbDevmode, in DEVMODE pDevmode, EPrintTicketScope scope, IStream pPrintTicket);

	/// <summary>Converts a print ticket into a DEVMODE structure.</summary>
	/// <param name="hProvider">
	/// A handle to an opened print ticket provider. This handle is returned by the PTOpenProvider or the PTOpenProviderEx function.
	/// </param>
	/// <param name="pPrintTicket">A pointer to an IStream with its seek position at the beginning of the print ticket.</param>
	/// <param name="baseDevmodeType">
	/// A value indicating whether the user's default DEVMODE or the print queue's default <c>DEVMODE</c> is used to provide values to
	/// the output <c>DEVMODE</c> when pPrintTicket does not specify every possible setting for a <c>DEVMODE</c>.
	/// </param>
	/// <param name="scope">
	/// A value that specifies the scope of pPrintTicket. This value can specify a single page, an entire document, or all documents in
	/// the print job. Settings in pPrintTicket that are outside of the specified scope are ignored. See Remarks.
	/// </param>
	/// <param name="pcbDevmode">A pointer to the size of the DEVMODE in bytes.</param>
	/// <param name="ppDevmode">A pointer to the newly created DEVMODE.</param>
	/// <param name="pbstrErrorMessage">
	/// A pointer to a string that specifies what, if anything, is invalid about pPrintTicket. If it is valid, this is <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK.</para>
	/// <para>If hProvider was opened in a different thread, the <c>HRESULT</c> is E_INVALIDARG.</para>
	/// <para>If pPrintTicket is invalid, the <c>HRESULT</c> is E_PRINTTICKET_FORMAT.</para>
	/// <para>
	/// Otherwise, some other error code is returned in the <c>HRESULT</c>. For more information about COM error codes, see Error Handling.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// The hProvider parameter must be a handle that was opened in the same thread as the thread in which it is used for this function.
	/// </para>
	/// <para>
	/// If baseDevmodeType is kUserDefaultDevmode, but the user's default is not available, then the device's default will be used.
	/// </para>
	/// <para>
	/// The returned DEVMODE may be internally inconsistent or conflict with hard printer settings even though each setting within it is
	/// viable individually. For example, if the printer supports an optional duplexer but the pPrintTicket calls for duplexing, then
	/// the returned <c>DEVMODE</c> will also call for duplexing, even if the duplexer is not installed. Use DocumentProperties to
	/// correct the returned <c>DEVMODE</c>.
	/// </para>
	/// <para>The buffer in the returned ppDevmode should be released with PTReleaseMemory.</para>
	/// <para>
	/// Values of pPrintTicket that are outside of the scope are ignored. For example, if the scope is only a single page, then job-wide
	/// settings and document-wide settings are ignored. Job scope includes document scope and page scope. Document scope includes page scope.
	/// </para>
	/// <para>If pbstrErrorMessage is not <c>NULL</c> when the function returns, the caller must free the string with SysFreeString.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptconvertprinttickettodevmode HRESULT
	// PTConvertPrintTicketToDevMode( HPTPROVIDER hProvider, IStream *pPrintTicket, EDefaultDevmodeType baseDevmodeType,
	// EPrintTicketScope scope, ULONG *pcbDevmode, OUT PDEVMODE *ppDevmode, BSTR *pbstrErrorMessage );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "5eec91b9-d554-4440-bc9e-6a26af34994b")]
	public static extern HRESULT PTConvertPrintTicketToDevMode(HPTPROVIDER hProvider, IStream pPrintTicket, EDefaultDevmodeType baseDevmodeType,
		EPrintTicketScope scope, out uint pcbDevmode, out SafePTMemory ppDevmode, [MarshalAs(UnmanagedType.BStr)] out string? pbstrErrorMessage);

	/// <summary>Retrieves the printer's capabilities formatted in compliance with the XML Print Schema.</summary>
	/// <param name="hProvider">
	/// A handle to an open provider whose print capabilities are to be retrieved. This handle is returned by the PTOpenProvider or the
	/// PTOpenProviderEx function.
	/// </param>
	/// <param name="pPrintTicket">
	/// A pointer to a stream with its seek position at the beginning of the print ticket content. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="pCapabilities">
	/// A pointer to the stream where the print capabilities will be written, starting at the current seek position.
	/// </param>
	/// <param name="pbstrErrorMessage">
	/// A pointer to a string that specifies what, if anything, is invalid about pPrintTicket. If it is valid, this value is <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK.</para>
	/// <para>If hProvider was opened in a different thread, the <c>HRESULT</c> is E_INVALIDARG.</para>
	/// <para>If the pPrintTicket is not compliant with the Print Schema , the <c>HRESULT</c> is E_PRINTTICKET_FORMAT.</para>
	/// <para>If the pCapabilities is not compliant with the Print Schema , the <c>HRESULT</c> is E_PRINTCAPABILITIES_FORMAT.</para>
	/// <para>If hProvider was opened in a different thread, the <c>HRESULT</c> is E_INVALIDARG.</para>
	/// <para>
	/// Otherwise, another error code is returned in the <c>HRESULT</c>. For more information about COM error codes, see Error Handling.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>hProvider must be a handle that was opened in the same thread as the thread in which it is used for this function.</para>
	/// <para>
	/// The printer driver uses pPrintTicket values (when the value is not <c>NULL</c>) to create settings when the driver produces
	/// printer capabilities that vary depending on the current settings.
	/// </para>
	/// <para>
	/// When the function returns, the seek position of pPrintTicket is at the end of the print ticket content and the seek position of
	/// pCapabilities is at the end of the stream. If the caller uses a memory stream for pCapabilities, such as a stream created by
	/// CreateStreamOnHGlobal , the caller is responsible for resetting the seek position before reading the data.
	/// </para>
	/// <para>If pbstrErrorMessage is not <c>NULL</c> when the function returns, the caller must free the string with SysFreeString.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptgetprintcapabilities HRESULT PTGetPrintCapabilities(
	// HPTPROVIDER hProvider, IStream *pPrintTicket, IStream *pCapabilities, BSTR *pbstrErrorMessage );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "925e314c-85ff-4c1b-b3c9-f36aa4b55e01")]
	public static extern HRESULT PTGetPrintCapabilities(HPTPROVIDER hProvider, [Optional] IStream? pPrintTicket, IStream pCapabilities,
		[MarshalAs(UnmanagedType.BStr)] out string? pbstrErrorMessage);

	/// <summary>Retrieves the device printer's capabilities formatted in compliance with the XML Print Schema.</summary>
	/// <param name="hProvider">
	/// A handle to an open device provider whose print capabilities are to be retrieved. This handle is returned by the PTOpenProvider
	/// or the PTOpenProviderEx function.
	/// </param>
	/// <param name="pPrintTicket">
	/// An optional pointer to a stream with its seek position at the beginning of the print ticket content. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="pDeviceCapabilities">
	/// A pointer to the stream where the device print capabilities will be written, starting at the current seek position.
	/// </param>
	/// <param name="pbstrErrorMessage">
	/// A pointer to a PDC file or string that specifies what, if anything, is invalid about pPrintTicket. If it is valid, this value is
	/// <c>NULL</c>.The function uses this parameter only used if pPrintTicket is used.
	/// </param>
	/// <returns>If the operation succeeds, the return value is S_OK. Otherwise, returns an error message.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptgetprintdevicecapabilities HRESULT
	// PTGetPrintDeviceCapabilities( HPTPROVIDER hProvider, IStream *pPrintTicket, IStream *pDeviceCapabilities, BSTR *pbstrErrorMessage );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "DB9D63B1-2703-47F7-8F31-30FA0110E1E9")]
	public static extern HRESULT PTGetPrintDeviceCapabilities(HPTPROVIDER hProvider, [Optional] IStream? pPrintTicket, IStream pDeviceCapabilities,
		[MarshalAs(UnmanagedType.BStr)] out string? pbstrErrorMessage);

	/// <summary>It retrieves the print devices resources for a printer formatted in compliance with the XML Print Schema.</summary>
	/// <param name="hProvider">
	/// A handle to an open device provider whose print device resources are to be retrieved. This handle is returned by the
	/// PTOpenProvider or the PTOpenProviderEx function.
	/// </param>
	/// <param name="pszLocaleName">Optional pointer to the locale name. This parameter can be <c>NULL</c>.</param>
	/// <param name="pPrintTicket">
	/// A pointer to a stream with its seek position at the beginning of the print ticket content. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="pDeviceResources">
	/// A pointer to the stream where the device print resources will be written, starting at the current seek position.
	/// </param>
	/// <param name="pbstrErrorMessage">
	/// A pointer to a PDC file or string that specifies what, if anything, is invalid about pPrintTicket. If it is valid, this value is <c>NULL</c>.
	/// </param>
	/// <returns>If the operation succeeds, the return value is S_OK. Otherwise, returns an error message.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptgetprintdeviceresources HRESULT
	// PTGetPrintDeviceResources( HPTPROVIDER hProvider, LPCWSTR pszLocaleName, IStream *pPrintTicket, IStream *pDeviceResources, BSTR
	// *pbstrErrorMessage );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "39F17562-B8EB-41AF-BA55-42FE35B4560F")]
	public static extern HRESULT PTGetPrintDeviceResources(HPTPROVIDER hProvider, [MarshalAs(UnmanagedType.LPWStr)] string? pszLocaleName,
		[Optional] IStream? pPrintTicket, IStream pDeviceResources, [MarshalAs(UnmanagedType.BStr)] out string? pbstrErrorMessage);

	/// <summary>Merges two print tickets and returns a valid, viable print ticket.</summary>
	/// <param name="hProvider">
	/// A handle to an open print ticket provider. This handle is returned by the PTOpenProvider or the PTOpenProviderEx function.
	/// </param>
	/// <param name="pBaseTicket">
	/// <para>A pointer to a print ticket. The stream's seek position must be at the beginning of the print ticket content.</para>
	/// <para>
	/// <c>Note</c><c>PTMergeAndValidatePrintTicket</c> will validate the base ticket against the Print Schema Framework before merging.
	/// </para>
	/// </param>
	/// <param name="pDeltaTicket">
	/// <para>
	/// A pointer to a print ticket. The stream's seek position must be at the beginning of the print ticket content. <c>NULL</c> can be
	/// passed to this parameter. See Remarks.
	/// </para>
	/// <para>
	/// <c>Note</c><c>PTMergeAndValidatePrintTicket</c> will validate the delta ticket against the Print Schema Framework before merging.
	/// </para>
	/// </param>
	/// <param name="scope">
	/// A value specifying whether the scope of pDeltaTicket and pResultTicket is a single page, an entire document, or all documents in
	/// the print job. See Remarks.
	/// </param>
	/// <param name="pResultTicket">
	/// A pointer to the stream where the viable, merged ticket will be written. The seek position will be at the end of the print
	/// ticket. See Remarks.
	/// </param>
	/// <param name="pbstrErrorMessage">
	/// A pointer to a string that specifies what, if anything, is invalid about pBaseTicket or pDeltaTicket. If both are valid, this is
	/// <c>NULL</c>. Viability problems are not reported in pbstrErrorMessage.
	/// </param>
	/// <returns>
	/// <para>
	/// If the operation succeeds with no conflict between the settings of the merged ticket and the capabilities of the printer, the
	/// <c>HRESULT</c> is S_PT_NO_CONFLICT.
	/// </para>
	/// <para>
	/// If the operation succeeds but the merged ticket had to be changed in one or more settings because it requested functionality
	/// that the printer does not support, the <c>HRESULT</c> is S_PT_CONFLICT_RESOLVED. See Remarks.
	/// </para>
	/// <para>If hProvider was opened in a different thread, the <c>HRESULT</c> is E_INVALIDARG.</para>
	/// <para>If pBaseTicket is invalid, the <c>HRESULT</c> is E_PRINTTICKET_FORMAT.</para>
	/// <para>If pDeltaTicket is invalid, the <c>HRESULT</c> is E_DELTA_PRINTTICKET_FORMAT.</para>
	/// <para>
	/// Otherwise, some other error code is returned in the <c>HRESULT</c>. For more information about COM error codes, see Error Handling.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>hProvider must be a handle that was opened in the same thread as the thread in which it is used for this function.</para>
	/// <para>
	/// This function validates in two ways: It first validates both input tickets against the Print Schema Framework, reporting errors
	/// in pbstrErrorMessage. It then checks the viability of the merged print ticket with the printer driver. If the merged ticket
	/// requests functionality that the printer does not support, the nonviable settings are replaced and the printer driver determines
	/// what substitute setting to use. Typically, the printer driver uses the user's default print ticket setting. If the printer
	/// driver does not use the same print ticket that pBaseTicket points to as the source for substitute values, it is possible that
	/// pResultTicket will differ in some settings from both of the input print tickets.
	/// </para>
	/// <para>
	/// Typically, pBaseTicket contains a full range of job, document and page settings. Usually the user default or the device default
	/// print ticket is used for pBaseTicket.
	/// </para>
	/// <para>
	/// If pDeltaTicket is <c>NULL</c>, the method validates pBaseTicket, checks its viability, and returns it, possibly modified, in
	/// the stream pointed to by pResultTicket.
	/// </para>
	/// <para>
	/// Values of pDeltaTicket that are outside of the scope are ignored. For example, if the scope is only a single page, then job-wide
	/// settings and document-wide settings are ignored. Job scope includes document scope and page scope. Document scope includes page scope.
	/// </para>
	/// <para>Settings that are outside of the scope are not included in the pResultTicket.</para>
	/// <para>
	/// When the function returns a value, the seek position of pResultTicket is at the end of the print ticket content. The caller is
	/// responsible for resetting the seek position before reading the data.
	/// </para>
	/// <para>If pbstrErrorMessage is not <c>NULL</c> when the function returns, the caller must free the string with SysFreeString.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptmergeandvalidateprintticket HRESULT
	// PTMergeAndValidatePrintTicket( HPTPROVIDER hProvider, IStream *pBaseTicket, IStream *pDeltaTicket, EPrintTicketScope scope,
	// IStream *pResultTicket, BSTR *pbstrErrorMessage );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "97691930-d76a-48c9-80b9-8413d96322a9")]
	public static extern HRESULT PTMergeAndValidatePrintTicket(HPTPROVIDER hProvider, IStream pBaseTicket, [Optional] IStream? pDeltaTicket,
		EPrintTicketScope scope, IStream pResultTicket, [MarshalAs(UnmanagedType.BStr)] out string? pbstrErrorMessage);

	/// <summary>Opens an instance of a print ticket provider.</summary>
	/// <param name="pszPrinterName">A pointer to the full name of a print queue.</param>
	/// <param name="dwVersion">The version of the Print Schema requested by the caller.</param>
	/// <param name="phProvider">A pointer to a handle for the provider.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> contains an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>pszPrinterName must be the full name, not the truncated name as it may appear in a DEVMODE.</para>
	/// <para>
	/// The first version of the Print Schema was released with Windows Vista and is version 1. This operation fails if version is not
	/// supported. Contrast this with PTOpenProviderEx which opens a provider even if it supports only versions that are earlier than requested.
	/// </para>
	/// <para>To avoid a resource leak, phProvider must be closed with PTCloseProvider.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptopenprovider HRESULT PTOpenProvider( PCWSTR
	// pszPrinterName, DWORD dwVersion, HPTPROVIDER *phProvider );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "6821b1b0-74b0-4caf-b8e6-a9df4d7693d7")]
	public static extern HRESULT PTOpenProvider([MarshalAs(UnmanagedType.LPWStr)] string pszPrinterName, uint dwVersion, out SafeHPTPROVIDER phProvider);

	/// <summary>Opens an instance of a print ticket provider.</summary>
	/// <param name="pszPrinterName">A pointer to the full name of a print queue.</param>
	/// <param name="dwMaxVersion">The latest version of the Print Schema that the caller supports.</param>
	/// <param name="dwPrefVersion">The version of the Print Schema requested by the caller.</param>
	/// <param name="phProvider">A pointer to a handle for the provider.</param>
	/// <param name="pUsedVersion">A pointer to the version of the Print Schema that the print ticket provider will use.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> contains an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>The pszPrinterName parameter must be the full name, not the truncated name as it may appear in a DEVMODE.</para>
	/// <para>
	/// The first version of the Print Schema was released with Windows Vista and is version 1. If the print ticket provider does not
	/// support prefVersion, <c>PTOpenProviderEx</c> successfully opens a handle and returns an earlier version in usedVersion.
	/// </para>
	/// <para>To avoid a resource leak, phProvider must be closed with PTCloseProvider.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptopenproviderex HRESULT PTOpenProviderEx( PCWSTR
	// pszPrinterName, DWORD dwMaxVersion, DWORD dwPrefVersion, HPTPROVIDER *phProvider, DWORD *pUsedVersion );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "0e65170b-66f6-4238-bdde-0a0b7108a686")]
	public static extern HRESULT PTOpenProviderEx([MarshalAs(UnmanagedType.LPWStr)] string pszPrinterName, uint dwMaxVersion,
		uint dwPrefVersion, out SafeHPTPROVIDER phProvider, out uint pUsedVersion);

	/// <summary>Retrieves the highest (latest) version of the Print Schema that the specified printer supports.</summary>
	/// <param name="pszPrinterName">A pointer to the full name of a print queue.</param>
	/// <param name="pMaxVersion">A pointer to the highest version.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> contains an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>The pszPrinterName parameter must be the full name, not the truncated name as it may appear in a DEVMODE.</para>
	/// <para>The first version of the Print Schema was released with Windows Vista and is version 1.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptqueryschemaversionsupport HRESULT
	// PTQuerySchemaVersionSupport( PCWSTR pszPrinterName, DWORD *pMaxVersion );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "a3b5a92f-3a5b-4438-b788-91c9ac5a191f")]
	public static extern HRESULT PTQuerySchemaVersionSupport([MarshalAs(UnmanagedType.LPWStr)] string pszPrinterName, out uint pMaxVersion);

	/// <summary>Releases buffers associated with print tickets and print capabilities.</summary>
	/// <param name="pBuffer">A pointer to a buffer allocated during a call to a print ticket API.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> contains an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>Use this function to release the DEVMODE buffer returned by PTConvertPrintTicketToDevMode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptreleasememory HRESULT PTReleaseMemory( PVOID pBuffer );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "d568b3a9-7f13-4e4e-8bbc-f4ab0009fe83")]
	public static extern HRESULT PTReleaseMemory(IntPtr pBuffer);

	/// <summary>
	/// <para>
	/// [This function is not supported and might be disabled or deleted in future versions of Windows. <c>PTCloseProvider</c> provides
	/// equivalent functionality and should be used instead.]
	/// </para>
	/// <para>Closes a handle to a print ticket provider.</para>
	/// </summary>
	/// <param name="hProvider">
	/// A handle to an open print ticket provider. This handle is returned by the <c>BindPTProviderThunk</c> function.
	/// </param>
	/// <returns>
	/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
	/// COM error codes, see Error Handling.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/unbindptproviderthunk HRESULT UnbindPTProviderThunk( _In_ HPTPROVIDER
	// hProvider );
	[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("prntvpt.h", MSDNShortId = "ce979c89-9f9d-4e89-b142-beed414caa3f")]
	public static extern HRESULT UnbindPTProviderThunk(HPTPROVIDER hProvider);

	/// <summary>Provides a <see cref="SafeHandle"/> for memory allocated by a PTxx function that is disposed using <see cref="PTReleaseMemory"/>.</summary>
	[AutoSafeHandle("PTReleaseMemory(handle).Succeeded")]
	public partial class SafePTMemory
	{
		/// <summary>Converts the memory held by this object to a structure.</summary>
		/// <typeparam name="T">The type of the structure.</typeparam>
		/// <returns>A structure marshaled from this memory.</returns>
		public T? ToStructure<T>() => IsInvalid ? default : handle.ToStructure<T>();
	}
}