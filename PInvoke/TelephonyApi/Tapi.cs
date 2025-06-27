namespace Vanara.PInvoke;

/// <summary>
/// A C-programming language based API that enables you to implement communications applications ranging from basic modem control to call
/// centers with multiple agents and switches.
/// </summary>
public static partial class TAPI2
{
	/// <summary>The <b>LINEFORWARDMODE_</b> bit-flag constants describe the conditions under which calls to an address can be forwarded.</summary>
	/// <remarks>
	/// <para>No extensibility. All 32 bits are reserved.</para>
	/// <para>
	/// The bit flags defined by LINEFORWARDMODE_ are not orthogonal. Unconditional forwarding ignores any specific condition such as busy or
	/// no answer. If unconditional forwarding is not in effect, then forwarding on busy and on no answer can be controlled separately or not
	/// separately. If controlled separately, the LINEFORWARDMODE_BUSY and LINEFORWARDMODE_NOANSW flags can be used separately. If not
	/// controlled separately, the flag LINEFORWARDMODE_BUSYNA must be used. Similarly, if forwarding of internal and external calls can be
	/// controlled separately, then LINEFORWARDMODE_INTERNAL and LINEFORWARDMODE_EXTERNAL flags can be used separately; otherwise the
	/// combination is used.
	/// </para>
	/// <para>
	/// Address capabilities indicate which forwarding modes are available for each address assigned to a line. An application can use
	/// <c><b>lineForward</b></c> to set forwarding conditions at the switch.
	/// </para>
	/// <para>
	/// For backward compatibility, it is the responsibility of the service provider to examine the negotiated API version on the line, and
	/// to not use these LINEFORWARDMODE_ values if the negotiated version does not support them.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/tapi/lineforwardmode--constants
	[PInvokeData("Tapi.h")]
	[Flags]
	public enum LINEFORWARDMODE
	{
		/// <summary>
		/// Forward all calls unconditionally, irrespective of their origin. Use this value when unconditional forwarding for internal and
		/// external calls cannot be controlled separately. Unconditional forwarding overrides forwarding on busy and/or no answer conditions.
		/// </summary>
		LINEFORWARDMODE_UNCOND = 0x1,

		/// <summary>
		/// Forward all internal calls unconditionally. Use this value when unconditional forwarding for internal and external calls can be
		/// controlled separately.
		/// </summary>
		LINEFORWARDMODE_UNCONDINTERNAL = 0x2,

		/// <summary>
		/// Forward all external calls unconditionally. Use this value when unconditional forwarding for internal and external calls can be
		/// controlled separately.
		/// </summary>
		LINEFORWARDMODE_UNCONDEXTERNAL = 0x4,

		/// <summary>Unconditionally forward all calls that originated at a specified address (selective call forwarding).</summary>
		LINEFORWARDMODE_UNCONDSPECIFIC = 0x8,

		/// <summary>
		/// Forward all calls on busy, irrespective of their origin. Use this value when forwarding for internal and external calls on busy
		/// and on no answer cannot be controlled separately.
		/// </summary>
		LINEFORWARDMODE_BUSY = 0x10,

		/// <summary>
		/// Forward all internal calls on busy. Use this value when forwarding for internal and external calls on busy and on no answer can
		/// be controlled separately.
		/// </summary>
		LINEFORWARDMODE_BUSYINTERNAL = 0x20,

		/// <summary>
		/// Forward all external calls on busy. Use this value when forwarding for internal and external calls on busy and on no answer can
		/// be controlled separately.
		/// </summary>
		LINEFORWARDMODE_BUSYEXTERNAL = 0x40,

		/// <summary>Forward on busy all calls that originated at a specified address (selective call forwarding).</summary>
		LINEFORWARDMODE_BUSYSPECIFIC = 0x80,

		/// <summary>
		/// Forward all calls on no answer, irrespective of their origin. Use this value when call forwarding for internal and external calls
		/// on no answer cannot be controlled separately.
		/// </summary>
		LINEFORWARDMODE_NOANSW = 0x100,

		/// <summary>
		/// Forward all internal calls on no answer. Use this value when forwarding for internal and external calls on no answer can be
		/// controlled separately.
		/// </summary>
		LINEFORWARDMODE_NOANSWINTERNAL = 0x200,

		/// <summary>
		/// Forward all external calls on no answer. Use this value when forwarding for internal and external calls on no answer can be
		/// controlled separately.
		/// </summary>
		LINEFORWARDMODE_NOANSWEXTERNAL = 0x400,

		/// <summary>Forward on no answer all calls that originated at a specified address (selective call forwarding).</summary>
		LINEFORWARDMODE_NOANSWSPECIFIC = 0x800,

		/// <summary>
		/// Forward all calls on busy/no answer, irrespective of their origin. Use this value when forwarding for internal and external calls
		/// on busy and on no answer cannot be controlled separately.
		/// </summary>
		LINEFORWARDMODE_BUSYNA = 0x1000,

		/// <summary>
		/// Forward all internal calls on busy/no answer. Use this value when call forwarding on busy and on no answer cannot be controlled
		/// separately for internal calls.
		/// </summary>
		LINEFORWARDMODE_BUSYNAINTERNAL = 0x2000,

		/// <summary>
		/// Forward all external calls on busy/no answer. Use this value when call forwarding on busy and on no answer cannot be controlled
		/// separately for internal calls.
		/// </summary>
		LINEFORWARDMODE_BUSYNAEXTERNAL = 0x4000,

		/// <summary>Forward on busy/no answer all calls that originated at a specified address (selective call forwarding).</summary>
		LINEFORWARDMODE_BUSYNASPECIFIC = 0x8000,

		/// <summary>
		/// Calls are forwarded, but the conditions under which forwarding will occur are not known at this time. It is possible that the
		/// conditions may become known at a future time. (TAPI versions 1.4 and later)
		/// </summary>
		LINEFORWARDMODE_UNKNOWN = 0x10000,

		/// <summary>
		/// Calls are forwarded, but the conditions under which forwarding will occur are not known, and will never be known by the service
		/// provider. (TAPI versions 1.4 and later)
		/// </summary>
		LINEFORWARDMODE_UNAVAIL = 0x20000,
	}

	/// <summary>
	/// The LINELOCATIONOPTION_ constants define values used in the dwOptions member of the LINELOCATIONENTRY structure returned as part of
	/// the LINETRANSLATECAPS structure returned by lineGetTranslateCaps.
	/// </summary>
	[Flags]
	public enum LINELOCATIONOPTION : uint
	{
		/// <summary>
		/// The default dialing mode at this location is pulse dialing. If this bit is set, lineTranslateAddress will insert a "P" dial
		/// modifier at the beginning of the dialable string returned when this location is selected. If this bit is not set,
		/// lineTranslateAddress will insert a "T" dial modifier at the beginning of the dialable string.
		/// </summary>
		LINELOCATIONOPTION_PULSEDIAL = 0x00000001,      // TAPI v1.4
	}

	/// <summary>The <b>LINETRANSLATEOPTION_</b> bit-flag constant describes an option used by address translation.</summary>
	/// <remarks>No extensibility. All 32 bits are reserved.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/tapi/linetranslateoption--constants
	[PInvokeData("Tapi.h")]
	[Flags]
	public enum LINETRANSLATEOPTION
	{
		/// <summary>The default calling card is to be overridden with a specified one.</summary>
		LINETRANSLATEOPTION_CARDOVERRIDE = 0x01,

		/// <summary>
		/// If a Cancel Call Waiting string is defined for the location, setting this bit will cause that string to be inserted at the
		/// beginning of the dialable string. This is commonly used by data modem and fax applications to prevent interruption of calls by
		/// call waiting beeps. If no Cancel Call Waiting string is defined for the location, this bit has no affect. Note that applications
		/// using this bit are advised to also set the LINECALLPARAMFLAGS_SECURE bit in the dwCallParamFlags member of the LINECALLPARAMS
		/// structure passed in to lineMakeCall through the lpCallParams parameter, so that if the line device uses a mechanism other than
		/// dialable digits to suppress call interrupts then that mechanism will be invoked.
		/// </summary>
		LINETRANSLATEOPTION_CANCELCALLWAITING = 0x02,

		/// <summary>This option forces the number (address) to be translated as local.</summary>
		LINETRANSLATEOPTION_FORCELOCAL = 0x04,

		/// <summary>This option forces the address (number) to be translated as long distance.</summary>
		LINETRANSLATEOPTION_FORCELD = 0x08,
	}

	/// <summary>
	/// <para>The <b>LINETRANSLATERESULT_</b> bit-flag constants describe various results of an address translation.</para>
	/// <note>The ":" (colon) character will be added to the list of characters that can be embedded in a dialable string and passed into
	/// destination addresses. Attempting to pass it from an application to a line device that supports an API version earlier than 2.0 will
	/// most likely result in LINEERR_INVALADDRESS, or possibly in the character being ignored entirely. The meaning of this character is
	/// "Pause until a voice prompt is detected, then continue dialing"; it is intended for use when automatically dialing into systems that
	/// give voice prompts, such as long distance calling card processors.</note>
	/// </summary>
	/// <remarks>No extensibility. All 32 bits are reserved.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/tapi/linetranslateresult--constants
	[PInvokeData("Tapi.h")]
	[Flags]
	public enum LINETRANSLATERESULT
	{
		/// <summary>Indicates that the input string was in valid canonical format.</summary>
		LINETRANSLATERESULT_CANONICAL = 0x00000001,

		/// <summary>
		/// Indicates that the call is being treated as an international call (country or region code specified in the destination address is
		/// different from the country or region code specified for the CurrentLocation).
		/// </summary>
		LINETRANSLATERESULT_INTERNATIONAL = 0x00000002,

		/// <summary>
		/// Indicates that the call is being treated as a long distance call (country or region code specified in the destination address is
		/// the same but area code is different from those specified for the CurrentLocation).
		/// </summary>
		LINETRANSLATERESULT_LONGDISTANCE = 0x00000004,

		/// <summary>
		/// Indicates that the call is being treated as a local call (country or region code and area code specified in the destination
		/// address are the same as those specified for the CurrentLocation).
		/// </summary>
		LINETRANSLATERESULT_LOCAL = 0x00000008,

		/// <summary>
		/// Indicates that the local call is being dialed as long distance because the country or region has toll calling and the prefix
		/// appears in the TollPrefixList of the CurrentLocation.
		/// </summary>
		LINETRANSLATERESULT_INTOLLLIST = 0x00000010,

		/// <summary>
		/// Indicates that the country or region supports toll calling but the prefix does not appear in the TollPrefixList, so the call is
		/// dialed as a local call. Note that if both INTOLLIST and NOTINTOLLIST are off, the current country or region does not support toll
		/// prefixes, and user-interface elements related to toll prefixes should not be presented to the user; if either such bit is on, the
		/// country or region does support toll lists, and the related user-interface elements should be enabled.
		/// </summary>
		LINETRANSLATERESULT_NOTINTOLLLIST = 0x00000020,

		/// <summary>Indicates that the returned address contains a "$".</summary>
		LINETRANSLATERESULT_DIALBILLING = 0x00000040,

		/// <summary>Indicates that the returned address contain a "@".</summary>
		LINETRANSLATERESULT_DIALQUIET = 0x00000080,

		/// <summary>Indicates that the returned address contains a "W".</summary>
		LINETRANSLATERESULT_DIALDIALTONE = 0x00000100,

		/// <summary>Indicates that the returned address contains a "?".</summary>
		LINETRANSLATERESULT_DIALPROMPT = 0x00000200,

		/// <summary>
		/// Indicates that the returned dialable address contains a ":". This element is exposed only to applications that negotiate a TAPI
		/// version of 2.0 or higher.
		/// </summary>
		LINETRANSLATERESULT_VOICEDETECT = 0x00000400, // TAPI v2.0

		/// <summary>
		/// Indicates that address translation is not available. This element is exposed only to applications that negotiate a TAPI version
		/// of 3.0 or higher.
		/// </summary>
		LINETRANSLATERESULT_NOTRANSLATION = 0x00000800, // TAPI v3.0
	}

	/// <summary>
	/// The digit mode describes the type, such as DTMF (Dial Tone Multifrequency). The values used are those from the TAPI 2
	/// <c>LINEDIGITMODE_ Constants</c>.
	/// </summary>
	/// <remarks>
	/// <para>No extensibility. All 32 bits are reserved.</para>
	/// <para>
	/// A digit mode can be specified when generating or detecting digits. Note that pulse digits are generated by making and breaking the
	/// local loop circuit. These pulses are absorbed by the switch. The remote end merely observes this as a series of inband audio clicks.
	/// Detecting digits sent as pulses must therefore be able to detect these sequences of 1 to 10 audible clicks.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/tapi/tapi-digitmode--constants
	[PInvokeData("tapi.h")]
	[Flags]
	public enum TAPI_DIGITMODE
	{
		/// <summary>Uses rotary pulse sequences to signal digits. Valid digits are 0 through 9.</summary>
		LINEDIGITMODE_PULSE = 0x00000001,

		/// <summary>Uses DTMF tones to signal digits. Valid digits are 0 through 9, '*', '#', 'A', 'B', 'C', and 'D'.</summary>
		LINEDIGITMODE_DTMF = 0x00000002,

		/// <summary>
		/// Uses DTMF tones to signal digits and detect the down edges. Valid digits are 0 through 9, '*', '#', 'A', 'B', 'C', and 'D'.
		/// </summary>
		LINEDIGITMODE_DTMFEND = 0x00000004,
	}
}