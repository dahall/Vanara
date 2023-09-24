namespace Vanara.PInvoke;

public static partial class Imm32
{
	/// <summary>
	/// Insert the wParam composition character at the current insertion point. An application should display the composition character
	/// if it processes this message.
	/// </summary>
	public const int CS_INSERTCHAR = 0x2000;

	/// <summary>
	/// Do not move the caret position as a result of processing the message. For example, if an IME specifies a combination of
	/// CS_INSERTCHAR and CS_NOMOVECARET, the application should insert the specified character at the current caret position but should
	/// not move the caret to the next position. A subsequent WM_IME_COMPOSITION message with GCS_RESULTSTR will replace this character.
	/// </summary>
	public const int CS_NOMOVECARET = 0x4000;

	/// <summary>General error detected by IME.</summary>
	public const int IMM_ERROR_GENERAL = -2;

	/// <summary>Composition data is not ready in the input context.</summary>
	public const int IMM_ERROR_NODATA = -1;

	/// <summary>
	/// Instructs the IME window to hide the status window. To send this command, the application uses the WM_IME_CONTROL message with
	/// the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_CLOSESTATUSWINDOW = (IntPtr)0x0021;

	/// <summary>
	/// Instructs an IME window to get the position of the candidate window. To send this command, the application uses the
	/// WM_IME_CONTROL message with the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_GETCANDIDATEPOS = (IntPtr)0x0007;

	/// <summary>
	/// Instructs an IME window to retrieve the logical font used for displaying intermediate characters in the composition window. To
	/// send this command, the application uses the WM_IME_CONTROL message with the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_GETCOMPOSITIONFONT = (IntPtr)0x0009;

	/// <summary>
	/// Instructs an IME window to get the position of the composition window. To send this command, the application uses the
	/// WM_IME_CONTROL message with the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_GETCOMPOSITIONWINDOW = (IntPtr)0x000B;

	/// <summary>
	/// Instructs an IME window to get the position of the status window. To send this command, the application uses the WM_IME_CONTROL
	/// message with the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_GETSTATUSWINDOWPOS = (IntPtr)0x000F;

	/// <summary>
	/// Instructs the IME window to show the status window. To send this command, the application uses the WM_IME_CONTROL message with
	/// the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_OPENSTATUSWINDOW = (IntPtr)0x0022;

	/// <summary>
	/// Instructs an IME window to set the position of the candidates window. To send this command, the application uses the
	/// WM_IME_CONTROL message with the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_SETCANDIDATEPOS = (IntPtr)0x0008;

	/// <summary>
	/// Instructs an IME window to specify the logical font to use for displaying intermediate characters in the composition window. To
	/// send this command, the application uses the WM_IME_CONTROL message with the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_SETCOMPOSITIONFONT = (IntPtr)0x000A;

	/// <summary>
	/// Instructs an IME window to set the style of the composition window. To send this command, the application uses the WM_IME_CONTROL
	/// message with the parameter settings shown below.
	/// </summary>
	public static readonly IntPtr IMC_SETCOMPOSITIONWINDOW = (IntPtr)0x000C;

	/// <summary>
	/// Instructs an IME window to set the position of the status window. To send this command, the application uses the WM_IME_CONTROL
	/// message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMC_SETSTATUSWINDOWPOS = (IntPtr)0x0010;

	/// <summary>
	/// Notifies the application when an IME is about to change the content of the candidate window. The application receives this
	/// command through the WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_CHANGECANDIDATE = (IntPtr)0x0003;

	/// <summary>
	/// Notifies an application when an IME is about to close the candidates window. The application receives this command through the
	/// WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_CLOSECANDIDATE = (IntPtr)0x0004;

	/// <summary>
	/// Notifies an application when an IME is about to close the status window. The application receives this command through the
	/// WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_CLOSESTATUSWINDOW = (IntPtr)0x0001;

	/// <summary>
	/// Notifies an application when an IME is about to show an error message or other information. The application receives this command
	/// through the WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_GUIDELINE = (IntPtr)0x000D;

	/// <summary>
	/// Notifies an application when an IME is about to open the candidate window. The application receives this command through the
	/// WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_OPENCANDIDATE = (IntPtr)0x0005;

	/// <summary>
	/// Notifies an application when an IME is about to create the status window. The application receives this command through the
	/// WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_OPENSTATUSWINDOW = (IntPtr)0x0002;

	/// <summary/>
	public static readonly IntPtr IMN_PRIVATE = (IntPtr)0x000E;

	/// <summary>
	/// Notifies an application when candidate processing has finished and the IME is about to move the candidate window. The application
	/// receives this command through the WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_SETCANDIDATEPOS = (IntPtr)0x0009;

	/// <summary>
	/// Notifies an application when the font of the input context is updated. The application receives this command through the
	/// WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_SETCOMPOSITIONFONT = (IntPtr)0x000A;

	/// <summary>
	/// Notifies an application when the style or position of the composition window is updated. The application receives this command
	/// through the WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_SETCOMPOSITIONWINDOW = (IntPtr)0x000B;

	/// <summary>
	/// Notifies an application when the conversion mode of the input context is updated. The application receives this command through
	/// the WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_SETCONVERSIONMODE = (IntPtr)0x0006;

	/// <summary>
	/// Notifies an application when the open status of the input context is updated. The application receives this command through the
	/// WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_SETOPENSTATUS = (IntPtr)0x0008;

	/// <summary>
	/// Notifies an application when the sentence mode of the input context is updated. The application receives this command through the
	/// WM_IME_NOTIFY message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMN_SETSENTENCEMODE = (IntPtr)0x0007;

	/// <summary>
	/// Notifies an application when the status window position in the input context is updated. The application receives this command
	/// through the WM_IME_NOTIFY message with parameter settings as follows.
	/// </summary>
	public static readonly IntPtr IMN_SETSTATUSWINDOWPOS = (IntPtr)0x000C;

	/// <summary>
	/// Notfies an application when a selected IME needs information about the candidate window. The application receives this command
	/// through the WM_IME_REQUEST message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMR_CANDIDATEWINDOW = (IntPtr)0x0002;

	/// <summary>
	/// Notifies an application when a selected IME needs information about the font used by the composition window. The application
	/// receives this command through the WM_IME_REQUEST message with parameters as shown below.
	/// </summary>
	public static readonly IntPtr IMR_COMPOSITIONFONT = (IntPtr)0x0003;

	/// <summary>
	/// Notifies an application when a selected IME needs information about the composition window. The application receives this command
	/// through the WM_IME_REQUEST message with parameters set as shown below.
	/// </summary>
	public static readonly IntPtr IMR_COMPOSITIONWINDOW = (IntPtr)0x0001;

	/// <summary>
	/// Notifies an application when the IME needs to change the RECONVERTSTRING structure. The application receives this command through
	/// the WM_IME_REQUEST message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMR_CONFIRMRECONVERTSTRING = (IntPtr)0x0005;

	/// <summary>
	/// Notifies an application when the selected IME needs the converted string from the application. The application receives this
	/// command through the WM_IME_REQUEST message with parameters set as shown below.
	/// </summary>
	public static readonly IntPtr IMR_DOCUMENTFEED = (IntPtr)0x0007;

	/// <summary>
	/// Notifies an application when the selected IME needs information about the coordinates of a character in the composition string.
	/// The application receives this command through the WM_IME_REQUEST message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMR_QUERYCHARPOSITION = (IntPtr)0x0006;

	/// <summary>
	/// Notifies an application when a selected IME needs a string for reconversion. The application receives this command through the
	/// WM_IME_REQUEST message with parameter settings as shown below.
	/// </summary>
	public static readonly IntPtr IMR_RECONVERTSTRING = (IntPtr)0x0004;
}