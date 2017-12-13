using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	public class EnumComboBox : CustomComboBox
	{
		private Type type = typeof(DayOfWeek);
		private List<ECBItem> items = new List<ECBItem>();
		private CheckedListBox checkListBox;
		private Timer timer = new Timer { Interval = 150 };

		public EnumComboBox() : base()
		{
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			timer.Enabled = false;
			if (HasFlags)
				Text = GetFlagText();
		}

		[DefaultValue("System.DayOfWeek")]
		public string EnumTypeString
		{
			get => type.FullName; set
			{
				type = FindType(null, value, true);
				if (type == null || !type.IsEnum)
					throw new ArgumentException("EnumTypeString must be an enumerated type.");

				items.Clear();
				foreach (var item in Enum.GetValues(type))
					items.Add(new ECBItem(item));

				if (type.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
				{
					if (checkListBox == null)
					{
						checkListBox = new System.Windows.Forms.CheckedListBox()
						{
							BorderStyle = System.Windows.Forms.BorderStyle.None,
							CheckOnClick = true,
							FormattingEnabled = true,
							Location = new System.Drawing.Point(17, 35),
							MultiColumn = false,
							Name = "checkedListBox1",
							Size = new System.Drawing.Size(187, 105),
							TabIndex = 0
						};
						checkListBox.ItemCheck += CheckListBox_ItemCheck;
					}
					checkListBox.Items.Clear();
					checkListBox.Items.AddRange(items.ToArray());
					DropDownControl = checkListBox;
				}
				else
				{
					DropDownControl = null;
					DisplayMember = "Text";
					ValueMember = "Value";
					DataSource = items;
				}
			}
		}

		private void CheckListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			timer.Enabled = true;
		}

		private string GetFlagText()
		{
			string[] items = new string[checkListBox.CheckedItems.Count];
			for (int i = 0; i < checkListBox.CheckedItems.Count; i++)
				items[i] = checkListBox.CheckedItems[i].ToString();
			return string.Join(", ", items);
		}

		private Type FindType(global::System.Reflection.Assembly asm, string name, bool ignoreCase)
		{
			Type t = null;
			foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
				if ((t = a.GetType(name, false, ignoreCase)) != null)
					break;
			return t;
		}

		public T GetSelectedValue<T>() => SelectedValue == null ? default(T) : (T)SelectedValue;

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ComboBoxStyle DropDownStyle { get => base.DropDownStyle; set => base.DropDownStyle = value; }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string DisplayMember { get => base.DisplayMember; set => base.DisplayMember = value; }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string ValueMember { get => base.ValueMember; set => base.ValueMember = value; }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new object DataSource { get => base.DataSource; set => base.DataSource = value; }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ObjectCollection Items => base.Items;

		public new object SelectedValue
		{
			get
			{
				long ret = 0;
				if (!HasFlags)
				{
					ret = Convert.ToInt64(items[SelectedIndex].Value);
				}
				else
				{
					for (int i = 0; i < checkListBox.CheckedItems.Count; i++)
					{
						ECBItem o = checkListBox.CheckedItems[i] as ECBItem;
						if (o != null && o.Value is IConvertible)
							try { ret |= Convert.ToInt64(o.Value); } catch { }
					}
				}

				return Convert.ChangeType(ret, GetEnumUnderlyingType(type));
			}
			set
			{
				if (!HasFlags)
					SelectedIndex = items.FindIndex(i => i.Value == value);
				else
				{
					long lval = Convert.ToInt64(value);
					checkListBox.BeginUpdate();
					for (int i = 0; i < checkListBox.Items.Count; i++)
					{
						long? val = null;
						ECBItem o = checkListBox.Items[i] as ECBItem;
						if (o != null && o.Value is IConvertible)
							try { val = Convert.ToInt64(o.Value); } catch { }
						checkListBox.SetItemCheckState(i, (val.HasValue && (val.Value & lval) == val.Value) ? CheckState.Checked : CheckState.Unchecked);
					}
					checkListBox.EndUpdate();
				}
			}
		}

		private bool HasFlags => DropDownControl != null;

		private static Type GetEnumUnderlyingType(Type eType)
		{
			if (!eType.IsEnum)
				throw new ArgumentException("Must be an Enum type.", nameof(eType));
			var fields = eType.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (fields == null || fields.Length != 1)
				throw new ArgumentException("Invalid Enum type.", nameof(eType));
			return fields[0].FieldType;
		}

		[Serializable]
		private class ECBItem
		{
			public ECBItem(object value)
			{
				Value = value;
				Text = value.ToString();
				// TODO: Alternatively get text from resource or translation service.
			}

			public string Text { get; set; }
			public object Value { get; set; }
			public override string ToString() => Text;
		}
	}
}
