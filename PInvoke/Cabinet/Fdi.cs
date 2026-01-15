using System.IO;

namespace Vanara.PInvoke;

/// <summary>Items from the cabinet.dll</summary>
public static partial class Cabinet
{
	/// <summary>
	/// The <c>FNCLOSE</c> macro provides the declaration for the application-defined callback function to close a file in an FDI context.
	/// </summary>
	/// <param name="hf">The file handle.</param>
	/// <returns>Returns 0 if the file was successfully closed. A return value of –1 indicates an error.</returns>
	/// <remarks>The function accepts parameters similar to _close.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fnclose
	[PInvokeData("fdi.h", MSDNShortId = "89db9c2a-42ab-410d-a427-60d282385c2b")]
	public delegate int PFNCLOSE(IntPtr hf);

	/// <summary>Undocumented.</summary>
	/// <param name="pfdid">The FDIDECRYPT structure.</param>
	/// <returns>Undocumented</returns>
	[PInvokeData("fdi.h")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate int PFNFDIDECRYPT(ref FDIDECRYPT pfdid);

	/// <summary>
	/// The <c>FNFDINOTIFY</c> macro provides the declaration for the application-defined callback notification function to update the
	/// application on the status of the decoder.
	/// </summary>
	/// <param name="fdint">The notification type.</param>
	/// <param name="pfdin">The FDINOTIFICATION structure.</param>
	/// <returns>Success returns 1; Failure returns 0; -1 if FDICopy() is aborted.</returns>
	/// <remarks>
	/// If this function is passed on the FDICopy() call, then FDI calls it at various times to update the decryption state and to
	/// decrypt FCDATA blocks.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fnfdinotify
	[PInvokeData("fdi.h", MSDNShortId = "7655ddb2-7cd4-4012-913c-9909fcea639a")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate IntPtr PFNFDINOTIFY(FDINOTIFICATIONTYPE fdint, ref FDINOTIFICATION pfdin);

	/// <summary>
	/// The <c>FNOPEN</c> macro provides the declaration for the application-defined callback function to open a file in an FDI context.
	/// </summary>
	/// <param name="pszFile">File name.</param>
	/// <param name="oflag">The kind of operations allowed.</param>
	/// <param name="pmode">Permission mode.</param>
	/// <returns>Return value is file handle of open file to read, or INVALID_FILE_HANDLE on failure.</returns>
	/// <remarks>The function accepts parameters similar to _open.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fnopen
	[PInvokeData("fdi.h", MSDNShortId = "45bd2d23-1f6d-42a6-8afb-86227da6118f")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate IntPtr PFNOPEN(string pszFile, RunTimeLib.FileOpConstant oflag, RunTimeLib.FilePermissionConstant pmode);

	/// <summary>
	/// The <c>FNREAD</c> macro provides the declaration for the application-defined callback function to read data from a file in an
	/// FDI context.
	/// </summary>
	/// <param name="hf">File descriptor referring to the open file.</param>
	/// <param name="memory">Storage location for data.</param>
	/// <param name="cb">Maximum number of bytes to read.</param>
	/// <returns>returns the number of bytes read</returns>
	/// <remarks>The function accepts parameters similar to _read.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fnread
	[PInvokeData("fdi.h", MSDNShortId = "0a8c6c9f-051c-43a0-b43b-1fd8b4fef10c")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate uint PFNREAD(IntPtr hf, [Out] IntPtr memory, uint cb);

	/// <summary>
	/// The <c>FNSEEK</c> macro provides the declaration for the application-defined callback function to move a file pointer to the
	/// specified location in an FDI context.
	/// </summary>
	/// <param name="hf">File descriptor referring to an open file.</param>
	/// <param name="dist">Number of bytes from origin.</param>
	/// <param name="seektype">Initial position..</param>
	/// <returns>returns the offset, in bytes, of the new position from the beginning of the file.</returns>
	/// <remarks>The function accepts parameters similar to _lseek.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fnseek
	[PInvokeData("fdi.h", MSDNShortId = "e49b5086-6b89-40ce-b6fa-905d21593dec")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate int PFNSEEK(IntPtr hf, int dist, SeekOrigin seektype);

	/// <summary>
	/// The <c>FNWRITE</c> macro provides the declaration for the application-defined callback function to write data to a file in an
	/// FDI context.
	/// </summary>
	/// <param name="hf">File descriptor of file into which data is written.</param>
	/// <param name="memory">Data to be written.</param>
	/// <param name="cb">Number of bytes.</param>
	/// <returns>returns the number of bytes actually written.</returns>
	/// <remarks>The function accepts parameters similar to _write.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fnwrite
	[PInvokeData("fdi.h", MSDNShortId = "e15d4293-2955-48cd-b8c9-77669a1e6436")]
	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate uint PFNWRITE(IntPtr hf, [In] IntPtr memory, uint cb);

	/// <summary>Specifies the CPU type.</summary>
	[PInvokeData("fdi.h")]
	public enum FDICPU
	{
		/// <summary>FDI should determine the CPU type.</summary>
		cpuUNKNOWN = -1,

		/// <summary>Only 80286 instructions can be used.</summary>
		cpu80286 = 0,

		/// <summary>80386 instructions can be used.</summary>
		cpu80386 = 1
	}

	/// <summary/>
	[PInvokeData("fdi.h")]
	public enum FDIDECRYPTTYPE
	{
		/// <summary>New cabinet</summary>
		fdidtNEW_CABINET,                   // New cabinet

		/// <summary>New folder</summary>
		fdidtNEW_FOLDER,                    // New folder

		/// <summary>Decrypt a data block</summary>
		fdidtDECRYPT,                       // Decrypt a data block
	}

	/// <summary>An FDI error code.</summary>
	[PInvokeData("fdi.h")]
	public enum FDIERROR
	{
		/// <summary>
		/// Description: No error
		/// Cause:       Function was successfull.
		/// Response:    Keep going!
		/// </summary>
		FDIERROR_NONE,

		/// <summary>
		/// Description: Cabinet not found
		/// Cause:       Bad file name or path passed to FDICopy(), or returned to fdintNEXT_CABINET.
		/// Response:    To prevent this error, validate the existence of the the cabinet *before* passing the path to FDI.
		/// </summary>
		FDIERROR_CABINET_NOT_FOUND,

		/// <summary>
		/// Description: Cabinet file does not have the correct format
		/// Cause:       File passed to to FDICopy(), or returned to fdintNEXT_CABINET, is too small to be a cabinet file, or does not
		/// have the cabinet signature in its first four bytes.
		/// Response:    To prevent this error, call FDIIsCabinet() to check a cabinet before calling FDICopy() or returning the cabinet
		/// path to fdintNEXT_CABINET.
		/// </summary>
		FDIERROR_NOT_A_CABINET,

		/// <summary>
		/// Description: Cabinet file has an unknown version number.
		/// Cause:       File passed to to FDICopy(), or returned to fdintNEXT_CABINET, has what looks like a cabinet file header, but
		/// the version of the cabinet file format is not one understood by this version of FDI. The erf.erfType field is filled in with
		/// the version number found in the cabinet file.
		/// Response:    To prevent this error, call FDIIsCabinet() to check a cabinet before calling FDICopy() or returning the cabinet
		/// path to fdintNEXT_CABINET.
		/// </summary>
		FDIERROR_UNKNOWN_CABINET_VERSION,

		/// <summary>
		/// Description: Cabinet file is corrupt
		/// Cause:       FDI returns this error any time it finds a problem with the logical format of a cabinet file, and any time one
		/// of the passed-in file I/O calls fails when operating on a cabinet (PFNOPEN, PFNSEEK, PFNREAD, or PFNCLOSE). The client can
		/// distinguish these two cases based upon whether the last file I/O call failed or not.
		/// Response:    Assuming this is not a real corruption problem in a cabinet file, the file I/O functions could attempt to do
		/// retries on failure (for example, if there is a temporary network connection problem). If this does not work, and the file
		/// I/O call has to fail, then the FDI client will have to clean up and call the FDICopy() function again.
		/// </summary>
		FDIERROR_CORRUPT_CABINET,

		/// <summary>
		/// Description: Could not allocate enough memory
		/// Cause:       FDI tried to allocate memory with the PFNALLOC function, but it failed.
		/// Response:    If possible, PFNALLOC should take whatever steps are possible to allocate the memory requested. If memory is not
		/// immediately available, it might post a dialog asking the user to free memory, for example. Note that the bulk of FDI's
		/// memory allocations are made at FDICreate() time and when the first cabinet file is opened during FDICopy().
		/// </summary>
		FDIERROR_ALLOC_FAIL,

		/// <summary>
		/// Description: Unknown compression type in a cabinet folder
		/// Cause:       [Should never happen.] A folder in a cabinet has an unknown compression type. This is probably caused by a
		/// mismatch between the version of Diamond used to create the cabinet and the FDI. LIB used to read the cabinet.
		/// Response:    Abort.
		/// </summary>
		FDIERROR_BAD_COMPR_TYPE,

		/// <summary>
		/// Description: Failure decompressing data from a cabinet file
		/// Cause:       The decompressor found an error in the data coming from the file cabinet. The cabinet file was corrupted.
		/// [11-Apr-1994 bens When checksuming is turned on, this error should never occur.]
		/// Response:    Probably should abort; only other choice is to cleanup and call FDICopy() again, and hope there was some
		/// intermittent data error that will not reoccur.
		/// </summary>
		FDIERROR_MDI_FAIL,

		/// <summary>
		/// Description: Failure writing to target file
		/// Cause:       FDI returns this error any time it gets an error back from one of the passed-in file I/O calls fails when
		/// writing to a file being extracted from a cabinet.
		/// Response:    To avoid or minimize this error, the file I/O functions could attempt to avoid failing. A common cause might be
		/// disk full -- in this case, the PFNWRITE function could have a check for free space, and put up a dialog asking the user to
		/// free some disk space.
		/// </summary>
		FDIERROR_TARGET_FILE,

		/// <summary>
		/// Description: Cabinets in a set do not have the same RESERVE sizes
		/// Cause:       [Should never happen]. FDI requires that the sizes of the per-cabinet, per-folder, and per-data block RESERVE
		/// sections be consistent across all the cabinet in a set. Diamond will only generate cabinet sets with these properties.
		/// Response:    Abort.
		/// </summary>
		FDIERROR_RESERVE_MISMATCH,

		/// <summary>
		/// Description: Cabinet returned on fdintNEXT_CABINET is incorrect
		/// Cause:       NOTE: THIS ERROR IS NEVER RETURNED BY FDICopy()! Rather, FDICopy() keeps calling the fdintNEXT_CABINET callback
		/// until either the correct cabinet is specified, or you return ABORT. When FDICopy() is extracting a file that crosses a
		/// cabinet boundary, it calls fdintNEXT_CABINET to ask for the path to the next cabinet. Not being very trusting, FDI then
		/// checks to make sure that the correct continuation cabinet was supplied! It does this by checking the "setID" and "iCabinet"
		/// fields in the cabinet. When DIAMOND.EXE creates a set of cabinets, it constructs the "setID" using the sum of the bytes of
		/// all the destination file names in the cabinet set. FDI makes sure that the 16-bit setID of the continuation cabinet matches
		/// the cabinet file just processed. FDI then checks that the cabinet number (iCabinet) is one more than the cabinet number for
		/// the cabinet just processed.
		/// Response:    You need code in your fdintNEXT_CABINET (see below) handler to do retries if you get recalled with this error.
		/// See the sample code (EXTRACT.C) to see how this should be handled.
		/// </summary>
		FDIERROR_WRONG_CABINET,

		/// <summary>
		/// Description: FDI aborted.
		/// Cause:       An FDI callback returned -1 (usually).
		/// Response:    Up to client.
		/// </summary>
		FDIERROR_USER_ABORT,

		/// <summary>
		/// Description: Unexpected end of file.
		/// Cause:       This error may be returned instead of FDIERROR_CORRUPT_CABINET if PFNREAD returned 0.
		/// Response:    See FDIERROR_CORRUPT_CABINET above.
		/// </summary>
		FDIERROR_EOF,
	}

	/// <summary>Types for PFNFDINOTIFY</summary>
	[PInvokeData("fdi.h", MSDNShortId = "6ec2b10b-f70a-4a22-beff-df6b6a4c4cfd")]
	public enum FDINOTIFICATIONTYPE
	{
		/// <summary>
		/// <para>General information about the cabinet.</para>
		/// <para>When this value is set, the FDINOTIFICATION structure is populated with the following information:</para>
		/// <list type="bullet">
		/// <item>psz1 will point to the name of the next cabinet (excluding path information)</item>
		/// <item>psz2 will point to the name of the next disk</item>
		/// <item>psz3 will point to the cabinet path name</item>
		/// <item>setID will equal the set ID of the current cabinet</item>
		/// <item>
		/// iCabinet will equal the cabinet number within the cabinet set (0 for the first cabinet, 1 for the second cabinet, etc.)
		/// </item>
		/// </list>
		/// <para>
		/// The application should return 0 to indicate success, or -1 to indicate failure, which will abort FDICopy. An
		/// fdintCABINET_INFO notification will be provided once for each cabinet opened by FDICopy; this includes continuation cabinets
		/// opened due to files spanning cabinet boundaries.
		/// </para>
		/// </summary>
		fdintCABINET_INFO,

		/// <summary>
		/// <para>First file in the cabinet is a continuation of a file from previous cabinet.</para>
		/// <para>When this value is set, the FDINOTIFICATION structure is populated with the following information:</para>
		/// <list type="bullet">
		/// <item>psz1 will point to the name of the file continued from a previous cabinet</item>
		/// <item>psz2 will point to the name of the cabinet on which the first segment of the file exists</item>
		/// <item>psz3 will point to the name of the disk on which the first segment of the file exists</item>
		/// </list>
		/// <para>
		/// The fdintPARTIAL_FILE notification is called for files at the beginning of a cabinet that have continued from a previous
		/// cabinet. This notification will occur only when FDICopy is started on the second or subsequent cabinet in a series, which
		/// has files continued from a previous cabinet. The application should return 0 for success, or -1 to indicate failure.
		/// </para>
		/// </summary>
		fdintPARTIAL_FILE,

		/// <summary>
		/// <para>Information identifying the file to be copied.</para>
		/// <para>When this value is set, the FDINOTIFICATION structure is populated with the following information:</para>
		/// <list type="bullet">
		/// <item>psz1 will point to the name of a file in the cabinet</item>
		/// <item>cb will equal the uncompressed size of the file</item>
		/// <item>date will equal the file's 16-bit MS-DOS date</item>
		/// <item>time will equal the file's 16-bit MS-DOS time</item>
		/// <item>attribs will equal the file's 16-bit MS-DOS attributes</item>
		/// </list>
		/// <para>
		/// The application should return one of three values; 0 to skip (i.e. not copy) the file; -1 (negative
		/// one) to abort FDICopy; or a nonzero (and non-negative-one) file handle that indicates where to write the file. The file
		/// handle must be compatible with the PFNCLOSE function supplied to FDICreate. The fdintCOPY_FILE notification is called for
		/// each file that starts within the current cabinet, providing the opportunity for the application to request that the file be
		/// copied or skipped.
		/// </para>
		/// </summary>
		fdintCOPY_FILE,

		/// <summary>
		/// <para>Close the file, set relevant information.</para>
		/// <para>When this value is set, the FDINOTIFICATION structure is populated with the following information:</para>
		/// <list type="bullet">
		/// <item>psz1 will point to the name of a file in the cabinet</item>
		/// <item>hf will be a file handle (which originated from fdintCOPY_FILE)</item>
		/// <item>date date will equal the file's 16-bit MS-DOS date</item>
		/// <item>time time will equal the file's 16-bit MS-DOS time</item>
		/// <item>attribs attributes will equal the file's 16-bit MS-DOS attributes (minus the _A_EXEC bit)</item>
		/// <item>cb will equal either 0 or 1, indicating whether the file should be executed after extract (1), or not (0)</item>
		/// </list>
		/// <para>
		/// It is the responsibility of the application to execute the file if cb equals 1. The fdintCLOSE_FILE_INFO notification is
		/// called after all of the data has been written to a target file. The application must close the file (using the provided hf
		/// handle), and set the file date, time, and attributes. The application should return TRUE for success, and FALSE or -1 to
		/// abort FDICopy. FDI assumes that the target file was closed, even if this callback returns failure; FDI will not attempt to
		/// use PFNCLOSE to close the file.
		/// </para>
		/// </summary>
		fdintCLOSE_FILE_INFO,

		/// <summary>
		/// <para>File continued to next cabinet.</para>
		/// <para>When this value is set, the FDINOTIFICATION structure is populated with the following information:</para>
		/// <list type="bullet">
		/// <item>psz1 will point to the name of the next cabinet on which the current file is continued</item>
		/// <item>psz2 will be a file handle (which originated from fdintCOPY_FILE)</item>
		/// <item>psz3 will point to the cabinet path information</item>
		/// <item>fdie will equal a success or error value</item>
		/// </list>
		/// <para>
		/// This notification is called only if fdintCOPY_FILE is instructed to copy a file, which is continued from a subsequent
		/// cabinet, to the current cabinet . Since it is possible for the application to modify the cabinet name, it is important that
		/// the cabinet path name, indicated by psz3, be validated before it is returned. Additionally, the application should ensure
		/// that the cabinet exists and is readable before returning; if necessary, the application should issue a disk change prompt to confirm.
		/// </para>
		/// <para>
		/// When this function returns to FDI, FDI will verify that the setID and iCabinet fields of the supplied cabinet match the
		/// expected values for that cabinet. If not, FDI will continue to send fdintNEXT_CABINET notification messages with the fdie
		/// field set to FDIERROR_WRONG_CABINET, until the correct cabinet file is specified, or until this function returns -1 and
		/// aborts the FDICopy call. If, after returning from this function, the cabinet file is not present, readable, or has been
		/// damaged, then the fdie field will equal one of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>FDIERROR_CABINET_NOT_FOUND</item>
		/// <item>FDIERROR_NOT_A_CABINET</item>
		/// <item>FDIERROR_UNKNOWN_CABINET_VERSION</item>
		/// <item>FDIERROR_CORRUPT_CABINET</item>
		/// <item>FDIERROR_BAD_COMPR_TYPE</item>
		/// <item>FDIERROR_RESERVE_MISMATCH</item>
		/// <item>FDIERROR_WRONG_CABINET</item>
		/// </list>
		/// <para>
		/// If there was no error, fdie will equal FDIERROR_NONE. The application should return 0 to indicate success, or -1 to indicate
		/// failure, which will abort FDICopy.
		/// </para>
		/// </summary>
		fdintNEXT_CABINET,

		/// <summary>Enumeration status.</summary>
		fdintENUMERATE,
	}

	/// <summary>The <c>FDICopy</c> function extracts files from cabinets.</summary>
	/// <param name="hfdi">A valid FDI context handle returned by the FDICreate function.</param>
	/// <param name="pszCabinet">
	/// The name of the cabinet file, excluding any path information, from which to extract files. If a file is split over multiple
	/// cabinets, <c>FDICopy</c> allows for subsequent cabinets to be opened.
	/// </param>
	/// <param name="pszCabPath">
	/// <para>The pathname of the cabinet file, but not including the name of the file itself. For example, "C:\MyCabs".</para>
	/// <para>The contents of pszCabinet are appended to pszCabPath to create the full pathname of the cabinet.</para>
	/// </param>
	/// <param name="flags">No flags are currently defined and this parameter should be set to zero.</param>
	/// <param name="pfnfdin">
	/// Pointer to an application-defined callback notification function to update the application on the status of the decoder. The
	/// function should be declared using the FNFDINOTIFY macro.
	/// </param>
	/// <param name="pfnfdid">Decryption function (pass NULL if not used)</param>
	/// <param name="pvUser">Pointer to an application-specified value to pass to the notification function.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>; otherwise, <c>FALSE</c>.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FDI context.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fdicopy BOOL DIAMONDAPI FDICopy( HFDI hfdi, LPSTR pszCabinet,
	// LPSTR pszCabPath, int flags, PFNFDINOTIFY pfnfdin, PFNFDIDECRYPT pfnfdid, void *pvUser );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fdi.h", MSDNShortId = "6ec2b10b-f70a-4a22-beff-df6b6a4c4cfd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FDICopy([In] HFDI hfdi, string pszCabinet, string pszCabPath, [Optional] int flags, [In] PFNFDINOTIFY pfnfdin,
		[In, Optional] PFNFDIDECRYPT? pfnfdid, [In, Optional] IntPtr pvUser);

	/// <summary>The <c>FDICreate</c> function creates an FDI context.</summary>
	/// <param name="pfnalloc">
	/// Pointer to an application-defined callback function to allocate memory. The function should be declared using the FNALLOC macro.
	/// </param>
	/// <param name="pfnfree">
	/// Pointer to an application-defined callback function to free previously allocated memory. The function should be declared using
	/// the FNFREE macro.
	/// </param>
	/// <param name="pfnopen">
	/// Pointer to an application-defined callback function to open a file. The function should be declared using the FNOPEN macro.
	/// </param>
	/// <param name="pfnread">
	/// Pointer to an application-defined callback function to read data from a file. The function should be declared using the FNREAD macro.
	/// </param>
	/// <param name="pfnwrite">
	/// Pointer to an application-defined callback function to write data to a file. The function should be declared using the FNWRITE macro.
	/// </param>
	/// <param name="pfnclose">
	/// Pointer to an application-defined callback function to close a file. The function should be declared using the FNCLOSE macro.
	/// </param>
	/// <param name="pfnseek">
	/// Pointer to an application-defined callback function to move a file pointer to the specified location. The function should be
	/// declared using the FNSEEK macro.
	/// </param>
	/// <param name="cpuType">
	/// <para>In the 16-bit version of FDI, specifies the CPU type and can be any of the following values.</para>
	/// <para><c>Note</c> Expressing the <c>cpuUNKNOWN</c> value is recommended.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>cpuUNKNOWN -1</term>
	/// <term>FDI should determine the CPU type.</term>
	/// </item>
	/// <item>
	/// <term>cpu80286 0</term>
	/// <term>Only 80286 instructions can be used.</term>
	/// </item>
	/// <item>
	/// <term>cpu80386 1</term>
	/// <term>80386 instructions can be used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="perf">Pointer to an ERF structure that receives the error information.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns a non- <c>NULL</c> HFDI context pointer; otherwise, it returns <c>NULL</c>.</para>
	/// <para>Extended error information is provided in the ERF structure.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fdicreate HFDI DIAMONDAPI FDICreate( PFNALLOC pfnalloc, PFNFREE
	// pfnfree, PFNOPEN pfnopen, PFNREAD pfnread, PFNWRITE pfnwrite, PFNCLOSE pfnclose, PFNSEEK pfnseek, int cpuType, PERF perf );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fdi.h", MSDNShortId = "90634725-b7a8-4369-8a91-684debee9548")]
	public static extern SafeHFDI FDICreate([In, MarshalAs(UnmanagedType.FunctionPtr)] PFNALLOC pfnalloc,
		[In, MarshalAs(UnmanagedType.FunctionPtr)] PFNFREE pfnfree,
		[In, MarshalAs(UnmanagedType.FunctionPtr)] PFNOPEN pfnopen,
		[In, MarshalAs(UnmanagedType.FunctionPtr)] PFNREAD pfnread,
		[In, MarshalAs(UnmanagedType.FunctionPtr)] PFNWRITE pfnwrite,
		[In, MarshalAs(UnmanagedType.FunctionPtr)] PFNCLOSE pfnclose,
		[In, MarshalAs(UnmanagedType.FunctionPtr)] PFNSEEK pfnseek, FDICPU cpuType, ref ERF perf);

	/// <summary>The <c>FDIDestroy</c> function deletes an open FDI context.</summary>
	/// <param name="hfdi">A valid FDI context handle returned by the FDICreate function.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>; otherwise, <c>FALSE</c>.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FDI context.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fdidestroy BOOL DIAMONDAPI FDIDestroy( HFDI hfdi );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fdi.h", MSDNShortId = "fe3b8045-a476-4a21-b732-0d4799798faf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FDIDestroy([In] HFDI hfdi);

	/// <summary>
	/// The <c>FDIIsCabinet</c> function determines whether a file is a cabinet and, if it is, returns information about it.
	/// </summary>
	/// <param name="hfdi">A valid FDI context handle returned by FDICreate.</param>
	/// <param name="hf">
	/// An application-defined value to keep track of the opened file. This value must be of the same type as values used by the File
	/// I/O functions passed to FDICreate.
	/// </param>
	/// <param name="pfdici">
	/// Pointer to an FDICABINETINFO structure that receives the cabinet details, in the event the file is actually a cabinet.
	/// </param>
	/// <returns>
	/// <para>If the file is a cabinet, the function returns <c>TRUE</c> ; otherwise, <c>FALSE</c>.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FDI context.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fdiiscabinet BOOL DIAMONDAPI FDIIsCabinet( HFDI hfdi, INT_PTR hf,
	// PFDICABINETINFO pfdici );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fdi.h", MSDNShortId = "01d223ca-56c6-49fa-b9e6-e5eeda88936a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FDIIsCabinet([In] HFDI hfdi, [In] IntPtr hf, out FDICABINETINFO pfdici);

	/// <summary>The <c>FDITruncateCabinet</c> function truncates a cabinet file starting at the specified folder number.</summary>
	/// <param name="hfdi">A valid FDI context handle returned by the FDICreate function.</param>
	/// <param name="pszCabinetName">The full cabinet filename.</param>
	/// <param name="iFolderToDelete">The index of the first folder to delete.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>; otherwise, <c>FALSE</c>.</para>
	/// <para>Extended error information is provided in the ERF structure used to create the FDI context.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/nf-fdi-fditruncatecabinet BOOL DIAMONDAPI FDITruncateCabinet( HFDI hfdi,
	// LPSTR pszCabinetName, USHORT iFolderToDelete );
	[DllImport(Lib.Cabinet, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	[PInvokeData("fdi.h", MSDNShortId = "c923b0a5-1a8d-42aa-bd05-0d318199756d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FDITruncateCabinet([In] HFDI hfdi, string pszCabinetName, ushort iFolderToDelete);

	/// <summary>The <c>FDICABINETINFO</c> structure contains details about a particular cabinet file.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/ns-fdi-__unnamed_struct_0 typedef struct { long cbCabinet; USHORT
	// cFolders; USHORT cFiles; USHORT setID; USHORT iCabinet; BOOL fReserve; BOOL hasprev; BOOL hasnext; } FDICABINETINFO;
	[PInvokeData("fdi.h", MSDNShortId = "fde1a2ca-60cd-4a4d-9872-681e2f8f4fb1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct FDICABINETINFO
	{
		/// <summary>The total length of the cabinet file.</summary>
		public int cbCabinet;

		/// <summary>The count of the folders in the cabinet.</summary>
		public ushort cFolders;

		/// <summary>The count of the files in the cabinet.</summary>
		public ushort cFiles;

		/// <summary>The identifier of the cabinet set.</summary>
		public ushort setID;

		/// <summary>The cabinet number in set. This index is zero based.</summary>
		public ushort iCabinet;

		/// <summary>If this value is set to <c>TRUE</c>, a reserved area is present in the cabinet.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fReserve;

		/// <summary>
		/// If this value is set to <c>TRUE</c>, the cabinet is linked to a previous cabinet. This is accomplished by having a file
		/// continued from the previous cabinet into the current one.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool hasprev;

		/// <summary>
		/// If this value is set to <c>TRUE</c>, the current cabinet is linked to the next cabinet by having a file continued from the
		/// current cabinet into the next one.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool hasnext;
	}

	/// <summary/>
	[PInvokeData("fdi.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct FDIDECRYPT
	{
		///<summary>Command type (selects union below)</summary>
		public FDIDECRYPTTYPE fdidt;

		///<summary>Decryption context</summary>
		public IntPtr pvUser;

		/// <summary/>
		public Union union;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct Union
		{
			/// <summary/>
			[FieldOffset(0)]
			public NEW_CABINET cabinet;

			/// <summary/>
			[FieldOffset(0)]
			public NEW_FOLDER folder;

			/// <summary/>
			[FieldOffset(0)]
			public DECRYPT decrypt;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct NEW_CABINET
		{
			///<summary>RESERVE section from CFHEADER</summary>
			public IntPtr pHeaderReserve;

			///<summary>Size of pHeaderReserve</summary>
			public ushort cbHeaderReserve;

			///<summary>Cabinet set ID</summary>
			public ushort setID;

			///<summary>Cabinet number in set (0 based)</summary>
			public int iCabinet;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct NEW_FOLDER
		{
			///<summary>RESERVE section from CFFOLDER</summary>
			public IntPtr pFolderReserve;

			///<summary>Size of pFolderReserve</summary>
			public ushort cbFolderReserve;

			///<summary>Folder number in cabinet (0 based)</summary>
			public ushort iFolder;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct DECRYPT
		{
			///<summary>RESERVE section from CFDATA</summary>
			public IntPtr pDataReserve;

			///<summary>Size of pDataReserve</summary>
			public ushort cbDataReserve;

			///<summary>Data buffer</summary>
			public IntPtr pbData;

			///<summary>Size of data buffer</summary>
			public ushort cbData;

			///<summary>TRUE if this is a split data block</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fSplit;

			///<summary>0 if this is not a split block, or the first piece of a split block; Greater than 0 if this is the second piece of a split block.</summary>
			public ushort cbPartial;
		}
	}

	/// <summary>The <c>FDINOTIFICATION</c> structure to provide information to FNFDINOTIFY.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/fdi/ns-fdi-fdinotification typedef struct { long cb; char *psz1; char *psz2;
	// char *psz3; void *pv; INT_PTR hf; USHORT date; USHORT time; USHORT attribs; USHORT setID; USHORT iCabinet; USHORT iFolder;
	// FDIERROR fdie; } FDINOTIFICATION, *PFDINOTIFICATION;
	[PInvokeData("fdi.h", MSDNShortId = "8b92226e-b19a-4624-925e-4a98d037637d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct FDINOTIFICATION
	{
		/// <summary>The size, in bytes, of a cabinet element.</summary>
		public int cb;

		/// <summary>A null-terminated string.</summary>
		public Vanara.InteropServices.LPSTR psz1;

		/// <summary>A null-terminated string.</summary>
		public IntPtr psz2;

		/// <summary>A null-terminated string.</summary>
		public Vanara.InteropServices.LPSTR psz3;

		/// <summary>Pointer to an application-defined value.</summary>
		public IntPtr pv;

		/// <summary>Application-defined value used to identify the opened file.</summary>
		public IntPtr hf;

		/// <summary>
		/// <para>The MS-DOS date.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0-4</term>
		/// <term>Day of the month (1-31)</term>
		/// </item>
		/// <item>
		/// <term>5-8</term>
		/// <term>Month (1 = January, 2 = February, etc.)</term>
		/// </item>
		/// <item>
		/// <term>9-15</term>
		/// <term>Year offset from 1980 (add 1980</term>
		/// </item>
		/// </list>
		/// </summary>
		public ushort date;

		/// <summary>
		/// <para>The MS-DOS time.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0-4</term>
		/// <term>Second divided by 2</term>
		/// </item>
		/// <item>
		/// <term>5-10</term>
		/// <term>Minute (0-59)</term>
		/// </item>
		/// <item>
		/// <term>11-15</term>
		/// <term>Hour (0-23 on a 24-hour clock)</term>
		/// </item>
		/// </list>
		/// </summary>
		public ushort time;

		/// <summary>The file attributes. For possible values and their descriptions, see File Attributes.</summary>
		public ushort attribs;

		/// <summary>The identifier for a cabinet set.</summary>
		public ushort setID;

		/// <summary>The number of the cabinets within a set.</summary>
		public ushort iCabinet;

		/// <summary>The number of folders within a cabinet.</summary>
		public ushort iFolder;

		/// <summary>
		/// <para>An FDI error code. Possible values include:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FDIERROR_NONE 0x00</term>
		/// <term>No error.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_CABINET_NOT_FOUND 0x01</term>
		/// <term>The cabinet file was not found.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_NOT_A_CABINET 0x02</term>
		/// <term>The cabinet file does not have the correct format.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_UNKNOWN_CABINET_VERSION 0x03</term>
		/// <term>The cabinet file has an unknown version number.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_CORRUPT_CABINET 0x04</term>
		/// <term>The cabinet file is corrupt.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_ALLOC_FAIL 0x05</term>
		/// <term>Insufficient memory.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_BAD_COMPR_TYPE 0x06</term>
		/// <term>Unknown compression type used in the cabinet folder.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_MDI_FAIL 0x07</term>
		/// <term>Failure decompressing data from the cabinet file.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_TARGET_FILE 0x08</term>
		/// <term>Failure writing to the target file.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_RESERVE_MISMATCH 0x09</term>
		/// <term>The cabinets within a set do not have the same RESERVE sizes.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_WRONG_CABINET 0x0A</term>
		/// <term>The cabinet returned by fdintNEXT_CABINET is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>FDIERROR_USER_ABORT 0x0B</term>
		/// <term>FDI aborted.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FDIERROR fdie;

		/// <summary>The file attributes.</summary>
		public FileFlagsAndAttributes Attributes => (FileFlagsAndAttributes)attribs;

		/// <summary>Gets the date and time.</summary>
		/// <value>The date and time value.</value>
		public DateTime DateTime
		{
			get
			{
				return new(BitHelper.GetBits(date, 9, 7) + 1980, GetValidBits(date, 5, 4, 1, 12, 1), GetValidBits(date, 0, 5, 1, 31, 1),
					GetValidBits(time, 11, 5, 0, 23, 0), GetValidBits(time, 5, 6, 0, 59, 0), GetValidBits(time, 0, 5, 0, 29, 0) * 2, DateTimeKind.Local);

				static ushort GetValidBits(ushort bits, byte start, byte len, ushort low, ushort high, ushort def)
				{
					var ret = BitHelper.GetBits(bits, start, len);
					return ret < low || ret > high ? def : ret;
				}
			}
		}
	}
}