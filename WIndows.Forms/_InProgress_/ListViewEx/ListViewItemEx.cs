using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	public class ListViewItemEx : ListViewItem
	{
		private ListViewSubItemExCollection subItems;

		public class ListViewSubItemEx : System.Windows.Forms.ListViewItem.ListViewSubItem
		{
			internal bool CustomBackColor { get; set; }
			internal bool CustomFont { get; set; }
			internal bool CustomForeColor { get; set; }
			internal bool CustomStyle { get; set; }
		}

		public class ListViewSubItemExCollection : ListViewSubItemCollection
		{
			public ListViewSubItemExCollection(ListViewItemEx owner) : base(owner)
			{
			}

			public new ListViewSubItemEx this[int index]
			{
				get { return Owner.BaseSubItems[index] as ListViewSubItemEx; }
				set { Owner.BaseSubItems[index] = value; }
			}

			public ListViewItemEx Owner => (ListViewItemEx)Owner;
		}

		internal ListViewSubItemCollection BaseSubItems => base.SubItems;

		internal class ListViewSubItemExCollectionEditor : CollectionEditor
		{
			// Fields
			private static int count;
			private ListViewItem.ListViewSubItem firstSubItem;

			// Methods
			public ListViewSubItemExCollectionEditor(Type type) : base(type)
			{
			}

			protected override object CreateInstance(Type type)
			{
				object obj2 = base.CreateInstance(type);
				if (obj2 is ListViewItem.ListViewSubItem)
				{
					((ListViewItem.ListViewSubItem)obj2).Name = "ListViewSubItemEx" + count++;
				}
				return obj2;
			}

			protected override string GetDisplayText(object value)
			{
				string str;
				if (value == null)
				{
					return string.Empty;
				}
				PropertyDescriptor defaultProperty = TypeDescriptor.GetDefaultProperty(base.CollectionType);
				if ((defaultProperty != null) && (defaultProperty.PropertyType == typeof(string)))
				{
					str = (string)defaultProperty.GetValue(value);
					if ((str != null) && (str.Length > 0))
					{
						return str;
					}
				}
				str = TypeDescriptor.GetConverter(value).ConvertToString(value);
				if ((str != null) && (str.Length != 0))
				{
					return str;
				}
				return value.GetType().Name;
			}

			protected override object[] GetItems(object editValue)
			{
				ListViewItem.ListViewSubItemCollection items = (ListViewItem.ListViewSubItemCollection)editValue;
				object[] array = new object[items.Count];
				((ICollection)items).CopyTo(array, 0);
				if (array.Length > 0)
				{
					firstSubItem = items[0];
					object[] destinationArray = new object[array.Length - 1];
					Array.Copy(array, 1, destinationArray, 0, destinationArray.Length);
					array = destinationArray;
				}
				return array;
			}

			protected override object SetItems(object editValue, object[] value)
			{
				IList list = editValue as IList;
				list.Clear();
				list.Add(firstSubItem);
				for (int i = 0; i < value.Length; i++)
				{
					list.Add(value[i]);
				}
				return editValue;
			}
		}

		[Category("Data"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("ListViewItemSubItems"), Editor(typeof(ListViewSubItemExCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public new ListViewSubItemExCollection SubItems
		{
			get
			{
				if (subItems == null)
					subItems = new ListViewSubItemExCollection(this);
				return subItems;
			}
		}
	}

	public class ListViewItemExConverter : ExpandableObjectConverter
	{
		// Methods
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException(nameof(destinationType));
			}
			if ((destinationType == typeof(InstanceDescriptor)) && (value is ListViewItemEx))
			{
				ConstructorInfo constructor;
				ListViewItemEx item = (ListViewItemEx)value;
				for (int i = 1; i < item.SubItems.Count; i++)
				{
					if (item.SubItems[i].CustomStyle)
					{
						if (string.IsNullOrEmpty(item.ImageKey))
						{
							constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(ListViewItemEx.ListViewSubItem[]), typeof(int) });
							if (constructor != null)
							{
								ListViewItemEx.ListViewSubItem[] array = new ListViewItemEx.ListViewSubItem[item.SubItems.Count];
								((ICollection)item.SubItems).CopyTo(array, 0);
								return new InstanceDescriptor(constructor, new object[] { array, item.ImageIndex }, false);
							}
						}
						else
						{
							constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(ListViewItemEx.ListViewSubItem[]), typeof(string) });
							if (constructor != null)
							{
								ListViewItemEx.ListViewSubItem[] itemArray = new ListViewItemEx.ListViewSubItem[item.SubItems.Count];
								((ICollection)item.SubItems).CopyTo(itemArray, 0);
								return new InstanceDescriptor(constructor, new object[] { itemArray, item.ImageKey }, false);
							}
						}
						break;
					}
				}
				string[] strArray = new string[item.SubItems.Count];
				for (int j = 0; j < strArray.Length; j++)
				{
					strArray[j] = item.SubItems[j].Text;
				}
				if (item.SubItems[0].CustomStyle)
				{
					if (!string.IsNullOrEmpty(item.ImageKey))
					{
						constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(string[]), typeof(string), typeof(Color), typeof(Color), typeof(Font) });
						if (constructor != null)
						{
							return new InstanceDescriptor(constructor, new object[] { strArray, item.ImageKey, item.SubItems[0].CustomForeColor ? item.ForeColor : Color.Empty, item.SubItems[0].CustomBackColor ? item.BackColor : Color.Empty, item.SubItems[0].CustomFont ? item.Font : null }, false);
						}
					}
					else
					{
						constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(string[]), typeof(int), typeof(Color), typeof(Color), typeof(Font) });
						if (constructor != null)
						{
							return new InstanceDescriptor(constructor, new object[] { strArray, item.ImageIndex, item.SubItems[0].CustomForeColor ? item.ForeColor : Color.Empty, item.SubItems[0].CustomBackColor ? item.BackColor : Color.Empty, item.SubItems[0].CustomFont ? item.Font : null }, false);
						}
					}
				}
				if (((item.ImageIndex == -1) && string.IsNullOrEmpty(item.ImageKey)) && (item.SubItems.Count <= 1))
				{
					constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(string) });
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[] { item.Text }, false);
					}
				}
				if (item.SubItems.Count <= 1)
				{
					if (!string.IsNullOrEmpty(item.ImageKey))
					{
						constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(string), typeof(string) });
						if (constructor != null)
						{
							return new InstanceDescriptor(constructor, new object[] { item.Text, item.ImageKey }, false);
						}
					}
					else
					{
						constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(string), typeof(int) });
						if (constructor != null)
						{
							return new InstanceDescriptor(constructor, new object[] { item.Text, item.ImageIndex }, false);
						}
					}
				}
				if (!string.IsNullOrEmpty(item.ImageKey))
				{
					constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(string[]), typeof(string) });
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[] { strArray, item.ImageKey }, false);
					}
				}
				else
				{
					constructor = typeof(ListViewItemEx).GetConstructor(new Type[] { typeof(string[]), typeof(int) });
					if (constructor != null)
					{
						return new InstanceDescriptor(constructor, new object[] { strArray, item.ImageIndex }, false);
					}
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
