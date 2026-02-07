namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>Enable color optimization.</summary>
	public const uint EMF_PP_COLOR_OPTIMIZATION = 0x01;

	/// <summary>Specifies the page type.</summary>
	[PInvokeData("winppi.h", MSDNShortId = "7eaed9d2-20fa-4cf1-b924-fbe1443535e9")]
	public enum EMF_PP : uint
	{
		/// <summary>The page is a normal page.</summary>
		EMF_PP_NORMAL = 1,

		/// <summary>The page is a form or has a watermark. (Not currently supported.)</summary>
		EMF_PP_FORM = 2,
	}

	/// <summary>The <c>GdiDeleteSpoolFileHandle</c> function releases a spool file handle.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <returns>If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiDeleteSpoolFileHandle</c> function is exported by Gdi32.dll for use within a print processor's
	/// PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// Print processors should call <c>GdiDeleteSpoolFileHandle</c> after calling GdiEndDocEMF, when processing a print job's EMF data
	/// stream has been completed. The function calls ClosePrinter (described in the Microsoft Window SDK documentation) to close the
	/// printer connection.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdideletespoolfilehandle BOOL
	// GdiDeleteSpoolFileHandle( HANDLE SpoolFileHandle );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "ff22498e-404f-42f6-82fd-f0178f6c7789")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiDeleteSpoolFileHandle(HSPOOLFILE SpoolFileHandle);

	/// <summary>The <c>GdiEndDocEMF</c> function ends EMF playback operations for an EMF-formatted print job.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <returns>
	/// If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>, and an error code can
	/// be obtained by calling <c>GetLastError</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiEndDocEMF</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// The function performs operations that must be performed after a print job's EMF records have been played. The function calls the
	/// spooler's <c>EndDoc</c> function (described in the Microsoft Window SDK documentation), which in turn calls the printer driver's
	/// DrvEndDoc function.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdienddocemf BOOL GdiEndDocEMF( HANDLE
	// SpoolFileHandle );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "e58403d4-aacc-4d22-98e5-86db1a69c54a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiEndDocEMF([In, AddAsMember] HSPOOLFILE SpoolFileHandle);

	/// <summary>The <c>GdiEndPageEMF</c> function ends EMF playback operations for a physical page of an EMF-formatted print job.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <param name="dwOptimization">
	/// <para>Caller-supplied flags. The following flag is defined:</para>
	/// <para>EMF_PP_COLOR_OPTIMIZATION</para>
	/// <para>Enable color optimization. For more information, see Remarks.</para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>, and an error code can
	/// be obtained by calling <c>GetLastError</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiEndPageEMF</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// The <c>GdiEndPageEMF</c> function ends the processing of a physical page and causes it to be ejected from the printer. A print
	/// processor should call <c>GdiEndPageEMF</c> at the following times:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// After the appropriate number of document pages have been placed on the physical page by making calls to GdiPlayPageEMF. Note
	/// that <c>GdiPlayPageEMF</c> does not actually print on the device context, but instead prepares a data structure that describes
	/// the text and graphics that are to be printed on the physical page(s). The text and graphics are printed to the device context
	/// when <c>GdiEndPageEMF</c> is called.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Whenever a call to GdiGetDevmodeForPage indicates a document page's DEVMODEW structure is different from the previous page's
	/// DEVMODE structure.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If this function is called with the dwOptimization parameter set to EMF_PP_COLOR_OPTIMIZATION, color optimization is enabled. If
	/// dwOptimization is set to 0, no optimization is performed. When color optimization is enabled, the presence of color in the spool
	/// file causes the spool file to be played in color; the lack of color in the spool file causes the spool file to be played in monochrome.
	/// </para>
	/// <para>
	/// If you are creating a Unidrv rendering plug-in to generate color watermarks, be advised that color optimization causes color
	/// watermarks to be printed in black and white when they are printed on black-and-white documents. To ensure that color watermarks
	/// print correctly with color and black-and-white documents, disable color optimization.
	/// </para>
	/// <para>
	/// The color optimization controlled by the dwOptimization parameter can also be controlled by setting the
	/// <c>dwColorOptimization</c> member of the ATTRIBUTE_INFO_2 or ATTRIBUTE_INFO_3 structures. This optimization also can be
	/// controlled by the Unidrv * <c>ChangeColorModeOnDoc?</c> color attribute (see Color Attributes).
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdiendpageemf BOOL GdiEndPageEMF( HANDLE
	// SpoolFileHandle, DWORD dwOptimization );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "e15344a5-32ed-43a8-93c2-d5201617d595")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiEndPageEMF([In, AddAsMember] HSPOOLFILE SpoolFileHandle, uint dwOptimization);

	/// <summary>The <c>GdiGetDC</c> function returns a handle to a printer's device context.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <returns>If the operation succeeds, the function returns a device context handle. Otherwise the function returns <c>NULL</c>.</returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiGetDC</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// A print processor can call <c>GdiGetDC</c> to obtain a printer's device context handle anytime after calling
	/// GdiGetSpoolFileHandle. The print processor can use the context handle to call Win32 device context functions, in order to
	/// perform such operations as applying transformations on the print image.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetdc HDC GdiGetDC( HANDLE SpoolFileHandle );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "f8aacb6d-4e8a-4fdb-902c-3d0efbc40f08")]
	public static extern HDC GdiGetDC([In, AddAsMember] HSPOOLFILE SpoolFileHandle);

	/// <summary>
	/// The <c>GdiGetDevmodeForPage</c> function returns DEVMODEW structures for the specified and previous pages of a print job.
	/// </summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <param name="dwPageNumber">Caller-supplied number of the page for which DEVMODEW contents are to be returned.</param>
	/// <param name="pCurrDM">Caller-supplied location to receive a pointer to a DEVMODE structure for the page specified by dwPageNumber.</param>
	/// <param name="pLastDM">
	/// Caller-supplied location to receive a pointer to a DEVMODE structure for the page previous to the one specified by dwPageNumber.
	/// </param>
	/// <returns>If the operation succeeds, the function returns <c>TRUE</c>. Otherwise it returns <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiGetDevmodeForPage</c> function is exported by Gdi32.dll for use within a print processor's
	/// PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// Before calling GdiPlayPageEMF to execute a page's EMF instructions, a print processor must call <c>GdiGetDevmodeForPage</c> to
	/// determine if the DEVMODE structure associated with the page to be printed is the same as that of the last page printed. If the
	/// two returned DEVMODE structures are not identical, the print processor must perform the following steps, in order, before
	/// calling <c>GdiPlayPageEMF</c> for the page:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call GdiEndPageEMF.</term>
	/// </item>
	/// <item>
	/// <term>Call GdiResetDCEMF, specifying the DEVMODE pointed to by pCurrDM.</term>
	/// </item>
	/// <item>
	/// <term>Call GdiStartPageEMF.</term>
	/// </item>
	/// </list>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetdevmodeforpage BOOL GdiGetDevmodeForPage(
	// HANDLE SpoolFileHandle, DWORD dwPageNumber, PDEVMODEW *pCurrDM, PDEVMODEW *pLastDM );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winppi.h", MSDNShortId = "3410e8b1-820f-4892-8d26-d803e3f943da")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiGetDevmodeForPage([In, AddAsMember] HSPOOLFILE SpoolFileHandle, uint dwPageNumber, out ManagedStructPointer<DEVMODE> pCurrDM, out ManagedStructPointer<DEVMODE> pLastDM);

	/// <summary>The <c>GdiGetPageCount</c> function returns the number of pages in a print job.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <returns>
	/// If the operation succeeds, the function returns the number of pages in the current print job. Otherwise the function returns zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiGetPageCount</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>GdiGetPageCount</c> function does not return until all pages have been spooled, even if the print server
	/// administrator has specified that print jobs should be printed during spooling. Therefore, this function should not be used
	/// unless it is necessary to obtain the total page count before document processing can begin, such as for printing pages in
	/// reverse order.Usually, a better method for determining the page count is to count the number of calls made to GdiGetPageHandle.
	/// </para>
	/// <para>For additional information about this set of functions, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetpagecount DWORD GdiGetPageCount( HANDLE
	// SpoolFileHandle );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "0a101b59-c610-4158-97a8-002222a94309")]
	public static extern uint GdiGetPageCount([In, AddAsMember] HSPOOLFILE SpoolFileHandle);

	/// <summary>The <c>GdiGetPageHandle</c> function returns a handle to the specified page within a print job.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <param name="Page">Caller-supplied page number.</param>
	/// <param name="pdwPageType">
	/// <para>
	/// Caller-supplied pointer to a location that receives the page type. The possible page types are shown in the following table:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Page Type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EMF_PP_FORM</term>
	/// <term>The page is a form or has a watermark. (Not currently supported.)</term>
	/// </item>
	/// <item>
	/// <term>EMF_PP_NORMAL</term>
	/// <term>The page is a normal page.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>, and an error code can
	/// be obtained by calling <c>GetLastError</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiGetPageHandle</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// Print processors must obtain a page handle before calling GdiPlayPageEMF to draw a page. If a Page value is specified that is
	/// too large, the function returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetpagehandle HANDLE GdiGetPageHandle( HANDLE
	// SpoolFileHandle, DWORD Page, LPDWORD pdwPageType );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "7eaed9d2-20fa-4cf1-b924-fbe1443535e9")]
	public static extern HANDLE GdiGetPageHandle([In, AddAsMember] HSPOOLFILE SpoolFileHandle, uint Page, out EMF_PP pdwPageType);

	/// <summary>The <c>GdiGetSpoolFileHandle</c> function returns a handle to a print job's EMF file.</summary>
	/// <param name="pwszPrinterName">
	/// Caller-supplied pointer to a string representing the name of the target printer. See the following Remarks section.
	/// </param>
	/// <param name="pDevmode">Caller-supplied pointer to a DEVMODEW structure. See the following Remarks section.</param>
	/// <param name="pwszDocName">Caller-supplied pointer to the print job's document name. See the following Remarks section.</param>
	/// <returns>If the operation succeeds, the function returns a spool file handle. Otherwise the function returns <c>NULL</c>.</returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiGetSpoolFileHandle</c> function is exported by Gdi32.dll for use within a print processor's
	/// PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// When a print processor calls <c>GdiGetSpoolFileHandle</c>, it should supply arguments as illustrated in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Argument</term>
	/// </listheader>
	/// <item>
	/// <term>pwszPrinterName</term>
	/// <term>Pointer to the printer name received by the print processor's OpenPrintProcessor function.</term>
	/// </item>
	/// <item>
	/// <term>pDevmode</term>
	/// <term>
	/// Pointer to the DEVMODEW structure contained in the PRINTPROCESSOROPENDATA structure, received by the print processor's
	/// OpenPrintProcessor function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>pwszDocName</term>
	/// <term>Document name pointer received by the print processor's PrintDocumentOnPrintProcessor function.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A print processor must call the <c>GdiGetSpoolFileHandle</c> function before calling any other GDI printing functions, because
	/// the returned handle must be passed to the other functions. The function calls OpenPrinter to open a connection to the printer,
	/// and CreateDC to create a device context for drawing. The print processor can obtain the device context's handle by calling GdiGetDC.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetspoolfilehandle HANDLE
	// GdiGetSpoolFileHandle( StrPtrUni pwszPrinterName, LPDEVMODEW pDevmode, StrPtrUni pwszDocName );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winppi.h", MSDNShortId = "c820ee94-29c2-4478-884c-49dd68cd713a")]
	[return: AddAsCtor]
	public static extern SafeHSPOOLFILE GdiGetSpoolFileHandle([MarshalAs(UnmanagedType.LPWStr)] string pwszPrinterName, in DEVMODE pDevmode, [MarshalAs(UnmanagedType.LPWStr)] string pwszDocName);

	/// <summary>
	/// The <c>GdiPlayPageEMF</c> function plays the EMF records within a specified rectangle for one document page of a spooled print job.
	/// </summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <param name="hemf">
	/// Caller-supplied page handle, obtained by calling GdiGetPageHandle, identifying the page for which records are to be played.
	/// </param>
	/// <param name="prectDocument">
	/// Caller-supplied pointer to a RECT structure specifying the rectangle into which the page is to be drawn.
	/// </param>
	/// <param name="prectBorder">
	/// Caller-supplied pointer to a RECT structure specifying the page's border rectangle (if any). Can be <c>NULL</c>.
	/// </param>
	/// <param name="prectClip">
	/// Caller-supplied pointer to a RECT structure specifying the coordinates of the page's clip region (if any). Can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>, and an error code can
	/// be obtained by calling <c>GetLastError</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiPlayPageEMF</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// The <c>GdiPlayPageEMF</c> function is the means by which a print processor positions a document page or a specified rectangular
	/// region of a document page on a physical page. Note that <c>GdiPlayPageEMF</c> does not actually print on the device context, but
	/// instead prepares a data structure that describes the text and graphics that are to be printed on the physical page(s). The text
	/// and graphics are printed to the device context when GdiEndPageEMF is called.
	/// </para>
	/// <para>
	/// The print processor uses prectClip to describe the rectangular region to be printed, and prectDocument to describe a rectangle
	/// into which the document page (or clipped region) must fit. If prectClip is <c>NULL</c>, the entire document page will be
	/// printed. For non- <c>NULL</c> values of prectClip, only the portion of the document page within the clip region will be printed.
	/// The <c>GdiPlayPageEMF</c> function then performs the scaling and translation operations required to make the document page (or
	/// selected portion) fit into the rectangle.
	/// </para>
	/// <para>
	/// The prectBorder parameter, if it is non- <c>NULL</c>, describes a solid-line border rectangle to be drawn around the document
	/// page. If prectBorder is <c>NULL</c>, no such border will be drawn.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdiplaypageemf BOOL GdiPlayPageEMF( HANDLE
	// SpoolFileHandle, HANDLE hemf, RECT *prectDocument, RECT *prectBorder, RECT *prectClip );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "e0122858-0c9d-4aa8-a394-89d65fb98fda")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiPlayPageEMF([In, AddAsMember] HSPOOLFILE SpoolFileHandle, HANDLE hemf, in RECT prectDocument, [In, Optional] PRECT? prectBorder, [In, Optional] PRECT? prectClip);

	/// <summary>The <c>GdiResetDCEMF</c> function resets a printer's device context during playback of a spooled EMF print job.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <param name="pCurrDM">Caller-supplied pointer to a DEVMODEW structure, obtained by a previous call to GdiGetDevmodeForPage.</param>
	/// <returns>If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiResetDCEMF</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// Print processors must call <c>GdiResetDCEMF</c> whenever it is necessary to reset the printer's device context. The function
	/// must be called whenever the GdiGetDevmodeForPage function indicates that the current document page's DEVMODEW structure is not
	/// identical to that of the previous document page.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdiresetdcemf BOOL GdiResetDCEMF( HANDLE
	// SpoolFileHandle, PDEVMODEW pCurrDM );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winppi.h", MSDNShortId = "ea97cc22-6057-427d-90c1-4f23ced932aa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiResetDCEMF([In, AddAsMember] HSPOOLFILE SpoolFileHandle, IntPtr pCurrDM);

	/// <summary>The <c>GdiStartDocEMF</c> function performs initialization operations for an EMF-formatted print job.</summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <param name="pDocInfo">Caller-supplied pointer to a DOCINFOW structure (described in the Microsoft Window SDK documentation).</param>
	/// <returns>
	/// If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>, and an error code can
	/// be obtained by calling <c>GetLastError</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiStartDocEMF</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// The function performs initializations that must take place before a print job's EMF records can be played. The function calls
	/// the spooler's <c>StartDoc</c> function (described in the Window SDK documentation), which in turn calls the printer driver's
	/// DrvStartDoc function.
	/// </para>
	/// <para>
	/// The print processor must set the <c>lpszOutput</c> member of the DOCINFOW structure to the output file name contained in the
	/// PRINTPROCESSOROPENDATA structure, previously received by the OpenPrintProcessor function.
	/// </para>
	/// <para>
	/// The print processor must set the <c>lpszDocName</c> member of the DOCINFOW structure to the document name pointer, previously
	/// received by the PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdistartdocemf BOOL GdiStartDocEMF( HANDLE
	// SpoolFileHandle, DOCINFOW *pDocInfo );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winppi.h", MSDNShortId = "aca4534a-871e-4d86-b329-cb4f84611a29")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiStartDocEMF([In, AddAsMember] HSPOOLFILE SpoolFileHandle, in DOCINFO pDocInfo);

	/// <summary>
	/// The <c>GdiStartPageEMF</c> function performs initialization operations for a physical page of an EMF-formatted print job.
	/// </summary>
	/// <param name="SpoolFileHandle">Caller-supplied spool file handle, obtained by a previous call to GdiGetSpoolFileHandle.</param>
	/// <returns>
	/// If the operation succeeds, the function returns <c>TRUE</c>. Otherwise the function returns <c>FALSE</c>, and an error code can
	/// be obtained by calling <c>GetLastError</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GdiStartPageEMF</c> function is exported by Gdi32.dll for use within a print processor's PrintDocumentOnPrintProcessor function.
	/// </para>
	/// <para>
	/// A print processor must call the <c>GdiStartPageEMF</c> function each time a new physical page is to be created. It can then call
	/// GdiPlayPageEMF for each document page that is to be placed on the physical page.
	/// </para>
	/// <para>For additional information, see Using GDI Functions in Print Processors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdistartpageemf BOOL GdiStartPageEMF( HANDLE
	// SpoolFileHandle );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winppi.h", MSDNShortId = "963c809f-da89-4f27-ba8b-3de8cdcec179")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiStartPageEMF([In, AddAsMember] HSPOOLFILE SpoolFileHandle);
}