namespace Vanara.PInvoke;

/// <summary>Helper to convert enum to different underlying base type.</summary>
/// <typeparam name="TEnum">Enum type.</typeparam>
/// <typeparam name="T">Underlying type.</typeparam>
/// <param name="val">Base value.</param>
public readonly struct EnumRebase<TEnum, T>(T val) where TEnum : Enum where T : unmanaged, IConvertible
{
	private readonly T value = val;

	/// <summary>Performs an implicit conversion from <typeparamref name="TEnum"/> to <typeparamref name="T"/>.</summary>
	public static implicit operator EnumRebase<TEnum, T>(TEnum enumVal) => new((T)Convert.ChangeType(enumVal, typeof(T)));

	/// <summary>Performs an implicit conversion from <typeparamref name="T"/> to <typeparamref name="TEnum"/>.</summary>
	public static implicit operator EnumRebase<TEnum, T>(T value) => new(value);

	/// <summary>Performs an implicit conversion from <typeparamref name="T"/> to <typeparamref name="TEnum"/>.</summary>
	public static implicit operator TEnum(EnumRebase<TEnum, T> er) => (TEnum)Enum.ToObject(typeof(TEnum), er.value);
}