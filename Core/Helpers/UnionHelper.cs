using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>Methods for working with unions in unmanaged structures.</summary>
public static class UnionHelper
{
	/// <summary>
	/// Retrieves an item of type <typeparamref name="T"/> from an unmanaged structure of type <typeparamref name="TOrig"/> at the specified
	/// offset index.
	/// </summary>
	/// <remarks>
	/// This method is intended for use with unmanaged types only. The caller must ensure that the types <typeparamref name="T"/> and
	/// <typeparamref name="TOrig"/> are compatible and that the memory layout of <typeparamref name="TOrig"/> allows for indexing into its
	/// contents as an array of <typeparamref name="T"/>.
	/// </remarks>
	/// <typeparam name="T">The type of the item to retrieve.</typeparam>
	/// <typeparam name="TOrig">The type of the original unmanaged structure.</typeparam>
	/// <param name="o">The original unmanaged structure from which the item is retrieved.</param>
	/// <param name="index">The zero-based offset index of the item to retrieve. Must be within the bounds of the structure.</param>
	/// <returns>The item of type <typeparamref name="T"/> located at the specified offset index within the original structure.</returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="index"/> is less than zero or greater than or equal to the number of items of type <typeparamref name="T"/>
	/// that can fit within the original structure.
	/// </exception>
	public static T GetArrayItemAtOffset<T, TOrig>(this TOrig o, SIZE_T index) where TOrig : unmanaged where T : unmanaged
	{
		unsafe
		{
			if (index < 0 || index >= sizeof(TOrig) / sizeof(T))
				throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds for the original structure.");
			return *(T*)(&o + index);
		}
	}

	/// <summary>
	/// Retrieves the value of type <typeparamref name="T"/> located at the specified offset within the memory of the unmanaged structure
	/// <typeparamref name="TOrig"/>.
	/// </summary>
	/// <remarks>
	/// This method performs an unsafe memory operation to retrieve the value at the specified offset. Ensure that the offset is valid and
	/// within the bounds of the memory layout of <typeparamref name="TOrig"/>.
	/// </remarks>
	/// <typeparam name="T">The type of the value to retrieve. Must be an unmanaged type.</typeparam>
	/// <typeparam name="TOrig">The type of the original structure. Must be an unmanaged type.</typeparam>
	/// <param name="o">The original structure from which the value is retrieved.</param>
	/// <param name="offset">The byte offset within the memory of the original structure where the value is located.</param>
	/// <returns>The value of type <typeparamref name="T"/> at the specified offset.</returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="offset"/> is less than 0 or greater than or equal to the size of <typeparamref name="TOrig"/>.
	/// </exception>
	public static T GetValueAtOffset<T, TOrig>(this TOrig o, SIZE_T offset) where TOrig : unmanaged where T : unmanaged
	{
		unsafe
		{
			if (offset < 0 || offset >= sizeof(TOrig))
				throw new ArgumentOutOfRangeException(nameof(offset), "Offset is out of bounds for the original structure.");
			return *(T*)((byte*)&o + offset);
		}
	}

	/// <summary>Sets the value of an array-like item at the specified offset within a structure.</summary>
	/// <remarks>
	/// This method operates on unmanaged types and uses unsafe code to directly manipulate memory. The caller must ensure that the structure
	/// and types are compatible and that the index is within bounds.
	/// </remarks>
	/// <typeparam name="T">The type of the item to set. Must be an unmanaged type.</typeparam>
	/// <typeparam name="TOrig">The type of the original structure containing the array-like data. Must be an unmanaged type.</typeparam>
	/// <param name="o">A reference to the original structure containing the array-like data.</param>
	/// <param name="index">The zero-based index of the item to set within the structure.</param>
	/// <param name="value">The value to set at the specified index.</param>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="index"/> is less than 0 or greater than or equal to the number of items that can fit within the original structure.
	/// </exception>
	public static void SetArrayItemAtOffset<T, TOrig>(ref TOrig o, SIZE_T index, T value) where TOrig : unmanaged where T : unmanaged
	{
		unsafe
		{
			fixed (TOrig* ptr = &o)
			{
				if (index < 0 || index >= sizeof(TOrig) / sizeof(T))
					throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds for the original structure.");
				*(T*)(ptr + index) = value;
			}
		}
	}

	/// <summary>Sets the value of a specified type at a given byte offset within an unmanaged structure.</summary>
	/// <remarks>
	/// This method uses unsafe code to directly manipulate memory. Ensure that the offset is valid and does not exceed the size of the
	/// original structure. Improper use of this method can lead to memory corruption or undefined behavior.
	/// </remarks>
	/// <typeparam name="T">The type of the value to set. Must be an unmanaged type.</typeparam>
	/// <typeparam name="TOrig">The type of the original structure. Must be an unmanaged type.</typeparam>
	/// <param name="o">The original structure in which the value will be set.</param>
	/// <param name="offset">The byte offset within the structure where the value will be set. Must be within the bounds of the structure.</param>
	/// <param name="value">The value to set at the specified offset.</param>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if <paramref name="offset"/> is less than 0 or greater than or equal to the size of the original structure.
	/// </exception>
	public static void SetValueAtOffset<T, TOrig>(ref TOrig o, SIZE_T offset, T value) where TOrig : unmanaged where T : unmanaged
	{
		unsafe
		{
			fixed (TOrig* ptr = &o)
			{
				if (offset < 0 || offset >= sizeof(TOrig))
					throw new ArgumentOutOfRangeException(nameof(offset), "Offset is out of bounds for the original structure.");
				*(T*)((byte*)ptr + offset) = value;
			}
		}
	}
}