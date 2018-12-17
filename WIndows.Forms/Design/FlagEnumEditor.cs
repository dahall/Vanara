using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms.Design;
using Vanara.Extensions;

namespace Vanara.Windows.Forms.Design
{
	/// <summary>A <see cref="UITypeEditor"/> for editing flag enums.</summary>
	/// <typeparam name="TE">The type of the enum.</typeparam>
	/// <seealso cref="System.Drawing.Design.UITypeEditor"/>
	public class FlagEnumUIEditor<TE> : UITypeEditor where TE : struct, System.Enum
	{
		private readonly FlagCheckedListBox listBox;

		public FlagEnumUIEditor() { listBox = new FlagCheckedListBox {BorderStyle = BorderStyle.None}; }

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context?.Instance != null && provider != null)
			{
				var edSvc = provider.GetService<IWindowsFormsEditorService>();
				if (edSvc == null) return null;
				var e = (TE)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType);
				listBox.Value = e;
				edSvc.DropDownControl(listBox);
				return listBox.Value;
			}
			return null;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.DropDown;

		public class FlagCheckedListBox : CheckedListBox
		{
			private readonly Container components = null;
			private TE enumValue;
			private bool isUpdatingCheckStates;

			public FlagCheckedListBox() { CheckOnClick = true; }

			[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
			public TE Value
			{
				get
				{
					long sum = 0;
					for (var i = 0; i < Items.Count; i++)
					{
						var item = Items[i] as FlagCheckedListBoxItem;
						if (item != null && GetItemChecked(i))
							sum |= item.LongVal;
					}
					return FromLong(sum);
				}
				set
				{
					Items.Clear();
					enumValue = value;
					foreach (TE val in Enum.GetValues(typeof(TE)))
						Add(val);
					UpdateCheckedItems(enumValue);
				}
			}

			public void Add(TE v) => Items.Add(new FlagCheckedListBoxItem(v));

			private static TE FromLong(long val) => (TE)Enum.ToObject(typeof(TE), val);

			protected override void Dispose(bool disposing)
			{
				if (disposing)
					components?.Dispose();
				base.Dispose(disposing);
			}

			protected override void OnItemCheck(ItemCheckEventArgs e)
			{
				base.OnItemCheck(e);

				if (isUpdatingCheckStates) return;
				var item = Items[e.Index] as FlagCheckedListBoxItem;
				if (item != null) UpdateCheckedItems(item, e.NewValue);
			}

			protected void UpdateCheckedItems(TE value)
			{
				isUpdatingCheckStates = true;
				var lval = Convert.ToInt64(value);
				// Iterate over all items
				for (var i = 0; i < Items.Count; i++)
				{
					var item = Items[i] as FlagCheckedListBoxItem;
					if (item == null) continue;
					SetItemChecked(i, (item.LongVal == 0 && lval == 0) || value.IsFlagSet(item.Value));
					//SetItemChecked(i, item.Value == 0 ? value == 0 : (item.value & value) == item.value && item.value != 0);
				}
				isUpdatingCheckStates = false;
			}

			// Updates items in the CheckListBox
			// composite = The item that was checked/unchecked
			// cs = The check state of that item
			protected void UpdateCheckedItems(FlagCheckedListBoxItem composite, CheckState cs)
			{
				long sum = 0;
				if (composite.LongVal != 0)
				{
					sum = Convert.ToInt64(Value);
					// If the item has been unchecked, remove its bits from the sum
					if (cs == CheckState.Unchecked)
						sum = sum & ~composite.LongVal;
					// If the item has been checked, combine its bits with the sum
					else
						sum |= composite.LongVal;
				}
				UpdateCheckedItems(FromLong(sum));
			}

			// Represents an item in the CheckListBox
			public class FlagCheckedListBoxItem
			{
				public FlagCheckedListBoxItem(TE value) { Value = value; }

				public TE Value { get; }

				public long LongVal => Convert.ToInt64(Value);

				public override string ToString() => Value.ToString(CultureInfo.CurrentCulture);
			}
		}
	}
}