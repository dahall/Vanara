namespace Vanara.PInvoke;

public static partial class Imm32
{
	/// <summary>ImePadApplet's Category ID version 14.0.0</summary>
	public static readonly Guid CATID_MSIME_IImePadApplet = new(0x7566cad1, 0x4ec9, 0x4478, 0x9f, 0xe9, 0x8e, 0xd7, 0x66, 0x61, 0x9e, 0xdf);

	/// <summary>ImePadApplet's Category ID</summary>
	public static readonly Guid CATID_MSIME_IImePadApplet_VER7 = new(0x4a0f8e31, 0xc3ee, 0x11d1, 0xaf, 0xef, 0x0, 0x80, 0x5f, 0xc, 0x8b, 0x6d);

	/// <summary>ImePadApplet's Category ID version 8.0.0</summary>
	public static readonly Guid CATID_MSIME_IImePadApplet_VER80 = new(0x56f7a792, 0xfef1, 0x11d3, 0x84, 0x63, 0x0, 0xc0, 0x4f, 0x7a, 0x6, 0xe5);

	/// <summary>ImePadApplet's Category ID version 8.1.0</summary>
	public static readonly Guid CATID_MSIME_IImePadApplet_VER81 = new(0x656520b0, 0xbb88, 0x11d4, 0x84, 0xc0, 0x0, 0xc0, 0x4f, 0x7a, 0x6, 0xe5);

	/// <summary>ImePadApplet's Category ID version 10.0.0</summary>
	public static readonly Guid CATID_MSIME_IImePadApplet1000 = new(0xe081e1d6, 0x2389, 0x43cb, 0xb6, 0x6f, 0x60, 0x9f, 0x82, 0x3d, 0x9f, 0x9c);

	/// <summary>ImePadApplet's Category ID version 12.0.0</summary>
	public static readonly Guid CATID_MSIME_IImePadApplet1200 = new(0xa47fb5fc, 0x7d15, 0x4223, 0xa7, 0x89, 0xb7, 0x81, 0xbf, 0x9a, 0xe6, 0x67);

	/// <summary>ImePadApplet's Category ID version 9.0.0</summary>
	public static readonly Guid CATID_MSIME_IImePadApplet900 = new(0xfaae51bf, 0x5e5b, 0x4a1d, 0x8d, 0xe1, 0x17, 0xc1, 0xd9, 0xe1, 0x72, 0x8d);

	private const int IMEPADREQ_FIRST = 0x1000;
	private const uint IMEPN_FIRST = 0x0100;

	/// <summary>IMECHARINFO's dwCharInfo bit mask</summary>
	[PInvokeData("imepad.h")]
	[Flags]
	public enum CHARINFO : uint
	{
		/// <summary></summary>
		CHARINFO_APPLETID_MASK = 0xFF000000,

		/// <summary></summary>
		CHARINFO_FEID_MASK = 0x00F00000,

		/// <summary></summary>
		CHARINFO_CHARID_MASK = 0x0000FFFF,
	}

	/// <summary>Character Id in FarEast</summary>
	[PInvokeData("imepad.h")]
	public enum FEID
	{
		/// <summary></summary>
		FEID_NONE = 0x00,

		/// <summary></summary>
		FEID_CHINESE_TRADITIONAL = 0x01,

		/// <summary></summary>
		FEID_CHINESE_SIMPLIFIED = 0x02,

		/// <summary></summary>
		FEID_CHINESE_HONGKONG = 0x03,

		/// <summary></summary>
		FEID_CHINESE_SINGAPORE = 0x04,

		/// <summary></summary>
		FEID_JAPANESE = 0x05,

		/// <summary></summary>
		FEID_KOREAN = 0x06,

		/// <summary></summary>
		FEID_KOREAN_JOHAB = 0x07,
	}

	/// <summary>FarEast data type</summary>
	[PInvokeData("imepad.h")]
	public enum IMEFAREASTINFO_TYPE
	{
		/// <summary></summary>
		IMEFAREASTINFO_TYPE_DEFAULT = 0,

		/// <summary></summary>
		IMEFAREASTINFO_TYPE_READING = 1,

		/// <summary></summary>
		IMEFAREASTINFO_TYPE_COMMENT = 2,

		/// <summary></summary>
		IMEFAREASTINFO_TYPE_COSTTIME = 3,
	}

	/// <summary>The type of request (the request ID).</summary>
	[PInvokeData("imepad.h", MSDNShortId = "NN:imepad.IImePad")]
	public enum IMEPADREQ
	{
		/// <summary>
		/// Insert a string into the app as a composition string.
		/// <para>wParam: Pointer to the NULL-terminated string (PWSTR) to be inserted into the app.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_INSERTSTRING = IMEPADREQ_FIRST + 1,

		/// <summary>
		/// Controls composition of the string and caret in the app.
		/// <para>
		/// wParam: Specifies the control value (IMEPADCTRL_*) that requests IME to process the composition string and caret position. See
		/// Remarks for a list of the IMEPADCTRL_* values.
		/// </para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_SENDCONTROL = IMEPADREQ_FIRST + 4,

		/// <summary>
		/// Set a new applet window size.
		/// <para>wParam: LOWORD(wParam) specifies the applet's width. HIWORD(wParam) specifies applet's height</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_SETAPPLETSIZE = IMEPADREQ_FIRST + 8,

		/// <summary>
		/// Gets the current composition string text.
		/// <para>wParam: Points to the buffer (PWSTR) that is to receive the current composition string text.</para>
		/// <para>lParam: The maximum number of characters to copy, including the terminating null character.</para>
		/// </summary>
		IMEPADREQ_GETCOMPOSITIONSTRING = IMEPADREQ_FIRST + 6,

		/// <summary>
		/// Gets information about the current composition string.
		/// <para>wParam: Pointer to a IMECOMPOSITIONSTRINGINFO structure that receives the composition information.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_GETCOMPOSITIONSTRINGINFO = IMEPADREQ_FIRST + 12,

		/// <summary>
		/// Delete the composition string.
		/// <para>
		/// wParam: LOWORD(wParam) specifies the start position of the composition string to be deleted. HIWORD(wParam) specifies the length
		/// of the composition string to delete.
		/// </para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_DELETESTRING = IMEPADREQ_FIRST + 16,

		/// <summary>
		/// Replace part of the composition string.
		/// <para>wParam: Pointer to the replacement string (PWSTR).</para>
		/// <para>
		/// lParam: LOWORD(lParam) specifies the start position of the composition string to be replaced. HIWORD(lParam) specifies the length
		/// of the composition string to be replaced.
		/// </para>
		/// </summary>
		IMEPADREQ_CHANGESTRING = IMEPADREQ_FIRST + 17,

		/// <summary>
		/// Gets the application window handle.
		/// <para>wParam: The HWND handle address (HWND *) to receive the application window handle.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_GETAPPLHWND = IMEPADREQ_FIRST + 20,

		/// <summary>
		/// Keeps the ImePad window visible.
		/// <para>wParam: TRUE to keep the IMEPad window visible.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_FORCEIMEPADWINDOWSHOW = IMEPADREQ_FIRST + 21,

		/// <summary>
		/// Causes IImePad to call the applet's Notify method asynchronously with a specific notification Id and user-defined data.
		/// <para>wParam: The notify code (IMEPN_*). See the Remarks for IImePadApplet::Notify for the possible IMEPN_* codes.</para>
		/// <para>lParam: User-defined data</para>
		/// </summary>
		IMEPADREQ_POSTMODALNOTIFY = IMEPADREQ_FIRST + 22,

		/// <summary>
		/// Gets the recommended (default) ImePad applet UI Language.
		/// <para>wParam: Address of Language ID (LANGID *) to receive the default UI Language.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_GETDEFAULTUILANGID = IMEPADREQ_FIRST + 23,

		/// <summary>
		/// Get the current ImePad applet UI Language.
		/// <para>wParam: Address of Language ID (LANGID *) to receive the current UI Language.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_GETCURRENTUILANG = IMEPADREQ_FIRST + 24,

		/// <summary>
		/// Gets the applet's UI style (IPAWS_* flags).
		/// <para>
		/// wParam: Address to receive the applet UI style (DWORD *). The style is a combination of IPAWS_* flags; see Remarks for the
		/// possible IPAWS_* flags.
		/// </para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_GETAPPLETUISTYLE = IMEPADREQ_FIRST + 25,

		/// <summary>
		/// Sets the applet's UI style (IPAWS_* flags).
		/// <para>wParam: Applet UI style. The style is a combination of IPAWS_* flags; see Remarks for the possible IPAWS_* flags.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_SETAPPLETUISTYLE = IMEPADREQ_FIRST + 26,

		/// <summary>
		/// Determines if the applet is active.
		/// <para>wParam: Address to receive the value (BOOL *). If it's TRUE, the applet is active; otherwise the applet is not active.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_ISAPPLETACTIVE = IMEPADREQ_FIRST + 27,

		/// <summary>
		/// Determines if ImePad is visible.
		/// <para>wParam: Address to receive the value (BOOL *). If it's TRUE, ImePad is visible; otherwise ImePad is not visible.</para>
		/// <para>lParam: Not used. Must be set to 0.</para>
		/// </summary>
		IMEPADREQ_ISIMEPADWINDOWVISIBLE = IMEPADREQ_FIRST + 28,

		/// <summary>
		/// Set the minimum and maximum applet size.
		/// <para>wParam: LOWORD(wParam) specifies the applet width. HIWORD(wParam) specifies the applet height.</para>
		/// <para>lParam: TRUE sets the maximum size; FALSE to sets the minimum size.</para>
		/// </summary>
		IMEPADREQ_SETAPPLETMINMAXSIZE = IMEPADREQ_FIRST + 29,

		/// <summary>
		/// Gets the current application IME's conversion status. For a complete list of conversion and sentence modes, see the header file Imm.h.
		/// <para>wParam: Address to receive the conversion mode (DWORD *).</para>
		/// <para>lParam: Address to receive the sentence mode (DWORD *).</para>
		/// </summary>
		IMEPADREQ_GETCONVERSIONSTATUS = IMEPADREQ_FIRST + 30,

		/// <summary>
		/// Gets IImePad's version information.
		/// <para>wParam: Address to receive Major version (DWORD *).</para>
		/// <para>lParam: Address to receive Minor version (DWORD *).</para>
		/// </summary>
		IMEPADREQ_GETVERSION = IMEPADREQ_FIRST + 31,

		/// <summary>
		/// Gets the IME information that invoked ImePad.
		/// <para>wParam: Address to receive the IME's language ID (DWORD *).</para>
		/// <para>lParam: Address to receive the IME's input ID (DWORD *).</para>
		/// </summary>
		IMEPADREQ_GETCURRENTIMEINFO = IMEPADREQ_FIRST + 32,

		/// <summary>
		/// <para>IMEPADREQ_INSERTSTRINGCANDIDATE</para>
		/// <para>wParam = (WPARAM)(LPIMESTRINGCANDIDATE)lpStrCand; //address of IMESTRINGCANDIDATE</para>
		/// <para>lParam = 0; //not used.</para>
		/// </summary>
		IMEPADREQ_INSERTSTRINGCANDIDATE = IMEPADREQ_FIRST + 2,

		/// <summary>
		/// <para>IMEPADREQ_INSERTITEMCANDIDATE</para>
		/// <para>Not implemented in version 7.1.0</para>
		/// <para>wParam = 0;</para>
		/// </summary>
		IMEPADREQ_INSERTITEMCANDIDATE = IMEPADREQ_FIRST + 3,

		/// <summary>
		/// <para>IMEPADREQ_SENDKEYCONTROL</para>
		/// <para>wParam = MAKEWPARAM(ctlMask, updown);</para>
		/// <para>ctlMask is IMEKEYCTRLMASK_XXX combination</para>
		/// <para>upDown is IMEKEYCTRL_UP or DOWN</para>
		/// <para>lParam = (LPARAM)wvKey; //Virtual keycode.</para>
		/// </summary>
		IMEPADREQ_SENDKEYCONTROL = IMEPADREQ_FIRST + 5,

		/// <summary>
		/// <para>IMEPADREQ_GETSELECTEDSTRING</para>
		/// <para>Not implemented in version 6.0.0</para>
		/// <para>wParam = 0;</para>
		/// </summary>
		IMEPADREQ_GETSELECTEDSTRING = IMEPADREQ_FIRST + 7,

		/// <summary>
		/// <para>IMEPADREQ_SETAPPLETDATA</para>
		/// <para>wParam = (WPARAM)(PBYTE)pByte; //address of applet's data.</para>
		/// <para>lParam = (LPARAM)(INT)size; //byte size of pByte.</para>
		/// </summary>
		IMEPADREQ_SETAPPLETDATA = IMEPADREQ_FIRST + 9,

		/// <summary>
		/// <para>IMEPADREQ_GETAPPLETDATA</para>
		/// <para>wParam = (WPARAM)(PBYTE)pByte; //address of applet's data.</para>
		/// <para>lParam = (LPARAM)(INT)size; //byte size of pByte.</para>
		/// </summary>
		IMEPADREQ_GETAPPLETDATA = IMEPADREQ_FIRST + 10,

		/// <summary>
		/// <para>IMEPADREQ_SETTITLEFONT</para>
		/// <para>wParam = (WPARAM)(PWSTR)lpwstrFontFace; //FontFace name</para>
		/// <para>lParam = (LPARAM)(INT)charSet; //character set</para>
		/// </summary>
		IMEPADREQ_SETTITLEFONT = IMEPADREQ_FIRST + 11,

		/// <summary>
		/// <para>IMEPADREQ_GETCOMPOSITIONSTRINGID</para>
		/// <para>wParam = (WPARAM)(LPIMECHARINFO)lpCharInfo;</para>
		/// <para>lParam = (LPARAM)(INT)dwMaxLen;</para>
		/// </summary>
		IMEPADREQ_GETCOMPOSITIONSTRINGID = IMEPADREQ_FIRST + 13,

		/// <summary>
		/// <para>IMEPADREQ_INSERTSTRINGCANDIDATEINFO</para>
		/// <para>wParam = (WPARAM)(LPIMESTRINGCANDIDATEINFO)lpCandInfo;</para>
		/// <para>lParam = (LPARAM)(WORD)wStartPos;</para>
		/// </summary>
		IMEPADREQ_INSERTSTRINGCANDIDATEINFO = IMEPADREQ_FIRST + 14,

		/// <summary>
		/// <para>IMEPADREQ_CHANGESTRINGCANDIDATEINFO</para>
		/// <para>wParam = (WPARAM)(LPIMESTRINGCANDIDATEINFO)lpCandInfo;</para>
		/// <para>lParam = MAKELPARAM(startPos, length);</para>
		/// </summary>
		IMEPADREQ_CHANGESTRINGCANDIDATEINFO = IMEPADREQ_FIRST + 15,

		/// <summary>
		/// <para>IMEPADREQ_INSERTSTRINGINFO</para>
		/// <para>wParam = (WPARAM)(LPIMESTRINGINFO)lpStrInfo;</para>
		/// <para>lParam = dwStartPos</para>
		/// </summary>
		IMEPADREQ_INSERTSTRINGINFO = IMEPADREQ_FIRST + 18,

		/// <summary>
		/// <para>IMEPADREQ_CHANGESTRINGINFO</para>
		/// <para>wParam = (WPARAM)(LPIMESTRINGINFO)lpStrInfo;</para>
		/// <para>lParam = MAKELPARAM(wStartPos, wLength);</para>
		/// </summary>
		IMEPADREQ_CHANGESTRINGINFO = IMEPADREQ_FIRST + 19,
	}

	/// <summary>The IImePadApplet notify code.</summary>
	[PInvokeData("imepad.h", MSDNShortId = "NN:imepad.IImePadApplet")]
	public enum IMEPN : uint
	{
		/// <summary>The applet is activated.</summary>
		IMEPN_ACTIVATE = IMEPN_FIRST + 1,

		/// <summary>The applet is inactivate.</summary>
		IMEPN_INACTIVATE = IMEPN_FIRST + 2,

		/// <summary>IMEPad and the applet are shown.</summary>
		IMEPN_SHOW = IMEPN_FIRST + 4,

		/// <summary>IMEPad and the applet are hidden.</summary>
		IMEPN_HIDE = IMEPN_FIRST + 5,

		/// <summary>The applet size is changing.</summary>
		IMEPN_SIZECHANGING = IMEPN_FIRST + 6,

		/// <summary>The applet size has changed.</summary>
		IMEPN_SIZECHANGED = IMEPN_FIRST + 7,

		/// <summary>The applet setting is selected in IMEPad menu.</summary>
		IMEPN_CONFIG = IMEPN_FIRST + 8,

		/// <summary>The applet help is selected in IMEPad menu.</summary>
		IMEPN_HELP = IMEPN_FIRST + 9,

		/// <summary/>
		IMEPN_QUERYCAND = IMEPN_FIRST + 10,

		/// <summary/>
		IMEPN_APPLYCAND = IMEPN_FIRST + 11,

		/// <summary/>
		IMEPN_APPLYCANDEX = IMEPN_FIRST + 12,

		/// <summary/>
		IMEPN_SETTINGCHANGED = IMEPN_FIRST + 13,

		/// <summary/>
		IMEPN_USER = IMEPN_FIRST + 100
	}

	/// <summary></summary>
	[PInvokeData("imepad.h")]
	[Flags]
	public enum INFOMASK : uint
	{
		/// <summary></summary>
		INFOMASK_NONE = 0x00000000,

		/// <summary></summary>
		INFOMASK_QUERY_CAND = 0x00000001,

		/// <summary></summary>
		INFOMASK_APPLY_CAND = 0x00000002,

		/// <summary></summary>
		INFOMASK_APPLY_CAND_EX = 0x00000004,

		/// <summary></summary>
		INFOMASK_STRING_FIX = 0x00010000,

		/// <summary></summary>
		INFOMASK_HIDE_CAND = 0x00020000,

		/// <summary></summary>
		INFOMASK_BLOCK_CAND = 0x00040000,
	}

	/// <summary>Mask flags for IMEAPPLETCFG</summary>
	[Flags]
	public enum IPACFG : uint
	{
		/// <summary>None</summary>
		IPACFG_NONE = 0,

		/// <summary>The applet has a property Dialog. If this flag is set, IImePad calls IImePadApplet::Notify with IMEPN_CFG.</summary>
		IPACFG_PROPERTY = 1,

		/// <summary>The applet has help. If this flag is set, IImePad calls IImePadApplet::Notify with IMEPN_HELP.</summary>
		IPACFG_HELP = 2,

		/// <summary>wchTitle is set.</summary>
		IPACFG_TITLE = 0x00010000,

		/// <summary>wchTitleFontFace and dwCharSet are set.</summary>
		IPACFG_TITLEFONTFACE = 0x00020000,

		/// <summary>iCategory is set.</summary>
		IPACFG_CATEGORY = 0x00040000,

		/// <summary>LangID is set.</summary>
		IPACFG_LANG = 0x00000010,
	}

	/// <summary>APPLETCFG iCategory</summary>
	[PInvokeData("imepad.h")]
	public enum IPACID
	{
		/// <summary></summary>
		IPACID_NONE = 0x0000,

		/// <summary></summary>
		IPACID_SOFTKEY = 0x0001,

		/// <summary></summary>
		IPACID_HANDWRITING = 0x0002,

		/// <summary></summary>
		IPACID_STROKESEARCH = 0x0003,

		/// <summary></summary>
		IPACID_RADICALSEARCH = 0x0004,

		/// <summary></summary>
		IPACID_SYMBOLSEARCH = 0x0005,

		/// <summary></summary>
		IPACID_VOICE = 0x0006,

		/// <summary></summary>
		IPACID_EPWING = 0x0007,

		/// <summary></summary>
		IPACID_OCR = 0x0008,

		/// <summary></summary>
		IPACID_CHARLIST = 0x0009,

		/// <summary></summary>
		IPACID_USER = 0x0100,
	}

	/// <summary>Applet window style.</summary>
	[PInvokeData("imepad.h", MSDNShortId = "NS:imepad.tagIMEAPPLETUI")]
	[Flags]
	public enum IPAWS : uint
	{
		/// <summary>Show the applet as an enabled window.</summary>
		IPAWS_ENABLED = 0x00000001,

		/// <summary>Send the IMEPN_SIZECHANGING or IMEPN_SIZECHANGED notify code to the applet.</summary>
		IPAWS_SIZINGNOTIFY = 0x00000004,

		/// <summary>Vertically fixed.</summary>
		IPAWS_VERTICALFIXED = 0x00000100,

		/// <summary>Horizontally fixed.</summary>
		IPAWS_HORIZONTALFIXED = 0x00000200,

		/// <summary>Size is fixed.</summary>
		IPAWS_SIZEFIXED = 0x00000300,

		/// <summary>Max width is fixed.</summary>
		IPAWS_MAXWIDTHFIXED = 0x00001000,

		/// <summary>Max height is fixed.</summary>
		IPAWS_MAXHEIGHTFIXED = 0x00002000,

		/// <summary>Max size is fixed.</summary>
		IPAWS_MAXSIZEFIXED = 0x00003000,

		/// <summary>Min width is fixed.</summary>
		IPAWS_MINWIDTHFIXED = 0x00010000,

		/// <summary>Min height is fixed.</summary>
		IPAWS_MINHEIGHTFIXED = 0x00020000,

		/// <summary>Min size is fixed.</summary>
		IPAWS_MINSIZEFIXED = 0x00030000,
	}

	/// <summary>
	/// <para>The <c>IImePad</c> interface inserts text into apps from IMEPadApplets that implement the IImePadApplet interface.</para>
	/// <para>IMEPadApplets can insert their own strings into the current active app by calling <c>IImePad</c> and the Microsoft IME.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nn-imepad-iimepad
	[PInvokeData("imepad.h", MSDNShortId = "NN:imepad.IImePad")]
	[ComImport, Guid("5D8E643A-C3A9-11d1-AFEF-00805F0C8B6D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IImePad
	{
		/// <summary>
		/// <para>Called by an IImePadApplet to insert text into an app.</para>
		/// <para>
		/// <c>Request</c> is the only method that IImePadApplet can call. By calling this method with one of the <c>IMEPADREQ_*</c> request
		/// IDs, <c>IImePadApplet</c> can insert text into an app and can control IME's composition string in an app.
		/// </para>
		/// </summary>
		/// <param name="pIImePadApplet">The interface pointer of the calling applet.</param>
		/// <param name="reqId">
		/// <para>The type of request (the request ID). This must be set to one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>IMEPADREQ_INSERTSTRING</c></description>
		/// <description>Insert a string into the app as a composition string.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_SENDCONTROL</c></description>
		/// <description>Controls composition of the string and caret in the app.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_SETAPPLETSIZE</c></description>
		/// <description>Set a new applet window size.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETCOMPOSITIONSTRING</c></description>
		/// <description>Gets the current composition string text.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETCOMPOSITIONSTRINGINFO</c></description>
		/// <description>Gets information about the current composition string.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_DELETESTRING</c></description>
		/// <description>Delete the composition string.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_CHANGESTRING</c></description>
		/// <description>Replace part of the composition string.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETAPPLHWND</c></description>
		/// <description>Gets the application window handle.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_FORCEIMEPADWINDOWSHOW</c></description>
		/// <description>Keeps the ImePad window visible.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_POSTMODALNOTIFY</c></description>
		/// <description>
		/// Causes IImePad to call the applet's Notify method asynchronously with a specific notification Id and user-defined data.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETDEFAULTUILANGID</c></description>
		/// <description>Gets the recommended (default) ImePad applet UI Language.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETCURRENTUILANG</c></description>
		/// <description>Get the current ImePad applet UI Language.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETAPPLETUISTYLE</c></description>
		/// <description>Gets the applet's UI style ( <c>IPAWS_*</c> flags).</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_SETAPPLETUISTYLE</c></description>
		/// <description>Sets the applet's UI style ( <c>IPAWS_*</c> flags).</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_ISAPPLETACTIVE</c></description>
		/// <description>Determines if the applet is active.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_ISIMEPADWINDOWVISIBLE</c></description>
		/// <description>Determines if ImePad is visible.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_SETAPPLETMINMAXSIZE</c></description>
		/// <description>Set the minimum and maximum applet size.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETCONVERSIONSTATUS</c></description>
		/// <description>
		/// Gets the current application IME's conversion status. For a complete list of conversion and sentence modes, see the header file Imm.h.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETVERSION</c></description>
		/// <description>Gets IImePad's version information.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADREQ_GETCURRENTIMEINFO</c></description>
		/// <description>Gets the IME information that invoked ImePad.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="wParam">Additional information specific to <c>reqId</c>.</param>
		/// <param name="lParam">Additional information specific to <c>reqId</c>.</param>
		/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
		/// <remarks>
		/// <para>Possible <c>IMEPADCTRL_*</c> values</para>
		/// <para>These are the possible values that <c>wParam</c> can take when <c>reqId</c> is set to <c>IMEPADREQ_SENDCONTROL</c>:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Name</description>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>IMEPADCTRL_CONVERTALL</c></description>
		/// <description>1</description>
		/// <description>Convert all composition strings.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_DETERMINALL</c></description>
		/// <description>2</description>
		/// <description>Determine all composition strings.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_DETERMINCHAR</c></description>
		/// <description>3</description>
		/// <description>Determine specified count's composition string character.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_CLEARALL</c></description>
		/// <description>4</description>
		/// <description>Clear all composition strings.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_CARETLEFT</c></description>
		/// <description>6</description>
		/// <description>Move character caret to the left.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_CARETRIGHT</c></description>
		/// <description>7</description>
		/// <description>Move character caret to the right.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_CARETTOP</c></description>
		/// <description>8</description>
		/// <description>Move character caret to the top of the composition string.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_CARETBOTTOM</c></description>
		/// <description>9</description>
		/// <description>Move character caret to the end of the composition string.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_CARETBACKSPACE</c></description>
		/// <description>10</description>
		/// <description>Delete composition string's character before the caret (like the BACKSPACE key).</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_CARETDELETE</c></description>
		/// <description>11</description>
		/// <description>Delete composition string's character after the caret (like the DELETE key).</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_PHRASEDELETE</c></description>
		/// <description>12</description>
		/// <description>Delete the composition string's phrase.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_INSERTSPACE</c></description>
		/// <description>13</description>
		/// <description>Insert a space characterâfull width or half width depending on the IME configuration.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_INSERTFULLSPACE</c></description>
		/// <description>14</description>
		/// <description>Insert full width space.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_INSERTHALFSPACE</c></description>
		/// <description>15</description>
		/// <description>Insert half width space.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_ONIME</c></description>
		/// <description>16</description>
		/// <description>Set IME ON.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_OFFIME</c></description>
		/// <description>17</description>
		/// <description>Set IME OFF.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_ONPRECONVERSION</c></description>
		/// <description>18</description>
		/// <description>Set pre-conversion ON.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_OFFPRECONVERSION</c></description>
		/// <description>19</description>
		/// <description>Set pre-conversion OFF.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPADCTRL_PHONETICCANDIDATE</c></description>
		/// <description>20</description>
		/// <description>Open IME's candidate.</description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para>Possible <c>IPAWS_*</c> values</para>
		/// <para>
		/// These are the possible values that can be received via <c>wParam</c> when <c>reqId</c> is set to
		/// <c>IMEPADREQ_GETAPPLETUISTYLE</c>, or that <c>wParam</c> can be set to when <c>reqId</c> is set to <c>IMEPADREQ_SETAPPLETUISTYLE</c>:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Name</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>IPAWS_ENABLED</c></description>
		/// <description>Show the applet as an enabled window.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_SIZINGNOTIFY</c></description>
		/// <description>Send the <c>IMEPN_SIZECHANGING</c> or <c>IMEPN_SIZECHANGED</c> notify code to the applet.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_VERTICALFIXED</c></description>
		/// <description>Vertically fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_HORIZONTALFIXED</c></description>
		/// <description>Horizontally fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_SIZEFIXED</c></description>
		/// <description>Size is fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_MAXWIDTHFIXED</c></description>
		/// <description>Max width is fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_MAXHEIGHTFIXED</c></description>
		/// <description>Max height is fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_MAXSIZEFIXED</c></description>
		/// <description>Max size is fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_MINWIDTHFIXED</c></description>
		/// <description>Min width is fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_MINHEIGHTFIXED</c></description>
		/// <description>Min height is fixed.</description>
		/// </item>
		/// <item>
		/// <description><c>IPAWS_MINSIZEFIXED</c></description>
		/// <description>Min size is fixed.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nf-imepad-iimepad-request HRESULT Request( [in] IImePadApplet
		// *pIImePadApplet, [in] INT reqId, [in, out] WPARAM wParam, [in, out] LPARAM lParam );
		void Request(IImePadApplet pIImePadApplet, IMEPADREQ reqId, IntPtr wParam, IntPtr lParam);
	}

	/// <summary>
	/// <para>The <c>IImePadApplet</c> interface inputs strings into apps through the IImePad interface.</para>
	/// <para>
	/// <c>IImePadApplet</c> should be implemented as a DLL inproc server. The developer can implement multiple <c>IImePadApplet</c>
	/// interfaces in one DLL. To specify and emulate the <c>IImePadApplet</c> interface in the applet DLL, the applet must also provide the
	/// IImeSpecifyApplets interface.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nn-imepad-iimepadapplet
	[PInvokeData("imepad.h", MSDNShortId = "NN:imepad.IImePadApplet")]
	[ComImport, Guid("5D8E643B-C3A9-11d1-AFEF-00805F0C8B6D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IImePadApplet
	{
		/// <summary>Called from IImePad interface to initialize IImePadApplet.</summary>
		/// <param name="lpIImePad">Pointer to IImePad ( <c>IUnknown</c> *)</param>
		/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
		/// <remarks>
		/// When the ImePad user interface is created, IImePad calls this method and sets the IImePad interface pointer as an argument. The
		/// applet can save and use this pointer to call the pIImePad-&gt;IImePad::Request method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nf-imepad-iimepadapplet-initialize HRESULT Initialize( IUnknown
		// *lpIImePad );
		[PreserveSig]
		HRESULT Initialize(IImePad lpIImePad);

		/// <summary>Called from IImePad to terminate IImePadApplet when the IMEPad instance exits.</summary>
		/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nf-imepad-iimepadapplet-terminate HRESULT Terminate();
		[PreserveSig]
		HRESULT Terminate();

		/// <summary>Gets the applet configuration.</summary>
		/// <param name="lpAppletCfg">The lp applet CFG.</param>
		[PreserveSig]
		HRESULT GetAppletConfig(out IMEAPPLETCFG lpAppletCfg);

		/// <summary>
		/// <para>Called from IImePad to get the applet's window handle, style, and size.</para>
		/// <para>The applet can set its window style and sizing policy.</para>
		/// </summary>
		/// <param name="hwndParent">Window handle of the IImePad GUI. The applet can create the window as its child window.</param>
		/// <param name="lpImeAppletUI">Pointer to IMEAPPLETUI structure. The applet can set its window style.</param>
		/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nf-imepad-iimepadapplet-createui HRESULT CreateUI( [in] HWND
		// hwndParent, [in] LPIMEAPPLETUI lpImeAppletUI );
		[PreserveSig]
		HRESULT CreateUI(HWND hwndParent, in IMEAPPLETUI lpImeAppletUI);

		/// <summary>Called from IImePad to pass information with a notify code</summary>
		/// <param name="lpImePad">Pointer of IUnknown interface. To get the IImePad interface pointer, use QueryInterface.</param>
		/// <param name="notify">The IImePadApplet notify code. See Remarks for the possible codes.</param>
		/// <param name="wParam">Additional information specific to <c>notify</c>.</param>
		/// <param name="lParam">Additional information specific to <c>notify</c>.</param>
		/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
		/// <remarks>
		/// <para>Possible notify codes ( <c>IMEPN_*</c> values)</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>IMEPN_ACTIVATE</c></description>
		/// <description>The applet is activated.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPN_INACTIVATE</c></description>
		/// <description>The applet is inactivate.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPN_SHOW</c></description>
		/// <description>IMEPad and the applet are shown.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPN_HIDE</c></description>
		/// <description>IMEPad and the applet are hidden.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPN_SIZECHANGING</c></description>
		/// <description>The applet size is changing.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPN_SIZECHANGED</c></description>
		/// <description>The applet size has changed.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPN_CONFIG</c></description>
		/// <description>The applet setting is selected in IMEPad menu.</description>
		/// </item>
		/// <item>
		/// <description><c>IMEPN_HELP</c></description>
		/// <description>The applet help is selected in IMEPad menu.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nf-imepad-iimepadapplet-notify HRESULT Notify( [in] IUnknown *lpImePad,
		// [in] INT notify, [in, out] WPARAM wParam, [in, out] LPARAM lParam );
		[PreserveSig]
		HRESULT Notify(IImePad lpImePad, IMEPN notify, IntPtr wParam, IntPtr lParam);
	}

	/// <summary>
	/// The <c>IImeSpecifyApplets</c> interface specifies methods called from the IImePad interface object to emulate the IImePadApplet interface.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nn-imepad-iimespecifyapplets
	[PInvokeData("imepad.h", MSDNShortId = "NN:imepad.IImeSpecifyApplets")]
	[ComImport, Guid("5D8E643C-C3A9-11d1-AFEF-00805F0C8B6D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IImeSpecifyApplets
	{
		/// <summary>Called from the IImePad interface to enumerate the IImePadApplet interfaces that are implemented.</summary>
		/// <param name="refiid">
		/// IID of the IImePadApplet interface. This IID is defined in Imepad.h as <c>IID_IImePadApplet</c>. This is for
		/// <c>IImePadApplet</c>'s future enhancement
		/// </param>
		/// <param name="lpIIDList">Pointer to a APPLETIIDLIST structure. Sets the applet's IID list and count.</param>
		/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/imepad/nf-imepad-iimespecifyapplets-getappletiidlist HRESULT GetAppletIIDList(
		// [in] REFIID refiid, [in, out] LPAPPLETIDLIST lpIIDList );
		[PreserveSig]
		HRESULT GetAppletIIDList(in Guid refiid, ref APPLETIDLIST lpIIDList);
	}

	/// <summary>Undocumented.</summary>
	public static uint APPLETIDFROMCHARINFO(CHARINFO charInfo) => (uint)(charInfo & CHARINFO.CHARINFO_APPLETID_MASK) >> 24;

	/// <summary>Undocumented.</summary>
	public static uint CHARIDFROMCHARINFO(CHARINFO charInfo) => (uint)(charInfo & CHARINFO.CHARINFO_CHARID_MASK);

	/// <summary>Undocumented.</summary>
	public static FEID FEIDFROMCHARINFO(CHARINFO charInfo) => (FEID)((uint)(charInfo & CHARINFO.CHARINFO_FEID_MASK) >> 20);

	/// <summary>Specifies an IImePadApplet IID list.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/imepad/ns-imepad-appletidlist typedef struct tagAPPLETIDLIST { INT count; IID
	// *pIIDList; } APPLETIDLIST, *LPAPPLETIDLIST;
	[PInvokeData("imepad.h", MSDNShortId = "NS:imepad.tagAPPLETIDLIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APPLETIDLIST : IArrayStruct<Guid>
	{
		/// <summary>The number of the IID's implemented in this applet.</summary>
		public int count;

		private IntPtr _pIIDList;

		/// <summary>The IID list. This must be allocated with CoTaskMemAlloc.</summary>
		public readonly Guid[] pIIDList => _pIIDList.ToArray<Guid>(count) ?? new Guid[0];

		/// <summary>Creates an <see cref="APPLETIDLIST"/> structure with space allocated for <c>pIIDList</c>.</summary>
		/// <param name="cnt">The number of the IID's implemented in this applet.</param>
		/// <returns>An <see cref="APPLETIDLIST"/> structure with space allocated for <c>pIIDList</c>.</returns>
		public static APPLETIDLIST CreateAllocated(int cnt)
		{
			APPLETIDLIST al = new();
			al._pIIDList = Marshal.AllocCoTaskMem((al.count = cnt) * Marshal.SizeOf<Guid>());
			return al;
		}
	}

	/// <summary>Used to specify and set applet configuration in IImePad.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/imepad/ns-imepad-imeappletcfg typedef struct tagAPPLETCFG { DWORD dwConfig; WCHAR
	// wchTitle[MAX_APPLETTITLE]; WCHAR wchTitleFontFace[MAX_FONTFACE]; DWORD dwCharSet; INT iCategory; HICON hIcon; LANGID langID; WORD
	// dummy; LPARAM lReserved1; } IMEAPPLETCFG, *LPIMEAPPLETCFG;
	[PInvokeData("imepad.h", MSDNShortId = "NS:imepad.tagAPPLETCFG")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMEAPPLETCFG
	{
		/// <summary>
		/// <para>Combination of <c>IPACFG_*</c> flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>IPACFG_NONE</c></description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description><c>IPACFG_PROPERTY</c></description>
		/// <description>The applet has a property Dialog. If this flag is set, IImePad calls IImePadApplet::Notify with <c>IMEPN_CFG</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>IPACFG_HELP</c></description>
		/// <description>The applet has help. If this flag is set, IImePad calls IImePadApplet::Notify with <c>IMEPN_HELP</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>IPACFG_TITLE</c></description>
		/// <description><c>wchTitle</c> is set.</description>
		/// </item>
		/// <item>
		/// <description><c>IPACFG_TITLEFONTFACE</c></description>
		/// <description><c>wchTitleFontFace</c> and <c>dwCharSet</c> are set.</description>
		/// </item>
		/// <item>
		/// <description><c>IPACFG_CATEGORY</c></description>
		/// <description><c>iCategory</c> is set.</description>
		/// </item>
		/// <item>
		/// <description><c>IPACFG_LANG</c></description>
		/// <description><c>LangID</c> is set.</description>
		/// </item>
		/// </list>
		/// </summary>
		public IPACFG dwConfig;

		/// <summary>The applet's title, in Unicode.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64 /*MAX_APPLETTITLE*/)]
		public string wchTitle;

		/// <summary>The applet title's FontFace name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32 /*MAX_FONTFACE*/)]
		public string wchTitleFontFace;

		/// <summary>The applet font's character set.</summary>
		public uint dwCharSet;

		/// <summary>Not used.</summary>
		public int iCategory;

		/// <summary>The icon handle for the ImePad applet's menu.</summary>
		public HICON hIcon;

		/// <summary>The applet's language ID.</summary>
		public LANGID langID;

		/// <summary>Not used.</summary>
		public ushort dummy;

		/// <summary>Reserved.</summary>
		public IntPtr lReserved1;
	}

	/// <summary>Used by IImePadApplet::CreateUI to specify applet window style.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/imepad/ns-imepad-imeappletui typedef struct tagIMEAPPLETUI { HWND hwnd; DWORD
	// dwStyle; INT width; INT height; INT minWidth; INT minHeight; INT maxWidth; INT maxHeight; LPARAM lReserved1; LPARAM lReserved2; }
	// IMEAPPLETUI, *LPIMEAPPLETUI;
	[PInvokeData("imepad.h", MSDNShortId = "NS:imepad.tagIMEAPPLETUI")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMEAPPLETUI
	{
		/// <summary>Window handle created by applet window.</summary>
		public HWND hwnd;

		/// <summary>
		/// Applet window style. The style is a combination of <c>IPAWS_</c> flags; see the Remarks of IImePad::Request for the possible
		/// <c>IPAWS_</c> flags.
		/// </summary>
		public IPAWS dwStyle;

		/// <summary>The applet window's initial width.</summary>
		public int width;

		/// <summary>The applet window's initial height.</summary>
		public int height;

		/// <summary>Minimum width of the applet window. Valid only when <c>IPAWS_MINWIDTHFIXED</c> style is set in <c>dwStyle</c>.</summary>
		public int minWidth;

		/// <summary>Minimum height of applet window. Valid only when <c>IPAWS_MINHEIGHTFIXED</c> is set in <c>dwStyle</c>.</summary>
		public int minHeight;

		/// <summary>Maximum width of applet window. Valid only when <c>IPAWS_MAXWIDTHFIXED</c> is set in <c>dwStyle</c>.</summary>
		public int maxWidth;

		/// <summary>Maximum height of applet window. Valid only when <c>IPAWS_MAXHEIGHTFIXED</c> is set in <c>dwStyle</c>.</summary>
		public int maxHeight;

		/// <summary>Reserved.</summary>
		public IntPtr lReserved1;

		/// <summary>Reserved.</summary>
		public IntPtr lReserved2;
	}

	/// <summary>Composition string's each character. wParam for IMEPADREQ_GETCOMPOSITIONSTRINGID.</summary>
	[PInvokeData("imepad.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct IMECHARINFO
	{
		/// <summary/>
		public char wch;

		/// <summary/>
		public CHARINFO dwCharInfo;
	}

	/// <summary>Composition string's information. wParam for IMEPADREQ_GETCOMPOSITIONSTRINGINFO.</summary>
	[PInvokeData("imepad.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMECOMPOSITIONSTRINGINFO
	{
		/// <summary/>
		public int iCompStrLen;

		/// <summary/>
		public int iCaretPos;

		/// <summary/>
		public int iEditStart;

		/// <summary/>
		public int iEditLen;

		/// <summary/>
		public int iTargetStart;

		/// <summary/>
		public int iTargetLen;
	}

	/// <summary>FarEast specified data.</summary>
	[PInvokeData("imepad.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IMEFAREASTINFO>), nameof(dwSize))]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMEFAREASTINFO
	{
		/// <summary>total structure size.</summary>
		public uint dwSize;

		/// <summary>Data type.</summary>
		public IMEFAREASTINFO_TYPE dwType;

		/// <summary>fareast spec data.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] dwData;
	}

	/// <summary>IMEPADREQ_INSERTITEMCANDIDATE structure</summary>
	[PInvokeData("imepad.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMEITEM
	{
		/// <summary/>
		public int cbSize;

		/// <summary/>
		public int iType;

		/// <summary/>
		public IntPtr lpItemData;
	}

	/// <summary/>
	[PInvokeData("imepad.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IMEITEMCANDIDATE>))]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMEITEMCANDIDATE
	{
		/// <summary/>
		public uint uCount;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public IMEITEM[] imeItem;
	}

	/// <summary>wParam value for IMEPADREQ_INSERTSTRINGCANDIDATE</summary>
	[PInvokeData("imepad.h")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<IMESTRINGCANDIDATE>))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct IMESTRINGCANDIDATE
	{
		/// <summary/>
		public uint uCount;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string lpwstr;
	}

	/// <summary>String candidate info</summary>
	[PInvokeData("imepad.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IMESTRINGCANDIDATEINFO>), nameof(uCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMESTRINGCANDIDATEINFO
	{
		/// <summary/>
		public FEID dwFarEastId;

		/// <summary>Pointer to a <see cref="IMEFAREASTINFO"/> structure.</summary>
		public IntPtr /* IMEFAREASTINFO* */ lpFarEastInfo;

		/// <summary/>
		public INFOMASK fInfoMask;

		/// <summary/>
		public int iSelIndex;

		/// <summary/>
		public uint uCount;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPWStr, SizeConst = 1)]
		public string[] lpwstr;
	}

	/// <summary>String with FarEast id. wParam for IMEPADREQ_INSERTSTRINGINFO.</summary>
	[PInvokeData("imepad.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMESTRINGINFO
	{
		/// <summary/>
		public FEID dwFarEastId;

		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpwstr;
	}
}