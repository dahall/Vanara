using System.IO;

namespace Vanara.PInvoke;

/// <summary>Functions and structures from Lz32.dll</summary>
public static partial class Lz32
{
	private const string Lib_Lz32 = "lz32.dll";

	/// <summary>Style flags for <see cref="LZOpenFile"/>.</summary>
	[PInvokeData("WinBase.h", MSDNShortId = "aa365430")]
	[Flags]
	public enum LZ_OF : ushort
	{
		/// <summary>
		/// Ignored.
		/// <para>To produce a dialog box containing a Cancel button, use OF_PROMPT.</para>
		/// </summary>
		OF_CANCEL = 0x00000800,

		/// <summary>
		/// Creates a new file.
		/// <para>If the file exists, it is truncated to zero (0) length.</para>
		/// </summary>
		OF_CREATE = 0x00001000,

		/// <summary>Deletes a file.</summary>
		OF_DELETE = 0x00000200,

		/// <summary>
		/// Opens a file and then closes it.
		/// <para>Use this to test for the existence of a file.</para>
		/// </summary>
		OF_EXIST = 0x00004000,

		/// <summary>Fills the OFSTRUCT structure, but does not do anything else.</summary>
		OF_PARSE = 0x00000100,

		/// <summary>
		/// Displays a dialog box if a requested file does not exist.
		/// <para>
		/// A dialog box informs a user that the system cannot find a file, and it contains Retry and Cancel buttons. The Cancel button
		/// directs OpenFile to return a file-not-found error message.
		/// </para>
		/// </summary>
		OF_PROMPT = 0x00002000,

		/// <summary>Opens a file for reading only.</summary>
		OF_READ = 0x00000000,

		/// <summary>Opens a file with read/write permissions.</summary>
		OF_READWRITE = 0x00000002,

		/// <summary>Opens a file by using information in the reopen buffer.</summary>
		OF_REOPEN = 0x00008000,

		/// <summary>
		/// For MS-DOS–based file systems, opens a file with compatibility mode, allows any process on a specified computer to open the
		/// file any number of times.
		/// <para>
		/// Other efforts to open a file with other sharing modes fail. This flag is mapped to the FILE_SHARE_READ|FILE_SHARE_WRITE
		/// flags of the CreateFile function.
		/// </para>
		/// </summary>
		OF_SHARE_COMPAT = 0x00000000,

		/// <summary>
		/// Opens a file without denying read or write access to other processes.
		/// <para>
		/// On MS-DOS-based file systems, if the file has been opened in compatibility mode by any other process, the function fails.
		/// </para>
		/// <para>This flag is mapped to the FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.</para>
		/// </summary>
		OF_SHARE_DENY_NONE = 0x00000040,

		/// <summary>
		/// Opens a file and denies read access to other processes.
		/// <para>
		/// On MS-DOS-based file systems, if the file has been opened in compatibility mode, or for read access by any other process,
		/// the function fails.
		/// </para>
		/// <para>This flag is mapped to the FILE_SHARE_WRITE flag of the CreateFile function.</para>
		/// </summary>
		OF_SHARE_DENY_READ = 0x00000030,

		/// <summary>
		/// Opens a file and denies write access to other processes.
		/// <para>
		/// On MS-DOS-based file systems, if a file has been opened in compatibility mode, or for write access by any other process, the
		/// function fails.
		/// </para>
		/// <para>This flag is mapped to the FILE_SHARE_READ flag of the CreateFile function.</para>
		/// </summary>
		OF_SHARE_DENY_WRITE = 0x00000020,

		/// <summary>
		/// Opens a file with exclusive mode, and denies both read/write access to other processes. If a file has been opened in any
		/// other mode for read/write access, even by the current process, the function fails.
		/// </summary>
		OF_SHARE_EXCLUSIVE = 0x00000010,

		/// <summary>
		/// Verifies that the date and time of a file are the same as when it was opened previously.
		/// <para>This is useful as an extra check for read-only files.</para>
		/// </summary>
		OF_VERIFY = 0x00000400,

		/// <summary>Opens a file for write access only.</summary>
		OF_WRITE = 0x00000001,
	}

	/// <summary>Return values for LZ functions.</summary>
	[PInvokeData("lzexpand.h")]
	public enum LZERROR : int
	{
		/// <summary>The handle identifying the source file is not valid. The file cannot be read.</summary>
		LZERROR_BADINHANDLE = -1,

		/// <summary>The handle identifying the destination file is not valid. The file cannot be written.</summary>
		LZERROR_BADOUTHANDLE = -2,

		/// <summary>The source file format is not valid.</summary>
		LZERROR_READ = -3,

		/// <summary>There is insufficient space for the output file.</summary>
		LZERROR_WRITE = -4,

		/// <summary>The maximum number of open compressed files has been exceeded or local memory cannot be allocated.</summary>
		LZERROR_GLOBALLOC = -5,

		/// <summary>The LZ file handle cannot be locked down.</summary>
		LZERROR_GLOBLOCK = -6,

		/// <summary>One of the input parameters is not valid.</summary>
		LZERROR_BADVALUE = -7,

		/// <summary>The file is compressed with an unrecognized compression algorithm.</summary>
		LZERROR_UNKNOWNALG = -8,
	}

	/// <summary>Retrieves the original name of a compressed file, if the file was compressed by the Lempel-Ziv algorithm.</summary>
	/// <param name="lpszSource">The name of the compressed file.</param>
	/// <param name="lpszBuffer">A pointer to a buffer that receives the original name of the compressed file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is 1.</para>
	/// <para>
	/// If the function fails, the return value is LZERROR_BADVALUE. There is no extended error information for this function; do not
	/// call GetLastError.
	/// </para>
	/// <para>
	/// <c>Note</c><c>GetExpandedName</c> calls neither SetLastError nor SetLastErrorEx; thus, its failure does not affect a thread's
	/// last-error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The contents of the buffer pointed to by the lpszBuffer parameter is the original file name if the file was compressed by using
	/// the <c>/r</c> option. If the <c>/r</c> option was not used, this function duplicates the name in the lpszSource parameter into
	/// the lpszBuffer buffer.
	/// </para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The lzexpand.h header defines GetExpandedName as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/lzexpand/nf-lzexpand-getexpandednamea INT GetExpandedNameA( LPSTR lpszSource,
	// LPSTR lpszBuffer );
	[DllImport(Lib_Lz32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("lzexpand.h", MSDNShortId = "NF:lzexpand.GetExpandedNameA")]
	public static extern int GetExpandedName([In, MarshalAs(UnmanagedType.LPTStr)] string lpszSource, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszBuffer);

	/// <summary>Closes a file that was opened by using the LZOpenFile function.</summary>
	/// <param name="hFile">A handle to the file to be closed.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The handle identifying the file must be retrieved by calling the LZOpenFile function. If the handle is retrieved by calling the
	/// CreateFile or OpenFile function, an error occurs.
	/// </para>
	/// <para>
	/// If the file has been compressed by the Lempel-Ziv algorithm and opened by using LZOpenFile, <c>LZClose</c> frees any global heap
	/// space that was allocated to expand the file.
	/// </para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>CsvFs will do redirected IO for compressed files.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/lzexpand/nf-lzexpand-lzclose void LZClose( INT hFile );
	[DllImport(Lib_Lz32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lzexpand.h", MSDNShortId = "NF:lzexpand.LZClose")]
	public static extern void LZClose(HLZFILE hFile);

	/// <summary>
	/// Copies a source file to a destination file. If the source file has been compressed by the Lempel-Ziv algorithm, this function
	/// creates a decompressed destination file. If the source file is not compressed, this function duplicates the original file.
	/// </summary>
	/// <param name="hfSource">A handle to the source file.</param>
	/// <param name="hfDest">A handle to the destination file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the size, in bytes, of the destination file.</para>
	/// <para>
	/// If the function fails, the return value is an LZERROR_* code. These codes have values less than zero. Note that <c>LZCopy</c>
	/// calls neither SetLastError nor SetLastErrorEx; thus, its failure does not affect a thread's last-error code.
	/// </para>
	/// <para>The following is a list of error codes that <c>LZCopy</c> can return upon failure.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>LZERROR_BADINHANDLE</term>
	/// <term>The handle identifying the source file is not valid. The file cannot be read.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_BADOUTHANDLE</term>
	/// <term>The handle identifying the destination file is not valid. The file cannot be written.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBALLOC</term>
	/// <term>The maximum number of open compressed files has been exceeded or local memory cannot be allocated.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBLOCK</term>
	/// <term>The LZ file handle cannot be locked down.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_READ</term>
	/// <term>The source file format is not valid.</term>
	/// </item>
	/// </list>
	/// <para>There is no extended error information for this function; do not call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The handles identifying the source and destination files must be retrieved by calling the LZInit or LZOpenFile function.</para>
	/// <para>If the function succeeds, the file identified by the hfDest parameter is always uncompressed.</para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>CsvFs will do redirected IO for compressed files.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/lzexpand/nf-lzexpand-lzcopy LONG LZCopy( INT hfSource, INT hfDest );
	[DllImport(Lib_Lz32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lzexpand.h", MSDNShortId = "NF:lzexpand.LZCopy")]
	public static extern int LZCopy(HLZFILE hfSource, HLZFILE hfDest);

	/// <summary>
	/// Allocates memory for the internal data structures required to decompress files, and then creates and initializes them.
	/// </summary>
	/// <param name="hfSource">A handle to the file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a new LZ file handle.</para>
	/// <para>
	/// If the function fails, the return value is an LZERROR_* code. These codes have values less than zero. Note that <c>LZInit</c>
	/// calls neither SetLastError nor SetLastErrorEx; thus, its failure does not affect a thread's last-error code.
	/// </para>
	/// <para>The following is the list of the error codes that <c>LZInit</c> can return upon failure.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>LZERROR_BADINHANDLE</term>
	/// <term>The handle identifying the source file is not valid. The file cannot be read.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBALLOC</term>
	/// <term>The maximum number of open compressed files has been exceeded or local memory cannot be allocated.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBLOCK</term>
	/// <term>The LZ file handle cannot be locked down.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_UNKNOWNALG</term>
	/// <term>The file is compressed with an unrecognized compression algorithm.</term>
	/// </item>
	/// </list>
	/// <para>There is no extended error information for this function; do not call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A maximum of 16 compressed files can be open at any given time. Similarly, a maximum of 16 uncompressed files can be open at any
	/// given time. An application should be careful to close the handle returned by <c>LZInit</c> when it is done using the file;
	/// otherwise, the application can inadvertently hit the 16-file limit.
	/// </para>
	/// <para>
	/// The handle this function returns is compatible only with the functions in Lz32.dll; it should not be used for other file operations.
	/// </para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>CsvFs will do redirected IO for compressed files.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/lzexpand/nf-lzexpand-lzinit INT LZInit( INT hfSource );
	[DllImport(Lib_Lz32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lzexpand.h", MSDNShortId = "NF:lzexpand.LZInit")]
	public static extern HLZFILE LZInit(/*HFILE*/ int hfSource);

	/// <summary>Creates, opens, reopens, or deletes the specified file.</summary>
	/// <param name="lpFileName">The name of the file.</param>
	/// <param name="lpReOpenBuf">
	/// <para>
	/// A pointer to the OFSTRUCT structure that is to receive information about the file when the file is first opened. The structure
	/// can be used in subsequent calls to the <c>LZOpenFile</c> function to see the open file.
	/// </para>
	/// <para>
	/// The <c>szPathName</c> member of this structure contains characters from the original equipment manufacturer (OEM) character set.
	/// </para>
	/// </param>
	/// <param name="wStyle">
	/// <para>The action to be taken. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OF_CANCEL 0x0800</term>
	/// <term>
	/// Ignored. Provided only for compatibility with 16-bit Windows. Use the OF_PROMPT style to display a dialog box containing a
	/// Cancel button.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_CREATE 0x1000</term>
	/// <term>Directs LZOpenFile to create a new file. If the file already exists, it is truncated to zero length.</term>
	/// </item>
	/// <item>
	/// <term>OF_DELETE 0x0200</term>
	/// <term>Deletes the file.</term>
	/// </item>
	/// <item>
	/// <term>OF_EXIST 0x4000</term>
	/// <term>Opens the file and then closes it to test for a file's existence.</term>
	/// </item>
	/// <item>
	/// <term>OF_PARSE 0x0100</term>
	/// <term>Fills the OFSTRUCT structure but carries out no other action.</term>
	/// </item>
	/// <item>
	/// <term>OF_PROMPT 0x2000</term>
	/// <term>
	/// Displays a dialog box if the requested file does not exist. The dialog box informs the user that the system cannot find the
	/// file, and it contains Retry and Cancel buttons. Clicking the Cancel button directs LZOpenFile to return a file not found error message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_READ 0x0000</term>
	/// <term>Opens the file for reading only.</term>
	/// </item>
	/// <item>
	/// <term>OF_READWRITE 0x0002</term>
	/// <term>Opens the file for reading and writing.</term>
	/// </item>
	/// <item>
	/// <term>OF_REOPEN 0x8000</term>
	/// <term>Opens the file using information in the reopen buffer.</term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_NONE 0x0040</term>
	/// <term>
	/// Opens the file without denying other processes read or write access to the file. LZOpenFile fails if the file has been opened in
	/// compatibility mode by any other process.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_READ 0x0030</term>
	/// <term>
	/// Opens the file and denies other processes read access to the file. LZOpenFile fails if the file has been opened in compatibility
	/// mode or has been opened for read access by any other process.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_WRITE 0x0020</term>
	/// <term>
	/// Opens the file and denies other processes write access to the file. LZOpenFile fails if the file has been opened in
	/// compatibility mode or has been opened for write access by any other process.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_EXCLUSIVE 0x0010</term>
	/// <term>
	/// Opens the file in exclusive mode, denying other processes both read and write access to the file. LZOpenFile fails if the file
	/// has been opened in any other mode for read or write access, even by the current process.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_WRITE 0x0001</term>
	/// <term>Opens the file for writing only.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds and the value specified by the wStyle parameter is not <c>OF_READ</c>, the return value is a handle
	/// identifying the file. If the file is compressed and opened with wStyle set to <c>OF_READ</c>, the return value is a special file handle.
	/// </para>
	/// <para>
	/// If the function fails, the return value is an <c>LZERROR_*</c> code. These codes have values less than zero. There is no
	/// extended error information for this function; do not call GetLastError.
	/// </para>
	/// <para>
	/// <c>Note</c><c>LZOpenFile</c> calls neither SetLastError nor SetLastErrorEx; thus, its failure does not affect a thread's
	/// last-error code.
	/// </para>
	/// <para>The following is the list of the error codes that <c>LZOpenFile</c> can return upon failure.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>LZERROR_BADINHANDLE -1</term>
	/// <term>The handle identifying the source file is not valid. The file cannot be read.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBALLOC -5</term>
	/// <term>The maximum number of open compressed files has been exceeded or local memory cannot be allocated.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the wStyle parameter is the <c>OF_READ</c> flag (or <c>OF_READ</c> and any of the <c>OF_SHARE_*</c> flags) and the file is
	/// compressed, <c>LZOpenFile</c> calls the LZInit function, which performs the required initialization for the decompression operations.
	/// </para>
	/// <para>
	/// The handle this function returns is compatible only with the functions in Lz32.dll; it should not be used for other file operations.
	/// </para>
	/// <para>
	/// If <c>LZOpenFile</c> is unable to open the file specified by lpFileName, on some versions of Windows it attempts to open a file
	/// with almost the same file name, except the last character is replaced with an underscore (""). Thus, if an attempt to open
	/// "MyProgram.exe" fails, <c>LZOpenFile</c> tries to open "MyProgram.ex". Installation packages often substitute the underscore for
	/// the last letter of a file name extension to indicate that the file is compressed. For example, "MyProgram.exe" compressed might
	/// be named "MyProgram.ex_". To determine the name of the file opened (if any), examine the <c>szPathName</c> member of the
	/// OFSTRUCT structure in the lpReOpenBuf parameter.
	/// </para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>CsvFs will do redirected IO for compressed files.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The lzexpand.h header defines LZOpenFile as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/lzexpand/nf-lzexpand-lzopenfilea INT LZOpenFileA( LPSTR lpFileName, LPOFSTRUCT
	// lpReOpenBuf, WORD wStyle );
	[DllImport(Lib_Lz32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("lzexpand.h", MSDNShortId = "NF:lzexpand.LZOpenFileA")]
	public static extern HLZFILE LZOpenFile([In, MarshalAs(UnmanagedType.LPTStr)] string lpFileName, ref OFSTRUCT lpReOpenBuf, LZ_OF wStyle);

	/// <summary>Reads (at most) the specified number of bytes from a file and copies them into a buffer.</summary>
	/// <param name="hFile">A handle to the file.</param>
	/// <param name="lpBuffer">
	/// A pointer to a buffer that receives the bytes read from the file. Ensure that this buffer is larger than cbRead.
	/// </param>
	/// <param name="cbRead">The count of bytes to be read.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the number of bytes read.</para>
	/// <para>
	/// If the function fails, the return value is an LZERROR_* code. These codes have values less than zero. Note that <c>LZRead</c>
	/// calls neither SetLastError nor SetLastErrorEx; thus, its failure does not affect a thread's last-error code.
	/// </para>
	/// <para>The following is the list of error codes that <c>LZRead</c> can return upon failure.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>LZERROR_BADINHANDLE</term>
	/// <term>The handle identifying the source file is not valid. The file cannot be read.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_BADOUTHANDLE</term>
	/// <term>The handle identifying the destination file is not valid. The file cannot be written.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_BADVALUE</term>
	/// <term>One of the input parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBALLOC</term>
	/// <term>The maximum number of open compressed files has been exceeded or local memory cannot be allocated.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBLOCK</term>
	/// <term>The LZ file handle cannot be locked down.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_READ</term>
	/// <term>The source file format is not valid.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_WRITE</term>
	/// <term>There is insufficient space for the output file.</term>
	/// </item>
	/// </list>
	/// <para>There is no extended error information for this function; do not call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The handle identifying the file must be retrieved by calling either the LZInit or LZOpenFile function.</para>
	/// <para>
	/// If the file is compressed, <c>LZRead</c> operates on an expanded image of the file and copies the bytes of data into the
	/// specified buffer.
	/// </para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>CsvFs will do redirected IO for compressed files.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/lzexpand/nf-lzexpand-lzread INT LZRead( INT hFile, CHAR *lpBuffer, INT cbRead );
	[DllImport(Lib_Lz32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lzexpand.h", MSDNShortId = "NF:lzexpand.LZRead")]
	public static extern int LZRead(HLZFILE hFile, [Out] IntPtr lpBuffer, int cbRead);

	/// <summary>Moves a file pointer the specified number of bytes from a starting position.</summary>
	/// <param name="hFile">A handle to the file.</param>
	/// <param name="lOffset">The number of bytes by which to move the file pointer.</param>
	/// <param name="iOrigin">
	/// <para>The starting position of the pointer. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Moves the file pointer lOffset bytes from the beginning of the file.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Moves the file pointer lOffset bytes from the current position.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Moves the file pointer lOffset bytes from the end of the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the offset from the beginning of the file to the new pointer position.</para>
	/// <para>
	/// If the function fails, the return value is an LZERROR_* code. These codes have values less than zero. Note that <c>LZSeek</c>
	/// calls neither SetLastError nor SetLastErrorEx; thus, its failure does not affect a thread's last-error code.
	/// </para>
	/// <para>The following is the list of error codes that <c>LZSeek</c> can return upon failure.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>LZERROR_BADINHANDLE</term>
	/// <term>The handle identifying the source file is not valid. The file cannot be read.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_BADVALUE</term>
	/// <term>One of the parameters is outside the range of acceptable values.</term>
	/// </item>
	/// <item>
	/// <term>LZERROR_GLOBLOCK</term>
	/// <term>The LZ file handle cannot be locked down.</term>
	/// </item>
	/// </list>
	/// <para>There is no extended error information for this function; do not call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The handle identified by the hFile parameter must be retrieved by calling either the LZInit or LZOpenFile function.</para>
	/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Technology</term>
	/// <term>Supported</term>
	/// </listheader>
	/// <item>
	/// <term>Server Message Block (SMB) 3.0 protocol</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 Transparent Failover (TFO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Cluster Shared Volume File System (CsvFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>Resilient File System (ReFS)</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>CsvFs will do redirected IO for compressed files.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/lzexpand/nf-lzexpand-lzseek LONG LZSeek( INT hFile, LONG lOffset, INT iOrigin );
	[DllImport(Lib_Lz32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lzexpand.h", MSDNShortId = "NF:lzexpand.LZSeek")]
	public static extern int LZSeek(HLZFILE hFile, int lOffset, SeekOrigin iOrigin);

	/// <summary>Provides a handle to a compressed file.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HLZFILE : IHandle
	{
		private readonly int handle;

		/// <summary>Initializes a new instance of the <see cref="HLZFILE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="int"/> object that represents the pre-existing handle to use.</param>
		public HLZFILE(int preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HLZFILE"/> object with <c>0</c>.</summary>
		public static HLZFILE NULL => new(0);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == 0;

		/// <summary>Performs an explicit conversion from <see cref="HLZFILE"/> to <see cref="int"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator int(HLZFILE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="HLZFILE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HLZFILE(int h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HLZFILE h1, HLZFILE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HLZFILE h1, HLZFILE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HLZFILE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => (IntPtr)handle;
	}
}