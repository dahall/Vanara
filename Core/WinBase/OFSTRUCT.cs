namespace Vanara.PInvoke;

/// <summary>Contains information about a file that the <c>OpenFile</c> function opened or attempted to open.</summary>
/// <param name="pathName">The path and file name of the file.</param>
/// <param name="fixedDisk">If this member is <see langword="true"/>, the file is on a hard (fixed) disk. Otherwise, it is not.</param>
// typedef struct _OFSTRUCT { BYTE cBytes; BYTE fFixedDisk; WORD nErrCode; WORD Reserved1; WORD Reserved2; CHAR
// szPathName[OFS_MAXPATHNAME];} OFSTRUCT,
// *POFSTRUCT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa365282(v=vs.85).aspx
[PInvokeData("WinBase.h", MSDNShortId = "aa365282")]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct OFSTRUCT(string pathName = "", bool fixedDisk = false)
{
	/// <summary>The size of the structure, in bytes.</summary>
	public byte cBytes = (byte)Marshal.SizeOf<OFSTRUCT>();

	/// <summary>If this member is <see langword="true"/>, the file is on a hard (fixed) disk. Otherwise, it is not.</summary>
	[MarshalAs(UnmanagedType.U1)]
	public bool fFixedDisk = fixedDisk;

	/// <summary>The MS-DOS error code if the <c>OpenFile</c> function failed.</summary>
	public ushort nErrCode;

	/// <summary>Reserved; do not use.</summary>
	public ushort Reserved1;

	/// <summary>Reserved; do not use.</summary>
	public ushort Reserved2;

	/// <summary>The path and file name of the file.</summary>
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPathName = pathName;

	/// <summary>Provides a default instance with size field set.</summary>
	public static readonly OFSTRUCT Default = new(string.Empty);
}