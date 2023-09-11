using System.IO;

namespace Vanara.PInvoke;

/// <summary>Items from the cabinet.dll</summary>
public static partial class Cabinet
{
	/// <summary/>
	public const int CB_MAX_CAB_PATH = 256;

	/// <summary/>
	public const int CB_MAX_CABINET_NAME = 256;

	/// <summary/>
	public const int CB_MAX_CHUNK = 32768;

	/// <summary/>
	public const int CB_MAX_DISK = 0x7fffffff;

	/// <summary/>
	public const int CB_MAX_DISK_NAME = 256;

	/// <summary/>
	public const int CB_MAX_FILENAME = 256;

	/// <summary/>
	[PInvokeData("fci.h")]
	public const int tcompSHIFT_LZX_WINDOW = 8;

	/// <summary/>
	[PInvokeData("fci.h")]
	public const int tcompSHIFT_QUANTUM_LEVEL = 4;

	/// <summary/>
	[PInvokeData("fci.h")]
	public const int tcompSHIFT_QUANTUM_MEM = 8;

	/// <summary>
	/// The <c>FNFCIALLOC</c> provides the declaration for the application-defined callback function to allocate memory within an FCI context.
	/// </summary>
	/// <param name="cb">Bytes to be allocated from the stack.</param>
	/// <returns>pointer to the allocated space</returns>
	/// <remarks>
	/// <para>The function accepts parameters similar to malloc.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcialloc
	[PInvokeData("fci.h", MSDNShortId = "339ac9d2-60bc-4a90-8a46-6fbb073be9d1")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate IntPtr PFNALLOC(uint cb);

	/// <summary>
	/// The <c>FNFCICLOSE</c> macro provides the declaration for the application-defined callback function to close a file in an FCI context.
	/// </summary>
	/// <param name="hf">The file handle.</param>
	/// <param name="err">The error.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>Returns 0 if the file was successfully closed. A return value of –1 indicates an error.</returns>
	/// <remarks>The function accepts parameters similar to _close, with the addition of err and pv.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfciclose
	[PInvokeData("fci.h", MSDNShortId = "c4edf6ca-0b16-4e30-933b-934f8930c6d6")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate int PFNFCICLOSE(IntPtr hf, out int err, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIDELETE</c> macro provides the declaration for the application-defined callback function to delete a file in the FCI context.
	/// </summary>
	/// <param name="pszFile">The name of the file to be deleted.</param>
	/// <param name="err">The error.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>Returns 0 if the file was successfully deleted. A return value of –1 indicates an error.</returns>
	/// <remarks>The function accepts parameters similar to remove, with the addition of err and pv.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcidelete
	[PInvokeData("fci.h", MSDNShortId = "5c85ad86-2794-4f7c-8c10-18fea3519b11")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate int PFNFCIDELETE(string pszFile, out int err, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIFILEPLACED</c> macro provides the declaration for the application-defined callback function to notify when a file is
	/// placed in the cabinet.
	/// </summary>
	/// <param name="pccab">Pointer to the CCAB structure containing the parameters of the cabinet on which the file has been stored.</param>
	/// <param name="pszFile">The name of the file to be replaced.</param>
	/// <param name="cbFile">The length of the file.</param>
	/// <param name="fContinuation">true if this is a later segment of a continued file</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>Returns 0 if the file was successfully replaced. A return value of –1 indicates an error.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcifileplaced
	[PInvokeData("fci.h", MSDNShortId = "f8a1bcfc-8a13-49cf-a3e7-caec6c6421b0")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate int PFNFCIFILEPLACED(ref CCAB pccab, string pszFile, int cbFile, [MarshalAs(UnmanagedType.Bool)] bool fContinuation, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIGETNEXTCABINET</c> macro provides the declaration for the application-defined callback function to request
	/// information for the next cabinet.
	/// </summary>
	/// <param name="pccab">Points to copy of old ccab structure to modify.</param>
	/// <param name="cbPrevCab">Estimate of size of previous cabinet.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns><see langword="true"/> on success.</returns>
	/// <remarks>
	/// <para>
	/// The CCAB structure referenced by this function is relevant to the most recently completed cabinet. However, with each successful
	/// operation the iCab field contained within this structure will have incremented by 1. Additionally, the next cabinet will be
	/// created using the fields in this structure. The szCab, in particular, should be modified as necessary. In particular, the szCab
	/// field, which specifies the cabinet name, should be changed for each cabinet.
	/// </para>
	/// <para>When creating multiple cabinets, typically the iCab field is used to create the name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcigetnextcabinet
	[PInvokeData("fci.h", MSDNShortId = "d56fb63e-91bf-4991-a954-176211697a2e")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PFNFCIGETNEXTCABINET(ref CCAB pccab, uint cbPrevCab, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIGETOPENINFO</c> macro provides the declaration for the application-defined callback function to open a file and
	/// retrieve file date, time, and attribute.
	/// </summary>
	/// <param name="pszName">complete path to filename.</param>
	/// <param name="pdate">location to return FAT-style date code.</param>
	/// <param name="ptime">location to return FAT-style time code.</param>
	/// <param name="pattribs">location to return FAT-style attributes.</param>
	/// <param name="err">The error.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>Return value is file handle of open file to read, or INVALID_FILE_HANDLE on failure.</returns>
	/// <remarks>The function should open the file using the file open function compatible with those passed into FCICreate.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcigetopeninfo
	[PInvokeData("fci.h", MSDNShortId = "5baccb69-7872-4d67-ad74-70cdd7459f8d")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate IntPtr PFNFCIGETOPENINFO(string pszName, ref ushort pdate, ref ushort ptime, ref ushort pattribs, out int err, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIGETTEMPFILE</c> macro provides the declaration for the application-defined callback function to obtain a temporary
	/// file name.
	/// </summary>
	/// <param name="pszTempName">Buffer to receive complete tempfile name.</param>
	/// <param name="cbTempName">Size of pszTempName buffer.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns><see langword="true"/> on success.</returns>
	/// <remarks>
	/// The function can return a filename that already exists by the time it is opened. For this reason, the caller should be prepared
	/// to make several attempts to create temporary files.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcigettempfile
	[PInvokeData("fci.h", MSDNShortId = "8978f688-d8f1-437a-b298-eed1e7dac012")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PFNFCIGETTEMPFILE(IntPtr pszTempName, int cbTempName, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIOPEN</c> macro provides the declaration for the application-defined callback function to open a file in an FCI context.
	/// </summary>
	/// <param name="pszFile">File name.</param>
	/// <param name="oflag">The kind of operations allowed.</param>
	/// <param name="pmode">Permission mode.</param>
	/// <param name="err">The error.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>Return value is file handle of open file to read, or INVALID_FILE_HANDLE on failure.</returns>
	/// <remarks>The function accepts parameters similar to _open.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfciopen
	[PInvokeData("fci.h", MSDNShortId = "72cf50cb-c895-4953-9c4d-f8ddaa294f2a")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate IntPtr PFNFCIOPEN(string pszFile, RunTimeLib.FileOpConstant oflag, RunTimeLib.FilePermissionConstant pmode, out int err, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIREAD</c> macro provides the declaration for the application-defined callback function to read data from a file in an
	/// FCI context.
	/// </summary>
	/// <param name="hf">File descriptor referring to the open file.</param>
	/// <param name="memory">Storage location for data.</param>
	/// <param name="cb">Maximum number of bytes to read.</param>
	/// <param name="err">The error.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>returns the number of bytes read</returns>
	/// <remarks>
	/// <para>The function accepts parameters similar to _read with the addition to err and pv.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfciread
	[PInvokeData("fci.h", MSDNShortId = "dd4e97ff-efbc-462b-b954-bc3260fa1513")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate uint PFNFCIREAD(IntPtr hf, [Out] IntPtr memory, uint cb, out int err, IntPtr pv);

	/// <summary>
	/// The <c>FNFCISEEK</c> macro provides the declaration for the application-defined callback function to move a file pointer to the
	/// specified location in an FCI context.
	/// </summary>
	/// <param name="hf">File descriptor referring to an open file.</param>
	/// <param name="dist">Number of bytes from origin.</param>
	/// <param name="seektype">Initial position..</param>
	/// <param name="err">The error.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>returns the offset, in bytes, of the new position from the beginning of the file.</returns>
	/// <remarks>
	/// <para>The function accepts parameters similar to _lseek with the addition to err and pv.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfciseek
	[PInvokeData("fci.h", MSDNShortId = "e5a14c98-4de6-452e-8993-afb7964aeee7")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate int PFNFCISEEK(IntPtr hf, int dist, System.IO.SeekOrigin seektype, out int err, IntPtr pv);

	/// <summary>
	/// The <c>FNFCISTATUS</c> macro provides the declaration for the application-defined callback function to update the user.
	/// </summary>
	/// <param name="typeStatus">The type status.</param>
	/// <param name="cb1">
	/// File: Size of compressed block. Folder: Amount of folder copied to cabinet so far. Cabinet: Estimated cabinet size that was
	/// previously passed to fnfciGetNextCabinet().
	/// </param>
	/// <param name="cb2">File: Size of uncompressed block. Folder: Total size of folder. Cabinet: Actual cabinet size.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>Returns -1 to signal that FCI should abort; Returns anything other than -1 on success.</returns>
	/// <remarks>
	/// If typeStatus equals <c>statusCabinet</c> the returned value indicates the desired size for the cabinet file. FCI updates the
	/// maximum cabinet size remaining using this returned value. This allows a client to generate multiple cabinets per disk, and have
	/// FCI limit the size accordingly.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcistatus
	[PInvokeData("fci.h", MSDNShortId = "529fd3c8-9783-4dbe-9268-a9137935cf9b")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate int PFNFCISTATUS(CabinetFileStatus typeStatus, uint cb1, uint cb2, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIWRITE</c> macro provides the declaration for the application-defined callback function to write data to a file in an
	/// FCI context.
	/// </summary>
	/// <param name="hf">File descriptor of file into which data is written.</param>
	/// <param name="memory">Data to be written.</param>
	/// <param name="cb">Number of bytes.</param>
	/// <param name="err">The error.</param>
	/// <param name="pv">An application-defined value.</param>
	/// <returns>returns the number of bytes actually written.</returns>
	/// <remarks>The function accepts parameters similar to _write.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfciwrite
	[PInvokeData("fci.h", MSDNShortId = "ca4c3b5b-1ed5-4f12-8317-c1e1dac5f816")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate uint PFNFCIWRITE(IntPtr hf, [In] IntPtr memory, uint cb, out int err, IntPtr pv);

	/// <summary>
	/// The <c>FNFCIFREE</c> macro provides the declaration for the application-defined callback function to free previously allocated
	/// memory in an FCI context.
	/// </summary>
	/// <param name="memory">The pointer to the memory to be freed.</param>
	/// <remarks>
	/// <para>The function accepts parameters similar to free.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fnfcifree
	[PInvokeData("fci.h", MSDNShortId = "48f052e2-7786-430a-b3dc-afcfdffae387")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate void PFNFREE(IntPtr memory);

	/// <summary>Used by <see cref="PFNFCISTATUS"/>.</summary>
	[PInvokeData("fci.h")]
	public enum CabinetFileStatus
	{
		/// <summary>compressing a block into a folder</summary>
		File,

		/// <summary>adding a folder to a cabinet</summary>
		Folder,

		/// <summary>writing out a complete cabinet</summary>
		Cabinet
	}

	/// <summary>An FCI/FDI error code.</summary>
	[PInvokeData("fci.h")]
	public enum FCIERROR
	{
		/// <summary>No Error.</summary>
		FCIERR_NONE = 0x00,

		/// <summary>Failure opening the file to be stored in the cabinet.</summary>
		FCIERR_OPEN_SRC = 0x01,

		/// <summary>Failure reading the file to be stored in the cabinet.</summary>
		FCIERR_READ_SRC = 0x02,

		/// <summary>Out of memory in FCI.</summary>
		FCIERR_ALLOC_FAIL = 0x03,

		/// <summary>Could not create a temporary file.</summary>
		FCIERR_TEMP_FILE = 0x04,

		/// <summary>Unknown compression type.</summary>
		FCIERR_BAD_COMPR_TYPE = 0x05,

		/// <summary>Could not create the cabinet file.</summary>
		FCIERR_CAB_FILE = 0x06,

		/// <summary>FCI aborted.</summary>
		FCIERR_USER_ABORT = 0x07,

		/// <summary>Failure compressing data.</summary>
		FCIERR_MCI_FAIL = 0x08,

		/// <summary>Data-size or file-count exceeded CAB format limits.</summary>
		FCIERR_CAB_FORMAT_LIMIT = 0x09,
	}

	/// <summary>The compression type to use.</summary>
	[PInvokeData("fci.h")]
	[Flags]
	public enum TCOMP
	{
		/// <summary/>
		tcompMASK_TYPE = 0x000F,

		/// <summary>No compression.</summary>
		tcompTYPE_NONE = 0x0000,

		/// <summary>Microsoft ZIP compression.</summary>
		tcompTYPE_MSZIP = 0x0001,

		/// <summary/>
		tcompTYPE_QUANTUM = 0x0002,

		/// <summary/>
		tcompTYPE_LZX = 0x0003,

		/// <summary/>
		tcompBAD = 0x000F,

		/// <summary/>
		tcompMASK_LZX_WINDOW = 0x1F00,

		/// <summary/>
		tcompLZX_WINDOW_LO = 0x0F00,

		/// <summary/>
		tcompLZX_WINDOW_HI = 0x1500,

		/// <summary/>
		tcompMASK_QUANTUM_LEVEL = 0x00F0,

		/// <summary/>
		tcompQUANTUM_LEVEL_LO = 0x0010,

		/// <summary/>
		tcompQUANTUM_LEVEL_HI = 0x0070,

		/// <summary/>
		tcompMASK_QUANTUM_MEM = 0x1F00,

		/// <summary/>
		tcompQUANTUM_MEM_LO = 0x0A00,

		/// <summary/>
		tcompQUANTUM_MEM_HI = 0x1500,

		/// <summary/>
		tcompMASK_RESERVED = 0xE000,
	}

	/// <summary>The <c>FCIAddFile</c> adds a file to the cabinet under construction.</summary>
	/// <param name="hfci">A valid FCI context handle returned by the FCICreate function.</param>
	/// <param name="pszSourceFile">The name of the file to add; this value should include path information.</param>
	/// <param name="pszFileName">The name under which to store the file in the cabinet.</param>
	/// <param name="fExecute">If set <c>TRUE</c>, the file will be executed when extracted.</param>
	/// <param name="pfnfcignc">
	/// Pointer to an application-defined callback function to obtain specifications on the next cabinet to create. The function should
	/// be declared using the FNFCIGETNEXTCABINET macro.
	/// </param>
	/// <param name="pfnfcis">
	/// Pointer to an application-defined callback function to update the progress information available to the user. The function
	/// should be declared using the FNFCISTATUS macro.
	/// </param>
	/// <param name="pfnfcigoi">
	/// Pointer to an application-defined callback function to open a file and retrieve the file date, time, and attributes. The
	/// function should be declared using the FNFCIGETOPENINFO macro.
	/// </param>
	/// <param name="typeCompress">
	/// <para>The compression type to use.</para>
	/// <para><c>Note</c> To indicate LZX compression, use the TCOMPfromLZXWindow macro.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>tcompTYPE_NONE 0x0000</term>
	/// <term>No compression.</term>
	/// </item>
	/// <item>
	/// <term>tcompTYPE_MSZIP 0x0001</term>
	/// <term>Microsoft ZIP compression.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>; otherwise, <c>FALSE</c>.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FCI context.</para>
	/// </returns>
	/// <remarks>
	/// When set, the _A_EXEC attribute is added to the file entry in the CAB. This mechanism is used in some Microsoft self-extracting
	/// executables, and could be used for this purpose in any custom extraction application.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fciaddfile BOOL DIAMONDAPI FCIAddFile( HFCI hfci, LPSTR
	// pszSourceFile, LPSTR pszFileName, BOOL fExecute, PFNFCIGETNEXTCABINET pfnfcignc, PFNFCISTATUS pfnfcis, PFNFCIGETOPENINFO
	// pfnfcigoi, TCOMP typeCompress );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fci.h", MSDNShortId = "f99e8718-853b-4d35-98ae-61a8333dbaba")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FCIAddFile([In] HFCI hfci, string pszSourceFile, string pszFileName, [MarshalAs(UnmanagedType.Bool)] bool fExecute,
		[In] PFNFCIGETNEXTCABINET pfnfcignc, [In] PFNFCISTATUS pfnfcis, [In] PFNFCIGETOPENINFO pfnfcigoi, TCOMP typeCompress);

	/// <summary>The <c>FCICreate</c> function creates an FCI context.</summary>
	/// <param name="perf">Pointer to an ERF structure that receives the error information.</param>
	/// <param name="pfnfcifp">
	/// Pointer to an application-defined callback function to notify when a file is placed in the cabinet. The function should be
	/// declared using the FNFCIFILEPLACED macro.
	/// </param>
	/// <param name="pfna">
	/// Pointer to an application-defined callback function to allocate memory. The function should be declared using the FNFCIALLOC macro.
	/// </param>
	/// <param name="pfnf">
	/// Pointer to an application-defined callback function to free previously allocated memory. The function should be delcared using
	/// the FNFCIFREE macro.
	/// </param>
	/// <param name="pfnopen">
	/// Pointer to an application-defined callback function to open a file. The function should be declared using the FNFCIOPEN macro.
	/// </param>
	/// <param name="pfnread">
	/// Pointer to an application-defined callback function to read data from a file. The function should be declared using the
	/// FNFCIREAD macro.
	/// </param>
	/// <param name="pfnwrite">
	/// Pointer to an application-defined callback function to write data to a file. The function should be declared using the
	/// FNFCIWRITE macro.
	/// </param>
	/// <param name="pfnclose">
	/// Pointer to an application-defined callback function to close a file. The function should be declared using the FNFCICLOSE macro.
	/// </param>
	/// <param name="pfnseek">
	/// Pointer to an application-defined callback function to move a file pointer to the specific location. The function should be
	/// declared using the FNFCISEEK macro.
	/// </param>
	/// <param name="pfndelete">
	/// Pointer to an application-defined callback function to delete a file. The function should be declared using the FNFCIDELETE macro.
	/// </param>
	/// <param name="pfnfcigtf">
	/// Pointer to an application-defined callback function to retrieve a temporary file name. The function should be declared using the
	/// FNFCIGETTEMPFILE macro.
	/// </param>
	/// <param name="pccab">Pointer to a CCAB structure that contains the parameters for creating a cabinet.</param>
	/// <param name="pv">Pointer to an application-defined value that is passed to callback functions.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns a non- <c>NULL</c> HFCI context pointer; otherwise, <c>NULL</c>.</para>
	/// <para>Extended error information is provided in the ERF structure.</para>
	/// </returns>
	/// <remarks>
	/// FCI supports multiple simultaneous contexts. As a result it is possible to create or extract multiple cabinets at the same time
	/// within the same application. If the application is multithreaded, it is also possible to run a different context in each thread;
	/// however, an application cannot use the same context simultaneously in multiple threads. For example, FCIAddFile cannot be called
	/// from two different threads, using the same FCI context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fcicreate HFCI DIAMONDAPI FCICreate( PERF perf, PFNFCIFILEPLACED
	// pfnfcifp, PFNFCIALLOC pfna, PFNFCIFREE pfnf, PFNFCIOPEN pfnopen, PFNFCIREAD pfnread, PFNFCIWRITE pfnwrite, PFNFCICLOSE pfnclose,
	// PFNFCISEEK pfnseek, PFNFCIDELETE pfndelete, PFNFCIGETTEMPFILE pfnfcigtf, PCCAB pccab, void *pv );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fci.h", MSDNShortId = "bfcea06d-2f09-405c-955c-0f56149148f2")]
	public static extern SafeHFCI FCICreate(ref ERF perf, [In] PFNFCIFILEPLACED pfnfcifp, [In] PFNALLOC pfna, [In] PFNFREE pfnf,
		[In] PFNFCIOPEN pfnopen, [In] PFNFCIREAD pfnread, [In] PFNFCIWRITE pfnwrite, [In] PFNFCICLOSE pfnclose, [In] PFNFCISEEK pfnseek,
		[In] PFNFCIDELETE pfndelete, [In] PFNFCIGETTEMPFILE pfnfcigtf, in CCAB pccab, [In, Optional] IntPtr pv);

	/// <summary>
	/// The <c>FCIDestroy</c> function deletes an open FCI context, freeing any memory and temporary files associated with the context.
	/// </summary>
	/// <param name="hfci">A valid FCI context handle returned by the FCICreate function.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>; otherwise, <c>FALSE</c>.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FCI context.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fcidestroy BOOL DIAMONDAPI FCIDestroy( HFCI hfci );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fci.h", MSDNShortId = "bb1a6294-664f-450f-b8ec-d6f8957d920e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FCIDestroy([In] HFCI hfci);

	/// <summary>The <c>FCIFlushCabinet</c> function completes the current cabinet.</summary>
	/// <param name="hfci">A valid FCI context handle returned by theFCICreate function.</param>
	/// <param name="fGetNextCab">Specifies whether the function pointed to by the supplied GetNextCab parameter will be called.</param>
	/// <param name="pfnfcignc">
	/// Pointer to an application-defined callback function to obtain specifications on the next cabinet to create. The function should
	/// be declared using the FNFCIGETNEXTCABINET macro.
	/// </param>
	/// <param name="pfnfcis">
	/// Pointer to an application-defined callback function to update the user. The function should be declared using the FNFCISTATUS macro.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>; otherwise, <c>FALSE</c>.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FCI context.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>FCIFlushCabinet</c> API forces the current cabinet under construction to be completed immediately and then written to
	/// disk. Further calls to FCIAddFile will result in files being added to another cabinet.
	/// </para>
	/// <para>
	/// In the event the current cabinet has reached the application-specified media size limit, the pending data within an FCI's
	/// internal buffers will be placed into another cabinet.
	/// </para>
	/// <para>
	/// The fGetNextCab flag determines whether the function pointed to by the GetNextCab parameter will be called. If fGetNextCab is
	/// set <c>TRUE</c>, GetNextCab is called to obtain continuation information. If <c>FALSE</c>, then GetNextCab is called only in the
	/// event the cabinet overflows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fciflushcabinet BOOL DIAMONDAPI FCIFlushCabinet( HFCI hfci, BOOL
	// fGetNextCab, PFNFCIGETNEXTCABINET pfnfcignc, PFNFCISTATUS pfnfcis );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fci.h", MSDNShortId = "dc586260-180e-4a6b-accf-2ddd62ac1335")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FCIFlushCabinet([In] HFCI hfci, [MarshalAs(UnmanagedType.Bool)] bool fGetNextCab, [In] PFNFCIGETNEXTCABINET pfnfcignc, [In] PFNFCISTATUS pfnfcis);

	/// <summary>The <c>FCIFlushFolder</c> function forces the current folder under construction to be completed immediately.</summary>
	/// <param name="hfci">A valid FCI context handle returned by the FCICreate function.</param>
	/// <param name="pfnfcignc">
	/// Pointer to an application-defined callback function to obtain specifications on the next cabinet to create. The function should
	/// be declared using the FNFCIGETNEXTCABINET macro.
	/// </param>
	/// <param name="pfnfcis">
	/// Pointer to an application-defined callback function to update the user. The function should be declared using the FNFCISTATUS macro.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>; otherwise, FASLE.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FCI context.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>FCIFlushFolder</c> API forces the folder currently under construction to be completed immediately; effectively resetting
	/// the compression history if a compression method is in use.
	/// </para>
	/// <para>
	/// The callback function indicated by GetNextCab will be called if the cabinet overflows, which occurs if the pending data buffered
	/// inside an FCI causes the application-specified cabinet media size to be exceeded.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/nf-fci-fciflushfolder BOOL DIAMONDAPI FCIFlushFolder( HFCI hfci,
	// PFNFCIGETNEXTCABINET pfnfcignc, PFNFCISTATUS pfnfcis );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fci.h", MSDNShortId = "dc9c226e-e309-48c3-9edb-3f0a040c0c18")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FCIFlushFolder([In] HFCI hfci, [In] PFNFCIGETNEXTCABINET pfnfcignc, [In] PFNFCISTATUS pfnfcis);

	/// <summary>The <c>CCAB</c> structure contains cabinet information.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fci/ns-fci-ccab typedef struct { ULONG cb; ULONG cbFolderThresh; UINT
	// cbReserveCFHeader; UINT cbReserveCFFolder; UINT cbReserveCFData; int iCab; int iDisk; int fFailOnIncompressible; USHORT setID;
	// char szDisk[CB_MAX_DISK_NAME]; char szCab[CB_MAX_CABINET_NAME]; char szCabPath[CB_MAX_CAB_PATH]; } CCAB;
	[PInvokeData("fci.h", MSDNShortId = "e25cb72b-4c96-40e9-9fd5-2920e4a01d3a")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CCAB
	{
		/// <summary>The maximum size, in bytes, of a cabinet created by FCI.</summary>
		public uint cb;

		/// <summary>The maximum size, in bytes, that a folder will contain before a new folder is created.</summary>
		public uint cbFolderThresh;

		/// <summary>The size, in bytes, of the CFHeader reserve area. Possible value range is 0-255.</summary>
		public uint cbReserveCFHeader;

		/// <summary>The size, in bytes, of the CFFolder reserve area. Possible value range is 0-255.</summary>
		public uint cbReserveCFFolder;

		/// <summary>The size, in bytes, of the CFData reserve area. Possible value range is 0-255.</summary>
		public uint cbReserveCFData;

		/// <summary>The number of created cabinets.</summary>
		public int iCab;

		/// <summary>The number of disks.</summary>
		public int iDisk;

		/// <summary>TRUE if fail if a block is incompressible.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fFailOnIncompressible;

		/// <summary>A value that represents the association between a collection of linked cabinet files.</summary>
		public ushort setID;

		/// <summary>The name of the disk on which the cabinet is placed.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CB_MAX_DISK_NAME)]
		public string szDisk;

		/// <summary>The name of the cabinet.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CB_MAX_CABINET_NAME)]
		public string szCab;

		/// <summary>The full path that indicates where to create the cabinet.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CB_MAX_CAB_PATH)]
		public string szCabPath;

		/// <summary>Initializes a new instance of the <see cref="CCAB"/> struct.</summary>
		/// <param name="cabFullPath">The full path to the cabinet to create.</param>
		/// <param name="setId">A value that represents the association between a collection of linked cabinet files.</param>
		/// <param name="disk">The number of disks.</param>
		/// <param name="maxSize">The maximum size, in bytes, of a cabinet created by FCI.</param>
		public CCAB(string cabFullPath, ushort setId = 1, int disk = 1, uint maxSize = CB_MAX_DISK)
		{
			cb = cbFolderThresh = maxSize;
			setID = setId;
			iDisk = disk;
			cbReserveCFData = cbReserveCFFolder = cbReserveCFHeader = 0;
			iCab = 0;
			fFailOnIncompressible = false;
			szDisk = string.Empty;
			szCab = Path.GetFileName(cabFullPath);
			szCabPath = Path.GetDirectoryName(cabFullPath) ?? throw new DirectoryNotFoundException();
			if (szCabPath[szCabPath.Length - 1] != Path.DirectorySeparatorChar)
				szCabPath += Path.DirectorySeparatorChar;
		}
	}

	/// <summary>Provides a handle to a file compression interface.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFCI : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFCI"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFCI(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFCI"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFCI NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HFCI"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFCI h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFCI"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFCI(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFCI h1, HFCI h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFCI h1, HFCI h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HFCI h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HFCI"/> that is disposed using <see cref="FCIDestroy"/>.</summary>
	public class SafeHFCI : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHFCI"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHFCI(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHFCI"/> class.</summary>
		private SafeHFCI() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHFCI"/> to <see cref="HFCI"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFCI(SafeHFCI h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => FCIDestroy(handle);
	}
}