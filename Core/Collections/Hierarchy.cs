using System;
using System.Collections.Generic;

namespace Vanara.Collections
{
	/// <summary>Represents a node in a <see cref="Hierarchy"/>.</summary>
	public class Entry
	{
		/// <summary>Initializes a new instance of the <see cref="Entry"/> class.</summary>
		/// <param name="key">The key.</param>
		public Entry(string key)
		{
			Key = key;
		}

		/// <summary>Gets the children of this <see cref="Entry"/>.</summary>
		public Hierarchy Children { get; } = new Hierarchy();

		/// <summary>Gets or sets the key for this <see cref="Entry"/>.</summary>
		/// <value>A unique string value.</value>
		public string Key { get; }
	}

	/// <summary>Storage and parsing of flat string based folder hierarchy.</summary>
	/// <example>
	/// <code>
	/// Hierarchy cItems = new Hierarchy();
	/// cItems.AddEntry(sLine, 0);
	/// </code>
	/// </example>
	public class Hierarchy : Dictionary<string, Entry>
	{
		/// <summary>Gets or sets the separator used to split the hierarchy.</summary>
		/// <value>The separator.</value>
		public string Separator { get; set; } = "\\";

		/// <summary>Parses and adds the entry to the hierarchy, creating any parent entries as required.</summary>
		/// <param name="entry">The entry.</param>
		/// <param name="startIndex">The start index.</param>
		public void AddEntry(string entry, int startIndex = 0)
		{
			if (string.IsNullOrEmpty(entry)) throw new ArgumentNullException(nameof(entry));
			if (startIndex >= entry.Length)
				return;

			var endIndex = entry.IndexOf(Separator, startIndex, StringComparison.InvariantCulture);
			if (endIndex == -1)
				endIndex = entry.Length;
			var key = entry.Substring(startIndex, endIndex - startIndex);
			if (string.IsNullOrEmpty(key))
				return;

			Entry item;
			if (ContainsKey(key))
			{
				item = this[key];
			}
			else
			{
				item = new Entry(key);
				Add(key, item);
			}
			// Now add the rest to the new item's children
			item.Children.AddEntry(entry, endIndex + 1);
		}
	}
}