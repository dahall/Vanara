using Vanara.PInvoke;

namespace Vanara;

/// <summary>Managed instance of the two-byte VARIANT_BOOL type.</summary>
[TypeDef(typeof(short), ConvertTo = typeof(bool), Excludes = ExcludeOptions.Numerics, GetConvValue = "value != 0", SetConvValue = "value ? True : False")]
public partial struct VARIANT_BOOL
{
	internal const short True = -1;

	internal const short False = 0;

	/// <summary>Performs an explicit conversion from <see cref="VARIANT_BOOL"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(VARIANT_BOOL value) => new(value.value);

	/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="VARIANT_BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator VARIANT_BOOL(IntPtr value) => value != IntPtr.Zero;
}