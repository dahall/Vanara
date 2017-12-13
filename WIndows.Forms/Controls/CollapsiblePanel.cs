using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Extensions;

namespace Vanara.Windows.Forms
{
	public enum CollapsiblePanelBorderCondition
	{
		Always,
		OnlyExpanded,
		Never
	}

	public enum CollapsiblePanelHeaderState
	{
		Normal = 0,
		Hot = 1,
		Pressed = 2,
		ExpandedNormal = 3,
		ExpandedHot = 4,
		ExpandedPressed = 5,
		Disabled = 6,
		ExpandedDisabled = 7
	}

	[Flags]
	internal enum CollapsiblePanelMousePosition
	{
		Body = 1,
		Header = 2,
		Button = 4
	}

	/// <summary>
	/// Control providing a panel that can be collapsed.
	/// </summary>
	[Designer(typeof(Design.CollapsiblePanelDesigner))]
	[ToolboxItem(true), ToolboxBitmap(typeof(CollapsiblePanel), "CollapsiblePanel.bmp")]
	[Description("Provides a panel that can be collapsed.")]
	public class CollapsiblePanel : Control, ISupportInitialize
	{
		private const int padding = 12;
		internal CollapsiblePanelHeaderState buttonState = CollapsiblePanelHeaderState.Normal;
		internal EmbeddedContainer contentPanel;
		internal bool headerHot;

		private ThemedTableLayoutPanel backgroundPanel;
		private ThemedPanel bottomBorder;
		private bool buttonDown;
		private ThemedTableLayoutPanel contentBackground;
		private CollapsiblePanelHeader headerPanel;
		private BaseRenderer renderer;
		private ThemedPanel topBorder;

		public CollapsiblePanel()
		{
			InitializeComponent();
			renderer = new SystemRenderer(this);
			CustomStyle = new Style();
		}

		[DefaultValue(typeof(CollapsiblePanelBorderCondition), "Always")]
		public CollapsiblePanelBorderCondition BottomBorderCondition { get; set; } = CollapsiblePanelBorderCondition.Always;

		[DefaultValue(false)]
		public bool Collapsed { get; set; }

		public Control Content => contentPanel;

		public Style CustomStyle { get; internal set; }

		[DefaultValue("")]
		public string HeaderText
		{
			get => headerPanel.Text; set => headerPanel.Text = value;
		}

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

		[DefaultValue(typeof(CollapsiblePanelBorderCondition), "Always")]
		public CollapsiblePanelBorderCondition TopBorderCondition { get; set; } = CollapsiblePanelBorderCondition.Always;

		public void BeginInit()
		{
		}

		public void EndInit()
		{
		}

		public override Size GetPreferredSize(Size proposedSize) => renderer.GetPreferredSize(proposedSize);

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			Collapsed = !Collapsed;
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
		}

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

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			headerHot = false;
			buttonDown = false;
			Refresh();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			HandleMouseEvent(e);
			base.OnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			HandleMouseEvent(e);
			buttonDown = false;
			Refresh();
			base.OnMouseUp(e);
		}

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
			// 
			// backgroundPanel
			// 
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
			// 
			// topBorder
			// 
			topBorder.BackColor = SystemColors.Control;
			topBorder.Dock = DockStyle.Top;
			topBorder.Height = 1;
			topBorder.Margin = new Padding(0);
			topBorder.Name = "topBorder";
			topBorder.StyleClass = "CONTROLPANEL";
			topBorder.StylePart = 17;
			// 
			// headerPanel
			// 
			headerPanel.Dock = DockStyle.Top;
			headerPanel.HorzPadding = padding;
			headerPanel.Margin = new Padding(0);
			headerPanel.Name = "headerPanel";
			headerPanel.Size = new Size(200, 37);
			headerPanel.Click += HeaderPanel_Click;
			// 
			// contentBackground
			// 
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
			// 
			// contentPanel
			// 
			contentPanel.Dock = DockStyle.Fill;
			contentPanel.Margin = new Padding(0);
			contentPanel.Name = "contentPanel";
			contentPanel.TabIndex = 0;
			// 
			// bottomBorder
			// 
			bottomBorder.BackColor = SystemColors.Control;
			bottomBorder.Dock = DockStyle.Bottom;
			bottomBorder.Height = 1;
			bottomBorder.Margin = new Padding(0);
			bottomBorder.Name = "bottomBorder";
			bottomBorder.StyleClass = "CONTROLPANEL";
			bottomBorder.StylePart = 17;
			// 
			// CollapsiblePanel
			// 
			Controls.Add(backgroundPanel);
			backgroundPanel.ResumeLayout(false);
			contentBackground.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void HeaderPanel_Click(object sender, EventArgs e)
		{
			bool collapsed = headerPanel.Collapsed;
			contentBackground.Visible = !collapsed;
			var h = collapsed ? headerPanel.Height : headerPanel.Height + contentBackground.Height;
			if (TopBorderCondition == CollapsiblePanelBorderCondition.Always || (TopBorderCondition == CollapsiblePanelBorderCondition.OnlyExpanded && !collapsed))
				h++;
			if (BottomBorderCondition == CollapsiblePanelBorderCondition.Always || (BottomBorderCondition == CollapsiblePanelBorderCondition.OnlyExpanded && !collapsed))
				h++;
			Height = h;
		}

		public class Style
		{
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

			[DefaultValue(typeof(Color), "White")]
			public Color BackColor { get; set; }

			public Image[] ExpandoImages { get; set; }

			public Font Font { get; set; }

			[DefaultValue(typeof(Color), "Black")]
			public Color ForeColor { get; set; }

			[DefaultValue(typeof(Color), "White")]
			public Color HeaderBackColor { get; set; }

			public Font HeaderFont { get; set; }

			[DefaultValue(30)]
			public int HeaderHeight { get; set; }

			[DefaultValue(typeof(Color), "LightSkyBlue")]
			public Color HeaderHotBackColor { get; set; }

			[DefaultValue(typeof(Color), "DarkBlue")]
			public Color HeaderTextColor { get; set; }

			[DefaultValue(typeof(Padding), "12,12,12,12")]
			public Padding Padding { get; set; }

			public override string ToString() => @"Style: " + string.Join("; ", GetType().GetProperties().Select(p => $"{p.Name}={p.GetValue(this, null)}").ToArray());
		}

		internal abstract class BaseRenderer
		{
			protected BaseRenderer(CollapsiblePanel ctrl) { Control = ctrl; }

			public CollapsiblePanel Control { get; }

			public abstract CollapsiblePanelMousePosition GetMousePosition(MouseEventArgs e);

			public virtual Size GetPreferredSize(Size proposedSize) { return proposedSize; }

			public abstract void Layout(PaintEventArgs e);

			public abstract void Paint(PaintEventArgs e);
		}

		internal class CustomRenderer : BaseRenderer
		{
			private Rectangle buttonBounds;
			private readonly ImageList headerImages;

			public CustomRenderer(CollapsiblePanel ctrl) : base(ctrl)
			{
				headerImages = new ImageList { ColorDepth = ColorDepth.Depth32Bit, TransparentColor = Color.Transparent };
			}

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
				headerImages.Images.AddRange(Control.CustomStyle.ExpandoImages);
			}

			public override void Paint(PaintEventArgs e)
			{
				Layout(e);
				using (var br = new SolidBrush(Control.headerHot ? Control.CustomStyle.HeaderHotBackColor : Control.CustomStyle.HeaderBackColor))
					e.Graphics.FillRectangle(br, new Rectangle(Point.Empty, new Size(Control.Width, Control.CustomStyle.HeaderHeight)));
				var imgSz = Control.CustomStyle.ExpandoImages[0].Size;
				buttonBounds = new Rectangle(e.ClipRectangle.Width - imgSz.Width - Control.CustomStyle.Padding.Right, (Control.CustomStyle.HeaderHeight - imgSz.Height) / 2, imgSz.Width, imgSz.Height);
				headerImages.Draw(e.Graphics, buttonBounds.Location, (int)Control.buttonState);
				using (var br = new SolidBrush(Control.CustomStyle.HeaderTextColor))
					e.Graphics.DrawString(Control.Text, Control.CustomStyle.HeaderFont, br, new RectangleF(Control.CustomStyle.Padding.Left, Control.CustomStyle.Padding.Top, Control.Width - Control.CustomStyle.Padding.Horizontal - imgSz.Width, Control.CustomStyle.HeaderHeight), new StringFormat(StringFormatFlags.NoWrap));
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

			public SystemRenderer(CollapsiblePanel ctrl) : base(ctrl) { }

			public override CollapsiblePanelMousePosition GetMousePosition(MouseEventArgs e)
			{
				CollapsiblePanelMousePosition ret = 0;
				if (e.Y <= headerHeight) ret |= CollapsiblePanelMousePosition.Header;
				if (buttonBounds.Contains(e.Location)) ret |= CollapsiblePanelMousePosition.Button;
				return ret;
			}

			public override Size GetPreferredSize(Size proposedSize)
			{
				using (var g = Control.CreateGraphics())
				{
					Layout(new PaintEventArgs(g, new Rectangle(Point.Empty, proposedSize)));
					int minW = (imgSz.Width*2) + (lrpadding*3);
					if (proposedSize.Width < minW) proposedSize.Width = minW;
					if (proposedSize.Height < headerHeight) proposedSize.Height = headerHeight;
					return proposedSize;
				}
			}

			public override void Layout(PaintEventArgs e)
			{
				// Get TaskDialog-MainInstructionPane
				var vs = new VisualStyleRenderer(taskDialogClass, 2, 0);
				var r = vs.GetTextExtent(e.Graphics, "W", TextFormatFlags.Default);
				headerHeight = (tbpadding * 2) + r.Height;
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
				vs = new VisualStyleRenderer(taskDialogClass, 13, ((int)Control.buttonState) + 1);
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
}
