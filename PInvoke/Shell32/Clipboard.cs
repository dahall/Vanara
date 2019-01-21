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

		/// <summary><para>Used with the CFSTR_SHELLIDLIST clipboard format to transfer the pointer to an item identifier list (PIDL) of one or more Shell namespace objects.</para></summary><remarks><para>To use this structure to retrieve a particular PIDL, add the <c>aoffset</c> value of the PIDL to the address of the structure. The following two macros can be used to retrieve PIDLs from the structure. The first retrieves the PIDL of the parent folder. The second retrieves a PIDL, specified by its zero-based index.</para><para>The value that is returned by these macros is a pointer to the ITEMIDLIST structure. Since these structures vary in length, you must determine the end of the structure by parsing it. See NameSpace for further discussion of PIDLs and the <c>ITEMIDLIST</c> structure.</para></remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ns-shlobj_core-_ida
		// typedef struct _IDA { UINT cidl; UINT aoffset[1]; } CIDA, *LPIDA;
		[PInvokeData("shlobj_core.h", MSDNShortId = "30caf91d-8f3c-48ea-ad64-47f919f33f1d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CIDA
		{
			/// <summary>
			///   <para>Type: <c>UINT</c></para><para>The number of PIDLs that are being transferred, not including the parent folder.</para>
			/// </summary>
			public uint cidl;

			/// <summary>
			///   <para>Type: <c>UINT[1]</c></para><para>An array of offsets, relative to the beginning of this structure. The array contains <c>cidl</c>+1 elements. The first element of <c>aoffset</c> contains an offset to the fully qualified PIDL of a parent folder. If this PIDL is empty, the parent folder is the desktop. Each of the remaining elements of the array contains an offset to one of the PIDLs to be transferred. All of these PIDLs are relative to the PIDL of the parent folder.</para>
			/// </summary>
			public IntPtr aoffset;

			/// <summary>
			///   <para>Type: <c>UINT[]</c></para><para>An array of offsets, relative to the beginning of this structure. The array contains <c>cidl</c>+1 elements. The first element of <c>aoffset</c> contains an offset to the fully qualified PIDL of a parent folder. If this PIDL is empty, the parent folder is the desktop. Each of the remaining elements of the array contains an offset to one of the PIDLs to be transferred. All of these PIDLs are relative to the PIDL of the parent folder.</para>
			/// </summary>
			/// <value>Returns a <see cref="UInt32[]"/> value.</value>
			public uint[] offsets => aoffset.ToArray<uint>((int)cidl + 1);

			public PIDL GetFolderPIDL()
			{
				using (var pinned = new PinnedObject(this))
					return new PIDL(((IntPtr)pinned).Offset(offsets[0]), true);
			}

			public PIDL GetItemRelativePIDL(int childIndex)
			{
				if (childIndex >= cidl) throw new ArgumentOutOfRangeException(nameof(childIndex));
				using (var pinned = new PinnedObject(this))
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/ns-shlobj_core-_filedescriptora typedef struct _FILEDESCRIPTORA {
		// DWORD dwFlags; CLSID clsid; SIZEL sizel; POINTL pointl; DWORD dwFileAttributes; FILETIME ftCreationTime; FILETIME
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
		/// Create a bitmap of the size specified by <c>sizeDragImage</c> with a handle to a device context (HDC) that is compatible with the screen.
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
		/// Shell clipboard formats are used to identify the type of Shell data being transferred through the clipboard. Most Shell clipboard
		/// formats identify a type of data, such as a list of file names or pointers to item identifier lists (PIDLs). However, some formats
		/// are used for communication between source and target. They can expedite the data transfer process by supporting Shell operations
		/// such as optimized move and delete_on_paste. Shell data is always contained in a data object that uses a FORMATETC structure as a
		/// more general way to characterize data. The structure's cfFormat member is set to the clipboard format for the particular item of
		/// data. The other members provide additional information, such as the data transfer mechanism. The data is contained in an
		/// accompanying STGMEDIUM structure.
		/// </para>
		/// <note type="note">Standard clipboard format identifiers have the form CF_XXX.A common example is CF_TEXT, which is used for
		/// transferring ANSI text data.These identifiers have predefined values and can be used directly with FORMATETC structures. With the
		/// exception of CF_HDROP, Shell format identifiers are not predefined. With the exception of DragWindow, they have the form
		/// CFSTR_XXX.To differentiate these values from predefined formats, they are often referred to as simply formats. However, unlike
		/// predefined formats, they must be registered by both source and target before they can be used to transfer data.To register a
		/// Shell format, include the Shlobj.h header file and pass the CFSTR_XXX format identifier to RegisterClipboardFormat.This function
		/// returns a valid clipboard format value, which can then be used as the cfFormat member of a FORMATETC structure.</note>
		/// </summary>
		public static class ShellClipboardFormat
		{
			public const string CFSTR_SHELLIDLIST = "Shell IDList Array";
			public const string CFSTR_SHELLIDLISTOFFSET = "Shell Object Offsets";
			public const string CFSTR_NETRESOURCES = "Net Resource";
			public const string CFSTR_FILEDESCRIPTORA = "FileGroupDescriptor";
			public const string CFSTR_FILEDESCRIPTORW = "FileGroupDescriptorW";
			public const string CFSTR_FILECONTENTS = "FileContents";
			public const string CFSTR_FILENAMEA = "FileName";
			public const string CFSTR_FILENAMEW = "FileNameW";
			public const string CFSTR_PRINTERGROUP = "PrinterFriendlyName";
			public const string CFSTR_FILENAMEMAPA = "FileNameMap";
			public const string CFSTR_FILENAMEMAPW = "FileNameMapW";
			public const string CFSTR_SHELLURL = "UniformResourceLocator";
			public const string CFSTR_INETURLA = CFSTR_SHELLURL;
			public const string CFSTR_INETURLW = "UniformResourceLocatorW";
			public const string CFSTR_PREFERREDDROPEFFECT = "Preferred DropEffect";
			public const string CFSTR_PERFORMEDDROPEFFECT = "Performed DropEffect";
			public const string CFSTR_PASTESUCCEEDED = "Paste Succeeded";
			public const string CFSTR_INDRAGLOOP = "InShellDragLoop";
			public const string CFSTR_MOUNTEDVOLUME = "MountedVolume";
			public const string CFSTR_PERSISTEDDATAOBJECT = "PersistedDataObject";
			public const string CFSTR_TARGETCLSID = "TargetCLSID";
			public const string CFSTR_LOGICALPERFORMEDDROPEFFECT = "Logical Performed DropEffect";
			public const string CFSTR_AUTOPLAY_SHELLIDLISTS = "Autoplay Enumerated IDList Array";
			public const string CFSTR_UNTRUSTEDDRAGDROP = "UntrustedDragDrop";
			public const string CFSTR_FILE_ATTRIBUTES_ARRAY = "File Attributes Array";
			public const string CFSTR_INVOKECOMMAND_DROPPARAM = "InvokeCommand DropParam";
			public const string CFSTR_SHELLDROPHANDLER = "DropHandlerCLSID";
			public const string CFSTR_DROPDESCRIPTION = "DropDescription";
			public const string CFSTR_ZONEIDENTIFIER = "ZoneIdentifier";
		}
	}
}