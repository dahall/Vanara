using System.ComponentModel;
using System.Globalization;
using Vanara.Extensions.Reflection;

namespace Vanara.PInvoke;

/// <summary>Converts a handle to a string or an integer and vice versa. The string representation is the handle value as an integer.</summary>
/// <seealso cref="System.ComponentModel.TypeConverter"/>
public class HANDLEConverter : TypeConverter
{
	/// <inheritdoc/>
	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string) || sourceType == typeof(int) ||
		sourceType == typeof(int) || sourceType.InheritsFrom<IHandle>() || base.CanConvertFrom(context, sourceType);

	/// <inheritdoc/>
	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) => value switch
	{
		null => IntPtr.Zero,
		string s => s.ToLower(culture).Trim() == "null" ? IntPtr.Zero : new IntPtr(long.Parse(s)),
		int i => new IntPtr(i),
		IHandle h => h.DangerousGetHandle(),
		_ => base.ConvertFrom(context, culture, value)
	};

	/// <inheritdoc/>
	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		value ??= HANDLE.NULL;
		if (destinationType == typeof(string))
		{
			if (value is IHandle h)
				return SVal(h.DangerousGetHandle().ToInt64());
			if (value is IConvertible c)
				return SVal(c.ToInt64(culture));
			try { return SVal(((IntPtr)value).ToInt64()); } catch { }
		}
		return base.ConvertTo(context, culture, value, destinationType);

		static string SVal(long v) => v == 0 ? "NULL" : v.ToString();
	}
}