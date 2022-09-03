using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Items from the Remote Differential Compression (RDC) API which allows applications to synchronize data between two computers in an
	/// efficient manner.
	/// </summary>
	public static partial class MsRdc
	{
		/// <summary/>
		public const uint MSRDC_DEFAULT_COMPAREBUFFER = 3200000;

		/// <summary/>
		public const uint MSRDC_DEFAULT_HASHWINDOWSIZE_1 = 48;

		/// <summary/>
		public const uint MSRDC_DEFAULT_HASHWINDOWSIZE_N = 2;

		/// <summary/>
		public const uint MSRDC_DEFAULT_HORIZONSIZE_1 = 1024;

		/// <summary/>
		public const uint MSRDC_DEFAULT_HORIZONSIZE_N = 128;

		/// <summary/>
		public const uint MSRDC_MAXIMUM_COMPAREBUFFER = (1 << 30);

		/// <summary/>
		public const uint MSRDC_MAXIMUM_DEPTH = 8;

		/// <summary/>
		public const uint MSRDC_MAXIMUM_HASHWINDOWSIZE = 96;

		/// <summary/>
		public const uint MSRDC_MAXIMUM_HORIZONSIZE = 1024 * 16;

		/// <summary/>
		public const uint MSRDC_MAXIMUM_MATCHESREQUIRED = 16;

		/// <summary/>
		public const uint MSRDC_MAXIMUM_TRAITVALUE = 63;

		/// <summary/>
		public const uint MSRDC_MINIMUM_COMPAREBUFFER = 100000;

		/// <summary/>
		public const uint MSRDC_MINIMUM_COMPATIBLE_APP_VERSION = 0x010000;

		/// <summary/>
		public const uint MSRDC_MINIMUM_DEPTH = 1;

		/// <summary/>
		public const uint MSRDC_MINIMUM_HASHWINDOWSIZE = 2;

		/// <summary/>
		public const uint MSRDC_MINIMUM_HORIZONSIZE = 128;

		/// <summary/>
		public const uint MSRDC_MINIMUM_INPUTBUFFERSIZE = 1024;

		/// <summary/>
		public const uint MSRDC_MINIMUM_MATCHESREQUIRED = 1;

		/// <summary/>
		public const int MSRDC_SIGNATURE_HASHSIZE = 16;

		/// <summary/>
		public const uint MSRDC_VERSION = 0x010000;

		/// <summary>The <c>GeneratorParametersType</c> enumeration type defines the set of supported generator parameters.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ne-msrdc-generatorparameterstype typedef enum
		// __MIDL___MIDL_itf_msrdc_0000_0000_0002 { RDCGENTYPE_Unused = 0, RDCGENTYPE_FilterMax } GeneratorParametersType;
		[PInvokeData("msrdc.h", MSDNShortId = "NE:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0002")]
		public enum GeneratorParametersType
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>The generator parameters type is unknown.</para>
			/// </summary>
			RDCGENTYPE_Unused,

			/// <summary>The FilterMax generator was used to generate the parameters.</summary>
			RDCGENTYPE_FilterMax,
		}

		/// <summary>The <c>RDC_ErrorCode</c> enumeration type defines the set of RDC-specific error codes.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ne-msrdc-rdc_errorcode typedef enum
		// __MIDL___MIDL_itf_msrdc_0000_0000_0001 { RDC_NoError = 0, RDC_HeaderVersionNewer, RDC_HeaderVersionOlder,
		// RDC_HeaderMissingOrCorrupt, RDC_HeaderWrongType, RDC_DataMissingOrCorrupt, RDC_DataTooManyRecords, RDC_FileChecksumMismatch,
		// RDC_ApplicationError, RDC_Aborted, RDC_Win32Error } RDC_ErrorCode;
		[PInvokeData("msrdc.h", MSDNShortId = "NE:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0001")]
		public enum RDC_ErrorCode
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>The operation was completed successfully.</para>
			/// </summary>
			RDC_NoError,

			/// <summary>The data header is incompatible with this library.</summary>
			RDC_HeaderVersionNewer,

			/// <summary>The data header is incompatible with this library.</summary>
			RDC_HeaderVersionOlder,

			/// <summary>The data header is missing or corrupt.</summary>
			RDC_HeaderMissingOrCorrupt,

			/// <summary>The data header format is incorrect.</summary>
			RDC_HeaderWrongType,

			/// <summary>The end of data was reached before all data expected was read.</summary>
			RDC_DataMissingOrCorrupt,

			/// <summary>Additional data was found past where the end of data was expected.</summary>
			RDC_DataTooManyRecords,

			/// <summary>The final file checksum doesn't match.</summary>
			RDC_FileChecksumMismatch,

			/// <summary>An application callback function returned failure.</summary>
			RDC_ApplicationError,

			/// <summary>The operation was aborted.</summary>
			RDC_Aborted,

			/// <summary>
			/// <para>The failure of the function is not RDC-specific and the</para>
			/// <para>HRESULT</para>
			/// <para>returned by</para>
			/// <para>the function contains the specific error code.</para>
			/// </summary>
			RDC_Win32Error,
		}

		/// <summary>Defines values that describe the state of the similarity traits table, similarity file ID table, or both.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ne-msrdc-rdccreatedtables typedef enum
		// __MIDL___MIDL_itf_msrdc_0000_0000_0009 { RDCTABLE_InvalidOrUnknown = 0, RDCTABLE_Existing, RDCTABLE_New } RdcCreatedTables;
		[PInvokeData("msrdc.h", MSDNShortId = "NE:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0009")]
		public enum RdcCreatedTables
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>The table contains data that is not valid.</para>
			/// </summary>
			RDCTABLE_InvalidOrUnknown,

			/// <summary>The table is an existing table.</summary>
			RDCTABLE_Existing,

			/// <summary>The table is a new table.</summary>
			RDCTABLE_New,
		}

		/// <summary>Defines the access mode values for RDC file mapping objects.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ne-msrdc-rdcmappingaccessmode typedef enum
		// __MIDL___MIDL_itf_msrdc_0000_0000_0010 { RDCMAPPING_Undefined = 0, RDCMAPPING_ReadOnly, RDCMAPPING_ReadWrite } RdcMappingAccessMode;
		[PInvokeData("msrdc.h", MSDNShortId = "NE:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0010")]
		public enum RdcMappingAccessMode
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>The mapping access mode is unknown.</para>
			/// </summary>
			RDCMAPPING_Undefined,

			/// <summary>Specifies read-only access.</summary>
			RDCMAPPING_ReadOnly,

			/// <summary>Specifies read/write access.</summary>
			RDCMAPPING_ReadWrite,
		}

		/// <summary>Defines the set of data chunks used to generate a remote copy.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ne-msrdc-rdcneedtype typedef enum __MIDL___MIDL_itf_msrdc_0000_0000_0003
		// { RDCNEED_SOURCE = 0, RDCNEED_TARGET = 1, RDCNEED_SEED = 2, RDCNEED_SEED_MAX = 255 } RdcNeedType;
		[PInvokeData("msrdc.h", MSDNShortId = "NE:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0003")]
		public enum RdcNeedType
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>The chunk is a source chunk.</para>
			/// </summary>
			RDCNEED_SOURCE,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1</para>
			/// <para>This value is reserved for future use.</para>
			/// </summary>
			RDCNEED_TARGET,

			/// <summary>
			/// <para>Value:</para>
			/// <para>2</para>
			/// <para>The chunk is a seed chunk.</para>
			/// </summary>
			RDCNEED_SEED,

			/// <summary>
			/// <para>Value:</para>
			/// <para>255</para>
			/// <para>This value is reserved for future use.</para>
			/// </summary>
			RDCNEED_SEED_MAX = 255,
		}

		/// <summary>Provides methods for retrieving information from the file list returned by the ISimilarity::FindSimilarFileId method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-ifindsimilarresults
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IFindSimilarResults")]
		[ComImport, Guid("96236A81-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FindSimilarResults))]
		public interface IFindSimilarResults
		{
			/// <summary>
			/// <para>Retrieves the number of entries in the file list that was returned by the ISimilarity::FindSimilarFileId method.</para>
			/// <para>
			/// The actual number of similarity file IDs that are returned by the GetNextFileId method may be less than the number that is
			/// returned by the <c>GetSize</c> method. <c>GetNextFileId</c> returns only valid similarity file IDs. However, <c>GetSize</c>
			/// counts all entries, even if their similarity file IDs are not valid.
			/// </para>
			/// </summary>
			/// <returns>A pointer to a variable that receives the number of entries in the file list.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-ifindsimilarresults-getsize HRESULT GetSize( [out] DWORD
			// *size );
			uint GetSize();

			/// <summary>
			/// Retrieves the next valid similarity file ID in the file list that was returned by the ISimilarity::FindSimilarFileId method.
			/// </summary>
			/// <param name="numTraitsMatched">A pointer to a variable that receives the number of traits that were matched.</param>
			/// <param name="similarityFileId">
			/// A pointer to a SimilarityFileId structure that contains the similarity file ID of the matching file.
			/// </param>
			/// <returns>
			/// <para>Returns <c>S_OK</c> on success, or an error <c>HRESULT</c> on failure.</para>
			/// <para>This method can also return the following error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-ifindsimilarresults-getnextfileid HRESULT GetNextFileId(
			// [out] DWORD *numTraitsMatched, [out] SimilarityFileId *similarityFileId );
			[PreserveSig]
			HRESULT GetNextFileId(out uint numTraitsMatched, out SimilarityFileId similarityFileId);
		}

		/// <summary>
		/// The <c>IRdcComparator</c> interface is used to compare two signature streams (seed and source) and produce the list of source and
		/// seed file data chunks needed to create the target file.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdccomparator
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcComparator")]
		[ComImport, Guid("96236A77-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcComparator))]
		public interface IRdcComparator
		{
			/// <summary>
			/// The <c>Process</c> method compares two signature streams (seed and source) and produces a needs list, which describes the
			/// chunks of file data needed to create the target file. The seed signature file may be read multiple times, depending on the
			/// size of the source signature file.
			/// </summary>
			/// <param name="endOfInput">Set to <c>TRUE</c> if the <c>inputBuffer</c> parameter contains all remaining input.</param>
			/// <param name="endOfOutput">
			/// Address of a <c>BOOL</c> that on successful completion is set to <c>TRUE</c> if all output data has been generated.
			/// </param>
			/// <param name="inputBuffer">
			/// Address of a RdcBufferPointer structure containing information about the input buffer. The <c>m_Used</c> member of this
			/// structure is used to indicate how much input, if any, was processed during this call.
			/// </param>
			/// <param name="outputBuffer">
			/// Address of a RdcNeedPointer structure containing information about the output buffer. On input the <c>m_Size</c> member of
			/// this structure must contain the number of RdcNeed structures in the array pointed to by the <c>m_Data</c> member, and the
			/// <c>m_Used</c> member must be zero. On output the <c>m_Used</c> member will contain the number of <c>RdcNeed</c> structures in
			/// the array pointed to by the <c>m_Data</c> member.
			/// </param>
			/// <param name="rdc_ErrorCode">
			/// The address of a RDC_ErrorCode enumeration that is filled with an RDC specific error code if the return value from the
			/// <c>Process</c> method is <c>E_FAIL</c>. If this value is <c>RDC_Win32ErrorCode</c>, then the return value of the
			/// <c>Process</c> method contains the specific error code.
			/// </param>
			/// <remarks>
			/// On successful return, iterate through each RdcNeed structure returned in the array pointed to by the <c>m_Data</c> member of
			/// the <c>outputBuffer</c> parameter, and copy the specified chunk of the source or seed data to the target data.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdccomparator-process HRESULT Process( [in] BOOL
			// endOfInput, [out] BOOL *endOfOutput, [in, out] RdcBufferPointer *inputBuffer, [in, out] RdcNeedPointer *outputBuffer, [out]
			// RDC_ErrorCode *rdc_ErrorCode );
			void Process([MarshalAs(UnmanagedType.Bool)] bool endOfInput, [MarshalAs(UnmanagedType.Bool)] out bool endOfOutput,
				ref RdcBufferPointer inputBuffer, ref RdcNeedPointer outputBuffer, out RDC_ErrorCode rdc_ErrorCode);
		}

		/// <summary>
		/// The <c>IRdcFileReader</c> interface is used to provide the equivalent of a file handle, because the data being synchronized may
		/// not exist as a file on disk.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdcfilereader
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcFileReader")]
		[ComImport, Guid("96236A74-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcFileReader))]
		public interface IRdcFileReader
		{
			/// <summary>The <c>GetFileSize</c> method returns the size of a file.</summary>
			/// <param name="fileSize">
			/// Address of a <c>ULONGLONG</c> that on successful return will be filled with the size of the file, in bytes.
			/// </param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilereader-getfilesize HRESULT GetFileSize( [out]
			// ULONGLONG *fileSize );
			[PreserveSig]
			HRESULT GetFileSize(out ulong fileSize);

			/// <summary>The <c>Read</c> method reads the specified amount of data starting at the specified position.</summary>
			/// <param name="offsetFileStart">Offset from the start of the data at which to start the read.</param>
			/// <param name="bytesToRead">Number of bytes to be read.</param>
			/// <param name="bytesActuallyRead">Address of a <c>ULONG</c> that will receive the number of bytes read.</param>
			/// <param name="buffer">
			/// Address of the buffer that receives the data read. This buffer must be at least <c>bytesToRead</c> bytes in size.
			/// </param>
			/// <param name="eof">Address of a <c>BOOL</c> that is set to <c>TRUE</c> if the end of the file has been read.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>
			/// Typically RDC will read the file sequentially from start to end. When reading signatures, the file may be read more than once.
			/// </para>
			/// <para>
			/// If the <c>BOOL</c> pointed to by the <c>eof</c> parameter is not <c>TRUE</c> on return then the value pointed to by the
			/// <c>bytesActuallyRead</c> parameter must equal the <c>bytesToRead</c> parameter. If the value pointed to by the <c>eof</c>
			/// parameter is set, then the value pointed to by the <c>bytesActuallyRead</c> parameter can be any value between zero and the
			/// <c>bytesToRead</c> parameter.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilereader-read HRESULT Read( [in] ULONGLONG
			// offsetFileStart, [in] ULONG bytesToRead, [out] ULONG *bytesActuallyRead, [out] BYTE *buffer, [out] BOOL *eof );
			[PreserveSig]
			HRESULT Read(ulong offsetFileStart, uint bytesToRead, out uint bytesActuallyRead, [Out] byte[] buffer, [MarshalAs(UnmanagedType.Bool)] out bool eof);

			/// <summary>The <c>GetFilePosition</c> method returns the current file position.</summary>
			/// <param name="offsetFromStart">Address of a <c>ULONGLONG</c> that will receive the current offset from the start of the data.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilereader-getfileposition HRESULT GetFilePosition(
			// [out] ULONGLONG *offsetFromStart );
			[PreserveSig]
			HRESULT GetFilePosition(out ulong offsetFromStart);
		}

		/// <summary>
		/// <para>Abstract interface to read from and write to a file.</para>
		/// <para>
		/// The RDC application must implement this interface for use with ISimilarityFileIdTable::CreateTableIndirect. Note that this
		/// interface does not include methods to open, close, or flush the file to disk. The application is responsible for properly opening
		/// and closing the file represented by an instance of this interface.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdcfilewriter
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcFileWriter")]
		[ComImport, Guid("96236A75-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcFileReader))]
		public interface IRdcFileWriter : IRdcFileReader
		{
			/// <summary>The <c>GetFileSize</c> method returns the size of a file.</summary>
			/// <param name="fileSize">
			/// Address of a <c>ULONGLONG</c> that on successful return will be filled with the size of the file, in bytes.
			/// </param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilereader-getfilesize HRESULT GetFileSize( [out]
			// ULONGLONG *fileSize );
			[PreserveSig]
			new HRESULT GetFileSize(out ulong fileSize);

			/// <summary>The <c>Read</c> method reads the specified amount of data starting at the specified position.</summary>
			/// <param name="offsetFileStart">Offset from the start of the data at which to start the read.</param>
			/// <param name="bytesToRead">Number of bytes to be read.</param>
			/// <param name="bytesActuallyRead">Address of a <c>ULONG</c> that will receive the number of bytes read.</param>
			/// <param name="buffer">
			/// Address of the buffer that receives the data read. This buffer must be at least <c>bytesToRead</c> bytes in size.
			/// </param>
			/// <param name="eof">Address of a <c>BOOL</c> that is set to <c>TRUE</c> if the end of the file has been read.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>
			/// Typically RDC will read the file sequentially from start to end. When reading signatures, the file may be read more than once.
			/// </para>
			/// <para>
			/// If the <c>BOOL</c> pointed to by the <c>eof</c> parameter is not <c>TRUE</c> on return then the value pointed to by the
			/// <c>bytesActuallyRead</c> parameter must equal the <c>bytesToRead</c> parameter. If the value pointed to by the <c>eof</c>
			/// parameter is set, then the value pointed to by the <c>bytesActuallyRead</c> parameter can be any value between zero and the
			/// <c>bytesToRead</c> parameter.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilereader-read HRESULT Read( [in] ULONGLONG
			// offsetFileStart, [in] ULONG bytesToRead, [out] ULONG *bytesActuallyRead, [out] BYTE *buffer, [out] BOOL *eof );
			[PreserveSig]
			new HRESULT Read(ulong offsetFileStart, uint bytesToRead, out uint bytesActuallyRead, [Out] byte[] buffer, [MarshalAs(UnmanagedType.Bool)] out bool eof);

			/// <summary>The <c>GetFilePosition</c> method returns the current file position.</summary>
			/// <param name="offsetFromStart">Address of a <c>ULONGLONG</c> that will receive the current offset from the start of the data.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilereader-getfileposition HRESULT GetFilePosition(
			// [out] ULONGLONG *offsetFromStart );
			[PreserveSig]
			new HRESULT GetFilePosition(out ulong offsetFromStart);

			/// <summary>Write bytes to a file starting at a given offset.</summary>
			/// <param name="offsetFileStart">Starting offset.</param>
			/// <param name="bytesToWrite">Number of bytes to be written to the file.</param>
			/// <param name="buffer">The data to be written to the file.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilewriter-write HRESULT Write( [in] ULONGLONG
			// offsetFileStart, [in] ULONG bytesToWrite, [out] BYTE *buffer );
			[PreserveSig]
			HRESULT Write(ulong offsetFileStart, uint bytesToWrite, out byte buffer);

			/// <summary>Truncates a file to zero length.</summary>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilewriter-truncate HRESULT Truncate();
			[PreserveSig]
			HRESULT Truncate();

			/// <summary>Sets a file to be deleted (or truncated) on close.</summary>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcfilewriter-deleteonclose HRESULT DeleteOnClose();
			[PreserveSig]
			HRESULT DeleteOnClose();
		}

		/// <summary>The <c>IRdcGenerator</c> interface is used to process the input data and read the parameters used by the generator.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdcgenerator
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcGenerator")]
		[ComImport, Guid("96236A73-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcGenerator))]
		public interface IRdcGenerator
		{
			/// <summary>
			/// The <c>GetGeneratorParameters</c> method returns a copy of the parameters used to create the generator. The generator
			/// parameters are fixed when the generator is created.
			/// </summary>
			/// <param name="level">The generator level for the parameters to be returned. The range is <c>MSRDC_MINIMUM_DEPTH</c> to <c>MSRDC_MAXIMUM_DEPTH</c>.</param>
			/// <returns>
			/// Address of a pointer that on successful return will contain the IRdcGeneratorParameters interface pointer for the parameters
			/// for the generator level specified in the <c>level</c> parameter.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgenerator-getgeneratorparameters HRESULT
			// GetGeneratorParameters( [in] ULONG level, [out] IRdcGeneratorParameters **iGeneratorParameters );
			IRdcGeneratorParameters GetGeneratorParameters(uint level);

			/// <summary>
			/// The <c>Process</c> method processes the input data and produces 0 or more output bytes. This method must be called repeatedly
			/// until the <c>BOOL</c> pointed to by <c>endOfOutput</c> is set to <c>TRUE</c>.
			/// </summary>
			/// <param name="endOfInput">
			/// Set to <c>TRUE</c> when the input buffer pointed to by the <c>inputBuffer</c> parameter contains the remaining input available.
			/// </param>
			/// <param name="endOfOutput">Address of a <c>BOOL</c> that is set to <c>TRUE</c> when the processing is complete for all data.</param>
			/// <param name="inputBuffer">
			/// Address of an RdcBufferPointer structure that contains the input buffer. On successful return, the <c>m_Used</c> member of
			/// this structure will be filled with the number of bytes by this call.
			/// </param>
			/// <param name="depth">
			/// The number of levels of signatures to generate. This must match the number of levels specified when the generator was created.
			/// </param>
			/// <param name="outputBuffers">
			/// The address of an array of RdcBufferPointer structures that will receive the output buffers. The <c>m_Used</c> member of
			/// these structures will be filled with the number of bytes returned in the buffer.
			/// </param>
			/// <param name="rdc_ErrorCode">
			/// The address of an RDC_ErrorCode enumeration that is filled with an RDC specific error code if the return value from the
			/// <c>Process</c> method is <c>E_FAIL</c>. If this value is <c>RDC_Win32ErrorCode</c>, then the return value of the
			/// <c>Process</c> method contains the specific error code.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgenerator-process HRESULT Process( [in] BOOL endOfInput,
			// [out] BOOL *endOfOutput, [in, out] RdcBufferPointer *inputBuffer, [in] ULONG depth, [out] RdcBufferPointer * [] outputBuffers,
			// [out] RDC_ErrorCode *rdc_ErrorCode );
			void Process([MarshalAs(UnmanagedType.Bool)] bool endOfInput, [MarshalAs(UnmanagedType.Bool)] out bool endOfOutput, ref RdcBufferPointer inputBuffer, uint depth,
				[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] IntPtr[] outputBuffers, out RDC_ErrorCode rdc_ErrorCode);
		}

		/// <summary>The <c>IRdcGeneratorFilterMaxParameters</c> interface sets and retrieves parameters used by the FilterMax generator.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdcgeneratorfiltermaxparameters
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcGeneratorFilterMaxParameters")]
		[ComImport, Guid("96236A72-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcGeneratorFilterMaxParameters))]
		public interface IRdcGeneratorFilterMaxParameters
		{
			/// <summary>
			/// The <c>GetHorizonSize</c> method returns the horizon size葉he length over which the FilterMax generator looks for local
			/// maxima. This determines the default smallest size for a chunk.
			/// </summary>
			/// <returns>
			/// Address of a <c>ULONG</c> that will receive the length in bytes of the horizon size. The valid range is from
			/// <c>MSRDC_MINIMUM_HORIZONSIZE</c> to <c>MSRDC_MAXIMUM_HORIZONSIZE</c>.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorfiltermaxparameters-gethorizonsize HRESULT
			// GetHorizonSize( [out] ULONG *horizonSize );
			uint GetHorizonSize();

			/// <summary>
			/// The <c>SetHorizonSize</c> method sets the horizon size葉he length over which the FilterMax generator looks for local maxima.
			/// This determines the default smallest size for a chunk.
			/// </summary>
			/// <param name="horizonSize">
			/// Specifies the length in bytes of the horizon size. The valid range is from <c>MSRDC_MINIMUM_HORIZONSIZE</c> to
			/// <c>MSRDC_MAXIMUM_HORIZONSIZE</c>. If this parameter is not set then a suitable default will be used.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorfiltermaxparameters-sethorizonsize HRESULT
			// SetHorizonSize( [in] ULONG horizonSize );
			void SetHorizonSize(uint horizonSize);

			/// <summary>
			/// The <c>GetHashWindowSize</c> method returns the hash window size葉he size of the sliding window used by the FilterMax
			/// generator for computing the hash used in the local maxima calculations.
			/// </summary>
			/// <returns>
			/// Address of a <c>ULONG</c> that will receive the length in bytes of the hash window size. The valid range is from
			/// <c>MSRDC_MINIMUM_HASHWINDOWSIZE</c> to <c>MSRDC_MAXIMUM_HASHWINDOWSIZE</c>.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorfiltermaxparameters-gethashwindowsize HRESULT
			// GetHashWindowSize( [out] ULONG *hashWindowSize );
			uint GetHashWindowSize();

			/// <summary>
			/// The <c>SetHashWindowSize</c> method sets the hash window size葉he size of the sliding window used by the FilterMax generator
			/// for computing the hash used in the local maxima calculations.
			/// </summary>
			/// <param name="hashWindowSize">
			/// The length in bytes of the hash window size. The valid range is from <c>MSRDC_MINIMUM_HASHWINDOWSIZE</c> to <c>MSRDC_MAXIMUM_HASHWINDOWSIZE</c>.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorfiltermaxparameters-sethashwindowsize HRESULT
			// SetHashWindowSize( [in] ULONG hashWindowSize );
			void SetHashWindowSize(uint hashWindowSize);
		}

		/// <summary>
		/// The <c>IRdcGeneratorParameters</c> interface is the generic interface for all types of generator parameters. All generator
		/// parameter objects must support this interface.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdcgeneratorparameters
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcGeneratorParameters")]
		[ComImport, Guid("96236A71-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcGeneratorParameters))]
		public interface IRdcGeneratorParameters
		{
			/// <summary>The <c>GetGeneratorParametersType</c> method returns the specific type of the parameters.</summary>
			/// <returns>The address of a GeneratorParametersType that will receive the type of the parameters.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorparameters-getgeneratorparameterstype HRESULT
			// GetGeneratorParametersType( [out] GeneratorParametersType *parametersType );
			GeneratorParametersType GetGeneratorParametersType();

			/// <summary>The <c>GetParametersVersion</c> method returns information about the version of RDC used to serialize the parameters.</summary>
			/// <param name="currentVersion">
			/// Address of a <c>ULONG</c> that will receive the version of RDC used to serialize the parameters for this object. This
			/// corresponds to the <c>MSRDC_VERSION</c> constant.
			/// </param>
			/// <param name="minimumCompatibleAppVersion">
			/// Address of a <c>ULONG</c> that will receive the version of RDC that is compatible with the serialized parameters. This
			/// corresponds to the <c>MSRDC_MINIMUM_COMPATIBLE_APP_VERSION</c> constant.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorparameters-getparametersversion HRESULT
			// GetParametersVersion( [out] ULONG *currentVersion, [out] ULONG *minimumCompatibleAppVersion );
			void GetParametersVersion(out uint currentVersion, out uint minimumCompatibleAppVersion);

			/// <summary>The <c>GetSerializeSize</c> method returns the size, in bytes, of the serialized parameter data.</summary>
			/// <returns>
			/// Address of a <c>ULONG</c> that on successful completion is filled with the size, in bytes, of the serialized parameter data.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorparameters-getserializesize HRESULT
			// GetSerializeSize( [out] ULONG *size );
			uint GetSerializeSize();

			/// <summary>
			/// The <c>Serialize</c> method serializes the parameter data into a block of memory. This allows the parameters to be stored or transmitted.
			/// </summary>
			/// <param name="size">The size of the buffer pointed to by the <c>parametersBlob</c> parameter.</param>
			/// <param name="parametersBlob">The address of a buffer to receive the serialized parameter data.</param>
			/// <param name="bytesWritten">
			/// Address of a <c>ULONG</c> that on successful completion is filled with the size, in bytes, of the serialized parameter data
			/// written to the buffer pointed to by the <c>parametersBlob</c> parameter.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcgeneratorparameters-serialize HRESULT Serialize( [in]
			// ULONG size, [out] BYTE *parametersBlob, [out] ULONG *bytesWritten );
			void Serialize(uint size, out byte parametersBlob, out uint bytesWritten);
		}

		/// <summary>The <c>IRdcLibrary</c> interface is the primary interface for using RDC.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdclibrary
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcLibrary")]
		[ComImport, Guid("96236A78-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcLibrary))]
		public interface IRdcLibrary
		{
			/// <summary>
			/// The <c>ComputeDefaultRecursionDepth</c> method computes the maximum level of recursion for the specified file size. The depth
			/// returned by the method may be larger than <c>MSRDC_MAXIMUM_DEPTH</c>. The caller must compare the value returned through the
			/// <c>depth</c> parameter with <c>MSRDC_MAXIMUM_DEPTH</c>.
			/// </summary>
			/// <param name="fileSize">The approximate size of the file.</param>
			/// <returns>Pointer to a <c>ULONG</c> that will receive the suggested maximum recursion depth.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdclibrary-computedefaultrecursiondepth HRESULT
			// ComputeDefaultRecursionDepth( [in] ULONGLONG fileSize, [out] ULONG *depth );
			uint ComputeDefaultRecursionDepth(ulong fileSize);

			/// <summary>
			/// The <c>CreateGeneratorParameters</c> method returns an IRdcGeneratorParameters interface pointer initialized with the
			/// parameters necessary for a signature generator.
			/// </summary>
			/// <param name="parametersType">
			/// Specifies the type of signature generator for the created parameters, enumerated by the GeneratorParametersType enumeration.
			/// The initial release of RDC only supports one type, <c>RDCGENTYPE_FilterMax</c>.
			/// </param>
			/// <param name="level">
			/// The recursion level for this parameter block. A parameter block is needed for each level of generated signatures. The valid
			/// range is from <c>MSRDC_MINIMUM_DEPTH</c> to <c>MSRDC_MAXIMUM_DEPTH</c>.
			/// </param>
			/// <returns>
			/// Pointer to a location that will receive an IRdcGeneratorParameters interface pointer. On a successful return the interface
			/// will be initialized on return. Callers must release the interface.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdclibrary-creategeneratorparameters HRESULT
			// CreateGeneratorParameters( [in] GeneratorParametersType parametersType, [in] ULONG level, [out] IRdcGeneratorParameters
			// **iGeneratorParameters );
			[return: MarshalAs(UnmanagedType.Interface)]
			IRdcGeneratorParameters CreateGeneratorParameters(GeneratorParametersType parametersType, uint level);

			/// <summary>
			/// The <c>OpenGeneratorParameters</c> method opens an existing serialized parameter block and returns an IRdcGeneratorParameters
			/// interface pointer initialized with the data.
			/// </summary>
			/// <param name="size">The size, in bytes, of the serialized parameter block.</param>
			/// <param name="parametersBlob">Pointer to a serialized parameter block.</param>
			/// <returns>
			/// Pointer to a location that will receive the returned IRdcGeneratorParameters interface pointer. Callers must release the interface.
			/// </returns>
			/// <remarks>To create a serialized parameter block, use the IRdcGeneratorParameters::Serialize method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdclibrary-opengeneratorparameters HRESULT
			// OpenGeneratorParameters( [in] ULONG size, [in] const BYTE *parametersBlob, [out] IRdcGeneratorParameters
			// **iGeneratorParameters );
			[return: MarshalAs(UnmanagedType.Interface)]
			IRdcGeneratorParameters OpenGeneratorParameters(uint size, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] parametersBlob);

			/// <summary>The <c>CreateGenerator</c> method creates a signature generator that will generate the specified levels of signatures.</summary>
			/// <param name="depth">
			/// The number of levels of signatures to generate. The valid range is from <c>MSRDC_MINIMUM_DEPTH</c> to <c>MSRDC_MAXIMUM_DEPTH</c>.
			/// </param>
			/// <param name="iGeneratorParametersArray">
			/// Pointer to an array of initialized IRdcGeneratorParameters interface pointers. Each <c>IRdcGeneratorParameters</c> interface
			/// pointer would have been initialized by IRdcLibrary::CreateGeneratorParameters or IRdcGenerator::GetGeneratorParameters.
			/// </param>
			/// <returns>
			/// Pointer to a location that will receive the returned IRdcGenerator interface pointer. Callers must release the interface.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdclibrary-creategenerator HRESULT CreateGenerator( [in]
			// ULONG depth, [in] IRdcGeneratorParameters * [] iGeneratorParametersArray, [out] IRdcGenerator **iGenerator );
			[return: MarshalAs(UnmanagedType.Interface)]
			IRdcGenerator CreateGenerator(uint depth, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IRdcGeneratorParameters[] iGeneratorParametersArray);

			/// <summary>The <c>CreateComparator</c> method creates a signature comparator.</summary>
			/// <param name="iSeedSignaturesFile">An IRdcFileReader interface pointer initialized to read the seed signatures.</param>
			/// <param name="comparatorBufferSize">
			///   <para>Specifies the size of the comparator buffer. The range is from <c>MSRDC_MINIMUM_COMPAREBUFFER</c> to <c>MSRDC_MAXIMUM_COMPAREBUFFER</c>.</para>
			///   <para>MSRDC_MINIMUM_COMPAREBUFFER (100000)</para>
			///   <para>Minimum size of a comparator buffer.</para>
			///   <para>MSRDC_DEFAULT_COMPAREBUFFER (3200000)</para>
			///   <para>Default size of a comparator buffer. Used if zero (0) is passed for <c>comparatorBufferSize</c>.</para>
			///   <para>MSRDC_MAXIMUM_COMPAREBUFFER (1073741824)</para>
			///   <para>Maximum size of a comparator buffer. (1&lt;&lt;30)</para>
			/// </param>
			/// <returns>
			/// Pointer to a location that will receive an IRdcComparator interface pointer. On a successful return the interface will be
			/// initialized on return. Callers must release the interface.
			/// </returns>
			/// <remarks>The caller must create a separate signature comparator for each level of recursion.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdclibrary-createcomparator
			// HRESULT CreateComparator( [in] IRdcFileReader *iSeedSignaturesFile, [in] ULONG comparatorBufferSize, [out] IRdcComparator **iComparator );
			[return: MarshalAs(UnmanagedType.Interface)]
			IRdcComparator CreateComparator([In, MarshalAs(UnmanagedType.Interface)] IRdcFileReader iSeedSignaturesFile, [Optional] uint comparatorBufferSize);

			/// <summary>
			/// The <c>CreateSignatureReader</c> method creates a signature reader to allow an application to decode the contents of a
			/// signature file.
			/// </summary>
			/// <param name="iFileReader">An IRdcFileReader interface pointer initialized to read the signatures.</param>
			/// <returns>
			/// Pointer to a location that will receive an IRdcSignatureReader interface pointer. On a successful return the interface will
			/// be initialized on return. Callers must release the interface.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdclibrary-createsignaturereader HRESULT
			// CreateSignatureReader( [in] IRdcFileReader *iFileReader, [out] IRdcSignatureReader **iSignatureReader );
			[return: MarshalAs(UnmanagedType.Interface)]
			IRdcSignatureReader CreateSignatureReader([In] IRdcFileReader iFileReader);

			/// <summary>
			/// The <c>GetRDCVersion</c> method retrieves the version of the installed RDC runtime and the oldest version of the RDC
			/// interfaces supported by the installed runtime.
			/// </summary>
			/// <param name="currentVersion">
			/// Address of a <c>ULONG</c> that will receive the installed version of RDC. This corresponds to the <c>MSRDC_VERSION</c> value.
			/// </param>
			/// <param name="minimumCompatibleAppVersion">
			/// Address of a <c>ULONG</c> that will receive the oldest version of RDC supported by the installed version of RDC. This
			/// corresponds to the <c>MSRDC_MINIMUM_COMPATIBLE_APP_VERSION</c> value.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdclibrary-getrdcversion HRESULT GetRDCVersion( [out] ULONG
			// *currentVersion, [out] ULONG *minimumCompatibleAppVersion );
			void GetRDCVersion(out uint currentVersion, out uint minimumCompatibleAppVersion);
		}

		/// <summary>The <c>IRdcSignatureReader</c> interface reads the signatures and the parameters used to generate the signatures.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdcsignaturereader
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcSignatureReader")]
		[ComImport, Guid("96236A76-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcSignatureReader))]
		public interface IRdcSignatureReader
		{
			/// <summary>
			/// The <c>ReadHeader</c> method reads the signature header and returns a copy of the parameters used to generate the signatures.
			/// </summary>
			/// <returns>Address of a RDC_ErrorCode enumeration that will receive any RDC-specific error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcsignaturereader-readheader HRESULT ReadHeader( [out]
			// RDC_ErrorCode *rdc_ErrorCode );
			RDC_ErrorCode ReadHeader();

			/// <summary>The <c>ReadSignatures</c> method reads a block of signatures from the current position.</summary>
			/// <param name="rdcSignaturePointer">
			/// Address of a RdcSignaturePointer structure. On input the <c>m_Size</c> member of this structure must contain the number of
			/// RdcSignature structures in the array pointed to by the <c>m_Data</c> member, and the <c>m_Used</c> member must be zero. On
			/// output the <c>m_Used</c> member will contain the number of <c>RdcSignature</c> structures in the array pointed to by the
			/// <c>m_Data</c> member.
			/// </param>
			/// <param name="endOfOutput">Address of a <c>BOOL</c> that is set to <c>TRUE</c> if the end of the signatures has been read.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcsignaturereader-readsignatures HRESULT ReadSignatures(
			// [in, out] RdcSignaturePointer *rdcSignaturePointer, [out] BOOL *endOfOutput );
			void ReadSignatures(ref RdcSignaturePointer rdcSignaturePointer, [MarshalAs(UnmanagedType.Bool)] out bool endOfOutput);
		}

		/// <summary>
		/// Defines methods for enabling the signature generator to generate similarity data and for retrieving the similarity data after it
		/// is generated.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-irdcsimilaritygenerator
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.IRdcSimilarityGenerator")]
		[ComImport, Guid("96236A80-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(RdcSimilarityGenerator))]
		public interface IRdcSimilarityGenerator
		{
			/// <summary>
			/// <para>Enables the signature generator to generate similarity data.</para>
			/// <para>
			/// The <c>EnableSimilarity</c> method must be called before the IRdcGenerator::Process method is called to begin generating
			/// signatures. Otherwise, this method will return an error.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcsimilaritygenerator-enablesimilarity HRESULT EnableSimilarity();
			void EnableSimilarity();

			/// <summary>
			/// <para>Retrieves the similarity data that was generated for a file by the signature generator.</para>
			/// <para>
			/// This method cannot be called until signature generation is completed. For more information, see the <c>endOfOutput</c>
			/// parameter of the IRdcGenerator::Process method.
			/// </para>
			/// </summary>
			/// <returns>A pointer to a SimilarityData structure that will receive the similarity data.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-irdcsimilaritygenerator-results HRESULT Results( [out]
			// SimilarityData *similarityData );
			SimilarityData Results();
		}

		/// <summary>Defines methods for storing and retrieving per-file similarity data and file IDs in a similarity file.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-isimilarity
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.ISimilarity")]
		[ComImport, Guid("96236A83-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(Similarity))]
		public interface ISimilarity
		{
			/// <summary>Creates or opens a similarity traits table and a similarity file ID table.</summary>
			/// <param name="path">
			/// A pointer to a null-terminated string that specifies the name of the file that will contain the tables. The similarity traits
			/// table and the similarity file ID table will be created in two alternate file streams of this file. For more information, see
			/// the <c>path</c> parameter of the ISimilarityFileIdTable::CreateTable and ISimilarityTraitsTable::CreateTable methods.
			/// </param>
			/// <param name="truncate">
			/// <c>TRUE</c> if a new similarity traits table and a new similarity file ID table should always be created or truncated. If
			/// <c>FALSE</c> is specified and these tables exist and are valid, they may be used; otherwise, if one of the tables is not
			/// valid or does not exist, any existing tables are overwritten.
			/// </param>
			/// <param name="securityDescriptor">
			/// A pointer to a security descriptor to use when opening the file. If this parameter is <c>NULL</c>, the file is assigned a
			/// default security descriptor. The access control lists (ACL) in the file's default security descriptor are inherited from the
			/// file's parent directory. For more information, see the <c>lpSecurityAttributes</c> parameter of the CreateFile function.
			/// </param>
			/// <param name="recordSize">
			/// The size, in bytes, of each file ID to be stored in the similarity file id table. All similarity file IDs must be the same
			/// size. The valid range is from <c>SimilarityFileIdMinSize</c> to <c>SimilarityFileIdMaxSize</c>. If existing tables are being
			/// opened, the value of this parameter must match the file ID size of the existing similarity file ID table. Otherwise, the
			/// existing tables are assumed to be not valid and will be overwritten.
			/// </param>
			/// <param name="isNew">
			/// A pointer to a variable that receives an RdcCreatedTables enumeration value that describes the state of the tables. If new
			/// tables are created, this variable receives <c>RDCTABLE_New</c>. If existing tables are used, this variable receives
			/// <c>RDCTABLE_Existing</c>. If this method fails, this variable receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </param>
			/// <remarks>
			/// If one of the tables can be created or opened successfully, but the other one cannot, both tables are marked as not valid,
			/// and the variable that the <c>isNew</c> parameter points to receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarity-createtable HRESULT CreateTable( [in] wchar_t
			// *path, [in] BOOL truncate, [in] BYTE *securityDescriptor, [in] DWORD recordSize, [out] RdcCreatedTables *isNew );
			void CreateTable([MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.Bool)] bool truncate,
				[In, Optional] IntPtr securityDescriptor, uint recordSize, out RdcCreatedTables isNew);

			/// <summary>
			/// Creates or opens a similarity traits table and a similarity file ID table using the RDC application's implementations of the
			/// ISimilarityTraitsMapping and IRdcFileWriter interfaces.
			/// </summary>
			/// <param name="mapping">
			/// An ISimilarityTraitsMapping interface pointer initialized to write the similarity traits table to the file.
			/// </param>
			/// <param name="fileIdFile">An IRdcFileWriter interface pointer initialized to write the file ID table to the file.</param>
			/// <param name="truncate">
			/// <c>TRUE</c> if a new similarity traits table and a new similarity file ID table should always be created or truncated. If
			/// <c>FALSE</c> is specified and these tables exist and are valid, they may be used; otherwise, if one of the tables is not
			/// valid or does not exist, any existing tables are overwritten.
			/// </param>
			/// <param name="recordSize">
			/// The size, in bytes, of each file ID to be stored in the similarity file ID table. All similarity file IDs must be the same
			/// size. The valid range is from <c>SimilarityFileIdMinSize</c> to <c>SimilarityFileIdMaxSize</c>. If existing tables are being
			/// opened, the value of this parameter must match the file ID size of the existing similarity file ID table. Otherwise, the
			/// existing tables are assumed to be not valid and will be overwritten.
			/// </param>
			/// <param name="isNew">
			/// A pointer to a variable that receives an RdcCreatedTables enumeration value that describes the state of the tables. If new
			/// tables are created, this variable receives <c>RDCTABLE_New</c>. If existing tables are used, this variable receives
			/// <c>RDCTABLE_Existing</c>. If this method fails, this variable receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </param>
			/// <remarks>
			/// If one of the tables can be created or opened successfully, but the other one cannot, both tables are marked as not valid,
			/// and the variable that the <c>isNew</c> parameter points to receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarity-createtableindirect HRESULT CreateTableIndirect(
			// [in] ISimilarityTraitsMapping *mapping, [in] IRdcFileWriter *fileIdFile, [in] BOOL truncate, [in] DWORD recordSize, [out]
			// RdcCreatedTables *isNew );
			void CreateTableIndirect([In] ISimilarityTraitsMapping mapping, [In] IRdcFileWriter fileIdFile,
				[MarshalAs(UnmanagedType.Bool)] bool truncate, uint recordSize, out RdcCreatedTables isNew);

			/// <summary>Closes the tables in a similarity file.</summary>
			/// <param name="isValid">
			/// <c>FALSE</c> if the similarity traits table and similarity file ID table should be deleted when they are closed; otherwise, <c>TRUE</c>.
			/// </param>
			/// <remarks>
			/// <para>
			/// If <c>FALSE</c> is specified for the <c>isValid</c> parameter, only the tables are deleted; the similarity file is not
			/// deleted. The caller is responsible for deleting the similarity file.
			/// </para>
			/// <para>When the <c>CloseTable</c> method returns, the tables are always closed, even if this method returns an error code.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarity-closetable HRESULT CloseTable( [in] BOOL isValid );
			void CloseTable([MarshalAs(UnmanagedType.Bool)] bool isValid);

			/// <summary>Adds the file ID and similarity data information to the tables in the similarity file.</summary>
			/// <param name="similarityFileId">A pointer to the SimilarityFileId structure to be added to the similarity file ID table.</param>
			/// <param name="similarityData">A pointer to the SimilarityData structure to be added to the similarity traits table.</param>
			/// <remarks>
			/// If this method fails, the similarity file ID table and the similarity traits table are marked as corrupted and must be
			/// rebuilt by the application. The application must close the corrupted tables and create new tables.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarity-append HRESULT Append( [in] SimilarityFileId
			// *similarityFileId, [in] SimilarityData *similarityData );
			void Append(in SimilarityFileId similarityFileId, in SimilarityData similarityData);

			/// <summary>Returns a list of files that are similar to a given file.</summary>
			/// <param name="similarityData">A pointer to a SimilarityData structure that contains similarity information for the file.</param>
			/// <param name="numberOfMatchesRequired">TBD</param>
			/// <param name="resultsSize">
			/// The number of file IDs that can be stored in the IFindSimilarResults object that the <c>findSimilarResults</c> parameter
			/// points to.
			/// </param>
			/// <returns>
			/// A pointer to a location that will receive the returned IFindSimilarResults interface pointer. The caller must release this
			/// interface when it is no longer needed.
			/// </returns>
			/// <remarks>
			/// The file IDs that are returned in the <c>findSimilarResults</c> parameter may include IDs of files that have been deleted.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarity-findsimilarfileid HRESULT FindSimilarFileId(
			// [in] SimilarityData *similarityData, USHORT numberOfMatchesRequired, [in] DWORD resultsSize, [out, optional]
			// IFindSimilarResults **findSimilarResults );
			IFindSimilarResults FindSimilarFileId(in SimilarityData similarityData, ushort numberOfMatchesRequired, uint resultsSize);

			/// <summary>
			/// <para>
			/// Creates copies of an existing similarity traits table and an existing similarity file ID table, swaps the internal pointers,
			/// and deletes the existing tables.
			/// </para>
			/// <para>
			/// After the <c>CopyAndSwap</c> method returns, the application continues to use the same ISimilarity object that it used before
			/// calling this method. However, the <c>ISimilarity</c> object is now associated with a different similarity file on disk.
			/// </para>
			/// </summary>
			/// <param name="newSimilarityTables">
			/// An optional pointer to a temporary ISimilarity object that is used to create temporary copies of the tables. Before calling
			/// the <c>CopyAndSwap</c> method, the caller must call the CreateTable method to create the temporary tables. On return, the
			/// caller must call the CloseTable method to close the temporary tables.
			/// </param>
			/// <param name="reportProgress">
			/// An optional pointer to an ISimilarityReportProgress object that will receive information on the progress of the copy-and-swap
			/// operation and allow the application to stop the copy operation. The caller must release this interface when it is no longer needed.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarity-copyandswap HRESULT CopyAndSwap( [in, optional]
			// ISimilarity *newSimilarityTables, [in, optional] ISimilarityReportProgress *reportProgress );
			void CopyAndSwap([In] ISimilarity newSimilarityTables, [In] ISimilarityReportProgress reportProgress);

			/// <summary>Retrieves the number of records that are stored in the similarity file ID table in a similarity file.</summary>
			/// <returns>A pointer to a variable that receives the number of records.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarity-getrecordcount HRESULT GetRecordCount( [out]
			// DWORD *recordCount );
			uint GetRecordCount();
		}

		/// <summary>Defines methods for storing and retrieving similarity file ID information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-isimilarityfileidtable
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.ISimilarityFileIdTable")]
		[ComImport, Guid("96236A7F-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SimilarityFileIdTable))]
		public interface ISimilarityFileIdTable
		{
			/// <summary>Creates or opens a similarity file ID table.</summary>
			/// <param name="path">
			/// A pointer to a null-terminated string that specifies the name of the file that will contain the similarity file ID table. The
			/// alternate stream name ":FileId" will be appended to the end of this file name. For more information, see Naming a File.
			/// </param>
			/// <param name="truncate">
			/// <c>TRUE</c> if a new similarity file ID table should always be created or truncated. If <c>FALSE</c> is specified and the
			/// table exists and is valid, it may be used; otherwise, if the table is not valid or does not exist, the existing table is overwritten.
			/// </param>
			/// <param name="securityDescriptor">
			/// A pointer to a security descriptor to use when opening the file. If this parameter is <c>NULL</c>, the file is assigned a
			/// default security descriptor. The access control lists (ACL) in the file's default security descriptor are inherited from the
			/// file's parent directory. For more information, see the <c>lpSecurityAttributes</c> parameter of the CreateFile function.
			/// </param>
			/// <param name="recordSize">
			/// The size, in bytes, of the file IDs that will be stored in the similarity file ID table. All file IDs must be the same size.
			/// The valid range is from <c>SimilarityFileIdMinSize</c> to <c>SimilarityFileIdMaxSize</c>. If an existing similarity file ID
			/// table is being opened, the value of this parameter must match the file ID size of the existing table. Otherwise, the existing
			/// table is assumed to be not valid and will be overwritten.
			/// </param>
			/// <param name="isNew">
			/// A pointer to a variable that receives an RdcCreatedTables enumeration value that describes the state of the similarity file
			/// ID table. If a new table is created, this variable receives <c>RDCTABLE_New</c>. If an existing table is used, this variable
			/// receives <c>RDCTABLE_Existing</c>. If this method fails, this variable receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </param>
			/// <remarks>
			/// If an existing table is being opened, the table must be valid, and the value of the <c>recordSize</c> parameter must match
			/// the record size of the existing table. Otherwise, the existing table is overwritten, even if <c>FALSE</c> is specified for
			/// the <c>truncate</c> parameter.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityfileidtable-createtable HRESULT CreateTable( [in]
			// wchar_t *path, [in] BOOL truncate, [in] BYTE *securityDescriptor, [in] DWORD recordSize, [out] RdcCreatedTables *isNew );
			void CreateTable([MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.Bool)] bool truncate,
				 [In, Optional] IntPtr securityDescriptor, uint recordSize, out RdcCreatedTables isNew);

			/// <summary>
			/// Creates or opens a similarity file ID table using the RDC application's implementation of the IRdcFileWriter interface.
			/// </summary>
			/// <param name="fileIdFile">An IRdcFileWriter interface pointer initialized to write the file ID table to the file.</param>
			/// <param name="truncate">
			/// <c>TRUE</c> if a new similarity file ID table should always be created or truncated. If <c>FALSE</c> is specified and the
			/// table exists and is valid, it may be used; otherwise, if the table is not valid or does not exist, the existing table is overwritten.
			/// </param>
			/// <param name="recordSize">
			/// The size, in bytes, of the file IDs that will be stored in the similarity file ID table. All file IDs must be the same size.
			/// The valid range is from <c>SimilarityFileIdMinSize</c> to <c>SimilarityFileIdMaxSize</c>. If an existing similarity file ID
			/// table is being opened, the value of this parameter must match the file ID size of the existing table. Otherwise, the existing
			/// table is assumed to be not valid and will be overwritten.
			/// </param>
			/// <param name="isNew">
			/// A pointer to a variable that receives an RdcCreatedTables enumeration value that describes the state of the similarity file
			/// ID table. If a new table is created, this variable receives <c>RDCTABLE_New</c>. If an existing table is used, this variable
			/// receives <c>RDCTABLE_Existing</c>. If this method fails, this variable receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </param>
			/// <remarks>
			/// If an existing table is being opened, the table must be valid, and the value of the <c>recordSize</c> parameter must match
			/// the record size of the existing table. Otherwise, the existing table is overwritten, even if <c>FALSE</c> is specified for
			/// the <c>truncate</c> parameter.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityfileidtable-createtableindirect HRESULT
			// CreateTableIndirect( [in] IRdcFileWriter *fileIdFile, [in] BOOL truncate, [in] DWORD recordSize, [out] RdcCreatedTables *isNew );
			void CreateTableIndirect([In] IRdcFileWriter fileIdFile, [MarshalAs(UnmanagedType.Bool)] bool truncate, uint recordSize, out RdcCreatedTables isNew);

			/// <summary>Closes a similarity file ID table.</summary>
			/// <param name="isValid"><c>FALSE</c> if the similarity file ID table should be deleted when it is closed; otherwise, <c>TRUE</c>.</param>
			/// <remarks>
			/// <para>
			/// If <c>FALSE</c> is specified for the <c>isValid</c> parameter, only the table is deleted; the similarity file is not deleted.
			/// The caller is responsible for deleting the similarity file.
			/// </para>
			/// <para>When the <c>CloseTable</c> method returns, the table is always closed, even if this method returns an error code.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityfileidtable-closetable HRESULT CloseTable( BOOL
			// isValid );
			void CloseTable([MarshalAs(UnmanagedType.Bool)] bool isValid);

			/// <summary>Adds the file ID to the similarity file ID table.</summary>
			/// <param name="similarityFileId">The file ID to be added to the similarity file ID table.</param>
			/// <param name="similarityFileIndex">
			/// A pointer to a variable that receives the file index for the file ID's entry in the similarity file ID table.
			/// </param>
			/// <remarks>If the <c>Append</c> method fails, the similarity file ID table is marked as corrupted and must be rebuilt.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityfileidtable-append HRESULT Append( [in]
			// SimilarityFileId *similarityFileId, [out] SimilarityFileIndexT *similarityFileIndex );
			void Append(in SimilarityFileId similarityFileId, out uint similarityFileIndex);

			/// <summary>Retrieves the file ID that corresponds to a given file index in the similarity file ID table.</summary>
			/// <param name="similarityFileIndex">
			/// The file index that was previously returned for the file ID by the ISimilarityFileIdTable::Append method.
			/// </param>
			/// <returns>
			/// A pointer to a variable that receives the file ID. If the file has been marked as not valid, the file ID receives zero.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityfileidtable-lookup HRESULT Lookup( [in]
			// SimilarityFileIndexT similarityFileIndex, [out] SimilarityFileId *similarityFileId );
			SimilarityFileId Lookup([In] uint similarityFileIndex);

			/// <summary>
			/// <para>Marks a file ID as not valid in the similarity file ID table.</para>
			/// <para>This method should be called for files that have been deleted or are otherwise no longer available.</para>
			/// </summary>
			/// <param name="similarityFileIndex">The index of the file ID's entry in the similarity file ID table.</param>
			/// <remarks>
			/// The file ID is marked as not valid by setting the contents of the corresponding SimilarityFileId structure to all zeros. A
			/// file ID that is marked as not valid will not be included in the results that are returned by the
			/// ISimilarity::FindSimilarFileId method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityfileidtable-invalidate HRESULT Invalidate( [in]
			// SimilarityFileIndexT similarityFileIndex );
			void Invalidate([In] uint similarityFileIndex);

			/// <summary>Retrieves the number of records that are stored in a similarity file ID table.</summary>
			/// <returns>A pointer to a variable that receives the number of records.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityfileidtable-getrecordcount HRESULT
			// GetRecordCount( [out] DWORD *recordCount );
			uint GetRecordCount();
		}

		/// <summary>Defines a method for RDC to report the current completion percentage of a similarity operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-isimilarityreportprogress
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.ISimilarityReportProgress")]
		[ComImport, Guid("96236A7A-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SimilarityReportProgress))]
		public interface ISimilarityReportProgress
		{
			/// <summary>Reports the current completion percentage of a similarity operation in progress.</summary>
			/// <param name="percentCompleted">The current completion percentage of the task. The valid range is from 0 through 100.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>
			/// The ISimilarity::CopyAndSwap method calls the <c>ReportProgress</c> method to report the progress of the copy-and-swap
			/// operation. To receive the progress information, RDC applications must implement this method.
			/// </para>
			/// <para>
			/// No guarantee is made as to how frequently this method is called, nor that it will be called with any specific values for the
			/// <c>percentCompleted</c> parameter. For example, the <c>percentCompleted</c> parameter may not start at zero and may never
			/// reach 100, and it may receive the same value more than once. However, each value is guaranteed to be greater than or equal to
			/// the previous value.
			/// </para>
			/// <para>
			/// If the application returns an error code such as <c>E_FAIL</c>, the similarity operation is stopped, and the error code is propagated.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilarityreportprogress-reportprogress HRESULT
			// ReportProgress( [in] DWORD percentCompleted );
			[PreserveSig]
			HRESULT ReportProgress(uint percentCompleted);
		}

		/// <summary>
		/// Provides a method for retrieving information from the similarity traits list that was returned by the
		/// ISimilarityTraitsTable::BeginDump method.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-isimilaritytabledumpstate
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.ISimilarityTableDumpState")]
		[ComImport, Guid("96236A7B-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SimilarityTableDumpState))]
		public interface ISimilarityTableDumpState
		{
			/// <summary>
			/// Retrieves one or more SimilarityDumpData structures from the similarity traits list that was returned by the
			/// ISimilarityTraitsTable::BeginDump method.
			/// </summary>
			/// <param name="resultsSize">
			/// The number of SimilarityDumpData structures that can be stored in the buffer that the <c>results</c> parameter points to.
			/// </param>
			/// <param name="resultsUsed">
			/// A pointer to a variable that receives the number of SimilarityDumpData structures that were returned in the buffer that the
			/// <c>results</c> parameter points to.
			/// </param>
			/// <param name="eof">A pointer to a variable that receives <c>TRUE</c> if the end of the file is reached; otherwise, <c>FALSE</c>.</param>
			/// <param name="results">A pointer to a buffer that receives the SimilarityDumpData structures.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytabledumpstate-getnextdata HRESULT GetNextData(
			// [in] DWORD resultsSize, [out] DWORD *resultsUsed, [out] BOOL *eof, [in, out] SimilarityDumpData *results );
			void GetNextData(uint resultsSize, out uint resultsUsed, [MarshalAs(UnmanagedType.Bool)] out bool eof, ref SimilarityDumpData results);
		}

		/// <summary>
		/// <para>Provides methods that an RDC application can implement for manipulating a mapped view of a similarity traits table file.</para>
		/// <para>
		/// This interface is used together with the ISimilarityTraitsMapping interface to allow the application to provide the I/O services
		/// needed by the ISimilarityTraitsTable and ISimilarity interfaces. The implementation model is based on memory mapped files, but
		/// the interface is rich enough to support other models as well, such as memory-only arrays or traditional file accesses.
		/// </para>
		/// <para>
		/// A mapped view is used to map an area of the entire file into a contiguous block of memory. This mapping is valid until the view
		/// is changed or unmapped. A possible implementation would call the ReadFile function when the view is mapped (see the Get method),
		/// and would then write the changes back to disk when the view is changed (see <c>Get</c>) or released (see the Unmap method).
		/// </para>
		/// <para>
		/// There can be multiple overlapping read-only mapped views of the same area of a file, and one or more read-only views can overlap
		/// a read/write view, but there can be only one read/write view of a given area of a file.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-isimilaritytraitsmappedview
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.ISimilarityTraitsMappedView")]
		[ComImport, Guid("96236A7C-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SimilarityTraitsMappedView))]
		public interface ISimilarityTraitsMappedView
		{
			/// <summary>Writes to the disk any dirty pages within a mapped view of a similarity traits table file.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmappedview-flush HRESULT Flush();
			void Flush();

			/// <summary>
			/// Unmaps a mapped view of a similarity traits table file. The view, if any, is not dirty or does not otherwise need to be
			/// flushed to disk.
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmappedview-unmap HRESULT Unmap();
			void Unmap();

			/// <summary>Returns information about the mapped view of a similarity traits table file.</summary>
			/// <param name="index">Beginning file offset, in bytes, of the underlying file data to be mapped in the mapped view.</param>
			/// <param name="dirty">
			/// If <c>TRUE</c> is specified, the data in the currently mapped view has been changed; otherwise, the data has not changed.
			/// This parameter can be used to determine if data may need to be written to disk.
			/// </param>
			/// <param name="numElements">Minimum number of bytes of data to be mapped in the mapped view.</param>
			/// <returns>
			/// Pointer to a location that receives a SimilarityMappedViewInfo structure containing information about the mapped view.
			/// </returns>
			/// <remarks>
			/// At least <c>numElements</c> bytes must be available in the mapped view, but depending on the application, more bytes may
			/// actually be mapped. The data must be 8-byte aligned relative to the file offset. For example, the data at file offset 0x8001
			/// must be mapped to some memory location whose address modulo 8 is 1.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmappedview-get HRESULT Get( [in] unsigned
			// __int64 index, [in] BOOL dirty, [in] DWORD numElements, [out] SimilarityMappedViewInfo *viewInfo );
			SimilarityMappedViewInfo Get([In] ulong index, [MarshalAs(UnmanagedType.Bool)] bool dirty, uint numElements);

			/// <summary>Returns the beginning and ending addresses for the mapped view of a similarity traits table file.</summary>
			/// <param name="mappedPageBegin">Pointer to a location that receives the start of the data that is mapped for this view.</param>
			/// <param name="mappedPageEnd">Pointer to a location that receives the end of the data that is mapped for this view, plus one.</param>
			/// <returns>None</returns>
			/// <remarks>
			/// If there is no mapped view, then must be set to zero. Otherwise, is set to a valid pointer, and equals the size, in bytes, of
			/// the mapped area.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmappedview-getview void GetView( [out]
			// const unsigned char **mappedPageBegin, [out] const unsigned char **mappedPageEnd );
			[PreserveSig]
			void GetView(out IntPtr mappedPageBegin, out IntPtr mappedPageEnd);
		}

		/// <summary>
		/// <para>
		/// Provides methods that an RDC application can implement for creating and manipulating a file mapping object for a similarity
		/// traits table file.
		/// </para>
		/// <para>
		/// This interface is used together with the ISimilarityTraitsMappedView interface to allow the application to provide the I/O
		/// services needed by the ISimilarityTraitsTable and ISimilarity interfaces. The implementation model is based on memory mapped
		/// files, but the interface is rich enough to support other models as well, such as memory-only arrays or traditional file accesses.
		/// </para>
		/// <para>
		/// This interface is used to represent the file on which multiple read-only or read/write views can be created. There can be
		/// multiple overlapping read-only mapped views of the same area of a file, and one or more read-only views can overlap a read/write
		/// view, but there can be only one read/write view of a given area of a file.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-isimilaritytraitsmapping
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.ISimilarityTraitsMapping")]
		[ComImport, Guid("96236A7D-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SimilarityTraitsMapping))]
		public interface ISimilarityTraitsMapping
		{
			/// <summary>Closes a file mapping object for a similarity traits table file.</summary>
			/// <returns>None</returns>
			/// <remarks>
			/// Note that there may still be valid views open on the file. No new views may be created after the mapping is closed, but
			/// existing views continue to work.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmapping-closemapping void CloseMapping();
			[PreserveSig]
			void CloseMapping();

			/// <summary>Sets the size of a similarity traits table file.</summary>
			/// <param name="fileSize">Pointer to a location that specifies the file size, in bytes.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmapping-setfilesize HRESULT SetFileSize(
			// [in] unsigned __int64 fileSize );
			void SetFileSize([In] ulong fileSize);

			/// <summary>Returns the size of a similarity traits table file.</summary>
			/// <returns>Pointer to a location that receives the file size, in bytes.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmapping-getfilesize HRESULT GetFileSize(
			// [out] unsigned __int64 *fileSize );
			ulong GetFileSize();

			/// <summary>Opens the file mapping object for a similarity traits table file.</summary>
			/// <param name="accessMode">RdcMappingAccessMode enumeration value that specifies the desired access to the file mapping object.</param>
			/// <param name="begin">File offset, in bytes, where the file mapping is to begin.</param>
			/// <param name="end">File offset, in bytes, where the file mapping is to end.</param>
			/// <param name="actualEnd">
			/// Pointer to a location that receives the file offset, in bytes, of the actual end of the file mapping, rounded up to the
			/// nearest block size.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmapping-openmapping HRESULT OpenMapping(
			// [in] RdcMappingAccessMode accessMode, [in] unsigned __int64 begin, [in] unsigned __int64 end, [out] unsigned __int64
			// *actualEnd );
			void OpenMapping([In] RdcMappingAccessMode accessMode, [In] ulong begin, [In] ulong end, out ulong actualEnd);

			/// <summary>Resizes the file mapping object for a similarity traits table file.</summary>
			/// <param name="accessMode">RdcMappingAccessMode enumeration value that specifies the desired access to the file mapping object.</param>
			/// <param name="begin">File offset, in bytes, where the file mapping is to begin.</param>
			/// <param name="end">File offset, in bytes, where the file mapping is to end.</param>
			/// <param name="actualEnd">
			/// Pointer to a location that receives the file offset, in bytes, of the actual end of the file mapping, rounded up to the
			/// nearest block size.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmapping-resizemapping HRESULT
			// ResizeMapping( [in] RdcMappingAccessMode accessMode, [in] unsigned __int64 begin, [in] unsigned __int64 end, [out] unsigned
			// __int64 *actualEnd );
			void ResizeMapping([In] RdcMappingAccessMode accessMode, [In] ulong begin, [In] ulong end, out ulong actualEnd);

			/// <summary>Returns the page size (disk block size) for a similarity traits table file.</summary>
			/// <param name="pageSize">
			/// Pointer to a location that receives the page size, in bytes. This page size must be at least 65536 bytes.
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmapping-getpagesize void GetPageSize( [out]
			// DWORD *pageSize );
			[PreserveSig]
			void GetPageSize(out uint pageSize);

			/// <summary>Maps a view of the file mapping for a similarity traits table file.</summary>
			/// <param name="minimumMappedPages">Minimum number of pages of the file mapping to map to the view.</param>
			/// <param name="accessMode">RdcMappingAccessMode enumeration value that specifies the desired access to the file mapping object.</param>
			/// <returns>
			/// Pointer to a location that will receive the returned ISimilarityTraitsMappedView interface pointer. Callers must release the interface.
			/// </returns>
			/// <remarks>Data accessed through read-only views will never be modified.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitsmapping-createview HRESULT CreateView( [in]
			// DWORD minimumMappedPages, [in] RdcMappingAccessMode accessMode, [out] ISimilarityTraitsMappedView **mappedView );
			ISimilarityTraitsMappedView CreateView(uint minimumMappedPages, [In] RdcMappingAccessMode accessMode);
		}

		/// <summary>Defines methods for storing per-file similarity data and performing similarity lookups.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nn-msrdc-isimilaritytraitstable
		[PInvokeData("msrdc.h", MSDNShortId = "NN:msrdc.ISimilarityTraitsTable")]
		[ComImport, Guid("96236A7E-9DBC-11DA-9E3F-0011114AE311"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SimilarityTraitsTable))]
		public interface ISimilarityTraitsTable
		{
			/// <summary>Creates or opens a similarity traits table.</summary>
			/// <param name="path">
			/// A pointer to a null-terminated string that specifies the name of the file that will contain the similarity traits table. The
			/// alternate stream name ":Traits" will be appended to the end of this file name. For more information, see Naming a File.
			/// </param>
			/// <param name="truncate">
			/// <c>TRUE</c> if a new similarity traits table should always be created or truncated. If <c>FALSE</c> is specified and the
			/// table exists and is valid, it may be used; otherwise, if the table is not valid or does not exist, the existing table is overwritten.
			/// </param>
			/// <param name="securityDescriptor">
			/// A pointer to a security descriptor to use when opening the file. If this parameter is <c>NULL</c>, the file is assigned a
			/// default security descriptor. The access control lists (ACL) in the file's default security descriptor are inherited from the
			/// file's parent directory. For more information, see the <c>lpSecurityAttributes</c> parameter of the CreateFile function.
			/// </param>
			/// <returns>
			/// A pointer to a variable that receives an RdcCreatedTables enumeration value that describes the state of the similarity traits
			/// table. If a new table is created, this variable receives <c>RDCTABLE_New</c>. If an existing table is used, this variable
			/// receives <c>RDCTABLE_Existing</c>. If this method fails, this variable receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </returns>
			/// <remarks>
			/// If an existing similarity traits table is being opened, the table must be valid. Otherwise, the existing table is
			/// overwritten, even if <c>FALSE</c> is specified for the <c>truncate</c> parameter.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitstable-createtable HRESULT CreateTable( [in]
			// wchar_t *path, [in] BOOL truncate, [in] BYTE *securityDescriptor, [out] RdcCreatedTables *isNew );
			RdcCreatedTables CreateTable([MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.Bool)] bool truncate,
				[In, Optional] IntPtr securityDescriptor);

			/// <summary>
			/// Creates or opens a similarity traits table using the RDC application's implementation of the ISimilarityTraitsMapping interface.
			/// </summary>
			/// <param name="mapping">
			/// An ISimilarityTraitsMapping interface pointer initialized to write the similarity traits table to the file.
			/// </param>
			/// <param name="truncate">
			/// <c>TRUE</c> if a new similarity traits table should always be created or truncated. If <c>FALSE</c> is specified and the
			/// table exists and is valid, it may be used; otherwise, if the table is not valid or does not exist, the existing table is overwritten.
			/// </param>
			/// <returns>
			/// A pointer to a variable that receives an RdcCreatedTables enumeration value that describes the state of the similarity traits
			/// table. If a new table is created, this variable receives <c>RDCTABLE_New</c>. If an existing table is used, this variable
			/// receives <c>RDCTABLE_Existing</c>. If this method fails, this variable receives <c>RDCTABLE_InvalidOrUnknown</c>.
			/// </returns>
			/// <remarks>
			/// If an existing similarity traits table is being opened, the table must be valid. Otherwise, the existing table is
			/// overwritten, even if <c>FALSE</c> is specified for the <c>truncate</c> parameter.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitstable-createtableindirect HRESULT
			// CreateTableIndirect( [in] ISimilarityTraitsMapping *mapping, [in] BOOL truncate, [out] RdcCreatedTables *isNew );
			RdcCreatedTables CreateTableIndirect([In] ISimilarityTraitsMapping mapping, [MarshalAs(UnmanagedType.Bool)] bool truncate);

			/// <summary>Closes a similarity traits table.</summary>
			/// <param name="isValid"><c>FALSE</c> if the similarity traits table should be deleted when it is closed; otherwise, <c>TRUE</c>.</param>
			/// <remarks>
			/// <para>
			/// If <c>FALSE</c> is specified for the <c>isValid</c> parameter, only the table is deleted; the similarity file is not deleted.
			/// The caller is responsible for deleting the similarity file.
			/// </para>
			/// <para>When the <c>CloseTable</c> method returns, the table is always closed, even if this method returns an error code.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitstable-closetable HRESULT CloseTable( [in]
			// BOOL isValid );
			void CloseTable([MarshalAs(UnmanagedType.Bool)] bool isValid);

			/// <summary>Adds a SimilarityData structure to the similarity traits table.</summary>
			/// <param name="data">The SimilarityData structure to be added to the similarity traits table.</param>
			/// <param name="fileIndex">The index in the similarity traits table where the SimilarityData structure is to be inserted.</param>
			/// <remarks>
			/// The application must supply <c>fileIndex</c> values that are greater than zero and are always increasing. Otherwise, this
			/// method returns the <c>E_INVALIDARG</c> error code.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitstable-append HRESULT Append( [in]
			// SimilarityData *data, [in] SimilarityFileIndexT fileIndex );
			void Append(in SimilarityData data, uint fileIndex);

			/// <summary>
			/// Returns a list of files that are similar to a given file. The results in the list are sorted in order of similarity,
			/// beginning with the most similar file.
			/// </summary>
			/// <param name="similarityData">A pointer to a SimilarityData structure that contains similarity information for the file.</param>
			/// <param name="numberOfMatchesRequired">TBD</param>
			/// <param name="findSimilarFileIndexResults">
			/// A pointer to a buffer that receives an array of FindSimilarFileIndexResults structures that contain the requested information.
			/// </param>
			/// <param name="resultsSize">
			/// The number of FindSimilarFileIndexResults structures that can be stored in the buffer that the
			/// <c>findSimilarFileIndexResults</c> parameter points to.
			/// </param>
			/// <param name="resultsUsed">
			/// The number of FindSimilarFileIndexResults structures that were returned in the buffer that the
			/// <c>findSimilarFileIndexResults</c> parameter points to.
			/// </param>
			/// <remarks>
			/// The list of files that is returned in the <c>findSimilarFileIndexResults</c> parameter may include files that have been deleted.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitstable-findsimilarfileindex HRESULT
			// FindSimilarFileIndex( [in] SimilarityData *similarityData, USHORT numberOfMatchesRequired, [out] FindSimilarFileIndexResults
			// *findSimilarFileIndexResults, [in] DWORD resultsSize, [out] DWORD *resultsUsed );
			void FindSimilarFileIndex(in SimilarityData similarityData, ushort numberOfMatchesRequired,
				out FindSimilarFileIndexResults findSimilarFileIndexResults, uint resultsSize, out uint resultsUsed);

			/// <summary>Retrieves similarity data from the similarity traits table.</summary>
			/// <returns>
			/// An optional pointer to a location that will receive the returned ISimilarityTableDumpState interface pointer. The caller must
			/// release this interface when it is no longer needed.
			/// </returns>
			/// <remarks>
			/// The <c>BeginDump</c> method is used for debugging and garbage collection. It returns an interface pointer to an iterator
			/// object that allows the application to efficiently dump all of the entries in the similarity traits table.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitstable-begindump HRESULT BeginDump( [out,
			// optional] ISimilarityTableDumpState **similarityTableDumpState );
			ISimilarityTableDumpState BeginDump();

			/// <summary>Retrieves the index of the last entry that was stored in the similarity traits table.</summary>
			/// <returns>A pointer to a variable that receives the index of the last entry.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/nf-msrdc-isimilaritytraitstable-getlastindex HRESULT GetLastIndex(
			// [out] SimilarityFileIndexT *fileIndex );
			uint GetLastIndex();
		}

		/// <summary>
		/// Contains the file index information that the ISimilarityTraitsTable::FindSimilarFileIndex method returned for a matching file.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-findsimilarfileindexresults typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0013 { SimilarityFileIndexT m_FileIndex; unsigned int m_MatchCount; } FindSimilarFileIndexResults;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0013")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FindSimilarFileIndexResults
		{
			/// <summary>The index of the matching file in the similarity traits table.</summary>
			public uint m_FileIndex;

			/// <summary>The number of traits that were matched. The valid range is from <c>MSRDC_MINIMUM_MATCHESREQUIRED</c> to <c>MSRDC_MAXIMUM_MATCHESREQUIRED</c>.</summary>
			public uint m_MatchCount;
		}

		/// <summary>The <c>RdcBufferPointer</c> structure describes a buffer.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-rdcbufferpointer typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0005 { ULONG m_Size; ULONG m_Used; BYTE *m_Data; } RdcBufferPointer;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0005")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RdcBufferPointer
		{
			/// <summary>Size, in bytes, of the buffer.</summary>
			public uint m_Size;

			/// <summary>
			/// For input buffers, IRdcComparator::Process and IRdcGenerator::Process will store here how much (if any) of the buffer was
			/// used during processing.
			/// </summary>
			public uint m_Used;

			/// <summary>Pointer to the buffer.</summary>
			public IntPtr m_Data;
		}

		/// <summary>The <c>RdcNeed</c> structure contains information about a chunk that is required to synchronize two sets of data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-rdcneed typedef struct __MIDL___MIDL_itf_msrdc_0000_0000_0004 {
		// RdcNeedType m_BlockType; unsigned __int64 m_FileOffset; unsigned __int64 m_BlockLength; } RdcNeed;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0004")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RdcNeed
		{
			/// <summary>Describes the type of data needed耀ource data or seed data.</summary>
			public RdcNeedType m_BlockType;

			/// <summary>Offset, in bytes, from the start of the data where the chunk should be copied from.</summary>
			public ulong m_FileOffset;

			/// <summary>Length, in bytes, of the chunk of data that is to be copied to the target data.</summary>
			public ulong m_BlockLength;
		}

		/// <summary>
		/// The <c>RdcNeedPointer</c> structure describes an array of RdcNeed structures. The <c>RdcNeedPointer</c> structure is used as both
		/// input and output by the IRdcComparator::Process method.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-rdcneedpointer typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0006 { ULONG m_Size; ULONG m_Used; RdcNeed *m_Data; } RdcNeedPointer;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0006")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RdcNeedPointer
		{
			/// <summary>Contains the number of RdcNeed structures in array pointed to by <c>m_Data</c>.</summary>
			public uint m_Size;

			/// <summary>
			/// When the structure is passed to the IRdcComparator::Process method, this member should be zero. On return this member will
			/// contain the number of RdcNeed structures that were filled with data.
			/// </summary>
			public uint m_Used;

			/// <summary>
			/// Address of array of <see cref="RdcNeed"/> structures that describe the chunks required from the source and seed data.
			/// </summary>
			public IntPtr m_Data;

			/// <summary>Array of <see cref="RdcNeed"/> structures that describe the chunks required from the source and seed data.</summary>
			public SafeNativeArray<RdcNeed> Data { get => new(m_Data, (int)m_Size, false); set => m_Data = value; }
		}

		/// <summary>The <c>RdcSignature</c> structure contains a single signature and the length of the chunk used to generate it.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-rdcsignature typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0007 { BYTE m_Signature[16]; USHORT m_BlockLength; } RdcSignature;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0007")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RdcSignature
		{
			/// <summary>Signature of a chunk of data.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] m_Signature;

			/// <summary>Length of the chunk represented by this signature.</summary>
			public ushort m_BlockLength;
		}

		/// <summary>
		/// The <c>RdcSignaturePointer</c> structure describes an array of RdcSignature structures. The <c>RdcSignaturePointer</c> structure
		/// is used as both input and output by the IRdcSignatureReader::ReadSignatures method.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-rdcsignaturepointer typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0008 { ULONG m_Size; ULONG m_Used; RdcSignature *m_Data; } RdcSignaturePointer;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0008")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RdcSignaturePointer
		{
			/// <summary>Contains the number of RdcSignature structures in array pointed to by <c>m_Data</c>.</summary>
			public uint m_Size;

			/// <summary>
			/// When the structure is passed to the IRdcSignatureReader::ReadSignatures method, this member should be zero. On return this
			/// member will contain the number of RdcSignature structures that were filled.
			/// </summary>
			public uint m_Used;

			/// <summary>Address of an array of <see cref="RdcSignature"/> structures.</summary>
			public IntPtr m_Data;

			/// <summary>An array of <see cref="RdcSignature"/> structures.</summary>
			public SafeNativeArray<RdcSignature> Data { get => new(m_Data, (int)m_Size, false); set => m_Data = value; }
		}

		/// <summary>Contains the similarity data for a file.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-similaritydata typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0012 { unsigned char m_Data[16]; } SimilarityData;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0012")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SimilarityData
		{
			/// <summary>The similarity data for the file.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] m_Data;
		}

		/// <summary>Contains the similarity information that was returned for a file by the ISimilarityTableDumpState::GetNextData method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-similaritydumpdata typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0014 { SimilarityFileIndexT m_FileIndex; SimilarityData m_Data; } SimilarityDumpData;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0014")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SimilarityDumpData
		{
			/// <summary>The index of the SimilarityData structure in the similarity traits table.</summary>
			public uint m_FileIndex;

			/// <summary>A SimilarityData structure that contains the similarity data for the file.</summary>
			public SimilarityData m_Data;
		}

		/// <summary>Contains the similarity file ID for a file.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-similarityfileid typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0015 { byte m_FileId[32]; } SimilarityFileId;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0015")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SimilarityFileId
		{
			/// <summary>The similarity file ID for the file.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public byte[] m_FileId;
		}

		/// <summary>Contains information about a similarity mapped view.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msrdc/ns-msrdc-similaritymappedviewinfo typedef struct
		// __MIDL___MIDL_itf_msrdc_0000_0000_0011 { unsigned char *m_Data; DWORD m_Length; } SimilarityMappedViewInfo;
		[PInvokeData("msrdc.h", MSDNShortId = "NS:msrdc.__MIDL___MIDL_itf_msrdc_0000_0000_0011")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SimilarityMappedViewInfo
		{
			/// <summary>The mapped view information.</summary>
			public IntPtr m_Data;

			/// <summary>Size, in bytes, of the mapped view information.</summary>
			public uint m_Length;
		}

		/// <summary>CLSID_FindSimilarResults</summary>
		[ComImport, Guid("96236A93-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class FindSimilarResults { }

		/// <summary>CLSID_RdcComparator</summary>
		[ComImport, Guid("96236A8B-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcComparator { }

		/// <summary>CLSID_RdcFileReader</summary>
		[ComImport, Guid("96236A89-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcFileReader { }

		/// <summary>CLSID_RdcGenerator</summary>
		[ComImport, Guid("96236A88-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcGenerator { }

		/// <summary>CLSID_RdcGeneratorFilterMaxParameters</summary>
		[ComImport, Guid("96236A87-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcGeneratorFilterMaxParameters { }

		/// <summary>CLSID_RdcGeneratorParameters</summary>
		[ComImport, Guid("96236A86-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcGeneratorParameters { }

		/// <summary>CLSID_RdcGenerator</summary>
		[ComImport, Guid("96236A85-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcLibrary { }

		/// <summary>CLSID_RdcSignatureReader</summary>
		[ComImport, Guid("96236A8A-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcSignatureReader { }

		/// <summary>CLSID_RdcSimilarityGenerator</summary>
		[ComImport, Guid("96236A92-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class RdcSimilarityGenerator { }

		/// <summary>CLSID_Similarity</summary>
		[ComImport, Guid("96236A91-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class Similarity { }

		/// <summary>CLSID_SimilarityFileIdTable</summary>
		[ComImport, Guid("96236A90-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class SimilarityFileIdTable { }

		/// <summary>CLSID_SimilarityReportProgress</summary>
		[ComImport, Guid("96236A8D-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class SimilarityReportProgress { }

		/// <summary>CLSID_SimilarityTableDumpState</summary>
		[ComImport, Guid("96236A8E-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class SimilarityTableDumpState { }

		/// <summary>CLSID_SimilarityTraitsMappedView</summary>
		[ComImport, Guid("96236A95-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class SimilarityTraitsMappedView { }

		/// <summary>CLSID_SimilarityTraitsMapping</summary>
		[ComImport, Guid("96236A94-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class SimilarityTraitsMapping { }

		/// <summary>CLSID_SimilarityTraitsTable</summary>
		[ComImport, Guid("96236A8F-9DBC-11DA-9E3F-0011114AE311"), ClassInterface(ClassInterfaceType.None)]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public class SimilarityTraitsTable { }
	}
}