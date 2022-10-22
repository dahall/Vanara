using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class WinMm
	{
		/// <summary>Point-of-view hat is pressed backward. The value 18,000 represents an orientation of 180.00 degrees (to the rear).</summary>
		public const int JOY_POVBACKWARD = 18000;

		/// <summary>Point-of-view hat is in the neutral position. The value -1 means the point-of-view hat has no angle to report.</summary>
		public const int JOY_POVCENTERED = -1;

		/// <summary>Point-of-view hat is pressed forward. The value 0 represents an orientation of 0.00 degrees (straight ahead).</summary>
		public const int JOY_POVFORWARD = 0;

		/// <summary>
		/// Point-of-view hat is being pressed to the left. The value 27,000 represents an orientation of 270.00 degrees (90.00 degrees to
		/// the left).
		/// </summary>
		public const int JOY_POVLEFT = 27000;

		/// <summary>Point-of-view hat is pressed to the right. The value 9,000 represents an orientation of 90.00 degrees (to the right).</summary>
		public const int JOY_POVRIGHT = 9000;

		/// <summary></summary>
		[PInvokeData("joystickapi.h")]
		[Flags]
		public enum JOY_BUTTON : uint
		{
			/// <summary>First joystick button is pressed.</summary>
			JOY_BUTTON1 = 0x0001,

			/// <summary>Second joystick button is pressed.</summary>
			JOY_BUTTON2 = 0x0002,

			/// <summary>Third joystick button is pressed.</summary>
			JOY_BUTTON3 = 0x0004,

			/// <summary>Fourth joystick button is pressed.</summary>
			JOY_BUTTON4 = 0x0008,

			/// <summary></summary>
			JOY_BUTTON1CHG = 0x0100,

			/// <summary></summary>
			JOY_BUTTON2CHG = 0x0200,

			/// <summary></summary>
			JOY_BUTTON3CHG = 0x0400,

			/// <summary></summary>
			JOY_BUTTON4CHG = 0x0800,

			/// <summary></summary>
			JOY_BUTTON5 = 0x00000010,

			/// <summary></summary>
			JOY_BUTTON6 = 0x00000020,

			/// <summary></summary>
			JOY_BUTTON7 = 0x00000040,

			/// <summary></summary>
			JOY_BUTTON8 = 0x00000080,

			/// <summary></summary>
			JOY_BUTTON9 = 0x00000100,

			/// <summary></summary>
			JOY_BUTTON10 = 0x00000200,

			/// <summary></summary>
			JOY_BUTTON11 = 0x00000400,

			/// <summary></summary>
			JOY_BUTTON12 = 0x00000800,

			/// <summary></summary>
			JOY_BUTTON13 = 0x00001000,

			/// <summary></summary>
			JOY_BUTTON14 = 0x00002000,

			/// <summary></summary>
			JOY_BUTTON15 = 0x00004000,

			/// <summary></summary>
			JOY_BUTTON16 = 0x00008000,

			/// <summary></summary>
			JOY_BUTTON17 = 0x00010000,

			/// <summary></summary>
			JOY_BUTTON18 = 0x00020000,

			/// <summary></summary>
			JOY_BUTTON19 = 0x00040000,

			/// <summary></summary>
			JOY_BUTTON20 = 0x00080000,

			/// <summary></summary>
			JOY_BUTTON21 = 0x00100000,

			/// <summary></summary>
			JOY_BUTTON22 = 0x00200000,

			/// <summary></summary>
			JOY_BUTTON23 = 0x00400000,

			/// <summary></summary>
			JOY_BUTTON24 = 0x00800000,

			/// <summary></summary>
			JOY_BUTTON25 = 0x01000000,

			/// <summary></summary>
			JOY_BUTTON26 = 0x02000000,

			/// <summary></summary>
			JOY_BUTTON27 = 0x04000000,

			/// <summary></summary>
			JOY_BUTTON28 = 0x08000000,

			/// <summary></summary>
			JOY_BUTTON29 = 0x10000000,

			/// <summary></summary>
			JOY_BUTTON30 = 0x20000000,

			/// <summary></summary>
			JOY_BUTTON31 = 0x40000000,

			/// <summary></summary>
			JOY_BUTTON32 = 0x80000000,
		}

		/// <summary>Joystick capabilities</summary>
		[Flags]
		public enum JOYCAPSF
		{
			/// <summary>Joystick has z-coordinate information.</summary>
			JOYCAPS_HASZ = 0x0001,

			/// <summary>Joystick has rudder (fourth axis) information.</summary>
			JOYCAPS_HASR = 0x0002,

			/// <summary>Joystick has u-coordinate (fifth axis) information.</summary>
			JOYCAPS_HASU = 0x0004,

			/// <summary>Joystick has v-coordinate (sixth axis) information.</summary>
			JOYCAPS_HASV = 0x0008,

			/// <summary>Joystick has point-of-view information.</summary>
			JOYCAPS_HASPOV = 0x0010,

			/// <summary>Joystick point-of-view supports discrete values (centered, forward, backward, left, and right).</summary>
			JOYCAPS_POV4DIR = 0x0020,

			/// <summary>Joystick point-of-view supports continuous degree bearings.</summary>
			JOYCAPS_POVCTS = 0x0040,
		}

		/// <summary>
		/// Flags indicating the valid information returned in this structure. Members that do not contain valid information are set to zero.
		/// </summary>
		[PInvokeData("joystickapi.h")]
		[Flags]
		public enum JOYINFOEXF : uint
		{
			/// <summary>The dwXpos member contains valid data for the x-coordinate of the joystick.</summary>
			JOY_RETURNX = 0x00000001,

			/// <summary>The dwYpos member contains valid data for the y-coordinate of the joystick.</summary>
			JOY_RETURNY = 0x00000002,

			/// <summary>The dwZpos member contains valid data for the z-coordinate of the joystick.</summary>
			JOY_RETURNZ = 0x00000004,

			/// <summary>The dwRpos member contains valid rudder pedal data. This information represents another (fourth) axis.</summary>
			JOY_RETURNR = 0x00000008,

			/// <summary>
			/// The dwUpos member contains valid data for a fifth axis of the joystick, if such an axis is available, or returns zero otherwise.
			/// </summary>
			JOY_RETURNU = 0x00000010,

			/// <summary>
			/// The dwVpos member contains valid data for a sixth axis of the joystick, if such an axis is available, or returns zero otherwise.
			/// </summary>
			JOY_RETURNV = 0x00000020,

			/// <summary>The dwPOV member contains valid information about the point-of-view control, expressed in discrete units.</summary>
			JOY_RETURNPOV = 0x00000040,

			/// <summary>The dwButtons member contains valid information about the state of each joystick button.</summary>
			JOY_RETURNBUTTONS = 0x00000080,

			/// <summary>Data stored in this structure is uncalibrated joystick readings.</summary>
			JOY_RETURNRAWDATA = 0x00000100,

			/// <summary>
			/// The dwPOV member contains valid information about the point-of-view control expressed in continuous, one-hundredth degree units.
			/// </summary>
			JOY_RETURNPOVCTS = 0x00000200,

			/// <summary>Centers the joystick neutral position to the middle value of each axis of movement.</summary>
			JOY_RETURNCENTERED = 0x00000400,

			/// <summary></summary>
			JOY_USEDEADZONE = 0x00000800,

			/// <summary>Equivalent to setting all of the JOY_RETURN bits except JOY_RETURNRAWDATA.</summary>
			JOY_RETURNALL = JOY_RETURNX | JOY_RETURNY | JOY_RETURNZ | JOY_RETURNR | JOY_RETURNU | JOY_RETURNV | JOY_RETURNPOV | JOY_RETURNBUTTONS,

			/// <summary>Read the joystick port even if the driver does not detect a device.</summary>
			JOY_CAL_READALWAYS = 0x00010000,

			/// <summary>Reads the x- and y-coordinates and place the raw values in dwXpos and dwYpos.</summary>
			JOY_CAL_READXYONLY = 0x00020000,

			/// <summary>Read the x-, y-, and z-coordinates and store the raw values in dwXpos, dwYpos, and dwZpos.</summary>
			JOY_CAL_READ3 = 0x00040000,

			/// <summary>
			/// Read the rudder information and the x-, y-, and z-coordinates and store the raw values in dwXpos, dwYpos, dwZpos, and dwRpos.
			/// </summary>
			JOY_CAL_READ4 = 0x00080000,

			/// <summary>Read the x-coordinate and store the raw (uncalibrated) value in dwXpos.</summary>
			JOY_CAL_READXONLY = 0x00100000,

			/// <summary>Reads the y-coordinate and store the raw value in dwYpos.</summary>
			JOY_CAL_READYONLY = 0x00200000,

			/// <summary>
			/// Read the rudder information and the x-, y-, z-, and u-coordinates and store the raw values in dwXpos, dwYpos, dwZpos,
			/// dwRpos, and dwUpos.
			/// </summary>
			JOY_CAL_READ5 = 0x00400000,

			/// <summary>Read the raw v-axis data if a joystick mini driver is present that will provide the data. Returns zero otherwise.</summary>
			JOY_CAL_READ6 = 0x00800000,

			/// <summary>Read the z-coordinate and store the raw value in dwZpos.</summary>
			JOY_CAL_READZONLY = 0x01000000,

			/// <summary>
			/// Read the rudder information if a joystick mini-driver is present that will provide the data and store the raw value in
			/// dwRpos. Return zero otherwise.
			/// </summary>
			JOY_CAL_READRONLY = 0x02000000,

			/// <summary>
			/// Read the u-coordinate if a joystick mini-driver is present that will provide the data and store the raw value in dwUpos.
			/// Return zero otherwise.
			/// </summary>
			JOY_CAL_READUONLY = 0x04000000,

			/// <summary>
			/// Read the v-coordinate if a joystick mini-driver is present that will provide the data and store the raw value in dwVpos.
			/// Return zero otherwise.
			/// </summary>
			JOY_CAL_READVONLY = 0x08000000,
		}

		private enum JOY
		{
			/// <summary></summary>
			JOYSTICKID1 = 0,

			/// <summary>joystick driver capabilites</summary>
			JOYSTICKID2 = 1,
		}

		/// <summary>
		/// The <c>joyConfigChanged</c> function informs the joystick driver that the configuration has changed and should be reloaded from
		/// the registry.
		/// </summary>
		/// <param name="dwFlags">Reserved for future use. Must equal zero.</param>
		/// <returns>Returns JOYERR_NOERROR if successful. Returns JOYERR_PARMS if the parameter is non-zero.</returns>
		/// <remarks>
		/// <para>
		/// This function causes a window message to be sent to all top-level windows. This message may be defined by applications that need
		/// to respond to changes in joystick calibration by using <c>RegisterWindowMessage</c> with the following message ID:
		/// </para>
		/// <para>
		/// <code> #define JOY_CONFIGCHANGED_MSGSTRING "MSJSTICK_VJOYD_MSGSTR"</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joyconfigchanged MMRESULT joyConfigChanged( DWORD
		// dwFlags );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joyConfigChanged")]
		public static extern MMRESULT joyConfigChanged(uint dwFlags = 0);

		/// <summary>The <c>joyGetDevCaps</c> function queries a joystick to determine its capabilities.</summary>
		/// <param name="uJoyID">
		/// Identifier of the joystick to be queried. Valid values for uJoyID range from -1 to 15. A value of -1 enables retrieval of the
		/// <c>szRegKey</c> member of the JOYCAPS structure whether a device is present or not.
		/// </param>
		/// <param name="pjc">Pointer to a JOYCAPS structure to contain the capabilities of the joystick.</param>
		/// <param name="cbjc">Size, in bytes, of the JOYCAPS structure.</param>
		/// <returns>
		/// <para>Returns JOYERR_NOERROR if successful or one of the following error values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>
		/// The joystick driver is not present, or the specified joystick identifier is invalid. The specified joystick identifier is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>An invalid parameter was passed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use the joyGetNumDevs function to determine the number of joystick devices supported by the driver.</para>
		/// <para>This method fails when passed an invalid value for the cbjc parameter.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joygetdevcaps MMRESULT joyGetDevCaps( UINT uJoyID,
		// LPJOYCAPS pjc, UINT cbjc );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joyGetDevCaps")]
		public static extern MMRESULT joyGetDevCaps(int uJoyID, ref JOYCAPS pjc, uint cbjc);

		/// <summary>The <c>joyGetNumDevs</c> function queries the joystick driver for the number of joysticks it supports.</summary>
		/// <returns>
		/// The <c>joyGetNumDevs</c> function returns the number of joysticks supported by the current driver or zero if no driver is installed.
		/// </returns>
		/// <remarks>
		/// Use the joyGetPos function to determine whether a given joystick is physically attached to the system. If the specified joystick
		/// is not connected, <c>joyGetPos</c> returns a JOYERR_UNPLUGGED error value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joygetnumdevs UINT joyGetNumDevs();
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joyGetNumDevs")]
		public static extern uint joyGetNumDevs();

		/// <summary>The <c>joyGetPos</c> function queries a joystick for its position and button status.</summary>
		/// <param name="uJoyID">Identifier of the joystick to be queried. Valid values for uJoyID range from zero (JOYSTICKID1) to 15.</param>
		/// <param name="pji">Pointer to a JOYINFO structure that contains the position and button status of the joystick.</param>
		/// <returns>
		/// <para>Returns JOYERR_NOERROR if successful or one of the following error values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>The joystick driver is not present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>An invalid parameter was passed.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_UNPLUGGED</term>
		/// <term>The specified joystick is not connected to the system.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// For devices that have four to six axes of movement, a point-of-view control, or more than four buttons, use the joyGetPosEx function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joygetpos MMRESULT joyGetPos( UINT uJoyID,
		// LPJOYINFO pji );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joyGetPos")]
		public static extern MMRESULT joyGetPos(int uJoyID, out JOYINFO pji);

		/// <summary>The <c>joyGetPosEx</c> function queries a joystick for its position and button status.</summary>
		/// <param name="uJoyID">Identifier of the joystick to be queried. Valid values for uJoyID range from zero (JOYSTICKID1) to 15.</param>
		/// <param name="pji">
		/// Pointer to a JOYINFOEX structure that contains extended position information and button status of the joystick. You must set the
		/// <c>dwSize</c> and <c>dwFlags</c> members or <c>joyGetPosEx</c> will fail. The information returned from <c>joyGetPosEx</c>
		/// depends on the flags you specify in <c>dwFlags</c>.
		/// </param>
		/// <returns>
		/// <para>Returns JOYERR_NOERROR if successful or one of the following error values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>The joystick driver is not present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>An invalid parameter was passed.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The specified joystick identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_UNPLUGGED</term>
		/// <term>The specified joystick is not connected to the system.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_PARMS</term>
		/// <term>The specified joystick identifier is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function provides access to extended devices such as rudder pedals, point-of-view hats, devices with a large number of
		/// buttons, and coordinate systems using up to six axes. For joystick devices that use three axes or fewer and have fewer than four
		/// buttons, use the joyGetPos function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joygetposex MMRESULT joyGetPosEx( UINT uJoyID,
		// LPJOYINFOEX pji );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joyGetPosEx")]
		public static extern MMRESULT joyGetPosEx(int uJoyID, ref JOYINFOEX pji);

		/// <summary>The <c>joyGetThreshold</c> function queries a joystick for its current movement threshold.</summary>
		/// <param name="uJoyID">Identifier of the joystick. Valid values for uJoyID range from zero (JOYSTICKID1) to 15.</param>
		/// <param name="puThreshold">Pointer to a variable that contains the movement threshold value.</param>
		/// <returns>
		/// <para>Returns JOYERR_NOERROR if successful or one of the following error values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>The joystick driver is not present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>An invalid parameter was passed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The movement threshold is the distance the joystick must be moved before a joystick position-change message (MM_JOY1MOVE,
		/// MM_JOY1ZMOVE, MM_JOY2MOVE, or MM_JOY2ZMOVE) is sent to a window that has captured the device. The threshold is initially zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joygetthreshold MMRESULT joyGetThreshold( UINT
		// uJoyID, LPUINT puThreshold );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joyGetThreshold")]
		public static extern MMRESULT joyGetThreshold(int uJoyID, out uint puThreshold);

		/// <summary>The <c>joyReleaseCapture</c> function releases the specified captured joystick.</summary>
		/// <param name="uJoyID">Identifier of the joystick to be released. Valid values for uJoyID range from zero (JOYSTICKID1) to 15.</param>
		/// <returns>
		/// <para>Returns JOYERR_NOERROR if successful or one of the following error values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>The joystick driver is not present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALIDPARAM</term>
		/// <term>The specified joystick device identifier uJoyID is invalid.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_PARMS</term>
		/// <term>The specified joystick device identifier uJoyID is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This method returns JOYERR_NOERROR when passed a valid joystick identifier that has not been captured.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joyreleasecapture MMRESULT joyReleaseCapture( UINT
		// uJoyID );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joyReleaseCapture")]
		public static extern MMRESULT joyReleaseCapture(int uJoyID);

		/// <summary>The <c>joySetCapture</c> function captures a joystick by causing its messages to be sent to the specified window.</summary>
		/// <param name="hwnd">Handle to the window to receive the joystick messages.</param>
		/// <param name="uJoyID">Identifier of the joystick to be captured. Valid values for uJoyID range from zero (JOYSTICKID1) to 15.</param>
		/// <param name="uPeriod">Polling frequency, in milliseconds.</param>
		/// <param name="fChanged">
		/// Change position flag. Specify <c>TRUE</c> for this parameter to send messages only when the position changes by a value greater
		/// than the joystick movement threshold. Otherwise, messages are sent at the polling frequency specified in uPeriod.
		/// </param>
		/// <returns>
		/// <para>Returns JOYERR_NOERROR if successful or one of the following error values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>The joystick driver is not present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>Invalid joystick ID or hwnd is NULL.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_NOCANDO</term>
		/// <term>Cannot capture joystick input because a required service (such as a Windows timer) is unavailable.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_UNPLUGGED</term>
		/// <term>The specified joystick is not connected to the system.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_PARMS</term>
		/// <term>Invalid joystick ID or hwnd is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the specified joystick is currently captured, the function returns undefined behavior. Call the joyReleaseCapture function to
		/// release the captured joystick, or destroy the window to release the joystick automatically.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joysetcapture MMRESULT joySetCapture( HWND hwnd,
		// UINT uJoyID, UINT uPeriod, BOOL fChanged );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joySetCapture")]
		public static extern MMRESULT joySetCapture(HWND hwnd, int uJoyID, uint uPeriod, [MarshalAs(UnmanagedType.Bool)] bool fChanged);

		/// <summary>The <c>joySetThreshold</c> function sets the movement threshold of a joystick.</summary>
		/// <param name="uJoyID">Identifier of the joystick. Valid values for uJoyID range from zero (JOYSTICKID1) to 15.</param>
		/// <param name="uThreshold">New movement threshold.</param>
		/// <returns>
		/// <para>Returns JOYERR_NOERROR if successful or one of the following error values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>The joystick driver is not present.</term>
		/// </item>
		/// <item>
		/// <term>JOYERR_PARMS</term>
		/// <term>The specified joystick device identifier uJoyID is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The movement threshold is the distance the joystick must be moved before a joystick position-change message (MM_JOY1MOVE,
		/// MM_JOY1ZMOVE, MM_JOY2MOVE, or MM_JOY2ZMOVE) is sent to a window that has captured the device. The threshold is initially zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/nf-joystickapi-joysetthreshold MMRESULT joySetThreshold( UINT
		// uJoyID, UINT uThreshold );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("joystickapi.h", MSDNShortId = "NF:joystickapi.joySetThreshold")]
		public static extern MMRESULT joySetThreshold(int uJoyID, uint uThreshold);

		/// <summary>The <c>JOYCAPS</c> structure contains information about the joystick capabilities.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/ns-joystickapi-joycaps typedef struct joycaps_tag { WORD wMid;
		// WORD wPid; char szPname[MAXPNAMELEN]; UINT wXmin; UINT wXmax; UINT wYmin; UINT wYmax; UINT wZmin; UINT wZmax; UINT wNumButtons;
		// UINT wPeriodMin; UINT wPeriodMax; UINT wRmin; UINT wRmax; UINT wUmin; UINT wUmax; UINT wVmin; UINT wVmax; UINT wCaps; UINT
		// wMaxAxes; UINT wNumAxes; UINT wMaxButtons; char szRegKey[MAXPNAMELEN]; char szOEMVxD[MAX_JOYSTICKOEMVXDNAME]; } JOYCAPS,
		// *PJOYCAPS, *NPJOYCAPS, *LPJOYCAPS;
		[PInvokeData("joystickapi.h", MSDNShortId = "NS:joystickapi.joycaps_tag")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct JOYCAPS
		{
			/// <summary>Manufacturer identifier. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.</summary>
			public ushort wMid;

			/// <summary>Product identifier. Product identifiers are defined in Manufacturer and Product Identifiers.</summary>
			public MMPRODID wPid;

			/// <summary>Null-terminated string containing the joystick product name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAXPNAMELEN)]
			public string szPname;

			/// <summary>Minimum X-coordinate.</summary>
			public uint wXmin;

			/// <summary>Maximum X-coordinate.</summary>
			public uint wXmax;

			/// <summary>Minimum Y-coordinate.</summary>
			public uint wYmin;

			/// <summary>Maximum Y-coordinate.</summary>
			public uint wYmax;

			/// <summary>Minimum Z-coordinate.</summary>
			public uint wZmin;

			/// <summary>Maximum Z-coordinate.</summary>
			public uint wZmax;

			/// <summary>Number of joystick buttons.</summary>
			public uint wNumButtons;

			/// <summary>Smallest polling frequency supported when captured by the joySetCapture function.</summary>
			public uint wPeriodMin;

			/// <summary>Largest polling frequency supported when captured by <c>joySetCapture</c>.</summary>
			public uint wPeriodMax;

			/// <summary>Minimum rudder value. The rudder is a fourth axis of movement.</summary>
			public uint wRmin;

			/// <summary>Maximum rudder value. The rudder is a fourth axis of movement.</summary>
			public uint wRmax;

			/// <summary>Minimum u-coordinate (fifth axis) values.</summary>
			public uint wUmin;

			/// <summary>Maximum u-coordinate (fifth axis) values.</summary>
			public uint wUmax;

			/// <summary>Minimum v-coordinate (sixth axis) values.</summary>
			public uint wVmin;

			/// <summary>Maximum v-coordinate (sixth axis) values.</summary>
			public uint wVmax;

			/// <summary>
			/// <para>Joystick capabilities The following flags define individual capabilities that a joystick might have:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>JOYCAPS_HASZ</term>
			/// <term>Joystick has z-coordinate information.</term>
			/// </item>
			/// <item>
			/// <term>JOYCAPS_HASR</term>
			/// <term>Joystick has rudder (fourth axis) information.</term>
			/// </item>
			/// <item>
			/// <term>JOYCAPS_HASU</term>
			/// <term>Joystick has u-coordinate (fifth axis) information.</term>
			/// </item>
			/// <item>
			/// <term>JOYCAPS_HASV</term>
			/// <term>Joystick has v-coordinate (sixth axis) information.</term>
			/// </item>
			/// <item>
			/// <term>JOYCAPS_HASPOV</term>
			/// <term>Joystick has point-of-view information.</term>
			/// </item>
			/// <item>
			/// <term>JOYCAPS_POV4DIR</term>
			/// <term>Joystick point-of-view supports discrete values (centered, forward, backward, left, and right).</term>
			/// </item>
			/// <item>
			/// <term>JOYCAPS_POVCTS</term>
			/// <term>Joystick point-of-view supports continuous degree bearings.</term>
			/// </item>
			/// </list>
			/// </summary>
			public JOYCAPSF wCaps;

			/// <summary>Maximum number of axes supported by the joystick.</summary>
			public uint wMaxAxes;

			/// <summary>Number of axes currently in use by the joystick.</summary>
			public uint wNumAxes;

			/// <summary>Maximum number of buttons supported by the joystick.</summary>
			public uint wMaxButtons;

			/// <summary>Null-terminated string containing the registry key for the joystick.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAXPNAMELEN)]
			public string szRegKey;

			/// <summary>Null-terminated string identifying the joystick driver OEM.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_JOYSTICKOEMVXDNAME)]
			public string szOEMVxD;
		}

		/// <summary>The <c>JOYINFO</c> structure contains information about the joystick position and button state.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/ns-joystickapi-joyinfo typedef struct joyinfo_tag { UINT wXpos;
		// UINT wYpos; UINT wZpos; UINT wButtons; } JOYINFO, *PJOYINFO, *NPJOYINFO, *LPJOYINFO;
		[PInvokeData("joystickapi.h", MSDNShortId = "NS:joystickapi.joyinfo_tag")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOYINFO
		{
			/// <summary>Current X-coordinate.</summary>
			public uint wXpos;

			/// <summary>Current Y-coordinate.</summary>
			public uint wYpos;

			/// <summary>Current Z-coordinate.</summary>
			public uint wZpos;

			/// <summary>
			/// <para>Current state of joystick buttons described by one or more of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Button</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>JOY_BUTTON1</term>
			/// <term>First joystick button is pressed.</term>
			/// </item>
			/// <item>
			/// <term>JOY_BUTTON2</term>
			/// <term>Second joystick button is pressed.</term>
			/// </item>
			/// <item>
			/// <term>JOY_BUTTON3</term>
			/// <term>Third joystick button is pressed.</term>
			/// </item>
			/// <item>
			/// <term>JOY_BUTTON4</term>
			/// <term>Fourth joystick button is pressed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public JOY_BUTTON wButtons;
		}

		/// <summary>
		/// The <c>JOYINFOEX</c> structure contains extended information about the joystick position, point-of-view position, and button state.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of the <c>dwSize</c> member is also used to identify the version number for the structure when it's passed to the
		/// joyGetPosEx function.
		/// </para>
		/// <para>
		/// Most devices with a point-of-view control have only five positions. When the JOY_RETURNPOV flag is set, these positions are
		/// reported by using the following constants:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Point-Of-View Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>JOY_POVBACKWARD</term>
		/// <term>Point-of-view hat is pressed backward. The value 18,000 represents an orientation of 180.00 degrees (to the rear).</term>
		/// </item>
		/// <item>
		/// <term>JOY_POVCENTERED</term>
		/// <term>Point-of-view hat is in the neutral position. The value -1 means the point-of-view hat has no angle to report.</term>
		/// </item>
		/// <item>
		/// <term>JOY_POVFORWARD</term>
		/// <term>Point-of-view hat is pressed forward. The value 0 represents an orientation of 0.00 degrees (straight ahead).</term>
		/// </item>
		/// <item>
		/// <term>JOY_POVLEFT</term>
		/// <term>
		/// Point-of-view hat is being pressed to the left. The value 27,000 represents an orientation of 270.00 degrees (90.00 degrees to
		/// the left).
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOY_POVRIGHT</term>
		/// <term>Point-of-view hat is pressed to the right. The value 9,000 represents an orientation of 90.00 degrees (to the right).</term>
		/// </item>
		/// </list>
		/// <para>
		/// The default joystick driver currently supports these five discrete directions. If an application can accept only the defined
		/// point-of-view values, it must use the JOY_RETURNPOV flag. If an application can accept other degree readings, it should use the
		/// JOY_RETURNPOVCTS flag to obtain continuous data if it is available. The JOY_RETURNPOVCTS flag also supports the JOY_POV
		/// constants used with the JOY_RETURNPOV flag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/joystickapi/ns-joystickapi-joyinfoex typedef struct joyinfoex_tag { DWORD
		// dwSize; DWORD dwFlags; DWORD dwXpos; DWORD dwYpos; DWORD dwZpos; DWORD dwRpos; DWORD dwUpos; DWORD dwVpos; DWORD dwButtons; DWORD
		// dwButtonNumber; DWORD dwPOV; DWORD dwReserved1; DWORD dwReserved2; } JOYINFOEX, *PJOYINFOEX, *NPJOYINFOEX, *LPJOYINFOEX;
		[PInvokeData("joystickapi.h", MSDNShortId = "NS:joystickapi.joyinfoex_tag")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOYINFOEX
		{
			/// <summary>Size, in bytes, of this structure.</summary>
			public uint dwSize;

			/// <summary>
			/// <para>
			/// Flags indicating the valid information returned in this structure. Members that do not contain valid information are set to
			/// zero. The following flags are defined:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>JOY_RETURNALL</term>
			/// <term>Equivalent to setting all of the JOY_RETURN bits except JOY_RETURNRAWDATA.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNBUTTONS</term>
			/// <term>The dwButtons member contains valid information about the state of each joystick button.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNCENTERED</term>
			/// <term>Centers the joystick neutral position to the middle value of each axis of movement.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNPOV</term>
			/// <term>The dwPOV member contains valid information about the point-of-view control, expressed in discrete units.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNPOVCTS</term>
			/// <term>
			/// The dwPOV member contains valid information about the point-of-view control expressed in continuous, one-hundredth degree units.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNR</term>
			/// <term>The dwRpos member contains valid rudder pedal data. This information represents another (fourth) axis.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNRAWDATA</term>
			/// <term>Data stored in this structure is uncalibrated joystick readings.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNU</term>
			/// <term>
			/// The dwUpos member contains valid data for a fifth axis of the joystick, if such an axis is available, or returns zero otherwise.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNV</term>
			/// <term>
			/// The dwVpos member contains valid data for a sixth axis of the joystick, if such an axis is available, or returns zero otherwise.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNX</term>
			/// <term>The dwXpos member contains valid data for the x-coordinate of the joystick.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNY</term>
			/// <term>The dwYpos member contains valid data for the y-coordinate of the joystick.</term>
			/// </item>
			/// <item>
			/// <term>JOY_RETURNZ</term>
			/// <term>The dwZpos member contains valid data for the z-coordinate of the joystick.</term>
			/// </item>
			/// </list>
			/// <para>The following flags provide data to calibrate a joystick and are intended for custom calibration applications.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>JOY_CAL_READ3</term>
			/// <term>Read the x-, y-, and z-coordinates and store the raw values in dwXpos, dwYpos, and dwZpos.</term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READ4</term>
			/// <term>
			/// Read the rudder information and the x-, y-, and z-coordinates and store the raw values in dwXpos, dwYpos, dwZpos, and dwRpos.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READ5</term>
			/// <term>
			/// Read the rudder information and the x-, y-, z-, and u-coordinates and store the raw values in dwXpos, dwYpos, dwZpos,
			/// dwRpos, and dwUpos.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READ6</term>
			/// <term>Read the raw v-axis data if a joystick mini driver is present that will provide the data. Returns zero otherwise.</term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READALWAYS</term>
			/// <term>Read the joystick port even if the driver does not detect a device.</term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READRONLY</term>
			/// <term>
			/// Read the rudder information if a joystick mini-driver is present that will provide the data and store the raw value in
			/// dwRpos. Return zero otherwise.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READXONLY</term>
			/// <term>Read the x-coordinate and store the raw (uncalibrated) value in dwXpos.</term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READXYONLY</term>
			/// <term>Reads the x- and y-coordinates and place the raw values in dwXpos and dwYpos.</term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READYONLY</term>
			/// <term>Reads the y-coordinate and store the raw value in dwYpos.</term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READZONLY</term>
			/// <term>Read the z-coordinate and store the raw value in dwZpos.</term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READUONLY</term>
			/// <term>
			/// Read the u-coordinate if a joystick mini-driver is present that will provide the data and store the raw value in dwUpos.
			/// Return zero otherwise.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOY_CAL_READVONLY</term>
			/// <term>
			/// Read the v-coordinate if a joystick mini-driver is present that will provide the data and store the raw value in dwVpos.
			/// Return zero otherwise.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public JOYINFOEXF dwFlags;

			/// <summary>Current X-coordinate.</summary>
			public uint dwXpos;

			/// <summary>Current Y-coordinate.</summary>
			public uint dwYpos;

			/// <summary>Current Z-coordinate.</summary>
			public uint dwZpos;

			/// <summary>Current position of the rudder or fourth joystick axis.</summary>
			public uint dwRpos;

			/// <summary>Current fifth axis position.</summary>
			public uint dwUpos;

			/// <summary>Current sixth axis position.</summary>
			public uint dwVpos;

			/// <summary>
			/// Current state of the 32 joystick buttons. The value of this member can be set to any combination of JOY_BUTTON n flags,
			/// where n is a value in the range of 1 through 32 corresponding to the button that is pressed.
			/// </summary>
			public JOY_BUTTON dwButtons;

			/// <summary>Current button number that is pressed.</summary>
			public uint dwButtonNumber;

			/// <summary>
			/// Current position of the point-of-view control. Values for this member are in the range 0 through 35,900. These values
			/// represent the angle, in degrees, of each view multiplied by 100.
			/// </summary>
			public int dwPOV;

			/// <summary>Reserved; do not use.</summary>
			public uint dwReserved1;

			/// <summary>Reserved; do not use.</summary>
			public uint dwReserved2;
		}
	}
}