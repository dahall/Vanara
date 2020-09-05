using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	[ListBindable(false), XmlRoot("Columns"), System.Configuration.SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml), Serializable]
	public class ColumnHeaderExCollection : IList<ColumnHeaderEx>, IList, IXmlSerializable
	{
		private ListView.ColumnHeaderCollection list;
		private ListViewEx listView;

		internal ColumnHeaderExCollection()
		{
		}

		internal ColumnHeaderExCollection(ListViewEx listView)
		{
			ListView = listView;
		}

		public int Count => list.Count;

		bool ICollection.IsSynchronized => true;

		object ICollection.SyncRoot => this;

		bool IList.IsFixedSize => false;

		public bool IsReadOnly => false;

		internal ListViewEx ListView
		{
			get { return listView; }
			set
			{
				listView = value;
				list = value.BaseColumns;
			}
		}

		object IList.this[int index]
		{
			get { return ((IList<ColumnHeaderEx>)this)[index]; }
			set { if (!(value is ColumnHeaderEx)) throw new ArgumentException("Only items of type ColumnHeaderEx can be added to the collection."); ((IList<ColumnHeaderEx>)this)[index] = value as ColumnHeaderEx; }
		}

		ColumnHeaderEx IList<ColumnHeaderEx>.this[int index]
		{
			get { return this[index]; }
			set
			{
				if (index >= list.Count)
					throw new IndexOutOfRangeException();
				list.RemoveAt(index);
				list.Insert(index, value);
			}
		}

		public ColumnHeaderEx this[int index] => list[index] as ColumnHeaderEx;

		public ColumnHeaderEx this[string key] => list[key] as ColumnHeaderEx;

		public int Add(ColumnHeaderEx item) => list.Add(item);

		public ColumnHeaderEx Add(string text) => AddInternal(null, text);

		public ColumnHeaderEx Add(string text, int width) => AddInternal(null, text, width);

		public ColumnHeaderEx Add(string key, string text) => AddInternal(key, text);

		public ColumnHeaderEx Add(string text, int width, HorizontalAlignment textAlign) => AddInternal(null, text, width, textAlign);

		public ColumnHeaderEx Add(string key, string text, int width) => AddInternal(key, text, width);

		public ColumnHeaderEx Add(string key, string text, int width, HorizontalAlignment textAlign, int imageIndex)
		{
			var hdr = AddInternal(key, text, width, textAlign);
			hdr.ImageIndex = imageIndex;
			return hdr;
		}

		public ColumnHeaderEx Add(string key, string text, int width, HorizontalAlignment textAlign, string imageKey)
		{
			var hdr = AddInternal(key, text, width, textAlign);
			hdr.ImageKey = imageKey;
			return hdr;
		}

		private ColumnHeaderEx AddInternal(string key, string text, int width = 60, HorizontalAlignment textAlign = HorizontalAlignment.Left)
		{
			var hdr = new ColumnHeaderEx() { Text = text, Name = key, Width = width, TextAlign = textAlign };
			list.Add(hdr);
			return hdr;
		}

		public void AddRange(ColumnHeaderEx[] values)
		{
			AddRange(values as IEnumerable<ColumnHeaderEx>);
		}

		public void AddRange(IEnumerable<ColumnHeaderEx> items)
		{
			listView.BeginUpdate();
			foreach (var item in items)
				Add(item);
			listView.EndUpdate();
		}

		public void AddRange(IEnumerable<string> items)
		{
			listView.BeginUpdate();
			foreach (var item in items)
				Add(item);
			listView.EndUpdate();
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool Contains(ColumnHeaderEx item) => list.Contains(item);

		public bool ContainsKey(string key) => list.ContainsKey(key);

		public void CopyTo(ColumnHeaderEx[] array, int arrayIndex)
		{
			if (list.Count + arrayIndex > array.Length)
				throw new ArgumentOutOfRangeException();
			for (int i = 0; i < list.Count; i++)
				array[i + arrayIndex] = list[i] as ColumnHeaderEx;
		}

		public System.Collections.Generic.IEnumerator<ColumnHeaderEx> GetEnumerator() => list.Cast<ColumnHeaderEx>().GetEnumerator();

		void ICollection.CopyTo(Array array, int index)
		{
			if (Count > 0)
				Array.Copy(this.ToArray(), 0, array, index, Count);
		}

		void ICollection<ColumnHeaderEx>.Add(ColumnHeaderEx item)
		{
			list.Add(item);
		}

		bool ICollection<ColumnHeaderEx>.Remove(ColumnHeaderEx item)
		{
			int idx = IndexOf(item);
			if (idx == -1)
				return false;
			list.RemoveAt(idx);
			return true;
		}

		int IList.Add(object value)
		{
			if (!(value is ColumnHeaderEx))
				throw new ArgumentException();
			return Add((ColumnHeaderEx)value);
		}

		bool IList.Contains(object value)
		{
			if (!(value is ColumnHeaderEx))
				throw new ArgumentException();
			return Contains((ColumnHeaderEx)value);
		}

		int IList.IndexOf(object value)
		{
			if (!(value is ColumnHeaderEx))
				throw new ArgumentException();
			return IndexOf((ColumnHeaderEx)value);
		}

		void IList.Insert(int index, object value)
		{
			if (!(value is ColumnHeaderEx))
				throw new ArgumentException();
			Insert(index, (ColumnHeaderEx)value);
		}

		void IList.Remove(object value)
		{
			if (!(value is ColumnHeaderEx))
				throw new ArgumentException();
			Remove((ColumnHeaderEx)value);
		}

		public int IndexOf(ColumnHeaderEx item) => list.IndexOf(item);

		public int IndexOfKey(string key) => list.IndexOfKey(key);

		public void Insert(int index, ColumnHeaderEx item)
		{
			list.Insert(index, item);
		}

		public void Insert(int index, string text)
		{
			var hdr = new ColumnHeaderEx() { Text = text };
			Insert(index, hdr);
		}

		public void Insert(int index, string text, int width)
		{
			var hdr = new ColumnHeaderEx() { Text = text, Width = width };
			Insert(index, hdr);
		}

		public void Insert(int index, string key, string text)
		{
			var hdr = new ColumnHeaderEx() { Text = text, Name = key };
			Insert(index, hdr);
		}

		public void Insert(int index, string text, int width, HorizontalAlignment textAlign)
		{
			var hdr = new ColumnHeaderEx() { Text = text, Width = width, TextAlign = textAlign };
			Insert(index, hdr);
		}

		public void Insert(int index, string key, string text, int width)
		{
			var hdr = new ColumnHeaderEx() { Text = text, Name = key, Width = width };
			Insert(index, hdr);
		}

		public void Insert(int index, string key, string text, int width, HorizontalAlignment textAlign, int imageIndex)
		{
			var hdr = new ColumnHeaderEx() { Text = text, Name = key, Width = width, TextAlign = textAlign, ImageIndex = imageIndex };
			Insert(index, hdr);
		}

		public void Insert(int index, string key, string text, int width, HorizontalAlignment textAlign, string imageKey)
		{
			var hdr = new ColumnHeaderEx() { Text = text, Name = key, Width = width, TextAlign = textAlign, ImageKey = imageKey };
			Insert(index, hdr);
		}

		System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema() => null;

		void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
		{
			reader.MoveToContent();
			int count = Convert.ToInt32(reader.GetAttribute("Count"));
			if (count == Count)
			{
				for (int i = 0; i < count; i++)
				{
					reader.ReadStartElement("Column");
					string attr = reader.GetAttribute("DisplayIndex");
					if (!string.IsNullOrEmpty(attr))
						this[i].DisplayIndex = Convert.ToInt32(attr);
					attr = reader.GetAttribute("Width");
					if (!string.IsNullOrEmpty(attr))
						this[i].Width = Convert.ToInt32(attr);
					attr = reader.GetAttribute("SortOrder");
					if (!string.IsNullOrEmpty(attr))
						this[i].SortOrder = (SortOrder)Enum.Parse(typeof(SortOrder), attr);
					reader.ReadEndElement();
				}
			}
		}

		void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
		{
			writer.WriteAttributeString("Count", Count.ToString());
			for (int i = 0; i < Count; i++)
			{
				writer.WriteStartElement("Column");
				writer.WriteAttributeString("Index", i.ToString());
				if (this[i].DisplayIndex != -1)
					writer.WriteAttributeString("DisplayIndex", this[i].DisplayIndex.ToString());
				writer.WriteAttributeString("Width", this[i].Width.ToString());
				if (this[i].SortOrder != SortOrder.None)
					writer.WriteAttributeString("SortOrder", this[i].SortOrder.ToString());
				writer.WriteEndElement();
			}
		}

		public void Remove(ColumnHeaderEx item)
		{
			list.Remove((ColumnHeader)item);
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}

		public void RemoveByKey(string key)
		{
			list.RemoveByKey(key);
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	internal class ColumnHeaderExCollectionEditor : CollectionEditor
	{
		public ColumnHeaderExCollectionEditor(Type type) : base(type)
		{
		}

		protected override string HelpTopic => "net.ComponentModel.ColumnHeaderCollectionEditor";

		protected override Type CreateCollectionItemType() => typeof(ColumnHeaderEx);

		/*internal override void OnItemRemoving(object item)
		{
			ListView instance = base.Context.Instance as ListView;
			if (instance != null)
			{
				ColumnHeaderEx column = item as ColumnHeaderEx;
				if (column != null)
				{
					IComponentChangeService service = base.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
					PropertyDescriptor member = null;
					if (service != null)
					{
						member = TypeDescriptor.GetProperties(base.Context.Instance)["Columns"];
						service.OnComponentChanging(base.Context.Instance, member);
					}
					instance.Columns.Remove(column);
					if ((service != null) && (member != null))
					{
						service.OnComponentChanged(base.Context.Instance, member, null, null);
					}
				}
			}
		}*/

		protected override object SetItems(object editValue, object[] value)
		{
			if (editValue != null)
			{
				ColumnHeaderExCollection headers = editValue as ColumnHeaderExCollection;
				if (headers != null)
				{
					headers.Clear();
					ColumnHeaderEx[] destinationArray = new ColumnHeaderEx[value.Length];
					Array.Copy(value, 0, destinationArray, 0, value.Length);
					headers.AddRange(destinationArray);
				}
			}
			return editValue;
		}
	}
}