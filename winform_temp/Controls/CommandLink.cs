using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Extensions;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms
{
	/// <summary>Represents a Windows Command Link control.</summary>
	/// <seealso cref="System.Windows.Forms.Button"/>
	[Designer(typeof(Design.CommandLinkDesigner)), DefaultProperty("Text")]
	public class CommandLink : Button
	{
		private static readonly bool IsPlatformSupported = Environment.OSVersion.Version.Major > 5;
		private PushButtonState buttonState = PushButtonState.Normal;
		private string noteText;
		private bool showShield;

		/// <summary>Initializes a new instance of the <see cref="CommandLink"/> class.</summary>
		public CommandLink() => FlatStyle = IsPlatformSupported ? FlatStyle.System : FlatStyle.Standard;

		/// <summary>
		/// Gets or sets the drawing style for custom drawing. By default, a style the resembles how Vista renders Command Links is provided.
		/// </summary>
		/// <value>The drawing style class.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IDrawingStyle<CommandLink, PushButtonState> DrawingStyle { get; set; } = new VistaCustomDrawingStyle();

		/// <summary>Gets or sets the image that is displayed on a button control.</summary>
		[DefaultValue(null), Category("Appearance"), Localizable(true)]
		[Description("The image that is displayed on a button control.")]
		public new Bitmap Image
		{
			get => base.Image is null ? null : base.Image as Bitmap ?? new Bitmap(base.Image);
			set
			{
				base.Image = value;
				if (IsPlatformSupported)
					this.SendMessage((uint)ButtonMessage.BM_SETIMAGE, (IntPtr)1, (base.Image as Bitmap)?.GetHicon() ?? IntPtr.Zero);
			}
		}

		/// <summary>Gets or sets the optional supplemental note to show below the main text.</summary>
		/// <value>The text to display for the note. If this value is <c>null</c>, no note will be displayed.</value>
		[Bindable(true)]
		[DefaultValue(null), Category("Appearance"), Localizable(true)]
		[Description("The text to display for the note.")]
		public string NoteText
		{
			get => noteText;
			set
			{
				if (value == string.Empty) value = null;
				if (string.Equals(noteText, value)) return;
				noteText = value;
				SetNote();
				Invalidate();
			}
		}

		/// <summary>Gets or sets a value indicating if elevation is required by showing the shield icon.</summary>
		/// <value><c>true</c> to indicate that elevation is required; otherwise, <c>false</c>.</value>
		[DefaultValue(false), Category("Behavior")]
		[Description("Indicates if elevation is required by showing the shield icon.")]
		public bool ShowShield
		{
			get => showShield;
			set
			{
				if (showShield == value) return;
				showShield = value;
				if (IsPlatformSupported)
					this.SendMessage((uint)ButtonMessage.BCM_SETSHIELD, (IntPtr)0, (IntPtr)(value ? 1 : 0));
				Invalidate();
			}
		}

		/// <summary>Gets a <see cref="T:System.Windows.Forms.CreateParams"/> on the base class when creating a window.</summary>
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				if (IsPlatformSupported)
					cp.Style |= (int)(Default ? ButtonStyle.BS_DEFCOMMANDLINK : ButtonStyle.BS_COMMANDLINK);
				return cp;
			}
		}

		/// <summary>Gets the default size of the control.</summary>
		protected override Size DefaultSize => new Size(200, AutoSize ? PreferredSize.Height : 58);

		private bool Default => ReferenceEquals(FindForm()?.AcceptButton, this);

		/// <summary>Retrieves the size of a rectangular area into which a control can be fitted.</summary>
		/// <param name="proposedSize">The custom-sized area for a control.</param>
		/// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.</returns>
		public override Size GetPreferredSize(Size proposedSize) => IsPlatformSupported ? proposedSize : DrawingStyle.Measure(this, buttonState);

		/// <summary>Raises the <see cref="E:Control.EnabledChanged"/> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			if (IsPlatformSupported) return;
			if (!Enabled)
				buttonState = PushButtonState.Disabled;
			Invalidate();
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e); SetNote();
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			buttonState = Enabled ? PushButtonState.Pressed : PushButtonState.Disabled;
			if (!IsPlatformSupported) Invalidate();
			base.OnMouseDown(e);
		}

		/// <summary>Raises the <see cref="E:Control.MouseEnter"/> event.</summary>
		/// <param name="e">Provides information for the event.</param>
		protected override void OnMouseEnter(EventArgs e)
		{
			buttonState = Enabled ? PushButtonState.Hot : PushButtonState.Disabled;
			if (!IsPlatformSupported) Invalidate();
			base.OnMouseEnter(e);
		}

		/// <summary>Raises the <see cref="E:Control.MouseLeave"/> event.</summary>
		/// <param name="e">Provides missing information for the event.</param>
		protected override void OnMouseLeave(EventArgs e)
		{
			buttonState = Enabled ? (Focused ? PushButtonState.Default : PushButtonState.Normal) : PushButtonState.Disabled;
			if (!IsPlatformSupported) Invalidate();
			base.OnMouseLeave(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			buttonState = Enabled ? PushButtonState.Hot : PushButtonState.Disabled;
			if (!IsPlatformSupported) Invalidate();
			base.OnMouseUp(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (IsPlatformSupported)
			{
				base.OnPaint(e);
			}
			else
			{
				if (FlatStyle != FlatStyle.Standard)
					FlatStyle = FlatStyle.Standard;

				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

				DrawingStyle.Draw(this, buttonState, e);
			}
		}

		private void SetNote()
		{
			if (IsPlatformSupported && IsHandleCreated)
				SendMessage(Handle, (uint)ButtonMessage.BCM_SETNOTE, IntPtr.Zero, noteText);
		}
	}

	internal class VistaCustomDrawingStyle : IDrawingStyle<CommandLink, PushButtonState>
	{
		private const int btnTxtPad = 1;
		private const string fontName = @"Segoe UI";
		private const int imgSpacer = 5;
		private const int line2Pad = 1;
		private const int line2Spacing = 2;
		private const int lrMargin = 8;
		private const int rndRectRadius = 6;
		private const int tbMargin = 10;

		private static readonly Font largeFont = new Font(fontName, 12, FontStyle.Regular, GraphicsUnit.Point, 0);

		private static readonly Dictionary<PushButtonState, DrawPattern> paintPattern = new Dictionary<PushButtonState, DrawPattern>
		{
			[PushButtonState.Normal] = new DrawPattern(Color.Transparent, Color.Transparent, Color.FromArgb(21, 28, 85), Properties.Resources.ArrowNormal),
			[PushButtonState.Hot] = new DrawPattern(Color.White, Color.FromArgb(237, 237, 237), 40, Color.FromArgb(189, 189, 189), Color.FromArgb(7, 74, 229), Properties.Resources.ArrowHovered),
			[PushButtonState.Pressed] = new DrawPattern(Color.FromArgb(233, 234, 234), Color.FromArgb(167, 167, 167), Color.FromArgb(6, 32, 115), Properties.Resources.ArrowNormal),
			[PushButtonState.Disabled] = new DrawPattern(Color.Transparent, Color.Transparent, Color.FromArgb(126, 133, 156), Properties.Resources.ArrowDisabled),
			[PushButtonState.Default] = new DrawPattern(Color.Transparent, Color.FromArgb(192, 233, 243), Color.FromArgb(21, 28, 85), Properties.Resources.ArrowNormal)
		};

		private static readonly Font smallFont = new Font(fontName, 9, FontStyle.Regular, GraphicsUnit.Point, 0);

		public void Draw(CommandLink ctrl, PushButtonState state, PaintEventArgs e)
		{
			var m = new Measurements(ctrl, state, e.Graphics);

			e.Graphics.Clear(ctrl.Parent.BackColor);
			var gp = new GraphicsPath();
			gp.AddRoundedRectangle(m.client, new Size(rndRectRadius, rndRectRadius));
			e.Graphics.FillPath(m.dp.Fill, gp);
			e.Graphics.DrawPath(m.dp.Line, gp);
			e.Graphics.DrawImage(m.img, m.imgRect);
			TextRenderer.DrawText(e.Graphics, ctrl.Text, largeFont, m.txtRect, m.dp.Text, m.tff);
			if (m.noteRect.Size != SizeF.Empty)
				TextRenderer.DrawText(e.Graphics, ctrl.NoteText, smallFont, m.noteRect, m.dp.Text, m.tff);
		}

		public Size Measure(CommandLink ctrl, PushButtonState state, Graphics g = null)
		{
			if (g == null) g = ctrl.CreateGraphics();
			var m = new Measurements(ctrl, state, g);
			return new Size(m.client.Width, m.minHeight);
		}

		private class DrawPattern
		{
			private int h;

			public DrawPattern(Color fill, Color line, Color text, Image arrow) : this(line, text, arrow) => Fill = fill.IsSystemColor ? SystemBrushes.FromSystemColor(fill) : new SolidBrush(fill);

			public DrawPattern(Color fill1, Color fill2, int height, Color line, Color text, Image arrow)
				: this(line, text, arrow)
			{
				h = height;
				var r = new Rectangle(0, 0, h, h);
				Fill = new LinearGradientBrush(r, fill1, fill2, LinearGradientMode.Vertical);
			}

			private DrawPattern(Color line, Color text, Image arrow)
			{
				Line = line.IsSystemColor ? SystemPens.FromSystemColor(line) : new Pen(line, 1);
				Text = text;
				Arrow = arrow;
			}

			public Image Arrow { get; }
			public Brush Fill { get; private set; }
			public Pen Line { get; }

			public int LinGradHeight
			{
				set
				{
					if (h == value) return;
					h = value;
					var r = new Rectangle(0, 0, h, h);
					var clrs = (Fill as LinearGradientBrush)?.LinearColors;
					if (clrs != null && clrs.Length == 2)
						Fill = new LinearGradientBrush(r, clrs[0], clrs[1], LinearGradientMode.Vertical);
				}
			}

			public Color Text { get; }
		}

		private class Measurements
		{
			public readonly Rectangle client, imgRect;
			public readonly DrawPattern dp;
			public readonly Image img;
			public readonly int minHeight;
			public readonly TextFormatFlags tff;
			public readonly Rectangle txtRect, noteRect;

			public Measurements(CommandLink ctrl, PushButtonState state, IDeviceContext g)
			{
				client = new Rectangle(ctrl.ClientRectangle.X, ctrl.ClientRectangle.Y, ctrl.ClientRectangle.Width - 1, ctrl.ClientRectangle.Height - 1);
				if (state == PushButtonState.Hot)
					paintPattern[PushButtonState.Hot].LinGradHeight = ctrl.ClientRectangle.Height;
				dp = paintPattern[state];
				img = ctrl.ShowShield ? (ctrl.Enabled ? Properties.Resources.SmallSecurity : Properties.Resources.SmallSecurityDisabled) : (ctrl.Image ?? dp.Arrow);
				var maxTextSz = new Size(ctrl.Width - (lrMargin * 2) - img.Width - imgSpacer, int.MaxValue);
				tff = ctrl.BuildTextFormatFlags(false);
				var szL = GetTextSize(g, ctrl.Text, maxTextSz, largeFont);
				maxTextSz.Width -= line2Pad;
				var szS = GetTextSize(g, ctrl.NoteText, maxTextSz, smallFont);
				imgRect = new Rectangle(new Point(lrMargin, tbMargin + szL.Height / 2 - img.Height / 2), img.Size);
				txtRect = new Rectangle(new Point(lrMargin + img.Width + btnTxtPad, tbMargin), szL);
				noteRect = new Rectangle(new Point(lrMargin + line2Pad + img.Width + btnTxtPad, tbMargin + line2Spacing + szL.Height), szS);
				var r = RectangleF.Union(imgRect, txtRect);
				if (noteRect.Size != SizeF.Empty)
					r = RectangleF.Union(r, noteRect);
				minHeight = Convert.ToInt32(Math.Ceiling(r.Height)) + (tbMargin * 2);
			}

			private Size GetTextSize(IDeviceContext g, string s, Size sz, Font f) => string.IsNullOrEmpty(s) ? Size.Empty : TextRenderer.MeasureText(g, s, f, sz, tff);
		}
	}
}