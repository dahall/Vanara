namespace Vanara.InteropServices;

/// <summary>Provides a custom marshaler for converting <see cref="Guid"/> objects to and from native string representations.</summary>
/// <remarks>
/// This marshaler is designed to handle the conversion of <see cref="Guid"/> instances to native strings and back, using a specified format
/// and character set.
/// </remarks>
public class GuidToStringMarshaler : ICustomMarshaler
{
	/// <summary>Format specifier for the GUID string representation.</summary>
	public readonly string fmt;

	/// <summary>Character set used for the string representation.</summary>
	public readonly CharSet charSet;

	/// <summary>Initializes a new instance of the <see cref="GuidToStringMarshaler"/> class.</summary>
	public static ICustomMarshaler GetInstance(string? format = null) => new GuidToStringMarshaler(format);

	/// <summary>Initializes a new instance of the <see cref="GuidToStringMarshaler"/> class.</summary>
	/// <param name="format">
	/// The format string can include a standard GUID format specifier (e.g., "D", "N", "B", "P", or "X") and an optional <see cref="CharSet"/>
	/// value (e.g., "Ansi", "Unicode") separated by a comma. If no format is provided, the default format is "D" with the default character set
	/// determined by the runtime.
	/// </param>
	protected GuidToStringMarshaler(string? format) => (fmt, charSet) = ParseFormat(format);

	void ICustomMarshaler.CleanUpManagedData(object ManagedObj) { }

	void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => StringHelper.FreeString(pNativeData);

	int ICustomMarshaler.GetNativeDataSize() => IntPtr.Size;

	IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj)
	{
		if (ManagedObj is null) return IntPtr.Zero;
		if (ManagedObj is string s && Guid.TryParse(s, out var g))
			return StringHelper.AllocString(g.ToString(fmt), charSet);
		if (ManagedObj is Guid g2)
			return StringHelper.AllocString(g2.ToString(fmt), charSet);
		throw new ArgumentException("Managed object must be a Guid or a string with a Guid representation.", nameof(ManagedObj));
	}

	object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData)
	{
		if (pNativeData == IntPtr.Zero) return null!;
		return Guid.TryParse(StringHelper.GetString(pNativeData, charSet), out var g) ? g : throw new FormatException($"Invalid GUID format: '{StringHelper.GetString(pNativeData, charSet)}'.");
	}

	internal static (string fmt, CharSet charSet) ParseFormat(string? format)
	{
		if (string.IsNullOrWhiteSpace(format)) return ("D", CharSet.Auto);
		var parts = Array.ConvertAll((format ?? "").Split([',', '|'], StringSplitOptions.RemoveEmptyEntries), s => s.Trim());
		switch (parts.Length)
		{
			case 0:
				return ("D", CharSet.Auto);

			case 1:
				if (IsValidFormat(parts[0]))
					return (parts[0], CharSet.Auto);
				else return GetCS(parts[0]) is CharSet cs1
					? ((string fmt, CharSet charSet))("D", cs1)
					: throw new FormatException("Format string must be a valid format specifier or a valid CharSet.");
			case 2:
				if (!IsValidFormat(parts[0]) || GetCS(parts[1]) is not CharSet cs)
					throw new FormatException("Format string can only contain a single format specifier and an optional CharSet, separted by a comma.");
				return (parts[0], cs);

			default:
				throw new FormatException("Format string can only contain a single format specifier and an optional CharSet, separted by a comma.");
		}

		static bool IsValidFormat(string fmt) => fmt.Length == 1 && fmt.ToUpper()[0] is 'D' or 'N' or 'B' or 'P' or 'X';
		static CharSet? GetCS(string fmt) => fmt.Length >= 4 && Enum.TryParse<CharSet>(fmt, true, out var cs) ? cs : null;
	}
}