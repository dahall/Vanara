using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Vanara.Windows.Forms;

/// <summary>
/// A combo box that displays the items of an <see cref="Enum"/> type. If the Enum type has a <see cref="FlagsAttribute"/>, then the
/// drop-down will be checked list of the values.
/// </summary>
/// <seealso cref="CustomComboBox"/>
public class EnumComboBox : CustomComboBox
{
	private readonly List<ECBItem> items = new();
	private readonly Timer timer = new() { Interval = 150 };
	private CheckedListBox? checkListBox;
	private Type? type = null;

	/// <summary>Initializes a new instance of the <see cref="EnumComboBox"/> class.</summary>
	public EnumComboBox() : base()
	{
		base.DropDownStyle = ComboBoxStyle.DropDownList;
		timer.Tick += Timer_Tick;
	}

	/// <summary>Gets or sets the data source for this <see cref="T:System.Windows.Forms.ComboBox"/>.</summary>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new object DataSource { get => base.DataSource!; set => base.DataSource = value; }

	/// <summary>Gets or sets the property to display for this <see cref="T:System.Windows.Forms.ListControl"/>.</summary>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new string DisplayMember { get => base.DisplayMember; set => base.DisplayMember = value; }

	/// <summary>Gets or sets a value specifying the style of the combo box.</summary>
	/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ComboBoxStyle DropDownStyle { get => base.DropDownStyle; set => base.DropDownStyle = value; }

	/// <summary>Gets or sets the Enum type that is used to populate the values of the combo box.</summary>
	/// <value>The enum type string.</value>
	/// <exception cref="ArgumentException">EnumTypeString must be an enumerated type.</exception>
	[DefaultValue(""), Category("Behavior"), Description("The Enum type that is used to populate the values of the combo box.")]
	public string EnumTypeString
	{
		get => type?.FullName ?? "";
		set
		{
			type = EnumComboBox.FindType(value, true);
			if (type is null || !type.IsEnum)
				throw new ArgumentException("EnumTypeString must be an enumerated type.");

			items.Clear();
			foreach (var item in Enum.GetValues(type))
				items.Add(new ECBItem(item));

			if (type.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
			{
				if (checkListBox == null)
				{
					checkListBox = new CheckedListBox()
					{
						BorderStyle = BorderStyle.None,
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

	/// <summary>
	/// Gets or sets the value of the member property specified by the <see cref="P:System.Windows.Forms.ListControl.ValueMember"/> property.
	/// </summary>
	public new object? SelectedValue
	{
		get
		{
			if (type is null) return null;
			var ret = 0L;
			if (!HasFlags)
			{
				ret = Convert.ToInt64(items[SelectedIndex].Value);
			}
			else if (checkListBox is not null)
			{
				for (var i = 0; i < checkListBox.CheckedItems.Count; i++)
				{
					if (checkListBox.CheckedItems[i] is ECBItem o && o.Value is IConvertible)
						try { ret |= Convert.ToInt64(o.Value); } catch { }
				}
			}
			return Convert.ChangeType(ret, GetEnumUnderlyingType(type));
		}
		set
		{
			if (!HasFlags)
				SelectedIndex = items.FindIndex(i => i.Value == value);
			else if (checkListBox is not null)
			{
				var lval = Convert.ToInt64(value);
				checkListBox.BeginUpdate();
				for (var i = 0; i < checkListBox.Items.Count; i++)
				{
					long? val = null;
					if (checkListBox.Items[i] is ECBItem o && o.Value is IConvertible)
						try { val = Convert.ToInt64(o.Value); } catch { }
					checkListBox.SetItemCheckState(i, (val.HasValue && (val.Value & lval) == val.Value) ? CheckState.Checked : CheckState.Unchecked);
				}
				checkListBox.EndUpdate();
			}
		}
	}

	/// <summary>Gets or sets the property to use as the actual value for the items in the <see cref="T:System.Windows.Forms.ListControl"/>.</summary>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new string ValueMember { get => base.ValueMember; set => base.ValueMember = value; }

	/// <summary>Gets an object representing the collection of the items contained in this <see cref="T:System.Windows.Forms.ComboBox"/>.</summary>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ObjectCollection Items => base.Items;

	private bool HasFlags => DropDownControl != null;

	/// <summary>Gets the selected value.</summary>
	/// <typeparam name="T">The type of the value to retrieve.</typeparam>
	/// <returns>The selected value cast to <typeparamref name="T"/>.</returns>
	public T? GetSelectedValue<T>() => SelectedValue == null ? default : (T)SelectedValue;

	private static Type GetEnumUnderlyingType(Type eType)
	{
		if (!eType.IsEnum)
			throw new ArgumentException("Must be an Enum type.", nameof(eType));
		var fields = eType.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
		if (fields == null || fields.Length != 1)
			throw new ArgumentException("Invalid Enum type.", nameof(eType));
		return fields[0].FieldType;
	}

	private void CheckListBox_ItemCheck(object? sender, ItemCheckEventArgs e) => timer.Enabled = true;

	private static Type? FindType(string name, bool ignoreCase) => AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(name, false, ignoreCase)).WhereNotNull().FirstOrDefault();

	private string GetFlagText()
	{
		var c = checkListBox?.CheckedItems.Count ?? 0;
		var items = new string?[c];
		for (var i = 0; i < c; i++)
			items[i] = checkListBox?.CheckedItems[i]!.ToString();
		return string.Join(", ", items);
	}

	private void Timer_Tick(object? sender, EventArgs e)
	{
		timer.Enabled = false;
		if (HasFlags)
			Text = GetFlagText();
	}

	[Serializable]
	private class ECBItem
	{
		public ECBItem(object? value)
		{
			Value = value;
			Text = value?.ToString();
			// TODO: Alternatively get text from resource or translation service.
		}

		public string? Text { get; set; }
		public object? Value { get; set; }

		public override string? ToString() => Text;
	}
}