using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Contains the basic information for a file. Used for file handles.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_basic_info typedef struct _FILE_BASIC_INFO { LARGE_INTEGER
	// CreationTime; LARGE_INTEGER LastAccessTime; LARGE_INTEGER LastWriteTime; LARGE_INTEGER ChangeTime; DWORD FileAttributes; }
	// FILE_BASIC_INFO, *PFILE_BASIC_INFO;
	[PInvokeData("winbase.h", MSDNShortId = "7765e430-cf6b-4ccf-b5e7-9fb6e15ca6d6")]
	[StructLayout(LayoutKind.Sequential, Size = 40)]
	public struct FILE_BASIC_INFO
	{
		/// <summary>
		/// The time the file was created in FILETIME format, which is a 64-bit value representing the number of 100-nanosecond intervals
		/// since January 1, 1601 (UTC).
		/// </summary>
		public FILETIME CreationTime;

		/// <summary>The time the file was last accessed in FILETIME format.</summary>
		public FILETIME LastAccessTime;

		/// <summary>The time the file was last written to in FILETIME format.</summary>
		public FILETIME LastWriteTime;

		/// <summary>The time the file was changed in FILETIME format.</summary>
		public FILETIME ChangeTime;

		/// <summary>
		/// The file attributes. For a list of attributes, see File Attribute Constants. If this is set to 0 in a <c>FILE_BASIC_INFO</c>
		/// structure passed to SetFileInformationByHandle then none of the attributes are changed.
		/// </summary>
		public FileFlagsAndAttributes FileAttributes;
	}
}