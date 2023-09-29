using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms;

/// <summary>Extends standard WinForms controls with post-Vista capabilities.</summary>
/// <seealso cref="Component"/>
/// <seealso cref="IExtenderProvider"/>
[ProvideProperty(ShowShield, typeof(ButtonBase))]
[ProvideProperty(CueBanner, typeof(ComboBox))]
[ProvideProperty(MinVisibleItems, typeof(ComboBox))]
//[ProvideProperty(CueBanner, typeof(TextBox))]
public sealed class VistaControlExtender : Component, IExtenderProvider, ISupportInitialize
{
	internal const string CueBanner = "CueBanner";
	internal const string MinVisibleItems = "MinVisibleItems";
	internal const string ShowShield = "ShowShield";

	private readonly Dictionary<Component, Dictionary<string, (object? value, Action<Control, object?> setter)>> bag = new();
	private readonly Container components = new();

	/// <summary>Initializes a new instance of the <see cref="VistaControlExtender"/> class.</summary>
	public VistaControlExtender() { }

	/// <summary>Initializes a new instance of the <see cref="VistaControlExtender"/> class.</summary>
	/// <param name="container">The container.</param>
	public VistaControlExtender(IContainer container) => container.Add(this);

	private static bool IsMinVista { get; } = Environment.OSVersion.Version.Major >= 6;

	/// <summary>Gets the text that is displayed as a prompt for an unselected <see cref="ComboBox"/>.</summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> instance.</param>
	/// <returns>The cue text to display.</returns>
	[DisplayName(CueBanner), DefaultValue(null), Category("Appearance")]
	[Description("Text that is displayed as a prompt for an unselected ComboBox.")]
	public string? GetCueBanner(ComboBox comboBox) => GetValue<string>(comboBox, CueBanner, out _);

	/// <summary>Sets the text that is displayed as a prompt for an unselected <see cref="ComboBox"/>.</summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> instance.</param>
	/// <param name="value">The cue text to display.</param>
	public void SetCueBanner(ComboBox comboBox, string? value) => SetValue(comboBox, CueBanner, value, SetCueBannerValue);

	/// <summary>Gets the minimum number of visible items in the drop-down list of a <see cref="ComboBox"/>.</summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> instance.</param>
	/// <returns>The minimum number of visible items in the drop-down list.</returns>
	[DisplayName(MinVisibleItems), DefaultValue(30), Category("Appearance")]
	[Description("The minimum number of visible items in the drop-down list of a combo box.")]
	public int GetMinVisibleItems(ComboBox comboBox) => GetValue(comboBox, MinVisibleItems, out _, comboBox.SendMessage((uint)ComboBoxMessage.CB_SETMINVISIBLE).ToInt32());

	/// <summary>Sets the minimum number of visible items in the drop-down list of a <see cref="ComboBox"/>.</summary>
	/// <param name="comboBox">The <see cref="ComboBox"/> instance.</param>
	/// <param name="value">The minimum number of visible items in the drop-down list.</param>
	public void SetMinVisibleItems(ComboBox comboBox, int value) => SetValue(comboBox, MinVisibleItems, value, SetMinVisibleItemsValue);

	/// <summary>
	/// Gets a value which indicates whether a shield is shown on the button to indicate that elevated permissions are required to
	/// perform the action of the button.
	/// </summary>
	/// <param name="btn">The Button instance.</param>
	/// <returns><see langword="true"/> if the shield should be shown; <see langword="false"/> otherwise.</returns>
	[DisplayName(ShowShield), DefaultValue(false), Category("Appearance")]
	[Description("Indicates whether a shield is shown on the button to indicate that elevated permissions are required to perform the action of the button.")]
	public bool GetShowShield(ButtonBase btn) => GetValue<bool>(btn, ShowShield, out _);

	/// <summary>
	/// Sets a value which indicates whether a shield is shown on the button to indicate that elevated permissions are required to
	/// perform the action of the button.
	/// </summary>
	/// <param name="btn">The Button instance.</param>
	/// <param name="value"><see langword="true"/> if the shield should be shown; <see langword="false"/> otherwise.</param>
	public void SetShowShield(ButtonBase btn, bool value) => SetValue(btn, ShowShield, value, SetShowShieldValue);

	void ISupportInitialize.BeginInit()
	{
	}

	bool IExtenderProvider.CanExtend(object extendee) => extendee is ComboBox || extendee is ButtonBase && extendee.GetType().GetProperty(ShowShield) is null;

	void ISupportInitialize.EndInit()
	{
		if (!DesignMode)
		{
			foreach (var key in bag.Keys.OfType<Control>())
				key.HandleCreated += OnComponentHandleCreated;
		}
	}

	/// <summary>
	/// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component"/> and optionally releases the managed resources.
	/// </summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			foreach (var key in bag.Keys.OfType<Control>())
				try { key.HandleCreated -= OnComponentHandleCreated; } catch { }
			components?.Dispose();
		}
		base.Dispose(disposing);
	}

	private static void SetCueBannerValue(Control comboBox, object? value)
	{
		(comboBox as ComboBox)?.SetCueBanner((string?)value);
		comboBox.Invalidate();
	}

	private static void SetMinVisibleItemsValue(Control comboBox, object? value)
	{
		if (!IsMinVista) return;
		comboBox.SendMessage((uint)ComboBoxMessage.CB_SETMINVISIBLE, (IntPtr)(int)value!);
		comboBox.Invalidate();
	}

	private static void SetShowShieldValue(Control btn, object? value)
	{
		(btn as ButtonBase)?.SetElevationRequiredState((bool)value!);
		btn.Invalidate();
	}

	/*[DisplayName(CueBanner), DefaultValue(null), Category("Appearance")]
	[Description("Text that is displayed as a prompt for an unselected TextBox.")]
	public string GetCueBanner(TextBox textBox) => GetValue<string>(textBox, CueBanner);

	public void SetCueBanner(TextBox textBox, string value)
	{
		if (SetValue(textBox, CueBanner, value))
			textBox.SetCueBanner(value);
	}*/

	private T? GetValue<T>(Control comp, string propName, out Action<Control, object?>? setter, T? defValue = default)
	{
		if (bag.TryGetValue(comp, out var props) && props.TryGetValue(propName, out var value))
		{
			setter = value.setter;
			return (T?)value.value;
		}
		setter = null;
		return defValue;
	}

	private void OnComponentHandleCreated(object? sender, EventArgs e)
	{
		foreach (var kv in bag.Where(kv => ReferenceEquals(kv.Key, sender)))
			foreach (var (value, setter) in kv.Value.Values)
				setter?.Invoke((Control)sender!, value);
	}

	private bool SetValue<T>(Control comp, string propName, T? value, Action<Control, object?> setter)
	{
		if (Equals(value, GetValue<T>(comp, propName, out _))) return false;
		if (!bag.ContainsKey(comp))
			bag.Add(comp, new Dictionary<string, (object? value, Action<Control, object?> setter)>());
		bag[comp][propName] = (value, setter);
		return true;
	}
}