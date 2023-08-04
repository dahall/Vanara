using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions;

namespace Vanara.PInvoke;

/// <summary>Items from the CimFs.dll</summary>
public static partial class CimFs
{
	private const string Lib_CimFs = "cimfs.dll";

	/// <summary>Flags that can be used to modify the behavior of CimMountImage.</summary>
	[PInvokeData("cimfs.h", MSDNShortId = "NS:cimfs._CIM_MOUNT_IMAGE_FLAGS")]
	[Flags]
	public enum CIM_MOUNT_IMAGE_FLAGS
	{
		/// <summary>When no flags are specified the mounted image will contain the entire contents of the image.</summary>
		CIM_MOUNT_IMAGE_NONE = 0x00000000,

		/// <summary>This flag is ignored.</summary>
		CIM_MOUNT_CHILD_ONLY = 0x00000001
	}

	/// <summary>Frees resources associated with the image handle.</summary>
	/// <param name="cimImageHandle">
	/// <para>Type: <c>CIMFS_IMAGE_HANDLE</c></para>
	/// <para>An opaque handle that represents a writer for the image. This handle is created using CimCreateImage.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// If the image handle is closed before it is committed, any modifications performed on the image using the image handle are
	/// discarded. If a stream handle exists for the image, the image resources will not be freed until the stream handle is closed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimcloseimage void CimCloseImage( CIMFS_IMAGE_HANDLE
	// cimImageHandle );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimCloseImage")]
	public static extern void CimCloseImage(CIMFS_IMAGE_HANDLE cimImageHandle);

	/// <summary>Frees resources associated with the stream handle.</summary>
	/// <param name="cimStreamHandle">
	/// <para>Type: <c>CIMFS_STREAM_HANDLE</c></para>
	/// <para>An opaque handle that represents a writer for the stream created with CimCreateFile or CimCreateAlternateStream.</para>
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimclosestream void CimCloseStream( CIMFS_STREAM_HANDLE
	// cimStreamHandle );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimCloseStream")]
	public static extern void CimCloseStream(CIMFS_STREAM_HANDLE cimStreamHandle);

	/// <summary>Commits the image represented by the image handle.</summary>
	/// <param name="cimImageHandle">
	/// Type: <c>CIMFS_IMAGE_HANDLE</c> An opaque handle that represents a writer for the image. This handle is created using CimCreateImage.
	/// </param>
	/// <returns>
	/// <c>HRESULT</c> E_INVALIDARG – The image handle is invalid HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) – The image handle is
	/// still in use by another stream handle or the parent image may be mounted. An image cannot be committed while an open stream
	/// handle exists and cannot be overwritten when mounted.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Once the image is committed no additional operations can be performed on the image using the image handle. The handle must still
	/// be closed to free its associated resources.
	/// </para>
	/// <para>
	/// The name of the image committed is determined by the parameters to CimCreateImage. Note, it is an error to commit an image while
	/// an open stream handle exists for the image.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimcommitimage HRESULT CimCommitImage( CIMFS_IMAGE_HANDLE
	// cimImageHandle );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimCommitImage")]
	public static extern HRESULT CimCommitImage(CIMFS_IMAGE_HANDLE cimImageHandle);

	/// <summary>
	/// Adds an alternate stream with the specified size at a path relative to the image represented by the image handle. Provides a
	/// handle to the stream which can be used to write data to the stream.
	/// </summary>
	/// <param name="cimImageHandle">
	/// Type: <c>CIMFS_IMAGE_HANDLE</c> An opaque handle that represents a writer for the image. This handle is created using
	/// CimCreateImage. Only one stream handle can be opened for a given image at a given time. Close the stream handle before opening
	/// another stream.
	/// </param>
	/// <param name="imageRelativePath">
	/// Type: <c>PCWSTR</c> A path relative to the image root where the new stream will be created. The path must refer to an existing
	/// file or directory in the image and the stream name must be separated by a ‘:’ character.
	/// </param>
	/// <param name="streamSize">
	/// Type: <c>UINT</c> The size of the stream in bytes. The stream may be written only up to this size. Once the stream is created
	/// its size cannot be extended. To extend the stream it must be re-created. The stream will be sparsely allocated in the image such
	/// that ranges that are never written contains zeros when read.
	/// </param>
	/// <param name="cimStreamHandle">
	/// Type: <c>CIMFS_STREAM_HANDLE*</c> An opaque handle that represents a writer for the stream. This handle may be passed in
	/// subsequent routines to write the stream.
	/// </param>
	/// <returns>
	/// Type: <c>HRESULT</c> E_INVALIDARG – The image handle is invalid, the relative path is not a valid relative path for an alternate
	/// stream. The stream name must have the format imageRelativeFilePath:StreamName. HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND) – parent
	/// file or directory for the path specified does not exist in the image. HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) – The image
	/// handle is in use by another stream handle. Only one stream handle may exist per image handle.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimcreatealternatestream HRESULT CimCreateAlternateStream(
	// CIMFS_IMAGE_HANDLE cimImageHandle, PCWSTR imageRelativePath, UINT64 streamSize, CIMFS_STREAM_HANDLE *cimStreamHandle );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimCreateAlternateStream")]
	public static extern HRESULT CimCreateAlternateStream(CIMFS_IMAGE_HANDLE cimImageHandle, [MarshalAs(UnmanagedType.LPWStr)] string imageRelativePath,
		ulong streamSize, out SafeCIMFS_STREAM_HANDLE cimStreamHandle);

	/// <summary>
	/// Adds a new file or directory with the specified metadata at a path relative to the image represented by the image handle.
	/// Returns a stream handle to the primary stream. The stream handle can be used to write data to a file. If the path already exists
	/// in the image it is overwritten. Only one stream handle can be opened for a given image at a given time. Close any existing
	/// stream handle before creating another stream.
	/// </summary>
	/// <param name="cimImageHandle">
	/// Type: <c>CIMFS_IMAGE_HANDLE</c> An opaque handle that represents a writer for the image. This handle is created using CimCreateImage.
	/// </param>
	/// <param name="imageRelativePath">
	/// Type: <c>PCWSTR</c> A path relative to the image root where the new file or directory will be created. A leading backslash in
	///       the path is allowed. If the path refers to an existing file or directory in the image, the existing item will be overwritten.
	/// </param>
	/// <param name="fileMetadata">
	/// Type: <c>CIMFS_FILE_METADATA*</c> Pointer to a structure that contains the metadata for the new file or directory. For files, a
	///       size is provided in the metadata. The file may be written up to this size. Once the file is created its size cannot be
	///       extended. To extend the file it must be re-created. Ranges in the file that are never written will be read as zero.
	/// </param>
	/// <param name="cimStreamHandle">
	/// Type: <c>CIMFS_STREAM_HANDLE*</c> Receives an opaque handle that represents a writer for the stream. This handle may be passed
	///       in subsequent routines to write the stream.
	/// </param>
	/// <returns>
	/// <c>HRESULT</c> E_INVALIDARG – The image handle is invalid, the relative path is not a valid relative path or the fileMetadata
	/// fields are malformed. HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) – The image handle is in use by another stream handle. Only
	/// one stream handle may exist per image handle.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimcreatefile HRESULT CimCreateFile( CIMFS_IMAGE_HANDLE
	// cimImageHandle, PCWSTR imageRelativePath, const CIMFS_FILE_METADATA *fileMetadata, CIMFS_STREAM_HANDLE *cimStreamHandle );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimCreateFile")]
	public static extern HRESULT CimCreateFile(CIMFS_IMAGE_HANDLE cimImageHandle, [MarshalAs(UnmanagedType.LPWStr)] string imageRelativePath,
		in CIMFS_FILE_METADATA fileMetadata, out SafeCIMFS_STREAM_HANDLE cimStreamHandle);

	/// <summary>Adds a hard link to an existing path relative to the image represented by the image handle.</summary>
	/// <param name="cimImageHandle">
	/// Type: <c>CIMFS_IMAGE_HANDLE</c> An opaque handle that represents a writer for the image. This handle is created using CimCreateImage.
	/// </param>
	/// <param name="imageRelativePath">
	/// Type: <c>PCWSTR</c> A path relative to the image root where the new hard link will be created. If the path refers to an existing
	///       file, that file will be replaced with a link to the file specified.
	/// </param>
	/// <param name="existingImageRelativePath">
	/// Type: <c>PCWSTR</c> An existing path relative to the image root that will be hard linked. The path must refer to an existing
	///       file in the image. It is an error to pass a path to a directory or alternate stream.
	/// </param>
	/// <returns>
	/// <c>HRESULT</c> E_INVALIDARG – The image handle is invalid, the imageRelativePath or existingImageRelative path is not a valid
	/// relative path for file. HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND) – existingImageRelativePath does not exist in the image.
	/// HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) – The image handle is in use by another stream handle. Only one stream handle may
	/// exist per image handle. E_ACCESSDENIED – The existingImageRelativePath is a directory.
	/// </returns>
	/// <remarks>
	/// Internally CimCreateHardLink opens and closes a stream handle and only one stream handle can be opened for a given image at a
	/// given time. It is an error to call CimCreateHardLink while a stream handle is opened on the image. Close any open stream handle
	/// before adding a hard link.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimcreatehardlink HRESULT CimCreateHardLink( CIMFS_IMAGE_HANDLE
	// cimImageHandle, PCWSTR imageRelativePath, PCWSTR existingImageRelativePath );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimCreateHardLink")]
	public static extern HRESULT CimCreateHardLink(CIMFS_IMAGE_HANDLE cimImageHandle, [MarshalAs(UnmanagedType.LPWStr)] string imageRelativePath,
		[MarshalAs(UnmanagedType.LPWStr)] string existingImageRelativePath);

	/// <summary>
	/// Creates a handle representing a new image at the location specified, optionally based on an existing image at that location.
	/// </summary>
	/// <param name="imageContainingPath">
	/// Type: <c>PCWSTR</c> The directory that will contain the image created. The caller must have FILE_ADD_FILE and
	///       FILE_LIST_DIRECTORY access rights. The directory will be opened without sharing write access so image creation within a
	///       given image directory must be serialized by the caller.
	/// </param>
	/// <param name="existingImageName">
	/// Type: <c>PCWSTR</c> Optionally provides the name of an existing image within the same imageContainingPath that will form the
	///       base of the new image. If provided, the existing image can be extended or forked when this image is later committed. This
	///       parameter must be NULL and the newImageName parameter must be provided to create an image from scratch.
	/// </param>
	/// <param name="newImageName">
	/// Type: <c>PCWSTR</c> Optionally provides the name of a new image to be created within the imageContainingPath. If this parameter
	///       is not provided the existingImageName parameter must be provided and the new image will overwrite the existing image. When
	///       both existingImageName and newImageName are provided the image will be overwritten if they are the same name or will be
	///       forked if they are different names. When an image is forked the existing image is preserved such that both the existing
	///       and the new image can be mounted independently.
	/// </param>
	/// <param name="cimImageHandle">
	/// Receives an opaque handle that represents a writer for the image. This handle may be passed in subsequent routines to modify the image.
	/// </param>
	/// <returns>
	/// <c>HRESULT</c> E_ACCESSDENIED - the caller does not have permissions to the specified image containing path. E_INVALIDARG –The
	/// caller failed to specify existingImageName and newImageName. HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND) – the image containing
	/// path does not exist. HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) - existingImageName is specified and an image by that name is not
	/// found in the containing path. HRESULT_FROM_WIN32(ERROR_FILE_EXISTS) – the newImageName differs from the existingImageName and
	/// the newImageName already exists at the path specified. HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) – A sharing violation
	/// occurred on the image containing path. Only one image handle may be created per image containing path.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimcreateimage HRESULT CimCreateImage( PCWSTR
	// imageContainingPath, PCWSTR existingImageName, PCWSTR newImageName, CIMFS_IMAGE_HANDLE *cimImageHandle );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimCreateImage")]
	public static extern HRESULT CimCreateImage([MarshalAs(UnmanagedType.LPWStr)] string imageContainingPath,
		[MarshalAs(UnmanagedType.LPWStr), Optional] string? existingImageName, [MarshalAs(UnmanagedType.LPWStr), Optional] string? newImageName,
		out SafeCIMFS_IMAGE_HANDLE cimImageHandle);

	/// <summary>Removes the file, stream, directory or hardlink at a path relative to the image represented by the image handle.</summary>
	/// <param name="cimImageHandle">
	/// Type: <c>CIMFS_IMAGE_HANDLE</c> An opaque handle that represents a writer for the image. This handle is created using CimCreateImage.
	/// </param>
	/// <param name="imageRelativePath">
	/// Type: <c>PCWSTR</c> A path relative to the image root for the file, directory, alternate stream or hardlink to be deleted. If
	///       the path refers to an existing directory, the directory and its entire contents are deleted.
	/// </param>
	/// <returns>
	/// <c>HRESULT</c> E_INVALIDARG – The image handle is invalid, the relative path is not a valid relative path for file.
	/// HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND) – The path specified does not exist in the image.
	/// HRESULT_FROM_WIN32(ERROR_SHARING_VIOLATION) – The image handle is in use by another stream handle. Only one stream handle may
	/// exist per image handle.
	/// </returns>
	/// <remarks>
	/// Internally CimDeletePath opens and closes a stream handle and only one stream handle can be opened for a given image at a given
	/// time. It is an error to call CimDeletePath while a stream handle is opened on the image. Close any open stream handle before
	/// deleting a path.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimdeletepath HRESULT CimDeletePath( CIMFS_IMAGE_HANDLE
	// cimImageHandle, PCWSTR imageRelativePath );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimDeletePath")]
	public static extern HRESULT CimDeletePath(CIMFS_IMAGE_HANDLE cimImageHandle, [MarshalAs(UnmanagedType.LPWStr)] string imageRelativePath);

	/// <summary>Dismounts an image mounted with volumeId as the volume GUID.</summary>
	/// <param name="volumeId">Type: <c>GUID*</c> Provides the volume GUID of the currently mounted image.</param>
	/// <returns>
	/// <c>HRESULT</c> HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) – The volume GUID specified does not refer to a volume for a mounted CIM image.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimdismountimage HRESULT CimDismountImage( const GUID *volumeId );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimDismountImage")]
	public static extern HRESULT CimDismountImage(in Guid volumeId);

	/// <summary>Mounts the named image from the location specified by cimPath as a volume with the volume GUID specified by volumeId.</summary>
	/// <param name="imageContainingPath">
	/// Type: <c>PCWSTR</c> The directory that will contain the image created. The caller must have FILE_ADD_FILE and
	///       FILE_LIST_DIRECTORY access rights.
	/// </param>
	/// <param name="imageName">
	/// Type: <c>PCWSTR</c> Provides the name of an existing image within the same imageContainingPath that will be mounted.
	/// </param>
	/// <param name="mountImageFlags">Type: <c>CIM_MOUNT_IMAGE_FLAGS</c></param>
	/// <param name="volumeId">Type: <c>GUID*</c> Provides a GUID to be used as the volume GUID of the mounted volume.</param>
	/// <returns>
	/// <c>HRESULT</c> E_INVALIDARG – The caller specified an invalid flag. HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND) – the image path is
	/// not found. HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) – imageName is not found at the path specified. E_ACCESSEDDENIED – The
	/// caller does not have access the image or does not have access to mount a volume. HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS) – A
	/// volume is already mounted with the volume GUID specified.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The mounted volume can be accessed at its volume GUID path as defined by the system. This path is in the form \?\Volume{GUID}.
	/// Mounting the volume allows the image created to be verified using the Windows file system APIs such as CreateFile,
	/// FindFirstFile/FindNextFile, GetFileAttributesEx and others.
	/// </para>
	/// <para>The image cannot be overwritten while it is mounted.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimmountimage HRESULT CimMountImage( PCWSTR
	// imageContainingPath, PCWSTR imageName, CIM_MOUNT_IMAGE_FLAGS mountImageFlags, const GUID *volumeId );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimMountImage")]
	public static extern HRESULT CimMountImage([MarshalAs(UnmanagedType.LPWStr)] string imageContainingPath,
		[MarshalAs(UnmanagedType.LPWStr)] string imageName, CIM_MOUNT_IMAGE_FLAGS mountImageFlags, in Guid volumeId);

	/// <summary>Writes data from the specified buffer to the stream represented by the stream handle.</summary>
	/// <param name="cimStreamHandle">
	/// Type: <c>CIMFS_STREAM_HANDLE</c> An opaque handle that represents a writer for the stream created with CimCreateFile or CimCreateAlternateStream.
	/// </param>
	/// <param name="buffer">TYPE: <c>void*</c> A caller allocated buffer that contains the data to be written</param>
	/// <param name="bufferSize">
	/// Type <c>UINT32</c> The size of the caller allocated buffer. The contents of the buffer will be written to the stream up to but
	/// not exceeding the stream size provided when the stream was created.
	/// </param>
	/// <returns>
	/// <c>HRESULT</c> E_INVALIDARG – The stream handle is invalid or the handle provided refers to a directory rather than a file or
	/// alternate stream. E_POINTER – The buffer pointer is NULL HRESULT_FROM_WIN32(ERROR_HANDLE_EOF) – The write extends past the file
	/// size specified when the stream was created. The data written was truncated at the end of file.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimwritestream HRESULT CimWriteStream( CIMFS_STREAM_HANDLE
	// cimStreamHandle, const void *buffer, UINT32 bufferSize );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimWriteStream")]
	public static extern HRESULT CimWriteStream(CIMFS_STREAM_HANDLE cimStreamHandle, IntPtr buffer, uint bufferSize);

	/// <summary>Writes data from the specified buffer to the stream represented by the stream handle.</summary>
	/// <param name="cimStreamHandle">
	/// Type: <c>CIMFS_STREAM_HANDLE</c> An opaque handle that represents a writer for the stream created with CimCreateFile or CimCreateAlternateStream.
	/// </param>
	/// <param name="buffer">TYPE: <c>void*</c> A caller allocated buffer that contains the data to be written</param>
	/// <param name="bufferSize">
	/// Type <c>UINT32</c> The size of the caller allocated buffer. The contents of the buffer will be written to the stream up to but
	/// not exceeding the stream size provided when the stream was created.
	/// </param>
	/// <returns>
	/// <c>HRESULT</c> E_INVALIDARG – The stream handle is invalid or the handle provided refers to a directory rather than a file or
	/// alternate stream. E_POINTER – The buffer pointer is NULL HRESULT_FROM_WIN32(ERROR_HANDLE_EOF) – The write extends past the file
	/// size specified when the stream was created. The data written was truncated at the end of file.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/nf-cimfs-cimwritestream HRESULT CimWriteStream( CIMFS_STREAM_HANDLE
	// cimStreamHandle, const void *buffer, UINT32 bufferSize );
	[DllImport(Lib_CimFs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cimfs.h", MSDNShortId = "NF:cimfs.CimWriteStream")]
	public static extern HRESULT CimWriteStream(CIMFS_STREAM_HANDLE cimStreamHandle, byte[] buffer, uint bufferSize);

	/// <summary>Structure that specifies file metadata for the file to be added by CimCreateFile.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cimfs/ns-cimfs-cimfs_file_metadata typedef struct _CIMFS_FILE_METADATA {
	// UINT32 Attributes; INT64 FileSize; LARGE_INTEGER CreationTime; LARGE_INTEGER LastWriteTime; LARGE_INTEGER ChangeTime;
	// LARGE_INTEGER LastAccessTime; const void *SecurityDescriptorBuffer; UINT32 SecurityDescriptorSize; const void *ReparseDataBuffer;
	// UINT32 ReparseDataSize; const void *EaBuffer; UINT32 EaBufferSize; } CIMFS_FILE_METADATA;
	[PInvokeData("cimfs.h", MSDNShortId = "NS:cimfs._CIMFS_FILE_METADATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CIMFS_FILE_METADATA
	{
		/// <summary>File attributes</summary>
		public FileFlagsAndAttributes Attributes;

		/// <summary>Size of the file. The file can be written up to this size by CimWriteFile.</summary>
		public long FileSize;

		/// <summary>Creation time</summary>
		public FILETIME CreationTime;

		/// <summary>Last write time</summary>
		public FILETIME LastWriteTime;

		/// <summary>Change time</summary>
		public FILETIME ChangeTime;

		/// <summary>Last access time</summary>
		public FILETIME LastAccessTime;

		/// <summary>Buffer containing the file security descriptor</summary>
		public IntPtr SecurityDescriptorBuffer;

		/// <summary>Size of the security descriptor buffer in bytes</summary>
		public uint SecurityDescriptorSize;

		/// <summary>Buffer containing the file reparse data</summary>
		public IntPtr ReparseDataBuffer;

		/// <summary>Size of the ReparseDataBuffer in bytes</summary>
		public uint ReparseDataSize;

		/// <summary>Buffer containing a FILE_FULL_EA_INFORMATION structure for the file extended attributes</summary>
		public IntPtr EaBuffer;

		/// <summary>Size of the EaBuffer in bytes</summary>
		public uint EaBufferSize;
	}

	/// <summary>Provides a handle to a CIMFS image.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct CIMFS_IMAGE_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="CIMFS_IMAGE_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public CIMFS_IMAGE_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="CIMFS_IMAGE_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static CIMFS_IMAGE_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="CIMFS_IMAGE_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(CIMFS_IMAGE_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="CIMFS_IMAGE_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CIMFS_IMAGE_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(CIMFS_IMAGE_HANDLE h1, CIMFS_IMAGE_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(CIMFS_IMAGE_HANDLE h1, CIMFS_IMAGE_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is CIMFS_IMAGE_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CIMFS stream handle.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct CIMFS_STREAM_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="CIMFS_STREAM_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public CIMFS_STREAM_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="CIMFS_STREAM_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static CIMFS_STREAM_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="CIMFS_STREAM_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(CIMFS_STREAM_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="CIMFS_STREAM_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CIMFS_STREAM_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(CIMFS_STREAM_HANDLE h1, CIMFS_STREAM_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(CIMFS_STREAM_HANDLE h1, CIMFS_STREAM_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is CIMFS_STREAM_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="CIMFS_IMAGE_HANDLE"/> that is disposed using <see cref="CimCloseImage"/>.</summary>
	public class SafeCIMFS_IMAGE_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeCIMFS_IMAGE_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeCIMFS_IMAGE_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeCIMFS_IMAGE_HANDLE"/> class.</summary>
		private SafeCIMFS_IMAGE_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeCIMFS_IMAGE_HANDLE"/> to <see cref="CIMFS_IMAGE_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CIMFS_IMAGE_HANDLE(SafeCIMFS_IMAGE_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { CimCloseImage(handle); return true; }
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="CIMFS_STREAM_HANDLE"/> that is disposed using <see cref="CimCloseStream"/>.</summary>
	public class SafeCIMFS_STREAM_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeCIMFS_STREAM_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeCIMFS_STREAM_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeCIMFS_STREAM_HANDLE"/> class.</summary>
		private SafeCIMFS_STREAM_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeCIMFS_STREAM_HANDLE"/> to <see cref="CIMFS_STREAM_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CIMFS_STREAM_HANDLE(SafeCIMFS_STREAM_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { CimCloseStream(handle); return true; }
	}
}