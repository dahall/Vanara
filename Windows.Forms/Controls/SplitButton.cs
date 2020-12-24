using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// The SplitButton is a composite control with which the user can select from a drop-down list bound to the button.
	/// </summary>
	public class SplitButton : VistaButtonBase
	{
		//private const int BCM_SETDROPDOWNSTATE = 0x1606;
		//private const int BCM_SETSPLITINFO = 0x1607;
		//private const int BCM_GETSPLITINFO = 0x1608;
		//private const int NM_GETCUSTOMSPLITRECT = -1247;
		//private const int BCN_DROPDOWN = -1248;
		//private const int BCN_HOTITEMCHANGE = -1249;
		//private const int BS_SPLITBUTTON = 0xC;

		private ContextMenuStrip contextMenu;
		private bool showingDropdown;
		private ImageList splitButtonImageList;
		private SplitButtonInfoStyle style = 0;

		/// <summary>
		/// Occurs when the split label is clicked.
		/// </summary>
		[Description("Occurs when the split button is clicked."), Category("Action")]
		public event EventHandler<SplitMenuEventArgs> SplitClick;

		/// <summary>
		/// Occurs when the split label is clicked, but before the associated context menu is displayed by the control.
		/// </summary>
		[Description("Occurs when the split label is clicked, but before the associated context menu is displayed."), Category("Action")]
		public event EventHandler<SplitMenuEventArgs> SplitMenuOpening;

		/// <summary>
		/// Gets or sets the visibility of the split button divider.
		/// </summary>
		/// <value>
		///   <c>true</c> if hiding split separator; otherwise, <c>false</c>.
		/// </value>
		[Description("Sets the visibility of the split button divider."), Category("Appearance"), DefaultValue(false)]
		public bool HideSplitSeparator
		{
			get => GetSplitStyle(SplitButtonInfoStyle.BCSS_NOSPLIT); set => SetSplitStyle(SplitButtonInfoStyle.BCSS_NOSPLIT, value);
		}

		/// <summary>
		/// Gets or sets the alignment of the split button image.
		/// </summary>
		/// <value>
		/// The split button alignment.
		/// </value>
		[Description("Sets the alignment of the split button image."), Category("Appearance"), DefaultValue(typeof(LeftRightAlignment), "Right")]
		public LeftRightAlignment SplitButtonAlignment
		{
			get => GetSplitStyle(SplitButtonInfoStyle.BCSS_ALIGNLEFT) ? LeftRightAlignment.Left : LeftRightAlignment.Right; set => SetSplitStyle(SplitButtonInfoStyle.BCSS_ALIGNLEFT, value == LeftRightAlignment.Left);
		}

		/// <summary>
		/// Gets or sets the split button image list.
		/// </summary>
		/// <value>
		/// The split button image list.
		/// </value>
		[Description("ImageList containing an image to show on split button."), Category("Appearance"), DefaultValue(null)]
		public ImageList SplitButtonImageList
		{
			get => splitButtonImageList; set
			{
				if (splitButtonImageList != value)
				{
					splitButtonImageList = value;
					if (IsHandleCreated)
					{
						if (splitButtonImageList != null)
							SetSplitInfo(new BUTTON_SPLITINFO(splitButtonImageList.Handle));
						else
							RecreateHandle();
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets the associated context menu that is displayed when the split glyph of the button is clicked.
		/// </summary>
		[Description("Sets the context menu that is displayed by clicking on the split button."), Category("Behavior"), DefaultValue(null)]
		public ContextMenuStrip SplitMenuStrip
		{
			get => contextMenu; set
			{
				if (value != contextMenu)
				{
					if (contextMenu != null)
						contextMenu.Closed -= contextMenu_Closed;
					contextMenu = value;
					contextMenu.Closed += contextMenu_Closed;
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to stretch the split button image.
		/// </summary>
		/// <value>
		/// <c>true</c> to stretch split button image; otherwise, <c>false</c>.
		/// </value>
		[Description("Stretch glyph, but try to retain aspect ratio."), Category("Appearance"), DefaultValue(false)]
		public bool StretchSplitButtonImage
		{
			get => GetSplitStyle(SplitButtonInfoStyle.BCSS_STRETCH); set => SetSplitStyle(SplitButtonInfoStyle.BCSS_STRETCH, value);
		}

		/// <summary>
		/// Gets a <see cref="T:System.Windows.Forms.CreateParams" /> on the base class when creating a window.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				if (IsPlatformSupported)
					cp.Style |= (int)ButtonStyle.BS_SPLITBUTTON;
				return cp;
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (style != 0)
				SetSplitInfo(new BUTTON_SPLITINFO(style));
			if (splitButtonImageList != null)
				SetSplitInfo(new BUTTON_SPLITINFO(splitButtonImageList.Handle));
		}

		/// <summary>
		/// Raises the <see cref="E:SplitClick" /> event.
		/// </summary>
		/// <param name="e">The <see cref="SplitMenuEventArgs"/> instance containing the event data.</param>
		protected virtual void OnSplitClick(SplitMenuEventArgs e)
		{
			if (SplitMenuStrip != null)
			{
				if (showingDropdown)
				{
					//SplitMenuStrip.Close();
				}
				else
				{
					SplitMenuOpening?.Invoke(this, e);

					if (!e.PreventOpening)
					{
						SplitMenuStrip.Width = e.DrawArea.Width;
						showingDropdown = true;
						SplitMenuStrip.Show(this, new Point(e.DrawArea.Left, e.DrawArea.Bottom));
					}
				}
			}

			SplitClick?.Invoke(this, e);
		}

		/// <summary>
		/// Processes Windows messages.
		/// </summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == OCM_NOTIFY)
			{
				var nmhdr = m.LParam.ToStructure<NMHDR>();
				if ((ButtonNotification)nmhdr.code == ButtonNotification.BCN_DROPDOWN && SplitMenuStrip != null)
					OnSplitClick(new SplitMenuEventArgs(ClientRectangle));
			}
			base.WndProc(ref m);
		}

		private void contextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			showingDropdown = false;
		}

		private BUTTON_SPLITINFO GetSplitInfo()
		{
			var info = new BUTTON_SPLITINFO();
			SendMessage(Handle, ButtonMessage.BCM_GETSPLITINFO, 0, ref info);
			return info;
		}

		private bool GetSplitStyle(SplitButtonInfoStyle btnStyle) => (style & btnStyle) == btnStyle;

		private void SetSplitInfo(BUTTON_SPLITINFO info)
		{
			SendMessage(Handle, ButtonMessage.BCM_SETSPLITINFO, 0, ref info);
			Refresh();
		}

		private void SetSplitStyle(SplitButtonInfoStyle btnStyle, bool value)
		{
			if (value != GetSplitStyle(btnStyle))
			{
				if (value)
					style |= btnStyle;
				else
					style &= ~btnStyle;
				if (IsHandleCreated)
					SetSplitInfo(new BUTTON_SPLITINFO(style));
			}
		}

		/// <summary>
		/// Provides data for the clicking of split buttons and the opening of context menus.
		/// </summary>
		public class SplitMenuEventArgs : EventArgs
		{
			internal SplitMenuEventArgs(Rectangle drawArea)
			{
				PreventOpening = false;
				DrawArea = drawArea;
			}

			/// <summary>Represents the bounding box of the clicked button.</summary>
			/// <remarks>A menu should be opened, with top-left coordinates in the left-bottom point of
			/// the rectangle and with width equal (or greater) than the width of the rectangle.</remarks>
			public Rectangle DrawArea { get; set; }

			/// <summary>Set to true if you want to prevent the menu from opening.</summary>
			public bool PreventOpening { get; set; }
		}
	}
}