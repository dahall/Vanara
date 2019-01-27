using System;
using System.Collections.Generic;
using Microsoft.Win32;
using Vanara.PInvoke;

namespace Vanara.Windows.Shell
{
	public enum VerbMultiSelectModel { Unset, Player, Single, Document }

	public enum VerbPosition { Unset, Top, Bottom }

	public enum VerbSelectionModel { Item, BackgroundShortcutMenu }

	/// <summary>Encapsulates a shortcut menu verb in the registry.</summary>
	public class CommandVerb : RegBasedSettings, IEquatable<CommandVerb>
	{
		internal CommandVerb(RegistryKey key, string name, bool readOnly = true) : base(key, readOnly)
		{
			Name = name;
		}

		public string AppliesTo
		{
			get => key.GetValue("AppliesTo", null)?.ToString();
			set => UpdateValue("AppliesTo", value);
		}

		public Shell32.SFGAO AttributeMask
		{
			get => (Shell32.SFGAO)(int)key.GetValue("AttributeMask", 0);
			set => UpdateValue("AttributeMask", (int)value, RegistryValueKind.DWord);
		}

		public Shell32.SFGAO AttributeValue
		{
			get => (Shell32.SFGAO)(int)key.GetValue("AttributeValue", 0);
			set => UpdateValue("AttributeValue", (int)value, RegistryValueKind.DWord);
		}

		/// <summary>Gets or sets the command string used to launch the command in a console window or batch (.bat) file.</summary>
		/// <value>The command string.</value>
		/// <remarks>
		/// If any element of the command string contains or might contain spaces, it must be enclosed in quotation marks. Otherwise, if the
		/// element contains a space, it will not parse correctly. For instance, "My Program.exe" starts the application properly. If you use
		/// My Program.exe without quotation marks, then the system attempts to launch My with Program.exe as its first command line
		/// argument. You should always use quotation marks with arguments such as "%1" that are expanded to strings by the Shell, because
		/// you cannot be certain that the string will not contain a space.
		/// </remarks>
		public string Command
		{
			get => key.GetSubKeyDefaultValue("command")?.ToString();
			set => UpdateKeyValue("command", value);
		}

		public Guid? CommandStateHandler
		{
			get => key.GetGuidValue("CommandStateHandler");
			set => UpdateValue("CommandStateHandler", value);
		}

		public string DefaultAppliesTo
		{
			get => key.GetValue("DefaultAppliesTo", null)?.ToString();
			set => UpdateValue("DefaultAppliesTo", value);
		}

		public Guid? DelegateExecute
		{
			get => key.GetGuidValue("DelegateExecute");
			set => UpdateValue("DelegateExecute", value);
		}

		/// <summary>
		/// Gets or sets an optional display name associated with them, which is displayed on the shortcut menu instead of the verb string
		/// itself. For example, the display string for <c>openas</c> is Open With. Like normal menu strings, including an ampersand
		/// character in the display string allows keyboard selection of the command.
		/// </summary>
		/// <value>The display name for the verb.</value>
		public string DisplayName
		{
			get => key.GetValue("", null)?.ToString();
			set => UpdateValue("", value);
		}

		public Guid? DropTarget
		{
			get
			{
				using (var sk = key.OpenSubKey("DropTarget"))
					return sk?.GetGuidValue("CLSID");
			}

			set
			{
				CheckRW();
				if (!value.HasValue)
				{
					try { key.DeleteSubKeyTree("DropTarget"); } catch { }
				}
				else
				{
					using (var sk = key.CreateSubKey("DropTarget"))
						sk?.SetValue("CLSID", value.Value.ToString());
				}
			}
		}

		public Guid? ExplorerCommandHandler
		{
			get => key.GetGuidValue("ExplorerCommandHandler");
			set => UpdateValue("ExplorerCommandHandler", value);
		}

		public bool Extended
		{
			get => key.HasValue("Extended");
			set => ToggleValue("Extended", value);
		}

		public string HasLUAShield
		{
			get => key.GetValue("HasLUAShield", null)?.ToString();
			set => UpdateValue("HasLUAShield", value);
		}

		public VerbSelectionModel ImpliedSelectionModel
		{
			get => (VerbSelectionModel)(int)key.GetValue("ImpliedSelectionModel", 0);
			set => UpdateValue("ImpliedSelectionModel", (int)value, RegistryValueKind.DWord);
		}

		public bool LegacyDisable
		{
			get => key.HasValue("LegacyDisable");
			set => ToggleValue("LegacyDisable", value);
		}

		public IndirectString MUIVerb
		{
			get => IndirectString.TryParse(key.GetValue("MUIVerb")?.ToString(), out var loc) ? loc : null;
			set => UpdateValue("MUIVerb", value?.ToString());
		}

		public VerbMultiSelectModel MultiSelectModel
		{
			get => (VerbMultiSelectModel)Enum.Parse(typeof(VerbMultiSelectModel), key.GetValue("MultiSelectModel", VerbMultiSelectModel.Unset.ToString()).ToString());
			set => UpdateValue("MultiSelectModel", value.ToString(), RegistryValueKind.String, VerbMultiSelectModel.Unset.ToString());
		}

		/// <summary>Gets or sets the text string that is used by the Shell to identify the associated command.</summary>
		/// <value>The verb name.</value>
		public string Name { get; set; }

		public bool NeverDefault
		{
			get => key.HasValue("NeverDefault");
			set => ToggleValue("NeverDefault", value);
		}
		public bool OnlyInBrowserWindow
		{
			get => key.HasValue("OnlyInBrowserWindow");
			set => ToggleValue("OnlyInBrowserWindow", value);
		}

		public VerbPosition Position
		{
			get => (VerbPosition)Enum.Parse(typeof(VerbPosition), key.GetValue("Position", VerbPosition.Unset.ToString()).ToString());
			set => UpdateValue("Position", value.ToString(), RegistryValueKind.String, VerbPosition.Unset.ToString());
		}

		public bool ProgrammaticAccessOnly
		{
			get => key.HasValue("ProgrammaticAccessOnly");
			set => ToggleValue("ProgrammaticAccessOnly", value);
		}

		public bool SeparatorAfter
		{
			get => 1 == key.GetValue("SeparatorAfter", 0) as int?;
			set => UpdateValue("SeparatorAfter", value ? 1 : 0, RegistryValueKind.DWord);
		}

		public bool SeparatorBefore
		{
			get => 1 == key.GetValue("SeparatorBefore", 0) as int?;
			set => UpdateValue("SeparatorBefore", value ? 1 : 0, RegistryValueKind.DWord);
		}

		public Shell32.RESTRICTIONS SuppressionPolicy
		{
			get => (Shell32.RESTRICTIONS)(int)key.GetValue("SuppressionPolicy", 0);
			set => UpdateValue("SuppressionPolicy", (int)value, RegistryValueKind.DWord);
		}

		public bool Equals(CommandVerb other) => Equals((RegBasedSettings)other);
	}
}