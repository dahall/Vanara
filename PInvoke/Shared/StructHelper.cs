using System;
using System.Runtime.CompilerServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
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
#if !(NET20 || NET35 || NET40)
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public unsafe static T[] FieldToArray<T>(ref T fieldReference, int count, int offset = 0) where T : unmanaged
		{
			if (count == 0) return new T[0];
			return DangerousAddressOf(ref fieldReference).ToArray<T>(count, offset);
		}
	}
}