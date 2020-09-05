using System;
using Vanara.PInvoke;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.WinBase;

namespace Vanara.Windows.Forms
{
	public partial class ListViewEx
	{
		private ColumnHeaderExCollection newCols;

		/// <summary>
		/// Occurs when the drop-down button on a column header is clicked.
		/// </summary>
		public event EventHandler<ColumnHeaderDropdownArgs> ColumnHeaderDropdown;

		/// <summary>
		/// Occurs when a column header is right clicked.
		/// </summary>
		public event EventHandler<ColumnClickEventArgs> ColumnRightClick;

		/// <summary>
		/// Gets or sets the <see cref="ContextMenuStrip"/> associated with the column headers of this control.
		/// </summary>
		/// <value>
		/// The column header context menu strip.
		/// </value>
		[DefaultValue(null), Category("Behavior")]
		public ContextMenuStrip ColumnContextMenuStrip { get; set; }

		/// <summary>
		/// Gets the collection of all column headers that appear in the control.
		/// </summary>
		/// <returns>A <see cref="T:System.Windows.Forms.ColumnHeaderExCollection" /> that represents the column headers that appear when the <see cref="P:System.Windows.Forms.ListViewEx.View" /> property is set to <see cref="F:System.Windows.Forms.View.Details" />.</returns>
		/// <remarks>The <c>Columns</c> property returns a collection that contains the <see cref="ColumnHeaderEx"/> objects that are displayed in the <see cref="ListViewEx"/> control. <see cref="ColumnHeaderEx"/> objects define the columns that are displayed in the <see cref="ListViewEx"/> control when the <see cref="P:System.Windows.Forms.ListViewEx.View"/> property is set to <see cref="F:System.Windows.Forms.View.Details"/>. Each column is used to display subitem information for each item in the <see cref="ListViewEx"/>. For more information about how to manipulate the items in the collection, see <see cref="ColumnHeaderExCollection"/>.</remarks>
		[Description("Columns"), Localizable(true), MergableProperty(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor(typeof(ColumnHeaderExCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public new ColumnHeaderExCollection Columns => newCols ?? (newCols = new ColumnHeaderExCollection(this));

		internal ColumnHeaderCollection BaseColumns => base.Columns;

		internal IntPtr HeaderHandle => this.GetHeaderHandle();

		internal void SetColumnFormat(int columnIndex, ListViewColumnFormat fmtFlag, bool on)
		{
			if (((columnIndex < 0) || ((columnIndex >= 0) && (Columns == null))) || (columnIndex >= Columns.Count))
				throw new ArgumentOutOfRangeException(nameof(columnIndex));

			if (IsHandleCreated)
			{
				var lvc = new LVCOLUMN(ListViewColumMask.Fmt);
				User32.SendMessage(Handle, ListViewMessage.GetColumn, columnIndex, lvc);
				if (on)
					lvc.Format |= fmtFlag;
				else
					lvc.Format &= (~fmtFlag);
				if (User32.SendMessage(Handle, ListViewMessage.SetColumn, columnIndex, lvc) == IntPtr.Zero)
					throw new Win32Exception();
				this.InvalidateHeader();
			}
		}

		/*internal void InvalidateColumnHeaders()
		{
			var mi = typeof(ListView).GetMethod("InvalidateColumnHeaders", Reflection.BindingFlags.Instance | Reflection.BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			mi?.Invoke(this, null);
		}*/

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.ListView.ColumnClick" /> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ColumnClickEventArgs" /> that contains the event data.</param>
		protected override void OnColumnClick(ColumnClickEventArgs e)
		{
			if (Columns[e.Column].Sortable)
			{
				var sorter = (ListViewColumnSorter)ListViewItemSorter;
				if (e.Column == sorter.SortColumn)
				{
					// Reverse the current sort direction for this column.
					sorter.Order = (sorter.Order == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
				}
				else
				{
					// Set the column number that is to be sorted; default to ascending.
					sorter.SortColumn = e.Column;
					sorter.Order = SortOrder.Ascending;
				}

				// Perform the sort with these new sort options.
				Sort();
				this.SetSortIcon(sorter.SortColumn, sorter.Order);
				Refresh();
			}
			base.OnColumnClick(e);
		}

		protected virtual void OnColumnHeaderDropdown(ColumnHeaderDropdownArgs e)
		{
			ColumnHeaderDropdown?.Invoke(this, e);
		}

		protected virtual void OnColumnRightClick(ColumnClickEventArgs e)
		{
			ColumnRightClick?.Invoke(this, e);
		}

		protected virtual void OnHandleCreated_Columns(EventArgs e)
		{
			for (var i = 0; i < Columns.Count; i++)
			{
				if (Columns[i].ShowDropDownButton)
					this.SetColumnDropDown(i, true);

				// Not sure if this needs to happen
				if (Columns[i].SortOrder != SortOrder.None)
					this.SetSortIcon(i, Columns[i].SortOrder);
			}
		}

		/// <summary>
		/// Overrides <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)" />.
		/// </summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected virtual void WndProc_Columns(ref Message m)
		{
			if (m.Msg == 0x7b) // WM_CONTEXTMENU
			{
				var lp = m.LParam.ToInt32();
				var pt = new Point(lp & 0xFFFF, (lp >> 16) & 0xFFFF);
				var hHdr = HeaderHandle;
				if (0 != MapWindowPoints(default(HandleRef), new HandleRef(this, hHdr), ref pt, 1))
				{
					var hti = new HDHITTESTINFO(pt);
					var item = User32.SendMessage(hHdr, HeaderMessage.HitTest, 0, hti).ToInt32();
					if (item != -1)
					{
						OnColumnRightClick(new ColumnClickEventArgs(item));
						ColumnContextMenuStrip?.Show(pt);
					}
					System.Diagnostics.Debug.WriteLine($"ListViewEx:WM_CONTEXTMENU for column header {item} ({hti.Flags})");
				}
			}
			else if (m.Msg == 0x204E) // WM_NOTIFY
			{
				var nm = m.GetLParam<NMHDR>();
				if (nm.code == (int)ListViewNotifications.ColumnDropDown)
				{
					var nmlv = m.GetLParam<NMLISTVIEW>();
					var iCol = nmlv.iSubItem;
					var rc = new RECT();
					User32.SendMessage(new HandleRef(this, HeaderHandle), (uint)HeaderMessage.GetItemDropDownRect, (IntPtr)iCol, ref rc);
					rc = RectangleToClient(rc);
					OnColumnHeaderDropdown(new ColumnHeaderDropdownArgs() { Column = iCol, ColumnBounds = rc });
					if (Columns[iCol].DropDownContextMenu != null)
						Columns[iCol].DropDownContextMenu.Show(this, rc.X, rc.Bottom);
				}
			}
		}

		public class ColumnHeaderDropdownArgs : EventArgs
		{
			public int Column { get; set; }

			public Rectangle ColumnBounds { get; set; }
		}
	}
}