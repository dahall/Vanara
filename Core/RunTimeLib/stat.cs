using System;

namespace Vanara.RunTimeLib
{
	/// <summary>These constants are used to indicate file type in the st_mode field of the _stat structure.</summary>
	[Flags]
	public enum FilePermissionConstant : int
	{
		/// <summary>File type mask</summary>
		_S_IFMT = 0xF000,

		/// <summary>Directory</summary>
		_S_IFDIR = 0x4000,

		/// <summary>Character special</summary>
		_S_IFCHR = 0x2000,

		/// <summary>Pipe</summary>
		_S_IFIFO = 0x1000,

		/// <summary>Regular</summary>
		_S_IFREG = 0x8000,

		/// <summary>Read permission, owner</summary>
		_S_IREAD = 0x0100,

		/// <summary>Write permission, owner</summary>
		_S_IWRITE = 0x0080,

		/// <summary>Execute/search permission, owner</summary>
		_S_IEXEC = 0x0040,
	}
}