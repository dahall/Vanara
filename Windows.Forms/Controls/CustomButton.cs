using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using Vanara.Extensions;

namespace Vanara.Windows.Forms;

/// <summary>A custom drawn button.</summary>
/// <seealso cref="Vanara.Windows.Forms.CustomDrawBase"/>
public class CustomButton : CustomDrawBase
{
	private const int pad = 3;
	private RectangleF contentRect;
	private int cornerRadius = 4;
	private DrawPattern defDrawPattern;
	private Corners roundCorners = Corners.All;

	/// <summary>Initializes a new instance of the <see cref="CustomButton"/> class.</summary>
	public CustomButton()
	{
		SetStyle(ControlStyles.Opaque, false);
		SetStyle(ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
	}

	/// <summary>Gets or sets the corner radius.</summary>
	/// <value>The corner radius.</value>
	[Category("Appearance"), DefaultValue(4), Description("Defines the radius of the controls RoundedCorners.")]
	public int CornerRadius
	{
		get => cornerRadius; set => SetField(ref cornerRadius, value, nameof(CornerRadius));
	}

	/// <summary>Gets the paint pattern.</summary>
	/// <value>The paint pattern.</value>
	public Dictionary<PushButtonState, DrawPattern> PaintPattern { get; } = new Dictionary<PushButtonState, DrawPattern>();

	/// <summary>Gets or sets the style of the rounded corners.</summary>
	/// <value>The rounded corner style.</value>
	[Category("Appearance"), DefaultValue(typeof(Corners), "All")]
	[Description("Gets/sets the corners of the control to round.")]
	[Editor(typeof(RoundCornersEditor), typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Corners RoundCorners
	{
		get => roundCorners; set => SetField(ref roundCorners, value, nameof(RoundCorners));
	}

	/// <summary>Gets the state of the button.</summary>
	/// <value>The state of the button.</value>
	protected PushButtonState ButtonState
	{
		get
		{
			EnumFlagIndexer<ControlState> state = State;
			if (state[ControlState.Disabled]) return PushButtonState.Disabled;
			if (state[ControlState.Hot]) return PushButtonState.Hot;
			if (state[ControlState.Pressed]) return PushButtonState.Pressed;
			if (state[ControlState.Defaulted]) return PushButtonState.Default;
			return PushButtonState.Normal;
		}
	}

	private DrawPattern DefaultDrawPattern => defDrawPattern ?? (defDrawPattern = new DrawPattern(BackColor, BackColor, ForeColor));

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
	protected override void OnPaint(PaintEventArgs e)
	{
		var dp = GetPaintPattern(ButtonState);
		e.Graphics.DrawImageAndText(Rectangle.Round(contentRect), Text, Font, Image, TextAlign, ImageAlign, TextImageRelation, dp.Text, false, 0, Enabled, this.BuildTextFormatFlags());
		DrawFocus(e.Graphics);
		base.OnPaint(e);
	}

	/// <summary>Paints the background of the control.</summary>
	/// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains information about the control to paint.</param>
	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
		//Simulate Transparency
		var g = pevent.Graphics.BeginContainer();
		var translateRect = Bounds;
		pevent.Graphics.TranslateTransform(-Left, -Top);
		var pe = new PaintEventArgs(pevent.Graphics, translateRect);
		InvokePaintBackground(Parent, pe);
		InvokePaint(Parent, pe);
		pevent.Graphics.ResetTransform();
		pevent.Graphics.EndContainer(g);

		pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

		var dp = GetPaintPattern(ButtonState);
		var path = new GraphicsPath();
		path.AddRoundedRectangle(Squeeze(pevent.ClipRectangle), new Size(CornerRadius, CornerRadius), RoundCorners);

		//Draw the Button Background
		pevent.Graphics.FillPath(dp.Fill, path);
		//...and border
		pevent.Graphics.DrawPath(dp.Line, path);

		// Get the Rectangle to be used for Content
		var xy = Math.Max(Convert.ToSingle(CornerRadius - (CornerRadius / Math.Sqrt(2))), pad);
		contentRect = RectangleF.Inflate(pevent.ClipRectangle, -xy, -xy);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.TextChanged"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate();
	}

	private static Rectangle Squeeze(Rectangle r, int val = 1)
	{
		var ret = r;
		ret.Height -= val;
		ret.Width -= val;
		return ret;
	}

	private void DrawFocus(Graphics g)
	{
		if (Focused && ShowFocusCues && TabStop)
		{
			var r = Rectangle.Inflate(Rectangle.Round(contentRect), 1, 1);
			ControlPaint.DrawFocusRectangle(g, r, ForeColor, BackColor);
		}
	}

	private DrawPattern GetPaintPattern(PushButtonState state)
	{
		DrawPattern dp;
		return !PaintPattern.TryGetValue(ButtonState, out dp) ? DefaultDrawPattern : dp;
	}

	/// <summary>A pattern to use for drawing the button.</summary>
	public class DrawPattern
	{
		private Point pt = Point.Empty;

		/// <summary>Initializes a new instance of the <see cref="DrawPattern"/> class.</summary>
		/// <param name="fill">The fill.</param>
		/// <param name="line">The line.</param>
		/// <param name="text">The text.</param>
		/// <param name="imageIndex">Index of the image.</param>
		public DrawPattern(Color fill, Color line, Color text, int imageIndex = -1) : this(line, text, imageIndex)
		{
			Fill = fill.IsSystemColor ? SystemBrushes.FromSystemColor(fill) : new SolidBrush(fill);
		}

		/// <summary>Initializes a new instance of the <see cref="DrawPattern"/> class.</summary>
		/// <param name="fill1">The fill1.</param>
		/// <param name="fill2">The fill2.</param>
		/// <param name="pt">The pt.</param>
		/// <param name="line">The line.</param>
		/// <param name="text">The text.</param>
		/// <param name="imageIndex">Index of the image.</param>
		public DrawPattern(Color fill1, Color fill2, Point pt, Color line, Color text, int imageIndex = -1) : this(line, text, imageIndex)
		{
			SetGradientFill(fill1, fill2, pt);
		}

		private DrawPattern(Color line, Color text, int imageIndex)
		{
			Line = line.IsSystemColor ? SystemPens.FromSystemColor(line) : new Pen(line, 1);
			Text = text;
			ImageIndex = imageIndex;
		}

		/// <summary>Gets the brush used to fill the pattern.</summary>
		/// <value>The fill brush.</value>
		public Brush Fill { get; private set; }

		/// <summary>Gets or sets the index of the image.</summary>
		/// <value>The index of the image.</value>
		public int ImageIndex { get; protected set; }

		/// <summary>Gets the pen used to draw lines.</summary>
		/// <value>The line pen.</value>
		public Pen Line { get; }

		/// <summary>Gets or sets the linear gradient point.</summary>
		/// <value>The linear gradient point.</value>
		public Point LinGradPoint
		{
			get => pt; set
			{
				if (pt != value)
				{
					pt = value;
					var clrs = (Fill as LinearGradientBrush)?.LinearColors;
					if (clrs != null && clrs.Length == 2)
						SetGradientFill(clrs[0], clrs[1], pt);
				}
			}
		}

		/// <summary>Gets the text.</summary>
		/// <value>The text.</value>
		public Color Text { get; }

		/// <summary>Gets the text brush.</summary>
		/// <value>The text brush.</value>
		public Brush TextBrush => Text.IsSystemColor ? SystemBrushes.FromSystemColor(Text) : new SolidBrush(Text);

		private void SetGradientFill(Color fill1, Color fill2, Point point)
		{
			Fill = new LinearGradientBrush(Point.Empty, point, fill1, fill2)
			{
				Blend = new Blend
				{
					Positions = new[] { 0, 0.45F, 0.55F, 1 },
					Factors = new float[] { 0, 0, 1, 1 }
				}
			};
		}
	}
}

internal class RoundCornersEditor : UITypeEditor
{
	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (!(value is Corners) || provider == null)
			return value;

		var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
		if (edSvc == null || context == null) return value;

		var cornerFlags = Corners.None;
		using (var lb = new CheckedListBox { BorderStyle = BorderStyle.None, CheckOnClick = true })
		{
			lb.Items.Add("TopLeft", (((CustomButton)context.Instance).RoundCorners & Corners.TopLeft) == Corners.TopLeft);
			lb.Items.Add("TopRight", (((CustomButton)context.Instance).RoundCorners & Corners.TopRight) == Corners.TopRight);
			lb.Items.Add("BottomLeft", (((CustomButton)context.Instance).RoundCorners & Corners.BottomLeft) == Corners.BottomLeft);
			lb.Items.Add("BottomRight", (((CustomButton)context.Instance).RoundCorners & Corners.BottomRight) == Corners.BottomRight);

			edSvc.DropDownControl(lb);
			foreach (var o in lb.CheckedItems)
				cornerFlags |= (Corners)Enum.Parse(typeof(Corners), o.ToString());
		}
		edSvc.CloseDropDown();
		return cornerFlags;
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.DropDown;
}