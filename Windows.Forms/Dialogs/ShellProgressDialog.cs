using System.ComponentModel;
using System.Windows.Forms;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Forms;

/// <summary>Display style for a <see cref="ShellProgressDialog"/>.</summary>
public enum ShellProgressDialogStyle
{
	/// <summary>Displays a progress bar that tracks to the progress values.</summary>
	Normal,

	/// <summary>
	/// Sets the progress bar to marquee mode. Use this when you wish to indicate that progress is being made, but the time required for
	/// the operation is unknown.
	/// </summary>
	Marquee,

	/// <summary>
	/// Do not display a progress bar. Typically, an application can quantitatively determine how much of the operation remains and
	/// periodically pass that value to <c>UpdateProgress</c>. The progress dialog box uses this information to
	/// update its progress bar. This flag is typically set when the calling application must wait for an operation to finish, but does
	/// not have any quantitative information it can use to update the dialog box.
	/// </summary>
	Hidden
}

/// <summary>
/// Wrapper for IProgressDialog which displays a system progress dialog. This object is a generic way to show a user how an operation is
/// progressing. It is typically used when deleting, uploading, copying, moving, or downloading large numbers of files. The dialog is shown
/// on a separate thread and will not block operations in the current thread.
/// </summary>
/// <example>This is an example of how to use ShellProgressDialog.
/// <code>
/// private void button1_Click(object? sender, System.EventArgs e)
/// {
///    var dlg = new ShellProgressDialog
///    {
///	      AutoTimeEstimation = true,
///	      CancelMessage = "Canceling. Please wait...",
///	      Description = "Processing application...",
///	      Title = "MyApp - Long Process"
///	   };
///	   dlg.Start(this);
///	   for (int i = 0; i &lt; steps.Count; i++)
///	   {
///	      dlg.Detail = steps[i].Text;
///	      steps[1].Action.Invoke();
///	      dlg.UpdateProgress(i + 1, steps.Count);
///	   }
///	}
/// </code>
/// </example>
public class ShellProgressDialog : Component
{
	private string? cancelMsg;
	private bool closed = true;
	private string? description;
	private string? detail;
	private EnumFlagIndexer<PROGDLG> flags;
	private IProgressDialog iDlg;
	private string title = string.Empty;

	/// <summary>Initializes a new instance of the <see cref="ShellProgressDialog"/> class.</summary>
	public ShellProgressDialog() => iDlg = new IProgressDialog();

	/// <summary> Gets or sets a value indicating whether to automatically estimate the remaining time and display it.</summary>
	[DefaultValue(false), Category("Behavior"), Description("Automatically estimate the remaining time and display it.")]
	public bool AutoTimeEstimation { get => flags[PROGDLG.PROGDLG_AUTOTIME]; set => flags[PROGDLG.PROGDLG_AUTOTIME] = value; }

	/// <summary>Gets or sets a message to be displayed if the user cancels the operation.</summary>
	/// <remarks>
	/// Even though the user clicks Cancel, the application cannot immediately call <see cref="Stop"/> to close the dialog box. The
	/// application must wait until the next time it read <see cref="IsCancelled"/> to discover that the user has canceled the operation.
	/// Since this delay might be significant, the progress dialog box provides the user with immediate feedback by clearing the
	/// description and detail lines and displaying this cancel message. The message is intended to let the user know that the delay is
	/// normal and that the progress dialog box will be closed shortly. It is typically is set to something like "Please wait while ...".
	/// </remarks>
	[DefaultValue(null), Category("Appearance"), Description("Message to be displayed if the user cancels the operation.")]
	public string? CancelMessage
	{
		get => cancelMsg;
		set
		{
			if (cancelMsg == value) return;
			iDlg.SetCancelMsg(cancelMsg = value);
		}
	}

	/// <summary>Gets or sets a value indicating whether to compact displayed strings if they are too large to fit on a line.</summary>
	/// <value><see langword="true"/> to have path strings compacted if they are too large to fit on a line.</value>
	[DefaultValue(false), Category("Appearance"), Description("Compact displayed strings if they are too large to fit on a line.")]
	public bool CompactStrings { get; set; }

	/// <summary>Gets or sets the description that appears on the first line.</summary>
	/// <value>The description.</value>
	[DefaultValue(null), Category("Appearance"), Description("Description that appears on the first line.")]
	public string? Description
	{
		get => description;
		set
		{
			if (description == value) return;
			iDlg.SetLine(1, description = value, CompactStrings);
		}
	}

	/// <summary>Gets or sets the detail that appears on the second line.</summary>
	/// <value>The detail.</value>
	[DefaultValue(null), Category("Appearance"), Description("Detail text that appears on the second line.")]
	public string? Detail
	{
		get => detail;
		set
		{
			if (detail == value) return;
			iDlg.SetLine(2, detail = value, CompactStrings);
		}
	}

	/// <summary>Gets or sets a value indicating whether to show the "time remaining" text.</summary>
	/// <value>Show the "time remaining" text.</value>
	[DefaultValue(false), Category("Appearance"), Description("Show the \"time remaining\" text.")]
	public bool HideTimeRemaining { get => flags[PROGDLG.PROGDLG_NOTIME]; set => flags[PROGDLG.PROGDLG_NOTIME] = value; }

	/// <summary>Checks whether the user has canceled the operation.</summary>
	/// <returns><see langword="true"/> if the user has canceled the operation; otherwise, <see langword="false"/>.</returns>
	/// <remarks>
	/// The system does not send a message to the component when the user clicks the Cancel button. You must periodically use this
	/// function to poll the progress dialog box object to determine whether the operation has been canceled.
	/// </remarks>
	[Browsable(false)]
	public bool IsCancelled => iDlg.HasUserCancelled();

	/// <summary>Gets or sets a value indicating whether the Minimize button is displayed in the caption bar of the progress dialog.</summary>
	/// <value>
	/// <see langword="true"/> to display a Minimize button for the dialog; otherwise, <see langword="false"/>. The default is <see langword="true"/>.
	/// </value>
	[DefaultValue(true), Category("Appearance"), Description("Show the Minimize button in the caption bar")]
	public bool MinimizeBox { get => !flags[PROGDLG.PROGDLG_NOMINIMIZE]; set => flags[PROGDLG.PROGDLG_NOMINIMIZE] = !value; }

	/// <summary>Gets a value indicating whether this form is displayed modally.</summary>
	/// <value><see langword="true"/> if the form is displayed modally; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false), Category("Appearance"), Description("Display this form is modally.")]
	public bool Modal { get => flags[PROGDLG.PROGDLG_MODAL]; set => flags[PROGDLG.PROGDLG_MODAL] = value; }

	/// <summary>Gets or sets a value indicating whether a Cancel button is displayed on the progress dialog.</summary>
	/// <value>
	/// <see langword="true"/> to display a Cancel button on the progress dialog; otherwise, <see langword="false"/>. The default is <see langword="true"/>.
	/// </value>
	[DefaultValue(true), Category("Appearance"), Description("Display the Cancel button.")]
	public bool ShowCancelButton { get => !flags[PROGDLG.PROGDLG_NOCANCEL]; set => flags[PROGDLG.PROGDLG_NOCANCEL] = !value; }

	/// <summary>Gets or sets the style of the progress bar on the progress dialog.</summary>
	/// <value>The style of the progress bar.</value>
	[DefaultValue(ShellProgressDialogStyle.Normal), Category("Appearance"), Description("Progress bar style.")]
	public ShellProgressDialogStyle Style
	{
		get => flags[PROGDLG.PROGDLG_NOPROGRESSBAR] ? ShellProgressDialogStyle.Hidden : (flags[PROGDLG.PROGDLG_MARQUEEPROGRESS] ? ShellProgressDialogStyle.Marquee : ShellProgressDialogStyle.Normal);
		set
		{
			switch (value)
			{
				case ShellProgressDialogStyle.Normal:
					flags[PROGDLG.PROGDLG_NOPROGRESSBAR] = false;
					flags[PROGDLG.PROGDLG_MARQUEEPROGRESS] = false;
					break;

				case ShellProgressDialogStyle.Marquee:
					flags[PROGDLG.PROGDLG_NOPROGRESSBAR] = false;
					flags[PROGDLG.PROGDLG_MARQUEEPROGRESS] = true;
					break;

				case ShellProgressDialogStyle.Hidden:
					flags[PROGDLG.PROGDLG_NOPROGRESSBAR] = true;
					flags[PROGDLG.PROGDLG_MARQUEEPROGRESS] = false;
					break;

				default:
					break;
			}
		}
	}

	/// <summary>Gets or sets the file dialog box title.</summary>
	/// <value>The progress dialog box title. The default value is an empty string ("").</value>
	[DefaultValue(""), Category("Appearance"), Description("")]
	public string Title
	{
		get => title;
		set
		{
			if (title == value) return;
			iDlg.SetTitle(title = value);
		}
	}

	/// <summary>Starts the progress dialog box.</summary>
	/// <param name="hwndParent">The progress dialog box's parent window. This value can be <see langword="null"/>.</param>
	public virtual void Start(IWin32Window hwndParent)
	{
		closed = false;
		iDlg.StartProgressDialog(hwndParent?.Handle ?? IntPtr.Zero, dwFlags: flags);
		iDlg.Timer(PDTIMER.PDTIMER_RESET);
	}

	/// <summary>Stops the progress dialog box and removes it from the screen.</summary>
	public virtual void Stop()
	{
		if (closed) return;
		iDlg.StopProgressDialog();
		closed = true;
	}

	/// <summary>Updates the progress dialog box with the current state of the operation.</summary>
	/// <param name="completed">
	/// An application-defined value that indicates what proportion of the operation has been completed at the time the method was
	/// called. If called with this value equaling the value supplied in <paramref name="total"/>, the <see cref="Stop"/> method will be
	/// called to close the progress dialog.
	/// </param>
	/// <param name="total">
	/// An application-defined value that specifies what value <paramref name="completed"/> will have when the operation is complete.
	/// </param>
	public virtual void UpdateProgress(ulong completed, ulong total)
	{
		if (closed) return;
		iDlg.SetProgress64(completed, total);
		if (completed == total) Stop();
	}

	/// <inheritdoc/>
	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
			return;
		if (!closed)
			Stop();
		GC.SuppressFinalize(this);
	}
}