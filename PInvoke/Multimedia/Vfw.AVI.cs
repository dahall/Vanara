#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the AviFil32.dll</summary>
public static partial class AviFil32
{
	/// <summary>Let the stream handler determine the number of samples to read.</summary>
	public const int AVISTREAMREAD_CONVENIENT = -1;

	private const string Lib_Avifil32 = "avifil32.dll";

	/// <summary>
	/// A callback function (referenced by using lpfnCallback) can display status information and let the user cancel the save operation.
	/// </summary>
	/// <param name="nPercent">Specifies the percentage of the file saved.</param>
	/// <returns>
	/// The callback function should return <see langword="false"/> if the operation should continue and <see langword="true"/> if the
	/// user wishes to abort the save operation.
	/// </returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool AVISAVECALLBACK(int nPercent);

	/// <summary>Flags used for compression.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_17")]
	[Flags]
	public enum AVICOMPRESSF : uint
	{
		/// <summary>Interleaves this stream every dwInterleaveEvery frames with respect to the first stream.</summary>
		AVICOMPRESSF_INTERLEAVE = 0x00000001,

		/// <summary>Compresses this video stream using the data rate specified in dwBytesPerSecond.</summary>
		AVICOMPRESSF_DATARATE = 0x00000002,

		/// <summary>
		/// Saves this video stream with key frames at least every dwKeyFrameEvery frames. By default, every frame will be a key frame.
		/// </summary>
		AVICOMPRESSF_KEYFRAMES = 0x00000004,

		/// <summary>
		/// Uses the data in this structure to set the default compression values for AVISaveOptions. If an empty structure is passed
		/// and this flag is not set, some defaults will be chosen.
		/// </summary>
		AVICOMPRESSF_VALID = 0x00000008,
	}

	/// <summary>Capability flags for <see cref="AVIFILEINFO"/>.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw._AVIFILEINFOA")]
	[Flags]
	public enum AVIFILECAPS : uint
	{
		/// <summary>An application can open the AVI file with the read privilege.</summary>
		AVIFILECAPS_CANREAD = 0x00000001,

		/// <summary>An application can open the AVI file with the write privilege.</summary>
		AVIFILECAPS_CANWRITE = 0x00000002,

		/// <summary>Every frame in the AVI file is a key frame.</summary>
		AVIFILECAPS_ALLKEYFRAMES = 0x00000010,

		/// <summary>The AVI file does not use a compression method.</summary>
		AVIFILECAPS_NOCOMPRESSION = 0x00000020,
	}

	/// <summary>Flags for <see cref="AVIFILEINFO"/>.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw._AVIFILEINFOA")]
	[Flags]
	public enum AVIFILEINFOF : uint
	{
		/// <summary>The AVI file has an index at the end of the file. For good performance, all AVI files should contain an index.</summary>
		AVIFILEINFO_HASINDEX = 0x00000010,

		/// <summary>
		/// The file index contains the playback order for the chunks in the file. Use the index rather than the physical ordering of
		/// the chunks when playing back the data. This could be used for creating a list of frames for editing.
		/// </summary>
		AVIFILEINFO_MUSTUSEINDEX = 0x00000020,

		/// <summary>The AVI file is interleaved.</summary>
		AVIFILEINFO_ISINTERLEAVED = 0x00000100,

		/// <summary>
		/// The AVI file is a specially allocated file used for capturing real-time video. Applications should warn the user before
		/// writing over a file with this flag set because the user probably defragmented this file.
		/// </summary>
		AVIFILEINFO_WASCAPTUREFILE = 0x00010000,

		/// <summary>
		/// The AVI file contains copyrighted data and software. When this flag is used, software should not permit the data to be duplicated.
		/// </summary>
		AVIFILEINFO_COPYRIGHTED = 0x00020000,
	}

	/// <summary>Flag associated with this data.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamWrite")]
	[Flags]
	public enum AVIIF : uint
	{
		/// <summary></summary>
		AVIIF_LIST = 0x00000001,

		/// <summary></summary>
		AVIIF_TWOCC = 0x00000002,

		/// <summary>Indicates this data does not rely on preceding data in the file.</summary>
		AVIIF_KEYFRAME = 0x00000010,
	}

	/// <summary>Applicable flags for the stream.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw._AVISTREAMINFOA")]
	[Flags]
	public enum AVISTREAMINFOF : uint
	{
		/// <summary>Indicates this stream should be rendered when explicitly enabled by the user.</summary>
		AVISTREAMINFO_DISABLED = 0x00000001,

		/// <summary>
		/// Indicates this video stream contains palette changes. This flag warns the playback software that it will need to animate the palette.
		/// </summary>
		AVISTREAMINFO_FORMATCHANGES = 0x00010000
	}

	/// <summary>Indicates whether the audio stream controls the clock when writing an AVI file.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.tagCaptureParms")]
	public enum AVSTREAMMASTER
	{
		/// <summary>
		/// The audio stream is considered the master stream and the video stream duration is forced to match the audio duration.
		/// </summary>
		AVSTREAMMASTER_AUDIO = 0,

		/// <summary>The durations of audio and video streams can differ.</summary>
		AVSTREAMMASTER_NONE = 1,
	}

	/// <summary>
	/// Flags that designate the type of frame to locate, the direction in the stream to search, and the type of return information.
	/// </summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamFindSample")]
	[Flags]
	public enum FINDF : uint
	{
		/// <summary>direction</summary>
		FIND_DIR = 0x0000000F,

		/// <summary>
		/// Finds nearest sample, frame, or format change searching forward. The current sample is included in the search. Use this flag
		/// with the FIND_ANY, FIND_KEY, or FIND_FORMAT flag. This flag supersedes the SEARCH_FORWARD flag.
		/// </summary>
		FIND_NEXT = 0x00000001,

		/// <summary>
		/// Finds nearest sample, frame, or format change searching backward. The current sample is included in the search. Use this
		/// flag with the FIND_ANY, FIND_KEY, or FIND_FORMAT flag. This flag supersedes the SEARCH_NEAREST and SEARCH_BACKWARD flags.
		/// </summary>
		FIND_PREV = 0x00000004,

		/// <summary>
		/// Finds first sample, frame, or format change beginning from the start of the stream. Use this flag with the FIND_ANY,
		/// FIND_KEY, or FIND_FORMAT flag.
		/// </summary>
		FIND_FROM_START = 0x00000008,

		/// <summary>type mask</summary>
		FIND_TYPE = 0x000000F0,

		/// <summary>Finds a key frame. This flag supersedes the SEARCH_KEY flag.</summary>
		FIND_KEY = 0x00000010,

		/// <summary>Finds a nonempty frame. This flag supersedes the SEARCH_ANY flag.</summary>
		FIND_ANY = 0x00000020,

		/// <summary>Finds a format change.</summary>
		FIND_FORMAT = 0x00000040,

		/// <summary>return mask</summary>
		FIND_RET = 0x0000F000,

		/// <summary>return logical position</summary>
		FIND_POS = 0x00000000,

		/// <summary>return logical size</summary>
		FIND_LENGTH = 0x00001000,

		/// <summary>return physical position</summary>
		FIND_OFFSET = 0x00002000,

		/// <summary>return physical size</summary>
		FIND_SIZE = 0x00003000,

		/// <summary>return physical index position</summary>
		FIND_INDEX = 0x00004000,
	}

	/// <summary>Flags for displaying the Compression Options dialog box.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveOptions")]
	[Flags]
	public enum ICMF_CHOOSE : uint
	{
		/// <summary>
		/// Displays a Key Frame Every dialog box for the video options. This is the same flag used in the ICCompressorChoose function.
		/// </summary>
		ICMF_CHOOSE_KEYFRAME = 0x0001,

		/// <summary>Displays a Data Rate dialog box for the video options. This is the same flag used in ICCompressorChoose.</summary>
		ICMF_CHOOSE_DATARATE = 0x0002,

		/// <summary>
		/// Displays a Preview button for the video options. This button previews the compression by using a frame from the stream. This
		/// is the same flag used in ICCompressorChoose.
		/// </summary>
		ICMF_CHOOSE_PREVIEW = 0x0004,

		/// <summary>Don't only show those that can handle the input format or input data.</summary>
		ICMF_CHOOSE_ALLCOMPRESSORS = 0x0008,
	}

	/// <summary>
	/// The <c>AVIBuildFilter</c> function builds a filter specification that is subsequently used by the GetOpenFileName or
	/// GetSaveFileName function.
	/// </summary>
	/// <param name="lpszFilter">Pointer to the buffer containing the filter string.</param>
	/// <param name="cbFilter">Size, in characters, of buffer pointed to by lpszFilter.</param>
	/// <param name="fSaving">
	/// Flag that indicates whether the filter should include read or write formats. Specify <c>TRUE</c> to include write formats or
	/// <c>FALSE</c> to include read formats.
	/// </param>
	/// <returns>
	/// <para>Returns AVIERR_OK if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AVIERR_BUFFERTOOSMALL</term>
	/// <term>The buffer size cbFilter was smaller than the generated filter specification.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_MEMORY</term>
	/// <term>There was not enough memory to complete the read operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function accesses the registry for all filter types that the AVIFile library can use to open, read, or write multimedia
	/// files. It does not search the hard disk for filter DLLs and formats.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVIBuildFilter as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avibuildfiltera HRESULT AVIBuildFilterA( LPSTR lpszFilter, LONG
	// cbFilter, BOOL fSaving );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIBuildFilterA")]
	public static extern HRESULT AVIBuildFilter([Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszFilter, int cbFilter,
		[MarshalAs(UnmanagedType.Bool)] bool fSaving);

	/// <summary>The <c>AVIClearClipboard</c> function removes an AVI file from the clipboard.</summary>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-aviclearclipboard HRESULT AVIClearClipboard();
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIClearClipboard")]
	public static extern HRESULT AVIClearClipboard();

	/// <summary>The <c>AVIFileAddRef</c> function increments the reference count of an AVI file.</summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <returns>Returns the updated reference count for the file interface.</returns>
	/// <remarks>The argument pfile is a pointer to an IAVIFile interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifileaddref ULONG AVIFileAddRef( IAVIFile pfile );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileAddRef")]
	public static extern uint AVIFileAddRef(IAVIFile pfile);

	/// <summary>
	/// The <c>AVIFileCreateStream</c> function creates a new stream in an existing file and creates an interface to the new stream.
	/// </summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <param name="ppavi">Pointer to the new stream interface.</param>
	/// <param name="psi">
	/// Pointer to a structure containing information about the new stream, including the stream type and its sample rate.
	/// </param>
	/// <returns>
	/// Returns zero if successful or an error otherwise. Unless the file has been opened with write permission, this function returns AVIERR_READONLY.
	/// </returns>
	/// <remarks>
	/// <para>This function starts a reference count for the new stream.</para>
	/// <para>The argument pfile is a pointer to an IAVIFile interface. The argument ppavi is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifilecreatestream HRESULT AVIFileCreateStream( IAVIFile pfile,
	// IAVIStream *ppavi, AVISTREAMINFO *psi );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileCreateStream")]
	public static extern HRESULT AVIFileCreateStream(IAVIFile pfile, out IAVIStream ppavi, in AVISTREAMINFO psi);

	/// <summary>
	/// The <c>AVIFileEndRecord</c> function marks the end of a record when writing an interleaved file that uses a 1:1 interleave
	/// factor of video to audio data. (Each frame of video is interspersed with an equivalent amount of audio data.)
	/// </summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>The AVISave function uses this function internally. In general, applications should not need to use this function.</para>
	/// <para>The argument pfile is a pointer to an IAVIFile interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifileendrecord HRESULT AVIFileEndRecord( IAVIFile pfile );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileEndRecord")]
	public static extern HRESULT AVIFileEndRecord(IAVIFile pfile);

	/// <summary>
	/// <para>The <c>AVIFileExit</c> function exits the AVIFile library and decrements the reference count for the library.</para>
	/// <para>This function supersedes the obsolete <c>AVIStreamExit</c> function.</para>
	/// </summary>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifileexit void AVIFileExit();
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileExit")]
	public static extern void AVIFileExit();

	/// <summary>
	/// The <c>AVIFileGetStream</c> function returns the address of a stream interface that is associated with a specified AVI file.
	/// </summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <param name="ppavi">Pointer to the new stream interface.</param>
	/// <param name="fccType">
	/// <para>
	/// Four-character code indicating the type of stream to open. Zero indicates any stream can be opened. The following definitions
	/// apply to the data commonly found in AVI streams.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>streamtypeAUDIO</term>
	/// <term>Indicates an audio stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeMIDI</term>
	/// <term>Indicates a MIDI stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeTEXT</term>
	/// <term>Indicates a text stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeVIDEO</term>
	/// <term>Indicates a video stream.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lParam">Count of the stream type. Identifies which occurrence of the specified stream type to access.</param>
	/// <returns>
	/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AVIERR_NODATA</term>
	/// <term>The file does not contain a stream corresponding to the values of fccType and lParam.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_MEMORY</term>
	/// <term>Not enough memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The argument pfile is a pointer to an IAVIFile interface. The argument ppavi is a pointer to an IAVIStream interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifilegetstream HRESULT AVIFileGetStream( IAVIFile pfile,
	// IAVIStream *ppavi, DWORD fccType, LONG lParam );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileGetStream")]
	public static extern HRESULT AVIFileGetStream(IAVIFile pfile, out IAVIStream ppavi, uint fccType, int lParam);

	/// <summary>The <c>AVIFileInfo</c> function obtains information about an AVI file.</summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <param name="pfi">
	/// Pointer to the structure used to return file information. Typically, this parameter points to an AVIFILEINFO structure.
	/// </param>
	/// <param name="lSize">Size, in bytes, of the structure.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>The argument pfile is a pointer to an IAVIFile interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifileinfo HRESULT AVIFileInfo( IAVIFile pfile, LPAVIFILEINFO pfi,
	// LONG lSize );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileInfo")]
	public static extern HRESULT AVIFileInfo(IAVIFile pfile, out AVIFILEINFO pfi, int lSize);

	/// <summary>
	/// <para>The <c>AVIFileInit</c> function initializes the AVIFile library.</para>
	/// <para>
	/// The AVIFile library maintains a count of the number of times it is initialized, but not the number of times it was released. Use
	/// the AVIFileExit function to release the AVIFile library and decrement the reference count. Call <c>AVIFileInit</c> before using
	/// any other AVIFile functions.
	/// </para>
	/// <para>This function supersedes the obsolete <c>AVIStreamInit</c> function.</para>
	/// </summary>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifileinit void AVIFileInit();
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileInit")]
	public static extern void AVIFileInit();

	/// <summary>
	/// The <c>AVIFileOpen</c> function opens an AVI file and returns the address of a file interface used to access it. The AVIFile
	/// library maintains a count of the number of times a file is opened, but not the number of times it was released. Use the
	/// AVIFileRelease function to release the file and decrement the count.
	/// </summary>
	/// <param name="ppfile">Pointer to a buffer that receives the new IAVIFile interface pointer.</param>
	/// <param name="szFile">Null-terminated string containing the name of the file to open.</param>
	/// <param name="uMode">
	/// <para>
	/// Access mode to use when opening the file. The default access mode is OF_READ. The following access modes can be specified with <c>AVIFileOpen</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OF_CREATE</term>
	/// <term>Creates a new file. If the file already exists, it is truncated to zero length.</term>
	/// </item>
	/// <item>
	/// <term>OF_PARSE</term>
	/// <term>
	/// Skips time-consuming operations, such as building an index. Set this flag if you want the function to return as quickly as
	/// possible—for example, if you are going to query the file properties but not read the file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_READ</term>
	/// <term>Opens the file for reading.</term>
	/// </item>
	/// <item>
	/// <term>OF_READWRITE</term>
	/// <term>Opens the file for reading and writing.</term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_NONE</term>
	/// <term>
	/// Opens the file nonexclusively. Other processes can open the file with read or write access. AVIFileOpen fails if another process
	/// has opened the file in compatibility mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_READ</term>
	/// <term>
	/// Opens the file nonexclusively. Other processes can open the file with write access. AVIFileOpen fails if another process has
	/// opened the file in compatibility mode or has read access to it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_WRITE</term>
	/// <term>
	/// Opens the file nonexclusively. Other processes can open the file with read access. AVIFileOpen fails if another process has
	/// opened the file in compatibility mode or has write access to it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_EXCLUSIVE</term>
	/// <term>Opens the file and denies other processes any access to it. AVIFileOpen fails if any other process has opened the file.</term>
	/// </item>
	/// <item>
	/// <term>OF_WRITE</term>
	/// <term>Opens the file for writing.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpHandler">
	/// Pointer to a class identifier of the standard or custom handler you want to use. If the value is <c>NULL</c>, the system chooses
	/// a handler from the registry based on the file extension or the RIFF type specified in the file.
	/// </param>
	/// <returns>
	/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AVIERR_BADFORMAT</term>
	/// <term>The file couldn't be read, indicating a corrupt file or an unrecognized format.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_MEMORY</term>
	/// <term>The file could not be opened because of insufficient memory.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_FILEREAD</term>
	/// <term>A disk error occurred while reading the file.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_FILEOPEN</term>
	/// <term>A disk error occurred while opening the file.</term>
	/// </item>
	/// <item>
	/// <term>REGDB_E_CLASSNOTREG</term>
	/// <term>According to the registry, the type of file specified in AVIFileOpen does not have a handler to process it.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifileopen HRESULT AVIFileOpen( IAVIFile *ppfile, LPCSTR szFile,
	// UINT uMode, LPCLSID lpHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileOpen")]
	public static extern HRESULT AVIFileOpen(out IAVIFile ppfile, [MarshalAs(UnmanagedType.LPTStr)] string szFile,
		Kernel32.OpenFileAction uMode, in Guid lpHandler);

	/// <summary>
	/// The <c>AVIFileOpen</c> function opens an AVI file and returns the address of a file interface used to access it. The AVIFile
	/// library maintains a count of the number of times a file is opened, but not the number of times it was released. Use the
	/// AVIFileRelease function to release the file and decrement the count.
	/// </summary>
	/// <param name="ppfile">Pointer to a buffer that receives the new IAVIFile interface pointer.</param>
	/// <param name="szFile">Null-terminated string containing the name of the file to open.</param>
	/// <param name="uMode">
	/// <para>
	/// Access mode to use when opening the file. The default access mode is OF_READ. The following access modes can be specified with <c>AVIFileOpen</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OF_CREATE</term>
	/// <term>Creates a new file. If the file already exists, it is truncated to zero length.</term>
	/// </item>
	/// <item>
	/// <term>OF_PARSE</term>
	/// <term>
	/// Skips time-consuming operations, such as building an index. Set this flag if you want the function to return as quickly as
	/// possible—for example, if you are going to query the file properties but not read the file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_READ</term>
	/// <term>Opens the file for reading.</term>
	/// </item>
	/// <item>
	/// <term>OF_READWRITE</term>
	/// <term>Opens the file for reading and writing.</term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_NONE</term>
	/// <term>
	/// Opens the file nonexclusively. Other processes can open the file with read or write access. AVIFileOpen fails if another process
	/// has opened the file in compatibility mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_READ</term>
	/// <term>
	/// Opens the file nonexclusively. Other processes can open the file with write access. AVIFileOpen fails if another process has
	/// opened the file in compatibility mode or has read access to it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_DENY_WRITE</term>
	/// <term>
	/// Opens the file nonexclusively. Other processes can open the file with read access. AVIFileOpen fails if another process has
	/// opened the file in compatibility mode or has write access to it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OF_SHARE_EXCLUSIVE</term>
	/// <term>Opens the file and denies other processes any access to it. AVIFileOpen fails if any other process has opened the file.</term>
	/// </item>
	/// <item>
	/// <term>OF_WRITE</term>
	/// <term>Opens the file for writing.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpHandler">
	/// Pointer to a class identifier of the standard or custom handler you want to use. If the value is <c>NULL</c>, the system chooses
	/// a handler from the registry based on the file extension or the RIFF type specified in the file.
	/// </param>
	/// <returns>
	/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AVIERR_BADFORMAT</term>
	/// <term>The file couldn't be read, indicating a corrupt file or an unrecognized format.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_MEMORY</term>
	/// <term>The file could not be opened because of insufficient memory.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_FILEREAD</term>
	/// <term>A disk error occurred while reading the file.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_FILEOPEN</term>
	/// <term>A disk error occurred while opening the file.</term>
	/// </item>
	/// <item>
	/// <term>REGDB_E_CLASSNOTREG</term>
	/// <term>According to the registry, the type of file specified in AVIFileOpen does not have a handler to process it.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifileopen HRESULT AVIFileOpen( IAVIFile *ppfile, LPCSTR szFile,
	// UINT uMode, LPCLSID lpHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileOpen")]
	public static extern HRESULT AVIFileOpen(out IAVIFile ppfile, [MarshalAs(UnmanagedType.LPTStr)] string szFile,
		Kernel32.OpenFileAction uMode, [In, Optional] GuidPtr lpHandler);

	/// <summary>
	/// The <c>AVIFileReadData</c> function reads optional header data that applies to the entire file, such as author or copyright information.
	/// </summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <param name="ckid">RIFF chunk identifier (four-character code) of the data.</param>
	/// <param name="lpData">Pointer to the buffer used to return the data read.</param>
	/// <param name="lpcbData">
	/// Pointer to a location indicating the size of the memory block referenced by lpData. If the data is read successfully, the value
	/// is changed to indicate the amount of data read.
	/// </param>
	/// <returns>
	/// Returns zero if successful or an error otherwise. The return value AVIERR_NODATA indicates that data with the requested chunk
	/// identifier does not exist.
	/// </returns>
	/// <remarks>
	/// <para>The optional header information is custom and does not have a set format.</para>
	/// <para>The argument pfile is a pointer to an IAVIFile interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifilereaddata HRESULT AVIFileReadData( IAVIFile pfile, DWORD
	// ckid, LPVOID lpData, LONG *lpcbData );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileReadData")]
	public static extern HRESULT AVIFileReadData([In] IAVIFile pfile, uint ckid, [Out] IntPtr lpData, ref int lpcbData);

	/// <summary>
	/// <para>
	/// The <c>AVIFileRelease</c> function decrements the reference count of an AVI file interface handle and closes the file if the
	/// count reaches zero.
	/// </para>
	/// <para>This function supersedes the obsolete <c>AVIFileClose</c> function.</para>
	/// </summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <returns>Returns the reference count of the file. This return value should be used only for debugging purposes.</returns>
	/// <remarks>The argument pfile is a pointer to an IAVIFile interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifilerelease ULONG AVIFileRelease( IAVIFile pfile );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileRelease")]
	public static extern uint AVIFileRelease(IAVIFile pfile);

	/// <summary>
	/// The <c>AVIFileWriteData</c> function writes supplementary data (other than normal header, format, and stream data) to the file.
	/// </summary>
	/// <param name="pfile">Handle to an open AVI file.</param>
	/// <param name="ckid">RIFF chunk identifier (four-character code) of the data.</param>
	/// <param name="lpData">Pointer to the buffer used to write the data.</param>
	/// <param name="cbData">Size, in bytes, of the memory block referenced by lpData.</param>
	/// <returns>
	/// Returns zero if successful or an error otherwise. In an application has read-only access to the file, the error code
	/// AVIERR_READONLY is returned.
	/// </returns>
	/// <remarks>
	/// <para>Use the AVIStreamWriteData function to write data that applies to an individual stream.</para>
	/// <para>The argument pfile is a pointer to an IAVIFile interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avifilewritedata HRESULT AVIFileWriteData( IAVIFile pfile, DWORD
	// ckid, LPVOID lpData, LONG cbData );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIFileWriteData")]
	public static extern HRESULT AVIFileWriteData(IAVIFile pfile, uint ckid, [In] IntPtr lpData, int cbData);

	/// <summary>The <c>AVIGetFromClipboard</c> function copies an AVI file from the clipboard.</summary>
	/// <param name="lppf">Pointer to the location used to return the handle created for the AVI file.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// If the clipboard does not contain an AVI file, <c>AVIGetFromClipboard</c> also can copy data with the CF_DIB or CF_WAVE
	/// clipboard flags to an AVI file. In this case, the function creates an AVI file with one DIB stream and one waveform-audio
	/// stream, and fills each stream with the data from the clipboard.
	/// </para>
	/// <para>The argument lppf is the address of a pointer to an IAVIFile interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avigetfromclipboard HRESULT AVIGetFromClipboard( IAVIFile *lppf );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIGetFromClipboard")]
	public static extern HRESULT AVIGetFromClipboard(out IAVIFile lppf);

	/// <summary>
	/// The <c>AVIMakeCompressedStream</c> function creates a compressed stream from an uncompressed stream and a compression filter,
	/// and returns the address of a pointer to the compressed stream. This function supports audio and video compression.
	/// </summary>
	/// <param name="ppsCompressed">Pointer to a buffer that receives the compressed stream pointer.</param>
	/// <param name="ppsSource">Pointer to the stream to be compressed.</param>
	/// <param name="lpOptions">
	/// Pointer to a structure that identifies the type of compression to use and the options to apply. You can specify video
	/// compression by identifying an appropriate handler in the AVICOMPRESSOPTIONS structure. For audio compression, specify the
	/// compressed data format.
	/// </param>
	/// <param name="pclsidHandler">Pointer to a class identifier used to create the stream.</param>
	/// <returns>
	/// <para>Returns AVIERR_OK if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AVIERR_NOCOMPRESSOR</term>
	/// <term>A suitable compressor cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_MEMORY</term>
	/// <term>There is not enough memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_UNSUPPORTED</term>
	/// <term>
	/// Compression is not supported for this type of data. This error might be returned if you try to compress data that is not audio
	/// or video.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Applications can read from or write to the compressed stream.</para>
	/// <para>A <c>IAVIStream</c> is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avimakecompressedstream HRESULT AVIMakeCompressedStream( IAVIStream
	// *ppsCompressed, IAVIStream ppsSource, AVICOMPRESSOPTIONS *lpOptions, CLSID *pclsidHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIMakeCompressedStream")]
	public static extern HRESULT AVIMakeCompressedStream(out IAVIStream ppsCompressed, [In] IAVIStream ppsSource,
		in AVICOMPRESSOPTIONS lpOptions, in Guid pclsidHandler);

	/// <summary>
	/// The <c>AVIMakeCompressedStream</c> function creates a compressed stream from an uncompressed stream and a compression filter,
	/// and returns the address of a pointer to the compressed stream. This function supports audio and video compression.
	/// </summary>
	/// <param name="ppsCompressed">Pointer to a buffer that receives the compressed stream pointer.</param>
	/// <param name="ppsSource">Pointer to the stream to be compressed.</param>
	/// <param name="lpOptions">
	/// Pointer to a structure that identifies the type of compression to use and the options to apply. You can specify video
	/// compression by identifying an appropriate handler in the AVICOMPRESSOPTIONS structure. For audio compression, specify the
	/// compressed data format.
	/// </param>
	/// <param name="pclsidHandler">Pointer to a class identifier used to create the stream.</param>
	/// <returns>
	/// <para>Returns AVIERR_OK if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AVIERR_NOCOMPRESSOR</term>
	/// <term>A suitable compressor cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_MEMORY</term>
	/// <term>There is not enough memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_UNSUPPORTED</term>
	/// <term>
	/// Compression is not supported for this type of data. This error might be returned if you try to compress data that is not audio
	/// or video.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Applications can read from or write to the compressed stream.</para>
	/// <para>A <c>IAVIStream</c> is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avimakecompressedstream HRESULT AVIMakeCompressedStream( IAVIStream
	// *ppsCompressed, IAVIStream ppsSource, AVICOMPRESSOPTIONS *lpOptions, CLSID *pclsidHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIMakeCompressedStream")]
	public static extern HRESULT AVIMakeCompressedStream(out IAVIStream ppsCompressed, [In] IAVIStream ppsSource,
		in AVICOMPRESSOPTIONS lpOptions, [In, Optional] GuidPtr pclsidHandler);

	/// <summary>The <c>AVIMakeFileFromStreams</c> function constructs an AVIFile interface pointer from separate streams.</summary>
	/// <param name="ppfile">Pointer to a buffer that receives the new file interface pointer.</param>
	/// <param name="nStreams">Count of the number of streams in the array of stream interface pointers referenced by papStreams.</param>
	/// <param name="papStreams">Pointer to an array of stream interface pointers.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>Use the AVIFileRelease function to close the file.</para>
	/// <para>
	/// Other functions can use the AVIFile interface created by this function to copy and edit the streams associated with the
	/// interface. For example, you can retrieve a specific stream by using AVIFileGetStream with the file interface pointer.
	/// </para>
	/// <para>
	/// The argument pfile is the address of a pointer to an IAVIFile interface. The argument papStreams is the address of a pointer to
	/// an IAVIStream interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avimakefilefromstreams HRESULT AVIMakeFileFromStreams( IAVIFile
	// *ppfile, int nStreams, IAVIStream *papStreams );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIMakeFileFromStreams")]
	public static extern HRESULT AVIMakeFileFromStreams(out IAVIFile ppfile, int nStreams,
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IAVIStream[] papStreams);

	/// <summary>The <c>AVIMakeStreamFromClipboard</c> function creates an editable stream from stream data on the clipboard.</summary>
	/// <param name="cfFormat">Clipboard flag.</param>
	/// <param name="hGlobal">Handle to stream data on the clipboard.</param>
	/// <param name="ppstream">Handle to the created stream.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// When an application finishes using the editable stream, it must release the stream to free the resources associated with it.
	/// </para>
	/// <para>The argument ppstream is the address of a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avimakestreamfromclipboard HRESULT AVIMakeStreamFromClipboard( UINT
	// cfFormat, HANDLE hGlobal, IAVIStream *ppstream );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIMakeStreamFromClipboard")]
	public static extern HRESULT AVIMakeStreamFromClipboard(uint cfFormat, Kernel32.HGLOBAL hGlobal, ref IAVIStream ppstream);

	/// <summary>The <c>AVIPutFileOnClipboard</c> function copies an AVI file to the clipboard.</summary>
	/// <param name="pf">Handle to an open AVI file.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function also copies data with the CF_DIB, CF_PALETTE, and CF_WAVE clipboard flags onto the clipboard using the first frame
	/// of the first video stream of the file as a DIB and using the audio stream as CF_WAVE.
	/// </para>
	/// <para>The argument pf is a pointer to an IAVIFile interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-aviputfileonclipboard HRESULT AVIPutFileOnClipboard( IAVIFile pf );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIPutFileOnClipboard")]
	public static extern HRESULT AVIPutFileOnClipboard(IAVIFile pf);

	/// <summary>The <c>AVISave</c> function builds a file by combining data streams from other files or from memory.</summary>
	/// <param name="szFile">Null-terminated string containing the name of the file to save.</param>
	/// <param name="pclsidHandler">
	/// Pointer to the file handler used to write the file. The file is created by calling the AVIFileOpen function using this handler.
	/// If a handler is not specified, a default is selected from the registry based on the file extension.
	/// </param>
	/// <param name="lpfnCallback">Pointer to a callback function for the save operation.</param>
	/// <param name="nStreams">Number of streams saved in the file.</param>
	/// <param name="pfile">
	/// Pointer to an AVI stream. This parameter is paired with lpOptions. The parameter pair can be repeated as a variable number of arguments.
	/// </param>
	/// <param name="lpOptions">
	/// Pointer to an application-defined AVICOMPRESSOPTIONS structure containing the compression options for the stream referenced by
	/// pavi. This parameter is paired with pavi. The parameter pair can be repeated as a variable number of arguments.
	/// </param>
	/// <returns>Returns AVIERR_OK if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function creates a file, copies stream data into the file, closes the file, and releases the resources used by the new
	/// file. The last two parameters of this function identify a stream to save in the file and define the compression options of that
	/// stream. When saving more than one stream in an AVI file, repeat these two stream-specific parameters for each stream in the file.
	/// </para>
	/// <para>
	/// A callback function (referenced by using lpfnCallback) can display status information and let the user cancel the save
	/// operation. The callback function uses the following format:
	/// </para>
	/// <para>
	/// <code> LONG PASCAL SaveCallback(int nPercent)</code>
	/// </para>
	/// <para>The nPercent parameter specifies the percentage of the file saved.</para>
	/// <para>
	/// The callback function should return AVIERR_OK if the operation should continue and AVIERR_USERABORT if the user wishes to abort
	/// the save operation.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVISave as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisavea HRESULT AVISaveA( LPCSTR szFile, CLSID *pclsidHandler,
	// AVISAVECALLBACK lpfnCallback, int nStreams, IAVIStream pfile, LPAVICOMPRESSOPTIONS lpOptions, ... );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveA")]
	public static extern HRESULT AVISave([MarshalAs(UnmanagedType.LPTStr)] string szFile, in Guid pclsidHandler,
		AVISAVECALLBACK lpfnCallback, int nStreams, IAVIStream pfile, in AVICOMPRESSOPTIONS lpOptions);

	/// <summary>The <c>AVISave</c> function builds a file by combining data streams from other files or from memory.</summary>
	/// <param name="szFile">Null-terminated string containing the name of the file to save.</param>
	/// <param name="pclsidHandler">
	/// Pointer to the file handler used to write the file. The file is created by calling the AVIFileOpen function using this handler.
	/// If a handler is not specified, a default is selected from the registry based on the file extension.
	/// </param>
	/// <param name="lpfnCallback">Pointer to a callback function for the save operation.</param>
	/// <param name="nStreams">Number of streams saved in the file.</param>
	/// <param name="pfile">
	/// Pointer to an AVI stream. This parameter is paired with lpOptions. The parameter pair can be repeated as a variable number of arguments.
	/// </param>
	/// <param name="lpOptions">
	/// Pointer to an application-defined AVICOMPRESSOPTIONS structure containing the compression options for the stream referenced by
	/// pavi. This parameter is paired with pavi. The parameter pair can be repeated as a variable number of arguments.
	/// </param>
	/// <returns>Returns AVIERR_OK if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function creates a file, copies stream data into the file, closes the file, and releases the resources used by the new
	/// file. The last two parameters of this function identify a stream to save in the file and define the compression options of that
	/// stream. When saving more than one stream in an AVI file, repeat these two stream-specific parameters for each stream in the file.
	/// </para>
	/// <para>
	/// A callback function (referenced by using lpfnCallback) can display status information and let the user cancel the save
	/// operation. The callback function uses the following format:
	/// </para>
	/// <para>
	/// <code> LONG PASCAL SaveCallback(int nPercent)</code>
	/// </para>
	/// <para>The nPercent parameter specifies the percentage of the file saved.</para>
	/// <para>
	/// The callback function should return AVIERR_OK if the operation should continue and AVIERR_USERABORT if the user wishes to abort
	/// the save operation.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVISave as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisavea HRESULT AVISaveA( LPCSTR szFile, CLSID *pclsidHandler,
	// AVISAVECALLBACK lpfnCallback, int nStreams, IAVIStream pfile, LPAVICOMPRESSOPTIONS lpOptions, ... );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveA")]
	public static extern HRESULT AVISave([MarshalAs(UnmanagedType.LPTStr)] string szFile, [In, Optional] GuidPtr pclsidHandler,
		AVISAVECALLBACK lpfnCallback, int nStreams, IAVIStream pfile, in AVICOMPRESSOPTIONS lpOptions);

	/// <summary>The <c>AVISaveOptions</c> function retrieves the save options for a file and returns them in a buffer.</summary>
	/// <param name="hwnd">Handle to the parent window for the Compression Options dialog box.</param>
	/// <param name="uiFlags">
	/// <para>Flags for displaying the Compression Options dialog box. The following flags are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICMF_CHOOSE_KEYFRAME</term>
	/// <term>Displays a Key Frame Every dialog box for the video options. This is the same flag used in the ICCompressorChoose function.</term>
	/// </item>
	/// <item>
	/// <term>ICMF_CHOOSE_DATARATE</term>
	/// <term>Displays a Data Rate dialog box for the video options. This is the same flag used in ICCompressorChoose.</term>
	/// </item>
	/// <item>
	/// <term>ICMF_CHOOSE_PREVIEW</term>
	/// <term>
	/// Displays a Preview button for the video options. This button previews the compression by using a frame from the stream. This is
	/// the same flag used in ICCompressorChoose.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="nStreams">Number of streams that have their options set by the dialog box.</param>
	/// <param name="ppavi">
	/// Pointer to an array of stream interface pointers. The nStreams parameter indicates the number of pointers in the array.
	/// </param>
	/// <param name="plpOptions">
	/// Pointer to an array of pointers to AVICOMPRESSOPTIONS structures. These structures hold the compression options set by the
	/// dialog box. The nStreams parameter indicates the number of pointers in the array.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if the user pressed OK, <c>FALSE</c> for CANCEL, or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function presents a standard Compression Options dialog box using hwnd as the parent window handle. When the user is
	/// finished selecting the compression options for each stream, the options are returned in the AVICOMPRESSOPTIONS structure in the
	/// array referenced by plpOptions. The calling application must pass the interface pointers for the streams in the array referenced
	/// by ppavi.
	/// </para>
	/// <para>An application must allocate memory for the AVICOMPRESSOPTIONS structures and the array of pointers to these structures.</para>
	/// <para>The argument ppavi contains the address of a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisaveoptions INT_PTR AVISaveOptions( HWND hwnd, UINT uiFlags, int
	// nStreams, IAVIStream *ppavi, LPAVICOMPRESSOPTIONS *plpOptions );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveOptions")]
	public static extern IntPtr AVISaveOptions(HWND hwnd, ICMF_CHOOSE uiFlags, int nStreams,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IAVIStream[] ppavi,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] plpOptions);

	/// <summary>The <c>AVISaveOptions</c> function retrieves the save options for a file and returns them in a buffer.</summary>
	/// <param name="hwnd">Handle to the parent window for the Compression Options dialog box.</param>
	/// <param name="uiFlags">
	/// <para>Flags for displaying the Compression Options dialog box. The following flags are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICMF_CHOOSE_KEYFRAME</term>
	/// <term>Displays a Key Frame Every dialog box for the video options. This is the same flag used in the ICCompressorChoose function.</term>
	/// </item>
	/// <item>
	/// <term>ICMF_CHOOSE_DATARATE</term>
	/// <term>Displays a Data Rate dialog box for the video options. This is the same flag used in ICCompressorChoose.</term>
	/// </item>
	/// <item>
	/// <term>ICMF_CHOOSE_PREVIEW</term>
	/// <term>
	/// Displays a Preview button for the video options. This button previews the compression by using a frame from the stream. This is
	/// the same flag used in ICCompressorChoose.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="nStreams">Number of streams that have their options set by the dialog box.</param>
	/// <param name="ppavi">
	/// Pointer to an array of stream interface pointers. The nStreams parameter indicates the number of pointers in the array.
	/// </param>
	/// <param name="plpOptions">
	/// Pointer to an array of pointers to AVICOMPRESSOPTIONS structures. These structures hold the compression options set by the
	/// dialog box. The nStreams parameter indicates the number of pointers in the array.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if the user pressed OK, <c>FALSE</c> for CANCEL, or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function presents a standard Compression Options dialog box using hwnd as the parent window handle. When the user is
	/// finished selecting the compression options for each stream, the options are returned in the AVICOMPRESSOPTIONS structure in the
	/// array referenced by plpOptions. The calling application must pass the interface pointers for the streams in the array referenced
	/// by ppavi.
	/// </para>
	/// <para>An application must allocate memory for the AVICOMPRESSOPTIONS structures and the array of pointers to these structures.</para>
	/// <para>The argument ppavi contains the address of a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisaveoptions INT_PTR AVISaveOptions( HWND hwnd, UINT uiFlags, int
	// nStreams, IAVIStream *ppavi, LPAVICOMPRESSOPTIONS *plpOptions );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveOptions")]
	public static unsafe extern IntPtr AVISaveOptions(HWND hwnd, ICMF_CHOOSE uiFlags, int nStreams,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IAVIStream[] ppavi,
		[In, Out] AVICOMPRESSOPTIONS** plpOptions);

	/// <summary>The <c>AVISaveOptionsFree</c> function frees the resources allocated by the AVISaveOptions function.</summary>
	/// <param name="nStreams">Count of the AVICOMPRESSOPTIONS structures referenced in plpOptions.</param>
	/// <param name="plpOptions">
	/// Pointer to an array of pointers to AVICOMPRESSOPTIONS structures. These structures hold the compression options set by the
	/// dialog box. The resources allocated by AVISaveOptions for each of these structures will be freed.
	/// </param>
	/// <returns>Returns AVIERR_OK.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisaveoptionsfree HRESULT AVISaveOptionsFree( int nStreams,
	// LPAVICOMPRESSOPTIONS *plpOptions );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveOptionsFree")]
	public static extern HRESULT AVISaveOptionsFree(int nStreams, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] plpOptions);

	/// <summary>The <c>AVISaveOptionsFree</c> function frees the resources allocated by the AVISaveOptions function.</summary>
	/// <param name="nStreams">Count of the AVICOMPRESSOPTIONS structures referenced in plpOptions.</param>
	/// <param name="plpOptions">
	/// Pointer to an array of pointers to AVICOMPRESSOPTIONS structures. These structures hold the compression options set by the
	/// dialog box. The resources allocated by AVISaveOptions for each of these structures will be freed.
	/// </param>
	/// <returns>Returns AVIERR_OK.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisaveoptionsfree HRESULT AVISaveOptionsFree( int nStreams,
	// LPAVICOMPRESSOPTIONS *plpOptions );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveOptionsFree")]
	public static unsafe extern HRESULT AVISaveOptionsFree(int nStreams, AVICOMPRESSOPTIONS** plpOptions);

	/// <summary>The <c>AVISaveV</c> function builds a file by combining data streams from other files or from memory.</summary>
	/// <param name="szFile">Null-terminated string containing the name of the file to save.</param>
	/// <param name="pclsidHandler">
	/// Pointer to the file handler used to write the file. The file is created by calling the AVIFileOpen function using this handler.
	/// If a handler is not specified, a default is selected from the registry based on the file extension.
	/// </param>
	/// <param name="lpfnCallback">
	/// Pointer to a callback function used to display status information and to let the user cancel the save operation.
	/// </param>
	/// <param name="nStreams">Number of streams to save.</param>
	/// <param name="ppavi">
	/// Pointer to an array of pointers to the <c>AVISTREAM</c> function structures. The array uses one pointer for each stream.
	/// </param>
	/// <param name="plpOptions">
	/// Pointer to an array of pointers to AVICOMPRESSOPTIONS structures. The array uses one pointer for each stream.
	/// </param>
	/// <returns>Returns AVIERR_OK if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function is equivalent to the AVISave function except the streams are passed in an array instead of as a variable number of arguments.
	/// </para>
	/// <para>
	/// This function creates a file, copies stream data into the file, closes the file, and releases the resources used by the new
	/// file. The last two parameters of this function are arrays that identify the streams to save in the file and define the
	/// compression options of those streams.
	/// </para>
	/// <para>An application must allocate memory for the AVICOMPRESSOPTIONS structures and the array of pointers to these structures.</para>
	/// <para>The argument ppavi contains the address of a pointer to an IAVIStream interface.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVISaveV as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisaveva HRESULT AVISaveVA( LPCSTR szFile, CLSID *pclsidHandler,
	// AVISAVECALLBACK lpfnCallback, int nStreams, IAVIStream *ppavi, LPAVICOMPRESSOPTIONS *plpOptions );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveVA")]
	public static extern HRESULT AVISaveV([MarshalAs(UnmanagedType.LPTStr)] string szFile, in Guid pclsidHandler, AVISAVECALLBACK lpfnCallback, int nStreams,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IAVIStream[] ppavi,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] plpOptions);

	/// <summary>The <c>AVISaveV</c> function builds a file by combining data streams from other files or from memory.</summary>
	/// <param name="szFile">Null-terminated string containing the name of the file to save.</param>
	/// <param name="pclsidHandler">
	/// Pointer to the file handler used to write the file. The file is created by calling the AVIFileOpen function using this handler.
	/// If a handler is not specified, a default is selected from the registry based on the file extension.
	/// </param>
	/// <param name="lpfnCallback">
	/// Pointer to a callback function used to display status information and to let the user cancel the save operation.
	/// </param>
	/// <param name="nStreams">Number of streams to save.</param>
	/// <param name="ppavi">
	/// Pointer to an array of pointers to the <c>AVISTREAM</c> function structures. The array uses one pointer for each stream.
	/// </param>
	/// <param name="plpOptions">
	/// Pointer to an array of pointers to AVICOMPRESSOPTIONS structures. The array uses one pointer for each stream.
	/// </param>
	/// <returns>Returns AVIERR_OK if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function is equivalent to the AVISave function except the streams are passed in an array instead of as a variable number of arguments.
	/// </para>
	/// <para>
	/// This function creates a file, copies stream data into the file, closes the file, and releases the resources used by the new
	/// file. The last two parameters of this function are arrays that identify the streams to save in the file and define the
	/// compression options of those streams.
	/// </para>
	/// <para>An application must allocate memory for the AVICOMPRESSOPTIONS structures and the array of pointers to these structures.</para>
	/// <para>The argument ppavi contains the address of a pointer to an IAVIStream interface.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVISaveV as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisaveva HRESULT AVISaveVA( LPCSTR szFile, CLSID *pclsidHandler,
	// AVISAVECALLBACK lpfnCallback, int nStreams, IAVIStream *ppavi, LPAVICOMPRESSOPTIONS *plpOptions );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveVA")]
	public static extern HRESULT AVISaveV([MarshalAs(UnmanagedType.LPTStr)] string szFile, [In, Optional] GuidPtr pclsidHandler,
		AVISAVECALLBACK lpfnCallback, int nStreams,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IAVIStream[] ppavi,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] plpOptions);

	/// <summary>The <c>AVISaveV</c> function builds a file by combining data streams from other files or from memory.</summary>
	/// <param name="szFile">Null-terminated string containing the name of the file to save.</param>
	/// <param name="pclsidHandler">
	/// Pointer to the file handler used to write the file. The file is created by calling the AVIFileOpen function using this handler.
	/// If a handler is not specified, a default is selected from the registry based on the file extension.
	/// </param>
	/// <param name="lpfnCallback">
	/// Pointer to a callback function used to display status information and to let the user cancel the save operation.
	/// </param>
	/// <param name="nStreams">Number of streams to save.</param>
	/// <param name="ppavi">
	/// Pointer to an array of pointers to the <c>AVISTREAM</c> function structures. The array uses one pointer for each stream.
	/// </param>
	/// <param name="plpOptions">
	/// Pointer to an array of pointers to AVICOMPRESSOPTIONS structures. The array uses one pointer for each stream.
	/// </param>
	/// <returns>Returns AVIERR_OK if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function is equivalent to the AVISave function except the streams are passed in an array instead of as a variable number of arguments.
	/// </para>
	/// <para>
	/// This function creates a file, copies stream data into the file, closes the file, and releases the resources used by the new
	/// file. The last two parameters of this function are arrays that identify the streams to save in the file and define the
	/// compression options of those streams.
	/// </para>
	/// <para>An application must allocate memory for the AVICOMPRESSOPTIONS structures and the array of pointers to these structures.</para>
	/// <para>The argument ppavi contains the address of a pointer to an IAVIStream interface.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVISaveV as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avisaveva HRESULT AVISaveVA( LPCSTR szFile, CLSID *pclsidHandler,
	// AVISAVECALLBACK lpfnCallback, int nStreams, IAVIStream *ppavi, LPAVICOMPRESSOPTIONS *plpOptions );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVISaveVA")]
	public static unsafe extern HRESULT AVISaveV([MarshalAs(UnmanagedType.LPTStr)] string szFile, [In, Optional] Guid* pclsidHandler,
		AVISAVECALLBACK lpfnCallback, int nStreams,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IAVIStream[] ppavi,
		[In, Out] AVICOMPRESSOPTIONS** plpOptions);

	/// <summary>The <c>AVIStreamAddRef</c> function increments the reference count of an AVI stream.</summary>
	/// <param name="pavi">Handle to an open AVI stream.</param>
	/// <returns>Returns the current reference count of the stream. This value should be used only for debugging purposes.</returns>
	/// <remarks>The argument pavi contains a pointer to an IAVIStream interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamaddref ULONG AVIStreamAddRef( IAVIStream pavi );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamAddRef")]
	public static extern uint AVIStreamAddRef(IAVIStream pavi);

	/// <summary>
	/// The <c>AVIStreamBeginStreaming</c> function specifies the parameters used in streaming and lets a stream handler prepare for streaming.
	/// </summary>
	/// <param name="pavi">Pointer to a stream.</param>
	/// <param name="lStart">Starting frame for streaming.</param>
	/// <param name="lEnd">Ending frame for streaming.</param>
	/// <param name="lRate">
	/// Speed at which the file is read relative to its natural speed. Specify 1000 for the normal speed. Values less than 1000 indicate
	/// a slower-than-normal speed; values greater than 1000 indicate a faster-than-normal speed.
	/// </param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>The argument pavi is a pointer to an IAVIStream interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreambeginstreaming HRESULT AVIStreamBeginStreaming( IAVIStream
	// pavi, LONG lStart, LONG lEnd, LONG lRate );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamBeginStreaming")]
	public static extern HRESULT AVIStreamBeginStreaming(IAVIStream pavi, int lStart, int lEnd, int lRate);

	/// <summary>The <c>AVIStreamCreate</c> function creates a stream not associated with any file.</summary>
	/// <param name="ppavi">Pointer to a buffer that receives the new stream interface.</param>
	/// <param name="lParam1">Stream-handler specific information.</param>
	/// <param name="lParam2">Stream-handler specific information.</param>
	/// <param name="pclsidHandler">Pointer to the class identifier used for the stream.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// You should not need to call this function. Some functions, such as CreateEditableStream and AVIMakeCompressedStream, use it internally.
	/// </para>
	/// <para>The argument ppavi contains the address of a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamcreate HRESULT AVIStreamCreate( IAVIStream *ppavi, LONG
	// lParam1, LONG lParam2, CLSID *pclsidHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamCreate")]
	public static extern HRESULT AVIStreamCreate(out IAVIStream ppavi, int lParam1, int lParam2, in Guid pclsidHandler);

	/// <summary>The <c>AVIStreamCreate</c> function creates a stream not associated with any file.</summary>
	/// <param name="ppavi">Pointer to a buffer that receives the new stream interface.</param>
	/// <param name="lParam1">Stream-handler specific information.</param>
	/// <param name="lParam2">Stream-handler specific information.</param>
	/// <param name="pclsidHandler">Pointer to the class identifier used for the stream.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// You should not need to call this function. Some functions, such as CreateEditableStream and AVIMakeCompressedStream, use it internally.
	/// </para>
	/// <para>The argument ppavi contains the address of a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamcreate HRESULT AVIStreamCreate( IAVIStream *ppavi, LONG
	// lParam1, LONG lParam2, CLSID *pclsidHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamCreate")]
	public static extern HRESULT AVIStreamCreate(out IAVIStream ppavi, int lParam1, int lParam2, [In, Optional] GuidPtr pclsidHandler);

	/// <summary>
	/// The <c>AVIStreamDataSize</c> macro determines the buffer size, in bytes, needed to retrieve optional header data for a specified stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="fcc">Four-character code specifying the stream type.</param>
	/// <param name="plSize">Address to contain the buffer size for the optional header data.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamDataSize</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamDataSize(pavi, fcc, plSize) \ AVIStreamReadData(pavi, fcc, NULL, plSize)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamdatasize void AVIStreamDataSize( pavi, fcc, plSize );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamDataSize")]
	public static void AVIStreamDataSize(IAVIStream pavi, uint fcc, out int plSize)
	{
		int sz = 0;
		AVIStreamReadData(pavi, fcc, default, ref sz);
		plSize = sz;
	}

	/// <summary>The <c>AVIStreamEnd</c> macro calculates the sample associated with the end of a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <returns>Returns the number if successful or -1 otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The sample number returned is not a valid sample number for reading data. It represents the end of the file. (The end of the
	/// file is equal to the start of the file plus its length.)
	/// </para>
	/// <para>The <c>AVIStreamEnd</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamEnd(pavi) \ (AVIStreamStart(pavi) + AVIStreamLength(pavi))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamend void AVIStreamEnd( pavi );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamEnd")]
	public static int AVIStreamEnd(IAVIStream pavi) => AVIStreamStart(pavi) + AVIStreamLength(pavi);

	/// <summary>The <c>AVIStreamEndStreaming</c> function ends streaming.</summary>
	/// <param name="pavi">Pointer to a stream.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>Many stream implementations ignore this function.</para>
	/// <para>The argument pavi contains a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamendstreaming HRESULT AVIStreamEndStreaming( IAVIStream
	// pavi );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamEndStreaming")]
	public static extern HRESULT AVIStreamEndStreaming(IAVIStream pavi);

	/// <summary>The <c>AVIStreamEndTime</c> macro returns the time representing the end of the stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <returns>Returns the converted time if successful or −1 otherwise.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamEndTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamEndTime(pavi) \ AVIStreamSampleToTime(pavi, AVIStreamEnd(pavi))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamendtime void AVIStreamEndTime( pavi );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamEndTime")]
	public static int AVIStreamEndTime(IAVIStream pavi) => AVIStreamSampleToTime(pavi, AVIStreamEnd(pavi));

	/// <summary>
	/// <para>
	/// The <c>AVIStreamFindSample</c> function returns the position of a sample (key frame, nonempty frame, or a frame containing a
	/// format change) relative to the specified position.
	/// </para>
	/// <para>This function supersedes the obsolete <c>AVIStreamFindKeyFrame</c> function.</para>
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Starting frame for the search.</param>
	/// <param name="lFlags">
	/// <para>
	/// Flags that designate the type of frame to locate, the direction in the stream to search, and the type of return information. The
	/// following flags are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FIND_ANY</term>
	/// <term>Finds a nonempty frame. This flag supersedes the SEARCH_ANY flag.</term>
	/// </item>
	/// <item>
	/// <term>FIND_KEY</term>
	/// <term>Finds a key frame. This flag supersedes the SEARCH_KEY flag.</term>
	/// </item>
	/// <item>
	/// <term>FIND_FORMAT</term>
	/// <term>Finds a format change.</term>
	/// </item>
	/// <item>
	/// <term>FIND_NEXT</term>
	/// <term>
	/// Finds nearest sample, frame, or format change searching forward. The current sample is included in the search. Use this flag
	/// with the FIND_ANY, FIND_KEY, or FIND_FORMAT flag. This flag supersedes the SEARCH_FORWARD flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FIND_PREV</term>
	/// <term>
	/// Finds nearest sample, frame, or format change searching backward. The current sample is included in the search. Use this flag
	/// with the FIND_ANY, FIND_KEY, or FIND_FORMAT flag. This flag supersedes the SEARCH_NEAREST and SEARCH_BACKWARD flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FIND_FROM_START</term>
	/// <term>
	/// Finds first sample, frame, or format change beginning from the start of the stream. Use this flag with the FIND_ANY, FIND_KEY,
	/// or FIND_FORMAT flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns the position of the frame found or -1 if the search is unsuccessful.</returns>
	/// <remarks>
	/// <para>The FIND_KEY, FIND_ANY, and FIND_FORMAT flags are mutually exclusive, as are the FIND_NEXT and FIND_PREV flags.</para>
	/// <para>The argument pavi contains a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamfindsample LONG AVIStreamFindSample( IAVIStream pavi, LONG
	// lPos, LONG lFlags );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamFindSample")]
	public static extern int AVIStreamFindSample(IAVIStream pavi, int lPos, FINDF lFlags);

	/// <summary>
	/// The <c>AVIStreamFormatSize</c> macro determines the buffer size, in bytes, needed to store format information for a sample in a stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Position of a sample in the stream.</param>
	/// <param name="plSize">Address to contain the buffer size.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamFormatSize</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamFormatSize(pavi, lPos, plSize) \ AVIStreamReadFormat(pavi, lPos, NULL, plSize)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamformatsize void AVIStreamFormatSize( pavi, lPos, plSize );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamFormatSize")]
	public static void AVIStreamFormatSize(IAVIStream pavi, int lPos, out int plSize)
	{
		var sz = 0;
		AVIStreamReadFormat(pavi, lPos, default, ref sz);
		plSize = sz;
	}

	/// <summary>The <c>AVIStreamGetFrame</c> function returns the address of a decompressed video frame.</summary>
	/// <param name="pg">Pointer to the IGetFrame interface.</param>
	/// <param name="lPos">Position, in samples, within the stream of the desired frame.</param>
	/// <returns>
	/// Returns a pointer to the frame data if successful or <c>NULL</c> otherwise. The frame data is returned as a packed DIB.
	/// </returns>
	/// <remarks>The returned frame is valid only until the next call to this function or the AVIStreamGetFrameClose function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamgetframe LPVOID AVIStreamGetFrame( PGETFRAME pg, LONG lPos );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamGetFrame")]
	public static extern IntPtr AVIStreamGetFrame([In] IGetFrame pg, int lPos);

	/// <summary>The <c>AVIStreamGetFrameClose</c> function releases resources used to decompress video frames.</summary>
	/// <param name="pg">Handle returned from the AVIStreamGetFrameOpen function. After calling this function, the handle is invalid.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamgetframeclose HRESULT AVIStreamGetFrameClose( PGETFRAME pg );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamGetFrameClose")]
	public static extern HRESULT AVIStreamGetFrameClose([In] IGetFrame pg);

	/// <summary>The <c>AVIStreamGetFrameOpen</c> function prepares to decompress video frames from the specified video stream.</summary>
	/// <param name="pavi">Pointer to the video stream used as the video source.</param>
	/// <param name="lpbiWanted">
	/// Pointer to a structure that defines the desired video format. Specify <c>NULL</c> to use a default format. You can also specify
	/// AVIGETFRAMEF_BESTDISPLAYFMT to decode the frames to the best format for your display.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a <c>GetFrame</c> object that can be used with the AVIStreamGetFrame function. If the system cannot find a decompressor
	/// that can decompress the stream to the given format, or to any RGB format, the function returns <c>NULL</c>.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamgetframeopen PGETFRAME AVIStreamGetFrameOpen( IAVIStream
	// pavi, LPBITMAPINFOHEADER lpbiWanted );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamGetFrameOpen")]
	[return: MarshalAs(UnmanagedType.Interface)]
	public static extern IGetFrame AVIStreamGetFrameOpen(IAVIStream pavi, in Gdi32.BITMAPINFOHEADER lpbiWanted);

	/// <summary>The <c>AVIStreamGetFrameOpen</c> function prepares to decompress video frames from the specified video stream.</summary>
	/// <param name="pavi">Pointer to the video stream used as the video source.</param>
	/// <param name="lpbiWanted">
	/// Pointer to a structure that defines the desired video format. Specify <c>NULL</c> to use a default format. You can also specify
	/// AVIGETFRAMEF_BESTDISPLAYFMT to decode the frames to the best format for your display.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a <c>GetFrame</c> object that can be used with the AVIStreamGetFrame function. If the system cannot find a decompressor
	/// that can decompress the stream to the given format, or to any RGB format, the function returns <c>NULL</c>.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamgetframeopen PGETFRAME AVIStreamGetFrameOpen( IAVIStream
	// pavi, LPBITMAPINFOHEADER lpbiWanted );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamGetFrameOpen")]
	[return: MarshalAs(UnmanagedType.Interface)]
	public static extern IGetFrame AVIStreamGetFrameOpen(IAVIStream pavi, [In, Optional] IntPtr lpbiWanted);

	/// <summary>The <c>AVIStreamInfo</c> function obtains stream header information.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="psi">Pointer to a structure to contain the stream information.</param>
	/// <param name="lSize">Size, in bytes, of the structure used for psi.</param>
	/// <returns>
	/// <para>Returns zero if successful or an error otherwise.</para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVISTREAMINFO as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreaminfoa HRESULT AVIStreamInfoA( IAVIStream pavi,
	// LPAVISTREAMINFOA psi, LONG lSize );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamInfoA")]
	public static extern HRESULT AVIStreamInfo(IAVIStream pavi, out AVISTREAMINFO psi, int lSize);

	/// <summary>The <c>AVIStreamIsKeyFrame</c> macro indicates whether a sample in a specified stream is a key frame.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Position to search in the stream.</param>
	/// <returns><see langword="true"/> if a sample in a specified stream is a key frame.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamIsKeyFrame</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamIsKeyFrame(pavi, lPos) \ (AVIStreamNearestKeyFrame(pavi, lPos) == 1)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamiskeyframe void AVIStreamIsKeyFrame( pavi, l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamIsKeyFrame")]
	public static bool AVIStreamIsKeyFrame(IAVIStream pavi, int lPos) => AVIStreamNearestKeyFrame(pavi, lPos) == 1;

	/// <summary>The <c>AVIStreamLength</c> function returns the length of the stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <returns>
	/// <para>Returns the stream's length, in samples, if successful or -1 otherwise.</para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamlength LONG AVIStreamLength( IAVIStream pavi );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamLength")]
	public static extern int AVIStreamLength(IAVIStream pavi);

	/// <summary>The <c>AVIStreamLengthTime</c> macro returns the length of a stream in time.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <returns>Returns the converted time if successful or −1 otherwise.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamLengthTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamLengthTime(pavi) \ AVIStreamSampleToTime(pavi, AVIStreamLength(pavi))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamlengthtime void AVIStreamLengthTime( pavi );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamLengthTime")]
	public static int AVIStreamLengthTime(IAVIStream pavi) => AVIStreamSampleToTime(pavi, AVIStreamLength(pavi));

	/// <summary>The <c>AVIStreamNearestKeyFrame</c> macro locates the key frame at or preceding a specified position in a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Starting position to search in the stream.</param>
	/// <returns>Returns the position of the frame found or -1 if the search is unsuccessful.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamNearestKeyFrame</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNearestKeyFrame(pavi, lPos) \ AVIStreamFindSample(pavi, lPos , FIND_PREV | FIND_KEY)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnearestkeyframe void AVIStreamNearestKeyFrame( pavi, l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNearestKeyFrame")]
	public static int AVIStreamNearestKeyFrame(IAVIStream pavi, int lPos) => AVIStreamFindSample(pavi, lPos, FINDF.FIND_PREV | FINDF.FIND_KEY);

	/// <summary>
	/// The <c>AVIStreamNearestKeyFrameTime</c> macro determines the time corresponding to the beginning of the key frame nearest (at or
	/// preceding) a specified time in a stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lTime">Starting time, in milliseconds, to search in the stream.</param>
	/// <returns>Returns the converted time if successful or -1 otherwise.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamNearestKeyFrameTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNearestKeyFrameTime(pavi, lTime) \ AVIStreamSampleToTime(pavi, AVIStreamNearestKeyFrame(pavi, AVIStreamTimeToSample(pavi, lTime)))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnearestkeyframetime void AVIStreamNearestKeyFrameTime(
	// pavi, t );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNearestKeyFrameTime")]
	public static int AVIStreamNearestKeyFrameTime(IAVIStream pavi, int lTime) => AVIStreamSampleToTime(pavi, AVIStreamNearestKeyFrame(pavi, AVIStreamTimeToSample(pavi, lTime)));

	/// <summary>
	/// The <c>AVIStreamNearestSample</c> macro locates the nearest nonempty sample at or preceding a specified position in a stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Starting position to search in the stream.</param>
	/// <returns>Returns the position of the frame found or -1 if the search is unsuccessful.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamNearestSample</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNearestSample(pavi, lPos) \ AVIStreamFindSample(pavi, lPos, FIND_PREV | FIND_ANY)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnearestsample void AVIStreamNearestSample( pavi, l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNearestSample")]
	public static int AVIStreamNearestSample(IAVIStream pavi, int lPos) => AVIStreamFindSample(pavi, lPos, FINDF.FIND_PREV | FINDF.FIND_ANY);

	/// <summary>
	/// The <c>AVIStreamNearestSampleTime</c> macro determines the time corresponding to the beginning of a sample that is nearest to a
	/// specified time in a stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lTime">Starting time, in milliseconds, to search in the stream.</param>
	/// <returns>Returns the converted time if successful or −1 otherwise.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamNearestSampleTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNearestSampleTime(pavi, lTime) \ AVIStreamSampleToTime(pavi, AVIStreamNearestSample(pavi, AVIStreamTimeToSample(pavi, lTime)))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnearestsampletime void AVIStreamNearestSampleTime( pavi, t );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNearestSampleTime")]
	public static int AVIStreamNearestSampleTime(IAVIStream pavi, int lTime) => AVIStreamSampleToTime(pavi, AVIStreamNearestSample(pavi, AVIStreamTimeToSample(pavi, lTime)));

	/// <summary>The <c>AVIStreamNextKeyFrame</c> macro locates the next key frame following a specified position in a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Starting position to search in the stream.</param>
	/// <returns>Returns the position of the frame found or -1 if the search is unsuccessful.</returns>
	/// <remarks>
	/// <para>The search performed by this macro does not include the frame at the specified position.</para>
	/// <para>The <c>AVIStreamNextKeyFrame</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNextKeyFrame(pavi, lPos) \ AVIStreamFindSample(pavi, lPos + 1, FIND_NEXT | FIND_KEY)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnextkeyframe void AVIStreamNextKeyFrame( pavi, l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNextKeyFrame")]
	public static int AVIStreamNextKeyFrame(IAVIStream pavi, int lPos) => AVIStreamFindSample(pavi, lPos + 1, FINDF.FIND_NEXT | FINDF.FIND_KEY);

	/// <summary>
	/// The <c>AVIStreamNextKeyFrameTime</c> macro returns the time of the next key frame in the stream, starting at a given time.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="t">Position in the stream to begin searching.</param>
	/// <returns>Returns the converted time if successful or −1 otherwise.</returns>
	/// <remarks>
	/// <para>The search performed by this macro includes the frame that corresponds to the specified time.</para>
	/// <para>The <c>AVIStreamNextKeyFrameTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNextKeyFrameTime(pavi, time) \ AVIStreamSampleToTime(pavi, \ AVIStreamNextKeyFrame(pavi, \ AVIStreamTimeToSample(pavi, time)))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnextkeyframetime void AVIStreamNextKeyFrameTime( pavi, t );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNextKeyFrameTime")]
	public static int AVIStreamNextKeyFrameTime(IAVIStream pavi, int t) => AVIStreamSampleToTime(pavi, AVIStreamNextKeyFrame(pavi, AVIStreamTimeToSample(pavi, t)));

	/// <summary>The <c>AVIStreamNextSample</c> macro locates the next nonempty sample from a specified position in a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="l">Starting position to search in the stream.</param>
	/// <returns>Returns the position of the frame found or -1 if the search is unsuccessful.</returns>
	/// <remarks>
	/// <para>The sample position returned does not include the sample specified by lPos.</para>
	/// <para>The <c>AVIStreamNextSample</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNextSample(pavi, lPos) \ AVIStreamFindSample(pavi, lPos + 1, FIND_NEXT | FIND_ANY)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnextsample void AVIStreamNextSample( pavi, l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNextSample")]
	public static int AVIStreamNextSample(IAVIStream pavi, int l) => AVIStreamFindSample(pavi, l + 1, FINDF.FIND_NEXT | FINDF.FIND_ANY);

	/// <summary>
	/// The <c>AVIStreamNextSampleTime</c> macro returns the time that a sample changes to the next sample in the stream. This macro
	/// finds the next interesting time in a stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="t">Position information of the sample in the stream.</param>
	/// <returns>Returns the converted time if successful or −1 otherwise.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamNextSampleTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamNextSampleTime(pavi, time) \ AVIStreamSampleToTime(pavi, \ AVIStreamNextSample(pavi, \ AVIStreamTimeToSample(pavi, t)))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamnextsampletime void AVIStreamNextSampleTime( pavi, t );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamNextSampleTime")]
	public static int AVIStreamNextSampleTime(IAVIStream pavi, int t) => AVIStreamSampleToTime(pavi, AVIStreamNextSample(pavi, AVIStreamTimeToSample(pavi, t)));

	/// <summary>The <c>AVIStreamOpenFromFile</c> function opens a single stream from a file.</summary>
	/// <param name="ppavi">Pointer to a buffer that receives the new stream handle.</param>
	/// <param name="szFile">Null-terminated string containing the name of the file to open.</param>
	/// <param name="fccType">
	/// <para>
	/// Four-character code indicating the type of stream to be opened. Zero indicates that any stream can be opened. The following
	/// definitions apply to the data commonly found in AVI streams:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>streamtypeAUDIO</term>
	/// <term>Indicates an audio stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeMIDI</term>
	/// <term>Indicates a MIDI stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeTEXT</term>
	/// <term>Indicates a text stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeVIDEO</term>
	/// <term>Indicates a video stream.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lParam">
	/// Stream of the type specified in fccType to access. This parameter is zero-based; use zero to specify the first occurrence.
	/// </param>
	/// <param name="mode">
	/// Access mode to use when opening the file. This function can open only existing streams, so the OF_CREATE mode flag cannot be
	/// used. For more information about the available flags for the mode parameter, see the <c>OpenFile</c> function.
	/// </param>
	/// <param name="pclsidHandler">
	/// Pointer to a class identifier of the handler you want to use. If the value is <c>NULL</c>, the system chooses one from the
	/// registry based on the file extension or the file RIFF type.
	/// </param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>This function calls the AVIFileOpen, AVIFileGetStream, and AVIFileRelease functions.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVIStreamOpenFromFile as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamopenfromfilea HRESULT AVIStreamOpenFromFileA( IAVIStream
	// *ppavi, LPCSTR szFile, DWORD fccType, LONG lParam, UINT mode, CLSID *pclsidHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamOpenFromFileA")]
	public static extern HRESULT AVIStreamOpenFromFile(out IAVIStream ppavi, [MarshalAs(UnmanagedType.LPTStr)] string szFile, uint fccType,
		int lParam, Kernel32.OpenFileAction mode, in Guid pclsidHandler);

	/// <summary>The <c>AVIStreamOpenFromFile</c> function opens a single stream from a file.</summary>
	/// <param name="ppavi">Pointer to a buffer that receives the new stream handle.</param>
	/// <param name="szFile">Null-terminated string containing the name of the file to open.</param>
	/// <param name="fccType">
	/// <para>
	/// Four-character code indicating the type of stream to be opened. Zero indicates that any stream can be opened. The following
	/// definitions apply to the data commonly found in AVI streams:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>streamtypeAUDIO</term>
	/// <term>Indicates an audio stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeMIDI</term>
	/// <term>Indicates a MIDI stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeTEXT</term>
	/// <term>Indicates a text stream.</term>
	/// </item>
	/// <item>
	/// <term>streamtypeVIDEO</term>
	/// <term>Indicates a video stream.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lParam">
	/// Stream of the type specified in fccType to access. This parameter is zero-based; use zero to specify the first occurrence.
	/// </param>
	/// <param name="mode">
	/// Access mode to use when opening the file. This function can open only existing streams, so the OF_CREATE mode flag cannot be
	/// used. For more information about the available flags for the mode parameter, see the <c>OpenFile</c> function.
	/// </param>
	/// <param name="pclsidHandler">
	/// Pointer to a class identifier of the handler you want to use. If the value is <c>NULL</c>, the system chooses one from the
	/// registry based on the file extension or the file RIFF type.
	/// </param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>This function calls the AVIFileOpen, AVIFileGetStream, and AVIFileRelease functions.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVIStreamOpenFromFile as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamopenfromfilea HRESULT AVIStreamOpenFromFileA( IAVIStream
	// *ppavi, LPCSTR szFile, DWORD fccType, LONG lParam, UINT mode, CLSID *pclsidHandler );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamOpenFromFileA")]
	public static extern HRESULT AVIStreamOpenFromFile(out IAVIStream ppavi, [MarshalAs(UnmanagedType.LPTStr)] string szFile, uint fccType,
		int lParam, Kernel32.OpenFileAction mode, [In, Optional] GuidPtr pclsidHandler);

	/// <summary>The <c>AVIStreamPrevKeyFrame</c> macro locates the key frame that precedes a specified position in a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="l">Starting position to search in the stream.</param>
	/// <returns>Returns the position of the frame found or -1 if the search is unsuccessful.</returns>
	/// <remarks>
	/// <para>The search performed by this macro does not include the frame at the specified position.</para>
	/// <para>The <c>AVIStreamPrevKeyFrame</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamPrevKeyFrame(pavi, lPos) \ AVIStreamFindSample(pavi, lPos - 1, FIND_PREV | FIND_KEY)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamprevkeyframe void AVIStreamPrevKeyFrame( pavi, l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamPrevKeyFrame")]
	public static int AVIStreamPrevKeyFrame(IAVIStream pavi, int l) => AVIStreamFindSample(pavi, l - 1, FINDF.FIND_PREV | FINDF.FIND_KEY);

	/// <summary>
	/// The <c>AVIStreamPrevKeyFrameTime</c> macro returns the time of the previous key frame in the stream, starting at a given time.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="t">Position in the stream to begin searching.</param>
	/// <returns>Returns the converted time if successful or −1 otherwise.</returns>
	/// <remarks>
	/// <para>The search performed by this macro includes the frame that corresponds to the specified time.</para>
	/// <para>The <c>AVIStreamPrevKeyFrameTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamPrevKeyFrameTime(pavi, time) \ AVIStreamSampleToTime(pavi, AVIStreamPrevKeyFrame(pavi, AVIStreamTimeToSample(pavi, time)))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamprevkeyframetime void AVIStreamPrevKeyFrameTime( pavi, t );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamPrevKeyFrameTime")]
	public static int AVIStreamPrevKeyFrameTime(IAVIStream pavi, int t) => AVIStreamSampleToTime(pavi, AVIStreamPrevKeyFrame(pavi, AVIStreamTimeToSample(pavi, t)));

	/// <summary>
	/// The <c>AVIStreamPrevSample</c> macro locates the nearest nonempty sample that precedes a specified position in a stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="l">Starting position to search in the stream.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The sample position returned does not include the sample specified by lPos.</para>
	/// <para>The <c>AVIStreamPrevSample</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamPrevSample(pavi, lPos) \ AVIStreamFindSample(pavi, lPos - 1, FIND_PREV | FIND_ANY)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamprevsample void AVIStreamPrevSample( pavi, l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamPrevSample")]
	public static int AVIStreamPrevSample(IAVIStream pavi, int l) => AVIStreamFindSample(pavi, l - 1, FINDF.FIND_PREV | FINDF.FIND_ANY);

	/// <summary>
	/// The <c>AVIStreamPrevSampleTime</c> macro determines the time of the nearest nonempty sample that precedes a specified time in a stream.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="t">Position information of the sample in the stream.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamPrevSampleTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamPrevSampleTime(pavi, time) \ AVIStreamSampleToTime(pavi, \ AVIStreamPrevSample(pavi, \ AVIStreamTimeToSample(pavi, t)))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamprevsampletime void AVIStreamPrevSampleTime( pavi, t );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamPrevSampleTime")]
	public static int AVIStreamPrevSampleTime(IAVIStream pavi, int t) => AVIStreamSampleToTime(pavi, AVIStreamPrevSample(pavi, AVIStreamTimeToSample(pavi, t)));

	/// <summary>The <c>AVIStreamRead</c> function reads audio, video or other data from a stream according to the stream type.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lStart">First sample to read.</param>
	/// <param name="lSamples">
	/// Number of samples to read. You can also specify the value AVISTREAMREAD_CONVENIENT to let the stream handler determine the
	/// number of samples to read.
	/// </param>
	/// <param name="lpBuffer">Pointer to a buffer to contain the data.</param>
	/// <param name="cbBuffer">Size, in bytes, of the buffer pointed to by lpBuffer.</param>
	/// <param name="plBytes">
	/// Pointer to a buffer that receives the number of bytes of data written in the buffer referenced by lpBuffer. This value can be <c>NULL</c>.
	/// </param>
	/// <param name="plSamples">
	/// Pointer to a buffer that receives the number of samples written in the buffer referenced by lpBuffer. This value can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AVIERR_BUFFERTOOSMALL</term>
	/// <term>The buffer size cbBuffer was smaller than a single sample of data.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_MEMORY</term>
	/// <term>There was not enough memory to complete the read operation.</term>
	/// </item>
	/// <item>
	/// <term>AVIERR_FILEREAD</term>
	/// <term>A disk error occurred while reading the file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If lpBuffer is <c>NULL</c>, this function does not read any data; it returns information about the size of data that would be read.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamread HRESULT AVIStreamRead( IAVIStream pavi, LONG lStart,
	// LONG lSamples, LPVOID lpBuffer, LONG cbBuffer, LONG *plBytes, LONG *plSamples );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamRead")]
	public static extern HRESULT AVIStreamRead(IAVIStream pavi, int lStart, int lSamples, [Out, Optional] IntPtr lpBuffer, int cbBuffer, out int plBytes, out int plSamples);

	/// <summary>The <c>AVIStreamReadData</c> function reads optional header data from a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="fcc">Four-character code identifying the data.</param>
	/// <param name="lp">Pointer to the buffer to contain the optional header data.</param>
	/// <param name="lpcb">
	/// Pointer to the location that specifies the buffer size used for lpData. If the read is successful, AVIFile changes this value to
	/// indicate the amount of data written into the buffer for lpData.
	/// </param>
	/// <returns>
	/// Returns zero if successful or an error otherwise. The return value AVIERR_NODATA indicates the system could not find any data
	/// with the specified chunk identifier.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function retrieves only optional header information from the stream. This information is custom and does not have a set format.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamreaddata HRESULT AVIStreamReadData( IAVIStream pavi, DWORD
	// fcc, LPVOID lp, LONG *lpcb );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamReadData")]
	public static extern HRESULT AVIStreamReadData(IAVIStream pavi, uint fcc, [Out, Optional] IntPtr lp, ref int lpcb);

	/// <summary>The <c>AVIStreamReadFormat</c> function reads the stream format data.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Position in the stream used to obtain the format data.</param>
	/// <param name="lpFormat">Pointer to a buffer to contain the format data.</param>
	/// <param name="lpcbFormat">
	/// Pointer to a location indicating the size of the memory block referenced by lpFormat. On return, the value is changed to
	/// indicate the amount of data read. If lpFormat is <c>NULL</c>, this parameter can be used to obtain the amount of memory needed
	/// to return the format.
	/// </param>
	/// <returns>
	/// <para>Returns zero if successful or an error otherwise.</para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </returns>
	/// <remarks>
	/// Standard video stream handlers provide format information in a BITMAPINFOHEADER structure. Standard audio stream handlers
	/// provide format information in a PCMWAVEFORMAT structure. Other data streams can use other structures that describe the stream data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamreadformat HRESULT AVIStreamReadFormat( IAVIStream pavi,
	// LONG lPos, LPVOID lpFormat, LONG *lpcbFormat );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamReadFormat")]
	public static extern HRESULT AVIStreamReadFormat(IAVIStream pavi, int lPos, IntPtr lpFormat, ref int lpcbFormat);

	/// <summary>
	/// <para>
	/// The <c>AVIStreamRelease</c> function decrements the reference count of an AVI stream interface handle, and closes the stream if
	/// the count reaches zero.
	/// </para>
	/// <para>This function supersedes the obsolete <c>AVIStreamClose</c> function.</para>
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <returns>
	/// <para>Returns the current reference count of the stream. This value should be used only for debugging purposes.</para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamrelease ULONG AVIStreamRelease( IAVIStream pavi );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamRelease")]
	public static extern uint AVIStreamRelease(IAVIStream pavi);

	/// <summary>
	/// The AVIStreamRelease macro determines the size of the buffer needed to store one sample of information from a stream. The size
	/// corresponds to the sample at the position specified by lPos.
	/// </summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Position of a sample in the stream.</param>
	/// <param name="plSize">Address to contain the buffer size.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamSampleSize</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamSampleSize(pavi, lPos, plSize) \ AVIStreamRead(pavi, lPos, 1, NULL, 0, plSize, NULL)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamsamplesize void AVIStreamSampleSize( pavi, lPos, plSize );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamSampleSize")]
	public static HRESULT AVIStreamSampleSize(IAVIStream pavi, int lPos, out int plSize) => AVIStreamRead(pavi, lPos, 1, default, 0, out plSize, out _);

	/// <summary>
	/// The <c>AVIStreamSampleToSample</c> macro returns the sample in a stream that occurs at the same time as a sample that occurs in
	/// a second stream.
	/// </summary>
	/// <param name="pavi1">Handle to an open stream that contains the sample that is returned.</param>
	/// <param name="pavi2">Handle to a second stream that contains the reference sample.</param>
	/// <param name="l">Position information of the sample in the stream referenced by pavi2.</param>
	/// <returns>Returns the converted time if successful or -1 otherwise.</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamSampleToSample</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamSampleToSample(pavi1, pavi2, lsample) \ AVIStreamTimeToSample(pavi1, AVIStreamSampleToTime \ (pavi2, lsample))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamsampletosample void AVIStreamSampleToSample( pavi1, pavi2,
	// l );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamSampleToSample")]
	public static int AVIStreamSampleToSample(IAVIStream pavi1, IAVIStream pavi2, int l) => AVIStreamTimeToSample(pavi1, AVIStreamSampleToTime(pavi2, l));

	/// <summary>The <c>AVIStreamSampleToTime</c> function converts a stream position from samples to milliseconds.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lSample">
	/// Position information. A sample can correspond to blocks of audio, a video frame, or other format, depending on the stream type.
	/// </param>
	/// <returns>Returns the converted time if successful or −1 otherwise.</returns>
	/// <remarks>The argument pavi is a pointer to an IAVIStream interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamsampletotime LONG AVIStreamSampleToTime( IAVIStream pavi,
	// LONG lSample );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamSampleToTime")]
	public static extern int AVIStreamSampleToTime(IAVIStream pavi, int lSample);

	/// <summary>The <c>AVIStreamSetFormat</c> function sets the format of a stream at the specified position.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lPos">Position in the stream to receive the format.</param>
	/// <param name="lpFormat">Pointer to a structure containing the new format.</param>
	/// <param name="cbFormat">Size, in bytes, of the block of memory referenced by lpFormat.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The handler for writing AVI files does not accept format changes. Besides setting the initial format for a stream, only changes
	/// in the palette of a video stream are allowed in an AVI file. The palette change must occur after any frames already written to
	/// the AVI file. Other handlers might impose different restrictions.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamsetformat HRESULT AVIStreamSetFormat( IAVIStream pavi,
	// LONG lPos, LPVOID lpFormat, LONG cbFormat );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamSetFormat")]
	public static extern HRESULT AVIStreamSetFormat(IAVIStream pavi, int lPos, [In] IntPtr lpFormat, int cbFormat);

	/// <summary>The <c>AVIStreamStart</c> function returns the starting sample number for the stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <returns>Returns the number if successful or -1 otherwise.</returns>
	/// <remarks>The argument pavi is a pointer to an IAVIStream interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamstart LONG AVIStreamStart( IAVIStream pavi );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamStart")]
	public static extern int AVIStreamStart(IAVIStream pavi);

	/// <summary>The <c>AVIStreamStartTime</c> macro returns the starting time of a stream's first sample.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The <c>AVIStreamStartTime</c> macro is defined as follows:</para>
	/// <para>
	/// <code> #define AVIStreamStartTime(pavi) \ AVIStreamSampleToTime(pavi, AVIStreamStart(pavi))</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamstarttime void AVIStreamStartTime( pavi );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamStartTime")]
	public static int AVIStreamStartTime(IAVIStream pavi) => AVIStreamSampleToTime(pavi, AVIStreamStart(pavi));

	/// <summary>The <c>AVIStreamTimeToSample</c> function converts from milliseconds to samples.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lTime">Time, expressed in milliseconds.</param>
	/// <returns>Returns the converted time if successful or -1 otherwise.</returns>
	/// <remarks>
	/// <para>
	/// Samples typically correspond to audio samples or video frames. Other stream types might support different formats than these.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamtimetosample LONG AVIStreamTimeToSample( IAVIStream pavi,
	// LONG lTime );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamTimeToSample")]
	public static extern int AVIStreamTimeToSample(IAVIStream pavi, int lTime);

	/// <summary>The <c>AVIStreamWrite</c> function writes data to a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lStart">First sample to write.</param>
	/// <param name="lSamples">Number of samples to write.</param>
	/// <param name="lpBuffer">Pointer to a buffer containing the data to write.</param>
	/// <param name="cbBuffer">Size of the buffer referenced by lpBuffer.</param>
	/// <param name="dwFlags">
	/// <para>Flag associated with this data. The following flag is defined:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AVIIF_KEYFRAME</term>
	/// <term>Indicates this data does not rely on preceding data in the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plSampWritten">Pointer to a buffer that receives the number of samples written. This can be set to <c>NULL</c>.</param>
	/// <param name="plBytesWritten">Pointer to a buffer that receives the number of bytes written. This can be set to <c>NULL</c>.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>The default AVI file handler supports writing only at the end of a stream. The "WAVE" file handler supports writing anywhere.</para>
	/// <para>This function overwrites existing data, rather than inserting new data.</para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamwrite HRESULT AVIStreamWrite( IAVIStream pavi, LONG
	// lStart, LONG lSamples, LPVOID lpBuffer, LONG cbBuffer, DWORD dwFlags, LONG *plSampWritten, LONG *plBytesWritten );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamWrite")]
	public static extern HRESULT AVIStreamWrite([In] IAVIStream pavi, int lStart, int lSamples, [In] IntPtr lpBuffer, int cbBuffer, AVIIF dwFlags, out int plSampWritten, out int plBytesWritten);

	/// <summary>The <c>AVIStreamWriteData</c> function writes optional header information to the stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="fcc">Four-character code identifying the data.</param>
	/// <param name="lp">Pointer to a buffer containing the data to write.</param>
	/// <param name="cb">Number of bytes of data to write into the stream.</param>
	/// <returns>
	/// Returns zero if successful or an error otherwise. The return value AVIERR_READONLY indicates the file was opened without write access.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the AVIStreamWrite function to write the multimedia content of the stream. Use AVIFileWriteData to write data that applies
	/// to an entire file.
	/// </para>
	/// <para>The argument pavi is a pointer to an IAVIStream interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-avistreamwritedata HRESULT AVIStreamWriteData( IAVIStream pavi,
	// DWORD fcc, LPVOID lp, LONG cb );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.AVIStreamWriteData")]
	public static extern HRESULT AVIStreamWriteData(IAVIStream pavi, uint fcc, [In] IntPtr lp, int cb);

	/// <summary>Macro to make a TWOCC out of two characters</summary>
	/// <param name="ch0">The first character.</param>
	/// <param name="ch1">The second character.</param>
	/// <returns>A <see cref="ushort"/> TWOCC value.</returns>
	public static ushort aviTWOCC(char ch0, char ch1) => (ushort)((byte)ch0 | ((byte)ch1 << 8));

	/// <summary>
	/// The <c>CreateEditableStream</c> function creates an editable stream. Use this function before using other stream editing functions.
	/// </summary>
	/// <param name="ppsEditable">Pointer to a buffer that receives the new stream handle.</param>
	/// <param name="psSource">
	/// Handle to the stream supplying data for the new stream. Specify <c>NULL</c> to create an empty editable string that you can copy
	/// and paste data into.
	/// </param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>The stream pointer returned in ppsEditable must be used as the source stream in the other stream editing functions.</para>
	/// <para>
	/// Internally, this function creates tables to keep track of changes to a stream. The original stream is never changed by the
	/// stream editing functions. The stream pointer created by this function can be used in any AVIFile function that accepts stream
	/// pointers. You can use this function on the same stream multiple times. A copy of a stream is not affected by changes in another copy.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-createeditablestream HRESULT CreateEditableStream( PAVISTREAM
	// *ppsEditable, PAVISTREAM psSource );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.CreateEditableStream")]
	public static extern HRESULT CreateEditableStream(out IAVIStream ppsEditable, [In] IAVIStream psSource);

	/// <summary>The <c>EditStreamClone</c> function creates a duplicate editable stream.</summary>
	/// <param name="pavi">Handle to an editable stream that will be copied.</param>
	/// <param name="ppResult">Pointer to a buffer that receives the new stream handle.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The editable stream that is being cloned must have been created by the <c>CreateEditableStream</c> function or one of the stream
	/// editing functions.
	/// </para>
	/// <para>The new stream can be treated as any other AVI stream.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-editstreamclone HRESULT EditStreamClone( PAVISTREAM pavi,
	// PAVISTREAM *ppResult );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.EditStreamClone")]
	public static extern HRESULT EditStreamClone([In] IAVIStream pavi, out IAVIStream ppResult);

	/// <summary>The <c>EditStreamCopy</c> function copies an editable stream (or a portion of it) into a temporary stream.</summary>
	/// <param name="pavi">Handle to the stream being copied.</param>
	/// <param name="plStart">Starting position within the stream being copied. The starting position is returned.</param>
	/// <param name="plLength">Amount of data to copy from the stream referenced by pavi. The length of the copied data is returned.</param>
	/// <param name="ppResult">Pointer to a buffer that receives the handle created for the new stream.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>The stream that is copied must be created by the <c>CreateEditableStream</c> function or one of the stream editing functions.</para>
	/// <para>The temporary stream can be treated as any other AVI stream.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-editstreamcopy HRESULT EditStreamCopy( PAVISTREAM pavi, LONG
	// *plStart, LONG *plLength, PAVISTREAM *ppResult );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.EditStreamCopy")]
	public static extern HRESULT EditStreamCopy([In] IAVIStream pavi, ref int plStart, ref int plLength, out IAVIStream ppResult);

	/// <summary>
	/// The <c>EditStreamCut</c> function deletes all or part of an editable stream and creates a temporary editable stream from the
	/// deleted portion of the stream.
	/// </summary>
	/// <param name="pavi">Handle to the stream being edited.</param>
	/// <param name="plStart">Starting position of the data to cut from the stream referenced by pavi.</param>
	/// <param name="plLength">Amount of data to cut from the stream referenced by pavi.</param>
	/// <param name="ppResult">Pointer to the handle created for the new stream.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The stream being edited must have been created by the <c>CreateEditableStream</c> function or one of the stream editing functions.
	/// </para>
	/// <para>
	/// The temporary stream is an editable stream and can be treated as any other AVI stream. An application must release the temporary
	/// stream to free the resources associated with it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-editstreamcut HRESULT EditStreamCut( PAVISTREAM pavi, LONG
	// *plStart, LONG *plLength, PAVISTREAM *ppResult );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.EditStreamCut")]
	public static extern HRESULT EditStreamCut([In] IAVIStream pavi, ref int plStart, ref int plLength, out IAVIStream ppResult);

	/// <summary>
	/// The <c>EditStreamPaste</c> function copies a stream (or a portion of it) from one stream and pastes it within another stream at
	/// a specified location.
	/// </summary>
	/// <param name="pavi">Handle to an editable stream that will receive the copied stream data.</param>
	/// <param name="plPos">Starting position to paste the data within the destination stream (referenced by pavi).</param>
	/// <param name="plLength">Pointer to a buffer that receives the amount of data pasted in the stream.</param>
	/// <param name="pstream">Handle to a stream supplying the data to paste. This stream does not need to be an editable stream.</param>
	/// <param name="lStart">Starting position of the data to copy within the source stream.</param>
	/// <param name="lEnd">
	/// Amount of data to copy from the source stream. If lLength is -1, the entire stream referenced by pstream is pasted in the other stream.
	/// </param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The stream referenced by pavi must have been created by the <c>CreateEditableStream</c> function or one of the stream editing functions.
	/// </para>
	/// <para>
	/// This function inserts data into the specified stream as a continuous block of data. It opens the specified data stream at the
	/// insertion point, pastes the specified stream segment at the insertion point, and appends the stream segment that trails the
	/// insertion point to the end of pasted segment.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-editstreampaste HRESULT EditStreamPaste( PAVISTREAM pavi, LONG
	// *plPos, LONG *plLength, PAVISTREAM pstream, LONG lStart, LONG lEnd );
	[DllImport(Lib_Avifil32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.EditStreamPaste")]
	public static extern HRESULT EditStreamPaste([In] IAVIStream pavi, ref int plPos, ref int plLength, [In] IAVIStream pstream, int lStart, int lEnd);

	/// <summary>The <c>EditStreamSetInfo</c> function changes characteristics of an editable stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lpInfo">Pointer to an AVISTREAMINFO structure containing new information.</param>
	/// <param name="cbInfo">Size, in bytes, of the structure pointed to by lpInfo.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// You must supply information for the entire AVISTREAMINFO structure, including the members you will not use. You can use the
	/// AVIStreamInfo function to initialize the structure and then update selected members with your data.
	/// </para>
	/// <para>This function does not change the following members:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>dwCaps</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwEditCount</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwFlags</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwInitialFrames</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwLength</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwSampleSize</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwSuggestedBufferSize</c></term>
	/// </item>
	/// <item>
	/// <term><c>fccHandler</c></term>
	/// </item>
	/// <item>
	/// <term><c>fccType</c></term>
	/// </item>
	/// </list>
	/// <para>The function changes the following members:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>dwRate</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwQuality</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwScale</c></term>
	/// </item>
	/// <item>
	/// <term><c>dwStart</c></term>
	/// </item>
	/// <item>
	/// <term><c>rcFrame</c></term>
	/// </item>
	/// <item>
	/// <term><c>szName</c></term>
	/// </item>
	/// <item>
	/// <term><c>wLanguage</c></term>
	/// </item>
	/// <item>
	/// <term><c>wPriority</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines EditStreamSetInfo as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-editstreamsetinfoa HRESULT EditStreamSetInfoA( PAVISTREAM pavi,
	// LPAVISTREAMINFOA lpInfo, LONG cbInfo );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.EditStreamSetInfoA")]
	public static extern HRESULT EditStreamSetInfo([In] IAVIStream pavi, in AVISTREAMINFO lpInfo, int cbInfo);

	/// <summary>The <c>EditStreamSetName</c> function assigns a descriptive string to a stream.</summary>
	/// <param name="pavi">Handle to an open stream.</param>
	/// <param name="lpszName">Null-terminated string containing the description of the stream.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>This function updates the <c>szName</c> member of the <c>AVISTREAMINFO</c> structure.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines EditStreamSetName as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-editstreamsetnamea HRESULT EditStreamSetNameA( PAVISTREAM pavi,
	// LPCSTR lpszName );
	[DllImport(Lib_Avifil32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.EditStreamSetNameA")]
	public static extern HRESULT EditStreamSetName([In] IAVIStream pavi, [MarshalAs(UnmanagedType.LPTStr)] string lpszName);

	/// <summary>
	/// The <c>AVICOMPRESSOPTIONS</c> structure contains information about a stream and how it is compressed and saved. This structure
	/// passes data to the AVIMakeCompressedStream function (or the AVISave function, which uses <c>AVIMakeCompressedStream</c>).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-avicompressoptions typedef struct { DWORD fccType; DWORD
	// fccHandler; DWORD dwKeyFrameEvery; DWORD dwQuality; DWORD dwBytesPerSecond; DWORD dwFlags; LPVOID lpFormat; DWORD cbFormat;
	// LPVOID lpParms; DWORD cbParms; DWORD dwInterleaveEvery; } AVICOMPRESSOPTIONS, *LPAVICOMPRESSOPTIONS;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_17")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AVICOMPRESSOPTIONS
	{
		/// <summary>
		/// <para>
		/// Four-character code indicating the stream type. The following constants have been defined for the data commonly found in AVI streams:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>streamtypeAUDIO</term>
		/// <term>Indicates an audio stream.</term>
		/// </item>
		/// <item>
		/// <term>streamtypeMIDI</term>
		/// <term>Indicates a MIDI stream.</term>
		/// </item>
		/// <item>
		/// <term>streamtypeTEXT</term>
		/// <term>Indicates a text stream.</term>
		/// </item>
		/// <item>
		/// <term>streamtypeVIDEO</term>
		/// <term>Indicates a video stream.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint fccType;

		/// <summary>
		/// Four-character code for the compressor handler that will compress this video stream when it is saved (for example,
		/// mmioFOURCC ('M','S','V','C')). This member is not used for audio streams.
		/// </summary>
		public uint fccHandler;

		/// <summary>
		/// Maximum period between video key frames. This member is used only if the AVICOMPRESSF_KEYFRAMES flag is set; otherwise every
		/// video frame is a key frame.
		/// </summary>
		public uint dwKeyFrameEvery;

		/// <summary>Quality value passed to a video compressor. This member is not used for an audio compressor.</summary>
		public uint dwQuality;

		/// <summary>Video compressor data rate. This member is used only if the AVICOMPRESSF_DATARATE flag is set.</summary>
		public uint dwBytesPerSecond;

		/// <summary>
		/// <para>Flags used for compression. The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AVICOMPRESSF_DATARATE</term>
		/// <term>Compresses this video stream using the data rate specified in dwBytesPerSecond.</term>
		/// </item>
		/// <item>
		/// <term>AVICOMPRESSF_INTERLEAVE</term>
		/// <term>Interleaves this stream every dwInterleaveEvery frames with respect to the first stream.</term>
		/// </item>
		/// <item>
		/// <term>AVICOMPRESSF_KEYFRAMES</term>
		/// <term>
		/// Saves this video stream with key frames at least every dwKeyFrameEvery frames. By default, every frame will be a key frame.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AVICOMPRESSF_VALID</term>
		/// <term>
		/// Uses the data in this structure to set the default compression values for AVISaveOptions. If an empty structure is passed
		/// and this flag is not set, some defaults will be chosen.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public AVICOMPRESSF dwFlags;

		/// <summary>Pointer to a structure defining the data format. For an audio stream, this is an <c>LPWAVEFORMAT</c> structure.</summary>
		public IntPtr lpFormat;

		/// <summary>Size, in bytes, of the data referenced by <c>lpFormat</c>.</summary>
		public uint cbFormat;

		/// <summary>Video-compressor-specific data; used internally.</summary>
		public IntPtr lpParms;

		/// <summary>Size, in bytes, of the data referenced by <c>lpParms</c></summary>
		public uint cbParms;

		/// <summary>
		/// Interleave factor for interspersing stream data with data from the first stream. Used only if the AVICOMPRESSF_INTERLEAVE
		/// flag is set.
		/// </summary>
		public uint dwInterleaveEvery;
	}

	/// <summary>The <c>AVIFILEINFO</c> structure contains global information for an entire AVI file.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVIFILEINFO as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-avifileinfoa typedef struct _AVIFILEINFOA { DWORD dwMaxBytesPerSec;
	// DWORD dwFlags; DWORD dwCaps; DWORD dwStreams; DWORD dwSuggestedBufferSize; DWORD dwWidth; DWORD dwHeight; DWORD dwScale; DWORD
	// dwRate; DWORD dwLength; DWORD dwEditCount; char szFileType[64]; } AVIFILEINFOA, *LPAVIFILEINFOA;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw._AVIFILEINFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct AVIFILEINFO
	{
		/// <summary>Approximate maximum data rate of the AVI file.</summary>
		public uint dwMaxBytesPerSec;

		/// <summary>
		/// <para>A bitwise <c>OR</c> of zero or more flags. The following flags are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AVIFILEINFO_HASINDEX</term>
		/// <term>The AVI file has an index at the end of the file. For good performance, all AVI files should contain an index.</term>
		/// </item>
		/// <item>
		/// <term>AVIFILEINFO_MUSTUSEINDEX</term>
		/// <term>
		/// The file index contains the playback order for the chunks in the file. Use the index rather than the physical ordering of
		/// the chunks when playing back the data. This could be used for creating a list of frames for editing.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AVIFILEINFO_ISINTERLEAVED</term>
		/// <term>The AVI file is interleaved.</term>
		/// </item>
		/// <item>
		/// <term>AVIFILEINFO_WASCAPTUREFILE</term>
		/// <term>
		/// The AVI file is a specially allocated file used for capturing real-time video. Applications should warn the user before
		/// writing over a file with this flag set because the user probably defragmented this file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AVIFILEINFO_COPYRIGHTED</term>
		/// <term>
		/// The AVI file contains copyrighted data and software. When this flag is used, software should not permit the data to be duplicated.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public AVIFILEINFOF dwFlags;

		/// <summary>
		/// <para>Capability flags. The following flags are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AVIFILECAPS_CANREAD</term>
		/// <term>An application can open the AVI file with the read privilege.</term>
		/// </item>
		/// <item>
		/// <term>AVIFILECAPS_CANWRITE</term>
		/// <term>An application can open the AVI file with the write privilege.</term>
		/// </item>
		/// <item>
		/// <term>AVIFILECAPS_ALLKEYFRAMES</term>
		/// <term>Every frame in the AVI file is a key frame.</term>
		/// </item>
		/// <item>
		/// <term>AVIFILECAPS_NOCOMPRESSION</term>
		/// <term>The AVI file does not use a compression method.</term>
		/// </item>
		/// </list>
		/// </summary>
		public AVIFILECAPS dwCaps;

		/// <summary>Number of streams in the file. For example, a file with audio and video has at least two streams.</summary>
		public uint dwStreams;

		/// <summary>
		/// <para>
		/// Suggested buffer size, in bytes, for reading the file. Generally, this size should be large enough to contain the largest
		/// chunk in the file. For an interleaved file, this size should be large enough to read an entire record, not just a chunk.
		/// </para>
		/// <para>
		/// If the buffer size is too small or is set to zero, the playback software will have to reallocate memory during playback,
		/// reducing performance.
		/// </para>
		/// </summary>
		public uint dwSuggestedBufferSize;

		/// <summary>Width, in pixels, of the AVI file.</summary>
		public uint dwWidth;

		/// <summary>Height, in pixels, of the AVI file.</summary>
		public uint dwHeight;

		/// <summary>
		/// <para>
		/// Time scale applicable for the entire file. Dividing <c>dwRate</c> by <c>dwScale</c> gives the number of samples per second.
		/// </para>
		/// <para>Any stream can define its own time scale to supersede the file time scale.</para>
		/// </summary>
		public uint dwScale;

		/// <summary>Rate in an integer format. To obtain the rate in samples per second, divide this value by the value in <c>dwScale</c>.</summary>
		public uint dwRate;

		/// <summary>Length of the AVI file. The units are defined by <c>dwRate</c> and <c>dwScale</c>.</summary>
		public uint dwLength;

		/// <summary>Number of streams that have been added to or deleted from the AVI file.</summary>
		public uint dwEditCount;

		/// <summary>Null-terminated string containing descriptive information for the file type.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string szFileType;
	}

	/// <summary>The <c>AVISTREAMINFO</c> structure contains information for a single stream.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines AVISTREAMINFO as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-avistreaminfoa typedef struct _AVISTREAMINFOA { DWORD fccType;
	// DWORD fccHandler; DWORD dwFlags; DWORD dwCaps; WORD wPriority; WORD wLanguage; DWORD dwScale; DWORD dwRate; DWORD dwStart; DWORD
	// dwLength; DWORD dwInitialFrames; DWORD dwSuggestedBufferSize; DWORD dwQuality; DWORD dwSampleSize; RECT rcFrame; DWORD
	// dwEditCount; DWORD dwFormatChangeCount; char szName[64]; } AVISTREAMINFOA, *LPAVISTREAMINFOA;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw._AVISTREAMINFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct AVISTREAMINFO
	{
		/// <summary>
		/// <para>
		/// Four-character code indicating the stream type. The following constants have been defined for the data commonly found in AVI streams:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>streamtypeAUDIO</term>
		/// <term>Indicates an audio stream.</term>
		/// </item>
		/// <item>
		/// <term>streamtypeMIDI</term>
		/// <term>Indicates a MIDI stream.</term>
		/// </item>
		/// <item>
		/// <term>streamtypeTEXT</term>
		/// <term>Indicates a text stream.</term>
		/// </item>
		/// <item>
		/// <term>streamtypeVIDEO</term>
		/// <term>Indicates a video stream.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint fccType;

		/// <summary>
		/// Four-character code of the compressor handler that will compress this video stream when it is saved (for example, mmioFOURCC
		/// ('M','S','V','C')). This member is not used for audio streams.
		/// </summary>
		public uint fccHandler;

		/// <summary>
		/// <para>
		/// Applicable flags for the stream. The bits in the high-order word of these flags are specific to the type of data contained
		/// in the stream. The following flags are defined:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AVISTREAMINFO_DISABLED</term>
		/// <term>Indicates this stream should be rendered when explicitly enabled by the user.</term>
		/// </item>
		/// <item>
		/// <term>AVISTREAMINFO_FORMATCHANGES</term>
		/// <term>
		/// Indicates this video stream contains palette changes. This flag warns the playback software that it will need to animate the palette.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public AVISTREAMINFOF dwFlags;

		/// <summary>Capability flags; currently unused.</summary>
		public uint dwCaps;

		/// <summary>Priority of the stream.</summary>
		public ushort wPriority;

		/// <summary>Language of the stream.</summary>
		public ushort wLanguage;

		/// <summary>
		/// <para>
		/// Time scale applicable for the stream. Dividing <c>dwRate</c> by <c>dwScale</c> gives the playback rate in number of samples
		/// per second.
		/// </para>
		/// <para>
		/// For video streams, this rate should be the frame rate. For audio streams, this rate should correspond to the audio block
		/// size (the <c>nBlockAlign</c> member of the WAVEFORMAT or PCMWAVEFORMAT structure), which for PCM (Pulse Code Modulation)
		/// audio reduces to the sample rate.
		/// </para>
		/// </summary>
		public uint dwScale;

		/// <summary>Rate in an integer format. To obtain the rate in samples per second, divide this value by the value in <c>dwScale</c>.</summary>
		public uint dwRate;

		/// <summary>
		/// <para>
		/// Sample number of the first frame of the AVI file. The units are defined by dwRate and <c>dwScale</c>. Normally, this is
		/// zero, but it can specify a delay time for a stream that does not start concurrently with the file.
		/// </para>
		/// <para>The 1.0 release of the AVI tools does not support a nonzero starting time.</para>
		/// </summary>
		public uint dwStart;

		/// <summary>Length of this stream. The units are defined by <c>dwRate</c> and <c>dwScale</c>.</summary>
		public uint dwLength;

		/// <summary>
		/// Audio skew. This member specifies how much to skew the audio data ahead of the video frames in interleaved files. Typically,
		/// this is about 0.75 seconds.
		/// </summary>
		public uint dwInitialFrames;

		/// <summary>
		/// Recommended buffer size, in bytes, for the stream. Typically, this member contains a value corresponding to the largest
		/// chunk in the stream. Using the correct buffer size makes playback more efficient. Use zero if you do not know the correct
		/// buffer size.
		/// </summary>
		public uint dwSuggestedBufferSize;

		/// <summary>
		/// Quality indicator of the video data in the stream. Quality is represented as a number between 0 and 10,000. For compressed
		/// data, this typically represents the value of the quality parameter passed to the compression software. If set to –1, drivers
		/// use the default quality value.
		/// </summary>
		public uint dwQuality;

		/// <summary>
		/// <para>
		/// Size, in bytes, of a single data sample. If the value of this member is zero, the samples can vary in size and each data
		/// sample (such as a video frame) must be in a separate chunk. A nonzero value indicates that multiple samples of data can be
		/// grouped into a single chunk within the file.
		/// </para>
		/// <para>
		/// For video streams, this number is typically zero, although it can be nonzero if all video frames are the same size. For
		/// audio streams, this number should be the same as the <c>nBlockAlign</c> member of the WAVEFORMAT or WAVEFORMATEX structure
		/// describing the audio.
		/// </para>
		/// </summary>
		public uint dwSampleSize;

		/// <summary>
		/// Dimensions of the video destination rectangle. The values represent the coordinates of upper left corner, the height, and
		/// the width of the rectangle.
		/// </summary>
		public RECT rcFrame;

		/// <summary>Number of times the stream has been edited. The stream handler maintains this count.</summary>
		public uint dwEditCount;

		/// <summary>Number of times the stream format has changed. The stream handler maintains this count.</summary>
		public uint dwFormatChangeCount;

		/// <summary>Null-terminated string containing a description of the stream.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string szName;
	}
}