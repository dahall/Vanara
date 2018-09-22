using System;
using System.Drawing;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Shell
{
	/// <summary>Wraps the icon location string used by some Shell classes.</summary>
	public class IconLocation
	{
		/// <summary>Initializes a new instance of the <see cref="IconLocation"/> class.</summary>
		public IconLocation() { }

		/// <summary>Initializes a new instance of the <see cref="IconLocation"/> class.</summary>
		/// <param name="module">The module file name.</param>
		/// <param name="resourceIdOrIndex">If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number is the resource ID of the icon in the module file.</param>
		public IconLocation(string module, int resourceIdOrIndex)
		{
			ModuleFileName = module;
			ResourceId = resourceIdOrIndex;
		}

		/// <summary>Gets the icon referred to by this instance.</summary>
		/// <value>The icon.</value>
		public Icon Icon
		{
			get
			{
				if (!IsValid) return null;
				using (var lib = LoadLibraryEx(ModuleFileName, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
					return new SafeHICON(LoadImage(lib, ResourceId, LoadImageType.IMAGE_ICON, 0, 0, 0)).ToIcon();
				//var hIconEx = new[] { IntPtr.Zero };
				//if (large)
				//	ExtractIconEx(loc.ModuleFileName, loc.ResourceId, hIconEx, null, 1);
				//else
				//	ExtractIconEx(loc.ModuleFileName, loc.ResourceId, null, hIconEx, 1);
			}
		}

		/// <summary>Returns true if this location is valid.</summary>
		/// <value><c>true</c> if this location is valid; otherwise, <c>false</c>.</value>
		public bool IsValid => System.IO.File.Exists(ModuleFileName) && ResourceId != 0;

		/// <summary>Gets or sets the module file name.</summary>
		/// <value>The module file name.</value>
		public string ModuleFileName { get; set; }

		/// <summary>Gets or sets the resource index or resource ID.</summary>
		/// <value>If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number is the resource ID of the icon in the module file.</value>
		public int ResourceId { get; set; }

		/// <summary>Gets the string value.</summary>
		/// <value>The string value.</value>
		public string StringValue => IsValid ? ToString() : null;

		/// <summary>Tries to parse the specified string to create a <see cref="IconLocation"/> instance.</summary>
		/// <param name="value">The string representation in the format of either "ModuleFileName,ResourceIndex" or "ModuleFileName,-ResourceID".</param>
		/// <param name="loc">The resulting <see cref="IconLocation"/> instance on success.</param>
		/// <returns><c>true</c> if successfully parsed.</returns>
		public static bool TryParse(string value, out IconLocation loc)
		{
			var parts = value?.Split(',');
			if (parts != null && parts.Length == 2 && int.TryParse(parts[1], out var i))
			{
				loc = new IconLocation(parts[0], i);
				return true;
			}
			loc = new IconLocation();
			return false;
		}

		/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString() => IsValid ? $"{ModuleFileName},{ResourceId}" : string.Empty;
	}
}