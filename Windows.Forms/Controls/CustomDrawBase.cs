using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Vanara.Windows.Forms;

/// <summary>State flags for controls derived from <see cref="CustomDrawBase"/>.</summary>
[Flags]
public enum ControlState
{
	/// <summary>A mouse is hovering over the control.</summary>
	Hot = 1 << 0,

	/// <summary>The control has been pressed or clicked.</summary>
	Pressed = 1 << 1,

	/// <summary>The control is disabled.</summary>
	Disabled = 1 << 2,

	/// <summary>The control is in the process of animating.</summary>
	Animating = 1 << 3,

	/// <summary>The mouse button is down.</summary>
	MouseDown = 1 << 4,

	/// <summary>The mouse button is up.</summary>
	InButtonUp = 1 << 5,

	/// <summary>The control is defaulted (used primarily by buttons).</summary>
	Defaulted = 1 << 6,

	/// <summary>The control has the focus.</summary>
	Focused = 1 << 7,
}

/// <summary>
/// Abstract class for implementing a custom-drawn control that tracks mouse movement and has text and/or an image. It exposes all
/// property changes.
/// </summary>
/// <seealso cref="Control"/>
/// <seealso cref="IButtonControl"/>
/// <seealso cref="INotifyPropertyChanged"/>
public abstract class CustomDrawBase : Control, IButtonControl, INotifyPropertyChanged
{
	private readonly ControlImage image;
	private bool autoEllipsis;
	private ContentAlignment imageAlign = ContentAlignment.MiddleCenter;

	//private bool keyPressed;
	private ControlState lastState;

	private EnumFlagIndexer<ControlState> state;
	private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
	private TextImageRelation textImageRelation = TextImageRelation.Overlay;
	private ToolTip? textToolTip;
	private bool useMnemonic = true;

	/// <summary>Initializes a new instance of the <see cref="CustomDrawBase"/> class.</summary>
	protected CustomDrawBase()
	{
		image = new ControlImage(this);
		SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.ResizeRedraw, true);
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
	}

	/// <summary>Occurs when the control is double-clicked.</summary>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
	public new event EventHandler? DoubleClick
	{
		add => base.DoubleClick += value;
		remove => base.DoubleClick -= value;
	}

	/// <summary>Occurs when the control is double clicked by the mouse.</summary>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
	public new event MouseEventHandler? MouseDoubleClick
	{
		add => base.MouseDoubleClick += value;
		remove => base.MouseDoubleClick -= value;
	}

	/// <summary>Occurs when a property value changes.</summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the control, denoting that the
	/// control text extends beyond the specified length of the control.
	/// </summary>
	/// <value>
	/// <c>true</c> if the additional label text is to be indicated by an ellipsis; otherwise, <c>false</c>. The default is <c>true</c>.
	/// </value>
	[Category("Behavior"), DefaultValue(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Description("")]
	public bool AutoEllipsis
	{
		get => autoEllipsis;
		set => SetField(ref autoEllipsis, value, nameof(AutoEllipsis), true, b => { if (b && textToolTip == null) textToolTip = new ToolTip(); });
	}

	/// <summary>Gets or sets the value returned to the parent form when the button is clicked.</summary>
	[Category("Behavior"), DefaultValue(typeof(DialogResult), "None")]
	[Description("The dialog result produced in a modal form by clicking the button.")]
	public virtual DialogResult DialogResult { get; set; }

	/// <summary>Gets or sets the image that is displayed on a button control.</summary>
	/// <value>The Image displayed on the button control. The default value is <c>null</c>.</value>
	[Description(""), Localizable(true), Category("Appearance"), DefaultValue(null)]
	public Image? Image
	{
		get => image.Image;
		set
		{
			if (image.Image == value) return;
			image.Image = value;
			OnPropertyChanged(nameof(Image));
		}
	}

	/// <summary>Gets or sets the alignment of the image on the button control.</summary>
	/// <value>One of the <see cref="ContentAlignment"/> values. The default value is <c>MiddleCenter</c>.</value>
	[Category("Appearance"), DefaultValue((int)ContentAlignment.MiddleCenter)]
	[Description("The alignment of the image that will be displayed in the face of the control.")]
	public virtual ContentAlignment ImageAlign
	{
		get => imageAlign;
		set => SetField(ref imageAlign, value, nameof(imageAlign));
	}

	/// <summary>Gets or sets the image list index value of the image displayed on the button control.</summary>
	/// <value>A zero-based index, which represents the image position in an <see cref="ImageList"/>. The default is -1.</value>
	[Description(""), Localizable(true), Category("Appearance"), DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint)]
	[TypeConverter(typeof(ImageIndexConverter)), Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public int ImageIndex
	{
		get => image.ImageIndex;
		set
		{
			if (image.ImageIndex == value) return;
			image.ImageIndex = value;
			OnPropertyChanged(nameof(ImageIndex));
		}
	}

	/// <summary>Gets or sets the key accessor for the image in the <see cref="ImageList"/>.</summary>
	/// <value>A string representing the key of the image.</value>
	[Description(""), Localizable(true), Category("Appearance"), DefaultValue(""), RefreshProperties(RefreshProperties.Repaint)]
	[TypeConverter(typeof(ImageKeyConverter)), Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string ImageKey
	{
		get => image.ImageKey;
		set
		{
			if (image.ImageKey == value) return;
			image.ImageKey = value;
			OnPropertyChanged(nameof(ImageKey));
		}
	}

	/// <summary>Gets or sets the <see cref="ImageList"/> that contains the <see cref="Image"/> displayed on a button control.</summary>
	/// <value>An <see cref="ImageList"/>. The default value is <c>null</c>.</value>
	[Description(""), Category("Appearance"), DefaultValue(null), RefreshProperties(RefreshProperties.Repaint)]
	public ImageList? ImageList
	{
		get => image.ImageList;
		set
		{
			if (image.ImageList == value) return;
			image.ImageList = value;
			OnPropertyChanged(nameof(ImageList));
		}
	}

	/// <summary>Gets or sets the alignment of the text on the button control.</summary>
	/// <value>One of the <see cref="ContentAlignment"/> values. The default value is <c>MiddleCenter</c>.</value>
	[Category("Appearance"), DefaultValue((int)ContentAlignment.MiddleCenter)]
	[Description("The alignment of the text that will be displayed in the face of the control.")]
	public virtual ContentAlignment TextAlign
	{
		get => textAlign;
		set => SetField(ref textAlign, value, nameof(TextAlign));
	}

	/// <summary>Gets or sets the position of text and image relative to each other.</summary>
	/// <value>One of the values of <see cref="TextImageRelation"/>. The default is <c>Overlay</c>.</value>
	[DefaultValue(0), Localizable(true), Description(""), Category("Appearance")]
	public TextImageRelation TextImageRelation
	{
		get => textImageRelation;
		set => SetField(ref textImageRelation, value, nameof(TextImageRelation));
	}

	/// <summary>
	/// Gets or sets a value indicating whether the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key
	/// of the control.
	/// </summary>
	/// <value>
	/// <c>true</c> if the first character that is preceded by an ampersand (&amp;) is used as the mnemonic key of the control;
	/// otherwise, <c>false</c>. The default is <c>true</c>.
	/// </value>
	[DefaultValue(true), Description(""), Category("Appearance")]
	public bool UseMnemonic
	{
		get => useMnemonic;
		set => SetField(ref useMnemonic, value, nameof(UseMnemonic));
	}

	/// <summary>Gets or sets a value indicating whether this <see cref="CustomDrawBase"/> is animating.</summary>
	/// <value><see langword="true"/> if animating; otherwise, <see langword="false"/>.</value>
	[Browsable(false)]
	protected virtual bool Animating
	{
		get => state[ControlState.Animating];
		set => SetState(ControlState.Animating, value, false);
	}

	/// <summary>Gets the default size of the control.</summary>
	protected override Size DefaultSize => new(75, 23);

	/// <summary>Gets or sets a value indicating whether the button control is the default button.</summary>
	/// <value><c>true</c> if the button control is the default button; otherwise, <c>false</c>.</value>
	[Browsable(false)]
	protected virtual bool IsDefault
	{
		get => state[ControlState.Defaulted];
		set => SetState(ControlState.Defaulted, value);
	}

	/// <summary>Gets the last state of the control.</summary>
	/// <value>The last state.</value>
	protected virtual ControlState LastState => lastState;

	/// <summary>Gets the current state of the control.</summary>
	/// <value>The state.</value>
	protected virtual ControlState State => state;

	private bool ShowToolTip => !DesignMode && AutoEllipsis && textToolTip != null;

	/// <summary>Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly.</summary>
	/// <param name="value">true if the control should behave as a default button; otherwise false.</param>
	public virtual void NotifyDefault(bool value)
	{
		if (IsDefault == value) return;
		IsDefault = value;
		Invalidate();
	}

	/// <summary>Generates a <see cref="E:System.Windows.Forms.Control.Click"/> event for the control.</summary>
	public void PerformClick()
	{
		if (CanSelect)
			OnClick(EventArgs.Empty);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnEnabledChanged(EventArgs e)
	{
		base.OnEnabledChanged(e);
		state[ControlState.Disabled] = !Enabled;
		if (Enabled) return;
		SetState(ControlState.MouseDown | ControlState.Pressed | ControlState.Hot, false);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnGotFocus(EventArgs e)
	{
		System.Diagnostics.Debug.WriteLine($"GotFocus[{Name}]");
		base.OnGotFocus(e);
		SetState(ControlState.Focused, true);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> that contains the event data.</param>
	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (e.KeyData == Keys.Space)
		{
			SetState(ControlState.MouseDown, true);
			e.Handled = true;
		}
		base.OnKeyDown(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> that contains the event data.</param>
	protected override void OnKeyUp(KeyEventArgs e)
	{
		if (state[ControlState.MouseDown])
		{
			if (SetState(ControlState.MouseDown | ControlState.Pressed, false, false))
				Refresh();
			if (e.KeyCode is Keys.Space or Keys.Enter)
				OnClick(EventArgs.Empty);
			e.Handled = true;
		}
		base.OnKeyUp(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnLostFocus(EventArgs e)
	{
		System.Diagnostics.Debug.WriteLine($"LostFocus[{Name}]");
		base.OnLostFocus(e);
		Capture = false;
		SetState(ControlState.MouseDown | ControlState.Pressed | ControlState.Focused, false);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
			SetState(ControlState.MouseDown | ControlState.Pressed, true);
		base.OnMouseDown(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnMouseEnter(EventArgs e)
	{
		SetState(ControlState.Hot, true);
		if (ShowToolTip && textToolTip is not null)
			try { textToolTip.Show(Text.RemoveMnemonic(), this); } catch { }
		base.OnMouseEnter(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnMouseLeave(EventArgs e)
	{
		System.Diagnostics.Debug.WriteLine($"OnMouseLeave[{Name}]");
		SetState(ControlState.Hot, false);
		textToolTip?.Hide(this);
		base.OnMouseLeave(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (e.Button != MouseButtons.None && state[ControlState.Pressed])
		{
			if (!ClientRectangle.Contains(e.X, e.Y))
			{
				if (state[ControlState.MouseDown])
					SetState(ControlState.MouseDown | ControlState.Pressed, false);
			}
			else if (!state[ControlState.MouseDown])
			{
				SetState(ControlState.MouseDown, true);
			}
		}
		base.OnMouseMove(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left && state[ControlState.Pressed])
		{
			var mouseWasDown = state[ControlState.MouseDown];
			if (SetState(ControlState.MouseDown | ControlState.Pressed, false, false))
				Refresh();
			if (mouseWasDown && WindowFromPoint(PointToScreen(e.Location)) == Handle)
			{
				OnClick(e);
				OnMouseClick(e);
			}
		}
		base.OnMouseUp(e);
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged"/> event when the <see
	/// cref="P:System.Windows.Forms.Control.BackColor"/> property value of the control's container changes.
	/// </summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnParentBackColorChanged(EventArgs e)
	{
		base.OnParentBackColorChanged(e);
		Invalidate();
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.BackgroundImageChanged"/> event when the <see
	/// cref="P:System.Windows.Forms.Control.BackgroundImage"/> property value of the control's container changes.
	/// </summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnParentBackgroundImageChanged(EventArgs e)
	{
		base.OnParentBackgroundImageChanged(e);
		Invalidate();
	}

	/// <summary>Raises the <see cref="PropertyChanged"/> event.</summary>
	/// <param name="propertyName">Name of the property that has changed.</param>
	protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.TextChanged"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate();
	}

	/// <summary>Processes a mnemonic character.</summary>
	/// <param name="charCode">The character to process.</param>
	/// <returns>true if the character was processed as a mnemonic by the control; otherwise, false.</returns>
	protected override bool ProcessMnemonic(char charCode)
	{
		if (!IsMnemonic(charCode, Text))
			return base.ProcessMnemonic(charCode);
		OnClick(EventArgs.Empty);
		return true;
	}

	/// <summary>
	/// Sets a field value to the new value. If the value has changed, the <see cref="PropertyChanged"/> event is raised and the control
	/// will optionally be invalidated.
	/// </summary>
	/// <typeparam name="T">The type of the field.</typeparam>
	/// <param name="field">A reference to the field.</param>
	/// <param name="value">The new value.</param>
	/// <param name="propertyName">The name of the property.</param>
	/// <param name="invalidateOnSet">if set to <c>true</c> the control is invalidated if this is a changed value.</param>
	/// <param name="validate">An optional action function that is called when it is determined that this is a changed value.</param>
	/// <returns><c>true</c> if the value has been changed; otherwise <c>false</c>.</returns>
	protected virtual bool SetField<T>(ref T field, T value, string propertyName, bool invalidateOnSet = true, Action<T>? validate = null) where T : struct
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
		validate?.Invoke(value);
		if (typeof(T).IsEnum && !Enum.IsDefined(typeof(T), value))
			throw new InvalidEnumArgumentException(propertyName, Convert.ToInt32(value), typeof(T));
		field = value;
		OnPropertyChanged(propertyName);
		if (invalidateOnSet && IsHandleCreated)
			Invalidate();
		return true;
	}

	/// <summary>Sets the state of the control.</summary>
	/// <param name="stateVal">The state value.</param>
	/// <param name="value">
	/// if set to <see langword="true"/> sets the flag in <paramref name="stateVal"/> on; otherwise it removes the state.
	/// </param>
	/// <param name="invalidateOnSet">if set to <see langword="true"/>, invalidate the control once set.</param>
	/// <returns></returns>
	protected virtual bool SetState(ControlState stateVal, bool value, bool invalidateOnSet = true)
	{
		if (state[stateVal] == value) return false;
		lastState = state;
		state[stateVal] = value;
		OnPropertyChanged(nameof(State));
		if (invalidateOnSet && IsHandleCreated)
			Invalidate();
		return true;
	}

	/// <summary>Processes Windows messages.</summary>
	/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
	protected override void WndProc(ref Message m)
	{
		switch (m.Msg)
		{
			case (int)WindowMessage.WM_ERASEBKGND:
				DefWndProc(ref m);
				return;

			/*case 0x2111:
				if (HIWORD(m.WParam) == 0)
				{
					OnClick(EventArgs.Empty);
					return;
				}
				break;*/

			case (int)ButtonMessage.BM_CLICK:
				PerformClick();
				return;

			case (int)ButtonMessage.BM_SETSTATE:
				// Ignore BM_SETSTATE -- Windows gets confused and paints things, even though we are ownerdraw.
				return;

			case (int)WindowMessage.WM_KILLFOCUS:
			case (int)WindowMessage.WM_CANCELMODE:
			case (int)WindowMessage.WM_CAPTURECHANGED:
				if (!state[ControlState.InButtonUp] && state[ControlState.Pressed])
					SetState(ControlState.MouseDown | ControlState.Pressed, false);
				break;

			case (int)WindowMessage.WM_LBUTTONUP:
			case (int)WindowMessage.WM_MBUTTONUP:
			case (int)WindowMessage.WM_RBUTTONUP:
				try
				{
					state[ControlState.InButtonUp] = true;
					base.WndProc(ref m);
					return;
				}
				finally
				{
					state[ControlState.InButtonUp] = false;
				}
		}
		base.WndProc(ref m);
	}
}