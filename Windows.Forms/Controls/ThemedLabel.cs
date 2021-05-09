using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using Microsoft.Win32;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Windows.Forms
{
	/// <summary>A Label containing some text that will be drawn with glowing border on top of the Glass Sheet effect.</summary>
	//[Designer("AeroWizard.Design.ThemedLabelDesigner")]
	[DefaultProperty("Text")]
	[ToolboxItem(true), ToolboxBitmap(typeof(ThemedLabel), "ThemedLabel.bmp")]
	public class ThemedLabel : Label
	{
		private const string defaultClass = "TextStyle";
		private const int defaultPart = 4;
		private const int defaultState = 0;

		private string styleClass;
		private int stylePart;
		private int styleState;
		private bool supportGlass;
		private TextImageRelation textImageRelation;
		private VisualTheme theme;

		/// <summary>Initializes a new instance of the <see cref="ThemedLabel"/> class.</summary>
		public ThemedLabel()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.BackColor = Color.Transparent;
			SetTheme(defaultClass, defaultPart, defaultState);
		}

		/// <summary>Gets or sets the background color for the control.</summary>
		/// <value></value>
		/// <returns>
		/// A <see cref="T:System.Drawing.Color"/> that represents the background color of the control. The default is the value of the <see
		/// cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
		/// </returns>
		[DefaultValue(typeof(Color), "Transparent")]
		public override Color BackColor
		{
			get => base.BackColor;
			set => base.BackColor = value;
		}

		/// <summary>Gets or sets a value indicating whether the text has a glow.</summary>
		/// <value><see langword="true"/> if text has glow; otherwise, <see langword="false"/>.</value>
		[DefaultValue(false), Category("Appearance")]
		public bool GlowingText { get; set; }

		/// <summary>Gets or sets the image that is displayed on a <see cref="T:System.Windows.Forms.Label"/>.</summary>
		/// <value></value>
		/// <returns>
		/// An <see cref="T:System.Drawing.Image"/> displayed on the <see cref="T:System.Windows.Forms.Label"/>. The default is null.
		/// </returns>
		[DefaultValue((Image)null)]
		public new Image Image
		{
			get => base.Image;
			set
			{
				base.Image = value;
				ImageIndex = -1;
				ImageList = null;
			}
		}

		/// <summary>Gets or sets the style class.</summary>
		/// <value>The style class.</value>
		[DefaultValue(defaultClass), Category("Appearance")]
		public string StyleClass
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

		/// <summary>Gets or sets the text image relation.</summary>
		/// <value>The text image relation.</value>
		[DefaultValue(0), Category("Appearance")]
		public TextImageRelation TextImageRelation
		{
			get => textImageRelation;
			set { textImageRelation = value; Invalidate(); }
		}

		private bool ThemingSupported => Application.RenderWithVisualStyles || DesktopWindowManager.CompositionEnabled;

		/// <summary>Retrieves the size of a rectangular area into which a control can be fitted.</summary>
		/// <param name="proposedSize">The custom-sized area for a control.</param>
		/// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.</returns>
		public override Size GetPreferredSize(Size proposedSize)
		{
			if (Text.Length <= 0 || theme == null) return base.GetPreferredSize(proposedSize);
			using (var g = CreateGraphics())
			{
				var tff = this.BuildTextFormatFlags();
				GraphicsExtension.CalcImageAndTextBounds(new Rectangle(Point.Empty, proposedSize), Text, Font, Image, TextAlign, ImageAlign, TextImageRelation, !AutoSize, 0, ref tff, out var tRect, out var iRect);
				return Size.Add(Rectangle.Union(tRect, iRect).Size, Padding.Size);
			}
		}

		/// <summary>Sets the theme using theme class information.</summary>
		/// <param name="className">Name of the theme class.</param>
		/// <param name="part">The theme part.</param>
		/// <param name="state">The theme state.</param>
		public void SetTheme(string className, int part, int state)
		{
			styleClass = className;
			stylePart = part;
			styleState = state;
			ResetTheme();
		}

		/// <summary>Sets the theme using <see cref="System.Windows.Forms.VisualStyles.VisualStyleElement"/> information.</summary>
		/// <param name="visualStyle">The visual style.</param>
		public void SetTheme(System.Windows.Forms.VisualStyles.VisualStyleElement visualStyle) => SetTheme(visualStyle?.ClassName, visualStyle?.Part ?? 0, visualStyle?.State ?? 0);

		internal static Rectangle DeflateRect(Rectangle rect, Padding padding)
		{
			rect.X += padding.Left;
			rect.Y += padding.Top;
			rect.Width -= padding.Horizontal;
			rect.Height -= padding.Vertical;
			return rect;
		}

		/// <inheritdoc/>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
			Invalidate(); // OnPaint() recalculates colors
        }

        /// <summary>Raises the Paint event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (!Visible) return;
			try
			{
				// Setup variables
				var r = DeflateRect(ClientRectangle, Padding);
				var tff = this.BuildTextFormatFlags();
				GraphicsExtension.CalcImageAndTextBounds(r, Text, Font, Image, TextAlign, ImageAlign, TextImageRelation, !AutoSize, 0,
					ref tff, out var tRect, out var iRect);

				// Draw background
				if (SupportGlass && !this.IsDesignMode() && ThemingSupported)
					e.Graphics.Clear(Color.Black);
				else
				{
					if (theme != null && ThemingSupported)
						theme.DrawBackground(e.Graphics, stylePart, styleState, ClientRectangle, e.ClipRectangle);
					else
						e.Graphics.Clear(BackColor);
				}

				// Draw image
				if (Image != null)
				{
					e.Graphics.DrawImage(Image, iRect);
				}

				// Draw text
				if (Text.Length > 0)
				{
					var rtl = this.GetRightToLeftProperty();
					if (theme != null && ThemingSupported)
					{
						if (rtl == RightToLeft.Yes) tff |= TextFormatFlags.RightToLeft;

						if (GlowingText && Environment.OSVersion.Version.Major == 10 && !SystemInformation.HighContrast && !DesignMode)
                        {
							Color textColor = SystemColors.ControlText;

							// SystemColors.ActiveCaption always returns an ugly shade of blue. SystemColors.ActiveCaptionText returns black.
							// We must therefore ask DWM for the title bar color. However, the user has the option to use white title bars,
							// which we must check for first. (I don't know any public API calls that return this value.)
							using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM"))
							{
								var prevalenceValue = key.GetValue("ColorPrevalence", null);
								if (prevalenceValue != null && Convert.ToBoolean(prevalenceValue))
                                {
									// While this API does not return the *exact* shade used in title bars, its value
									// is pretty close; certainly close enough to be useful for the below test.
									DwmApi.DwmGetColorizationColor(out uint colorValue, out _).ThrowIfFailed();
									Color color = Color.FromArgb((int)colorValue);

									if ((color.R * 0.299 + color.G * 0.587 + color.B * 0.114) > 186)
										textColor = SystemColors.ControlText;
									else
										textColor = Color.White;
								}
                                else
								{
									// If we get here, then "Show accent color on title bars" has been disabled in Settings.
									if (Form.ActiveForm.Equals(FindForm())) textColor = SystemColors.ControlText;
									else textColor = SystemColors.GrayText;
								}
							}

							DTTOPTS opts = new DTTOPTS(null)
							{
								AntiAliasedAlpha = true,
								crText = new COLORREF(textColor),
							};

							e.Graphics.DrawViaDIB(tRect, (hdc, rc) =>
								theme.DrawText(Graphics.FromHdc(hdc.DangerousGetHandle()), stylePart, styleState, r, Text, tff, opts));
						}
						else if (GlowingText)
							e.Graphics.DrawViaDIB(tRect, (hdc, rc) =>
								theme.DrawText(Graphics.FromHdc(hdc.DangerousGetHandle()), stylePart, styleState, r, Text, tff, new DTTOPTS(null) { GlowSize = 10, AntiAliasedAlpha = true }));
						else
							theme.DrawText(e.Graphics, stylePart, styleState, tRect, Text, tff, !Enabled);
					}
					else
					{
						var br = ThemingSupported ? SystemBrushes.ActiveCaptionText : SystemBrushes.ControlText;
						var sf = new StringFormat(StringFormat.GenericDefault);
						if (rtl == RightToLeft.Yes) sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
						e.Graphics.DrawString(Text, Font, br, ClientRectangle, sf);
					}
				}
			}
			catch { }
		}

		/// <summary>Processes Windows messages.</summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
		protected override void WndProc(ref Message m)
		{
			if (!DesignMode && SupportGlass && m.Msg == (int)WindowMessage.WM_NCHITTEST)
			{
				m.Result = (IntPtr)HitTestValues.HTTRANSPARENT;
				return;
			}
			base.WndProc(ref m);
		}

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
}