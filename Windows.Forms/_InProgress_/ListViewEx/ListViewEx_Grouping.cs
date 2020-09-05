using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// Defines a model for grouping <see cref="ListViewItem"/> elements.
	/// </summary>
	public class ListViewGroupingModel
	{
		/// <summary>
		/// Gets or sets the delegate to run on each <see cref="ListViewItem"/> that assigns to a group.
		/// </summary>
		/// <value>
		/// The delegate that adds an item to a group.
		/// </value>
		public Action<ListViewItem, int, List<ListViewGroupEx>> AddItemToGroup { get; set; }

		/// <summary>
		/// Gets the list of groups that is passed to the <see cref="AddItemToGroup"/> method. This can and should be ignored if the <see cref="GroupBuilder"/> delegate is defined.
		/// </summary>
		/// <value>
		/// The list of groups.
		/// </value>
		public List<ListViewGroupEx> Groups { get; } = new List<ListViewGroupEx>();

		/// <summary>
		/// Gets or sets a delegate used to build groups from the set of <see cref="ListViewItem"/> elements. Defining this delegate will cause the <see cref="Groups"/> property to be cleared.
		/// </summary>
		/// <value>
		/// The group builder delegate.
		/// </value>
		public Func<IEnumerable<ListViewItem>, int, IEnumerable<ListViewGroupEx>> GroupBuilder { get; set; }

		/// <summary>
		/// The default grouping model that will find all distinct entries for a column and then create groups for each and assign items to them.
		/// </summary>
		public static ListViewGroupingModel Default = new ListViewGroupingModel
		{
			GroupBuilder = DistinctItemGroupBuilder,
			AddItemToGroup = SubitemMathesGroupKeyAdder,
		};

		private static void SubitemMathesGroupKeyAdder(ListViewItem item, int colIdx, List<ListViewGroupEx> groups)
		{
			var grp = groups.Find(g => g.Name == item.SubItems[colIdx].Text);
			if (grp == null)
				throw new InvalidOperationException($"A group with key {item.SubItems[colIdx].Text} must exist.");
			grp.Items.Add(item);
		}

		private static IEnumerable<ListViewGroupEx> DistinctItemGroupBuilder(IEnumerable<ListViewItem> items, int colIdx)
		{
			var ret = new List<ListViewGroupEx>();
			foreach (var s in DistinctBy(items, i => i.SubItems[colIdx].Text))
				ret.Add(new ListViewGroupEx(s, s));
			return ret;
		}

		internal static IEnumerable<TKey> DistinctBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			var knownKeys = new HashSet<TKey>();
			foreach (TSource item in source)
				knownKeys.Add(keySelector(item));
			return knownKeys;
		}
	}

	public partial class ColumnHeaderEx
	{
		public ListViewGroupingModel GroupingModel
		{
			get { return Extras.GroupingInfo as ListViewGroupingModel; }
			set { Extras.GroupingInfo = value; }
		}
	}

	public partial class ListViewEx : ListView
	{
		/// <summary>
		/// Groups this instance.
		/// </summary>
		public virtual void GroupOnColumn(int columnIndex)
		{
			ListViewGroupingModel model = null; // DefaultGroupingModel;
			if (View == View.Details && columnIndex < Columns.Count && Columns[columnIndex].GroupingModel != null)
				model = Columns[columnIndex].GroupingModel;
			if (!VirtualMode && model?.AddItemToGroup != null && ShowGroups && Items.Count > 0)
			{
				BeginUpdate();
				if (model.GroupBuilder != null)
				{
					model.Groups.Clear();
					foreach (var g in model.GroupBuilder(Items, columnIndex))
						model.Groups.Add(g);
				}
				foreach (ListViewItem i in Items)
					model.AddItemToGroup(i, columnIndex, model.Groups);
				EndUpdate();
			}
		}

		/// <summary>
		/// Removes the empty groups.
		/// </summary>
		public virtual void RemoveEmptyGroups()
		{
			for (int i = Groups.Count - 1; i >= 0; i--)
			{
				if (Groups[i].Items.Count == 0)
					Groups.RemoveAt(i);
			}
		}
	}
}