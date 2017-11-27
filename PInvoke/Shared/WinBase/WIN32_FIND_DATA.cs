using System;
using System.IO;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Contains information about the file that is found by the FindFirstFile, FindFirstFileEx, or FindNextFile function.</summary>
	[Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto), BestFitMapping(false)]
	public class WIN32_FIND_DATA
	{
		/// <summary>
		/// The file attributes of a file.
		/// <para>
		/// For possible values and their descriptions, see <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/gg258117(v=vs.85).aspx">File
		/// Attribute Constants</a>.
		/// </para>
		/// <para>The FILE_ATTRIBUTE_SPARSE_FILE attribute on the file is set if any of the streams of the file have ever been sparse.</para>
		/// </summary>
		public FileAttributes dwFileAttributes;

		/// <summary>
		/// A FILETIME structure that specifies when a file or directory was created.
		/// <para>If the underlying file system does not support creation time, this member is zero.</para>
		/// </summary>
		public FILETIME ftCreationTime;

		/// <summary>
		/// A FILETIME structure.
		/// <para>For a file, the structure specifies when the file was last read from, written to, or for executable files, run.</para>
		/// <para>
		/// For a directory, the structure specifies when the directory is created. If the underlying file system does not support last access time, this member
		/// is zero.
		/// </para>
		/// <para>On the FAT file system, the specified date for both files and directories is correct, but the time of day is always set to midnight.</para>
		/// </summary>
		public FILETIME ftLastAccessTime;

		/// <summary>
		/// A FILETIME structure.
		/// <para>
		/// For a file, the structure specifies when the file was last written to, truncated, or overwritten, for example, when WriteFile or SetEndOfFile are
		/// used. The date and time are not updated when file attributes or security descriptors are changed.
		/// </para>
		/// <para>
		/// For a directory, the structure specifies when the directory is created. If the underlying file system does not support last write time, this member
		/// is zero.
		/// </para>
		/// </summary>
		public FILETIME ftLastWriteTime;

		/// <summary>
		/// The high-order DWORD value of the file size, in bytes.
		/// <para>This value is zero unless the file size is greater than MAXDWORD.</para>
		/// <para>The size of the file is equal to (nFileSizeHigh * (MAXDWORD+1)) + nFileSizeLow.</para>
		/// </summary>
		public uint nFileSizeHigh;

		/// <summary>The low-order DWORD value of the file size, in bytes.</summary>
		public uint nFileSizeLow;

		/// <summary>
		/// If the dwFileAttributes member includes the FILE_ATTRIBUTE_REPARSE_POINT attribute, this member specifies the reparse point tag.
		/// <para>Otherwise, this value is undefined and should not be used.</para>
		/// </summary>
		public int dwReserved0;

		/// <summary>Reserved for future use.</summary>
		public int dwReserved1;

		/// <summary>The name of the file.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string cFileName;

		/// <summary>
		/// An alternative name for the file.
		/// <para>This name is in the classic 8.3 file name format.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)] public string cAlternateFileName;

		/// <summary>Gets the size of the file, combining <see cref="nFileSizeLow"/> and <see cref="nFileSizeHigh"/>.</summary>
		/// <value>The size of the file.</value>
		public ulong FileSize => Macros.MAKELONG64(nFileSizeLow, nFileSizeHigh);
	}
}