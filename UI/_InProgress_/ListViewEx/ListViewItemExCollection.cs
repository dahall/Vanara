using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	public class ListViewItemExCollection : ListView.ListViewItemCollection, IEnumerable<ListViewItem>
	{
		public ListViewItemExCollection(ListView owner) : base(owner)
		{
		}

		IEnumerator<ListViewItem> IEnumerable<ListViewItem>.GetEnumerator() => this.AsEnumerable().GetEnumerator();
	}

	internal class ListViewItemExCollectionEditor : CollectionEditor
	{
		public ListViewItemExCollectionEditor(Type type) : base(type)
		{
		}

		protected override string GetDisplayText(object value)
		{
			string str;
			if (value == null)
				return string.Empty;

			var defaultProperty = TypeDescriptor.GetDefaultProperty(base.CollectionType);
			if ((defaultProperty != null) && (defaultProperty.PropertyType == typeof(string)))
			{
				str = (string)defaultProperty.GetValue(value);
				if (!string.IsNullOrEmpty(str))
				{
					return str;
				}
			}
			str = TypeDescriptor.GetConverter(value).ConvertToString(value);
			if (!string.IsNullOrEmpty(str))
				return str;

			return value.GetType().Name;
		}
	}

	internal class ListViewSubItemExCollectionEditor : CollectionEditor
	{
		// Fields
		private static int count;
		private ListViewItemEx.ListViewSubItemEx firstSubItem;

		// Methods
		public ListViewSubItemExCollectionEditor(Type type) : base(type)
		{
		}

		protected override object CreateInstance(Type type)
		{
			var obj2 = base.CreateInstance(type);
			var ex = obj2 as ListViewItemEx.ListViewSubItemEx;
			if (ex != null)
				ex.Name = "listViewSubItemEx" + count++;
			return obj2;
		}

		protected override string GetDisplayText(object value)
		{
			string str;
			if (value == null)
			{
				return string.Empty;
			}
			var defaultProperty = TypeDescriptor.GetDefaultProperty(base.CollectionType);
			if ((defaultProperty != null) && (defaultProperty.PropertyType == typeof(string)))
			{
				str = (string)defaultProperty.GetValue(value);
				if (!string.IsNullOrEmpty(str))
				{
					return str;
				}
			}
			str = TypeDescriptor.GetConverter(value).ConvertToString(value);
			if (!string.IsNullOrEmpty(str))
			{
				return str;
			}
			return value.GetType().Name;
		}

		protected override object[] GetItems(object editValue)
		{
			var items = (ListViewItemEx.ListViewSubItemExCollection)editValue;
			var array = new object[items.Count];
			((ICollection)items).CopyTo(array, 0);
			if (array.Length > 0)
			{
				firstSubItem = items[0];
				var destinationArray = new object[array.Length - 1];
				Array.Copy(array, 1, destinationArray, 0, destinationArray.Length);
				array = destinationArray;
			}
			return array;
		}

		protected override object SetItems(object editValue, object[] value)
		{
			var list = editValue as IList;
			list.Clear();
			list.Add(firstSubItem);
			for (var i = 0; i < value.Length; i++)
			{
				list.Add(value[i]);
			}
			return editValue;
		}
	}
}
