using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Shell
{
	/// <summary>Wraps the icon location string used by some Shell classes.</summary>
	[TypeConverter(typeof(IconLocationTypeConverter))]
	public class IconLocation : IndirectResource
	{
		/// <summary>Initializes a new instance of the <see cref="IconLocation"/> class.</summary>
		public IconLocation() { }

		/// <summary>Initializes a new instance of the <see cref="IconLocation"/> class.</summary>
		/// <param name="module">The module file name.</param>
		/// <param name="resourceIdOrIndex">If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number is the resource ID of the icon in the module file.</param>
		public IconLocation(string module, int resourceIdOrIndex) : base(module, resourceIdOrIndex) { }

		/// <summary>Gets the icon referred to by this instance.</summary>
		/// <value>The icon.</value>
		[Browsable(false)]
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

	internal class IconLocationTypeConverter : ExpandableObjectConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
		{
			if (destType == typeof(InstanceDescriptor) || destType == typeof(string))
				return true;
			return base.CanConvertTo(context, destType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string s)
				return IconLocation.TryParse(s, out var loc) ? loc : null;
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo info, object value, Type destType)
		{
			if (destType == typeof(InstanceDescriptor))
				return new InstanceDescriptor(typeof(IconLocation).GetConstructor(new Type[0]), null, false);
			if (destType == typeof(string) && value is IconLocation s)
				return s.ToString();
			return base.ConvertTo(context, info, value, destType);
		}
	}

}