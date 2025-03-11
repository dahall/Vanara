using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Windows.Forms;
using Vanara.PInvoke;

namespace Vanara.Windows.Shell;

/// <summary>Provides access to the functionality of the taskbar button.</summary>
/// <seealso cref="Component"/>
[ProvideProperty("AppID", typeof(Form))]
[ProvideProperty("TaskbarButtonTooltip", typeof(Form))]
[ProvideProperty("TaskbarButtonOverlay", typeof(Form))]
[ProvideProperty("TaskbarButtonOverlayTooltip", typeof(Form))]
[ProvideProperty("TaskbarButtonProgressState", typeof(Form))]
[ProvideProperty("TaskbarButtonProgressValue", typeof(Form))]
[ProvideProperty("JumpList", typeof(Form))]
[ProvideProperty("TaskbarButtonThumbnails", typeof(Form))]
public class TaskbarButton : ExtenderProviderBase<Form>, INotifyPropertyChanged
{
	private const string category = "Taskbar Button";

	static TaskbarButton() => Application.AddMessageFilter(new ThumbButtonMessageFilter());

	/// <summary>Initializes a new instance of the <see cref="TaskbarButton"/> class.</summary>
	public TaskbarButton()
	{
		TaskbarButtonCreated += OnTaskbarButtonCreated;
		ThumbnailButtonClick += OnThumbnailButtonClick;
	}

	/// <summary>Initializes a new instance of the <see cref="TaskbarButton"/> class.</summary>
	/// <param name="container">The container of this component.</param>
	/// <exception cref="ArgumentNullException">container</exception>
	public TaskbarButton(IContainer container) : this()
	{
		if (container is null)
			throw new ArgumentNullException(nameof(container));
		container.Add(this);
	}

	/// <summary>
	/// Occurs when the system reports a taskbar button has been created. The first parameter will contain the HWND of the window for
	/// which the button was created.
	/// </summary>
	public static event Action<HWND>? TaskbarButtonCreated;

	/// <summary>
	/// Occurs when the system reports a thumbnail button has been clicked. The first parameter contains the HWND of the window shown by
	/// the thumbnail and the second contains the Command ID of the button that was clicked.
	/// </summary>
	public static event Action<HWND, int>? ThumbnailButtonClick;

	/// <summary>Occurs when a property has changed.</summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>Gets a value indicating whether the taskbar button has been created.</summary>
	/// <value><see langword="true"/> if the taskbar button was created; otherwise, <see langword="false"/>.</value>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsTaskbarButtonCreated { get; internal set; } = false;

	/// <summary>Signals the object that initialization is starting.</summary>
	public override void BeginInit()
	{
		base.BeginInit();
		if (Container is Form f && f.ShowInTaskbar)
			TaskbarList.ActivateTaskbarItem(f.Handle);
	}

	/// <summary>Gets the application identifier.</summary>
	/// <param name="form">The form.</param>
	/// <returns>The application identifier.</returns>
	[Category(category), DisplayName("AppID"), DefaultValue(null)]
	[Description("Gets or sets the application identifier.")]
	public string? GetAppID(Form form) => GetPropertyValue<string>(form);

	/// <summary>Gets the jumplist to display on this taskbar button.</summary>
	/// <param name="form">The form.</param>
	/// <returns>The jumplist.</returns>
	[Category(category), DisplayName("JumpList"), Localizable(true)]
	[Description("Gets the jumplist to display with the taskbar button.")]
	public JumpList GetJumpList(Form form)
	{
		var ret = GetPropertyValue<JumpList>(form);
		if (ret is null)
		{
			ret = new JumpList();
			SetPropertyValue(form, ret, "JumpList");
		}
		return ret;
	}

	/// <summary>Gets the overlay icon to dispaly on a taskbar button to indicate application status or a notification to the user.</summary>
	/// <param name="form">The form.</param>
	/// <returns>The overlay icon.</returns>
	[Category(category), DisplayName("TaskbarButtonOverlay"), DefaultValue(null), Localizable(true)]
	[Description("Gets or sets the overlay icon to dispaly on a taskbar button.")]
	public Icon? GetTaskbarButtonOverlay(Form form) => GetPropertyValue<Icon>(form);

	/// <summary>
	/// Gets the overlay tooltip to dispaly on a taskbar button to indicate application status or a notification to the user.
	/// </summary>
	/// <param name="form">The form.</param>
	/// <returns>The overlay tooltip.</returns>
	[Category(category), DisplayName("TaskbarButtonOverlayTooltip"), DefaultValue(null), Localizable(true)]
	[Description("Gets or sets the overlay tooltip to dispaly on a taskbar button.")]
	public string? GetTaskbarButtonOverlayTooltip(Form form) => GetPropertyValue<string>(form);

	/// <summary>Gets the state of the progress indicator displayed on a taskbar button.</summary>
	/// <param name="form">
	/// The window in which the progress of an operation is being shown. This window's associated taskbar button will display the
	/// progress bar.
	/// </param>
	/// <returns>The current state of the progress button.</returns>
	[Category(category), DisplayName("TaskbarButtonProgressState"), DefaultValue(TaskbarButtonProgressState.None)]
	[Description("Gets or sets the state of the progress indicator displayed on a taskbar button.")]
	public TaskbarButtonProgressState GetTaskbarButtonProgressState(Form form) => GetPropertyValue(form, TaskbarButtonProgressState.None);

	/// <summary>
	/// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
	/// </summary>
	/// <param name="form">The window whose associated taskbar button is being used as a progress indicator.</param>
	/// <returns>The proportion of the operation that has been completed at the time the method is called.</returns>
	[Category(category), DisplayName("TaskbarButtonProgressValue"), DefaultValue(0.0f)]
	[Description("Gets or sets the percentage completion for the progress bar hosted in a taskbar button.")]
	public float GetTaskbarButtonProgressValue(Form form) => GetPropertyValue(form, 0.0f);

	/// <summary>Gets the taskbar button thumbnails.</summary>
	/// <param name="form">The window owning the taskbar button thumbnails.</param>
	/// <returns>A collection of thumbnails.</returns>
	[Category(category), DisplayName("TaskbarButtonThumbnails")]
	[Description("Gets the list of thumbnails associated with the taskbar button.")]
	public TaskbarButtonThumbnails GetTaskbarButtonThumbnails(Form form)
	{
		var ret = GetPropertyValue<TaskbarButtonThumbnails>(form);
		if (ret is null)
		{
			ret = new TaskbarButtonThumbnails(form);
			SetPropertyValue(form, ret, "TaskbarButtonThumbnails");
		}
		return ret;
	}

	/// <summary>Gets the description displayed on the tooltip of the taskbar button.</summary>
	/// <param name="form">The form.</param>
	/// <returns>The description</returns>
	[Category(category), DisplayName("TaskbarButtonTooltip"), DefaultValue(null), Localizable(true)]
	[Description("Gets or sets the description displayed on the tooltip of the taskbar button.")]
	public string? GetTaskbarButtonTooltip(Form form) => GetPropertyValue<string>(form);

	/// <summary>Sets the application identifier.</summary>
	/// <param name="form">The form.</param>
	/// <param name="value">The value.</param>
	public void SetAppID(Form form, string value)
	{
		if (SetPropertyValue(form, value) && IsTaskbarButtonCreated)
			ApplySetting(form, value);
	}

	/// <summary>Sets the overlay icon to dispaly on a taskbar button to indicate application status or a notification to the user.</summary>
	/// <param name="form">The form.</param>
	/// <param name="value">The overlay icon to apply.</param>
	public void SetTaskbarButtonOverlay(Form form, Icon value)
	{
		if (SetPropertyValue(form, value) && IsTaskbarButtonCreated)
			ApplySetting(form, value);
	}

	/// <summary>
	/// Gets the overlay tooltip to dispaly on a taskbar button to indicate application status or a notification to the user.
	/// </summary>
	/// <param name="form">The form.</param>
	/// <param name="value">The overlay tooltip.</param>
	public void SetTaskbarButtonOverlayTooltip(Form form, string value)
	{
		if (SetPropertyValue(form, value) && IsTaskbarButtonCreated)
			ApplySetting(form, value);
	}

	/// <summary>Sets the type and state of the progress indicator displayed on a taskbar button.</summary>
	/// <param name="form">
	/// The window in which the progress of an operation is being shown. This window's associated taskbar button will display the
	/// progress bar.
	/// </param>
	/// <param name="value">The current state of the progress button. Specify only one of the enum values.</param>
	public void SetTaskbarButtonProgressState(Form form, TaskbarButtonProgressState value)
	{
		if (SetPropertyValue(form, value) && IsTaskbarButtonCreated)
			ApplySetting(form, value);
	}

	/// <summary>
	/// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
	/// </summary>
	/// <param name="form">The window whose associated taskbar button is being used as a progress indicator.</param>
	/// <param name="value">
	/// The proportion of the operation that has been completed at the time the method is called. This value must be between 0.0f and
	/// </param>
	public void SetTaskbarButtonProgressValue(Form form, float value)
	{
		if (value < 0f || value > 1.0f)
			throw new ArgumentOutOfRangeException(nameof(value), "Progress value must be a number between 0 and 1, inclusive.");
		if (SetPropertyValue(form, value) && IsTaskbarButtonCreated)
			ApplySetting(form, value);
	}

	/// <summary>Sets the description displayed on the tooltip of the taskbar button.</summary>
	/// <param name="form">The form.</param>
	/// <param name="value">The description.</param>
	public void SetTaskbarButtonTooltip(Form form, string value)
	{
		if (SetPropertyValue(form, value) && IsTaskbarButtonCreated)
			ApplySetting(form, value);
	}

	/// <summary>Calls the <see cref="PropertyChanged"/> event.</summary>
	/// <param name="form">The form.</param>
	/// <param name="propName">Name of the changed property.</param>
	protected virtual void OnProperyChanged(Form form, string propName) => PropertyChanged?.Invoke(form, new PropertyChangedEventArgs(propName));

	private void ApplySetting(Form form, object? value, [CallerMemberName] string propName = "")
	{
		if (propName.StartsWith("Set"))
			propName = propName.Remove(0, 3);
		switch (propName)
		{
			case "AppID":
				TaskbarList.SetWindowAppId(form.Handle, (string?)value);
				break;

			case "TaskbarButtonTooltip":
				TaskbarList.SetThumbnailTooltip(form.Handle, (string?)value);
				break;

			case "TaskbarButtonOverlay":
				TaskbarList.SetOverlayIcon(form.Handle, ((Icon?)value)?.Handle ?? HICON.NULL, GetTaskbarButtonOverlayTooltip(form));
				break;

			case "TaskbarButtonOverlayTooltip":
				TaskbarList.SetOverlayIcon(form.Handle, GetTaskbarButtonOverlay(form)?.Handle ?? default, (string?)value);
				break;

			case "TaskbarButtonProgressState":
				TaskbarList.SetProgressState(form.Handle, (TaskbarButtonProgressState)(value ?? 0));
				break;

			case "TaskbarButtonProgressValue":
				TaskbarList.SetProgressValue(form.Handle, (ulong)(100000 * (float)(value ?? 0f)), 100000);
				break;

			case "TaskbarButtonThumbnails":
				GetTaskbarButtonThumbnails(form).ResetToolbar();
				break;

			case "JumpList":
				GetJumpList(form).ApplySettings(GetAppID(form));
				break;

			default:
				throw new InvalidOperationException("Unrecognized setting name.");
		}
		OnProperyChanged(form, propName);
	}

	private void OnTaskbarButtonCreated(HWND hWnd)
	{
		IsTaskbarButtonCreated = true;

		// Apply any settings for this window
		var form = ExtendedComponents.FirstOrDefault(f => f.Handle == hWnd);
		if (form is null) return;
		foreach (var kv in propHash[form])
			ApplySetting(form, kv.Value, kv.Key);
	}

	private void OnThumbnailButtonClick(HWND hWnd, int buttonId)
	{
		var form = ExtendedComponents.FirstOrDefault(f => f.Handle == hWnd);
		if (form is null) return;
		var th = GetTaskbarButtonThumbnails(form);
		if (th is null) return;
		if (buttonId >= 0 && buttonId < th.Toolbar.Buttons.Count)
			th.Toolbar.Buttons[buttonId].InvokeClick();
	}

#pragma warning disable IDE0051 // Remove unused private members
	private void ResetJumpList(Form form) => propHash[form].Remove("JumpList");

	private void ResetTaskbarButtonThumbnails(Form form) => propHash[form].Remove("TaskbarButtonThumbnails");

	private bool ShouldSerializeJumpList(Form form) => GetJumpList(form).Count > 0;

	private bool ShouldSerializeTaskbarButtonThumbnails(Form form) => GetTaskbarButtonThumbnails(form).Count > 0;
#pragma warning restore IDE0051 // Remove unused private members

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	private class ThumbButtonMessageFilter : IMessageFilter
	{
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == Shell32.WM_TASKBARBUTTONCREATED)
				TaskbarButtonCreated?.Invoke(m.HWnd);
			else if (m.Msg == (int)User32.WindowMessage.WM_COMMAND && Macros.HIWORD(m.WParam) == Shell32.THBN_CLICKED)
			{
				ThumbnailButtonClick?.Invoke(m.HWnd, Macros.LOWORD(m.WParam));
				return true;
			}
			return false;
		}
	}
}