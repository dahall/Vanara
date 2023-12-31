using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.User32;
using ComboBoxStyle = System.Windows.Forms.ComboBoxStyle;

namespace Vanara.Windows.Forms;

internal interface IPopupControlHost
{
	/// <summary>Hides drop-down area of combo box, if shown.</summary>
	void HideDropDown();

	/// <summary>Displays drop-down area of combo box, if not already shown.</summary>
	void ShowDropDown();
}

/// <summary><c>CustomComboBox</c> is an extension of <see cref="ComboBox"/> which provides drop-down customization.</summary>
public abstract class CustomComboBox : ComboBox, IPopupControlHost
{
	private const int maxItemLen = 1024;
	private static DateTime showTime = DateTime.Now;

	/// <summary>Actual drop-down control itself.</summary>
	private Control? dropDownCtrl;

	/// <summary>Indicates if drop-down is currently shown.</summary>
	private bool droppedDown;

	/// <summary>Time drop-down was last hidden.</summary>
	private DateTime lastHideTime = DateTime.Now;

	/// <summary>Popup control.</summary>
	private PopupControl popupCtrl = new();

	/// <summary>Original size of combo box drop-down when first assigned.</summary>
	private Size sizeCombo;

	/// <summary>Indicates current sizing mode.</summary>
	private SizeMode sizeMode = SizeMode.UseComboSize;

	/// <summary>Original size of control dimensions when first assigned.</summary>
	private Size sizeOriginal = new(1, 1);

	/// <summary>Automatic focus timer helps make sure drop-down control is focused for user input upon drop-down.</summary>
	private Timer? timerAutoFocus;

	private ToolTip toolTip;

	/// <summary>Initializes a new instance of the <see cref="CustomComboBox"/> class.</summary>
	public CustomComboBox()
	{
		base.DropDownStyle = ComboBoxStyle.DropDownList;
		base.Items.Add(string.Empty);
		sizeCombo = new Size(base.DropDownWidth, base.DropDownHeight);
		popupCtrl.Closing += DropDownClosing;
		toolTip = new ToolTip { StripAmpersands = true };
	}

	/// <summary>Initializes a new instance of the <see cref="CustomComboBox"/> class.</summary>
	/// <param name="dropControl">The control to display in the drop-down.</param>
	public CustomComboBox(Control dropControl) : this() => DropDownControl = dropControl;

	/// <summary>Occurs when the drop-down portion of a <see cref="CustomComboBox"/> is shown.</summary>
	[Category("Action")]
	public new event EventHandler? DropDown;

	/// <summary>Occurs when the drop-down portion of the <see cref="CustomComboBox"/> is no longer visible.</summary>
	[Category("Action")]
	public new event EventHandler? DropDownClosed;

	/// <summary>Sizing mode for the CustomComboBox drop-down area.</summary>
	public enum SizeMode
	{
		/// <summary>Uses the width of the parent.</summary>
		UseComboSize,

		/// <summary>Uses the width of the supplied control for the drop-down.</summary>
		UseControlSize,

		/// <summary>Uses the width of the combo box drop-down box.</summary>
		UseDropDownSize
	}

	internal enum GripAlignMode
	{
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight
	}

	internal enum PopupResizeMode
	{
		None = 0,

		// Individual styles.
		Left = 1,

		Top = 2,
		Right = 4,
		Bottom = 8,

		// Combined styles.
		All = Top | Left | Bottom | Right,

		TopLeft = Top | Left,
		TopRight = Top | Right,
		BottomLeft = Bottom | Left,
		BottomRight = Bottom | Right
	}

	/// <summary>Indicates if drop-down is re-sizable.</summary>
	[Category("Custom Drop-Down"), Description("Indicates if drop-down is re-sizable."), DefaultValue(true)]
	public bool AllowResizeDropDown { get; set; } = true;

	/// <summary>Gets or sets the size of the drop-down control itself.</summary>
	/// <value>The size of the drop-down control.</value>
	[Category("Custom Drop-Down"), Browsable(false)]
	public Size ControlSize
	{
		get => sizeOriginal;
		set
		{
			sizeOriginal = value;
			if (DropDownSizeMode == SizeMode.UseControlSize)
				AutoSizeDropDown();
		}
	}

	/// <summary>Gets or sets the property to display for this <see cref="T:System.Windows.Forms.ListControl"/>.</summary>
	/// <value></value>
	/// <returns>
	/// A <see cref="T:System.String"/> specifying the name of an object property that is contained in the collection specified by the <see
	/// cref="P:System.Windows.Forms.ListControl.DataSource"/> property. The default is an empty string ("").
	/// </returns>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new string DisplayMember { get => base.DisplayMember; set { } }

	/// <summary>Gets or sets drop-down control itself.</summary>
	/// <value>The drop down control.</value>
	[Browsable(false)]
	public Control? DropDownControl { get => dropDownCtrl; set => AssignControl(value); }

	/// <summary>Gets or sets the height in pixels of the drop-down portion of the <see cref="T:System.Windows.Forms.ComboBox"/>.</summary>
	/// <value></value>
	/// <returns>The height, in pixels, of the drop-down box.</returns>
	/// <exception cref="T:System.ArgumentException">The specified value is less than one.</exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new int DropDownHeight { get => base.DropDownHeight; set { } }

	/// <summary>Gets or sets the sizing mode for the drop-down.</summary>
	/// <value>The drop down size mode.</value>
	[Category("Custom Drop-Down"), Description("Indicates current sizing mode."), DefaultValue(SizeMode.UseComboSize)]
	public SizeMode DropDownSizeMode
	{
		get => sizeMode;
		set
		{
			if (value != sizeMode)
			{
				sizeMode = value;
				AutoSizeDropDown();
			}
		}
	}

	/// <summary>Gets or sets a value specifying the style of the combo box.</summary>
	/// <value></value>
	/// <returns>One of the <see cref="T:System.Windows.Forms.ComboBoxStyle"/> values. The default is DropDown.</returns>
	/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
	/// The assigned value is not one of the <see cref="T:System.Windows.Forms.ComboBoxStyle"/> values.
	/// </exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new ComboBoxStyle DropDownStyle { get => base.DropDownStyle; set { } }

	/// <summary>Gets or sets the width of the of the drop-down portion of a combo box.</summary>
	/// <value></value>
	/// <returns>The width, in pixels, of the drop-down box.</returns>
	/// <exception cref="T:System.ArgumentException">The specified value is less than one.</exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new int DropDownWidth { get => base.DropDownWidth; set { } }

	/// <summary>Gets or sets the size of the drop-down area.</summary>
	/// <value>The size of the drop-down area.</value>
	[Category("Custom Drop-Down")]
	public Size DropSize
	{
		get => sizeCombo;
		set
		{
			sizeCombo = value;
			if (DropDownSizeMode == SizeMode.UseDropDownSize)
				AutoSizeDropDown();
		}
	}

	/// <summary>Gets or sets a value indicating whether the control should resize to avoid showing partial items.</summary>
	/// <value></value>
	/// <returns>true if the list portion can contain only complete items; otherwise, false. The default is true.</returns>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new bool IntegralHeight { get => base.IntegralHeight; set { } }

	/// <summary>Indicates if drop-down is currently shown.</summary>
	/// <value><c>true</c> if this instance is dropped down; otherwise, <c>false</c>.</value>
	[Browsable(false)]
	public bool IsDroppedDown => droppedDown /*&& m_popupCtrl.Visible*/;

	/// <summary>Gets or sets the height of an item in the combo box.</summary>
	/// <value></value>
	/// <returns>The height, in pixels, of an item in the combo box.</returns>
	/// <exception cref="T:System.ArgumentException">The item height value is less than zero.</exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new int ItemHeight { get => base.ItemHeight; set { } }

	/// <summary>Gets an object representing the collection of the items contained in this <see cref="T:System.Windows.Forms.ComboBox"/>.</summary>
	/// <value></value>
	/// <returns>A <see cref="T:System.Windows.Forms.ComboBox.ObjectCollection"/> representing the items in the <see cref="T:System.Windows.Forms.ComboBox"/>.</returns>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new ObjectCollection Items => base.Items;

	/// <summary>Gets or sets the maximum number of items to be shown in the drop-down portion of the <see cref="T:System.Windows.Forms.ComboBox"/>.</summary>
	/// <value></value>
	/// <returns>The maximum number of items of in the drop-down portion. The minimum for this property is 1 and the maximum is 100.</returns>
	/// <exception cref="T:System.ArgumentException">The maximum number is set less than one or greater than 100.</exception>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new int MaxDropDownItems { get => base.MaxDropDownItems; set { } }

	/// <summary>Gets or sets the index specifying the currently selected item.</summary>
	/// <value></value>
	/// <returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// The specified index is less than or equal to -2.
	/// -or- The specified index is greater than or equal to the number of items in the combo box.
	/// </exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new int SelectedIndex { get => base.SelectedIndex; set { } }

	/// <summary>Gets or sets currently selected item in the <see cref="T:System.Windows.Forms.ComboBox"/>.</summary>
	/// <value></value>
	/// <returns>The object that is the currently selected item or null if there is no currently selected item.</returns>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new object SelectedItem { get => base.SelectedItem!; set { } }

	/// <summary>Gets or sets the text that is selected in the editable portion of a <see cref="T:System.Windows.Forms.ComboBox"/>.</summary>
	/// <value></value>
	/// <returns>
	/// A string that represents the currently selected text in the combo box. If <see cref="P:System.Windows.Forms.ComboBox.DropDownStyle"/>
	/// is set to <see cref="F:System.Windows.Forms.ComboBoxStyle.DropDownList"/>, the return value is an empty string ("").
	/// </returns>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new string SelectedText { get => base.SelectedText; set { } }

	/// <summary>
	/// Gets or sets the value of the member property specified by the <see cref="P:System.Windows.Forms.ListControl.ValueMember"/> property.
	/// </summary>
	/// <value></value>
	/// <returns>
	/// An object containing the value of the member of the data source specified by the <see
	/// cref="P:System.Windows.Forms.ListControl.ValueMember"/> property.
	/// </returns>
	/// <exception cref="T:System.InvalidOperationException">The assigned value is null or the empty string ("").</exception>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new object SelectedValue { get => base.SelectedValue!; set { } }

	/// <summary>Gets or sets the number of characters selected in the editable portion of the combo box.</summary>
	/// <value></value>
	/// <returns>The number of characters selected in the combo box.</returns>
	/// <exception cref="T:System.ArgumentException">The value was less than zero.</exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new int SelectionLength { get => base.SelectionLength; set { } }

	/// <summary>Gets or sets the starting index of text selected in the combo box.</summary>
	/// <value></value>
	/// <returns>The zero-based index of the first character in the string of the current text selection.</returns>
	/// <exception cref="T:System.ArgumentException">The value is less than zero.</exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new int SelectionStart { get => base.SelectionStart; set { } }

	/// <summary>Gets or sets a value indicating whether the items in the combo box are sorted.</summary>
	/// <value></value>
	/// <returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
	/// <exception cref="T:System.ArgumentException">
	/// An attempt was made to sort a <see cref="T:System.Windows.Forms.ComboBox"/> that is attached to a data source.
	/// </exception>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new bool Sorted { get => base.Sorted; set { } }

	/// <summary>Gets or sets the text associated with this control.</summary>
	/// <value></value>
	/// <returns>The text associated with this control.</returns>
	/// <PermissionSet>
	/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission,
	/// mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission
	/// class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral,
	/// PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission
	/// class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	/// version="1" Unrestricted="true"/>
	/// </PermissionSet>
	public new string Text
	{
		get => base.Items.Count == 0 ? string.Empty : base.Items[0]!.ToString()!;
		set
		{
			// Get toolTip value
			var items = value.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			if (items.Length > 0)
				toolTip.SetToolTip(this, string.Join("\r\n", items));
			// Limit length and then set 0 item to value so it displays
			if (value.Length > maxItemLen)
				value = value.Substring(0, maxItemLen);
			if (base.Items.Count == 0)
				base.Items.Add(value);
			else if (!Equals(value, base.Items[0]))
				base.Items[0] = value;
			base.SelectedIndex = 0;
		}
	}

	/// <summary>Gets or sets the property to use as the actual value for the items in the <see cref="T:System.Windows.Forms.ListControl"/>.</summary>
	/// <value></value>
	/// <returns>
	/// A <see cref="T:System.String"/> representing the name of an object property that is contained in the collection specified by the <see
	/// cref="P:System.Windows.Forms.ListControl.DataSource"/> property. The default is an empty string ("").
	/// </returns>
	/// <exception cref="T:System.ArgumentException">
	/// The specified property cannot be found on the object specified by the <see cref="P:System.Windows.Forms.ListControl.DataSource"/> property.
	/// </exception>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false), ReadOnly(true)]
	public new string ValueMember { get => base.ValueMember; set { } }

	/// <summary>Gets or sets a value indicating whether to prevent hiding the popup window.</summary>
	/// <value><c>true</c> if hiding is prevented; otherwise, <c>false</c>.</value>
	protected bool PreventPopupHide { get; set; }

	/// <summary>Hides drop-down area of combo box, if shown.</summary>
	public virtual void HideDropDown()
	{
		if (popupCtrl != null && IsDroppedDown && !PreventPopupHide)
		{
			// Hide drop-down control.
			popupCtrl.Hide();
			droppedDown = false;

			// Disable automatic focus timer.
			if (timerAutoFocus != null && timerAutoFocus.Enabled)
				timerAutoFocus.Enabled = false;

			Focus();

			// Raise drop-down closed event.
			OnDropDownClosed(EventArgs.Empty);
		}
	}

	/// <summary>Preprocesses keyboard or input messages within the message loop before they are dispatched.</summary>
	/// <param name="m">
	/// A <see cref="Message"/>, passed by reference, that represents the message to process. The possible values are WM_KEYDOWN,
	/// WM_SYSKEYDOWN, WM_CHAR, and WM_SYSCHAR.
	/// </param>
	/// <returns><c>true</c> if the message was processed by the control; otherwise, <c>false</c>.</returns>
	public override bool PreProcessMessage(ref Message m)
	{
		if (m.Msg == (int)WindowMessage.WM_REFLECT + (int)WindowMessage.WM_COMMAND)
		{
			if (HIWORD(m.WParam) == (int)ComboBoxNotification.CBN_DROPDOWN)
				return false;
		}
		return base.PreProcessMessage(ref m);
	}

	/// <summary>Displays drop-down area of combo box, if not already shown.</summary>
	public virtual void ShowDropDown()
	{
		if (popupCtrl is not null && DropDownControl is not null && !IsDroppedDown)
		{
			// Raise drop-down event.
			OnDropDown(EventArgs.Empty);

			// Restore original control size.
			AutoSizeDropDown();

			var location = PointToScreen(new Point(0, Height));

			// Actually show popup.
			var resizeMode = AllowResizeDropDown ? PopupResizeMode.BottomRight : PopupResizeMode.None;
			popupCtrl.Show(DropDownControl, location.X, location.Y, Width, Height, resizeMode);
			droppedDown = true;

			popupCtrl.PopupControlHost = this;

			// Initialize automatic focus timer?
			if (timerAutoFocus == null)
			{
				timerAutoFocus = new Timer {Interval = 10};
				timerAutoFocus.Tick += timerAutoFocus_Tick;
			}
			// Enable the timer!
			timerAutoFocus.Enabled = true;
			showTime = DateTime.Now;
		}
	}

	/// <summary>Assigns control to custom drop-down area of combo box.</summary>
	/// <param name="control">Control to be used as drop-down. Please note that this control must not be contained elsewhere.</param>
	protected virtual void AssignControl(Control? control)
	{
		// If specified control is different then...
		if (control != dropDownCtrl)
		{
			if (dropDownCtrl != null)
				Controls.Remove(dropDownCtrl);

			// Reference the user-specified drop down control.
			dropDownCtrl = control;

			// Preserve original container size.
			sizeOriginal = dropDownCtrl?.Size ?? new Size(1, 1);

			if (dropDownCtrl != null)
				Controls.Add(control);
		}
	}

	/// <summary>Automatically resize drop-down from properties.</summary>
	protected void AutoSizeDropDown()
	{
		if (DropDownControl != null)
		{
			switch (DropDownSizeMode)
			{
				case SizeMode.UseComboSize:
					DropDownControl.Size = new Size(Width, sizeCombo.Height);
					break;

				case SizeMode.UseControlSize:
					DropDownControl.Size = new Size(sizeOriginal.Width, sizeOriginal.Height);
					break;

				case SizeMode.UseDropDownSize:
					DropDownControl.Size = sizeCombo;
					break;
			}
		}
	}

	/// <summary>
	/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ComboBox"/> and optionally releases the managed resources.
	/// </summary>
	/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (timerAutoFocus != null)
			{
				timerAutoFocus.Dispose();
				timerAutoFocus = null;
			}
		}
		base.Dispose(disposing);
	}

	/// <summary>Raises the <see cref="DropDown"/> event.</summary>
	/// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected new virtual void OnDropDown(EventArgs args) => DropDown?.Invoke(this, args);

	/// <summary>Raises the <see cref="DropDownClosed"/> event.</summary>
	/// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected new virtual void OnDropDownClosed(EventArgs args) => DropDownClosed?.Invoke(this, args);

	/// <summary>Raises the <see cref="E:FontChanged"/> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		if (DropDownControl != null)
			DropDownControl.Font = Font;
	}

	/// <summary>Processes Windows messages.</summary>
	/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
	protected override void WndProc(ref Message m)
	{
		if (m.Msg == (int)WindowMessage.WM_LBUTTONDOWN && DropDownControl != null)
		{
			AutoDropDown();
			return;
		}

		if (m.Msg == (int)WindowMessage.WM_REFLECT + (int)WindowMessage.WM_COMMAND && DropDownControl != null)
		{
			switch (HIWORD(m.WParam))
			{
				case (int)ComboBoxNotification.CBN_DROPDOWN:
					AutoDropDown();
					return;

				case (int)ComboBoxNotification.CBN_CLOSEUP:
					if ((DateTime.Now - showTime).Seconds > 1)
						HideDropDown();
					return;
			}
		}

		base.WndProc(ref m);
	}

	private void AutoDropDown()
	{
		if (popupCtrl != null && popupCtrl.Visible)
			HideDropDown();
		else if ((DateTime.Now - lastHideTime).Milliseconds > 50)
			ShowDropDown();
	}

	private void DropDownClosing(object? sender, ToolStripDropDownClosingEventArgs e) => lastHideTime = DateTime.Now;

	private void m_dropDown_LostFocus(object? sender, EventArgs e) => lastHideTime = DateTime.Now;

	private void timerAutoFocus_Tick(object? sender, EventArgs e)
	{
		if (popupCtrl != null && popupCtrl.Visible && DropDownControl != null && !DropDownControl.Focused)
		{
			DropDownControl.Focus();
			if (timerAutoFocus != null && timerAutoFocus.Enabled)
				timerAutoFocus.Enabled = false;
		}

		if (DroppedDown)
			DroppedDown = false;
	}

	internal static class GripRenderer
	{
		private static Bitmap? gripBitmap;

		public static void RefreshSystemColors(Graphics g, Size size) => InitializeGripBitmap(g, size, true);

		public static void Render(Graphics g, Point location, Size size, GripAlignMode mode)
		{
			InitializeGripBitmap(g, size, false);

			// Calculate display size and position of grip.
			switch (mode)
			{
				case GripAlignMode.TopLeft:
					size.Height = -size.Height;
					size.Width = -size.Width;
					break;

				case GripAlignMode.TopRight:
					size.Height = -size.Height;
					break;

				case GripAlignMode.BottomLeft:
					size.Width = -size.Height;
					break;
			}

			// Reverse size grip for left-aligned.
			if (size.Width < 0)
				location.X -= size.Width;
			if (size.Height < 0)
				location.Y -= size.Height;

			g.DrawImage(gripBitmap, location.X, location.Y, size.Width, size.Height);
		}

		public static void Render(Graphics g, Point location, GripAlignMode mode) => Render(g, location, new Size(16, 16), mode);

		[MemberNotNull(nameof(gripBitmap))]
		private static void InitializeGripBitmap(Graphics g, Size size, bool forceRefresh)
		{
			if (gripBitmap == null || forceRefresh || size != gripBitmap.Size)
			{
				// Draw size grip into a bitmap image.
				gripBitmap = new Bitmap(size.Width, size.Height, g);
				using var gripG = Graphics.FromImage(gripBitmap);
				ControlPaint.DrawSizeGrip(gripG, SystemColors.ButtonFace, 0, 0, size.Width, size.Height);
			}
		}
	}

	internal class PopupControl
	{
		private PopupDropDown dropDown;
		private ToolStripControlHost? host;

		public PopupControl() => InitializeDropDown();

		public event ToolStripDropDownClosingEventHandler? Closing { add => dropDown.Closing += value; remove => dropDown.Closing -= value; }

		public bool AutoResetWhenClosed { get; set; } = false;

		public Control? Control => host?.Control;

		public Padding Margin { get; set; } = new Padding(1);

		public Padding Padding { get; set; } = Padding.Empty;

		/// <summary>Gets or sets the popup control host, this is used to hide/show popup.</summary>
		public IPopupControlHost? PopupControlHost { get; set; }

		public bool Visible => dropDown != null && dropDown.Visible;

		public void Hide()
		{
			if (dropDown != null && dropDown.Visible)
			{
				dropDown.Hide();
				DisposeHost();
			}
		}

		public void Reset() => DisposeHost();

		public void Show(Control control, int x, int y, PopupResizeMode resizeMode = PopupResizeMode.None) => Show(control, x, y, -1, -1, resizeMode);

		public void Show(Control control, int x, int y, int width, int height, PopupResizeMode resizeMode)
		{
			InitializeHost(control);

			dropDown.ResizeMode = resizeMode;
			dropDown.Show(x, y, width, height);

			control.Focus();
		}

		protected void DisposeHost()
		{
			if (host != null)
			{
				// Make sure host is removed from drop down.
				dropDown?.Items.Clear();

				// Dispose of host.
				host = null;
			}

			PopupControlHost = null;
		}

		[MemberNotNull(nameof(dropDown))]
		protected void InitializeDropDown()
		{
			// Does a drop down exist?
			if (dropDown == null)
			{
				dropDown = new PopupDropDown(false);
				dropDown.Closed += DropDownClosed;
			}
		}

		protected void InitializeHost(Control control)
		{
			InitializeDropDown();

			// If control is not yet being hosted then initialize host.
			if (control != Control)
				DisposeHost();

			// Create a new host?
			host ??= new ToolStripControlHost(control)
				{
					AutoSize = false,
					Padding = Padding,
					Margin = Margin
				};

			// Add control to drop-down.
			dropDown.Items.Clear();
			dropDown.Padding = dropDown.Margin = Padding.Empty;
			dropDown.Items.Add(host);
		}

		private void DropDownClosed(object? sender, ToolStripDropDownClosedEventArgs e)
		{
			if (AutoResetWhenClosed)
				DisposeHost();

			// Hide drop down within popup control.
			PopupControlHost?.HideDropDown();
		}
	}

	internal class PopupDropDown : ToolStripDropDown
	{
		private bool lockedHostedControlSize;
		private bool lockedThisSize;
		private bool refreshSize;
		private PopupResizeMode resizeMode = PopupResizeMode.None;

		public PopupDropDown(bool autoSize)
		{
			AutoSize = autoSize;
			Padding = Margin = Padding.Empty;
		}

		/// <summary>Type of resize mode, grips are automatically drawn at bottom-left and bottom-right corners.</summary>
		public PopupResizeMode ResizeMode
		{
			get => resizeMode; set
			{
				if (value != resizeMode)
				{
					resizeMode = value;
					Invalidate();
				}
			}
		}

		/// <summary>Bounds of active grip box position.</summary>
		protected Rectangle GripBounds { get; set; } = Rectangle.Empty;

		/// <summary>Indicates when a grip box is shown.</summary>
		protected bool IsGripShown => ResizeMode is PopupResizeMode.TopLeft or PopupResizeMode.TopRight or PopupResizeMode.BottomLeft or PopupResizeMode.BottomRight;

		public bool CompareResizeMode(PopupResizeMode resizeMode) => (ResizeMode & resizeMode) == resizeMode;

		public Control? GetHostedControl() => Items.Count > 0 && Items[0] is ToolStripControlHost host ? host.Control : null;

		/// <summary>Processes the resizing messages.</summary>
		/// <param name="m">The message.</param>
		/// <returns>true, if the WndProc method from the base class shouldn't be invoked.</returns>
		public bool ProcessGrip(ref Message m) => ProcessGrip(ref m, true);

		public void Show(int x, int y, int width = -1, int height = -1)
		{
			// If no hosted control is associated, this procedure is pointless!
			var hostedControl = GetHostedControl();
			if (hostedControl == null)
				return;

			// Initially hosted control should be displayed within a drop down of 1x1, however its size should exceed the dimensions of the drop-down.
			{
				lockedHostedControlSize = true;
				lockedThisSize = true;

				// Display actual popup and occupy just 1x1 pixel to avoid automatic reposition.
				Size = new Size(1, 1);
				base.Show(x, y);

				lockedHostedControlSize = false;
				lockedThisSize = false;
			}

			// Resize drop-down to fit its contents.
			ResizeFromContent(width);

			// If client area was enlarged using the minimum width parameter, then the hosted control must also be enlarged.
			if (refreshSize)
				RecalculateHostedControlLayout();

			// If popup is overlapping the initial position then move above!
			if (y > Top && y <= Bottom)
			{
				Top = y - Height - (height != -1 ? height : 0);

				var previous = ResizeMode;
				if (ResizeMode == PopupResizeMode.BottomLeft)
					ResizeMode = PopupResizeMode.TopLeft;
				else if (ResizeMode == PopupResizeMode.BottomRight)
					ResizeMode = PopupResizeMode.TopRight;

				if (ResizeMode != previous)
					RecalculateHostedControlLayout();
			}

			// Assign event handler to control.
			hostedControl.SizeChanged += hostedControl_SizeChanged;
		}

		protected void hostedControl_SizeChanged(object? sender, EventArgs e)
		{
			// Only update size of this container when it is not locked.
			if (!lockedHostedControlSize)
				ResizeFromContent(-1);
		}

		protected override void OnClosing(ToolStripDropDownClosingEventArgs e)
		{
			var hostedControl = GetHostedControl();
			if (hostedControl != null)
				hostedControl.SizeChanged -= hostedControl_SizeChanged;
			base.OnClosing(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			GripBounds = Rectangle.Empty;

			if (CompareResizeMode(PopupResizeMode.BottomLeft))
			{
				// Draw grip area at bottom-left of popup.
				e.Graphics.FillRectangle(SystemBrushes.ButtonFace, 1, Height - 16, Width - 2, 14);
				GripBounds = new Rectangle(1, Height - 16, 16, 16);
				GripRenderer.Render(e.Graphics, GripBounds.Location, GripAlignMode.BottomLeft);
			}
			else if (CompareResizeMode(PopupResizeMode.BottomRight))
			{
				// Draw grip area at bottom-right of popup.
				e.Graphics.FillRectangle(SystemBrushes.ButtonFace, 1, Height - 16, Width - 2, 14);
				GripBounds = new Rectangle(Width - 17, Height - 16, 16, 16);
				GripRenderer.Render(e.Graphics, GripBounds.Location, GripAlignMode.BottomRight);
			}
			else if (CompareResizeMode(PopupResizeMode.TopLeft))
			{
				// Draw grip area at top-left of popup.
				e.Graphics.FillRectangle(SystemBrushes.ButtonFace, 1, 1, Width - 2, 14);
				GripBounds = new Rectangle(1, 0, 16, 16);
				GripRenderer.Render(e.Graphics, GripBounds.Location, GripAlignMode.TopLeft);
			}
			else if (CompareResizeMode(PopupResizeMode.TopRight))
			{
				// Draw grip area at top-right of popup.
				e.Graphics.FillRectangle(SystemBrushes.ButtonFace, 1, 1, Width - 2, 14);
				GripBounds = new Rectangle(Width - 17, 0, 16, 16);
				GripRenderer.Render(e.Graphics, GripBounds.Location, GripAlignMode.TopRight);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			// When drop-down window is being resized by the user (i.e. not locked), update size of hosted control.
			if (!lockedThisSize)
				RecalculateHostedControlLayout();
		}

		protected void RecalculateHostedControlLayout()
		{
			if (lockedHostedControlSize)
				return;

			lockedThisSize = true;

			// Update size of hosted control.
			var hostedControl = GetHostedControl();
			if (hostedControl != null)
			{
				// Fetch control bounds and adjust as necessary.
				var bounds = hostedControl.Bounds;
				if (CompareResizeMode(PopupResizeMode.TopLeft) || CompareResizeMode(PopupResizeMode.TopRight))
					bounds.Location = new Point(1, 16);
				else
					bounds.Location = new Point(1, 1);

				bounds.Width = ClientRectangle.Width - 2;
				bounds.Height = ClientRectangle.Height - 2;
				if (IsGripShown)
					bounds.Height -= 16;

				if (bounds.Size != hostedControl.Size)
					hostedControl.Size = bounds.Size;
				if (bounds.Location != hostedControl.Location)
					hostedControl.Location = bounds.Location;
			}

			lockedThisSize = false;
		}

		protected void ResizeFromContent(int width)
		{
			if (lockedThisSize)
				return;

			// Prevent resizing hosted control to 1x1 pixel!
			lockedHostedControlSize = true;

			// Resize from content again because certain information was not available before.
			var bounds = Bounds;
			bounds.Size = SizeFromContent(width);

			if (!CompareResizeMode(PopupResizeMode.None))
			{
				if (width > 0 && bounds.Width - 2 > width)
					if (!CompareResizeMode(PopupResizeMode.Right))
						bounds.X -= bounds.Width - 2 - width;
			}

			Bounds = bounds;

			lockedHostedControlSize = false;
		}

		protected Size SizeFromContent(int width)
		{
			var contentSize = Size.Empty;

			refreshSize = false;

			// Fetch hosted control.
			var hostedControl = GetHostedControl();
			if (hostedControl != null)
			{
				if (CompareResizeMode(PopupResizeMode.TopLeft) || CompareResizeMode(PopupResizeMode.TopRight))
					hostedControl.Location = new Point(1, 16);
				else
					hostedControl.Location = new Point(1, 1);
				contentSize = SizeFromClientSize(hostedControl.Size);

				// Use minimum width (if specified).
				if (width > 0 && contentSize.Width < width)
				{
					contentSize.Width = width;
					refreshSize = true;
				}
			}

			// If a grip box is shown then add it into the drop down height.
			if (IsGripShown)
				contentSize.Height += 16;

			// Add some additional space to allow for borders.
			contentSize.Width += 2;
			contentSize.Height += 2;

			return contentSize;
		}

		protected override void WndProc(ref Message m)
		{
			if (!ProcessGrip(ref m, false))
				base.WndProc(ref m);
		}

		private bool OnGetMinMaxInfo(ref Message m)
		{
			var hostedControl = GetHostedControl();
			if (hostedControl != null)
			{
				var minmax = m.LParam.ToStructure<MINMAXINFO>();

				// Maximum size.
				if (hostedControl.MaximumSize.Width != 0)
					minmax.maxTrackSize.Width = hostedControl.MaximumSize.Width;
				if (hostedControl.MaximumSize.Height != 0)
					minmax.maxTrackSize.Height = hostedControl.MaximumSize.Height;

				// Minimum size.
				minmax.minTrackSize = new Size(32, 32);
				if (hostedControl.MinimumSize.Width > minmax.minTrackSize.Width)
					minmax.minTrackSize.Width = hostedControl.MinimumSize.Width;
				if (hostedControl.MinimumSize.Height > minmax.minTrackSize.Height)
					minmax.minTrackSize.Height = hostedControl.MinimumSize.Height;

				Marshal.StructureToPtr(minmax, m.LParam, false);
			}
			return true;
		}

		private bool OnNcHitTest(ref Message m, bool contentControl)
		{
			var location = PointToClient(new Point(LOWORD(m.LParam), HIWORD(m.LParam)));
			var transparent = (IntPtr)HitTestValues.HTTRANSPARENT;

			// Check for simple gripper dragging.
			if (GripBounds.Contains(location))
			{
				if (CompareResizeMode(PopupResizeMode.BottomLeft))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTBOTTOMLEFT;
					return true;
				}
				if (CompareResizeMode(PopupResizeMode.BottomRight))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTBOTTOMRIGHT;
					return true;
				}
				if (CompareResizeMode(PopupResizeMode.TopLeft))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTTOPLEFT;
					return true;
				}
				if (CompareResizeMode(PopupResizeMode.TopRight))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTTOPRIGHT;
					return true;
				}
			}
			else   // Check for edge based dragging.
			{
				var rectClient = ClientRectangle;
				if (location.X > rectClient.Right - 3 && location.X <= rectClient.Right && CompareResizeMode(PopupResizeMode.Right))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTRIGHT;
					return true;
				}
				if (location.Y > rectClient.Bottom - 3 && location.Y <= rectClient.Bottom && CompareResizeMode(PopupResizeMode.Bottom))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTBOTTOM;
					return true;
				}
				if (location.X > -1 && location.X < 3 && CompareResizeMode(PopupResizeMode.Left))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTLEFT;
					return true;
				}
				if (location.Y > -1 && location.Y < 3 && CompareResizeMode(PopupResizeMode.Top))
				{
					m.Result = contentControl ? transparent : (IntPtr)HitTestValues.HTTOP;
					return true;
				}
			}
			return false;
		}

		private bool ProcessGrip(ref Message m, bool contentControl)
		{
			if (ResizeMode != PopupResizeMode.None)
			{
				switch (m.Msg)
				{
					case (int)WindowMessage.WM_NCHITTEST:
						return OnNcHitTest(ref m, contentControl);

					case (int)WindowMessage.WM_GETMINMAXINFO:
						return OnGetMinMaxInfo(ref m);
				}
			}
			return false;
		}
	}
}