using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Vanara.Windows.Forms;

internal class CollapsiblePanelHeader : Control
{
	private const int tbpadding = 8;
	private const string bgClass = "LISTVIEW", btnClass = "TASKDIALOG", txtClass = btnClass;
	private const int bgPart = 6, btnPart = 13, txtPart = 2;
	private readonly VisualStyleRenderer? bgRnd, btnRnd, txtRnd;
	private int headerHeight;
	private Size imgSz;
	private Rectangle buttonBounds;
	private Rectangle textBounds;

	public CollapsiblePanelHeader()
	{
		SetStyle(ControlStyles.OptimizedDoubleBuffer |
			ControlStyles.AllPaintingInWmPaint |
			ControlStyles.ResizeRedraw |
			ControlStyles.UserPaint, true);
		if (VisualStyleRenderer.IsSupported)
			try
			{
				bgRnd = new VisualStyleRenderer(bgClass, bgPart, 0);
				btnRnd = new VisualStyleRenderer(btnClass, btnPart, 0);
				txtRnd = new VisualStyleRenderer(txtClass, txtPart, 0);
			}
			catch { }
	}

	[DefaultValue(false)]
	public bool Collapsed { get; set; }

	internal PushButtonState ButtonState { get; set; } = PushButtonState.Normal;

	internal int HorzPadding { get; set; } = 12;

	/// <summary>
	/// Retrieves the default size for the control.
	/// </summary>
	/// <value></value>
	/// <returns>
	/// The default <see cref="T:System.Drawing.Size"/> of the control.
	/// </returns>
	protected override Size DefaultSize => new(200, 200);

	/// <summary>
	/// Retrieves the size of a rectangular area into which a control can be fitted.
	/// </summary>
	/// <param name="proposedSize">The custom-sized area for a control.</param>
	/// <returns>
	/// An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.
	/// </returns>
	public override Size GetPreferredSize(Size proposedSize) => DefaultSize;

	protected override void OnClick(EventArgs e)
	{
		Collapsed = !Collapsed;
		base.OnClick(e);
	}

	/// <summary>
	/// Process Enabled property changed
	/// </summary>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected override void OnEnabledChanged(EventArgs e)
	{
		ButtonState = Enabled ? PushButtonState.Normal : PushButtonState.Disabled;
		Invalidate();
		base.OnEnabledChanged(e);
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
	/// </summary>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected override void OnGotFocus(EventArgs e)
	{
		Invalidate();
		base.OnGotFocus(e);
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
	/// </summary>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected override void OnLostFocus(EventArgs e)
	{
		Invalidate();
		base.OnLostFocus(e);
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
	/// </summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseDown(MouseEventArgs e)
	{
		if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
		ButtonState = PushButtonState.Pressed;
		Invalidate();
		base.OnMouseDown(e);
	}

	/// <summary>
	/// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseEnter(System.EventArgs)"/> event.
	/// </summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnMouseEnter(EventArgs e)
	{
		ButtonState = PushButtonState.Hot;
		Invalidate();
		base.OnMouseEnter(e);
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.
	/// </summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnMouseLeave(EventArgs e)
	{
		ButtonState = Enabled ? PushButtonState.Normal : PushButtonState.Disabled;
		Invalidate();
		base.OnMouseLeave(e);
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.
	/// </summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseUp(MouseEventArgs e)
	{
		if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
		ButtonState = Enabled ? PushButtonState.Hot : PushButtonState.Disabled;
		Invalidate();
		base.OnMouseUp(e);
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
	/// </summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
	protected override void OnPaint(PaintEventArgs e)
	{
		if (Visible)
		{
			var g = e.Graphics;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;

			if (bgRnd is null)
				try
				{
					e.Graphics.Clear(ButtonState is PushButtonState.Hot or PushButtonState.Pressed ? SystemColors.Highlight : SystemColors.Window);
					TextRenderer.DrawText(e.Graphics, Text, SystemFonts.CaptionFont, textBounds.Location, ButtonState is PushButtonState.Hot or PushButtonState.Pressed ? SystemColors.HighlightText : SystemColors.WindowText);
				}
				catch { }
			else
			{
				LayoutElements(e.Graphics, e.ClipRectangle);
				bgRnd.DrawBackground(e.Graphics, ClientRectangle);
				btnRnd!.DrawBackground(e.Graphics, buttonBounds, null, this.GetRightToLeftProperty() == RightToLeft.Yes);
				var tff = TextFormatFlags.SingleLine;
				if (this.GetRightToLeftProperty() == RightToLeft.Yes)
					tff |= TextFormatFlags.RightToLeft;
				txtRnd!.DrawText(e.Graphics, textBounds, Text, !Enabled, tff);
			}
			base.OnPaint(e);
		}
	}

	private void LayoutElements(IDeviceContext g, Rectangle clipRect)
	{
		if (btnRnd is null) return;
		var state = (int)ButtonState;
		if (state == 4)
			state = Collapsed ? 7 : 8;
		else if (!Collapsed)
			state += 3;
		btnRnd.SetState(state);
		state = (ButtonState is PushButtonState.Hot or PushButtonState.Pressed) ? 2 : 1;
		bgRnd!.SetState(state);
		var r = txtRnd!.GetTextExtent(g, "W", TextFormatFlags.Default);
		headerHeight = tbpadding * 2 + r.Height;
		imgSz = new Size(btnRnd.GetInteger(IntegerProperty.Width), btnRnd.GetInteger(IntegerProperty.Height));
		buttonBounds = new Rectangle(clipRect.Width - imgSz.Width - HorzPadding, (headerHeight - imgSz.Height) / 2, imgSz.Width, imgSz.Height);
		textBounds = new Rectangle(HorzPadding, tbpadding, clipRect.Width - HorzPadding - imgSz.Width, tbpadding + r.Height);
		Height = headerHeight;
	}
}
