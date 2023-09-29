using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Vanara.Windows.Forms.Design;

/// <summary>A <see cref="UITypeEditor"/> for editing flag enums.</summary>
/// <typeparam name="TE">The type of the enum.</typeparam>
/// <seealso cref="UITypeEditor"/>
public class FlagEnumUIEditor<TE> : UITypeEditor where TE : struct, Enum
{
	private readonly FlagCheckedListBox listBox;

	/// <summary>Initializes a new instance of the <see cref="FlagEnumUIEditor{TE}"/> class.</summary>
	public FlagEnumUIEditor() => listBox = new FlagCheckedListBox { BorderStyle = BorderStyle.None };

	/// <summary>
	/// Edits the specified object's value using the editor style indicated by the <see
	/// cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.
	/// </summary>
	/// <param name="context">
	/// An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.
	/// </param>
	/// <param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services.</param>
	/// <param name="value">The object to edit.</param>
	/// <returns>
	/// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
	/// </returns>
	public override object? EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
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

	/// <summary>
	/// Gets the editor style used by the <see
	/// cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.
	/// </summary>
	/// <param name="context">
	/// An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.
	/// </param>
	/// <returns>
	/// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see
	/// cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method. If the <see
	/// cref="T:System.Drawing.Design.UITypeEditor"/> does not support this method, then <see
	/// cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"/>.
	/// </returns>
	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.DropDown;

	/// <summary>A checked list box to use as the editor.</summary>
	/// <seealso cref="UITypeEditor"/>
	public class FlagCheckedListBox : CheckedListBox
	{
		private readonly Container? components = null;
		private TE enumValue;
		private bool isUpdatingCheckStates;

		/// <summary>Initializes a new instance of the <see cref="FlagCheckedListBox"/> class.</summary>
		public FlagCheckedListBox() => CheckOnClick = true;

		/// <summary>Gets or sets the value.</summary>
		/// <value>The value.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TE Value
		{
			get
			{
				long sum = 0;
				for (var i = 0; i < Items.Count; i++)
				{
					if (Items[i] is FlagCheckedListBoxItem item && GetItemChecked(i))
						sum |= item.LongVal;
				}
				return FromLong(sum);
			}
			set
			{
				Items.Clear();
				enumValue = value;
				foreach (TE val in Enum.GetValues(typeof(TE)).Cast<TE>())
					Add(val);
				UpdateCheckedItems(enumValue);
			}
		}

		/// <summary>Adds the specified v.</summary>
		/// <param name="v">The v.</param>
		public void Add(TE v) => Items.Add(new FlagCheckedListBoxItem(v));

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"/> and its child controls and
		/// optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				components?.Dispose();
			base.Dispose(disposing);
		}

		/// <summary>Raises the <see cref="E:ItemCheck"/> event.</summary>
		/// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
		protected override void OnItemCheck(ItemCheckEventArgs e)
		{
			base.OnItemCheck(e);

			if (isUpdatingCheckStates) return;
			if (Items[e.Index] is FlagCheckedListBoxItem item) UpdateCheckedItems(item, e.NewValue);
		}

		/// <summary>Updates the checked items.</summary>
		/// <param name="value">The value.</param>
		protected void UpdateCheckedItems(TE value)
		{
			isUpdatingCheckStates = true;
			var lval = Convert.ToInt64(value);
			// Iterate over all items
			for (var i = 0; i < Items.Count; i++)
			{
				if (Items[i] is not FlagCheckedListBoxItem item) continue;
				SetItemChecked(i, item.LongVal == 0 && lval == 0 || value.IsFlagSet(item.Value));
				//SetItemChecked(i, item.Value == 0 ? value == 0 : (item.value & value) == item.value && item.value != 0);
			}
			isUpdatingCheckStates = false;
		}

		/// <summary>Updates items in the CheckListBox.</summary>
		/// <param name="composite">The item that was checked/unchecked.</param>
		/// <param name="cs">The check state of that item.</param>
		protected void UpdateCheckedItems(FlagCheckedListBoxItem composite, CheckState cs)
		{
			long sum = 0;
			if (composite.LongVal != 0)
			{
				sum = Convert.ToInt64(Value);
				// If the item has been unchecked, remove its bits from the sum
				if (cs == CheckState.Unchecked)
					sum &= ~composite.LongVal;
				// If the item has been checked, combine its bits with the sum
				else
					sum |= composite.LongVal;
			}
			UpdateCheckedItems(FromLong(sum));
		}

		private static TE FromLong(long val) => (TE)Enum.ToObject(typeof(TE), val);

		/// <summary>Represents an item in the CheckListBox</summary>
		/// <seealso cref="UITypeEditor"/>
		public class FlagCheckedListBoxItem
		{
			/// <summary>Initializes a new instance of the <see cref="FlagCheckedListBoxItem"/> class.</summary>
			/// <param name="value">The value.</param>
			public FlagCheckedListBoxItem(TE value) => Value = value;

			/// <summary>Gets the long value.</summary>
			/// <value>The long value.</value>
			public long LongVal => Convert.ToInt64(Value);

			/// <summary>Gets the value.</summary>
			/// <value>The value.</value>
			public TE Value { get; }

			/// <summary>Converts to string.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => Value.ToString();
		}
	}
}