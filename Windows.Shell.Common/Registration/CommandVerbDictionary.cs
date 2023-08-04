using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Vanara.Windows.Shell;

/// <summary>A dictionary of Command Verbs defined in the Windows Registry.</summary>
/// <seealso cref="RegBasedDictionary{T}"/>
public class CommandVerbDictionary : RegBasedDictionary<CommandVerb>
{
	private const string rootKeyName = "shell";
	private readonly RegBasedSettings parent;

	internal CommandVerbDictionary(RegBasedSettings parent, bool readOnly) : base(parent.key.OpenSubKey(rootKeyName, !readOnly), readOnly) => this.parent = parent;

	/// <summary>Gets or sets the default verb.</summary>
	/// <value>The default verb.</value>
	[DefaultValue(null)]
	public string DefaultVerb
	{
		get => key.GetValue(null)?.ToString();
		set { if (ContainsKey(value)) key.SetValue(null, value); else throw new KeyNotFoundException("The command verb specified is not defined."); }
	}

	/// <summary>Get the filtered list of keys under the base.</summary>
	[Browsable(false)]
	public override IEnumerable<string> Keys => key?.GetSubKeyNames() ?? new string[0];

	/// <summary>Gets or sets the order of the command verbs.</summary>
	/// <value>The ordered list of command verbs.</value>
	[Browsable(false)]
	public IList<CommandVerb> Order
	{
		get
		{
			var order = key.GetValue("", null)?.ToString();
			var vals = Values.ToList();
			if (order != null)
			{
				var orderedItems = order.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				for (var i = orderedItems.Length - 1; i >= 0; i--)
				{
					var match = vals.Find(c =>
						string.Equals(c.Name, orderedItems[i], StringComparison.InvariantCultureIgnoreCase));
					if (match == null) continue;
					vals.Remove(match);
					vals.Insert(0, match);
				}
			}
			return vals;
		}
		set
		{
			switch (value?.Count ?? 0)
			{
				case 0:
					key.DeleteValue("", false);
					break;

				case 1:
					key.SetValue("", value.First().Name);
					break;

				default:
					key.SetValue("", string.Join(",", value.Select(c => c.Name).ToArray()));
					break;
			}
		}
	}

	/// <summary>Adds the specified command verb.</summary>
	/// <param name="verb">The command verb name.</param>
	/// <param name="displayName">
	/// The command verb display name. This is the string shown to the user when requesting a context menu for a shell item.
	/// </param>
	/// <param name="command">The command to execute.</param>
	/// <param name="setAsDefault">if set to <see langword="true"/> set this verb as default.</param>
	/// <returns>A <see cref="CommandVerb"/> instance which has been added to the registry.</returns>
	public CommandVerb Add(string verb, string displayName = null, string command = null, bool setAsDefault = false)
	{
		if (key == null && !readOnly)
			key = parent.key.CreateSubKey(rootKeyName);
		var vkey = key.CreateSubKey(verb) ?? throw new InvalidOperationException("Unable to create required key in registry.");
		var v = new CommandVerb(vkey, verb, false) { DisplayName = displayName, Command = command };
		if (setAsDefault) key.SetValue(null, verb);
		return v;
	}

	/// <summary>Determines if a specified key is in the filtered list of keys under the base.</summary>
	/// <param name="verb">The name of the key to check.</param>
	/// <returns><see langword="true" /> if the key is found; otherwise <see langword="false" />.</returns>
	public override bool ContainsKey(string verb) => key?.HasSubKey(verb) ?? false;

	/// <summary>Removes the specified key from this dictionary and the registry.</summary>
	/// <param name="verb">The name of the command verb to remove.</param>
	/// <returns>A value indicating success (<see langword="true"/>) or failure (<see langword="false"/>).</returns>
	public bool Remove(string verb)
	{
		try
		{
			key.DeleteSubKeyTree(verb);
			return true;
		}
		catch
		{
			return false;
		}
	}

	/// <summary>Tries to get the <see cref="CommandVerb"/> with the name <paramref name="verb"/>.</summary>
	/// <param name="verb">The verb name.</param>
	/// <param name="value">On success, the corresponding <see cref="CommandVerb"/> instance; <see langword="null"/> on failure.</param>
	/// <returns>A value indicating if <paramref name="verb"/> was found.</returns>
	public override bool TryGetValue(string verb, out CommandVerb value)
	{
		value = null;
		if (!ContainsKey(verb)) return false;
		value = new CommandVerb(key.OpenSubKey(verb, !readOnly), verb, readOnly);
		return true;
	}
}