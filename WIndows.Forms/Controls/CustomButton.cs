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

namespace Vanara.Windows.Forms
{
	public class CustomButton : CustomDrawBase
	{
		private const int pad = 3;
		private RectangleF contentRect;
		private int cornerRadius = 4;
		private DrawPattern defDrawPattern;
		private Corners roundCorners = Corners.All;

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

		public CustomButton()
		{
			SetStyle(ControlStyles.Opaque, false);
			SetStyle(ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
		}

		[Category("Appearance"), DefaultValue(4), Description("Defines the radius of the controls RoundedCorners.")]
		public int CornerRadius
		{
			get => cornerRadius; set => SetField(ref cornerRadius, value, nameof(CornerRadius));
		}

		public Dictionary<PushButtonState, DrawPattern> PaintPattern { get; } = new Dictionary<PushButtonState, DrawPattern>();

		[Category("Appearance"), DefaultValue(typeof(Corners), "All")]
		[Description("Gets/sets the corners of the control to round.")]
		[Editor(typeof(RoundCornersEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Corners RoundCorners
		{
			get => roundCorners; set => SetField(ref roundCorners, value, nameof(RoundCorners));
		}

		private DrawPattern DefaultDrawPattern => defDrawPattern ?? (defDrawPattern = new DrawPattern(BackColor, BackColor, ForeColor));

		protected override void OnPaint(PaintEventArgs e)
		{
			var dp = GetPaintPattern(ButtonState);
			e.Graphics.DrawImageAndText(Rectangle.Round(contentRect), Text, Font, Image, TextAlign, ImageAlign, TextImageRelation, dp.Text, false, 0, Enabled, this.BuildTextFormatFlags());
			DrawFocus(e.Graphics);
			base.OnPaint(e);
		}

		private DrawPattern GetPaintPattern(PushButtonState state)
		{
			DrawPattern dp;
			return !PaintPattern.TryGetValue(ButtonState, out dp) ? DefaultDrawPattern : dp;
		}

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
			var xy = Math.Max(Convert.ToSingle(CornerRadius - (CornerRadius/Math.Sqrt(2))), pad);
			contentRect = RectangleF.Inflate(pevent.ClipRectangle, -xy, -xy);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			Invalidate();
		}

		private void DrawFocus(Graphics g)
		{
			if (Focused && ShowFocusCues && TabStop)
			{
				var r = Rectangle.Inflate(Rectangle.Round(contentRect), 1, 1);
				ControlPaint.DrawFocusRectangle(g, r, ForeColor, BackColor);
			}
		}

		private static Rectangle Squeeze(Rectangle r, int val = 1)
		{
			var ret = r;
			ret.Height -= val;
			ret.Width -= val;
			return ret;
		}

		public class DrawPattern
		{
			private Point pt = Point.Empty;

			public DrawPattern(Color fill, Color line, Color text, int imageIndex = -1) : this(line, text, imageIndex)
			{
				Fill = fill.IsSystemColor ? SystemBrushes.FromSystemColor(fill) : new SolidBrush(fill);
			}

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

			public Brush Fill { get; private set; }

			public int ImageIndex { get; protected set; }

			public Pen Line { get; }

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

			public Color Text { get; }

			public Brush TextBrush => Text.IsSystemColor ? SystemBrushes.FromSystemColor(Text) : new SolidBrush(Text);

			private void SetGradientFill(Color fill1, Color fill2, Point point)
			{
				Fill = new LinearGradientBrush(Point.Empty, point, fill1, fill2)
				{
					Blend = new Blend
					{
						Positions = new[] {0, 0.45F, 0.55F, 1},
						Factors = new float[] {0, 0, 1, 1}
					}
				};
			}
		}
	}

	[PermissionSetAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
	[PermissionSetAttribute(SecurityAction.InheritanceDemand, Unrestricted = true)]
	internal class RoundCornersEditor : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (!(value is Corners) || provider == null)
				return value;

			var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (edSvc == null || context == null) return value;

			var cornerFlags = Corners.None;
			using (var lb = new CheckedListBox {BorderStyle = BorderStyle.None, CheckOnClick = true})
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
}