using System;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Shell
{
	/// <summary>Wraps the icon location string used by some Shell classes.</summary>
	public class IndirectString
	{
		/// <summary>Initializes a new instance of the <see cref="IndirectString"/> class.</summary>
		public IndirectString() { }

		/// <summary>Initializes a new instance of the <see cref="IndirectString"/> class.</summary>
		/// <param name="module">The module file name.</param>
		/// <param name="resourceIdOrIndex">
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the icon in the module file.
		/// </param>
		public IndirectString(string module, int resourceIdOrIndex)
		{
			ModuleFileName = module;
			ResourceId = resourceIdOrIndex;
		}

		/// <summary>Returns true if this location is valid.</summary>
		/// <value><c>true</c> if this location is valid; otherwise, <c>false</c>.</value>
		public bool IsValid => System.IO.File.Exists(ModuleFileName) && ResourceId != 0;

		/// <summary>Gets or sets the module file name.</summary>
		/// <value>The module file name.</value>
		public string ModuleFileName { get; set; }

		/// <summary>Gets or sets the resource index or resource ID.</summary>
		/// <value>
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the icon in the module file.
		/// </value>
		public int ResourceId { get; set; }

		/// <summary>Gets the icon referred to by this instance.</summary>
		/// <value>The icon.</value>
		public string Value
		{
			get
			{
				if (!IsValid) return null;
				using (var lib = LoadLibraryEx(ModuleFileName, Kernel32.LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
				{
					if (ResourceId >= 0) throw new NotSupportedException();
					const int sz = 2048;
					var sb = new System.Text.StringBuilder(sz, sz);
					LoadString(lib, -ResourceId, sb, sz);
					return sb.ToString();
				}
			}
		}

		/// <summary>Tries to parse the specified string to create a <see cref="IndirectString"/> instance.</summary>
		/// <param name="value">The string representation in the format of either "ModuleFileName,ResourceIndex" or "ModuleFileName,-ResourceID".</param>
		/// <param name="loc">The resulting <see cref="IndirectString"/> instance on success.</param>
		/// <returns><c>true</c> if successfully parsed.</returns>
		public static bool TryParse(string value, out IndirectString loc)
		{
			var parts = value?.Split(',');
			if (parts != null && parts.Length == 2 && int.TryParse(parts[1], out var i) && parts[0].StartsWith("@"))
			{
				loc = new IndirectString(parts[0].TrimStart('@'), i);
				return true;
			}
			loc = new IndirectString();
			return false;
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => IsValid ? $"@{ModuleFileName},{ResourceId}" : string.Empty;
	}
}