using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Extensions;

namespace Vanara.Windows.Forms
{
	/// <summary>A panel that supports a glass overlay and is drawn using a visual style.</summary>
	[ToolboxItem(true), ToolboxBitmap(typeof(ThemedPanel), "ThemedPanel.bmp")]
	public class ThemedPanel : Panel
	{
		private VisualStyleRenderer rnd;
		private string styleClass;
		private int stylePart;
		private int styleState;
		private bool supportGlass;

		/// <summary>Initializes a new instance of the <see cref="ThemedTableLayoutPanel"/> class.</summary>
		public ThemedPanel()
		{
			SetTheme("WINDOW", 29, 1);
		}

		/// <summary>Sets the theme using a defined <see cref="VisualStyleElement"/>.</summary>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public VisualStyleRenderer Style
		{
			get => rnd;
			set
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
		[DefaultValue("WINDOW"), Category("Appearance")]
		public string StyleClass
		{
			get => styleClass;
			set { styleClass = value; ResetTheme(); }
		}

		/// <summary>Gets or sets the style part.</summary>
		/// <value>The style part.</value>
		[DefaultValue(29), Category("Appearance")]
		public int StylePart
		{
			get => stylePart;
			set { stylePart = value; ResetTheme(); }
		}

		/// <summary>Gets or sets the style part.</summary>
		/// <value>The style part.</value>
		[DefaultValue(1), Category("Appearance")]
		public int StyleState
		{
			get => styleState;
			set { styleState = value; ResetTheme(); }
		}

		/// <summary>Gets or sets a value indicating whether this table supports glass (can be enclosed in the glass margin).</summary>
		/// <value><c>true</c> if supports glass; otherwise, <c>false</c>.</value>
		[DefaultValue(false), Category("Appearance")]
		public bool SupportGlass
		{
			get => supportGlass;
			set { supportGlass = value; Invalidate(); }
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

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (!this.IsDesignMode() && SupportGlass && DesktopWindowManager.CompositionEnabled)
				try { e.Graphics.Clear(Color.Black); } catch { }
			else
			{
				if (rnd == null || !Application.RenderWithVisualStyles)
				{
					try { e.Graphics.Clear(BackColor); } catch { }
					if (!string.IsNullOrEmpty(Text))
						TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, this.BuildTextFormatFlags(false));
				}
				else
				{
					if (rnd.IsBackgroundPartiallyTransparent())
						rnd.DrawParentBackground(e.Graphics, ClientRectangle, this);
					rnd.DrawBackground(e.Graphics, ClientRectangle, e.ClipRectangle);
					if (!string.IsNullOrEmpty(Text))
						rnd.DrawText(e.Graphics, ClientRectangle, Text, !Enabled, this.BuildTextFormatFlags(false));
				}
			}
			base.OnPaint(e);
		}

		/// <summary>
		/// Fires the event indicating that the panel has been resized. Inheriting controls should use this in favor of actually listening to the event, but should still call base.onResize to ensure that the event is fired for external listeners.
		/// </summary>
		/// <param name="eventargs">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnResize(System.EventArgs eventargs)
		{
			base.OnResize(eventargs);
			Refresh();
		}

		private void ResetTheme()
		{
			if (VisualStyleRenderer.IsSupported && styleClass != null)
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
			Invalidate();
		}
	}
}