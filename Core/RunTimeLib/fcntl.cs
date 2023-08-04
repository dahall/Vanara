namespace Vanara.RunTimeLib;

/// <summary>
/// The integer expression formed from one or more of these constants determines the type of reading or writing operations permitted. It
/// is formed by combining one or more constants with a translation-mode constant.
/// </summary>
[Flags]
public enum FileOpConstant : int
{
	/// <summary>Opens file for reading only; if this flag is given, neither _O_RDWR nor _O_WRONLY can be given.</summary>
	_O_RDONLY = 0x0000,

	/// <summary>Opens file for writing only; if this flag is given, neither _O_RDONLY nor _O_RDWR can be given.</summary>
	_O_WRONLY = 0x0001,

	/// <summary>Opens file for both reading and writing; if this flag is given, neither _O_RDONLY nor _O_WRONLY can be given.</summary>
	_O_RDWR = 0x0002,

	/// <summary>Repositions the file pointer to the end of the file before every write operation.</summary>
	_O_APPEND = 0x0008,

	/// <summary>Creates and opens a new file for writing; this has no effect if the file specified by filename exists.</summary>
	_O_CREAT = 0x0100,

	/// <summary>
	/// Opens and truncates an existing file to zero length; the file must have write permission. The contents of the file are
	/// destroyed. If this flag is given, you cannot specify _O_RDONLY.
	/// </summary>
	_O_TRUNC = 0x0200,

	/// <summary>Returns an error value if the file specified by filename exists. Only applies when used with _O_CREAT.</summary>
	_O_EXCL = 0x0400,

	/// <summary>Opens a file in text (translated) mode. (For more information, see Text and Binary Mode File I/O and fopen.)</summary>
	_O_TEXT = 0x4000,

	/// <summary>Opens the file in binary (untranslated) mode. (See fopen for a description of binary mode.)</summary>
	_O_BINARY = 0x8000,

	/// <summary>Opens a file in Unicode mode.</summary>
	_O_WTEXT = 0x10000,

	/// <summary>Opens a file in Unicode UTF-16 mode.</summary>
	_O_U16TEXT = 0x20000,

	/// <summary>Opens a file in Unicode UTF-8 mode.</summary>
	_O_U8TEXT = 0x40000,

	// macro to translate the C 2.0 name used to force binary mode for files
	/// <summary></summary>
	_O_RAW = _O_BINARY,

	/// <summary>Prevents creation of a shared file descriptor.</summary>
	_O_NOINHERIT = 0x0080,

	/// <summary>
	/// Creates a file as temporary; the file is deleted when the last file descriptor is closed. The pmode argument is required when
	/// _O_CREAT is specified.
	/// </summary>
	_O_TEMPORARY = 0x0040,

	/// <summary>
	/// Creates a file as temporary and if possible does not flush to disk. The pmode argument is required when _O_CREAT is specified.
	/// </summary>
	_O_SHORT_LIVED = 0x1000,

	/// <summary>get information about a directory</summary>
	_O_OBTAIN_DIR = 0x2000,

	/// <summary>Specifies that caching is optimized for, but not restricted to, sequential access from disk.</summary>
	_O_SEQUENTIAL = 0x0020,

	/// <summary>Specifies that caching is optimized for, but not restricted to, random access from disk.</summary>
	_O_RANDOM = 0x0010,
}