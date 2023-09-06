namespace Vanara.PInvoke;

/// <summary>Items from the AviFil32.dll</summary>
public static partial class AviFil32
{
	/// <summary>
	/// The <c>IAVIEditStream</c> interface supports manipulating and modifying editable streams. Uses IUnknown::QueryInterface,
	/// IUnknown::AddRef, IUnknown::Release in addition to the following custom methods:
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nn-vfw-iavieditstream
	[PInvokeData("vfw.h", MSDNShortId = "NN:vfw.IAVIEditStream")]
	[ComImport, Guid("00020024-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAVIEditStream
	{
		/// <summary>
		/// The <c>Cut</c> method removes a portion of a stream and places it in a temporary stream. Called when an application uses the
		/// EditStreamCut function.
		/// </summary>
		/// <param name="plStart">Pointer to a buffer that receives the starting position of the operation.</param>
		/// <param name="plLength">Pointer to a buffer that receives the length, in frames, of the operation.</param>
		/// <returns>Pointer to a buffer that receives a pointer to the interface to the new stream.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavieditstream-cut HRESULT Cut( LONG *plStart, LONG *plLength,
		// PAVISTREAM *ppResult );
		IAVIStream Cut(ref int plStart, ref int plLength);

		/// <summary>
		/// The <c>Copy</c> method copies a stream or a portion of it to a temporary stream. Called when an application uses the
		/// EditStreamCopy function.
		/// </summary>
		/// <param name="plStart">Pointer to a buffer that receives the starting position of the operation.</param>
		/// <param name="plLength">Pointer to a buffer that receives the length, in frames, of the operation.</param>
		/// <returns>Pointer to a buffer that receives a pointer to the interface to the new stream.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavieditstream-copy HRESULT Copy( LONG *plStart, LONG
		// *plLength, PAVISTREAM *ppResult );
		IAVIStream Copy(ref int plStart, ref int plLength);

		/// <summary>
		/// The <c>Paste</c> method copies a stream or a portion of it in another stream. Called when an application uses the
		/// EditStreamPaste function.
		/// </summary>
		/// <param name="plPos">Pointer to a buffer that receives the starting position of the operation.</param>
		/// <param name="plLength">Pointer to a buffer that receives the length, in bytes, of the data to paste from the source stream.</param>
		/// <param name="pstream">Pointer to the interface to the source stream.</param>
		/// <param name="lStart">Starting position of the copy operation within the source stream.</param>
		/// <param name="lEnd">Ending position of the copy operation within the source stream.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavieditstream-paste HRESULT Paste( LONG *plPos, LONG
		// *plLength, PAVISTREAM pstream, LONG lStart, LONG lEnd );
		void Paste(ref int plPos, ref int plLength, [In, Out] IAVIStream pstream, [In] int lStart, [In] int lEnd);

		/// <summary>The <c>Clone</c> method duplicates a stream. Called when an application uses the EditStreamClone function.</summary>
		/// <returns>Receives a pointer to the interface to the new stream.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavieditstream-clone HRESULT Clone( PAVISTREAM *ppResult );
		IAVIStream Clone();

		/// <summary>
		/// The <c>SetInfo</c> method changes the characteristics of a stream. Called when an application uses the EditStreamSetInfo function.
		/// </summary>
		/// <param name="lpInfo">Pointer to an AVISTREAMINFO structure containing the new stream characteristics.</param>
		/// <param name="cbInfo">Size, in bytes, of the buffer.</param>
		/// <returns>Returns the HRESULT defined by OLE.</returns>
		/// <remarks>
		/// <para>For handlers written in C++, <c>SetInfo</c> has the following syntax:</para>
		/// <para>
		/// <code> HRESULT SetInfo(AVISTREAMINFO *lpInfo, LONG cbInfo);</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavieditstream-setinfo HRESULT SetInfo( AVISTREAMINFOW *lpInfo,
		// LONG cbInfo );
		void SetInfo(in AVISTREAMINFO lpInfo, [In] int cbInfo);
	};

	/// <summary>
	/// The <c>IAVIFile</c> interface supports opening and manipulating files and file headers, and creating and obtaining stream
	/// interfaces. Uses IUnknown::QueryInterface, IUnknown::AddRef, and IUnknown::Release in addition to the following custom methods:
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nn-vfw-iavifile
	[PInvokeData("vfw.h", MSDNShortId = "NN:vfw.IAVIFile")]
	[ComImport, Guid("00020020-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAVIFile
	{
		/// <summary>
		/// The <c>Info</c> method returns with information about an AVI file. Called when an application uses the AVIFileInfo function.
		/// </summary>
		/// <param name="pfi">A pointer to an AVIFILEINFO structure. The method fills the structure with information about the file.</param>
		/// <param name="lSize">The size, in bytes, of the buffer specified by pfi.</param>
		/// <remarks>
		/// <para>
		/// If the buffer allocated is too small for the structure, this method should fail the call by returning AVIERR_BUFFERTOOSMALL.
		/// Otherwise, it should fill the structure and return its size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavifile-info HRESULT Info( AVIFILEINFOW *pfi, LONG lSize );
		void Info(out AVIFILEINFO pfi, [In] int lSize);

		/// <summary>
		/// The <c>GetStream</c> method opens a stream by accessing it in a file. Called when an application uses the AVIFileGetStream function.
		/// </summary>
		/// <param name="ppStream">Pointer to a buffer that receives a pointer to the interface to a stream.</param>
		/// <param name="fccType">Four-character code indicating the type of stream to locate.</param>
		/// <param name="lParam">Stream number.</param>
		/// <remarks>
		/// <para>
		/// It is typically easier to implement this method by creating all of the stream objects in advance by using the IAVIFile::Open
		/// method. Then, this method accesses the interface to the specified stream.
		/// </para>
		/// <para>
		/// Remember to increment the reference count maintained by the <c>AddRef</c> method for the stream when this method is used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavifile-getstream HRESULT GetStream( PAVISTREAM *ppStream,
		// DWORD fccType, LONG lParam );
		void GetStream(out IAVIStream ppStream, [In] uint fccType, [In] int lParam);

		/// <summary>
		/// The <c>CreateStream</c> method creates a stream for writing. Called when an application uses the AVIFileCreateStream function.
		/// </summary>
		/// <param name="ppStream">Pointer to a buffer that receives a pointer to the interface to the new stream.</param>
		/// <param name="psi">Pointer to an AVISTREAMINFO structure defining the stream to create.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavifile-createstream HRESULT CreateStream( PAVISTREAM
		// *ppStream, AVISTREAMINFOW *psi );
		void CreateStream(out IAVIStream ppStream, in AVISTREAMINFO psi);

		/// <summary>The <c>WriteData</c> method writes file headers. Called when an application uses the AVIFileWriteData function.</summary>
		/// <param name="ckid">A chunk ID.</param>
		/// <param name="lpData">A pointer specifying the memory from which the data is written.</param>
		/// <param name="cbData">A LONG specifying the number of bytes to write.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavifile-writedata HRESULT WriteData( DWORD ckid, LPVOID
		// lpData, LONG cbData );
		void WriteData([In] uint ckid, [In] IntPtr lpData, [In] int cbData);

		/// <summary>The <c>ReadData</c> method reads file headers. Called when an application uses the AVIFileReadData function.</summary>
		/// <param name="ckid">A chunk identfier.</param>
		/// <param name="lpData">A pointer specifying the memory into which the data is read.</param>
		/// <param name="lpcbData">A pointer to a LONG specifying the number of bytes read.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavifile-readdata HRESULT ReadData( DWORD ckid, LPVOID lpData,
		// LONG *lpcbData );
		void ReadData([In] uint ckid, [Out] IntPtr lpData, ref int lpcbData);

		/// <summary>
		/// The <c>EndRecord</c> method writes the "REC" chunk in a tightly interleaved AVI file (having a one-to-one interleave factor
		/// of audio to video). Called when an application uses the AVIFileEndRecord function.
		/// </summary>
		/// <remarks>
		/// <para>This file handler method is typically not used.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavifile-endrecord HRESULT EndRecord();
		void EndRecord();

		/// <summary>Deletes the stream.</summary>
		/// <param name="fccType">Four-character code indicating the type of stream to delete.</param>
		/// <param name="lParam">Stream number.</param>
		void DeleteStream([In] uint fccType, [In] int lParam);
	}

	/// <summary>
	/// The <c>IAVIStream</c> interface supports creating and manipulating data streams within a file. Uses IUnknown::QueryInterface,
	/// IUnknown::AddRef, IUnknown::Release in addition to the following custom methods:
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nn-vfw-iavistream
	[PInvokeData("vfw.h", MSDNShortId = "NN:vfw.IAVIStream")]
	[ComImport, Guid("00020021-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAVIStream
	{
		/// <summary>
		/// The <c>Create</c> method initializes a stream handler that is not associated with any file. Called when an application uses
		/// the AVIStreamCreate function.
		/// </summary>
		/// <param name="lParam1">Stream handler-specific data.</param>
		/// <param name="lParam2">Stream handler-specific data.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-create HRESULT Create( LPARAM lParam1, LPARAM
		// lParam2 );
		void Create(IntPtr lParam1, IntPtr lParam2);

		/// <summary>
		/// The <c>Info</c> method fills and returns an AVISTREAMINFO structure with information about a stream. Called when an
		/// application uses the AVIStreamInfo function.
		/// </summary>
		/// <param name="psi">Pointer to an AVISTREAMINFO structure to contain stream information.</param>
		/// <param name="lSize">Size, in bytes, of the structure specified by psi.</param>
		/// <remarks>
		/// <para>
		/// If the buffer allocated is too small for the structure, the <c>Info</c> method should fail the call by returning
		/// AVIERR_BUFFERTOOSMALL. Otherwise, it should fill the structure and return its size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-info HRESULT Info( AVISTREAMINFOW *psi, LONG lSize );
		void Info(out AVISTREAMINFO psi, [In] int lSize);

		/// <summary>
		/// The <c>FindSample</c> method obtains the position in a stream of a key frame or a nonempty frame. Called when an application
		/// uses the AVIStreamFindSample function.
		/// </summary>
		/// <param name="lPos">Position of the sample or frame.</param>
		/// <param name="lFlags">
		/// <para>Applicable flags. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>FIND_ANY</term>
		/// <term>Searches for a nonempty frame.</term>
		/// </item>
		/// <item>
		/// <term>FIND_FORMAT</term>
		/// <term>Searches for a format change.</term>
		/// </item>
		/// <item>
		/// <term>FIND_KEY</term>
		/// <term>Searches for a key frame.</term>
		/// </item>
		/// <item>
		/// <term>FIND_NEXT</term>
		/// <term>Searches forward through a stream, beginning with the current frame.</term>
		/// </item>
		/// <item>
		/// <term>FIND_PREV</term>
		/// <term>Searches backward through a stream, beginning with the current frame.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The FIND_ANY, FIND_KEY, and FIND_FORMAT flags are mutually exclusive, as are the FIND_NEXT and FIND_PREV flags. You must
		/// specify one value from each group.
		/// </para>
		/// </param>
		/// <returns>Returns the location of the key frame corresponding to the frame specified by the application.</returns>
		/// <remarks>
		/// <para>If key frames are not significant in your custom format, return the position specified for lPos.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-findsample LONG FindSample( LONG lPos, LONG lFlags );
		[PreserveSig]
		int FindSample([In] int lPos, [In] FINDF lFlags);

		/// <summary>
		/// The <c>ReadFormat</c> method obtains format information from a stream. Fills and returns a structure with the data in an
		/// application-defined buffer. If no buffer is supplied, determines the buffer size needed to retrieve the buffer of format
		/// data. Called when an application uses the AVIStreamReadFormat function.
		/// </summary>
		/// <param name="lPos">Position of the sample or frame.</param>
		/// <param name="lpFormat">
		/// Pointer to the buffer for the format data. Specify <c>NULL</c> to request the required size of the buffer.
		/// </param>
		/// <param name="lpcbFormat">
		/// Pointer to a buffer that receives the size, in bytes, of the buffer specified by lpFormat. When this method is called, the
		/// contents of this parameter indicates the size of the buffer specified by lpFormat. When this method returns control to the
		/// application, the contents of this parameter specifies the amount of data read or the required size of the buffer.
		/// </param>
		/// <remarks>
		/// <para>
		/// The type of data stored in a stream dictates the format information and the structure that contains the format information.
		/// A stream handler should return all applicable format information in this structure, including palette information when the
		/// format uses a palette. A stream handler should not return stream data with the structure.
		/// </para>
		/// <para>
		/// Standard video stream handlers provide format information in a <c>BITMAPINFOHEADER</c> structure. Standard audio stream
		/// handlers provide format information in a <c>PCMWAVEFORMAT</c> structure. Other data streams can use other structures that
		/// describe the stream data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-readformat HRESULT ReadFormat( LONG lPos, LPVOID
		// lpFormat, LONG *lpcbFormat );
		void ReadFormat([In] int lPos, [Out, Optional] IntPtr lpFormat, ref int lpcbFormat);

		/// <summary>
		/// The <c>SetFormat</c> method sets format information in a stream. Called when an application uses the AVIStreamSetFormat function.
		/// </summary>
		/// <param name="lPos">Pointer to the interface to a stream.</param>
		/// <param name="lpFormat">Pointer to the buffer for the format data.</param>
		/// <param name="cbFormat">Address containing the size, in bytes, of the buffer specified by lpFormat.</param>
		/// <remarks>
		/// <para>
		/// Standard video stream handlers provide format information in a <c>BITMAPINFOHEADER</c> structure. Standard audio stream
		/// handlers provide format information in a <c>PCMWAVEFORMAT</c> structure. Other data streams can use other structures that
		/// describe the stream data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-setformat HRESULT SetFormat( LONG lPos, LPVOID
		// lpFormat, LONG cbFormat );
		void SetFormat([In] int lPos, [In] IntPtr lpFormat, [In] int cbFormat);

		/// <summary>
		/// The <c>Read</c> method reads data from a stream and copies it to an application-defined buffer. If no buffer is supplied, it
		/// determines the buffer size needed to retrieve the next buffer of data. Called when an application uses the AVIStreamRead function.
		/// </summary>
		/// <param name="lStart">Starting sample or frame number to read.</param>
		/// <param name="lSamples">Number of samples to read.</param>
		/// <param name="lpBuffer">
		/// Pointer to the application-defined buffer to contain the stream data. You can also specify <c>NULL</c> to request the
		/// required size of the buffer. Many applications precede each read operation with a query for the buffer size to see how large
		/// a buffer is needed.
		/// </param>
		/// <param name="cbBuffer">Size, in bytes, of the buffer specified by lpBuffer.</param>
		/// <param name="plBytes">Pointer to a buffer that receives the number of bytes read.</param>
		/// <param name="plSamples">Pointer to a buffer that receives the number of samples read.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-read HRESULT Read( LONG lStart, LONG lSamples,
		// LPVOID lpBuffer, LONG cbBuffer, LONG *plBytes, LONG *plSamples );
		void Read([In] int lStart, [In] int lSamples, [Out, Optional] IntPtr lpBuffer, [In] int cbBuffer, out int plBytes, out int plSamples);

		/// <summary>The <c>Write</c> method writes data to a stream. Called when an application uses the AVIStreamWrite function.</summary>
		/// <param name="lStart">Starting sample or frame number to write.</param>
		/// <param name="lSamples">Number of samples to write.</param>
		/// <param name="lpBuffer">Pointer to the buffer for the data.</param>
		/// <param name="cbBuffer">Size, in bytes, of the buffer specified by lpBuffer.</param>
		/// <param name="dwFlags">
		/// Applicable flags. The AVIF_KEYFRAME flag is defined and indicates that this frame contains all the information needed for a
		/// complete image.
		/// </param>
		/// <param name="plSampWritten">Pointer to a buffer used to contain the number of samples written.</param>
		/// <param name="plBytesWritten">Pointer to a buffer that receives the number of bytes written.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-write HRESULT Write( LONG lStart, LONG lSamples,
		// LPVOID lpBuffer, LONG cbBuffer, DWORD dwFlags, LONG *plSampWritten, LONG *plBytesWritten );
		void Write([In] int lStart, [In] int lSamples, [In] IntPtr lpBuffer, [In] int cbBuffer, [In] AVIIF dwFlags, out int plSampWritten, out int plBytesWritten);

		/// <summary>The <c>Delete</c> method deletes data from a stream.</summary>
		/// <param name="lStart">Starting sample or frame number to delete.</param>
		/// <param name="lSamples">Number of samples to delete.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-delete HRESULT Delete( LONG lStart, LONG lSamples );
		void Delete([In] int lStart, [In] int lSamples);

		/// <summary>
		/// The <c>ReadData</c> method reads data headers of a stream. Called when an application uses the AVIStreamReadData function.
		/// </summary>
		/// <param name="fcc">Four-character code of the stream header to read.</param>
		/// <param name="lp">Pointer to the buffer to contain the header data.</param>
		/// <param name="lpcb">
		/// Size, in bytes, of the buffer specified by lpBuffer. When this method returns control to the application, the contents of
		/// this parameter specifies the amount of data read.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-readdata HRESULT ReadData( DWORD fcc, LPVOID lp,
		// LONG *lpcb );
		void ReadData([In] uint fcc, [Out, Optional] IntPtr lp, ref int lpcb);

		/// <summary>
		/// The <c>WriteData</c> method writes headers for a stream. Called when an application uses the AVIStreamWriteData function.
		/// </summary>
		/// <param name="fcc">Four-character code of the stream header to write.</param>
		/// <param name="lp">Pointer to the buffer that contains the header data to write.</param>
		/// <param name="cb">Size, in bytes, of the buffer specified by lpBuffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistream-writedata HRESULT WriteData( DWORD fcc, LPVOID lp,
		// LONG cb );
		void WriteData([In] uint fcc, [In] IntPtr lp, [In] int cb);
	}

	/// <summary>
	/// The <c>IAVIStreaming</c> interface supports preparing open data streams for playback in streaming operations. Uses
	/// IUnknown::QueryInterface, IUnknown::AddRef, IUnknown::Release in addition to the following custom methods:
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nn-vfw-iavistreaming
	[PInvokeData("vfw.h", MSDNShortId = "NN:vfw.IAVIStreaming")]
	[ComImport, Guid("00020022-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAVIStreaming
	{
		/// <summary>
		/// The <c>Begin</c> method prepares for the streaming operation. Called when an application uses the AVIStreamBeginStreaming function.
		/// </summary>
		/// <param name="lStart">Starting frame for streaming.</param>
		/// <param name="lEnd">Ending frame for streaming.</param>
		/// <param name="lRate">
		/// Speed at which the file is read relative to its normal playback rate. Normal speed is 1000. Larger values indicate faster
		/// speeds; smaller values indicate slower speeds.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistreaming-begin HRESULT Begin( LONG lStart, LONG lEnd, LONG
		// lRate );
		void Begin([In] int lStart, [In] int lEnd, [In] int lRate);

		/// <summary>
		/// The <c>End</c> method ends the streaming operation. Called when an application uses the AVIStreamEndStreaming function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-iavistreaming-end HRESULT End();
		void End();
	};

	//[ComImport, Guid("00020025-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	//public interface IAVIPersistFile : System.Runtime.InteropServices.ComTypes.IPersistFile
	//{
	//	new void GetClassID(out Guid pClassID);
	//	new int IsDirty();
	//	new void Load(string pszFileName, int dwMode);
	//	new void Save(string pszFileName, bool fRemember);
	//	new void SaveCompleted(string pszFileName);
	//	new void GetCurFile(out string ppszFileName);
	//	void Reserved1();
	//}
	/// <summary>
	/// The <c>IGetFrame</c> interface supports extracting, decompressing, and displaying individual frames from an open stream. Uses
	/// IUnknown::QueryInterface, IUnknown::AddRef, IUnknown::Release in addition to the following custom methods:
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nn-vfw-igetframe
	[PInvokeData("vfw.h", MSDNShortId = "NN:vfw.IGetFrame")]
	[ComImport, Guid("00020023-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IGetFrame
	{
		/// <summary>
		/// The <c>GetFrame</c> method retrieves a decompressed copy of a frame from a stream. Called when an application uses the
		/// AVIStreamGetFrame function.
		/// </summary>
		/// <param name="lPos">Frame to copy and decompress.</param>
		/// <returns>Returns the address of the decompressed frame data.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-igetframe-getframe LPVOID GetFrame( LONG lPos );
		[PreserveSig]
		IntPtr GetFrame([In] int lPos);

		/// <summary>
		/// The <c>Begin</c> method prepares to extract and decompress copies of frames from a stream. Called when an application uses
		/// the AVIStreamGetFrameOpen function.
		/// </summary>
		/// <param name="lStart">Starting frame for extracting and decompressing.</param>
		/// <param name="lEnd">Ending frame for extracting and decompressing.</param>
		/// <param name="lRate">
		/// Speed at which the file is read relative to its normal playback rate. Normal speed is 1000. Larger values indicate faster
		/// speeds; smaller values indicate slower speeds.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-igetframe-begin HRESULT Begin( LONG lStart, LONG lEnd, LONG
		// lRate );
		void Begin([In] int lStart, [In] int lEnd, [In] int lRate);

		/// <summary>
		/// The <c>End</c> method ends frame extraction and decompression. Called when an application uses the AVIStreamGetFrameClose function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-igetframe-end HRESULT End();
		void End();

		/// <summary>
		/// The <c>SetFormat</c> method sets the decompressed image format of the frames being extracted and optionally provides a
		/// buffer for the decompression operation.
		/// </summary>
		/// <param name="lpbi">
		/// Pointer to a BITMAPINFOHEADER structure defining the decompressed image format. You can also specify <c>NULL</c> or the value
		/// <code>((LPBITMAPINFOHEADER) 1)</code>
		/// for this parameter. <c>NULL</c> causes the decompressor to choose a format that is appropriate for editing (normally a
		/// 24-bit image depth format). The value
		/// <code>((LPBITMAPINFOHEADER) 1)</code>
		/// causes the decompressor to choose a format appropriate for the current display mode.
		/// </param>
		/// <param name="lpBits">
		/// Pointer to a buffer to contain the decompressed image data. Specify <c>NULL</c> to have this method allocate a buffer.
		/// </param>
		/// <param name="x">
		/// The x-coordinate of the destination rectangle within the DIB specified by lpbi. This parameter is used when lpBits is not <c>NULL</c>.
		/// </param>
		/// <param name="y">
		/// The y-coordinate of the destination rectangle within the DIB specified by lpbi. This parameter is used when lpBits is not <c>NULL</c>.
		/// </param>
		/// <param name="dx">Width of the destination rectangle. This parameter is used when lpBits is not <c>NULL</c>.</param>
		/// <param name="dy">Height of the destination rectangle. This parameter is used when lpBits is not <c>NULL</c>.</param>
		/// <remarks>
		/// <para>
		/// The x, y, dx, and dy parameters identify the portion of the bitmap specified by lpbi and lpBits that receives the
		/// decompressed image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-igetframe-setformat HRESULT SetFormat( LPBITMAPINFOHEADER lpbi,
		// LPVOID lpBits, int x, int y, int dx, int dy );
		void SetFormat([In, Optional] IntPtr lpbi, [In, Optional] IntPtr lpBits, [In] int x, [In] int y, [In] int dx, [In] int dy);
	}
}