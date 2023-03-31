using Microsoft.Win32;
using System;
using Vanara.PInvoke;

namespace Vanara.Windows.Shell;

/// <summary>A value that determines if a user can select a single item, multiple items, or a selection from an item.</summary>
[Flags]
public enum VerbMultiSelectModel
{
	/// <summary>
	/// Inferred from the type of verb implementation you have chosen. For COM-based methods (such as DropTarget and ExecuteCommand)
	/// Player is assumed, and for the other methods Document is assumed.
	/// </summary>
	Unset = 0,

	/// <summary>Support any number of items.</summary>
	Player = 1,

	/// <summary>Support only a single selection.</summary>
	Single = 2,

	/// <summary>
	/// Create a top level window for each item. Doing so limits the number of items activated and helps avoid running out of system
	/// resources if the user opens too many windows.
	/// </summary>
	Document = 4
}

/// <summary>Determines the placement of a verb in a menu.</summary>
public enum VerbPosition
{
	/// <summary>The menu position is undefined.</summary>
	Undefined,

	/// <summary>The menu should be displayed at the top.</summary>
	Top,

	/// <summary>The menu should be displayed at the bottom.</summary>
	Bottom
}

/// <summary>Determines menu location.</summary>
public enum VerbSelectionModel
{
	/// <summary>Specifies an item verb.</summary>
	Item,

	/// <summary>Specifies a verb on the background shortcut menu.</summary>
	BackgroundShortcutMenu
}

/// <summary>Encapsulates a shortcut menu verb in the registry.</summary>
public class CommandVerb : RegBasedSettings, IEquatable<CommandVerb>
{
	internal CommandVerb(RegistryKey key, string name, bool readOnly = true) : base(key, readOnly)
	{
		Name = name;
	}

	/// <summary>Gets or sets an Advanced Query Syntax (AQS) expression that determines whether the verb is displayed or hidden.</summary>
	/// <value>The AQS expression that controls visibility.</value>
	public string AppliesTo
	{
		get => key.GetValue("AppliesTo", null)?.ToString();
		set => UpdateValue("AppliesTo", value);
	}

	/// <summary>
	/// Gets or sets the SFGAO value of the bit values of the mask to test to determine whether the verb should be enabled or disabled.
	/// </summary>
	/// <value>The attribute mask.</value>
	public Shell32.SFGAO AttributeMask
	{
		get => (Shell32.SFGAO)(int)key.GetValue("AttributeMask", 0);
		set => UpdateValue("AttributeMask", (int)value, RegistryValueKind.DWord);
	}

	/// <summary>Gets or sets the SFGAO value of the bits that are tested to determine whether the verb should be enabled or disabled.</summary>
	/// <value>The attribute value.</value>
	public Shell32.SFGAO AttributeValue
	{
		get => (Shell32.SFGAO)(int)key.GetValue("AttributeValue", 0);
		set => UpdateValue("AttributeValue", (int)value, RegistryValueKind.DWord);
	}

	/// <summary>Gets or sets the command string used to launch the command in a console window or batch (.bat) file.</summary>
	/// <value>The command string.</value>
	/// <remarks>
	/// If any element of the command string contains or might contain spaces, it must be enclosed in quotation marks. Otherwise, if the
	/// element contains a space, it will not parse correctly. For instance, "My Program.exe" starts the application properly. If you
	/// use My Program.exe without quotation marks, then the system attempts to launch My with Program.exe as its first command line
	/// argument. You should always use quotation marks with arguments such as "%1" that are expanded to strings by the Shell, because
	/// you cannot be certain that the string will not contain a space.
	/// </remarks>
	public string Command
	{
		get => key.GetSubKeyDefaultValue("command")?.ToString();
		set => UpdateKeyValue("command", value);
	}

	/// <summary>Gets or sets the optional CLSID of an object that implments <c>IExplorerCommandState</c>.</summary>
	/// <value>The command state handler.</value>
	public Guid? CommandStateHandler
	{
		get => key.GetGuidValue("CommandStateHandler");
		set => UpdateValue("CommandStateHandler", value);
	}

	/// <summary>Gets or sets an Advanced Query Syntax (AQS) expression that controls which verb is the default.</summary>
	/// <value>The AQS expression that controls which verb is the default.</value>
	public string DefaultAppliesTo
	{
		get => key.GetValue("DefaultAppliesTo", null)?.ToString();
		set => UpdateValue("DefaultAppliesTo", value);
	}

	/// <summary>
	/// Gets or sets the optional CLSID value of the inproc extension that handles an excution within Windows Explorer or IE. For
	/// Windows Explorer, this value should be also assigned to the <see cref="ExplorerCommandHandler"/> value and exclusively
	/// associated with a <see cref="Command"/> value of "%SYSTEMROOT%\Explorer.exe". For IE, this value should be exclusively
	/// associated with a <see cref="Command"/> value of <c>"C:\Program Files\Internet Explorer\iexplore.exe" %1</c>.
	/// </summary>
	/// <value>The explorer command handler CLSID.</value>
	public Guid? DelegateExecute
	{
		get
		{
			using var sk = key.OpenSubKey("command");
			return sk?.GetGuidValue("DelegateExecute");
		}

		set
		{
			EnsureWritable();
			if (!value.HasValue)
			{
				try { key.DeleteSubKeyTree("command"); } catch { }
			}
			else
			{
				using var sk = key.CreateSubKey("command");
				sk?.SetValue("DelegateExecute", value.Value.ToRegString());
			}
		}
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

	/// <summary>Gets or sets the optional CLSID of the object that implements <c>IDropTarget</c>.</summary>
	/// <value>The drop target handler's CLSID.</value>
	public Guid? DropTarget
	{
		get
		{
			using var sk = key.OpenSubKey("DropTarget");
			return sk?.GetGuidValue("CLSID");
		}

		set
		{
			EnsureWritable();
			if (!value.HasValue)
			{
				try { key.DeleteSubKeyTree("DropTarget"); } catch { }
			}
			else
			{
				using var sk = key.CreateSubKey("DropTarget");
				sk?.SetValue("CLSID", value.Value.ToRegString());
			}
		}
	}

	/// <summary>
	/// Gets or sets the optional CLSID value of the inproc explorer extension that handles this verb's execution. This value should be
	/// also assigned to the <see cref="DelegateExecute"/> value and is generally associated with a <see cref="Command"/> value of "%SYSTEMROOT%\Explorer.exe".
	/// </summary>
	/// <value>The explorer command handler CLSID.</value>
	public Guid? ExplorerCommandHandler
	{
		get => key.GetGuidValue("ExplorerCommandHandler");
		set => UpdateValue("ExplorerCommandHandler", value);
	}

	/// <summary>
	/// Gets or sets a value that marks the command as extended and will be displayed only when the user right-clicks an object while
	/// also pressing the SHIFT key.
	/// </summary>
	/// <value>
	/// <see langword="true"/> if command is only displayed only when the user right-clicks an object while also pressing the SHIFT key;
	/// otherwise, <see langword="false"/>.
	/// </value>
	public bool Extended
	{
		get => key.HasValue("Extended");
		set => ToggleValue("Extended", value);
	}

	/// <summary>
	/// Gets or sets an Advanced Query Syntax (AQS) expression that controls whether a User Account Control (UAC) shield is displayed.
	/// </summary>
	/// <value>The AQS expression that controls whether a User Account Control (UAC) shield is displayed.</value>
	public string HasLUAShield
	{
		get => key.GetValue("HasLUAShield", null)?.ToString();
		set => UpdateValue("HasLUAShield", value);
	}

	/// <summary>Gets or sets a value that determines on which menu the command is displayed.</summary>
	/// <value>The implied selection model.</value>
	public VerbSelectionModel ImpliedSelectionModel
	{
		get => (VerbSelectionModel)(int)key.GetValue("ImpliedSelectionModel", 0);
		set => UpdateValue("ImpliedSelectionModel", (int)value, RegistryValueKind.DWord);
	}

	/// <summary>
	/// Gets or sets a value that tells the system that the verb is not an actual verb, but exists solely for the purpose of backward compatibility.
	/// </summary>
	/// <value><see langword="true"/> if disabled; otherwise, <see langword="false"/>.</value>
	public bool LegacyDisable
	{
		get => key.HasValue("LegacyDisable");
		set => ToggleValue("LegacyDisable", value);
	}

	/// <summary>Gets or sets a localizable value that is displayed as a menu's text.</summary>
	/// <value>The menu's text.</value>
	public IndirectString MUIVerb
	{
		get => IndirectString.TryParse(key.GetValue("MUIVerb")?.ToString(), out var loc) ? loc : null;
		set => UpdateValue("MUIVerb", value?.ToString());
	}

	/// <summary>
	/// Gets or sets a value that determines if a user can select a single item, multiple items, or a selection from an item.
	/// </summary>
	/// <value>The multi select model for the menu.</value>
	public VerbMultiSelectModel MultiSelectModel
	{
		get
		{
			var value = key.GetValue("MultiSelectModel", VerbMultiSelectModel.Unset.ToString()).ToString().Replace('|', ',').Replace(" ", "");
			return (VerbMultiSelectModel)Enum.Parse(typeof(VerbMultiSelectModel), value, true);
		}
		set => UpdateValue("MultiSelectModel", value.ToString().Replace(", ", " | "), RegistryValueKind.String, VerbMultiSelectModel.Unset.ToString());
	}

	/// <summary>Gets the text string that is used by the Shell to identify the associated command.</summary>
	/// <value>The verb name.</value>
	public string Name { get; }

	/// <summary>
	/// Gets or sets a value that tells the system that this verb can never be displayed as the default verb for this file type.
	/// </summary>
	/// <value><see langword="true"/> if menu can never be set as default; otherwise, <see langword="false"/>.</value>
	public bool NeverDefault
	{
		get => key.HasValue("NeverDefault");
		set => ToggleValue("NeverDefault", value);
	}

	/// <summary>Gets or sets a value that tells the system that this verb can only be displayed when in an Explorer window.</summary>
	/// <value><see langword="true"/> if menu is only to be displayed when in an Explorer window; otherwise, <see langword="false"/>.</value>
	public bool OnlyInBrowserWindow
	{
		get => key.HasValue("OnlyInBrowserWindow");
		set => ToggleValue("OnlyInBrowserWindow", value);
	}

	/// <summary>
	/// Gets or sets a value that is used to place a verb at the top or bottom of the menu. If there are multiple verbs that specify
	/// this attribute then the last one to do so gets priority
	/// </summary>
	/// <value>The verb menu placement.</value>
	public VerbPosition Position
	{
		get => (VerbPosition)Enum.Parse(typeof(VerbPosition), key.GetValue("Position", VerbPosition.Undefined.ToString()).ToString());
		set => UpdateValue("Position", value.ToString(), RegistryValueKind.String, VerbPosition.Undefined.ToString());
	}

	/// <summary>Gets or sets a value that tells the system that this verb is available for programmatic access only and not displayed.</summary>
	/// <value><see langword="true"/> if verb is available for programmatic access only and not displayed; otherwise, <see langword="false"/>.</value>
	public bool ProgrammaticAccessOnly
	{
		get => key.HasValue("ProgrammaticAccessOnly");
		set => ToggleValue("ProgrammaticAccessOnly", value);
	}

	/// <summary>Gets or sets a value that tells the system to place a separator after this menu item.</summary>
	/// <value><see langword="true"/> if a separator should be displayed after this menu item; otherwise, <see langword="false"/>.</value>
	public bool SeparatorAfter
	{
		get => 1 == key.GetValue("SeparatorAfter", 0) as int?;
		set => UpdateValue("SeparatorAfter", value ? 1 : 0, RegistryValueKind.DWord);
	}

	/// <summary>Gets or sets a value that tells the system to place a separator before this menu item.</summary>
	/// <value><see langword="true"/> if a separator should be displayed before this menu item; otherwise, <see langword="false"/>.</value>
	public bool SeparatorBefore
	{
		get => 1 == key.GetValue("SeparatorBefore", 0) as int?;
		set => UpdateValue("SeparatorBefore", value ? 1 : 0, RegistryValueKind.DWord);
	}

	/// <summary>Gets or sets a value that controls if verb visibility can be suppressed through policy settings.</summary>
	/// <value>A <see cref="Shell32.RESTRICTIONS"/> value.</value>
	public Shell32.RESTRICTIONS SuppressionPolicy
	{
		get => (Shell32.RESTRICTIONS)(int)key.GetValue("SuppressionPolicy", 0);
		set => UpdateValue("SuppressionPolicy", (int)value, RegistryValueKind.DWord);
	}

	/// <summary>Gets or sets an optional CLSID for a handler that controls if verb visibility can be suppressed through policy settings.</summary>
	/// <value>The handler's CLSID value.</value>
	public Guid? SuppressionPolicyEx
	{
		get => key.GetGuidValue("SuppressionPolicyEx");
		set => UpdateValue("SuppressionPolicyEx", value);
	}

	/// <summary>Determines if another <see cref="CommandVerb"/> is equal to this instance.</summary>
	/// <param name="other">The other <see cref="CommandVerb"/>.</param>
	/// <returns><see langword="true"/> if the items are equal; otherwise <see langword="false"/>.</returns>
	public bool Equals(CommandVerb other) => Equals((RegBasedSettings)other);
}