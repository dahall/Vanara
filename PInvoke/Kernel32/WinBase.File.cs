using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Flags used in the <see cref="CreateSymbolicLink"/> function.</summary>
		[PInvokeData("WinBase.h")]
		public enum SymbolicLinkType : uint
		{
			/// <summary>The link target is a file.</summary>
			SYMBOLIC_LINK_FLAG_FILE = 0x0,

			/// <summary>The link target is a directory.</summary>
			SYMBOLIC_LINK_FLAG_DIRECTORY = 0x1
		}

		/// <summary>
		/// Creates a symbolic link.
		/// </summary>
		/// <param name="lpSymlinkFileName">The symbolic link to be created.
		/// <para>This parameter may include the path. In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.</para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function (<c>CreateSymbolicLinkW</c>), you can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</note></param>
		/// <param name="lpTargetFileName">The name of the target for the symbolic link to be created.
		/// <para>If lpTargetFileName has a device name associated with it, the link is treated as an absolute link; otherwise, the link is treated as a relative link.</para>
		/// <para>This parameter may include the path. In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.</para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function (<c>CreateSymbolicLinkW</c>), you can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</note></param>
		/// <param name="dwFlags">Indicates whether the link target, lpTargetFileName, is a directory.</param>
		/// <returns>f the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363866")]
		public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName,
			SymbolicLinkType dwFlags);

		/// <summary>
		/// Establishes a hard link between an existing file and a new file. This function is only supported on the NTFS file system, and only for files, not directories.
		/// </summary>
		/// <param name="lpFileName">The name of the new file.
		/// <para>This parameter may include the path but cannot specify the name of a directory.</para>
		/// <para>In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.</para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function (<c>CreateHardLinkW</c>), you can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</note></param>
		/// <param name="lpExistingFileName">The name of the existing file.
		/// <para>This parameter may include the path but cannot specify the name of a directory.</para>
		/// <para>In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.</para>
		/// <note><c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function (<c>CreateHardLinkW</c>), you can opt-in to remove the <c>MAX_PATH</c> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</note></param>
		/// <param name="lpSecurityAttributes">Reserved; must be NULL.</param>
		/// <returns></returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363860")]
		public static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, [Optional] IntPtr lpSecurityAttributes);

		/// <summary>
		/// Retrieves the actual number of bytes of disk storage used to store a specified file. If the file is located on a volume that supports compression and
		/// the file is compressed, the value obtained is the compressed size of the specified file. If the file is located on a volume that supports sparse
		/// files and the file is a sparse file, the value obtained is the sparse size of the specified file.
		/// </summary>
		/// <param name="lpFileName">
		/// The name of the file.
		/// <para>Do not specify the name of a file on a nonseeking device, such as a pipe or a communications device, as its file size has no meaning.</para>
		/// <para>
		/// This parameter may include the path. In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters. To extend this
		/// limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see <a
		/// href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx">Naming a File</a>.
		/// </para>
		/// <para>
		/// <c>Tip</c> Starting with Windows 10, version 1607, for the Unicode version of this function ( <c>GetCompressedFileSizeW</c>), you can opt-in to
		/// remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of <a
		/// href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx">Naming Files, Paths, and Namespaces</a> for details.
		/// </para>
		/// </param>
		/// <param name="lpFileSizeHigh">
		/// The high-order DWORD of the compressed file size. The function's return value is the low-order DWORD of the compressed file size.
		/// <para>
		/// This parameter can be NULL if the high-order DWORD of the compressed file size is not needed.Files less than 4 gigabytes in size do not need the
		/// high-order DWORD.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the low-order DWORD of the actual number of bytes of disk storage used to store the specified file, and
		/// if <paramref name="lpFileSizeHigh"/> is non-NULL, the function puts the high-order DWORD of that actual value into the DWORD pointed to by that
		/// parameter. This is the compressed file size for compressed files, the actual file size for noncompressed files.
		/// <para>
		/// If the function fails, and <paramref name="lpFileSizeHigh"/> is NULL, the return value is INVALID_FILE_SIZE. To get extended error information, call GetLastError.
		/// </para>
		/// <para>
		/// If the return value is INVALID_FILE_SIZE and <paramref name="lpFileSizeHigh"/> is non-NULL, an application must call GetLastError to determine
		/// whether the function has succeeded (value is NO_ERROR) or failed (value is other than NO_ERROR).
		/// </para>
		/// </returns>
		/// <remarks>
		/// An application can determine whether a volume is compressed by calling <see cref="GetVolumeInformation(string, out string, out uint, out uint, out FileSystemFlags, out string)"/>,
		/// then checking the status of the FS_VOL_IS_COMPRESSED flag in the DWORD value pointed to by that function's lpFileSystemFlags parameter.
		/// <para>
		/// If the file is not located on a volume that supports compression or sparse files, or if the file is not compressed or a sparse file, the value
		/// obtained is the actual file size, the same as the value returned by a call to GetFileSize.
		/// </para>
		/// <para>Symbolic link behavior—If the path points to a symbolic link, the function returns the file size of the target.</para>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364930")]
		public static extern uint GetCompressedFileSize(string lpFileName, ref uint lpFileSizeHigh);

	}
}