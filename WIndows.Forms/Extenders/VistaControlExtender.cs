using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Forms
{
	[ProvideProperty(ShowShield, typeof(ButtonBase))]
	[ProvideProperty(CueBanner, typeof(ComboBox))]
	[ProvideProperty(MinVisibleItems, typeof(ComboBox))]
	[ProvideProperty(CueBanner, typeof(TextBox))]
	public sealed class VistaControlExtender : Component, IExtenderProvider
	{
		internal const string CueBanner = "CueBanner";
		internal const string MinVisibleItems = "MinVisibleItems";
		internal const string ShowShield = "ShowShield";

		private readonly Dictionary<Component, Dictionary<string, object>> bag = new Dictionary<Component, Dictionary<string, object>>();

		private static bool IsMinVista { get; } = Environment.OSVersion.Version.Major >= 6;

		[DisplayName(ShowShield)]
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether a shield is shown on the button to indicate that elevated permissions are required to perform the action of the button.")]
		public bool GetShowShield(ButtonBase btn) => GetValue<bool>(btn, ShowShield);

		public void SetShowShield(ButtonBase btn, bool value)
		{
			if (SetValue(btn, ShowShield, value))
				btn.SetElevationRequiredState(value);
		}

		[DisplayName(CueBanner), DefaultValue(null), Category("Appearance")]
		[Description("Text that is displayed as a prompt for an unselected ComboBox.")]
		public string GetCueBanner(ComboBox comboBox) => GetValue<string>(comboBox, CueBanner);

		public void SetCueBanner(ComboBox comboBox, string value)
		{
			if (SetValue(comboBox, CueBanner, value))
				comboBox.SetCueBanner(value);
		}

		[DisplayName(MinVisibleItems), DefaultValue(30), Category("Appearance")]
		[Description("The minimum number of visible items in the drop-down list of a combo box.")]
		public int GetMinVisibleItems(ComboBox comboBox) => GetValue<int>(comboBox, MinVisibleItems, SendMessage(comboBox.Handle, (uint)ComboBoxMessage.CB_SETMINVISIBLE).ToInt32());

		public void SetMinVisibleItems(ComboBox comboBox, int value)
		{
			if (SetValue(comboBox, MinVisibleItems, value) && IsMinVista && comboBox.IsHandleCreated)
				SendMessage(comboBox.Handle, (uint)ComboBoxMessage.CB_SETMINVISIBLE, (IntPtr)value);
		}

		/*[DisplayName(CueBanner), DefaultValue(null), Category("Appearance")]
		[Description("Text that is displayed as a prompt for an unselected TextBox.")]
		public string GetCueBanner(TextBox textBox) => GetValue<string>(textBox, CueBanner);

		public void SetCueBanner(TextBox textBox, string value)
		{
			if (SetValue(textBox, CueBanner, value))
				textBox.SetCueBanner(value);
		}*/

		bool IExtenderProvider.CanExtend(object extendee) { return extendee is Component; }

		private T GetValue<T>(Component comp, string propName, T defValue = default)
		{
			try { return (T)bag[comp][propName]; } catch { }
			return defValue;
		}

		private bool SetValue<T>(Component comp, string propName, T value)
		{
			if (Equals(value, GetValue<T>(comp, propName))) return false;
			if (!bag.ContainsKey(comp))
				bag.Add(comp, new Dictionary<string, object>());
			bag[comp][propName] = value;
			return true;
		}
	}
}