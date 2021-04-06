using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.CustomMarshalers;
using Vanara.Collections;

namespace Vanara.PInvoke
{
	/// <summary>Interfaces and constants for IMAPI v1 and v2.</summary>
	public static partial class IMAPI
	{
		/// <summary>Defines values for media types that the boot image is intended to emulate.</summary>
		/// <remarks>
		/// <para>
		/// Other values not defined here may exist. Consumers of this enumeration should not presume this list to be the only set of valid values.
		/// </para>
		/// <para>For complete details of these emulation types, see the "El Torito" Bootable CD-ROM format specification at http://www.phoenix.com/docs/specscdrom.pdf.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/ne-imapi2fs-emulationtype typedef enum EmulationType { EmulationNone,
		// Emulation12MFloppy, Emulation144MFloppy, Emulation288MFloppy, EmulationHardDisk } ;
		[PInvokeData("imapi2fs.h", MSDNShortId = "NE:imapi2fs.EmulationType")]
		public enum EmulationType
		{
			/// <summary>
			/// No emulation. The BIOS will not emulate any device type or special sector size for the CD during boot from the CD.
			/// </summary>
			EmulationNone,

			/// <summary>Emulates a 1.2 MB floppy disk.</summary>
			Emulation12MFloppy,

			/// <summary>Emulates a 1.44 MB floppy disk.</summary>
			Emulation144MFloppy,

			/// <summary>Emulates a 2.88 MB floppy disk.</summary>
			Emulation288MFloppy,

			/// <summary>Emulates a hard disk.</summary>
			EmulationHardDisk,
		}

		/// <summary>Defines values for recognized file systems.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/ne-imapi2fs-fsifilesystems typedef enum FsiFileSystems {
		// FsiFileSystemNone, FsiFileSystemISO9660, FsiFileSystemJoliet, FsiFileSystemUDF, FsiFileSystemUnknown } ;
		[PInvokeData("imapi2fs.h", MSDNShortId = "NE:imapi2fs.FsiFileSystems")]
		[Flags]
		public enum FsiFileSystems
		{
			/// <summary>The disc does not contain a recognized file system.</summary>
			FsiFileSystemNone = 0x000000000,

			/// <summary>Standard CD file system.</summary>
			FsiFileSystemISO9660 = 0x000000001,

			/// <summary>Joliet file system.</summary>
			FsiFileSystemJoliet = 0x000000002,

			/// <summary>UDF file system.</summary>
			FsiFileSystemUDF = 0x000000004,

			/// <summary>The disc appears to have a file system, but the layout does not match any of the recognized types.</summary>
			FsiFileSystemUnknown = 0x040000000,
		}

		/// <summary>Defines values for the file system item that was found using the IFileSystemImage::Exists method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/ne-imapi2fs-fsiitemtype typedef enum FsiItemType { FsiItemNotFound,
		// FsiItemDirectory, FsiItemFile } ;
		[PInvokeData("imapi2fs.h", MSDNShortId = "NE:imapi2fs.FsiItemType")]
		public enum FsiItemType
		{
			/// <summary>The specified item was not found.</summary>
			FsiItemNotFound,

			/// <summary>The specified item is a directory.</summary>
			FsiItemDirectory,

			/// <summary>The specified item is a file.</summary>
			FsiItemFile,
		}

		/// <summary>Defines values for the operating system architecture that the boot image supports</summary>
		/// <remarks>
		/// Other values not defined here may exist. Consumers of this enumeration should not presume this list to be the only set of valid values.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/ne-imapi2fs-platformid typedef enum PlatformId { PlatformX86,
		// PlatformPowerPC, PlatformMac, PlatformEFI } ;
		[PInvokeData("imapi2fs.h", MSDNShortId = "NE:imapi2fs.PlatformId")]
		public enum PlatformId
		{
			/// <summary>Intel Pentium™ series of chip sets. This entry implies a Windows operating system.</summary>
			PlatformX86,

			/// <summary>Apple PowerPC family.</summary>
			PlatformPowerPC,

			/// <summary>Apple Macintosh family.</summary>
			PlatformMac,

			/// <summary>EFI Family.</summary>
			PlatformEFI = 0xef,
		}

		/// <summary>Implement this interface to receive notifications of the current write operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-dfilesystemimageevents
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.DFileSystemImageEvents")]
		[ComImport, Guid("2C941FDF-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
		public interface DFileSystemImageEvents
		{
			/// <summary>
			/// Implement this method to receive progress notification of the current write operation. The notifications are sent when
			/// copying the content of a file or while adding directories or files to the file system image.
			/// </summary>
			/// <param name="object">
			/// <para>An IFileSystemImage interface of the file system image that is being written.</para>
			/// <para>This parameter is a <c>CFileSystemImage</c> object in a script.</para>
			/// </param>
			/// <param name="currentFile">String that contains the full path of the file being written.</param>
			/// <param name="copiedSectors">Number of sectors copied.</param>
			/// <param name="totalSectors">Total number of sectors in the file.</param>
			/// <remarks>
			/// <para>Notifications are sent in response to calling one of the following methods:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>IFsiDirectoryItem::Add</term>
			/// </item>
			/// <item>
			/// <term>IFsiDirectoryItem::AddFile</term>
			/// </item>
			/// <item>
			/// <term>IFsiDirectoryItem::AddTree</term>
			/// </item>
			/// </list>
			/// <para>
			/// Notifications can also be sent when calling one of the following methods to import a UDF file system that was created using
			/// immediate allocation (immediate allocation means that the file data is contained within the file descriptor instead of
			/// having allocation descriptors in the file descriptor that point to sectors of data):
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>IFileSystemImage::ImportFileSystem</term>
			/// </item>
			/// <item>
			/// <term>IFileSystemImage::ImportSpecificFileSystem</term>
			/// </item>
			/// </list>
			/// <para>Notification is sent:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Once before adding the first sector of a file (copiedSectors is 0)</term>
			/// </item>
			/// <item>
			/// <term>For every megabyte that is written</term>
			/// </item>
			/// <item>
			/// <term>Once after the final write if the file did not end on a megabyte boundary</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-dfilesystemimageevents-update HRESULT Update(
			// IDispatch *object, BSTR currentFile, LONG copiedSectors, LONG totalSectors );
			[DispId(0x100)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Update([In, MarshalAs(UnmanagedType.IDispatch)] IFileSystemImage @object,
						[In, MarshalAs(UnmanagedType.BStr)] string currentFile,
						long copiedSectors,
						long totalSectors);
		}

		/// <summary>Receives notifications of the current write operation.</summary>
		[ClassInterface(ClassInterfaceType.None)]
		public class DFileSystemImageEventsSink : DFileSystemImageEvents
		{
			/// <summary>Initializes a new instance of the <see cref="DFileSystemImageEventsSink"/> class.</summary>
			/// <param name="onUpdate">The delegate to assign to the <see cref="Update"/> event.</param>
			public DFileSystemImageEventsSink(Action<IFileSystemImage, string, long, long> onUpdate)
			{
				if (onUpdate is not null) Update += onUpdate;
			}

			/// <summary>
			/// Occurs on progress notifications from the current write operation. The notifications are sent when
			/// copying the content of a file or while adding directories or files to the file system image.
			/// </summary>
			/// <remarks>
			/// <para>Notifications are sent in response to calling one of the following methods:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>IFsiDirectoryItem::Add</term>
			/// </item>
			/// <item>
			/// <term>IFsiDirectoryItem::AddFile</term>
			/// </item>
			/// <item>
			/// <term>IFsiDirectoryItem::AddTree</term>
			/// </item>
			/// </list>
			/// <para>
			/// Notifications can also be sent when calling one of the following methods to import a UDF file system that was created using
			/// immediate allocation (immediate allocation means that the file data is contained within the file descriptor instead of
			/// having allocation descriptors in the file descriptor that point to sectors of data):
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>IFileSystemImage::ImportFileSystem</term>
			/// </item>
			/// <item>
			/// <term>IFileSystemImage::ImportSpecificFileSystem</term>
			/// </item>
			/// </list>
			/// <para>Notification is sent:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Once before adding the first sector of a file (copiedSectors is 0)</term>
			/// </item>
			/// <item>
			/// <term>For every megabyte that is written</term>
			/// </item>
			/// <item>
			/// <term>Once after the final write if the file did not end on a megabyte boundary</term>
			/// </item>
			/// </list>
			/// </remarks>
			public event Action<IFileSystemImage, string, long, long> Update;

			void DFileSystemImageEvents.Update(IFileSystemImage @object, string currentFile, long copiedSectors, long totalSectors) => Update?.Invoke(@object, currentFile, copiedSectors, totalSectors);
		}

		/// <summary>Use this interface to receives notifications regarding the current file system import operation.</summary>
		/// <remarks>This interface supports import notifications for ISO9660, Joliet and UDF file systems.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-dfilesystemimageimportevents
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.DFileSystemImageImportEvents")]
		[ComImport, Guid("D25C30F9-4087-4366-9E24-E55BE286424B"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
		public interface DFileSystemImageImportEvents
		{
			/// <summary>Receives import notification for every file and directory item imported from an optical medium.</summary>
			/// <param name="object">Pointer to an IFilesystemImage3 interface of a file system image object to which data is being imported.</param>
			/// <param name="fileSystem">
			/// Type of the file system currently being imported. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <param name="currentItem">A string containing the name of the file or directory being imported at the moment.</param>
			/// <param name="importedDirectoryItems">The number of directories imported so far.</param>
			/// <param name="totalDirectoryItems">The total number of directories to be imported from the optical medium.</param>
			/// <param name="importedFileItems">The number of files imported so far.</param>
			/// <param name="totalFileItems">The total number of files to be imported from the optical medium.</param>
			/// <remarks>
			/// <para>Notifications are sent in response to calling one of the following methods for importing a file system.</para>
			/// <list type="bullet">
			/// <item>
			/// <term>IFileSystemImage::ImportFileSystem</term>
			/// </item>
			/// <item>
			/// <term>IFileSystemImage::ImportSpecificFileSystem</term>
			/// </item>
			/// </list>
			/// <para>UpdateImport method receives import notifications from ISO9660, Joliet and UDF file systems. A notification is sent:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Once after every individual imported file.</term>
			/// </item>
			/// <item>
			/// <term>Once before every directory import begins.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The totalFileItems parameter of an <c>UpdateImport</c> event is always set to (-1) for ISO9660 and Joliet file systems,
			/// because of the difficulty quickly and accurately determining the total number of files in an ISO9660/Joliet file system
			/// prior to import.
			/// </para>
			/// <para>Import notifications are generated only for files and directories, and not for associated named streams.</para>
			/// <para>If the currentItem is a directory, it contains a back slash '' at the end.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-dfilesystemimageimportevents-updateimport HRESULT
			// UpdateImport( IDispatch *object, FsiFileSystems fileSystem, BSTR currentItem, LONG importedDirectoryItems, LONG
			// totalDirectoryItems, LONG importedFileItems, LONG totalFileItems );
			[DispId(0x101)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void UpdateImport([In, MarshalAs(UnmanagedType.IDispatch)] IFileSystemImage @object,
							  FsiFileSystems fileSystem,
							  [In, MarshalAs(UnmanagedType.BStr)] string currentItem,
							  long importedDirectoryItems,
							  long totalDirectoryItems,
							  long importedFileItems,
							  long totalFileItems);
		}

		/// <summary>Sink implementation for <see cref="DFileSystemImageImportEvents"/>.</summary>
		/// <seealso cref="Vanara.PInvoke.IMAPI.DFileSystemImageImportEvents"/>
		[ClassInterface(ClassInterfaceType.None)]
		public class DFileSystemImageImportEventsSink : DFileSystemImageImportEvents
		{
			/// <summary>Initializes a new instance of the <see cref="DFileSystemImageImportEventsSink"/> class.</summary>
			/// <param name="onUpdateImport">The delegate to call on import update.</param>
			public DFileSystemImageImportEventsSink(Action<IFileSystemImage, FsiFileSystems, string, long, long, long, long> onUpdateImport)
			{
				if (onUpdateImport is not null) UpdateImport += onUpdateImport;
			}

			/// <summary>Receives import notification for every file and directory item imported from an optical medium.</summary>
			/// <remarks>
			/// <para>Notifications are sent in response to calling one of the following methods for importing a file system.</para>
			/// <list type="bullet">
			/// <item>
			/// <term>IFileSystemImage::ImportFileSystem</term>
			/// </item>
			/// <item>
			/// <term>IFileSystemImage::ImportSpecificFileSystem</term>
			/// </item>
			/// </list>
			/// <para>UpdateImport method receives import notifications from ISO9660, Joliet and UDF file systems. A notification is sent:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Once after every individual imported file.</term>
			/// </item>
			/// <item>
			/// <term>Once before every directory import begins.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The totalFileItems parameter of an <c>UpdateImport</c> event is always set to (-1) for ISO9660 and Joliet file systems,
			/// because of the difficulty quickly and accurately determining the total number of files in an ISO9660/Joliet file system
			/// prior to import.
			/// </para>
			/// <para>Import notifications are generated only for files and directories, and not for associated named streams.</para>
			/// <para>If the currentItem is a directory, it contains a back slash '' at the end.</para>
			/// </remarks>
			public event Action<IFileSystemImage, FsiFileSystems, string, long, long, long, long> UpdateImport;

			void DFileSystemImageImportEvents.UpdateImport(IFileSystemImage @object, FsiFileSystems fileSystem, string currentItem, long importedDirectoryItems, long totalDirectoryItems, long importedFileItems, long totalFileItems) =>
				UpdateImport?.Invoke(@object, fileSystem, currentItem, importedDirectoryItems, totalDirectoryItems, importedFileItems, totalFileItems);
		}

		/// <summary>
		/// <para>
		/// Use this interface to specify the boot image to add to the optical disc. A boot image contains one or more sectors of code used
		/// to start the computer.
		/// </para>
		/// <para>
		/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(BootOptions) for the class
		/// identifier and __uuidof(IBootOptions) for the interface identifier.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>This interface supports the "El Torito" Bootable CD-ROM format specification.</para>
		/// <para>To add the boot image to a file system image, call the IFileSystemImage::put_BootImageOptions method.</para>
		/// <para>To get the boot image associated with a file system image, call the IFileSystemImage::get_BootImageOptions method.</para>
		/// <para>To create the <c>BootOptions</c> object in a script, use IMAPI2.BootOptions as the program identifier when calling <c>CreateObject</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ibootoptions
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IBootOptions")]
		[ComImport, Guid("2C941FD4-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(BootOptions))]
		public interface IBootOptions
		{
			/// <summary>Retrieves a pointer to the boot image data stream.</summary>
			/// <value>Pointer to the <c>IStream</c> interface associated with the boot image data stream.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ibootoptions-get_bootimage HRESULT get_BootImage(
			// IStream **pVal );
			[DispId(1)]
			IStream BootImage { get; }

			/// <summary>Sets an identifier that identifies the manufacturer or developer of the CD.</summary>
			/// <value>
			/// Identifier that identifies the manufacturer or developer of the CD. This is an ANSI string that is limited to 24 bytes. The
			/// string does not need to include a NULL character; however, you must set unused bytes to 0x00.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ibootoptions-put_manufacturer HRESULT
			// put_Manufacturer( BSTR newVal );
			[DispId(2)]
			string Manufacturer { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

			/// <summary>Sets the platform identifier that identifies the operating system architecture that the boot image supports.</summary>
			/// <value>
			/// Identifies the operating system architecture that the boot image supports. For possible values, see the PlatformId
			/// enumeration type. The default value is <c>PlatformX86</c> for Intel x86–based platforms.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ibootoptions-put_platformid HRESULT put_PlatformId(
			// PlatformId newVal );
			[DispId(3)]
			PlatformId PlatformId { get; set; }

			/// <summary>Sets the media type that the boot image is intended to emulate.</summary>
			/// <value>
			/// Media type that the boot image is intended to emulate. For possible values, see the EmulationType enumeration type. The
			/// default value is <c>EmulationNone</c>, which means the BIOS will not emulate any device type or special sector size for the
			/// CD during boot from the CD.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ibootoptions-put_emulation HRESULT put_Emulation(
			// EmulationType newVal );
			[DispId(4)]
			EmulationType Emulation { get; set; }

			/// <summary>Retrieves the size of the boot image.</summary>
			/// <value>Size, in bytes, of the boot image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ibootoptions-get_imagesize HRESULT get_ImageSize(
			// ULONG *pVal );
			[DispId(5)]
			uint ImageSize { get; }

			/// <summary>Sets the data stream that contains the boot image.</summary>
			/// <param name="newVal">An <c>IStream</c> interface of the data stream that contains the boot image.</param>
			/// <remarks>
			/// <para>
			/// If the size of the newly assigned boot image is either 1.2, 1.44. or 2.88 MB, this method will automatically adjust the
			/// EmulationType value to the respective "floppy" type value. It is, however, possible to override the default or previously
			/// assigned <c>EmulationType</c> value by calling the IBootOptions::put_Emulation method.
			/// </para>
			/// <para>
			/// The additional specification of the platform on which to use the boot image requires the call to the
			/// IBootOptions::put_PlatformId method.
			/// </para>
			/// <para>IMAPI does not include any boot images; developers must provide their own boot images.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ibootoptions-assignbootimage HRESULT AssignBootImage(
			// IStream *newVal );
			[DispId(20)]
			void AssignBootImage(IStream newVal);
		}

		/// <summary>
		/// <para>Use this interface to enumerate the child directory and file items for a FsiDirectoryItem object.</para>
		/// <para>To get this interface, call the IFsiDirectoryItem::get_EnumFsiItems method.</para>
		/// </summary>
		/// <remarks>This is a <c>EnumFsiItems</c> object in script.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ienumfsiitems
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IEnumFsiItems")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2C941FDA-975B-59BE-A960-9A2A262853A5"), CoClass(typeof(EnumFsiItems))]
		public interface IEnumFsiItems : ICOMEnum<IFsiItem>
		{
			/// <summary>Retrieves a specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">Number of items to retrieve.</param>
			/// <param name="rgelt">Array of IFsiItem interfaces. You must release each interface in rgelt when done.</param>
			/// <param name="pceltFetched">
			/// Number of elements returned in rgelt. You can set pceltFetched to <c>NULL</c> if celt is one. Otherwise, initialize the
			/// value of pceltFetched to 0 before calling this method.
			/// </param>
			/// <returns>
			/// <para>
			/// S_OK is returned when the number of requested elements (celt) are returned successfully or the number of returned items
			/// (pceltFetched) is less than the number of requested elements.
			/// </para>
			/// <para>
			/// Other success codes may be returned as a result of implementation. The following error codes are commonly returned on
			/// operation failure, but do not represent the only possible error values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>Pointer is not valid. Value: 0x80004003</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Failed to allocate the required memory. Value: 0x8007000E</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more arguments are not valid. Value: 0x80070057</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>If there are fewer than the requested number of elements left in the sequence, it retrieves the remaining elements.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumfsiitems-next HRESULT Next( ULONG celt, IFsiItem
			// **rgelt, ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next(uint celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IFsiItem[] rgelt, out uint pceltFetched);

			/// <summary>Skips a specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">Number of items to skip.</param>
			/// <returns>
			/// <para>
			/// S_OK is returned on success, but other success codes may be returned as a result of implementation. The following error
			/// codes are commonly returned on operation failure, but do not represent the only possible error values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>Skipped less than the number of requested elements.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// If there are fewer elements left in the sequence than the requested number of elements to skip, it skips past the last
			/// element in the sequence.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumfsiitems-skip HRESULT Skip( ULONG celt );
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumfsiitems-reset HRESULT Reset();
			void Reset();

			/// <summary>Creates another enumerator that contains the same enumeration state as the current one.</summary>
			/// <returns>
			/// Receives the interface pointer to the enumeration object. If the method is unsuccessful, the value of this output variable
			/// is undefined. You must release ppEnum when done.
			/// </returns>
			/// <remarks>
			/// Using this method, a client can record a particular point in the enumeration sequence, and then return to that point at a
			/// later time. The new enumerator supports the same interface as the original one.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumfsiitems-clone HRESULT Clone( IEnumFsiItems
			// **ppEnum );
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumFsiItems Clone();
		}

		/// <summary>
		/// <para>Use this interface to enumerate a collection of progress items.</para>
		/// <para>To get this interface, call the IProgressItems::get_EnumProgressItems method.</para>
		/// </summary>
		/// <remarks>This is a <c>EnumProgressItems</c> object in script.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ienumprogressitems
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IEnumProgressItems")]
		[ComImport, Guid("2C941FD6-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnumProgressItems))]
		public interface IEnumProgressItems : ICOMEnum<IProgressItem>
		{
			/// <summary>Retrieves a specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">Number of items to retrieve.</param>
			/// <param name="rgelt">Array of IProgressItem interfaces. You must release each interface in rgelt when done.</param>
			/// <param name="pceltFetched">
			/// Number of elements returned in rgelt. You can set pceltFetched to <c>NULL</c> if celt is one. Otherwise, initialize the
			/// value of pceltFetched to 0 before calling this method.
			/// </param>
			/// <returns>
			/// <para>
			/// S_OK is returned when the number of requested elements (celt) are returned successfully or the number of returned items
			/// (pceltFetched) is less than the number of requested elements.
			/// </para>
			/// <para>
			/// Other success codes may be returned as a result of implementation. The following error codes are commonly returned on
			/// operation failure, but do not represent the only possible error values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>Pointer is not valid. Value: 0x80004003</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Failed to allocate the required memory. Value: 0x8007000E</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more arguments are not valid. Value: 0x80070057</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>If there are fewer than the requested number of elements left in the sequence, it retrieves the remaining elements.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumprogressitems-next HRESULT Next( ULONG celt,
			// IProgressItem **rgelt, ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next(uint celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IProgressItem[] rgelt, out uint pceltFetched);

			/// <summary>Skips a specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">Number of items to skip.</param>
			/// <returns>
			/// <para>
			/// S_OK is returned on success, but other success codes may be returned as a result of implementation. The following error
			/// codes are commonly returned on operation failure, but do not represent the only possible error values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>Skipped less than the number of requested elements.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// If there are fewer elements left in the sequence than the requested number of elements to skip, it skips past the last
			/// element in the sequence.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumprogressitems-skip HRESULT Skip( ULONG celt );
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumprogressitems-reset HRESULT Reset();
			void Reset();

			/// <summary>Creates another enumerator that contains the same enumeration state as the current one.</summary>
			/// <returns>
			/// Receives the interface pointer to the enumeration object. If the method is unsuccessful, the value of this output variable
			/// is undefined. You must release ppEnum when done.
			/// </returns>
			/// <remarks>
			/// Using this method, a client can record a particular point in the enumeration sequence, and then return to that point at a
			/// later time. The new enumerator supports the same interface as the original one.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ienumprogressitems-clone HRESULT Clone(
			// IEnumProgressItems **ppEnum );
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumProgressItems Clone();
		}

		/// <summary>
		/// <para>Use this interface to build a file system image, set session parameter, and import or export an image.</para>
		/// <para>The file system directory hierarchy is built by adding directories and files to the root or child directories.</para>
		/// <para>
		/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftFileSystemImage) for the
		/// class identifier and __uuidof(IFileSystemImage) for the interface identifier.
		/// </para>
		/// </summary>
		/// <remarks>
		/// To create the <c>CFileSystemImage</c> object in a script, use IMAPI2.MsftFileSystemImage as the program identifier when calling <c>CreateObject</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifilesystemimage
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFileSystemImage")]
		[ComImport, Guid("2C941FE1-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftFileSystemImage))]
		public interface IFileSystemImage
		{
			/// <summary>Retrieves the root directory item.</summary>
			/// <value>An IFsiDirectoryItem interface of the root directory item.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_root HRESULT get_Root(
			// IFsiDirectoryItem **pVal );
			[DispId(0)]
			IFsiDirectoryItem Root { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Retrieves the starting block address for the recording session.</summary>
			/// <value>Starting block address for the recording session.</value>
			/// <remarks>
			/// <para>The session starting block can be set in the following ways:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Importing a file system automatically sets the session starting block.</term>
			/// </item>
			/// <item>
			/// <term>If the previous session is not imported, the client can call IFileSystemImage::put_SessionStartBlock to set this property.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_sessionstartblock HRESULT
			// get_SessionStartBlock( LONG *pVal );
			[DispId(1)]
			int SessionStartBlock { get; set; }

			/// <summary>Retrieves the maximum number of blocks available for the image.</summary>
			/// <value>Number of blocks to use in creating the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_freemediablocks HRESULT
			// get_FreeMediaBlocks( LONG *pVal );
			[DispId(2)]
			int FreeMediaBlocks { get; set; }

			/// <summary>Set maximum number of blocks available based on the capabilities of the recorder.</summary>
			/// <param name="discRecorder">
			/// An IDiscRecorder2 interface that identifies the recording device from which you want to set the maximum number of blocks available.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-setmaxmediablocksfromdevice HRESULT
			// SetMaxMediaBlocksFromDevice( IDiscRecorder2 *discRecorder );
			[DispId(36)]
			void SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder);

			/// <summary>Retrieves the number of blocks in use.</summary>
			/// <value>Estimated number of blocks used in the file-system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_usedblocks HRESULT
			// get_UsedBlocks( LONG *pVal );
			[DispId(3)]
			int UsedBlocks { get; }

			/// <summary>Retrieves or sets the volume name for this file system image.</summary>
			/// <value>String that contains the volume name for this file system image.</value>
			/// <remarks>To set the volume name, call the IFileSystemImage::put_VolumeName method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumename HRESULT
			// get_VolumeName( BSTR *pVal );
			[DispId(4)]
			string VolumeName { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

			/// <summary>Retrieves the volume name provided from an imported file system.</summary>
			/// <value>
			/// String that contains the volume name provided from an imported file system. Is <c>NULL</c> until a file system is imported.
			/// </value>
			/// <remarks>
			/// The imported volume name is provided for user information and is not automatically carried forward to subsequent sessions.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_importedvolumename HRESULT
			// get_ImportedVolumeName( BSTR *pVal );
			[DispId(5)]
			string ImportedVolumeName { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the boot image that you want to add to the file system image.</summary>
			/// <value>An IBootOptions interface of the boot image to add to the disc. Is <c>NULL</c> if a boot image has not been specified.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_bootimageoptions HRESULT
			// get_BootImageOptions( IBootOptions **pVal );
			[DispId(6)]
			IBootOptions BootImageOptions { [return: MarshalAs(UnmanagedType.Interface)] get; set; }

			/// <summary>Retrieves the number of files in the file system image.</summary>
			/// <value>Number of files in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filecount HRESULT get_FileCount(
			// LONG *pVal );
			[DispId(7)]
			int FileCount { get; }

			/// <summary>Retrieves the number of directories in the file system image.</summary>
			/// <value>Number of directories in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_directorycount HRESULT
			// get_DirectoryCount( LONG *pVal );
			[DispId(8)]
			int DirectoryCount { get; }

			/// <summary>Retrieves the temporary directory in which stash files are built.</summary>
			/// <value>String that contains the path to the temporary directory.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_workingdirectory HRESULT
			// get_WorkingDirectory( BSTR *pVal );
			[DispId(9)]
			string WorkingDirectory { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

			/// <summary>Retrieves the change point identifier.</summary>
			/// <value>Change point identifier. The identifier is a count of the changes to the file system image since its inception.</value>
			/// <remarks>
			/// <para>
			/// An application can store the value of this property prior to making a change to the file system, then at a later point pass
			/// the value to the IFileSystemImage::RollbackToChangePoint method to revert changes since that point in development.
			/// </para>
			/// <para>
			/// An application can call the IFileSystemImage::LockInChangePoint method to lock the state of a file system image at any point
			/// in its development. Once a lock is set, you cannot call RollbackToChangePoint to revert the file system image to its earlier state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_changepoint HRESULT
			// get_ChangePoint( LONG *pVal );
			[DispId(10)]
			int ChangePoint { get; }

			/// <summary>Determines the compliance level for creating and developing the file-system image.</summary>
			/// <value>
			/// <para>Is VARIANT_TRUE if the file system images are created in strict compliance with applicable standards.</para>
			/// <para>Is VARIANT_FALSE if the compliance standards are relaxed to be compatible with IMAPI version 1.0.</para>
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_strictfilesystemcompliance
			// HRESULT get_StrictFileSystemCompliance( VARIANT_BOOL *pVal );
			[DispId(11)]
			bool StrictFileSystemCompliance { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Determines if the file and directory names use a restricted character.</summary>
			/// <value>
			/// Is VARIANT_TRUE if the file and directory names to add to the file system image must consist of characters that map directly
			/// to CP_ANSI (code points 32 through 127). Otherwise, VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_userestrictedcharacterset
			// HRESULT get_UseRestrictedCharacterSet( VARIANT_BOOL *pVal );
			[DispId(12)]
			bool UseRestrictedCharacterSet { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the types of file systems to create when generating the result stream.</summary>
			/// <value>
			/// One or more file system types to create when generating the result stream. For possible values, see the FsiFileSystems
			/// enumeration type.
			/// </value>
			/// <remarks>
			/// <para>
			/// To specify the file system types, call the IFileSystemImage::put_FileSystemsToCreate method. You could also call either
			/// IFilesystemImage::ChooseImageDefaults or IFilesystemImage::ChooseImageDefaultsForMediaType to have IMAPI choose the file
			/// system for you.
			/// </para>
			/// <para>To retrieve a list of supported file system types, call the IFileSystemImage::get_FileSystemsSupported method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filesystemstocreate HRESULT
			// get_FileSystemsToCreate( FsiFileSystems *pVal );
			[DispId(13)]
			FsiFileSystems FileSystemsToCreate { get; set; }

			/// <summary>Retrieves the list of file system types that a client can use to build a file system image.</summary>
			/// <value>
			/// One or more file system types that a client can use to build a file system image. For possible values, see the
			/// FsiFileSystems enumeration type.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filesystemssupported HRESULT
			// get_FileSystemsSupported( FsiFileSystems *pVal );
			[DispId(14)]
			FsiFileSystems FileSystemsSupported { get; }

			/// <summary>Retrieves the UDF revision level of the imported file system image.</summary>
			/// <value>UDF revision level of the imported file system image.</value>
			/// <remarks>
			/// The value is encoded according to the UDF specification, except the variable size is LONG. For example, revision level 1.02
			/// is represented as 0x102.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_udfrevision HRESULT
			// get_UDFRevision( LONG *pVal );
			[DispId(37)]
			int UDFRevision { set; get; }

			/// <summary>Retrieves a list of supported UDF revision levels.</summary>
			/// <value>
			/// List of supported UDF revision levels. Each element of the list is VARIANT. The variant type is <c>VT_I4</c>. The
			/// <c>lVal</c> member of the variant contains the revision level.
			/// </value>
			/// <remarks>
			/// The value is encoded according to the UDF specification, except the variable size is LONG. For example, revision level 1.02
			/// is represented as 0x102.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_udfrevisionssupported HRESULT
			// get_UDFRevisionsSupported( SAFEARRAY **pVal );
			[DispId(31)]
			int[] UDFRevisionsSupported { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<int>))] get; }

			/// <summary>Sets the default file system types and the image size based on the current media.</summary>
			/// <param name="discRecorder">An IDiscRecorder2 the identifies the device that contains the current media.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-chooseimagedefaults HRESULT
			// ChooseImageDefaults( IDiscRecorder2 *discRecorder );
			[DispId(32)]
			void ChooseImageDefaults(IDiscRecorder2 discRecorder);

			/// <summary>Sets the default file system types and the image size based on the specified media type.</summary>
			/// <param name="value">
			/// Identifies the physical media type that will receive the burn image. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPE
			/// enumeration type.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-chooseimagedefaultsformediatype
			// HRESULT ChooseImageDefaultsForMediaType( IMAPI_MEDIA_PHYSICAL_TYPE value );
			[DispId(33)]
			void ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value);

			/// <summary>Retrieves the ISO9660 compatibility level to use when creating the result image.</summary>
			/// <value>Identifies the interchange level of the ISO9660 file system.</value>
			/// <remarks>
			/// For a list of supported compatibility levels, call the IFileSystemImage::get_ISO9660InterchangeLevelsSupported method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_iso9660interchangelevel HRESULT
			// get_ISO9660InterchangeLevel( LONG *pVal );
			[DispId(34)]
			int ISO9660InterchangeLevel { set; get; }

			/// <summary>Retrieves the supported ISO9660 compatibility levels.</summary>
			/// <value>
			/// List of supported ISO9660 compatibility levels. Each item in the list is a VARIANT that identifies one supported interchange
			/// level. The variant type is <c>VT_UI4</c>. The <c>ulVal</c> member of the variant contains the compatibility level.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_iso9660interchangelevelssupported
			// HRESULT get_ISO9660InterchangeLevelsSupported( SAFEARRAY **pVal );
			[DispId(38)]
			uint[] ISO9660InterchangeLevelsSupported { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<uint>))] get; }

			/// <summary>Create the result object that contains the file system and file data.</summary>
			/// <returns>
			/// <para>An IFileSystemImageResult interface of the image result.</para>
			/// <para>Client applications can stream the image to media or other long-term storage devices, such as disk drives.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Currently, <c>IFileSystemImage::CreateResultImage</c> will require disc media access as a result of a previous
			/// IFileSystemImage::IdentifyFileSystemsOnDisc method call. To resolve this issue, it is recommended that another
			/// IFileSystemImage object be created specifically for the <c>IFileSystemImage::IdentifyFileSystemsOnDisc</c> operation.
			/// </para>
			/// <para>
			/// The resulting stream can be saved as an ISO file if the file system is generated in a single session and has a start address
			/// of zero.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createresultimage HRESULT
			// CreateResultImage( IFileSystemImageResult **resultStream );
			[DispId(15)]
			IFileSystemImageResult CreateResultImage();

			/// <summary>Checks for the existence of a given file or directory.</summary>
			/// <param name="fullPath">String that contains the fully qualified path of the directory or file to check.</param>
			/// <returns>
			/// Indicates if the item is a file, a directory, or does not exist. For possible values, see the FsiItemType enumeration type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-exists HRESULT Exists( BSTR
			// fullPath, FsiItemType *itemType );
			[DispId(16)]
			FsiItemType Exists([MarshalAs(UnmanagedType.BStr)] string fullPath);

			/// <summary>Retrieves a string that identifies a disc and the sessions recorded on the disc.</summary>
			/// <returns>
			/// String that contains a signature that identifies the disc and the sessions on it. This string is not guaranteed to be unique
			/// between discs.
			/// </returns>
			/// <remarks>
			/// <para>
			/// When layering sessions on a disc, the signature acts as a key that the client can use to ensure the session order, and to
			/// distinguish sessions on disc from session images that will be laid on the disc.
			/// </para>
			/// <para>You must call IFileSystemImage::put_MultisessionInterfaces prior to calling <c>CalculateDiscIdentifier</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-calculatediscidentifier HRESULT
			// CalculateDiscIdentifier( BSTR *discIdentifier );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			string CalculateDiscIdentifier();

			/// <summary>Retrieves a list of the different types of file systems on the optical media.</summary>
			/// <param name="discRecorder">
			/// An IDiscRecorder2 interface that identifies the recording device that contains the media. If this parameter is <c>NULL</c>,
			/// the discRecorder specified in IMultisession will be used.
			/// </param>
			/// <returns>One or more files systems on the disc. For possible values, see FsiFileSystems enumeration type.</returns>
			/// <remarks>
			/// Client applications can call IFileSystemImage::GetDefaultFileSystemForImport with the value returned by this method to
			/// determine the type of file system to import.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-identifyfilesystemsondisc HRESULT
			// IdentifyFileSystemsOnDisc( IDiscRecorder2 *discRecorder, FsiFileSystems *fileSystems );
			[DispId(19)]
			FsiFileSystems IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder);

			/// <summary>Retrieves the file system to import by default.</summary>
			/// <param name="fileSystems">One or more file system values. For possible values, see the FsiFileSystems enumeration type.</param>
			/// <returns>
			/// A single file system value that identifies the default file system. The value is one of the file systems specified in fileSystems
			/// </returns>
			/// <remarks>
			/// <para>Use this method to identify the default file system to use with IFileSystemImage::ImportFileSystem.</para>
			/// <para>To identify the supported file systems, call the IFileSystemImage::get_FileSystemsSupported method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-getdefaultfilesystemforimport
			// HRESULT GetDefaultFileSystemForImport( FsiFileSystems fileSystems, FsiFileSystems *importDefault );
			[DispId(20)]
			FsiFileSystems GetDefaultFileSystemForImport(FsiFileSystems fileSystems);

			/// <summary>Imports the default file system on the current disc.</summary>
			/// <returns>Identifies the imported file system. For possible values, see the FsiFileSystems enumeration type.</returns>
			/// <remarks>
			/// <para>
			/// You must call IFileSystemImage::put_MultisessionInterfaces prior to calling <c>IFileSystemImage::ImportFileSystem</c>.
			/// Additionally, it is recommended that IDiscFormat2::get_MediaHeuristicallyBlank is called before
			/// <c>IFileSystemImage::put_MultisessionInterfaces</c> to verify that the media is not blank.
			/// </para>
			/// <para>
			/// If the disc contains more than one file system, only one file system is imported. This method chooses the file system to
			/// import in the following order: UDF, Joliet, ISO 9660. The import includes transferring directories and files to the
			/// in-memory file system structure.
			/// </para>
			/// <para>
			/// You may call this method at any time during the construction of the in-memory file system. If, during import, a file or
			/// directory already exists in the in-memory copy, the in-memory version will be retained; the imported file will be discarded.
			/// </para>
			/// <para>
			/// To determine which file system is the default file system for the disc, call the
			/// IFileSystemImage::GetDefaultFileSystemForImport method.
			/// </para>
			/// <para>
			/// This method only reads the file information. If the item is a file, the file data is copied when calling
			/// IFsiDirectoryItem::AddFile, IFsiDirectoryItem::AddTree, or IFsiDirectoryItem::Add method.
			/// </para>
			/// <para>
			/// This method returns <c>IMAPI_E_NO_SUPPORTED_FILE_SYSTEM</c> if a supported file system is not found in the last session.
			/// Additionally, this method returns <c>IMAPI_E_INCOMPATIBLE_PREVIOUS_SESSION</c> if the layout of the file system in the last
			/// session is incompatible with the layout used by IMAPI for the creation of requested file systems for the result image. For
			/// more details see the IFileSystemImage::put_FileSystemsToCreate method documention.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-importfilesystem HRESULT
			// ImportFileSystem( FsiFileSystems *importedFileSystem );
			[DispId(21)]
			FsiFileSystems ImportFileSystem();

			/// <summary>Import a specific file system from disc.</summary>
			/// <param name="fileSystemToUse">
			/// Identifies the file system to import. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <remarks>
			/// <para>
			/// You must call IFileSystemImage::put_MultisessionInterfaces prior to calling
			/// <c>IFileSystemImage::ImportSpecificFileSystem</c>. Additionally, it is recommended that
			/// IDiscFormat2::get_MediaHeuristicallyBlank is called before <c>IFileSystemImage::put_MultisessionInterfaces</c> to verify
			/// that the media is not blank.
			/// </para>
			/// <para>
			/// You may call this method at any time during the construction of the in-memory file system. If, during import, a file or
			/// directory already exists in the in-memory copy, the in-memory version will be retained; the imported file will be discarded.
			/// </para>
			/// <para>
			/// On re-writable media (DVD+/-RW, DVDRAM, BD-RE), import or burning a second session is not support if the first session has
			/// an ISO9660 file system, due to file system limitations.
			/// </para>
			/// <para>
			/// This method only reads the file information. If the item is a file, the file data is copied when calling
			/// IFsiDirectoryItem::AddFile, IFsiDirectoryItem::AddTree, or IFsiDirectoryItem::Add method.
			/// </para>
			/// <para>
			/// this method returns <c>IMAPI_E_INCOMPATIBLE_PREVIOUS_SESSION</c> if the layout of the file system in the last session is
			/// incompatible with the layout used by IMAPI for the creation of requested file systems for the result image. For more details
			/// see the IFileSystemImage::put_FileSystemsToCreate method documention. If the file system specified by fileSystemToUse has
			/// not been found, this method returns <c>IMAPI_E_FILE_SYSTEM_NOT_FOUND</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-importspecificfilesystem HRESULT
			// ImportSpecificFileSystem( FsiFileSystems fileSystemToUse );
			[DispId(22)]
			void ImportSpecificFileSystem(FsiFileSystems fileSystemToUse);

			/// <summary>Reverts the image back to the specified change point.</summary>
			/// <param name="changePoint">Change point that identifies the target state for rollback.</param>
			/// <remarks>
			/// <para>
			/// Typically, an application calls the IFileSystemImage::get_ChangePoint method and stores the change point value prior to
			/// making a change to the file system. If necessary, you can pass the change point value to this method to revert changes since
			/// that point in development.
			/// </para>
			/// <para>
			/// An application can call the IFileSystemImage::LockInChangePoint method to lock the state of a file system image at any point
			/// in its development. After a lock is set, you cannot call this method to revert the file system image to its earlier state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-rollbacktochangepoint HRESULT
			// RollbackToChangePoint( LONG changePoint );
			[DispId(23)]
			void RollbackToChangePoint(int changePoint);

			/// <summary>Locks the file system information at the current change-point level.</summary>
			/// <remarks>
			/// <para>Once the change point is locked, rollback to earlier change points is not permitted.</para>
			/// <para>Locking the change point does not change the IFileSystemImage::get_ChangePoint property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-lockinchangepoint HRESULT LockInChangePoint();
			[DispId(24)]
			void LockInChangePoint();

			/// <summary>Create a directory item with the specified name.</summary>
			/// <param name="name">String that contains the name of the directory item to create.</param>
			/// <returns>
			/// An IFsiDirectoryItem interface of the new directory item. When done, call the <c>IFsiDirectoryItem::Release</c> method to
			/// release the interface.
			/// </returns>
			/// <remarks>
			/// After setting properties on the IFsiDirectoryItem interface, call the IFsiDirectoryItem::Add method on the parent directory
			/// item to add it to the file system image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createdirectoryitem HRESULT
			// CreateDirectoryItem( BSTR name, IFsiDirectoryItem **newItem );
			[DispId(25)]
			IFsiDirectoryItem CreateDirectoryItem([MarshalAs(UnmanagedType.BStr)] string name);

			/// <summary>Create a file item with the specified name.</summary>
			/// <param name="name">String that contains the name of the file item to create.</param>
			/// <returns>
			/// An IFsiFileItem interface of the new file item. When done, call the <c>IFsiFileItem::Release</c> method to release the interface.
			/// </returns>
			/// <remarks>
			/// After setting properties on the IFsiFileItem interface, call the IFsiDirectoryItem::Add method on the parent directory item
			/// to add it to the file system image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createfileitem HRESULT
			// CreateFileItem( BSTR name, IFsiFileItem **newItem );
			[DispId(26)]
			IFsiFileItem CreateFileItem([MarshalAs(UnmanagedType.BStr)] string name);

			/// <summary>Retrieves the volume name for the UDF system image.</summary>
			/// <value>String that contains the volume name for the UDF system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenameudf HRESULT
			// get_VolumeNameUDF( BSTR *pVal );
			[DispId(27)]
			string VolumeNameUDF { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the volume name for the Joliet system image.</summary>
			/// <value>String that contains the volume name for the Joliet system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenamejoliet HRESULT
			// get_VolumeNameJoliet( BSTR *pVal );
			[DispId(28)]
			string VolumeNameJoliet { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the volume name for the ISO9660 system image.</summary>
			/// <value>String that contains the volume name for the ISO9660 system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenameiso9660 HRESULT
			// get_VolumeNameISO9660( BSTR *pVal );
			[DispId(29)]
			string VolumeNameISO9660 { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Indicates if the files being added to the file system image should be staged before the burn.</summary>
			/// <value>
			/// <c>VARIANT_TRUE</c> if the files being added to the file system image are required to be stageded in one or more stage files
			/// before burning. Otherwise, <c>VARIANT_FALSE</c> is returned if IMAPI is permitted to optimize the image creation process by
			/// not staging the files being added to the file system image.
			/// </value>
			/// <remarks>
			/// <para>
			/// "Staging" is a process in which an image is created on the hard-drive, containing all files to be burned, prior to the
			/// initiation of the burn operation.
			/// </para>
			/// <para>
			/// Setting this this property to <c>VARIANT_TRUE</c> via IFileSystemImage::put_StageFiles will only affect files that are added
			/// after the property is set: those files will always be staged. Files that were not staged prior to a specified property value
			/// of <c>VARIANT_TRUE</c>, will not be staged.
			/// </para>
			/// <para>By specifying <c>VARIANT_FALSE</c>, the file system image creation process is optimized in two ways:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Less time is required for image generation</term>
			/// </item>
			/// <item>
			/// <term>Less space is consumed on a local disk by IMAPI</term>
			/// </item>
			/// </list>
			/// <para>
			/// However, in order to avoid buffer underrun problems during burning, a certain minimum throughput is required for read
			/// operations on non-staged files. In the event that file accessibility or throughput may not meet the requirements of the
			/// burner, IMAPI enforces file staging regardless of the specified property value. For example, file staging is enforced for
			/// source files from removable storage devices, such as USB Flash Disk.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_stagefiles HRESULT
			// get_StageFiles( VARIANT_BOOL *pVal );
			[DispId(30)]
			bool StageFiles { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the list of multi-session interfaces for the optical media.</summary>
			/// <value>
			/// List of multi-session interfaces for the optical media. Each element of the list is a <c>VARIANT</c> of type
			/// <c>VT_Dispatch</c>. Query the <c>pdispVal</c> member of the variant for the IMultisession interface.
			/// </value>
			/// <remarks>
			/// Query the IMultisession interface for a derived <c>IMultisession</c> interface, for example, the IMultisessionSequential interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_multisessioninterfaces HRESULT
			// get_MultisessionInterfaces( SAFEARRAY **pVal );
			[DispId(40)]
			IMultisession[] MultisessionInterfaces { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMultisession>))] get; set;  }
		}

		/// <summary>
		/// Use this interface to write multiple boot entries or boot images required for the EFI/UEFI support. For example, boot media with
		/// boot straps for both Windows XP and Windows Vista.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Boot entries are limited by the interface to 32 per disc. The boot image must be supplied to IMAPIv2FS by outside applications
		/// who invoke IMAPIv2FS to build the bootable disc.
		/// </para>
		/// <para>Section Entry Extension is not supported by IMAPIv2FS at this time.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifilesystemimage2
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFileSystemImage2")]
		[ComImport, Guid("D7644B2C-1537-4767-B62F-F1387B02DDFD"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftFileSystemImage))]
		public interface IFileSystemImage2 : IFileSystemImage
		{
			/// <summary>Retrieves the root directory item.</summary>
			/// <value>An IFsiDirectoryItem interface of the root directory item.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_root HRESULT get_Root(
			// IFsiDirectoryItem **pVal );
			[DispId(0)]
			new IFsiDirectoryItem Root { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Retrieves the starting block address for the recording session.</summary>
			/// <value>Starting block address for the recording session.</value>
			/// <remarks>
			/// <para>The session starting block can be set in the following ways:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Importing a file system automatically sets the session starting block.</term>
			/// </item>
			/// <item>
			/// <term>If the previous session is not imported, the client can call IFileSystemImage::put_SessionStartBlock to set this property.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_sessionstartblock HRESULT
			// get_SessionStartBlock( LONG *pVal );
			[DispId(1)]
			new int SessionStartBlock { get; set; }

			/// <summary>Retrieves the maximum number of blocks available for the image.</summary>
			/// <value>Number of blocks to use in creating the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_freemediablocks HRESULT
			// get_FreeMediaBlocks( LONG *pVal );
			[DispId(2)]
			new int FreeMediaBlocks { get; set; }

			/// <summary>Set maximum number of blocks available based on the capabilities of the recorder.</summary>
			/// <param name="discRecorder">
			/// An IDiscRecorder2 interface that identifies the recording device from which you want to set the maximum number of blocks available.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-setmaxmediablocksfromdevice HRESULT
			// SetMaxMediaBlocksFromDevice( IDiscRecorder2 *discRecorder );
			[DispId(36)]
			new void SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder);

			/// <summary>Retrieves the number of blocks in use.</summary>
			/// <value>Estimated number of blocks used in the file-system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_usedblocks HRESULT
			// get_UsedBlocks( LONG *pVal );
			[DispId(3)]
			new int UsedBlocks { get; }

			/// <summary>Retrieves or sets the volume name for this file system image.</summary>
			/// <value>String that contains the volume name for this file system image.</value>
			/// <remarks>To set the volume name, call the IFileSystemImage::put_VolumeName method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumename HRESULT
			// get_VolumeName( BSTR *pVal );
			[DispId(4)]
			new string VolumeName { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

			/// <summary>Retrieves the volume name provided from an imported file system.</summary>
			/// <value>
			/// String that contains the volume name provided from an imported file system. Is <c>NULL</c> until a file system is imported.
			/// </value>
			/// <remarks>
			/// The imported volume name is provided for user information and is not automatically carried forward to subsequent sessions.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_importedvolumename HRESULT
			// get_ImportedVolumeName( BSTR *pVal );
			[DispId(5)]
			new string ImportedVolumeName { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the boot image that you want to add to the file system image.</summary>
			/// <value>An IBootOptions interface of the boot image to add to the disc. Is <c>NULL</c> if a boot image has not been specified.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_bootimageoptions HRESULT
			// get_BootImageOptions( IBootOptions **pVal );
			[DispId(6)]
			new IBootOptions BootImageOptions { [return: MarshalAs(UnmanagedType.Interface)] get; set; }

			/// <summary>Retrieves the number of files in the file system image.</summary>
			/// <value>Number of files in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filecount HRESULT get_FileCount(
			// LONG *pVal );
			[DispId(7)]
			new int FileCount { get; }

			/// <summary>Retrieves the number of directories in the file system image.</summary>
			/// <value>Number of directories in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_directorycount HRESULT
			// get_DirectoryCount( LONG *pVal );
			[DispId(8)]
			new int DirectoryCount { get; }

			/// <summary>Retrieves the temporary directory in which stash files are built.</summary>
			/// <value>String that contains the path to the temporary directory.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_workingdirectory HRESULT
			// get_WorkingDirectory( BSTR *pVal );
			[DispId(9)]
			new string WorkingDirectory { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

			/// <summary>Retrieves the change point identifier.</summary>
			/// <value>Change point identifier. The identifier is a count of the changes to the file system image since its inception.</value>
			/// <remarks>
			/// <para>
			/// An application can store the value of this property prior to making a change to the file system, then at a later point pass
			/// the value to the IFileSystemImage::RollbackToChangePoint method to revert changes since that point in development.
			/// </para>
			/// <para>
			/// An application can call the IFileSystemImage::LockInChangePoint method to lock the state of a file system image at any point
			/// in its development. Once a lock is set, you cannot call RollbackToChangePoint to revert the file system image to its earlier state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_changepoint HRESULT
			// get_ChangePoint( LONG *pVal );
			[DispId(10)]
			new int ChangePoint { get; }

			/// <summary>Determines the compliance level for creating and developing the file-system image.</summary>
			/// <value>
			/// <para>Is VARIANT_TRUE if the file system images are created in strict compliance with applicable standards.</para>
			/// <para>Is VARIANT_FALSE if the compliance standards are relaxed to be compatible with IMAPI version 1.0.</para>
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_strictfilesystemcompliance
			// HRESULT get_StrictFileSystemCompliance( VARIANT_BOOL *pVal );
			[DispId(11)]
			new bool StrictFileSystemCompliance { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Determines if the file and directory names use a restricted character.</summary>
			/// <value>
			/// Is VARIANT_TRUE if the file and directory names to add to the file system image must consist of characters that map directly
			/// to CP_ANSI (code points 32 through 127). Otherwise, VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_userestrictedcharacterset
			// HRESULT get_UseRestrictedCharacterSet( VARIANT_BOOL *pVal );
			[DispId(12)]
			new bool UseRestrictedCharacterSet { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the types of file systems to create when generating the result stream.</summary>
			/// <value>
			/// One or more file system types to create when generating the result stream. For possible values, see the FsiFileSystems
			/// enumeration type.
			/// </value>
			/// <remarks>
			/// <para>
			/// To specify the file system types, call the IFileSystemImage::put_FileSystemsToCreate method. You could also call either
			/// IFilesystemImage::ChooseImageDefaults or IFilesystemImage::ChooseImageDefaultsForMediaType to have IMAPI choose the file
			/// system for you.
			/// </para>
			/// <para>To retrieve a list of supported file system types, call the IFileSystemImage::get_FileSystemsSupported method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filesystemstocreate HRESULT
			// get_FileSystemsToCreate( FsiFileSystems *pVal );
			[DispId(13)]
			new FsiFileSystems FileSystemsToCreate { get; set; }

			/// <summary>Retrieves the list of file system types that a client can use to build a file system image.</summary>
			/// <value>
			/// One or more file system types that a client can use to build a file system image. For possible values, see the
			/// FsiFileSystems enumeration type.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filesystemssupported HRESULT
			// get_FileSystemsSupported( FsiFileSystems *pVal );
			[DispId(14)]
			new FsiFileSystems FileSystemsSupported { get; }

			/// <summary>Retrieves the UDF revision level of the imported file system image.</summary>
			/// <value>UDF revision level of the imported file system image.</value>
			/// <remarks>
			/// The value is encoded according to the UDF specification, except the variable size is LONG. For example, revision level 1.02
			/// is represented as 0x102.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_udfrevision HRESULT
			// get_UDFRevision( LONG *pVal );
			[DispId(37)]
			new int UDFRevision { set; get; }

			/// <summary>Retrieves a list of supported UDF revision levels.</summary>
			/// <value>
			/// List of supported UDF revision levels. Each element of the list is VARIANT. The variant type is <c>VT_I4</c>. The
			/// <c>lVal</c> member of the variant contains the revision level.
			/// </value>
			/// <remarks>
			/// The value is encoded according to the UDF specification, except the variable size is LONG. For example, revision level 1.02
			/// is represented as 0x102.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_udfrevisionssupported HRESULT
			// get_UDFRevisionsSupported( SAFEARRAY **pVal );
			[DispId(31)]
			new int[] UDFRevisionsSupported { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<int>))] get; }

			/// <summary>Sets the default file system types and the image size based on the current media.</summary>
			/// <param name="discRecorder">An IDiscRecorder2 the identifies the device that contains the current media.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-chooseimagedefaults HRESULT
			// ChooseImageDefaults( IDiscRecorder2 *discRecorder );
			[DispId(32)]
			new void ChooseImageDefaults(IDiscRecorder2 discRecorder);

			/// <summary>Sets the default file system types and the image size based on the specified media type.</summary>
			/// <param name="value">
			/// Identifies the physical media type that will receive the burn image. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPE
			/// enumeration type.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-chooseimagedefaultsformediatype
			// HRESULT ChooseImageDefaultsForMediaType( IMAPI_MEDIA_PHYSICAL_TYPE value );
			[DispId(33)]
			new void ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value);

			/// <summary>Retrieves the ISO9660 compatibility level to use when creating the result image.</summary>
			/// <value>Identifies the interchange level of the ISO9660 file system.</value>
			/// <remarks>
			/// For a list of supported compatibility levels, call the IFileSystemImage::get_ISO9660InterchangeLevelsSupported method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_iso9660interchangelevel HRESULT
			// get_ISO9660InterchangeLevel( LONG *pVal );
			[DispId(34)]
			new int ISO9660InterchangeLevel { set; get; }

			/// <summary>Retrieves the supported ISO9660 compatibility levels.</summary>
			/// <value>
			/// List of supported ISO9660 compatibility levels. Each item in the list is a VARIANT that identifies one supported interchange
			/// level. The variant type is <c>VT_UI4</c>. The <c>ulVal</c> member of the variant contains the compatibility level.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_iso9660interchangelevelssupported
			// HRESULT get_ISO9660InterchangeLevelsSupported( SAFEARRAY **pVal );
			[DispId(38)]
			new uint[] ISO9660InterchangeLevelsSupported { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<uint>))] get; }

			/// <summary>Create the result object that contains the file system and file data.</summary>
			/// <returns>
			/// <para>An IFileSystemImageResult interface of the image result.</para>
			/// <para>Client applications can stream the image to media or other long-term storage devices, such as disk drives.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Currently, <c>IFileSystemImage::CreateResultImage</c> will require disc media access as a result of a previous
			/// IFileSystemImage::IdentifyFileSystemsOnDisc method call. To resolve this issue, it is recommended that another
			/// IFileSystemImage object be created specifically for the <c>IFileSystemImage::IdentifyFileSystemsOnDisc</c> operation.
			/// </para>
			/// <para>
			/// The resulting stream can be saved as an ISO file if the file system is generated in a single session and has a start address
			/// of zero.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createresultimage HRESULT
			// CreateResultImage( IFileSystemImageResult **resultStream );
			[DispId(15)]
			new IFileSystemImageResult CreateResultImage();

			/// <summary>Checks for the existence of a given file or directory.</summary>
			/// <param name="fullPath">String that contains the fully qualified path of the directory or file to check.</param>
			/// <returns>
			/// Indicates if the item is a file, a directory, or does not exist. For possible values, see the FsiItemType enumeration type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-exists HRESULT Exists( BSTR
			// fullPath, FsiItemType *itemType );
			[DispId(16)]
			new FsiItemType Exists([MarshalAs(UnmanagedType.BStr)] string fullPath);

			/// <summary>Retrieves a string that identifies a disc and the sessions recorded on the disc.</summary>
			/// <returns>
			/// String that contains a signature that identifies the disc and the sessions on it. This string is not guaranteed to be unique
			/// between discs.
			/// </returns>
			/// <remarks>
			/// <para>
			/// When layering sessions on a disc, the signature acts as a key that the client can use to ensure the session order, and to
			/// distinguish sessions on disc from session images that will be laid on the disc.
			/// </para>
			/// <para>You must call IFileSystemImage::put_MultisessionInterfaces prior to calling <c>CalculateDiscIdentifier</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-calculatediscidentifier HRESULT
			// CalculateDiscIdentifier( BSTR *discIdentifier );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string CalculateDiscIdentifier();

			/// <summary>Retrieves a list of the different types of file systems on the optical media.</summary>
			/// <param name="discRecorder">
			/// An IDiscRecorder2 interface that identifies the recording device that contains the media. If this parameter is <c>NULL</c>,
			/// the discRecorder specified in IMultisession will be used.
			/// </param>
			/// <returns>One or more files systems on the disc. For possible values, see FsiFileSystems enumeration type.</returns>
			/// <remarks>
			/// Client applications can call IFileSystemImage::GetDefaultFileSystemForImport with the value returned by this method to
			/// determine the type of file system to import.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-identifyfilesystemsondisc HRESULT
			// IdentifyFileSystemsOnDisc( IDiscRecorder2 *discRecorder, FsiFileSystems *fileSystems );
			[DispId(19)]
			new FsiFileSystems IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder);

			/// <summary>Retrieves the file system to import by default.</summary>
			/// <param name="fileSystems">One or more file system values. For possible values, see the FsiFileSystems enumeration type.</param>
			/// <returns>
			/// A single file system value that identifies the default file system. The value is one of the file systems specified in fileSystems
			/// </returns>
			/// <remarks>
			/// <para>Use this method to identify the default file system to use with IFileSystemImage::ImportFileSystem.</para>
			/// <para>To identify the supported file systems, call the IFileSystemImage::get_FileSystemsSupported method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-getdefaultfilesystemforimport
			// HRESULT GetDefaultFileSystemForImport( FsiFileSystems fileSystems, FsiFileSystems *importDefault );
			[DispId(20)]
			new FsiFileSystems GetDefaultFileSystemForImport(FsiFileSystems fileSystems);

			/// <summary>Imports the default file system on the current disc.</summary>
			/// <returns>Identifies the imported file system. For possible values, see the FsiFileSystems enumeration type.</returns>
			/// <remarks>
			/// <para>
			/// You must call IFileSystemImage::put_MultisessionInterfaces prior to calling <c>IFileSystemImage::ImportFileSystem</c>.
			/// Additionally, it is recommended that IDiscFormat2::get_MediaHeuristicallyBlank is called before
			/// <c>IFileSystemImage::put_MultisessionInterfaces</c> to verify that the media is not blank.
			/// </para>
			/// <para>
			/// If the disc contains more than one file system, only one file system is imported. This method chooses the file system to
			/// import in the following order: UDF, Joliet, ISO 9660. The import includes transferring directories and files to the
			/// in-memory file system structure.
			/// </para>
			/// <para>
			/// You may call this method at any time during the construction of the in-memory file system. If, during import, a file or
			/// directory already exists in the in-memory copy, the in-memory version will be retained; the imported file will be discarded.
			/// </para>
			/// <para>
			/// To determine which file system is the default file system for the disc, call the
			/// IFileSystemImage::GetDefaultFileSystemForImport method.
			/// </para>
			/// <para>
			/// This method only reads the file information. If the item is a file, the file data is copied when calling
			/// IFsiDirectoryItem::AddFile, IFsiDirectoryItem::AddTree, or IFsiDirectoryItem::Add method.
			/// </para>
			/// <para>
			/// This method returns <c>IMAPI_E_NO_SUPPORTED_FILE_SYSTEM</c> if a supported file system is not found in the last session.
			/// Additionally, this method returns <c>IMAPI_E_INCOMPATIBLE_PREVIOUS_SESSION</c> if the layout of the file system in the last
			/// session is incompatible with the layout used by IMAPI for the creation of requested file systems for the result image. For
			/// more details see the IFileSystemImage::put_FileSystemsToCreate method documention.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-importfilesystem HRESULT
			// ImportFileSystem( FsiFileSystems *importedFileSystem );
			[DispId(21)]
			new FsiFileSystems ImportFileSystem();

			/// <summary>Import a specific file system from disc.</summary>
			/// <param name="fileSystemToUse">
			/// Identifies the file system to import. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <remarks>
			/// <para>
			/// You must call IFileSystemImage::put_MultisessionInterfaces prior to calling
			/// <c>IFileSystemImage::ImportSpecificFileSystem</c>. Additionally, it is recommended that
			/// IDiscFormat2::get_MediaHeuristicallyBlank is called before <c>IFileSystemImage::put_MultisessionInterfaces</c> to verify
			/// that the media is not blank.
			/// </para>
			/// <para>
			/// You may call this method at any time during the construction of the in-memory file system. If, during import, a file or
			/// directory already exists in the in-memory copy, the in-memory version will be retained; the imported file will be discarded.
			/// </para>
			/// <para>
			/// On re-writable media (DVD+/-RW, DVDRAM, BD-RE), import or burning a second session is not support if the first session has
			/// an ISO9660 file system, due to file system limitations.
			/// </para>
			/// <para>
			/// This method only reads the file information. If the item is a file, the file data is copied when calling
			/// IFsiDirectoryItem::AddFile, IFsiDirectoryItem::AddTree, or IFsiDirectoryItem::Add method.
			/// </para>
			/// <para>
			/// this method returns <c>IMAPI_E_INCOMPATIBLE_PREVIOUS_SESSION</c> if the layout of the file system in the last session is
			/// incompatible with the layout used by IMAPI for the creation of requested file systems for the result image. For more details
			/// see the IFileSystemImage::put_FileSystemsToCreate method documention. If the file system specified by fileSystemToUse has
			/// not been found, this method returns <c>IMAPI_E_FILE_SYSTEM_NOT_FOUND</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-importspecificfilesystem HRESULT
			// ImportSpecificFileSystem( FsiFileSystems fileSystemToUse );
			[DispId(22)]
			new void ImportSpecificFileSystem(FsiFileSystems fileSystemToUse);

			/// <summary>Reverts the image back to the specified change point.</summary>
			/// <param name="changePoint">Change point that identifies the target state for rollback.</param>
			/// <remarks>
			/// <para>
			/// Typically, an application calls the IFileSystemImage::get_ChangePoint method and stores the change point value prior to
			/// making a change to the file system. If necessary, you can pass the change point value to this method to revert changes since
			/// that point in development.
			/// </para>
			/// <para>
			/// An application can call the IFileSystemImage::LockInChangePoint method to lock the state of a file system image at any point
			/// in its development. After a lock is set, you cannot call this method to revert the file system image to its earlier state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-rollbacktochangepoint HRESULT
			// RollbackToChangePoint( LONG changePoint );
			[DispId(23)]
			new void RollbackToChangePoint(int changePoint);

			/// <summary>Locks the file system information at the current change-point level.</summary>
			/// <remarks>
			/// <para>Once the change point is locked, rollback to earlier change points is not permitted.</para>
			/// <para>Locking the change point does not change the IFileSystemImage::get_ChangePoint property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-lockinchangepoint HRESULT LockInChangePoint();
			[DispId(24)]
			new void LockInChangePoint();

			/// <summary>Create a directory item with the specified name.</summary>
			/// <param name="name">String that contains the name of the directory item to create.</param>
			/// <returns>
			/// An IFsiDirectoryItem interface of the new directory item. When done, call the <c>IFsiDirectoryItem::Release</c> method to
			/// release the interface.
			/// </returns>
			/// <remarks>
			/// After setting properties on the IFsiDirectoryItem interface, call the IFsiDirectoryItem::Add method on the parent directory
			/// item to add it to the file system image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createdirectoryitem HRESULT
			// CreateDirectoryItem( BSTR name, IFsiDirectoryItem **newItem );
			[DispId(25)]
			new IFsiDirectoryItem CreateDirectoryItem([MarshalAs(UnmanagedType.BStr)] string name);

			/// <summary>Create a file item with the specified name.</summary>
			/// <param name="name">String that contains the name of the file item to create.</param>
			/// <returns>
			/// An IFsiFileItem interface of the new file item. When done, call the <c>IFsiFileItem::Release</c> method to release the interface.
			/// </returns>
			/// <remarks>
			/// After setting properties on the IFsiFileItem interface, call the IFsiDirectoryItem::Add method on the parent directory item
			/// to add it to the file system image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createfileitem HRESULT
			// CreateFileItem( BSTR name, IFsiFileItem **newItem );
			[DispId(26)]
			new IFsiFileItem CreateFileItem([MarshalAs(UnmanagedType.BStr)] string name);

			/// <summary>Retrieves the volume name for the UDF system image.</summary>
			/// <value>String that contains the volume name for the UDF system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenameudf HRESULT
			// get_VolumeNameUDF( BSTR *pVal );
			[DispId(27)]
			new string VolumeNameUDF { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the volume name for the Joliet system image.</summary>
			/// <value>String that contains the volume name for the Joliet system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenamejoliet HRESULT
			// get_VolumeNameJoliet( BSTR *pVal );
			[DispId(28)]
			new string VolumeNameJoliet { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the volume name for the ISO9660 system image.</summary>
			/// <value>String that contains the volume name for the ISO9660 system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenameiso9660 HRESULT
			// get_VolumeNameISO9660( BSTR *pVal );
			[DispId(29)]
			new string VolumeNameISO9660 { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Indicates if the files being added to the file system image should be staged before the burn.</summary>
			/// <value>
			/// <c>VARIANT_TRUE</c> if the files being added to the file system image are required to be stageded in one or more stage files
			/// before burning. Otherwise, <c>VARIANT_FALSE</c> is returned if IMAPI is permitted to optimize the image creation process by
			/// not staging the files being added to the file system image.
			/// </value>
			/// <remarks>
			/// <para>
			/// "Staging" is a process in which an image is created on the hard-drive, containing all files to be burned, prior to the
			/// initiation of the burn operation.
			/// </para>
			/// <para>
			/// Setting this this property to <c>VARIANT_TRUE</c> via IFileSystemImage::put_StageFiles will only affect files that are added
			/// after the property is set: those files will always be staged. Files that were not staged prior to a specified property value
			/// of <c>VARIANT_TRUE</c>, will not be staged.
			/// </para>
			/// <para>By specifying <c>VARIANT_FALSE</c>, the file system image creation process is optimized in two ways:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Less time is required for image generation</term>
			/// </item>
			/// <item>
			/// <term>Less space is consumed on a local disk by IMAPI</term>
			/// </item>
			/// </list>
			/// <para>
			/// However, in order to avoid buffer underrun problems during burning, a certain minimum throughput is required for read
			/// operations on non-staged files. In the event that file accessibility or throughput may not meet the requirements of the
			/// burner, IMAPI enforces file staging regardless of the specified property value. For example, file staging is enforced for
			/// source files from removable storage devices, such as USB Flash Disk.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_stagefiles HRESULT
			// get_StageFiles( VARIANT_BOOL *pVal );
			[DispId(30)]
			new bool StageFiles { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the list of multi-session interfaces for the optical media.</summary>
			/// <value>
			/// List of multi-session interfaces for the optical media. Each element of the list is a <c>VARIANT</c> of type
			/// <c>VT_Dispatch</c>. Query the <c>pdispVal</c> member of the variant for the IMultisession interface.
			/// </value>
			/// <remarks>
			/// Query the IMultisession interface for a derived <c>IMultisession</c> interface, for example, the IMultisessionSequential interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_multisessioninterfaces HRESULT
			// get_MultisessionInterfaces( SAFEARRAY **pVal );
			[DispId(40)]
			new IMultisession[] MultisessionInterfaces { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMultisession>))] get; set; }

			/// <summary>Retrieves the boot option array that will be utilized to generate the file system image.</summary>
			/// <value>
			/// Pointer to a boot option array that contains a list of IBootOptions interfaces of boot images used to generate the file
			/// system image. Each element of the list is a <c>VARIANT</c> of type <c>VT_DISPATCH</c>.
			/// </value>
			/// <remarks>
			/// The <c>SAFEARRAY</c> will be a one-dimensional array. If a boot image is not specified, a zero-sized array will be returned.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage2-get_bootimageoptionsarray HRESULT
			// get_BootImageOptionsArray( SAFEARRAY **pVal );
			[DispId(60)]
			IBootOptions[] BootImageOptionsArray { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IBootOptions>))] get; }
		}

		/// <summary>
		/// Use this interface to set or check the metadata and metadata mirror files in a UDF file system (rev 2.50 and later) to determine redundancy.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the metadata and metadata mirror files are set for redundancy, IMAPI creates identical copies of each in the file system
		/// image, which results in increased level of fault tolerance. In a scenario where the metadata files are not set for redundancy,
		/// IMAPI only creates a single copy in the file system image, which can save several MB of space on the burned disc.
		/// </para>
		/// <para>The metadata redundancy option is set to <c>TRUE</c> by default.</para>
		/// <para><c>IFileSystemImage3</c> is the default interface of <c>MsftFileSystemImage3</c> objects.</para>
		/// <para>
		/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifilesystemimage3
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFileSystemImage3")]
		[ComImport, Guid("7CFF842C-7E97-4807-8304-910DD8F7C051"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftFileSystemImage))]
		public interface IFileSystemImage3 : IFileSystemImage2
		{
			/// <summary>Retrieves the root directory item.</summary>
			/// <value>An IFsiDirectoryItem interface of the root directory item.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_root HRESULT get_Root(
			// IFsiDirectoryItem **pVal );
			[DispId(0)]
			new IFsiDirectoryItem Root { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Retrieves the starting block address for the recording session.</summary>
			/// <value>Starting block address for the recording session.</value>
			/// <remarks>
			/// <para>The session starting block can be set in the following ways:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Importing a file system automatically sets the session starting block.</term>
			/// </item>
			/// <item>
			/// <term>If the previous session is not imported, the client can call IFileSystemImage::put_SessionStartBlock to set this property.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_sessionstartblock HRESULT
			// get_SessionStartBlock( LONG *pVal );
			[DispId(1)]
			new int SessionStartBlock { get; set; }

			/// <summary>Retrieves the maximum number of blocks available for the image.</summary>
			/// <value>Number of blocks to use in creating the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_freemediablocks HRESULT
			// get_FreeMediaBlocks( LONG *pVal );
			[DispId(2)]
			new int FreeMediaBlocks { get; set; }

			/// <summary>Set maximum number of blocks available based on the capabilities of the recorder.</summary>
			/// <param name="discRecorder">
			/// An IDiscRecorder2 interface that identifies the recording device from which you want to set the maximum number of blocks available.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-setmaxmediablocksfromdevice HRESULT
			// SetMaxMediaBlocksFromDevice( IDiscRecorder2 *discRecorder );
			[DispId(36)]
			new void SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder);

			/// <summary>Retrieves the number of blocks in use.</summary>
			/// <value>Estimated number of blocks used in the file-system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_usedblocks HRESULT
			// get_UsedBlocks( LONG *pVal );
			[DispId(3)]
			new int UsedBlocks { get; }

			/// <summary>Retrieves or sets the volume name for this file system image.</summary>
			/// <value>String that contains the volume name for this file system image.</value>
			/// <remarks>To set the volume name, call the IFileSystemImage::put_VolumeName method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumename HRESULT
			// get_VolumeName( BSTR *pVal );
			[DispId(4)]
			new string VolumeName { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

			/// <summary>Retrieves the volume name provided from an imported file system.</summary>
			/// <value>
			/// String that contains the volume name provided from an imported file system. Is <c>NULL</c> until a file system is imported.
			/// </value>
			/// <remarks>
			/// The imported volume name is provided for user information and is not automatically carried forward to subsequent sessions.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_importedvolumename HRESULT
			// get_ImportedVolumeName( BSTR *pVal );
			[DispId(5)]
			new string ImportedVolumeName { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the boot image that you want to add to the file system image.</summary>
			/// <value>An IBootOptions interface of the boot image to add to the disc. Is <c>NULL</c> if a boot image has not been specified.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_bootimageoptions HRESULT
			// get_BootImageOptions( IBootOptions **pVal );
			[DispId(6)]
			new IBootOptions BootImageOptions { [return: MarshalAs(UnmanagedType.Interface)] get; set; }

			/// <summary>Retrieves the number of files in the file system image.</summary>
			/// <value>Number of files in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filecount HRESULT get_FileCount(
			// LONG *pVal );
			[DispId(7)]
			new int FileCount { get; }

			/// <summary>Retrieves the number of directories in the file system image.</summary>
			/// <value>Number of directories in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_directorycount HRESULT
			// get_DirectoryCount( LONG *pVal );
			[DispId(8)]
			new int DirectoryCount { get; }

			/// <summary>Retrieves the temporary directory in which stash files are built.</summary>
			/// <value>String that contains the path to the temporary directory.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_workingdirectory HRESULT
			// get_WorkingDirectory( BSTR *pVal );
			[DispId(9)]
			new string WorkingDirectory { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

			/// <summary>Retrieves the change point identifier.</summary>
			/// <value>Change point identifier. The identifier is a count of the changes to the file system image since its inception.</value>
			/// <remarks>
			/// <para>
			/// An application can store the value of this property prior to making a change to the file system, then at a later point pass
			/// the value to the IFileSystemImage::RollbackToChangePoint method to revert changes since that point in development.
			/// </para>
			/// <para>
			/// An application can call the IFileSystemImage::LockInChangePoint method to lock the state of a file system image at any point
			/// in its development. Once a lock is set, you cannot call RollbackToChangePoint to revert the file system image to its earlier state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_changepoint HRESULT
			// get_ChangePoint( LONG *pVal );
			[DispId(10)]
			new int ChangePoint { get; }

			/// <summary>Determines the compliance level for creating and developing the file-system image.</summary>
			/// <value>
			/// <para>Is VARIANT_TRUE if the file system images are created in strict compliance with applicable standards.</para>
			/// <para>Is VARIANT_FALSE if the compliance standards are relaxed to be compatible with IMAPI version 1.0.</para>
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_strictfilesystemcompliance
			// HRESULT get_StrictFileSystemCompliance( VARIANT_BOOL *pVal );
			[DispId(11)]
			new bool StrictFileSystemCompliance { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Determines if the file and directory names use a restricted character.</summary>
			/// <value>
			/// Is VARIANT_TRUE if the file and directory names to add to the file system image must consist of characters that map directly
			/// to CP_ANSI (code points 32 through 127). Otherwise, VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_userestrictedcharacterset
			// HRESULT get_UseRestrictedCharacterSet( VARIANT_BOOL *pVal );
			[DispId(12)]
			new bool UseRestrictedCharacterSet { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the types of file systems to create when generating the result stream.</summary>
			/// <value>
			/// One or more file system types to create when generating the result stream. For possible values, see the FsiFileSystems
			/// enumeration type.
			/// </value>
			/// <remarks>
			/// <para>
			/// To specify the file system types, call the IFileSystemImage::put_FileSystemsToCreate method. You could also call either
			/// IFilesystemImage::ChooseImageDefaults or IFilesystemImage::ChooseImageDefaultsForMediaType to have IMAPI choose the file
			/// system for you.
			/// </para>
			/// <para>To retrieve a list of supported file system types, call the IFileSystemImage::get_FileSystemsSupported method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filesystemstocreate HRESULT
			// get_FileSystemsToCreate( FsiFileSystems *pVal );
			[DispId(13)]
			new FsiFileSystems FileSystemsToCreate { get; set; }

			/// <summary>Retrieves the list of file system types that a client can use to build a file system image.</summary>
			/// <value>
			/// One or more file system types that a client can use to build a file system image. For possible values, see the
			/// FsiFileSystems enumeration type.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_filesystemssupported HRESULT
			// get_FileSystemsSupported( FsiFileSystems *pVal );
			[DispId(14)]
			new FsiFileSystems FileSystemsSupported { get; }

			/// <summary>Retrieves the UDF revision level of the imported file system image.</summary>
			/// <value>UDF revision level of the imported file system image.</value>
			/// <remarks>
			/// The value is encoded according to the UDF specification, except the variable size is LONG. For example, revision level 1.02
			/// is represented as 0x102.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_udfrevision HRESULT
			// get_UDFRevision( LONG *pVal );
			[DispId(37)]
			new int UDFRevision { set; get; }

			/// <summary>Retrieves a list of supported UDF revision levels.</summary>
			/// <value>
			/// List of supported UDF revision levels. Each element of the list is VARIANT. The variant type is <c>VT_I4</c>. The
			/// <c>lVal</c> member of the variant contains the revision level.
			/// </value>
			/// <remarks>
			/// The value is encoded according to the UDF specification, except the variable size is LONG. For example, revision level 1.02
			/// is represented as 0x102.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_udfrevisionssupported HRESULT
			// get_UDFRevisionsSupported( SAFEARRAY **pVal );
			[DispId(31)]
			new int[] UDFRevisionsSupported { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<int>))] get; }

			/// <summary>Sets the default file system types and the image size based on the current media.</summary>
			/// <param name="discRecorder">An IDiscRecorder2 the identifies the device that contains the current media.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-chooseimagedefaults HRESULT
			// ChooseImageDefaults( IDiscRecorder2 *discRecorder );
			[DispId(32)]
			new void ChooseImageDefaults(IDiscRecorder2 discRecorder);

			/// <summary>Sets the default file system types and the image size based on the specified media type.</summary>
			/// <param name="value">
			/// Identifies the physical media type that will receive the burn image. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPE
			/// enumeration type.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-chooseimagedefaultsformediatype
			// HRESULT ChooseImageDefaultsForMediaType( IMAPI_MEDIA_PHYSICAL_TYPE value );
			[DispId(33)]
			new void ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value);

			/// <summary>Retrieves the ISO9660 compatibility level to use when creating the result image.</summary>
			/// <value>Identifies the interchange level of the ISO9660 file system.</value>
			/// <remarks>
			/// For a list of supported compatibility levels, call the IFileSystemImage::get_ISO9660InterchangeLevelsSupported method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_iso9660interchangelevel HRESULT
			// get_ISO9660InterchangeLevel( LONG *pVal );
			[DispId(34)]
			new int ISO9660InterchangeLevel { set; get; }

			/// <summary>Retrieves the supported ISO9660 compatibility levels.</summary>
			/// <value>
			/// List of supported ISO9660 compatibility levels. Each item in the list is a VARIANT that identifies one supported interchange
			/// level. The variant type is <c>VT_UI4</c>. The <c>ulVal</c> member of the variant contains the compatibility level.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_iso9660interchangelevelssupported
			// HRESULT get_ISO9660InterchangeLevelsSupported( SAFEARRAY **pVal );
			[DispId(38)]
			new uint[] ISO9660InterchangeLevelsSupported { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<uint>))] get; }

			/// <summary>Create the result object that contains the file system and file data.</summary>
			/// <returns>
			/// <para>An IFileSystemImageResult interface of the image result.</para>
			/// <para>Client applications can stream the image to media or other long-term storage devices, such as disk drives.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Currently, <c>IFileSystemImage::CreateResultImage</c> will require disc media access as a result of a previous
			/// IFileSystemImage::IdentifyFileSystemsOnDisc method call. To resolve this issue, it is recommended that another
			/// IFileSystemImage object be created specifically for the <c>IFileSystemImage::IdentifyFileSystemsOnDisc</c> operation.
			/// </para>
			/// <para>
			/// The resulting stream can be saved as an ISO file if the file system is generated in a single session and has a start address
			/// of zero.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createresultimage HRESULT
			// CreateResultImage( IFileSystemImageResult **resultStream );
			[DispId(15)]
			new IFileSystemImageResult CreateResultImage();

			/// <summary>Checks for the existence of a given file or directory.</summary>
			/// <param name="fullPath">String that contains the fully qualified path of the directory or file to check.</param>
			/// <returns>
			/// Indicates if the item is a file, a directory, or does not exist. For possible values, see the FsiItemType enumeration type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-exists HRESULT Exists( BSTR
			// fullPath, FsiItemType *itemType );
			[DispId(16)]
			new FsiItemType Exists([MarshalAs(UnmanagedType.BStr)] string fullPath);

			/// <summary>Retrieves a string that identifies a disc and the sessions recorded on the disc.</summary>
			/// <returns>
			/// String that contains a signature that identifies the disc and the sessions on it. This string is not guaranteed to be unique
			/// between discs.
			/// </returns>
			/// <remarks>
			/// <para>
			/// When layering sessions on a disc, the signature acts as a key that the client can use to ensure the session order, and to
			/// distinguish sessions on disc from session images that will be laid on the disc.
			/// </para>
			/// <para>You must call IFileSystemImage::put_MultisessionInterfaces prior to calling <c>CalculateDiscIdentifier</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-calculatediscidentifier HRESULT
			// CalculateDiscIdentifier( BSTR *discIdentifier );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string CalculateDiscIdentifier();

			/// <summary>Retrieves a list of the different types of file systems on the optical media.</summary>
			/// <param name="discRecorder">
			/// An IDiscRecorder2 interface that identifies the recording device that contains the media. If this parameter is <c>NULL</c>,
			/// the discRecorder specified in IMultisession will be used.
			/// </param>
			/// <returns>One or more files systems on the disc. For possible values, see FsiFileSystems enumeration type.</returns>
			/// <remarks>
			/// Client applications can call IFileSystemImage::GetDefaultFileSystemForImport with the value returned by this method to
			/// determine the type of file system to import.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-identifyfilesystemsondisc HRESULT
			// IdentifyFileSystemsOnDisc( IDiscRecorder2 *discRecorder, FsiFileSystems *fileSystems );
			[DispId(19)]
			new FsiFileSystems IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder);

			/// <summary>Retrieves the file system to import by default.</summary>
			/// <param name="fileSystems">One or more file system values. For possible values, see the FsiFileSystems enumeration type.</param>
			/// <returns>
			/// A single file system value that identifies the default file system. The value is one of the file systems specified in fileSystems
			/// </returns>
			/// <remarks>
			/// <para>Use this method to identify the default file system to use with IFileSystemImage::ImportFileSystem.</para>
			/// <para>To identify the supported file systems, call the IFileSystemImage::get_FileSystemsSupported method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-getdefaultfilesystemforimport
			// HRESULT GetDefaultFileSystemForImport( FsiFileSystems fileSystems, FsiFileSystems *importDefault );
			[DispId(20)]
			new FsiFileSystems GetDefaultFileSystemForImport(FsiFileSystems fileSystems);

			/// <summary>Imports the default file system on the current disc.</summary>
			/// <returns>Identifies the imported file system. For possible values, see the FsiFileSystems enumeration type.</returns>
			/// <remarks>
			/// <para>
			/// You must call IFileSystemImage::put_MultisessionInterfaces prior to calling <c>IFileSystemImage::ImportFileSystem</c>.
			/// Additionally, it is recommended that IDiscFormat2::get_MediaHeuristicallyBlank is called before
			/// <c>IFileSystemImage::put_MultisessionInterfaces</c> to verify that the media is not blank.
			/// </para>
			/// <para>
			/// If the disc contains more than one file system, only one file system is imported. This method chooses the file system to
			/// import in the following order: UDF, Joliet, ISO 9660. The import includes transferring directories and files to the
			/// in-memory file system structure.
			/// </para>
			/// <para>
			/// You may call this method at any time during the construction of the in-memory file system. If, during import, a file or
			/// directory already exists in the in-memory copy, the in-memory version will be retained; the imported file will be discarded.
			/// </para>
			/// <para>
			/// To determine which file system is the default file system for the disc, call the
			/// IFileSystemImage::GetDefaultFileSystemForImport method.
			/// </para>
			/// <para>
			/// This method only reads the file information. If the item is a file, the file data is copied when calling
			/// IFsiDirectoryItem::AddFile, IFsiDirectoryItem::AddTree, or IFsiDirectoryItem::Add method.
			/// </para>
			/// <para>
			/// This method returns <c>IMAPI_E_NO_SUPPORTED_FILE_SYSTEM</c> if a supported file system is not found in the last session.
			/// Additionally, this method returns <c>IMAPI_E_INCOMPATIBLE_PREVIOUS_SESSION</c> if the layout of the file system in the last
			/// session is incompatible with the layout used by IMAPI for the creation of requested file systems for the result image. For
			/// more details see the IFileSystemImage::put_FileSystemsToCreate method documention.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-importfilesystem HRESULT
			// ImportFileSystem( FsiFileSystems *importedFileSystem );
			[DispId(21)]
			new FsiFileSystems ImportFileSystem();

			/// <summary>Import a specific file system from disc.</summary>
			/// <param name="fileSystemToUse">
			/// Identifies the file system to import. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <remarks>
			/// <para>
			/// You must call IFileSystemImage::put_MultisessionInterfaces prior to calling
			/// <c>IFileSystemImage::ImportSpecificFileSystem</c>. Additionally, it is recommended that
			/// IDiscFormat2::get_MediaHeuristicallyBlank is called before <c>IFileSystemImage::put_MultisessionInterfaces</c> to verify
			/// that the media is not blank.
			/// </para>
			/// <para>
			/// You may call this method at any time during the construction of the in-memory file system. If, during import, a file or
			/// directory already exists in the in-memory copy, the in-memory version will be retained; the imported file will be discarded.
			/// </para>
			/// <para>
			/// On re-writable media (DVD+/-RW, DVDRAM, BD-RE), import or burning a second session is not support if the first session has
			/// an ISO9660 file system, due to file system limitations.
			/// </para>
			/// <para>
			/// This method only reads the file information. If the item is a file, the file data is copied when calling
			/// IFsiDirectoryItem::AddFile, IFsiDirectoryItem::AddTree, or IFsiDirectoryItem::Add method.
			/// </para>
			/// <para>
			/// this method returns <c>IMAPI_E_INCOMPATIBLE_PREVIOUS_SESSION</c> if the layout of the file system in the last session is
			/// incompatible with the layout used by IMAPI for the creation of requested file systems for the result image. For more details
			/// see the IFileSystemImage::put_FileSystemsToCreate method documention. If the file system specified by fileSystemToUse has
			/// not been found, this method returns <c>IMAPI_E_FILE_SYSTEM_NOT_FOUND</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-importspecificfilesystem HRESULT
			// ImportSpecificFileSystem( FsiFileSystems fileSystemToUse );
			[DispId(22)]
			new void ImportSpecificFileSystem(FsiFileSystems fileSystemToUse);

			/// <summary>Reverts the image back to the specified change point.</summary>
			/// <param name="changePoint">Change point that identifies the target state for rollback.</param>
			/// <remarks>
			/// <para>
			/// Typically, an application calls the IFileSystemImage::get_ChangePoint method and stores the change point value prior to
			/// making a change to the file system. If necessary, you can pass the change point value to this method to revert changes since
			/// that point in development.
			/// </para>
			/// <para>
			/// An application can call the IFileSystemImage::LockInChangePoint method to lock the state of a file system image at any point
			/// in its development. After a lock is set, you cannot call this method to revert the file system image to its earlier state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-rollbacktochangepoint HRESULT
			// RollbackToChangePoint( LONG changePoint );
			[DispId(23)]
			new void RollbackToChangePoint(int changePoint);

			/// <summary>Locks the file system information at the current change-point level.</summary>
			/// <remarks>
			/// <para>Once the change point is locked, rollback to earlier change points is not permitted.</para>
			/// <para>Locking the change point does not change the IFileSystemImage::get_ChangePoint property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-lockinchangepoint HRESULT LockInChangePoint();
			[DispId(24)]
			new void LockInChangePoint();

			/// <summary>Create a directory item with the specified name.</summary>
			/// <param name="name">String that contains the name of the directory item to create.</param>
			/// <returns>
			/// An IFsiDirectoryItem interface of the new directory item. When done, call the <c>IFsiDirectoryItem::Release</c> method to
			/// release the interface.
			/// </returns>
			/// <remarks>
			/// After setting properties on the IFsiDirectoryItem interface, call the IFsiDirectoryItem::Add method on the parent directory
			/// item to add it to the file system image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createdirectoryitem HRESULT
			// CreateDirectoryItem( BSTR name, IFsiDirectoryItem **newItem );
			[DispId(25)]
			new IFsiDirectoryItem CreateDirectoryItem([MarshalAs(UnmanagedType.BStr)] string name);

			/// <summary>Create a file item with the specified name.</summary>
			/// <param name="name">String that contains the name of the file item to create.</param>
			/// <returns>
			/// An IFsiFileItem interface of the new file item. When done, call the <c>IFsiFileItem::Release</c> method to release the interface.
			/// </returns>
			/// <remarks>
			/// After setting properties on the IFsiFileItem interface, call the IFsiDirectoryItem::Add method on the parent directory item
			/// to add it to the file system image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-createfileitem HRESULT
			// CreateFileItem( BSTR name, IFsiFileItem **newItem );
			[DispId(26)]
			new IFsiFileItem CreateFileItem([MarshalAs(UnmanagedType.BStr)] string name);

			/// <summary>Retrieves the volume name for the UDF system image.</summary>
			/// <value>String that contains the volume name for the UDF system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenameudf HRESULT
			// get_VolumeNameUDF( BSTR *pVal );
			[DispId(27)]
			new string VolumeNameUDF { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the volume name for the Joliet system image.</summary>
			/// <value>String that contains the volume name for the Joliet system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenamejoliet HRESULT
			// get_VolumeNameJoliet( BSTR *pVal );
			[DispId(28)]
			new string VolumeNameJoliet { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the volume name for the ISO9660 system image.</summary>
			/// <value>String that contains the volume name for the ISO9660 system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_volumenameiso9660 HRESULT
			// get_VolumeNameISO9660( BSTR *pVal );
			[DispId(29)]
			new string VolumeNameISO9660 { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Indicates if the files being added to the file system image should be staged before the burn.</summary>
			/// <value>
			/// <c>VARIANT_TRUE</c> if the files being added to the file system image are required to be stageded in one or more stage files
			/// before burning. Otherwise, <c>VARIANT_FALSE</c> is returned if IMAPI is permitted to optimize the image creation process by
			/// not staging the files being added to the file system image.
			/// </value>
			/// <remarks>
			/// <para>
			/// "Staging" is a process in which an image is created on the hard-drive, containing all files to be burned, prior to the
			/// initiation of the burn operation.
			/// </para>
			/// <para>
			/// Setting this this property to <c>VARIANT_TRUE</c> via IFileSystemImage::put_StageFiles will only affect files that are added
			/// after the property is set: those files will always be staged. Files that were not staged prior to a specified property value
			/// of <c>VARIANT_TRUE</c>, will not be staged.
			/// </para>
			/// <para>By specifying <c>VARIANT_FALSE</c>, the file system image creation process is optimized in two ways:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Less time is required for image generation</term>
			/// </item>
			/// <item>
			/// <term>Less space is consumed on a local disk by IMAPI</term>
			/// </item>
			/// </list>
			/// <para>
			/// However, in order to avoid buffer underrun problems during burning, a certain minimum throughput is required for read
			/// operations on non-staged files. In the event that file accessibility or throughput may not meet the requirements of the
			/// burner, IMAPI enforces file staging regardless of the specified property value. For example, file staging is enforced for
			/// source files from removable storage devices, such as USB Flash Disk.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_stagefiles HRESULT
			// get_StageFiles( VARIANT_BOOL *pVal );
			[DispId(30)]
			new bool StageFiles { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the list of multi-session interfaces for the optical media.</summary>
			/// <value>
			/// List of multi-session interfaces for the optical media. Each element of the list is a <c>VARIANT</c> of type
			/// <c>VT_Dispatch</c>. Query the <c>pdispVal</c> member of the variant for the IMultisession interface.
			/// </value>
			/// <remarks>
			/// Query the IMultisession interface for a derived <c>IMultisession</c> interface, for example, the IMultisessionSequential interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage-get_multisessioninterfaces HRESULT
			// get_MultisessionInterfaces( SAFEARRAY **pVal );
			[DispId(40)]
			new IMultisession[] MultisessionInterfaces { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMultisession>))] get; set; }

			/// <summary>Retrieves the boot option array that will be utilized to generate the file system image.</summary>
			/// <value>
			/// Pointer to a boot option array that contains a list of IBootOptions interfaces of boot images used to generate the file
			/// system image. Each element of the list is a <c>VARIANT</c> of type <c>VT_DISPATCH</c>.
			/// </value>
			/// <remarks>
			/// The <c>SAFEARRAY</c> will be a one-dimensional array. If a boot image is not specified, a zero-sized array will be returned.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage2-get_bootimageoptionsarray HRESULT
			// get_BootImageOptionsArray( SAFEARRAY **pVal );
			[DispId(60)]
			new IBootOptions[] BootImageOptionsArray { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IBootOptions>))] get; }

			/// <summary>Retrieves a property value that specifies if the UDF Metadata will be redundant in the file system image.</summary>
			/// <value>
			/// Pointer to a value that specifies if the UDF metadata is redundant in the resultant file system image. A value of
			/// <c>VARIANT_TRUE</c> indicates that UDF metadata will be redundant; otherwise, <c>VARIANT_FALSE</c>.
			/// </value>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage3-get_createredundantudfmetadatafiles
			// HRESULT get_CreateRedundantUdfMetadataFiles( VARIANT_BOOL *pVal );
			[DispId(61)]
			bool CreateRedundantUdfMetadataFiles { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Determines if a specific file system on the current media is appendable through the IMAPI.</summary>
			/// <param name="fileSystemToProbe">The file system on the current media to probe.</param>
			/// <returns>A <c>VARIANT_BOOL</c> value specifying if the specified file system is appendable.</returns>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimage3-probespecificfilesystem HRESULT
			// ProbeSpecificFileSystem( FsiFileSystems fileSystemToProbe, VARIANT_BOOL *isAppendable );
			[DispId(70)]
			[return: MarshalAs(UnmanagedType.VariantBool)]
			bool ProbeSpecificFileSystem(FsiFileSystems fileSystemToProbe);
		}

		/// <summary>
		/// <para>Use this interface to get information about the burn image, the image data stream, and progress information.</para>
		/// <para>To get this interface, call the IFileSystemImage::CreateResultImage method.</para>
		/// </summary>
		/// <remarks>This is an <c>FileSystemImageResult</c> object in script.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifilesystemimageresult
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFileSystemImageResult")]
		[ComImport, Guid("2C941FD8-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(FileSystemImageResult))]
		public interface IFileSystemImageResult
		{
			/// <summary>Retrieves the burn image stream.</summary>
			/// <value>An IStream interface of the burn image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_imagestream HRESULT
			// get_ImageStream( IStream **pVal );
			[DispId(1)]
			IStream ImageStream { get; }

			/// <summary>Retrieves the progress item block mapping collection.</summary>
			/// <value>
			/// An IProgressItems interface that contains a collection of progress items. Each progress item identifies the blocks written
			/// since the previous progress status was taken.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_progressitems HRESULT
			// get_ProgressItems( IProgressItems **pVal );
			[DispId(2)]
			IProgressItems ProgressItems { get; }

			/// <summary>Retrieves the number of blocks in the result image.</summary>
			/// <value>Number of blocks to burn on the disc.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_totalblocks HRESULT
			// get_TotalBlocks( LONG *pVal );
			[DispId(3)]
			int TotalBlocks { get; }

			/// <summary>Retrieves the size, in bytes, of a block of data.</summary>
			/// <value>Number of bytes in a block.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_blocksize HRESULT
			// get_BlockSize( LONG *pVal );
			[DispId(4)]
			int BlockSize { get; }

			/// <summary>Retrieves the disc volume name for this file system image.</summary>
			/// <value>String that contains the volume name for this file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_discid HRESULT get_DiscId(
			// BSTR *pVal );
			[DispId(5)]
			string DiscId { [return: MarshalAs(UnmanagedType.BStr)] get; }
		}

		/// <summary>
		/// The <c>IFileSystemImageResult2</c> interface allows the data recorder object to retrieve information about modified blocks in
		/// images created for rewritable discs. Alternatively, <c>IUnknown::QueryInterface</c> can be called on the object returned by
		/// IFileSystemImageResult::get_ImageStream to get the IBlockRangeList interface providing this information.
		/// </summary>
		/// <remarks>
		/// When the file system image object is used to append data to a rewritable disc, the result image contains both the previous
		/// logical session and the new additions. The result image represents the binary data that must be recorded to disc starting from
		/// sector 0 to get a disc containing both old and new files. However, the previous logical session remains mostly intact during
		/// addition of new files, so the burn time can be substantially optimized by recording only the sectors that are new or have been modified.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifilesystemimageresult2
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFileSystemImageResult2")]
		[ComImport, Guid("B507CA29-2204-11DD-966A-001AA01BBC58"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(FileSystemImageResult))]
		public interface IFileSystemImageResult2 : IFileSystemImageResult
		{
			/// <summary>Retrieves the burn image stream.</summary>
			/// <value>An IStream interface of the burn image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_imagestream HRESULT
			// get_ImageStream( IStream **pVal );
			[DispId(1)]
			new IStream ImageStream { get; }

			/// <summary>Retrieves the progress item block mapping collection.</summary>
			/// <value>
			/// An IProgressItems interface that contains a collection of progress items. Each progress item identifies the blocks written
			/// since the previous progress status was taken.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_progressitems HRESULT
			// get_ProgressItems( IProgressItems **pVal );
			[DispId(2)]
			new IProgressItems ProgressItems { get; }

			/// <summary>Retrieves the number of blocks in the result image.</summary>
			/// <value>Number of blocks to burn on the disc.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_totalblocks HRESULT
			// get_TotalBlocks( LONG *pVal );
			[DispId(3)]
			new int TotalBlocks { get; }

			/// <summary>Retrieves the size, in bytes, of a block of data.</summary>
			/// <value>Number of bytes in a block.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_blocksize HRESULT
			// get_BlockSize( LONG *pVal );
			[DispId(4)]
			new int BlockSize { get; }

			/// <summary>Retrieves the disc volume name for this file system image.</summary>
			/// <value>String that contains the volume name for this file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult-get_discid HRESULT get_DiscId(
			// BSTR *pVal );
			[DispId(5)]
			new string DiscId { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the list of modified blocks in the result image.</summary>
			/// <value>Pointer to an IBlockRangeList interface representing the modified block ranges in the result image.</value>
			/// <remarks>
			/// This method returns <c>E_NOTIMPL</c> if the entire result image must be recorded. If this method returns a successful return
			/// code, it is sufficient to record only the sectors described by IBlockRangeList returned in pVal. It is highly recommended to
			/// record the sector ranges in exactly the same order as they are listed in <c>IBlockRangeList</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifilesystemimageresult2-get_modifiedblocks HRESULT
			// get_ModifiedBlocks( IBlockRangeList **pVal );
			[DispId(6)]
			IBlockRangeList ModifiedBlocks { [return: MarshalAs(UnmanagedType.Interface)] get; }
		}

		/// <summary>
		/// <para>Use this interface to add items to or remove items from the file-system image.</para>
		/// <para>To get this interface, call the IFileSystemImage::CreateDirectoryItem method.</para>
		/// </summary>
		/// <remarks>
		/// <para>Each directory item contains an enumerable collection of child items within the directory.</para>
		/// <para>You can add and remove files and directories only after the directory item has been added to the file system image.</para>
		/// <para>This is an <c>FsiDirectoryItem</c> object in script.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifsidirectoryitem
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFsiDirectoryItem")]
		[ComImport, Guid("2C941FDC-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(FsiDirectoryItem))]
		public interface IFsiDirectoryItem : IFsiItem, IEnumerable
		{
			/// <summary>Retrieves the name of the directory or file item in the file system image.</summary>
			/// <value>String that contains the name of the file or directory item in the file system image.</value>
			/// <remarks>To get the full path to the item, call the IFsiItem::get_FullPath method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_name HRESULT get_Name( BSTR *pVal );
			[DispId(11)]
			new string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the full path of the file or directory item in the file system image.</summary>
			/// <value>String that contains the absolute path of the file or directory item in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_fullpath HRESULT get_FullPath( BSTR
			// *pVal );
			[DispId(12)]
			new string FullPath { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets or sets the date and time that the directory or file item was created and added to the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was created and added to the file system image, according to UTC time.
			/// Defaults to the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// IMAPI does not support the extended attribute for CreationTime, and as a result, UDFS populates the CreationTime with the
			/// value expressed by the LastAccessed property from the file entry.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_creationtime HRESULT put_CreationTime(
			// DATE newVal );
			[DispId(13)]
			new DateTime CreationTime { get; set; }

			/// <summary>Gets or sets the date and time that the directory or file item was last accessed in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last accessed in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// UDFS (UDF) uses the LastAccessedTime value for the CreationTime, as IMAPI does not currently support the CreationTime
			/// extended attribue.
			/// </para>
			/// <para>
			/// CDFS (ISO 9660) sets the LastAccessedTime value to 0, as only the recording time is stored within the File/Directory descriptor.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastaccessedtime HRESULT
			// put_LastAccessedTime( DATE newVal );
			[DispId(14)]
			new DateTime LastAccessedTime { get; set; }

			/// <summary>Gets or sets the date and time that the item was last modified in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last modified in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// The last modified time is propagated to the attribute that users see when viewing the properties of a directory or a file.
			/// </para>
			/// <para>When implementing this method, a few things should be taken into consideration:</para>
			/// <para>UDFS (UDF) will use the value provided by <c>IFsiItem::put_LastModifiedTime</c> as both the CreationTime and LastModifiedTime.</para>
			/// <para>
			/// CDFS (ISO 9660) uses the date/time of recording as the CreationTime and LastModifiedTime. As a result, CDFS sets the value
			/// of LastModifiedTime to 0.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastmodifiedtime HRESULT
			// put_LastModifiedTime( DATE newVal );
			[DispId(15)]
			new DateTime LastModifiedTime { get; set; }

			/// <summary>Determines if the item's hidden attribute is set in the file system image.</summary>
			/// <value>
			/// Set to VARIANT_TRUE to set the hidden attribute of the item in the file system image; otherwise, VARIANT_FALSE. The default
			/// is VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_ishidden HRESULT put_IsHidden(
			// VARIANT_BOOL newVal );
			[DispId(16)]
			new bool IsHidden { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the name of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the name should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the name of the item as it conforms to the specified file system. The name in the IFsiItem::get_Name
			/// property is modified if the characters used and its length do not meet the requirements of the specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystemname HRESULT FileSystemName(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemName(FsiFileSystems fileSystem);

			/// <summary>Retrieves the full path of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the path should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the full path of the item as it conforms to the specified file system. The path in the
			/// IFsiItem::get_FullPath property is modified if the characters used and its length do not meet the requirements of the
			/// specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystempath HRESULT FileSystemPath(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemPath(FsiFileSystems fileSystem);

			/// <summary>Retrieves a list of child items contained within the directory in the file system image.</summary>
			/// <returns>
			/// An <c>IEnumVariant</c> interface that you use to enumerate the child items contained within the directory. The items of the
			/// enumeration are variants whose type is <c>VT_BSTR</c>. Use the <c>bstrVal</c> member to retrieve the path to the child item.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The enumeration is a snapshot of the children contained in the directory at the time of the call and will not reflect
			/// children that are added and removed.
			/// </para>
			/// <para>To retrieve a single item, see the IFsiDirectoryItem::get_Item property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get__newenum HRESULT get__NewEnum(
			// IEnumVARIANT **NewEnum );
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnumeratorToEnumVariantMarshaler))]
			new IEnumerator GetEnumerator();

			/// <summary>Retrieves the specified directory or file item from file system image.</summary>
			/// <param name="path">String that contains the path to the item to retrieve.</param>
			/// <value>An IFsiItem interface of the requested directory or file item.</value>
			/// <remarks>
			/// <para>
			/// To determine whether the item is a file item or directory item, call the IFsiItem::QueryInterface method passing
			/// __uuidof(IFsiDirectoryItem) as the interface identifier. If the call succeeds, the item is a directory item; otherwise, the
			/// item is a file item.
			/// </para>
			/// <para>To enumerate all children, call the IFsiDirectoryItem::get__NewEnum method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get_item HRESULT get_Item( BSTR
			// path, IFsiItem **item );
			[DispId(0)]
			IFsiItem this[string path] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Number of child items in the enumeration.</summary>
			/// <value>Number of directory and file items within the directory in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get_count HRESULT get_Count( LONG
			// *Count );
			[DispId(1)]
			int Count { get; }

			/// <summary>Retrieves a list of child items contained within the directory in the file system image.</summary>
			/// <value>
			/// An IEnumFsiItems interface that contains a collection of the child directory and file items contained within the directory.
			/// </value>
			/// <remarks>
			/// This property returns the same results as the IFsiDirectoryItem::get__NewEnum property and is meant for use by C/C++ applications.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get_enumfsiitems HRESULT
			// get_EnumFsiItems( IEnumFsiItems **NewEnum );
			[DispId(2)]
			IEnumFsiItems EnumFsiItems { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Adds a directory to the file system image.</summary>
			/// <param name="path">
			/// <para>String that contains the relative path of directory to create.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <remarks>The parent directory for the new subdirectory must already exist within the file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-adddirectory HRESULT AddDirectory(
			// BSTR path );
			[DispId(30)]
			void AddDirectory([MarshalAs(UnmanagedType.BStr)] string path);

			/// <summary>Adds a file to the file system image.</summary>
			/// <param name="path">
			/// <para>String that contains the relative path of the directory to contain the new file.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <param name="fileData">An <c>IStream</c> interface of the file (data stream) to write to the media.</param>
			/// <remarks>The directory that will contain the new file must already exist within the file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-addfile HRESULT AddFile( BSTR path,
			// IStream *fileData );
			[DispId(31)]
			void AddFile([MarshalAs(UnmanagedType.BStr)] string path, IStream fileData);

			/// <summary>Adds the contents of a directory tree to the file system image.</summary>
			/// <param name="sourceDirectory">
			/// <para>String that contains the relative path of the directory tree to create.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <param name="includeBaseDirectory">
			/// Set to VARIANT_TRUE to include the directory in sourceDirectory as a subdirectory in the file system image. Otherwise, VARIANT_FALSE.
			/// </param>
			/// <remarks>
			/// <para>The parent directory for the new subdirectory must already exist within the file system image.</para>
			/// <para>The subdirectory structure within specified source directory is implicitly mirrored in the file system image.</para>
			/// <para>
			/// If file or directory collisions occur, the content of the specified source directory prevails. The file system image is
			/// overwritten with the appropriate directories and files from the source directory.
			/// </para>
			/// <para>If an exception occurs during processing, the file system image reverts to its previous state.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-addtree HRESULT AddTree( BSTR
			// sourceDirectory, VARIANT_BOOL includeBaseDirectory );
			[DispId(32)]
			void AddTree([MarshalAs(UnmanagedType.BStr)] string sourceDirectory, [MarshalAs(UnmanagedType.VariantBool)] bool includeBaseDirectory);

			/// <summary>Adds a file or directory described by the IFsiItem object to the file system image.</summary>
			/// <param name="item">An IFsiItem interface of the IFsiFileItemor IFsiDirectoryItem to add to the file system image.</param>
			/// <remarks>
			/// <para>
			/// To create a directory item or file item, call the IFileSystemImage::CreateDirectoryItem or IFileSystemImage::CreateFileItem
			/// method, respectively.
			/// </para>
			/// <para>Once an item is added to the file system image, the IFsiFileItem::get_Data property becomes read-only.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-add HRESULT Add( IFsiItem *item );
			[DispId(33)]
			void Add(IFsiItem item);

			/// <summary>Removes the specified item from the file system image.</summary>
			/// <param name="path">
			/// <para>String that contains the relative path of the item to remove. The path is relative to current directory item.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <remarks>This method is only callable on directory items present in the file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-remove HRESULT Remove( BSTR path );
			[DispId(34)]
			void Remove([MarshalAs(UnmanagedType.BStr)] string path);

			/// <summary>Remove the specified directory tree from the file system image.</summary>
			/// <param name="path">String that contains the name of directory to remove. The path is relative to current directory item.</param>
			/// <remarks>
			/// <para>The directory item must be present in the file system image.</para>
			/// <para>
			/// You can delete the entire file-system image by calling this method for the root directory item and setting the path to a
			/// single path delimiter (\).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-removetree HRESULT RemoveTree( BSTR
			// path );
			[DispId(35)]
			void RemoveTree([MarshalAs(UnmanagedType.BStr)] string path);
		}

		/// <summary>
		/// Use this interface to add a directory tree, which includes all sub-directories, files, and associated named streams to a file
		/// system image.
		/// </summary>
		/// <remarks>
		/// <para>
		/// All sub-directories, files, and associated named streams can only be added after the directory item has been added to the file
		/// system image.
		/// </para>
		/// <para>
		/// UDF must be enabled and set to UDF revision 2.00 or later in order to enable named stream support during the creation of the
		/// file system image.
		/// </para>
		/// <para>
		/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifsidirectoryitem2
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFsiDirectoryItem2")]
		[ComImport, Guid("F7FB4B9B-6D96-4d7b-9115-201B144811EF"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(FsiDirectoryItem))]
		public interface IFsiDirectoryItem2 : IFsiDirectoryItem
		{
			/// <summary>Retrieves the name of the directory or file item in the file system image.</summary>
			/// <value>String that contains the name of the file or directory item in the file system image.</value>
			/// <remarks>To get the full path to the item, call the IFsiItem::get_FullPath method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_name HRESULT get_Name( BSTR *pVal );
			[DispId(11)]
			new string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the full path of the file or directory item in the file system image.</summary>
			/// <value>String that contains the absolute path of the file or directory item in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_fullpath HRESULT get_FullPath( BSTR
			// *pVal );
			[DispId(12)]
			new string FullPath { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets or sets the date and time that the directory or file item was created and added to the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was created and added to the file system image, according to UTC time.
			/// Defaults to the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// IMAPI does not support the extended attribute for CreationTime, and as a result, UDFS populates the CreationTime with the
			/// value expressed by the LastAccessed property from the file entry.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_creationtime HRESULT put_CreationTime(
			// DATE newVal );
			[DispId(13)]
			new DateTime CreationTime { get; set; }

			/// <summary>Gets or sets the date and time that the directory or file item was last accessed in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last accessed in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// UDFS (UDF) uses the LastAccessedTime value for the CreationTime, as IMAPI does not currently support the CreationTime
			/// extended attribue.
			/// </para>
			/// <para>
			/// CDFS (ISO 9660) sets the LastAccessedTime value to 0, as only the recording time is stored within the File/Directory descriptor.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastaccessedtime HRESULT
			// put_LastAccessedTime( DATE newVal );
			[DispId(14)]
			new DateTime LastAccessedTime { get; set; }

			/// <summary>Gets or sets the date and time that the item was last modified in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last modified in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// The last modified time is propagated to the attribute that users see when viewing the properties of a directory or a file.
			/// </para>
			/// <para>When implementing this method, a few things should be taken into consideration:</para>
			/// <para>UDFS (UDF) will use the value provided by <c>IFsiItem::put_LastModifiedTime</c> as both the CreationTime and LastModifiedTime.</para>
			/// <para>
			/// CDFS (ISO 9660) uses the date/time of recording as the CreationTime and LastModifiedTime. As a result, CDFS sets the value
			/// of LastModifiedTime to 0.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastmodifiedtime HRESULT
			// put_LastModifiedTime( DATE newVal );
			[DispId(15)]
			new DateTime LastModifiedTime { get; set; }

			/// <summary>Determines if the item's hidden attribute is set in the file system image.</summary>
			/// <value>
			/// Set to VARIANT_TRUE to set the hidden attribute of the item in the file system image; otherwise, VARIANT_FALSE. The default
			/// is VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_ishidden HRESULT put_IsHidden(
			// VARIANT_BOOL newVal );
			[DispId(16)]
			new bool IsHidden { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the name of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the name should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the name of the item as it conforms to the specified file system. The name in the IFsiItem::get_Name
			/// property is modified if the characters used and its length do not meet the requirements of the specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystemname HRESULT FileSystemName(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemName(FsiFileSystems fileSystem);

			/// <summary>Retrieves the full path of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the path should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the full path of the item as it conforms to the specified file system. The path in the
			/// IFsiItem::get_FullPath property is modified if the characters used and its length do not meet the requirements of the
			/// specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystempath HRESULT FileSystemPath(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemPath(FsiFileSystems fileSystem);

			/// <summary>Retrieves a list of child items contained within the directory in the file system image.</summary>
			/// <returns>
			/// An <c>IEnumVariant</c> interface that you use to enumerate the child items contained within the directory. The items of the
			/// enumeration are variants whose type is <c>VT_BSTR</c>. Use the <c>bstrVal</c> member to retrieve the path to the child item.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The enumeration is a snapshot of the children contained in the directory at the time of the call and will not reflect
			/// children that are added and removed.
			/// </para>
			/// <para>To retrieve a single item, see the IFsiDirectoryItem::get_Item property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get__newenum HRESULT get__NewEnum(
			// IEnumVARIANT **NewEnum );
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnumeratorToEnumVariantMarshaler))]
			new IEnumerator GetEnumerator();

			/// <summary>Retrieves the specified directory or file item from file system image.</summary>
			/// <param name="path">String that contains the path to the item to retrieve.</param>
			/// <value>An IFsiItem interface of the requested directory or file item.</value>
			/// <remarks>
			/// <para>
			/// To determine whether the item is a file item or directory item, call the IFsiItem::QueryInterface method passing
			/// __uuidof(IFsiDirectoryItem) as the interface identifier. If the call succeeds, the item is a directory item; otherwise, the
			/// item is a file item.
			/// </para>
			/// <para>To enumerate all children, call the IFsiDirectoryItem::get__NewEnum method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get_item HRESULT get_Item( BSTR
			// path, IFsiItem **item );
			[DispId(0)]
			new IFsiItem this[string path] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Number of child items in the enumeration.</summary>
			/// <value>Number of directory and file items within the directory in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get_count HRESULT get_Count( LONG
			// *Count );
			[DispId(1)]
			new int Count { get; }

			/// <summary>Retrieves a list of child items contained within the directory in the file system image.</summary>
			/// <value>
			/// An IEnumFsiItems interface that contains a collection of the child directory and file items contained within the directory.
			/// </value>
			/// <remarks>
			/// This property returns the same results as the IFsiDirectoryItem::get__NewEnum property and is meant for use by C/C++ applications.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-get_enumfsiitems HRESULT
			// get_EnumFsiItems( IEnumFsiItems **NewEnum );
			[DispId(2)]
			new IEnumFsiItems EnumFsiItems { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Adds a directory to the file system image.</summary>
			/// <param name="path">
			/// <para>String that contains the relative path of directory to create.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <remarks>The parent directory for the new subdirectory must already exist within the file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-adddirectory HRESULT AddDirectory(
			// BSTR path );
			[DispId(30)]
			new void AddDirectory([MarshalAs(UnmanagedType.BStr)] string path);

			/// <summary>Adds a file to the file system image.</summary>
			/// <param name="path">
			/// <para>String that contains the relative path of the directory to contain the new file.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <param name="fileData">An <c>IStream</c> interface of the file (data stream) to write to the media.</param>
			/// <remarks>The directory that will contain the new file must already exist within the file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-addfile HRESULT AddFile( BSTR path,
			// IStream *fileData );
			[DispId(31)]
			new void AddFile([MarshalAs(UnmanagedType.BStr)] string path, IStream fileData);

			/// <summary>Adds the contents of a directory tree to the file system image.</summary>
			/// <param name="sourceDirectory">
			/// <para>String that contains the relative path of the directory tree to create.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <param name="includeBaseDirectory">
			/// Set to VARIANT_TRUE to include the directory in sourceDirectory as a subdirectory in the file system image. Otherwise, VARIANT_FALSE.
			/// </param>
			/// <remarks>
			/// <para>The parent directory for the new subdirectory must already exist within the file system image.</para>
			/// <para>The subdirectory structure within specified source directory is implicitly mirrored in the file system image.</para>
			/// <para>
			/// If file or directory collisions occur, the content of the specified source directory prevails. The file system image is
			/// overwritten with the appropriate directories and files from the source directory.
			/// </para>
			/// <para>If an exception occurs during processing, the file system image reverts to its previous state.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-addtree HRESULT AddTree( BSTR
			// sourceDirectory, VARIANT_BOOL includeBaseDirectory );
			[DispId(32)]
			new void AddTree([MarshalAs(UnmanagedType.BStr)] string sourceDirectory, [MarshalAs(UnmanagedType.VariantBool)] bool includeBaseDirectory);

			/// <summary>Adds a file or directory described by the IFsiItem object to the file system image.</summary>
			/// <param name="item">An IFsiItem interface of the IFsiFileItemor IFsiDirectoryItem to add to the file system image.</param>
			/// <remarks>
			/// <para>
			/// To create a directory item or file item, call the IFileSystemImage::CreateDirectoryItem or IFileSystemImage::CreateFileItem
			/// method, respectively.
			/// </para>
			/// <para>Once an item is added to the file system image, the IFsiFileItem::get_Data property becomes read-only.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-add HRESULT Add( IFsiItem *item );
			[DispId(33)]
			new void Add(IFsiItem item);

			/// <summary>Removes the specified item from the file system image.</summary>
			/// <param name="path">
			/// <para>String that contains the relative path of the item to remove. The path is relative to current directory item.</para>
			/// <para>Specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <remarks>This method is only callable on directory items present in the file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-remove HRESULT Remove( BSTR path );
			[DispId(34)]
			new void Remove([MarshalAs(UnmanagedType.BStr)] string path);

			/// <summary>Remove the specified directory tree from the file system image.</summary>
			/// <param name="path">String that contains the name of directory to remove. The path is relative to current directory item.</param>
			/// <remarks>
			/// <para>The directory item must be present in the file system image.</para>
			/// <para>
			/// You can delete the entire file-system image by calling this method for the root directory item and setting the path to a
			/// single path delimiter (\).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem-removetree HRESULT RemoveTree( BSTR
			// path );
			[DispId(35)]
			new void RemoveTree([MarshalAs(UnmanagedType.BStr)] string path);

			/// <summary>
			/// Adds the contents of a directory tree along with named streams associated with all files to the file system image.
			/// </summary>
			/// <param name="sourceDirectory">
			/// <para>
			/// String that contains the relative path of the directory tree to create. The path should contain only valid characters as per
			/// file system naming conventions. This parameter cannot be <c>NULL</c>.
			/// </para>
			/// <para><c>Note</c> You must specify the full path when calling this method from the root directory item.</para>
			/// </param>
			/// <param name="includeBaseDirectory">
			/// Set to <c>VARIANT_TRUE</c> to include the directory in sourceDirectory as a subdirectory in the file system image.
			/// Otherwise, <c>VARIANT_FALSE</c>.
			/// </param>
			/// <remarks>
			/// <para>The parent directory for the new sub-directory must already exist within the file system image.</para>
			/// <para>
			/// The sub-directory structure within specified sourceDirectory is implicitly mirrored in the file system image. If file or
			/// directory collisions occur, the content of the specified source directory prevails.
			/// </para>
			/// <para>
			/// The file system image is overwritten with the appropriate directories and files from the source directory. If an exception
			/// occurs during processing, the file system image reverts to its previous state.
			/// </para>
			/// <para>
			/// If this method is invoked for a file system object that does not contain UDF in the list of file systems enabled for
			/// creation in the resultant image or if the UDF revision is below 2.00, this method returns success code
			/// <c>IMAPI_S_IMAGE_FEATURE_NOT_SUPPORTED</c>. This indicates that the named streams have been added but will not appear in the
			/// resultant file system image unless UDF revision 2.00 or higher is enabled in the file system object.
			/// </para>
			/// <para>
			/// When utilizing alternate data streams (ADS) it is important to note that the file system image has a limitation of 1000
			/// streams. Exceeding this number will result in lost data.
			/// </para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsidirectoryitem2-addtreewithnamedstreams HRESULT
			// AddTreeWithNamedStreams( BSTR sourceDirectory, VARIANT_BOOL includeBaseDirectory );
			[DispId(36)]
			void AddTreeWithNamedStreams([MarshalAs(UnmanagedType.BStr)] string sourceDirectory, [MarshalAs(UnmanagedType.VariantBool)] bool includeBaseDirectory);
		};

		/// <summary>
		/// <para>Use this interface to identify the file size and data stream of the file contents.</para>
		/// <para>To get this interface, call the IFileSystemImage::CreateFileItem method.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Data streams for files contained within the file system image are read-only. File data can only be replaced by overwriting an
		/// existing file item.
		/// </para>
		/// <para>This is an <c>FsiFileItem</c> object in script.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifsifileitem
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFsiFileItem")]
		[ComImport, Guid("2C941FDB-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(FsiFileItem))]
		public interface IFsiFileItem : IFsiItem
		{
			/// <summary>Retrieves the name of the directory or file item in the file system image.</summary>
			/// <value>String that contains the name of the file or directory item in the file system image.</value>
			/// <remarks>To get the full path to the item, call the IFsiItem::get_FullPath method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_name HRESULT get_Name( BSTR *pVal );
			[DispId(11)]
			new string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the full path of the file or directory item in the file system image.</summary>
			/// <value>String that contains the absolute path of the file or directory item in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_fullpath HRESULT get_FullPath( BSTR
			// *pVal );
			[DispId(12)]
			new string FullPath { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets or sets the date and time that the directory or file item was created and added to the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was created and added to the file system image, according to UTC time.
			/// Defaults to the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// IMAPI does not support the extended attribute for CreationTime, and as a result, UDFS populates the CreationTime with the
			/// value expressed by the LastAccessed property from the file entry.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_creationtime HRESULT put_CreationTime(
			// DATE newVal );
			[DispId(13)]
			new DateTime CreationTime { get; set; }

			/// <summary>Gets or sets the date and time that the directory or file item was last accessed in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last accessed in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// UDFS (UDF) uses the LastAccessedTime value for the CreationTime, as IMAPI does not currently support the CreationTime
			/// extended attribue.
			/// </para>
			/// <para>
			/// CDFS (ISO 9660) sets the LastAccessedTime value to 0, as only the recording time is stored within the File/Directory descriptor.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastaccessedtime HRESULT
			// put_LastAccessedTime( DATE newVal );
			[DispId(14)]
			new DateTime LastAccessedTime { get; set; }

			/// <summary>Gets or sets the date and time that the item was last modified in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last modified in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// The last modified time is propagated to the attribute that users see when viewing the properties of a directory or a file.
			/// </para>
			/// <para>When implementing this method, a few things should be taken into consideration:</para>
			/// <para>UDFS (UDF) will use the value provided by <c>IFsiItem::put_LastModifiedTime</c> as both the CreationTime and LastModifiedTime.</para>
			/// <para>
			/// CDFS (ISO 9660) uses the date/time of recording as the CreationTime and LastModifiedTime. As a result, CDFS sets the value
			/// of LastModifiedTime to 0.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastmodifiedtime HRESULT
			// put_LastModifiedTime( DATE newVal );
			[DispId(15)]
			new DateTime LastModifiedTime { get; set; }

			/// <summary>Determines if the item's hidden attribute is set in the file system image.</summary>
			/// <value>
			/// Set to VARIANT_TRUE to set the hidden attribute of the item in the file system image; otherwise, VARIANT_FALSE. The default
			/// is VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_ishidden HRESULT put_IsHidden(
			// VARIANT_BOOL newVal );
			[DispId(16)]
			new bool IsHidden { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the name of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the name should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the name of the item as it conforms to the specified file system. The name in the IFsiItem::get_Name
			/// property is modified if the characters used and its length do not meet the requirements of the specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystemname HRESULT FileSystemName(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemName(FsiFileSystems fileSystem);

			/// <summary>Retrieves the full path of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the path should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the full path of the item as it conforms to the specified file system. The path in the
			/// IFsiItem::get_FullPath property is modified if the characters used and its length do not meet the requirements of the
			/// specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystempath HRESULT FileSystemPath(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemPath(FsiFileSystems fileSystem);

			/// <summary>Retrieves the data stream of the file's content.</summary>
			/// <value>An <c>IStream</c> interface of the contents of the file.</value>
			/// <remarks>The contents of the file becomes read-only once the file item is added to file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-get_data HRESULT get_Data( IStream
			// **pVal );
			[DispId(41)]
			long DataSize { get; }

			/// <summary>Retrieves the least significant 32 bits of the IFsiFileItem::get_DataSize property.</summary>
			/// <value>Least significant 32 bits of the IFsiFileItem::get_DataSize property.</value>
			/// <remarks>
			/// This property and IFsiFileItem::get_DataSize32BitHigh together provide the size of the file as two 32-bit numbers for
			/// languages that do not support 64-bit values, such as VBScript and Visual Basic 6.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-get_datasize32bitlow HRESULT
			// get_DataSize32BitLow( LONG *pVal );
			[DispId(42)]
			int DataSize32BitLow { get; }

			/// <summary>Retrieves the most significant 32 bits of the IFsiFileItem::get_DataSize property.</summary>
			/// <value>Most significant 32 bits of the IFsiFileItem::get_DataSize property.</value>
			/// <remarks>
			/// This property and IFsiFileItem::get_DataSize32BitLow together provide the size of the file as two 32-bit numbers for
			/// languages that do not support 64-bit values, such as VBScript and Visual Basic 6.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-get_datasize32bithigh HRESULT
			// get_DataSize32BitHigh( LONG *pVal );
			[DispId(43)]
			int DataSize32BitHigh { get; }

			/// <summary>Gets or sets the data stream of the file's content.</summary>
			/// <value>An <c>IStream</c> interface of the content of the file to add to the file system image.</value>
			/// <remarks>The contents of the file becomes read-only once the file item is added to file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-put_data HRESULT put_Data( IStream
			// *newVal );
			[DispId(44)]
			IStream Data { [return: MarshalAs(UnmanagedType.Interface)] get; set; }
		}

		/// <summary>
		/// Use this interface to add, remove and enumerate named streams associated with a file. This interface also provides access to the
		/// 'Real-Time' attribute of a file.
		/// </summary>
		/// <remarks>
		/// <para>
		/// While UDF 2.0 is the lowest required revision for named stream support, the user must enable UDF 2.01 or higher to enable the
		/// use of both named streams and real-time file attributes.
		/// </para>
		/// <para>
		/// The recipients of a storage medium containing such files are required to read them using special MMC commands reducing read
		/// latency and increasing the worst-case read speed.
		/// </para>
		/// <para>
		/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifsifileitem2
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFsiFileItem2")]
		[ComImport, Guid("199D0C19-11E1-40eb-8EC2-C8C822A07792"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(FsiFileItem))]
		public interface IFsiFileItem2 : IFsiFileItem
		{
			/// <summary>Retrieves the name of the directory or file item in the file system image.</summary>
			/// <value>String that contains the name of the file or directory item in the file system image.</value>
			/// <remarks>To get the full path to the item, call the IFsiItem::get_FullPath method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_name HRESULT get_Name( BSTR *pVal );
			[DispId(11)]
			new string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the full path of the file or directory item in the file system image.</summary>
			/// <value>String that contains the absolute path of the file or directory item in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_fullpath HRESULT get_FullPath( BSTR
			// *pVal );
			[DispId(12)]
			new string FullPath { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets or sets the date and time that the directory or file item was created and added to the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was created and added to the file system image, according to UTC time.
			/// Defaults to the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// IMAPI does not support the extended attribute for CreationTime, and as a result, UDFS populates the CreationTime with the
			/// value expressed by the LastAccessed property from the file entry.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_creationtime HRESULT put_CreationTime(
			// DATE newVal );
			[DispId(13)]
			new DateTime CreationTime { get; set; }

			/// <summary>Gets or sets the date and time that the directory or file item was last accessed in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last accessed in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// UDFS (UDF) uses the LastAccessedTime value for the CreationTime, as IMAPI does not currently support the CreationTime
			/// extended attribue.
			/// </para>
			/// <para>
			/// CDFS (ISO 9660) sets the LastAccessedTime value to 0, as only the recording time is stored within the File/Directory descriptor.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastaccessedtime HRESULT
			// put_LastAccessedTime( DATE newVal );
			[DispId(14)]
			new DateTime LastAccessedTime { get; set; }

			/// <summary>Gets or sets the date and time that the item was last modified in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last modified in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// The last modified time is propagated to the attribute that users see when viewing the properties of a directory or a file.
			/// </para>
			/// <para>When implementing this method, a few things should be taken into consideration:</para>
			/// <para>UDFS (UDF) will use the value provided by <c>IFsiItem::put_LastModifiedTime</c> as both the CreationTime and LastModifiedTime.</para>
			/// <para>
			/// CDFS (ISO 9660) uses the date/time of recording as the CreationTime and LastModifiedTime. As a result, CDFS sets the value
			/// of LastModifiedTime to 0.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastmodifiedtime HRESULT
			// put_LastModifiedTime( DATE newVal );
			[DispId(15)]
			new DateTime LastModifiedTime { get; set; }

			/// <summary>Determines if the item's hidden attribute is set in the file system image.</summary>
			/// <value>
			/// Set to VARIANT_TRUE to set the hidden attribute of the item in the file system image; otherwise, VARIANT_FALSE. The default
			/// is VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_ishidden HRESULT put_IsHidden(
			// VARIANT_BOOL newVal );
			[DispId(16)]
			new bool IsHidden { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the name of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the name should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the name of the item as it conforms to the specified file system. The name in the IFsiItem::get_Name
			/// property is modified if the characters used and its length do not meet the requirements of the specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystemname HRESULT FileSystemName(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemName(FsiFileSystems fileSystem);

			/// <summary>Retrieves the full path of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the path should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the full path of the item as it conforms to the specified file system. The path in the
			/// IFsiItem::get_FullPath property is modified if the characters used and its length do not meet the requirements of the
			/// specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystempath HRESULT FileSystemPath(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			new string FileSystemPath(FsiFileSystems fileSystem);

			/// <summary>Retrieves the data stream of the file's content.</summary>
			/// <value>An <c>IStream</c> interface of the contents of the file.</value>
			/// <remarks>The contents of the file becomes read-only once the file item is added to file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-get_data HRESULT get_Data( IStream
			// **pVal );
			[DispId(41)]
			new long DataSize { get; }

			/// <summary>Retrieves the least significant 32 bits of the IFsiFileItem::get_DataSize property.</summary>
			/// <value>Least significant 32 bits of the IFsiFileItem::get_DataSize property.</value>
			/// <remarks>
			/// This property and IFsiFileItem::get_DataSize32BitHigh together provide the size of the file as two 32-bit numbers for
			/// languages that do not support 64-bit values, such as VBScript and Visual Basic 6.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-get_datasize32bitlow HRESULT
			// get_DataSize32BitLow( LONG *pVal );
			[DispId(42)]
			new int DataSize32BitLow { get; }

			/// <summary>Retrieves the most significant 32 bits of the IFsiFileItem::get_DataSize property.</summary>
			/// <value>Most significant 32 bits of the IFsiFileItem::get_DataSize property.</value>
			/// <remarks>
			/// This property and IFsiFileItem::get_DataSize32BitLow together provide the size of the file as two 32-bit numbers for
			/// languages that do not support 64-bit values, such as VBScript and Visual Basic 6.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-get_datasize32bithigh HRESULT
			// get_DataSize32BitHigh( LONG *pVal );
			[DispId(43)]
			new int DataSize32BitHigh { get; }

			/// <summary>Gets or sets the data stream of the file's content.</summary>
			/// <value>An <c>IStream</c> interface of the content of the file to add to the file system image.</value>
			/// <remarks>The contents of the file becomes read-only once the file item is added to file system image.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem-put_data HRESULT put_Data( IStream
			// *newVal );
			[DispId(44)]
			new IStream Data { [return: MarshalAs(UnmanagedType.Interface)] get; set; }

			/// <summary>Retrieves a collection of named streams associated with a file in the file system image.</summary>
			/// <value>Pointer to an IFsiNamedStreams object that represents a collection of named streams associated with the file.</value>
			/// <remarks>
			/// <para>
			/// If this method is invoked for a file item which itself represents a named stream, the <c>IMAPI_E_PROPERTY_NOT_ACCESSIBLE</c>
			/// error code is returned, as a named streams cannot contain additional named streams.
			/// </para>
			/// <para>The user must enable UDF and set the UDF revision to 2.00 or higher to support named streams.</para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem2-get_fsinamedstreams HRESULT
			// get_FsiNamedStreams( IFsiNamedStreams **streams );
			[DispId(45)]
			IFsiNamedStreams FsiNamedStreams { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>
			/// Determines if the item is a named stream. Data streams for named streams contained within the file system image are
			/// read-only. Stream data can only be replaced by overwriting the existing named stream.
			/// </summary>
			/// <value>Pointer to a value that indicates if the item is a named stream. to <c>VARIANT_TRUE</c> if an ; otherwise, <c>VARIANT_FALSE</c>.</value>
			/// <remarks>
			/// <para>The user must enable UDF and set the UDF revision to 2.00 or higher to support named streams.</para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem2-get_isnamedstream HRESULT
			// get_IsNamedStream( VARIANT_BOOL *pVal );
			[DispId(46)]
			bool IsNamedStream { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

			/// <summary>Associates a named stream with a specific file in the file system image.</summary>
			/// <param name="name">
			/// A string represents the name of the named stream. This should not include the path and should only contain valid characters
			/// as per file system naming conventions.
			/// </param>
			/// <param name="streamData">An <c>IStream</c> interface of the named stream used to write to the resultant file system image.</param>
			/// <remarks>
			/// <para>
			/// The file to which the named stream will be added must already exist within the file system image. If this method is called
			/// with a name that already exists for a named stream, it will return an error and will not replace the existing named stream.
			/// </para>
			/// <para>
			/// If this method is invoked for a file system object that does not contain UDF in the list of file systems enabled for
			/// creation in the resultant image or if the UDF revision is below 2.00, this method returns success code
			/// <c>IMAPI_S_IMAGE_FEATURE_NOT_SUPPORTED</c>. This success code indicates that the named stream has been added but will not
			/// appear in the resultant file system image unless UDF revision 2.00 or higher is enabled in the file system object.
			/// </para>
			/// <para>
			/// Currently, <c>IMAPI_E_READONLY</c> is returned when this method is called on an imported file system image, regardless of
			/// the read only status of the image.
			/// </para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem2-addstream HRESULT AddStream( BSTR name,
			// IStream *streamData );
			[DispId(47)]
			void AddStream([MarshalAs(UnmanagedType.BStr)] string name, IStream streamData);

			/// <summary>Removes a named stream association with a file.</summary>
			/// <param name="name">
			/// String that specifies the name of the named stream association to remove. This should not include the path and should only
			/// contain valid characters as per file system naming conventions.
			/// </param>
			/// <remarks>
			/// <para>This method can be called only for file items present in the file system image.</para>
			/// <para>The user must enable UDF and set the UDF revision to 2.00 or higher to support named streams.</para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem2-removestream HRESULT RemoveStream( BSTR
			// name );
			[DispId(48)]
			void RemoveStream([MarshalAs(UnmanagedType.BStr)] string name);

			/// <summary>
			/// Gets or sets the 'Real-Time' attribute of a file in a file system. This attribute specifies whether or not the content
			/// requires a minimum data-transfer rate when writing or reading, for example, audio and video data.
			/// </summary>
			/// <value>
			/// Specify <c>VARIANT_TRUE</c> to set the Real-Time attribute of a file in the file system image; otherwise,
			/// <c>VARIANT_FALSE</c>. The default is <c>VARIANT_FALSE</c>.
			/// </value>
			/// <remarks>
			/// <para>
			/// The IFsiDirectoryItem::AddTree and IFsiDirectoryItem2::AddTreeWithNamedStreams methods do not set the Real-Time attribute
			/// while adding files to a file system image. To mark files as Real-time files, they must be enumerated after they have been
			/// added to the file system image and have the Real-Time attribute set individually.
			/// </para>
			/// <para>
			/// If this method is invoked for a file item representing a named stream, this method returns error code
			/// <c>IMAPI_E_PROPERTY_NOT_ACCESSIBLE</c> as named streams do not have the Real-Time attribute.
			/// </para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsifileitem2-put_isrealtime HRESULT put_IsRealTime(
			// VARIANT_BOOL newVal );
			[DispId(49)]
			bool IsRealTime { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }
		}

		/// <summary>
		/// <para>Base interface containing properties common to both file and directory items.</para>
		/// <para>To access the properties of this interface, use the IFsiFileItem or IFsiDirectoryItem interface.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifsiitem
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFsiItem")]
		[ComImport, Guid("2C941FD9-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
		public interface IFsiItem
		{
			/// <summary>Retrieves the name of the directory or file item in the file system image.</summary>
			/// <value>String that contains the name of the file or directory item in the file system image.</value>
			/// <remarks>To get the full path to the item, call the IFsiItem::get_FullPath method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_name HRESULT get_Name( BSTR *pVal );
			[DispId(11)]
			string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the full path of the file or directory item in the file system image.</summary>
			/// <value>String that contains the absolute path of the file or directory item in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-get_fullpath HRESULT get_FullPath( BSTR
			// *pVal );
			[DispId(12)]
			string FullPath { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets or sets the date and time that the directory or file item was created and added to the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was created and added to the file system image, according to UTC time.
			/// Defaults to the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// IMAPI does not support the extended attribute for CreationTime, and as a result, UDFS populates the CreationTime with the
			/// value expressed by the LastAccessed property from the file entry.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_creationtime HRESULT put_CreationTime(
			// DATE newVal );
			[DispId(13)]
			DateTime CreationTime { get; set; }

			/// <summary>Gets or sets the date and time that the directory or file item was last accessed in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last accessed in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// UDFS (UDF) uses the LastAccessedTime value for the CreationTime, as IMAPI does not currently support the CreationTime
			/// extended attribue.
			/// </para>
			/// <para>
			/// CDFS (ISO 9660) sets the LastAccessedTime value to 0, as only the recording time is stored within the File/Directory descriptor.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastaccessedtime HRESULT
			// put_LastAccessedTime( DATE newVal );
			[DispId(14)]
			DateTime LastAccessedTime { get; set; }

			/// <summary>Gets or sets the date and time that the item was last modified in the file system image.</summary>
			/// <value>
			/// Date and time that the directory or file item was last modified in the file system image, according to UTC time. Defaults to
			/// the time the item was added to the image.
			/// </value>
			/// <remarks>
			/// <para>
			/// The last modified time is propagated to the attribute that users see when viewing the properties of a directory or a file.
			/// </para>
			/// <para>When implementing this method, a few things should be taken into consideration:</para>
			/// <para>UDFS (UDF) will use the value provided by <c>IFsiItem::put_LastModifiedTime</c> as both the CreationTime and LastModifiedTime.</para>
			/// <para>
			/// CDFS (ISO 9660) uses the date/time of recording as the CreationTime and LastModifiedTime. As a result, CDFS sets the value
			/// of LastModifiedTime to 0.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_lastmodifiedtime HRESULT
			// put_LastModifiedTime( DATE newVal );
			[DispId(15)]
			DateTime LastModifiedTime { get; set; }

			/// <summary>Determines if the item's hidden attribute is set in the file system image.</summary>
			/// <value>
			/// Set to VARIANT_TRUE to set the hidden attribute of the item in the file system image; otherwise, VARIANT_FALSE. The default
			/// is VARIANT_FALSE.
			/// </value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-put_ishidden HRESULT put_IsHidden(
			// VARIANT_BOOL newVal );
			[DispId(16)]
			bool IsHidden { [return: MarshalAs(UnmanagedType.VariantBool)] get; set; }

			/// <summary>Retrieves the name of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the name should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the name of the item as it conforms to the specified file system. The name in the IFsiItem::get_Name
			/// property is modified if the characters used and its length do not meet the requirements of the specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystemname HRESULT FileSystemName(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			string FileSystemName(FsiFileSystems fileSystem);

			/// <summary>Retrieves the full path of the item as modified to conform to the specified file system.</summary>
			/// <param name="fileSystem">
			/// File system to which the path should conform. For possible values, see the FsiFileSystems enumeration type.
			/// </param>
			/// <returns>
			/// String that contains the full path of the item as it conforms to the specified file system. The path in the
			/// IFsiItem::get_FullPath property is modified if the characters used and its length do not meet the requirements of the
			/// specified file system type.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsiitem-filesystempath HRESULT FileSystemPath(
			// FsiFileSystems fileSystem, BSTR *pVal );
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			string FileSystemPath(FsiFileSystems fileSystem);
		}

		/// <summary>Use this interface to enumerate the named streams associated with a file in a file system image.</summary>
		/// <remarks>
		/// <para>
		/// To access this interface, call the IFsiFileItem2::get_FsiNamedStreams method of a file item object representing a standard or
		/// 'Real-Time' file.
		/// </para>
		/// <para>
		/// This interface is provided only for file item objects representing regular or 'Real-Time' files. Named streams cannot have other
		/// name streams associated with them.
		/// </para>
		/// <para>UDF must be enabled and set to UDF revision 2.00 or later in order to enable named stream support.</para>
		/// <para>
		/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-ifsinamedstreams
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IFsiNamedStreams")]
		[ComImport, Guid("ED79BA56-5294-4250-8D46-F9AECEE23459"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(FsiNamedStreams))]
		public interface IFsiNamedStreams : IEnumerable
		{
			/// <summary>Retrieves an <c>IEnumVARIANT</c> list of the named streams associated with a file in the file system image.</summary>
			/// <returns>
			/// Pointer to a pointer to an <c>IEnumVariant</c> interface that is used to enumerate the named streams associated with a file.
			/// The items of the enumeration are variants whose type is <c>VT_BSTR</c>. Use the <c>bstrVal</c> member to retrieve the path
			/// to the named stream.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The enumeration is a snapshot of the named streams associated with the file at the time of the call and will not reflect
			/// named streams that are added or removed later on.
			/// </para>
			/// <para>To retrieve a single named stream, use the IFsiNamedStreams::get_Item method.</para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsinamedstreams-get__newenum HRESULT get__NewEnum(
			// IEnumVARIANT **NewEnum );
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnumeratorToEnumVariantMarshaler))]
			new IEnumerator GetEnumerator();

			/// <summary>Retrieves a single named stream associated with a file in the file system image.</summary>
			/// <param name="index">
			/// This value indicates the position of the named stream within the collection. The index number is zero-based, i.e. the first
			/// item is at location 0 of the collection.
			/// </param>
			/// <value>
			/// Pointer to a pointer to an IFsiFileItem2 object representing the named stream at the position specified by index. This
			/// parameter is set to <c>NULL</c> if the specified index is not within the collection boundary.
			/// </value>
			/// <remarks>
			/// <para>If the index number is negative or out of range, this method returns the <c>IMAPI_E_INVALID_PARAM</c>.</para>
			/// <para>
			/// To fetch an <c>IEnumVARIANT</c> enumerator for all named streams associated with a file, use the
			/// IFsiNamedStreams::get__NewEnum method.
			/// </para>
			/// <para>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsinamedstreams-get_item HRESULT get_Item( LONG
			// index, IFsiFileItem2 **item );
			[DispId(0)]
			IFsiFileItem2 this[int index] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Returns the number of the named streams associated with a file in the file system image.</summary>
			/// <value>Pointer to a value indicating the total number of named streams in the collection.</value>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsinamedstreams-get_count HRESULT get_Count( LONG
			// *count );
			[DispId(81)]
			int Count { get; }

			/// <summary>
			/// Creates a non-variant enumerator for the collection of the named streams associated with a file in the file system image.
			/// </summary>
			/// <value>Pointer to a pointer to an IEnumFsiItems object representing a collection of named streams associated with a file.</value>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-ifsinamedstreams-get_enumnamedstreams HRESULT
			// get_EnumNamedStreams( IEnumFsiItems **NewEnum );
			[DispId(82)]
			IEnumFsiItems EnumNamedStreams { [return: MarshalAs(UnmanagedType.Interface)] get; }
		}

		/// <summary>Use this interface to verify if an existing .iso file contains a valid file system for burning.</summary>
		/// <remarks>
		/// <para>
		/// If a valid path is provided via SetPath, an <c>IStream</c> object will be created from the supplied image file and the
		/// <c>Stream</c> property will be populated. If a valid <c>IStream</c> is provided via SetStream, it will be used directly for
		/// image validation and the <c>Path</c> property will not be populated.
		/// </para>
		/// <para>
		/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-iisoimagemanager
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IIsoImageManager")]
		[ComImport, Guid("6CA38BE5-FBBB-4800-95A1-A438865EB0D4"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftIsoImageManager))]
		public interface IIsoImageManager
		{
			/// <summary>Retrives the logical path to an .iso image.</summary>
			/// <value>Pointer to the logical path to an .iso image. For example, "c:\path\file.iso".</value>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iisoimagemanager-get_path HRESULT get_Path( BSTR
			// *pVal );
			[DispId(0x100)]
			string Path { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the <c>IStream</c> object associated with the .iso image.</summary>
			/// <value>The <c>IStream</c> object associated with the .iso image.</value>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iisoimagemanager-get_stream HRESULT get_Stream(
			// IStream **data );
			[DispId(0x101)]
			IStream Stream { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Sets the <c>Path</c> property value with a logical path to an .iso image.</summary>
			/// <param name="Val">The logical path to the .iso image. For example, "c:\path\file.iso".</param>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iisoimagemanager-setpath HRESULT SetPath( BSTR Val );
			[DispId(0x200)]
			void SetPath([In, MarshalAs(UnmanagedType.BStr)] string Val);

			/// <summary>Sets the <c>Stream</c> property with the <c>IStream</c> object associated with the .iso image.</summary>
			/// <param name="data">The <c>IStream</c> object associated with the .iso image.</param>
			/// <remarks>
			/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
			/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in
			/// Windows 7 and Windows Server 2008 R2.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iisoimagemanager-setstream HRESULT SetStream( IStream
			// *data );
			[DispId(0x201)]
			void SetStream([In, MarshalAs(UnmanagedType.Interface)] IStream data);

			/// <summary>
			/// <para>
			/// Determines if the provided .iso image is valid. <c>Note</c> Support for this interface method is included in the latest
			/// Windows Feature Pack for Storage Beta release offered via Microsoft Connect.
			/// </para>
			/// <para>Syntax</para>
			/// <para>
			/// <code>void IsValid();</code>
			/// </para>
			/// <para>Parameters</para>
			/// <para>This method has no parameters.</para>
			/// <para>Return Value</para>
			/// <para>This method does not return a value.</para>
			/// <para>Remarks</para>
			/// <para>Requirements</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Client</term>
			/// <term>Windows Vista or Windows XP with SP2</term>
			/// </listheader>
			/// <item>
			/// <term>Server</term>
			/// <term>Windows Server 2008 or Windows Server 2003</term>
			/// </item>
			/// <item>
			/// <term>IDL</term>
			/// <term>Imapi2.idl</term>
			/// </item>
			/// </list>
			/// <para>See Also</para>
			/// <para><c>IIsoImageManager</c></para>
			/// <para>Send comments about this topic to Microsoft</para>
			/// <para>Build date: 10/30/2008</para>
			/// </summary>
			/// <returns>
			/// <para>This method does not return a value.</para>
			/// <para>Remarks</para>
			/// <para>Requirements</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Client</term>
			/// <term>Windows Vista or Windows XP with SP2</term>
			/// </listheader>
			/// <item>
			/// <term>Server</term>
			/// <term>Windows Server 2008 or Windows Server 2003</term>
			/// </item>
			/// <item>
			/// <term>IDL</term>
			/// <term>Imapi2.idl</term>
			/// </item>
			/// </list>
			/// <para>See Also</para>
			/// <para><c>IIsoImageManager</c></para>
			/// <para>Send comments about this topic to Microsoft</para>
			/// <para>Build date: 10/30/2008</para>
			/// </returns>
			/// <remarks>
			/// <para>Requirements</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Client</term>
			/// <term>Windows Vista or Windows XP with SP2</term>
			/// </listheader>
			/// <item>
			/// <term>Server</term>
			/// <term>Windows Server 2008 or Windows Server 2003</term>
			/// </item>
			/// <item>
			/// <term>IDL</term>
			/// <term>Imapi2.idl</term>
			/// </item>
			/// </list>
			/// <para>See Also</para>
			/// <para><c>IIsoImageManager</c></para>
			/// <para>Send comments about this topic to Microsoft</para>
			/// <para>Build date: 10/30/2008</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/cc507536(v%3dvs.85) void IsValid();
			[DispId(0x202)]
			[PreserveSig]
			HRESULT Validate();
		}

		/// <summary>
		/// <para>
		/// Use this interface to retrieve block information for one segment of the result file image. This can be used to determine the LBA
		/// ranges of files in the resulting image. This information can then be used to display to the user which file is currently being
		/// written to the media or used for other advanced burning functionality.
		/// </para>
		/// <para>To get this interface, call the IEnumProgressItems::Next or IEnumProgressItems::RemoteNext method.</para>
		/// </summary>
		/// <remarks>This is a <c>ProgressItem</c> object in script.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-iprogressitem
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IProgressItem")]
		[ComImport, Guid("2C941FD5-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(ProgressItem))]
		public interface IProgressItem
		{
			/// <summary>Retrieves the description in the progress item.</summary>
			/// <value>String containing the description. The description contains the name of the file in the file system image.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitem-get_description HRESULT
			// get_Description( BSTR *desc );
			[DispId(1)]
			string Description { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Retrieves the first block number in this segment of the result image.</summary>
			/// <value>First block number of this segment.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitem-get_firstblock HRESULT get_FirstBlock(
			// ULONG *block );
			[DispId(2)]
			uint FirstBlock { get; }

			/// <summary>Retrieves the last block in this segment of the result image.</summary>
			/// <value>Number of the last block of this segment.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitem-get_lastblock HRESULT get_LastBlock(
			// ULONG *block );
			[DispId(3)]
			uint LastBlock { get; }

			/// <summary>Retrieves the number of blocks in the progress item.</summary>
			/// <value>Number of blocks in the segment.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitem-get_blockcount HRESULT get_BlockCount(
			// ULONG *blocks );
			[DispId(4)]
			uint BlockCount { get; }
		}

		/// <summary>
		/// <para>
		/// Use this interface to enumerate the progress items in a result image. A progress item represents a segment of the result image.
		/// </para>
		/// <para>To get this interface, call the IFileSystemImageResult::get_ProgressItems method.</para>
		/// </summary>
		/// <remarks>This is a <c>ProgressItems</c> object in script.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nn-imapi2fs-iprogressitems
		[PInvokeData("imapi2fs.h", MSDNShortId = "NN:imapi2fs.IProgressItems")]
		[ComImport, Guid("2C941FD7-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(ProgressItems))]
		public interface IProgressItems : IEnumerable
		{
			/// <summary>Retrieves the list of progress items from the collection.</summary>
			/// <returns>
			/// An <c>IEnumVariant</c> interface that you use to enumerate the progress items contained within the collection. Each item of
			/// the enumeration is a VARIANT whose type is <c>VT_DISPATCH</c>. Query the <c>pdispVal</c> member to retrieve the
			/// IProgressItem interface.
			/// </returns>
			/// <remarks>
			/// <para>The enumeration is a snapshot of the progress items contained in the collection at the time of the call.</para>
			/// <para>To retrieve a single item, see the IProgressItems::get_Item property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitems-get__newenum HRESULT get__NewEnum(
			// IEnumVARIANT **NewEnum );
			[DispId(-4)]
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnumeratorToEnumVariantMarshaler))]
			new IEnumerator GetEnumerator();

			/// <summary>Retrieves the specified progress item from the collection.</summary>
			/// <param name="item">Zero-based index number corresponding to a progress item in the collection.</param>
			/// <value>An IProgressItem interface associated with the specified index value.</value>
			/// <remarks>To enumerate all progress items, call the IProgressItems::get__NewEnum method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitems-get_item HRESULT get_Item( long Index,
			// IProgressItem **item );
			[DispId(0)]
			IProgressItem this[int item] { get; }

			/// <summary>Retrieves the number of progress items in the collection.</summary>
			/// <value>Number of progress items in the collection.</value>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitems-get_count HRESULT get_Count( long
			// *Count );
			[DispId(1)]
			int Count { get; }

			/// <summary>Retrieves a progress item based on the specified block number.</summary>
			/// <param name="block">
			/// Block number of the progress item to retrieve. The method returns the progress item if the block number is in the first and
			/// last block range of the item.
			/// </param>
			/// <returns>An IProgressItem interface associated with the specified block number.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitems-progressitemfromblock HRESULT
			// ProgressItemFromBlock( ULONG block, IProgressItem **item );
			[DispId(2)]
			IProgressItem ProgressItemFromBlock(uint block);

			/// <summary>Retrieves a progress item based on the specified file name.</summary>
			/// <param name="description">
			/// String that contains the file name of the progress item to retrieve. The method returns the progress item if this string
			/// matches the value for item's description property.
			/// </param>
			/// <returns>An IProgressItem interface of the progress item associated with the specified file name.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitems-progressitemfromdescription HRESULT
			// ProgressItemFromDescription( BSTR description, IProgressItem **item );
			[DispId(3)]
			IProgressItem ProgressItemFromDescription([MarshalAs(UnmanagedType.BStr)] string description);

			/// <summary>Retrieves the list of progress items from the collection.</summary>
			/// <value>An IEnumProgressItems interface that contains a collection of the progress items contained in the collection.</value>
			/// <remarks>
			/// This property returns the same results as the IProgressItems::get__NewEnum property and is meant for use by C/C++ applications.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/imapi2fs/nf-imapi2fs-iprogressitems-get_enumprogressitems HRESULT
			// get_EnumProgressItems( IEnumProgressItems **NewEnum );
			[DispId(4)]
			IEnumProgressItems EnumProgressItems { get; }
		}

		/// <summary>CLSID_BlockRange</summary>
		[ComImport, Guid("B507CA27-2204-11DD-966A-001AA01BBC58"), ClassInterface(ClassInterfaceType.None)]
		public class BlockRange { }

		/// <summary>CLSID_BlockRangeList</summary>
		[ComImport, Guid("B507CA28-2204-11DD-966A-001AA01BBC58"), ClassInterface(ClassInterfaceType.None)]
		public class BlockRangeList { }

		/// <summary>CLSID_BootOptions</summary>
		[ComImport, Guid("2C941FCE-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class BootOptions { }

		/// <summary>CLSID_EnumFsiItems</summary>
		[ComImport, Guid("2C941FC6-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class EnumFsiItems { }

		/// <summary>CLSID_EnumProgressItems</summary>
		[ComImport, Guid("2C941FCA-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class EnumProgressItems { }

		/// <summary>CLSID_FileSystemImageResult</summary>
		[ComImport, Guid("2C941FCC-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class FileSystemImageResult { }

		/// <summary>CLSID_FsiDirectoryItem</summary>
		[ComImport, Guid("2C941FC8-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class FsiDirectoryItem { }

		/// <summary>CLSID_FsiFileItem</summary>
		[ComImport, Guid("2C941FC7-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class FsiFileItem { }

		/// <summary>CLSID_FsiNamedStreams</summary>
		[ComImport, Guid("C6B6F8ED-6D19-44b4-B539-B159B793A32D"), ClassInterface(ClassInterfaceType.None)]
		public class FsiNamedStreams { }

		/// <summary>CLSID_FsiStream</summary>
		[ComImport, Guid("2C941FCD-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class FsiStream { }

		/// <summary>CLSID_MsftFileSystemImage</summary>
		[ComImport, Guid("2C941FC5-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class MsftFileSystemImage { }

		/// <summary>CLSID_MsftIsoImageManager</summary>
		[ComImport, Guid("CEEE3B62-8F56-4056-869B-EF16917E3EFC"), ClassInterface(ClassInterfaceType.None)]
		public class MsftIsoImageManager { }

		/// <summary>CLSID_ProgressItem</summary>
		[ComImport, Guid("2C941FCB-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class ProgressItem { }

		/// <summary>CLSID_ProgressItems</summary>
		[ComImport, Guid("2C941FC9-975B-59BE-A960-9A2A262853A5"), ClassInterface(ClassInterfaceType.None)]
		public class ProgressItems { }
	}
}