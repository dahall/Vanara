using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the WinMm.dll</summary>
public static partial class WinMm
{
	/// <summary></summary>
	public const int JOY_POV_NUMDIRS = 4;

	/// <summary></summary>
	[PInvokeData("mmddk.h")]
	[Flags]
	public enum JOY_ISCAL : uint
	{
		/// <summary>XY are calibrated</summary>
		JOY_ISCAL_XY = 0x00000001,

		/// <summary>Z is calibrated</summary>
		JOY_ISCAL_Z = 0x00000002,

		/// <summary>R is calibrated</summary>
		JOY_ISCAL_R = 0x00000004,

		/// <summary>U is calibrated</summary>
		JOY_ISCAL_U = 0x00000008,

		/// <summary>V is calibrated</summary>
		JOY_ISCAL_V = 0x00000010,

		/// <summary>POV is calibrated</summary>
		JOY_ISCAL_POV = 0x00000020,
	}

	/// <summary></summary>
	[PInvokeData("mmddk.h")]
	public enum JOY_POVVAL : uint
	{
		/// <summary></summary>
		JOY_POVVAL_FORWARD = 0,

		/// <summary></summary>
		JOY_POVVAL_BACKWARD = 1,

		/// <summary></summary>
		JOY_POVVAL_LEFT = 2,

		/// <summary></summary>
		JOY_POVVAL_RIGHT = 3,
	}

	/// <summary></summary>
	[PInvokeData("mmddk.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct JOYPOS
	{
		/// <summary></summary>
		public uint dwX;

		/// <summary></summary>
		public uint dwY;

		/// <summary></summary>
		public uint dwZ;

		/// <summary></summary>
		public uint dwR;

		/// <summary></summary>
		public uint dwU;

		/// <summary></summary>
		public uint dwV;
	}

	/// <summary></summary>
	[PInvokeData("mmddk.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct JOYRANGE
	{
		/// <summary></summary>
		public JOYPOS jpMin;

		/// <summary></summary>
		public JOYPOS jpMax;

		/// <summary></summary>
		public JOYPOS jpCenter;
	}

	/// <summary>The <c>JOYREGHWVALUES</c> structure contains the range of values returned by the hardware (filled in by calibration).</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmddk/ns-mmddk-joyreghwvalues typedef struct joyreghwvalues_tag { JOYRANGE
	// jrvHardware; DWORD dwPOVValues[JOY_POV_NUMDIRS]; DWORD dwCalFlags; } JOYREGHWVALUES, *LPJOYREGHWVALUES;
	[PInvokeData("mmddk.h", MSDNShortId = "NS:mmddk.joyreghwvalues_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct JOYREGHWVALUES
	{
		/// <summary>The values returned by the hardware.</summary>
		public JOYRANGE jrvHardware;

		/// <summary>The point-of-view (POV) values returned by the hardware.</summary>
		[MarshalAs(UnmanagedType.LPArray, SizeConst = JOY_POV_NUMDIRS)]
		public JOY_POVVAL[] dwPOVValues;

		/// <summary>What has been calibrated.</summary>
		public JOY_ISCAL dwCalFlags;
	}

	/// <summary>
	/// The
	/// <code>MDEVICECAPSEX</code>
	/// structure contains device capability information for Plug and Play (PnP) device drivers.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmddk/ns-mmddk-mdevicecapsex typedef struct { DWORD cbSize; LPVOID pCaps; } MDEVICECAPSEX;
	[PInvokeData("mmddk.h", MSDNShortId = "NS:mmddk.__unnamed_struct_1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MDEVICECAPSEX
	{
		/// <summary>Specifies the size of the structure, in bytes.</summary>
		public uint cbSize;

		/// <summary>Specifies the capabilities of the device. The format of this data is device specific.</summary>
		public IntPtr pCaps;
	}

	/// <summary>
	/// The
	/// <code>MIDIOPENDESC</code>
	/// structure is a client-filled structure that provides information about how to open a MIDI device.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmddk/ns-mmddk-midiopendesc typedef struct midiopendesc_tag { HMIDI hMidi;
	// DWORD_PTR dwCallback; DWORD_PTR dwInstance; DWORD_PTR dnDevNode; DWORD cIds; MIDIOPENSTRMID rgIds[1]; } MIDIOPENDESC;
	[PInvokeData("mmddk.h", MSDNShortId = "NS:mmddk.midiopendesc_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDIOPENDESC
	{
		/// <summary>
		/// Specifies the handle that the client uses to reference the device. This handle is assigned by WINMM. Use this handle when
		/// you notify the client with the DriverCallback function.
		/// </summary>
		public HMIDI hMidi;

		/// <summary>
		/// Specifies either the address of a callback function, a window handle, or a task handle, depending on the flags that are
		/// specified in the dwParam2 parameter of the MODM_OPEN message. If this field contains a handle, it is contained in the
		/// low-order word.
		/// </summary>
		public IntPtr dwCallback;

		/// <summary>
		/// Specifies a pointer to a DWORD that contains instance information for the client. This instance information is returned to
		/// the client whenever the driver notifies the client by using the <c>DriverCallback</c> function.
		/// </summary>
		public IntPtr dwInstance;

		/// <summary>Specifies a device node for the MIDI output device, if it is a Plug and Play (PnP) MIDI device.</summary>
		public IntPtr dnDevNode;

		/// <summary>Specifies the number of stream identifiers, if a stream is open.</summary>
		public uint cIds;

		/// <summary>Specifies an array of device identifiers. The number of identifiers is given by the <c>cIds</c> member.</summary>
		[MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]
		public MIDIOPENSTRMID[] rgIds;
	}

	/// <summary></summary>
	[PInvokeData("mmddk.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDIOPENSTRMID
	{
		/// <summary></summary>
		public uint dwStreamID;

		/// <summary></summary>
		public uint uDeviceID;
	}
}