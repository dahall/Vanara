using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Drawing;
using Vanara.Extensions;

namespace Vanara.Windows.Forms
{
	public delegate int TranslateButtonStateDelegate(ControlState btnState);

	/// <summary>
	/// A button that displays an image and no text.
	/// </summary>
	[ToolboxItem(true), ToolboxBitmap(typeof(ThemedImageDraw), "ThemedImageButton.bmp")]
	public class ThemedImageDraw : CustomDrawBase
	{
		private const string defaultText = "";
		private const string defaultToolTip = "";

		private readonly ToolTip toolTip;
		private VisualStyleRenderer rnd;
		private int[,] rndTransitions;

		/// <summary>
		/// Initializes a new instance of the <see cref="ThemedImageDraw"/> class.
		/// </summary>
		public ThemedImageDraw()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.ResizeRedraw |
				ControlStyles.UserPaint, true);

			toolTip = new ToolTip();
			toolTip.SetToolTip(this, defaultToolTip);
			StyleClass = "BUTTON";
			StylePart = 1;
			base.Text = defaultText;
		}

		public event TranslateButtonStateDelegate TranslateButtonState;

		/// <summary>
		/// Gets or sets the background color of the control.
		/// </summary>
		/// <returns>A <see cref="T:System.Drawing.Color" /> value representing the background color.</returns>
		public override Color BackColor
		{
			get => OnGlass ? Color.Transparent : base.BackColor; set => base.BackColor = value;
		}

		/// <summary>
		/// Gets or sets the image that is displayed on a button control.
		/// </summary>
		/// <returns>The <see cref="T:System.Drawing.Image" /> displayed on the button control. The default value is null.</returns>
		[DefaultValue(null)]
		public new Image Image
		{
			get => base.Image; set
			{
				if (value != null)
				{
					InitializeImageList(value.Size);
					ImageList.Images.Add(value);
				}
				else
					ImageList = null;
				base.Image = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control supports glass (can be enclosed in the glass margin).
		/// </summary>
		/// <value>
		///   <c>true</c> if supports glass; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool SupportGlass { get; set; }

		/// <summary>
		/// Gets or sets the style class.
		/// </summary>
		/// <value>The style class.</value>
		[DefaultValue("BUTTON"), Category("Appearance")]
		public string StyleClass { get; set; }

		/// <summary>
		/// Gets or sets the style part.
		/// </summary>
		/// <value>The style part.</value>
		[DefaultValue(1), Category("Appearance")]
		public int StylePart { get; set; }

		/// <summary>
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// <returns>
		/// The text associated with this control.
		///   </returns>
		[DefaultValue(defaultText), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text
		{
			get => base.Text; set => base.Text = value;
		}

		/// <summary>
		/// Gets or sets the tool tip text.
		/// </summary>
		/// <value>The tool tip text.</value>
		[DefaultValue(defaultToolTip), Category("Appearance")]
		public string ToolTipText
		{
			get => toolTip.GetToolTip(this); set => toolTip.SetToolTip(this, value);
		}

		/// <summary>
		/// Gets a value indicating whether on glass.
		/// </summary>
		/// <value><c>true</c> if on glass; otherwise, <c>false</c>.</value>
		private bool OnGlass => !this.IsDesignMode() && DesktopWindowManager.CompositionEnabled && SupportGlass;

		/// <summary>
		/// Retrieves the default size for the control.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The default <see cref="T:System.Drawing.Size"/> of the control.
		/// </returns>
		protected override Size DefaultSize => new Size(30, 30);

		/// <summary>
		/// Retrieves the size of a rectangular area into which a control can be fitted.
		/// </summary>
		/// <param name="proposedSize">The custom-sized area for a control.</param>
		/// <returns>
		/// An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.
		/// </returns>
		public override Size GetPreferredSize(Size proposedSize) => DefaultSize;

		/// <summary>
		/// Sets the image list images using an image strip.
		/// </summary>
		/// <param name="imageStrip">The image strip.</param>
		/// <param name="orientation">The orientation of the strip.</param>
		public void SetImageListImageStrip(Image imageStrip, Orientation orientation)
		{
			if (imageStrip == null)
				ImageList = null;
			else
			{
				var imageSize = orientation == Orientation.Vertical ? new Size(imageStrip.Width, imageStrip.Height / 4) : new Size(imageStrip.Width / 4, imageStrip.Height);
				InitializeImageList(imageSize);
				if (orientation == Orientation.Horizontal)
					ImageList.Images.AddStrip(imageStrip);
				else
					using (var bmp = new Bitmap(imageStrip))
						for (var r = new Rectangle(Point.Empty, imageSize); r.Y < imageStrip.Height; r.Y += imageSize.Height)
							ImageList.Images.Add(bmp.Clone(r, bmp.PixelFormat));
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			var g = e.Graphics;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			BufferedPaint.PaintAnimation(g, this, e.ClipRectangle, PaintAction, TranslateState(LastState), TranslateState(State), GetDuration);
		}

		private void PaintAction(Graphics graphics, Rectangle bounds, int currentstate, int data)
		{
			PaintButton(graphics, bounds, currentstate);
		}

		private int GetDuration(int oldstate, int newstate) => rndTransitions?[oldstate - 1, newstate - 1] ?? 0;

		private int TranslateState(ControlState st) => TranslateButtonState?.Invoke(st) ?? (int)st;

		/// <summary>
		/// Primary function for painting the button. This method should be overridden instead of OnPaint.
		/// </summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="bounds">The bounds.</param>
		/// <param name="currentstate">The translated current state of the control.</param>
		protected virtual void PaintButton(Graphics graphics, Rectangle bounds, int currentstate)
		{
			System.Diagnostics.Debug.WriteLine($"PaintButton: desMode:{this.IsDesignMode()};vsEnabled:{Application.RenderWithVisualStyles};vsOnOS:{VisualStyleInformation.IsSupportedByOS};btnState:{currentstate};enabled:{Enabled};imgCt:{ImageList?.Images.Count ?? 0}");

			if (InitializeRenderer())
			{
				if (OnGlass)
				{
					rnd.DrawGlassBackground(graphics, bounds, bounds);
				}
				else
				{
					rnd.DrawParentBackground(graphics, bounds, this);
					rnd.DrawBackground(graphics, bounds);
				}
			}
			else
			{
				if (ImageList != null && ImageList.Images.Count > 0)
				{
					var idx = (int)currentstate - 1;
					if (ImageList.Images.Count == 1)
						idx = 0;
					else if (ImageList.Images.Count == 2)
						idx = currentstate == TranslateState(ControlState.Disabled) ? 1 : 0;
					// TODO: Determine if this is needed
					//else if (ImageList.Images.Count == 3)
					//	idx = currentstate == TranslateState(ControlState.Normal) ? 0 : idx - 1;
					var forceDisabled = !Enabled && ImageList.Images.Count == 1;
					if (OnGlass)
					{
                        VisualStylesRendererExtension.DrawGlassImage(null, graphics, bounds, ImageList.Images[idx], forceDisabled);
					}
					else
					{
						if (!Application.RenderWithVisualStyles && VisualStyleInformation.IsSupportedByOS)
						{
							var g = graphics.BeginContainer();
							var translateRect = bounds;
							graphics.TranslateTransform(-bounds.Left, -bounds.Top);
							var pe = new PaintEventArgs(graphics, translateRect);
							InvokePaintBackground(Parent, pe);
							InvokePaint(Parent, pe);
							graphics.ResetTransform();
							graphics.EndContainer(g);
						}
						else
							graphics.Clear(Parent.BackColor);
						if (forceDisabled)
							ControlPaint.DrawImageDisabled(graphics, ImageList.Images[idx], 0, 0, Color.Transparent);
						else
						{
							//base.ImageList.Draw(graphics, bounds.X, bounds.Y, bounds.Width, bounds.Height, idx);
							//VisualStyleRendererExtender.DrawGlassImage(null, graphics, bounds, base.ImageList.Images[idx], forceDisabled); // Not 7
							graphics.DrawImage(ImageList.Images[idx], bounds, bounds, GraphicsUnit.Pixel); // Works on XP, not 7, with Parent.BackColor
						}
					}
				}
				/*else if (this.ImageList != null && this.ImageList.Images.Count > 1)
				{
					int idx = (int)currentstate - 1;
					if (this.ImageList.Images.Count == 2)
						idx = currentstate == PushButtonState.Disabled ? 1 : 0;
					if (this.ImageList.Images.Count == 3)
						idx = currentstate == PushButtonState.Normal ? 0 : idx - 1;
					if (rnd != null && !this.IsDesignMode() && DesktopWindowManager.IsCompositionEnabled())
						rnd.DrawGlassIcon(graphics, bounds, this.ImageList, idx);
					else
						this.ImageList.Draw(graphics, bounds.X, bounds.Y, bounds.Width, bounds.Height, idx);
				}*/
				// No image so draw standard button
				else
				{
					ButtonRenderer.DrawParentBackground(graphics, bounds, this);
					if (Enum.IsDefined(typeof(PushButtonState), currentstate))
						ButtonRenderer.DrawButton(graphics, bounds, (PushButtonState)currentstate);
					else
						ButtonRenderer.DrawButton(graphics, bounds, PushButtonState.Normal);
				}
			}

			if (Focused)
				ControlPaint.DrawFocusRectangle(graphics, bounds);
		}

		private void InitializeImageList(Size imageSize)
		{
			ImageList = new ImageList() { ImageSize = imageSize, ColorDepth = ColorDepth.Depth32Bit, TransparentColor = Color.Transparent };
		}

		private bool InitializeRenderer()
		{
			if (Application.RenderWithVisualStyles)
			{
				try
				{
					var bs = TranslateButtonState?.Invoke(State) ?? (int)State;
					if (rnd == null)
					{
						rnd = new VisualStyleRenderer(StyleClass, StylePart, bs);
						rndTransitions = rnd.GetTransitionMatrix();
					}
					else if (StyleClass != rnd.Class || StylePart != rnd.Part || bs != rnd.State)
					{
						rnd.SetParameters(StyleClass, StylePart, bs);
						rndTransitions = rnd.GetTransitionMatrix();
					}
					return true;
				}
				catch { }
			}
			rnd = null;
			rndTransitions = null;
			return false;
		}
	}
}