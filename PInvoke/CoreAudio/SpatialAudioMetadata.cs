namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>Specifies the copy mode used when calling ISpatialAudioMetadataCopier::CopyMetadataForFrames.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/ne-spatialaudiometadata-spatialaudiometadatacopymode typedef
	// enum SpatialAudioMetadataCopyMode { SpatialAudioMetadataCopy_Overwrite, SpatialAudioMetadataCopy_Append,
	// SpatialAudioMetadataCopy_AppendMergeWithLast, SpatialAudioMetadataCopy_AppendMergeWithFirst } ;
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "2E9C2C66-26EB-43E8-A518-25980B287542")]
	public enum SpatialAudioMetadataCopyMode
	{
		/// <summary>
		/// Creates a direct copy of the number of metadata items specified with the copyFrameCount parameter into destination buffer,
		/// overwriting any previously existing data.
		/// </summary>
		SpatialAudioMetadataCopy_Overwrite,

		/// <summary>Performs an append operation which will fail if the resulting ISpatialAudioMetadataItemsBuffer has too many items.</summary>
		SpatialAudioMetadataCopy_Append,

		/// <summary>
		/// Performs an append operation, and if overflow occurs, extra items are merged into last item, adopting last merged item's offset value.
		/// </summary>
		SpatialAudioMetadataCopy_AppendMergeWithLast,

		/// <summary>
		/// Performs an append operation, and if overflow occurs, extra items are merged, assigning the offset to the offset of the first
		/// non-overflow item.
		/// </summary>
		SpatialAudioMetadataCopy_AppendMergeWithFirst,
	}

	/// <summary>
	/// Specifies the desired behavior when an ISpatialAudioMetadataWriter attempts to write more items into the metadata buffer than was
	/// specified when the client was initialized.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/ne-spatialaudiometadata-spatialaudiometadatawriteroverflowmode
	// typedef enum SpatialAudioMetadataWriterOverflowMode { SpatialAudioMetadataWriterOverflow_Fail,
	// SpatialAudioMetadataWriterOverflow_MergeWithNew, SpatialAudioMetadataWriterOverflow_MergeWithLast } ;
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "B61C8D75-FCC3-42A6-84DE-01DBA7492962")]
	public enum SpatialAudioMetadataWriterOverflowMode
	{
		/// <summary>The write operation will fail.</summary>
		SpatialAudioMetadataWriterOverflow_Fail,

		/// <summary>
		/// The write operation will succeed, the overflow item will be merged with previous item and adopt the frame offset of newest item.
		/// </summary>
		SpatialAudioMetadataWriterOverflow_MergeWithNew,

		/// <summary>
		/// The write operation will succeed, the overflow item will be merged with previous item and keep the existing frame offset.
		/// </summary>
		SpatialAudioMetadataWriterOverflow_MergeWithLast,
	}

	/// <summary>
	/// <para>
	/// Provides a class factory for creating ISpatialAudioMetadataItems, ISpatialAudioMetadataWriter, ISpatialAudioMetadataReader, and
	/// ISpatialAudioMetadataCopier objects. When an <c>ISpatialAudioMetadataItems</c> is activated, a metadata format ID is specified, which
	/// defines the metadata format enforced for all objects created from this factory. If the specified format is not supported by the
	/// current audio render endpoint, the class factory will not successfully activate the interface and will return an error.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudiometadataclient
	[ComImport, Guid("777D4A3B-F6FF-4A26-85DC-68D7CDEDA1D4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioMetadataClient
	{
		/// <summary>Creates an ISpatialAudioMetadataItems object for storing spatial audio metadata items.</summary>
		/// <param name="maxItemCount">The maximum number of metadata items that can be stored in the returned ISpatialAudioMetadataItems.</param>
		/// <param name="frameCount">The valid range of frame offset positions for metadata items stored in the returned ISpatialAudioMetadataItems.</param>
		/// <param name="metadataItemsBuffer">
		/// If a pointer is supplied, returns an ISpatialAudioMetadataItemsBuffer interface which provides methods for attaching
		/// caller-provided memory for storage of metadata items. If this parameter is NULL, the object will allocate internal storage for
		/// the items. This interface cannot be obtained via QueryInterface.
		/// </param>
		/// <param name="metadataItems">
		/// Receives an instance ISpatialAudioMetadataItems object which can be populated with metadata items using an by
		/// ISpatialAudioMetadataWriter or ISpatialAudioMetadataCopier and can be read with an ISpatialAudioMetadataReader.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataclient-activatespatialaudiometadataitems
		// HRESULT ActivateSpatialAudioMetadataItems( UINT16 maxItemCount, UINT16 frameCount, ISpatialAudioMetadataItemsBuffer
		// **metadataItemsBuffer, ISpatialAudioMetadataItems **metadataItems );
		void ActivateSpatialAudioMetadataItems([In] ushort maxItemCount, [In] ushort frameCount, out ISpatialAudioMetadataItemsBuffer metadataItemsBuffer, out ISpatialAudioMetadataItems metadataItems);

		/// <summary>
		/// Gets the length of the buffer required to store the specified number of spatial audio metadata items. Use this method to
		/// determine the correct buffer size to use when attaching caller-provided memory through the ISpatialAudioMetadataItemsBuffer interface.
		/// </summary>
		/// <param name="maxItemCount">The maximum number of metadata items to be stored in an ISpatialAudioMetadataItems object.</param>
		/// <returns>
		/// The length of the buffer required to store the number of spatial audio metadata items specified in the maxItemCount parameter.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataclient-getspatialaudiometadataitemsbufferlength
		// HRESULT GetSpatialAudioMetadataItemsBufferLength( UINT16 maxItemCount, UINT32 *bufferLength );
		uint GetSpatialAudioMetadataItemsBufferLength([In] ushort maxItemCount);

		/// <summary>
		/// Creates an ISpatialAudioMetadataWriter object for writing spatial audio metadata items to an ISpatialAudioMetadataItems object.
		/// </summary>
		/// <param name="overflowMode">
		/// A value that specifies the behavior when attempting to write more metadata items to the ISpatialAudioMetadataItems than the
		/// maximum number of items specified when calling ActivateSpatialAudioMetadataItems.
		/// </param>
		/// <returns>Receives a pointer to an instance of ISpatialAudioMetadataWriter.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataclient-activatespatialaudiometadatawriter
		// HRESULT ActivateSpatialAudioMetadataWriter( SpatialAudioMetadataWriterOverflowMode overflowMode, ISpatialAudioMetadataWriter
		// **metadataWriter );
		ISpatialAudioMetadataWriter ActivateSpatialAudioMetadataWriter([In] SpatialAudioMetadataWriterOverflowMode overflowMode);

		/// <summary>
		/// Creates an ISpatialAudioMetadataWriter object for copying spatial audio metadata items from one ISpatialAudioMetadataItems object
		/// to another.
		/// </summary>
		/// <returns>Receives a pointer to an instance of ISpatialAudioMetadataWriter.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataclient-activatespatialaudiometadatacopier
		// HRESULT ActivateSpatialAudioMetadataCopier( ISpatialAudioMetadataCopier **metadataCopier );
		ISpatialAudioMetadataCopier ActivateSpatialAudioMetadataCopier();

		/// <summary>
		/// Creates an ISpatialAudioMetadataWriter object for reading spatial audio metadata items from an ISpatialAudioMetadataItems object.
		/// </summary>
		/// <returns>Receives a pointer to an instance of ISpatialAudioMetadataReader.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataclient-activatespatialaudiometadatareader
		// HRESULT ActivateSpatialAudioMetadataReader( ISpatialAudioMetadataReader **metadataReader );
		ISpatialAudioMetadataReader ActivateSpatialAudioMetadataReader();
	}

	/// <summary>
	/// <para>
	/// Provides methods for copying all or subsets of metadata items from a source SpatialAudioMetadataItems into a destination
	/// <c>SpatialAudioMetadataItems</c>. The <c>SpatialAudioMetadataItems</c> object, which is populated using an
	/// ISpatialAudioMetadataWriter or <c>ISpatialAudioMetadataCopier</c>, has a frame count, specified with the frameCount parameter to
	/// ActivateSpatialAudioMetadataItems, that represents the valid range of metadata item offsets. <c>ISpatialAudioMetadataReader</c>
	/// enables copying groups of items within a subrange of the total frame count. The object maintains an internal read position, which is
	/// advanced by the number of frames specified when a copy operation is performed.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudiometadatacopier
	[ComImport, Guid("D224B233-E251-4FD0-9CA2-D5ECF9A68404"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioMetadataCopier
	{
		/// <summary>Opens an ISpatialAudioMetadataItems object for copying.</summary>
		/// <param name="metadataItems">A pointer to an ISpatialAudioMetadataItems object to be opened for copying</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatacopier-open
		// HRESULT Open( ISpatialAudioMetadataItems *metadataItems );
		void Open([In] ISpatialAudioMetadataItems metadataItems);

		/// <summary>
		/// Copies metadata items from the source ISpatialAudioMetadataItems, provided to the Open method, object to the destination
		/// <c>ISpatialAudioMetadataItems</c> object, specified with the dstMetadataItems parameter. Each call advances the internal copy
		/// position by the number of frames in the copyFrameCount parameter.
		/// </summary>
		/// <param name="copyFrameCount">
		/// The number of frames from the current copy position for which metadata items are copied. After the copy, the internal copy
		/// position within the source <c>SpatialAudioMetadataItems</c> is advanced the value specified in this parameter. Set this value to
		/// 0 to copy the entire frame range contained in the source <c>SpatialAudioMetadataItems</c>.
		/// </param>
		/// <param name="copyMode">A value that specifies the copy mode for the operation.</param>
		/// <param name="dstMetadataItems">A pointer to the destination <c>SpatialAudioMetadataItems</c> for the copy operation.</param>
		/// <param name="itemsCopied">Receives number of metadata items copied in the operation.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatacopier-copymetadataforframes
		// HRESULT CopyMetadataForFrames( UINT16 copyFrameCount, SpatialAudioMetadataCopyMode copyMode, ISpatialAudioMetadataItems
		// *dstMetadataItems, UINT16 *itemsCopied );
		void CopyMetadataForFrames([In] ushort copyFrameCount, [In] SpatialAudioMetadataCopyMode copyMode, [In] ISpatialAudioMetadataItems dstMetadataItems, out ushort itemsCopied);

		/// <summary>Completes any necessary operations on the SpatialAudioMetadataItems object and releases the object.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatacopier-close
		// HRESULT Close();
		void Close();
	}

	/// <summary>
	/// <para>
	/// Represents a buffer of spatial audio metadata items. Metadata commands and values can be written to, read from, and copied between
	/// ISpatialAudioMetadataItems using the ISpatialAudioMetadataWriter, ISpatialAudioMetadataReader, and ISpatialAudioMetadataCopier
	/// interfaces. Use caller-allocated memory to store metadata items by creating an ISpatialAudioMetadataItemsBuffer.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	/// <remarks>Get an instance of this interface by calling ISpatialAudioMetadataClient::ActivateSpatialAudioMetadataItems.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudiometadataitems
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "54A6B7DE-A41E-4214-AF02-CC19250B9037")]
	[ComImport, Guid("BCD7C78F-3098-4F22-B547-A2F25A381269"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioMetadataItems
	{
		/// <summary>Gets the total frame count of the ISpatialAudioMetadataItems, which defines valid item offsets.</summary>
		/// <returns>The total frame count.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitems-getframecount
		// HRESULT GetFrameCount( UINT16 *frameCount );
		ushort GetFrameCount();

		/// <summary>The current number of items stored by the ISpatialAudioMetadataItems.</summary>
		/// <returns>The current number of stored items.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitems-getitemcount
		// HRESULT GetItemCount( UINT16 *itemCount );
		ushort GetItemCount();

		/// <summary>The maximum number of items allowed by the ISpatialAudioMetadataItems, defined when the object is created.</summary>
		/// <returns>The maximum number of items allowed.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitems-getmaxitemcount
		// HRESULT GetMaxItemCount( UINT16 *maxItemCount );
		ushort GetMaxItemCount();

		/// <summary>The size of the largest command value defined by the metadata format for the ISpatialAudioMetadataItems.</summary>
		/// <returns>The size of the largest command value defined by the metadata format.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitems-getmaxvaluebufferlength
		// HRESULT GetMaxValueBufferLength( UINT32 *maxValueBufferLength );
		uint GetMaxValueBufferLength();

		/// <summary>Gets the total frame count for the ISpatialAudioMetadataItems, which defines valid item offsets.</summary>
		/// <returns>The total frame count, which defines valid item offsets.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitems-getinfo
		// HRESULT GetInfo( SpatialAudioMetadataItemsInfo *info );
		SpatialAudioMetadataItemsInfo GetInfo();
	}

	/// <summary>
	/// <para>
	/// Provides methods for attaching buffers to SpatialAudioMetadataItems for in-place storage of data. Get an instance of this object by
	/// passing a pointer to the interface into ActivateSpatialAudioMetadataItems. The buffer will be associated with the returned
	/// <c>SpatialAudioMetadataItems</c>. This interface allows you to attach a buffer and reset its contents to the empty set of metadata
	/// items or attach a previously-populated buffer and retain the data stored in the buffer.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudiometadataitemsbuffer
	[ComImport, Guid("42640A16-E1BD-42D9-9FF6-031AB71A2DBA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioMetadataItemsBuffer
	{
		/// <summary>Attaches caller-provided memory for storage of ISpatialAudioMetadataItems objects.</summary>
		/// <param name="buffer">A pointer to memory to use for storage.</param>
		/// <param name="bufferLength">
		/// The length of the supplied buffer. This size must match the length required for the metadata format and maximum metadata item count.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitemsbuffer-attachtobuffer
		// HRESULT AttachToBuffer( BYTE *buffer, UINT32 bufferLength );
		void AttachToBuffer([Out] IntPtr buffer, [In] uint bufferLength);

		/// <summary>
		/// Attaches a previously populated buffer for storage of ISpatialAudioMetadataItems objects. The metadata items already in the
		/// buffer are retained.
		/// </summary>
		/// <param name="buffer">A pointer to memory to use for storage.</param>
		/// <param name="bufferLength">
		/// The length of the supplied buffer. This size must match the length required for the metadata format and maximum metadata item count.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitemsbuffer-attachtopopulatedbuffer
		// HRESULT AttachToPopulatedBuffer( BYTE *buffer, UINT32 bufferLength );
		void AttachToPopulatedBuffer([Out] IntPtr buffer, [In] uint bufferLength);

		/// <summary>Detaches the buffer. Memory can only be attached to a single metadata item at a time.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadataitemsbuffer-detachbuffer
		// HRESULT DetachBuffer();
		void DetachBuffer();
	}

	/// <summary>
	/// <para>
	/// Provides methods for extracting spatial audio metadata items and item command value pairs from an ISpatialAudioMetadataItems object.
	/// The <c>SpatialAudioMetadataItems</c> object, which is populated using an ISpatialAudioMetadataWriter or ISpatialAudioMetadataCopier,
	/// has a frame count, specified with the frameCount parameter to ActivateSpatialAudioMetadataItems, that represents the valid range of
	/// metadata item offsets. <c>ISpatialAudioMetadataReader</c> enables reading back groups of items within a subrange of the total frame
	/// count. The object maintains an internal read position, which is advanced by the number of frames specified when read operation is performed.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudiometadatareader
	[ComImport, Guid("B78E86A2-31D9-4C32-94D2-7DF40FC7EBEC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioMetadataReader
	{
		/// <summary>Opens an ISpatialAudioMetadataItems object for reading.</summary>
		/// <param name="metadataItems">A pointer to an ISpatialAudioMetadataItems object to be opened for reading</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatareader-open
		// HRESULT Open( ISpatialAudioMetadataItems *metadataItems );
		void Open([In] ISpatialAudioMetadataItems metadataItems);

		/// <summary>Gets the number of commands and the sample offset for the metadata item being read.</summary>
		/// <param name="commandCount">Receives the number of command/value pairs in the metadata item being read.</param>
		/// <param name="frameOffset">Gets the frame offset associated with the metadata item being read.</param>
		/// <remarks>
		/// <para>
		/// Before calling <c>ReadNextItem</c>, you must open the ISpatialAudioMetadataReader for reading by calling Open after the object is
		/// created and after Close has been called. You must also call ReadItemCountInFrames before calling <c>ReadNextItem</c>.
		/// </para>
		/// <para>
		/// The ISpatialAudioMetadataReader keeps an internal pointer to the current position within the total range of frames contained by
		/// the ISpatialAudioMetadataItems with which the reader is associated. Each call to this method causes the pointer to be advanced by
		/// the number of frames specified in the readFrameCount parameter.
		/// </para>
		/// <para>
		/// The process for reading commands and the associated values is recursive. After each call to <c>ReadItemCountInFrames</c>, call
		/// <c>ReadNextItem</c> to get the number of commands in the next item. After every call to <c>ReadNextItem</c>, call
		/// ReadNextItemCommand to read each command for the item. Repeat this process until the entire frame range of the
		/// <c>ISpatialAudioMetadataItems</c> has been read.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatareader-readnextitem
		// HRESULT ReadNextItem( UINT8 *commandCount, UINT16 *frameOffset );
		void ReadNextItem(out byte commandCount, out ushort frameOffset);

		/// <summary>Reads metadata commands and value data for the current item.</summary>
		/// <param name="commandID">Receives the command ID for the current command.</param>
		/// <param name="valueBuffer">
		/// A pointer to a buffer which receives data specific to the command as specified by the metadata format definition. The buffer must
		/// be at least maxValueBufferLength to ensure all commands can be successfully retrieved.
		/// </param>
		/// <param name="maxValueBufferLength">The maximum size of a command value.</param>
		/// <param name="valueBufferLength">The size, in bytes, of the data written to the valueBuffer parameter.</param>
		/// <remarks>
		/// <para>
		/// Before calling <c>ReadNextItem</c>, you must open the ISpatialAudioMetadataReader for reading by calling Open after the object is
		/// created and after Close has been called. You must also call ReadItemCountInFrames and then call ReadNextItem before calling <c>ReadNextItem</c>.
		/// </para>
		/// <para>
		/// The ISpatialAudioMetadataReader keeps an internal pointer to the current position within the total range of frames contained by
		/// the ISpatialAudioMetadataItems with which the reader is associated. Each call to this method causes the pointer to be advanced by
		/// the number of frames specified in the readFrameCount parameter.
		/// </para>
		/// <para>
		/// The process for reading commands and the associated values is recursive. After each call to <c>ReadItemCountInFrames</c>, call
		/// ReadNextItem to get the number of commands in the next item. After every call to <c>ReadNextItem</c>, call
		/// <c>ReadNextItemCommand</c> to read each command for the item. Repeat this process until the entire frame range of the
		/// <c>ISpatialAudioMetadataItems</c> has been read.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatareader-readnextitemcommand
		// HRESULT ReadNextItemCommand( BYTE *commandID, void *valueBuffer, UINT32 maxValueBufferLength, UINT32 *valueBufferLength );
		void ReadNextItemCommand(out byte commandID, [In] IntPtr valueBuffer, [In] uint maxValueBufferLength, out uint valueBufferLength);

		/// <summary>Completes any necessary operations on the SpatialAudioMetadataItems object and releases the object.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatareader-close
		// HRESULT Close();
		void Close();
	}

	/// <summary>
	/// <para>
	/// Provides methods for storing spatial audio metadata items positioned within a range of corresponding audio frames. Each metadata item
	/// has a zero-based offset position within the specified frame. Each item can contain one or more commands specific to the metadata
	/// format ID provided in the SpatialAudioObjectRenderStreamForMetadataActivationParams when the ISpatialAudioMetadataClient was created.
	/// This object does not allocate storage for the metadata it is provided, the caller is expected to manage the allocation of memory used
	/// to store the packed data. Multiple metadata items can be placed in the ISpatialAudioMetadataItems object. For each item, call
	/// WriteNextItem followed by a call to WriteNextItemCommand.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudiometadatawriter
	[ComImport, Guid("1B17CA01-2955-444D-A430-537DC589A844"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioMetadataWriter
	{
		/// <summary>Opens an ISpatialAudioMetadataItems object for writing.</summary>
		/// <param name="metadataItems">A pointer to an ISpatialAudioMetadataItems object to be opened for writing.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatawriter-open
		// HRESULT Open( ISpatialAudioMetadataItems *metadataItems );
		void Open([In] ISpatialAudioMetadataItems metadataItems);

		/// <summary>Starts a new metadata item at the specified offset.</summary>
		/// <param name="frameOffset">The frame offset of the item within the range specified with the frameCount parameter to ActivateSpatialAudioMetadataItems.</param>
		/// <remarks>
		/// <para>
		/// Before calling <c>WriteNextItem</c>, you must open the ISpatialAudioMetadataWriter for writing by calling Open after the object
		/// is created and after Close has been called. During a writing session demarcated by calls to <c>Open</c> and <c>Close</c>, the
		/// value of the frameOffset parameter must be greater than the value in the preceding call.
		/// </para>
		/// <para>
		/// Within a single writing session, you must not use <c>WriteNextItem</c> to write more items than the value supplied in the
		/// <c>MaxMetadataItemCount</c> field in the SpatialAudioObjectRenderStreamForMetadataActivationParam passed into
		/// ISpatialAudioClient::ActivateSpatialAudioStream or an SPTLAUD_MD_CLNT_E_FRAMEOFFSET_OUT_OF_RANGE error will occur.
		/// </para>
		/// <para>
		/// If the overflow mode is set to <c>SpatialAudioMetadataWriterOverflow_Fail</c>, the value of the frameOffset parameter must be
		/// less than he value of the frameCount parameter to ActivateSpatialAudioMetadataItems or an
		/// SPTLAUD_MD_CLNT_E_FRAMEOFFSET_OUT_OF_RANGE error will occur.
		/// </para>
		/// <para>After calling <c>WriteNextItem</c>, call WriteNextItemCommand to write metadata commands and value data for the item.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatawriter-writenextitem
		// HRESULT WriteNextItem( UINT16 frameOffset );
		void WriteNextItem([In] ushort frameOffset);

		/// <summary>Writes metadata commands and value data to the current item.</summary>
		/// <param name="commandID">
		/// A command supported by the metadata format of the object. The call will fail if the command not defined by metadata format. Each
		/// command can only be written once per item.
		/// </param>
		/// <param name="valueBuffer">
		/// A pointer to a buffer which stores data specific to the command as specified by the metadata format definition.
		/// </param>
		/// <param name="valueBufferLength">
		/// The size, in bytes, of the command data supplied in the valueBuffer parameter. The size must match command definition specified
		/// by the metadata format or the call will fail.
		/// </param>
		/// <remarks>
		/// You must open the ISpatialAudioMetadataWriter for writing by calling Open, and set the current metadata item offset by calling
		/// WriteNextItem before calling <c>WriteNextItemCommand</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatawriter-writenextitemcommand
		// HRESULT WriteNextItemCommand( BYTE commandID, const void *valueBuffer, UINT32 valueBufferLength );
		void WriteNextItemCommand([In] byte commandID, [In] IntPtr valueBuffer, [In] uint valueBufferLength);

		/// <summary>Completes any needed operations on the metadata buffer and releases the specified ISpatialAudioMetadataItems object.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudiometadatawriter-close
		// HRESULT Close();
		void Close();
	}

	/// <summary>
	/// <para>
	/// Used to write metadata commands for spatial audio. Valid commands and value lengths are defined by the metadata format specified in
	/// the SpatialAudioObjectRenderStreamForMetadataActivationParams when the ISpatialAudioObjectRenderStreamForMetadata was created.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	/// <remarks><c>Note</c> Many of the methods provided by this interface are implemented in the inherited ISpatialAudioObjectBase interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudioobjectformetadatacommands
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "B142D5CC-7321-4F3C-804D-50E728C37D10")]
	[ComImport, Guid("0DF2C94B-F5F9-472D-AF6B-C46E0AC9CD05"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioObjectForMetadataCommands : ISpatialAudioObjectBase
	{
		/// <summary>Gets a buffer that is used to supply the audio data for the ISpatialAudioObject.</summary>
		/// <param name="buffer">The buffer into which audio data is written.</param>
		/// <param name="bufferLength">
		/// The length of the buffer in bytes. This length will be the value returned in the frameCountPerBuffer parameter to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects multiplied by the value of the <c>nBlockAlign</c> field of the
		/// WAVEFORMATEX structure passed in the SpatialAudioObjectRenderStreamActivationParams parameter to ISpatialAudioClient::ActivateSpatialAudioStream.
		/// </param>
		/// <remarks>
		/// <para>
		/// The first time <c>GetBuffer</c> is called after the ISpatialAudioObject is activated with a call
		/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject, lifetime of the spatial audio object starts. To keep the spatial
		/// audio object alive after that, this <c>GetBuffer</c> must be called on every processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects). If
		/// <c>GetBuffer</c> is not called within an audio processing pass, SetEndOfStream is called implicitly on the audio object to
		/// deactivate, and the audio object can only be reused after calling Release on the object and then reactivating the object by
		/// calling <c>ActivateSpatialAudioObject</c> again.
		/// </para>
		/// <para>
		/// The pointers retrieved by <c>GetBuffer</c> should not be used after ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects has
		/// been called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getbuffer
		// HRESULT GetBuffer( BYTE **buffer, UINT32 *bufferLength );
		new void GetBuffer(out IntPtr buffer, out uint bufferLength);

		/// <summary>
		/// Instructs the system that the final block of audio data has been submitted for the ISpatialAudioObject so that the object can be
		/// deactivated and it's resources reused.
		/// </summary>
		/// <param name="frameCount">
		/// The number of audio frames in the audio buffer that should be included in the final processing pass. This number may be smaller
		/// than or equal to the value returned in the frameCountPerBuffer parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SPTLAUDCLNT_E_OUT_OF_ORDER</term>
		/// <term>ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects was not called before the call to SetEndOfStream.</term>
		/// </item>
		/// <item>
		/// <term>SPTLAUDCLNT_E_RESOURCES_INVALIDATED</term>
		/// <term>
		/// SetEndOfStream was called either explicitly or implicitly in a previous audio processing pass. SetEndOfStream is called
		/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Call Release after calling <c>SetEndOfStream</c> to make free the audio object resources for future use.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-setendofstream
		// HRESULT SetEndOfStream( UINT32 frameCount );
		new void SetEndOfStream([In] uint frameCount);

		/// <summary>Gets a boolean value indicating whether the ISpatialAudioObject is valid.</summary>
		/// <returns><c>TRUE</c> if the audio object is currently valid; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>If this value is false, you should call Release to make the audio object resource available in the future.</para>
		/// <para>
		/// <c>IsActive</c> will be set to false after SetEndOfStream is called implicitly or explicitly. <c>SetEndOfStream</c> is called
		/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
		/// </para>
		/// <para>
		/// The rendering engine will also deactivate the audio object, setting <c>IsActive</c> to false, when audio object resources become
		/// unavailable. In this case, a notification is sent via ISpatialAudioObjectRenderStreamNotify before the object is deactivated. The
		/// value returned in the availableDynamicObjectCount parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects
		/// indicates how many objects will be processed for each pass.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-isactive
		// HRESULT IsActive( BOOL *isActive );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsActive();

		/// <summary>
		/// Gets a value specifying the type of audio object that is represented by the ISpatialAudioObject. This value indicates if the
		/// object is dynamic or static. If the object is static, one and only one of the static audio channel values to which the object is
		/// assigned is returned.
		/// </summary>
		/// <returns>A value specifying the type of audio object that is represented</returns>
		/// <remarks>
		/// Set the type of the audio object with the type parameter to the ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getaudioobjecttype
		// HRESULT GetAudioObjectType( AudioObjectType *audioObjectType );
		new AudioObjectType GetAudioObjectType();

		/// <summary>
		/// Writes a metadata command to the spatial audio object, each command may only be added once per object per processing cycle. Valid
		/// commands and value lengths are defined by the metadata format specified in the
		/// SpatialAudioObjectRenderStreamForMetadataActivationParams when the ISpatialAudioObjectRenderStreamForMetadata was created.
		/// </summary>
		/// <param name="commandID">The ID of the metadata command.</param>
		/// <param name="valueBuffer">The buffer containing the value data for the metadata command.</param>
		/// <param name="valueBufferLength">The length of the valueBuffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudioobjectformetadatacommands-writenextmetadatacommand
		// HRESULT WriteNextMetadataCommand( BYTE commandID, void *valueBuffer, UINT32 valueBufferLength );
		void WriteNextMetadataCommand([In] byte commandID, [In] IntPtr valueBuffer, [In] uint valueBufferLength);
	}

	/// <summary>
	/// <para>
	/// Used to write spatial audio metadata for applications that require multiple metadata items per buffer with frame-accurate placement.
	/// The data written via this interface must adhere to the format defined by the metadata format specified in the
	/// SpatialAudioObjectRenderStreamForMetadataActivationParams when the ISpatialAudioObjectRenderStreamForMetadata was created.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	/// <remarks><c>Note</c> Many of the methods provided by this interface are implemented in the inherited ISpatialAudioObjectBase interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudioobjectformetadataitems
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "4861D2AA-E685-4A72-BE98-6FEEB72ACF67")]
	[ComImport, Guid("DDEA49FF-3BC0-4377-8AAD-9FBCFD808566"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioObjectForMetadataItems : ISpatialAudioObjectBase
	{
		/// <summary>Gets a buffer that is used to supply the audio data for the ISpatialAudioObject.</summary>
		/// <param name="buffer">The buffer into which audio data is written.</param>
		/// <param name="bufferLength">
		/// The length of the buffer in bytes. This length will be the value returned in the frameCountPerBuffer parameter to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects multiplied by the value of the <c>nBlockAlign</c> field of the
		/// WAVEFORMATEX structure passed in the SpatialAudioObjectRenderStreamActivationParams parameter to ISpatialAudioClient::ActivateSpatialAudioStream.
		/// </param>
		/// <remarks>
		/// <para>
		/// The first time <c>GetBuffer</c> is called after the ISpatialAudioObject is activated with a call
		/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject, lifetime of the spatial audio object starts. To keep the spatial
		/// audio object alive after that, this <c>GetBuffer</c> must be called on every processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects). If
		/// <c>GetBuffer</c> is not called within an audio processing pass, SetEndOfStream is called implicitly on the audio object to
		/// deactivate, and the audio object can only be reused after calling Release on the object and then reactivating the object by
		/// calling <c>ActivateSpatialAudioObject</c> again.
		/// </para>
		/// <para>
		/// The pointers retrieved by <c>GetBuffer</c> should not be used after ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects has
		/// been called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getbuffer
		// HRESULT GetBuffer( BYTE **buffer, UINT32 *bufferLength );
		new void GetBuffer(out IntPtr buffer, out uint bufferLength);

		/// <summary>
		/// Instructs the system that the final block of audio data has been submitted for the ISpatialAudioObject so that the object can be
		/// deactivated and it's resources reused.
		/// </summary>
		/// <param name="frameCount">
		/// The number of audio frames in the audio buffer that should be included in the final processing pass. This number may be smaller
		/// than or equal to the value returned in the frameCountPerBuffer parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SPTLAUDCLNT_E_OUT_OF_ORDER</term>
		/// <term>ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects was not called before the call to SetEndOfStream.</term>
		/// </item>
		/// <item>
		/// <term>SPTLAUDCLNT_E_RESOURCES_INVALIDATED</term>
		/// <term>
		/// SetEndOfStream was called either explicitly or implicitly in a previous audio processing pass. SetEndOfStream is called
		/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Call Release after calling <c>SetEndOfStream</c> to make free the audio object resources for future use.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-setendofstream
		// HRESULT SetEndOfStream( UINT32 frameCount );
		new void SetEndOfStream([In] uint frameCount);

		/// <summary>Gets a boolean value indicating whether the ISpatialAudioObject is valid.</summary>
		/// <returns><c>TRUE</c> if the audio object is currently valid; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>If this value is false, you should call Release to make the audio object resource available in the future.</para>
		/// <para>
		/// <c>IsActive</c> will be set to false after SetEndOfStream is called implicitly or explicitly. <c>SetEndOfStream</c> is called
		/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
		/// </para>
		/// <para>
		/// The rendering engine will also deactivate the audio object, setting <c>IsActive</c> to false, when audio object resources become
		/// unavailable. In this case, a notification is sent via ISpatialAudioObjectRenderStreamNotify before the object is deactivated. The
		/// value returned in the availableDynamicObjectCount parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects
		/// indicates how many objects will be processed for each pass.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-isactive
		// HRESULT IsActive( BOOL *isActive );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsActive();

		/// <summary>
		/// Gets a value specifying the type of audio object that is represented by the ISpatialAudioObject. This value indicates if the
		/// object is dynamic or static. If the object is static, one and only one of the static audio channel values to which the object is
		/// assigned is returned.
		/// </summary>
		/// <returns>A value specifying the type of audio object that is represented</returns>
		/// <remarks>
		/// Set the type of the audio object with the type parameter to the ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getaudioobjecttype
		// HRESULT GetAudioObjectType( AudioObjectType *audioObjectType );
		new AudioObjectType GetAudioObjectType();

		/// <summary>Gets a pointer to the ISpatialAudioMetadataItems object which stores metadata items for the ISpatialAudioObjectForMetadataItems.</summary>
		/// <returns>Receives a pointer to the ISpatialAudioMetadataItems associated with the ISpatialAudioObjectForMetadataItems.</returns>
		/// <remarks>The client must free this object when it is no longer being used by calling Release.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudioobjectformetadataitems-getspatialaudiometadataitems
		// HRESULT GetSpatialAudioMetadataItems( ISpatialAudioMetadataItems **metadataItems );
		ISpatialAudioMetadataItems GetSpatialAudioMetadataItems();
	}

	/// <summary>
	/// <para>
	/// Provides methods for controlling a spatial audio object render stream for metadata, including starting, stopping, and resetting the
	/// stream. Also provides methods for activating new ISpatialAudioObjectForMetadataCommands and ISpatialAudioObjectForMetadataItems
	/// instances and notifying the system when you are beginning and ending the process of updating activated spatial audio objects and data.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <c>Note</c> Many of the methods provided by this interface are implemented in the inherited ISpatialAudioObjectRenderStreamBase interface.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nn-spatialaudiometadata-ispatialaudioobjectrenderstreamformetadata
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "1623B280-FC12-4C19-9D4A-D8463D1A1046")]
	[ComImport, Guid("BBC9C907-48D5-4A2E-A0C7-F7F0D67C1FB1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioObjectRenderStreamForMetadata : ISpatialAudioObjectRenderStreamBase
	{
		/// <summary>Gets the number of dynamic spatial audio objects that are currently available.</summary>
		/// <returns>The number of dynamic spatial audio objects that are currently available.</returns>
		/// <remarks>
		/// <para>
		/// A dynamic ISpatialAudioObject is one that was activated by setting the type parameter to the ActivateSpatialAudioObject method to
		/// <c>AudioObjectType_Dynamic</c>. The system has a limit of the maximum number of dynamic spatial audio objects that can be
		/// activated at one time. Call Release on an <c>ISpatialAudioObject</c> when it is no longer being used to free up the resource to
		/// create new dynamic spatial audio objects.
		/// </para>
		/// <para>
		/// You should not call this method after streaming has started, as the value is already provided by
		/// ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects. This method should only be called before streaming has started,
		/// which occurs after ISpatialAudioObjectRenderStreamBase::Start is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-getavailabledynamicobjectcount
		// HRESULT GetAvailableDynamicObjectCount( UINT32 *value );
		new uint GetAvailableDynamicObjectCount();

		/// <summary>Gets additional services from the <c>ISpatialAudioObjectRenderStream</c>.</summary>
		/// <param name="riid">
		/// <para>The interface ID for the requested service. The client should set this parameter to one of the following REFIID values:</para>
		/// <para>IID_IAudioClock</para>
		/// <para>IID_IAudioClock2</para>
		/// <para>IID_IAudioStreamVolume</para>
		/// </param>
		/// <param name="service">
		/// Pointer to a pointer variable into which the method writes the address of an instance of the requested interface. Through this
		/// method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when it
		/// is no longer needed, by calling the interface's Release method. If the <c>GetService</c> call fails, *ppv is NULL.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter ppv is NULL.</term>
		/// </item>
		/// <item>
		/// <term>SPTLAUDCLNT_E_DESTROYED</term>
		/// <term>The ISpatialAudioClient associated with the spatial audio stream has been destroyed.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SPTLAUDCLNT_E_INTERNAL</term>
		/// <term>An internal error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>The media associated with the spatial audio stream uses an unsupported format.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetService</c> method supports the following service interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClock</term>
		/// </item>
		/// <item>
		/// <term>IAudioClock2</term>
		/// </item>
		/// <item>
		/// <term>IAudioStreamVolume</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-getservice
		// HRESULT GetService( REFIID riid, void **service );
		[PreserveSig]
		new HRESULT GetService(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object service);

		/// <summary>Starts the spatial audio stream.</summary>
		/// <remarks>
		/// <para>
		/// Starting the stream causes data flow between the endpoint buffer and the audio engine. The first time this method is called, the
		/// stream's audio clock position will be at 0. Otherwise, the clock resumes from its position at the time that the stream was last
		/// paused with a call to Stop. Call Reset to reset the clock position to 0 and cause all active ISpatialAudioObject instances to be revoked.
		/// </para>
		/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-start
		// HRESULT Start();
		new void Start();

		/// <summary>Stops a running audio stream.</summary>
		/// <remarks>
		/// Stopping stream causes data to stop flowing between the endpoint buffer and the audio engine. You can consider this operation to
		/// pause the stream because it leaves the stream's audio clock at its current stream position and does not reset it to 0. A
		/// subsequent call to Start causes the stream to resume running from the current position. Call Reset to reset the clock position to
		/// 0 and cause all active ISpatialAudioObject instances to be revoked.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-stop
		// HRESULT Stop();
		new void Stop();

		/// <summary>Reset a stopped audio stream.</summary>
		/// <remarks>
		/// <para>
		/// Resetting the audio stream flushes all pending data and resets the audio clock stream position to 0. Resetting the stream also
		/// causes all active ISpatialAudioObject instances to be revoked. A subsequent call to Start causes the stream to start from 0 position.
		/// </para>
		/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-reset
		// HRESULT Reset();
		new void Reset();

		/// <summary>
		/// Puts the system into the state where audio object data can be submitted for processing and the ISpatialAudioObject state can be modified.
		/// </summary>
		/// <param name="availableDynamicObjectCount">
		/// The number of dynamic audio objects that are available to be rendered for the current processing pass. All allocated static audio
		/// objects can be rendered in every pass. For information on audio object types, see AudioObjectType.
		/// </param>
		/// <param name="frameCountPerBuffer">The size, in audio frames, of the buffer returned by GetBuffer.</param>
		/// <remarks>
		/// <para>
		/// This method must be called each time the event passed in the SpatialAudioObjectRenderStreamActivationParams to
		/// ISpatialAudioClient::ActivateSpatialAudioStream is signaled, even if there no audio object data to submit.
		/// </para>
		/// <para>
		/// For each <c>BeginUpdatingAudioObjects</c> call, there should be a corresponding call to EndUpdatingAudioObjects call. If
		/// <c>BeginUpdatingAudioObjects</c> is called twice without a call <c>EndUpdatingAudioObjects</c> between them, the second call to
		/// <c>BeginUpdatingAudioObjects</c> will return SPTLAUDCLNT_E_OUT_OF_ORDER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-beginupdatingaudioobjects
		// HRESULT BeginUpdatingAudioObjects( UINT32 *availableDynamicObjectCount, UINT32 *frameCountPerBuffer );
		new void BeginUpdatingAudioObjects(out uint availableDynamicObjectCount, out uint frameCountPerBuffer);

		/// <summary>Notifies the system that the app has finished supplying audio data for the spatial audio objects activated with ActivateSpatialAudioObject.</summary>
		/// <remarks>The pointers retrieved with ISpatialAudioObjectBase::GetBuffer can no longer be used after this method is called.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-endupdatingaudioobjects
		// HRESULT EndUpdatingAudioObjects();
		new void EndUpdatingAudioObjects();

		/// <summary>Activate an ISpatialAudioObjectForMetadataCommands for rendering.</summary>
		/// <param name="type">
		/// The type of audio object to activate. For dynamic audio objects, this value must be <c>AudioObjectType_Dynamic</c>. For static
		/// audio objects, specify one of the static audio channel values from the enumeration. Specifying <c>AudioObjectType_None</c> will
		/// produce an audio object that is not spatialized.
		/// </param>
		/// <returns>Receives a pointer to the activated interface.</returns>
		/// <remarks>
		/// A dynamic ISpatialAudioObjectForMetadataCommands is one that was activated by setting the type parameter to the
		/// <c>ActivateSpatialAudioObjectForMetadataCommands</c> method to <c>AudioObjectType_Dynamic</c>. The client has a limit of the
		/// maximum number of dynamic spatial audio objects that can be activated at one time. After the limit has been reached, attempting
		/// to activate additional audio objects will result in this method returning an SPTLAUDCLNT_E_NO_MORE_OBJECTS error. To avoid this,
		/// call Release on each dynamic <c>ISpatialAudioObjectForMetadataCommands</c> after it is no longer being used to free up the
		/// resource so that it can be reallocated. See ISpatialAudioObjectBase::IsActive and ISpatialAudioObjectBase::SetEndOfStream for
		/// more information on the managing the lifetime of spatial audio objects.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudioobjectrenderstreamformetadata-activatespatialaudioobjectformetadatacommands
		// HRESULT ActivateSpatialAudioObjectForMetadataCommands( AudioObjectType type, ISpatialAudioObjectForMetadataCommands
		// **audioObject );
		ISpatialAudioObjectForMetadataCommands ActivateSpatialAudioObjectForMetadataCommands([In] AudioObjectType type);

		/// <summary>Activate an ISpatialAudioObjectForMetadataItems for rendering.</summary>
		/// <param name="type">
		/// The type of audio object to activate. For dynamic audio objects, this value must be <c>AudioObjectType_Dynamic</c>. For static
		/// audio objects, specify one of the static audio channel values from the enumeration. Specifying <c>AudioObjectType_None</c> will
		/// produce an audio object that is not spatialized.
		/// </param>
		/// <returns>Receives a pointer to the activated interface.</returns>
		/// <remarks>
		/// A dynamic ISpatialAudioObjectForMetadataItems is one that was activated by setting the type parameter to the
		/// <c>ActivateSpatialAudioObjectForMetadataItems</c> method to <c>AudioObjectType_Dynamic</c>. The client has a limit of the maximum
		/// number of dynamic spatial audio objects that can be activated at one time. After the limit has been reached, attempting to
		/// activate additional audio objects will result in this method returning an SPTLAUDCLNT_E_NO_MORE_OBJECTS error. To avoid this,
		/// call Release on each dynamic <c>ISpatialAudioObjectForMetadataItems</c> after it is no longer being used to free up the resource
		/// so that it can be reallocated. See ISpatialAudioObjectBase::IsActive and ISpatialAudioObjectBase::SetEndOfStream for more
		/// information on the managing the lifetime of spatial audio objects.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/nf-spatialaudiometadata-ispatialaudioobjectrenderstreamformetadata-activatespatialaudioobjectformetadataitems
		// HRESULT ActivateSpatialAudioObjectForMetadataItems( AudioObjectType type, ISpatialAudioObjectForMetadataItems **audioObject );
		ISpatialAudioObjectForMetadataItems ActivateSpatialAudioObjectForMetadataItems([In] AudioObjectType type);
	}

	/// <summary>Provides information about an ISpatialAudioMetadataItems object. Get a copy of this structure by calling GetInfo.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/ns-spatialaudiometadata-spatialaudiometadataitemsinfo typedef
	// struct SpatialAudioMetadataItemsInfo { UINT16 FrameCount; UINT16 ItemCount; UINT16 MaxItemCount; UINT32 MaxValueBufferLength; } SpatialAudioMetadataItemsInfo;
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "EC694B26-988B-4765-8B9F-130FCF614166")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SpatialAudioMetadataItemsInfo
	{
		/// <summary>The total frame count, which defines valid item offsets.</summary>
		public ushort FrameCount;

		/// <summary>
		/// <para>The current number of items stored.</para>
		/// <para>MaxItemCount</para>
		/// <para>The maximum number of items allowed.</para>
		/// <para>MaxValueBufferLength</para>
		/// <para>The size of the largest command value defined by the metadata format.</para>
		/// </summary>
		public ushort ItemCount;

		/// <summary/>
		public ushort MaxItemCount;

		/// <summary/>
		public uint MaxValueBufferLength;
	}

	/// <summary>
	/// Represents activation parameters for a spatial audio render stream for metadata. Pass this structure to
	/// ISpatialAudioClient::ActivateSpatialAudioStream when activating a stream.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/ns-spatialaudiometadata-spatialaudioobjectrenderstreamformetadataactivationparams
	// typedef struct SpatialAudioObjectRenderStreamForMetadataActivationParams { const WAVEFORMATEX *ObjectFormat; AudioObjectType
	// StaticObjectTypeMask; UINT32 MinDynamicObjectCount; UINT32 MaxDynamicObjectCount; AUDIO_STREAM_CATEGORY Category; HANDLE EventHandle;
	// GUID MetadataFormatId; UINT16 MaxMetadataItemCount; const PROPVARIANT *MetadataActivationParams; ISpatialAudioObjectRenderStreamNotify
	// *NotifyObject; } SpatialAudioObjectRenderStreamForMetadataActivationParams;
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "5B92F521-537F-4296-B9A7-7EC6985530B3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioObjectRenderStreamForMetadataActivationParams
	{
		/// <summary>
		/// Format descriptor for a single spatial audio object. All objects used by the stream must have the same format and the format must
		/// be of type WAVEFORMATEX or WAVEFORMATEXTENSIBLE.
		/// </summary>
		public IntPtr ObjectFormat;

		/// <summary>
		/// A bitwise combination of <c>AudioObjectType</c> values indicating the set of static spatial audio channels that will be allowed
		/// by the activated stream.
		/// </summary>
		public AudioObjectType StaticObjectTypeMask;

		/// <summary>
		/// The minimum number of concurrent dynamic objects. If this number of dynamic audio objects can't be activated simultaneously,
		/// ISpatialAudioClient::ActivateSpatialAudioStream will fail with this error <c>SPTLAUDCLNT_E_NO_MORE_OBJECTS</c>.
		/// </summary>
		public uint MinDynamicObjectCount;

		/// <summary>The maximum number of concurrent dynamic objects that can be activated with ISpatialAudioObjectRenderStream.</summary>
		public uint MaxDynamicObjectCount;

		/// <summary>The category of the audio stream and its spatial audio objects.</summary>
		public AUDIO_STREAM_CATEGORY Category;

		/// <summary>
		/// The event that will signal the client to provide more audio data. This handle will be duplicated internally before it is used.
		/// </summary>
		public HEVENT EventHandle;

		/// <summary>The identifier of the metadata format for the currently active spatial rendering engine.</summary>
		public Guid MetadataFormatId;

		/// <summary>The maximum number of metadata items per frame.</summary>
		public ushort MaxMetadataItemCount;

		/// <summary>Additional activation parameters.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ISpatialAudioObjectRenderStreamNotify MetadataActivationParams;

		/// <summary>
		/// The object that provides notifications for spatial audio clients to respond to changes in the state of an
		/// ISpatialAudioObjectRenderStream. This object is used to notify clients that the number of dynamic spatial audio objects that can
		/// be activated concurrently is about to change.
		/// </summary>
		public IntPtr NotifyObject;
	}

	/// <summary>
	/// Represents activation parameters for a spatial audio render stream for metadata, extending
	/// SpatialAudioObjectRenderStreamForMetadataActivationParams (spatialaudiometadata.h) with the ability to specify stream options.
	/// </summary>
	/// <remarks>The following example shows how to activate a metadata stream with stream options.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/spatialaudiometadata/ns-spatialaudiometadata-spatialaudioobjectrenderstreamformetadataactivationparams2
	// typedef struct SpatialAudioObjectRenderStreamForMetadataActivationParams2 { const WAVEFORMATEX *ObjectFormat; AudioObjectType
	// StaticObjectTypeMask; UINT32 MinDynamicObjectCount; UINT32 MaxDynamicObjectCount; AUDIO_STREAM_CATEGORY Category; HANDLE EventHandle;
	// GUID MetadataFormatId; UINT32 MaxMetadataItemCount; const PROPVARIANT *MetadataActivationParams; ISpatialAudioObjectRenderStreamNotify
	// *NotifyObject; SPATIAL_AUDIO_STREAM_OPTIONS Options; } SpatialAudioObjectRenderStreamForMetadataActivationParams2;
	[PInvokeData("spatialaudiometadata.h", MSDNShortId = "NS:spatialaudiometadata.SpatialAudioObjectRenderStreamForMetadataActivationParams2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioObjectRenderStreamForMetadataActivationParams2
	{
		/// <summary>
		/// Format descriptor for a single spatial audio object. All objects used by the stream must have the same format and the format must
		/// be of type WAVEFORMATEX or WAVEFORMATEXTENSIBLE.
		/// </summary>
		public IntPtr /*WAVEFORMATEX*/ ObjectFormat;

		/// <summary>
		/// A bitwise combination of <c>AudioObjectType</c> values indicating the set of static spatial audio channels that will be allowed
		/// by the activated stream.
		/// </summary>
		public AudioObjectType StaticObjectTypeMask;

		/// <summary>
		/// The minimum number of concurrent dynamic objects. If this number of dynamic audio objects can't be activated simultaneously,
		/// ISpatialAudioClient::ActivateSpatialAudioStream will fail with this error <c>SPTLAUDCLNT_E_NO_MORE_OBJECTS</c>.
		/// </summary>
		public uint MinDynamicObjectCount;

		/// <summary>The maximum number of concurrent dynamic objects that can be activated with ISpatialAudioObjectRenderStream.</summary>
		public uint MaxDynamicObjectCount;

		/// <summary>The category of the audio stream and its spatial audio objects.</summary>
		public AUDIO_STREAM_CATEGORY Category;

		/// <summary>
		/// The event that will signal the client to provide more audio data. This handle will be duplicated internally before it is used.
		/// </summary>
		public HEVENT EventHandle;

		/// <summary>The identifier of the metadata format for the currently active spatial rendering engine.</summary>
		public Guid MetadataFormatId;

		/// <summary>The maximum number of metadata items per frame.</summary>
		public uint MaxMetadataItemCount;

		/// <summary>Additional activation parameters.</summary>
		public IntPtr /*PROPVARIANT*/ MetadataActivationParams;

		/// <summary>
		/// The object that provides notifications for spatial audio clients to respond to changes in the state of an
		/// ISpatialAudioObjectRenderStream. This object is used to notify clients that the number of dynamic spatial audio objects that can
		/// be activated concurrently is about to change.
		/// </summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ISpatialAudioObjectRenderStreamNotify NotifyObject;

		/// <summary>A member of the SPATIAL_AUDIO_STREAM_OPTIONS emumeration, specifying options for the activated audio stream.</summary>
		public SPATIAL_AUDIO_STREAM_OPTIONS Options;
	}
}