using System;
using Vanara.PInvoke;
using System.ComponentModel;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms
{
	public partial class ListViewEx : ListView
	{
		private bool collapsible = false;
		private ListViewGroupEx defaultGroup;
		private ListViewGroupExCollection groups;

		[DefaultValue(false), Category("Behavior")]
		public bool CollapsibleGroups
		{
			get { return collapsible; }
			set
			{
				if (value != collapsible)
				{
					collapsible = value;
					SetAllGroupState(ListViewGroupState.Collapsible | ListViewGroupState.Normal, collapsible);
				}
			}
		}

		[MergableProperty(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Behavior"), Localizable(true), Editor(typeof(ListViewGroupExCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public new ListViewGroupExCollection Groups
		{
			get
			{
				if (groups == null)
					groups = new ListViewGroupExCollection(this);
				return groups;
			}
		}

		internal ListViewGroupCollection BaseGroups => base.Groups;

		internal ListViewGroupEx DefaultGroup
		{
			get
			{
				if (defaultGroup == null)
					defaultGroup = new ListViewGroupEx();
				return defaultGroup;
			}
		}

		internal bool GroupsEnabled => (((ShowGroups && (groups != null)) && ((groups.Count > 0) && ComctlSupportsVisualStyles)) && !VirtualMode);

		internal int GetGroupId(int groupIndex)
		{
			if (IsHandleCreated)
			{
				try
				{
					LVGROUP mgroup = new LVGROUP(ListViewGroupMask.GroupId);
					if (0 != SendMessage(ListViewMessage.GetGroupInfoByIndex, groupIndex, mgroup))
						return mgroup.ID;
				}
				catch { }
			}
			return -1;
		}

		internal LVGROUP GetGroupInfo(int groupIndex, ListViewGroupMask mask)
		{
			if (IsHandleCreated)
			{
				try
				{
					LVGROUP mgroup = new LVGROUP(mask);
					if (0 != SendMessage(ListViewMessage.GetGroupInfoByIndex, groupIndex, mgroup))
						return mgroup;
				}
				catch { }
			}
			return null;
		}

		internal ListViewGroupState GetGroupState(ListViewGroupEx group, ListViewGroupState stateMask = (ListViewGroupState)0xFF) => (ListViewGroupState)SendMessage(ListViewMessage.GetGroupState, GetGroupId(Groups.IndexOf(group)), new IntPtr((int)stateMask));

		internal void InsertGroupInListView(int index, ListViewGroupEx group)
		{
			UpdateGroupView();
			EnsureDefaultGroup();
			InsertGroupNative(index, group);
			if ((groups.Count == 1) && GroupsEnabled)
			{
				this.CallWhenHandleValid(c =>
				{
					foreach (ListViewItem item in Items)
					{
						if (item.Group == null)
						{
							var lvItem = new LVITEM(index);
							lvItem.GroupId = group.ID;
							User32.SendMessage(Handle, ListViewMessage.SetItem, 0, lvItem);
						}
					}
				});
			}
		}

		internal void RemoveGroupFromListView(ListViewGroupEx group)
		{
			EnsureDefaultGroup();
			foreach (ListViewItem item in group.Items)
			{
				if (item.ListView == this)
					UpdateItem(new LVITEM(item.Index) { GroupId = I_GROUPIDNONE });
			}
			RemoveGroupNative(group);
			UpdateGroupView();
		}

		internal void SetGroupState(ListViewGroupEx group, ListViewGroupState item, bool value)
		{
			LVGROUP mgroup = new LVGROUP(ListViewGroupMask.State);
			mgroup.SetState(item, value);
			this.CallWhenHandleValid(c => SendMessage(ListViewMessage.SetGroupInfo, group.ID, mgroup));
		}

		internal void UpdateGroupNative(ListViewGroupEx group, bool invalidate = true)
		{
			LVGROUP nGroup = group.AsLVGROUP();
			nGroup.SetState(ListViewGroupState.Collapsible, collapsible);
			this.CallWhenHandleValid(c => { SendMessage(ListViewMessage.SetGroupInfo, group.ID, nGroup); if (invalidate) base.Invalidate(); });
		}

		internal void UpdateGroupView()
		{
			if (ComctlSupportsVisualStyles)
				this.CallWhenHandleValid(c => SendMessage(ListViewMessage.EnableGroupView, GroupsEnabled ? 1 : 0, IntPtr.Zero));
		}

		private void EnsureDefaultGroup()
		{
			if ((base.IsHandleCreated && ComctlSupportsVisualStyles) && (GroupsEnabled && (SendMessage(ListViewMessage.HasGroup, DefaultGroup.ID, IntPtr.Zero) == 0)))
			{
				UpdateGroupView();
				InsertGroupNative(0, DefaultGroup);
			}
		}

		private void InsertGroupNative(int index, ListViewGroupEx group)
		{
			this.CallWhenHandleValid(c => this.SendMessage(ListViewMessage.InsertGroup, index, group.AsLVGROUP()));
		}

		private void OnHandleCreated_Groups(EventArgs e)
		{
			if (groups != null)
			{
				for (int i = 0; i < groups.Count; i++)
					UpdateGroupNative(groups[i], false);
			}
		}

		private void RemoveGroupNative(ListViewGroupEx group)
		{
			this.CallWhenHandleValid(c => SendMessage(ListViewMessage.RemoveGroup, group.ID, IntPtr.Zero));
		}

		private int SendMessage(ListViewMessage msg, int wParam, LVGROUP group) => User32.SendMessage(Handle, msg, wParam, group).ToInt32();

		private void SetAllGroupState(ListViewGroupState state, bool on = true)
		{
			if (IsHandleCreated)
			{
				LVGROUP group = new LVGROUP(ListViewGroupMask.State);
				group.SetState(state, on);
				//group.Subtitle = "Dog";

				for (int i = 0; i < Groups.Count; i++)
					SendMessage(ListViewMessage.SetGroupInfo, i, group);

				using (LVGROUP grp = new LVGROUP(ListViewGroupMask.Subtitle))
				{
					int res = SendMessage(ListViewMessage.GetGroupInfoByIndex, 0, grp);
					if (res >= 0)
						System.Diagnostics.Debug.WriteLine(grp.Subtitle);
				}

				RecreateHandle();
			}
		}
	}
}