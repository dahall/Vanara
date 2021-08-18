using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// <para>Values used with the DROPDESCRIPTION structure to specify the drop image.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ne-shlobj_core-dropimagetype typedef enum { DROPIMAGE_INVALID,
		// DROPIMAGE_NONE, DROPIMAGE_COPY, DROPIMAGE_MOVE, DROPIMAGE_LINK, DROPIMAGE_LABEL, DROPIMAGE_WARNING, DROPIMAGE_NOIMAGE } ;
		[PInvokeData("shlobj_core.h", MSDNShortId = "eeaf8bd4-25ab-4ec3-9da9-9a72ba3813b9")]
		public enum DROPIMAGETYPE : int
		{
			/// <summary>No drop image preference; use the default image.</summary>
			DROPIMAGE_INVALID = -1,

			/// <summary>A red bisected circle such as that found on a "no smoking" sign.</summary>
			DROPIMAGE_NONE = 0,

			/// <summary>A plus sign (+) that indicates a copy operation.</summary>
			DROPIMAGE_COPY = (int)Ole32.DROPEFFECT.DROPEFFECT_COPY,

			/// <summary>An arrow that indicates a move operation.</summary>
			DROPIMAGE_MOVE = (int)Ole32.DROPEFFECT.DROPEFFECT_MOVE,

			/// <summary>An arrow that indicates a link.</summary>
			DROPIMAGE_LINK = (int)Ole32.DROPEFFECT.DROPEFFECT_LINK,

			/// <summary>A tag icon that indicates that the metadata will be changed.</summary>
			DROPIMAGE_LABEL = 6,

			/// <summary>A yellow exclamation mark that indicates that a problem has been encountered in the operation.</summary>
			DROPIMAGE_WARNING = 7,

			/// <summary>Windows 7 and later. Use no drop image.</summary>
			DROPIMAGE_NOIMAGE = 8,
		}

		/// <summary>An array of flags that indicate which of the <see cref="FILEDESCRIPTOR"/> structure members contain valid data.</summary>
		[PInvokeData("shlobj_core.h", MSDNShortId = "b81a7e52-5bd8-4fa4-bd76-9a58afaceec0")]
		[Flags]
		public enum FD_FLAGS : uint
		{
			/// <summary>The <c>clsid</c> member is valid.</summary>
			FD_CLSID = 0x00000001,

			/// <summary>The <c>sizel</c> and <c>pointl</c> members are valid.</summary>
			FD_SIZEPOINT = 0x00000002,

			/// <summary>The <c>dwFileAttributes</c> member is valid.</summary>
			FD_ATTRIBUTES = 0x00000004,

			/// <summary>The <c>ftCreationTime</c> member is valid.</summary>
			FD_CREATETIME = 0x00000008,

			/// <summary>The <c>ftLastAccessTime</c> member is valid.</summary>
			FD_ACCESSTIME = 0x00000010,

			/// <summary>The <c>ftLastWriteTime</c> member is valid.</summary>
			FD_WRITESTIME = 0x00000020,

			/// <summary>The <c>nFileSizeHigh</c> and <c>nFileSizeLow</c> members are valid.</summary>
			FD_FILESIZE = 0x00000040,

			/// <summary>A progress indicator is shown with drag-and-drop operations.</summary>
			FD_PROGRESSUI = 0x00004000,

			/// <summary>Treat the operation as a shortcut.</summary>
			FD_LINKUI = 0x00008000,

			/// <summary><c>Windows Vista and later</c>. The descriptor is Unicode.</summary>
			FD_UNICODE = 0x80000000,
		}

		/// <summary>
		/// <para>
		/// Used with the CFSTR_SHELLIDLIST clipboard format to transfer the pointer to an item identifier list (PIDL) of one or more Shell
		/// namespace objects.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To use this structure to retrieve a particular PIDL, add the <c>aoffset</c> value of the PIDL to the address of the structure.
		/// The following two macros can be used to retrieve PIDLs from the structure. The first retrieves the PIDL of the parent folder.
		/// The second retrieves a PIDL, specified by its zero-based index.
		/// </para>
		/// <para>
		/// The value that is returned by these macros is a pointer to the ITEMIDLIST structure. Since these structures vary in length, you
		/// must determine the end of the structure by parsing it. See NameSpace for further discussion of PIDLs and the <c>ITEMIDLIST</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ns-shlobj_core-_ida typedef struct _IDA { UINT cidl; UINT
		// aoffset[1]; } CIDA, *LPIDA;
		[PInvokeData("shlobj_core.h", MSDNShortId = "30caf91d-8f3c-48ea-ad64-47f919f33f1d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CIDA
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of PIDLs that are being transferred, not including the parent folder.</para>
			/// </summary>
			public uint cidl;

			/// <summary>
			/// <para>Type: <c>UINT[1]</c></para>
			/// <para>
			/// An array of offsets, relative to the beginning of this structure. The array contains <c>cidl</c>+1 elements. The first
			/// element of <c>aoffset</c> contains an offset to the fully qualified PIDL of a parent folder. If this PIDL is empty, the
			/// parent folder is the desktop. Each of the remaining elements of the array contains an offset to one of the PIDLs to be
			/// transferred. All of these PIDLs are relative to the PIDL of the parent folder.
			/// </para>
			/// </summary>
			public IntPtr aoffset;

			/// <summary>
			/// <para>Type: <c>UINT[]</c></para>
			/// <para>
			/// An array of offsets, relative to the beginning of this structure. The array contains <c>cidl</c>+1 elements. The first
			/// element of <c>aoffset</c> contains an offset to the fully qualified PIDL of a parent folder. If this PIDL is empty, the
			/// parent folder is the desktop. Each of the remaining elements of the array contains an offset to one of the PIDLs to be
			/// transferred. All of these PIDLs are relative to the PIDL of the parent folder.
			/// </para>
			/// </summary>
			/// <value>Returns a <see cref="uint"/>[] value.</value>
			public uint[] offsets => aoffset.ToArray<uint>((int)cidl + 1);

			/// <summary>Gets the folder PIDL from <see cref="offsets"/>.</summary>
			/// <returns>A PIDL.</returns>
			public PIDL GetFolderPIDL()
			{
				using var pinned = new PinnedObject(this);
				return new PIDL(((IntPtr)pinned).Offset(offsets[0]), true);
			}

			/// <summary>Gets the item relative PIDL from <see cref="offsets"/> at the specified index.</summary>
			/// <param name="childIndex">Index of the child PIDL.</param>
			/// <returns>A PIDL.</returns>
			/// <exception cref="ArgumentOutOfRangeException">childIndex</exception>
			public PIDL GetItemRelativePIDL(int childIndex)
			{
				if (childIndex >= cidl) throw new ArgumentOutOfRangeException(nameof(childIndex));
				using var pinned = new PinnedObject(this);
				return new PIDL(((IntPtr)pinned).Offset(offsets[childIndex + 1]), true);
			}
		}

		/// <summary>Describes the image and accompanying text for a drop object.</summary>
		/// <remarks>
		/// Some UI coloring is applied to the text in szInsert if used by specifying %1 in szMessage. The characters %% and %1 are the
		/// subset of FormatMessage markers that are processed here.
		/// </remarks>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "78757001-cac8-412d-a6c3-74bae6eb3ad8")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DROPDESCRIPTION
		{
			/// <summary>A DROPIMAGETYPE indicating the stock image to use.</summary>
			public DROPIMAGETYPE type;

			/// <summary>Text such as "Move to %1".</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szMessage;

			/// <summary>Text such as "Documents", inserted as specified by szMessage.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szInsert;
		}

		/// <summary>
		/// <para>Defines the CF_HDROP clipboard format. The data that follows is a double null-terminated list of file names.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ns-shlobj_core-_dropfiles typedef struct _DROPFILES { DWORD
		// pFiles; POINT pt; BOOL fNC; BOOL fWide; } DROPFILES, *LPDROPFILES;
		[PInvokeData("shlobj_core.h", MSDNShortId = "e1f80529-2151-4ff6-95e0-afff67f2f117")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DROPFILES
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The offset of the file list from the beginning of this structure, in bytes.</para>
			/// </summary>
			public uint pFiles;

			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The drop point. The coordinates depend on <c>fNC</c>.</para>
			/// </summary>
			public System.Drawing.Point pt;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// A nonclient area flag. If this member is <c>TRUE</c>, <c>pt</c> specifies the screen coordinates of a point in a window's
			/// nonclient area. If it is <c>FALSE</c>, <c>pt</c> specifies the client coordinates of a point in the client area.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fNC;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// A value that indicates whether the file contains ANSI or Unicode characters. If the value is zero, the file contains ANSI
			/// characters. Otherwise, it contains Unicode characters.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fWide;
		}

		/// <summary>
		/// Describes the properties of a file that is being copied by means of the clipboard during a Microsoft ActiveX drag-and-drop operation.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the CFSTR_FILECONTENTS format that corresponds to this structure contains the file as a global memory object,
		/// <c>nFileSizeHigh</c> and <c>nFileSizeLow</c> specify the size of the associated memory block. If they are set, they can also be
		/// used if a user-interface needs to be displayed. For example, if a file is about to be overwritten, you would typically use
		/// information from this structure to display a dialog box containing the size, data, and name of the file.
		/// </para>
		/// <para>
		/// To create a zero-length file, set the <c>FD_FILESIZE</c> flag in the <c>dwFlags</c>, and set <c>nFileSizeHigh</c> and
		/// <c>nFileSizeLow</c> to zero. The CFSTR_FILECONTENTS format should represent the file as either a stream or global memory object
		/// (TYMED_ISTREAM or TYMED_HGLOBAL).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ns-shlobj_core-_filedescriptora typedef struct _FILEDESCRIPTORA
		// { DWORD dwFlags; CLSID clsid; SIZEL sizel; POINTL pointl; DWORD dwFileAttributes; FILETIME ftCreationTime; FILETIME
		// ftLastAccessTime; FILETIME ftLastWriteTime; DWORD nFileSizeHigh; DWORD nFileSizeLow; CHAR cFileName[MAX_PATH]; } FILEDESCRIPTORA, *LPFILEDESCRIPTORA;
		[PInvokeData("shlobj_core.h", MSDNShortId = "b81a7e52-5bd8-4fa4-bd76-9a58afaceec0")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FILEDESCRIPTOR
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// An array of flags that indicate which of the other structure members contain valid data. This member can be a combination of
			/// the following values.
			/// </para>
			/// <para>FD_CLSID (0x00000001)</para>
			/// <para>0x00000001. The <c>clsid</c> member is valid.</para>
			/// <para>FD_SIZEPOINT (0x00000002)</para>
			/// <para>0x00000002. The <c>sizel</c> and <c>pointl</c> members are valid.</para>
			/// <para>FD_ATTRIBUTES (0x00000004)</para>
			/// <para>0x00000004. The <c>dwFileAttributes</c> member is valid.</para>
			/// <para>FD_CREATETIME (0x00000008)</para>
			/// <para>0x00000008. The <c>ftCreationTime</c> member is valid.</para>
			/// <para>FD_ACCESSTIME (0x00000010)</para>
			/// <para>0x00000010. The <c>ftLastAccessTime</c> member is valid.</para>
			/// <para>FD_WRITESTIME (0x00000020)</para>
			/// <para>0x00000020. The <c>ftLastWriteTime</c> member is valid.</para>
			/// <para>FD_FILESIZE (0x00000040)</para>
			/// <para>0x00000040. The <c>nFileSizeHigh</c> and <c>nFileSizeLow</c> members are valid.</para>
			/// <para>FD_PROGRESSUI (0x00004000)</para>
			/// <para>0x00004000. A progress indicator is shown with drag-and-drop operations.</para>
			/// <para>FD_LINKUI (0x00008000)</para>
			/// <para>0x00008000. Treat the operation as a shortcut.</para>
			/// <para>FD_UNICODE ((int)0x80000000)</para>
			/// <para>(int)0x80000000. <c>Windows Vista and later</c>. The descriptor is Unicode.</para>
			/// </summary>
			public FD_FLAGS dwFlags;

			/// <summary>
			/// <para>Type: <c>CLSID</c></para>
			/// <para>The file type identifier.</para>
			/// </summary>
			public Guid clsid;

			/// <summary>
			/// <para>Type: <c>SIZEL</c></para>
			/// <para>The width and height of the file icon.</para>
			/// </summary>
			public SIZE sizel;

			/// <summary>
			/// <para>Type: <c>POINTL</c></para>
			/// <para>The screen coordinates of the file object.</para>
			/// </summary>
			public Point pointl;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>File attribute flags. This will be a combination of the FILE_ATTRIBUTE_ values described in GetFileAttributes.</para>
			/// </summary>
			public FileFlagsAndAttributes dwFileAttributes;

			/// <summary>
			/// <para>Type: <c>FILETIME</c></para>
			/// <para>The FILETIME structure that contains the time of file creation.</para>
			/// </summary>
			public FILETIME ftCreationTime;

			/// <summary>
			/// <para>Type: <c>FILETIME</c></para>
			/// <para>The FILETIME structure that contains the time that the file was last accessed.</para>
			/// </summary>
			public FILETIME ftLastAccessTime;

			/// <summary>
			/// <para>Type: <c>FILETIME</c></para>
			/// <para>The FILETIME structure that contains the time of the last write operation.</para>
			/// </summary>
			public FILETIME ftLastWriteTime;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The high-order <c>DWORD</c> of the file size, in bytes.</para>
			/// </summary>
			public uint nFileSizeHigh;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The low-order <c>DWORD</c> of the file size, in bytes.</para>
			/// </summary>
			public uint nFileSizeLow;

			/// <summary>
			/// <para>Type: <c>TCHAR[MAX_PATH]</c></para>
			/// <para>The null-terminated string that contains the name of the file.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string cFileName;

			/// <summary>The file size, in bytes.</summary>
			public ulong nFileSize
			{
				get => Macros.MAKELONG64(nFileSizeLow, nFileSizeHigh);
				set
				{
					nFileSizeHigh = (uint)(value >> 32);
					nFileSizeLow = (uint)(value & 0xFFFFFFFF);
				}
			}
		}

		/// <summary>Defines the CF_FILEGROUPDESCRIPTOR clipboard format.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ns-shlobj_core-_filegroupdescriptora typedef struct
		// _FILEGROUPDESCRIPTORA { UINT cItems; FILEDESCRIPTORA fgd[1]; } FILEGROUPDESCRIPTORA, *LPFILEGROUPDESCRIPTORA;
		[PInvokeData("shlobj_core.h", MSDNShortId = "9357ab73-086c-44db-8f89-e14240647e89")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FILEGROUPDESCRIPTOR : IEnumerable<FILEDESCRIPTOR>
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of elements in <c>fgd</c>.</para>
			/// </summary>
			public uint cItems;

			/// <summary>
			/// <para>Type: <c>FILEDESCRIPTOR[1]</c></para>
			/// <para>An array of FILEDESCRIPTOR structures that contain the file information.</para>
			/// </summary>
			public IntPtr fgd;

			/// <inheritdoc/>
			public IEnumerator<FILEDESCRIPTOR> GetEnumerator() => fgd.ToIEnum<FILEDESCRIPTOR>((int)cItems).GetEnumerator();

			/// <inheritdoc/>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		/// <summary>Defines the CF_NETRESOURCE clipboard format.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ns-shlobj_core-_nresarray typedef struct _NRESARRAY { UINT
		// cItems; NETRESOURCE nr[1]; } NRESARRAY, *LPNRESARRAY;
		[PInvokeData("shlobj_core.h", MSDNShortId = "261338c2-8fb4-4d10-8392-f9f6254a30ed")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NRESARRAY
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of elements in the <c>nr</c> array.</para>
			/// </summary>
			public uint cItems;

			/// <summary>
			/// <para>Type: <c>NETRESOURCE[1]</c></para>
			/// <para>
			/// The array of NETRESOURCE structures that contain information about network resources. The string members ( <c>LPSTR</c>
			/// types) in the structure contain offsets instead of addresses.
			/// </para>
			/// </summary>
			public IntPtr nr;
		}

		/// <summary>
		/// <para>Contains the information needed to create a drag image.</para>
		/// </summary>
		/// <remarks>
		/// <para>In Windows Vista this structure is defined in Shobjidl.idl. Prior to that, it was defined in Shlobj.h.</para>
		/// <para>Use the following procedure to create the drag image.</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Create a bitmap of the size specified by <c>sizeDragImage</c> with a handle to a device context (HDC) that is compatible with
		/// the screen.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Draw the bitmap.</term>
		/// </item>
		/// <item>
		/// <term>Select the bitmap out of the HDC it was created with.</term>
		/// </item>
		/// <item>
		/// <term>Destroy the HDC.</term>
		/// </item>
		/// <item>
		/// <term>Assign the bitmap handle to <c>hbmpDragImage</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Turn off antialiasing when drawing text. Otherwise, artifacts could occur at the edges, between the text color and
		/// the color key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ns-shobjidl_core-shdragimage typedef struct SHDRAGIMAGE { SIZE
		// sizeDragImage; POINT ptOffset; HBITMAP hbmpDragImage; COLORREF crColorKey; } SHDRAGIMAGE, *LPSHDRAGIMAGE;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "e0dd76b2-fd5c-41e8-b540-db90a2f0dcec")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SHDRAGIMAGE
		{
			/// <summary>
			/// <para>Type: <c>SIZE</c></para>
			/// <para>A SIZE structure with the length and width of the drag image.</para>
			/// </summary>
			public SIZE sizeDragImage;

			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>
			/// A POINT structure that specifies the location of the cursor within the drag image. The structure should contain the offset
			/// from the upper-left corner of the drag image to the location of the cursor.
			/// </para>
			/// </summary>
			public System.Drawing.Point ptOffset;

			/// <summary>
			/// <para>Type: <c>HBITMAP</c></para>
			/// <para>The drag image's bitmap handle.</para>
			/// </summary>
			public HBITMAP hbmpDragImage;

			/// <summary>
			/// <para>Type: <c>COLORREF</c></para>
			/// <para>The color used by the control to fill the background of the drag image.</para>
			/// </summary>
			public COLORREF crColorKey;
		}

		/// <summary>
		/// <para>
		/// Shell clipboard formats are used to identify the type of Shell data being transferred through the clipboard. Most Shell
		/// clipboard formats identify a type of data, such as a list of file names or pointers to item identifier lists (PIDLs). However,
		/// some formats are used for communication between source and target. They can expedite the data transfer process by supporting
		/// Shell operations such as optimized move and delete_on_paste. Shell data is always contained in a data object that uses a
		/// FORMATETC structure as a more general way to characterize data. The structure's cfFormat member is set to the clipboard format
		/// for the particular item of data. The other members provide additional information, such as the data transfer mechanism. The data
		/// is contained in an accompanying STGMEDIUM structure.
		/// </para>
		/// <note type="note">Standard clipboard format identifiers have the form CF_XXX.A common example is CF_TEXT, which is used for
		/// transferring ANSI text data. These identifiers have predefined values and can be used directly with FORMATETC structures. With
		/// the exception of CF_HDROP, Shell format identifiers are not predefined. With the exception of DragWindow, they have the form
		/// CFSTR_XXX.To differentiate these values from predefined formats, they are often referred to as simply formats. However, unlike
		/// predefined formats, they must be registered by both source and target before they can be used to transfer data. To register a
		/// Shell format, include the Shlobj.h header file and pass the CFSTR_XXX format identifier to RegisterClipboardFormat. This function
		/// returns a valid clipboard format value, which can then be used as the cfFormat member of a FORMATETC structure.</note>
		/// </summary>
		public static class ShellClipboardFormat
		{
			/// <summary>HTML Format</summary>
			public const string CF_HTML = "HTML Format";

			/// <summary>Rich Text Format</summary>
			public const string CF_RTF = "Rich Text Format";

			/// <summary>Rich Text Format Without Objects</summary>
			public const string CF_RTFNOOBJS = "Rich Text Format Without Objects";

			/// <summary>RichEdit Text and Objects</summary>
			public const string CF_RETEXTOBJ = "RichEdit Text and Objects";

			/// <summary>Comma Separated Value</summary>
			public const string CF_CSV = "Csv";

			/// <summary>Undocumented.</summary>
			public const string CFSTR_AUTOPLAY_SHELLIDLISTS = "Autoplay Enumerated IDList Array";

			/// <summary>Undocumented.</summary>
			public const string CFSTR_DROPDESCRIPTION = "DropDescription";

			/// <summary>Undocumented.</summary>
			public const string CFSTR_FILE_ATTRIBUTES_ARRAY = "File Attributes Array";

			/// <summary>
			/// This format identifier is used with the CFSTR_FILEDESCRIPTOR format to transfer data as if it were a file, regardless of how
			/// it is actually stored. The data consists of an STGMEDIUM structure that represents the contents of one file. The file is
			/// normally represented as a stream object, which avoids having to place the contents of the file in memory. In that case, the
			/// tymed member of the STGMEDIUM structure is set to TYMED_ISTREAM, and the file is represented by an IStream interface. The
			/// file can also be a storage or global memory object (TYMED_ISTORAGE or TYMED_HGLOBAL). The associated CFSTR_FILEDESCRIPTOR
			/// format contains a FILEDESCRIPTOR structure for each file that specifies the file's name and attributes.
			/// <para>
			/// The target treats the data associated with a CFSTR_FILECONTENTS format as if it were a file.When the target calls
			/// IDataObject::GetData to extract the data, it specifies a particular file by setting the lindex member of the FORMATETC
			/// structure to the zero-based index of the file's FILEDESCRIPTOR structure in the accompanying CFSTR_FILEDESCRIPTOR format.
			/// The target then uses the returned interface pointer or global memory handle to extract the data.
			/// </para>
			/// </summary>
			public const string CFSTR_FILECONTENTS = "FileContents";

			/// <summary>
			/// This format identifier is used with the CFSTR_FILECONTENTS format to transfer data as a group of files. These two formats
			/// are the preferred way to transfer Shell objects that are not stored as file-system files. For example, these formats can be
			/// used to transfer a group of email messages as individual files, even though each email is actually stored as a block of data
			/// in a database. The data consists of an STGMEDIUM structure that contains a global memory object. The structure's hGlobal
			/// member points to a FILEGROUPDESCRIPTOR structure that is followed by an array containing one FILEDESCRIPTOR structure for
			/// each file in the group. For each FILEDESCRIPTOR structure, there is a separate CFSTR_FILECONTENTS format that contains the
			/// contents of the file. To identify a particular file's CFSTR_FILECONTENTS format, set the lIndex value of the FORMATETC
			/// structure to the zero-based index of the file's FILEDESCRIPTOR structure.
			/// <para>
			/// The CFSTR_FILEDESCRIPTOR format is commonly used to transfer data as if it were a group of files, regardless of how it is
			/// actually stored. From the target's perspective, each CFSTR_FILECONTENTS format represents a single file and is treated
			/// accordingly. However, the source can store the data in any way it chooses. While a CSFTR_FILECONTENTS format might
			/// correspond to a single file, it could also, for example, represent data extracted by the source from a database or text document.
			/// </para>
			/// </summary>
			public const string CFSTR_FILEDESCRIPTORA = "FileGroupDescriptor";

			/// <summary>
			/// This format identifier is used with the CFSTR_FILECONTENTS format to transfer data as a group of files. These two formats
			/// are the preferred way to transfer Shell objects that are not stored as file-system files. For example, these formats can be
			/// used to transfer a group of email messages as individual files, even though each email is actually stored as a block of data
			/// in a database. The data consists of an STGMEDIUM structure that contains a global memory object. The structure's hGlobal
			/// member points to a FILEGROUPDESCRIPTOR structure that is followed by an array containing one FILEDESCRIPTOR structure for
			/// each file in the group. For each FILEDESCRIPTOR structure, there is a separate CFSTR_FILECONTENTS format that contains the
			/// contents of the file. To identify a particular file's CFSTR_FILECONTENTS format, set the lIndex value of the FORMATETC
			/// structure to the zero-based index of the file's FILEDESCRIPTOR structure.
			/// <para>
			/// The CFSTR_FILEDESCRIPTOR format is commonly used to transfer data as if it were a group of files, regardless of how it is
			/// actually stored. From the target's perspective, each CFSTR_FILECONTENTS format represents a single file and is treated
			/// accordingly. However, the source can store the data in any way it chooses. While a CSFTR_FILECONTENTS format might
			/// correspond to a single file, it could also, for example, represent data extracted by the source from a database or text document.
			/// </para>
			/// </summary>
			public const string CFSTR_FILEDESCRIPTORW = "FileGroupDescriptorW";

			/// <summary>
			/// This format identifier is used to transfer a single file. The data consists of an STGMEDIUM structure that contains a global
			/// memory object. The structure's hGlobal member points to a single null-terminated string containing the file's fully
			/// qualified file path. This format has been superseded by CF_HDROP, but it is supported for backward compatibility with
			/// Windows 3.1 applications.
			/// </summary>
			public const string CFSTR_FILENAMEA = "FileName";

			/// <summary>
			/// This format identifier is used when a group of files in CF_HDROP format is being renamed as well as transferred. The data
			/// consists of an STGMEDIUM structure that contains a global memory object. The structure's hGlobal member points to a double
			/// null-terminated character array. This array contains a new name for each file, in the same order that the files are listed
			/// in the accompanying CF_HDROP format. The format of the character array is the same as that used by CF_HDROP to list the
			/// transferred files.
			/// </summary>
			public const string CFSTR_FILENAMEMAPA = "FileNameMap";

			/// <summary>
			/// This format identifier is used when a group of files in CF_HDROP format is being renamed as well as transferred. The data
			/// consists of an STGMEDIUM structure that contains a global memory object. The structure's hGlobal member points to a double
			/// null-terminated character array. This array contains a new name for each file, in the same order that the files are listed
			/// in the accompanying CF_HDROP format. The format of the character array is the same as that used by CF_HDROP to list the
			/// transferred files.
			/// </summary>
			public const string CFSTR_FILENAMEMAPW = "FileNameMapW";

			/// <summary>
			/// This format identifier is used to transfer a single file. The data consists of an STGMEDIUM structure that contains a global
			/// memory object. The structure's hGlobal member points to a single null-terminated string containing the file's fully
			/// qualified file path. This format has been superseded by CF_HDROP, but it is supported for backward compatibility with
			/// Windows 3.1 applications.
			/// </summary>
			public const string CFSTR_FILENAMEW = "FileNameW";

			/// <summary>
			/// This format identifier is used by a data object to indicate whether it is in a drag-and-drop loop. The data is an STGMEDIUM
			/// structure that contains a global memory object. The structure's hGlobal member points to a DWORD value. If the DWORD value
			/// is nonzero, the data object is within a drag-and-drop loop. If the value is set to zero, the data object is not within a
			/// drag-and-drop loop.
			/// <para>
			/// Some drop targets might call IDataObject::GetData and attempt to extract data while the object is still within the
			/// drag-and-drop loop. Fully rendering the object for each such occurrence might cause the drag cursor to stall. If the data
			/// object supports CFSTR_INDRAGLOOP, the target can instead use that format to check the status of the drag-and-drop loop and
			/// avoid memory intensive rendering of the object until it is actually dropped. The formats that are memory intensive to render
			/// should still be included in the FORMATETC enumerator and in calls to IDataObject::QueryGetData.If the data object does not
			/// set CFSTR_INDRAGLOOP, it should act as if the value is set to zero.
			/// </para>
			/// </summary>
			public const string CFSTR_INDRAGLOOP = "InShellDragLoop";

			/// <summary>
			/// This format identifier replaces CFSTR_SHELLURL (deprecated). If you want your application to manipulate clipboard URLs, use
			/// CFSTR_INETURL instead of CFSTR_SHELLURL (deprecated). This format gives the best clipboard representation of a single URL.
			/// If UNICODE is not defined, the application retrieves the CF_TEXT/CFSTR_SHELLURL version of the URL. If UNICODE is defined,
			/// the application retrieves the CF_UNICODE version of the URL.
			/// </summary>
			public const string CFSTR_INETURLA = CFSTR_SHELLURL;

			/// <summary>
			/// This format identifier replaces CFSTR_SHELLURL (deprecated). If you want your application to manipulate clipboard URLs, use
			/// CFSTR_INETURL instead of CFSTR_SHELLURL (deprecated). This format gives the best clipboard representation of a single URL.
			/// If UNICODE is not defined, the application retrieves the CF_TEXT/CFSTR_SHELLURL version of the URL. If UNICODE is defined,
			/// the application retrieves the CF_UNICODE version of the URL.
			/// </summary>
			public const string CFSTR_INETURLW = "UniformResourceLocatorW";

			/// <summary>Undocumented.</summary>
			public const string CFSTR_INVOKECOMMAND_DROPPARAM = "InvokeCommand DropParam";

			/// <summary>
			/// Version 5.0.This format identifier allows a drop source to call the data object's IDataObject::GetData method to determine
			/// the outcome of a Shell data transfer. The data is an STGMEDIUM structure that contains a global memory object. The
			/// structure's hGlobal member points to a DWORD containing a DROPEFFECT value.
			/// <para>
			/// The CFSTR_PERFORMEDDROPEFFECT format identifier was intended to allow the target to indicate to the data object what
			/// operation actually took place.However, the Shell uses optimized moves for file system objects whenever possible.In that
			/// case, the Shell normally sets the CFSTR_PERFORMEDDROPEFFECT value to DROPEFFECT_NONE, to indicate to the data object that
			/// the original data has been deleted. Thus, the source cannot use the CFSTR_PERFORMEDDROPEFFECT value to determine which
			/// operation has taken place. While most sources do not need this information, there are some exceptions. For instance, even
			/// though optimized moves eliminate the need for a source to delete any data, the source might still need to update a related
			/// database to indicate that the files have been moved or copied.
			/// </para>
			/// <para>
			/// If a source needs to know which operation took place, it can call the data object's IDataObject::GetData method and request
			/// the CFSTR_LOGICALPERFORMEDDROPEFFECT format. This format essentially reflects what happens from the user's point of view
			/// after the operation is complete.If a new file is created and the original file is deleted, the user sees a move operation
			/// and the format's data value is set to DROPEFFECT_MOVE. If the original file is still there, the user sees a copy operation
			/// and the format's data value is set to DROPEFFECT_COPY.If a link was created, the format's data value will be DROPEFFECT_LINK.
			/// </para>
			/// </summary>
			public const string CFSTR_LOGICALPERFORMEDDROPEFFECT = "Logical Performed DropEffect";

			/// <summary>
			/// This format identifier is used to transfer a path on a mounted volume. It is similar to CF_HDROP, but it contains only a
			/// single path and can handle the longer path strings that might be needed to represent a path when the volume is mounted on a
			/// folder. The data consists of an STGMEDIUM structure that contains a global memory object. The structure's hGlobal member
			/// points to a single null-terminated string containing the fully qualified file path. The path string must end with a '\'
			/// character, followed by the terminating NULL.
			/// <para>
			/// Prior to Windows 2000, volumes could be mounted only on drive letters.For Windows 2000 and later systems with an NTFS
			/// formatted drive, you can also mount volumes on empty folders. This feature allows a volume to be mounted without taking up a
			/// drive letter. The mounted volume can use any currently supported format, including FAT, FAT32, NTFS, and CDFS.
			/// </para>
			/// <para>
			/// You can add pages to a Drive Properties property sheet by implementing a property sheet handler. If the volume is mounted on
			/// a drive letter, the Shell passes path information to the handler with the CF_HDROP format. With Windows 2000 and later
			/// systems, the CF_HDROP format is used when a volume is mounted on a drive letter, just as with earlier systems.However, if a
			/// volume is mounted on a folder, the CFSTR_MOUNTEDVOLUME format identifier is used instead of CF_HDROP.
			/// </para>
			/// <para>
			/// If only drive letters will be used to mount volumes, only CF_HDROP will be used, and existing property sheet handlers will
			/// work as they did with earlier systems.However, if you want your handler to display a page for volumes that are mounted on
			/// folders as well as drive letters, the handler must be able to understand both the CSFTR_MOUNTEDVOLUME and CF_HDROP formats.
			/// </para>
			/// </summary>
			public const string CFSTR_MOUNTEDVOLUME = "MountedVolume";

			/// <summary>
			/// This format identifier is used when transferring network resources, such as a domain or server. The data is an STGMEDIUM
			/// structure that contains a global memory object. The structure's hGlobal member points to a NRESARRAY structure. The nr
			/// member of that structure indicates a NETRESOURCE structure whose lpRemoteName member contains a null-terminated string
			/// identifying the network resource. The drop target can then use the data with any of the Windows Networking (WNet) API
			/// functions, such as WNetAddConnection, to perform network operations on the object.
			/// </summary>
			public const string CFSTR_NETRESOURCES = "Net Resource";

			/// <summary>
			/// This format identifier is used by the target to inform the data object, through its IDataObject::SetData method, that a
			/// delete-on-paste operation succeeded. The data is an STGMEDIUM structure that contains a global memory object. The
			/// structure's hGlobal member points to a DWORD containing a DROPEFFECT value. This format is used to notify the data object
			/// that it should complete the cut operation and delete the original data, if necessary. For more information, see
			/// Delete-on-Paste Operations.
			/// </summary>
			public const string CFSTR_PASTESUCCEEDED = "Paste Succeeded";

			/// <summary>
			/// This format identifier is used by the target to inform the data object through its IDataObject::SetData method of the
			/// outcome of a data transfer. The data is an STGMEDIUM structure that contains a global memory object. The structure's hGlobal
			/// member points to a DWORD set to the appropriate DROPEFFECT value, normally DROPEFFECT_MOVE or DROPEFFECT_COPY.
			/// <para>
			/// This format is normally used when the outcome of an operation can be either move or copy, such as in an optimized move or
			/// delete-on-paste operation.It provides a reliable way for the target to tell the data object what actually happened. It was
			/// introduced because the value of pdwEffect returned by DoDragDrop did not reliably indicate which operation had taken place.
			/// The CFSTR_PERFORMEDDROPEFFECT format is the reliable way to indicate that an unoptimized move has taken place.
			/// </para>
			/// </summary>
			public const string CFSTR_PERFORMEDDROPEFFECT = "Performed DropEffect";

			/// <summary>Undocumented.</summary>
			public const string CFSTR_PERSISTEDDATAOBJECT = "PersistedDataObject";

			/// <summary>
			/// <para>
			/// This format identifier is used by the source to specify whether its preferred method of data transfer is move or copy. A
			/// drop target requests this format by calling the data object's IDataObject::GetData method. The data is an STGMEDIUM
			/// structure that contains a global memory object. The structure's hGlobal member points to a DWORD value. This value is set to
			/// DROPEFFECT_MOVE if a move operation is preferred or DROPEFFECT_COPY if a copy operation is preferred.
			/// </para>
			/// <para>
			/// This feature is used when a source can support either a move or copy operation. It uses the CFSTR_PREFERREDDROPEFFECT format
			/// to communicate its preference to the target. Because the target is not obligated to honor the request, the target must call
			/// the source's IDataObject::SetData method with a CFSTR_PERFORMEDDROPEFFECT format to tell the data object which operation was
			/// actually performed.
			/// </para>
			/// <para>
			/// With a delete-on-paste operation, the CFSTR_PREFERREDDROPFORMAT format is used to tell the target whether the source did a
			/// cut or copy. With a drag-and-drop operation, you can use CFSTR_PREFERREDDROPFORMAT to specify the Shell's action. If this
			/// format is not present, the Shell performs a default action, based on context. For instance, if a user drags a file from one
			/// volume and drops it on another volume, the Shell's default action is to copy the file. By including a
			/// CFSTR_PREFERREDDROPFORMAT format in the data object, you can override the default action and explicitly tell the Shell to
			/// copy, move, or link the file. If the user chooses to drag with the right button, CFSTR_PREFERREDDROPFORMAT specifies the
			/// default command on the drag-and-drop shortcut menu. The user is still free to choose other commands on the menu.
			/// </para>
			/// <para>
			/// Before Microsoft Internet Explorer 4.0, an application indicated that it was transferring shortcut file types by setting
			/// FD_LINKUI in the dwFlags member of the FILEDESCRIPTOR structure. Targets then had to use a potentially time-consuming call
			/// to IDataObject::GetData to find out if the FD_LINKUI flag was set. Now, the preferred way to indicate that shortcuts are
			/// being transferred is to use the CFSTR_PREFERREDDROPEFFECT format set to DROPEFFECT_LINK. However, for backward compatibility
			/// with older systems, sources should still set the FD_LINKUI flag.
			/// </para>
			/// </summary>
			public const string CFSTR_PREFERREDDROPEFFECT = "Preferred DropEffect";

			/// <summary>
			/// This format identifier is used when transferring the friendly names of printers. The data is an STGMEDIUM structure that
			/// contains a global memory object. The structure's hGlobal member points to a string in the same format as that used with
			/// CF_HDROP. However, the pFiles member of the DROPFILES structure contains one or more friendly names of printers instead of
			/// file paths.
			/// </summary>
			public const string CFSTR_PRINTERGROUP = "PrinterFriendlyName";

			/// <summary>Undocumented.</summary>
			public const string CFSTR_SHELLDROPHANDLER = "DropHandlerCLSID";

			/// <summary>
			///   <para>This format identifier is used when transferring the locations of one or more existing namespace objects. It is used in much the same way as CF_HDROP, but it contains PIDLs instead of file system paths. Using PIDLs allows the CFSTR_SHELLIDLIST format to handle virtual objects as well as file system objects. The data is an STGMEDIUM structure that contains a global memory object. The structure's hGlobal member points to a CIDA structure.</para>
			///   <para>The aoffset member of the CIDA structure is an array containing offsets to the beginning of the ITEMIDLIST structure for each PIDL that is being transferred. To extract a particular PIDL, first determine its index. Then, add the aoffset value that corresponds to that index to the address of the CIDA structure.</para>
			///   <para>The first element of aoffset contains an offset to the fully qualified PIDL of a parent folder. If this PIDL is empty, the parent folder is the desktop. Each of the remaining elements of the array contains an offset to one of the PIDLs to be transferred. All of these PIDLs are relative to the PIDL of the parent folder.</para>
			///   <para>The following two macros can be used to retrieve PIDLs from a CIDA structure. The first takes a pointer to the structure and retrieves the PIDL of the parent folder. The second takes a pointer to the structure and retrieves one of the other PIDLs, identified by its zero-based index.</para>
			///   <code lang="cpp">#define GetPIDLFolder(pida) (LPCITEMIDLIST)(((LPBYTE)pida)+(pida)-&gt;aoffset[0])
			///#define GetPIDLItem(pida, i) (LPCITEMIDLIST)(((LPBYTE)pida)+(pida)-&gt;aoffset[i+1])</code>
			///   <note type="note">The value that is returned by these macros is a pointer to the PIDL's ITEMIDLIST structure. Since these structures vary in length, you must determine the end of the structure by walking through each of the ITEMIDLIST structure's SHITEMID structures until you reach the two-byte NULL that marks the end.</note>
			/// </summary>
			public const string CFSTR_SHELLIDLIST = "Shell IDList Array";

			/// <summary>
			/// This format identifier is used with formats such as CF_HDROP, CFSTR_SHELLIDLIST, and CFSTR_FILECONTENTS to specify the
			/// position of a group of objects following a transfer. The data consists of an STGMEDIUM structure that contains a global
			/// memory object. The structure's hGlobal member points to an array of POINT structures. The first structure specifies the
			/// screen coordinates, in pixels, of the upper-left corner of the rectangle that encloses the group. The remainder of the
			/// structures specify the locations of the individual objects relative to the group's position. They must be in the same order
			/// as that used to list the objects in the associated format.
			/// </summary>
			public const string CFSTR_SHELLIDLISTOFFSET = "Shell Object Offsets";

			/// <summary><note type="note">This format identifier has been deprecated; use <see cref="CFSTR_INETURLA"/> instead.</note></summary>
			public const string CFSTR_SHELLURL = "UniformResourceLocator";

			/// <summary>
			/// <para>
			/// This format identifier is used by a target to provide its CLSID to the source. The data is an STGMEDIUM structure that
			/// contains a global memory object. The structure's hGlobal member points to the CLSID GUID of the drop target.
			/// </para>
			/// <para>
			/// This format is used primarily to allow objects to be deleted by dragging them to the Recycle Bin. When an object is dropped
			/// in the Recycle Bin, the source's IDataObject::SetData method is called with a CFSTR_TARGETCLSID format set to the Recycle
			/// Bin's CLSID (CLSID_RecycleBin). The source can then delete the original object.
			/// </para>
			/// </summary>
			public const string CFSTR_TARGETCLSID = "TargetCLSID";

			/// <summary>
			/// <para>
			/// This format identifier is used by Windows Internet Explorer and the Windows Shell to provide a mechanism through which to
			/// block or prompt for drag-and-drop operations originating from Internet Explorer in conjunction with the
			/// URLACTION_SHELL_ENHANCED_DRAGDROP_SECURITY flag.
			/// </para>
			/// <para>
			/// CFSTR_UNTRUSTEDDRAGDROP is added by the source of a drag-and-drop operation to specify that the data object might contain
			/// untrustworthy data. The data is represented by an STGMEDIUM structure that contains a global memory object. The structure's
			/// hGlobal member points to a DWORD set to an appropriate URL Action flag to cause a policy check through the
			/// IInternetSecurityManager::ProcessUrlAction method, using the PUAF_ENFORCERESTRICTED flag.
			/// </para>
			/// </summary>
			public const string CFSTR_UNTRUSTEDDRAGDROP = "UntrustedDragDrop";

			/// <summary>Undocumented.</summary>
			public const string CFSTR_ZONEIDENTIFIER = "ZoneIdentifier";
		}
	}
}