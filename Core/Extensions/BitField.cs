namespace Vanara;

/// <summary>A struct that allows for bit manipulation of a value type.</summary>
/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
/// <param name="data">The initial value of the bitfield.</param>
[StructLayout(LayoutKind.Sequential)]
public struct BitField<T>(T data = default) where T : unmanaged, IConvertible
{
	private T data = data;

	/// <summary>Gets or sets the value of the bit at the specified index.</summary>
	/// <param name="index">The zero-based index of the bit to get.</param>
	/// <returns><see langword="true"/> if the bit is set (1); <see langword="false"/> otherwise.</returns>
	public bool this[int index]
	{
		get => (ValidateIndex(index) & (1UL << index)) != 0;
		set => data = (T)Convert.ChangeType(value ? ValidateIndex(index) | (1UL << index) : ValidateIndex(index) & ~(1UL << index), typeof(T));
	}

	/// <summary>Gets the bit array value from the specified range in a bit vector.</summary>
	/// <param name="range">The zero-based start and end indicies of the bit range to get or set.</param>
	/// <returns>The value of the requested bit range.</returns>
	public T this[Range range]
	{
		get => (T)Convert.ChangeType((ValidateRange(range) >> range.Start.Value) & ((1UL << (range.End.Value - range.Start.Value + 1)) - 1UL), typeof(T));
		set => data = (T)Convert.ChangeType((ValidateRange(range) & ~(((1UL << (range.End.Value - range.Start.Value + 1)) - 1UL) << range.Start.Value)) | (Convert.ToUInt64(value) << range.Start.Value), typeof(T));
	}

	/// <summary>Performs an implicit conversion from <see cref="BitField{T}"/> to <typeparamref name="T"/>.</summary>
	/// <param name="bf">The <see cref="BitField{T}"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator T(BitField<T> bf) => bf.data;

	private ulong ValidateIndex(int index) => index >= 0 && index < Marshal.SizeOf<T>() * 8 ? unchecked((ulong)data.ToInt64(null)) : throw new IndexOutOfRangeException("The index is not valid for the underlying type.");
	private ulong ValidateRange(Range range) => range.Start.Value <= range.End.Value && range.Start.Value >= 0 && range.End.Value < Marshal.SizeOf<T>() * 8 ? unchecked((ulong)data.ToInt64(null)) : throw new IndexOutOfRangeException("The index is not valid for the underlying type.");
}