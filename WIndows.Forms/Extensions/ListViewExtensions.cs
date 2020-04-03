using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="ListView"/>.</summary>
	public static partial class ListViewExtension
	{
		private static PropertyInfo GroupIdProperty;

		/// <summary>Gets the items in a list view as a sequence.</summary>
		/// <param name="items">The items.</param>
		/// <returns></returns>
		public static IEnumerable<ListViewItem> AsEnumerable(this ListView.ListViewItemCollection items)
		{
			foreach (ListViewItem item in items)
				yield return item;
		}

		/// <summary>Gets the groups in a list view as a sequence.</summary>
		/// <param name="items">The items.</param>
		/// <returns></returns>
		public static IEnumerable<ListViewGroup> AsEnumerable(this ListViewGroupCollection items)
		{
			foreach (ListViewGroup item in items)
				yield return item;
		}

		/// <summary>Performs an action on every item in a list view.</summary>
		/// <param name="items">The items.</param>
		/// <param name="action">The action.</param>
		public static void ForEach(this ListView.ListViewItemCollection items, Action<ListViewItem> action)
		{
			foreach (ListViewItem item in items) action(item);
		}

		/// <summary>Gets the collapsed state of the list view group.</summary>
		/// <param name="group">The list view group.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static bool GetCollapsed(this ListViewGroup group)
		{
			if (group == null)
				throw new ArgumentNullException();
			return GetState(group, ListViewGroupState.LVGS_NORMAL | ListViewGroupState.LVGS_COLLAPSED);
		}

		/// <summary>Determines if the list view group is collapsible.</summary>
		/// <param name="group">The group.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static bool GetCollapsible(this ListViewGroup group)
		{
			if (group == null)
				throw new ArgumentNullException();
			return IsWinVista() && GetState(group, ListViewGroupState.LVGS_COLLAPSIBLE);
		}

		/// <summary>Gets the handle of the list view header.</summary>
		/// <param name="listView">The list view.</param>
		/// <returns></returns>
		public static IntPtr GetHeaderHandle(this ListView listView)
		{
			if (listView.IsHandleCreated)
				return SendMessage(listView.Handle, (uint)ListViewMessage.LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
			return IntPtr.Zero;
		}

		/// <summary>Invalidates the header.</summary>
		/// <param name="listView">The list view.</param>
		public static void InvalidateHeader(this ListView listView)
		{
			if (listView.IsHandleCreated && listView.View == View.Details)
				InvalidateRect(GetHeaderHandle(listView), null, true);
		}

		/// <summary>Sets the collapsed state of the list view group.</summary>
		/// <param name="group">The group.</param>
		/// <param name="value">if set to <see langword="true"/> [value].</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static void SetCollapsed(this ListViewGroup group, bool value)
		{
			if (group == null)
				throw new ArgumentNullException();
			SetState(group, ListViewGroupState.LVGS_NORMAL | ListViewGroupState.LVGS_COLLAPSED, value);
		}

		/// <summary>Sets a value that determines if the list view group is collapsible.</summary>
		/// <param name="group">The group.</param>
		/// <param name="value">if set to <see langword="true"/> [value].</param>
		/// <exception cref="System.ArgumentNullException"></exception>
		/// <exception cref="System.PlatformNotSupportedException"></exception>
		public static void SetCollapsible(this ListViewGroup group, bool value)
		{
			if (group == null)
				throw new ArgumentNullException();
			if (!IsWinVista())
				throw new PlatformNotSupportedException();
			SetState(group, ListViewGroupState.LVGS_COLLAPSIBLE, value);
		}

		/// <summary>Sets a list view header column to display as a split button or not.</summary>
		/// <param name="listView">The list view.</param>
		/// <param name="columnIndex">Index of the column.</param>
		/// <param name="enable">if set to <see langword="true"/> show the column header as a split button.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">columnIndex</exception>
		public static void SetColumnDropDown(this ListView listView, int columnIndex, bool enable)
		{
			if (((columnIndex < 0) || ((columnIndex >= 0) && (listView.Columns == null))) || (columnIndex >= listView.Columns.Count))
				throw new ArgumentOutOfRangeException(nameof(columnIndex));

			if (listView.IsHandleCreated)
			{
				var lvc = new LVCOLUMN(ListViewColumMask.LVCF_FMT);
				var hr = listView.Handle;
				SendMessage(hr, ListViewMessage.LVM_GETCOLUMN, columnIndex, lvc);
				lvc.Format = lvc.Format.SetFlags(ListViewColumnFormat.LVCFMT_SPLITBUTTON, enable);
				SendMessage(hr, ListViewMessage.LVM_SETCOLUMN, columnIndex, lvc);
				listView.InvalidateHeader();
			}
		}

		/// <summary>Enables or disables the Explorer theme on a list view.</summary>
		/// <param name="listView">The list view.</param>
		/// <param name="on">if set to <see langword="true"/> [on].</param>
		public static void SetExplorerTheme(this ListView listView, bool on = true)
		{
			if (IsWinVista())
			{
				listView.SetWindowTheme(on ? "explorer" : null);
				if (!on) return;
				SendMessage(listView.Handle, (uint)ListViewMessage.LVM_SETEXTENDEDLISTVIEWSTYLE, (IntPtr)ListViewStyleEx.LVS_EX_DOUBLEBUFFER, (IntPtr)ListViewStyleEx.LVS_EX_DOUBLEBUFFER);
			}
		}

		/// <summary>Sets the footer text and alignment for a list view group.</summary>
		/// <param name="group">The group.</param>
		/// <param name="footer">The footer text.</param>
		/// <param name="footerAlignment">The footer alignment.</param>
		public static void SetFooter(this ListViewGroup group, string footer = null, HorizontalAlignment footerAlignment = HorizontalAlignment.Left)
		{
			var groupId = GetGroupId(group);
			if (groupId >= 0)
			{
				using var lvgroup = new LVGROUP { Footer = footer, Alignment = MakeAlignment(group.HeaderAlignment, footerAlignment) };
				SendMessage(group.ListView.Handle, ListViewMessage.LVM_SETGROUPINFO, groupId, lvgroup);
			}
		}

		/// <summary>Sets the image list to use for a list view group.</summary>
		/// <param name="group">The group.</param>
		/// <param name="imageList">The image list.</param>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static void SetGroupImageList(this ListViewGroup group, ImageList imageList)
		{
			if (!group.ListView.IsHandleCreated)
				throw new InvalidOperationException();
			var lparam = imageList?.Handle ?? IntPtr.Zero;
			SendMessage(group.ListView.Handle, (uint)ListViewMessage.LVM_SETIMAGELIST, (IntPtr)3, lparam);
		}

		/// <summary>Sets the image index from the image list to use for a list view group.</summary>
		/// <param name="group">The group.</param>
		/// <param name="titleImageIndex">Index of the title image.</param>
		/// <param name="descriptionTop">The description top.</param>
		/// <param name="descriptionBottom">The description bottom.</param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static void SetImage(this ListViewGroup group, int titleImageIndex, string descriptionTop = null, string descriptionBottom = null)
		{
			var groupId = GetGroupId(group);
			if (groupId >= 0)
			{
				using var lvgroup = new LVGROUP { TitleImageIndex = titleImageIndex };
				if (descriptionBottom != null)
					lvgroup.DescriptionBottom = descriptionBottom;
				if (descriptionTop != null)
					lvgroup.DescriptionTop = descriptionTop;
				SendMessage(group.ListView.Handle, ListViewMessage.LVM_SETGROUPINFO, groupId, lvgroup);
			}
		}

		/// <summary>Sets the overlay image for an item in a list view.</summary>
		/// <param name="lvi">The list view item.</param>
		/// <param name="imageIndex">Index of the image.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">imageIndex</exception>
		/// <exception cref="System.ArgumentNullException">lvi - ListViewItem must be attached to a valid ListView.</exception>
		/// <exception cref="Win32Exception"></exception>
		public static void SetOverlayImage(this ListViewItem lvi, int imageIndex)
		{
			if (imageIndex < 1 || imageIndex > 15)
				throw new ArgumentOutOfRangeException(nameof(imageIndex));
			if (lvi.ListView == null)
				throw new ArgumentNullException(nameof(lvi), @"ListViewItem must be attached to a valid ListView.");
			var nItem = new LVITEM(lvi.Index) { OverlayImageIndex = (uint)imageIndex };
			if (SendMessage(lvi.ListView.Handle, ListViewMessage.LVM_SETITEM, 0, nItem).ToInt32() == 0)
				throw new Win32Exception();
		}

		/// <summary>Sets the sort icon displayed on a list view header column.</summary>
		/// <param name="listView">The list view.</param>
		/// <param name="columnIndex">Index of the column.</param>
		/// <param name="order">The sort order icon to display.</param>
		public static void SetSortIcon(this ListView listView, int columnIndex, SortOrder order)
		{
			var columnHeader = (HWND)SendMessage(listView.Handle, (uint)ListViewMessage.LVM_GETHEADER);

			for (var columnNumber = 0; columnNumber <= listView.Columns.Count - 1; columnNumber++)
			{
				// Get current ListView column info
				var lvcol = new LVCOLUMN(ListViewColumMask.LVCF_FMT);
				SendMessage(listView.Handle, ListViewMessage.LVM_GETCOLUMN, columnNumber, lvcol);

				// Get current header info
				var hditem = new HDITEM(HeaderItemMask.HDI_FORMAT | HeaderItemMask.HDI_DI_SETITEM);
				SendMessage(columnHeader, HeaderMessage.HDM_GETITEM, columnNumber, hditem);

				// Update header with column info
				hditem.Format |= (HeaderItemFormat)((uint)lvcol.Format & 0x1001803);
				if ((lvcol.Format & ListViewColumnFormat.LVCFMT_NO_TITLE) == 0)
					hditem.ShowText = true;

				// Set header image info
				if (order != SortOrder.None && columnNumber == columnIndex)
					hditem.ImageDisplay = (order == SortOrder.Descending) ? HeaderItemImageDisplay.DownArrow : HeaderItemImageDisplay.UpArrow;
				else
					hditem.ImageDisplay = HeaderItemImageDisplay.None;

				// Update header
				SendMessage(columnHeader, HeaderMessage.HDM_SETITEM, columnNumber, hditem);
			}
		}

		/// <summary>Sets the task link for a list view group.</summary>
		/// <param name="group">The group.</param>
		/// <param name="taskLink">The task link.</param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static void SetTask(this ListViewGroup group, string taskLink)
		{
			var groupId = GetGroupId(group);
			if (groupId >= 0)
			{
				using var lvgroup = new LVGROUP { TaskLink = taskLink };
				SendMessage(group.ListView.Handle, ListViewMessage.LVM_SETGROUPINFO, groupId, lvgroup);
			}
		}

		private static void ApplyGroupingSet<T>(this ListView listView, ListViewGroupingSet<T> set, string nonMatchingGroupName = "Other") where T : class
		{
			var vm = listView.VirtualMode;
			listView.BeginUpdate();
			if (vm)
				listView.VirtualMode = false;
			listView.Groups.Clear();
			listView.Groups.AddRange(set.Groups);
			var other = new List<ListViewItem>();
			foreach (ListViewItem i in listView.Items)
			{
				var found = false;
				for (var r = 0; r < set.Conditions.Length; r++)
				{
					if (set.Conditions[r](i))
					{
						listView.Groups[r].Items.Add(i);
						found = true;
						break;
					}
				}
				if (!found)
					other.Add(i);
			}
			if (other.Count > 0 && !string.IsNullOrEmpty(nonMatchingGroupName))
			{
				var og = listView.Groups.Add(nonMatchingGroupName, nonMatchingGroupName);
				og.Items.AddRange(other.ToArray());
			}
			if (vm)
				listView.VirtualMode = true;
			listView.ShowGroups = true;
			listView.EndUpdate();
		}

		private static int GetGroupId(ListViewGroup group)
		{
			if (GroupIdProperty == null)
				GroupIdProperty = typeof(ListViewGroup).GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance);
			return (int?)GroupIdProperty?.GetValue(group, null) ?? -1;
		}

		private static bool GetState(ListViewGroup group, ListViewGroupState state)
		{
			var groupId = GetGroupId(group);
			if (groupId < 0)
				return false;
			return (SendMessage(group.ListView.Handle, (uint)ListViewMessage.LVM_GETGROUPSTATE, (IntPtr)groupId, new IntPtr((int)state)).ToInt32() & (int)state) != 0;
		}

		private static bool IsWinVista() => Environment.OSVersion.Version.Major >= 6;

		private static ListViewGroupAlignment MakeAlignment(HorizontalAlignment hdr, HorizontalAlignment ftr)
		{
			var h = (hdr == HorizontalAlignment.Left ? ListViewGroupAlignment.LVGA_HEADER_LEFT : (hdr == HorizontalAlignment.Center ? ListViewGroupAlignment.LVGA_HEADER_CENTER : ListViewGroupAlignment.LVGA_HEADER_RIGHT));
			return h | (ftr == HorizontalAlignment.Left ? ListViewGroupAlignment.LVGA_FOOTER_LEFT : (ftr == HorizontalAlignment.Center ? ListViewGroupAlignment.LVGA_FOOTER_CENTER : ListViewGroupAlignment.LVGA_FOOTER_RIGHT));
		}

		private static void SetState(ListViewGroup group, ListViewGroupState state, bool value)
		{
			var groupId = GetGroupId(group);
			if (groupId >= 0)
			{
				var lvgroup = new LVGROUP(ListViewGroupMask.LVGF_STATE);
				{
					lvgroup.SetState(state, value);
					SendMessage(group.ListView.Handle, ListViewMessage.LVM_SETGROUPINFO, groupId, lvgroup);
				}
			}
		}
	}

	/// <summary>Takes a list of groups and matching predicates to be used by the ApplyGroupingSet extension method.</summary>
	/// <typeparam name="T">Type of the item that represents and can convert to a <see cref="ListViewGroup"/>.</typeparam>
	public class ListViewGroupingSet<T> where T : class
	{
		private readonly Converter<T, ListViewGroup> converter;
		private readonly List<KeyValuePair<T, Predicate<ListViewItem>>> list = new List<KeyValuePair<T, Predicate<ListViewItem>>>();

		/// <summary>Initializes a new instance of the <see cref="ListViewGroupingSet{T}"/> class.</summary>
		/// <param name="converter">
		/// The converter to take the <typeparamref name="T"/> and convert it to a <see cref="ListViewGroup"/>. If <typeparamref name="T"/>
		/// is not <see cref="ListViewGroup"/>, an exception is thrown.
		/// </param>
		/// <exception cref="System.InvalidCastException">Generic type T must be convertible to a ListViewGroup.</exception>
		public ListViewGroupingSet(Converter<T, ListViewGroup> converter = null)
		{
			if (converter != null)
				this.converter = converter;
			else
			{
				if (typeof(T) == typeof(ListViewGroup))
					this.converter = a => a as ListViewGroup;
				else
				{
					var tc = TypeDescriptor.GetConverter(typeof(T));
					if (!tc.CanConvertTo(typeof(ListViewGroup)))
						throw new InvalidCastException("Generic type T must be convertible to a ListViewGroup.");
					this.converter = t => (ListViewGroup)tc.ConvertTo(t, typeof(ListViewGroup));
				}
			}
		}

		internal Predicate<ListViewItem>[] Conditions => list.ConvertAll(kvp => kvp.Value).ToArray();
		internal ListViewGroup[] Groups => list.ConvertAll(kvp => converter(kvp.Key)).ToArray();

		/// <summary>Adds the specified group and matching condition to the set.</summary>
		/// <param name="group">The group.</param>
		/// <param name="condition">The condition for <see cref="ListViewItem"/> instances to be added to the group.</param>
		public void Add(T group, Predicate<ListViewItem> condition)
		{
			list.Add(new KeyValuePair<T, Predicate<ListViewItem>>(group, condition));
		}
	}
}