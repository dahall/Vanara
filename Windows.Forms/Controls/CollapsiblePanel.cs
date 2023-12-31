using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Vanara.Windows.Forms;

/// <summary>Determines when a border will be displayed.</summary>
public enum CollapsiblePanelBorderCondition
{
	/// <summary>Always.</summary>
	Always,

	/// <summary>Only when the panel is expanded.</summary>
	OnlyExpanded,

	/// <summary>Never.</summary>
	Never
}

/// <summary>Determines the state of the panel's header.</summary>
public enum CollapsiblePanelHeaderState
{
	/// <summary>Normal</summary>
	Normal = 0,

	/// <summary>The mouse is over the header.</summary>
	Hot = 1,

	/// <summary>The header is being clicked.</summary>
	Pressed = 2,

	/// <summary>The header is in the normal expanded state.</summary>
	ExpandedNormal = 3,

	/// <summary>The header is in the hot expanded state.</summary>
	ExpandedHot = 4,

	/// <summary>The header is in the pressed expanded state.</summary>
	ExpandedPressed = 5,

	/// <summary>The header is disabled.</summary>
	Disabled = 6,

	/// <summary>The header is disabled and expanded.</summary>
	ExpandedDisabled = 7
}

[Flags]
internal enum CollapsiblePanelMousePosition
{
	Body = 1,
	Header = 2,
	Button = 4
}

/// <summary>Control providing a panel that can be collapsed.</summary>
[Designer(typeof(Design.CollapsiblePanelDesigner))]
[ToolboxItem(true), ToolboxBitmap(typeof(CollapsiblePanel), "CollapsiblePanel.bmp")]
[Description("Provides a panel that can be collapsed.")]
public class CollapsiblePanel : Control, ISupportInitialize
{
	internal CollapsiblePanelHeaderState buttonState = CollapsiblePanelHeaderState.Normal;
	internal EmbeddedContainer contentPanel;
	internal bool headerHot;
	private const int padding = 12;
	private ThemedTableLayoutPanel backgroundPanel;
	private ThemedPanel bottomBorder;
	private bool buttonDown;
	private ThemedTableLayoutPanel contentBackground;
	private CollapsiblePanelHeader headerPanel;
	private BaseRenderer renderer;
	private ThemedPanel topBorder;

	/// <summary>Initializes a new instance of the <see cref="CollapsiblePanel"/> class.</summary>
	public CollapsiblePanel()
	{
		InitializeComponent();
		renderer = new SystemRenderer(this);
		CustomStyle = new Style();
	}

	/// <summary>Gets or sets the bottom border condition.</summary>
	/// <value>The bottom border condition.</value>
	[DefaultValue(typeof(CollapsiblePanelBorderCondition), "Always")]
	public CollapsiblePanelBorderCondition BottomBorderCondition { get; set; } = CollapsiblePanelBorderCondition.Always;

	/// <summary>Gets or sets a value indicating whether this <see cref="CollapsiblePanel"/> is collapsed.</summary>
	/// <value><see langword="true"/> if collapsed; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false)]
	public bool Collapsed { get; set; }

	/// <summary>Gets the control that holds the content.</summary>
	/// <value>The content control.</value>
	public Control Content => contentPanel;

	/// <summary>Gets the custom style.</summary>
	/// <value>The custom style.</value>
	public Style CustomStyle { get; internal set; }

	/// <summary>Gets or sets the header text.</summary>
	/// <value>The header text.</value>
	[DefaultValue("")]
	public string HeaderText
	{
		get => headerPanel.Text; set => headerPanel.Text = value;
	}

	/// <summary>Gets or sets the render style.</summary>
	/// <value>The render style.</value>
	[DefaultValue(typeof(RenderStyle), "SystemTheme")]
	public RenderStyle RenderStyle
	{
		get => renderer is CustomRenderer ? RenderStyle.Custom : RenderStyle.SystemTheme; set
		{
			if (value == RenderStyle.SystemTheme)
				renderer = new SystemRenderer(this);
			else
				renderer = new CustomRenderer(this);
		}
	}

	/// <summary>Gets or sets the top border condition.</summary>
	/// <value>The top border condition.</value>
	[DefaultValue(typeof(CollapsiblePanelBorderCondition), "Always")]
	public CollapsiblePanelBorderCondition TopBorderCondition { get; set; } = CollapsiblePanelBorderCondition.Always;

	/// <summary>Signals the object that initialization is starting.</summary>
	public virtual void BeginInit()
	{
	}

	/// <summary>Signals the object that initialization is complete.</summary>
	public virtual void EndInit()
	{
	}

	/// <summary>Retrieves the size of a rectangular area into which a control can be fitted.</summary>
	/// <param name="proposedSize">The custom-sized area for a control.</param>
	/// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.</returns>
	public override Size GetPreferredSize(Size proposedSize) => renderer.GetPreferredSize(proposedSize);

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Click"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnClick(EventArgs e)
	{
		base.OnClick(e);
		Collapsed = !Collapsed;
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnHandleCreated(EventArgs e) => base.OnHandleCreated(e);

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseDown(MouseEventArgs e)
	{
		HandleMouseEvent(e);
		if (e.Button == MouseButtons.Left && headerHot)
		{
			buttonDown = true;
			Refresh();
		}
		base.OnMouseDown(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		headerHot = false;
		buttonDown = false;
		Refresh();
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseMove(MouseEventArgs e)
	{
		HandleMouseEvent(e);
		base.OnMouseMove(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
	protected override void OnMouseUp(MouseEventArgs e)
	{
		HandleMouseEvent(e);
		buttonDown = false;
		Refresh();
		base.OnMouseUp(e);
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.</summary>
	/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
	protected override void OnPaint(PaintEventArgs e)
	{
		// Draw header
		//renderer.Paint(e);
	}

	private void HandleMouseEvent(MouseEventArgs e)
	{
		var mp = renderer.GetMousePosition(e);
		var hh = mp.IsFlagSet(CollapsiblePanelMousePosition.Header);
		CollapsiblePanelHeaderState bs;
		if (hh)
		{
			if (buttonDown)
				bs = Collapsed ? CollapsiblePanelHeaderState.Pressed : CollapsiblePanelHeaderState.ExpandedPressed;
			else
				bs = Collapsed ? CollapsiblePanelHeaderState.Hot : CollapsiblePanelHeaderState.ExpandedHot;
		}
		else
		{
			if (Enabled)
				bs = Collapsed ? CollapsiblePanelHeaderState.Normal : CollapsiblePanelHeaderState.ExpandedNormal;
			else
				bs = Collapsed ? CollapsiblePanelHeaderState.Disabled : CollapsiblePanelHeaderState.ExpandedDisabled;
		}
		if (bs == buttonState && hh == headerHot) return;
		buttonState = bs;
		headerHot = hh;
		Refresh();
	}

	private void HeaderPanel_Click(object? sender, EventArgs e)
	{
		bool collapsed = headerPanel.Collapsed;
		contentBackground.Visible = !collapsed;
		var h = collapsed ? headerPanel.Height : headerPanel.Height + contentBackground.Height;
		if (TopBorderCondition == CollapsiblePanelBorderCondition.Always || TopBorderCondition == CollapsiblePanelBorderCondition.OnlyExpanded && !collapsed)
			h++;
		if (BottomBorderCondition == CollapsiblePanelBorderCondition.Always || BottomBorderCondition == CollapsiblePanelBorderCondition.OnlyExpanded && !collapsed)
			h++;
		Height = h;
	}

	[MemberNotNull(nameof(backgroundPanel), nameof(topBorder), nameof(headerPanel), nameof(contentBackground), nameof(contentPanel), nameof(bottomBorder))]
	private void InitializeComponent()
	{
		backgroundPanel = new ThemedTableLayoutPanel();
		topBorder = new ThemedPanel();
		headerPanel = new CollapsiblePanelHeader();
		contentBackground = new ThemedTableLayoutPanel();
		contentPanel = new EmbeddedContainer();
		bottomBorder = new ThemedPanel();
		backgroundPanel.SuspendLayout();
		contentBackground.SuspendLayout();
		SuspendLayout();
		// backgroundPanel
		backgroundPanel.ColumnCount = 1;
		backgroundPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		backgroundPanel.Controls.Add(topBorder, 0, 0);
		backgroundPanel.Controls.Add(headerPanel, 0, 1);
		backgroundPanel.Controls.Add(contentBackground, 0, 2);
		backgroundPanel.Controls.Add(bottomBorder, 0, 3);
		backgroundPanel.Dock = DockStyle.Fill;
		backgroundPanel.Name = "backgroundPanel";
		backgroundPanel.RowCount = 4;
		backgroundPanel.RowStyles.Add(new RowStyle());
		backgroundPanel.RowStyles.Add(new RowStyle());
		backgroundPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		backgroundPanel.RowStyles.Add(new RowStyle());
		backgroundPanel.StyleClass = "CONTROLPANEL";
		backgroundPanel.StylePart = 2;
		// topBorder
		topBorder.BackColor = SystemColors.Control;
		topBorder.Dock = DockStyle.Top;
		topBorder.Height = 1;
		topBorder.Margin = new Padding(0);
		topBorder.Name = "topBorder";
		topBorder.StyleClass = "CONTROLPANEL";
		topBorder.StylePart = 17;
		// headerPanel
		headerPanel.Dock = DockStyle.Top;
		headerPanel.HorzPadding = padding;
		headerPanel.Margin = new Padding(0);
		headerPanel.Name = "headerPanel";
		headerPanel.Size = new Size(200, 37);
		headerPanel.Click += HeaderPanel_Click;
		// contentBackground
		contentBackground.ColumnCount = 3;
		contentBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, padding));
		contentBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		contentBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, padding));
		contentBackground.Controls.Add(contentPanel, 1, 1);
		contentBackground.Dock = DockStyle.Fill;
		contentBackground.Margin = new Padding(0);
		contentBackground.Name = "contentBackground";
		contentBackground.RowCount = 3;
		contentBackground.RowStyles.Add(new RowStyle(SizeType.Absolute, padding));
		contentBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		contentBackground.RowStyles.Add(new RowStyle(SizeType.Absolute, padding));
		contentBackground.StyleClass = "CONTROLPANEL";
		contentBackground.StylePart = 2;
		// contentPanel
		contentPanel.Dock = DockStyle.Fill;
		contentPanel.Margin = new Padding(0);
		contentPanel.Name = "contentPanel";
		contentPanel.TabIndex = 0;
		// bottomBorder
		bottomBorder.BackColor = SystemColors.Control;
		bottomBorder.Dock = DockStyle.Bottom;
		bottomBorder.Height = 1;
		bottomBorder.Margin = new Padding(0);
		bottomBorder.Name = "bottomBorder";
		bottomBorder.StyleClass = "CONTROLPANEL";
		bottomBorder.StylePart = 17;
		// CollapsiblePanel
		Controls.Add(backgroundPanel);
		backgroundPanel.ResumeLayout(false);
		contentBackground.ResumeLayout(false);
		ResumeLayout(false);
	}

	/// <summary>The panel's style.</summary>
	public class Style
	{
		/// <summary>Initializes a new instance of the <see cref="Style"/> class.</summary>
		public Style()
		{
			BackColor = Color.White;
			//Font = ;
			ForeColor = Color.Black;
			HeaderHeight = 30;
			HeaderBackColor = Color.White;
			//HeaderFont =;
			HeaderHotBackColor = Color.LightSkyBlue;
			HeaderTextColor = Color.DarkBlue;
			Padding = new Padding(12);
		}

		/// <summary>Gets or sets the backgroun color.</summary>
		/// <value>The backgroun color.</value>
		[DefaultValue(typeof(Color), "White")]
		public Color BackColor { get; set; }

		/// <summary>Gets or sets the expando images.</summary>
		/// <value>The expando images.</value>
		public Image[]? ExpandoImages { get; set; }

		/// <summary>Gets or sets the font.</summary>
		/// <value>The font.</value>
		public Font? Font { get; set; }

		/// <summary>Gets or sets the foreground color.</summary>
		/// <value>The foreground color.</value>
		[DefaultValue(typeof(Color), "Black")]
		public Color ForeColor { get; set; }

		/// <summary>Gets or sets the color of the header background.</summary>
		/// <value>The color of the header background.</value>
		[DefaultValue(typeof(Color), "White")]
		public Color HeaderBackColor { get; set; }

		/// <summary>Gets or sets the header font.</summary>
		/// <value>The header font.</value>
		public Font? HeaderFont { get; set; }

		/// <summary>Gets or sets the height of the header.</summary>
		/// <value>The height of the header.</value>
		[DefaultValue(30)]
		public int HeaderHeight { get; set; }

		/// <summary>Gets or sets the color of the header hot background.</summary>
		/// <value>The color of the header hot background.</value>
		[DefaultValue(typeof(Color), "LightSkyBlue")]
		public Color HeaderHotBackColor { get; set; }

		/// <summary>Gets or sets the color of the header text.</summary>
		/// <value>The color of the header text.</value>
		[DefaultValue(typeof(Color), "DarkBlue")]
		public Color HeaderTextColor { get; set; }

		/// <summary>Gets or sets the padding.</summary>
		/// <value>The padding.</value>
		[DefaultValue(typeof(Padding), "12,12,12,12")]
		public Padding Padding { get; set; }

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => @"Style: " + string.Join("; ", GetType().GetProperties().Select(p => $"{p.Name}={p.GetValue(this, null)}").ToArray());
	}

	internal abstract class BaseRenderer
	{
		protected BaseRenderer(CollapsiblePanel ctrl) => Control = ctrl;

		public CollapsiblePanel Control { get; }

		public abstract CollapsiblePanelMousePosition GetMousePosition(MouseEventArgs e);

		public virtual Size GetPreferredSize(Size proposedSize) => proposedSize;

		public abstract void Layout(PaintEventArgs e);

		public abstract void Paint(PaintEventArgs e);
	}

	internal class CustomRenderer : BaseRenderer
	{
		private readonly ImageList headerImages;
		private Rectangle buttonBounds;

		public CustomRenderer(CollapsiblePanel ctrl) : base(ctrl) => headerImages = new ImageList { ColorDepth = ColorDepth.Depth32Bit, TransparentColor = Color.Transparent };

		public override CollapsiblePanelMousePosition GetMousePosition(MouseEventArgs e)
		{
			CollapsiblePanelMousePosition ret = 0;
			if (e.Y <= Control.CustomStyle.HeaderHeight) ret |= CollapsiblePanelMousePosition.Header;
			if (buttonBounds.Contains(e.Location)) ret |= CollapsiblePanelMousePosition.Button;
			return ret;
		}

		public override void Layout(PaintEventArgs e)
		{
			headerImages.Images.Clear();
			headerImages.Images.AddRange(Control.CustomStyle.ExpandoImages!);
		}

		public override void Paint(PaintEventArgs e)
		{
			Layout(e);
			using (var br = new SolidBrush(Control.headerHot ? Control.CustomStyle.HeaderHotBackColor : Control.CustomStyle.HeaderBackColor))
				e.Graphics.FillRectangle(br, new Rectangle(Point.Empty, new Size(Control.Width, Control.CustomStyle.HeaderHeight)));
			var imgSz = Control.CustomStyle.ExpandoImages?[0].Size ?? default;
			buttonBounds = new Rectangle(e.ClipRectangle.Width - imgSz.Width - Control.CustomStyle.Padding.Right, (Control.CustomStyle.HeaderHeight - imgSz.Height) / 2, imgSz.Width, imgSz.Height);
			headerImages.Draw(e.Graphics, buttonBounds.Location, (int)Control.buttonState);
			using (var br = new SolidBrush(Control.CustomStyle.HeaderTextColor))
				e.Graphics.DrawString(Control.Text, Control.CustomStyle.HeaderFont ?? SystemFonts.DefaultFont, br, new RectangleF(Control.CustomStyle.Padding.Left, Control.CustomStyle.Padding.Top, Control.Width - Control.CustomStyle.Padding.Horizontal - imgSz.Width, Control.CustomStyle.HeaderHeight), new StringFormat(StringFormatFlags.NoWrap));
		}
	}

	internal class SystemRenderer : BaseRenderer
	{
		private const int lrpadding = 12;
		private const string taskDialogClass = @"TaskDialog";
		private const int tbpadding = 8;
		private Rectangle buttonBounds;
		private int headerHeight;
		private Size imgSz;
		private Rectangle textBounds;

		public SystemRenderer(CollapsiblePanel ctrl) : base(ctrl)
		{
		}

		public override CollapsiblePanelMousePosition GetMousePosition(MouseEventArgs e)
		{
			CollapsiblePanelMousePosition ret = 0;
			if (e.Y <= headerHeight) ret |= CollapsiblePanelMousePosition.Header;
			if (buttonBounds.Contains(e.Location)) ret |= CollapsiblePanelMousePosition.Button;
			return ret;
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			using var g = Control.CreateGraphics();
			Layout(new PaintEventArgs(g, new Rectangle(Point.Empty, proposedSize)));
			int minW = imgSz.Width * 2 + lrpadding * 3;
			if (proposedSize.Width < minW) proposedSize.Width = minW;
			if (proposedSize.Height < headerHeight) proposedSize.Height = headerHeight;
			return proposedSize;
		}

		public override void Layout(PaintEventArgs e)
		{
			// Get TaskDialog-MainInstructionPane
			var vs = new VisualStyleRenderer(taskDialogClass, 2, 0);
			var r = vs.GetTextExtent(e.Graphics, "W", TextFormatFlags.Default);
			headerHeight = tbpadding * 2 + r.Height;
			// Get TaskDialog-ExpandoButton
			vs = new VisualStyleRenderer(taskDialogClass, 13, (int)Control.buttonState);
			imgSz = new Size(vs.GetInteger(IntegerProperty.Width), vs.GetInteger(IntegerProperty.Height));
			buttonBounds = new Rectangle(e.ClipRectangle.Width - imgSz.Width - lrpadding, (headerHeight - imgSz.Height) / 2, imgSz.Width, imgSz.Height);
			textBounds = new Rectangle(lrpadding, tbpadding, e.ClipRectangle.Width - lrpadding - imgSz.Width, tbpadding + r.Height);
			Control.Padding = new Padding(lrpadding, headerHeight + tbpadding, lrpadding, tbpadding);
			System.Diagnostics.Debug.WriteLine($"Layout: hdrH={headerHeight}; imgSz={imgSz}; btnBnd={buttonBounds}; txtBnd={textBounds}");
		}

		public override void Paint(PaintEventArgs e)
		{
			Layout(e);

			// Get TaskDialog-PrimaryPanel
			var vs = new VisualStyleRenderer(taskDialogClass, 1, 0);
			vs.DrawParentBackground(e.Graphics, Control.ClientRectangle, Control);
			if (Control.headerHot)
			{
				// Get ListView-GroupHeader-OpenHot
				vs = new VisualStyleRenderer("ListView", 6, 2);
				var hdrRect = Control.ClientRectangle;
				hdrRect.Height = headerHeight;
				vs.DrawBackground(e.Graphics, hdrRect, e.ClipRectangle);
			}
			// Get TaskDialog-ExpandoButton
			vs = new VisualStyleRenderer(taskDialogClass, 13, (int)Control.buttonState + 1);
			vs.DrawBackground(e.Graphics, buttonBounds);
			// Get TaskDialog-MainInstructionPane
			vs = new VisualStyleRenderer(taskDialogClass, 2, 0);
			var tff = TextFormatFlags.SingleLine;
			if (Control.GetRightToLeftProperty() == RightToLeft.Yes)
				tff |= TextFormatFlags.RightToLeft;
			vs.DrawText(e.Graphics, textBounds, Control.Text, !Control.Enabled, tff);
		}
	}
}