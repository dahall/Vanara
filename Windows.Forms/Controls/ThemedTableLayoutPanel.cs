using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Windows.Forms;

/// <summary>
/// A table layout panel that supports a glass overlay.
/// </summary>
[ToolboxItem(true), ToolboxBitmap(typeof(ThemedTableLayoutPanel), "ThemedTableLayoutPanel.bmp")]
public class ThemedTableLayoutPanel : TableLayoutPanel
{
	private const string defaultClass = "WINDOW";
	private const int defaultPart = 29;
	private const int defaultState = 0;

	private string? styleClass;
	private int stylePart;
	private int styleState;
	private bool supportGlass;
	private VisualTheme? theme;

	/// <summary>Initializes a new instance of the <see cref="ThemedTableLayoutPanel"/> class.</summary>
	public ThemedTableLayoutPanel()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
		SetTheme(defaultClass, defaultPart, defaultState);
		HandleCreated += (s, e) => BindFormEvents(true);
		HandleDestroyed += (s, e) => BindFormEvents(false);
	}

	/// <summary>Sets the theme using a defined <see cref="VisualStyleElement"/>.</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public VisualStyleRenderer? Style
	{
		get => styleClass is not null ? new(styleClass, stylePart, styleState) : null;
		set => SetTheme(value?.Class, value?.Part ?? 0, value?.State ?? 0);
	}

	/// <summary>Gets or sets the style class.</summary>
	/// <value>The style class.</value>
	[DefaultValue(defaultClass), Category("Appearance")]
	public string? StyleClass
	{
		get => styleClass;
		set { if (styleClass != value) { styleClass = value; ResetTheme(); } }
	}

	/// <summary>Gets or sets the style part.</summary>
	/// <value>The style part.</value>
	[DefaultValue(defaultPart), Category("Appearance")]
	public int StylePart
	{
		get => stylePart;
		set { if (stylePart != value) { stylePart = value; Invalidate(); } }
	}

	/// <summary>Gets or sets the style part.</summary>
	/// <value>The style part.</value>
	[DefaultValue(defaultState), Category("Appearance")]
	public int StyleState
	{
		get => styleState;
		set { if (styleState != value) { styleState = value; Invalidate(); } }
	}

	/// <summary>Gets or sets a value indicating whether this table supports glass (can be enclosed in the glass margin).</summary>
	/// <value><c>true</c> if supports glass; otherwise, <c>false</c>.</value>
	[DefaultValue(false), Category("Appearance")]
	public bool SupportGlass
	{
		get => supportGlass;
		set { if (supportGlass != value) { supportGlass = value; Invalidate(); } }
	}

	/// <summary>Gets or sets a style part value that is used when focus is lost.</summary>
	/// <value>The non-focused style part value. A value of -1 will set the state to the same value as <see cref="StyleState"/>.</value>
	[DefaultValue(-1), Category("Appearance")]
	public int UnfocusedStyleState { get; set; } = -1;

	private bool ThemingSupported => Application.RenderWithVisualStyles || DesktopWindowManager.CompositionEnabled;

	/// <summary>Sets the theme using theme class information.</summary>
	/// <param name="className">Name of the theme class.</param>
	/// <param name="part">The theme part.</param>
	/// <param name="state">The theme state.</param>
	public void SetTheme(string? className, int part, int state)
	{
		styleClass = className;
		stylePart = part;
		styleState = state;
		ResetTheme();
	}

	/// <summary>Sets the theme using <see cref="VisualStyleElement"/> information.</summary>
	/// <param name="visualStyle">The visual style.</param>
	public void SetTheme(VisualStyleElement visualStyle) => SetTheme(visualStyle?.ClassName, visualStyle?.Part ?? 0, visualStyle?.State ?? 0);

	/// <summary>Raises the <see cref="Control.Paint"/> event.</summary>
	/// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
	protected override void OnPaint(PaintEventArgs e)
	{
		if (Visible)
		{
			if (!this.IsDesignMode() && SupportGlass && ThemingSupported)
				try { e.Graphics.Clear(Color.Black); } catch { }
			else
			{
				var state = UnfocusedStyleState == -1 || FindForm().Focused ? styleState : UnfocusedStyleState;
				if (theme != null && ThemingSupported)
				{
					if (theme.IsBackgroundPartiallyTransparent(stylePart, state))
						theme.DrawParentBackground(this, e.Graphics, ClientRectangle);
					theme.DrawBackground(e.Graphics, stylePart, state, ClientRectangle, e.ClipRectangle);
					if (!string.IsNullOrEmpty(Text))
						theme.DrawText(e.Graphics, stylePart, state, ClientRectangle, Text, this.BuildTextFormatFlags(false), !Enabled);
				}
				else
				{
					try { e.Graphics.Clear(BackColor); } catch { }
					if (!string.IsNullOrEmpty(Text))
						TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, this.BuildTextFormatFlags(false));
				}
			}
		}
		base.OnPaint(e);
	}

	/// <summary>
	/// Fires the event indicating that the panel has been resized. Inheriting controls should use this in favor of actually listening to
	/// the event, but should still call base.onResize to ensure that the event is fired for external listeners.
	/// </summary>
	/// <param name="eventargs">An <see cref="EventArgs"/> that contains the event data.</param>
	protected override void OnResize(EventArgs eventargs)
	{
		base.OnResize(eventargs);
		Refresh();
	}

	private void BindFormEvents(bool attach)
	{
		var pForm = FindForm();
		if (pForm != null)
		{
			if (attach)
			{
				pForm.Activated += ParentStateChanged;
				pForm.Deactivate += ParentStateChanged;
			}
			else
			{
				pForm.Activated -= ParentStateChanged;
				pForm.Deactivate -= ParentStateChanged;
			}
		}
	}

	private void ParentStateChanged(object? sender, EventArgs e) => Refresh();

	private void ResetTheme()
	{
		if (styleClass != null && ThemingSupported)
		{
			try
			{
				theme = new VisualTheme(Parent, styleClass, SupportGlass ? OpenThemeDataOptions.OTD_NONCLIENT : OpenThemeDataOptions.None);
			}
			catch
			{
				theme = null;
			}
		}
		else
			theme = null;
		Refresh();
	}
}