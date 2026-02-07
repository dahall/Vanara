using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

/// <summary>Helper methods for structures.</summary>
public static class StructHelper
{
	/// <summary>Gets the address of a reference.</summary>
	/// <typeparam name="T">The unmanaged value type to convert.</typeparam>
	/// <param name="target">The target value.</param>
	/// <returns>The address of <paramref name="target"/>.</returns>
	/// <remarks>This address will only remain valid if the target value or its encapsulating type are pinned.</remarks>
	public static IntPtr DangerousAddressOf<T>(ref T target) where T : unmanaged
	{
		unsafe
		{
			fixed (T* p = &target)
				return (IntPtr)p;
		}
	}

	/// <summary>Converts a field reference to array. Used when a structure defines an ANYSIZE array as the last field.</summary>
	/// <typeparam name="T">The unmanaged type to convert.</typeparam>
	/// <param name="fieldReference">A reference to the field value.</param>
	/// <param name="count">The number of items in the array.</param>
	/// <param name="offset">The offset from the field value at which to start extracting the array.</param>
	/// <returns>An <paramref name="count"/> item array of values of <typeparamref name="T"/>.</returns>
	/// <remarks>
	/// Properties defined with this can only be safely used when the structure has been marshaled via a dynamic memory block and not
	/// when marshaled directly.
	/// </remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static T[] FieldToArray<T>(ref T fieldReference, int count, int offset = 0) where T : unmanaged =>
		count == 0 ? [] : DangerousAddressOf(ref fieldReference).ToArray<T>(count, offset) ?? [];

	/// <summary>Creates a new instance of <typeparamref name="T"/> with a size field set to the size of its unmanaged type.</summary>
	/// <typeparam name="T">The type to return .</typeparam>
	/// <param name="fieldName">
	/// Name of the field which is assigned the size. If <see langword="null"/>, the first public or private field is used.
	/// </param>
	/// <returns>An initialized instance of <typeparamref name="T"/>.</returns>
	public static T InitWithSize<T>(string? fieldName = null) where T : new()
	{
		const BindingFlags bf = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		var fi = (fieldName is null ? typeof(T).GetOrderedFields(bf).FirstOrDefault() : typeof(T).GetField(fieldName, bf)) ?? throw new ArgumentException($"A field named '{nameof(fieldName)}' cannot be found.");
		var ret = (object)new T();
		fi.SetValue(ret, Convert.ChangeType((uint)InteropExtensions.SizeOf<T>(), fi.FieldType));
		return (T)ret;
	}

	/// <summary>
	/// Initializes a fixed-length array by copying the contents of the specified array and padding with default values if
	/// necessary.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="fixedLen">The required length of the returned array. Must be greater than or equal to the length of <paramref name="array"/>.</param>
	/// <param name="array">The source array whose elements are to be copied. If null, an empty array is used.</param>
	/// <returns>A new array of length <paramref name="fixedLen"/> containing the elements of <paramref name="array"/>, followed by
	/// default values if <paramref name="array"/> is shorter than <paramref name="fixedLen"/>. If <paramref name="array"/>
	/// is already of the required length, the original array is returned.</returns>
	/// <exception cref="ArgumentException">Thrown if the length of <paramref name="array"/> is greater than <paramref name="fixedLen"/>.</exception>
	public static T[] InitFixedArray<T>(int fixedLen, T[] array)
	{
		array ??= [];
		if (array.Length > fixedLen)
			throw new ArgumentException($"The length of {nameof(array)} is larger than {nameof(fixedLen)} limit.", nameof(array));
		if (array.Length == fixedLen)
			return array;
		var ret = new T[fixedLen];
		Array.Copy(array, ret, array.Length);
		return ret;
	}
}