using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// Represents an expanded Windows list view control, which displays a collection of items that can be displayed using one of four different views. Added support for DataSource, columns, and groups.
	/// </summary>
	public partial class ListViewEx : ListView
	{
		private Image watermarkImage;

		/// <summary>
		/// Initializes a new instance of the <see cref="ListViewEx"/> class.
		/// </summary>
		public ListViewEx()
		{
			ListViewItemSorter = new ListViewColumnSorter();
			InvokeMatchingMethods<Action>("Initialize_");
		}

		internal void InvokeMatchingMethods<T>(string methodPrefix, params object[] parameters)
		{
			foreach (var mi in GetType().GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
			{
				if (mi.Name.StartsWith(methodPrefix) && (Delegate.CreateDelegate(typeof(T), this, mi, false) != null))
					try { mi.Invoke(this, parameters); } catch { }
			}
		}

		/// <summary>
		/// Gets or sets the watermark.
		/// </summary>
		/// <value>
		/// The watermark.
		/// </value>
		[DefaultValue((Image)null), Category("Appearance")]
		public Image Watermark
		{
			get { return watermarkImage; }
			set
			{
				if (watermarkImage != value)
				{
					watermarkImage = value;
					this.CallWhenHandleValid(c =>
					{
						var bki = value == null ? new LVBKIMAGE() : new LVBKIMAGE(new Bitmap(value), true, true);
						Vanara.PInvoke.User32.SendMessage(Handle, ListViewMessage.SetBkImage, 0, bki);
					});
				}
			}
		}

		/// <summary>
		/// Measures the width of the text using the current font.
		/// </summary>
		/// <param name="text">The text to measure.</param>
		/// <returns>Width of text in pixels.</returns>
		public int MeasureTextWidth(string text) => Vanara.PInvoke.User32.SendMessage(new HandleRef(this, Handle), (uint)ListViewMessage.GetStringWidth, IntPtr.Zero, text).ToInt32();

		internal void RecreateHandleInternal()
		{
			if (IsHandleCreated && (StateImageList != null))
				SendMessage(ListViewMessage.Update, -1, IntPtr.Zero);
			RecreateHandle();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			(this as System.Configuration.IPersistComponentSettings).SaveComponentSettings();
			InvokeMatchingMethods<Action<bool>>("Dispose_", disposing);
			base.Dispose(disposing);
		}

		/// <summary>
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			InvokeMatchingMethods<Action<EventArgs>>("OnHandleCreated_", e);
		}

		private delegate void WndProcDelegate(ref Message m);

		/// <summary>
		/// Overrides <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)" />.
		/// </summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			InvokeMatchingMethods<WndProcDelegate>("WndProc_", m);
			if (m.Result != IntPtr.Zero)
				return;

			switch (m.Msg)
			{
				case 0x0200: // WM_MOUSEMOVE
					break;

				case 0x0202: // WM_LBUTTONUP
				//base.DefWndProc(ref m);
				//break;
				default:
					base.WndProc(ref m);
					break;
			}
		}

		private int SendMessage(ListViewMessage msg, int wParam, IntPtr lParam) => Vanara.PInvoke.User32.SendMessage(new HandleRef(this, Handle), (uint)msg, (IntPtr)wParam, lParam).ToInt32();

		private void UpdateListViewItemsLocations()
		{
			if (!VirtualMode && IsHandleCreated && AutoArrange)
			{
				try
				{
					BeginUpdate();
					SendMessage(ListViewMessage.Update, -1, IntPtr.Zero);
				}
				finally
				{
					EndUpdate();
				}
			}
		}

		internal void UpdateItem(LVITEM lvItem)
		{
			this.CallWhenHandleValid(c => Vanara.PInvoke.User32.SendMessage(c.Handle, ListViewMessage.SetItem, 0, lvItem));
		}

		private bool ComctlSupportsVisualStyles => Application.RenderWithVisualStyles;
	}
}