using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>The handle identifying the source file is not valid. The file cannot be read.</summary>
		public const int LZERROR_BADINHANDLE = (-1);

		/// <summary>The handle identifying the destination file is not valid. The file cannot be written.</summary>
		public const int LZERROR_BADOUTHANDLE = (-2);

		/// <summary>One of the parameters is outside the range of acceptable values.</summary>
		public const int LZERROR_BADVALUE = (-7);

		/// <summary>The maximum number of open compressed files has been exceeded or local memory cannot be allocated.</summary>
		public const int LZERROR_GLOBALLOC = (-5);

		/// <summary>The LZ file handle cannot be locked down.</summary>
		public const int LZERROR_GLOBLOCK = (-6);

		/// <summary>The source file format is not valid.</summary>
		public const int LZERROR_READ = (-3);

		/// <summary>The file is compressed with an unrecognized compression algorithm.</summary>
		public const int LZERROR_UNKNOWNALG = (-8);

		/// <summary>There is insufficient space for the output file.</summary>
		public const int LZERROR_WRITE = (-4);

		/// <summary>Retrieves the original name of a compressed file, if the file was compressed by the Lempel-Ziv algorithm.</summary>
		/// <param name="lpszSource">The name of the compressed file.</param>
		/// <param name="lpszBuffer">A pointer to a buffer that receives the original name of the compressed file.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is 1.</para>
		/// <para>
		/// If the function fails, the return value is LZERROR_BADVALUE. There is no extended error information for this function; do not
		/// call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// INT WINAPI GetExpandedName( _In_ LPTSTR lpszSource, _Out_ LPTSTR lpszBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364941(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("LzExpand.h", MSDNShortId = "aa364941")]
		public static extern int GetExpandedName(string lpszSource, StringBuilder lpszBuffer);

		/// <summary>Closes a file that was opened by using the <c>LZOpenFile</c> function.</summary>
		/// <param name="hFile">A handle to the file to be closed.</param>
		/// <returns>This function does not return a value.</returns>
		// void APIENTRY LZClose( _In_ INT hFile); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365221(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("LzExpand.h", MSDNShortId = "aa365221")]
		public static extern void LZClose(int hFile);

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
		/// calls neither <c>SetLastError</c> nor <c>SetLastErrorEx</c>; thus, its failure does not affect a thread's last-error code.
		/// </para>
		/// <para>The following is a list of error codes that <c>LZCopy</c> can return upon failure.</para>
		/// <para>
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
		/// </para>
		/// <para>There is no extended error information for this function; do not call <c>GetLastError</c>.</para>
		/// </returns>
		// LONG WINAPI LZCopy( _In_ INT hfSource, _In_ INT hfDest); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365223(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("LzExpand.h", MSDNShortId = "aa365223")]
		public static extern int LZCopy(int hfSource, int hfDest);

		/// <summary>
		/// Allocates memory for the internal data structures required to decompress files, and then creates and initializes them.
		/// </summary>
		/// <param name="hfSource">A handle to the file.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a new LZ file handle.</para>
		/// <para>
		/// If the function fails, the return value is an LZERROR_* code. These codes have values less than zero. Note that <c>LZInit</c>
		/// calls neither <c>SetLastError</c> nor <c>SetLastErrorEx</c>; thus, its failure does not affect a thread's last-error code.
		/// </para>
		/// <para>The following is the list of the error codes that <c>LZInit</c> can return upon failure.</para>
		/// <para>
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
		/// </para>
		/// <para>There is no extended error information for this function; do not call <c>GetLastError</c>.</para>
		/// </returns>
		// INT WINAPI LZInit( _In_ INT hfSource); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365224(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("LzExpand.h", MSDNShortId = "aa365224")]
		public static extern int LZInit(int hfSource);

		/// <summary>Creates, opens, reopens, or deletes the specified file.</summary>
		/// <param name="lpFileName">The name of the file.</param>
		/// <param name="lpReOpenBuf">
		/// <para>
		/// A pointer to the <c>OFSTRUCT</c> structure that is to receive information about the file when the file is first opened. The
		/// structure can be used in subsequent calls to the <c>LZOpenFile</c> function to see the open file.
		/// </para>
		/// <para>
		/// The <c>szPathName</c> member of this structure contains characters from the original equipment manufacturer (OEM) character set.
		/// </para>
		/// </param>
		/// <param name="wStyle">
		/// <para>The action to be taken. This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OF_CANCEL0x0800</term>
		/// <term>
		/// Ignored. Provided only for compatibility with 16-bit Windows. Use the OF_PROMPT style to display a dialog box containing a
		/// Cancel button.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_CREATE0x1000</term>
		/// <term>Directs LZOpenFile to create a new file. If the file already exists, it is truncated to zero length.</term>
		/// </item>
		/// <item>
		/// <term>OF_DELETE0x0200</term>
		/// <term>Deletes the file.</term>
		/// </item>
		/// <item>
		/// <term>OF_EXIST0x4000</term>
		/// <term>Opens the file and then closes it to test for a file's existence.</term>
		/// </item>
		/// <item>
		/// <term>OF_PARSE0x0100</term>
		/// <term>Fills the OFSTRUCT structure but carries out no other action.</term>
		/// </item>
		/// <item>
		/// <term>OF_PROMPT0x2000</term>
		/// <term>
		/// Displays a dialog box if the requested file does not exist. The dialog box informs the user that the system cannot find the
		/// file, and it contains Retry and Cancel buttons. Clicking the Cancel button directs LZOpenFile to return a file not found error message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_READ0x0000</term>
		/// <term>Opens the file for reading only.</term>
		/// </item>
		/// <item>
		/// <term>OF_READWRITE0x0002</term>
		/// <term>Opens the file for reading and writing.</term>
		/// </item>
		/// <item>
		/// <term>OF_REOPEN0x8000</term>
		/// <term>Opens the file using information in the reopen buffer.</term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_DENY_NONE0x0040</term>
		/// <term>
		/// Opens the file without denying other processes read or write access to the file. LZOpenFile fails if the file has been opened in
		/// compatibility mode by any other process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_DENY_READ0x0030</term>
		/// <term>
		/// Opens the file and denies other processes read access to the file. LZOpenFile fails if the file has been opened in compatibility
		/// mode or has been opened for read access by any other process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_DENY_WRITE0x0020</term>
		/// <term>
		/// Opens the file and denies other processes write access to the file. LZOpenFile fails if the file has been opened in
		/// compatibility mode or has been opened for write access by any other process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_SHARE_EXCLUSIVE0x0010</term>
		/// <term>
		/// Opens the file in exclusive mode, denying other processes both read and write access to the file. LZOpenFile fails if the file
		/// has been opened in any other mode for read or write access, even by the current process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OF_WRITE0x0001</term>
		/// <term>Opens the file for writing only.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds and the value specified by the wStyle parameter is not <c>OF_READ</c>, the return value is a handle
		/// identifying the file. If the file is compressed and opened with wStyle set to <c>OF_READ</c>, the return value is a special file handle.
		/// </para>
		/// <para>
		/// If the function fails, the return value is an <c>LZERROR_*</c> code. These codes have values less than zero. There is no
		/// extended error information for this function; do not call <c>GetLastError</c>.
		/// </para>
		/// <para>The following is the list of the error codes that <c>LZOpenFile</c> can return upon failure.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>LZERROR_BADINHANDLE-1</term>
		/// <term>The handle identifying the source file is not valid. The file cannot be read.</term>
		/// </item>
		/// <item>
		/// <term>LZERROR_GLOBALLOC-5</term>
		/// <term>The maximum number of open compressed files has been exceeded or local memory cannot be allocated.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// INT WINAPI LZOpenFile( _In_ LPTSTR lpFileName, _Out_ LPOFSTRUCT lpReOpenBuf, _In_ WORD wStyle); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365225(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("LzExpand.h", MSDNShortId = "aa365225")]
		public static extern int LZOpenFile(string lpFileName, out OFSTRUCT lpReOpenBuf, ushort wStyle);

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
		/// calls neither <c>SetLastError</c> nor <c>SetLastErrorEx</c>; thus, its failure does not affect a thread's last-error code.
		/// </para>
		/// <para>The following is the list of error codes that <c>LZRead</c> can return upon failure.</para>
		/// <para>
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
		/// </para>
		/// <para>There is no extended error information for this function; do not call <c>GetLastError</c>.</para>
		/// </returns>
		// INT WINAPI LZRead( _In_ INT hFile, _Out_ LPSTR lpBuffer, _In_ INT cbRead); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365226(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("LzExpand.h", MSDNShortId = "aa365226")]
		public static extern int LZRead(int hFile, StringBuilder lpBuffer, int cbRead);

		/// <summary>Moves a file pointer the specified number of bytes from a starting position.</summary>
		/// <param name="hFile">A handle to the file.</param>
		/// <param name="lOffset">The number of bytes by which to move the file pointer.</param>
		/// <param name="iOrigin">
		/// <para>The starting position of the pointer. This parameter must be one of the following values.</para>
		/// <para>
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
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the offset from the beginning of the file to the new pointer position.</para>
		/// <para>
		/// If the function fails, the return value is an LZERROR_* code. These codes have values less than zero. Note that <c>LZSeek</c>
		/// calls neither <c>SetLastError</c> nor <c>SetLastErrorEx</c>; thus, its failure does not affect a thread's last-error code.
		/// </para>
		/// <para>The following is the list of error codes that <c>LZSeek</c> can return upon failure.</para>
		/// <para>
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
		/// </para>
		/// <para>There is no extended error information for this function; do not call <c>GetLastError</c>.</para>
		/// </returns>
		// LONG WINAPI LZSeek( _In_ INT hFile, _In_ LONG lOffset, _In_ INT iOrigin); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365227(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("LzExpand.h", MSDNShortId = "aa365227")]
		public static extern int LZSeek(int hFile, int lOffset, int iOrigin);
	}
}