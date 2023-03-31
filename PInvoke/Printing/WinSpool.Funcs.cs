using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class WinSpool
{
	/// <summary>The <c>AbortPrinter</c> function deletes a printer's spool file if the printer is configured for spooling.</summary>
	/// <param name="hPrinter">
	/// Handle to the printer from which the spool file is deleted. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve
	/// a printer handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the printer is not configured for spooling, the <c>AbortPrinter</c> function has no effect.</para>
	/// <para>The sequence for a print job is as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>To begin a print job, call <c>StartDocPrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To begin each page, call <c>StartPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To write data to a page, call <c>WritePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To end each page, call <c>EndPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>Repeat 2, 3, and 4 for as many pages as necessary.</term>
	/// </item>
	/// <item>
	/// <term>To end the print job, call <c>EndDocPrinter</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When a page in a spooled file exceeds approximately 350 MB, it can fail to print and not send an error message. For example,
	/// this can occur when printing large EMF files. The page size limit depends on many factors including the amount of virtual memory
	/// available, the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/abortprinter BOOL AbortPrinter( _In_ HANDLE hPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "b361fba5-e4e7-4c9e-ab32-b8ab88dcb1dc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AbortPrinter(HPRINTER hPrinter);

	/// <summary>The <c>AddForm</c> function adds a form to the list of available forms that can be selected for the specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer that supports printing with the specified form. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <param name="Level">The level of the structure to which pForm points. This value must be 1 or 2.</param>
	/// <param name="pForm">A pointer to a <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>An application can determine which forms are available for a printer by calling the <c>EnumForms</c> function.</para>
	/// <para>
	/// If pForm points to a <c>FORM_INFO_2</c>, then <c>AddForm</c> will fail if either a form with the specified name already exists
	/// or the structure's pKeyword value already exists.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addform BOOL AddForm( _In_ HANDLE hPrinter, _In_ DWORD Level, _In_
	// LPBYTE pForm );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "17b59019-f93a-4b57-86fb-91c61aecbac4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddForm(HPRINTER hPrinter, uint Level, IntPtr pForm);

	/// <summary>The <c>AddForm</c> function adds a form to the list of available forms that can be selected for the specified printer.</summary>
	/// <typeparam name="T">The type of the structure used in <paramref name="pForm"/>.</typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer that supports printing with the specified form. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <param name="pForm">A <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <exception cref="ArgumentException"></exception>
	/// <remarks>
	/// <para>An application can determine which forms are available for a printer by calling the <c>EnumForms</c> function.</para>
	/// <para>
	/// If pForm points to a <c>FORM_INFO_2</c>, then <c>AddForm</c> will fail if either a form with the specified name already exists
	/// or the structure's pKeyword value already exists.
	/// </para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "17b59019-f93a-4b57-86fb-91c61aecbac4")]
	public static bool AddForm<T>(HPRINTER hPrinter, in T pForm) where T : struct
	{
		if (!TryGetLevel<T>("FORM_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(AddForm)} cannot process a structure of type {typeof(T).Name}.");
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pForm);
		return AddForm(hPrinter, lvl, mem);
	}

	/// <summary>
	/// The <c>AddJob</c> function adds a print job to the list of print jobs that can be scheduled by the print spooler. The function
	/// retrieves the name of the file you can use to store the job.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle that specifies the printer for the print job. This must be a local printer that is configured as a spooled printer. If
	/// hPrinter is a handle to a remote printer connection, or if the printer is configured for direct printing, the <c>AddJob</c>
	/// function fails. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="Level">
	/// The version of the print job information data structure that the function stores into the buffer pointed to by pData. Set this
	/// parameter to one.
	/// </param>
	/// <param name="pData">A pointer to a buffer that receives an <see cref="ADDJOB_INFO_1"/> data structure and a path string.</param>
	/// <param name="cbBuf">
	/// The size, in bytes, of the buffer pointed to by pData. The buffer needs to be large enough to contain an <c>ADDJOB_INFO_1</c>
	/// structure and a path string.
	/// </param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the total size, in bytes, of the <see cref="ADDJOB_INFO_1"/> data structure plus the path
	/// string. If this value is less than or equal to cbBuf and the function succeeds, this is the actual number of bytes written to
	/// the buffer pointed to by pData. If this number is greater than cbBuf, the buffer is too small, and you must call the function
	/// again with a buffer size at least as large as *pcbNeeded.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// You can call the <c>CreateFile</c> function to open the spool file specified by the <c>Path</c> member of the
	/// <c>ADDJOB_INFO_1</c> structure, and then call the <c>WriteFile</c> function to write print job data to it. After that is done,
	/// call the <c>ScheduleJob</c> function to notify the print spooler that the print job can now be scheduled by the spooler for printing.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addjob BOOL AddJob( _In_ HANDLE hPrinter, _In_ DWORD Level, _Out_ LPBYTE
	// pData, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "cfafa874-6022-4bf4-bf3d-096213eb0c98")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddJob(HPRINTER hPrinter, uint Level, IntPtr pData, uint cbBuf, out uint pcbNeeded);

	/// <summary>
	/// The <c>AddJob</c> function adds a print job to the list of print jobs that can be scheduled by the print spooler. The function
	/// retrieves the name of the file you can use to store the job.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle that specifies the printer for the print job. This must be a local printer that is configured as a spooled printer. If
	/// hPrinter is a handle to a remote printer connection, or if the printer is configured for direct printing, the <c>AddJob</c>
	/// function fails. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="path">The path and file name that the application can use to store the print job.</param>
	/// <param name="jobId">A handle to the print job.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// You can call the <c>CreateFile</c> function to open the spool file specified by <paramref name="path"/>, and then call the
	/// <c>WriteFile</c> function to write print job data to it. After that is done, call the <c>ScheduleJob</c> function to notify the
	/// print spooler that the print job can now be scheduled by the spooler for printing.
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "cfafa874-6022-4bf4-bf3d-096213eb0c98")]
	public static bool AddJob(HPRINTER hPrinter, out string path, out uint jobId)
	{
		path = null; jobId = 0;
		AddJob(hPrinter, 1, default, 0, out var sz);
		if (sz == 0) return false;
		using var mem = new SafeCoTaskMemHandle(sz);
		if (!AddJob(hPrinter, 1, mem, sz, out sz))
			return false;
		var str = mem.ToStructure<ADDJOB_INFO_1>();
		path = str.Path;
		jobId = str.JobId;
		return true;
	}

	/// <summary>The <c>AddPrinter</c> function adds a printer to the list of supported printers for a specified server.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the printer should be installed. If this
	/// string is <c>NULL</c>, the printer is installed locally.
	/// </param>
	/// <param name="Level">The version of the structure to which pPrinter points. This value must be 2.</param>
	/// <param name="pPrinter">
	/// A pointer to a <c>PRINTER_INFO_2</c> structure that contains information about the printer. You must specify non- <c>NULL</c>
	/// values for the <c>pPrinterName</c>, <c>pPortName</c>, <c>pDriverName</c>, and <c>pPrintProcessor</c> members of this structure
	/// before calling <c>AddPrinter</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle (not thread safe) to a new printer object. When you are finished with the
	/// handle, pass it to the <c>ClosePrinter</c> function to close it.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>Do not call this method in <c>DllMain</c>.</para>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// The returned handle is not thread safe. If callers need to use it concurrently on multiple threads, they must provide custom
	/// synchronization access to the printer handle using the Synchronization Functions. To avoid writing custom code the application
	/// can open a printer handle on each thread, as needed.
	/// </para>
	/// <para>
	/// The following are the members of the <c>PRINTER_INFO_2</c> structure that can be set before the <c>AddPrinter</c> function is called:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>Attributes</c></term>
	/// </item>
	/// <item>
	/// <term><c>pPrintProcessor</c></term>
	/// </item>
	/// <item>
	/// <term><c>DefaultPriority</c></term>
	/// </item>
	/// <item>
	/// <term><c>Priority</c></term>
	/// </item>
	/// <item>
	/// <term><c>pComment</c></term>
	/// </item>
	/// <item>
	/// <term><c>pSecurityDescriptor</c></term>
	/// </item>
	/// <item>
	/// <term><c>pDatatype</c></term>
	/// </item>
	/// <item>
	/// <term><c>pSepFile</c></term>
	/// </item>
	/// <item>
	/// <term><c>pDevMode</c></term>
	/// </item>
	/// <item>
	/// <term><c>pShareName</c></term>
	/// </item>
	/// <item>
	/// <term><c>pLocation</c></term>
	/// </item>
	/// <item>
	/// <term><c>StartTime</c></term>
	/// </item>
	/// <item>
	/// <term><c>pParameters</c></term>
	/// </item>
	/// <item>
	/// <term><c>UntilTime</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>Status</c>, <c>cJobs</c>, and <c>AveragePPM</c> members of the <c>PRINTER_INFO_2</c> structure are reserved for use by
	/// the <c>GetPrinter</c> function. They must not be set before calling <c>AddPrinter</c>.
	/// </para>
	/// <para>
	/// If <c>pSecurityDescriptor</c> is <c>NULL</c>, the system assigns a default security descriptor to the printer. The default
	/// security descriptor has the following permissions.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>Administrators and Power Users</term>
	/// <term>
	/// Full control on the print queue. This means members of these groups can print, manage the queue (can delete the queue, change
	/// any setting of the queue, including the security descriptor), and manage the print jobs of all users (delete, pause, resume,
	/// restart jobs).Note that Power Users do not exist before Windows XP Professional.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Creator/Owner</term>
	/// <term>Can manage own jobs. This means that user who submit jobs can manage (delete, pause, resume, restart) their own jobs.</term>
	/// </item>
	/// <item>
	/// <term>Everyone</term>
	/// <term>
	/// Execute and standard read control. This means that members of the everyone group can print and read properties of the print queue.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// After an application creates a printer object with the <c>AddPrinter</c> function, it must use the <c>PrinterProperties</c>
	/// function to specify the correct settings for the printer driver associated with the printer object.
	/// </para>
	/// <para>
	/// The <c>AddPrinter</c> function returns an error if a printer object with the same name already exists, unless that object is
	/// marked as pending deletion. In that case, the existing printer is not deleted, and the <c>AddPrinter</c> creation parameters are
	/// used to change the existing printer settings (as if the application had used the <c>SetPrinter</c> function).
	/// </para>
	/// <para>
	/// Use the <c>EnumPrintProcessors</c> function to enumerate the set of print processors installed on a server. Use the
	/// <c>EnumPrintProcessorDatatypes</c> function to enumerate the set of data types that a print processor supports. Use the
	/// <c>EnumPorts</c> function to enumerate the set of available ports. Use the <c>EnumPrinterDrivers</c> function to enumerate the
	/// installed printer drivers.
	/// </para>
	/// <para>
	/// The caller of the <c>AddPrinter</c> function must have SERVER_ACCESS_ADMINISTER access to the server on which the printer is to
	/// be created. The handle returned by the function will have PRINTER_ALL_ACCESS permission, and can be used to perform
	/// administrative operations on the printer.
	/// </para>
	/// <para>
	/// If the <c>DrvPrinterEvent</c> function is passed the PRINTER_EVENT_FLAG_NO_UI flag, the driver should not use a UI call during
	/// <c>DrvPrinterEvent</c>. To do UI-related jobs, the installer should either use the <c>VendorSetup</c> entry in the printer's
	/// .inf file or, for Plug and Play devices, the installer can use a device-specific co-installer. For more information about
	/// <c>VendorSetup</c>, see the Microsoft Windows Driver Development Kit (DDK).
	/// </para>
	/// <para>
	/// The Internet Connection Firewall (ICF) blocks printer ports by default, but an exception for File and Print Sharing is enabled
	/// when you run <c>AddPrinter</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprinter HANDLE AddPrinter( _In_ LPTSTR *pName, _In_ DWORD Level, _In_
	// LPBYTE pPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "ffc4fee8-46c6-47ad-803d-623bf8efdefd")]
	public static extern SafeHPRINTER AddPrinter([Optional] string? pName, uint Level, in PRINTER_INFO_2 pPrinter);

	/// <summary>The <c>AddPrinterConnection</c> function adds a connection to the specified printer for the current user.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of a printer to which the current user wishes to establish a connection.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When Windows makes a connection to a printer, it may need to copy printer driver files to the server to which the printer is
	/// attached. If the user does not have permission to copy files to the appropriate location, the <c>AddPrinterConnection</c>
	/// function fails, and <c>GetLastError</c> returns ERROR_ACCESS_DENIED.
	/// </para>
	/// <para>
	/// A printer connection established by calling <c>AddPrinterConnection</c> will be enumerated when <c>EnumPrinters</c> is called
	/// with dwType set to PRINTER_ENUM_CONNECTION.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprinterconnection BOOL AddPrinterConnection( _In_ LPTSTR pName );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "6decf89a-1411-4e7e-aa20-60e7068658c2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddPrinterConnection(string pName);

	/// <summary>Adds a connection to the specified printer for the current user and specifies connection details.</summary>
	/// <param name="hWnd">
	/// A handle to the parent window in which the dialog box will be displayed if the print system must download a printer driver from
	/// the print server for this connection.
	/// </param>
	/// <param name="pszName">
	/// A pointer to a constant null-terminated string specifying the name of the printer to which the current user wishes to connect.
	/// </param>
	/// <param name="dwLevel">
	/// The version of the structure pointed to by pConnectionInfo. Currently, only level 1 is defined so the value of dwLevel must be 1.
	/// </param>
	/// <param name="pConnectionInfo">
	/// A pointer to a <see cref="PRINTER_CONNECTION_INFO_1"/> structure. See the Remarks section for more about this parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When Windows Vista makes a connection to a printer, it may need to copy printer driver files from the server to which the
	/// printer is attached. If the user does not have permission to copy files to the appropriate location, the
	/// <c>AddPrinterConnection2</c> function fails and <c>GetLastError</c> returns ERROR_ACCESS_DENIED.
	/// </para>
	/// <para>
	/// If the printer driver files must be copied from the print server but cannot be copied silently due to the group policies that
	/// are in effect and PRINTER_CONNECTION_NO_UI is set in pConnectionInfo-&gt;dwFlags, no dialog boxes will be displayed and the call
	/// will fail.
	/// </para>
	/// <para>
	/// If the local printer driver can be used to render print jobs for this printer and the version of the local driver must not match
	/// the version of the printer driver on the server, set PRINTER_CONNECTION_MISMATCH in pConnectionInfo-&gt;dwFlags and assign the
	/// pointer to a string variable that contains the path to the local printer driver to pConnectionInfo-&gt;pszDriverName.
	/// </para>
	/// <para>
	/// A printer connection that is established by calling <c>AddPrinterConnection2</c> will be enumerated when <c>EnumPrinters</c> is
	/// called with dwType set to PRINTER_ENUM_CONNECTION.
	/// </para>
	/// <para>The ANSI version of this function, <c>AddPrinterConnection2A</c>, is not supported and returns <c>ERROR_NOT_SUPPORTED</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprinterconnection2 BOOL AddPrinterConnection2( _In_ HWND hWnd, _In_
	// LPCTSTR pszName, DWORD dwLevel, _In_ PVOID pConnectionInfo );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winspool.h", MSDNShortId = "5ae98157-5978-449e-beb1-4787110925fa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddPrinterConnection2([Optional] HWND hWnd, string pszName, uint dwLevel, IntPtr pConnectionInfo);

	/// <summary>
	/// Adds a connection to the specified printer for the current user and specifies connection details.
	/// </summary>
	/// <param name="hWnd">A handle to the parent window in which the dialog box will be displayed if the print system must download a printer driver from
	/// the print server for this connection.</param>
	/// <param name="pszName">A pointer to a constant null-terminated string specifying the name of the printer to which the current user wishes to connect.</param>
	/// <param name="flags">
	/// <para>The following values are defined:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_CONNECTION_MISMATCH (0x00000020)</term>
	/// <term>
	/// If this bit-flag is set, the printer connection is mismatched. The user can supply a local print driver as pszDriverName and
	/// use it to do the rendering instead of using the driver installed on the server printer to which the user is connected.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CONNECTION_NO_UI (0x00000040)</term>
	/// <term>
	/// If this bit-flag is set then this call cannot display a dialog box. If a dialog box must be displayed to install a printer
	/// driver from the server and this bit-flag is set, the printer driver will not be installed, the printer connection will not
	/// be added, and the call will fail. Windows 7: In Windows 7 and later versions of Windows, if this flag is set and the user is
	/// running in elevated mode, the Do you trust this printer? dialog will not be shown.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="driverName">The name of the driver.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When Windows Vista makes a connection to a printer, it may need to copy printer driver files from the server to which the
	/// printer is attached. If the user does not have permission to copy files to the appropriate location, the
	/// <c>AddPrinterConnection2</c> function fails and <c>GetLastError</c> returns ERROR_ACCESS_DENIED.
	/// </para>
	/// <para>
	/// If the printer driver files must be copied from the print server but cannot be copied silently due to the group policies that
	/// are in effect and PRINTER_CONNECTION_NO_UI is set in <paramref name="flags"/>, no dialog boxes will be displayed and the call
	/// will fail.
	/// </para>
	/// <para>
	/// If the local printer driver can be used to render print jobs for this printer and the version of the local driver must not match
	/// the version of the printer driver on the server, set PRINTER_CONNECTION_MISMATCH in <paramref name="flags"/> and assign the
	/// string variable that contains the path to the local printer driver to <paramref name="driverName"/>.
	/// </para>
	/// <para>
	/// A printer connection that is established by calling <c>AddPrinterConnection2</c> will be enumerated when <c>EnumPrinters</c> is
	/// called with dwType set to PRINTER_ENUM_CONNECTION.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprinterconnection2 BOOL AddPrinterConnection2( _In_ HWND hWnd, _In_
	// LPCTSTR pszName, DWORD dwLevel, _In_ PVOID pConnectionInfo );
	[PInvokeData("winspool.h", MSDNShortId = "5ae98157-5978-449e-beb1-4787110925fa")]
	public static bool AddPrinterConnection2([Optional] HWND hWnd, string pszName, PRINTER_CONNECTION_FLAGS flags, string driverName = null) =>
		AddPrinterConnection2(hWnd, pszName, 1, new PRINTER_CONNECTION_INFO_1 { dwFlags = flags, pszDriverName = driverName });

	/// <summary>
	/// <para>
	/// The <c>AdvancedDocumentProperties</c> function displays a printer-configuration dialog box for the specified printer, allowing
	/// the user to configure that printer.
	/// </para>
	/// <para>This function is a special case of the <c>DocumentProperties</c> function. For more details, see the Remarks section.</para>
	/// </summary>
	/// <param name="hWnd">A handle to the parent window of the printer-configuration dialog box.</param>
	/// <param name="hPrinter">
	/// A handle to a printer object. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pDeviceName">
	/// A pointer to a null-terminated string specifying the name of the device for which a printer-configuration dialog box should be displayed.
	/// </param>
	/// <param name="pDevModeOutput">
	/// A pointer to a <c>DEVMODE</c> structure that will contain the configuration data specified by the user.
	/// </param>
	/// <param name="pDevModeInput">
	/// A pointer to a <c>DEVMODE</c> structure that contains the configuration data used to initialize the controls of the
	/// printer-configuration dialog box.
	/// </param>
	/// <returns>
	/// If the <c>DocumentProperties</c> function with these parameters is successful, the return value of
	/// <c>AdvancedDocumentProperties</c> is 1. Otherwise, the return value is zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function can only display the printer-configuration dialog box so a user can configure it. For more control, use
	/// <c>DocumentProperties</c>. The input parameters for this function are passed directly to <c>DocumentProperties</c> and the fMode
	/// value is set to DM_IN_BUFFER | DM_IN_PROMPT | DM_OUT_BUFFER. Unlike <c>DocumentProperties</c>, this function only returns 1 or
	/// 0. Thus, you cannot determine the required size of <c>DEVMODE</c> by setting pDevMode to zero.
	/// </para>
	/// <para>
	/// An application can obtain the name pointed to by the pDeviceName parameter by calling the <c>GetPrinter</c> function and then
	/// examining the <c>pPrinterName</c> member of the <c>PRINTER_INFO_2</c> structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/advanceddocumentproperties LONG AdvancedDocumentProperties( _In_ HWND
	// hWnd, _In_ HANDLE hPrinter, _In_ LPTSTR pDeviceName, _Out_ PDEVMODE pDevModeOutput, _In_ PDEVMODE pDevModeInput );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "29e33f34-f6ec-4989-b076-e1fef8eb5bc4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AdvancedDocumentProperties(HWND hWnd, HPRINTER hPrinter, string pDeviceName, ref DEVMODE pDevModeOutput, in DEVMODE pDevModeInput);

	/// <summary>
	/// <para>
	/// The <c>AdvancedDocumentProperties</c> function displays a printer-configuration dialog box for the specified printer, allowing
	/// the user to configure that printer.
	/// </para>
	/// <para>This function is a special case of the <c>DocumentProperties</c> function. For more details, see the Remarks section.</para>
	/// </summary>
	/// <param name="hWnd">A handle to the parent window of the printer-configuration dialog box.</param>
	/// <param name="hPrinter">
	/// A handle to a printer object. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pDeviceName">
	/// A pointer to a null-terminated string specifying the name of the device for which a printer-configuration dialog box should be displayed.
	/// </param>
	/// <param name="pDevModeOutput">
	/// A pointer to a <c>DEVMODE</c> structure that will contain the configuration data specified by the user.
	/// </param>
	/// <param name="pDevModeInput">
	/// A pointer to a <c>DEVMODE</c> structure that contains the configuration data used to initialize the controls of the
	/// printer-configuration dialog box.
	/// </param>
	/// <returns>
	/// If the <c>DocumentProperties</c> function with these parameters is successful, the return value of
	/// <c>AdvancedDocumentProperties</c> is 1. Otherwise, the return value is zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function can only display the printer-configuration dialog box so a user can configure it. For more control, use
	/// <c>DocumentProperties</c>. The input parameters for this function are passed directly to <c>DocumentProperties</c> and the fMode
	/// value is set to DM_IN_BUFFER | DM_IN_PROMPT | DM_OUT_BUFFER. Unlike <c>DocumentProperties</c>, this function only returns 1 or
	/// 0. Thus, you cannot determine the required size of <c>DEVMODE</c> by setting pDevMode to zero.
	/// </para>
	/// <para>
	/// An application can obtain the name pointed to by the pDeviceName parameter by calling the <c>GetPrinter</c> function and then
	/// examining the <c>pPrinterName</c> member of the <c>PRINTER_INFO_2</c> structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/advanceddocumentproperties LONG AdvancedDocumentProperties( _In_ HWND
	// hWnd, _In_ HANDLE hPrinter, _In_ LPTSTR pDeviceName, _Out_ PDEVMODE pDevModeOutput, _In_ PDEVMODE pDevModeInput );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "29e33f34-f6ec-4989-b076-e1fef8eb5bc4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AdvancedDocumentProperties(HWND hWnd, HPRINTER hPrinter, string pDeviceName, [Out] IntPtr pDevModeOutput = default, [In] IntPtr pDevModeInput = default);

	/// <summary>The <c>ClosePrinter</c> function closes the specified printer object.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer object to be closed. This handle is returned by the <c>OpenPrinter</c> or <c>AddPrinter</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// When the <c>ClosePrinter</c> function returns, the handle hPrinter is invalid, regardless of whether the function has succeeded
	/// or failed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/closeprinter BOOL ClosePrinter( _In_ HANDLE hPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "95cc3eca-e65c-4fa6-8975-479e8e728dca")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ClosePrinter(HPRINTER hPrinter);

	/// <summary>
	/// The <c>CloseSpoolFileHandle</c> function closes a handle to a spool file associated with the print job currently submitted by
	/// the application.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer to which the job was submitted. This should be the same handle that was used to obtain hSpoolFile with <c>GetSpoolFileHandle</c>.
	/// </param>
	/// <param name="hSpoolFile">
	/// A handle to the spool file being closed. If <c>CommitSpoolData</c> has not been called since <c>GetSpoolFileHandle</c> was
	/// called, then this should be the same handle that was returned by <c>GetSpoolFileHandle</c>. Otherwise, it should be the handle
	/// that was returned by the most recent call to <c>CommitSpoolData</c>.
	/// </param>
	/// <returns><c>TRUE</c>, if it succeeds, <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// Your application must not call <c>ClosePrinter</c> on hPrinter until after it has accessed the spool file for the last time.
	/// Then it should call <c>CloseSpoolFileHandle</c> followed by <c>ClosePrinter</c>. Attempts to access the spool file handle after
	/// the original hPrinter has been closed will fail even if the file handle itself has not been closed. <c>CloseSpoolFileHandle</c>
	/// will fail if <c>ClosePrinter</c> is called first.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/closespoolfilehandle BOOL CloseSpoolFileHandle( _In_ HANDLE hPrinter,
	// _In_ HANDLE hSpoolFile );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "e2c0e68f-b72e-4a97-ba18-8943bc5789c1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseSpoolFileHandle(HPRINTER hPrinter, HSPOOLFILE hSpoolFile);

	/// <summary>
	/// The <c>CommitSpoolData</c> function notifies the print spooler that a specified amount of data has been written to a specified
	/// spool file and is ready to be rendered.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer to which the job was submitted. This should be the same handle that was used to obtain hSpoolFile with <c>GetSpoolFileHandle</c>.
	/// </param>
	/// <param name="hSpoolFile">
	/// A handle to the spool file being changed. On the first call of <c>CommitSpoolData</c>, this should be the same handle that was
	/// returned by <c>GetSpoolFileHandle</c>. Subsequent calls to <c>CommitSpoolData</c> should pass the handle returned by the
	/// preceding call. See Remarks.
	/// </param>
	/// <param name="cbCommit">The number of bytes committed to the print spooler.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the spool file.</para>
	/// <para>If the function fails, it returns INVALID_HANDLE_VALUE.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Applications submitting a spooler print job can call <c>GetSpoolFileHandle</c> and then directly write data to the spool file
	/// handle by calling <c>WriteFile</c>. To notify the print spooler that the file contains data which is ready to be rendered, the
	/// application must call <c>CommitSpoolData</c> and provide the number of available bytes.
	/// </para>
	/// <para>
	/// If <c>CommitSpoolData</c> is called multiple times, each call must use the spool file handle returned by the previous call. When
	/// no more data will be written to the spool file, <c>CloseSpoolFileHandle</c> should be called for the file handle returned by the
	/// last call to <c>CommitSpoolData</c>.
	/// </para>
	/// <para>
	/// Before calling <c>CommitSpoolData</c>, applications must set the file pointer to the position it had before it wrote data to the
	/// file. In the process of rendering the data in the spooler file, the print spooler will move the spool file pointer cbCommit
	/// bytes from the current value of file pointer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/commitspooldata HANDLE CommitSpoolData( _In_ HANDLE hPrinter, _In_
	// HANDLE hSpoolFile, DWORD cbCommit );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "cb8899e0-2fdf-4928-adff-17ef5af39f63")]
	public static extern HANDLE CommitSpoolData(HPRINTER hPrinter, HSPOOLFILE hSpoolFile, uint cbCommit);

	/// <summary>The <c>ConfigurePort</c> function displays the port-configuration dialog box for a port on the specified server.</summary>
	/// <param name="pName">
	/// Pointer to a null-terminated string that specifies the name of the server on which the specified port exists. If this parameter
	/// is <c>NULL</c>, the port is local.
	/// </param>
	/// <param name="hWnd">Handle to the parent window of the port-configuration dialog box.</param>
	/// <param name="pPortName">Pointer to a null-terminated string that specifies the name of the port to be configured.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// Before calling the <c>ConfigurePort</c> function, an application should call the <c>EnumPorts</c> function to determine valid
	/// port names.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/configureport BOOL ConfigurePort( _In_ LPTSTR pName, _In_ HWND hWnd,
	// _In_ LPTSTR pPortName );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "a65e9876-d6af-48c2-9e6b-8bd8695db130")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ConfigurePort([Optional] string? pName, HWND hWnd, string pPortName);

	/// <summary>
	/// The <c>ConnectToPrinterDlg</c> function displays a dialog box that lets users browse and connect to printers on a network. If
	/// the user selects a printer, the function attempts to create a connection to it; if a suitable driver is not installed on the
	/// server, the user is given the option of creating a printer locally.
	/// </summary>
	/// <param name="hwnd">Specifies the parent window of the dialog box.</param>
	/// <param name="Flags">This parameter is reserved and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds and the user selects a printer, the return value is a handle to the selected printer.</para>
	/// <para>If the function fails, or the user cancels the dialog box without selecting a printer, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ConnectToPrinterDlg</c> function attempts to create a connection to the selected printer. However, if the server on which
	/// the printer resides does not have a suitable driver installed, the function offers the user the option of creating a printer
	/// locally. A calling application can determine whether the function has created a printer locally by calling <c>GetPrinter</c>
	/// with a <c>PRINTER_INFO_2</c> structure, then examining that structure's <c>Attributes</c> member.
	/// </para>
	/// <para>
	/// An application should call <c>DeletePrinter</c> to delete a local printer. An application should call
	/// <c>DeletePrinterConnection</c> to delete a connection to a printer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/connecttoprinterdlg HANDLE ConnectToPrinterDlg( _In_ HWND hwnd, _In_
	// DWORD Flags );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "7cb9108b-8b65-4af3-88c8-a69771ed8e3f")]
	public static extern SafeHPRINTER ConnectToPrinterDlg(HWND hwnd, uint Flags = 0);

	/// <summary>The <c>DeleteForm</c> function removes a form name from the list of supported forms.</summary>
	/// <param name="hPrinter">
	/// Indicates the open printer handle that this function is to be performed upon. Use the <c>OpenPrinter</c> or <c>AddPrinter</c>
	/// function to retrieve a printer handle.
	/// </param>
	/// <param name="pFormName">Pointer to the form name to be removed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks><c>DeleteForm</c> can only delete form names that were added by using the <c>AddForm</c> function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteform BOOL DeleteForm( _In_ HANDLE hPrinter, _In_ LPTSTR pFormName );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "a2d0345f-2469-46ab-935f-777f2b33b621")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteForm(HPRINTER hPrinter, string pFormName);

	/// <summary>The <c>DeletePrinter</c> function deletes the specified printer object.</summary>
	/// <param name="hPrinter">
	/// Handle to a printer object that will be deleted. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If there are print jobs remaining to be processed for the specified printer, <c>DeletePrinter</c> marks the printer for pending
	/// deletion, and then deletes it when all the print jobs have been printed. No print jobs can be added to a printer that is marked
	/// for pending deletion.
	/// </para>
	/// <para>
	/// A printer marked for pending deletion cannot be held, but its print jobs can be held, resumed, and restarted. If the printer is
	/// held and there are jobs for the printer, <c>DeletePrinter</c> fails with ERROR_ACCESS_DENIED.
	/// </para>
	/// <para>Note that <c>DeletePrinter</c> does not close the handle that is passed to it. Thus, the application must still call <c>ClosePrinter</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinter BOOL DeletePrinter( _Inout_ HANDLE hPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "04d9c073-b795-4307-ba89-d4984bc5b354")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeletePrinter(HPRINTER hPrinter);

	/// <summary>
	/// The <c>DeletePrinterConnection</c> function deletes a connection to a printer that was established by a call to
	/// <c>AddPrinterConnection</c> or <c>ConnectToPrinterDlg</c>.
	/// </summary>
	/// <param name="pName">Pointer to a null-terminated string that specifies the name of the printer connection to delete.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The <c>DeletePrinterConnection</c> function does not delete any printer driver files that were copied to the server to which the
	/// printer is attached.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinterconnection BOOL DeletePrinterConnection( _In_ LPTSTR pName );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "7b056eea-fbd9-4a08-a2dc-7326caeec387")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeletePrinterConnection(string pName);

	/// <summary>
	/// <para>
	/// The <c>DeletePrinterData</c> function deletes specified configuration data for a printer. A printer's configuration data
	/// consists of a set of named and typed values. The <c>DeletePrinterData</c> function deletes one of these values, specified by its
	/// value name.
	/// </para>
	/// <para>
	/// Calling <c>DeletePrinterData</c> is equivalent to calling the <c>DeletePrinterDataEx</c> function with the pKeyName parameter
	/// set to "PrinterDriverData".
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer whose configuration data is to be deleted. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="pValueName">A pointer to the null-terminated name of the configuration data value to be deleted.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinterdata DWORD DeletePrinterData( _In_ HANDLE hPrinter, _In_
	// LPTSTR pValueName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "03c0bd75-d6de-46e3-b8e9-5a55df5135ea")]
	public static extern Win32Error DeletePrinterData(HPRINTER hPrinter, string pValueName);

	/// <summary>
	/// <para>
	/// The <c>DeletePrinterDataEx</c> function deletes a specified value from the configuration data for a printer. A printer's
	/// configuration data consists of a set of named and typed values stored in a hierarchy of registry keys. The function deletes a
	/// specified value under a specified key.
	/// </para>
	/// <para>
	/// Like the <c>DeletePrinterData</c> function, <c>DeletePrinterDataEx</c> can delete values stored by the <c>SetPrinterData</c>
	/// function. In addition, <c>DeletePrinterDataEx</c> can delete values stored under a specified key by the <c>SetPrinterDataEx</c> function.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function deletes a value. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the value to delete. Use the backslash ( \ ) character
	/// as a delimiter to specify a path that has one or more subkeys.
	/// </para>
	/// <para>If pKeyName is <c>NULL</c> or an empty string, <c>DeletePrinterDataEx</c> returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <param name="pValueName">A pointer to a null-terminated string that specifies the name of the value to delete.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinterdataex DWORD DeletePrinterDataEx( _In_ HANDLE hPrinter,
	// _In_ LPCTSTR pKeyName, _In_ LPCTSTR pValueName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "bcc9cdb3-0fbf-40b6-9de2-1479c3c0ff55")]
	public static extern Win32Error DeletePrinterDataEx(HPRINTER hPrinter, string pKeyName, string pValueName);

	/// <summary>The <c>DeletePrinterKey</c> function deletes a specified key and all its subkeys for a specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function deletes a key. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key to delete. Use the backslash ( \ ) character as a delimiter to
	/// specify a path with one or more subkeys.
	/// </para>
	/// <para>
	/// If pKeyName is an empty string (""), <c>DeletePrinterKey</c> deletes all keys below the top-level key for the printer. If
	/// pKeyName is <c>NULL</c>, <c>DeletePrinterKey</c> returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinterkey DWORD DeletePrinterKey( _In_ HANDLE hPrinter, _In_
	// LPCTSTR pKeyName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "0bd81b43-5c1e-4989-8350-2ec0dc215f28")]
	public static extern Win32Error DeletePrinterKey(HPRINTER hPrinter, string pKeyName);

	/// <summary>The <c>DeviceCapabilities</c> function retrieves the capabilities of a printer driver.</summary>
	/// <param name="pDevice">
	/// A pointer to a null-terminated string that contains the name of the printer. Note that this is the name of the printer, not of
	/// the printer driver.
	/// </param>
	/// <param name="pPort">
	/// A pointer to a null-terminated string that contains the name of the port to which the device is connected, such as LPT1.
	/// </param>
	/// <param name="fwCapability">
	/// <para>The capabilities to be queried. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DC_BINNAMES</term>
	/// <term>
	/// Retrieves the names of the printer's paper bins. The pOutput buffer receives an array of string buffers. Each string buffer is
	/// 24 characters long and contains the name of a paper bin. The return value indicates the number of entries in the array. The name
	/// strings are null-terminated unless the name is 24 characters long. If pOutput is NULL, the return value is the number of bin
	/// entries required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_BINS</term>
	/// <term>
	/// Retrieves a list of available paper bins. The pOutput buffer receives an array of WORD values that indicate the available paper
	/// sources for the printer. The return value indicates the number of entries in the array. For a list of the possible array values,
	/// see the description of the dmDefaultSource member of the DEVMODE structure. If pOutput is NULL, the return value indicates the
	/// required number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_COLLATE</term>
	/// <term>
	/// If the printer supports collating, the return value is 1; otherwise, the return value is zero. The pOutput parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_COLORDEVICE</term>
	/// <term>
	/// If the printer supports color printing, the return value is 1; otherwise, the return value is zero. The pOutput parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_COPIES</term>
	/// <term>Returns the number of copies the device can print.</term>
	/// </item>
	/// <item>
	/// <term>DC_DRIVER</term>
	/// <term>Returns the version number of the printer driver.</term>
	/// </item>
	/// <item>
	/// <term>DC_DUPLEX</term>
	/// <term>
	/// If the printer supports duplex printing, the return value is 1; otherwise, the return value is zero. The pOutput parameter is
	/// not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_ENUMRESOLUTIONS</term>
	/// <term>
	/// Retrieves a list of the resolutions supported by the printer. The pOutput buffer receives an array of LONG values. For each
	/// supported resolution, the array contains a pair of LONG values that specify the x and y dimensions of the resolution, in dots
	/// per inch. The return value indicates the number of supported resolutions. If pOutput is NULL, the return value indicates the
	/// number of supported resolutions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_EXTRA</term>
	/// <term>Returns the number of bytes required for the device-specific portion of the DEVMODE structure for the printer driver.</term>
	/// </item>
	/// <item>
	/// <term>DC_FIELDS</term>
	/// <term>
	/// Returns the dmFields member of the printer driver's DEVMODE structure. The dmFields member indicates which members in the
	/// device-independent portion of the structure are supported by the printer driver.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_FILEDEPENDENCIES</term>
	/// <term>
	/// Retrieves the names of any additional files that need to be loaded when a driver is installed. The pOutput buffer receives an
	/// array of string buffers. Each string buffer is 64 characters long and contains the name of a file. The return value indicates
	/// the number of entries in the array. The name strings are null-terminated unless the name is 64 characters long. If pOutput is
	/// NULL, the return value is the number of files.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MAXEXTENT</term>
	/// <term>
	/// Returns the maximum paper size that the dmPaperLength and dmPaperWidth members of the printer driver's DEVMODE structure can
	/// specify. The LOWORD of the return value contains the maximum dmPaperWidth value, and the HIWORD contains the maximum
	/// dmPaperLength value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MEDIAREADY</term>
	/// <term>
	/// Retrieves the names of the paper forms that are currently available for use. The pOutput buffer receives an array of string
	/// buffers. Each string buffer is 64 characters long and contains the name of a paper form. The return value indicates the number
	/// of entries in the array. The name strings are null-terminated unless the name is 64 characters long. If pOutput is NULL, the
	/// return value is the number of paper forms.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MEDIATYPENAMES</term>
	/// <term>
	/// Retrieves the names of the supported media types. The pOutput buffer receives an array of string buffers. Each string buffer is
	/// 64 characters long and contains the name of a supported media type. The return value indicates the number of entries in the
	/// array. The strings are null-terminated unless the name is 64 characters long. If pOutput is NULL, the return value is the number
	/// of media type names required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MEDIATYPES</term>
	/// <term>
	/// Retrieves a list of supported media types. The pOutput buffer receives an array of DWORD values that indicate the supported
	/// media types. The return value indicates the number of entries in the array. For a list of possible array values, see the
	/// description of the dmMediaType member of the DEVMODE structure. If pOutput is NULL, the return value indicates the required
	/// number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MINEXTENT</term>
	/// <term>
	/// Returns the minimum paper size that the dmPaperLength and dmPaperWidth members of the printer driver's DEVMODE structure can
	/// specify. The LOWORD of the return value contains the minimum dmPaperWidth value, and the HIWORD contains the minimum
	/// dmPaperLength value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_ORIENTATION</term>
	/// <term>
	/// Returns the relationship between portrait and landscape orientations for a device, in terms of the number of degrees that
	/// portrait orientation is rotated counterclockwise to produce landscape orientation. The return value can be one of the following:
	/// 0 No landscape orientation. 90 Portrait is rotated 90 degrees to produce landscape. 270 Portrait is rotated 270 degrees to
	/// produce landscape.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_NUP</term>
	/// <term>
	/// Retrieves an array of integers that indicate that printer's ability to print multiple document pages per printed page. The
	/// pOutput buffer receives an array of DWORD values. Each value represents a supported number of document pages per printed page.
	/// The return value indicates the number of entries in the array. If pOutput is NULL, the return value indicates the required
	/// number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PAPERNAMES</term>
	/// <term>
	/// Retrieves a list of supported paper names (for example, Letter or Legal). The pOutput buffer receives an array of string
	/// buffers. Each string buffer is 64 characters long and contains the name of a paper form. The return value indicates the number
	/// of entries in the array. The name strings are null-terminated unless the name is 64 characters long. If pOutput is NULL, the
	/// return value is the number of paper forms.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PAPERS</term>
	/// <term>
	/// Retrieves a list of supported paper sizes. The pOutput buffer receives an array of WORD values that indicate the available paper
	/// sizes for the printer. The return value indicates the number of entries in the array. For a list of the possible array values,
	/// see the description of the dmPaperSize member of the DEVMODE structure. If pOutput is NULL, the return value indicates the
	/// required number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PAPERSIZE</term>
	/// <term>
	/// Retrieves the dimensions, in tenths of a millimeter, of each supported paper size. The pOutput buffer receives an array of POINT
	/// structures. Each structure contains the width (x-dimension) and length (y-dimension) of a paper size as if the paper were in the
	/// DMORIENT_PORTRAIT orientation. The return value indicates the number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PERSONALITY</term>
	/// <term>
	/// Retrieves a list of printer description languages supported by the printer. The pOutput buffer receives an array of string
	/// buffers. Each buffer is 32 characters long and contains the name of a printer description language. The return value indicates
	/// the number of entries in the array. The name strings are null-terminated unless the name is 32 characters long. If pOutput is
	/// NULL, the return value indicates the required number of array entries.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTERMEM</term>
	/// <term>The return value is the amount of available printer memory, in kilobytes. The pOutput parameter is not used.</term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTRATE</term>
	/// <term>
	/// The return value indicates the printer's print rate. The value returned for DC_PRINTRATEUNIT indicates the units of the
	/// DC_PRINTRATE value. The pOutput parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTRATEPPM</term>
	/// <term>The return value indicates the printer's print rate, in pages per minute. The pOutput parameter is not used.</term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTRATEUNIT</term>
	/// <term>
	/// The return value is one of the following values that indicate the print rate units for the value returned for the DC_PRINTRATE
	/// flag. The pOutput parameter is not used. PRINTRATEUNIT_CPS Characters per second. PRINTRATEUNIT_IPM Inches per minute.
	/// PRINTRATEUNIT_LPM Lines per minute. PRINTRATEUNIT_PPM Pages per minute.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_SIZE</term>
	/// <term>Returns the dmSize member of the printer driver's DEVMODE structure.</term>
	/// </item>
	/// <item>
	/// <term>DC_STAPLE</term>
	/// <term>
	/// If the printer supports stapling, the return value is a nonzero value; otherwise, the return value is zero. The pOutput
	/// parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_TRUETYPE</term>
	/// <term>
	/// Retrieves the abilities of the driver to use TrueType fonts. For DC_TRUETYPE, the pOutput parameter should be NULL. The return
	/// value can be one or more of the following: DCTT_BITMAP Device can print TrueType fonts as graphics. DCTT_DOWNLOAD Device can
	/// download TrueType fonts. DCTT_SUBDEV Device can substitute device fonts for TrueType fonts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_VERSION</term>
	/// <term>Returns the specification version to which the printer driver conforms.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pOutput">
	/// A pointer to an array. The format of the array depends on the setting of the fwCapability parameter. See each capability above
	/// to find out what is returned if pOutput is <c>NULL</c>.
	/// </param>
	/// <param name="pDevMode">
	/// A pointer to a DEVMODE structure. If this parameter is <c>NULL</c>, <c>DeviceCapabilities</c> retrieves the current default
	/// initialization values for the specified printer driver. Otherwise, the function retrieves the values contained in the structure
	/// to which pDevMode points.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value depends on the setting of the fwCapability parameter. A return value of zero
	/// generally indicates that, while the function completed successfully, there was some type of failure, such as a capability that
	/// is not supported. For more details, see the descriptions for the fwCapability values.
	/// </para>
	/// <para>
	/// If the function returns -1, this may mean either that the capability is not supported or there was a general function failure.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>The DEVMODE structure pointed to by the pDevMode parameter may be obtained by calling the DocumentProperties function.</para>
	/// <para>
	/// If a printer driver supports custom device capabilities, the driver must call the SetPrinterData function for each custom
	/// capability. The <c>SetPrinterData</c> function adds the appropriate printer data to the print system, which enables 32-bit
	/// applications to access the custom capabilities on 64-bit Windows installations.
	/// </para>
	/// <para>
	/// For each custom capability, you must first add printer data that describes the type of the capability. To do this, when you call
	/// <c>SetPrinterData</c>, set the pValueName string to <c>CustomDeviceCapabilityType_Xxx</c>, where "Xxx" is the hexadecimal
	/// representation of the capability. For example, you might have "CustomDeviceCapabilityType_1234". The registry data that you set
	/// must be of the <c>REG_DWORD</c> type, and you must set its value to one of the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>0, if the custom capability is a <c>DWORD</c></term>
	/// </item>
	/// <item>
	/// <term>1, if the custom capability is a buffer of bytes</term>
	/// </item>
	/// <item>
	/// <term>2, if the custom capability is an array of items</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the custom capability is an array of items, you must call <c>SetPinterData</c> a second time to provide information about the
	/// size of an item in the array. To do this, when you call <c>SetPinterData</c>, the pValueName string that you provide must be
	/// "CustomDeviceCapabilitySize_Xxx" where Xxx is the hexadecimal representation of the capability. For example, you might have
	/// "CustomDeviceCapabilitySize_1234". The registry data that you set must be of the <c>REG_DWORD</c> type, and you must set its
	/// value to the size in bytes of an item in the array.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-devicecapabilitiesa
	// int DeviceCapabilitiesA( LPCSTR pDevice, LPCSTR pPort, WORD fwCapability, LPSTR pOutput, const DEVMODEA *pDevMode );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "d7f63ef7-0a2e-47c3-9e81-6e8a6dffe9af")]
	public static extern int DeviceCapabilities(string pDevice, [Optional] string? pPort, DC fwCapability, [Optional] IntPtr pOutput, in DEVMODE pDevMode);

	/// <summary>The <c>DeviceCapabilities</c> function retrieves the capabilities of a printer driver.</summary>
	/// <param name="pDevice">
	/// A pointer to a null-terminated string that contains the name of the printer. Note that this is the name of the printer, not of
	/// the printer driver.
	/// </param>
	/// <param name="pPort">
	/// A pointer to a null-terminated string that contains the name of the port to which the device is connected, such as LPT1.
	/// </param>
	/// <param name="fwCapability">
	/// <para>The capabilities to be queried. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DC_BINNAMES</term>
	/// <term>
	/// Retrieves the names of the printer's paper bins. The pOutput buffer receives an array of string buffers. Each string buffer is
	/// 24 characters long and contains the name of a paper bin. The return value indicates the number of entries in the array. The name
	/// strings are null-terminated unless the name is 24 characters long. If pOutput is NULL, the return value is the number of bin
	/// entries required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_BINS</term>
	/// <term>
	/// Retrieves a list of available paper bins. The pOutput buffer receives an array of WORD values that indicate the available paper
	/// sources for the printer. The return value indicates the number of entries in the array. For a list of the possible array values,
	/// see the description of the dmDefaultSource member of the DEVMODE structure. If pOutput is NULL, the return value indicates the
	/// required number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_COLLATE</term>
	/// <term>
	/// If the printer supports collating, the return value is 1; otherwise, the return value is zero. The pOutput parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_COLORDEVICE</term>
	/// <term>
	/// If the printer supports color printing, the return value is 1; otherwise, the return value is zero. The pOutput parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_COPIES</term>
	/// <term>Returns the number of copies the device can print.</term>
	/// </item>
	/// <item>
	/// <term>DC_DRIVER</term>
	/// <term>Returns the version number of the printer driver.</term>
	/// </item>
	/// <item>
	/// <term>DC_DUPLEX</term>
	/// <term>
	/// If the printer supports duplex printing, the return value is 1; otherwise, the return value is zero. The pOutput parameter is
	/// not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_ENUMRESOLUTIONS</term>
	/// <term>
	/// Retrieves a list of the resolutions supported by the printer. The pOutput buffer receives an array of LONG values. For each
	/// supported resolution, the array contains a pair of LONG values that specify the x and y dimensions of the resolution, in dots
	/// per inch. The return value indicates the number of supported resolutions. If pOutput is NULL, the return value indicates the
	/// number of supported resolutions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_EXTRA</term>
	/// <term>Returns the number of bytes required for the device-specific portion of the DEVMODE structure for the printer driver.</term>
	/// </item>
	/// <item>
	/// <term>DC_FIELDS</term>
	/// <term>
	/// Returns the dmFields member of the printer driver's DEVMODE structure. The dmFields member indicates which members in the
	/// device-independent portion of the structure are supported by the printer driver.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_FILEDEPENDENCIES</term>
	/// <term>
	/// Retrieves the names of any additional files that need to be loaded when a driver is installed. The pOutput buffer receives an
	/// array of string buffers. Each string buffer is 64 characters long and contains the name of a file. The return value indicates
	/// the number of entries in the array. The name strings are null-terminated unless the name is 64 characters long. If pOutput is
	/// NULL, the return value is the number of files.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MAXEXTENT</term>
	/// <term>
	/// Returns the maximum paper size that the dmPaperLength and dmPaperWidth members of the printer driver's DEVMODE structure can
	/// specify. The LOWORD of the return value contains the maximum dmPaperWidth value, and the HIWORD contains the maximum
	/// dmPaperLength value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MEDIAREADY</term>
	/// <term>
	/// Retrieves the names of the paper forms that are currently available for use. The pOutput buffer receives an array of string
	/// buffers. Each string buffer is 64 characters long and contains the name of a paper form. The return value indicates the number
	/// of entries in the array. The name strings are null-terminated unless the name is 64 characters long. If pOutput is NULL, the
	/// return value is the number of paper forms.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MEDIATYPENAMES</term>
	/// <term>
	/// Retrieves the names of the supported media types. The pOutput buffer receives an array of string buffers. Each string buffer is
	/// 64 characters long and contains the name of a supported media type. The return value indicates the number of entries in the
	/// array. The strings are null-terminated unless the name is 64 characters long. If pOutput is NULL, the return value is the number
	/// of media type names required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MEDIATYPES</term>
	/// <term>
	/// Retrieves a list of supported media types. The pOutput buffer receives an array of DWORD values that indicate the supported
	/// media types. The return value indicates the number of entries in the array. For a list of possible array values, see the
	/// description of the dmMediaType member of the DEVMODE structure. If pOutput is NULL, the return value indicates the required
	/// number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_MINEXTENT</term>
	/// <term>
	/// Returns the minimum paper size that the dmPaperLength and dmPaperWidth members of the printer driver's DEVMODE structure can
	/// specify. The LOWORD of the return value contains the minimum dmPaperWidth value, and the HIWORD contains the minimum
	/// dmPaperLength value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_ORIENTATION</term>
	/// <term>
	/// Returns the relationship between portrait and landscape orientations for a device, in terms of the number of degrees that
	/// portrait orientation is rotated counterclockwise to produce landscape orientation. The return value can be one of the following:
	/// 0 No landscape orientation. 90 Portrait is rotated 90 degrees to produce landscape. 270 Portrait is rotated 270 degrees to
	/// produce landscape.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_NUP</term>
	/// <term>
	/// Retrieves an array of integers that indicate that printer's ability to print multiple document pages per printed page. The
	/// pOutput buffer receives an array of DWORD values. Each value represents a supported number of document pages per printed page.
	/// The return value indicates the number of entries in the array. If pOutput is NULL, the return value indicates the required
	/// number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PAPERNAMES</term>
	/// <term>
	/// Retrieves a list of supported paper names (for example, Letter or Legal). The pOutput buffer receives an array of string
	/// buffers. Each string buffer is 64 characters long and contains the name of a paper form. The return value indicates the number
	/// of entries in the array. The name strings are null-terminated unless the name is 64 characters long. If pOutput is NULL, the
	/// return value is the number of paper forms.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PAPERS</term>
	/// <term>
	/// Retrieves a list of supported paper sizes. The pOutput buffer receives an array of WORD values that indicate the available paper
	/// sizes for the printer. The return value indicates the number of entries in the array. For a list of the possible array values,
	/// see the description of the dmPaperSize member of the DEVMODE structure. If pOutput is NULL, the return value indicates the
	/// required number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PAPERSIZE</term>
	/// <term>
	/// Retrieves the dimensions, in tenths of a millimeter, of each supported paper size. The pOutput buffer receives an array of POINT
	/// structures. Each structure contains the width (x-dimension) and length (y-dimension) of a paper size as if the paper were in the
	/// DMORIENT_PORTRAIT orientation. The return value indicates the number of entries in the array.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PERSONALITY</term>
	/// <term>
	/// Retrieves a list of printer description languages supported by the printer. The pOutput buffer receives an array of string
	/// buffers. Each buffer is 32 characters long and contains the name of a printer description language. The return value indicates
	/// the number of entries in the array. The name strings are null-terminated unless the name is 32 characters long. If pOutput is
	/// NULL, the return value indicates the required number of array entries.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTERMEM</term>
	/// <term>The return value is the amount of available printer memory, in kilobytes. The pOutput parameter is not used.</term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTRATE</term>
	/// <term>
	/// The return value indicates the printer's print rate. The value returned for DC_PRINTRATEUNIT indicates the units of the
	/// DC_PRINTRATE value. The pOutput parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTRATEPPM</term>
	/// <term>The return value indicates the printer's print rate, in pages per minute. The pOutput parameter is not used.</term>
	/// </item>
	/// <item>
	/// <term>DC_PRINTRATEUNIT</term>
	/// <term>
	/// The return value is one of the following values that indicate the print rate units for the value returned for the DC_PRINTRATE
	/// flag. The pOutput parameter is not used. PRINTRATEUNIT_CPS Characters per second. PRINTRATEUNIT_IPM Inches per minute.
	/// PRINTRATEUNIT_LPM Lines per minute. PRINTRATEUNIT_PPM Pages per minute.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_SIZE</term>
	/// <term>Returns the dmSize member of the printer driver's DEVMODE structure.</term>
	/// </item>
	/// <item>
	/// <term>DC_STAPLE</term>
	/// <term>
	/// If the printer supports stapling, the return value is a nonzero value; otherwise, the return value is zero. The pOutput
	/// parameter is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_TRUETYPE</term>
	/// <term>
	/// Retrieves the abilities of the driver to use TrueType fonts. For DC_TRUETYPE, the pOutput parameter should be NULL. The return
	/// value can be one or more of the following: DCTT_BITMAP Device can print TrueType fonts as graphics. DCTT_DOWNLOAD Device can
	/// download TrueType fonts. DCTT_SUBDEV Device can substitute device fonts for TrueType fonts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DC_VERSION</term>
	/// <term>Returns the specification version to which the printer driver conforms.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pOutput">
	/// A pointer to an array. The format of the array depends on the setting of the fwCapability parameter. See each capability above
	/// to find out what is returned if pOutput is <c>NULL</c>.
	/// </param>
	/// <param name="pDevMode">
	/// A pointer to a DEVMODE structure. If this parameter is <c>NULL</c>, <c>DeviceCapabilities</c> retrieves the current default
	/// initialization values for the specified printer driver. Otherwise, the function retrieves the values contained in the structure
	/// to which pDevMode points.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value depends on the setting of the fwCapability parameter. A return value of zero
	/// generally indicates that, while the function completed successfully, there was some type of failure, such as a capability that
	/// is not supported. For more details, see the descriptions for the fwCapability values.
	/// </para>
	/// <para>
	/// If the function returns -1, this may mean either that the capability is not supported or there was a general function failure.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>The DEVMODE structure pointed to by the pDevMode parameter may be obtained by calling the DocumentProperties function.</para>
	/// <para>
	/// If a printer driver supports custom device capabilities, the driver must call the SetPrinterData function for each custom
	/// capability. The <c>SetPrinterData</c> function adds the appropriate printer data to the print system, which enables 32-bit
	/// applications to access the custom capabilities on 64-bit Windows installations.
	/// </para>
	/// <para>
	/// For each custom capability, you must first add printer data that describes the type of the capability. To do this, when you call
	/// <c>SetPrinterData</c>, set the pValueName string to <c>CustomDeviceCapabilityType_Xxx</c>, where "Xxx" is the hexadecimal
	/// representation of the capability. For example, you might have "CustomDeviceCapabilityType_1234". The registry data that you set
	/// must be of the <c>REG_DWORD</c> type, and you must set its value to one of the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>0, if the custom capability is a <c>DWORD</c></term>
	/// </item>
	/// <item>
	/// <term>1, if the custom capability is a buffer of bytes</term>
	/// </item>
	/// <item>
	/// <term>2, if the custom capability is an array of items</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the custom capability is an array of items, you must call <c>SetPinterData</c> a second time to provide information about the
	/// size of an item in the array. To do this, when you call <c>SetPinterData</c>, the pValueName string that you provide must be
	/// "CustomDeviceCapabilitySize_Xxx" where Xxx is the hexadecimal representation of the capability. For example, you might have
	/// "CustomDeviceCapabilitySize_1234". The registry data that you set must be of the <c>REG_DWORD</c> type, and you must set its
	/// value to the size in bytes of an item in the array.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-devicecapabilitiesa
	// int DeviceCapabilitiesA( LPCSTR pDevice, LPCSTR pPort, WORD fwCapability, LPSTR pOutput, const DEVMODEA *pDevMode );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "d7f63ef7-0a2e-47c3-9e81-6e8a6dffe9af")]
	public static extern int DeviceCapabilities(string pDevice, [Optional] string? pPort, DC fwCapability, [Optional] IntPtr pOutput, [In, Optional] IntPtr pDevMode);

	/// <summary>The <c>DocumentEvent</c> function is an event handler for events associated with printing a document.</summary>
	/// <param name="hPrinter">
	/// A handle to a printer object. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="hdc">
	/// A device context handle that is generated by a call of <c>CreateDC</c>. This is zero if iEsc is set to
	/// DOCUMENTEVENT_CREATEDCPRE. For restrictions on printing from a 32-bit application on a 64-bit version of Windows, see Remarks.
	/// </param>
	/// <param name="iEsc">
	/// <para>An escape code that identifies the event to be handled. This parameter can be one of the following integer constants.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Event</term>
	/// </listheader>
	/// <item>
	/// <term>DOCUMENTEVENT_ABORTDOC</term>
	/// <term>GDI is about to process a call to its AbortDoc function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_CREATEDCPOST</term>
	/// <term>
	/// GDI has just processed a call to its CreateDC or CreateIC function. This escape code should not be used unless there has been a
	/// previous call to DocumentEvent with iEsc set to DOCUMENTEVENT_CREATEDCPRE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_CREATEDCPRE</term>
	/// <term>GDI is about to process a call to its CreateDC or CreateIC function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_DELETEDC</term>
	/// <term>GDI is about to process a call to its DeleteDC function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDDOCPOST</term>
	/// <term>GDI has just processed a call to its EndDoc function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDDOCPRE or DOCUMENTEVENT_ENDDOC</term>
	/// <term>GDI is about to process a call to its EndDoc function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDPAGE</term>
	/// <term>GDI is about to process a call to its EndPage function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ESCAPE</term>
	/// <term>GDI is about to process a call to its ExtEscape function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_QUERYFILTER</term>
	/// <term>
	/// The DOCUMENTEVENT_QUERYFILTER event represents an opportunity for the spooler to query the driver for a list of the
	/// DOCUMENTEVENT_ XXX events to which the driver will respond. This event is issued just prior to a call to DocumentEvent that
	/// passes the DOCUMENTEVENT_CREATEDCPRE event.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_RESETDCPOST</term>
	/// <term>
	/// GDI has just processed a call to its ResetDC function. This escape code should not be used unless there has been a previous call
	/// to DocumentEvent with iEsc set to DOCUMENTEVENT_RESETDCPRE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_RESETDCPRE</term>
	/// <term>GDI is about to process a call to its ResetDC function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTDOCPOST</term>
	/// <term>GDI has just processed a call to its StartDoc function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTDOCPRE or DOCUMENTEVENT_STARTDOC</term>
	/// <term>GDI is about to process a call to its StartDoc function.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTPAGE</term>
	/// <term>GDI is about to process a call to its StartPage function.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cbIn">The size, in bytes, of the buffer pointed to by pvIn.</param>
	/// <param name="pvIn">
	/// <para>A pointer to a buffer. What the buffer contains depends on the value of iEsc, as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>pvin Contents</term>
	/// </listheader>
	/// <item>
	/// <term>DOCUMENTEVENT_ABORTDOC</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_CREATEDCPOST</term>
	/// <term>
	/// pvIn contains the address of a pointer to the DEVMODE structure specified in the pvOut parameter in a previous call to this
	/// function, for which the iEsc parameter was set to DOCUMENTEVENT_CREATEDCPRE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_CREATEDCPRE</term>
	/// <term>pvIn points to a DOCEVENT_CREATEDCPRE structure which is documented in the Windows Driver Development Kit.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_DELETEDC</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDDOCPOST</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDDOCPRE or DOCUMENTEVENT_ENDDOC</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDPAGE</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ESCAPE</term>
	/// <term>pvIn points to a DOCEVENT_ESCAPE structure which is documented in the Windows Driver Development Kit.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_QUERYFILTER</term>
	/// <term>Same as for DOCUMENTEVENT_CREATEDCPRE.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_RESETDCPOST</term>
	/// <term>
	/// pvIn contains the address of a pointer to the DEVMODE structure specified in the pvOut parameter in a previous call to this
	/// function, for which the iEsc parameter was set to DOCUMENTEVENT_RESETDCPRE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_RESETDCPRE</term>
	/// <term>pvIn contains the address of a pointer to the DEVMODE structure supplied by the caller of ResetDC.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTDOCPOST</term>
	/// <term>pvIn points to a LONG that specifies the print job identifier returned by StartDoc.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTDOCPRE or DOCUMENTEVENT_STARTDOC</term>
	/// <term>pvIn contains the address of a pointer to a DOCINFO structure supplied by the caller of StartDoc.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTPAGE</term>
	/// <term>Not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cbOut">
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>IDOCUMENTEVENT_QUERYFILTER</term>
	/// <term>The size, in bytes, of the buffer pointer to by pvOut.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ESCAPE</term>
	/// <term>A value that is used as the cbOutput parameter for ExtEscape.</term>
	/// </item>
	/// <item>
	/// <term>For all other values</term>
	/// <term>iEsc is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvOut">
	/// <para>A pointer to a buffer. The contents of the buffer depend on the value supplied for iEsc, as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>pvOut Contents</term>
	/// </listheader>
	/// <item>
	/// <term>DOCUMENTEVENT_CREATEDCPRE</term>
	/// <term>
	/// A pointer to a driver-supplied DEVMODE structure, which GDI uses instead of the one supplied by the CreateDC caller. (If NULL,
	/// GDI uses the caller-supplied structure.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ESCAPE</term>
	/// <term>A pointer to a buffer that is used as the lpszOutData parameter for ExtEscape.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_QUERYFILTER</term>
	/// <term>A pointer to buffer containing a DOCEVENT_FILTER structure which is documented in the Windows Driver Development Kit.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_RESETDCPRE</term>
	/// <term>
	/// A pointer to a driver-supplied DEVMODE structure, which GDI uses instead of the one supplied by the ResetDC caller. (If NULL,
	/// GDI uses the caller-supplied structure.)
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// The function's return value is dependent on the escape supplied for iEsc. For some escape codes, the return value is not used
	/// (see below). If the function supplies a return value, it must be one of the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DOCUMENTEVENT_FAILURE</term>
	/// <term>The driver supports the escape code identified by iEsc, but a failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_SUCCESS</term>
	/// <term>The driver successfully handled the escape code identified by iEsc.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_UNSUPPORTED</term>
	/// <term>The driver does not support the escape code identified by iEsc.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The following list indicates which escape codes that require a return value and which do not, and explains the meaning of the
	/// DOCUMENTEVENT_SUCCESS, DOCUMENTEVENT_FAILURE, and DOCUMENTEVENT_UNSUPPORTED return codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DOCUMENTEVENT_ABORTDOC</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_CREATEDCPOST</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_CREATEDCPRE</term>
	/// <term>
	/// DOCUMENTEVENT_FAILURE - GDI does not create the device context or information context, and provides a return value of 0 for
	/// CreateDC or CreateIC.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_DELETEDC</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDDOCPOST</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDDOCPRE or DOCUMENTEVENT_ENDDOC</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ENDPAGE</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_ESCAPE</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_QUERYFILTER</term>
	/// <term>See Remarks.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_RESETDCPOST</term>
	/// <term>The return value is not used and should not be read.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_RESETDCPRE</term>
	/// <term>DOCUMENTEVENT_FAILURE - GDI does not reset the device context, and provides a return value of 0 for ResetDC.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTDOCPOST</term>
	/// <term>DOCUMENTEVENT_FAILURE - GDI calls AbortDoc to stop the document, and then provides a return value of SP_ERROR for StartDoc.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTDOCPRE or DOCUMENTEVENT_STARTDOC</term>
	/// <term>DOCUMENTEVENT_FAILURE - GDI does not start the document, and provides a return value of SP_ERROR for StartDoc.</term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_STARTPAGE</term>
	/// <term>DOCUMENTEVENT_FAILURE - GDI does not start the page, and provides a return value of SP_ERROR for StartPage.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For an iEsc value of DOCUMENTEVENT_QUERYFILTER, the spooler can interpret a DOCUMENTEVENT_SUCCESS value returned by
	/// <c>DocumentEvent</c> in two ways, depending on whether the driver modified certain members of the DOCEVENT_FILTER structure
	/// (which is documented in the Windows Driver Development Kit ). (The pvOut parameter points to this structure.) When the spooler
	/// allocates memory for a structure of this type, it initializes two members of this structure, <c>cElementsReturned</c> and
	/// <c>cElementsNeeded</c>, to known values. After <c>DocumentEvent</c> returns, the spooler determines whether the values of these
	/// members have changed, and uses that information to interpret the <c>DocumentEvent</c> return value. The following table
	/// summarizes this situation.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return Value</term>
	/// <term>Status of cElementsReturned and cElementsNeeded</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DOCUMENTEVENT_SUCCESS</term>
	/// <term>Driver made no change to either member.</term>
	/// <term>
	/// The spooler interprets this return value as equivalent to DOCUMENTEVENT_UNSUPPORTED. The spooler is unable to retrieve the event
	/// filter from the driver, so it persists in calling DocumentEvent for all events.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_SUCCESS</term>
	/// <term>Driver wrote to one or both members.</term>
	/// <term>
	/// The spooler accepts this return value without interpretation. If the driver wrote to only one of cElementsNeeded and
	/// cElementsReturned, the spooler considers the unchanged member to have a value of zero. The spooler filters out all events listed
	/// in the aDocEventCall member of DOCEVENT_FILTER (which is documented in the Windows Driver Development Kit ).
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_UNSUPPORTED</term>
	/// <term>Not applicable</term>
	/// <term>
	/// The driver does not support DOCUMENTEVENT_QUERYFILTER. The spooler is unable to retrieve the event filter from the driver, so it
	/// persists in calling DocumentEvent for all events.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DOCUMENTEVENT_FAILURE</term>
	/// <term>Not applicable</term>
	/// <term>
	/// The driver supports DOCUMENTEVENT_QUERYFILTER, but encountered an internal error. The spooler is unable to retrieve the event
	/// filter from the driver, so it persists in calling DocumentEvent for all events.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the escape code supplied in the iEsc parameter is DOCUMENTEVENT_CREATEDCPRE, the following rules apply:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the job is being sent directly to the printer without spooling, pvIn-&gt;pszDevice points to the printer name. (For more
	/// information, see the documentation for the DOCEVENT_CREATEDCPRE structure in the Windows Driver Development Kit.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the job is being spooled, pvIn-&gt;pszDevice points to the printer port name.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/documentevent HRESULT DocumentEvent( _In_ HANDLE hPrinter, _In_ HDC hdc,
	// INT iEsc, ULONG cbIn, _In_ PVOID pvIn, ULONG cbOut, _Out_ PVOID pvOut );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "1250116e-55c7-470f-97f6-36f27a31a841")]
	public static extern HRESULT DocumentEvent(HPRINTER hPrinter, HDC hdc, DOCUMENTEVENT iEsc, uint cbIn, IntPtr pvIn, uint cbOut, IntPtr pvOut);

	/// <summary>
	/// The <c>DocumentProperties</c> function retrieves or modifies printer initialization information or displays a
	/// printer-configuration property sheet for the specified printer.
	/// </summary>
	/// <param name="hWnd">A handle to the parent window of the printer-configuration property sheet.</param>
	/// <param name="hPrinter">
	/// A handle to a printer object. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pDeviceName">
	/// A pointer to a null-terminated string that specifies the name of the device for which the printer-configuration property sheet
	/// is displayed.
	/// </param>
	/// <param name="pDevModeOutput">
	/// A pointer to a <c>DEVMODE</c> structure that receives the printer configuration data specified by the user.
	/// </param>
	/// <param name="pDevModeInput">
	/// <para>A pointer to a <c>DEVMODE</c> structure that the operating system uses to initialize the property sheet controls.</para>
	/// <para>
	/// This parameter is only used if the <c>DM_IN_BUFFER</c> flag is set in the fMode parameter. If <c>DM_IN_BUFFER</c> is not set,
	/// the operating system uses the printer's default <c>DEVMODE</c>.
	/// </para>
	/// </param>
	/// <param name="fMode">
	/// <para>
	/// The operations the function performs. If this parameter is zero, the <c>DocumentProperties</c> function returns the number of
	/// bytes required by the printer driver's <c>DEVMODE</c> data structure. Otherwise, use one or more of the following constants to
	/// construct a value for this parameter; note, however, that in order to change the print settings, an application must specify at
	/// least one input value and one output value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DM_IN_BUFFER</term>
	/// <term>
	/// Input value. Before prompting, copying, or updating, the function merges the printer driver's current print settings with the
	/// settings in the DEVMODE structure specified by the pDevModeInput parameter. The function updates the structure only for those
	/// members specified by the DEVMODE structure's dmFields member. This value is also defined as DM_MODIFY. In cases of conflict
	/// during the merge, the settings in the DEVMODE structure specified by pDevModeInput override the printer driver's current print settings.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DM_IN_PROMPT</term>
	/// <term>
	/// Input value. The function presents the printer driver's Print Setup property sheet and then changes the settings in the
	/// printer's DEVMODE data structure to those values specified by the user. This value is also defined as DM_PROMPT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DM_OUT_BUFFER</term>
	/// <term>
	/// Output value. The function writes the printer driver's current print settings, including private data, to the DEVMODE data
	/// structure specified by the pDevModeOutput parameter. The caller must allocate a buffer sufficiently large to contain the
	/// information. If the bit DM_OUT_BUFFER sets is clear, the pDevModeOutput parameter can be NULL. This value is also defined as DM_COPY.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the fMode parameter is zero, the return value is the size of the buffer required to contain the printer driver initialization
	/// data. Note that this buffer can be larger than a <c>DEVMODE</c> structure if the printer driver appends private data to the structure.
	/// </para>
	/// <para>
	/// If the function displays the property sheet, the return value is either <c>IDOK</c> or <c>IDCANCEL</c>, depending on which
	/// button the user selects.
	/// </para>
	/// <para>If the function does not display the property sheet and is successful, the return value is <c>IDOK</c>.</para>
	/// <para>If the function fails, the return value is less than zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The string pointed to by the pDeviceName parameter can be obtained by calling the <c>GetPrinter</c> function.</para>
	/// <para>
	/// The <c>DEVMODE</c> structure actually used by a printer driver contains the device-independent part (as defined above) followed
	/// by a driver-specific part that varies in size and content with each driver and driver version. Because of this driver
	/// dependence, it is very important for applications to query the driver for the correct size of the <c>DEVMODE</c> structure
	/// before allocating a buffer for it.
	/// </para>
	/// <para><c>To make changes to print settings that are local to an application, an application should follow these steps:</c></para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Get the number of bytes required for the full <c>DEVMODE</c> structure by calling <c>DocumentProperties</c> and specifying zero
	/// in the fMode parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Allocate memory for the full <c>DEVMODE</c> structure.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Get the current printer settings by calling <c>DocumentProperties</c>. Pass a pointer to the <c>DEVMODE</c> structure allocated
	/// in Step 2 as the pDevModeOutput parameter and specify the <c>DM_OUT_BUFFER</c> value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Modify the appropriate members of the returned <c>DEVMODE</c> structure and indicate which members were changed by setting the
	/// corresponding bits in the <c>dmFields</c> member of the <c>DEVMODE</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call <c>DocumentProperties</c> and pass the modified <c>DEVMODE</c> structure back as both the pDevModeInput and pDevModeOutput
	/// parameters and specify both the <c>DM_IN_BUFFER</c> and <c>DM_OUT_BUFFER</c> values (which are combined using the OR
	/// operator).The <c>DEVMODE</c> structure returned by the third call to <c>DocumentProperties</c> can be used as an argument in a
	/// call to the <c>CreateDC</c> function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To create a handle to a printer-device context using the current printer settings, you only need to call
	/// <c>DocumentProperties</c> twice, as described above. The first call gets the size of the full <c>DEVMODE</c> and the second call
	/// initializes the <c>DEVMODE</c> with the current printer settings. Pass the initialized <c>DEVMODE</c> to <c>CreateDC</c> to
	/// obtain the handle to the printer device context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/documentproperties LONG DocumentProperties( _In_ HWND hWnd, _In_ HANDLE
	// hPrinter, _In_ LPTSTR pDeviceName, _Out_ PDEVMODE pDevModeOutput, _In_ PDEVMODE pDevModeInput, _In_ DWORD fMode );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "e89a2f6f-2bac-4369-b526-f8e15028698b")]
	public static extern int DocumentProperties(HWND hWnd, HPRINTER hPrinter, string pDeviceName, IntPtr pDevModeOutput, in DEVMODE pDevModeInput, DM fMode);

	/// <summary>
	/// The <c>DocumentProperties</c> function retrieves or modifies printer initialization information or displays a
	/// printer-configuration property sheet for the specified printer.
	/// </summary>
	/// <param name="hWnd">A handle to the parent window of the printer-configuration property sheet.</param>
	/// <param name="hPrinter">
	/// A handle to a printer object. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pDeviceName">
	/// A pointer to a null-terminated string that specifies the name of the device for which the printer-configuration property sheet
	/// is displayed.
	/// </param>
	/// <param name="pDevModeOutput">
	/// A pointer to a <c>DEVMODE</c> structure that receives the printer configuration data specified by the user.
	/// </param>
	/// <param name="pDevModeInput">
	/// <para>A pointer to a <c>DEVMODE</c> structure that the operating system uses to initialize the property sheet controls.</para>
	/// <para>
	/// This parameter is only used if the <c>DM_IN_BUFFER</c> flag is set in the fMode parameter. If <c>DM_IN_BUFFER</c> is not set,
	/// the operating system uses the printer's default <c>DEVMODE</c>.
	/// </para>
	/// </param>
	/// <param name="fMode">
	/// <para>
	/// The operations the function performs. If this parameter is zero, the <c>DocumentProperties</c> function returns the number of
	/// bytes required by the printer driver's <c>DEVMODE</c> data structure. Otherwise, use one or more of the following constants to
	/// construct a value for this parameter; note, however, that in order to change the print settings, an application must specify at
	/// least one input value and one output value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DM_IN_BUFFER</term>
	/// <term>
	/// Input value. Before prompting, copying, or updating, the function merges the printer driver's current print settings with the
	/// settings in the DEVMODE structure specified by the pDevModeInput parameter. The function updates the structure only for those
	/// members specified by the DEVMODE structure's dmFields member. This value is also defined as DM_MODIFY. In cases of conflict
	/// during the merge, the settings in the DEVMODE structure specified by pDevModeInput override the printer driver's current print settings.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DM_IN_PROMPT</term>
	/// <term>
	/// Input value. The function presents the printer driver's Print Setup property sheet and then changes the settings in the
	/// printer's DEVMODE data structure to those values specified by the user. This value is also defined as DM_PROMPT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DM_OUT_BUFFER</term>
	/// <term>
	/// Output value. The function writes the printer driver's current print settings, including private data, to the DEVMODE data
	/// structure specified by the pDevModeOutput parameter. The caller must allocate a buffer sufficiently large to contain the
	/// information. If the bit DM_OUT_BUFFER sets is clear, the pDevModeOutput parameter can be NULL. This value is also defined as DM_COPY.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the fMode parameter is zero, the return value is the size of the buffer required to contain the printer driver initialization
	/// data. Note that this buffer can be larger than a <c>DEVMODE</c> structure if the printer driver appends private data to the structure.
	/// </para>
	/// <para>
	/// If the function displays the property sheet, the return value is either <c>IDOK</c> or <c>IDCANCEL</c>, depending on which
	/// button the user selects.
	/// </para>
	/// <para>If the function does not display the property sheet and is successful, the return value is <c>IDOK</c>.</para>
	/// <para>If the function fails, the return value is less than zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The string pointed to by the pDeviceName parameter can be obtained by calling the <c>GetPrinter</c> function.</para>
	/// <para>
	/// The <c>DEVMODE</c> structure actually used by a printer driver contains the device-independent part (as defined above) followed
	/// by a driver-specific part that varies in size and content with each driver and driver version. Because of this driver
	/// dependence, it is very important for applications to query the driver for the correct size of the <c>DEVMODE</c> structure
	/// before allocating a buffer for it.
	/// </para>
	/// <para><c>To make changes to print settings that are local to an application, an application should follow these steps:</c></para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Get the number of bytes required for the full <c>DEVMODE</c> structure by calling <c>DocumentProperties</c> and specifying zero
	/// in the fMode parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Allocate memory for the full <c>DEVMODE</c> structure.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Get the current printer settings by calling <c>DocumentProperties</c>. Pass a pointer to the <c>DEVMODE</c> structure allocated
	/// in Step 2 as the pDevModeOutput parameter and specify the <c>DM_OUT_BUFFER</c> value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Modify the appropriate members of the returned <c>DEVMODE</c> structure and indicate which members were changed by setting the
	/// corresponding bits in the <c>dmFields</c> member of the <c>DEVMODE</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call <c>DocumentProperties</c> and pass the modified <c>DEVMODE</c> structure back as both the pDevModeInput and pDevModeOutput
	/// parameters and specify both the <c>DM_IN_BUFFER</c> and <c>DM_OUT_BUFFER</c> values (which are combined using the OR
	/// operator).The <c>DEVMODE</c> structure returned by the third call to <c>DocumentProperties</c> can be used as an argument in a
	/// call to the <c>CreateDC</c> function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To create a handle to a printer-device context using the current printer settings, you only need to call
	/// <c>DocumentProperties</c> twice, as described above. The first call gets the size of the full <c>DEVMODE</c> and the second call
	/// initializes the <c>DEVMODE</c> with the current printer settings. Pass the initialized <c>DEVMODE</c> to <c>CreateDC</c> to
	/// obtain the handle to the printer device context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/documentproperties LONG DocumentProperties( _In_ HWND hWnd, _In_ HANDLE
	// hPrinter, _In_ LPTSTR pDeviceName, _Out_ PDEVMODE pDevModeOutput, _In_ PDEVMODE pDevModeInput, _In_ DWORD fMode );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "e89a2f6f-2bac-4369-b526-f8e15028698b")]
	public static extern int DocumentProperties(HWND hWnd, HPRINTER hPrinter, string pDeviceName, IntPtr pDevModeOutput, [Optional] IntPtr pDevModeInput, DM fMode);

	/// <summary>The <c>EndDocPrinter</c> function ends a print job for the specified printer.</summary>
	/// <param name="hPrinter">
	/// Handle to a printer for which the print job should be ended. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EndDocPrinter</c> function returns an error if the print job was not started by calling the <c>StartDocPrinter</c> function.
	/// </para>
	/// <para>The sequence for a print job is as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>To begin a print job, call <c>StartDocPrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To begin each page, call <c>StartPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To write data to a page, call <c>WritePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To end each page, call <c>EndPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>Repeat 2, 3, and 4 for as many pages as necessary.</term>
	/// </item>
	/// <item>
	/// <term>To end the print job, call <c>EndDocPrinter</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When a page in a spooled file exceeds approximately 350 MB, it may fail to print and not send an error message. For example,
	/// this can occur when printing large EMF files. The page size limit depends on many factors including the amount of virtual memory
	/// available, the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enddocprinter BOOL EndDocPrinter( _In_ HANDLE hPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "13c713e8-cc24-4191-8b1e-967b9e20e541")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndDocPrinter(HPRINTER hPrinter);

	/// <summary>
	/// The <c>EndPagePrinter</c> function notifies the print spooler that the application is at the end of a page in a print job.
	/// </summary>
	/// <param name="hPrinter">
	/// Handle to the printer for which the page will be concluded. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve
	/// a printer handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The sequence for a print job is as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>To begin a print job, call <c>StartDocPrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To begin each page, call <c>StartPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To write data to a page, call <c>WritePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To end each page, call <c>EndPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>Repeat 2, 3, and 4 for as many pages as necessary.</term>
	/// </item>
	/// <item>
	/// <term>To end the print job, call <c>EndDocPrinter</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When a page in a spooled file exceeds approximately 350 MB, it can fail to print and not send an error message. For example,
	/// this can occur when printing large EMF files. The page size limit depends on many factors including the amount of virtual memory
	/// available, the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/endpageprinter BOOL EndPagePrinter( _In_ HANDLE hPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "aceb88b9-375b-4cd2-996a-c369f590154e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndPagePrinter(HPRINTER hPrinter);

	/// <summary>The <c>EnumForms</c> function enumerates the forms supported by the specified printer.</summary>
	/// <param name="hPrinter">
	/// Handle to the printer for which the forms should be enumerated. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="Level">Specifies the version of the structure to which pForm points. This value must be 1 or 2.</param>
	/// <param name="pForm">
	/// Pointer to one or more <c>FORM_INFO_1</c> structures or to one or more <c>FORM_INFO_2</c> structures. All the structures will
	/// have the same level.
	/// </param>
	/// <param name="cbBuf">Specifies the size, in bytes, of the buffer to which pForm points.</param>
	/// <param name="pcbNeeded">
	/// Pointer to a variable that receives the number of bytes copied to the array to which pForm points (if the operation succeeds) or
	/// the number of bytes required (if it fails because cbBuf is too small).
	/// </param>
	/// <param name="pcReturned">
	/// Pointer to a variable that receives the number of structures copied into the array to which pForm points.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the caller is remote, and the Level is 2, the <c>StringType</c> value of the returned <c>FORM_INFO_2</c> structures will
	/// always be <c>STRING_LANGPAIR</c>.
	/// </para>
	/// <para>
	/// In Windows Vista, the form data returned by <c>EnumForms</c> is retrieved from a local cache when hPrinter refers to a remote
	/// print server or a printer hosted by a print server and there is at least one open connection to a printer on the remote print
	/// server. In all other configurations, the form data is queried from the remote print server.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumforms BOOL EnumForms( _In_ HANDLE hPrinter, _In_ DWORD Level, _Out_
	// LPBYTE pForm, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded, _Out_ LPDWORD pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "b13b515a-c764-4a80-ab85-95fb4abb2a6b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumForms(HPRINTER hPrinter, uint Level, IntPtr pForm, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumForms</c> function enumerates the forms supported by the specified printer.</summary>
	/// <typeparam name="T">The type of form information to enumerate. This must be either <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c>.</typeparam>
	/// <param name="hPrinter">
	/// Handle to the printer for which the forms should be enumerated. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <returns>A sequence of <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c> structures. All the structures will be of <typeparamref name="T"/>.</returns>
	[PInvokeData("winspool.h", MSDNShortId = "b13b515a-c764-4a80-ab85-95fb4abb2a6b")]
	public static IEnumerable<T> EnumForms<T>(HPRINTER hPrinter) where T : struct
	{
		if (!TryGetLevel<T>("FORM_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(EnumForms)} cannot process a structure of type {typeof(T).Name}.");
		if (!EnumForms(hPrinter, lvl, default, 0, out var bytes, out var count))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		if (bytes == 0)
			return new T[0];
		using var mem = new SafeCoTaskMemHandle(bytes);
		if (!EnumForms(hPrinter, lvl, mem, mem.Size, out bytes, out count))
			Win32Error.ThrowLastError();
		return mem.ToArray<T>((int)count);
	}

	/// <summary>The <c>EnumJobs</c> function retrieves information about a specified set of print jobs for a specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer object whose print jobs the function enumerates. Use the <c>OpenPrinter</c> or <c>AddPrinter</c>
	/// function to retrieve a printer handle.
	/// </param>
	/// <param name="FirstJob">
	/// The zero-based position within the print queue of the first print job to enumerate. For example, a value of 0 specifies that
	/// enumeration should begin at the first print job in the print queue; a value of 9 specifies that enumeration should begin at the
	/// tenth print job in the print queue.
	/// </param>
	/// <param name="NoJobs">The total number of print jobs to enumerate.</param>
	/// <param name="Level">
	/// <para>The type of information returned in the pJob buffer.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>pJob receives an array of JOB_INFO_1 structures</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>pJob receives an array of JOB_INFO_2 structures</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>pJob receives an array of JOB_INFO_3 structures</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pJob">
	/// <para>
	/// A pointer to a buffer that receives an array of <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_3</c> structures. The
	/// buffer must be large enough to receive the array of structures and any strings or other data to which the structure members point.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>EnumJobs</c> with cbBuf set to zero. <c>EnumJobs</c> fails, <c>GetLastError</c>
	/// returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter returns the size, in bytes, of the buffer required to hold the
	/// array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the pJob buffer.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the number of bytes copied if the function succeeds. If the function fails, the variable
	/// receives the number of bytes required.
	/// </param>
	/// <param name="pcReturned">
	/// A pointer to a variable that receives the number of <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_3</c> structures
	/// returned in the pJob buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>JOB_INFO_1</c> structure contains general print-job information; the <c>JOB_INFO_2</c> structure has much more detailed
	/// information. The <c>JOB_INFO_3</c> structure contains information about how jobs are linked.
	/// </para>
	/// <para>
	/// To determine the number of print jobs in the printer queue, call the <c>GetPrinter</c> function with the Level parameter set to 2.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumjobs BOOL EnumJobs( _In_ HANDLE hPrinter, _In_ DWORD FirstJob, _In_
	// DWORD NoJobs, _In_ DWORD Level, _Out_ LPBYTE pJob, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded, _Out_ LPDWORD pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "1cf429ea-b40e-4063-b6de-c43b7b87f3d3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumJobs(HPRINTER hPrinter, uint FirstJob, uint NoJobs, uint Level, IntPtr pJob, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumJobs</c> function retrieves information about a specified set of print jobs for a specified printer.</summary>
	/// <typeparam name="T">
	/// The type of form information to enumerate. This must be either <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_3</c>.
	/// </typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer object whose print jobs the function enumerates. Use the <c>OpenPrinter</c> or <c>AddPrinter</c>
	/// function to retrieve a printer handle.
	/// </param>
	/// <param name="FirstJob">
	/// The zero-based position within the print queue of the first print job to enumerate. For example, a value of 0 specifies that
	/// enumeration should begin at the first print job in the print queue; a value of 9 specifies that enumeration should begin at the
	/// tenth print job in the print queue.
	/// </param>
	/// <param name="NoJobs">The total number of print jobs to enumerate.</param>
	/// <returns>
	/// A sequence of <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_3</c> structures. All the structures will be of <typeparamref name="T"/>.
	/// </returns>
	[PInvokeData("winspool.h", MSDNShortId = "1cf429ea-b40e-4063-b6de-c43b7b87f3d3")]
	public static IEnumerable<T> EnumJobs<T>(HPRINTER hPrinter, uint FirstJob = 0, uint NoJobs = uint.MaxValue) where T : struct
	{
		if (!TryGetLevel<T>("JOB_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(EnumJobs)} cannot process a structure of type {typeof(T).Name}.");
		if (!EnumJobs(hPrinter, FirstJob, NoJobs, lvl, default, 0, out var bytes, out var count))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		if (bytes == 0)
			return new T[0];
		using var mem = new SafeCoTaskMemHandle(bytes);
		if (!EnumJobs(hPrinter, FirstJob, NoJobs, lvl, mem, mem.Size, out bytes, out count))
			Win32Error.ThrowLastError();
		return mem.ToArray<T>((int)count);
	}

	/// <summary>
	/// <para>The <c>EnumPrinterData</c> function enumerates configuration data for a specified printer.</para>
	/// <para>To retrieve the configuration data in a single call, use the <c>EnumPrinterDataEx</c> function.</para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer whose configuration data is to be obtained. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="dwIndex">
	/// <para>An index value that specifies the configuration data value to retrieve.</para>
	/// <para>
	/// Set this parameter to zero for the first call to <c>EnumPrinterData</c> for a specified printer handle. Then increment the
	/// parameter by one for subsequent calls involving the same printer, until the function returns ERROR_NO_MORE_ITEMS. See the
	/// following Remarks section for further information.
	/// </para>
	/// <para>
	/// If you use the technique mentioned in the descriptions of the cbValueName and cbData parameters to obtain adequate buffer size
	/// values, setting both those parameters to zero in a first call to <c>EnumPrinterData</c> for a specified printer handle, the
	/// value of dwIndex does not matter for that call. Set dwIndex to zero in the next call to <c>EnumPrinterData</c> to start the
	/// actual enumeration process.
	/// </para>
	/// <para>
	/// Configuration data values are not ordered. New values will have an arbitrary index. This means that the <c>EnumPrinterData</c>
	/// function may return values in any order.
	/// </para>
	/// </param>
	/// <param name="pValueName">
	/// A pointer to a buffer that receives the name of the configuration data value, including a terminating null character.
	/// </param>
	/// <param name="cbValueName">
	/// <para>The size, in bytes, of the buffer pointed to by pValueName.</para>
	/// <para>
	/// If you want to have the operating system supply an adequate buffer size, set both this parameter and the cbData parameter to
	/// zero for the first call to <c>EnumPrinterData</c> for a specified printer handle. When the function returns, the variable
	/// pointed to by pcbValueName will contain a buffer size that is large enough to successfully enumerate all of the printer's
	/// configuration data value names.
	/// </para>
	/// </param>
	/// <param name="pcbValueName">A pointer to a variable that receives the number of bytes stored into the buffer pointed to by pValueName.</param>
	/// <param name="pType">
	/// A pointer to a variable that receives a code indicating the type of data stored in the specified value. For a list of the
	/// possible type codes, see Registry Value Types. The pType parameter can be <c>NULL</c> if the type code is not required.
	/// </param>
	/// <param name="pData">
	/// <para>A pointer to a buffer that receives the configuration data value.</para>
	/// <para>This parameter can be <c>NULL</c> if the configuration data value is not required.</para>
	/// </param>
	/// <param name="cbData">
	/// <para>The size, in bytes, of the buffer pointed to by pData.</para>
	/// <para>
	/// If you want to have the operating system supply an adequate buffer size, set both this parameter and the cbValueName parameter
	/// to zero for the first call to <c>EnumPrinterData</c> for a specified printer handle. When the function returns, the variable
	/// pointed to by pcbData will contain a buffer size that is large enough to successfully enumerate all of the printer's
	/// configuration data value names.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>A pointer to a variable that receives the number of bytes stored into the buffer pointed to by pData.</para>
	/// <para>This parameter can be <c>NULL</c> if pData is <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>
	/// The function returns ERROR_NO_MORE_ITEMS when there are no more configuration data values to retrieve for a specified printer handle.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>EnumPrinterData</c> retrieves printer configuration data set by the <c>SetPrinterData</c> function. A printer's configuration
	/// data consists of a set of named and typed values. The <c>EnumPrinterData</c> function obtains one of these values, and its name
	/// and a type code, each time you call it. Call the <c>EnumPrinterData</c> function several times in succession to obtain all of a
	/// printer's configuration data values.
	/// </para>
	/// <para>
	/// Printer configuration data is stored in the registry. While enumerating printer configuration data, you should avoid calling
	/// registry functions that might change that data.
	/// </para>
	/// <para>
	/// If you want to have the operating system supply an adequate buffer size, first call <c>EnumPrinterData</c> with both the
	/// cbValueName and cbData parameters set to zero, as noted earlier in the Parameters section. The value of dwIndex does not matter
	/// for this call. When the function returns, *pcbValueName and *pcbData will contain buffer sizes that are large enough to
	/// enumerate all of the printer's configuration data value names and values. On the next call, allocate value name and data
	/// buffers, set cbValueName and cbData to the sizes in bytes of the allocated buffers, and set dwIndex to zero. Thereafter,
	/// continue to call the <c>EnumPrinterData</c> function, incrementing dwIndex by one each time, until the function returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumprinterdata DWORD EnumPrinterData( _In_ HANDLE hPrinter, _In_ DWORD
	// dwIndex, _Out_ LPTSTR pValueName, _In_ DWORD cbValueName, _Out_ LPDWORD pcbValueName, _Out_ LPDWORD pType, _Out_ LPBYTE pData,
	// _In_ DWORD cbData, _Out_ LPDWORD pcbData );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "0a4c8436-46fe-4e21-8d55-c5031a3d1b38")]
	public static extern Win32Error EnumPrinterData(HPRINTER hPrinter, uint dwIndex, StringBuilder pValueName, uint cbValueName,
		out uint pcbValueName, out REG_VALUE_TYPE pType, IntPtr pData, uint cbData, out uint pcbData);

	/// <summary>
	/// <para>The <c>EnumPrinterData</c> function enumerates configuration data for a specified printer.</para>
	/// <para>To retrieve the configuration data in a single call, use the <c>EnumPrinterDataEx</c> function.</para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer whose configuration data is to be obtained. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <returns>
	/// <para>A sequence of tuples, each with the following information.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>valueName ( <see cref="string"/>)</term>
	/// <description>The name of the configuration data value.</description>
	/// </item>
	/// <item>
	/// <term>valueType ( <see cref="REG_VALUE_TYPE"/>)</term>
	/// <description>The type of data stored in the specified value.</description>
	/// </item>
	/// <item>
	/// <term>value ( <see cref="object"/>)</term>
	/// <description>The configuration data value.</description>
	/// </item>
	/// </list>
	/// </returns>
	[PInvokeData("winspool.h", MSDNShortId = "0a4c8436-46fe-4e21-8d55-c5031a3d1b38")]
	public static IEnumerable<(string valueName, REG_VALUE_TYPE valueType, object value)> EnumPrinterData(HPRINTER hPrinter)
	{
		var idx = 0U;
		EnumPrinterData(hPrinter, idx, null, 0, out var valueNameSz, out _, default, 0, out var dataSz).ThrowIfFailed();
		if (valueNameSz == 0) yield break;
		var name = new StringBuilder(1024);
		using var mem = new SafeCoTaskMemHandle(dataSz);
		while (true)
		{
			name.EnsureCapacity((int)valueNameSz);
			if (mem.Size < dataSz) mem.Size = dataSz;
			var ret = EnumPrinterData(hPrinter, idx, name, (uint)name.Capacity, out valueNameSz, out var valueType, mem, mem.Size, out dataSz);
			if (ret == Win32Error.ERROR_NO_MORE_ITEMS) break;
			if (ret == Win32Error.ERROR_MORE_DATA) continue;
			ret.ThrowIfFailed();
			if (valueNameSz == 0) continue;
			++idx;
			yield return (name.ToString(), valueType, valueType.GetValue(mem, mem.Size));
		}
	}

	/// <summary>
	/// <para>The <c>EnumPrinterDataEx</c> function enumerates all value names and data for a specified printer and key.</para>
	/// <para>
	/// Printer data is stored in the registry. While enumerating printer data, do not call registry functions that might change the data.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function retrieves configuration data. Use the <c>OpenPrinter</c> or <c>AddPrinter</c>
	/// function to retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the values to enumerate. Use the backslash ( \ )
	/// character as a delimiter to specify a path with one or more subkeys. <c>EnumPrinterDataEx</c> enumerates all values of the key,
	/// but does not enumerate values of subkeys of the specified key. Use the <c>EnumPrinterKey</c> function to enumerate subkeys.
	/// </para>
	/// <para>If pKeyName is <c>NULL</c> or an empty string, <c>EnumPrinterDataEx</c> returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <param name="pEnumValues">
	/// A pointer to a buffer that receives an array of <c>PRINTER_ENUM_VALUES</c> structures. Each structure contains the value name,
	/// type, data, and sizes of a value under the key.
	/// </param>
	/// <param name="cbEnumValues">
	/// The size, in bytes, of the buffer pointed to by pcbEnumValues. If you set cbEnumValues to zero, the pcbEnumValues parameter
	/// returns the required buffer size.
	/// </param>
	/// <param name="pcbEnumValues">
	/// A pointer to a variable that receives the size, in bytes, of the retrieved configuration data. If the buffer size specified by
	/// cbEnumValues is too small, the function returns ERROR_MORE_DATA and pcbEnumValues indicates the required buffer size.
	/// </param>
	/// <param name="pnEnumValues">
	/// A pointer to a variable that receives the number of <c>PRINTER_ENUM_VALUES</c> structures returned in pEnumValues.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <c>EnumPrinterDataEx</c> retrieves printer configuration data set by the <c>SetPrinterDataEx</c> and <c>SetPrinterData</c> functions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumprinterdataex DWORD EnumPrinterDataEx( _In_ HANDLE hPrinter, _In_
	// LPCTSTR pKeyName, _Out_ LPBYTE pEnumValues, _In_ DWORD cbEnumValues, _Out_ LPDWORD pcbEnumValues, _Out_ LPDWORD pnEnumValues );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "bc5ecc46-24a4-4b54-9431-0eaf6446e2d6")]
	public static extern Win32Error EnumPrinterDataEx(HPRINTER hPrinter, string pKeyName, IntPtr pEnumValues, uint cbEnumValues, out uint pcbEnumValues, out uint pnEnumValues);

	/// <summary>
	/// <para>The <c>EnumPrinterDataEx</c> function enumerates all value names and data for a specified printer and key.</para>
	/// <para>
	/// Printer data is stored in the registry. While enumerating printer data, do not call registry functions that might change the data.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function retrieves configuration data. Use the <c>OpenPrinter</c> or <c>AddPrinter</c>
	/// function to retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the values to enumerate. Use the backslash ( \ )
	/// character as a delimiter to specify a path with one or more subkeys. <c>EnumPrinterDataEx</c> enumerates all values of the key,
	/// but does not enumerate values of subkeys of the specified key. Use the <c>EnumPrinterKey</c> function to enumerate subkeys.
	/// </para>
	/// <para>If pKeyName is <c>NULL</c> or an empty string, <c>EnumPrinterDataEx</c> returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <returns>
	/// <para>A sequence of tuples, each with the following information.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>valueName ( <see cref="string"/>)</term>
	/// <description>The name of the configuration data value.</description>
	/// </item>
	/// <item>
	/// <term>valueType ( <see cref="REG_VALUE_TYPE"/>)</term>
	/// <description>The type of data stored in the specified value.</description>
	/// </item>
	/// <item>
	/// <term>value ( <see cref="object"/>)</term>
	/// <description>The configuration data value.</description>
	/// </item>
	/// </list>
	/// </returns>
	[PInvokeData("winspool.h", MSDNShortId = "bc5ecc46-24a4-4b54-9431-0eaf6446e2d6")]
	public static IEnumerable<(string valueName, REG_VALUE_TYPE valueType, object value)> EnumPrinterDataEx(HPRINTER hPrinter, string pKeyName = "PrinterDriverData")
	{
		EnumPrinterDataEx(hPrinter, pKeyName, default, 0, out var sz, out var cnt).ThrowUnless(Win32Error.ERROR_MORE_DATA);
		using var mem = new SafeCoTaskMemHandle(sz);
		EnumPrinterDataEx(hPrinter, pKeyName, mem, mem.Size, out sz, out cnt).ThrowIfFailed();
		return mem.ToEnumerable<PRINTER_ENUM_VALUES>((int)cnt).Select(v => (v.pValueName, v.dwType, v.dwType.GetValue(v.pData, v.cbData))).ToArray();
	}

	/// <summary>
	/// <para>The <c>EnumPrinterKey</c> function enumerates the subkeys of a specified key for a specified printer.</para>
	/// <para>
	/// Printer data is stored in the registry. While enumerating printer data, do not call registry functions that might change the data.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function enumerates subkeys. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the subkeys to enumerate. Use the backslash '\'
	/// character as a delimiter to specify a path with one or more subkeys. <c>EnumPrinterKey</c> enumerates all subkeys of the key,
	/// but does not enumerate the subkeys of those subkeys.
	/// </para>
	/// <para>
	/// If pKeyName is an empty string (""), <c>EnumPrinterKey</c> enumerates the top-level key for the printer. If pKeyName is
	/// <c>NULL</c>, <c>EnumPrinterKey</c> returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="pSubkey">
	/// A pointer to a buffer that receives an array of null-terminated subkey names. The array is terminated by two null characters.
	/// </param>
	/// <param name="cbSubkey">
	/// The size, in bytes, of the buffer pointed to by pSubkey. If you set cbSubkey to zero, the pcbSubkey parameter returns the
	/// required buffer size.
	/// </param>
	/// <param name="pcbSubkey">
	/// A pointer to a variable that receives the number of bytes retrieved in the pSubkey buffer. If the buffer size specified by
	/// cbSubkey is too small, the function returns ERROR_MORE_DATA and pcbSubkey indicates the required buffer size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code. If pKeyName does not exist, the return value is ERROR_FILE_NOT_FOUND.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumprinterkey DWORD EnumPrinterKey( _In_ HANDLE hPrinter, _In_ LPCTSTR
	// pKeyName, _Out_ LPTSTR pSubkey, _In_ DWORD cbSubkey, _Out_ LPDWORD pcbSubkey );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "721b1d23-a594-4439-b8f9-9b11be5fe874")]
	public static extern Win32Error EnumPrinterKey(HPRINTER hPrinter, string pKeyName, IntPtr pSubkey, uint cbSubkey, out uint pcbSubkey);

	/// <summary>
	/// <para>The <c>EnumPrinterKey</c> function enumerates the subkeys of a specified key for a specified printer.</para>
	/// <para>
	/// Printer data is stored in the registry. While enumerating printer data, do not call registry functions that might change the data.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function enumerates subkeys. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the subkeys to enumerate. Use the backslash '\'
	/// character as a delimiter to specify a path with one or more subkeys. <c>EnumPrinterKey</c> enumerates all subkeys of the key,
	/// but does not enumerate the subkeys of those subkeys.
	/// </para>
	/// <para>
	/// If pKeyName is an empty string (""), <c>EnumPrinterKey</c> enumerates the top-level key for the printer. If pKeyName is
	/// <c>NULL</c>, <c>EnumPrinterKey</c> returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>An array of subkey names.</returns>
	[PInvokeData("winspool.h", MSDNShortId = "721b1d23-a594-4439-b8f9-9b11be5fe874")]
	public static IEnumerable<string> EnumPrinterKey(HPRINTER hPrinter, string pKeyName)
	{
		EnumPrinterKey(hPrinter, pKeyName, default, 0, out var bytes).ThrowUnless(Win32Error.ERROR_MORE_DATA);
		if (bytes == 0)
			return new string[0];
		using var mem = new SafeCoTaskMemHandle(bytes);
		EnumPrinterKey(hPrinter, pKeyName, mem, mem.Size, out bytes).ThrowIfFailed();
		return mem.ToStringEnum().ToArray();
	}

	/// <summary>The <c>EnumPrinters</c> function enumerates available printers, print servers, domains, or print providers.</summary>
	/// <param name="Flags">
	/// <para>The types of print objects that the function should enumerate. This value can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_ENUM_LOCAL</term>
	/// <term>
	/// If the PRINTER_ENUM_NAME flag is not also passed, the function ignores the Name parameter, and enumerates the locally installed
	/// printers. If PRINTER_ENUM_NAME is also passed, the function enumerates the local printers on Name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NAME</term>
	/// <term>
	/// The function enumerates the printer identified by Name. This can be a server, a domain, or a print provider. If Name is NULL,
	/// the function enumerates available print providers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_SHARED</term>
	/// <term>
	/// The function enumerates printers that have the shared attribute. Cannot be used in isolation; use an OR operation to combine
	/// with another PRINTER_ENUM type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CONNECTIONS</term>
	/// <term>The function enumerates the list of printers to which the user has made previous connections.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NETWORK</term>
	/// <term>The function enumerates network printers in the computer's domain. This value is valid only if Level is 1.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_REMOTE</term>
	/// <term>
	/// The function enumerates network printers and print servers in the computer's domain. This value is valid only if Level is 1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CATEGORY_3D</term>
	/// <term>The function enumerates only 3D printers.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CATEGORY_ALL</term>
	/// <term>The function enumerates all print devices, including 3D printers.</term>
	/// </item>
	/// </list>
	/// <para>If Level is 4, you can only use the PRINTER_ENUM_CONNECTIONS and PRINTER_ENUM_LOCAL constants.</para>
	/// </param>
	/// <param name="Name">
	/// <para>
	/// If Level is 1, Flags contains PRINTER_ENUM_NAME, and Name is non- <c>NULL</c>, then Name is a pointer to a null-terminated
	/// string that specifies the name of the object to enumerate. This string can be the name of a server, a domain, or a print provider.
	/// </para>
	/// <para>
	/// If Level is 1, Flags contains PRINTER_ENUM_NAME, and Name is <c>NULL</c>, then the function enumerates the available print providers.
	/// </para>
	/// <para>
	/// If Level is 1, Flags contains PRINTER_ENUM_REMOTE, and Name is <c>NULL</c>, then the function enumerates the printers in the
	/// user's domain.
	/// </para>
	/// <para>
	/// If Level is 2 or 5,Name is a pointer to a null-terminated string that specifies the name of a server whose printers are to be
	/// enumerated. If this string is <c>NULL</c>, then the function enumerates the printers installed on the local computer.
	/// </para>
	/// <para>If Level is 4, Name should be <c>NULL</c>. The function always queries on the local computer.</para>
	/// <para>
	/// When Name is <c>NULL</c>, setting Flags to PRINTER_ENUM_LOCAL | PRINTER_ENUM_CONNECTIONS enumerates printers that are installed
	/// on the local machine. These printers include those that are physically attached to the local machine as well as remote printers
	/// to which it has a network connection.
	/// </para>
	/// <para>
	/// When Name is not <c>NULL</c>, setting Flags to PRINTER_ENUM_LOCAL | PRINTER_ENUM_NAME enumerates the local printers that are
	/// installed on the server Name.
	/// </para>
	/// </param>
	/// <param name="Level">
	/// <para>
	/// The type of data structures pointed to by pPrinterEnum. Valid values are 1, 2, 4, and 5, which correspond to the
	/// <c>PRINTER_INFO_1</c>, <c>PRINTER_INFO_2</c> , <c>PRINTER_INFO_4</c>, and <c>PRINTER_INFO_5</c> data structures.
	/// </para>
	/// <para>This value can be 1, 2, 4, or 5.</para>
	/// </param>
	/// <param name="pPrinterEnum">
	/// <para>
	/// A pointer to a buffer that receives an array of <c>PRINTER_INFO_1</c>, <c>PRINTER_INFO_2</c>, <c>PRINTER_INFO_4</c>, or
	/// <c>PRINTER_INFO_5</c> structures. Each structure contains data that describes an available print object.
	/// </para>
	/// <para>
	/// If Level is 1, the array contains <c>PRINTER_INFO_1</c> structures. If Level is 2, the array contains <c>PRINTER_INFO_2</c>
	/// structures. If Level is 4, the array contains <c>PRINTER_INFO_4</c> structures. If Level is 5, the array contains
	/// <c>PRINTER_INFO_5</c> structures.
	/// </para>
	/// <para>
	/// The buffer must be large enough to receive the array of data structures and any strings or other data to which the structure
	/// members point. If the buffer is too small, the pcbNeeded parameter returns the required buffer size.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the buffer pointed to by pPrinterEnum.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a value that receives the number of bytes copied if the function succeeds or the number of bytes required if cbBuf
	/// is too small.
	/// </param>
	/// <param name="pcReturned">
	/// A pointer to a value that receives the number of <c>PRINTER_INFO_1</c>, <c>PRINTER_INFO_2</c> , <c>PRINTER_INFO_4</c>, or
	/// <c>PRINTER_INFO_5</c> structures that the function returns in the array to which pPrinterEnum points.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>Do not call this method in <c>DllMain</c>.</para>
	/// <para>
	/// If <c>EnumPrinters</c> returns a <c>PRINTER_INFO_1</c> structure in which PRINTER_ENUM_CONTAINER is specified, this indicates
	/// that there is a hierarchy of printer objects. An application can enumerate the hierarchy by calling <c>EnumPrinters</c> again,
	/// setting Name to the value of the <c>PRINTER_INFO_1</c> structure's <c>pName</c> member.
	/// </para>
	/// <para>
	/// The <c>EnumPrinters</c> function does not retrieve security information. If <c>PRINTER_INFO_2</c> structures are returned in the
	/// array pointed to by pPrinterEnum, their pSecurityDescriptor members will be set to <c>NULL</c>.
	/// </para>
	/// <para>To get information about the default printer, call <c>GetDefaultPrinter</c>.</para>
	/// <para>
	/// The <c>PRINTER_INFO_4</c> structure provides an easy and extremely fast way to retrieve the names of the printers installed on a
	/// local machine, as well as the remote connections that a user has established. When <c>EnumPrinters</c> is called with a
	/// <c>PRINTER_INFO_4</c> data structure, that function queries the registry for the specified information, then returns
	/// immediately. This differs from the behavior of <c>EnumPrinters</c> when called with other levels of <c>PRINTER_INFO_*</c> data
	/// structures. In particular, when <c>EnumPrinters</c> is called with a level 2 ( <c>PRINTER_INFO_2</c>) data structure, it
	/// performs an <c>OpenPrinter</c> call on each remote connection. If a remote connection is down, or the remote server no longer
	/// exists, or the remote printer no longer exists, the function must wait for RPC to time out and consequently fail the
	/// <c>OpenPrinter</c> call. This can take a while. Passing a <c>PRINTER_INFO_4</c> structure lets an application retrieve a bare
	/// minimum of required information; if more detailed information is desired, a subsequent <c>EnumPrinters</c> level 2 call can be made.
	/// </para>
	/// <para>
	/// <c>Windows Vista:</c> The printer data returned by <c>EnumPrinters</c> is retrieved from a local cache when the value of Level
	/// is 4.
	/// </para>
	/// <para>The following table shows the <c>EnumPrinters</c> output for various Flags values when the Level parameter is set to 1.</para>
	/// <para>
	/// In the Name parameter column of the table, you should substitute an appropriate name for Print Provider, Domain, and Machine.
	/// For example, for "Print Provider," you could use the name of the network print provider or the name of the local print provider.
	/// To retrieve print provider names, call <c>EnumPrinters</c> with Name set to <c>NULL</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flags parameter</term>
	/// <term>Name parameter</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_ENUM_LOCAL (and not PRINTER_ENUM_NAME)</term>
	/// <term>The Name parameter is ignored.</term>
	/// <term>All local printers.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NAME</term>
	/// <term>"Print Provider"</term>
	/// <term>All domain names</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NAME</term>
	/// <term>"Print Provider!Domain"</term>
	/// <term>All printers and print servers in the computer's domain</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NAME</term>
	/// <term>"Print Provider!!\\Machine"</term>
	/// <term>All printers shared at \\Machine</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NAME</term>
	/// <term>An empty string, ""</term>
	/// <term>All local printers.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NAME</term>
	/// <term>NULL</term>
	/// <term>All print providers in the computer's domain</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CONNECTIONS</term>
	/// <term>The Name parameter is ignored.</term>
	/// <term>All connected remote printers</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NETWORK</term>
	/// <term>The Name parameter is ignored.</term>
	/// <term>All printers in the computer's domain</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_REMOTE</term>
	/// <term>An empty string, ""</term>
	/// <term>All printers and print servers in the computer's domain</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_REMOTE</term>
	/// <term>"Print Provider"</term>
	/// <term>Same as PRINTER_ENUM_NAME</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_REMOTE</term>
	/// <term>"Print Provider!Domain"</term>
	/// <term>All printers and print servers in computer's domain, regardless of Domain specified.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CATEGORY_3D</term>
	/// <term>The Name parameter is ignored.</term>
	/// <term>Only 3D printers are enumerated.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CATEGORY_ALL</term>
	/// <term>The Name parameter is ignored.</term>
	/// <term>3D printers are enumerated, along with all other printers.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumprinters BOOL EnumPrinters( _In_ DWORD Flags, _In_ LPTSTR Name, _In_
	// DWORD Level, _Out_ LPBYTE pPrinterEnum, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded, _Out_ LPDWORD pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "0d0cc726-c515-4146-9273-cdf1db3c76b7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumPrinters(PRINTER_ENUM Flags, string Name, uint Level, IntPtr pPrinterEnum, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumPrinters</c> function enumerates available printers, print servers, domains, or print providers.</summary>
	/// <typeparam name="T">
	/// The type of form information to enumerate. This must be either <see cref="PRINTER_INFO_1"/>, <see cref="PRINTER_INFO_2"/>,
	/// <see cref="PRINTER_INFO_4"/>, or <see cref="PRINTER_INFO_5"/>.
	/// </typeparam>
	/// <param name="Flags">
	/// <para>The types of print objects that the function should enumerate. This value can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_ENUM_LOCAL</term>
	/// <term>
	/// If the PRINTER_ENUM_NAME flag is not also passed, the function ignores the Name parameter, and enumerates the locally installed
	/// printers. If PRINTER_ENUM_NAME is also passed, the function enumerates the local printers on Name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NAME</term>
	/// <term>
	/// The function enumerates the printer identified by Name. This can be a server, a domain, or a print provider. If Name is NULL,
	/// the function enumerates available print providers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_SHARED</term>
	/// <term>
	/// The function enumerates printers that have the shared attribute. Cannot be used in isolation; use an OR operation to combine
	/// with another PRINTER_ENUM type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CONNECTIONS</term>
	/// <term>The function enumerates the list of printers to which the user has made previous connections.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_NETWORK</term>
	/// <term>The function enumerates network printers in the computer's domain. This value is valid only if Level is 1.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_REMOTE</term>
	/// <term>
	/// The function enumerates network printers and print servers in the computer's domain. This value is valid only if Level is 1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CATEGORY_3D</term>
	/// <term>The function enumerates only 3D printers.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ENUM_CATEGORY_ALL</term>
	/// <term>The function enumerates all print devices, including 3D printers.</term>
	/// </item>
	/// </list>
	/// <para>If Level is 4, you can only use the PRINTER_ENUM_CONNECTIONS and PRINTER_ENUM_LOCAL constants.</para>
	/// </param>
	/// <param name="Name">
	/// <para>
	/// If Level is 1, Flags contains PRINTER_ENUM_NAME, and Name is non- <c>NULL</c>, then Name is a pointer to a null-terminated
	/// string that specifies the name of the object to enumerate. This string can be the name of a server, a domain, or a print provider.
	/// </para>
	/// <para>
	/// If Level is 1, Flags contains PRINTER_ENUM_NAME, and Name is <c>NULL</c>, then the function enumerates the available print providers.
	/// </para>
	/// <para>
	/// If Level is 1, Flags contains PRINTER_ENUM_REMOTE, and Name is <c>NULL</c>, then the function enumerates the printers in the
	/// user's domain.
	/// </para>
	/// <para>
	/// If Level is 2 or 5,Name is a pointer to a null-terminated string that specifies the name of a server whose printers are to be
	/// enumerated. If this string is <c>NULL</c>, then the function enumerates the printers installed on the local computer.
	/// </para>
	/// <para>If Level is 4, Name should be <c>NULL</c>. The function always queries on the local computer.</para>
	/// <para>
	/// When Name is <c>NULL</c>, setting Flags to PRINTER_ENUM_LOCAL | PRINTER_ENUM_CONNECTIONS enumerates printers that are installed
	/// on the local machine. These printers include those that are physically attached to the local machine as well as remote printers
	/// to which it has a network connection.
	/// </para>
	/// <para>
	/// When Name is not <c>NULL</c>, setting Flags to PRINTER_ENUM_LOCAL | PRINTER_ENUM_NAME enumerates the local printers that are
	/// installed on the server Name.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// A sequence of the structures of <typeparamref name="T"/>. Each structure contains data that describes an available print object.
	/// </para>
	/// </returns>
	[PInvokeData("winspool.h", MSDNShortId = "0d0cc726-c515-4146-9273-cdf1db3c76b7")]
	public static IEnumerable<T> EnumPrinters<T>(PRINTER_ENUM Flags = PRINTER_ENUM.PRINTER_ENUM_LOCAL, string Name = null) where T : struct
	{
		if (!TryGetLevel<T>("PRINTER_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(EnumPrinters)} cannot process a structure of type {typeof(T).Name}.");
		if (!EnumPrinters(Flags, Name, lvl, default, 0, out var bytes, out var count))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		if (bytes == 0)
			return new T[0];
		using var mem = new SafeCoTaskMemHandle(bytes);
		if (!EnumPrinters(Flags, Name, lvl, mem, mem.Size, out bytes, out count))
			Win32Error.ThrowLastError();
		return mem.ToArray<T>((int)count);
	}

	/// <summary>
	/// The <c>FindClosePrinterChangeNotification</c> function closes a change notification object created by calling the
	/// <c>FindFirstPrinterChangeNotification</c> function. The printer or print server associated with the change notification object
	/// will no longer be monitored by that object.
	/// </summary>
	/// <param name="hChange">
	/// A handle to the change notification object to be closed. This is a handle created by calling the
	/// <c>FindFirstPrinterChangeNotification</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// After calling the <c>FindClosePrinterChangeNotification</c> function, you cannot use the hChange handle in subsequent calls to
	/// either <c>FindFirstPrinterChangeNotification</c> or <c>FindNextPrinterChangeNotification</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/findcloseprinterchangenotification BOOL
	// FindClosePrinterChangeNotification( _In_ HANDLE hChange );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "2b4758f8-af0a-494b-8f1b-8ea6ee73c79b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindClosePrinterChangeNotification(HPRINTERCHANGENOTIFICATION hChange);

	/// <summary>
	/// <para>
	/// The <c>FindFirstPrinterChangeNotification</c> function creates a change notification object and returns a handle to the object.
	/// You can then use this handle in a call to one of the wait functions to monitor changes to the printer or print server.
	/// </para>
	/// <para>
	/// The <c>FindFirstPrinterChangeNotification</c> call specifies the type of changes to be monitored. You can specify a set of
	/// conditions to monitor for changes, a set of printer information fields to monitor, or both.
	/// </para>
	/// <para>
	/// A wait operation on the change notification handle succeeds when one of the specified changes occurs in the specified printer or
	/// print server. You then call the <c>FindNextPrinterChangeNotification</c> function to retrieve information about the change, and
	/// to reset the change notification object for use in the next wait operation.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server that you want to monitor. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="fdwFilter">
	/// <para>
	/// The conditions that will cause the change notification object to enter a signaled state. A change notification occurs when one
	/// or more of the specified conditions are met. The fdwFilter parameter can be zero if pPrinterNotifyOptions is non- <c>NULL</c>.
	/// </para>
	/// <para>This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_CHANGE_FORM</term>
	/// <term>
	/// Notify of any changes to a form. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_FORM PRINTER_CHANGE_SET_FORM PRINTER_CHANGE_DELETE_FORM
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_JOB</term>
	/// <term>
	/// Notify of any changes to a job. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_JOB PRINTER_CHANGE_SET_JOB PRINTER_CHANGE_DELETE_JOB PRINTER_CHANGE_WRITE_JOB
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PORT</term>
	/// <term>
	/// Notify of any changes to a port. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PORT PRINTER_CHANGE_CONFIGURE_PORT PRINTER_CHANGE_DELETE_PORT
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PRINT_PROCESSOR</term>
	/// <term>
	/// Notify of any changes to a print processor. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PRINT_PROCESSOR PRINTER_CHANGE_DELETE_PRINT_PROCESSOR
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PRINTER</term>
	/// <term>
	/// Notify of any changes to a printer. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PRINTER PRINTER_CHANGE_SET_PRINTER PRINTER_CHANGE_DELETE_PRINTER PRINTER_CHANGE_FAILED_CONNECTION_PRINTER
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PRINTER_DRIVER</term>
	/// <term>
	/// Notify of any changes to a printer driver. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PRINTER_DRIVER PRINTER_CHANGE_SET_PRINTER_DRIVER PRINTER_CHANGE_DELETE_PRINTER_DRIVER
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ALL</term>
	/// <term>Notify if any of the preceding changes occur.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SERVER</term>
	/// <term>
	/// Windows 7: Notify of any changes to the server. This flag is not included in the changes monitored by setting the
	/// PRINTER_CHANGE_ALL value.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For descriptions of the more specific flags in the preceding table, see the <c>FindNextPrinterChangeNotification</c> function.</para>
	/// </param>
	/// <param name="fdwOptions">
	/// <para>The flag that determines the category of printers for which notifications will work.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_NOTIFY_CATEGORY_ALL 0x001000</term>
	/// <term>FindNextPrinterChangeNotification returns notifications for both 2D and 3D printers.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_CATEGORY_3D 0x002000</term>
	/// <term>FindNextPrinterChangeNotification returns notifications only for 3D printers.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When this flag is set to zero (0), <c>FindFirstPrinterChangeNotification</c> will only work for 2D printers. This is the default value.
	/// </para>
	/// </param>
	/// <param name="pPrinterNotifyOptions">
	/// <para>
	/// A pointer to a <c>PRINTER_NOTIFY_OPTIONS</c> structure. The <c>pTypes</c> member of this structure is an array of one or more
	/// <c>PRINTER_NOTIFY_OPTIONS_TYPE</c> structures, each of which specifies a printer information field to monitor. A change
	/// notification occurs when one or more of the specified fields changes. When a change occurs, the
	/// <c>FindNextPrinterChangeNotification</c> function can retrieve the new printer information. This parameter can be <c>NULL</c> if
	/// fdwFilter is nonzero.
	/// </para>
	/// <para>For a list of fields that can be monitored, see <c>PRINTER_NOTIFY_OPTIONS_TYPE</c>.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to a change notification object associated with the specified printer or
	/// print server.
	/// </para>
	/// <para>If the function fails, the return value is INVALID_HANDLE_VALUE.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To monitor a printer or print server, call the <c>FindFirstPrinterChangeNotification</c> function, then use the returned change
	/// notification object handle in a call to one of the wait functions. A wait operation on a change notification object is satisfied
	/// when the change notification object enters the signaled state. The system signals the object when one or more of the changes
	/// specified by fdwFilter or pPrinterNotifyOptions occurs in the monitored printer or print server.
	/// </para>
	/// <para>
	/// When you call <c>FindFirstPrinterChangeNotification</c>, either fdwFilter must be nonzero or pPrinterNotifyOptions must be non-
	/// <c>NULL</c>. If both are specified, notifications will occur for both.
	/// </para>
	/// <para>
	/// When a wait operation on a printer change notification object is satisfied, call the <c>FindNextPrinterChangeNotification</c>
	/// function to determine the cause of the notification. For a condition specified by fdwFilter,
	/// <c>FindNextPrinterChangeNotification</c> reports the condition or conditions that changed. For a printer information field
	/// specified by pPrinterNotifyOptions, <c>FindNextPrinterChangeNotification</c> reports the field or fields that changed as well as
	/// the new information for these fields. <c>FindNextPrinterChangeNotification</c> also resets the change notification object to the
	/// nonsignaled state so you can use it in another wait operation to continue monitoring the printer or print server.
	/// </para>
	/// <para>
	/// With one exception, do not call the <c>FindNextPrinterChangeNotification</c> function if the change notification object is not
	/// in the signaled state. If the wait function returns the value WAIT_TIMEOUT, the change object is not in the signaled state. Call
	/// the <c>FindNextPrinterChangeNotification</c> function only if the wait function succeeds without timing out. The exception is
	/// when <c>FindNextPrinterChangeNotification</c> is called with the PRINTER_NOTIFY_OPTIONS_REFRESH bit set in the
	/// pPrinterNotifyOptions parameter.
	/// </para>
	/// <para>
	/// When you no longer need the change notification object, close it by calling the <c>FindClosePrinterChangeNotification</c> function.
	/// </para>
	/// <para>
	/// Callers of <c>FindFirstPrinterChangeNotification</c> must ensure that the printer handle passed into
	/// <c>FindFirstPrinterChangeNotification</c> remains valid until <c>FindClosePrinterChangeNotification</c> is called. If the
	/// printer handle is closed before the printer change notification handle, further notifications will fail to be delivered.
	/// </para>
	/// <para><c>FindFirstPrinterChangeNotification</c> will not send change notifications for 3D printers to server handles.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/findfirstprinterchangenotification HANDLE
	// FindFirstPrinterChangeNotification( _In_ HANDLE hPrinter, DWORD fdwFilter, DWORD fdwOptions, _In_opt_ LPVOID
	// pPrinterNotifyOptions );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "4155ef5c-cd96-4960-919b-d9a495bb73a5")]
	public static extern SafeHPRINTERCHANGENOTIFICATION FindFirstPrinterChangeNotification(HPRINTER hPrinter, PRINTER_CHANGE fdwFilter,
		PRINTER_NOTIFY_CATEGORY fdwOptions, in PRINTER_NOTIFY_OPTIONS pPrinterNotifyOptions);

	/// <summary>
	/// <para>
	/// The <c>FindFirstPrinterChangeNotification</c> function creates a change notification object and returns a handle to the object.
	/// You can then use this handle in a call to one of the wait functions to monitor changes to the printer or print server.
	/// </para>
	/// <para>
	/// The <c>FindFirstPrinterChangeNotification</c> call specifies the type of changes to be monitored. You can specify a set of
	/// conditions to monitor for changes, a set of printer information fields to monitor, or both.
	/// </para>
	/// <para>
	/// A wait operation on the change notification handle succeeds when one of the specified changes occurs in the specified printer or
	/// print server. You then call the <c>FindNextPrinterChangeNotification</c> function to retrieve information about the change, and
	/// to reset the change notification object for use in the next wait operation.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server that you want to monitor. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="fdwFilter">
	/// <para>
	/// The conditions that will cause the change notification object to enter a signaled state. A change notification occurs when one
	/// or more of the specified conditions are met. The fdwFilter parameter can be zero if pPrinterNotifyOptions is non- <c>NULL</c>.
	/// </para>
	/// <para>This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_CHANGE_FORM</term>
	/// <term>
	/// Notify of any changes to a form. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_FORM PRINTER_CHANGE_SET_FORM PRINTER_CHANGE_DELETE_FORM
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_JOB</term>
	/// <term>
	/// Notify of any changes to a job. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_JOB PRINTER_CHANGE_SET_JOB PRINTER_CHANGE_DELETE_JOB PRINTER_CHANGE_WRITE_JOB
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PORT</term>
	/// <term>
	/// Notify of any changes to a port. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PORT PRINTER_CHANGE_CONFIGURE_PORT PRINTER_CHANGE_DELETE_PORT
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PRINT_PROCESSOR</term>
	/// <term>
	/// Notify of any changes to a print processor. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PRINT_PROCESSOR PRINTER_CHANGE_DELETE_PRINT_PROCESSOR
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PRINTER</term>
	/// <term>
	/// Notify of any changes to a printer. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PRINTER PRINTER_CHANGE_SET_PRINTER PRINTER_CHANGE_DELETE_PRINTER PRINTER_CHANGE_FAILED_CONNECTION_PRINTER
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_PRINTER_DRIVER</term>
	/// <term>
	/// Notify of any changes to a printer driver. You can set this general flag or one or more of the following specific flags:
	/// PRINTER_CHANGE_ADD_PRINTER_DRIVER PRINTER_CHANGE_SET_PRINTER_DRIVER PRINTER_CHANGE_DELETE_PRINTER_DRIVER
	/// </term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ALL</term>
	/// <term>Notify if any of the preceding changes occur.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SERVER</term>
	/// <term>
	/// Windows 7: Notify of any changes to the server. This flag is not included in the changes monitored by setting the
	/// PRINTER_CHANGE_ALL value.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For descriptions of the more specific flags in the preceding table, see the <c>FindNextPrinterChangeNotification</c> function.</para>
	/// </param>
	/// <param name="fdwOptions">
	/// <para>The flag that determines the category of printers for which notifications will work.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_NOTIFY_CATEGORY_ALL 0x001000</term>
	/// <term>FindNextPrinterChangeNotification returns notifications for both 2D and 3D printers.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_CATEGORY_3D 0x002000</term>
	/// <term>FindNextPrinterChangeNotification returns notifications only for 3D printers.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When this flag is set to zero (0), <c>FindFirstPrinterChangeNotification</c> will only work for 2D printers. This is the default value.
	/// </para>
	/// </param>
	/// <param name="pPrinterNotifyOptions">
	/// <para>
	/// A pointer to a <c>PRINTER_NOTIFY_OPTIONS</c> structure. The <c>pTypes</c> member of this structure is an array of one or more
	/// <c>PRINTER_NOTIFY_OPTIONS_TYPE</c> structures, each of which specifies a printer information field to monitor. A change
	/// notification occurs when one or more of the specified fields changes. When a change occurs, the
	/// <c>FindNextPrinterChangeNotification</c> function can retrieve the new printer information. This parameter can be <c>NULL</c> if
	/// fdwFilter is nonzero.
	/// </para>
	/// <para>For a list of fields that can be monitored, see <c>PRINTER_NOTIFY_OPTIONS_TYPE</c>.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to a change notification object associated with the specified printer or
	/// print server.
	/// </para>
	/// <para>If the function fails, the return value is INVALID_HANDLE_VALUE.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To monitor a printer or print server, call the <c>FindFirstPrinterChangeNotification</c> function, then use the returned change
	/// notification object handle in a call to one of the wait functions. A wait operation on a change notification object is satisfied
	/// when the change notification object enters the signaled state. The system signals the object when one or more of the changes
	/// specified by fdwFilter or pPrinterNotifyOptions occurs in the monitored printer or print server.
	/// </para>
	/// <para>
	/// When you call <c>FindFirstPrinterChangeNotification</c>, either fdwFilter must be nonzero or pPrinterNotifyOptions must be non-
	/// <c>NULL</c>. If both are specified, notifications will occur for both.
	/// </para>
	/// <para>
	/// When a wait operation on a printer change notification object is satisfied, call the <c>FindNextPrinterChangeNotification</c>
	/// function to determine the cause of the notification. For a condition specified by fdwFilter,
	/// <c>FindNextPrinterChangeNotification</c> reports the condition or conditions that changed. For a printer information field
	/// specified by pPrinterNotifyOptions, <c>FindNextPrinterChangeNotification</c> reports the field or fields that changed as well as
	/// the new information for these fields. <c>FindNextPrinterChangeNotification</c> also resets the change notification object to the
	/// nonsignaled state so you can use it in another wait operation to continue monitoring the printer or print server.
	/// </para>
	/// <para>
	/// With one exception, do not call the <c>FindNextPrinterChangeNotification</c> function if the change notification object is not
	/// in the signaled state. If the wait function returns the value WAIT_TIMEOUT, the change object is not in the signaled state. Call
	/// the <c>FindNextPrinterChangeNotification</c> function only if the wait function succeeds without timing out. The exception is
	/// when <c>FindNextPrinterChangeNotification</c> is called with the PRINTER_NOTIFY_OPTIONS_REFRESH bit set in the
	/// pPrinterNotifyOptions parameter.
	/// </para>
	/// <para>
	/// When you no longer need the change notification object, close it by calling the <c>FindClosePrinterChangeNotification</c> function.
	/// </para>
	/// <para>
	/// Callers of <c>FindFirstPrinterChangeNotification</c> must ensure that the printer handle passed into
	/// <c>FindFirstPrinterChangeNotification</c> remains valid until <c>FindClosePrinterChangeNotification</c> is called. If the
	/// printer handle is closed before the printer change notification handle, further notifications will fail to be delivered.
	/// </para>
	/// <para><c>FindFirstPrinterChangeNotification</c> will not send change notifications for 3D printers to server handles.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/findfirstprinterchangenotification HANDLE
	// FindFirstPrinterChangeNotification( _In_ HANDLE hPrinter, DWORD fdwFilter, DWORD fdwOptions, _In_opt_ LPVOID
	// pPrinterNotifyOptions );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "4155ef5c-cd96-4960-919b-d9a495bb73a5")]
	public static extern SafeHPRINTERCHANGENOTIFICATION FindFirstPrinterChangeNotification(HPRINTER hPrinter, PRINTER_CHANGE fdwFilter,
		PRINTER_NOTIFY_CATEGORY fdwOptions, [In, Optional] IntPtr pPrinterNotifyOptions);

	/// <summary>
	/// <para>
	/// The <c>FindNextPrinterChangeNotification</c> function retrieves information about the most recent change notification for a
	/// change notification object associated with a printer or print server. Call this function when a wait operation on the change
	/// notification object is satisfied.
	/// </para>
	/// <para>
	/// The function also resets the change notification object to the not-signaled state. You can then use the object in another wait
	/// operation to continue monitoring the printer or print server. The operating system will set the object to the signaled state the
	/// next time one of a specified set of changes occurs to the printer or print server. The <c>FindFirstPrinterChangeNotification</c>
	/// function creates the change notification object and specifies the set of changes to be monitored.
	/// </para>
	/// </summary>
	/// <param name="hChange">
	/// A handle to a change notification object associated with a printer or print server. You obtain such a handle by calling the
	/// <c>FindFirstPrinterChangeNotification</c> function. The operating system sets this change notification object to the signaled
	/// state when it detects one of the changes specified in the object's change notification filter.
	/// </param>
	/// <param name="pdwChange">
	/// <para>
	/// A pointer to a variable whose bits are set to indicate the changes that occurred to cause the most recent notification. The bit
	/// flags that might be set correspond to those specified in the fdwFilter parameter of the
	/// <c>FindFirstPrinterChangeNotification</c> call. The system sets one or more of the following bit flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_FORM</term>
	/// <term>A form was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_JOB</term>
	/// <term>A print job was sent to the printer.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PORT</term>
	/// <term>A port or monitor was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PRINT_PROCESSOR</term>
	/// <term>A print processor was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PRINTER</term>
	/// <term>A printer was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PRINTER_DRIVER</term>
	/// <term>A printer driver was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_CONFIGURE_PORT</term>
	/// <term>A port was configured on the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_FORM</term>
	/// <term>A form was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_JOB</term>
	/// <term>A job was deleted.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PORT</term>
	/// <term>A port or monitor was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PRINT_PROCESSOR</term>
	/// <term>A print processor was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PRINTER</term>
	/// <term>A printer was deleted.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PRINTER_DRIVER</term>
	/// <term>A printer driver was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_FAILED_CONNECTION_PRINTER</term>
	/// <term>A printer connection has failed.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_FORM</term>
	/// <term>A form was set on the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_JOB</term>
	/// <term>A job was set.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_PRINTER</term>
	/// <term>A printer was set.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_PRINTER_DRIVER</term>
	/// <term>A printer driver was set.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_WRITE_JOB</term>
	/// <term>Job data was written.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_TIMEOUT</term>
	/// <term>The job timed out.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SERVER</term>
	/// <term>Windows 7: A change occurred on the server.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pPrinterNotifyOptions">
	/// A pointer to a <c>PRINTER_NOTIFY_OPTIONS</c> structure. Set the <c>Flags</c> member of this structure to
	/// <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c>, to cause the function to return the current data for all monitored printer information
	/// fields. The function ignores all other members of the structure. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ppPrinterNotifyInfo">
	/// <para>
	/// A pointer to a pointer variable that receives a pointer to a system-allocated, read-only buffer. Call the
	/// <c>FreePrinterNotifyInfo</c> function to free the buffer when you are finished with it. This parameter can be <c>NULL</c> if no
	/// information is required.
	/// </para>
	/// <para>
	/// The buffer contains a <c>PRINTER_NOTIFY_INFO</c> structure, which contains an array of <c>PRINTER_NOTIFY_INFO_DATA</c>
	/// structures. Each element of the array contains information about one of the fields specified in the pPrinterNotifyOptions
	/// parameter of the <c>FindFirstPrinterChangeNotification</c> call. Typically, the function provides data only for the fields that
	/// changed to cause the most recent notification. However, if the structure pointed to by the pPrinterNotifyOptions parameter
	/// specifies <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c>, the function provides data for all monitored fields.
	/// </para>
	/// <para>
	/// If the <c>PRINTER_NOTIFY_INFO_DISCARDED</c> bit is set in the <c>Flags</c> member of the <c>PRINTER_NOTIFY_INFO</c> structure,
	/// an overflow or error occurred, and notifications may have been lost. In this case, no additional notifications will be sent
	/// until you make a second <c>FindNextPrinterChangeNotification</c> call that specifies <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call the <c>FindNextPrinterChangeNotification</c> function after a wait operation on a notification object created by
	/// <c>FindFirstPrinterChangeNotification</c> has been satisfied. Calling <c>FindNextPrinterChangeNotification</c> lets you obtain
	/// information about the change that satisfied the wait operation, and resets the notification object so it can be signaled when
	/// the next change occurs.
	/// </para>
	/// <para>
	/// With one exception, do not call the <c>FindNextPrinterChangeNotification</c> function if the change notification object is not
	/// in the signaled state. If a wait function returns the value <c>WAIT_TIMEOUT</c>, the change object is not in the signaled state.
	/// Call the <c>FindNextPrinterChangeNotification</c> function only if the wait function succeeds without timing out. The exception
	/// is when <c>FindNextPrinterChangeNotification</c> is called with the <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c> bit set in the
	/// pPrinterNotifyOptions parameter. Note that even when this flag is set, it is still possible for the
	/// <c>PRINTER_NOTIFY_INFO_DISCARDED</c> flag to be set in the ppPrinterNotifyInfo parameter.
	/// </para>
	/// <para>
	/// To continue monitoring the printer or print server for changes, repeat the cycle of calling one of the wait functions , and then
	/// calling the <c>FindNextPrinterChangeNotification</c> function to examine the change and reset the notification object.
	/// </para>
	/// <para>
	/// <c>FindNextPrinterChangeNotification</c> may combine multiple changes to the same printer information field into a single
	/// notification. When this occurs, the function typically collapses all changes for the field into a single entry in the array of
	/// <c>PRINTER_NOTIFY_INFO_DATA</c> structures in ppPrinterNotifyInfo; the single entry reports only the most current information.
	/// However, for some job and printer information fields, the function can return multiple array entries for the same field. In this
	/// case, the last array entry for the field reports the current data, and the earlier entries contain the data for the intermediate stages.
	/// </para>
	/// <para>
	/// When you no longer need the change notification object, close it by calling the <c>FindClosePrinterChangeNotification</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/findnextprinterchangenotification BOOL
	// FindNextPrinterChangeNotification( _In_ HANDLE hChange, _Out_opt_ PDWORD pdwChange, _In_opt_ LPVOID pPrinterNotifyOptions,
	// _Out_opt_ LPVOID *ppPrinterNotifyInfo );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "ea7774ae-361f-41e4-bbc6-3f100028b22a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindNextPrinterChangeNotification(HPRINTERCHANGENOTIFICATION hChange, out PRINTER_CHANGE pdwChange,
		in PRINTER_NOTIFY_OPTIONS pPrinterNotifyOptions, out SafePRINTER_NOTIFY_INFO ppPrinterNotifyInfo);

	/// <summary>
	/// <para>
	/// The <c>FindNextPrinterChangeNotification</c> function retrieves information about the most recent change notification for a
	/// change notification object associated with a printer or print server. Call this function when a wait operation on the change
	/// notification object is satisfied.
	/// </para>
	/// <para>
	/// The function also resets the change notification object to the not-signaled state. You can then use the object in another wait
	/// operation to continue monitoring the printer or print server. The operating system will set the object to the signaled state the
	/// next time one of a specified set of changes occurs to the printer or print server. The <c>FindFirstPrinterChangeNotification</c>
	/// function creates the change notification object and specifies the set of changes to be monitored.
	/// </para>
	/// </summary>
	/// <param name="hChange">
	/// A handle to a change notification object associated with a printer or print server. You obtain such a handle by calling the
	/// <c>FindFirstPrinterChangeNotification</c> function. The operating system sets this change notification object to the signaled
	/// state when it detects one of the changes specified in the object's change notification filter.
	/// </param>
	/// <param name="pdwChange">
	/// <para>
	/// A pointer to a variable whose bits are set to indicate the changes that occurred to cause the most recent notification. The bit
	/// flags that might be set correspond to those specified in the fdwFilter parameter of the
	/// <c>FindFirstPrinterChangeNotification</c> call. The system sets one or more of the following bit flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_FORM</term>
	/// <term>A form was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_JOB</term>
	/// <term>A print job was sent to the printer.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PORT</term>
	/// <term>A port or monitor was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PRINT_PROCESSOR</term>
	/// <term>A print processor was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PRINTER</term>
	/// <term>A printer was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_ADD_PRINTER_DRIVER</term>
	/// <term>A printer driver was added to the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_CONFIGURE_PORT</term>
	/// <term>A port was configured on the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_FORM</term>
	/// <term>A form was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_JOB</term>
	/// <term>A job was deleted.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PORT</term>
	/// <term>A port or monitor was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PRINT_PROCESSOR</term>
	/// <term>A print processor was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PRINTER</term>
	/// <term>A printer was deleted.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_DELETE_PRINTER_DRIVER</term>
	/// <term>A printer driver was deleted from the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_FAILED_CONNECTION_PRINTER</term>
	/// <term>A printer connection has failed.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_FORM</term>
	/// <term>A form was set on the server.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_JOB</term>
	/// <term>A job was set.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_PRINTER</term>
	/// <term>A printer was set.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SET_PRINTER_DRIVER</term>
	/// <term>A printer driver was set.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_WRITE_JOB</term>
	/// <term>Job data was written.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_TIMEOUT</term>
	/// <term>The job timed out.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CHANGE_SERVER</term>
	/// <term>Windows 7: A change occurred on the server.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pPrinterNotifyOptions">
	/// A pointer to a <c>PRINTER_NOTIFY_OPTIONS</c> structure. Set the <c>Flags</c> member of this structure to
	/// <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c>, to cause the function to return the current data for all monitored printer information
	/// fields. The function ignores all other members of the structure. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ppPrinterNotifyInfo">
	/// <para>
	/// A pointer to a pointer variable that receives a pointer to a system-allocated, read-only buffer. Call the
	/// <c>FreePrinterNotifyInfo</c> function to free the buffer when you are finished with it. This parameter can be <c>NULL</c> if no
	/// information is required.
	/// </para>
	/// <para>
	/// The buffer contains a <c>PRINTER_NOTIFY_INFO</c> structure, which contains an array of <c>PRINTER_NOTIFY_INFO_DATA</c>
	/// structures. Each element of the array contains information about one of the fields specified in the pPrinterNotifyOptions
	/// parameter of the <c>FindFirstPrinterChangeNotification</c> call. Typically, the function provides data only for the fields that
	/// changed to cause the most recent notification. However, if the structure pointed to by the pPrinterNotifyOptions parameter
	/// specifies <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c>, the function provides data for all monitored fields.
	/// </para>
	/// <para>
	/// If the <c>PRINTER_NOTIFY_INFO_DISCARDED</c> bit is set in the <c>Flags</c> member of the <c>PRINTER_NOTIFY_INFO</c> structure,
	/// an overflow or error occurred, and notifications may have been lost. In this case, no additional notifications will be sent
	/// until you make a second <c>FindNextPrinterChangeNotification</c> call that specifies <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call the <c>FindNextPrinterChangeNotification</c> function after a wait operation on a notification object created by
	/// <c>FindFirstPrinterChangeNotification</c> has been satisfied. Calling <c>FindNextPrinterChangeNotification</c> lets you obtain
	/// information about the change that satisfied the wait operation, and resets the notification object so it can be signaled when
	/// the next change occurs.
	/// </para>
	/// <para>
	/// With one exception, do not call the <c>FindNextPrinterChangeNotification</c> function if the change notification object is not
	/// in the signaled state. If a wait function returns the value <c>WAIT_TIMEOUT</c>, the change object is not in the signaled state.
	/// Call the <c>FindNextPrinterChangeNotification</c> function only if the wait function succeeds without timing out. The exception
	/// is when <c>FindNextPrinterChangeNotification</c> is called with the <c>PRINTER_NOTIFY_OPTIONS_REFRESH</c> bit set in the
	/// pPrinterNotifyOptions parameter. Note that even when this flag is set, it is still possible for the
	/// <c>PRINTER_NOTIFY_INFO_DISCARDED</c> flag to be set in the ppPrinterNotifyInfo parameter.
	/// </para>
	/// <para>
	/// To continue monitoring the printer or print server for changes, repeat the cycle of calling one of the wait functions , and then
	/// calling the <c>FindNextPrinterChangeNotification</c> function to examine the change and reset the notification object.
	/// </para>
	/// <para>
	/// <c>FindNextPrinterChangeNotification</c> may combine multiple changes to the same printer information field into a single
	/// notification. When this occurs, the function typically collapses all changes for the field into a single entry in the array of
	/// <c>PRINTER_NOTIFY_INFO_DATA</c> structures in ppPrinterNotifyInfo; the single entry reports only the most current information.
	/// However, for some job and printer information fields, the function can return multiple array entries for the same field. In this
	/// case, the last array entry for the field reports the current data, and the earlier entries contain the data for the intermediate stages.
	/// </para>
	/// <para>
	/// When you no longer need the change notification object, close it by calling the <c>FindClosePrinterChangeNotification</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/findnextprinterchangenotification BOOL
	// FindNextPrinterChangeNotification( _In_ HANDLE hChange, _Out_opt_ PDWORD pdwChange, _In_opt_ LPVOID pPrinterNotifyOptions,
	// _Out_opt_ LPVOID *ppPrinterNotifyInfo );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "ea7774ae-361f-41e4-bbc6-3f100028b22a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindNextPrinterChangeNotification(HPRINTERCHANGENOTIFICATION hChange, out PRINTER_CHANGE pdwChange,
		[Optional] IntPtr pPrinterNotifyOptions, out SafePRINTER_NOTIFY_INFO ppPrinterNotifyInfo);

	/// <summary>The <c>FlushPrinter</c> function sends a buffer to the printer in order to clear it from a transient state.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer object. This should be the same handle that was used, in a prior <c>WritePrinter</c> call, by the
	/// printer driver.
	/// </param>
	/// <param name="pBuf">A pointer to an array of bytes that contains the data to be written to the printer.</param>
	/// <param name="cbBuf">The size, in bytes, of the array pointed to by pBuf.</param>
	/// <param name="pcWritten">A pointer to a value that receives the number of bytes of data that were written to the printer.</param>
	/// <param name="cSleep">The time, in milliseconds, for which the I/O line to the printer port should be kept idle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>FlushPrinter</c> should be called only if <c>WritePrinter</c> failed, leaving the printer in a transient state. For example,
	/// the printer could get into a transient state when the job gets aborted and the printer driver has partially sent some raw data
	/// to the printer.
	/// </para>
	/// <para>
	/// <c>FlushPrinter</c> also can specify an idle period during which the print spooler does not schedule any jobs to the
	/// corresponding printer port.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/flushprinter BOOL FlushPrinter( _In_ HANDLE hPrinter, _In_ LPVOID pBuf,
	// _In_ DWORD cbBuf, _Out_ LPDWORD pcWritten, _In_ DWORD cSleep );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "08e54175-da68-4ebd-91ec-8f4525f49d30")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlushPrinter(HPRINTER hPrinter, IntPtr pBuf, uint cbBuf, out uint pcWritten, uint cSleep);

	/// <summary>The <c>FlushPrinter</c> function sends a buffer to the printer in order to clear it from a transient state.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer object. This should be the same handle that was used, in a prior <c>WritePrinter</c> call, by the
	/// printer driver.
	/// </param>
	/// <param name="pBuf">A pointer to an array of bytes that contains the data to be written to the printer.</param>
	/// <param name="cbBuf">The size, in bytes, of the array pointed to by pBuf.</param>
	/// <param name="pcWritten">A pointer to a value that receives the number of bytes of data that were written to the printer.</param>
	/// <param name="cSleep">The time, in milliseconds, for which the I/O line to the printer port should be kept idle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>FlushPrinter</c> should be called only if <c>WritePrinter</c> failed, leaving the printer in a transient state. For example,
	/// the printer could get into a transient state when the job gets aborted and the printer driver has partially sent some raw data
	/// to the printer.
	/// </para>
	/// <para>
	/// <c>FlushPrinter</c> also can specify an idle period during which the print spooler does not schedule any jobs to the
	/// corresponding printer port.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/flushprinter BOOL FlushPrinter( _In_ HANDLE hPrinter, _In_ LPVOID pBuf,
	// _In_ DWORD cbBuf, _Out_ LPDWORD pcWritten, _In_ DWORD cSleep );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "08e54175-da68-4ebd-91ec-8f4525f49d30")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlushPrinter(HPRINTER hPrinter, byte[] pBuf, int cbBuf, out uint pcWritten, uint cSleep);

	/// <summary>
	/// The <c>FreePrinterNotifyInfo</c> function frees a system-allocated buffer created by the
	/// <c>FindNextPrinterChangeNotification</c> function.
	/// </summary>
	/// <param name="pPrinterNotifyInfo">
	/// Pointer to a <c>PRINTER_NOTIFY_INFO</c> buffer returned from a call to the <c>FindNextPrinterChangeNotification</c> function.
	/// <c>FreePrinterNotifyInfo</c> deallocates this buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/freeprinternotifyinfo BOOL FreePrinterNotifyInfo( _In_
	// PPRINTER_NOTIFY_INFO pPrinterNotifyInfo );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "e50d4718-3682-486b-9d07-ddddd0b284dc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreePrinterNotifyInfo(IntPtr pPrinterNotifyInfo);

	/// <summary>
	/// The <c>GetDefaultPrinter</c> function retrieves the printer name of the default printer for the current user on the local computer.
	/// </summary>
	/// <param name="pszBuffer">
	/// A pointer to a buffer that receives a null-terminated character string containing the default printer name. If this parameter is
	/// <c>NULL</c>, the function fails and the variable pointed to by pcchBuffer returns the required buffer size, in characters.
	/// </param>
	/// <param name="pcchBuffer">
	/// On input, specifies the size, in characters, of the pszBuffer buffer. On output, receives the size, in characters, of the
	/// printer name string, including the terminating null character.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a nonzero value and the variable pointed to by pcchBuffer contains the number of
	/// characters copied to the pszBuffer buffer, including the terminating null character.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The pszBuffer buffer is too small. The variable pointed to by pcchBuffer contains the required buffer size, in characters.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>There is no default printer.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getdefaultprinter BOOL GetDefaultPrinter( _In_ LPTSTR pszBuffer, _Inout_
	// LPDWORD pcchBuffer );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "8ec06743-43ce-4fac-83c4-f09eac7ee333")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);

	/// <summary>The <c>GetForm</c> function retrieves information about a specified form.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pFormName">
	/// A pointer to a null-terminated string that specifies the name of the form. To get the names of the forms supported by the
	/// printer, call the <c>EnumForms</c> function.
	/// </param>
	/// <param name="Level">The version of the structure to which pForm points. This value must be 1 or 2.</param>
	/// <param name="pForm">A pointer to an array of bytes that receives the initialized <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c> structure.</param>
	/// <param name="cbBuf">The size, in bytes, of the pForm array.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a value that specifies the number of bytes copied if the function succeeds or the number of bytes required if cbBuf
	/// is too small.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// If the caller is remote, and the Level is 2, the <c>StringType</c> value of the returned <c>FORM_INFO_2</c> will always be STRING_LANGPAIR.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getform BOOL GetForm( _In_ HANDLE hPrinter, _In_ LPTSTR pFormName, _In_
	// DWORD Level, _Out_ LPBYTE pForm, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "10b25748-6d7c-46ab-bd2c-9b6126a1d7d1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetForm(HPRINTER hPrinter, string pFormName, uint Level, IntPtr pForm, uint cbBuf, out uint pcbNeeded);

	/// <summary>The <c>GetForm</c> function retrieves information about a specified form.</summary>
	/// <typeparam name="T">The type of the structure to get. This must be either <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c>.</typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pFormName">
	/// A pointer to a null-terminated string that specifies the name of the form. To get the names of the forms supported by the
	/// printer, call the <c>EnumForms</c> function.
	/// </param>
	/// <returns>The initialized <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c> structure.</returns>
	/// <exception cref="ArgumentException"></exception>
	/// <remarks>
	/// If the caller is remote, and the Level is 2, the <c>StringType</c> value of the returned <c>FORM_INFO_2</c> will always be STRING_LANGPAIR.
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "10b25748-6d7c-46ab-bd2c-9b6126a1d7d1")]
	public static T GetForm<T>(HPRINTER hPrinter, string pFormName) where T : struct
	{
		if (!TryGetLevel<T>("FORM_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(GetForm)} cannot process a structure of type {typeof(T).Name}.");
		if (!GetForm(hPrinter, pFormName, lvl, default, 0, out var sz))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using var mem = new SafeCoTaskMemHandle(sz);
		if (!GetForm(hPrinter, pFormName, lvl, mem, mem.Size, out sz))
			Win32Error.ThrowLastError();
		return mem.ToStructure<T>();
	}

	/// <summary>The <c>GetJob</c> function retrieves information about a specified print job.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the print-job data is retrieved. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="JobId">
	/// Identifies the print job for which to retrieve data. Use the <c>AddJob</c> function or <c>StartDoc</c> function to get a print
	/// job identifier.
	/// </param>
	/// <param name="Level">
	/// The type of information returned in the pJob buffer. If Level is 1, pJob receives a <c>JOB_INFO_1</c> structure. If Level is 2,
	/// pJob receives a <c>JOB_INFO_2</c> structure.
	/// </param>
	/// <param name="pJob">
	/// <para>
	/// A pointer to a buffer that receives a <c>JOB_INFO_1</c> or a <c>JOB_INFO_2</c> structure containing information about the job.
	/// The buffer must be large enough to store the strings pointed to by the structure members.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>GetJob</c> with cbBuf set to zero. <c>GetJob</c> fails, <c>GetLastError</c>
	/// returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter returns the size, in bytes, of the buffer required to hold the
	/// array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the array.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a value that specifies the number of bytes copied if the function succeeds or the number of bytes required if cbBuf
	/// is too small.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getjob BOOL GetJob( _In_ HANDLE hPrinter, _In_ DWORD JobId, _In_ DWORD
	// Level, _Out_ LPBYTE pJob, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "57e59f84-d2a0-4722-b0fc-6673f7bb5c57")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetJob(HPRINTER hPrinter, uint JobId, uint Level, IntPtr pJob, uint cbBuf, out uint pcbNeeded);

	/// <summary>The <c>GetJob</c> function retrieves information about a specified print job.</summary>
	/// <typeparam name="T">The type of the structure to get. This must be either <c>JOB_INFO_1</c> or a <c>JOB_INFO_2</c>.</typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer for which the print-job data is retrieved. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="JobId">
	/// Identifies the print job for which to retrieve data. Use the <c>AddJob</c> function or <c>StartDoc</c> function to get a print
	/// job identifier.
	/// </param>
	/// <returns>A <c>JOB_INFO_1</c> or a <c>JOB_INFO_2</c> structure containing information about the job as specified by <typeparamref name="T"/>.</returns>
	/// <exception cref="ArgumentException"></exception>
	[PInvokeData("winspool.h", MSDNShortId = "57e59f84-d2a0-4722-b0fc-6673f7bb5c57")]
	public static T GetJob<T>(HPRINTER hPrinter, uint JobId) where T : struct
	{
		if (!TryGetLevel<T>("JOB_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(GetJob)} cannot process a structure of type {typeof(T).Name}.");
		if (!GetJob(hPrinter, JobId, lvl, default, 0, out var sz))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using var mem = new SafeCoTaskMemHandle(sz);
		if (!GetJob(hPrinter, JobId, lvl, mem, mem.Size, out sz))
			Win32Error.ThrowLastError();
		return mem.ToStructure<T>();
	}

	/// <summary>The <c>GetPrinter</c> function retrieves information about a specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function retrieves information. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <param name="Level">
	/// <para>The level or type of structure that the function stores into the buffer pointed to by pPrinter.</para>
	/// <para>This value can be 1, 2, 3, 4, 5, 6, 7, 8 or 9.</para>
	/// </param>
	/// <param name="pPrinter">
	/// <para>
	/// A pointer to a buffer that receives a structure containing information about the specified printer. The buffer must be large
	/// enough to receive the structure and any strings or other data to which the structure members point. If the buffer is too small,
	/// the pcbNeeded parameter returns the required buffer size.
	/// </para>
	/// <para>The type of structure is determined by the value of Level.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Level</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>A PRINTER_INFO_1 structure containing general printer information.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>A PRINTER_INFO_2 structure containing detailed information about the printer.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>A PRINTER_INFO_3 structure containing the printer's security information.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>
	/// A PRINTER_INFO_4 structure containing minimal printer information, including the name of the printer, the name of the server,
	/// and whether the printer is remote or local.
	/// </term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>A PRINTER_INFO_5 structure containing printer information such as printer attributes and time-out settings.</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>A PRINTER_INFO_6 structure specifying the status value of a printer.</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>A PRINTER_INFO_7 structure that indicates whether the printer is published in the directory service.</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>A PRINTER_INFO_8 structure specifying the global default printer settings.</term>
	/// </item>
	/// <item>
	/// <term>9</term>
	/// <term>A PRINTER_INFO_9 structure specifying the per-user default printer settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the buffer pointed to by pPrinter.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that the function sets to the size, in bytes, of the printer information. If cbBuf is smaller than this
	/// value, <c>GetPrinter</c> fails, and the value represents the required buffer size. If cbBuf is equal to or greater than this
	/// value, <c>GetPrinter</c> succeeds, and the value represents the number of bytes stored in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>pDevMode</c> member in the <c>PRINTER_INFO_2</c>, <c>PRINTER_INFO_8</c>, and <c>PRINTER_INFO_9</c> structures can be
	/// <c>NULL</c>. When this happens, the printer is unusable until the driver is reinstalled successfully.
	/// </para>
	/// <para>
	/// For the <c>PRINTER_INFO_2</c> and <c>PRINTER_INFO_3</c> structures that contain a pointer to a security descriptor, the function
	/// retrieves only those components of the security descriptor that the caller has permission to read. To retrieve particular
	/// security descriptor components, you must specify the necessary access rights when you call the <c>OpenPrinter</c> function to
	/// retrieve a handle to the printer. The following table shows the access rights required to read the various security descriptor components.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Access Right</term>
	/// <term>Security Descriptor Component</term>
	/// </listheader>
	/// <item>
	/// <term>READ_CONTROL</term>
	/// <term>Owner Primary group Discretionary access-control list (DACL)</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SYSTEM_SECURITY</term>
	/// <term>System access-control list (SACL)</term>
	/// </item>
	/// </list>
	/// <para>
	/// If you specify level 7, the <c>dwAction</c> member of <c>PRINTER_INFO_7</c> returns one of the following values to indicate
	/// whether the printer is published in the directory service.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwAction value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DSPRINT_PUBLISH</term>
	/// <term>
	/// The printer is published. The pszObjectGUID member contains the GUID of the directory services print queue object associated
	/// with the printer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_UNPUBLISH</term>
	/// <term>The printer is not published.</term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_PENDING</term>
	/// <term>
	/// Indicates that the system is attempting to complete a publish or unpublish operation. If a SetPrinter call fails to publish or
	/// unpublish a printer, the system makes further attempts to complete the operation in the background.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Starting with Windows Vista, the printer data returned by <c>GetPrinter</c> is retrieved from a local cache when hPrinter refers
	/// to a printer hosted by a print server and there is at least one open connection to the print server. In all other
	/// configurations, the printer data is queried from the print server.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprinter BOOL GetPrinter( _In_ HANDLE hPrinter, _In_ DWORD Level,
	// _Out_ LPBYTE pPrinter, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "f162edbb-83ee-40c3-8710-9c867301d652")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetPrinter(HPRINTER hPrinter, uint Level, IntPtr pPrinter, uint cbBuf, out uint pcbNeeded);

	/// <summary>The <c>GetPrinter</c> function retrieves information about a specified printer.</summary>
	/// <typeparam name="T">
	/// The type of the structure to get. This must be either <c>PRINTER_INFO_1</c>, <c>PRINTER_INFO_2</c>, <c>PRINTER_INFO_3</c>,
	/// <c>PRINTER_INFO_4</c>, <c>PRINTER_INFO_5</c>, <c>PRINTER_INFO_6</c>, <c>PRINTER_INFO_7</c>, <c>PRINTER_INFO_8</c>, or <c>JOB_INFO_9</c>.
	/// </typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer for which the function retrieves information. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <returns>
	/// A <c>PRINTER_INFO_1</c>, <c>PRINTER_INFO_2</c>, <c>PRINTER_INFO_3</c>, <c>PRINTER_INFO_4</c>, <c>PRINTER_INFO_5</c>,
	/// <c>PRINTER_INFO_6</c>, <c>PRINTER_INFO_7</c>, <c>PRINTER_INFO_8</c>, or <c>JOB_INFO_9</c> structure containing information about
	/// the printer as specified by <typeparamref name="T"/>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>pDevMode</c> member in the <c>PRINTER_INFO_2</c>, <c>PRINTER_INFO_8</c>, and <c>PRINTER_INFO_9</c> structures can be
	/// <c>NULL</c>. When this happens, the printer is unusable until the driver is reinstalled successfully.
	/// </para>
	/// <para>
	/// For the <c>PRINTER_INFO_2</c> and <c>PRINTER_INFO_3</c> structures that contain a pointer to a security descriptor, the function
	/// retrieves only those components of the security descriptor that the caller has permission to read. To retrieve particular
	/// security descriptor components, you must specify the necessary access rights when you call the <c>OpenPrinter</c> function to
	/// retrieve a handle to the printer. The following table shows the access rights required to read the various security descriptor components.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Access Right</term>
	/// <term>Security Descriptor Component</term>
	/// </listheader>
	/// <item>
	/// <term>READ_CONTROL</term>
	/// <term>Owner Primary group Discretionary access-control list (DACL)</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SYSTEM_SECURITY</term>
	/// <term>System access-control list (SACL)</term>
	/// </item>
	/// </list>
	/// <para>
	/// If you specify level 7, the <c>dwAction</c> member of <c>PRINTER_INFO_7</c> returns one of the following values to indicate
	/// whether the printer is published in the directory service.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwAction value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DSPRINT_PUBLISH</term>
	/// <term>
	/// The printer is published. The pszObjectGUID member contains the GUID of the directory services print queue object associated
	/// with the printer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_UNPUBLISH</term>
	/// <term>The printer is not published.</term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_PENDING</term>
	/// <term>
	/// Indicates that the system is attempting to complete a publish or unpublish operation. If a SetPrinter call fails to publish or
	/// unpublish a printer, the system makes further attempts to complete the operation in the background.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Starting with Windows Vista, the printer data returned by <c>GetPrinter</c> is retrieved from a local cache when hPrinter refers
	/// to a printer hosted by a print server and there is at least one open connection to the print server. In all other
	/// configurations, the printer data is queried from the print server.
	/// </para>
	/// </remarks>
	public static T GetPrinter<T>(HPRINTER hPrinter) where T : struct
	{
		if (!TryGetLevel<T>("PRINTER_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(GetPrinter)} cannot process a structure of type {typeof(T).Name}.");
		if (!GetPrinter(hPrinter, lvl, default, 0, out var sz))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using var mem = new SafeCoTaskMemHandle(sz);
		if (!GetPrinter(hPrinter, lvl, mem, mem.Size, out sz))
			Win32Error.ThrowLastError();
		return mem.ToStructure<T>();
	}

	/// <summary>
	/// <para>The <c>GetPrinterData</c> function retrieves configuration data for the specified printer or print server.</para>
	/// <para>
	/// In Windows 2000 and later versions of Windows, calling <c>GetPrinterData</c> is equivalent to calling <c>GetPrinterDataEx</c>
	/// with the pKeyName parameter set to "PrinterDriverData".
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function retrieves configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to retrieve.</para>
	/// <para>For printers, this string is the name of a registry value under the printer's "PrinterDriverData" key in the registry.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="pType">
	/// A pointer to a variable that receives a value that indicates the type of data retrieved in pData. The function returns the type
	/// specified in the <c>SetPrinterData</c> or <c>SetPrinterDataEx</c> call that stored the data. Set this parameter to <c>NULL</c>
	/// if you don't need the data type.
	/// </param>
	/// <param name="pData">A pointer to a buffer that receives the configuration data.</param>
	/// <param name="nSize">The size, in bytes, of the buffer that pData points to.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the size, in bytes, of the configuration data. If the buffer size specified by nSize is
	/// too small, the function returns <c>ERROR_MORE_DATA</c>, and pcbNeeded indicates the required buffer size.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. If the function fails, the return value is an error value.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetPrinterData</c> retrieves printer configuration data that was set by the <c>SetPrinterDataEx</c> or <c>SetPrinterData</c> function.
	/// </para>
	/// <para>
	/// <c>GetPrinterData</c> might trigger a Windows call to <c>GetPrinterDataFromPort</c>, which might write to the registry. If it
	/// does, side effects can occur, such as triggering an update or upgrade printer event ID 20 in the client, if the printer is
	/// shared in a network.
	/// </para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_ARCHITECTURE</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DNS_MACHINE_NAME</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT</term>
	/// <term>On successful return, pData contains 0x0001 if the machine is on a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT_FOR_USER</term>
	/// <term>On successful return, pData contains 0x0001 if the user is logged onto a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MAJOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MINOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP_TO_COMPUTER</term>
	/// <term>
	/// On successful return, pData contains 1 if job notifications should be sent to the client computer, or 0 if job notifications are
	/// to be sent to the user. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSION</term>
	/// <term>Windows XP and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSIONEX</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_REMOTE_FAX</term>
	/// <term>On successful return, pData contains 0x0001 if the FAX service supports remote clients, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>The following values of pValueName indicate the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegQueryValueEx</c> function to query these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// The following values configure client-side rendering of a print jobs and can be read if you set the following values in pValueName.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, will cause the print jobs to be rendered on the client. If a
	/// print job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server,
	/// it will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprinterdata DWORD GetPrinterData( _In_ HANDLE hPrinter, _In_ LPTSTR
	// pValueName, _Out_ LPDWORD pType, _Out_ LPBYTE pData, _In_ DWORD nSize, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "b5a44b27-a4aa-4e58-9a64-05be87d12ab5")]
	public static extern Win32Error GetPrinterData(HPRINTER hPrinter, string pValueName, out REG_VALUE_TYPE pType, IntPtr pData, uint nSize, out uint pcbNeeded);

	/// <summary>
	/// <para>The <c>GetPrinterData</c> function retrieves configuration data for the specified printer or print server.</para>
	/// <para>
	/// In Windows 2000 and later versions of Windows, calling <c>GetPrinterData</c> is equivalent to calling <c>GetPrinterDataEx</c>
	/// with the pKeyName parameter set to "PrinterDriverData".
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function retrieves configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to retrieve.</para>
	/// <para>For printers, this string is the name of a registry value under the printer's "PrinterDriverData" key in the registry.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <returns>THe requested configuration data.</returns>
	/// <remarks>
	/// <para>
	/// <c>GetPrinterData</c> retrieves printer configuration data that was set by the <c>SetPrinterDataEx</c> or <c>SetPrinterData</c> function.
	/// </para>
	/// <para>
	/// <c>GetPrinterData</c> might trigger a Windows call to <c>GetPrinterDataFromPort</c>, which might write to the registry. If it
	/// does, side effects can occur, such as triggering an update or upgrade printer event ID 20 in the client, if the printer is
	/// shared in a network.
	/// </para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_ARCHITECTURE</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DNS_MACHINE_NAME</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT</term>
	/// <term>On successful return, pData contains 0x0001 if the machine is on a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT_FOR_USER</term>
	/// <term>On successful return, pData contains 0x0001 if the user is logged onto a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MAJOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MINOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP_TO_COMPUTER</term>
	/// <term>
	/// On successful return, pData contains 1 if job notifications should be sent to the client computer, or 0 if job notifications are
	/// to be sent to the user. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSION</term>
	/// <term>Windows XP and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSIONEX</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_REMOTE_FAX</term>
	/// <term>On successful return, pData contains 0x0001 if the FAX service supports remote clients, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>The following values of pValueName indicate the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegQueryValueEx</c> function to query these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// The following values configure client-side rendering of a print jobs and can be read if you set the following values in pValueName.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, will cause the print jobs to be rendered on the client. If a
	/// print job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server,
	/// it will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "b5a44b27-a4aa-4e58-9a64-05be87d12ab5")]
	public static object GetPrinterData(HPRINTER hPrinter, string pValueName)
	{
		GetPrinterData(hPrinter, pValueName, out _, default, 0, out var sz).ThrowUnless(Win32Error.ERROR_MORE_DATA);
		using var mem = new SafeCoTaskMemHandle(sz);
		GetPrinterData(hPrinter, pValueName, out var type, mem, mem.Size, out sz).ThrowIfFailed();
		return type.GetValue(mem, mem.Size);
	}

	/// <summary>
	/// The <c>GetPrinterDataEx</c> function retrieves configuration data for the specified printer or print server.
	/// <c>GetPrinterDataEx</c> can retrieve values that the <c>SetPrinterData</c> function stored. In addition, <c>GetPrinterDataEx</c>
	/// can retrieve values that the <c>SetPrinterDataEx</c> function stored under a specified key.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function retrieves configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the value to be retrieved. Use the backslash ( \ )
	/// character as a delimiter to specify a path that has one or more subkeys.
	/// </para>
	/// <para>If hPrinter is a handle to a printer and pKeyName is <c>NULL</c> or an empty string, <c>GetPrinterDataEx</c> returns <c>ERROR_INVALID_PARAMETER</c>.</para>
	/// <para>If hPrinter is a handle to a print server, pKeyName is ignored.</para>
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to retrieve.</para>
	/// <para>For printers, this string specifies the name of a value under the pKeyName key.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="pType">
	/// A pointer to a variable that receives the type of data stored in the value. The function returns the type specified in the
	/// <c>SetPrinterDataEx</c> call when the data was stored. This parameter can be <c>NULL</c> if you don't need the information.
	/// <c>GetPrinterDataEx</c> passes pType on as the lpdwType parameter of a <c>RegQueryValueEx</c> function call.
	/// </param>
	/// <param name="pData">A pointer to a buffer that receives the configuration data.</param>
	/// <param name="nSize">The size, in bytes, of the buffer pointed to by pData.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the size, in bytes, of the configuration data. If the buffer size specified by nSize is
	/// too small, the function returns <c>ERROR_MORE_DATA</c>, and pcbNeeded indicates the required buffer size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is an error value.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetPrinterDataEx</c> retrieves printer-configuration data that was set by the <c>SetPrinterDataEx</c> and
	/// <c>SetPrinterData</c> functions.
	/// </para>
	/// <para>
	/// Calling <c>GetPrinterDataEx</c> with the pKeyName parameter set to "PrinterDriverData" is equivalent to calling the
	/// <c>GetPrinterData</c> function.
	/// </para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_ARCHITECTURE</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DNS_MACHINE_NAME</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT</term>
	/// <term>On successful return, pData contains 0x0001 if the machine is on a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT_FOR_USER</term>
	/// <term>On successful return, pData contains 0x0001 if the user is logged onto a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MAJOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MINOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP_TO_COMPUTER</term>
	/// <term>
	/// On successful return, pData contains 1 if job notifications should be sent to the client computer, or 0 if job notifications are
	/// to be sent to the user. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSION</term>
	/// <term>Windows XP and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSIONEX</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_REMOTE_FAX</term>
	/// <term>On successful return, pData contains 0x0001 if the FAX service supports remote clients, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>The following values of pValueName indicate the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegQueryValueEx</c> function to query these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If pKeyName is one of the predefined Directory Service (DS) keys (see <c>SetPrinter</c>) and pValueName contains a comma (','),
	/// then the portion of pValueName before the comma is the value name and the portion of pValueName to the right of the comma is the
	/// DS Property OID. A subkey called OID is created and a new value that consists of the value name and OID is entered under the OID
	/// key. <c>SetPrinterDataEx</c> also adds the value name and data under the DS key.
	/// </para>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// The configuration of client-side rendering for a printer can be read by setting pKeyName to "PrinterDriverData" and pValueName
	/// to the setting value in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, will cause the print jobs to be rendered on the client. If a
	/// print job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server,
	/// it will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprinterdataex DWORD GetPrinterDataEx( _In_ HANDLE hPrinter, _In_
	// LPCTSTR pKeyName, _In_ LPCTSTR pValueName, _Out_ LPDWORD pType, _Out_ LPBYTE pData, _In_ DWORD nSize, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "5d9183a7-97cc-46de-848e-e37ce51396eb")]
	public static extern Win32Error GetPrinterDataEx(HPRINTER hPrinter, string pKeyName, string pValueName, out REG_VALUE_TYPE pType,
		IntPtr pData, uint nSize, out uint pcbNeeded);

	/// <summary>
	/// The <c>GetPrinterDataEx</c> function retrieves configuration data for the specified printer or print server.
	/// <c>GetPrinterDataEx</c> can retrieve values that the <c>SetPrinterData</c> function stored. In addition, <c>GetPrinterDataEx</c>
	/// can retrieve values that the <c>SetPrinterDataEx</c> function stored under a specified key.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function retrieves configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the value to be retrieved. Use the backslash ( \ )
	/// character as a delimiter to specify a path that has one or more subkeys.
	/// </para>
	/// <para>If hPrinter is a handle to a printer and pKeyName is <c>NULL</c> or an empty string, <c>GetPrinterDataEx</c> returns <c>ERROR_INVALID_PARAMETER</c>.</para>
	/// <para>If hPrinter is a handle to a print server, pKeyName is ignored.</para>
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to retrieve.</para>
	/// <para>For printers, this string specifies the name of a value under the pKeyName key.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <returns>The requested valued.</returns>
	/// <remarks>
	/// <para>
	/// <c>GetPrinterDataEx</c> retrieves printer-configuration data that was set by the <c>SetPrinterDataEx</c> and
	/// <c>SetPrinterData</c> functions.
	/// </para>
	/// <para>
	/// Calling <c>GetPrinterDataEx</c> with the pKeyName parameter set to "PrinterDriverData" is equivalent to calling the
	/// <c>GetPrinterData</c> function.
	/// </para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_ARCHITECTURE</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DNS_MACHINE_NAME</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT</term>
	/// <term>On successful return, pData contains 0x0001 if the machine is on a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_DS_PRESENT_FOR_USER</term>
	/// <term>On successful return, pData contains 0x0001 if the user is logged onto a DS domain, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MAJOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_MINOR_VERSION</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP_TO_COMPUTER</term>
	/// <term>
	/// On successful return, pData contains 1 if job notifications should be sent to the client computer, or 0 if job notifications are
	/// to be sent to the user. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSION</term>
	/// <term>Windows XP and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_OS_VERSIONEX</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_REMOTE_FAX</term>
	/// <term>On successful return, pData contains 0x0001 if the FAX service supports remote clients, 0 otherwise.</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>The following values of pValueName indicate the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegQueryValueEx</c> function to query these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If pKeyName is one of the predefined Directory Service (DS) keys (see <c>SetPrinter</c>) and pValueName contains a comma (','),
	/// then the portion of pValueName before the comma is the value name and the portion of pValueName to the right of the comma is the
	/// DS Property OID. A subkey called OID is created and a new value that consists of the value name and OID is entered under the OID
	/// key. <c>SetPrinterDataEx</c> also adds the value name and data under the DS key.
	/// </para>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// The configuration of client-side rendering for a printer can be read by setting pKeyName to "PrinterDriverData" and pValueName
	/// to the setting value in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, will cause the print jobs to be rendered on the client. If a
	/// print job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server,
	/// it will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "5d9183a7-97cc-46de-848e-e37ce51396eb")]
	public static object GetPrinterDataEx(HPRINTER hPrinter, string pKeyName, string pValueName)
	{
		GetPrinterDataEx(hPrinter, pKeyName, pValueName, out _, default, 0, out var sz).ThrowUnless(Win32Error.ERROR_MORE_DATA);
		using var mem = new SafeCoTaskMemHandle(sz);
		GetPrinterDataEx(hPrinter, pKeyName, pValueName, out var type, mem, mem.Size, out sz).ThrowIfFailed();
		return type.GetValue(mem, mem.Size);
	}

	/// <summary>The <c>GetPrintExecutionData</c> retrieves the current print context.</summary>
	/// <param name="pData">A pointer to a variable that receives the address of the <c>PRINT_EXECUTION_DATA</c> structure.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the function succeeds; otherwise <c>FALSE</c>. If the return value is <c>FALSE</c>, call
	/// <c>GetLastError</c> to get the error status.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Printer drivers should call <c>GetProcAddress</c> on the winspool.drv module to get the address of the
	/// <c>GetPrintExecutionData</c> function because <c>GetPrintExecutionData</c> is not supported on Windows Vista or earlier versions
	/// of Windows.
	/// </para>
	/// <para><c>GetPrintExecutionData</c> only fails if the value of pData is <c>NULL</c>.</para>
	/// <para>
	/// The value of the <c>clientAppPID</c> member of <c>PRINT_EXECUTION_DATA</c> is only meaningful if the value of <c>context</c> is
	/// <c>PRINT_EXECUTION_CONTEXT_WOW64</c>. If the value of <c>context</c> is not <c>PRINT_EXECUTION_CONTEXT_WOW64</c>, the value of
	/// <c>clientAppPID</c> is 0.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprintexecutiondata BOOL WINAPI GetPrintExecutionData( _Out_
	// PRINT_EXECUTION_DATA *pData );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "bb9506aa-a0da-46bc-a86a-84a79587cd50")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetPrintExecutionData(out PRINT_EXECUTION_DATA pData);

	/// <summary>
	/// The <c>GetSpoolFileHandle</c> function retrieves a handle for the spool file associated with the job currently submitted by the application.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer to which the job was submitted. This should be the same handle that was used to submit the job. (Use the
	/// <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.)
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the spool file.</para>
	/// <para>If the function fails, it returns <c>INVALID_HANDLE_VALUE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// With the handle to the spool file, your application can write to the spool file with calls to <c>WriteFile</c> followed by <c>CommitSpoolData</c>.
	/// </para>
	/// <para>
	/// Your application must not call <c>ClosePrinter</c> on hPrinter until after it has accessed the spool file for the last time.
	/// Then it should call <c>CloseSpoolFileHandle</c> followed by <c>ClosePrinter</c>. Attempts to access the spool file handle after
	/// the original hPrinter has been closed will fail even if the file handle itself has not been closed. <c>CloseSpoolFileHandle</c>
	/// will itself fail if <c>ClosePrinter</c> is called first.
	/// </para>
	/// <para>This function will fail if it is called before the print job has finished spooling.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getspoolfilehandle HANDLE GetSpoolFileHandle( _In_ HANDLE hPrinter );
	[PInvokeData("winspool.h", MSDNShortId = "df6f28b3-66a6-4fb7-bdde-40cd7d934c5f")]
	public static SafeHSPOOLFILE GetSpoolFileHandle(HPRINTER hPrinter) => new SafeHSPOOLFILE(hPrinter, InternalGetSpoolFileHandle(hPrinter), true);

	/// <summary>The <c>IsValidDevmode</c> function verifies that the contents of a DEVMODE structure are valid.</summary>
	/// <param name="pDevmode">A pointer to the <c>DEVMODE</c> to validate.</param>
	/// <param name="DevmodeSize">The size in bytes of the input byte buffer.</param>
	/// <returns>
	/// <para>
	/// <c>TRUE</c>, if the <c>DEVMODE</c> is structurally valid. If minor errors are found the function will fix them and return <c>TRUE</c>.
	/// </para>
	/// <para>
	/// <c>FALSE</c>, if the <c>DEVMODE</c> has one or more significant structural problems. For example, its <c>dmSize</c> member is
	/// misaligned or specifies a buffer that is too small. Also, <c>FALSE</c> if <c>pDevmode</c> is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>No private printer driver fields of the <c>DEVMODE</c> are checked, only the public fields.</para>
	/// <para>
	/// Callers should use <c>dmSize</c>+ <c>dmDriverExtra</c> for <c>DevmodeSize</c> only if they can guarantee that the input buffer
	/// size is at least that big. Since the <c>DEVMODE</c> is generally untrusted data, the values that are in the input buffer at the
	/// <c>dmSize</c> and <c>dmDriverExtra</c> offsets are also untrusted.
	/// </para>
	/// <para>This function is executable in Least-Privileged User Account (LUA) context.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/isvaliddevmode BOOL IsValidDevmode( _In_ PDEVMODE pDevmode, size_t
	// DevmodeSize );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "8b4e32cc-5eeb-4a0d-a1b7-f6edb99ed8d8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsValidDevmode(in DEVMODE pDevmode, SizeT DevmodeSize);

	/// <summary>
	/// The <c>OpenPrinter</c> function retrieves a handle to the specified printer or print server or other types of handles in the
	/// print subsystem.
	/// </summary>
	/// <param name="pPrinterName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the name of the printer or print server, the printer object, the
	/// XcvMonitor, or the XcvPort.
	/// </para>
	/// <para>
	/// For a printer object use: PrinterName, Job xxxx. For an XcvMonitor, use: ServerName, XcvMonitor MonitorName. For an XcvPort,
	/// use: ServerName, XcvPort PortName.
	/// </para>
	/// <para>If <c>NULL</c>, it indicates the local printer server.</para>
	/// </param>
	/// <param name="phPrinter">
	/// <para>A pointer to a variable that receives a handle (not thread safe) to the open printer or print server object.</para>
	/// <para>
	/// The phPrinter parameter can return an Xcv handle for use with the XcvData function. For more information about XcvData, see the DDK.
	/// </para>
	/// </param>
	/// <param name="pDefault">A pointer to a <c>PRINTER_DEFAULTS</c> structure. This value can be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>Do not call this method in <c>DllMain</c>.</para>
	/// <para>
	/// The handle pointed to by phPrinter is not thread safe. If callers need to use it concurrently on multiple threads, they must
	/// provide custom synchronization access to the printer handle using the Synchronization Functions. To avoid writing custom code
	/// the application can open a printer handle on each thread, as needed.
	/// </para>
	/// <para>
	/// The pDefault parameter enables you to specify the data type and device mode values that are used for printing documents
	/// submitted by the <c>StartDocPrinter</c> function. However, you can override these values by using the <c>SetJob</c> function
	/// after a document has been started.
	/// </para>
	/// <para>
	/// The <c>DEVMODE</c> settings defined in the <c>PRINTER_DEFAULTS</c> structure of the pDefault parameter are not used when the
	/// value of the pDatatype member of the <c>DOC_INFO_1</c> structure that was passed in the pDocInfo parameter of the
	/// <c>StartDocPrinter</c> call is "RAW". When a high-level document (such as an Adobe PDF or Microsoft Word file) or other printer
	/// data (such PCL, PS, or HPGL) is sent directly to a printer with pDatatype set to "RAW", the document must fully describe the
	/// <c>DEVMODE</c>-style print job settings in the language understood by the hardware.
	/// </para>
	/// <para>
	/// You can call the <c>OpenPrinter</c> function to open a handle to a print server or to determine the access rights that a client
	/// has to a print server. To do so, specify the name of the print server in the pPrinterName parameter, set the <c>pDatatype</c>
	/// and <c>pDevMode</c> members of the <c>PRINTER_DEFAULTS</c> structure to <c>NULL</c>, and set the <c>DesiredAccess</c> member to
	/// specify a server access mask value such as SERVER_ALL_ACCESS. When you finish with the handle, pass it to the
	/// <c>ClosePrinter</c> function to close it.
	/// </para>
	/// <para>
	/// Use the <c>DesiredAccess</c> member of the <c>PRINTER_DEFAULTS</c> structure to specify the access rights that you need to the
	/// printer. The access rights can be one of the following. (If pDefault is <c>NULL</c>, then the access rights are PRINTER_ACCESS_USE.)
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Desired Access value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_ACCESS_ADMINISTER</term>
	/// <term>To perform administrative tasks, such as those provided by SetPrinter.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ACCESS_USE</term>
	/// <term>To perform basic printing operations.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ALL_ACCESS</term>
	/// <term>To perform all administrative tasks and basic printing operations except for SYNCHRONIZE (see Standard Access Rights.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ACCESS_MANAGE_LIMITED</term>
	/// <term>
	/// To perform administrative tasks, such as those provided by SetPrinter and SetPrinterData. This value is available starting from
	/// Windows 8.1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>generic security values, such as WRITE_DAC</term>
	/// <term>To allow specific control access rights. See Standard Access Rights.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If a user does not have permission to open a specified printer or print server with the desired access, the <c>OpenPrinter</c>
	/// call will fail with a return value of zero and <c>GetLastError</c> will return the value ERROR_ACCESS_DENIED.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/openprinter BOOL OpenPrinter( _In_ LPTSTR pPrinterName, _Out_ LPHANDLE
	// phPrinter, _In_ LPPRINTER_DEFAULTS pDefault );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "96763220-d851-46f0-8be8-403f3356edb9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OpenPrinter(string pPrinterName, out SafeHPRINTER phPrinter,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRINTER_DEFAULTS_Marshaler))] PRINTER_DEFAULTS pDefault);

	/// <summary>
	/// Retrieves a handle to the specified printer, print server, or other types of handles in the print subsystem, while setting some
	/// of the printer options.
	/// </summary>
	/// <param name="pPrinterName">
	/// <para>
	/// A pointer to a constant null-terminated string that specifies the name of the printer or print server, the printer object, the
	/// XcvMonitor, or the XcvPort.
	/// </para>
	/// <para>
	/// For a printer object, use: PrinterName,Job xxxx. For an XcvMonitor, use: ServerName,XcvMonitor MonitorName. For an XcvPort, use:
	/// ServerName,XcvPort PortName.
	/// </para>
	/// <para><c>Windows Vista:</c> If <c>NULL</c>, it indicates the local print server.</para>
	/// </param>
	/// <param name="phPrinter">A pointer to a variable that receives a handle to the open printer or print server object.</param>
	/// <param name="pDefault">A pointer to a <c>PRINTER_DEFAULTS</c> structure. This value can be <c>NULL</c>.</param>
	/// <param name="pOptions">A pointer to a <c>PRINTER_OPTIONS</c> structure. This value can be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>Do not call this method in <c>DllMain</c>.</para>
	/// <para>The ANSI version of this function is not implemented and returns ERROR_NOT_SUPPORTED.</para>
	/// <para>
	/// The pDefault parameter enables you to specify the data type and device mode values that are used for printing documents
	/// submitted by the <c>StartDocPrinter</c> function. However, you can override these values by using the <c>SetJob</c> function
	/// after a document has been started.
	/// </para>
	/// <para>
	/// You can call the <c>OpenPrinter2</c> function to open a handle to a print server or to determine client access rights to a print
	/// server. To do this, specify the name of the print server in the pPrinterName parameter, set the <c>pDatatype</c> and
	/// <c>pDevMode</c> members of the <c>PRINTER_DEFAULTS</c> structure to <c>NULL</c>, and set the <c>DesiredAccess</c> member to
	/// specify a server access mask value such as SERVER_ALL_ACCESS. When you are finished with the handle, pass it to the
	/// <c>ClosePrinter</c> function to close it.
	/// </para>
	/// <para>
	/// Use the <c>DesiredAccess</c> member of the <c>PRINTER_DEFAULTS</c> structure to specify the necessary access rights. The access
	/// rights can be one of the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Desired Access value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_ACCESS_ADMINISTER</term>
	/// <term>To perform administrative tasks, such as those provided by SetPrinter.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ACCESS_USE</term>
	/// <term>To perform basic printing operations.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ALL_ACCESS</term>
	/// <term>To perform all administrative tasks and basic printing operations except SYNCHRONIZE. See Standard Access Rights.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_ACCESS_MANAGE_LIMITED</term>
	/// <term>
	/// To perform administrative tasks, such as those provided by SetPrinter and SetPrinterData. This value is available starting from
	/// Windows 8.1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>generic security values, such as WRITE_DAC</term>
	/// <term>To allow specific control access rights. See Standard Access Rights.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If a user does not have permission to open a specified printer or print server with the desired access, the <c>OpenPrinter2</c>
	/// call will fail, and <c>GetLastError</c> will return the value ERROR_ACCESS_DENIED.
	/// </para>
	/// <para>
	/// When pPrinterName is a local printer, then <c>OpenPrinter2</c> ignores all values of the <c>dwFlags</c> that the
	/// <c>PRINTER_OPTIONS</c> structure pointed to using pOptions, except PRINTER_OPTION_CLIENT_CHANGE. If the latter is passed, then
	/// <c>OpenPrinter2</c> will return ERROR_ACCESS_DENIED. Accordingly, when opening a local printer, <c>OpenPrinter2</c> provides no
	/// advantage over <c>OpenPrinter</c>.
	/// </para>
	/// <para>
	/// <c>Windows Vista:</c> The printer data returned by <c>OpenPrinter2</c> is retrieved from a local cache unless the
	/// <c>PRINTER_OPTION_NO_CACHE</c> flag is set in the <c>dwFlags</c> field of the <c>PRINTER_OPTIONS</c> structure referenced by pOptions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/openprinter2 BOOL OpenPrinter2( _In_ LPCTSTR pPrinterName, _Out_
	// LPHANDLE phPrinter, _In_ LPPRINTER_DEFAULTS pDefault, _In_ PPRINTER_OPTIONS pOptions );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "e2370ae4-4475-4ccc-a6f9-3d33d1370054")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OpenPrinter2(string pPrinterName, out SafeHPRINTER phPrinter,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRINTER_DEFAULTS_Marshaler))] PRINTER_DEFAULTS pDefault, in PRINTER_OPTIONS pOptions);

	/// <summary>The <c>PrinterProperties</c> function displays a printer-properties property sheet for the specified printer.</summary>
	/// <param name="hWnd">A handle to the parent window of the property sheet.</param>
	/// <param name="hPrinter">
	/// A handle to a printer object. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printerproperties BOOL PrinterProperties( _In_ HWND hWnd, _In_ HANDLE
	// hPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "1d4c961b-178b-47af-b983-5b7327919f93")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrinterProperties(HWND hWnd, HPRINTER hPrinter);

	/// <summary>The <c>ReadPrinter</c> function retrieves data from the specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer object for which to retrieve data. Use the <c>OpenPrinter</c> function to retrieve a printer object
	/// handle. Use the format: Printername, Job xxxx.
	/// </param>
	/// <param name="pBuf">A pointer to a buffer that receives the printer data.</param>
	/// <param name="cbBuf">The size, in bytes, of the buffer to which pBuf points.</param>
	/// <param name="pNoBytesRead">
	/// A pointer to a variable that receives the number of bytes of data copied into the array to which pBuf points.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks><c>ReadPrinter</c> returns an error if the device or the printer is not bidirectional.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/readprinter BOOL ReadPrinter( _In_ HANDLE hPrinter, _Out_ LPVOID pBuf,
	// _In_ DWORD cbBuf, _Out_ LPDWORD pNoBytesRead );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "d7c3f186-c53e-424b-89bf-6742babb998f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadPrinter(HPRINTER hPrinter, IntPtr pBuf, uint cbBuf, out uint pNoBytesRead);

	/// <summary>
	/// Reports to the Print Spooler service whether an XPS print job is in the spooling or the rendering phase and what part of the
	/// processing is currently underway.
	/// </summary>
	/// <param name="printerHandle">
	/// A printer handle for which the function is to retrieve information. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="jobId">
	/// Identifies the print job for which to retrieve data. Use the <c>AddJob</c> function or <c>StartDoc</c> function to get a print
	/// job identifier.
	/// </param>
	/// <param name="jobOperation">Specifies whether the job is in the spooling phase or the rendering phase.</param>
	/// <param name="jobProgress">
	/// Specifies what part of the processing is currently underway. This value refers to events in either the spooling or rendering
	/// phase depending on the value of jobOperation.
	/// </param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> will contain an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/reportjobprocessingprogress HRESULT ReportJobProcessingProgress( _In_
	// HANDLE printerHandle, _In_ ULONG jobId, EPrintXPSJobOperation jobOperation, EPrintXPSJobProgress jobProgress );
	[DllImport(Lib.Winspool, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "66f7483d-be98-410d-b0c7-430743397de2")]
	public static extern HRESULT ReportJobProcessingProgress(HPRINTER printerHandle, uint jobId, EPrintXPSJobOperation jobOperation, EPrintXPSJobProgress jobProgress);

	/// <summary>
	/// The <c>ResetPrinter</c> function specifies the data type and device mode values to be used for printing documents submitted by
	/// the <c>StartDocPrinter</c> function. These values can be overridden by using the <c>SetJob</c> function after document printing
	/// has started.
	/// </summary>
	/// <param name="hPrinter">
	/// Handle to the printer. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pDefault">
	/// <para>Pointer to a <c>PRINTER_DEFAULTS</c> structure.</para>
	/// <para>
	/// The <c>ResetPrinter</c> function ignores the <c>DesiredAccess</c> member of the <c>PRINTER_DEFAULTS</c> structure. Set that
	/// member to zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/resetprinter BOOL ResetPrinter( _In_ HANDLE hPrinter, _In_
	// LPPRINTER_DEFAULTS pDefault );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "9efc6629-dbb7-4320-90b9-07c66f0add47")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ResetPrinter(HPRINTER hPrinter, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRINTER_DEFAULTS_Marshaler))] PRINTER_DEFAULTS pDefault);

	/// <summary>The <c>ScheduleJob</c> function requests that the print spooler schedule a specified print job for printing.</summary>
	/// <param name="hPrinter">
	/// <para>
	/// A handle to the printer for the print job. This must be a local printer that is configured as a spooled printer. If hPrinter is
	/// a handle to a remote printer connection, or if the printer is configured for direct printing, the <c>ScheduleJob</c> function
	/// fails. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </para>
	/// <para>hPrinter must be the same printer handle specified in the call to <c>AddJob</c> that obtained the dwJobID print job identifier.</para>
	/// </param>
	/// <param name="dwJobID">The print job to be scheduled. You obtain this print job identifier by calling the <c>AddJob</c> function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You must successfully call the <c>AddJob</c> function before calling the <c>ScheduleJob</c> function. <c>AddJob</c> obtains the
	/// print job identifier that you pass to <c>ScheduleJob</c> as dwJobID. Both calls must use the same value for hPrinter.
	/// </para>
	/// <para>
	/// The <c>ScheduleJob</c> function checks for a valid spool file. If there is an invalid spool file, or if it is empty,
	/// <c>ScheduleJob</c> deletes both the spool file and the corresponding print job entry in the print spooler.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/schedulejob BOOL ScheduleJob( _In_ HANDLE hPrinter, _In_ DWORD dwJobID );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "a103a29c-be4d-491e-9b04-84571fe969a5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ScheduleJob(HPRINTER hPrinter, uint dwJobID);

	/// <summary>
	/// The <c>SetDefaultPrinter</c> function sets the printer name of the default printer for the current user on the local computer.
	/// </summary>
	/// <param name="pszPrinter">
	/// <para>
	/// A pointer to a null-terminated string containing the default printer name. For a remote printer connection, the name format is
	/// **\\ <c>server</c>\**printername. For a local printer, the name format is printername.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c> or an empty string, that is, "", <c>SetDefaultPrinter</c> will select a default printer from
	/// one of the installed printers. If a default printer already exists, calling <c>SetDefaultPrinter</c> with a <c>NULL</c> or an
	/// empty string in this parameter might change the default printer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// When using this method, you must specify a valid printer, driver, and port. If they are invalid, the APIs do not fail but the
	/// result is not defined. This could cause other programs to set the printer back to the previous valid printer. You can use
	/// <c>EnumPrinters</c> to retrieve the printer name, driver name, and port name of all available printers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setdefaultprinter BOOL SetDefaultPrinter( _In_ LPCTSTR pszPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "55eec548-577f-422b-80e3-8b23aa4d2159")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDefaultPrinter(string pszPrinter);

	/// <summary>The <c>SetForm</c> function sets the form information for the specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the form information is set. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="pFormName">
	/// A pointer to a null-terminated string that specifies the form name for which the form information is set.
	/// </param>
	/// <param name="Level">The version of the structure to which pForm points. This value must be 1 or 2.</param>
	/// <param name="pForm">A pointer to a <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetForm</c> can be called multiple times for an existing <c>FORM_INFO_2</c>, each call adding additional pairs of
	/// <c>pDisplayName</c> and <c>wLangId</c> values. All languages versions of the form will get the <c>Size</c> and
	/// <c>ImageableArea</c> values of the <c>FORM_INFO_2</c> in the most recent call to <c>SetForm</c>.
	/// </para>
	/// <para>If the caller is remote and the Level is 2, the <c>StringType</c> value of the <c>FORM_INFO_2</c> cannot be STRING_MUIDLL.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setform BOOL SetForm( _In_ HANDLE hPrinter, _In_ LPTSTR pFormName, _In_
	// DWORD Level, _In_ LPTSTR pForm );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "05d5d495-952c-4a1d-8694-1004d0c2bcf6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetForm(HPRINTER hPrinter, string pFormName, uint Level, IntPtr pForm);

	/// <summary>The <c>SetForm</c> function sets the form information for the specified printer.</summary>
	/// <typeparam name="T">The type of the value being set.</typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer for which the form information is set. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="pFormName">A pointer to a string that specifies the form name for which the form information is set.</param>
	/// <param name="pForm">A <c>FORM_INFO_1</c> or <c>FORM_INFO_2</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <exception cref="ArgumentException"></exception>
	/// <remarks>
	/// <para>
	/// <c>SetForm</c> can be called multiple times for an existing <c>FORM_INFO_2</c>, each call adding additional pairs of
	/// <c>pDisplayName</c> and <c>wLangId</c> values. All languages versions of the form will get the <c>Size</c> and
	/// <c>ImageableArea</c> values of the <c>FORM_INFO_2</c> in the most recent call to <c>SetForm</c>.
	/// </para>
	/// <para>If the caller is remote and the Level is 2, the <c>StringType</c> value of the <c>FORM_INFO_2</c> cannot be STRING_MUIDLL.</para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "05d5d495-952c-4a1d-8694-1004d0c2bcf6")]
	public static bool SetForm<T>(HPRINTER hPrinter, string pFormName, in T pForm) where T : struct
	{
		if (!TryGetLevel<T>("FORM_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(SetForm)} cannot process a structure of type {typeof(T).Name}.");
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pForm);
		return SetForm(hPrinter, pFormName, lvl, mem);
	}

	/// <summary>
	/// <para>
	/// The <c>SetJob</c> function pauses, resumes, cancels, or restarts a print job on a specified printer. You can also use the
	/// <c>SetJob</c> function to set print job parameters, such as the print job priority and the document name.
	/// </para>
	/// <para>
	/// You can use the <c>SetJob</c> function to give a command to a print job, or to set print job parameters, or to do both in the
	/// same call. The value of the Command parameter does not affect how the function uses the Level and pJob parameters. Also, you can
	/// use <c>SetJob</c> with <c>JOB_INFO_3</c> to link together a set of print jobs. See Remarks for more information.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer object of interest. Use the <c>OpenPrinter</c>, <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="JobId">
	/// <para>
	/// Identifier that specifies the print job. You obtain a print job identifier by calling the <c>AddJob</c> function or the
	/// <c>StartDoc</c> function.
	/// </para>
	/// <para>
	/// If the Level parameter is set to 3, the JobId parameter must match the <c>JobId</c> member of the <c>JOB_INFO_3</c> structure
	/// pointed to by pJob
	/// </para>
	/// </param>
	/// <param name="Level">
	/// <para>The type of job information structure pointed to by the pJob parameter.</para>
	/// <para>
	/// <c>All versions of Windows</c>: You can set the Level parameter to 0, 1, or 2. When you set Level to 0, pJob should be
	/// <c>NULL</c>. Use these values when you are not setting any print job parameters.
	/// </para>
	/// <para>You can also set the Level parameter to 3.</para>
	/// <para>Starting with <c>Windows Vista</c>: You can also set the Level parameter to 4.</para>
	/// </param>
	/// <param name="pJob">
	/// <para>A pointer to a structure that sets the print job parameters.</para>
	/// <para><c>All versions of Windows</c>: pJob can point to a <c>JOB_INFO_1</c> or <c>JOB_INFO_2</c> structure.</para>
	/// <para>
	/// pJob can also point to a <c>JOB_INFO_3</c> structure. You must have <c>JOB_ACCESS_ADMINISTER</c> access permission for the jobs
	/// specified by the <c>JobId</c> and <c>NextJobId</c> members of the <c>JOB_INFO_3</c> structure.
	/// </para>
	/// <para>Starting with <c>Windows Vista</c>: pJob can also point to a <c>JOB_INFO_4</c> structure.</para>
	/// <para>If the Level parameter is 0, pJob should be <c>NULL</c>.</para>
	/// </param>
	/// <param name="Command">
	/// <para>The print job operation to perform. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>JOB_CONTROL_CANCEL</term>
	/// <term>Do not use. To delete a print job, use JOB_CONTROL_DELETE.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_PAUSE</term>
	/// <term>Pause the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RESTART</term>
	/// <term>Restart the print job. A job can only be restarted if it was printing.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RESUME</term>
	/// <term>Resume a paused print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_DELETE</term>
	/// <term>Delete the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_SENT_TO_PRINTER</term>
	/// <term>Used by port monitors to end the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_LAST_PAGE_EJECTED</term>
	/// <term>Used by language monitors to end the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RETAIN</term>
	/// <term>Windows Vista and later: Keep the job in the queue after it prints.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RELEASE</term>
	/// <term>Windows Vista and later: Release the print job.</term>
	/// </item>
	/// </list>
	/// <para>
	/// You can use the same call to the <c>SetJob</c> function to set print job parameters and to give a command to a print job. Thus,
	/// Command does not need to be 0 if you are setting print job parameters, although it can be.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can use the <c>SetJob</c> function to set various print job parameters by supplying a pointer to a <c>JOB_INFO_1</c>,
	/// <c>JOB_INFO_2</c>, <c>JOB_INFO_3</c>, or <c>JOB_INFO_4</c> structure that contains the necessary data.
	/// </para>
	/// <para>
	/// To remove or delete all of the print jobs for a particular printer, call the <c>SetPrinter</c> function with its Command
	/// parameter set to <c>PRINTER_CONTROL_PURGE</c>.
	/// </para>
	/// <para>
	/// The following members of a <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_4</c> structure are ignored on a call to
	/// <c>SetJob</c>: <c>JobId</c>, <c>pPrinterName</c>, <c>pMachineName</c>, <c>pUserName</c>, <c>pDrivername</c>, <c>Size</c>,
	/// <c>Submitted</c>, <c>Time</c>, and <c>TotalPages</c>.
	/// </para>
	/// <para>
	/// You must have <c>PRINTER_ACCESS_ADMINISTER</c> access permission for a printer in order to change a print job's position in the
	/// print queue.
	/// </para>
	/// <para>
	/// If you do not want to set a print job's position in the print queue, you should set the <c>Position</c> member of the
	/// <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_4</c> structure to <c>JOB_POSITION_UNSPECIFIED</c>.
	/// </para>
	/// <para>
	/// Use the <c>SetJob</c> function with the <c>JOB_INFO_3</c> structure to link together a set of print jobs (also known as a
	/// chain). This is useful in situations where a single document consists of several parts that you want to render separately. To
	/// print jobs A, B, C, and D in order, call <c>SetJob</c> with <c>JOB_INFO_4</c> to link A to B, B to C, and C to D.
	/// </para>
	/// <para>If you link print jobs, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setjob BOOL SetJob( _In_ HANDLE hPrinter, _In_ DWORD JobId, _In_ DWORD
	// Level, _In_ LPBYTE pJob, _In_ DWORD Command );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "21947c69-c517-4962-8eb7-b45ed4211d9a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetJob(HPRINTER hPrinter, uint JobId, uint Level, IntPtr pJob, JOB_CONTROL Command = 0);

	/// <summary>
	/// <para>
	/// The <c>SetJob</c> function pauses, resumes, cancels, or restarts a print job on a specified printer. You can also use the
	/// <c>SetJob</c> function to set print job parameters, such as the print job priority and the document name.
	/// </para>
	/// <para>
	/// You can use the <c>SetJob</c> function to give a command to a print job.
	/// </para>
	/// </summary>
	/// <param name="hPrinter">A handle to the printer object of interest. Use the <c>OpenPrinter</c>, <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to
	/// retrieve a printer handle.</param>
	/// <param name="JobId">Identifier that specifies the print job. You obtain a print job identifier by calling the <c>AddJob</c> function or the
	/// <c>StartDoc</c> function.</param>
	/// <param name="Command"><para>The print job operation to perform. This parameter can be one of the following values.</para>
	/// <list type="table">
	///   <listheader>
	///     <term>Value</term>
	///     <term>Meaning</term>
	///   </listheader>
	///   <item>
	///     <term>JOB_CONTROL_CANCEL</term>
	///     <term>Do not use. To delete a print job, use JOB_CONTROL_DELETE.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_PAUSE</term>
	///     <term>Pause the print job.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_RESTART</term>
	///     <term>Restart the print job. A job can only be restarted if it was printing.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_RESUME</term>
	///     <term>Resume a paused print job.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_DELETE</term>
	///     <term>Delete the print job.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_SENT_TO_PRINTER</term>
	///     <term>Used by port monitors to end the print job.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_LAST_PAGE_EJECTED</term>
	///     <term>Used by language monitors to end the print job.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_RETAIN</term>
	///     <term>Windows Vista and later: Keep the job in the queue after it prints.</term>
	///   </item>
	///   <item>
	///     <term>JOB_CONTROL_RELEASE</term>
	///     <term>Windows Vista and later: Release the print job.</term>
	///   </item>
	/// </list></param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// To remove or delete all of the print jobs for a particular printer, call the <c>SetPrinter</c> function with its Command
	/// parameter set to <c>PRINTER_CONTROL_PURGE</c>.
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "21947c69-c517-4962-8eb7-b45ed4211d9a")]
	public static bool SetJob(HPRINTER hPrinter, uint JobId, JOB_CONTROL Command) =>
		SetJob(hPrinter, JobId, 0, default, Command);

	/// <summary>
	/// <para>
	/// The <c>SetJob</c> function pauses, resumes, cancels, or restarts a print job on a specified printer. You can also use the
	/// <c>SetJob</c> function to set print job parameters, such as the print job priority and the document name.
	/// </para>
	/// <para>
	/// You can use the <c>SetJob</c> function to give a command to a print job, or to set print job parameters, or to do both in the
	/// same call. The value of the Command parameter does not affect how the function uses the Level and pJob parameters. Also, you can
	/// use <c>SetJob</c> with <c>JOB_INFO_3</c> to link together a set of print jobs. See Remarks for more information.
	/// </para>
	/// </summary>
	/// <typeparam name="T">The type of the value being set.</typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer object of interest. Use the <c>OpenPrinter</c>, <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to
	/// retrieve a printer handle.
	/// </param>
	/// <param name="JobId">
	/// <para>
	/// Identifier that specifies the print job. You obtain a print job identifier by calling the <c>AddJob</c> function or the
	/// <c>StartDoc</c> function.
	/// </para>
	/// <para>
	/// If the Level parameter is set to 3, the JobId parameter must match the <c>JobId</c> member of the <c>JOB_INFO_3</c> structure
	/// pointed to by pJob
	/// </para>
	/// </param>
	/// <param name="pJob">
	/// <para>A pointer to a structure that sets the print job parameters.</para>
	/// <para><c>All versions of Windows</c>: pJob can point to a <c>JOB_INFO_1</c> or <c>JOB_INFO_2</c> structure.</para>
	/// <para>
	/// pJob can also point to a <c>JOB_INFO_3</c> structure. You must have <c>JOB_ACCESS_ADMINISTER</c> access permission for the jobs
	/// specified by the <c>JobId</c> and <c>NextJobId</c> members of the <c>JOB_INFO_3</c> structure.
	/// </para>
	/// <para>Starting with <c>Windows Vista</c>: pJob can also point to a <c>JOB_INFO_4</c> structure.</para>
	/// <para>If the Level parameter is 0, pJob should be <c>NULL</c>.</para>
	/// </param>
	/// <param name="Command">
	/// <para>The print job operation to perform. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>JOB_CONTROL_CANCEL</term>
	/// <term>Do not use. To delete a print job, use JOB_CONTROL_DELETE.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_PAUSE</term>
	/// <term>Pause the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RESTART</term>
	/// <term>Restart the print job. A job can only be restarted if it was printing.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RESUME</term>
	/// <term>Resume a paused print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_DELETE</term>
	/// <term>Delete the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_SENT_TO_PRINTER</term>
	/// <term>Used by port monitors to end the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_LAST_PAGE_EJECTED</term>
	/// <term>Used by language monitors to end the print job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RETAIN</term>
	/// <term>Windows Vista and later: Keep the job in the queue after it prints.</term>
	/// </item>
	/// <item>
	/// <term>JOB_CONTROL_RELEASE</term>
	/// <term>Windows Vista and later: Release the print job.</term>
	/// </item>
	/// </list>
	/// <para>
	/// You can use the same call to the <c>SetJob</c> function to set print job parameters and to give a command to a print job. Thus,
	/// Command does not need to be 0 if you are setting print job parameters, although it can be.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <exception cref="ArgumentException"></exception>
	/// <remarks>
	/// <para>
	/// You can use the <c>SetJob</c> function to set various print job parameters by supplying a pointer to a <c>JOB_INFO_1</c>,
	/// <c>JOB_INFO_2</c>, <c>JOB_INFO_3</c>, or <c>JOB_INFO_4</c> structure that contains the necessary data.
	/// </para>
	/// <para>
	/// To remove or delete all of the print jobs for a particular printer, call the <c>SetPrinter</c> function with its Command
	/// parameter set to <c>PRINTER_CONTROL_PURGE</c>.
	/// </para>
	/// <para>
	/// The following members of a <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_4</c> structure are ignored on a call to
	/// <c>SetJob</c>: <c>JobId</c>, <c>pPrinterName</c>, <c>pMachineName</c>, <c>pUserName</c>, <c>pDrivername</c>, <c>Size</c>,
	/// <c>Submitted</c>, <c>Time</c>, and <c>TotalPages</c>.
	/// </para>
	/// <para>
	/// You must have <c>PRINTER_ACCESS_ADMINISTER</c> access permission for a printer in order to change a print job's position in the
	/// print queue.
	/// </para>
	/// <para>
	/// If you do not want to set a print job's position in the print queue, you should set the <c>Position</c> member of the
	/// <c>JOB_INFO_1</c>, <c>JOB_INFO_2</c>, or <c>JOB_INFO_4</c> structure to <c>JOB_POSITION_UNSPECIFIED</c>.
	/// </para>
	/// <para>
	/// Use the <c>SetJob</c> function with the <c>JOB_INFO_3</c> structure to link together a set of print jobs (also known as a
	/// chain). This is useful in situations where a single document consists of several parts that you want to render separately. To
	/// print jobs A, B, C, and D in order, call <c>SetJob</c> with <c>JOB_INFO_4</c> to link A to B, B to C, and C to D.
	/// </para>
	/// <para>If you link print jobs, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "21947c69-c517-4962-8eb7-b45ed4211d9a")]
	public static bool SetJob<T>(HPRINTER hPrinter, uint JobId, in T pJob, JOB_CONTROL Command = 0) where T : struct
	{
		if (!TryGetLevel<T>("JOB_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(SetJob)} cannot process a structure of type {typeof(T).Name}.");
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pJob);
		return SetJob(hPrinter, JobId, lvl, mem, Command);
	}

	/// <summary>The <c>SetPort</c> function sets the status associated with a printer port.</summary>
	/// <param name="pName">
	/// Pointer to a zero-terminated string that specifies the name of the printer server to which the port is connected. Set this
	/// parameter to <c>NULL</c> if the port is on the local machine.
	/// </param>
	/// <param name="pPortName">Pointer to a zero-terminated string that specifies the name of the printer port.</param>
	/// <param name="dwLevel">
	/// <para>Specifies the type of structure pointed to by the pPortInfo parameter.</para>
	/// <para>This value must be 3, which corresponds to a <c>PORT_INFO_3</c> data structure.</para>
	/// </param>
	/// <param name="pPortInfo">Pointer to a <c>PORT_INFO_3</c> structure that contains the port status information to set.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller of the <c>SetPort</c> function must be executing as an Administrator. Additionally, if the caller is a Port Monitor
	/// or Language Monitor, it must call <c>RevertToSelf</c> to cease impersonation before it calls <c>SetPort</c>.
	/// </para>
	/// <para>All programs that call <c>SetPort</c> must have SERVER_ACCESS_ADMINISTER access to the server to which the port is connected.</para>
	/// <para>
	/// When you set a printer port status value with the severity value PORT_STATUS_TYPE_ERROR, the print spooler stops sending jobs to
	/// the port. The print spooler resumes sending jobs to the port when the port status is cleared by another call to <c>SetPort</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setport BOOL SetPort( _In_ LPTSTR pName, _In_ LPTSTR pPortName, _In_
	// DWORD dwLevel, _In_ LPBYTE pPortInfo );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "1b80ad93-aaa1-41ed-a668-a944fa62c3eb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetPort([Optional] string? pName, string pPortName, uint dwLevel, IntPtr pPortInfo);

	/// <summary>The <c>SetPort</c> function sets the status associated with a printer port.</summary>
	/// <param name="pName">
	/// A string that specifies the name of the printer server to which the port is connected. Set this parameter to
	/// <see langword="null"/> if the port is on the local machine.
	/// </param>
	/// <param name="pPortName">A string that specifies the name of the printer port.</param>
	/// <param name="status">The new port status value.</param>
	/// <param name="severity">The severity of the port status value.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller of the <c>SetPort</c> function must be executing as an Administrator. Additionally, if the caller is a Port Monitor
	/// or Language Monitor, it must call <c>RevertToSelf</c> to cease impersonation before it calls <c>SetPort</c>.
	/// </para>
	/// <para>All programs that call <c>SetPort</c> must have SERVER_ACCESS_ADMINISTER access to the server to which the port is connected.</para>
	/// <para>
	/// When you set a printer port status value with the severity value PORT_STATUS_TYPE_ERROR, the print spooler stops sending jobs to
	/// the port. The print spooler resumes sending jobs to the port when the port status is cleared by another call to <c>SetPort</c>.
	/// </para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "1b80ad93-aaa1-41ed-a668-a944fa62c3eb")]
	public static bool SetPort([Optional] string? pName, string pPortName, PORT_STATUS status, PORT_STATUS_TYPE severity)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(new PORT_INFO_3 { dwStatus = status, dwSeverity = severity });
		return SetPort(pName, pPortName, 3, mem);
	}

	/// <summary>The <c>SetPort</c> function sets the status associated with a printer port.</summary>
	/// <param name="pName">
	/// A string that specifies the name of the printer server to which the port is connected. Set this parameter to
	/// <see langword="null"/> if the port is on the local machine.
	/// </param>
	/// <param name="pPortName">A string that specifies the name of the printer port.</param>
	/// <param name="status">
	/// A new printer port status value string to set. Use this member if there is no suitable status value among those listed for <see cref="PORT_STATUS"/>.
	/// </param>
	/// <param name="severity">The severity of the port status value.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller of the <c>SetPort</c> function must be executing as an Administrator. Additionally, if the caller is a Port Monitor
	/// or Language Monitor, it must call <c>RevertToSelf</c> to cease impersonation before it calls <c>SetPort</c>.
	/// </para>
	/// <para>All programs that call <c>SetPort</c> must have SERVER_ACCESS_ADMINISTER access to the server to which the port is connected.</para>
	/// <para>
	/// When you set a printer port status value with the severity value PORT_STATUS_TYPE_ERROR, the print spooler stops sending jobs to
	/// the port. The print spooler resumes sending jobs to the port when the port status is cleared by another call to <c>SetPort</c>.
	/// </para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "1b80ad93-aaa1-41ed-a668-a944fa62c3eb")]
	public static bool SetPort([Optional] string? pName, string pPortName, string status, PORT_STATUS_TYPE severity)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(new PORT_INFO_3 { pszStatus = status, dwSeverity = severity });
		return SetPort(pName, pPortName, 3, mem);
	}

	/// <summary>
	/// The <c>SetPrinter</c> function sets the data for a specified printer or sets the state of the specified printer by pausing
	/// printing, resuming printing, or clearing all print jobs.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c>, <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="Level">
	/// <para>
	/// The type of data that the function stores into the buffer pointed to by pPrinter. If the Command parameter is not equal to zero,
	/// the Level parameter must be zero.
	/// </para>
	/// <para>This value can be 0, 2, 3, 4, 5, 6, 7, 8, or 9.</para>
	/// </param>
	/// <param name="pPrinter">
	/// <para>
	/// A pointer to a buffer containing data to set for the printer, or containing information for the command specified by the Command
	/// parameter. The type of data in the buffer is determined by the value of Level.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Level</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// If the Command parameter is PRINTER_CONTROL_SET_STATUS, pPrinter must contain a DWORD value that specifies the new printer
	/// status to set. For a list of the possible status values, see the Status member of the PRINTER_INFO_2 structure. Note that
	/// PRINTER_STATUS_PAUSED and PRINTER_STATUS_PENDING_DELETION are not valid status values to set. If Level is 0, but the Command
	/// parameter is not PRINTER_CONTROL_SET_STATUS, pPrinter must be NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>A PRINTER_INFO_2 structure containing detailed information about the printer.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>A PRINTER_INFO_3 structure containing the printer's security information.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>
	/// A PRINTER_INFO_4 structure containing minimal printer information, including the name of the printer, the name of the server,
	/// and whether the printer is remote or local.
	/// </term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>A PRINTER_INFO_5 structure containing printer information such as printer attributes and time-out settings.</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>A PRINTER_INFO_6 structure specifying the status value of a printer.</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>
	/// A PRINTER_INFO_7 structure. The dwAction member of this structure indicates whether SetPrinter should publish, unpublish,
	/// re-publish, or update the printer's data in the directory service.
	/// </term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>A PRINTER_INFO_8 structure specifying the global default printer settings.</term>
	/// </item>
	/// <item>
	/// <term>9</term>
	/// <term>A PRINTER_INFO_9 structure specifying the per-user default printer settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Command">
	/// <para>The action to perform.</para>
	/// <para>
	/// If the Level parameter is nonzero, set the value of this parameter to zero. In this case, the printer retains its current state
	/// and the function reconfigures the printer data as specified by the Level and pPrinter parameters.
	/// </para>
	/// <para>If the Level parameter is zero, set the value of this parameter to one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_CONTROL_PAUSE</term>
	/// <term>Pause the printer.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CONTROL_PURGE</term>
	/// <term>Delete all print jobs in the printer.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CONTROL_RESUME</term>
	/// <term>Resume a paused printer.</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_CONTROL_SET_STATUS</term>
	/// <term>Set the printer status. Set the pPrinter parameter to a pointer to a DWORD value that specifies the new printer status.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>
	/// If Level is 7 and the publish action failed, <c>SetPrinter</c> returns <c>ERROR_IO_PENDING</c> and attempts to complete the
	/// action in the background. If Level is 7 and the update action failed, <c>SetPrinter</c> returns <c>ERROR_FILE_NOT_FOUND</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>You cannot use <c>SetPrinter</c> to change the default printer.</para>
	/// <para>
	/// To modify the current printer settings, call the <c>GetPrinter</c> function to retrieve the current settings into a
	/// <c>PRINTER_INFO_2</c> structure, modify the members of that structure as necessary, and then call <c>SetPrinter</c>.
	/// </para>
	/// <para>
	/// The <c>SetPrinter</c> function ignores the <c>pServerName</c>, <c>AveragePPM</c>, <c>Status</c>, and <c>cJobs</c> members of a
	/// <c>PRINTER_INFO_2</c> structure.
	/// </para>
	/// <para>
	/// Pausing a printer suspends scheduling of all print jobs for that printer, except for the one print job that may be currently
	/// printing. Print jobs can be submitted to a paused printer, but no jobs will be scheduled to print on that printer until printing
	/// is resumed. If a printer is cleared, all print jobs for that printer are deleted, except for the current print job.
	/// </para>
	/// <para>
	/// If you use <c>SetPrinter</c> to modify the default <c>DEVMODE</c> structure for a printer (globally setting the printer
	/// defaults), you must first call the <c>DocumentProperties</c> function to validate the <c>DEVMODE</c> structure.
	/// </para>
	/// <para>
	/// For the <c>PRINTER_INFO_2</c> and <c>PRINTER_INFO_3</c> structures that contain a pointer to a security descriptor, the function
	/// can set only those components of the security descriptor that the caller has permission to modify. To set particular security
	/// descriptor components, you must specify the necessary access rights when you call the <c>OpenPrinter</c> or <c>OpenPrinter2</c>
	/// function to retrieve a handle to the printer. The following table shows the access rights required to modify the various
	/// security descriptor components.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Access permission</term>
	/// <term>Security descriptor component</term>
	/// </listheader>
	/// <item>
	/// <term>WRITE_OWNER</term>
	/// <term>Owner Primary group</term>
	/// </item>
	/// <item>
	/// <term>WRITE_DAC</term>
	/// <term>Discretionary access-control list (DACL)</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SYSTEM_SECURITY</term>
	/// <term>System access-control list (SACL)</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the security descriptor contains a component that the caller does not have the access right to modify, <c>SetPrinter</c>
	/// fails. Those components of a security descriptor that you don't want to modify should be <c>NULL</c> or not be present, as
	/// appropriate. If you do not want to modify the security descriptor, and are calling <c>SetPrinter</c> with a
	/// <c>PRINTER_INFO_2</c> structure, set the <c>pSecurityDescriptor</c> member of that structure to <c>NULL</c>.
	/// </para>
	/// <para>
	/// The Internet Connection Firewall (ICF) blocks printer ports by default, but an exception for File and Print Sharing can be
	/// enabled. If <c>SetPrinter</c> is called by a machine admin, it enables the exception. If it is called by a non-admin and the
	/// exception has not already been enabled, the call fails.
	/// </para>
	/// <para>
	/// You can use level 7 with the <c>PRINTER_INFO_7</c> structure to publish, unpublish, or update directory service data for the
	/// printer. The directory service data for a printer includes all the data stored under the SPLDS_* keys by calls to the
	/// <c>SetPrinterDataEx</c> function for the printer. Before calling <c>SetPrinter</c>, set the <c>pszObjectGUID</c> member of
	/// <c>PRINTER_INFO_7</c> to <c>NULL</c> and set the dwAction member to one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DSPRINT_PUBLISH</term>
	/// <term>Publishes the directory service data.</term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_REPUBLISH</term>
	/// <term>
	/// The directory service data for the printer is unpublished and then published again, refreshing all properties in the published
	/// printer. Re-publishing also changes the GUID of the published printer. Use this value if you suspect the printer's published
	/// data has been corrupted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_UNPUBLISH</term>
	/// <term>Unpublishes the directory service data.</term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_UPDATE</term>
	/// <term>
	/// Updates the directory service data. This is the same as DSPRINT_PUBLISH, except that SetPrinter fails with ERROR_FILE_NOT_FOUND
	/// if the printer is not already published. Use DSPRINT_UPDATE to update published properties but not force publishing. Printer
	/// drivers should always use DSPRINT_UPDATE rather than DSPRINT_PUBLISH.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>DSPRINT_PENDING</c> is not a valid dwAction value for <c>SetPrinter</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setprinter BOOL SetPrinter( _In_ HANDLE hPrinter, _In_ DWORD Level, _In_
	// LPBYTE pPrinter, _In_ DWORD Command );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "ade367c5-20d6-4da9-bb52-ce6768cf7537")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetPrinter(HPRINTER hPrinter, uint Level, IntPtr pPrinter, PRINTER_CONTROL Command = 0);

	/// <summary>
	/// The <c>SetPrinter</c> function sets the data for a specified printer or sets the state of the specified printer by pausing
	/// printing, resuming printing, or clearing all print jobs.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c>, <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="Command">
	/// <para>The action to perform. Set the value of this parameter to one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description>PRINTER_CONTROL_PAUSE</description>
	/// <description>Pause the printer.</description>
	/// </item>
	/// <item>
	/// <description>PRINTER_CONTROL_PURGE</description>
	/// <description>Delete all print jobs in the printer.</description>
	/// </item>
	/// <item>
	/// <description>PRINTER_CONTROL_RESUME</description>
	/// <description>Resume a paused printer.</description>
	/// </item>
	/// <item>
	/// <description>PRINTER_CONTROL_SET_STATUS</description>
	/// <description>
	/// Set the printer status. Set the pPrinter parameter to a pointer to a DWORD value that specifies the new printer status.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setprinter BOOL SetPrinter( _In_ HANDLE hPrinter, _In_ DWORD Level, _In_
	// LPBYTE pPrinter, _In_ DWORD Command );
	[PInvokeData("winspool.h", MSDNShortId = "ade367c5-20d6-4da9-bb52-ce6768cf7537")]
	public static bool SetPrinter(HPRINTER hPrinter, PRINTER_CONTROL Command) => SetPrinter(hPrinter, 0, default, Command);

	/// <summary>
	/// The <c>SetPrinter</c> function sets the data for a specified printer or sets the state of the specified printer by pausing
	/// printing, resuming printing, or clearing all print jobs.
	/// </summary>
	/// <typeparam name="T">The type of the structure used in <paramref name="pPrinter"/>.</typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c>, <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pPrinter">
	/// <para>
	/// A pointer to a buffer containing data to set for the printer, or containing information for the command specified by the Command
	/// parameter. The type of data in the buffer is determined by the value of Level.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Level</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// If the Command parameter is PRINTER_CONTROL_SET_STATUS, pPrinter must contain a DWORD value that specifies the new printer
	/// status to set. For a list of the possible status values, see the Status member of the PRINTER_INFO_2 structure. Note that
	/// PRINTER_STATUS_PAUSED and PRINTER_STATUS_PENDING_DELETION are not valid status values to set. If Level is 0, but the Command
	/// parameter is not PRINTER_CONTROL_SET_STATUS, pPrinter must be NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>A PRINTER_INFO_2 structure containing detailed information about the printer.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>A PRINTER_INFO_3 structure containing the printer's security information.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>
	/// A PRINTER_INFO_4 structure containing minimal printer information, including the name of the printer, the name of the server,
	/// and whether the printer is remote or local.
	/// </term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>A PRINTER_INFO_5 structure containing printer information such as printer attributes and time-out settings.</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>A PRINTER_INFO_6 structure specifying the status value of a printer.</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>
	/// A PRINTER_INFO_7 structure. The dwAction member of this structure indicates whether SetPrinter should publish, unpublish,
	/// re-publish, or update the printer's data in the directory service.
	/// </term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>A PRINTER_INFO_8 structure specifying the global default printer settings.</term>
	/// </item>
	/// <item>
	/// <term>9</term>
	/// <term>A PRINTER_INFO_9 structure specifying the per-user default printer settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>
	/// If Level is 7 and the publish action failed, <c>SetPrinter</c> returns <c>ERROR_IO_PENDING</c> and attempts to complete the
	/// action in the background. If Level is 7 and the update action failed, <c>SetPrinter</c> returns <c>ERROR_FILE_NOT_FOUND</c>.
	/// </para>
	/// </returns>
	/// <exception cref="ArgumentException"></exception>
	/// <remarks>
	/// <para>You cannot use <c>SetPrinter</c> to change the default printer.</para>
	/// <para>
	/// To modify the current printer settings, call the <c>GetPrinter</c> function to retrieve the current settings into a
	/// <c>PRINTER_INFO_2</c> structure, modify the members of that structure as necessary, and then call <c>SetPrinter</c>.
	/// </para>
	/// <para>
	/// The <c>SetPrinter</c> function ignores the <c>pServerName</c>, <c>AveragePPM</c>, <c>Status</c>, and <c>cJobs</c> members of a
	/// <c>PRINTER_INFO_2</c> structure.
	/// </para>
	/// <para>
	/// Pausing a printer suspends scheduling of all print jobs for that printer, except for the one print job that may be currently
	/// printing. Print jobs can be submitted to a paused printer, but no jobs will be scheduled to print on that printer until printing
	/// is resumed. If a printer is cleared, all print jobs for that printer are deleted, except for the current print job.
	/// </para>
	/// <para>
	/// If you use <c>SetPrinter</c> to modify the default <c>DEVMODE</c> structure for a printer (globally setting the printer
	/// defaults), you must first call the <c>DocumentProperties</c> function to validate the <c>DEVMODE</c> structure.
	/// </para>
	/// <para>
	/// For the <c>PRINTER_INFO_2</c> and <c>PRINTER_INFO_3</c> structures that contain a pointer to a security descriptor, the function
	/// can set only those components of the security descriptor that the caller has permission to modify. To set particular security
	/// descriptor components, you must specify the necessary access rights when you call the <c>OpenPrinter</c> or <c>OpenPrinter2</c>
	/// function to retrieve a handle to the printer. The following table shows the access rights required to modify the various
	/// security descriptor components.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Access permission</term>
	/// <term>Security descriptor component</term>
	/// </listheader>
	/// <item>
	/// <term>WRITE_OWNER</term>
	/// <term>Owner Primary group</term>
	/// </item>
	/// <item>
	/// <term>WRITE_DAC</term>
	/// <term>Discretionary access-control list (DACL)</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SYSTEM_SECURITY</term>
	/// <term>System access-control list (SACL)</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the security descriptor contains a component that the caller does not have the access right to modify, <c>SetPrinter</c>
	/// fails. Those components of a security descriptor that you don't want to modify should be <c>NULL</c> or not be present, as
	/// appropriate. If you do not want to modify the security descriptor, and are calling <c>SetPrinter</c> with a
	/// <c>PRINTER_INFO_2</c> structure, set the <c>pSecurityDescriptor</c> member of that structure to <c>NULL</c>.
	/// </para>
	/// <para>
	/// The Internet Connection Firewall (ICF) blocks printer ports by default, but an exception for File and Print Sharing can be
	/// enabled. If <c>SetPrinter</c> is called by a machine admin, it enables the exception. If it is called by a non-admin and the
	/// exception has not already been enabled, the call fails.
	/// </para>
	/// <para>
	/// You can use level 7 with the <c>PRINTER_INFO_7</c> structure to publish, unpublish, or update directory service data for the
	/// printer. The directory service data for a printer includes all the data stored under the SPLDS_* keys by calls to the
	/// <c>SetPrinterDataEx</c> function for the printer. Before calling <c>SetPrinter</c>, set the <c>pszObjectGUID</c> member of
	/// <c>PRINTER_INFO_7</c> to <c>NULL</c> and set the dwAction member to one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DSPRINT_PUBLISH</term>
	/// <term>Publishes the directory service data.</term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_REPUBLISH</term>
	/// <term>
	/// The directory service data for the printer is unpublished and then published again, refreshing all properties in the published
	/// printer. Re-publishing also changes the GUID of the published printer. Use this value if you suspect the printer's published
	/// data has been corrupted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_UNPUBLISH</term>
	/// <term>Unpublishes the directory service data.</term>
	/// </item>
	/// <item>
	/// <term>DSPRINT_UPDATE</term>
	/// <term>
	/// Updates the directory service data. This is the same as DSPRINT_PUBLISH, except that SetPrinter fails with ERROR_FILE_NOT_FOUND
	/// if the printer is not already published. Use DSPRINT_UPDATE to update published properties but not force publishing. Printer
	/// drivers should always use DSPRINT_UPDATE rather than DSPRINT_PUBLISH.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>DSPRINT_PENDING</c> is not a valid dwAction value for <c>SetPrinter</c>.</para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "ade367c5-20d6-4da9-bb52-ce6768cf7537")]
	public static bool SetPrinter<T>(HPRINTER hPrinter, in T pPrinter) where T : struct
	{
		if (!TryGetLevel<T>("PRINTER_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(SetPrinter)} cannot process a structure of type {typeof(T).Name}.");
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pPrinter);
		return SetPrinter(hPrinter, lvl, mem);
	}

	/// <summary>
	/// <para>The <c>SetPrinterData</c> function sets the configuration data for a printer or print server.</para>
	/// <para>
	/// To specify the registry key under which to store the data, call the <c>SetPrinterDataEx</c> function. Calling
	/// <c>SetPrinterData</c> is equivalent to calling the <c>SetPrinterDataEx</c> function with the pKeyName parameter set to "PrinterDriverData".
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function sets configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to set.</para>
	/// <para>For printers, this string is the name of a registry value under the printer's "PrinterDriverData" key in the registry.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="Type">
	/// A code that indicates the type of data that the pData parameter points to. For a list of the possible type codes, see Registry
	/// Value Types.
	/// </param>
	/// <param name="pData">A pointer to an array of bytes that contains the printer configuration data.</param>
	/// <param name="cbData">The size, in bytes, of the array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is an error value.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve existing configuration data for a printer, call the <c>GetPrinterDataEx</c> or <c>GetPrinterData</c> function.</para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>The following values of pValueName determine the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegSetValueEx</c> function to set these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// Client-side rendering of a print jobs can be configured for each printer by setting the following values in pValueName.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, causes the print jobs to be rendered on the client. If a print
	/// job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server, it
	/// will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setprinterdata DWORD SetPrinterData( _In_ HANDLE hPrinter, _In_ LPTSTR
	// pValueName, _In_ DWORD Type, _In_ LPBYTE pData, _In_ DWORD cbData );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "16072de9-98fb-4ada-8216-180b64cf44c8")]
	public static extern Win32Error SetPrinterData(HPRINTER hPrinter, string pValueName, REG_VALUE_TYPE Type, IntPtr pData, uint cbData);

	/// <summary>
	/// <para>The <c>SetPrinterData</c> function sets the configuration data for a printer or print server.</para>
	/// <para>
	/// To specify the registry key under which to store the data, call the <c>SetPrinterDataEx</c> function. Calling
	/// <c>SetPrinterData</c> is equivalent to calling the <c>SetPrinterDataEx</c> function with the pKeyName parameter set to "PrinterDriverData".
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function sets configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to set.</para>
	/// <para>For printers, this string is the name of a registry value under the printer's "PrinterDriverData" key in the registry.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="Type">
	/// A code that indicates the type of data that the pData parameter points to. For a list of the possible type codes, see Registry
	/// Value Types.
	/// </param>
	/// <param name="pData">A pointer to an array of bytes that contains the printer configuration data.</param>
	/// <param name="cbData">The size, in bytes, of the array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is an error value.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve existing configuration data for a printer, call the <c>GetPrinterDataEx</c> or <c>GetPrinterData</c> function.</para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>The following values of pValueName determine the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegSetValueEx</c> function to set these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// Client-side rendering of a print jobs can be configured for each printer by setting the following values in pValueName.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, causes the print jobs to be rendered on the client. If a print
	/// job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server, it
	/// will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setprinterdata DWORD SetPrinterData( _In_ HANDLE hPrinter, _In_ LPTSTR
	// pValueName, _In_ DWORD Type, _In_ LPBYTE pData, _In_ DWORD cbData );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "16072de9-98fb-4ada-8216-180b64cf44c8")]
	public static extern Win32Error SetPrinterData(HPRINTER hPrinter, string pValueName, REG_VALUE_TYPE Type, byte[] pData, int cbData);

	/// <summary>
	/// <para>The <c>SetPrinterData</c> function sets the configuration data for a printer or print server.</para>
	/// <para>
	/// To specify the registry key under which to store the data, call the <c>SetPrinterDataEx</c> function. Calling
	/// <c>SetPrinterData</c> is equivalent to calling the <c>SetPrinterDataEx</c> function with the pKeyName parameter set to "PrinterDriverData".
	/// </para>
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function sets configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to set.</para>
	/// <para>For printers, this string is the name of a registry value under the printer's "PrinterDriverData" key in the registry.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="pData">A pointer to an array of bytes that contains the printer configuration data.</param>
	/// <param name="type">
	/// A code that indicates the type of data that the pData parameter points to. For a list of the possible type codes, see Registry
	/// Value Types.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is an error value.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve existing configuration data for a printer, call the <c>GetPrinterDataEx</c> or <c>GetPrinterData</c> function.</para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>The following values of pValueName determine the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegSetValueEx</c> function to set these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// Client-side rendering of a print jobs can be configured for each printer by setting the following values in pValueName.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, causes the print jobs to be rendered on the client. If a print
	/// job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server, it
	/// will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "16072de9-98fb-4ada-8216-180b64cf44c8")]
	public static Win32Error SetPrinterData(HPRINTER hPrinter, string pValueName, object pData, REG_VALUE_TYPE type = 0)
	{
		return InlineSetPrinterData(SetData, hPrinter, null, pValueName, pData, type);

		static Win32Error SetData(HPRINTER p1, string p2, string p3, REG_VALUE_TYPE p4, IntPtr p5, uint p6) =>
			SetPrinterData(p1, p3, p4, p5, p6);
	}

	/// <summary>
	/// The <c>SetPrinterDataEx</c> function sets the configuration data for a printer or print server. The function stores the
	/// configuration data under the printer's registry key.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function sets configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the value to set. If the specified key or subkeys do not
	/// exist, the function creates them.
	/// </para>
	/// <para>
	/// To store configuration data that can be published in the directory service (DS), specify one of the following predefined
	/// registry keys.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPLDS_DRIVER_KEY</term>
	/// <term>Printer drivers use this key to store driver properties.</term>
	/// </item>
	/// <item>
	/// <term>SPLDS_SPOOLER_KEY</term>
	/// <term>Reserved. Used only by the print spooler to store internal spooler properties.</term>
	/// </item>
	/// <item>
	/// <term>SPLDS_USER_KEY</term>
	/// <term>Applications use this key to store printer properties such as printer asset numbers.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Values that are stored under the SPLDS_USER_KEY key are published in the directory service only if there is a corresponding
	/// property in the schema. A domain administrator must create the property if it doesn't already exist. To publish a user-defined
	/// property after you use <c>SetPrinterDataEx</c> to add or change a value, call <c>SetPrinter</c> with Level = 7 and with the
	/// <c>dwAction</c> member of <c>PRINTER_INFO_7</c> set to <c>DSPRINT_UPDATE</c>.
	/// </para>
	/// <para>
	/// You can specify other keys to store non-DS configuration data. Use the backslash ( \ ) character as a delimiter to specify a
	/// path that has one or more subkeys.
	/// </para>
	/// <para>If hPrinter is a handle to a printer and pKeyName is <c>NULL</c> or an empty string, <c>SetPrinterDataEx</c> returns <c>ERROR_INVALID_PARAMETER</c>.</para>
	/// <para>If hPrinter is a handle to a print server, pKeyName is ignored.</para>
	/// <para>Do not use <c>SPLDS_SPOOLER_KEY</c>. To change the spooler printer properties, use <c>SetPrinter</c> with Level = 2.</para>
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to set.</para>
	/// <para>For printers, this string specifies the name of a value under the pKeyName key.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="Type">
	/// <para>
	/// A code indicating the type of data pointed to by the pData parameter. For a list of the possible type codes, see Registry Value Types.
	/// </para>
	/// <para>
	/// If pKeyName specifies one of the predefined directory service keys, Type must be <c>REG_SZ</c>, <c>REG_MULTI_SZ</c>,
	/// <c>REG_DWORD</c>, or <c>REG_BINARY</c>. If <c>REG_BINARY</c> is used, cbData must be equal to 1, and the directory service
	/// treats the data as a Boolean value.
	/// </para>
	/// </param>
	/// <param name="pData">A pointer to a buffer that contains the printer configuration data.</param>
	/// <param name="cbData">The size, in bytes, of the array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is an error value.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve existing configuration data for a printer or print spooler, call the <c>GetPrinterDataEx</c> function.</para>
	/// <para>
	/// Calling <c>SetPrinterDataEx</c> with the pKeyName parameter set to "PrinterDriverData" is equivalent to calling the
	/// <c>SetPrinterData</c> function.
	/// </para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>Passing one of the following predefined values as pValueName sets the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegSetValueEx</c> function to set these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To ensure that the spooler redirects jobs to the next available printer in the pool (when the print job is not printed within
	/// the set time), the port monitor must support SNMP and the network ports in the pool must be configured as "SNMP status enabled."
	/// The port monitor that supports SNMP is Standard TCP/IP port monitor.
	/// </para>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// Client-side rendering of print jobs can be configured by setting pKeyName to "PrinterDriverData" and pValueName to the setting
	/// value in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, will cause the print jobs to be rendered on the client. If a
	/// print job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server,
	/// it will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setprinterdataex DWORD SetPrinterDataEx( _In_ HANDLE hPrinter, _In_
	// LPCTSTR pKeyName, _In_ LPCTSTR pValueName, _In_ DWORD Type, _In_ LPBYTE pData, _In_ DWORD cbData );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "b7faadfc-1c81-4ddf-8fe5-68f4cc0376f1")]
	public static extern Win32Error SetPrinterDataEx(HPRINTER hPrinter, string pKeyName, string pValueName, REG_VALUE_TYPE Type, IntPtr pData, uint cbData);

	/// <summary>
	/// The <c>SetPrinterDataEx</c> function sets the configuration data for a printer or print server. The function stores the
	/// configuration data under the printer's registry key.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function sets configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the value to set. If the specified key or subkeys do not
	/// exist, the function creates them.
	/// </para>
	/// <para>
	/// To store configuration data that can be published in the directory service (DS), specify one of the following predefined
	/// registry keys.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPLDS_DRIVER_KEY</term>
	/// <term>Printer drivers use this key to store driver properties.</term>
	/// </item>
	/// <item>
	/// <term>SPLDS_SPOOLER_KEY</term>
	/// <term>Reserved. Used only by the print spooler to store internal spooler properties.</term>
	/// </item>
	/// <item>
	/// <term>SPLDS_USER_KEY</term>
	/// <term>Applications use this key to store printer properties such as printer asset numbers.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Values that are stored under the SPLDS_USER_KEY key are published in the directory service only if there is a corresponding
	/// property in the schema. A domain administrator must create the property if it doesn't already exist. To publish a user-defined
	/// property after you use <c>SetPrinterDataEx</c> to add or change a value, call <c>SetPrinter</c> with Level = 7 and with the
	/// <c>dwAction</c> member of <c>PRINTER_INFO_7</c> set to <c>DSPRINT_UPDATE</c>.
	/// </para>
	/// <para>
	/// You can specify other keys to store non-DS configuration data. Use the backslash ( \ ) character as a delimiter to specify a
	/// path that has one or more subkeys.
	/// </para>
	/// <para>If hPrinter is a handle to a printer and pKeyName is <c>NULL</c> or an empty string, <c>SetPrinterDataEx</c> returns <c>ERROR_INVALID_PARAMETER</c>.</para>
	/// <para>If hPrinter is a handle to a print server, pKeyName is ignored.</para>
	/// <para>Do not use <c>SPLDS_SPOOLER_KEY</c>. To change the spooler printer properties, use <c>SetPrinter</c> with Level = 2.</para>
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to set.</para>
	/// <para>For printers, this string specifies the name of a value under the pKeyName key.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="Type">
	/// <para>
	/// A code indicating the type of data pointed to by the pData parameter. For a list of the possible type codes, see Registry Value Types.
	/// </para>
	/// <para>
	/// If pKeyName specifies one of the predefined directory service keys, Type must be <c>REG_SZ</c>, <c>REG_MULTI_SZ</c>,
	/// <c>REG_DWORD</c>, or <c>REG_BINARY</c>. If <c>REG_BINARY</c> is used, cbData must be equal to 1, and the directory service
	/// treats the data as a Boolean value.
	/// </para>
	/// </param>
	/// <param name="pData">A pointer to a buffer that contains the printer configuration data.</param>
	/// <param name="cbData">The size, in bytes, of the array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is an error value.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve existing configuration data for a printer or print spooler, call the <c>GetPrinterDataEx</c> function.</para>
	/// <para>
	/// Calling <c>SetPrinterDataEx</c> with the pKeyName parameter set to "PrinterDriverData" is equivalent to calling the
	/// <c>SetPrinterData</c> function.
	/// </para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>Passing one of the following predefined values as pValueName sets the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegSetValueEx</c> function to set these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To ensure that the spooler redirects jobs to the next available printer in the pool (when the print job is not printed within
	/// the set time), the port monitor must support SNMP and the network ports in the pool must be configured as "SNMP status enabled."
	/// The port monitor that supports SNMP is Standard TCP/IP port monitor.
	/// </para>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// Client-side rendering of print jobs can be configured by setting pKeyName to "PrinterDriverData" and pValueName to the setting
	/// value in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, will cause the print jobs to be rendered on the client. If a
	/// print job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server,
	/// it will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/setprinterdataex DWORD SetPrinterDataEx( _In_ HANDLE hPrinter, _In_
	// LPCTSTR pKeyName, _In_ LPCTSTR pValueName, _In_ DWORD Type, _In_ LPBYTE pData, _In_ DWORD cbData );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "b7faadfc-1c81-4ddf-8fe5-68f4cc0376f1")]
	public static extern Win32Error SetPrinterDataEx(HPRINTER hPrinter, string pKeyName, string pValueName, REG_VALUE_TYPE Type, byte[] pData, uint cbData);

	/// <summary>
	/// The <c>SetPrinterDataEx</c> function sets the configuration data for a printer or print server. The function stores the
	/// configuration data under the printer's registry key.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer or print server for which the function sets configuration data. Use the <c>OpenPrinter</c>,
	/// <c>OpenPrinter2</c>, or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pKeyName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the key containing the value to set. If the specified key or subkeys do not
	/// exist, the function creates them.
	/// </para>
	/// <para>
	/// To store configuration data that can be published in the directory service (DS), specify one of the following predefined
	/// registry keys.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPLDS_DRIVER_KEY</term>
	/// <term>Printer drivers use this key to store driver properties.</term>
	/// </item>
	/// <item>
	/// <term>SPLDS_SPOOLER_KEY</term>
	/// <term>Reserved. Used only by the print spooler to store internal spooler properties.</term>
	/// </item>
	/// <item>
	/// <term>SPLDS_USER_KEY</term>
	/// <term>Applications use this key to store printer properties such as printer asset numbers.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Values that are stored under the SPLDS_USER_KEY key are published in the directory service only if there is a corresponding
	/// property in the schema. A domain administrator must create the property if it doesn't already exist. To publish a user-defined
	/// property after you use <c>SetPrinterDataEx</c> to add or change a value, call <c>SetPrinter</c> with Level = 7 and with the
	/// <c>dwAction</c> member of <c>PRINTER_INFO_7</c> set to <c>DSPRINT_UPDATE</c>.
	/// </para>
	/// <para>
	/// You can specify other keys to store non-DS configuration data. Use the backslash ( \ ) character as a delimiter to specify a
	/// path that has one or more subkeys.
	/// </para>
	/// <para>If hPrinter is a handle to a printer and pKeyName is <c>NULL</c> or an empty string, <c>SetPrinterDataEx</c> returns <c>ERROR_INVALID_PARAMETER</c>.</para>
	/// <para>If hPrinter is a handle to a print server, pKeyName is ignored.</para>
	/// <para>Do not use <c>SPLDS_SPOOLER_KEY</c>. To change the spooler printer properties, use <c>SetPrinter</c> with Level = 2.</para>
	/// </param>
	/// <param name="pValueName">
	/// <para>A pointer to a null-terminated string that identifies the data to set.</para>
	/// <para>For printers, this string specifies the name of a value under the pKeyName key.</para>
	/// <para>For print servers, this string is one of the predefined strings listed in the following Remarks section.</para>
	/// </param>
	/// <param name="pData">A pointer to a buffer that contains the printer configuration data.</param>
	/// <param name="type">
	/// <para>
	/// A code indicating the type of data pointed to by the pData parameter. For a list of the possible type codes, see Registry Value Types.
	/// </para>
	/// <para>
	/// If pKeyName specifies one of the predefined directory service keys, Type must be <c>REG_SZ</c>, <c>REG_MULTI_SZ</c>,
	/// <c>REG_DWORD</c>, or <c>REG_BINARY</c>. If <c>REG_BINARY</c> is used, cbData must be equal to 1, and the directory service
	/// treats the data as a Boolean value.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is an error value.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve existing configuration data for a printer or print spooler, call the <c>GetPrinterDataEx</c> function.</para>
	/// <para>
	/// Calling <c>SetPrinterDataEx</c> with the pKeyName parameter set to "PrinterDriverData" is equivalent to calling the
	/// <c>SetPrinterData</c> function.
	/// </para>
	/// <para>If hPrinter is a handle to a print server, pValueName can specify one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_ALLOW_USER_MANAGEFORMS</term>
	/// <term>Windows XP with Service Pack 2 (SP2) and later Windows Server 2003 with Service Pack 1 (SP1) and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_BEEP_ENABLED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_DEFAULT_SPOOL_DIRECTORY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_EVENT_LOG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_NET_POPUP</term>
	/// <term>Not supported in Windows Server 2003 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PORT_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_GROUPS</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_TIME_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_MAX_OBJECTS_BEFORE_RECYCLE</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_IDLE_TIMEOUT</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_EXECUTION_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_PRINT_DRIVER_ISOLATION_OVERRIDE_POLICY</term>
	/// <term>Windows 7 and later</term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RETRY_POPUP</term>
	/// <term>
	/// On successful return, pData contains 1 if server is set to retry pop-up windows for all jobs, or 0 if server does not retry
	/// pop-up windows for all jobs. Not supported in Windows Server 2003 and later
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_SCHEDULER_THREAD_PRIORITY_DEFAULT</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>SPLREG_WEBSHAREMGMT</term>
	/// <term>Windows Server 2003 and later</term>
	/// </item>
	/// </list>
	/// <para>Passing one of the following predefined values as pValueName sets the pool printing behavior when an error occurs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ERROR</term>
	/// <term>
	/// The value of pData indicates the time, in seconds, when a job is restarted on another port after an error occurs. This setting
	/// is used with SPLREG_RESTART_JOB_ON_POOL_ENABLED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLREG_RESTART_JOB_ON_POOL_ENABLED</term>
	/// <term>A nonzero value in pData indicates that SPLREG_RESTART_JOB_ON_POOL_ERROR is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The time specified in <c>SPLREG_RESTART_JOB_ON_POOL_ERROR</c> is a minimum time. The actual time can be longer, depending on the
	/// following port monitor settings, which are registry values under this registry key:
	/// </para>
	/// <para><c>HKLM\SYSTEM\CurrentControlSet\Control\Print\Monitors\&lt;MonitorName&gt;\Ports</c></para>
	/// <para>Call the <c>RegSetValueEx</c> function to set these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Port monitor setting</term>
	/// <term>Data type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>StatusUpdateEnabled</term>
	/// <term>REG_DWORD</term>
	/// <term>If a nonzero value, enables the port monitor to update the spooler with the port status.</term>
	/// </item>
	/// <item>
	/// <term>StatusUpdateInterval</term>
	/// <term>REG_DWORD</term>
	/// <term>Specifies the interval, in minutes, when the port monitor updates the spooler with the port status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To ensure that the spooler redirects jobs to the next available printer in the pool (when the print job is not printed within
	/// the set time), the port monitor must support SNMP and the network ports in the pool must be configured as "SNMP status enabled."
	/// The port monitor that supports SNMP is Standard TCP/IP port monitor.
	/// </para>
	/// <para>
	/// In Windows 7 and later versions of Windows, print jobs that are sent to a print server are rendered on the client by default.
	/// Client-side rendering of print jobs can be configured by setting pKeyName to "PrinterDriverData" and pValueName to the setting
	/// value in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Setting</term>
	/// <term>Data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>EMFDespoolingSetting</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, enables the default client-side rendering of print jobs. A value
	/// of 1 disables client-side rendering of print jobs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ForceClientSideRendering</term>
	/// <term>REG_DWORD</term>
	/// <term>
	/// A value of 0, or if this value is not present in the registry, will cause the print jobs to be rendered on the client. If a
	/// print job cannot be rendered on the client, it will be rendered on the server. If a print job cannot be rendered on the server,
	/// it will fail. A value of 1 will render print jobs on the client. If a print job cannot be rendered on the client, it will fail.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "b7faadfc-1c81-4ddf-8fe5-68f4cc0376f1")]
	public static Win32Error SetPrinterDataEx(HPRINTER hPrinter, string pKeyName, string pValueName, object pData, REG_VALUE_TYPE type = 0) =>
		InlineSetPrinterData(SetPrinterDataEx, hPrinter, pKeyName, pValueName, pData, type);

	/// <summary>The <c>StartDocPrinter</c> function notifies the print spooler that a document is to be spooled for printing.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="Level">The version of the structure to which pDocInfo points. This value must be 1.</param>
	/// <param name="pDocInfo">A pointer to a <c>DOC_INFO_1</c> structure that describes the document to print.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value identifies the print job.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The typical sequence for a print job is as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>To begin a print job, call <c>StartDocPrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To begin each page, call <c>StartPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To write data to a page, call <c>WritePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To end each page, call <c>EndPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>Repeat 2, 3, and 4 for as many pages as necessary.</term>
	/// </item>
	/// <item>
	/// <term>To end the print job, call <c>EndDocPrinter</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Note that calling <c>StartPagePrinter</c> and <c>EndPagePrinter</c> may not be necessary, such as if the print data type
	/// includes the page information.
	/// </para>
	/// <para>
	/// When a page in a spooled file exceeds approximately 350 MB, it can fail to print and not send an error message. For example,
	/// this can occur when printing large EMF files. The page size limit depends on many factors including the amount of virtual memory
	/// available, the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/startdocprinter DWORD StartDocPrinter( _In_ HANDLE hPrinter, _In_ DWORD
	// Level, _In_ LPBYTE pDocInfo );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "caa2bd80-4af3-4968-a5b9-d12f16cac6fc")]
	public static extern uint StartDocPrinter(HPRINTER hPrinter, uint Level, in DOC_INFO_1 pDocInfo);

	/// <summary>The <c>StartPagePrinter</c> function notifies the spooler that a page is about to be printed on the specified printer.</summary>
	/// <param name="hPrinter">
	/// Handle to a printer. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The sequence for a print job is as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>To begin a print job, call <c>StartDocPrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To begin each page, call <c>StartPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To write data to a page, call <c>WritePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To end each page, call <c>EndPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>Repeat 2, 3, and 4 for as many pages as necessary.</term>
	/// </item>
	/// <item>
	/// <term>To end the print job, call <c>EndDocPrinter</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When a page in a spooled file exceeds approximately 350 MB, it can fail to print and not send an error message. For example,
	/// this can occur when printing large EMF files. The page size limit depends on many factors including the amount of virtual memory
	/// available, the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/startpageprinter BOOL StartPagePrinter( _In_ HANDLE hPrinter );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "8ac7c47b-b3a7-4642-bfb7-54e014139fbf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StartPagePrinter(HPRINTER hPrinter);

	/// <summary>The <c>WritePrinter</c> function notifies the print spooler that data should be written to the specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pBuf">A pointer to an array of bytes that contains the data that should be written to the printer.</param>
	/// <param name="cbBuf">The size, in bytes, of the array.</param>
	/// <param name="pcWritten">A pointer to a value that receives the number of bytes of data that were written to the printer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The sequence for a print job is as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>To begin a print job, call <c>StartDocPrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To begin each page, call <c>StartPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To write data to a page, call <c>WritePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To end each page, call <c>EndPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>Repeat 2, 3, and 4 for as many pages as necessary.</term>
	/// </item>
	/// <item>
	/// <term>To end the print job, call <c>EndDocPrinter</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When a high-level document (such as an Adobe PDF or Microsoft Word file) or other printer data (such PCL, PS, or HPGL) is sent
	/// directly to a printer, the print settings defined in the document take precedent over Windows print settings. Documents output
	/// when the value of the pDatatype member of the <c>DOC_INFO_1</c> structure that was passed in the pDocInfo parameter of the
	/// <c>StartDocPrinter</c> call is "RAW" must fully describe the <c>DEVMODE</c>-style print job settings in the language understood
	/// by the hardware.
	/// </para>
	/// <para>
	/// In versions of Windows prior to Windows XP, when a page in a spooled file exceeds approximately 350 MB, it can fail to print and
	/// not send an error message. For example, this can occur when printing large EMF files. The page size limit in versions of Windows
	/// prior to Windows XP depends on many factors including the amount of virtual memory available, the amount of memory allocated by
	/// calling processes, and the amount of fragmentation in the process heap. In Windows XP and later versions of Windows, EMF files
	/// must be 2GB or less in size. If <c>WritePrinter</c> is used to write non EMF data, such as printer-ready PDL, the size of the
	/// file is limited only by the available disk space.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/writeprinter BOOL WritePrinter( _In_ HANDLE hPrinter, _In_ LPVOID pBuf,
	// _In_ DWORD cbBuf, _Out_ LPDWORD pcWritten );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "9411b71f-d686-44ed-9051-d410e5ab228e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WritePrinter(HPRINTER hPrinter, IntPtr pBuf, uint cbBuf, out uint pcWritten);

	/// <summary>The <c>WritePrinter</c> function notifies the print spooler that data should be written to the specified printer.</summary>
	/// <param name="hPrinter">
	/// A handle to the printer. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function to retrieve a printer handle.
	/// </param>
	/// <param name="pBuf">A pointer to an array of bytes that contains the data that should be written to the printer.</param>
	/// <param name="cbBuf">The size, in bytes, of the array.</param>
	/// <param name="pcWritten">A pointer to a value that receives the number of bytes of data that were written to the printer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The sequence for a print job is as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>To begin a print job, call <c>StartDocPrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To begin each page, call <c>StartPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To write data to a page, call <c>WritePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>To end each page, call <c>EndPagePrinter</c>.</term>
	/// </item>
	/// <item>
	/// <term>Repeat 2, 3, and 4 for as many pages as necessary.</term>
	/// </item>
	/// <item>
	/// <term>To end the print job, call <c>EndDocPrinter</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When a high-level document (such as an Adobe PDF or Microsoft Word file) or other printer data (such PCL, PS, or HPGL) is sent
	/// directly to a printer, the print settings defined in the document take precedent over Windows print settings. Documents output
	/// when the value of the pDatatype member of the <c>DOC_INFO_1</c> structure that was passed in the pDocInfo parameter of the
	/// <c>StartDocPrinter</c> call is "RAW" must fully describe the <c>DEVMODE</c>-style print job settings in the language understood
	/// by the hardware.
	/// </para>
	/// <para>
	/// In versions of Windows prior to Windows XP, when a page in a spooled file exceeds approximately 350 MB, it can fail to print and
	/// not send an error message. For example, this can occur when printing large EMF files. The page size limit in versions of Windows
	/// prior to Windows XP depends on many factors including the amount of virtual memory available, the amount of memory allocated by
	/// calling processes, and the amount of fragmentation in the process heap. In Windows XP and later versions of Windows, EMF files
	/// must be 2GB or less in size. If <c>WritePrinter</c> is used to write non EMF data, such as printer-ready PDL, the size of the
	/// file is limited only by the available disk space.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/writeprinter BOOL WritePrinter( _In_ HANDLE hPrinter, _In_ LPVOID pBuf,
	// _In_ DWORD cbBuf, _Out_ LPDWORD pcWritten );
	[DllImport(Lib.Winspool, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winspool.h", MSDNShortId = "9411b71f-d686-44ed-9051-d410e5ab228e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WritePrinter(HPRINTER hPrinter, byte[] pBuf, int cbBuf, out uint pcWritten);

	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool AddPrinterConnection2([Optional] HWND hWnd, string pszName, uint dwLevel, in PRINTER_CONNECTION_INFO_1 pConnectionInfo);

	private static Win32Error InlineSetPrinterData(Func<HPRINTER, string, string, REG_VALUE_TYPE, IntPtr, uint, Win32Error> f, HPRINTER hPrinter, string pKeyName, string pValueName, object pData, REG_VALUE_TYPE type)
	{
		var pDataType = pData.GetType();
		if (type == 0) type = RegistryTypeExt.GetFromType(pDataType);
		switch (type)
		{
			case REG_VALUE_TYPE.REG_NONE:
			case REG_VALUE_TYPE.REG_BINARY:
				using (var str = new NativeMemoryStream())
				{
					str.WriteObject(pData);
					str.Flush();
					return f(hPrinter, pKeyName, pValueName, type, str.Pointer, (uint)str.Length);
				}

			case REG_VALUE_TYPE.REG_DWORD:
			case REG_VALUE_TYPE.REG_DWORD_BIG_ENDIAN:
				var bytes = BitConverter.GetBytes(Convert.ToUInt32(pData));
				if (BitConverter.IsLittleEndian && type == REG_VALUE_TYPE.REG_DWORD_BIG_ENDIAN || !BitConverter.IsLittleEndian && type == REG_VALUE_TYPE.REG_DWORD)
					Array.Reverse(bytes);
				using (var bs = SafeCoTaskMemHandle.CreateFromList(bytes))
					return f(hPrinter, pKeyName, pValueName, type, bs, bs.Size);

			case REG_VALUE_TYPE.REG_MULTI_SZ:
				using (var ms = SafeCoTaskMemHandle.CreateFromStringList((IEnumerable<string>)pData))
					return f(hPrinter, pKeyName, pValueName, type, ms, ms.Size);

			case REG_VALUE_TYPE.REG_QWORD:
				var q = Convert.ToUInt64(pData);
				return f(hPrinter, pKeyName, pValueName, type, new PinnedObject(q), 8);

			case REG_VALUE_TYPE.REG_SZ:
			case REG_VALUE_TYPE.REG_EXPAND_SZ:
				using (var ms = new SafeCoTaskMemString(pData.ToString()))
					return f(hPrinter, pKeyName, pValueName, type, ms, ms.Size);

			default:
				throw new ArgumentException("Cannot convert to a registry format.", nameof(pData));
		}
	}

	[DllImport(Lib.Winspool, SetLastError = true, EntryPoint = "GetSpoolFileHandle")]
	private static extern IntPtr InternalGetSpoolFileHandle(HPRINTER hPrinter);

	private static bool TryGetLevel<T>(string prefix, out uint level)
	{
		level = 0;
		return typeof(T).Name.StartsWith(prefix) && uint.TryParse(typeof(T).Name.Substring(typeof(T).Name.LastIndexOf('_') + 1), out level);
	}
}