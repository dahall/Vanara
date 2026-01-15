using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>110 bps</summary>
	public const uint BR_110 = 110;

	/// <summary>115200 bps</summary>
	public const uint CBR_115200 = 115200;

	/// <summary>1200 bps</summary>
	public const uint CBR_1200 = 1200;

	/// <summary>128000 bps</summary>
	public const uint CBR_128000 = 128000;

	/// <summary>14400 bps</summary>
	public const uint CBR_14400 = 14400;

	/// <summary>19200 bps</summary>
	public const uint CBR_19200 = 19200;

	/// <summary>2400 bps</summary>
	public const uint CBR_2400 = 2400;

	/// <summary>256000 bps</summary>
	public const uint CBR_256000 = 256000;

	/// <summary>300 bps</summary>
	public const uint CBR_300 = 300;

	/// <summary>38400 bps</summary>
	public const uint CBR_38400 = 38400;

	/// <summary>4800 bps</summary>
	public const uint CBR_4800 = 4800;

	/// <summary>57600 bps</summary>
	public const uint CBR_57600 = 57600;

	/// <summary>600 bps</summary>
	public const uint CBR_600 = 600;

	/// <summary>9600 bps</summary>
	public const uint CBR_9600 = 9600;

	/// <summary>A mask indicating the type of error.</summary>
	[Flags]
	public enum COMM_ERRS : uint
	{
		/// <summary>The hardware detected a break condition.</summary>
		CE_BREAK = 0x0010,

		/// <summary>The hardware detected a framing error.</summary>
		CE_FRAME = 0x0008,

		/// <summary>A character-buffer overrun has occurred. The next character is lost.</summary>
		CE_OVERRUN = 0x0002,

		/// <summary>
		/// An input buffer overflow has occurred. There is either no room in the input buffer, or a character was received after the
		/// end-of-file (EOF) character.
		/// </summary>
		CE_RXOVER = 0x0001,

		/// <summary>The hardware detected a parity error.</summary>
		CE_RXPARITY = 0x0004,

		/// <summary>Undocumented.</summary>
		CE_TXFULL = 0x0100,

		/// <summary>Undocumented.</summary>
		CE_PTO = 0x0200,

		/// <summary>Undocumented.</summary>
		CE_IOE = 0x0400,

		/// <summary>Undocumented.</summary>
		CE_DNS = 0x0800,

		/// <summary>Undocumented.</summary>
		CE_OOP = 0x1000,

		/// <summary>Undocumented.</summary>
		CE_MODE = 0x8000,
	}

	/// <summary>The extended function to be performed.</summary>
	public enum COMM_ESC_FUNC
	{
		/// <summary>
		/// Restores character transmission and places the transmission line in a nonbreak state. The CLRBREAK extended function code is
		/// identical to the ClearCommBreak function.
		/// </summary>
		CLRBREAK = 9,

		/// <summary>Clears the DTR (data-terminal-ready) signal.</summary>
		CLRDTR = 6,

		/// <summary>Clears the RTS (request-to-send) signal.</summary>
		CLRRTS = 4,

		/// <summary>
		/// Suspends character transmission and places the transmission line in a break state until the ClearCommBreak function is called
		/// (or EscapeCommFunction is called with the CLRBREAK extended function code). The SETBREAK extended function code is identical
		/// to the SetCommBreak function. Note that this extended function does not flush data that has not been transmitted.
		/// </summary>
		SETBREAK = 8,

		/// <summary>Sends the DTR (data-terminal-ready) signal.</summary>
		SETDTR = 5,

		/// <summary>Sends the RTS (request-to-send) signal.</summary>
		SETRTS = 3,

		/// <summary>Causes transmission to act as if an XOFF character has been received.</summary>
		SETXOFF = 1,

		/// <summary>Causes transmission to act as if an XON character has been received.</summary>
		SETXON = 2,
	}

	/// <summary>A mask of events that are currently enabled.</summary>
	[Flags]
	public enum COMM_EVT_MASK : uint
	{
		/// <summary>A break was detected on input.</summary>
		EV_BREAK = 0x0040,

		/// <summary>The CTS (clear-to-send) signal changed state.</summary>
		EV_CTS = 0x0008,

		/// <summary>The DSR (data-set-ready) signal changed state.</summary>
		EV_DSR = 0x0010,

		/// <summary>A line-status error occurred. Line-status errors are CE_FRAME, CE_OVERRUN, and CE_RXPARITY.</summary>
		EV_ERR = 0x0080,

		/// <summary>An event of the first provider-specific type occurred.</summary>
		EV_EVENT1 = 0x0800,

		/// <summary>An event of the second provider-specific type occurred.</summary>
		EV_EVENT2 = 0x1000,

		/// <summary>A printer error occurred.</summary>
		EV_PERR = 0x0200,

		/// <summary>A ring indicator was detected.</summary>
		EV_RING = 0x0100,

		/// <summary>The RLSD (receive-line-signal-detect) signal changed state.</summary>
		EV_RLSD = 0x0020,

		/// <summary>The receive buffer is 80 percent full.</summary>
		EV_RX80FULL = 0x0400,

		/// <summary>A character was received and placed in the input buffer.</summary>
		EV_RXCHAR = 0x0001,

		/// <summary>
		/// The event character was received and placed in the input buffer. The event character is specified in the device's DCB
		/// structure, which is applied to a serial port by using the SetCommState function.
		/// </summary>
		EV_RXFLAG = 0x0002,

		/// <summary>The last character in the output buffer was sent.</summary>
		EV_TXEMPTY = 0x0004,
	}

	/// <summary>The current state of the modem control-register values.</summary>
	[Flags]
	public enum COMM_MODEM_STATUS : uint
	{
		/// <summary>The CTS (clear-to-send) signal is on.</summary>
		MS_CTS_ON = 0x0010,

		/// <summary>The DSR (data-set-ready) signal is on.</summary>
		MS_DSR_ON = 0x0020,

		/// <summary>The ring indicator signal is on.</summary>
		MS_RING_ON = 0x0040,

		/// <summary>The RLSD (receive-line-signal-detect) signal is on.</summary>
		MS_RLSD_ON = 0x0080,
	}

	/// <summary>PurgeComm flags</summary>
	[Flags]
	public enum COMM_PURGE
	{
		/// <summary>
		/// Terminates all outstanding overlapped read operations and returns immediately, even if the read operations have not been completed.
		/// </summary>
		PURGE_RXABORT = 0x0002,

		/// <summary>Clears the input buffer (if the device driver has one).</summary>
		PURGE_RXCLEAR = 0x0008,

		/// <summary>
		/// Terminates all outstanding overlapped write operations and returns immediately, even if the write operations have not been completed.
		/// </summary>
		PURGE_TXABORT = 0x0001,

		/// <summary>Clears the output buffer (if the device driver has one).</summary>
		PURGE_TXCLEAR = 0x0004,
	}

	/// <summary/>
	[Flags]
	public enum COMM_SET_DATA : ushort
	{
		/// <summary>5 data bits</summary>
		DATABITS_5 = 0x0001,

		/// <summary>6 data bits</summary>
		DATABITS_6 = 0x0002,

		/// <summary>7 data bits</summary>
		DATABITS_7 = 0x0004,

		/// <summary>8 data bits</summary>
		DATABITS_8 = 0x0008,

		/// <summary>16 data bits</summary>
		DATABITS_16 = 0x0010,

		/// <summary>Special wide path through serial hardware lines</summary>
		DATABITS_16X = 0x0020,
	}

	/// <summary/>
	[Flags]
	public enum COMM_SET_PARAMS : uint
	{
		/// <summary>Baud rate</summary>
		SP_BAUD = 0x0002,

		/// <summary>Data bits</summary>
		SP_DATABITS = 0x0004,

		/// <summary>Handshaking (flow control)</summary>
		SP_HANDSHAKING = 0x0010,

		/// <summary>Parity</summary>
		SP_PARITY = 0x0001,

		/// <summary>Parity checking</summary>
		SP_PARITY_CHECK = 0x0020,

		/// <summary>RLSD (receive-line-signal-detect)</summary>
		SP_RLSD = 0x0040,

		/// <summary>Stop bits</summary>
		SP_STOPBITS = 0x0008,
	}

	/// <summary/>
	[Flags]
	public enum COMM_STOP_PARITY : ushort
	{
		/// <summary>1 stop bit</summary>
		STOPBITS_10 = 0x0001,

		/// <summary>1.5 stop bits</summary>
		STOPBITS_15 = 0x0002,

		/// <summary>2 stop bits</summary>
		STOPBITS_20 = 0x0004,

		/// <summary>No parity</summary>
		PARITY_NONE = 0x0100,

		/// <summary>Odd parity</summary>
		PARITY_ODD = 0x0200,

		/// <summary>Even parity</summary>
		PARITY_EVEN = 0x0400,

		/// <summary>Mark parity</summary>
		PARITY_MARK = 0x0800,

		/// <summary>Space parity</summary>
		PARITY_SPACE = 0x1000,
	}

	/// <summary>The DTR (data-terminal-ready) flow control.</summary>
	public enum DTR_CONTROL
	{
		/// <summary>Disables the DTR line when the device is opened and leaves it disabled.</summary>
		DTR_CONTROL_DISABLE = 0x00,

		/// <summary>Enables the DTR line when the device is opened and leaves it on.</summary>
		DTR_CONTROL_ENABLE = 0x01,

		/// <summary>
		/// Enables DTR handshaking. If handshaking is enabled, it is an error for the application to adjust the line by using the
		/// EscapeCommFunction function.
		/// </summary>
		DTR_CONTROL_HANDSHAKE = 0x02,
	}

	/// <summary>Parity scheme for comm settings.</summary>
	public enum Parity : byte
	{
		/// <summary>Even parity.</summary>
		EVENPARITY = 2,

		/// <summary>Mark parity.</summary>
		MARKPARITY = 3,

		/// <summary>No parity.</summary>
		NOPARITY = 0,

		/// <summary>Odd parity.</summary>
		ODDPARITY = 1,

		/// <summary>Space parity.</summary>
		SPACEPARITY = 4,
	}

	/// <summary>A bitmask indicating the capabilities offered by the provider.</summary>
	[Flags]
	public enum PROV_CAPABILITIES : uint
	{
		/// <summary>Special 16-bit mode supported</summary>
		PCF_16BITMODE = 0x0200,

		/// <summary>DTR (data-terminal-ready)/DSR (data-set-ready) supported</summary>
		PCF_DTRDSR = 0x0001,

		/// <summary>Interval time-outs supported</summary>
		PCF_INTTIMEOUTS = 0x0080,

		/// <summary>Parity checking supported</summary>
		PCF_PARITY_CHECK = 0x0008,

		/// <summary>RLSD (receive-line-signal-detect) supported</summary>
		PCF_RLSD = 0x0004,

		/// <summary>RTS (request-to-send)/CTS (clear-to-send) supported</summary>
		PCF_RTSCTS = 0x0002,

		/// <summary>Settable XON/XOFF supported</summary>
		PCF_SETXCHAR = 0x0020,

		/// <summary>Special character support provided</summary>
		PCF_SPECIALCHARS = 0x0100,

		/// <summary>The total (elapsed) time-outs supported</summary>
		PCF_TOTALTIMEOUTS = 0x0040,

		/// <summary>XON/XOFF flow control supported</summary>
		PCF_XONXOFF = 0x0010,
	}

	/// <summary>The type of communications provider</summary>
	public enum PROV_SUB_TYPE : uint
	{
		/// <summary>FAX device</summary>
		PST_FAX = 0x00000021,

		/// <summary>LAT protocol</summary>
		PST_LAT = 0x00000101,

		/// <summary>Modem device</summary>
		PST_MODEM = 0x00000006,

		/// <summary>Unspecified network bridge</summary>
		PST_NETWORK_BRIDGE = 0x00000100,

		/// <summary>Parallel port</summary>
		PST_PARALLELPORT = 0x00000002,

		/// <summary>RS-232 serial port</summary>
		PST_RS232 = 0x00000001,

		/// <summary>RS-422 port</summary>
		PST_RS422 = 0x00000003,

		/// <summary>RS-423 port</summary>
		PST_RS423 = 0x00000004,

		/// <summary>RS-449 port</summary>
		PST_RS449 = 0x00000005,

		/// <summary>Scanner device</summary>
		PST_SCANNER = 0x00000022,

		/// <summary>TCP/IP Telnet protocol</summary>
		PST_TCPIP_TELNET = 0x00000102,

		/// <summary>Unspecified</summary>
		PST_UNSPECIFIED = 0x00000000,

		/// <summary>X.25 standards</summary>
		PST_X25 = 0x00000103,
	}

	/// <summary>The DTR (data-terminal-ready) flow control.</summary>
	public enum RTS_CONTROL
	{
		/// <summary>Disables the RTS line when the device is opened and leaves it disabled.</summary>
		RTS_CONTROL_DISABLE = 0x00,

		/// <summary>Enables the RTS line when the device is opened and leaves it on.</summary>
		RTS_CONTROL_ENABLE = 0x01,

		/// <summary>
		/// Enables RTS handshaking. The driver raises the RTS line when the "type-ahead" (input) buffer is less than one-half full and
		/// lowers the RTS line when the buffer is more than three-quarters full. If handshaking is enabled, it is an error for the
		/// application to adjust the line by using the EscapeCommFunction function.
		/// </summary>
		RTS_CONTROL_HANDSHAKE = 0x02,

		/// <summary>
		/// Specifies that the RTS line will be high if bytes are available for transmission. After all buffered bytes have been sent,
		/// the RTS line will be low.
		/// </summary>
		RTS_CONTROL_TOGGLE = 0x03,
	}

	/// <summary>Stop bits for comm settings.</summary>
	public enum StopBits : byte
	{
		/// <summary>1 stop bit.</summary>
		ONESTOPBIT = 0,

		/// <summary>1.5 stop bits.</summary>
		ONE5STOPBITS = 1,

		/// <summary>2 stop bits.</summary>
		TWOSTOPBITS = 2,
	}

	/// <summary>
	/// Fills a specified <c>DCB</c> structure with values specified in a device-control string. The device-control string uses the
	/// syntax of the <c>mode</c> command.
	/// </summary>
	/// <param name="lpDef">
	/// <para>
	/// The device-control information. The function takes this string, parses it, and then sets appropriate values in the <c>DCB</c>
	/// structure pointed to by lpDCB.
	/// </para>
	/// <para>The string must have the same form as the <c>mode</c> command's command-line arguments:</para>
	/// <para>COMx[:][baud=b][parity=p][data=d][stop=s][to={on|off}][xon={on|off}][odsr={on|off}][octs={on|off}][dtr={on|off|hs}][rts={on|off|hs|tg}][idsr={on|off}]</para>
	/// <para>The device name is optional, but it must specify a valid device if used.</para>
	/// <para>For example, the following string specifies a baud rate of 1200, no parity, 8 data bits, and 1 stop bit:</para>
	/// </param>
	/// <param name="lpDCB">A pointer to a <c>DCB</c> structure that receives the information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI BuildCommDCB( _In_ LPCTSTR lpDef, _Out_ LPDCB lpDCB); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363143(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363143")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BuildCommDCB(string lpDef, out DCB lpDCB);

	/// <summary>
	/// Translates a device-definition string into appropriate device-control block codes and places them into a device control block.
	/// The function can also set up time-out values, including the possibility of no time-outs, for a device; the function's behavior in
	/// this regard depends on the contents of the device-definition string.
	/// </summary>
	/// <param name="lpDef">
	/// <para>
	/// The device-control information. The function takes this string, parses it, and then sets appropriate values in the <c>DCB</c>
	/// structure pointed to by lpDCB.
	/// </para>
	/// <para>The string must have the same form as the <c>mode</c> command's command-line arguments:</para>
	/// <para>
	/// <c>COM</c> x[ <c>:</c>][ <c>baud=</c>{ <c>11</c>| <c>110</c>| <c>15</c>| <c>150</c>| <c>30</c>| <c>300</c>| <c>60</c>|
	/// <c>600</c>| <c>12</c>| <c>1200</c>| <c>24</c>| <c>2400</c>| <c>48</c>| <c>4800</c>| <c>96</c>| <c>9600</c>| <c>19</c>|
	/// <c>19200</c>}][ <c>parity=</c>{ <c>n</c>| <c>e</c>| <c>o</c>| <c>m</c>| <c>s</c>}][ <c>data=</c>{ <c>5</c>| <c>6</c>| <c>7</c>|
	/// <c>8</c>}][ <c>stop=</c>{ <c>1</c>| <c>1.5</c>| <c>2</c>}][ <c>to=</c>{ <c>on</c>| <c>off</c>}][ <c>xon=</c>{ <c>on</c>|
	/// <c>off</c>}][ <c>odsr=</c>{ <c>on</c>| <c>off</c>}][ <c>octs=</c>{ <c>on</c>| <c>off</c>}][ <c>dtr=</c>{ <c>on</c>| <c>off</c>|
	/// <c>hs</c>}][ <c>rts=</c>{ <c>on</c>| <c>off</c>| <c>hs</c>| <c>tg</c>}][ <c>idsr=</c>{ <c>on</c>| <c>off</c>}]
	/// </para>
	/// <para>
	/// The "baud" substring can be any of the values listed, which are in pairs. The two-digit values are the first two digits of the
	/// associated values that they represent. For example, 11 represents 110 baud, 19 represents 19,200 baud.
	/// </para>
	/// <para>
	/// The "parity" substring indicates how the parity bit is used to detect transmission errors. The values represent "none", "even",
	/// "odd", "mark", and "space".
	/// </para>
	/// <para>For more information, see the Mode command reference in TechNet.</para>
	/// <para>For example, the following string specifies a baud rate of 1200, no parity, 8 data bits, and 1 stop bit:</para>
	/// </param>
	/// <param name="lpDCB">
	/// A pointer to a <c>DCB</c> structure that receives information from the device-control information string pointed to by lpDef.
	/// This <c>DCB</c> structure defines the control settings for a communications device.
	/// </param>
	/// <param name="lpCommTimeouts">A pointer to a <c>COMMTIMEOUTS</c> structure that receives time-out information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI BuildCommDCBAndTimeouts( _In_ LPCTSTR lpDef, _Out_ LPDCB lpDCB, _Out_ LPCOMMTIMEOUTS lpCommTimeouts); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363145(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363145")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BuildCommDCBAndTimeouts(string lpDef, out DCB lpDCB, out COMMTIMEOUTS lpCommTimeouts);

	/// <summary>
	/// Restores character transmission for a specified communications device and places the transmission line in a nonbreak state.
	/// </summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI ClearCommBreak( _In_ HANDLE hFile); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363179(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363179")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ClearCommBreak([In] HFILE hFile);

	/// <summary>
	/// Retrieves information about a communications error and reports the current status of a communications device. The function is
	/// called when a communications error occurs, and it clears the device's error flag to enable additional input and output (I/O) operations.
	/// </summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpErrors">
	/// <para>
	/// A pointer to a variable that receives a mask indicating the type of error. This parameter can be one or more of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CE_BREAK0x0010</term>
	/// <term>The hardware detected a break condition.</term>
	/// </item>
	/// <item>
	/// <term>CE_FRAME0x0008</term>
	/// <term>The hardware detected a framing error.</term>
	/// </item>
	/// <item>
	/// <term>CE_OVERRUN0x0002</term>
	/// <term>A character-buffer overrun has occurred. The next character is lost.</term>
	/// </item>
	/// <item>
	/// <term>CE_RXOVER0x0001</term>
	/// <term>
	/// An input buffer overflow has occurred. There is either no room in the input buffer, or a character was received after the
	/// end-of-file (EOF) character.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CE_RXPARITY0x0004</term>
	/// <term>The hardware detected a parity error.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>The following values are not supported:</para>
	/// </param>
	/// <param name="lpStat">
	/// A pointer to a <c>COMSTAT</c> structure in which the device's status information is returned. If this parameter is <c>NULL</c>,
	/// no status information is returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI ClearCommError( _In_ HANDLE hFile, _Out_opt_ LPDWORD lpErrors, _Out_opt_ LPCOMSTAT lpStat); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363180(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363180")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ClearCommError([In] HFILE hFile, out COMM_ERRS lpErrors, out COMSTAT lpStat);

	/// <summary>Displays a driver-supplied configuration dialog box.</summary>
	/// <param name="lpszName">
	/// The name of the device for which a dialog box should be displayed. For example, COM1 through COM9 are serial ports and LPT1
	/// through LPT9 are parallel ports.
	/// </param>
	/// <param name="hWnd">
	/// A handle to the window that owns the dialog box. This parameter can be any valid window handle, or it should be <c>NULL</c> if
	/// the dialog box is to have no owner.
	/// </param>
	/// <param name="lpCC">
	/// A pointer to a <c>COMMCONFIG</c> structure. This structure contains initial settings for the dialog box before the call, and
	/// changed values after the call.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	[PInvokeData("Winbase.h", MSDNShortId = "aa363187")]
	public static bool CommConfigDialog(string lpszName, [In, Optional] HWND hWnd, COMMCONFIG lpCC)
	{
		using var cc = SafeCoTaskMemHandle.CreateFromStructure(lpCC);
		cc.Size = 4096;
		if (!CommConfigDialog(lpszName, hWnd, cc))
			return false;
		lpCC = cc.ToStructure<COMMCONFIG>()!;
		return true;
	}

	/// <summary>Directs the specified communications device to perform an extended function.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="dwFunc">
	/// <para>The extended function to be performed. This parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CLRBREAK9</term>
	/// <term>
	/// Restores character transmission and places the transmission line in a nonbreak state. The CLRBREAK extended function code is
	/// identical to the ClearCommBreak function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CLRDTR6</term>
	/// <term>Clears the DTR (data-terminal-ready) signal.</term>
	/// </item>
	/// <item>
	/// <term>CLRRTS4</term>
	/// <term>Clears the RTS (request-to-send) signal.</term>
	/// </item>
	/// <item>
	/// <term>SETBREAK8</term>
	/// <term>
	/// Suspends character transmission and places the transmission line in a break state until the ClearCommBreak function is called (or
	/// EscapeCommFunction is called with the CLRBREAK extended function code). The SETBREAK extended function code is identical to the
	/// SetCommBreak function. Note that this extended function does not flush data that has not been transmitted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SETDTR5</term>
	/// <term>Sends the DTR (data-terminal-ready) signal.</term>
	/// </item>
	/// <item>
	/// <term>SETRTS3</term>
	/// <term>Sends the RTS (request-to-send) signal.</term>
	/// </item>
	/// <item>
	/// <term>SETXOFF1</term>
	/// <term>Causes transmission to act as if an XOFF character has been received.</term>
	/// </item>
	/// <item>
	/// <term>SETXON2</term>
	/// <term>Causes transmission to act as if an XON character has been received.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI EscapeCommFunction( _In_ HANDLE hFile, _In_ DWORD dwFunc); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363254(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363254")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EscapeCommFunction([In] HFILE hFile, COMM_ESC_FUNC dwFunc);

	/// <summary>
	/// <para>Retrieves the current configuration of a communications device.</para>
	/// <para>To retrieve the default configuration settings from the device manager, use the <c>GetDefaultCommConfig</c> function.</para>
	/// </summary>
	/// <param name="hCommDev">A handle to the open communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpCC">A pointer to a buffer that receives a <c>COMMCONFIG</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetCommConfig( _In_ HANDLE hCommDev, _Out_ LPCOMMCONFIG lpCC, _Inout_ LPDWORD lpdwSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363256(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "aa363256")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static bool GetCommConfig([In] HFILE hCommDev, [NotNullWhen(true)] out COMMCONFIG? lpCC)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure<COMMCONFIG.COMMCONFIG_UNMGD>();
		uint sz = mem.Size;
		do
		{
			if (GetCommConfig(hCommDev, mem, ref sz))
			{
				lpCC = mem.ToStructure<COMMCONFIG>()!;
				return true;
			}
			if (sz == mem.Size)
			{
				lpCC = null;
				return false;
			}
			mem.Size = sz;
		} while (true);
	}

	/// <summary>Retrieves the value of the event mask for a specified communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpEvtMask">
	/// <para>
	/// A pointer to the variable that receives a mask of events that are currently enabled. This parameter can be one or more of the
	/// following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EV_BREAK0x0040</term>
	/// <term>A break was detected on input.</term>
	/// </item>
	/// <item>
	/// <term>EV_CTS0x0008</term>
	/// <term>The CTS (clear-to-send) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_DSR0x0010</term>
	/// <term>The DSR (data-set-ready) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_ERR0x0080</term>
	/// <term>A line-status error occurred. Line-status errors are CE_FRAME, CE_OVERRUN, and CE_RXPARITY.</term>
	/// </item>
	/// <item>
	/// <term>EV_EVENT10x0800</term>
	/// <term>An event of the first provider-specific type occurred.</term>
	/// </item>
	/// <item>
	/// <term>EV_EVENT20x1000</term>
	/// <term>An event of the second provider-specific type occurred.</term>
	/// </item>
	/// <item>
	/// <term>EV_PERR0x0200</term>
	/// <term>A printer error occurred.</term>
	/// </item>
	/// <item>
	/// <term>EV_RING0x0100</term>
	/// <term>A ring indicator was detected.</term>
	/// </item>
	/// <item>
	/// <term>EV_RLSD0x0020</term>
	/// <term>The RLSD (receive-line-signal-detect) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_RX80FULL0x0400</term>
	/// <term>The receive buffer is 80 percent full.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXCHAR0x0001</term>
	/// <term>A character was received and placed in the input buffer.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXFLAG0x0002</term>
	/// <term>
	/// The event character was received and placed in the input buffer. The event character is specified in the device's DCB structure,
	/// which is applied to a serial port by using the SetCommState function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EV_TXEMPTY0x0004</term>
	/// <term>The last character in the output buffer was sent.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetCommMask( _In_ HANDLE hFile, _Out_ LPDWORD lpEvtMask); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363257(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363257")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCommMask([In] HFILE hFile, out COMM_EVT_MASK lpEvtMask);

	/// <summary>Retrieves the modem control-register values.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpModemStat">
	/// <para>
	/// A pointer to a variable that receives the current state of the modem control-register values. This parameter can be one or more
	/// of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MS_CTS_ON0x0010</term>
	/// <term>The CTS (clear-to-send) signal is on.</term>
	/// </item>
	/// <item>
	/// <term>MS_DSR_ON0x0020</term>
	/// <term>The DSR (data-set-ready) signal is on.</term>
	/// </item>
	/// <item>
	/// <term>MS_RING_ON0x0040</term>
	/// <term>The ring indicator signal is on.</term>
	/// </item>
	/// <item>
	/// <term>MS_RLSD_ON0x0080</term>
	/// <term>The RLSD (receive-line-signal-detect) signal is on.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetCommModemStatus( _In_ HANDLE hFile, _Out_ LPDWORD lpModemStat); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363258(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363258")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCommModemStatus([In] HFILE hFile, out COMM_MODEM_STATUS lpModemStat);

	/// <summary>
	/// <para>Gets an array that contains the well-formed COM ports.</para>
	/// <para>
	/// This function obtains the COM port numbers from the <c>HKLM\Hardware\DeviceMap\SERIALCOMM</c> registry key and then writes them
	/// to a caller-supplied array. If the array is too small, the function gets the necessary size.
	/// </para>
	/// <para><c>Note</c> If new entries are added to the registry key, the necessary size can change between API calls.</para>
	/// </summary>
	/// <param name="lpPortNumbers">
	/// <para>An array for the port numbers.</para>
	/// </param>
	/// <param name="uPortNumbersCount">
	/// <para>The length of the array in the lpPortNumbers parameter.</para>
	/// </param>
	/// <param name="puPortNumbersFound">
	/// <para>The number of port numbers written to the lpPortNumbers or the length of the array required for the port numbers.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The call succeeded. The lpPortNumbers array was large enough for the result.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The lpPortNumbers array was too small to contain all available port numbers.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>There are no comm ports available.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getcommports ULONG GetCommPorts( PULONG lpPortNumbers,
	// ULONG uPortNumbersCount, PULONG puPortNumbersFound );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "8E57FB62-D7A0-4B47-942B-E33E0B7A37B1", MinClient = PInvokeClient.Windows10)]
	public static extern Win32Error GetCommPorts([In, Out] uint[]? lpPortNumbers, uint uPortNumbersCount, out uint puPortNumbersFound);

	/// <summary>
	/// <para>Gets an array that contains the well-formed COM ports.</para>
	/// <para>
	/// This function obtains the COM port numbers from the <c>HKLM\Hardware\DeviceMap\SERIALCOMM</c> registry key and then writes them
	/// to a caller-supplied array.
	/// </para>
	/// <para><c>Note</c> If new entries are added to the registry key, the necessary size can change between API calls.</para>
	/// </summary>
	/// <returns>An array of port numbers.</returns>
	[PInvokeData("winbase.h", MSDNShortId = "8E57FB62-D7A0-4B47-942B-E33E0B7A37B1", MinClient = PInvokeClient.Windows10)]
	public static uint[] GetCommPorts()
	{
		GetCommPorts(null, 0, out var c).ThrowUnless(Win32Error.ERROR_MORE_DATA);
		var ports = new uint[c];
		GetCommPorts(ports, c, out _).ThrowIfFailed();
		return ports;
	}

	/// <summary>Retrieves information about the communications properties for a specified communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpCommProp">
	/// A pointer to a <c>COMMPROP</c> structure in which the communications properties information is returned. This information can be
	/// used in subsequent calls to the <c>SetCommState</c>, <c>SetCommTimeouts</c>, or <c>SetupComm</c> function to configure the
	/// communications device.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetCommProperties( _In_ HANDLE hFile, _Out_ LPCOMMPROP lpCommProp); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363259(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363259")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCommProperties([In] HFILE hFile, out COMMPROP lpCommProp);

	/// <summary>Retrieves the current control settings for a specified communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpDCB">A pointer to a <c>DCB</c> structure that receives the control settings information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetCommState( _In_ HANDLE hFile, _Inout_ LPDCB lpDCB); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363260(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363260")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCommState([In] HFILE hFile, out DCB lpDCB);

	/// <summary>Retrieves the time-out parameters for all read and write operations on a specified communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpCommTimeouts">A pointer to a <c>COMMTIMEOUTS</c> structure in which the time-out information is returned.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetCommTimeouts( _In_ HANDLE hFile, _Out_ LPCOMMTIMEOUTS lpCommTimeouts); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363261(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363261")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCommTimeouts([In] HFILE hFile, out COMMTIMEOUTS lpCommTimeouts);

	/// <summary>Retrieves the default configuration for the specified communications device.</summary>
	/// <param name="lpszName">
	/// The name of the device. For example, COM1 through COM9 are serial ports and LPT1 through LPT9 are parallel ports.
	/// </param>
	/// <param name="lpCC">A pointer to a buffer that receives a <c>COMMCONFIG</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	public static bool GetDefaultCommConfig(string lpszName, [NotNullWhen(true)] out COMMCONFIG? lpCC)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure<COMMCONFIG.COMMCONFIG_UNMGD>();
		uint sz = mem.Size;
		do
		{
			if (GetDefaultCommConfig(lpszName, mem, ref sz))
			{
				lpCC = mem.ToStructure<COMMCONFIG>()!;
				return true;
			}
			if (sz == mem.Size)
			{
				lpCC = null;
				return false;
			}
			mem.Size = sz;
		} while (true);
	}

	/// <summary>
	/// <para>Attempts to open a communication device.</para>
	/// </summary>
	/// <param name="uPortNumber">
	/// <para>A one-based port number for the communication device to open.</para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The requested access to the device.</para>
	/// <para>For more information about requested access, see CreateFile and Creating and Opening Files.</para>
	/// </param>
	/// <param name="dwFlagsAndAttributes">
	/// <para>The requested flags and attributes to the device.</para>
	/// <para><c>Note</c> For this function, only values of <c>FILE_FLAG_OVERLAPPED</c> or 0x0 are expected for this parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_FLAG_OVERLAPPED 0x40000000</term>
	/// <term>The file or device is being opened or created for asynchronous I/O.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns a valid <c>HANDLE</c>. Use CloseHandle to close that handle.</para>
	/// <para>If an error occurs, the function returns <c>INVALID_HANDLE_VALUE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The uPortNumber parameter accepts one-based values. A value of 1 for uPortNumber causes this function to attempt to open COM1.
	/// </para>
	/// <para>To support UWP, link against WindowsApp.lib.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-opencommport HANDLE OpenCommPort( ULONG uPortNumber, DWORD
	// dwDesiredAccess, DWORD dwFlagsAndAttributes );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "D96D3F6D-2158-4E6A-84A8-DC3BAE9624FA")]
	public static extern SafeHFILE OpenCommPort(uint uPortNumber, FileAccess dwDesiredAccess, uint dwFlagsAndAttributes);

	/// <summary>
	/// Discards all characters from the output or input buffer of a specified communications resource. It can also terminate pending
	/// read or write operations on the resource.
	/// </summary>
	/// <param name="hFile">A handle to the communications resource. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one or more of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PURGE_RXABORT0x0002</term>
	/// <term>
	/// Terminates all outstanding overlapped read operations and returns immediately, even if the read operations have not been completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PURGE_RXCLEAR0x0008</term>
	/// <term>Clears the input buffer (if the device driver has one).</term>
	/// </item>
	/// <item>
	/// <term>PURGE_TXABORT0x0001</term>
	/// <term>
	/// Terminates all outstanding overlapped write operations and returns immediately, even if the write operations have not been completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PURGE_TXCLEAR0x0004</term>
	/// <term>Clears the output buffer (if the device driver has one).</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI PurgeComm( _In_ HANDLE hFile, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363428(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363428")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PurgeComm([In] HFILE hFile, COMM_PURGE dwFlags);

	/// <summary>
	/// Suspends character transmission for a specified communications device and places the transmission line in a break state until the
	/// <c>ClearCommBreak</c> function is called.
	/// </summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetCommBreak( _In_ HANDLE hFile); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363433(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363433")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetCommBreak([In] HFILE hFile);

	/// <summary>Sets the current configuration of a communications device.</summary>
	/// <param name="hCommDev">A handle to the open communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpCC">A pointer to a <c>COMMCONFIG</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetCommConfig( _In_ HANDLE hCommDev, _In_ LPCOMMCONFIG lpCC, _In_ DWORD dwSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363434(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "aa363434")]
	public static bool SetCommConfig([In] HFILE hCommDev, [In] COMMCONFIG lpCC)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(lpCC);
		return SetCommConfig(hCommDev, mem, (uint)mem.Size);
	}

	/// <summary>Specifies a set of events to be monitored for a communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="dwEvtMask">
	/// <para>The events to be enabled. A value of zero disables all events. This parameter can be one or more of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EV_BREAK0x0040</term>
	/// <term>A break was detected on input.</term>
	/// </item>
	/// <item>
	/// <term>EV_CTS0x0008</term>
	/// <term>The CTS (clear-to-send) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_DSR0x0010</term>
	/// <term>The DSR (data-set-ready) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_ERR0x0080</term>
	/// <term>A line-status error occurred. Line-status errors are CE_FRAME, CE_OVERRUN, and CE_RXPARITY.</term>
	/// </item>
	/// <item>
	/// <term>EV_RING0x0100</term>
	/// <term>A ring indicator was detected.</term>
	/// </item>
	/// <item>
	/// <term>EV_RLSD0x0020</term>
	/// <term>The RLSD (receive-line-signal-detect) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXCHAR0x0001</term>
	/// <term>A character was received and placed in the input buffer.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXFLAG0x0002</term>
	/// <term>
	/// The event character was received and placed in the input buffer. The event character is specified in the device's DCB structure,
	/// which is applied to a serial port by using the SetCommState function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EV_TXEMPTY0x0004</term>
	/// <term>The last character in the output buffer was sent.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetCommMask( _In_ HANDLE hFile, _In_ DWORD dwEvtMask); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363435(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363435")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetCommMask([In] HFILE hFile, COMM_EVT_MASK dwEvtMask);

	/// <summary>
	/// Configures a communications device according to the specifications in a device-control block (a <c>DCB</c> structure). The
	/// function reinitializes all hardware and control settings, but it does not empty output or input queues.
	/// </summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpDCB">
	/// A pointer to a <c>DCB</c> structure that contains the configuration information for the specified communications device.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetCommState( _In_ HANDLE hFile, _In_ LPDCB lpDCB); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363436(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363436")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetCommState([In] HFILE hFile, in DCB lpDCB);

	/// <summary>Sets the time-out parameters for all read and write operations on a specified communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpCommTimeouts">A pointer to a <c>COMMTIMEOUTS</c> structure that contains the new time-out values.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetCommTimeouts( _In_ HANDLE hFile, _In_ LPCOMMTIMEOUTS lpCommTimeouts); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363437(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363437")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetCommTimeouts([In] HFILE hFile, in COMMTIMEOUTS lpCommTimeouts);

	/// <summary>Sets the default configuration for a communications device.</summary>
	/// <param name="lpszName">
	/// The name of the device. For example, COM1 through COM9 are serial ports and LPT1 through LPT9 are parallel ports.
	/// </param>
	/// <param name="lpCC">A pointer to a <see cref="COMMCONFIG"/> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetDefaultCommConfig( _In_ LPCTSTR lpszName, _In_ LPCOMMCONFIG lpCC, _In_ DWORD dwSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363438(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "aa363438")]
	public static bool SetDefaultCommConfig(string lpszName, [In] COMMCONFIG lpCC)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(lpCC);
		return SetDefaultCommConfig(lpszName, mem, (uint)mem.Size);
	}

	/// <summary>Initializes the communications parameters for a specified communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="dwInQueue">The recommended size of the device's internal input buffer, in bytes.</param>
	/// <param name="dwOutQueue">The recommended size of the device's internal output buffer, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetupComm( _In_ HANDLE hFile, _In_ DWORD dwInQueue, _In_ DWORD dwOutQueue); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363439(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363439")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupComm([In] HFILE hFile, uint dwInQueue, uint dwOutQueue);

	/// <summary>Transmits a specified character ahead of any pending data in the output buffer of the specified communications device.</summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="cChar">The character to be transmitted.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI TransmitCommChar( _In_ HANDLE hFile, _In_ char cChar); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363473(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363473")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TransmitCommChar([In] HFILE hFile, byte cChar);

	/// <summary>
	/// Waits for an event to occur for a specified communications device. The set of events that are monitored by this function is
	/// contained in the event mask associated with the device handle.
	/// </summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpEvtMask">
	/// <para>
	/// A pointer to a variable that receives a mask indicating the type of event that occurred. If an error occurs, the value is zero;
	/// otherwise, it is one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EV_BREAK0x0040</term>
	/// <term>A break was detected on input.</term>
	/// </item>
	/// <item>
	/// <term>EV_CTS0x0008</term>
	/// <term>The CTS (clear-to-send) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_DSR0x0010</term>
	/// <term>The DSR (data-set-ready) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_ERR0x0080</term>
	/// <term>A line-status error occurred. Line-status errors are CE_FRAME, CE_OVERRUN, and CE_RXPARITY.</term>
	/// </item>
	/// <item>
	/// <term>EV_RING0x0100</term>
	/// <term>A ring indicator was detected.</term>
	/// </item>
	/// <item>
	/// <term>EV_RLSD0x0020</term>
	/// <term>The RLSD (receive-line-signal-detect) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXCHAR0x0001</term>
	/// <term>A character was received and placed in the input buffer.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXFLAG0x0002</term>
	/// <term>
	/// The event character was received and placed in the input buffer. The event character is specified in the device's DCB structure,
	/// which is applied to a serial port by using the SetCommState function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EV_TXEMPTY0x0004</term>
	/// <term>The last character in the output buffer was sent.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpOverlapped">
	/// <para>A pointer to an <c>OVERLAPPED</c> structure. This structure is required if hFile was opened with <c>FILE_FLAG_OVERLAPPED</c>.</para>
	/// <para>
	/// If hFile was opened with <c>FILE_FLAG_OVERLAPPED</c>, the lpOverlapped parameter must not be <c>NULL</c>. It must point to a
	/// valid <c>OVERLAPPED</c> structure. If hFile was opened with <c>FILE_FLAG_OVERLAPPED</c> and lpOverlapped is <c>NULL</c>, the
	/// function can incorrectly report that the operation is complete.
	/// </para>
	/// <para>
	/// If hFile was opened with <c>FILE_FLAG_OVERLAPPED</c> and lpOverlapped is not <c>NULL</c>, <c>WaitCommEvent</c> is performed as an
	/// overlapped operation. In this case, the <c>OVERLAPPED</c> structure must contain a handle to a manual-reset event object (created
	/// by using the <c>CreateEvent</c> function).
	/// </para>
	/// <para>
	/// If hFile was not opened with <c>FILE_FLAG_OVERLAPPED</c>, <c>WaitCommEvent</c> does not return until one of the specified events
	/// or an error occurs.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI WaitCommEvent( _In_ HANDLE hFile, _Out_ LPDWORD lpEvtMask, _In_ LPOVERLAPPED lpOverlapped); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363479(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363479")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WaitCommEvent([In] HFILE hFile, out COMM_EVT_MASK lpEvtMask, [In, Optional] StructPointer<NativeOverlapped> lpOverlapped);

	/// <summary>
	/// Waits for an event to occur for a specified communications device. The set of events that are monitored by this function is
	/// contained in the event mask associated with the device handle.
	/// </summary>
	/// <param name="hFile">A handle to the communications device. The <c>CreateFile</c> function returns this handle.</param>
	/// <param name="lpEvtMask">
	/// <para>
	/// A pointer to a variable that receives a mask indicating the type of event that occurred. If an error occurs, the value is zero;
	/// otherwise, it is one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EV_BREAK0x0040</term>
	/// <term>A break was detected on input.</term>
	/// </item>
	/// <item>
	/// <term>EV_CTS0x0008</term>
	/// <term>The CTS (clear-to-send) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_DSR0x0010</term>
	/// <term>The DSR (data-set-ready) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_ERR0x0080</term>
	/// <term>A line-status error occurred. Line-status errors are CE_FRAME, CE_OVERRUN, and CE_RXPARITY.</term>
	/// </item>
	/// <item>
	/// <term>EV_RING0x0100</term>
	/// <term>A ring indicator was detected.</term>
	/// </item>
	/// <item>
	/// <term>EV_RLSD0x0020</term>
	/// <term>The RLSD (receive-line-signal-detect) signal changed state.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXCHAR0x0001</term>
	/// <term>A character was received and placed in the input buffer.</term>
	/// </item>
	/// <item>
	/// <term>EV_RXFLAG0x0002</term>
	/// <term>
	/// The event character was received and placed in the input buffer. The event character is specified in the device's DCB structure,
	/// which is applied to a serial port by using the SetCommState function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EV_TXEMPTY0x0004</term>
	/// <term>The last character in the output buffer was sent.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpOverlapped">
	/// <para>A pointer to an <c>OVERLAPPED</c> structure. This structure is required if hFile was opened with <c>FILE_FLAG_OVERLAPPED</c>.</para>
	/// <para>
	/// If hFile was opened with <c>FILE_FLAG_OVERLAPPED</c>, the lpOverlapped parameter must not be <c>NULL</c>. It must point to a
	/// valid <c>OVERLAPPED</c> structure. If hFile was opened with <c>FILE_FLAG_OVERLAPPED</c> and lpOverlapped is <c>NULL</c>, the
	/// function can incorrectly report that the operation is complete.
	/// </para>
	/// <para>
	/// If hFile was opened with <c>FILE_FLAG_OVERLAPPED</c> and lpOverlapped is not <c>NULL</c>, <c>WaitCommEvent</c> is performed as an
	/// overlapped operation. In this case, the <c>OVERLAPPED</c> structure must contain a handle to a manual-reset event object (created
	/// by using the <c>CreateEvent</c> function).
	/// </para>
	/// <para>
	/// If hFile was not opened with <c>FILE_FLAG_OVERLAPPED</c>, <c>WaitCommEvent</c> does not return until one of the specified events
	/// or an error occurs.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI WaitCommEvent( _In_ HANDLE hFile, _Out_ LPDWORD lpEvtMask, _In_ LPOVERLAPPED lpOverlapped); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363479(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa363479")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WaitCommEvent([In] HFILE hFile, out COMM_EVT_MASK lpEvtMask, in NativeOverlapped lpOverlapped);

	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CommConfigDialog(string lpszName, [In, Optional] HWND hWnd, [In, Out] IntPtr lpCC);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetCommConfig([In] HFILE hCommDev, IntPtr lpCC, ref uint lpdwSize);

	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetDefaultCommConfig(string lpszName, IntPtr lpCC, ref uint lpdwSize);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool SetCommConfig([In] HFILE hCommDev, [In] IntPtr lpCC, uint dwSize);

	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool SetDefaultCommConfig(string lpszName, [In] IntPtr lpCC, uint dwSize);

	/// <summary>Contains information about a communications driver.</summary>
	// typedef struct _COMMPROP { WORD wPacketLength; WORD wPacketVersion; DWORD dwServiceMask; DWORD dwReserved1; DWORD dwMaxTxQueue;
	// DWORD dwMaxRxQueue; DWORD dwMaxBaud; DWORD dwProvSubType; DWORD dwProvCapabilities; DWORD dwSettableParams; DWORD dwSettableBaud;
	// WORD wSettableData; WORD wSettableStopParity; DWORD dwCurrentTxQueue; DWORD dwCurrentRxQueue; DWORD dwProvSpec1; DWORD
	// dwProvSpec2; WCHAR wcProvChar[1];} COMMPROP,
	// *LPCOMMPROP; https://msdn.microsoft.com/en-us/library/windows/desktop/aa363189(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "aa363189")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
	public struct COMMPROP
	{
		/// <summary>The size of the entire data packet, regardless of the amount of data requested, in bytes.</summary>
		public ushort wPacketLength;

		/// <summary>The version of the structure.</summary>
		public ushort wPacketVersion;

		/// <summary>
		/// A bitmask indicating which services are implemented by this provider. The <c>SP_SERIALCOMM</c> value is always specified for
		/// communications providers, including modem providers.
		/// </summary>
		public uint dwServiceMask;

		/// <summary>Reserved; do not use.</summary>
		public uint dwReserved1;

		/// <summary>
		/// The maximum size of the driver's internal output buffer, in bytes. A value of zero indicates that no maximum value is imposed
		/// by the serial provider.
		/// </summary>
		public uint dwMaxTxQueue;

		/// <summary>
		/// The maximum size of the driver's internal input buffer, in bytes. A value of zero indicates that no maximum value is imposed
		/// by the serial provider.
		/// </summary>
		public uint dwMaxRxQueue;

		/// <summary>
		/// <para>The maximum allowable baud rate, in bits per second (bps). This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BAUD_0750x00000001</term>
		/// <term>75 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_1100x00000002</term>
		/// <term>110 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_134_50x00000004</term>
		/// <term>134.5 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_1500x00000008</term>
		/// <term>150 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_3000x00000010</term>
		/// <term>300 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_6000x00000020</term>
		/// <term>600 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_12000x00000040</term>
		/// <term>1200 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_18000x00000080</term>
		/// <term>1800 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_24000x00000100</term>
		/// <term>2400 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_48000x00000200</term>
		/// <term>4800 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_72000x00000400</term>
		/// <term>7200 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_96000x00000800</term>
		/// <term>9600 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_144000x00001000</term>
		/// <term>14400 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_192000x00002000</term>
		/// <term>19200 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_384000x00004000</term>
		/// <term>38400 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_56K0x00008000</term>
		/// <term>56K bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_576000x00040000</term>
		/// <term>57600 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_1152000x00020000</term>
		/// <term>115200 bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_128K0x00010000</term>
		/// <term>128K bps</term>
		/// </item>
		/// <item>
		/// <term>BAUD_USER0x10000000</term>
		/// <term>Programmable baud rate.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public uint dwMaxBaud;

		/// <summary>
		/// <para>The communications-provider type.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PST_FAX0x00000021</term>
		/// <term>FAX device</term>
		/// </item>
		/// <item>
		/// <term>PST_LAT0x00000101</term>
		/// <term>LAT protocol</term>
		/// </item>
		/// <item>
		/// <term>PST_MODEM0x00000006</term>
		/// <term>Modem device</term>
		/// </item>
		/// <item>
		/// <term>PST_NETWORK_BRIDGE0x00000100</term>
		/// <term>Unspecified network bridge</term>
		/// </item>
		/// <item>
		/// <term>PST_PARALLELPORT0x00000002</term>
		/// <term>Parallel port</term>
		/// </item>
		/// <item>
		/// <term>PST_RS2320x00000001</term>
		/// <term>RS-232 serial port</term>
		/// </item>
		/// <item>
		/// <term>PST_RS4220x00000003</term>
		/// <term>RS-422 port</term>
		/// </item>
		/// <item>
		/// <term>PST_RS4230x00000004</term>
		/// <term>RS-423 port</term>
		/// </item>
		/// <item>
		/// <term>PST_RS4490x00000005</term>
		/// <term>RS-449 port</term>
		/// </item>
		/// <item>
		/// <term>PST_SCANNER0x00000022</term>
		/// <term>Scanner device</term>
		/// </item>
		/// <item>
		/// <term>PST_TCPIP_TELNET0x00000102</term>
		/// <term>TCP/IP Telnet protocol</term>
		/// </item>
		/// <item>
		/// <term>PST_UNSPECIFIED0x00000000</term>
		/// <term>Unspecified</term>
		/// </item>
		/// <item>
		/// <term>PST_X250x00000103</term>
		/// <term>X.25 standards</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public PROV_SUB_TYPE dwProvSubType;

		/// <summary>
		/// <para>A bitmask indicating the capabilities offered by the provider. This member can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PCF_16BITMODE0x0200</term>
		/// <term>Special 16-bit mode supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_DTRDSR0x0001</term>
		/// <term>DTR (data-terminal-ready)/DSR (data-set-ready) supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_INTTIMEOUTS0x0080</term>
		/// <term>Interval time-outs supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_PARITY_CHECK0x0008</term>
		/// <term>Parity checking supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_RLSD0x0004</term>
		/// <term>RLSD (receive-line-signal-detect) supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_RTSCTS0x0002</term>
		/// <term>RTS (request-to-send)/CTS (clear-to-send) supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_SETXCHAR0x0020</term>
		/// <term>Settable XON/XOFF supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_SPECIALCHARS0x0100</term>
		/// <term>Special character support provided</term>
		/// </item>
		/// <item>
		/// <term>PCF_TOTALTIMEOUTS0x0040</term>
		/// <term>The total (elapsed) time-outs supported</term>
		/// </item>
		/// <item>
		/// <term>PCF_XONXOFF0x0010</term>
		/// <term>XON/XOFF flow control supported</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public PROV_CAPABILITIES dwProvCapabilities;

		/// <summary>
		/// <para>
		/// A bitmask indicating the communications parameters that can be changed. This member can be a combination of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SP_BAUD0x0002</term>
		/// <term>Baud rate</term>
		/// </item>
		/// <item>
		/// <term>SP_DATABITS0x0004</term>
		/// <term>Data bits</term>
		/// </item>
		/// <item>
		/// <term>SP_HANDSHAKING0x0010</term>
		/// <term>Handshaking (flow control)</term>
		/// </item>
		/// <item>
		/// <term>SP_PARITY0x0001</term>
		/// <term>Parity</term>
		/// </item>
		/// <item>
		/// <term>SP_PARITY_CHECK0x0020</term>
		/// <term>Parity checking</term>
		/// </item>
		/// <item>
		/// <term>SP_RLSD0x0040</term>
		/// <term>RLSD (receive-line-signal-detect)</term>
		/// </item>
		/// <item>
		/// <term>SP_STOPBITS0x0008</term>
		/// <term>Stop bits</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public COMM_SET_PARAMS dwSettableParams;

		/// <summary>The baud rates that can be used. For values, see the <c>dwMaxBaud</c> member.</summary>
		public uint dwSettableBaud;

		/// <summary>
		/// <para>A bitmask indicating the number of data bits that can be set. This member can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DATABITS_50x0001</term>
		/// <term>5 data bits</term>
		/// </item>
		/// <item>
		/// <term>DATABITS_60x0002</term>
		/// <term>6 data bits</term>
		/// </item>
		/// <item>
		/// <term>DATABITS_70x0004</term>
		/// <term>7 data bits</term>
		/// </item>
		/// <item>
		/// <term>DATABITS_80x0008</term>
		/// <term>8 data bits</term>
		/// </item>
		/// <item>
		/// <term>DATABITS_160x0010</term>
		/// <term>16 data bits</term>
		/// </item>
		/// <item>
		/// <term>DATABITS_16X0x0020</term>
		/// <term>Special wide path through serial hardware lines</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public COMM_SET_DATA wSettableData;

		/// <summary>
		/// <para>
		/// A bitmask indicating the stop bit and parity settings that can be selected. This member can be a combination of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STOPBITS_100x0001</term>
		/// <term>1 stop bit</term>
		/// </item>
		/// <item>
		/// <term>STOPBITS_150x0002</term>
		/// <term>1.5 stop bits</term>
		/// </item>
		/// <item>
		/// <term>STOPBITS_200x0004</term>
		/// <term>2 stop bits</term>
		/// </item>
		/// <item>
		/// <term>PARITY_NONE0x0100</term>
		/// <term>No parity</term>
		/// </item>
		/// <item>
		/// <term>PARITY_ODD0x0200</term>
		/// <term>Odd parity</term>
		/// </item>
		/// <item>
		/// <term>PARITY_EVEN0x0400</term>
		/// <term>Even parity</term>
		/// </item>
		/// <item>
		/// <term>PARITY_MARK0x0800</term>
		/// <term>Mark parity</term>
		/// </item>
		/// <item>
		/// <term>PARITY_SPACE0x1000</term>
		/// <term>Space parity</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public COMM_STOP_PARITY wSettableStopParity;

		/// <summary>The size of the driver's internal output buffer, in bytes. A value of zero indicates that the value is unavailable.</summary>
		public uint dwCurrentTxQueue;

		/// <summary>The size of the driver's internal input buffer, in bytes. A value of zero indicates that the value is unavailable.</summary>
		public uint dwCurrentRxQueue;

		/// <summary>
		/// <para>
		/// Any provider-specific data. Applications should ignore this member unless they have detailed information about the format of
		/// the data required by the provider.
		/// </para>
		/// <para>
		/// Set this member to <c>COMMPROP_INITIALIZED</c> before calling the <c>GetCommProperties</c> function to indicate that the
		/// <c>wPacketLength</c> member is already valid.
		/// </para>
		/// </summary>
		public uint dwProvSpec1;

		/// <summary>
		/// Any provider-specific data. Applications should ignore this member unless they have detailed information about the format of
		/// the data required by the provider.
		/// </summary>
		public uint dwProvSpec2;

		/// <summary>
		/// Any provider-specific data. Applications should ignore this member unless they have detailed information about the format of
		/// the data required by the provider.
		/// </summary>
		public ushort wcProvChar;
	}

	/// <summary>
	/// Contains the time-out parameters for a communications device. The parameters determine the behavior of <c>ReadFile</c>,
	/// <c>WriteFile</c>, <c>ReadFileEx</c>, and <c>WriteFileEx</c> operations on the device.
	/// </summary>
	// typedef struct _COMMTIMEOUTS { DWORD ReadIntervalTimeout; DWORD ReadTotalTimeoutMultiplier; DWORD ReadTotalTimeoutConstant; DWORD
	// WriteTotalTimeoutMultiplier; DWORD WriteTotalTimeoutConstant;} COMMTIMEOUTS, *LPCOMMTIMEOUTS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa363190(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "aa363190")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMMTIMEOUTS
	{
		/// <summary>
		/// <para>
		/// The maximum time allowed to elapse before the arrival of the next byte on the communications line, in milliseconds. If the
		/// interval between the arrival of any two bytes exceeds this amount, the <c>ReadFile</c> operation is completed and any
		/// buffered data is returned. A value of zero indicates that interval time-outs are not used.
		/// </para>
		/// <para>
		/// A value of <c>MAXDWORD</c>, combined with zero values for both the <c>ReadTotalTimeoutConstant</c> and
		/// <c>ReadTotalTimeoutMultiplier</c> members, specifies that the read operation is to return immediately with the bytes that
		/// have already been received, even if no bytes have been received.
		/// </para>
		/// </summary>
		public uint ReadIntervalTimeout;

		/// <summary>
		/// The multiplier used to calculate the total time-out period for read operations, in milliseconds. For each read operation,
		/// this value is multiplied by the requested number of bytes to be read.
		/// </summary>
		public uint ReadTotalTimeoutMultiplier;

		/// <summary>
		/// <para>
		/// A constant used to calculate the total time-out period for read operations, in milliseconds. For each read operation, this
		/// value is added to the product of the <c>ReadTotalTimeoutMultiplier</c> member and the requested number of bytes.
		/// </para>
		/// <para>
		/// A value of zero for both the <c>ReadTotalTimeoutMultiplier</c> and <c>ReadTotalTimeoutConstant</c> members indicates that
		/// total time-outs are not used for read operations.
		/// </para>
		/// </summary>
		public uint ReadTotalTimeoutConstant;

		/// <summary>
		/// The multiplier used to calculate the total time-out period for write operations, in milliseconds. For each write operation,
		/// this value is multiplied by the number of bytes to be written.
		/// </summary>
		public uint WriteTotalTimeoutMultiplier;

		/// <summary>
		/// <para>
		/// A constant used to calculate the total time-out period for write operations, in milliseconds. For each write operation, this
		/// value is added to the product of the <c>WriteTotalTimeoutMultiplier</c> member and the number of bytes to be written.
		/// </para>
		/// <para>
		/// A value of zero for both the <c>WriteTotalTimeoutMultiplier</c> and <c>WriteTotalTimeoutConstant</c> members indicates that
		/// total time-outs are not used for write operations.
		/// </para>
		/// </summary>
		public uint WriteTotalTimeoutConstant;
	}

	/// <summary>Contains information about a communications device. This structure is filled by the <c>ClearCommError</c> function.</summary>
	// typedef struct _COMSTAT { DWORD fCtsHold :1; DWORD fDsrHold :1; DWORD fRlsdHold :1; DWORD fXoffHold :1; DWORD fXoffSent :1; DWORD
	// fEof :1; DWORD fTxim :1; DWORD fReserved :25; DWORD cbInQue; DWORD cbOutQue;} COMSTAT, *LPCOMSTAT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa363200(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "aa363200")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMSTAT
	{
		private uint bitvector1;

		/// <summary>The number of bytes received by the serial provider but not yet read by a <c>ReadFile</c> operation.</summary>
		public uint cbInQue;

		/// <summary>
		/// The number of bytes of user data remaining to be transmitted for all write operations. This value will be zero for a
		/// nonoverlapped write.
		/// </summary>
		public uint cbOutQue;

		/// <summary>If this member is <c>TRUE</c>, transmission is waiting for the CTS (clear-to-send) signal to be sent.</summary>
		public bool fCtsHold { get => GetFlag(0x0001); set => SetFlag(0x0001, value); }

		/// <summary>If this member is <c>TRUE</c>, transmission is waiting for the DSR (data-set-ready) signal to be sent.</summary>
		public bool fDsrHold { get => GetFlag(0x0002); set => SetFlag(0x0002, value); }

		/// <summary>
		/// If this member is <c>TRUE</c>, transmission is waiting for the RLSD (receive-line-signal-detect) signal to be sent.
		/// </summary>
		public bool fRlsdHold { get => GetFlag(0x0004); set => SetFlag(0x0004, value); }

		/// <summary>If this member is <c>TRUE</c>, transmission is waiting because the XOFF character was received.</summary>
		public bool fXoffHold { get => GetFlag(0x0008); set => SetFlag(0x0008, value); }

		/// <summary>
		/// If this member is <c>TRUE</c>, transmission is waiting because the XOFF character was transmitted. (Transmission halts when
		/// the XOFF character is transmitted to a system that takes the next character as XON, regardless of the actual character.)
		/// </summary>
		public bool fXoffSent { get => GetFlag(0x0010); set => SetFlag(0x0010, value); }

		/// <summary>If this member is <c>TRUE</c>, the end-of-file (EOF) character has been received.</summary>
		public bool fEof { get => GetFlag(0x0020); set => SetFlag(0x0020, value); }

		/// <summary>
		/// If this member is <c>TRUE</c>, there is a character queued for transmission that has come to the communications device by way
		/// of the <c>TransmitCommChar</c> function. The communications device transmits such a character ahead of other characters in
		/// the device's output buffer.
		/// </summary>
		public bool fTxim { get => GetFlag(0x0040); set => SetFlag(0x0040, value); }

		private readonly bool GetFlag(uint mask) => (bitvector1 & mask) != 0;

		private void SetFlag(uint mask, bool value)
		{
			if (value) bitvector1 |= mask; else bitvector1 &= ~mask;
		}
	}

	/// <summary>Defines the control setting for a serial communications device.</summary>
	// typedef struct _DCB { DWORD DCBlength; DWORD BaudRate; DWORD fBinary :1; DWORD fParity :1; DWORD fOutxCtsFlow :1; DWORD
	// fOutxDsrFlow :1; DWORD fDtrControl :2; DWORD fDsrSensitivity :1; DWORD fTXContinueOnXoff :1; DWORD fOutX :1; DWORD fInX :1; DWORD
	// fErrorChar :1; DWORD fNull :1; DWORD fRtsControl :2; DWORD fAbortOnError :1; DWORD fDummy2 :17; WORD wReserved; WORD XonLim; WORD
	// XoffLim; BYTE ByteSize; BYTE Parity; BYTE StopBits; char XonChar; char XoffChar; char ErrorChar; char EofChar; char EvtChar; WORD
	// wReserved1;} DCB, *LPDCB; https://msdn.microsoft.com/en-us/library/windows/desktop/aa363214(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "aa363214")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct DCB()
	{
		/// <summary>The length of the structure, in bytes. The caller must set this member to .</summary>
		public uint DCBlength = (uint)Marshal.SizeOf<DCB>();

		/// <summary>
		/// <para>
		/// The baud rate at which the communications device operates. This member can be an actual baud rate value, or one of the
		/// following indexes.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CBR_110110</term>
		/// <term>110 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_300300</term>
		/// <term>300 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_600600</term>
		/// <term>600 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_12001200</term>
		/// <term>1200 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_24002400</term>
		/// <term>2400 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_48004800</term>
		/// <term>4800 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_96009600</term>
		/// <term>9600 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_1440014400</term>
		/// <term>14400 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_1920019200</term>
		/// <term>19200 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_3840038400</term>
		/// <term>38400 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_5760057600</term>
		/// <term>57600 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_115200115200</term>
		/// <term>115200 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_128000128000</term>
		/// <term>128000 bps</term>
		/// </item>
		/// <item>
		/// <term>CBR_256000256000</term>
		/// <term>256000 bps</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public uint BaudRate;

		private uint flags;

		/// <summary>Reserved; must be zero.</summary>
		public ushort wReserved;

		/// <summary>
		/// The minimum number of bytes in use allowed in the input buffer before flow control is activated to allow transmission by the
		/// sender. This assumes that either XON/XOFF, RTS, or DTR input flow control is specified in the <c>fInX</c>,
		/// <c>fRtsControl</c>, or <c>fDtrControl</c> members.
		/// </summary>
		public ushort XonLim;

		/// <summary>
		/// The minimum number of free bytes allowed in the input buffer before flow control is activated to inhibit the sender. Note
		/// that the sender may transmit characters after the flow control signal has been activated, so this value should never be zero.
		/// This assumes that either XON/XOFF, RTS, or DTR input flow control is specified in the <c>fInX</c>, <c>fRtsControl</c>, or
		/// <c>fDtrControl</c> members. The maximum number of bytes in use allowed is calculated by subtracting this value from the size,
		/// in bytes, of the input buffer.
		/// </summary>
		public ushort XoffLim;

		/// <summary>The number of bits in the bytes transmitted and received.</summary>
		public byte ByteSize;

		/// <summary>
		/// <para>The parity scheme to be used. This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EVENPARITY2</term>
		/// <term>Even parity.</term>
		/// </item>
		/// <item>
		/// <term>MARKPARITY3</term>
		/// <term>Mark parity.</term>
		/// </item>
		/// <item>
		/// <term>NOPARITY0</term>
		/// <term>No parity.</term>
		/// </item>
		/// <item>
		/// <term>ODDPARITY1</term>
		/// <term>Odd parity.</term>
		/// </item>
		/// <item>
		/// <term>SPACEPARITY4</term>
		/// <term>Space parity.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public Parity Parity;

		/// <summary>
		/// <para>The number of stop bits to be used. This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ONESTOPBIT0</term>
		/// <term>1 stop bit.</term>
		/// </item>
		/// <item>
		/// <term>ONE5STOPBITS1</term>
		/// <term>1.5 stop bits.</term>
		/// </item>
		/// <item>
		/// <term>TWOSTOPBITS2</term>
		/// <term>2 stop bits.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public StopBits StopBits;

		/// <summary>The value of the XON character for both transmission and reception.</summary>
		public sbyte XonChar;

		/// <summary>The value of the XOFF character for both transmission and reception.</summary>
		public sbyte XoffChar;

		/// <summary>The value of the character used to replace bytes received with a parity error.</summary>
		public sbyte ErrorChar;

		/// <summary>The value of the character used to signal the end of data.</summary>
		public sbyte EofChar;

		/// <summary>The value of the character used to signal an event.</summary>
		public sbyte EvtChar;

		/// <summary>Reserved; do not use.</summary>
		public ushort wReserved1;

		/// <summary>
		/// If this member is <c>TRUE</c>, binary mode is enabled. Windows does not support nonbinary mode transfers, so this member must
		/// be <c>TRUE</c>.
		/// </summary>
		public bool fBinary { get => GetFlag(0x01); set => SetFlag(0x01, value); }

		/// <summary>If this member is <c>TRUE</c>, parity checking is performed and errors are reported.</summary>
		public bool fParity { get => GetFlag(0x02); set => SetFlag(0x02, value); }

		/// <summary>
		/// If this member is <c>TRUE</c>, the CTS (clear-to-send) signal is monitored for output flow control. If this member is
		/// <c>TRUE</c> and CTS is turned off, output is suspended until CTS is sent again.
		/// </summary>
		public bool fOutxCtsFlow { get => GetFlag(0x04); set => SetFlag(0x04, value); }

		/// <summary>
		/// If this member is <c>TRUE</c>, the DSR (data-set-ready) signal is monitored for output flow control. If this member is
		/// <c>TRUE</c> and DSR is turned off, output is suspended until DSR is sent again.
		/// </summary>
		public bool fOutxDsrFlow { get => GetFlag(0x08); set => SetFlag(0x08, value); }

		/// <summary>
		/// <para>The DTR (data-terminal-ready) flow control. This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DTR_CONTROL_DISABLE0x00</term>
		/// <term>Disables the DTR line when the device is opened and leaves it disabled.</term>
		/// </item>
		/// <item>
		/// <term>DTR_CONTROL_ENABLE0x01</term>
		/// <term>Enables the DTR line when the device is opened and leaves it on.</term>
		/// </item>
		/// <item>
		/// <term>DTR_CONTROL_HANDSHAKE0x02</term>
		/// <term>
		/// Enables DTR handshaking. If handshaking is enabled, it is an error for the application to adjust the line by using the
		/// EscapeCommFunction function.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public DTR_CONTROL fDtrControl { get => (DTR_CONTROL)((flags & 0x30) >> 4); set => flags = (flags & ~0x30U) | (((uint)value) << 4); }

		/// <summary>
		/// If this member is <c>TRUE</c>, the communications driver is sensitive to the state of the DSR signal. The driver ignores any
		/// bytes received, unless the DSR modem input line is high.
		/// </summary>
		public bool fDsrSensitivity { get => GetFlag(0x40); set => SetFlag(0x40, value); }

		/// <summary>
		/// If this member is <c>TRUE</c>, transmission continues after the input buffer has come within <c>XoffLim</c> bytes of being
		/// full and the driver has transmitted the <c>XoffChar</c> character to stop receiving bytes. If this member is <c>FALSE</c>,
		/// transmission does not continue until the input buffer is within <c>XonLim</c> bytes of being empty and the driver has
		/// transmitted the <c>XonChar</c> character to resume reception.
		/// </summary>
		public bool fTXContinueOnXoff { get => GetFlag(0x80); set => SetFlag(0x80, value); }

		/// <summary>
		/// Indicates whether XON/XOFF flow control is used during transmission. If this member is <c>TRUE</c>, transmission stops when
		/// the <c>XoffChar</c> character is received and starts again when the <c>XonChar</c> character is received.
		/// </summary>
		public bool fOutX { get => GetFlag(0x100); set => SetFlag(0x100, value); }

		/// <summary>
		/// Indicates whether XON/XOFF flow control is used during reception. If this member is <c>TRUE</c>, the <c>XoffChar</c>
		/// character is sent when the input buffer comes within <c>XoffLim</c> bytes of being full, and the <c>XonChar</c> character is
		/// sent when the input buffer comes within <c>XonLim</c> bytes of being empty.
		/// </summary>
		public bool fInX { get => GetFlag(0x200); set => SetFlag(0x200, value); }

		/// <summary>
		/// Indicates whether bytes received with parity errors are replaced with the character specified by the <c>ErrorChar</c> member.
		/// If this member is <c>TRUE</c> and the <c>fParity</c> member is <c>TRUE</c>, replacement occurs.
		/// </summary>
		public bool fErrorChar { get => GetFlag(0x400); set => SetFlag(0x400, value); }

		/// <summary>If this member is <c>TRUE</c>, null bytes are discarded when received.</summary>
		public bool fNull { get => GetFlag(0x800); set => SetFlag(0x800, value); }

		/// <summary>
		/// <para>The RTS (request-to-send) flow control. This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RTS_CONTROL_DISABLE0x00</term>
		/// <term>Disables the RTS line when the device is opened and leaves it disabled.</term>
		/// </item>
		/// <item>
		/// <term>RTS_CONTROL_ENABLE0x01</term>
		/// <term>Enables the RTS line when the device is opened and leaves it on.</term>
		/// </item>
		/// <item>
		/// <term>RTS_CONTROL_HANDSHAKE0x02</term>
		/// <term>
		/// Enables RTS handshaking. The driver raises the RTS line when the &amp;quot;type-ahead&amp;quot; (input) buffer is less than
		/// one-half full and lowers the RTS line when the buffer is more than three-quarters full. If handshaking is enabled, it is an
		/// error for the application to adjust the line by using the EscapeCommFunction function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RTS_CONTROL_TOGGLE0x03</term>
		/// <term>
		/// Specifies that the RTS line will be high if bytes are available for transmission. After all buffered bytes have been sent,
		/// the RTS line will be low.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public RTS_CONTROL fRtsControl { get => (RTS_CONTROL)((flags & 0x3000) >> 12); set => flags = (flags & ~0x3000U) | (((uint)value) << 12); }

		/// <summary>
		/// If this member is <c>TRUE</c>, the driver terminates all read and write operations with an error status if an error occurs.
		/// The driver will not accept any further communications operations until the application has acknowledged the error by calling
		/// the <c>ClearCommError</c> function.
		/// </summary>
		public bool fAbortOnError { get => GetFlag(0x4000); set => SetFlag(0x4000, value); }

		private readonly bool GetFlag(uint mask) => (flags & mask) != 0;

		private void SetFlag(uint mask, bool value)
		{
			if (value) flags |= mask; else flags &= ~mask;
		}

		/// <summary>Gets a default instance with the size field set.</summary>
		public static readonly DCB Default = new();
	}

	/// <summary>
	/// <para>Contains information about the configuration state of a communications device.</para>
	/// </summary>
	// typedef struct _COMM_CONFIG { DWORD dwSize; WORD wVersion; WORD wReserved; DCB dcb; DWORD dwProviderSubType; DWORD
	// dwProviderOffset; DWORD dwProviderSize; WCHAR wcProviderData[1];} COMMCONFIG, *LPCOMMCONFIG;
	[PInvokeData("Winbase.h", MSDNShortId = "aa363188")]
	public class COMMCONFIG : IVanaraMarshaler
	{
		/// <summary>
		/// The device-control block ( <c>DCB</c>) structure for RS-232 serial devices. A <c>DCB</c> structure is always present
		/// regardless of the port driver subtype specified in the device's <c>COMMPROP</c> structure.
		/// </summary>
		public DCB dcb = DCB.Default;

		/// <summary>
		/// The type of communications provider, and thus the format of the provider-specific data. For a list of communications provider
		/// types, see the description of the <c>COMMPROP</c> structure.
		/// </summary>
		public PROV_SUB_TYPE dwProviderSubType;

		/// <summary>
		/// Optional provider-specific data. This member can be of any size or can be omitted. Because the <c>COMMCONFIG</c> structure
		/// may be expanded in the future, applications should use the <c>dwProviderOffset</c> member to determine the location of this member.
		/// </summary>
		public byte[] wcProviderData = [];

		/// <summary>
		/// The version number of the structure. This parameter can be 1. The version of the provider-specific structure should be
		/// included in the <c>wcProviderData</c> member.
		/// </summary>
		public ushort wVersion = 1;

		SIZE_T IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf<COMMCONFIG_UNMGD>();

		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
		{
			if (managedObject is not COMMCONFIG cc) throw new ArgumentException($"Invalid type {managedObject?.GetType().FullName ?? "null"}", nameof(managedObject));
			var off = (uint)Marshal.OffsetOf<COMMCONFIG_UNMGD>(nameof(wcProviderData)).ToInt32();
			COMMCONFIG_UNMGD ccu = new()
			{
				wVersion = cc.wVersion,
				dcb = cc.dcb,
				dwProviderSubType = cc.dwProviderSubType,
				dwProviderOffset = (cc.wcProviderData?.Length ?? 0) == 0 ? 0 : off,
				dwProviderSize = (uint)(cc.wcProviderData?.Length ?? 0),
			};
			SafeCoTaskMemStruct<COMMCONFIG_UNMGD> mem = new(ccu, ccu.dwSize + ccu.dwProviderSize - sizeof(ushort));
			if (cc.wcProviderData != null && cc.wcProviderData.Length > 0)
				mem.DangerousGetHandle().Write(cc.wcProviderData, ccu.dwProviderOffset, mem.Size);
			return mem;
		}

		object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SIZE_T allocatedBytes)
		{
			if (pNativeData == default || allocatedBytes == default) return null;
			ref COMMCONFIG_UNMGD cc = ref pNativeData.AsRef<COMMCONFIG_UNMGD>();
			return new COMMCONFIG()
			{
				wVersion = cc.wVersion,
				dcb = cc.dcb,
				dwProviderSubType = cc.dwProviderSubType,
				wcProviderData = cc.dwProviderOffset == 0 || cc.dwProviderSize == 0 ? [] : pNativeData.Offset(cc.dwProviderOffset).AsSpan<byte>(cc.dwProviderSize).ToArray()
			};
		}

		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		internal struct COMMCONFIG_UNMGD()
		{
			public uint dwSize = (uint)Marshal.SizeOf<COMMCONFIG_UNMGD>();
			public ushort wVersion = 1;
			public ushort wReserved;
			public DCB dcb = DCB.Default;
			public PROV_SUB_TYPE dwProviderSubType;
			public uint dwProviderOffset;
			public uint dwProviderSize;
			public ushort wcProviderData;
		}
	}
}