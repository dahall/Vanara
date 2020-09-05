using System.Collections.Generic;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	internal class ListViewColumnSorter : IComparer<ListViewItem>, System.Collections.IComparer
	{
		private System.Collections.CaseInsensitiveComparer ObjectCompare = new System.Collections.CaseInsensitiveComparer(System.Globalization.CultureInfo.InvariantCulture);

		public ListViewColumnSorter()
		{
			Group = false;
			NewSortSameColumn = false;
			Order = SortOrder.Descending;
			SortColumn = 1;
		}

		public bool Group { get; set; }

		public bool NewSortSameColumn { get; set; }

		public SortOrder Order { get; set; }

		public int SortColumn { get; set; }

		public int Compare(ListViewItem listviewX, ListViewItem listviewY)
		{
			// Compare the two items, checking tags first
			int compareResult = 0;
			if (listviewX.SubItems[SortColumn].Tag != null && listviewY.SubItems[SortColumn].Tag != null)
				compareResult = ObjectCompare.Compare(listviewX.SubItems[SortColumn].Tag, listviewY.SubItems[SortColumn].Tag);
			else
				compareResult = ObjectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);

			return AdjustCompareForOrder(compareResult);
		}

		public void ResortOnColumn(int column)
		{
			if (column == SortColumn)
			{
				// Reverse the current sort direction for this column.
				Order = Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
				NewSortSameColumn = true;
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				SortColumn = column;
				Order = SortOrder.Ascending;
				NewSortSameColumn = false;
			}
		}

		int System.Collections.IComparer.Compare(object x, object y)
		{
			if (x is ListViewItem && y is ListViewItem)
				return Compare((ListViewItem)x, (ListViewItem)y);
			if (x.GetType() == y.GetType())
			{
				var props = ListBindingHelper.GetListItemProperties(x);
				if (props != null && props.Count > SortColumn)
				{
					return AdjustCompareForOrder(ObjectCompare.Compare(props[SortColumn].GetValue(x), props[SortColumn].GetValue(y)));
				}
			}
			return ObjectCompare.Compare(x, y);
		}

		private int AdjustCompareForOrder(int compareResult)
		{
			// Calculate correct return value based on object comparison
			if (Order == SortOrder.Ascending)
				return compareResult;
			else if (Order == SortOrder.Descending)
				return (-compareResult);
			return 0;
		}
	}
}