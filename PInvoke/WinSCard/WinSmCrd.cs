#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using static Vanara.PInvoke.WinSCard.SCARD_CLASS;

namespace Vanara.PInvoke;

public static partial class WinSCard
{
	/// <summary>Nothing bigger than this from getAttr</summary>
	public const int MAXIMUM_ATTR_STRING_LENGTH = 32;

	/// <summary>Limit the readers on the system</summary>
	public const int MAXIMUM_SMARTCARD_READERS = 10;

	/// <summary>Smart card reader interface GUID</summary>
	public static readonly Guid GUID_DEVINTERFACE_SMARTCARD_READER = new(0x50DD5230, 0xBA8A, 0x11D1, 0xBF, 0x5D, 0x00, 0x00, 0xF8, 0x05, 0xF5, 0x30);

	public static readonly uint IOCTL_SMARTCARD_CONFISCATE = SCARD_CTL_CODE(4);

	public static readonly uint IOCTL_SMARTCARD_EJECT = SCARD_CTL_CODE(6);

	public static readonly uint IOCTL_SMARTCARD_GET_ATTRIBUTE = SCARD_CTL_CODE(2);

	public static readonly uint IOCTL_SMARTCARD_GET_FEATURE_REQUEST = SCARD_CTL_CODE(3400);

	public static readonly uint IOCTL_SMARTCARD_GET_LAST_ERROR = SCARD_CTL_CODE(15);

	public static readonly uint IOCTL_SMARTCARD_GET_PERF_CNTR = SCARD_CTL_CODE(16);

	public static readonly uint IOCTL_SMARTCARD_GET_STATE = SCARD_CTL_CODE(14);

	public static readonly uint IOCTL_SMARTCARD_IS_ABSENT = SCARD_CTL_CODE(11);

	public static readonly uint IOCTL_SMARTCARD_IS_PRESENT = SCARD_CTL_CODE(10);

	/// <summary>
	/// <para>This code is used to issue various power operations on a smart card.</para>
	/// <para>Parameters</para>
	/// <list type="bullet">
	/// <item>
	/// <term>dwOpenData [in] Handle returned from a call to the smart card reader driver's XXX_Open function.</term>
	/// </item>
	/// <item>
	/// <term>dwCode [in] Specifies this code.</term>
	/// </item>
	/// <item>
	/// <term>pBufIn [in] Contains one of the following codes to select a specific power operation.</term>
	/// </item>
	/// <item>
	/// <term>dwLenIn Ignored.</term>
	/// </item>
	/// <item>
	/// <term>pBufOut [out] Used with SCARD_COLD_RESET and SCARD_WARM_RESET to store a complete ATR from the smart card.</term>
	/// </item>
	/// <item>
	/// <term>dwLenOut [out] The size of the output buffer. This must be at least 33 bytes to hold a complete ATR.</term>
	/// </item>
	/// <item>
	/// <term>pdwActualOut [out] The actual number of bytes in the ATR.</term>
	/// </item>
	/// </list>
	/// <para>Return Values</para>
	/// <para>One of the following status values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Status</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The operation completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_UNRECOGNIZED_MEDIA</term>
	/// <term>The smart card is unsupported or unknown.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEDIA</term>
	/// <term>There is no smart card in the card reader.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_IO_TIMEOUT</term>
	/// <term>The operation has timed out.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Smart card reader drivers return Windows NT status values, rather than Win32 error values, as the return values from the driver's
	/// callback function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/embedded/ms920705(v%3dmsdn.10)
	[PInvokeData("winsmcrd.h")]
	public static readonly uint IOCTL_SMARTCARD_POWER = SCARD_CTL_CODE(1);

	public static readonly uint IOCTL_SMARTCARD_SET_ATTRIBUTE = SCARD_CTL_CODE(3);

	public static readonly uint IOCTL_SMARTCARD_SET_PROTOCOL = SCARD_CTL_CODE(12);

	public static readonly uint IOCTL_SMARTCARD_SWALLOW = SCARD_CTL_CODE(7);

	public static readonly uint IOCTL_SMARTCARD_TRANSMIT = SCARD_CTL_CODE(5);

	public static readonly uint SCARD_ATTR_ATR_STRING = SCARD_ATTR_VALUE(SCARD_CLASS_ICC_STATE, 0x0303);

	public static readonly uint SCARD_ATTR_CHANNEL_ID = SCARD_ATTR_VALUE(SCARD_CLASS_COMMUNICATIONS, 0x0110);

	public static readonly uint SCARD_ATTR_CHARACTERISTICS = SCARD_ATTR_VALUE(SCARD_CLASS_MECHANICAL, 0x0150);

	public static readonly uint SCARD_ATTR_CURRENT_BWT = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0209);

	public static readonly uint SCARD_ATTR_CURRENT_CLK = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0202);

	public static readonly uint SCARD_ATTR_CURRENT_CWT = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x020a);

	public static readonly uint SCARD_ATTR_CURRENT_D = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0204);

	public static readonly uint SCARD_ATTR_CURRENT_EBC_ENCODING = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x020b);

	public static readonly uint SCARD_ATTR_CURRENT_F = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0203);

	public static readonly uint SCARD_ATTR_CURRENT_IFSC = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0207);

	public static readonly uint SCARD_ATTR_CURRENT_IFSD = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0208);

	public static readonly uint SCARD_ATTR_CURRENT_IO_STATE = SCARD_ATTR_VALUE(SCARD_CLASS_ICC_STATE, 0x0302);

	public static readonly uint SCARD_ATTR_CURRENT_N = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0205);

	public static readonly uint SCARD_ATTR_CURRENT_PROTOCOL_TYPE = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0201);

	public static readonly uint SCARD_ATTR_CURRENT_W = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x0206);

	public static readonly uint SCARD_ATTR_DEFAULT_CLK = SCARD_ATTR_VALUE(SCARD_CLASS_PROTOCOL, 0x0121);

	public static readonly uint SCARD_ATTR_DEFAULT_DATA_RATE = SCARD_ATTR_VALUE(SCARD_CLASS_PROTOCOL, 0x0123);

	public static readonly uint SCARD_ATTR_DEVICE_FRIENDLY_NAME = Marshal.SystemDefaultCharSize == 2 ? SCARD_ATTR_DEVICE_FRIENDLY_NAME_W : SCARD_ATTR_DEVICE_FRIENDLY_NAME_A;

	public static readonly uint SCARD_ATTR_DEVICE_FRIENDLY_NAME_A = SCARD_ATTR_VALUE(SCARD_CLASS_SYSTEM, 0x0003);

	public static readonly uint SCARD_ATTR_DEVICE_FRIENDLY_NAME_W = SCARD_ATTR_VALUE(SCARD_CLASS_SYSTEM, 0x0005);

	public static readonly uint SCARD_ATTR_DEVICE_IN_USE = SCARD_ATTR_VALUE(SCARD_CLASS_SYSTEM, 0x0002);

	public static readonly uint SCARD_ATTR_DEVICE_SYSTEM_NAME = Marshal.SystemDefaultCharSize == 2 ? SCARD_ATTR_DEVICE_SYSTEM_NAME_W : SCARD_ATTR_DEVICE_SYSTEM_NAME_A;

	public static readonly uint SCARD_ATTR_DEVICE_SYSTEM_NAME_A = SCARD_ATTR_VALUE(SCARD_CLASS_SYSTEM, 0x0004);

	public static readonly uint SCARD_ATTR_DEVICE_SYSTEM_NAME_W = SCARD_ATTR_VALUE(SCARD_CLASS_SYSTEM, 0x0006);

	public static readonly uint SCARD_ATTR_DEVICE_UNIT = SCARD_ATTR_VALUE(SCARD_CLASS_SYSTEM, 0x0001);

	public static readonly uint SCARD_ATTR_ESC_AUTHREQUEST = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_DEFINED, 0xA005);

	public static readonly uint SCARD_ATTR_ESC_CANCEL = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_DEFINED, 0xA003);

	public static readonly uint SCARD_ATTR_ESC_RESET = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_DEFINED, 0xA000);

	public static readonly uint SCARD_ATTR_EXTENDED_BWT = SCARD_ATTR_VALUE(SCARD_CLASS_IFD_PROTOCOL, 0x020c);

	public static readonly uint SCARD_ATTR_ICC_INTERFACE_STATUS = SCARD_ATTR_VALUE(SCARD_CLASS_ICC_STATE, 0x0301);

	public static readonly uint SCARD_ATTR_ICC_PRESENCE = SCARD_ATTR_VALUE(SCARD_CLASS_ICC_STATE, 0x0300);

	public static readonly uint SCARD_ATTR_ICC_TYPE_PER_ATR = SCARD_ATTR_VALUE(SCARD_CLASS_ICC_STATE, 0x0304);

	public static readonly uint SCARD_ATTR_MAX_CLK = SCARD_ATTR_VALUE(SCARD_CLASS_PROTOCOL, 0x0122);

	public static readonly uint SCARD_ATTR_MAX_DATA_RATE = SCARD_ATTR_VALUE(SCARD_CLASS_PROTOCOL, 0x0124);

	public static readonly uint SCARD_ATTR_MAX_IFSD = SCARD_ATTR_VALUE(SCARD_CLASS_PROTOCOL, 0x0125);

	public static readonly uint SCARD_ATTR_MAXINPUT = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_DEFINED, 0xA007);

	public static readonly uint SCARD_ATTR_POWER_MGMT_SUPPORT = SCARD_ATTR_VALUE(SCARD_CLASS_POWER_MGMT, 0x0131);

	public static readonly uint SCARD_ATTR_PROTOCOL_TYPES = SCARD_ATTR_VALUE(SCARD_CLASS_PROTOCOL, 0x0120);

	public static readonly uint SCARD_ATTR_SUPRESS_T1_IFS_REQUEST = SCARD_ATTR_VALUE(SCARD_CLASS_SYSTEM, 0x0007);

	public static readonly uint SCARD_ATTR_USER_AUTH_INPUT_DEVICE = SCARD_ATTR_VALUE(SCARD_CLASS_SECURITY, 0x0142);

	public static readonly uint SCARD_ATTR_USER_TO_CARD_AUTH_DEVICE = SCARD_ATTR_VALUE(SCARD_CLASS_SECURITY, 0x0140);

	public static readonly uint SCARD_ATTR_VENDOR_IFD_SERIAL_NO = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_INFO, 0x0103);

	public static readonly uint SCARD_ATTR_VENDOR_IFD_TYPE = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_INFO, 0x0101);

	public static readonly uint SCARD_ATTR_VENDOR_IFD_VERSION = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_INFO, 0x0102);

	public static readonly uint SCARD_ATTR_VENDOR_NAME = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_INFO, 0x0100);

	public static readonly uint SCARD_ATTR_VENDOR_SPECIFIC_INFO = SCARD_ATTR_VALUE(SCARD_CLASS_VENDOR_DEFINED, 0xA008);

	public static readonly uint SCARD_PERF_BYTES_TRANSMITTED = SCARD_ATTR_VALUE(SCARD_CLASS_PERF, 0x0002);

	public static readonly uint SCARD_PERF_NUM_TRANSMISSIONS = SCARD_ATTR_VALUE(SCARD_CLASS_PERF, 0x0001);

	public static readonly uint SCARD_PERF_TRANSMISSION_TIME = SCARD_ATTR_VALUE(SCARD_CLASS_PERF, 0x0003);

	/// <summary>Ioctl parameters 1 for IOCTL_SMARTCARD_POWER</summary>
	[PInvokeData("winsmcrd.h")]
	public enum SCARD_POWER : uint
	{
		/// <summary>Remove power from the smart card.</summary>
		SCARD_POWER_DOWN = 0,

		/// <summary>Power down the smart card and power it up again.</summary>
		SCARD_COLD_RESET = 1,

		/// <summary>Reset the smart card without removing power.</summary>
		SCARD_WARM_RESET = 2,
	}

	/// <summary>Acceptable protocols for a smartcard connection.</summary>
	[PInvokeData("winsmcrd.h")]
	[Flags]
	public enum SCARD_PROTOCOL : uint
	{
		/// <summary>
		/// SCARD_SHARE_DIRECT has been specified, so that no protocol negotiation has occurred. It is possible that there is no card in the reader.
		/// </summary>
		SCARD_PROTOCOL_UNDEFINED = 0x00000000,

		/// <summary>The ISO 7816/3 T=0 protocol is in use.</summary>
		SCARD_PROTOCOL_T0 = 0x00000001,

		/// <summary>The ISO 7816/3 T=1 protocol is in use.</summary>
		SCARD_PROTOCOL_T1 = 0x00000002,

		/// <summary>The Raw Transfer protocol is in use.</summary>
		SCARD_PROTOCOL_RAW = 0x00010000,

		/// <summary>This is the mask of ISO defined transmission protocols</summary>
		SCARD_PROTOCOL_Tx = SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1,

		/// <summary>Use the default transmission parameters / card clock freq.</summary>
		SCARD_PROTOCOL_DEFAULT = 0x80000000,

		/// <summary>Use optimal transmission parameters / card clock freq.</summary>
		SCARD_PROTOCOL_OPTIMAL = 0x00000000,
	}

	/// <summary>Reader properties.</summary>
	[PInvokeData("winsmcrd.h")]
	[Flags]
	public enum SCARD_READER : uint
	{
		/// <summary>Reader has a swallowing mechanism.</summary>
		SCARD_READER_SWALLOWS = 0x00000001,

		/// <summary>Reader can eject the smart card.</summary>
		SCARD_READER_EJECTS = 0x00000002,

		/// <summary>Reader can swallow the smart card.</summary>
		SCARD_READER_CONFISCATES = 0x00000004,

		/// <summary/>
		SCARD_READER_CONTACTLESS = 0x00000008,
	}

	/// <summary>Current state of the smart card in the reader.</summary>
	[PInvokeData("winsmcrd.h")]
	public enum SCARD_READER_STATE
	{
		/// <summary>Unknown.</summary>
		SCARD_UNKNOWN = 0,

		/// <summary>There is no card in the reader.</summary>
		SCARD_ABSENT = 1,

		/// <summary>There is a card in the reader, but it has not been moved into position for use.</summary>
		SCARD_PRESENT = 2,

		/// <summary>There is a card in the reader in position for use. The card is not powered.</summary>
		SCARD_SWALLOWED = 3,

		/// <summary>Power is being provided to the card, but the reader driver is unaware of the mode of the card.</summary>
		SCARD_POWERED = 4,

		/// <summary>The card has been reset and is awaiting PTS negotiation.</summary>
		SCARD_NEGOTIABLE = 5,

		/// <summary>The card has been reset and specific communication protocols have been established.</summary>
		SCARD_SPECIFIC = 6,
	}

	/// <summary>A Smartcard reader type.</summary>
	[PInvokeData("winsmcrd.h")]
	[Flags]
	public enum SCARD_READER_TYPE
	{
		/// <summary>Serial reader</summary>
		SCARD_READER_TYPE_SERIAL = 0x01,

		/// <summary>Paralell reader</summary>
		SCARD_READER_TYPE_PARALELL = 0x02,

		/// <summary>Keyboard-attached reader</summary>
		SCARD_READER_TYPE_KEYBOARD = 0x04,

		/// <summary>SCSI reader</summary>
		SCARD_READER_TYPE_SCSI = 0x08,

		/// <summary>IDE reader</summary>
		SCARD_READER_TYPE_IDE = 0x10,

		/// <summary>USB reader</summary>
		SCARD_READER_TYPE_USB = 0x20,

		/// <summary>PCMCIA reader</summary>
		SCARD_READER_TYPE_PCMCIA = 0x40,

		/// <summary>Reader that uses a TPM chip for key material storage and cryptographic operations</summary>
		SCARD_READER_TYPE_TPM = 0x80,

		/// <summary>NFC reader</summary>
		SCARD_READER_TYPE_NFC = 0x100,

		/// <summary>UICC reader</summary>
		SCARD_READER_TYPE_UICC = 0x200,

		/// <summary>NGC reader</summary>
		SCARD_READER_TYPE_NGC = 0x400,

		/// <summary/>
		SCARD_READER_TYPE_EMBEDDEDSE = 0x800,

		/// <summary>Reader that uses a proprietary vendor bus</summary>
		SCARD_READER_TYPE_VENDOR = 0xF0,
	}

	internal enum SCARD_CLASS : uint
	{
		SCARD_CLASS_VENDOR_INFO = 1,
		SCARD_CLASS_COMMUNICATIONS = 2,
		SCARD_CLASS_PROTOCOL = 3,
		SCARD_CLASS_POWER_MGMT = 4,
		SCARD_CLASS_SECURITY = 5,
		SCARD_CLASS_MECHANICAL = 6,
		SCARD_CLASS_VENDOR_DEFINED = 7,
		SCARD_CLASS_IFD_PROTOCOL = 8,
		SCARD_CLASS_ICC_STATE = 9,
		SCARD_CLASS_PERF = 0x7ffe,
		SCARD_CLASS_SYSTEM = 0x7fff,
	}

	private static uint SCARD_ATTR_VALUE(SCARD_CLASS Class, uint Tag) => (((uint)Class) << 16) | Tag;

	private static uint SCARD_CTL_CODE(ushort code) => Kernel32.CTL_CODE(Kernel32.DEVICE_TYPE.FILE_DEVICE_SMARTCARD, code, Kernel32.IOMethod.METHOD_BUFFERED, Kernel32.IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// The <c>SCARD_IO_REQUEST</c> structure begins a protocol control information structure. Any protocol-specific information then
	/// immediately follows this structure. The entire length of the structure must be aligned with the underlying hardware architecture word
	/// size. For example, in Win32 the length of any PCI information must be a multiple of four bytes so that it aligns on a 32-bit boundary.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secauthn/scard-io-request typedef struct { DWORD dwProtocol; DWORD cbPciLength; } SCARD_IO_REQUEST;
	[PInvokeData("Winsmcrd.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCARD_IO_REQUEST
	{
		/// <summary>Protocol identifier</summary>
		public SCARD_PROTOCOL dwProtocol;

		/// <summary>Protocol Control Information Length</summary>
		public uint cbPciLength;
	}

	/// <summary>[This documentation is preliminary and is subject to change.]</summary>
	// https://docs.microsoft.com/en-us/previous-versions/dn905583(v%3dvs.85) typedef struct _SCARD_T0_COMMAND { BYTE bCla; BYTE bIns; BYTE
	// bP1; BYTE bP2; BYTE bP3; } SCARD_T0_COMMAND, *LPSCARD_T0_COMMAND;
	[PInvokeData("Winsmcrd.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCARD_T0_COMMAND
	{
		/// <summary><c>bCla</c> The instruction class.</summary>
		public byte bCla;

		/// <summary><c>bIns</c> The instruction code within the instruction class.</summary>
		public byte bIns;

		/// <summary><c>bP1</c> Parameter to the instruction.</summary>
		public byte bP1;

		/// <summary><c>bP2</c> Parameter to the instruction.</summary>
		public byte bP2;

		/// <summary><c>bP3</c> Size of I/O transfer.</summary>
		public byte bP3;
	}

	/// <summary>
	/// <para>[This documentation is preliminary and is subject to change.]</para>
	/// <para>TBD</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/previous-versions/dn905586(v%3dvs.85) typedef struct _SCARD_T0_REQUEST { SCARD_IO_REQUEST ioRequest;
	// BYTE bSw1; BYTE bSw2; union { SCARD_T0_COMMAND CmdBytes; BYTE rgbHeader[5]; } DUMMYUNIONNAME; } SCARD_T0_REQUEST;
	[PInvokeData("Winsmcrd.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCARD_T0_REQUEST
	{
		/// <summary><c>ioRequest</c> TBD</summary>
		public SCARD_IO_REQUEST ioRequest;

		/// <summary><c>bSw1</c> Return code from the instruction.</summary>
		public byte bSw1;

		/// <summary><c>bSw2</c> Return code from the instruction.</summary>
		public byte bSw2;

		/// <summary>Return codes from the instruction</summary>
		public SCARD_T0_COMMAND CmdBytes;
	}

	/// <summary>
	/// <para>[This documentation is preliminary and is subject to change.]</para>
	/// <para>TBD</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/previous-versions/dn905587(v%3dvs.85) typedef struct _SCARD_T1_REQUEST { SCARD_IO_REQUEST ioRequest;
	// } SCARD_T1_REQUEST, *PSCARD_T1_REQUEST, *LPSCARD_T1_REQUEST;
	[PInvokeData("Winsmcrd.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCARD_T1_REQUEST
	{
		/// <summary>
		/// <para>ioRequest</para>
		/// <para>TBD</para>
		/// </summary>
		public SCARD_IO_REQUEST ioRequest;
	}
}