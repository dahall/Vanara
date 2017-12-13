using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Extensions;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// A Label containing some text that will be drawn with glowing border on top of the Glass Sheet effect.
	/// </summary>
	//[Designer("AeroWizard.Design.ThemedLabelDesigner")]
	[DefaultProperty("Text")]
	[ToolboxItem(true), ToolboxBitmap(typeof(ThemedLabel), "ThemedLabel.bmp")]
	public class ThemedLabel : Label
	{
		private VisualStyleRenderer rnd;
		private string styleClass;
		private int stylePart;
		private int styleState;
		private bool supportGlass;
		private TextImageRelation textImageRelation;

		/// <summary>
		/// Initializes a new instance of the <see cref="ThemedLabel"/> class.
		/// </summary>
		public ThemedLabel()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			base.BackColor = Color.Transparent;
			SetTheme("TextStyle", 4, 0);
		}

		/// <summary>
		/// Gets or sets the background color for the control.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// A <see cref="T:System.Drawing.Color"/> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
		/// </returns>
		/// <PermissionSet>
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// </PermissionSet>
		[DefaultValue(typeof(Color), "Transparent")]
		public override Color BackColor
		{
			get => base.BackColor; set => base.BackColor = value;
		}

		[DefaultValue(false), Category("Appearance")]
		public bool GlowingText { get; set; }

		/// <summary>
		/// Gets or sets the image that is displayed on a <see cref="T:System.Windows.Forms.Label"/>.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// An <see cref="T:System.Drawing.Image"/> displayed on the <see cref="T:System.Windows.Forms.Label"/>. The default is null.
		/// </returns>
		/// <PermissionSet>
		/// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
		/// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
		/// </PermissionSet>
		[DefaultValue((Image)null)]
		public new Image Image
		{
			get => base.Image; set
			{
				base.Image = value;
				ImageIndex = -1;
				ImageList = null;
			}
		}

		/// <summary>Sets the theme using a defined <see cref="VisualStyleElement"/>.</summary>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public VisualStyleRenderer Style
		{
			get => rnd; set
			{
				rnd = value;
				styleClass = rnd.Class;
				stylePart = rnd.Part;
				styleState = rnd.State;
				Invalidate();
			}
		}

		/// <summary>Gets or sets the style class.</summary>
		/// <value>The style class.</value>
		[DefaultValue("TextStyle"), Category("Appearance")]
		public string StyleClass
		{
			get => styleClass; set { styleClass = value; ResetTheme(); Invalidate(); }
		}

		/// <summary>Gets or sets the style part.</summary>
		/// <value>The style part.</value>
		[DefaultValue(4), Category("Appearance")]
		public int StylePart
		{
			get => stylePart; set { stylePart = value; ResetTheme(); Invalidate(); }
		}

		/// <summary>Gets or sets the style part.</summary>
		/// <value>The style part.</value>
		[DefaultValue(0), Category("Appearance")]
		public int StyleState
		{
			get => styleState; set { styleState = value; ResetTheme(); Invalidate(); }
		}

		/// <summary>Gets or sets a value indicating whether this table supports glass (can be enclosed in the glass margin).</summary>
		/// <value><c>true</c> if supports glass; otherwise, <c>false</c>.</value>
		[DefaultValue(false), Category("Appearance")]
		public bool SupportGlass
		{
			get => supportGlass; set { supportGlass = value; Invalidate(); }
		}

		public TextImageRelation TextImageRelation
		{
			get => textImageRelation; set { textImageRelation = value; Invalidate(); }
		}

		/// <summary>
		/// Retrieves the size of a rectangular area into which a control can be fitted.
		/// </summary>
		/// <param name="proposedSize">The custom-sized area for a control.</param>
		/// <returns>
		/// An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.
		/// </returns>
		public override Size GetPreferredSize(Size proposedSize)
		{
			if (Text.Length <= 0 || rnd == null) return base.GetPreferredSize(proposedSize);
			using (var g = CreateGraphics())
			{
				var tff = this.BuildTextFormatFlags();
				Rectangle tRect, iRect;
				GraphicsExtension.CalcImageAndTextBounds(new Rectangle(Point.Empty, proposedSize), Text, Font, Image, TextAlign, ImageAlign, TextImageRelation, !AutoSize, 0, ref tff, out tRect, out iRect);
				return System.Drawing.Size.Add(Rectangle.Union(tRect, iRect).Size, Padding.Size);
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

		internal static Rectangle DeflateRect(Rectangle rect, Padding padding)
		{
			rect.X += padding.Left;
			rect.Y += padding.Top;
			rect.Width -= padding.Horizontal;
			rect.Height -= padding.Vertical;
			return rect;
		}

		/// <summary>
		/// Raises the Paint event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			try
			{
				// Setup variables
				var useVs = rnd != null && Application.RenderWithVisualStyles;
				var r = DeflateRect(ClientRectangle, Padding);
				var tff = this.BuildTextFormatFlags();
				Rectangle tRect, iRect;
				GraphicsExtension.CalcImageAndTextBounds(r, Text, Font, Image, TextAlign, ImageAlign, TextImageRelation, !AutoSize, 0,
					ref tff, out tRect, out iRect);

				// Draw background
				if (SupportGlass && !this.IsDesignMode() && DesktopWindowManager.IsCompositionEnabled())
					e.Graphics.Clear(Color.Black);
				else
				{
					if (useVs)
						rnd.DrawBackground(e.Graphics, ClientRectangle, e.ClipRectangle);
					else
						e.Graphics.Clear(BackColor);
				}

				// Draw image
				if (Image != null)
				{
					if (useVs)
						rnd.DrawImage(e.Graphics, iRect, Image);
					else
						e.Graphics.DrawImage(Image, iRect);
				}

				// Draw text
				if (Text.Length > 0)
				{
					var rtl = this.GetRightToLeftProperty();
					if (useVs)
					{
						if (rtl == RightToLeft.Yes) tff |= TextFormatFlags.RightToLeft;
						if (GlowingText)
							rnd.DrawGlowingText(e.Graphics, tRect, Text, Font, ForeColor, tff);
						else
							rnd.DrawText(e.Graphics, tRect, Text, !Enabled, tff);
					}
					else
					{
						var br = DesktopWindowManager.IsCompositionEnabled() ? SystemBrushes.ActiveCaptionText : SystemBrushes.ControlText;
						var sf = new StringFormat(StringFormat.GenericDefault);
						if (rtl == RightToLeft.Yes) sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
						e.Graphics.DrawString(Text, Font, br, ClientRectangle, sf);
					}
				}
			}
			catch { }
		}

		/// <summary>
		/// Processes Windows messages.
		/// </summary>
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
			if (VisualStyleRenderer.IsSupported)
			{
				try
				{
					if (rnd == null)
						rnd = new VisualStyleRenderer(styleClass, stylePart, styleState);
					else
						rnd.SetParameters(styleClass, stylePart, styleState);
				}
				catch
				{
					rnd = null;
				}
			}
			else
				rnd = null;
		}
	}
}