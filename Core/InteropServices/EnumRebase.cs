namespace Vanara.PInvoke;

/// <summary>Helper to convert enum to different underlying base type.</summary>
/// <typeparam name="TEnum">Enum type.</typeparam>
/// <typeparam name="T">Underlying type.</typeparam>
/// <param name="enumVal">Enum value.</param>
public readonly struct EnumRebase<TEnum, T>(TEnum enumVal) where TEnum : Enum where T : unmanaged, IConvertible
{
	private readonly T value = (T)Convert.ChangeType(enumVal, typeof(T));

	/// <summary>Performs an implicit conversion from <typeparamref name="TEnum"/> to <typeparamref name="T"/>.</summary>
	public static implicit operator EnumRebase<TEnum, T>(TEnum e) => new(e);

	/// <summary>Performs an implicit conversion from <typeparamref name="T"/> to <typeparamref name="TEnum"/>.</summary>
	public static implicit operator EnumRebase<TEnum, T>(T v) => new((TEnum)Enum.ToObject(typeof(TEnum), v));
}