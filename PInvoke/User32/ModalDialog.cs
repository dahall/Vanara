using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Initializes a new instance of the <see cref="ModalDialog"/> class.</summary>
/// <param name="hInst">The <see cref="SafeHINSTANCE"/> of the loaded library that holds the dialog resource.</param>
/// <param name="dlgId">
/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of the dialog
/// box template or an integer value that specifies the resource identifier of the dialog box template.
/// </param>
public abstract class ModalDialog(SafeHINSTANCE hInst, ResourceId dlgId) : IWindowHandle
{
	/// <summary>Initializes a new instance of the <see cref="ModalDialog"/> class.</summary>
	/// <param name="hInst">The <see cref="HINSTANCE"/> of the loaded library that holds the dialog resource.</param>
	/// <param name="dlgId">
	/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of the
	/// dialog box template or an integer value that specifies the resource identifier of the dialog box template.
	/// </param>
	public ModalDialog(HINSTANCE hInst, ResourceId dlgId) : this(new SafeHINSTANCE(hInst, false), dlgId) { }

	/// <summary>Initializes a new instance of the <see cref="ModalDialog"/> class.</summary>
	/// <param name="libraryPath">The path of the library that holds the dialog resource.</param>
	/// <param name="dlgId">
	/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of the
	/// dialog box template or an integer value that specifies the resource identifier of the dialog box template.
	/// </param>
	public ModalDialog(string libraryPath, ResourceId dlgId)
		: this(Win32Error.ThrowLastErrorIfInvalid(LoadLibraryEx(libraryPath, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE)), dlgId) { }

	/// <inheritdoc/>
	public HWND Handle { get; protected set; }

	/// <inheritdoc/>
	bool IHandle.IsInvalid => Handle.IsInvalid;

	/// <summary>Gets the handle to the loaded library instance.</summary>
	public HINSTANCE LibHandle => hInst;

	/// <summary>Closes the dialog and optionally sets a result value.</summary>
	public virtual void Close() => SendMessage(Handle, WindowMessage.WM_CLOSE);

	/// <summary>Displays a modal dialog box using the specified parent window handle.</summary>
	/// <remarks>
	/// This method creates a modal dialog box using the specified parent window handle and the dialog box procedure. The dialog box remains
	/// active until it is closed by the user or programmatically.
	/// </remarks>
	/// <param name="hParent">
	/// The handle to the parent window of the dialog box. If <see langword="default"/>, the dialog box will have no parent.
	/// </param>
	/// <returns>A handle to the dialog box result. The value depends on the dialog box procedure's return value.</returns>
	public virtual IntPtr Show(HWND hParent = default) => DialogBox(hInst, dlgId, hParent, InternalDialogProc);

	/// <inheritdoc/>
	nint IHandle.DangerousGetHandle() => Handle.DangerousGetHandle();

	/// <summary>
	/// Processes all messages sent to a dialog box except WM_INITDIALOG, WM_COMMAND, WM_CLOSE, and WM_DESTROY, which are handled by their
	/// corresponding methods.
	/// </summary>
	/// <remarks>
	/// Override this method to customize the behavior of the dialog box for specific messages. Ensure that the method handles only the
	/// messages relevant to your implementation.
	/// </remarks>
	/// <param name="hDlg">A handle to the dialog box receiving the message.</param>
	/// <param name="message">The message identifier. This parameter specifies the type of message being sent.</param>
	/// <param name="wParam">Additional message-specific information. The meaning of this parameter depends on the value of <paramref name="message"/>.</param>
	/// <param name="lParam">Additional message-specific information. The meaning of this parameter depends on the value of <paramref name="message"/>.</param>
	/// <returns>A pointer that depends on the message being processed. Typically, returning zero indicates that the message was not handled.</returns>
	protected virtual IntPtr DialogProc(HWND hDlg, uint message, nint wParam, nint lParam) => IntPtr.Zero;

	/// <summary>Called when the dialog recieves the WM_CLOSE message.</summary>
	/// <remarks>
	/// This method is intended to be overridden in a derived class to provide custom behavior during the closing process. The default
	/// implementation returns a value of <see langword="0"/>.
	/// </remarks>
	/// <returns>The value passed to <c>EndDialog</c> to be returned as the result of <c>DialogBoxParam</c>.</returns>
	protected virtual IntPtr OnClosing() => IntPtr.Zero;

	/// <summary>Handles a command event triggered by a control. Called when the dialog receives the WM_COMMAND message.</summary>
	/// <remarks>This method is intended to be overridden in derived classes to provide custom handling for command events.</remarks>
	/// <param name="id">The identifier of the command.</param>
	/// <param name="hControl">The handle to the control that triggered the command.</param>
	/// <param name="code">The notification code associated with the command.</param>
	protected virtual void OnCommand(int id, HWND hControl, uint code) { }

	/// <summary>Performs cleanup operations before the object is destroyed. Called when the dialog receives the WM_DESTROY message.</summary>
	/// <remarks>
	/// This method is called during the destruction process of the object. Override this method in a derived class to implement custom
	/// cleanup logic. Ensure that any resources held by the object are released and any necessary finalization steps are performed.
	/// </remarks>
	protected virtual void OnDestroying() { }

	/// <summary>Initializes the dialog and prepares it for display. Called when the dialog receives the WM_INITDIALOG message.</summary>
	/// <remarks>Override this method in a derived class to perform custom initialization logic for the dialog.</remarks>
	/// <returns><see langword="true"/> if the dialog was successfully initialized; otherwise, <see langword="false"/>.</returns>
	protected virtual bool OnInitDialog() => true;

	private IntPtr InternalDialogProc(HWND hDlg, uint message, nint wParam, nint lParam)
	{
		switch ((WindowMessage)message)
		{
			case WindowMessage.WM_INITDIALOG:
				Handle = hDlg;
				if (!OnInitDialog())
				{
					DestroyWindow(hDlg);
					return IntPtr.Zero;
				}
				break;

			case WindowMessage.WM_COMMAND:
				if (!Handle.IsNull)
					HANDLE_WM_COMMAND(hDlg, wParam, lParam, (h1, i, h2, u) => OnCommand(i, h2, u));
				break;

			case WindowMessage.WM_CLOSE:
				EndDialog(Handle, OnClosing());
				break;

			case WindowMessage.WM_DESTROY:
				OnDestroying();
				break;

			default:
				return DialogProc(hDlg, message, wParam, lParam);
		}
		return new(1); // Handled
	}
}