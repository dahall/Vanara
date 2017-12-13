using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Vanara.Windows.Forms
{
	[ListBindable(false)]
	public class ListViewGroupExCollection : IList<ListViewGroupEx>, IList
	{
		private ListViewEx listView;
		private List<ListViewGroupEx> groups = new List<ListViewGroupEx>();

		internal ListViewGroupExCollection(ListViewEx listView) : base()
		{
			this.listView = listView;
		}

		public int Count => listView.BaseGroups.Count;

		public bool IsReadOnly => false;

		public ListViewGroupEx this[int index]
		{
			get { return groups[index]; }
			set
			{
				listView.BaseGroups[index] = value.BaseGroup;
				groups[index] = value;
			}
		}

		public ListViewGroupEx this[string key]
		{
			get { return groups.Find(g => string.Compare(key, g.Name, false, CultureInfo.CurrentCulture) == 0); }
			set
			{
				int num = groups.FindIndex(g => string.Compare(key, g.Name, false, CultureInfo.CurrentCulture) == 0);
				if (num == -1)
					throw new ArgumentOutOfRangeException(nameof(key));
				this[num] = value;
			}
		}

		public int Add(ListViewGroupEx group)
		{
			if (Contains(group))
				return -1;

			group.ListView = listView;
			groups.Add(group);
			return listView.BaseGroups.Add(group.BaseGroup);
		}

		public ListViewGroupEx Add(string key, string headerText)
		{
			var g = listView.BaseGroups.Add(key, headerText);
			var gx = new ListViewGroupEx(key, headerText) { BaseGroup = g };
			groups.Add(gx);
			return gx;
		}

		public void AddRange(IEnumerable<ListViewGroupEx> items)
		{
			listView.BeginUpdate();
			foreach (var item in items)
				Add(item);
			listView.EndUpdate();
		}

		public void Clear()
		{
			groups.Clear();
			listView.BaseGroups.Clear();
		}

		public bool Contains(ListViewGroupEx item) => groups.Contains(item);

		public void CopyTo(ListViewGroupEx[] array, int arrayIndex)
		{
			groups.CopyTo(array, arrayIndex);
		}

		public IEnumerator<ListViewGroupEx> GetEnumerator() => groups.GetEnumerator();

		public int IndexOf(ListViewGroupEx item) => groups.IndexOf(item);

		public void Insert(int index, ListViewGroupEx item)
		{
			listView.BaseGroups.Insert(index, item.BaseGroup);
			groups.Insert(index, item);
		}

		public bool Remove(ListViewGroupEx group)
		{
			try
			{
				groups.Remove(group);
				listView.BaseGroups.Remove(group.BaseGroup);
				return true;
			}
			catch { }
			return false;
		}

		public void RemoveAt(int index)
		{
			Remove(this[index]);
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		int IList.Add(object value)
		{
			if (!(value is ListViewGroupEx))
				throw new ArgumentException();
			return Add((ListViewGroupEx)value);
		}

		bool IList.Contains(object value)
		{
			if (!(value is ListViewGroupEx))
				throw new ArgumentException();
			return Contains((ListViewGroupEx)value);
		}

		int IList.IndexOf(object value)
		{
			if (!(value is ListViewGroupEx))
				throw new ArgumentException();
			return IndexOf((ListViewGroupEx)value);
		}

		void IList.Insert(int index, object value)
		{
			if (!(value is ListViewGroupEx))
				throw new ArgumentException();
			Insert(index, (ListViewGroupEx)value);
		}

		bool IList.IsFixedSize => false;

		void IList.Remove(object value)
		{
			if (!(value is ListViewGroupEx))
				throw new ArgumentException();
			Remove((ListViewGroupEx)value);
		}

		object IList.this[int index]
		{
			get { return this[index]; }
			set
			{
				if (!(value is ListViewGroupEx))
					throw new ArgumentException();
				this[index] = (ListViewGroupEx)value;
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (Count > 0)
				Array.Copy(groups.ToArray(), 0, array, index, Count);
		}

		bool ICollection.IsSynchronized => true;

		object ICollection.SyncRoot => this;

		void ICollection<ListViewGroupEx>.Add(ListViewGroupEx item)
		{
			Add(item);
		}
	}

	internal class ListViewGroupExCollectionEditor : CollectionEditor
	{
		private object editValue;

		public ListViewGroupExCollectionEditor(Type type) : base(type)
		{
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			editValue = value;
			object obj2 = base.EditValue(context, provider, value);
			editValue = null;
			return obj2;
		}

		protected override object CreateInstance(Type itemType)
		{
			ListViewGroupEx group = (ListViewGroupEx)base.CreateInstance(itemType);
			group.Name = CreateListViewGroupName((ListViewGroupExCollection)editValue);
			return group;
		}

		private string CreateListViewGroupName(ListViewGroupExCollection lvgCollection)
		{
			string str = "ListViewGroupEx";
			INameCreationService service = base.GetService(typeof(INameCreationService)) as INameCreationService;
			IContainer container = base.GetService(typeof(IContainer)) as IContainer;
			if ((service != null) && (container != null))
			{
				str = service.CreateName(container, typeof(ListViewGroupEx));
			}
			while (char.IsDigit(str[str.Length - 1]))
			{
				str = str.Substring(0, str.Length - 1);
			}
			int num = 1;
			string str2 = str + num.ToString(System.Globalization.CultureInfo.CurrentCulture);
			while (lvgCollection[str2] != null)
			{
				num++;
				str2 = str + num.ToString(System.Globalization.CultureInfo.CurrentCulture);
			}
			return str2;
		}
	}
}