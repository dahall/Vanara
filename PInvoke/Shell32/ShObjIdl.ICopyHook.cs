namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes a method that creates a copy hook handler. A copy hook handler is a Shell extension that determines if a Shell folder or printer object can be moved, copied, renamed, or deleted. The Shell calls the ICopyHook::CopyCallback method prior to performing one of these operations.</summary>
	[ComImport, Guid("000214EF-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("Shlobj.h")]
	public interface ICopyHookA
	{
		/// <summary>
		/// Determines whether the Shell will be allowed to move, copy, delete, or rename a folder or printer object.
		/// </summary>
		/// <param name="hwnd">The HWND.A handle to the window that the copy hook handler should use as the parent for any user interface elements the handler may need to display. If FOF_SILENT is specified in wFunc, the method should ignore this parameter.</param>
		/// <param name="wFunc">The operation to perform. This parameter can be one of the values listed under the wFunc member of the SHFILEOPSTRUCT structure.</param>
		/// <param name="wFlags">The flags that control the operation. This parameter can be one or more of the values listed under the fFlags member of the SHFILEOPSTRUCT structure.</param>
		/// <param name="pszSrcFile">A pointer to a string that contains the name of the source folder.</param>
		/// <param name="dwSrcAttribs">The attributes of the source folder. This parameter can be a combination of any of the file attribute flags (FILE_ATTRIBUTE_*) defined in the Windows header files. See File Attribute Constants.</param>
		/// <param name="pszDestFile">A pointer to a string that contains the name of the destination folder.</param>
		/// <param name="dwDestAttribs">The attributes of the destination folder. This parameter can be a combination of any of the file attribute flags (FILE_ATTRIBUTE_*) defined in the Windows header files. See File Attribute Constants.</param>
		/// <returns>Returns an integer value that indicates whether the Shell should perform the operation. One of the following:
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>IDYES (0x06)</term><description>Allows the operation.</description></item>
		/// <item><term>IDNO (0x07)</term><description>Prevents the operation on this folder but continues with any other operations that have been approved (for example, a batch copy operation).</description></item>
		/// <item><term>IDCANCEL (0x02)</term><description>Prevents the current operation and cancels any pending operations.</description></item>
		/// </list>
		/// </returns>
		int CopyCallback([In, Optional] HWND hwnd, ShellFileOperation wFunc, FILEOP_FLAGS wFlags, [In, MarshalAs(UnmanagedType.LPStr)] string pszSrcFile, FileFlagsAndAttributes dwSrcAttribs, [In, Optional, MarshalAs(UnmanagedType.LPStr)] string? pszDestFile, FileFlagsAndAttributes dwDestAttribs);
	}

	/// <summary>Exposes a method that creates a copy hook handler. A copy hook handler is a Shell extension that determines if a Shell folder or printer object can be moved, copied, renamed, or deleted. The Shell calls the ICopyHook::CopyCallback method prior to performing one of these operations.</summary>
	[ComImport, Guid("000214FC-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("Shlobj.h")]
	public interface ICopyHookW
	{
		/// <summary>
		/// Determines whether the Shell will be allowed to move, copy, delete, or rename a folder or printer object.
		/// </summary>
		/// <param name="hwnd">The HWND.A handle to the window that the copy hook handler should use as the parent for any user interface elements the handler may need to display. If FOF_SILENT is specified in wFunc, the method should ignore this parameter.</param>
		/// <param name="wFunc">The operation to perform. This parameter can be one of the values listed under the wFunc member of the SHFILEOPSTRUCT structure.</param>
		/// <param name="wFlags">The flags that control the operation. This parameter can be one or more of the values listed under the fFlags member of the SHFILEOPSTRUCT structure.</param>
		/// <param name="pszSrcFile">A pointer to a string that contains the name of the source folder.</param>
		/// <param name="dwSrcAttribs">The attributes of the source folder. This parameter can be a combination of any of the file attribute flags (FILE_ATTRIBUTE_*) defined in the Windows header files. See File Attribute Constants.</param>
		/// <param name="pszDestFile">A pointer to a string that contains the name of the destination folder.</param>
		/// <param name="dwDestAttribs">The attributes of the destination folder. This parameter can be a combination of any of the file attribute flags (FILE_ATTRIBUTE_*) defined in the Windows header files. See File Attribute Constants.</param>
		/// <returns>Returns an integer value that indicates whether the Shell should perform the operation. One of the following:
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>IDYES (0x06)</term><description>Allows the operation.</description></item>
		/// <item><term>IDNO (0x07)</term><description>Prevents the operation on this folder but continues with any other operations that have been approved (for example, a batch copy operation).</description></item>
		/// <item><term>IDCANCEL (0x02)</term><description>Prevents the current operation and cancels any pending operations.</description></item>
		/// </list>
		/// </returns>
		int CopyCallback([In, Optional] HWND hwnd, ShellFileOperation wFunc, FILEOP_FLAGS wFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pszSrcFile, FileFlagsAndAttributes dwSrcAttribs, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszDestFile, FileFlagsAndAttributes dwDestAttribs);
	}
}