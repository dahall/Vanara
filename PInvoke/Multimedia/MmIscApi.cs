namespace Vanara.PInvoke;

public static partial class WinMm
{
	/// <summary>Processes driver messages for the installable driver. <c>DriverProc</c> is a driver-supplied function.</summary>
	/// <param name="dwDriverIdentifier">Identifier of the installable driver.</param>
	/// <param name="hdrvr">Handle of the installable driver instance. Each instance of the installable driver has a unique handle.</param>
	/// <param name="uMsg">
	/// <para>Driver message value. It can be a custom value or one of these standard values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DRV_CLOSE</term>
	/// <term>Notifies the driver that it should decrement its usage count and unload the driver if the count is zero.</term>
	/// </item>
	/// <item>
	/// <term>DRV_CONFIGURE</term>
	/// <term>
	/// Notifies the driver that it should display a configuration dialog box. This message is sent only if the driver returns a nonzero
	/// value when processing the DRV_QUERYCONFIGURE message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DRV_DISABLE</term>
	/// <term>Notifies the driver that its allocated memory is about to be freed.</term>
	/// </item>
	/// <item>
	/// <term>DRV_ENABLE</term>
	/// <term>Notifies the driver that it has been loaded or reloaded or that Windows has been enabled.</term>
	/// </item>
	/// <item>
	/// <term>DRV_FREE</term>
	/// <term>Notifies the driver that it will be discarded.</term>
	/// </item>
	/// <item>
	/// <term>DRV_INSTALL</term>
	/// <term>Notifies the driver that it has been successfully installed.</term>
	/// </item>
	/// <item>
	/// <term>DRV_LOAD</term>
	/// <term>Notifies the driver that it has been successfully loaded.</term>
	/// </item>
	/// <item>
	/// <term>DRV_OPEN</term>
	/// <term>Notifies the driver that it is about to be opened.</term>
	/// </item>
	/// <item>
	/// <term>DRV_POWER</term>
	/// <term>Notifies the driver that the device's power source is about to be turned on or off.</term>
	/// </item>
	/// <item>
	/// <term>DRV_QUERYCONFIGURE</term>
	/// <term>Directs the driver to specify whether it supports the DRV_CONFIGURE message.</term>
	/// </item>
	/// <item>
	/// <term>DRV_REMOVE</term>
	/// <term>Notifies the driver that it is about to be removed from the system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lParam1">32-bit message-specific value.</param>
	/// <param name="lParam2">32-bit message-specific value.</param>
	/// <returns>Returns nonzero if successful or zero otherwise.</returns>
	/// <remarks>
	/// <para>
	/// When msg is DRV_OPEN, lParam1 is the string following the driver filename from the SYSTEM.INI file and lParam2 is the value
	/// given as the lParam parameter in a call to the OpenDriver function.
	/// </para>
	/// <para>
	/// When msg is DRV_CLOSE, lParam1 and lParam2 are the same values as the lParam1 and lParam2 parameters in a call to the
	/// CloseDriver function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nc-mmiscapi-driverproc DRIVERPROC Driverproc; LRESULT Driverproc(
	// DWORD_PTR unnamedParam1, HDRVR unnamedParam2, UINT unnamedParam3, LPARAM unnamedParam4, LPARAM unnamedParam5 ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NC:mmiscapi.DRIVERPROC")]
	public delegate IntPtr DRIVERPROC(IntPtr dwDriverIdentifier, HDRVR hdrvr, DRV uMsg, IntPtr lParam1, IntPtr lParam2);

	/// <summary>
	/// The <c>MMIOProc</c> function is a custom input/output (I/O) procedure installed by the mmioInstallIOProc function.
	/// <c>MMIOProc</c> is a placeholder for the application-defined function name. The address of this function can be specified in the
	/// callback-address parameter of <c>mmioInstallIOProc</c>.
	/// </summary>
	/// <param name="lpmmioinfo">
	/// <para>Points to an MMIOINFO structure containing information about the open file.</para>
	/// <para>
	/// The I/O procedure must maintain the <c>lDiskOffset</c> member in this structure to indicate the file offset to the next read or
	/// write location. The I/O procedure can use the <c>adwInfo</c>[] member to store state information. The I/O procedure should not
	/// modify any other members of the MMIOINFO structure.
	/// </para>
	/// </param>
	/// <param name="uMsg">
	/// Specifies a message indicating the requested I/O operation. Messages that can be received include MMIOM_OPEN, MMIOM_CLOSE,
	/// MMIOM_READ, MMIOM_SEEK, MMIOM_WRITE, and MMIOM_WRITEFLUSH.
	/// </param>
	/// <param name="lParam1">Specifies an application-defined parameter for the message.</param>
	/// <param name="lParam2">Specifies an application-defined parameter for the message.</param>
	/// <returns>
	/// The return value depends on the message specified by uMsg. If the I/O procedure does not recognize a message, it should return zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The four-character code specified by the <c>fccMMIOProc</c> member in the MMIOINFO structure associated with a file identifies a
	/// file name extension for a custom storage system. When an application calls mmioOpen with a file name such as "one.xyz+two", the
	/// I/O procedure associated with the four-character code "XYZ" is called to open the "two" element of the file "one.xyz".
	/// </para>
	/// <para>
	/// The mmioInstallIOProc function maintains a separate list of installed I/O procedures for each Windows-based application.
	/// Therefore, different applications can use the same I/O procedure identifier for different I/O procedures without conflict.
	/// However, installing an I/O procedure globally enables any process to use the procedure.
	/// </para>
	/// <para>
	/// If an application calls mmioInstallIOProc more than once to register the same I/O procedure, then it must call
	/// <c>mmioInstallIOProc</c> to remove the procedure once for each time it installed the procedure.
	/// </para>
	/// <para>
	/// mmioInstallIOProc will not prevent an application from installing two different I/O procedures with the same identifier, or
	/// installing an I/O procedure with one of the predefined identifiers ("DOS ", "MEM "). The most recently installed procedure takes
	/// precedence, and the most recently installed procedure is the first one to be removed.
	/// </para>
	/// <para>When searching for a specified I/O procedure, local procedures are searched first, then global procedures.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nc-mmiscapi-mmioproc MMIOPROC Mmioproc; LRESULT Mmioproc( LPSTR
	// lpmmioinfo, UINT uMsg, LPARAM lParam1, LPARAM lParam2 ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NC:mmiscapi.MMIOPROC")]
	public delegate IntPtr MMIOPROC(ref MMIOINFO lpmmioinfo, MMIOM uMsg, IntPtr lParam1, IntPtr lParam2);

	/// <summary>Notification flags.</summary>
	[PInvokeData("mmddk.h")]
	public enum DCB : uint
	{
		/// <summary>Unknown callback type</summary>
		DCB_NULL = 0x0000,

		/// <summary>
		/// The dwCallback parameter is the handle of an application-defined window. The system sends subsequent notifications to the window.
		/// </summary>
		DCB_WINDOW = 0x0001,

		/// <summary>
		/// The dwCallback parameter is the handle of an application or task. The system sends subsequent notifications to the
		/// application or task.
		/// </summary>
		DCB_TASK = 0x0002,

		/// <summary>
		/// The dwCallback parameter is the address of an application-defined callback function. The system sends the callback message
		/// to the callback function.
		/// </summary>
		DCB_FUNCTION = 0x0003,

		/// <summary>dwCallback is an EVENT</summary>
		DCB_EVENT = 0x0005,

		/// <summary>
		/// The system is prevented from switching stacks. This value is only used if enough stack space for the callback function is
		/// known to exist.
		/// </summary>
		DCB_NOSWITCH = 0x0008,
	}

	/// <summary>Driver message value. It can be a custom value or one of these standard values.</summary>
	[PInvokeData("mmiscapi.h", MSDNShortId = "NC:mmiscapi.DRIVERPROC")]
	public enum DRV
	{
		/// <summary>Notifies the driver that it has been successfully loaded.</summary>
		DRV_LOAD = 0x0001,

		/// <summary>Notifies the driver that it has been loaded or reloaded or that Windows has been enabled.</summary>
		DRV_ENABLE = 0x0002,

		/// <summary>Notifies the driver that it is about to be opened.</summary>
		DRV_OPEN = 0x0003,

		/// <summary>Notifies the driver that it should decrement its usage count and unload the driver if the count is zero.</summary>
		DRV_CLOSE = 0x0004,

		/// <summary>Notifies the driver that its allocated memory is about to be freed.</summary>
		DRV_DISABLE = 0x0005,

		/// <summary>Notifies the driver that it will be discarded.</summary>
		DRV_FREE = 0x0006,

		/// <summary>
		/// Notifies the driver that it should display a configuration dialog box. This message is sent only if the driver returns a
		/// nonzero value when processing the DRV_QUERYCONFIGURE message.
		/// </summary>
		DRV_CONFIGURE = 0x0007,

		/// <summary>Directs the driver to specify whether it supports the DRV_CONFIGURE message.</summary>
		DRV_QUERYCONFIGURE = 0x0008,

		/// <summary>Notifies the driver that it has been successfully installed.</summary>
		DRV_INSTALL = 0x0009,

		/// <summary>Notifies the driver that it is about to be removed from the system.</summary>
		DRV_REMOVE = 0x000A,

		/// <summary></summary>
		DRV_EXITSESSION = 0x000B,

		/// <summary>Notifies the driver that the device's power source is about to be turned on or off.</summary>
		DRV_POWER = 0x000F,

		/// <summary></summary>
		DRV_RESERVED = 0x0800,

		/// <summary></summary>
		DRV_USER = 0x4000,
	}

	/// <summary></summary>
	[Flags]
	public enum MMIO : uint
	{
		/* constants for dwFlags field of MMIOINFO */

		/// <summary>The mmioOpen function was directed to create the file (or truncate it to zero length if it already existed).</summary>
		MMIO_CREATE = 0x00001000,

		/// <summary>The new file's path is returned.</summary>
		MMIO_PARSE = 0x00000100,

		/// <summary>create new file (or truncate file)</summary>
		MMIO_DELETE = 0x00000200,

		/// <summary>Checks for the existence of the file.</summary>
		MMIO_EXIST = 0x00004000,

		/// <summary>File's I/O buffer was allocated by the mmioOpen or mmioSetBuffer function.</summary>
		MMIO_ALLOCBUF = 0x00010000,

		/// <summary>A temporary name was retrieved by the mmioOpen function.</summary>
		MMIO_GETTEMP = 0x00020000,

		/// <summary>The I/O buffer has been modified.</summary>
		MMIO_DIRTY = 0x10000000,

		/// <summary>File was opened only for reading.</summary>
		MMIO_READ = 0x00000000,

		/// <summary>File was opened only for writing.</summary>
		MMIO_WRITE = 0x00000001,

		/// <summary>File was opened for reading and writing.</summary>
		MMIO_READWRITE = 0x00000002,

		/* share mode numbers (bit field MMIO_SHAREMODE) */

		/// <summary>
		/// File was opened with compatibility mode, allowing any process on a given machine to open the file any number of times.
		/// </summary>
		MMIO_COMPAT = 0x00000000,

		/// <summary>Other processes are denied read and write access to the file.</summary>
		MMIO_EXCLUSIVE = 0x00000010,

		/// <summary>Other processes are denied write access to the file.</summary>
		MMIO_DENYWRITE = 0x00000020,

		/// <summary>Other processes are denied read access to the file.</summary>
		MMIO_DENYREAD = 0x00000030,

		/// <summary>Other processes are not denied read or write access to the file.</summary>
		MMIO_DENYNONE = 0x00000040,
	}

	/// <summary>Flags for the close operation.</summary>
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioClose")]
	[Flags]
	public enum MMIOCLOSE : uint
	{
		/// <summary>
		/// If the file was opened by passing a file handle whose type is not HMMIO, using this flag tells the mmioClose function to
		/// close the multimedia file handle, but not the standard file handle.
		/// </summary>
		MMIO_FHOPEN = 0x0010,
	}

	/// <summary>Flags for the conversion.</summary>
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioStringToFOURCC")]
	[Flags]
	public enum MMIOCONV : uint
	{
		/// <summary>Converts all characters to uppercase.</summary>
		MMIO_TOUPPER = 0x0010,
	}

	/// <summary>Flags identifying what type of chunk to create.</summary>
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioCreateChunk")]
	[Flags]
	public enum MMIOCREATE : uint
	{
		/// <summary>RIFF chunk</summary>
		MMIO_CREATERIFF = 0x0020,

		/// <summary>LIST chunk</summary>
		MMIO_CREATELIST = 0x0040,
	}

	/// <summary>
	/// Search flags. If no flags are specified, <c>mmioDescend</c> descends into the chunk beginning at the current file position.
	/// </summary>
	[Flags]
	public enum MMIODESC : uint
	{
		/// <summary>Searches for a chunk with the specified chunk identifier.</summary>
		MMIO_FINDCHUNK = 0x0010,

		/// <summary>Searches for a chunk with the chunk identifier "RIFF" and with the specified form type.</summary>
		MMIO_FINDRIFF = 0x0020,

		/// <summary>Searches for a chunk with the chunk identifier "LIST" and with the specified form type.</summary>
		MMIO_FINDLIST = 0x0040,
	}

	/// <summary>Flag determining how the flush is carried out.</summary>
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioFlush")]
	[Flags]
	public enum MMIOFLUSH : uint
	{
		/// <summary>Empties the buffer after writing it to the disk.</summary>
		MMIO_EMPTYBUF = 0x0010,
	}

	/// <summary>Flag indicating whether the I/O procedure is being installed, removed, or located.</summary>
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioInstallIOProc")]
	[Flags]
	public enum MMIOINST : uint
	{
		/// <summary>Installs the specified I/O procedure.</summary>
		MMIO_INSTALLPROC = 0x00010000,

		/// <summary>
		/// This flag is a modifier to the MMIO_INSTALLPROC flag and indicates the I/O procedure should be installed for global use.
		/// This flag is ignored if MMIO_FINDPROC or MMIO_REMOVEPROC is specified.
		/// </summary>
		MMIO_GLOBALPROC = 0x10000000,

		/// <summary>Removes the specified I/O procedure.</summary>
		MMIO_REMOVEPROC = 0x00020000,

		/// <summary>Unicode MMIOProc</summary>
		MMIO_UNICODEPROC = 0x01000000,

		/// <summary>Searches for the specified I/O procedure.</summary>
		MMIO_FINDPROC = 0x00040000,
	}

	/// <summary>MMIO messages.</summary>
	[PInvokeData("mmiscapi.h")]
	public enum MMIOM : uint
	{
		/// <summary>read</summary>
		MMIOM_READ = MMIO.MMIO_READ,

		/// <summary>write</summary>
		MMIOM_WRITE = MMIO.MMIO_WRITE,

		/// <summary>seek to a new position in file</summary>
		MMIOM_SEEK = 2,

		/// <summary>open file</summary>
		MMIOM_OPEN = 3,

		/// <summary>close file</summary>
		MMIOM_CLOSE = 4,

		/// <summary>write and flush</summary>
		MMIOM_WRITEFLUSH = 5,

		/// <summary>rename specified file</summary>
		MMIOM_RENAME = 6,

		/// <summary>beginning of user-defined messages</summary>
		MMIOM_USER = 0x8000,
	}

	/// <summary>Closes an installable driver.</summary>
	/// <param name="hDriver">
	/// Handle of an installable driver instance. The handle must have been previously created by using the OpenDriver function.
	/// </param>
	/// <param name="lParam1">32-bit driver-specific data.</param>
	/// <param name="lParam2">32-bit driver-specific data.</param>
	/// <returns>Returns nonzero if successful or zero otherwise.</returns>
	/// <remarks>The function passes the lParam1 and lParam2 parameters to the DriverProc function of the installable driver.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-closedriver LRESULT CloseDriver( HDRVR hDriver, LPARAM
	// lParam1, LPARAM lParam2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.CloseDriver")]
	public static extern IntPtr CloseDriver(HDRVR hDriver, [In, Optional] IntPtr lParam1, [In, Optional] IntPtr lParam2);

	/// <summary>
	/// Provides default processing for any messages not processed by an installable driver. This function is intended to be used only
	/// within the DriverProc function of an installable driver.
	/// </summary>
	/// <param name="dwDriverIdentifier">Identifier of the installable driver.</param>
	/// <param name="hdrvr">Handle of the installable driver instance.</param>
	/// <param name="uMsg">Driver message value.</param>
	/// <param name="lParam1">32-bit message-dependent information.</param>
	/// <param name="lParam2">32-bit message-dependent information.</param>
	/// <returns>Returns nonzero if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-defdriverproc LRESULT DefDriverProc( DWORD_PTR
	// dwDriverIdentifier, HDRVR hdrvr, UINT uMsg, LPARAM lParam1, LPARAM lParam2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.DefDriverProc")]
	public static extern IntPtr DefDriverProc(IntPtr dwDriverIdentifier, HDRVR hdrvr, DRV uMsg, IntPtr lParam1, IntPtr lParam2);

	/// <summary>
	/// Calls a callback function, sends a message to a window, or unblocks a thread. The action depends on the value of the
	/// notification flag. This function is intended to be used only within the DriverProc function of an installable driver.
	/// </summary>
	/// <param name="dwCallback">
	/// Address of the callback function, a window handle, or a task handle, depending on the flag specified in the dwFlags parameter.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Notification flags. It can be one of these values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DCB_NOSWITCH</term>
	/// <term>
	/// The system is prevented from switching stacks. This value is only used if enough stack space for the callback function is known
	/// to exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DCB_FUNCTION</term>
	/// <term>
	/// The dwCallback parameter is the address of an application-defined callback function. The system sends the callback message to
	/// the callback function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DCB_WINDOW</term>
	/// <term>
	/// The dwCallback parameter is the handle of an application-defined window. The system sends subsequent notifications to the window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DCB_TASK</term>
	/// <term>
	/// The dwCallback parameter is the handle of an application or task. The system sends subsequent notifications to the application
	/// or task.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hDevice">Handle of the installable driver instance.</param>
	/// <param name="dwMsg">Message value.</param>
	/// <param name="dwUser">32-bit user-instance data supplied by the application when the device was opened.</param>
	/// <param name="dwParam1">32-bit message-dependent parameter.</param>
	/// <param name="dwParam2">32-bit message-dependent parameter.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> if a parameter is invalid or the task's message queue is full.</returns>
	/// <remarks>
	/// <para>
	/// The client specifies how to notify it when the device is opened. The DCB_FUNCTION and DCB_WINDOW flags are equivalent to the
	/// high-order word of the corresponding flags CALLBACK_FUNCTION and CALLBACK_WINDOW specified in the lParam2 parameter of the
	/// DRV_OPEN message when the device was opened.
	/// </para>
	/// <para>
	/// If notification is accomplished with a callback function, hdrvr, msg, dwUser, dwParam1, and dwParam2 are passed to the callback
	/// function. If notification is accomplished by means of a window, only msg, hdrvr, and dwParam1 are passed to the window.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-drivercallback BOOL DriverCallback( DWORD_PTR dwCallback,
	// DWORD dwFlags, HDRVR hDevice, DWORD dwMsg, DWORD_PTR dwUser, DWORD_PTR dwParam1, DWORD_PTR dwParam2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.DriverCallback")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DriverCallback(IntPtr dwCallback, DCB dwFlags, HDRVR hDevice, uint dwMsg, IntPtr dwUser, IntPtr dwParam1, IntPtr dwParam2);

	/// <summary>
	/// Provides default processing for any messages not processed by an installable driver. This function is intended to be used only
	/// within the DriverProc function of an installable driver.
	/// </summary>
	/// <param name="dwDriverIdentifier">Identifier of the installable driver.</param>
	/// <param name="hdrvr">Handle of the installable driver instance.</param>
	/// <param name="uMsg">Driver message value.</param>
	/// <param name="lParam1">32-bit message-dependent information.</param>
	/// <param name="lParam2">32-bit message-dependent information.</param>
	/// <returns>Returns nonzero if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-drvdefdriverproc LRESULT DrvDefDriverProc( DWORD
	// dwDriverIdentifier, HDRVR hdrvr, UINT uMsg, LPARAM lParam1, LPARAM lParam2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.DrvDefDriverProc")]
	public static extern IntPtr DrvDefDriverProc(uint dwDriverIdentifier, HDRVR hdrvr, uint uMsg, IntPtr lParam1, IntPtr lParam2);

	/// <summary>
	/// Retrieves the instance handle of the module that contains the installable driver. This function is provided for compatibility
	/// with previous versions of Windows.
	/// </summary>
	/// <param name="hDriver">
	/// Handle of the installable driver instance. The handle must have been previously created by using the OpenDriver function.
	/// </param>
	/// <returns>Returns an instance handle of the driver module if successful or <c>NULL</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-drvgetmodulehandle HMODULE DrvGetModuleHandle( HDRVR
	// hDriver );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.DrvGetModuleHandle")]
	public static extern HINSTANCE DrvGetModuleHandle([In] HDRVR hDriver);

	/// <summary>Retrieves the instance handle of the module that contains the installable driver.</summary>
	/// <param name="hDriver">Handle of the installable driver instance. The handle must have been previously created by using the OpenDriver function.</param>
	/// <returns>Returns an instance handle of the driver module if successful or <c>NULL</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-getdrivermodulehandle
	// HMODULE GetDriverModuleHandle( HDRVR hDriver );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.GetDriverModuleHandle")]
	public static extern HINSTANCE GetDriverModuleHandle([In] HDRVR hDriver);

	/// <summary>
	/// The <c>mmioAdvance</c> function advances the I/O buffer of a file set up for direct I/O buffer access with the mmioGetInfo function.
	/// </summary>
	/// <param name="hmmio">File handle of a file opened by using the mmioOpen function.</param>
	/// <param name="pmmioinfo">
	/// Pointer to the MMIOINFO structure obtained by using the mmioGetInfo function. This structure is used to set the current file
	/// information, and then it is updated after the buffer is advanced. This parameter is optional.
	/// </param>
	/// <param name="fuAdvance">
	/// <para>Flags for the operation. It can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_READ</term>
	/// <term>Buffer is filled from the file.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_WRITE</term>
	/// <term>Buffer is written to the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CANNOTEXPAND</term>
	/// <term>
	/// The specified memory file cannot be expanded, probably because the adwInfo member of the MMIOINFO structure was set to zero in
	/// the initial call to the mmioOpen function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_CANNOTREAD</term>
	/// <term>An error occurred while refilling the buffer.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_CANNOTWRITE</term>
	/// <term>The contents of the buffer could not be written to disk.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_OUTOFMEMORY</term>
	/// <term>There was not enough memory to expand a memory file for further writing.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_UNBUFFERED</term>
	/// <term>The specified file is not opened for buffered I/O.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the file is opened for reading, the I/O buffer is filled from the disk. If the file is opened for writing and the MMIO_DIRTY
	/// flag is set in the <c>dwFlags</c> member of the MMIOINFO structure, the buffer is written to disk. The
	/// <c>pchNext,</c><c>pchEndRead</c>, and <c>pchEndWrite</c> members of the <c>MMIOINFO</c> structure are updated to reflect the new
	/// state of the I/O buffer.
	/// </para>
	/// <para>
	/// If the specified file is opened for writing or for both reading and writing, the I/O buffer is flushed to disk before the next
	/// buffer is read. If the I/O buffer cannot be written to disk because the disk is full, <c>mmioAdvance</c> returns MMIOERR_CANNOTWRITE.
	/// </para>
	/// <para>If the specified file is open only for writing, the MMIO_WRITE flag must be specified.</para>
	/// <para>
	/// If you have written to the I/O buffer, you must set the MMIO_DIRTY flag in the <c>dwFlags</c> member of the <c>MMIOINFO</c>
	/// structure before calling <c>mmioAdvance</c>. Otherwise, the buffer will not be written to disk.
	/// </para>
	/// <para>
	/// If the end of file is reached, <c>mmioAdvance</c> still returns successfully even though no more data can be read. To check for
	/// the end of the file, check if the <c>pchNext</c> and <c>pchEndRead</c> members of the <c>MMIOINFO</c> structure are equal after
	/// calling <c>mmioAdvance</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioadvance MMRESULT mmioAdvance( HMMIO hmmio, LPMMIOINFO
	// pmmioinfo, UINT fuAdvance );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioAdvance")]
	public static extern MMRESULT mmioAdvance(HMMIO hmmio, in MMIOINFO pmmioinfo, MMIO fuAdvance);

	/// <summary>
	/// The <c>mmioAdvance</c> function advances the I/O buffer of a file set up for direct I/O buffer access with the mmioGetInfo function.
	/// </summary>
	/// <param name="hmmio">File handle of a file opened by using the mmioOpen function.</param>
	/// <param name="pmmioinfo">
	/// Pointer to the MMIOINFO structure obtained by using the mmioGetInfo function. This structure is used to set the current file
	/// information, and then it is updated after the buffer is advanced. This parameter is optional.
	/// </param>
	/// <param name="fuAdvance">
	/// <para>Flags for the operation. It can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_READ</term>
	/// <term>Buffer is filled from the file.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_WRITE</term>
	/// <term>Buffer is written to the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CANNOTEXPAND</term>
	/// <term>
	/// The specified memory file cannot be expanded, probably because the adwInfo member of the MMIOINFO structure was set to zero in
	/// the initial call to the mmioOpen function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_CANNOTREAD</term>
	/// <term>An error occurred while refilling the buffer.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_CANNOTWRITE</term>
	/// <term>The contents of the buffer could not be written to disk.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_OUTOFMEMORY</term>
	/// <term>There was not enough memory to expand a memory file for further writing.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_UNBUFFERED</term>
	/// <term>The specified file is not opened for buffered I/O.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the file is opened for reading, the I/O buffer is filled from the disk. If the file is opened for writing and the MMIO_DIRTY
	/// flag is set in the <c>dwFlags</c> member of the MMIOINFO structure, the buffer is written to disk. The
	/// <c>pchNext,</c><c>pchEndRead</c>, and <c>pchEndWrite</c> members of the <c>MMIOINFO</c> structure are updated to reflect the new
	/// state of the I/O buffer.
	/// </para>
	/// <para>
	/// If the specified file is opened for writing or for both reading and writing, the I/O buffer is flushed to disk before the next
	/// buffer is read. If the I/O buffer cannot be written to disk because the disk is full, <c>mmioAdvance</c> returns MMIOERR_CANNOTWRITE.
	/// </para>
	/// <para>If the specified file is open only for writing, the MMIO_WRITE flag must be specified.</para>
	/// <para>
	/// If you have written to the I/O buffer, you must set the MMIO_DIRTY flag in the <c>dwFlags</c> member of the <c>MMIOINFO</c>
	/// structure before calling <c>mmioAdvance</c>. Otherwise, the buffer will not be written to disk.
	/// </para>
	/// <para>
	/// If the end of file is reached, <c>mmioAdvance</c> still returns successfully even though no more data can be read. To check for
	/// the end of the file, check if the <c>pchNext</c> and <c>pchEndRead</c> members of the <c>MMIOINFO</c> structure are equal after
	/// calling <c>mmioAdvance</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioadvance MMRESULT mmioAdvance( HMMIO hmmio, LPMMIOINFO
	// pmmioinfo, UINT fuAdvance );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioAdvance")]
	public static extern MMRESULT mmioAdvance(HMMIO hmmio, [In, Optional] IntPtr pmmioinfo, MMIO fuAdvance);

	/// <summary>
	/// The <c>mmioAscend</c> function ascends out of a chunk in a RIFF file descended into with the mmioDescend function or created
	/// with the mmioCreateChunk function.
	/// </summary>
	/// <param name="hmmio">File handle of an open RIFF file.</param>
	/// <param name="pmmcki">
	/// Pointer to an application-defined MMCKINFO structure previously filled by the mmioDescend or mmioCreateChunk function.
	/// </param>
	/// <param name="fuAscend">Reserved; must be zero.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CANNOTSEEK</term>
	/// <term>There was an error while seeking to the end of the chunk.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_CANNOTWRITE</term>
	/// <term>The contents of the buffer could not be written to disk.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the chunk was descended into by using mmioDescend, <c>mmioAscend</c> seeks to the location following the end of the chunk
	/// (past the extra pad byte, if any).
	/// </para>
	/// <para>
	/// If the chunk was created and descended into by using <c>mmioCreateChunk</c>, or if the MMIO_DIRTY flag is set in the
	/// <c>dwFlags</c> member of the <c>MMCKINFO</c> structure referenced by lpck, the current file position is assumed to be the end of
	/// the data portion of the chunk. If the chunk size is not the same as the value stored in the <c>cksize</c> member of the
	/// <c>MMCKINFO</c> structure when <c>mmioCreateChunk</c> was called, <c>mmioAscend</c> corrects the chunk size in the file before
	/// ascending from the chunk. If the chunk size is odd, <c>mmioAscend</c> writes a null pad byte at the end of the chunk. After
	/// ascending from the chunk, the current file position is the location following the end of the chunk (past the extra pad byte, if any).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioascend MMRESULT mmioAscend( HMMIO hmmio, LPMMCKINFO
	// pmmcki, UINT fuAscend );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioAscend")]
	public static extern MMRESULT mmioAscend(HMMIO hmmio, in MMCKINFO pmmcki, uint fuAscend = 0);

	/// <summary>The <c>mmioClose</c> function closes a file that was opened by using the mmioOpen function.</summary>
	/// <param name="hmmio">File handle of the file to close.</param>
	/// <param name="fuClose">
	/// <para>Flags for the close operation. The following value is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_FHOPEN</term>
	/// <term>
	/// If the file was opened by passing a file handle whose type is not HMMIO, using this flag tells the mmioClose function to close
	/// the multimedia file handle, but not the standard file handle.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns zero if successful or an error otherwise. The error value can originate from the mmioFlush function or from the I/O
	/// procedure. Possible error values include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CANNOTWRITE</term>
	/// <term>The contents of the buffer could not be written to disk.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioclose MMRESULT mmioClose( HMMIO hmmio, UINT fuClose );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioClose")]
	public static extern MMRESULT mmioClose(HMMIO hmmio, MMIOCLOSE fuClose);

	/// <summary>
	/// The <c>mmioCreateChunk</c> function creates a chunk in a RIFF file that was opened by using the mmioOpen function. The new chunk
	/// is created at the current file position. After the new chunk is created, the current file position is the beginning of the data
	/// portion of the new chunk.
	/// </summary>
	/// <param name="hmmio">File handle of an open RIFF file.</param>
	/// <param name="pmmcki">Pointer to a buffer that receives a MMCKINFO structure containing information about the chunk to be created.</param>
	/// <param name="fuCreate">
	/// <para>Flags identifying what type of chunk to create. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_CREATELIST</term>
	/// <term>"LIST" chunk.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_CREATERIFF</term>
	/// <term>"RIFF" chunk.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CANNOTSEEK</term>
	/// <term>Unable to determine offset of the data portion of the chunk.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_CANNOTWRITE</term>
	/// <term>Unable to write the chunk header.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function cannot insert a chunk into the middle of a file. If an application attempts to create a chunk somewhere other than
	/// at the end of a file, <c>mmioCreateChunk</c> overwrites existing information in the file.
	/// </para>
	/// <para>The MMCKINFO structure pointed to by the lpck parameter should be set up as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The <c>ckid</c> member specifies the chunk identifier. If wFlags includes MMIO_CREATERIFF or MMIO_CREATELIST, this member will
	/// be filled by <c>mmioCreateChunk</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>cksize</c> member specifies the size of the data portion of the chunk, including the form type or list type (if any). If
	/// this value is not correct when the mmioAscend function is called to mark the end of the chunk, <c>mmioAscend</c> corrects the
	/// chunk size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>fccType</c> member specifies the form type or list type if the chunk is a "RIFF" or "LIST" chunk. If the chunk is not a
	/// "RIFF" or "LIST" chunk, this member does not need to be filled in.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>dwDataOffset</c> member does not need to be filled in. The <c>mmioCreateChunk</c> function fills this member with the
	/// file offset of the data portion of the chunk.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>dwFlags</c> member does not need to be filled in. The <c>mmioCreateChunk</c> function sets the MMIO_DIRTY flag in <c>dwFlags</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiocreatechunk MMRESULT mmioCreateChunk( HMMIO hmmio,
	// LPMMCKINFO pmmcki, UINT fuCreate );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioCreateChunk")]
	public static extern MMRESULT mmioCreateChunk(HMMIO hmmio, in MMCKINFO pmmcki, MMIOCREATE fuCreate);

	/// <summary>
	/// The <c>mmioDescend</c> function descends into a chunk of a RIFF file that was opened by using the mmioOpen function. It can also
	/// search for a given chunk.
	/// </summary>
	/// <param name="hmmio">File handle of an open RIFF file.</param>
	/// <param name="pmmcki">Pointer to a buffer that receives an MMCKINFO structure.</param>
	/// <param name="pmmckiParent">
	/// Pointer to an optional application-defined MMCKINFO structure identifying the parent of the chunk being searched for. If this
	/// parameter is not <c>NULL</c>, <c>mmioDescend</c> assumes the <c>MMCKINFO</c> structure it refers to was filled when
	/// <c>mmioDescend</c> was called to descend into the parent chunk, and <c>mmioDescend</c> searches for a chunk within the parent
	/// chunk. Set this parameter to <c>NULL</c> if no parent chunk is being specified.
	/// </param>
	/// <param name="fuDescend">
	/// <para>
	/// Search flags. If no flags are specified, <c>mmioDescend</c> descends into the chunk beginning at the current file position. The
	/// following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_FINDCHUNK</term>
	/// <term>Searches for a chunk with the specified chunk identifier.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_FINDLIST</term>
	/// <term>Searches for a chunk with the chunk identifier "LIST" and with the specified form type.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_FINDRIFF</term>
	/// <term>Searches for a chunk with the chunk identifier "RIFF" and with the specified form type.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CHUNKNOTFOUND</term>
	/// <term>The end of the file (or the end of the parent chunk, if given) was reached before the desired chunk was found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A "RIFF" chunk consists of a four-byte chunk identifier (type <c>FOURCC</c>), followed by a four-byte chunk size (type
	/// <c>DWORD</c>), followed by the data portion of the chunk, followed by a null pad byte if the size of the data portion is odd. If
	/// the chunk identifier is "RIFF" or "LIST", the first four bytes of the data portion of the chunk are a form type or list type
	/// (type <c>FOURCC</c>).
	/// </para>
	/// <para>
	/// If you use <c>mmioDescend</c> to search for a chunk, make sure the file position is at the beginning of a chunk before calling
	/// the function. The search begins at the current file position and continues to the end of the file. If a parent chunk is
	/// specified, the file position should be somewhere within the parent chunk before calling <c>mmioDescend</c>. In this case, the
	/// search begins at the current file position and continues to the end of the parent chunk.
	/// </para>
	/// <para>
	/// If <c>mmioDescend</c> is unsuccessful in searching for a chunk, the current file position is undefined. If <c>mmioDescend</c> is
	/// successful, the current file position is changed. If the chunk is a "RIFF" or "LIST" chunk, the new file position will be just
	/// after the form type or list type (12 bytes from the beginning of the chunk). For other chunks, the new file position will be the
	/// start of the data portion of the chunk (8 bytes from the beginning of the chunk).
	/// </para>
	/// <para>The <c>mmioDescend</c> function fills the MMCKINFO structure pointed to by the lpck parameter with the following information:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The <c>ckid</c> member is the chunk. If the MMIO_FINDCHUNK, MMIO_FINDRIFF, or MMIO_FINDLIST flag is specified for <c>wFlags</c>,
	/// the MMCKINFO structure is also used to pass parameters to <c>mmioDescend</c>. In this case, the <c>ckid</c> member specifies the
	/// four-character code of the chunk identifier, form type, or list type to search for.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>cksize</c> member is the size, in bytes, of the data portion of the chunk. The size includes the form type or list type
	/// (if any), but does not include the 8-byte chunk header or the pad byte at the end of the data (if any).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>fccType</c> member is the form type if <c>ckid</c> is "RIFF", or the list type if <c>ckid</c> is "LIST". Otherwise, it is <c>NULL</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>dwDataOffset</c> member is the file offset of the beginning of the data portion of the chunk. If the chunk is a "RIFF"
	/// chunk or a "LIST" chunk, this member is the offset of the form type or list type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>dwFlags</c> member contains other information about the chunk. Currently, this information is not used and is set to zero.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiodescend MMRESULT mmioDescend( HMMIO hmmio, LPMMCKINFO
	// pmmcki, const MMCKINFO *pmmckiParent, UINT fuDescend );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioDescend")]
	public static extern MMRESULT mmioDescend(HMMIO hmmio, ref MMCKINFO pmmcki, in MMCKINFO pmmckiParent, MMIODESC fuDescend);

	/// <summary>
	/// The <c>mmioDescend</c> function descends into a chunk of a RIFF file that was opened by using the mmioOpen function. It can also
	/// search for a given chunk.
	/// </summary>
	/// <param name="hmmio">File handle of an open RIFF file.</param>
	/// <param name="pmmcki">Pointer to a buffer that receives an MMCKINFO structure.</param>
	/// <param name="pmmckiParent">
	/// Pointer to an optional application-defined MMCKINFO structure identifying the parent of the chunk being searched for. If this
	/// parameter is not <c>NULL</c>, <c>mmioDescend</c> assumes the <c>MMCKINFO</c> structure it refers to was filled when
	/// <c>mmioDescend</c> was called to descend into the parent chunk, and <c>mmioDescend</c> searches for a chunk within the parent
	/// chunk. Set this parameter to <c>NULL</c> if no parent chunk is being specified.
	/// </param>
	/// <param name="fuDescend">
	/// <para>
	/// Search flags. If no flags are specified, <c>mmioDescend</c> descends into the chunk beginning at the current file position. The
	/// following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_FINDCHUNK</term>
	/// <term>Searches for a chunk with the specified chunk identifier.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_FINDLIST</term>
	/// <term>Searches for a chunk with the chunk identifier "LIST" and with the specified form type.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_FINDRIFF</term>
	/// <term>Searches for a chunk with the chunk identifier "RIFF" and with the specified form type.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CHUNKNOTFOUND</term>
	/// <term>The end of the file (or the end of the parent chunk, if given) was reached before the desired chunk was found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A "RIFF" chunk consists of a four-byte chunk identifier (type <c>FOURCC</c>), followed by a four-byte chunk size (type
	/// <c>DWORD</c>), followed by the data portion of the chunk, followed by a null pad byte if the size of the data portion is odd. If
	/// the chunk identifier is "RIFF" or "LIST", the first four bytes of the data portion of the chunk are a form type or list type
	/// (type <c>FOURCC</c>).
	/// </para>
	/// <para>
	/// If you use <c>mmioDescend</c> to search for a chunk, make sure the file position is at the beginning of a chunk before calling
	/// the function. The search begins at the current file position and continues to the end of the file. If a parent chunk is
	/// specified, the file position should be somewhere within the parent chunk before calling <c>mmioDescend</c>. In this case, the
	/// search begins at the current file position and continues to the end of the parent chunk.
	/// </para>
	/// <para>
	/// If <c>mmioDescend</c> is unsuccessful in searching for a chunk, the current file position is undefined. If <c>mmioDescend</c> is
	/// successful, the current file position is changed. If the chunk is a "RIFF" or "LIST" chunk, the new file position will be just
	/// after the form type or list type (12 bytes from the beginning of the chunk). For other chunks, the new file position will be the
	/// start of the data portion of the chunk (8 bytes from the beginning of the chunk).
	/// </para>
	/// <para>The <c>mmioDescend</c> function fills the MMCKINFO structure pointed to by the lpck parameter with the following information:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The <c>ckid</c> member is the chunk. If the MMIO_FINDCHUNK, MMIO_FINDRIFF, or MMIO_FINDLIST flag is specified for <c>wFlags</c>,
	/// the MMCKINFO structure is also used to pass parameters to <c>mmioDescend</c>. In this case, the <c>ckid</c> member specifies the
	/// four-character code of the chunk identifier, form type, or list type to search for.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>cksize</c> member is the size, in bytes, of the data portion of the chunk. The size includes the form type or list type
	/// (if any), but does not include the 8-byte chunk header or the pad byte at the end of the data (if any).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>fccType</c> member is the form type if <c>ckid</c> is "RIFF", or the list type if <c>ckid</c> is "LIST". Otherwise, it is <c>NULL</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>dwDataOffset</c> member is the file offset of the beginning of the data portion of the chunk. If the chunk is a "RIFF"
	/// chunk or a "LIST" chunk, this member is the offset of the form type or list type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The <c>dwFlags</c> member contains other information about the chunk. Currently, this information is not used and is set to zero.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiodescend MMRESULT mmioDescend( HMMIO hmmio, LPMMCKINFO
	// pmmcki, const MMCKINFO *pmmckiParent, UINT fuDescend );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioDescend")]
	public static extern MMRESULT mmioDescend(HMMIO hmmio, ref MMCKINFO pmmcki, [In, Optional] IntPtr pmmckiParent, MMIODESC fuDescend);

	/// <summary>The <c>mmioFlush</c> function writes the I/O buffer of a file to disk if the buffer has been written to.</summary>
	/// <param name="hmmio">File handle of a file opened by using the mmioOpen function.</param>
	/// <param name="fuFlush">
	/// <para>Flag determining how the flush is carried out. It can be zero or the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_EMPTYBUF</term>
	/// <term>Empties the buffer after writing it to the disk.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CANNOTWRITE</term>
	/// <term>The contents of the buffer could not be written to disk.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Closing a file with the mmioClose function automatically flushes its buffer.</para>
	/// <para>
	/// If there is insufficient disk space to write the buffer, <c>mmioFlush</c> fails, even if the preceding calls of the mmioWrite
	/// function were successful.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioflush MMRESULT mmioFlush( HMMIO hmmio, UINT fuFlush );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioFlush")]
	public static extern MMRESULT mmioFlush(HMMIO hmmio, MMIOFLUSH fuFlush);

	/// <summary>
	/// The <c>mmioGetInfo</c> function retrieves information about a file opened by using the mmioOpen function. This information
	/// allows the application to directly access the I/O buffer, if the file is opened for buffered I/O.
	/// </summary>
	/// <param name="hmmio">File handle of the file.</param>
	/// <param name="pmmioinfo">
	/// Pointer to a buffer that receives an MMIOINFO structure that <c>mmioGetInfo</c> fills with information about the file.
	/// </param>
	/// <param name="fuInfo">Reserved; must be zero.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// <para>
	/// To directly access the I/O buffer of a file opened for buffered I/O, use the following members of the MMIOINFO structure filled
	/// by <c>mmioGetInfo</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The <c>pchNext</c> member points to the next byte in the buffer that can be read or written. When you read or write, increment
	/// <c>pchNext</c> by the number of bytes read or written.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The <c>pchEndRead</c> member points to 1 byte past the last valid byte in the buffer that can be read.</term>
	/// </item>
	/// <item>
	/// <term>The <c>pchEndWrite</c> member points to 1 byte past the last location in the buffer that can be written.</term>
	/// </item>
	/// </list>
	/// <para>
	/// After you read or write to the buffer and modify <c>pchNext</c>, do not call any multimedia file I/O functions except
	/// mmioAdvance until you call the mmioSetInfo function. Call <c>mmioSetInfo</c> when you are finished directly accessing the buffer.
	/// </para>
	/// <para>
	/// When you reach the end of the buffer specified by the <c>pchEndRead</c> or <c>pchEndWrite</c> member, call mmioAdvance to fill
	/// the buffer from the disk or write the buffer to the disk. The <c>mmioAdvance</c> function updates the <c>pchNext</c>,
	/// <c>pchEndRead</c>, and <c>pchEndWrite</c> members in the MMIOINFO structure for the file.
	/// </para>
	/// <para>
	/// Before calling mmioAdvance or mmioSetInfo to flush a buffer to disk, set the MMIO_DIRTY flag in the <c>dwFlags</c> member of the
	/// MMIOINFO structure for the file. Otherwise, the buffer will not be written to disk.
	/// </para>
	/// <para>
	/// Do not decrement <c>pchNext</c> or modify any members in the MMIOINFO structure other than <c>pchNext</c> and <c>dwFlags</c>. Do
	/// not set any flags in <c>dwFlags</c> except MMIO_DIRTY.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiogetinfo MMRESULT mmioGetInfo( HMMIO hmmio, LPMMIOINFO
	// pmmioinfo, UINT fuInfo );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioGetInfo")]
	public static extern MMRESULT mmioGetInfo(HMMIO hmmio, out MMIOINFO pmmioinfo, uint fuInfo = 0);

	/// <summary>
	/// The <c>mmioInstallIOProc</c> function installs or removes a custom I/O procedure. This function also locates an installed I/O
	/// procedure, using its corresponding four-character code.
	/// </summary>
	/// <param name="fccIOProc">
	/// Four-character code identifying the I/O procedure to install, remove, or locate. All characters in this code should be uppercase.
	/// </param>
	/// <param name="pIOProc">
	/// Pointer to the I/O procedure to install. To remove or locate an I/O procedure, set this parameter to <c>NULL</c>. For more
	/// information about the I/O procedure, see MMIOProc.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flag indicating whether the I/O procedure is being installed, removed, or located. The following values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_FINDPROC</term>
	/// <term>Searches for the specified I/O procedure.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_GLOBALPROC</term>
	/// <term>
	/// This flag is a modifier to the MMIO_INSTALLPROC flag and indicates the I/O procedure should be installed for global use. This
	/// flag is ignored if MMIO_FINDPROC or MMIO_REMOVEPROC is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_INSTALLPROC</term>
	/// <term>Installs the specified I/O procedure.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_REMOVEPROC</term>
	/// <term>Removes the specified I/O procedure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns the address of the I/O procedure installed, removed, or located. Returns <c>NULL</c> if there is an error.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioinstallioproc LPMMIOPROC mmioInstallIOProc( FOURCC
	// fccIOProc, LPMMIOPROC pIOProc, DWORD dwFlags );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioInstallIOProc")]
	[return: MarshalAs(UnmanagedType.FunctionPtr)]
	public static extern MMIOPROC mmioInstallIOProc(uint fccIOProc, [In, Optional] MMIOPROC? pIOProc, MMIOINST dwFlags);

	/// <summary>
	/// <para>
	/// The <c>mmioOpen</c> function opens a file for unbuffered or buffered I/O; creates a file; deletes a file; or checks whether a
	/// file exists. The file can be a standard file, a memory file, or an element of a custom storage system. The handle returned by
	/// mmioOpen is not a standard file handle; do not use it with any file I/O functions other than multimedia file I/O functions.
	/// </para>
	/// <para><c>Note</c> This function is deprecated. Applications should call CreateFile to create or open files.</para>
	/// </summary>
	/// <param name="pszFileName">
	/// <para>
	/// Pointer to a buffer that contains the name of the file. If no I/O procedure is specified to open the file, the file name
	/// determines how the file is opened, as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the file name does not contain a plus sign (+), it is assumed to be the name of a standard file (that is, a file whose type
	/// is not <c>HMMIO</c>).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the file name is of the form EXAMPLE.EXT+ABC, the extension EXT is assumed to identify an installed I/O procedure which is
	/// called to perform I/O on the file. For more information, see mmioInstallIOProc.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the file name is <c>NULL</c> and no I/O procedure is given, the <c>adwInfo</c> member of the MMIOINFO structure is assumed to
	/// be the standard (non- <c>HMMIO</c>) file handle of a currently open file.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The file name should not be longer than 128 characters, including the terminating NULL character.</para>
	/// <para>When opening a memory file, set szFilename to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pmmioinfo">
	/// Pointer to an MMIOINFO structure containing extra parameters used by <c>mmioOpen</c>. Unless you are opening a memory file,
	/// specifying the size of a buffer for buffered I/O, or specifying an uninstalled I/O procedure to open a file, this parameter
	/// should be <c>NULL</c>. If this parameter is not <c>NULL</c>, all unused members of the <c>MMIOINFO</c> structure it references
	/// must be set to zero, including the reserved members.
	/// </param>
	/// <param name="fdwOpen">
	/// <para>
	/// Flags for the open operation. The MMIO_READ, MMIO_WRITE, and MMIO_READWRITE flags are mutually exclusive – only one should be
	/// specified. The MMIO_COMPAT, MMIO_EXCLUSIVE, MMIO_DENYWRITE, MMIO_DENYREAD, and MMIO_DENYNONE flags are file-sharing flags. The
	/// following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_ALLOCBUF</term>
	/// <term>
	/// Opens a file for buffered I/O. To allocate a buffer larger or smaller than the default buffer size (8K, defined as
	/// MMIO_DEFAULTBUFFER), set the cchBuffer member of the MMIOINFO structure to the desired buffer size. If cchBuffer is zero, the
	/// default buffer size is used. If you are providing your own I/O buffer, this flag should not be used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_COMPAT</term>
	/// <term>
	/// Opens the file with compatibility mode, allowing any process on a given machine to open the file any number of times. If the
	/// file has been opened with any of the other sharing modes, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_CREATE</term>
	/// <term>
	/// Creates a new file. If the file already exists, it is truncated to zero length. For memory files, this flag indicates the end of
	/// the file is initially at the start of the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DELETE</term>
	/// <term>
	/// Deletes a file. If this flag is specified, szFilename should not be NULL. The return value is TRUE (cast to HMMIO) if the file
	/// was deleted successfully or FALSE otherwise. Do not call the mmioClose function for a file that has been deleted. If this flag
	/// is specified, all other flags that open files are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DENYNONE</term>
	/// <term>
	/// Opens the file without denying other processes read or write access to the file. If the file has been opened in compatibility
	/// mode by any other process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DENYREAD</term>
	/// <term>
	/// Opens the file and denies other processes read access to the file. If the file has been opened in compatibility mode or for read
	/// access by any other process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DENYWRITE</term>
	/// <term>
	/// Opens the file and denies other processes write access to the file. If the file has been opened in compatibility mode or for
	/// write access by any other process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_EXCLUSIVE</term>
	/// <term>
	/// Opens the file and denies other processes read and write access to the file. If the file has been opened in any other mode for
	/// read or write access, even by the current process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_EXIST</term>
	/// <term>
	/// Determines whether the specified file exists and creates a fully qualified file name from the path specified in szFilename. The
	/// return value is TRUE (cast to HMMIO) if the qualification was successful and the file exists or FALSE otherwise. The file is not
	/// opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_GETTEMP</term>
	/// <term>
	/// Creates a temporary file name, optionally using the parameters passed in szFilename. For example, you can specify "C:F" to
	/// create a temporary file residing on drive C, starting with letter "F". The resulting file name is copied to the buffer pointed
	/// to by szFilename. The buffer must be large enough to hold at least 128 characters. If the temporary file name was created
	/// successfully, the return value is MMSYSERR_NOERROR (cast to HMMIO). Otherwise, the return value is MMIOERR_FILENOTFOUND
	/// otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt
	/// to close the file. This flag overrides all other flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_PARSE</term>
	/// <term>
	/// Creates a fully qualified file name from the path specified in szFilename. The fully qualified name is copied to the buffer
	/// pointed to by szFilename. The buffer must be large enough to hold at least 128 characters. If the function succeeds, the return
	/// value is TRUE (cast to HMMIO). Otherwise, the return value is FALSE. The file is not opened, and the function does not return a
	/// valid multimedia file I/O file handle, so do not attempt to close the file. If this flag is specified, all flags that open files
	/// are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_READ</term>
	/// <term>Opens the file for reading only. This is the default if MMIO_WRITE and MMIO_READWRITE are not specified.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_READWRITE</term>
	/// <term>Opens the file for reading and writing.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_WRITE</term>
	/// <term>Opens the file for writing only.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a handle of the opened file. If the file cannot be opened, the return value is <c>NULL</c>. If lpmmioinfo is not
	/// <c>NULL</c>, the <c>wErrorRet</c> member of the MMIOINFO structure will contain one of the following error values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_ACCESSDENIED</term>
	/// <term>The file is protected and cannot be opened.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_INVALIDFILE</term>
	/// <term>Another failure condition occurred. This is the default error for an open-file failure.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_NETWORKERROR</term>
	/// <term>The network is not responding to the request to open a remote file.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_PATHNOTFOUND</term>
	/// <term>The directory specification is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_SHARINGVIOLATION</term>
	/// <term>The file is being used by another application and is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_TOOMANYOPENFILES</term>
	/// <term>The number of files simultaneously open is at a maximum level. The system has run out of available file handles.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If lpmmioinfo points to an MMIOINFO structure, initialize the members of the structure as follows. All unused members must be
	/// set to zero, including reserved members.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To request that a file be opened with an installed I/O procedure, set <c>fccIOProc</c> to the four-character code of the I/O
	/// procedure, and set <c>pIOProc</c> to <c>NULL</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To request that a file be opened with an uninstalled I/O procedure, set IOProc to point to the I/O procedure, and set
	/// <c>fccIOProc</c> to <c>NULL</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To request that <c>mmioOpen</c> determine which I/O procedure to use to open the file based on the file name contained in
	/// szFilename, set <c>fccIOProc</c> and <c>pIOProc</c> to <c>NULL</c>. This is the default behavior if no MMIOINFO structure is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To open a memory file using an internally allocated and managed buffer, set <c>pchBuffer</c> to <c>NULL</c>, <c>fccIOProc</c> to
	/// FOURCC_MEM, <c>cchBuffer</c> to the initial size of the buffer, and <c>adwInfo</c> to the incremental expansion size of the
	/// buffer. This memory file will automatically be expanded in increments of the number of bytes specified in <c>adwInfo</c> when
	/// necessary. Specify the MMIO_CREATE flag for the dwOpenFlags parameter to initially set the end of the file to be the beginning
	/// of the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To open a memory file using an application-supplied buffer, set <c>pchBuffer</c> to point to the memory buffer, <c>fccIOProc</c>
	/// to FOURCC_MEM, <c>cchBuffer</c> to the size of the buffer, and <c>adwInfo</c> to the incremental expansion size of the buffer.
	/// The expansion size in <c>adwInfo</c> should be nonzero only if <c>pchBuffer</c> is a pointer obtained by calling the GlobalAlloc
	/// and GlobalLock functions; in this case, the GlobalReAlloc function will be called to expand the buffer. In other words, if
	/// <c>pchBuffer</c> points to a local or global array or a block of memory in the local heap, <c>adwInfo</c> must be zero. Specify
	/// the MMIO_CREATE flag for the dwOpenFlags parameter to initially set the end of the file to be the beginning of the buffer.
	/// Otherwise, the entire block of memory is considered readable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To use a currently open standard file handle (that is, a file handle that does not have the <c>HMMIO</c> type) with multimedia
	/// file I/O services, set <c>fccIOProc</c> to FOURCC_DOS, <c>pchBuffer</c> to <c>NULL</c>, and <c>adwInfo</c> to the standard file
	/// handle. Offsets within the file will be relative to the beginning of the file and are not related to the position in the
	/// standard file at the time <c>mmioOpen</c> is called; the initial multimedia file I/O offset will be the same as the offset in
	/// the standard file when <c>mmioOpen</c> is called. To close the multimedia file I/O file handle without closing the standard file
	/// handle, pass the MMIO_FHOPEN flag to mmioClose.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// You must call mmioClose to close a file opened by using <c>mmioOpen</c>. Open files are not automatically closed when an
	/// application exits.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioopen HMMIO mmioOpen( LPSTR pszFileName, LPMMIOINFO
	// pmmioinfo, DWORD fdwOpen );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioOpen")]
	public static extern HMMIO mmioOpen([In, Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? pszFileName, ref MMIOINFO pmmioinfo, MMIO fdwOpen);

	/// <summary>
	/// <para>
	/// The <c>mmioOpen</c> function opens a file for unbuffered or buffered I/O; creates a file; deletes a file; or checks whether a
	/// file exists. The file can be a standard file, a memory file, or an element of a custom storage system. The handle returned by
	/// mmioOpen is not a standard file handle; do not use it with any file I/O functions other than multimedia file I/O functions.
	/// </para>
	/// <para><c>Note</c> This function is deprecated. Applications should call CreateFile to create or open files.</para>
	/// </summary>
	/// <param name="pszFileName">
	/// <para>
	/// Pointer to a buffer that contains the name of the file. If no I/O procedure is specified to open the file, the file name
	/// determines how the file is opened, as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the file name does not contain a plus sign (+), it is assumed to be the name of a standard file (that is, a file whose type
	/// is not <c>HMMIO</c>).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the file name is of the form EXAMPLE.EXT+ABC, the extension EXT is assumed to identify an installed I/O procedure which is
	/// called to perform I/O on the file. For more information, see mmioInstallIOProc.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the file name is <c>NULL</c> and no I/O procedure is given, the <c>adwInfo</c> member of the MMIOINFO structure is assumed to
	/// be the standard (non- <c>HMMIO</c>) file handle of a currently open file.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The file name should not be longer than 128 characters, including the terminating NULL character.</para>
	/// <para>When opening a memory file, set szFilename to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pmmioinfo">
	/// Pointer to an MMIOINFO structure containing extra parameters used by <c>mmioOpen</c>. Unless you are opening a memory file,
	/// specifying the size of a buffer for buffered I/O, or specifying an uninstalled I/O procedure to open a file, this parameter
	/// should be <c>NULL</c>. If this parameter is not <c>NULL</c>, all unused members of the <c>MMIOINFO</c> structure it references
	/// must be set to zero, including the reserved members.
	/// </param>
	/// <param name="fdwOpen">
	/// <para>
	/// Flags for the open operation. The MMIO_READ, MMIO_WRITE, and MMIO_READWRITE flags are mutually exclusive – only one should be
	/// specified. The MMIO_COMPAT, MMIO_EXCLUSIVE, MMIO_DENYWRITE, MMIO_DENYREAD, and MMIO_DENYNONE flags are file-sharing flags. The
	/// following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_ALLOCBUF</term>
	/// <term>
	/// Opens a file for buffered I/O. To allocate a buffer larger or smaller than the default buffer size (8K, defined as
	/// MMIO_DEFAULTBUFFER), set the cchBuffer member of the MMIOINFO structure to the desired buffer size. If cchBuffer is zero, the
	/// default buffer size is used. If you are providing your own I/O buffer, this flag should not be used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_COMPAT</term>
	/// <term>
	/// Opens the file with compatibility mode, allowing any process on a given machine to open the file any number of times. If the
	/// file has been opened with any of the other sharing modes, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_CREATE</term>
	/// <term>
	/// Creates a new file. If the file already exists, it is truncated to zero length. For memory files, this flag indicates the end of
	/// the file is initially at the start of the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DELETE</term>
	/// <term>
	/// Deletes a file. If this flag is specified, szFilename should not be NULL. The return value is TRUE (cast to HMMIO) if the file
	/// was deleted successfully or FALSE otherwise. Do not call the mmioClose function for a file that has been deleted. If this flag
	/// is specified, all other flags that open files are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DENYNONE</term>
	/// <term>
	/// Opens the file without denying other processes read or write access to the file. If the file has been opened in compatibility
	/// mode by any other process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DENYREAD</term>
	/// <term>
	/// Opens the file and denies other processes read access to the file. If the file has been opened in compatibility mode or for read
	/// access by any other process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_DENYWRITE</term>
	/// <term>
	/// Opens the file and denies other processes write access to the file. If the file has been opened in compatibility mode or for
	/// write access by any other process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_EXCLUSIVE</term>
	/// <term>
	/// Opens the file and denies other processes read and write access to the file. If the file has been opened in any other mode for
	/// read or write access, even by the current process, mmioOpen fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_EXIST</term>
	/// <term>
	/// Determines whether the specified file exists and creates a fully qualified file name from the path specified in szFilename. The
	/// return value is TRUE (cast to HMMIO) if the qualification was successful and the file exists or FALSE otherwise. The file is not
	/// opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_GETTEMP</term>
	/// <term>
	/// Creates a temporary file name, optionally using the parameters passed in szFilename. For example, you can specify "C:F" to
	/// create a temporary file residing on drive C, starting with letter "F". The resulting file name is copied to the buffer pointed
	/// to by szFilename. The buffer must be large enough to hold at least 128 characters. If the temporary file name was created
	/// successfully, the return value is MMSYSERR_NOERROR (cast to HMMIO). Otherwise, the return value is MMIOERR_FILENOTFOUND
	/// otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt
	/// to close the file. This flag overrides all other flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_PARSE</term>
	/// <term>
	/// Creates a fully qualified file name from the path specified in szFilename. The fully qualified name is copied to the buffer
	/// pointed to by szFilename. The buffer must be large enough to hold at least 128 characters. If the function succeeds, the return
	/// value is TRUE (cast to HMMIO). Otherwise, the return value is FALSE. The file is not opened, and the function does not return a
	/// valid multimedia file I/O file handle, so do not attempt to close the file. If this flag is specified, all flags that open files
	/// are ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MMIO_READ</term>
	/// <term>Opens the file for reading only. This is the default if MMIO_WRITE and MMIO_READWRITE are not specified.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_READWRITE</term>
	/// <term>Opens the file for reading and writing.</term>
	/// </item>
	/// <item>
	/// <term>MMIO_WRITE</term>
	/// <term>Opens the file for writing only.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a handle of the opened file. If the file cannot be opened, the return value is <c>NULL</c>. If lpmmioinfo is not
	/// <c>NULL</c>, the <c>wErrorRet</c> member of the MMIOINFO structure will contain one of the following error values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_ACCESSDENIED</term>
	/// <term>The file is protected and cannot be opened.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_INVALIDFILE</term>
	/// <term>Another failure condition occurred. This is the default error for an open-file failure.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_NETWORKERROR</term>
	/// <term>The network is not responding to the request to open a remote file.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_PATHNOTFOUND</term>
	/// <term>The directory specification is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_SHARINGVIOLATION</term>
	/// <term>The file is being used by another application and is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_TOOMANYOPENFILES</term>
	/// <term>The number of files simultaneously open is at a maximum level. The system has run out of available file handles.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If lpmmioinfo points to an MMIOINFO structure, initialize the members of the structure as follows. All unused members must be
	/// set to zero, including reserved members.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To request that a file be opened with an installed I/O procedure, set <c>fccIOProc</c> to the four-character code of the I/O
	/// procedure, and set <c>pIOProc</c> to <c>NULL</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To request that a file be opened with an uninstalled I/O procedure, set IOProc to point to the I/O procedure, and set
	/// <c>fccIOProc</c> to <c>NULL</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To request that <c>mmioOpen</c> determine which I/O procedure to use to open the file based on the file name contained in
	/// szFilename, set <c>fccIOProc</c> and <c>pIOProc</c> to <c>NULL</c>. This is the default behavior if no MMIOINFO structure is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To open a memory file using an internally allocated and managed buffer, set <c>pchBuffer</c> to <c>NULL</c>, <c>fccIOProc</c> to
	/// FOURCC_MEM, <c>cchBuffer</c> to the initial size of the buffer, and <c>adwInfo</c> to the incremental expansion size of the
	/// buffer. This memory file will automatically be expanded in increments of the number of bytes specified in <c>adwInfo</c> when
	/// necessary. Specify the MMIO_CREATE flag for the dwOpenFlags parameter to initially set the end of the file to be the beginning
	/// of the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To open a memory file using an application-supplied buffer, set <c>pchBuffer</c> to point to the memory buffer, <c>fccIOProc</c>
	/// to FOURCC_MEM, <c>cchBuffer</c> to the size of the buffer, and <c>adwInfo</c> to the incremental expansion size of the buffer.
	/// The expansion size in <c>adwInfo</c> should be nonzero only if <c>pchBuffer</c> is a pointer obtained by calling the GlobalAlloc
	/// and GlobalLock functions; in this case, the GlobalReAlloc function will be called to expand the buffer. In other words, if
	/// <c>pchBuffer</c> points to a local or global array or a block of memory in the local heap, <c>adwInfo</c> must be zero. Specify
	/// the MMIO_CREATE flag for the dwOpenFlags parameter to initially set the end of the file to be the beginning of the buffer.
	/// Otherwise, the entire block of memory is considered readable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To use a currently open standard file handle (that is, a file handle that does not have the <c>HMMIO</c> type) with multimedia
	/// file I/O services, set <c>fccIOProc</c> to FOURCC_DOS, <c>pchBuffer</c> to <c>NULL</c>, and <c>adwInfo</c> to the standard file
	/// handle. Offsets within the file will be relative to the beginning of the file and are not related to the position in the
	/// standard file at the time <c>mmioOpen</c> is called; the initial multimedia file I/O offset will be the same as the offset in
	/// the standard file when <c>mmioOpen</c> is called. To close the multimedia file I/O file handle without closing the standard file
	/// handle, pass the MMIO_FHOPEN flag to mmioClose.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// You must call mmioClose to close a file opened by using <c>mmioOpen</c>. Open files are not automatically closed when an
	/// application exits.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioopen HMMIO mmioOpen( LPSTR pszFileName, LPMMIOINFO
	// pmmioinfo, DWORD fdwOpen );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioOpen")]
	public static extern HMMIO mmioOpen([In, Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? pszFileName, [In, Optional] IntPtr pmmioinfo, MMIO fdwOpen);

	/// <summary>The <c>mmioRead</c> function reads a specified number of bytes from a file opened by using the mmioOpen function.</summary>
	/// <param name="hmmio">File handle of the file to be read.</param>
	/// <param name="pch">Pointer to a buffer to contain the data read from the file.</param>
	/// <param name="cch">Number of bytes to read from the file.</param>
	/// <returns>
	/// Returns the number of bytes actually read. If the end of the file has been reached and no more bytes can be read, the return
	/// value is 0. If there is an error reading from the file, the return value is –1.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioread LONG mmioRead( HMMIO hmmio, HPSTR pch, LONG cch );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioRead")]
	public static extern int mmioRead(HMMIO hmmio, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pch, int cch);

	/// <summary>The <c>mmioRename</c> function renames the specified file.</summary>
	/// <param name="pszFileName">Pointer to a string containing the file name of the file to rename.</param>
	/// <param name="pszNewFileName">Pointer to a string containing the new file name.</param>
	/// <param name="pmmioinfo">
	/// Pointer to an MMIOINFO structure containing extra parameters used by <c>mmioRename</c>. If this parameter is not <c>NULL</c>,
	/// all unused members of the <c>MMIOINFO</c> structure it references must be set to zero, including the reserved members.
	/// </param>
	/// <param name="fdwRename">Flags for the rename operation. This parameter should be set to zero.</param>
	/// <returns>
	/// Returns zero if the file was renamed. Otherwise, returns an error code returned from <c>mmioRename</c> or from the I/O procedure.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiorename MMRESULT mmioRename( LPCSTR pszFileName,
	// LPCSTR pszNewFileName, const MMIOINFO *pmmioinfo, DWORD fdwRename );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioRename")]
	public static extern MMRESULT mmioRename([MarshalAs(UnmanagedType.LPTStr)] string pszFileName, [MarshalAs(UnmanagedType.LPTStr)] string pszNewFileName, in MMIOINFO pmmioinfo, uint fdwRename = 0);

	/// <summary>The <c>mmioRename</c> function renames the specified file.</summary>
	/// <param name="pszFileName">Pointer to a string containing the file name of the file to rename.</param>
	/// <param name="pszNewFileName">Pointer to a string containing the new file name.</param>
	/// <param name="pmmioinfo">
	/// Pointer to an MMIOINFO structure containing extra parameters used by <c>mmioRename</c>. If this parameter is not <c>NULL</c>,
	/// all unused members of the <c>MMIOINFO</c> structure it references must be set to zero, including the reserved members.
	/// </param>
	/// <param name="fdwRename">Flags for the rename operation. This parameter should be set to zero.</param>
	/// <returns>
	/// Returns zero if the file was renamed. Otherwise, returns an error code returned from <c>mmioRename</c> or from the I/O procedure.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiorename MMRESULT mmioRename( LPCSTR pszFileName,
	// LPCSTR pszNewFileName, const MMIOINFO *pmmioinfo, DWORD fdwRename );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioRename")]
	public static extern MMRESULT mmioRename([MarshalAs(UnmanagedType.LPTStr)] string pszFileName, [MarshalAs(UnmanagedType.LPTStr)] string pszNewFileName, [In, Optional] IntPtr pmmioinfo, uint fdwRename = 0);

	/// <summary>The <c>mmioSeek</c> function changes the current file position in a file opened by using the mmioOpen function.</summary>
	/// <param name="hmmio">File handle of the file to seek in.</param>
	/// <param name="lOffset">Offset to change the file position.</param>
	/// <param name="iOrigin">
	/// <para>Flags indicating how the offset specified by lOffset is interpreted. The following values are defined:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>SEEK_CUR</term>
	/// <term>Seeks to lOffset bytes from the current file position.</term>
	/// </item>
	/// <item>
	/// <term>SEEK_END</term>
	/// <term>Seeks to lOffset bytes from the end of the file.</term>
	/// </item>
	/// <item>
	/// <term>SEEK_SET</term>
	/// <term>Seeks to lOffset bytes from the beginning of the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns the new file position, in bytes, relative to the beginning of the file. If there is an error, the return value is –1.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Seeking to an invalid location in the file, such as past the end of the file, might not cause <c>mmioSeek</c> to return an
	/// error, but it might cause subsequent I/O operations on the file to fail.
	/// </para>
	/// <para>To locate the end of a file, call <c>mmioSeek</c> with lOffset set to zero and iOrigin set to SEEK_END.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmioseek LONG mmioSeek( HMMIO hmmio, LONG lOffset, int
	// iOrigin );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioSeek")]
	public static extern int mmioSeek(HMMIO hmmio, int lOffset, int iOrigin);

	/// <summary>The <c>mmioSendMessage</c> function sends a message to the I/O procedure associated with the specified file.</summary>
	/// <param name="hmmio">File handle for a file opened by using the mmioOpen function.</param>
	/// <param name="uMsg">Message to send to the I/O procedure.</param>
	/// <param name="lParam1">Parameter for the message.</param>
	/// <param name="lParam2">Parameter for the message.</param>
	/// <returns>
	/// Returns a value that corresponds to the message. If the I/O procedure does not recognize the message, the return value should be zero.
	/// </returns>
	/// <remarks>
	/// Use this function to send custom user-defined messages. Do not use it to send the MMIOM_OPEN, MMIOM_CLOSE, MMIOM_READ,
	/// MMIOM_WRITE, MMIOM_WRITEFLUSH, or MMIOM_SEEK messages. Define custom messages to be greater than or equal to the MMIOM_USER constant.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiosendmessage LRESULT mmioSendMessage( HMMIO hmmio,
	// UINT uMsg, LPARAM lParam1, LPARAM lParam2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioSendMessage")]
	public static extern IntPtr mmioSendMessage(HMMIO hmmio, uint uMsg, IntPtr lParam1, IntPtr lParam2);

	/// <summary>
	/// The <c>mmioSetBuffer</c> function enables or disables buffered I/O, or changes the buffer or buffer size for a file opened by
	/// using the mmioOpen function.
	/// </summary>
	/// <param name="hmmio">File handle of the file.</param>
	/// <param name="pchBuffer">
	/// Pointer to an application-defined buffer to use for buffered I/O. If this parameter is <c>NULL</c>, <c>mmioSetBuffer</c>
	/// allocates an internal buffer for buffered I/O.
	/// </param>
	/// <param name="cchBuffer">
	/// Size, in characters, of the application-defined buffer, or the size of the buffer for <c>mmioSetBuffer</c> to allocate.
	/// </param>
	/// <param name="fuBuffer">Reserved; must be zero.</param>
	/// <returns>
	/// <para>
	/// Returns zero if successful or an error otherwise. If an error occurs, the file handle remains valid. The following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMIOERR_CANNOTWRITE</term>
	/// <term>The contents of the old buffer could not be written to disk, so the operation was aborted.</term>
	/// </item>
	/// <item>
	/// <term>MMIOERR_OUTOFMEMORY</term>
	/// <term>The new buffer could not be allocated, probably due to a lack of available memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>To enable buffering using an internal buffer, set pchBuffer to <c>NULL</c> and cchBuffer to the desired buffer size.</para>
	/// <para>To supply your own buffer, set pchBuffer to point to the buffer, and set cchBuffer to the size of the buffer.</para>
	/// <para>To disable buffered I/O, set pchBuffer to <c>NULL</c> and cchBuffer to zero.</para>
	/// <para>
	/// If buffered I/O is already enabled using an internal buffer, you can reallocate the buffer to a different size by setting
	/// pchBuffer to <c>NULL</c> and cchBuffer to the new buffer size. The contents of the buffer can be changed after resizing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiosetbuffer MMRESULT mmioSetBuffer( HMMIO hmmio, LPSTR
	// pchBuffer, LONG cchBuffer, UINT fuBuffer );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioSetBuffer")]
	public static extern MMRESULT mmioSetBuffer(HMMIO hmmio, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder? pchBuffer, int cchBuffer, uint fuBuffer = 0);

	/// <summary>
	/// The <c>mmioSetInfo</c> function updates the information retrieved by the mmioGetInfo function about a file opened by using the
	/// mmioOpen function. Use this function to terminate direct buffer access of a file opened for buffered I/O.
	/// </summary>
	/// <param name="hmmio">File handle of the file.</param>
	/// <param name="pmmioinfo">Pointer to an MMIOINFO structure filled with information by the mmioGetInfo function.</param>
	/// <param name="fuInfo">Reserved; must be zero.</param>
	/// <returns>Returns zero if successful or an error otherwise.</returns>
	/// <remarks>
	/// If you have written to the file I/O buffer, set the MMIO_DIRTY flag in the <c>dwFlags</c> member of the MMIOINFO structure
	/// before calling <c>mmioSetInfo</c> to terminate direct buffer access. Otherwise, the buffer will not get flushed to disk.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiosetinfo MMRESULT mmioSetInfo( HMMIO hmmio,
	// LPCMMIOINFO pmmioinfo, UINT fuInfo );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioSetInfo")]
	public static extern MMRESULT mmioSetInfo(HMMIO hmmio, in MMIOINFO pmmioinfo, uint fuInfo = 0);

	/// <summary>The <c>mmioStringToFOURCC</c> function converts a null-terminated string to a four-character code.</summary>
	/// <param name="sz">Pointer to a null-terminated string to convert to a four-character code.</param>
	/// <param name="uFlags">
	/// <para>Flags for the conversion. The following value is defined:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MMIO_TOUPPER</term>
	/// <term>Converts all characters to uppercase.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns the four-character code created from the given string.</returns>
	/// <remarks>
	/// This function copies the string to a four-character code and pads it with space characters or truncates it if necessary. It does
	/// not check whether the code it returns is valid.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiostringtofourcc FOURCC mmioStringToFOURCC( LPCSTR sz,
	// UINT uFlags );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioStringToFOURCC")]
	public static extern uint mmioStringToFOURCC([MarshalAs(UnmanagedType.LPTStr)] string sz, MMIOCONV uFlags);

	/// <summary>The <c>mmioWrite</c> function writes a specified number of bytes to a file opened by using the mmioOpen function.</summary>
	/// <param name="hmmio">File handle of the file.</param>
	/// <param name="pch">Pointer to the buffer to be written to the file.</param>
	/// <param name="cch">Number of bytes to write to the file.</param>
	/// <returns>Returns the number of bytes actually written. If there is an error writing to the file, the return value is -1.</returns>
	/// <remarks>The current file position is incremented by the number of bytes written.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-mmiowrite LONG mmioWrite( HMMIO hmmio, const char _huge
	// *pch, LONG cch );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.mmioWrite")]
	public static extern int mmioWrite(HMMIO hmmio, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pch, int cch);

	/// <summary>
	/// Opens an instance of an installable driver and initializes the instance using either the driver's default settings or a
	/// driver-specific value.
	/// </summary>
	/// <param name="szDriverName">
	/// Address of a null-terminated, wide-character string that specifies the filename of an installable driver or the name of a
	/// registry value associated with the installable driver. (This value must have been previously set when the driver was installed.)
	/// </param>
	/// <param name="szSectionName">
	/// Address of a null-terminated, wide-character string that specifies the name of the registry key containing the registry value
	/// given by the lpDriverName parameter. If lpSectionName is <c>NULL</c>, the registry key is assumed to be <c>Drivers32</c>.
	/// </param>
	/// <param name="lParam2">
	/// 32-bit driver-specific value. This value is passed as the lParam2 parameter to the DriverProc function of the installable driver.
	/// </param>
	/// <returns>Returns the handle of the installable driver instance if successful or <c>NULL</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-opendriver HDRVR OpenDriver( LPCWSTR szDriverName,
	// LPCWSTR szSectionName, LPARAM lParam2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.OpenDriver")]
	public static extern SafeHDRVR OpenDriver([MarshalAs(UnmanagedType.LPWStr)] string szDriverName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? szSectionName, [In, Optional] IntPtr lParam2);

	/// <summary>Sends the specified message to the installable driver.</summary>
	/// <param name="hDriver">
	/// Handle of the installable driver instance. The handle must been previously created by using the OpenDriver function.
	/// </param>
	/// <param name="message">
	/// <para>Driver message value. It can be a custom message value or one of these standard message values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DRV_QUERYCONFIGURE</term>
	/// <term>
	/// Queries an installable driver about whether it supports the DRV_CONFIGURE message and can display a configuration dialog box.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DRV_CONFIGURE</term>
	/// <term>
	/// Notifies an installable driver that it should display a configuration dialog box. (This message should only be sent if the
	/// driver returns a nonzero value when the DRV_QUERYCONFIGURE message is processed.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>DRV_INSTALL</term>
	/// <term>Notifies an installable driver that it has been successfully installed.</term>
	/// </item>
	/// <item>
	/// <term>DRV_REMOVE</term>
	/// <term>Notifies an installable driver that it is about to be removed from the system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lParam1">32-bit message-dependent information.</param>
	/// <param name="lParam2">32-bit message-dependent information.</param>
	/// <returns>Returns nonzero if successful or zero otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-senddrivermessage LRESULT SendDriverMessage( HDRVR
	// hDriver, UINT message, LPARAM lParam1, LPARAM lParam2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.SendDriverMessage")]
	public static extern IntPtr SendDriverMessage(HDRVR hDriver, DRV message, IntPtr lParam1, IntPtr lParam2);

	/// <summary>Opens the specified sound event.</summary>
	/// <param name="EventName">The name of the sound event.</param>
	/// <param name="AppName">The application associated with the sound event.</param>
	/// <param name="Flags">Flags for playing the sound. The following values are defined.</param>
	/// <param name="FileHandle">Receives the handle to the sound.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/nf-mmiscapi-sndopensound LONG sndOpenSound( LPCWSTR EventName,
	// LPCWSTR AppName, INT32 Flags, PHANDLE FileHandle );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmiscapi.h", MSDNShortId = "NF:mmiscapi.sndOpenSound")]
	public static extern int sndOpenSound([MarshalAs(UnmanagedType.LPWStr)] string EventName, [MarshalAs(UnmanagedType.LPWStr)] string AppName, int Flags, out IntPtr FileHandle);

	/// <summary>Contains the registry key and value names associated with the installable driver.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/ns-mmiscapi-drvconfiginfo typedef struct tagDRVCONFIGINFO { DWORD
	// dwDCISize; LPCWSTR lpszDCISectionName; LPCWSTR lpszDCIAliasName; } DRVCONFIGINFO, *PDRVCONFIGINFO, *NPDRVCONFIGINFO, *LPDRVCONFIGINFO;
	[PInvokeData("mmiscapi.h", MSDNShortId = "NS:mmiscapi.tagDRVCONFIGINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRVCONFIGINFO
	{
		/// <summary>Size of the structure, in bytes.</summary>
		public uint dwDCISize;

		/// <summary>
		/// Address of a null-terminated, wide-character string specifying the name of the registry key associated with the driver.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszDCISectionName;

		/// <summary>
		/// Address of a null-terminated, wide-character string specifying the name of the registry value associated with the driver.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszDCIAliasName;
	}

	/// <summary>The <c>MMCKINFO</c> structure contains information about a chunk in a RIFF file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmiscapi/ns-mmiscapi-mmckinfo typedef struct _MMCKINFO { FOURCC ckid; DWORD
	// cksize; FOURCC fccType; DWORD dwDataOffset; DWORD dwFlags; } MMCKINFO, *PMMCKINFO, *NPMMCKINFO, *LPMMCKINFO;
	[PInvokeData("mmiscapi.h", MSDNShortId = "NS:mmiscapi._MMCKINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MMCKINFO
	{
		/// <summary>Chunk identifier.</summary>
		public uint ckid;

		/// <summary>
		/// Size, in bytes, of the data member of the chunk. The size of the data member does not include the 4-byte chunk identifier,
		/// the 4-byte chunk size, or the optional pad byte at the end of the data member.
		/// </summary>
		public uint cksize;

		/// <summary>Form type for "RIFF" chunks or the list type for "LIST" chunks.</summary>
		public uint fccType;

		/// <summary>File offset of the beginning of the chunk's data member, relative to the beginning of the file.</summary>
		public uint dwDataOffset;

		/// <summary>
		/// <para>Flags specifying additional information about the chunk. It can be zero or the following flag:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMIO_DIRTY</term>
		/// <term>
		/// The length of the chunk might have changed and should be updated by the mmioAscend function. This flag is set when a chunk
		/// is created by using the mmioCreateChunk function.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public MMIO dwFlags;
	}

	/// <summary>The <c>MMIOINFO</c> structure contains the current state of a file opened by using the <c>mmioOpen</c> function.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/dd757322(v=vs.85) typedef struct { DWORD dwFlags; FOURCC fccIOProc; LPMMIOPROC
	// pIOProc; UINT wErrorRet; HTASK hTask; LONG cchBuffer; HPSTR pchBuffer; HPSTR pchNext; HPSTR pchEndRead; HPSTR pchEndWrite; LONG
	// lBufOffset; LONG lDiskOffset; DWORD adwInfo[4]; DWORD dwReserved1; DWORD dwReserved2; HMMIO hmmio; } MMIOINFO;
	[PInvokeData("Mmsystem.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct MMIOINFO
	{
		/// <summary>Flags specifying how a file was opened.</summary>
		public MMIO dwFlags;

		/// <summary>
		/// Four-character code identifying the file's I/O procedure. If the I/O procedure is not an installed I/O procedure, this
		/// member is NULL.
		/// </summary>
		public uint fccIOProc;

		/// <summary>Pointer to file's IO procedure.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public MMIOPROC pIOProc;

		/// <summary>
		/// Extended error value from the mmioOpen function if it returns NULL. This member is not used to return extended error
		/// information from any other functions.
		/// </summary>
		public uint wErrorRet;

		/// <summary>
		/// Handle to a local I/O procedure. Media Control Interface (MCI) devices that perform file I/O in the background and need an
		/// I/O procedure can locate a local I/O procedure with this handle.
		/// </summary>
		public HTASK hTask;

		/// <summary>Size, in bytes, of the file's I/O buffer. If the file does not have an I/O buffer, this member is zero.</summary>
		public int cchBuffer;

		/// <summary>Pointer to the file's I/O buffer. If the file is unbuffered, this member is NULL.</summary>
		public LPSTR pchBuffer;

		/// <summary>
		/// Pointer to the next location in the I/O buffer to be read or written. If no more bytes can be read without calling the
		/// mmioAdvance or mmioRead function, this member points to the pchEndRead member. If no more bytes can be written without
		/// calling the mmioAdvance or mmioWrite function, this member points to the pchEndWrite member.
		/// </summary>
		public LPSTR pchNext;

		/// <summary>Pointer to the location that is 1 byte past the last location in the buffer that can be read.</summary>
		public LPSTR pchEndRead;

		/// <summary>Pointer to the location that is 1 byte past the last location in the buffer that can be written.</summary>
		public LPSTR pchEndWrite;

		/// <summary>Reserved.</summary>
		public int lBufOffset;

		/// <summary>
		/// Current file position, which is an offset, in bytes, from the beginning of the file. I/O procedures are responsible for
		/// maintaining this member.
		/// </summary>
		public int lDiskOffset;

		/// <summary>
		/// State information maintained by the I/O procedure. I/O procedures can also use these members to transfer information from
		/// the application to the I/O procedure when the application opens a file.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public uint[] adwInfo;

		/// <summary>Reserved.</summary>
		public uint dwReserved1;

		/// <summary>Reserved.</summary>
		public uint dwReserved2;

		/// <summary>
		/// Handle to the open file, as returned by the mmioOpen function. I/O procedures can use this handle when calling other
		/// multimedia file I/O functions.
		/// </summary>
		public HMMIO hmmio;
	}
}