using System;

namespace Vanara.RunTimeLib
{
	/// <summary>These constants specify the current attributes of the file or directory specified by the function.</summary>
	[Flags]
	public enum FileAttributeConstant : int
	{
		/// <summary>Normal. File can be read or written to without restriction.</summary>
		_A_NORMAL = 0x00,

		/// <summary>Read-only. File cannot be opened for writing, and a file with the same name cannot be created.</summary>
		_A_RDONLY = 0x01,

		/// <summary>
		/// Hidden file. Not normally seen with the DIR command, unless the /AH option is used. Returns information about normal files as
		/// well as files with this attribute.
		/// </summary>
		_A_HIDDEN = 0x02,

		/// <summary>System file. Not normally seen with the DIR command, unless the /AS option is used.</summary>
		_A_SYSTEM = 0x04,

		/// <summary>Subdirectory.</summary>
		_A_SUBDIR = 0x10,

		/// <summary>Archive. Set whenever the file is changed, and cleared by the BACKUP command.</summary>
		_A_ARCH = 0x20,
	}
}