namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// <para>Used by IActionProgress::Begin, these constants specify certain UI operations that are to be enabled or disabled.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-_spbeginf
	[PInvokeData("shobjidl_core.h", MSDNShortId = "dc5215ca-17c8-47c1-8059-f46400ff1d0f")]
	[Flags]
	public enum SPBEGINF : uint
	{
		/// <summary>Indicates default progress behavior.</summary>
		SPBEGINF_NORMAL = 0x00000000,

		/// <summary>
		/// Indicates that the progress UI should automatically update a text field with the amount of time remaining until the action completes.
		/// </summary>
		SPBEGINF_AUTOTIME = 0x00000002,

		/// <summary>Indicates that the UI should not display a progress bar.</summary>
		SPBEGINF_NOPROGRESSBAR = 0x00000010,

		/// <summary>Indicates that the UI should use a marquee-style progress bar.</summary>
		SPBEGINF_MARQUEEPROGRESS = 0x00000020,

		/// <summary>Indicates that the UI should not include a Cancel button.</summary>
		SPBEGINF_NOCANCELBUTTON = 0x00000040,
	}

	/// <summary>Flags used by IActionProgressDialog::Initialize</summary>
	[PInvokeData("shobjidl_core.h")]
	public enum SPINITF
	{
		/// <summary>Use the default progress dialog behavior.</summary>
		SPINITF_NORMAL = 0x00000000,

		/// <summary>Use a modal window for the dialog.</summary>
		SPINITF_MODAL = 0x00000001,

		/// <summary>Do not display a minimize button.</summary>
		SPINITF_NOMINIMIZE = 0x00000008,
	}

	/// <summary>
	/// <para>Specifies the type of descriptive text being provided to an IActionProgress interface.</para>
	/// </summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "3d33cb3a-5949-446c-97ec-7ac4f4b1f675")]
	public enum SPTEXT
	{
		/// <summary>The text is a high level, short description.</summary>
		SPTEXT_ACTIONDESCRIPTION = 1,

		/// <summary>The text is a detailed description.</summary>
		SPTEXT_ACTIONDETAIL,
	}

	/// <summary>
	/// <para>Represents the abstract base class from which progress-driven operations can inherit.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This class is an abstract class that may not be instantiated. It provides a framework that derived classes can use to implement a
	/// progress callback. This callback can be used by applications to report progress of actions to the UI. Here, "Actions" refers to
	/// operations that may take a significant amount of time, such as downloading or copying files, and during which a visible progress
	/// indication would be appropriate.
	/// </para>
	/// <para>
	/// Applications typically do not implement this interface. Much of the functionality that users interact with during actions is
	/// provided by the CProgressDialog class (CLSID_ProgressDialog) that implements <c>IActionProgress</c> and displays progress in a
	/// dialog box. If a solution requiring a mechanism other than a dialog box is required, <c>IActionProgress</c> can be used to
	/// provide basic progress indicator functionality.
	/// </para>
	/// <para>
	/// Once implemented, classes should call IActionProgress::Begin when an action is started. Periodically,
	/// IActionProgress::UpdateProgress should be called to update the UI with progress information, and detailed textual information
	/// should be conveyed to the UI by calling IActionProgress::UpdateText. IActionProgress::QueryCancel and
	/// IActionProgress::ResetCancel should be called to handle cancellation requests. Once the operation ends, IActionProgress::End
	/// should be called.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iactionprogress
	[PInvokeData("shobjidl_core.h", MSDNShortId = "e742e381-0fd2-482a-81a0-7b43d11b073b")]
	[ComImport, Guid("49ff1173-eadc-446d-9285-156453a6431c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ProgressDialog))]
	public interface IActionProgress
	{
		/// <summary>
		/// <para>Called when an action has begun that requires its progress be displayed to the user.</para>
		/// </summary>
		/// <param name="action">
		/// <para>Type: <c>SPACTION</c></para>
		/// <para>The action being performed. See SPACTION for a list of acceptable values.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>SPBEGINF</c></para>
		/// <para>Optional flags that request certain UI operations be enabled or disabled. See SPBEGINF for a list of acceptable values.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method should be called when an action is beginning. The values of and may be used to determine how to draw the UI that
		/// will be displayed to the user, or how to interpret or filter certain user actions associated with the action. When the action
		/// has completed, IActionProgress::End should be called.
		/// </para>
		/// </remarks>
		void Begin(SPACTION action, SPBEGINF flags);

		/// <summary>
		/// <para>Updates the progress of an action to the UI.</para>
		/// </summary>
		/// <param name="ulCompleted">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>The amount of the action completed.</para>
		/// </param>
		/// <param name="ulTotal">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>The total amount of the action.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method should be called periodically to update the progress of the action. The implementing class may interpret these
		/// values in any way desired, although the values of and should be interpreted relative to one another to determine a meaningful
		/// progress amount. Often, a percentage is desired, in which case the value of should be divided by , and the result multiplied
		/// by a value of 100.
		/// </para>
		/// </remarks>
		void UpdateProgress(ulong ulCompleted, ulong ulTotal);

		/// <summary>
		/// <para>Called if descriptive text associated with the action will be changed.</para>
		/// </summary>
		/// <param name="sptext">
		/// <para>Type: <c>SPTEXT</c></para>
		/// <para>A value that specifies the type of text displayed. See SPTEXT for acceptable values.</para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a wide character string to display.</para>
		/// </param>
		/// <param name="fMayCompact">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A value that specifies whether to allow a text string to be compacted to fit the available space on screen.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The class implementing this method must interpret the value of and in the context of the action being performed and the UI
		/// that shows the progress to the user. The value of can be used to differentiate between lines of changeable text. Often, the
		/// value of refers to whether the text string can be truncated with an ellipsis (...) in order to conserve screen space.
		/// </para>
		/// </remarks>
		void UpdateText(SPTEXT sptext, [In, MarshalAs(UnmanagedType.LPWStr)] string pszText, [MarshalAs(UnmanagedType.Bool)] bool fMayCompact);

		/// <summary>
		/// <para>Provides information about whether the action is being canceled.</para>
		/// </summary>
		/// <returns>
		/// <para>A reference to a <c>BOOL</c> value that specifies whether the action is being canceled.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Call this method when a process must know whether an action has been canceled. Implementing this method requires the
		/// implementing class to query either an internal or external flag to provide this information, and store the result in the
		/// value of .
		/// </para>
		/// </remarks>
		bool QueryCancel();

		/// <summary>
		/// <para>Resets progress dialog after a cancellation has been completed.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method is called when a cancellation has been completed. User input should typically be limited for cancellations of
		/// actions that involve large calculations or file operations. This method may be used by calling applications to notify a
		/// progress UI that the cancellation has been completed and the UI should return control to the user.
		/// </para>
		/// </remarks>
		void ResetCancel();

		/// <summary>
		/// <para>Indicates that the action associated with this progress implementation has ended.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method indicates that the action has finished, and the implementing class should perform cleanup and display results to
		/// the user, if applicable.
		/// </para>
		/// </remarks>
		void End();
	}

	/// <summary>Exposes methods that initialize and stop a progress dialog.</summary>
	/// <remarks>
	/// To instantiate an object that implements this interface, call CoCreateInstance using the class identifier (CLSID) CLSID_ProgressDialog.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iactionprogressdialog
	[PInvokeData("shobjidl_core.h", MSDNShortId = "f3c0e4ae-f93f-4ee2-873a-d9370044e922")]
	[ComImport, Guid("49ff1172-eadc-446d-9285-156453a6431c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ProgressDialog))]
	public interface IActionProgressDialog
	{
		/// <summary>Provides details about the action progress dialog.</summary>
		/// <param name="flags">
		/// <para>Type: <c>SPINITF</c></para>
		/// <para>One of the following values.</para>
		/// <para>SPINITF_NORMAL (0x01)</para>
		/// <para>Use the default progress dialog behavior.</para>
		/// <para>SPINITF_MODAL (0x01)</para>
		/// <para>Use a modal window for the dialog.</para>
		/// <para>SPINITF_NOMINIMIZE (0x08)</para>
		/// <para>Do not display a minimize button.</para>
		/// </param>
		/// <param name="pszTitle">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The title of the progress dialog.</para>
		/// </param>
		/// <param name="pszCancel">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The string displayed when a user closes the dialog before completion.</para>
		/// </param>
		void Initialize(SPINITF flags, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle, [In, MarshalAs(UnmanagedType.LPWStr)] string pszCancel);

		/// <summary>Stops a progress dialog.</summary>
		void Stop();
	}
}