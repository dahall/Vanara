using System;
using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Interface that identifies a structure containing only a 4-byte size field followed by a pointer to an array of <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">A marshalable structure.</typeparam>
	public interface IArrayStruct<T> where T : struct { }

	/// <summary>Extension methods for <see cref="IArrayStruct{T}"/>.</summary>
	public static class IArrayStructExtensions
	{
		/// <summary>Gets the array from an <see cref="IArrayStruct{T}"/> instance.</summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="ias">The <see cref="IArrayStruct{T}"/> instance.</param>
		/// <returns>The array contained in the instance.</returns>
		public static T[] GetArray<T>(this IArrayStruct<T> ias) where T : struct
		{
			using var pin = new PinnedObject(ias);
			return ((IntPtr)pin).ToArray<T>((int)((IntPtr)pin).ToStructure<uint>(), sizeof(uint));
		}
	}

	/// <summary>Allows marshaling of arrays in place of a structure supporting <see cref="IArrayStruct{T}"/>.</summary>
	/// <typeparam name="T">The type of the array element.</typeparam>
	/// <seealso cref="Vanara.InteropServices.IVanaraMarshaler"/>
	public class IArrayStructMarshaler<T> : IVanaraMarshaler where T : struct
	{
		public static readonly int hSz = sizeof(uint);

		/// <inheritdoc/>
		public SizeT GetNativeSize() => hSz + IntPtr.Size;

		/// <inheritdoc/>
		public SafeAllocatedMemoryHandle MarshalManagedToNative(object managedObject)
		{
			if (managedObject is IEnumerable<T> ias)
			{
				var cnt = ias.Count();
				var mem = new SafeHGlobalHandle(hSz + InteropExtensions.SizeOf<T>() * cnt);
				mem.Write(cnt);
				mem.Write(ias, true, hSz);
				return mem;
			}
			throw new ArgumentException("Unexpected type. Value must be of IEnumerable<T>.");
		}

		/// <inheritdoc/>
		public object MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
		{
			if (pNativeData == default) return new T[0];
			var cnt = pNativeData.ToStructure<uint>();
			return pNativeData.ToArray<T>((int)cnt, hSz, allocatedBytes);
		}
	}
}