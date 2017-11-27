using System.Configuration;

namespace Vanara.Windows.Forms
{
	public partial class ListViewEx : IPersistComponentSettings
	{
		private ListViewExSettings settings;

		internal class ListViewExSettings : ApplicationSettingsBase
		{
			public ListViewExSettings(string settingsKey) : base(settingsKey) { }

			public ListViewExSettings(System.ComponentModel.IComponent owner) : base(owner) { }

			[UserScopedSetting]
			public ColumnHeaderExCollection Columns
			{
				get { return this["Columns"] as ColumnHeaderExCollection; }
				set { this["Columns"] = value; }
			}
		}

		void IPersistComponentSettings.LoadComponentSettings()
		{
			if (settings == null)
				settings = new ListViewExSettings(Name);
			else
				settings.SettingsKey = Name;
			settings.Reload();
		}

		void IPersistComponentSettings.ResetComponentSettings()
		{
			settings.Reset();
		}

		void IPersistComponentSettings.SaveComponentSettings()
		{
			if (settings != null)
			{
				settings.Columns = Columns;
				settings.Save();
			}
		}

		bool IPersistComponentSettings.SaveSettings { get; set; }

		string IPersistComponentSettings.SettingsKey
		{
			get { return settings.SettingsKey; }
			set { settings.SettingsKey = value; }
		}
	}
}