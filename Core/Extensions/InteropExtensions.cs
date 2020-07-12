using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Collections;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for System.Runtime.InteropServices.</summary>
	public static partial class InteropExtensions
	{
#if ALLOWSPAN
		/// <summary>Returns the pointer as a <see cref="ReadOnlySpan{T}"/>.</summary>
		/// <typeparam name="T">The type of items in the <see cref="ReadOnlySpan{T}"/>.</typeparam>
		/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
		/// <param name="length">The number of <typeparamref name="T"/> elements to be included in the <see cref="ReadOnlySpan{T}"/>.</param>
		/// <param name="prefixBytes">Bytes to skip before starting the span.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>A <see cref="ReadOnlySpan{T}"/> that represents the memory.</returns>
		/// <exception cref="System.InsufficientMemoryException"></exception>
		public static unsafe ReadOnlySpan<T> AsReadOnlySpan<T>(this IntPtr ptr, int length, int prefixBytes = 0, SizeT allocatedBytes = default)
		{
			if (ptr == IntPtr.Zero) return null;
			if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
			if (allocatedBytes > 0 && SizeOf<T>() * length + prefixBytes > allocatedBytes)
				throw new InsufficientMemoryException();

			return new ReadOnlySpan<T>((ptr + prefixBytes).ToPointer(), length);
		}

		/// <summary>Returns the pointer as a <see cref="Span{T}"/>.</summary>
		/// <typeparam name="T">The type of items in the <see cref="Span{T}"/>.</typeparam>
		/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
		/// <param name="length">The number of <typeparamref name="T"/> elements to be included in the <see cref="Span{T}"/>.</param>
		/// <param name="prefixBytes">Bytes to skip before starting the span.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>A <see cref="Span{T}"/> that represents the memory.</returns>
		/// <exception cref="System.InsufficientMemoryException"></exception>
		public static unsafe Span<T> AsSpan<T>(this IntPtr ptr, int length, int prefixBytes = 0, SizeT allocatedBytes = default)
		{
			if (ptr == IntPtr.Zero) return null;
			if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
			if (allocatedBytes > 0 && SizeOf<T>() * length + prefixBytes > allocatedBytes)
				throw new InsufficientMemoryException();

			return new Span<T>((ptr + prefixBytes).ToPointer(), length);
		}
#endif

		/// <summary>Returns the pointer.</summary>
		/// <typeparam name="T">The type of items.</typeparam>
		/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
		/// <param name="length">The number of <typeparamref name="T"/> elements to be included in the pointer.</param>
		/// <param name="prefixBytes">Bytes to skip before starting the span.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>A pointer that represents the memory.</returns>
		/// <exception cref="System.InsufficientMemoryException"></exception>
		public static unsafe T* AsUnmanagedArrayPointer<T>(this IntPtr ptr, int length, int prefixBytes = 0, SizeT allocatedBytes = default) where T : unmanaged
		{
			if (ptr == IntPtr.Zero) return null;
			if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
			if (allocatedBytes > 0 && SizeOf<T>() * length + prefixBytes > allocatedBytes)
				throw new InsufficientMemoryException();

			return (T*)ptr.Offset(prefixBytes).ToPointer();
		}

		/// <summary>Copies the number of specified bytes from one unmanaged memory block to another.</summary>
		/// <param name="ptr">The allocated memory pointer.</param>
		/// <param name="dest">The allocated memory pointer to copy to.</param>
		/// <param name="length">The number of bytes to copy from <paramref name="ptr"/> to <paramref name="dest"/>.</param>
		public static void CopyTo(this IntPtr ptr, IntPtr dest, long length) => CopyTo(ptr, 0L, dest, length);

		/// <summary>Copies the number of specified bytes from one unmanaged memory block to another.</summary>
		/// <param name="source">The allocated memory pointer.</param>
		/// <param name="start">The offset from <paramref name="source"/> at which to start the copying.</param>
		/// <param name="dest">The allocated memory pointer to copy to.</param>
		/// <param name="length">The number of bytes to copy from <paramref name="source"/> to <paramref name="dest"/>.</param>
		public static void CopyTo(this IntPtr source, long start, IntPtr dest, long length)
		{
			if (start < 0 || length < 0) throw new ArgumentOutOfRangeException();
			if (source == IntPtr.Zero || dest == IntPtr.Zero) throw new ArgumentNullException();
			unsafe
			{
				byte* psrc = (byte*)source + start, pdest = (byte*)dest;
				for (long i = 0; i < length; i++, psrc++, pdest++)
					*pdest = *psrc;
			}
		}

		/// <summary>
		/// Fills the memory with a particular byte value. <note type="warning">This is a very dangerous function that can cause memory
		/// access errors if the provided <paramref name="length"/> is bigger than allocated memory of if the <paramref name="ptr"/> is not a
		/// valid memory pointer.</note>
		/// </summary>
		/// <param name="ptr">The allocated memory pointer.</param>
		/// <param name="value">The byte value with which to fill the memory.</param>
		/// <param name="length">The number of bytes to fill with the value.</param>
		public static void FillMemory(this IntPtr ptr, byte value, long length)
		{
			if (ptr == IntPtr.Zero || length <= 0) return;
			// Write multiples of 8 bytes first
			var lval = value == 0 ? 0L : BitConverter.ToInt64(new[] { value, value, value, value, value, value, value, value }, 0);
			for (var ofs = 0L; ofs < length / 8; ofs++)
				Marshal.WriteInt64(ptr.Offset(ofs * 8), 0, lval);
			// Write remaining bytes
			for (var ofs = length - (length % 8); ofs < length; ofs++)
				Marshal.WriteByte(ptr.Offset(ofs), 0, value);
		}

		/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="IEnumerator{T}"/>.</summary>
		/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="count">The number of items in the native array.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
		public static IEnumerator<T> GetEnumerator<T>(this IntPtr ptr, int count, int prefixBytes = 0, SizeT allocatedBytes = default) =>
			new NativeMemoryEnumerator<T>(ptr, count, prefixBytes, allocatedBytes);

		/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="System.Collections.IEnumerator"/>.</summary>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="type">Type of native structure used by the C-style array.</param>
		/// <param name="count">The number of items in the native array.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
		public static System.Collections.IEnumerator GetEnumerator(this IntPtr ptr, Type type, int count, int prefixBytes = 0, SizeT allocatedBytes = default) =>
			new UntypedNativeMemoryEnumerator(ptr, type, count, prefixBytes, allocatedBytes);

		/// <summary>
		/// Gets the length of a null terminated array of pointers. <note type="warning">This is a very dangerous function and can result in
		/// memory access errors if the <paramref name="lptr"/> does not point to a null-terminated array of pointers.</note>
		/// </summary>
		/// <param name="lptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <returns>
		/// The number of non-null pointers in the array. If <paramref name="lptr"/> is equal to IntPtr.Zero, this result is 0.
		/// </returns>
		public static int GetNulledPtrArrayLength(this IntPtr lptr)
		{
			if (lptr == IntPtr.Zero) return 0;
			var c = 0;
			while (Marshal.ReadIntPtr(lptr, IntPtr.Size * c++) != IntPtr.Zero) { }

			return c - 1;
		}

		/// <summary>Determines whether this type is formatted or blittable.</summary>
		/// <param name="T">The type to check.</param>
		/// <returns><see langword="true"/> if the specified type is blittable; otherwise, <see langword="false"/>.</returns>
		public static bool IsBlittable(this Type T)
		{
			if (T is null) return false;

			// if (T.IsArray && T.GetArrayRank() > 1) return false; // Need to find a way to exclude jagged arrays
			while (T.IsArray)
				T = T.GetElementType();
			//
			//if (T == typeof(decimal) || T.IsAbstract || T.IsAutoClass || T.IsGenericType) return false;
			//if (T.IsEnum || T.IsPrimitive && T != typeof(bool) && T != typeof(char)) return true;
			//try
			//{
			//	GCHandle.Alloc(FormatterServices.GetUninitializedObject(T), GCHandleType.Pinned).Free();
			//	return true;
			//}
			//catch
			//{
			//	return false;
			//}
			if (T.IsEnum) return true;
			try { Marshal.SizeOf(T); return true; } catch { return false; }
		}

		/// <summary>Determines whether this type is marshalable.</summary>
		/// <param name="type">The type to check.</param>
		/// <returns><see langword="true"/> if the specified type is marshalable; otherwise, <see langword="false"/>.</returns>
		public static bool IsMarshalable(this Type type)
		{
			var t = type.IsNullable() ? type.GetGenericArguments()[0] : type;
			return t.IsSerializable || VanaraMarshaler.CanMarshal(t, out _) || t.IsBlittable();
		}

		/// <summary>Determines whether this type is nullable (derived from <see cref="Nullable{T}"/>).</summary>
		/// <param name="type">The type to check.</param>
		/// <returns><see langword="true"/> if the specified type is nullable; otherwise, <see langword="false"/>.</returns>
		public static bool IsNullable(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

		/// <summary>Marshals an unmanaged linked list of structures to an <see cref="IEnumerable{T}"/> of that structure.</summary>
		/// <typeparam name="T">Type of native structure used by the unmanaged linked list.</typeparam>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="next">The expression to be used to fetch the pointer to the next item in the list.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the linked list.</returns>
		public static IEnumerable<T> LinkedListToIEnum<T>(this IntPtr ptr, Func<T, IntPtr> next)
		{
			for (var pCurrent = ptr; pCurrent != IntPtr.Zero;)
			{
				var ret = pCurrent.ToStructure<T>();
				yield return ret;
				pCurrent = next(ret);
			}
		}

		/// <summary>
		/// Marshals data from a managed list of objects to an unmanaged block of memory allocated by the <paramref name="memAlloc"/> method.
		/// </summary>
		/// <param name="values">The enumerated list of objects to marshal.</param>
		/// <param name="memAlloc">
		/// The function that allocates the memory for the block of objects (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
		/// </param>
		/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
		/// <param name="referencePointers">
		/// if set to <see langword="true"/> the pointer will be processed by storing a reference to the value; if <see langword="false"/>,
		/// the pointer value will be directly inserted into the array of pointers.
		/// </param>
		/// <param name="charSet">The character set to use for strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the allocated objects.</param>
		/// <returns>Pointer to the allocated native (unmanaged) array of objects stored using the character set defined by <paramref name="charSet"/>.</returns>
		public static IntPtr MarshalObjectsToPtr(this IEnumerable<object> values, Func<int, IntPtr> memAlloc, out int bytesAllocated, bool referencePointers = false, CharSet charSet = CharSet.Auto, int prefixBytes = 0)
		{
			// Bail early if empty
			if (values is null || !values.Any())
			{
				bytesAllocated = prefixBytes + IntPtr.Size;
				var ret = memAlloc(bytesAllocated);
				ret.FillMemory(0, bytesAllocated);
				return ret;
			}

			// Write to memory stream
			using (var ms = new NativeMemoryStream(1024, 1024) { CharSet = charSet })
			{
				ms.SetLength(ms.Position = prefixBytes);
				foreach (var o in values)
				{
					if (referencePointers)
						ms.WriteReferenceObject(o);
					else
						ms.WriteObject(o);
				}
				if (referencePointers) ms.WriteReference(null);
				ms.Flush();

				// Copy to newly allocated memory using memAlloc
				bytesAllocated = (int)ms.Length;
				var ret = memAlloc(bytesAllocated);
				ms.Pointer.CopyTo(ret, bytesAllocated);
				return ret;
			}
		}

		/// <summary>Marshals data from a managed list of specified type to a pre-allocated unmanaged block of memory.</summary>
		/// <typeparam name="T">
		/// A type of the enumerated managed object that holds the data to be marshaled. The object must be a structure or an instance of a
		/// formatted class.
		/// </typeparam>
		/// <param name="items">The enumerated list of items to marshal.</param>
		/// <param name="ptr">
		/// A pointer to a pre-allocated block of memory. The allocated memory must be sufficient to hold the size of
		/// <typeparamref name="T"/> times the number of items in the enumeration plus the number of bytes specified by <paramref name="prefixBytes"/>.
		/// </param>
		/// <param name="prefixBytes">The number of bytes to skip before writing the first element of <paramref name="items"/>.</param>
		[Obsolete("Please use the Vanara.Extensions.InteropExtensions.Write method instead. This will be removed from the library shortly as it performs no allocation.", true)]
		public static void MarshalToPtr<T>(this IEnumerable<T> items, IntPtr ptr, int prefixBytes = 0) => Write(ptr, items, prefixBytes);

		/// <summary>Marshals data from a managed object to an unmanaged block of memory that is allocated using <paramref name="memAlloc"/>.</summary>
		/// <typeparam name="T">The type of the managed object.</typeparam>
		/// <param name="value">
		/// A managed object that holds the data to be marshaled. The object must be a structure or an instance of a formatted class.
		/// </param>
		/// <param name="memAlloc">
		/// The function that allocates the memory for the structure (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
		/// </param>
		/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>A pointer to the memory allocated by <paramref name="memAlloc"/>.</returns>
		public static IntPtr MarshalToPtr<T>(this T value, Func<int, IntPtr> memAlloc, out int bytesAllocated, int prefixBytes = 0)
		{
			if (VanaraMarshaler.CanMarshal(typeof(T), out var marshaler))
			{
				using var mem = marshaler.MarshalManagedToNative(value);
				var ret = memAlloc(bytesAllocated = mem.Size + prefixBytes);
				mem.DangerousGetHandle().CopyTo(ret.Offset(prefixBytes), mem.Size);
				return ret;
			}
			else
			{
				var newVal = TrueValue(value, out bytesAllocated);
				bytesAllocated += prefixBytes;
				var ret = memAlloc(bytesAllocated);
				Write(ret, newVal, prefixBytes, bytesAllocated);
				return ret;
			}
		}

		/// <summary>
		/// Marshals data from a managed list of specified type to an unmanaged block of memory allocated by the <paramref name="memAlloc"/> method.
		/// </summary>
		/// <typeparam name="T">
		/// A type of the enumerated managed object that holds the data to be marshaled. The object must be a structure or an instance of a
		/// formatted class.
		/// </typeparam>
		/// <param name="items">The enumerated list of items to marshal.</param>
		/// <param name="memAlloc">
		/// The function that allocates the memory for the block of items (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
		/// </param>
		/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>Pointer to the allocated native (unmanaged) array of items stored.</returns>
		/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
		public static IntPtr MarshalToPtr<T>(this IEnumerable<T> items, Func<int, IntPtr> memAlloc, out int bytesAllocated, int prefixBytes = 0)
		{
			if (!typeof(T).IsMarshalable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");

			bytesAllocated = prefixBytes;
			var count = items?.Count() ?? 0;
			if (count == 0) return memAlloc(bytesAllocated);

			var sz = Marshal.SizeOf(typeof(T));
			bytesAllocated += sz * count;
			var result = memAlloc(bytesAllocated);
			result.Write(items, prefixBytes, bytesAllocated);
			return result;
		}

		/// <summary>
		/// Marshals data from an array of a specified type to an unmanaged block of memory allocated by the <paramref name="memAlloc"/> method.
		/// </summary>
		/// <typeparam name="T">
		/// A type of the array element that holds the data to be marshaled. The object must be a structure or an instance of a formatted class.
		/// </typeparam>
		/// <param name="items">The array of items to marshal.</param>
		/// <param name="memAlloc">
		/// The function that allocates the memory for the block of items (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
		/// </param>
		/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>Pointer to the allocated native (unmanaged) array of items stored.</returns>
		/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
		public static IntPtr MarshalToPtr<T>(this T[] items, Func<int, IntPtr> memAlloc, out int bytesAllocated, int prefixBytes = 0) =>
			MarshalToPtr(items.Cast<T>(), memAlloc, out bytesAllocated, prefixBytes);

		/// <summary>
		/// Marshals data from a managed list of strings to an unmanaged block of memory allocated by the <paramref name="memAlloc"/> method.
		/// </summary>
		/// <param name="values">The enumerated list of strings to marshal.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="memAlloc">
		/// The function that allocates the memory for the block of strings (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
		/// </param>
		/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>
		/// Pointer to the allocated native (unmanaged) array of strings stored using the <paramref name="packing"/> model and the character
		/// set defined by <paramref name="charSet"/>.
		/// </returns>
		public static IntPtr MarshalToPtr(this IEnumerable<string> values, StringListPackMethod packing, Func<int, IntPtr> memAlloc, out int bytesAllocated, CharSet charSet = CharSet.Auto, int prefixBytes = 0)
		{
			// Bail early if empty
			if (values is null || !values.Any())
			{
				bytesAllocated = prefixBytes + (packing == StringListPackMethod.Concatenated ? StringHelper.GetCharSize(charSet) : IntPtr.Size);
				var ret = memAlloc(bytesAllocated);
				ret.FillMemory(0, bytesAllocated);
				return ret;
			}

			// Write to memory stream
			using (var ms = new NativeMemoryStream(1024, 1024) { CharSet = charSet })
			{
				ms.SetLength(ms.Position = prefixBytes);
				if (packing == StringListPackMethod.Packed)
				{
					foreach (var s in values)
						ms.WriteReference(s);
					ms.WriteReference(null);
				}
				else
				{
					foreach (var s in values)
					{
						if (string.IsNullOrEmpty(s)) throw new ArgumentException("Concatenated string arrays cannot contain empty or null strings.");
						ms.Write(s);
					}
					ms.Write("");
				}
				ms.Flush();

				// Copy to newly allocated memory using memAlloc
				bytesAllocated = (int)ms.Length;
				var ret = memAlloc(bytesAllocated);
				ms.Pointer.CopyTo(ret, bytesAllocated);
				return ret;
			}
		}

		/// <summary>
		/// Marshals data from a managed array of strings to an unmanaged block of memory allocated by the <paramref name="memAlloc"/> method.
		/// </summary>
		/// <param name="values">The array of strings to marshal.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="memAlloc">
		/// The function that allocates the memory for the block of strings (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
		/// </param>
		/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>
		/// Pointer to the allocated native (unmanaged) array of strings stored using the <paramref name="packing"/> model and the character
		/// set defined by <paramref name="charSet"/>.
		/// </returns>
		public static IntPtr MarshalToPtr(this string[] values, StringListPackMethod packing, Func<int, IntPtr> memAlloc, out int bytesAllocated, CharSet charSet = CharSet.Auto, int prefixBytes = 0) =>
			MarshalToPtr((IEnumerable<string>)values, packing, memAlloc, out bytesAllocated, charSet, prefixBytes);

		/// <summary>Adds an offset to the value of a pointer.</summary>
		/// <param name="pointer">The pointer to add the offset to.</param>
		/// <param name="offset">The offset to add.</param>
		/// <returns>A new pointer that reflects the addition of <paramref name="offset"/> to <paramref name="pointer"/>.</returns>
		public static IntPtr Offset(this IntPtr pointer, long offset) => new IntPtr(pointer.ToInt64() + offset);

		/// <summary>Queries the object for a COM interface and returns it, if found, in <paramref name="ppv"/>.</summary>
		/// <param name="iUnk">The object to query.</param>
		/// <param name="iid">The interface identifier (IID) of the requested interface.</param>
		/// <param name="ppv">When this method returns, contains a reference to the returned interface.</param>
		/// <returns>An HRESULT that indicates the success or failure of the call.</returns>
		public static int QueryInterface(object iUnk, Guid iid, out object ppv)
		{
			var hr = Marshal.QueryInterface(Marshal.GetIUnknownForObject(iUnk), ref iid, out var ippv);
			ppv = hr == 0 ? Marshal.GetObjectForIUnknown(ippv) : null;
			return hr;
		}

		/// <summary>Returns the native memory size of a type, if possible.</summary>
		/// <typeparam name="T">The type whose size is to be returned.</typeparam>
		/// <returns>The size, in bytes, of the type that is specified by the <typeparamref name="T"/> type parameter.</returns>
		/// <exception cref="ArgumentException">Unable to get size of type.</exception>
		public static SizeT SizeOf<T>() => SizeOf(typeof(T));

		/// <summary>Returns the native memory size of a type, if possible.</summary>
		/// <param name="type">The type whose size is to be returned.</param>
		/// <returns>The size, in bytes, of the type that is specified by the <paramref name="type"/> parameter.</returns>
		/// <exception cref="ArgumentException">Unable to get size of type. - type</exception>
		public static SizeT SizeOf(Type type)
		{
			if (VanaraMarshaler.CanMarshal(type, out var marshaler))
				return marshaler.GetNativeSize();
			return type.IsEnum ? Marshal.SizeOf(Enum.GetUnderlyingType(type)) : Marshal.SizeOf(type);
		}

		/// <summary>Marshals data from a managed object to an unmanaged block of memory that is allocated using <paramref name="memAlloc"/>.</summary>
		/// <typeparam name="T">The type of the managed object.</typeparam>
		/// <param name="value">
		/// A managed object that holds the data to be marshaled. The object must be a structure or an instance of a formatted class.
		/// </param>
		/// <param name="memAlloc">
		/// The function that allocates the memory for the structure (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
		/// </param>
		/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
		/// <returns>A pointer to the memory allocated by <paramref name="memAlloc"/>.</returns>
		[Obsolete("This function has been renamed MarshalToPtr for consistency. Please migrate your usage as this method will be removed in subsequent releases.")]
		public static IntPtr StructureToPtr<T>(this T value, Func<int, IntPtr> memAlloc, out int bytesAllocated) => MarshalToPtr(value, memAlloc, out bytesAllocated);

		/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.</summary>
		/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="count">The number of items in the native array.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>An array of type <typeparamref name="T"/> containing the elements of the native array.</returns>
		public static T[] ToArray<T>(this IntPtr ptr, int count, int prefixBytes = 0, SizeT allocatedBytes = default) =>
			ToArray(ptr, typeof(T), count, prefixBytes, allocatedBytes).ToTypedArray<T>();

		/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.</summary>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="type">Type of native structure used by the C-style array.</param>
		/// <param name="count">The number of items in the native array.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>An array of type <paramref name="type"/> containing the elements of the native array.</returns>
		public static Array ToArray(this IntPtr ptr, Type type, int count, int prefixBytes = 0, SizeT allocatedBytes = default)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (ptr == IntPtr.Zero) return null;
			var ret = Array.CreateInstance(type, count); // new object[count];
			var stSize = SizeOf(type);
			if (allocatedBytes > 0 && stSize * count + prefixBytes > allocatedBytes)
				throw new InsufficientMemoryException();
			if (allocatedBytes == default) allocatedBytes = uint.MaxValue;
			for (var i = 0; i < count; i++)
			{
				var offset = prefixBytes + i * stSize;
				ret.SetValue(ptr.Offset(offset).Convert(allocatedBytes - (uint)offset, type), i);
			}
			return ret;
		}

		/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="IEnumerable{T}"/>.</summary>
		/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="count">The number of items in the native array.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
		public static IEnumerable<T> ToIEnum<T>(this IntPtr ptr, int count, int prefixBytes = 0, SizeT allocatedBytes = default) =>
			new NativeMemoryEnumerator<T>(ptr, count, prefixBytes, allocatedBytes);

		/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="IEnumerable{T}"/>.</summary>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="type">Type of native structure used by the C-style array.</param>
		/// <param name="count">The number of items in the native array.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
		public static System.Collections.IEnumerable ToIEnum(this IntPtr ptr, Type type, int count, int prefixBytes = 0, SizeT allocatedBytes = default) =>
			new UntypedNativeMemoryEnumerator(ptr, type, count, prefixBytes, allocatedBytes);

		/// <summary>Converts a <see cref="SecureString"/> to a string.</summary>
		/// <param name="s">The <see cref="SecureString"/> value.</param>
		/// <returns>The extracted string.</returns>
		public static string ToInsecureString(this SecureString s)
		{
			if (s == null) return null;
			var p = IntPtr.Zero;
			try
			{
				p = Marshal.SecureStringToCoTaskMemUnicode(s);
				return Marshal.PtrToStringUni(p);
			}
			finally
			{
				if (p != IntPtr.Zero)
					Marshal.ZeroFreeCoTaskMemUnicode(p);
			}
		}

		/// <summary>Converts a <see cref="UIntPtr"/> to a <see cref="IntPtr"/>.</summary>
		/// <param name="p">The <see cref="UIntPtr"/>.</param>
		/// <returns>An equivalent <see cref="IntPtr"/>.</returns>
		public static IntPtr ToIntPtr(this UIntPtr p)
		{
			unsafe { return new IntPtr(p.ToPointer()); }
		}

		/// <summary>Converts an <see cref="IntPtr"/> to a structure. If pointer has no value, <c>null</c> is returned.</summary>
		/// <typeparam name="T">Type of the structure.</typeparam>
		/// <param name="ptr">The <see cref="IntPtr"/> that points to allocated memory holding a structure or <see cref="IntPtr.Zero"/>.</param>
		/// <returns>The converted structure or <c>null</c>.</returns>
		public static T? ToNullableStructure<T>(this IntPtr ptr) where T : struct => ptr != IntPtr.Zero ? ptr.ToStructure<T>() : (T?)null;

		/// <summary>Converts a pointer to an unmanaged Unicode string to a <see cref="SecureString"/>.</summary>
		/// <param name="p">A pointer to an unmanaged Unicode string.</param>
		/// <returns>A <see cref="SecureString"/> with the contents of the in memory string.</returns>
		public static SecureString ToSecureString(this IntPtr p)
		{
			if (p == IntPtr.Zero) return null;
			var s = new SecureString();
			var i = 0;
			while (true)
			{
				var c = (char)Marshal.ReadInt16(p, ((i++) * sizeof(short)));
				if (c == '\u0000')
					break;
				s.AppendChar(c);
			}
			s.MakeReadOnly();
			return s;
		}

		/// <summary>Converts a pointer to an unmanaged Unicode string of a specified length to a <see cref="SecureString"/>.</summary>
		/// <param name="p">A pointer to an unmanaged Unicode string.</param>
		/// <param name="length">The number of Unicode characters in the unmanaged string, excluding any terminating null values.</param>
		/// <returns>A <see cref="SecureString"/> with the contents of the in memory string.</returns>
		public static SecureString ToSecureString(this IntPtr p, int length)
		{
			if (p == IntPtr.Zero) return null;
			var s = new SecureString();
			for (var i = 0; i < length; i++)
				s.AppendChar((char)Marshal.ReadInt16(p, i * sizeof(short)));
			s.MakeReadOnly();
			return s;
		}

		/// <summary>Converts a string to a <see cref="SecureString"/>.</summary>
		/// <param name="s">A string.</param>
		/// <returns>A <see cref="SecureString"/> with the contents of the string.</returns>
		public static SecureString ToSecureString(this string s)
		{
			if (s == null) return null;
			var ss = new SecureString();
			foreach (var c in s)
				ss.AppendChar(c);
			ss.MakeReadOnly();
			return ss;
		}

		/// <summary>
		/// Returns an enumeration of strings from memory where each string is pointed to by a preceding list of pointers of length <paramref name="count"/>.
		/// </summary>
		/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="count">The count of expected strings.</param>
		/// <param name="charSet">The character set of the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>Enumeration of strings.</returns>
		public static IEnumerable<string> ToStringEnum(this IntPtr ptr, int count, CharSet charSet = CharSet.Auto, int prefixBytes = 0, SizeT allocatedBytes = default)
		{
			if (ptr == IntPtr.Zero || count == 0) yield break;
			if (allocatedBytes > 0 && count * IntPtr.Size + prefixBytes > allocatedBytes)
				throw new InsufficientMemoryException();
			for (var i = 0; i < count; i++)
			{
				var sptr = Marshal.ReadIntPtr(ptr.Offset(prefixBytes + i * IntPtr.Size));
				yield return StringHelper.GetString(sptr, charSet);
			}
		}

		/// <summary>
		/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character and
		/// is terminated by two '\0' characters.
		/// </summary>
		/// <param name="lptr">The <see cref="IntPtr"/> pointing to the native array.</param>
		/// <param name="charSet">The character set of the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="lptr"/>.</param>
		/// <returns>An enumerated list of strings.</returns>
		public static IEnumerable<string> ToStringEnum(this IntPtr lptr, CharSet charSet = CharSet.Auto, int prefixBytes = 0, SizeT allocatedBytes = default)
		{
			if (lptr == IntPtr.Zero) yield break;
			var charLength = StringHelper.GetCharSize(charSet);
			var i = prefixBytes;
			if (allocatedBytes == 0) allocatedBytes = SizeT.MaxValue;
			for (var ptr = lptr.Offset(i); i + charLength <= allocatedBytes && GetCh(ptr) != 0; i += charLength, ptr = lptr.Offset(i))
			{
				for (var cptr = ptr; i + charLength <= allocatedBytes && GetCh(cptr) != 0; cptr = cptr.Offset(charLength), i += charLength) { }
				if (i + charLength > allocatedBytes)
					throw new InsufficientMemoryException();
				yield return StringHelper.GetString(ptr, charSet);
				//ptr = ptr.Offset(((s?.Length ?? 0) + 1) * charLength);
			}
			if (i + charLength > allocatedBytes) throw new InsufficientMemoryException();

			int GetCh(IntPtr p)
			{
				return charLength == 1 ? Marshal.ReadByte(p) : Marshal.ReadInt16(p);
			}
		}

		/// <summary>
		/// Marshals data from an unmanaged block of memory to a newly allocated managed object of the type specified by a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <param name="offset">The number of bytes to skip before reading the element.</param>
		/// <returns>A managed object that contains the data that the <paramref name="ptr"/> parameter points to.</returns>
		/// <exception cref="InsufficientMemoryException"></exception>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static T ToStructure<T>(this IntPtr ptr, SizeT allocatedBytes = default, int offset = 0)
		{
			if (allocatedBytes == default) allocatedBytes = uint.MaxValue;
			return ptr.Offset(offset).Convert<T>(allocatedBytes - (uint)offset);
		}

		/// <summary>Marshals data from an unmanaged block of memory to a managed object.</summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a formatted class.</typeparam>
		/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
		/// <param name="instance">The object to which the data is to be copied. This must be an instance of a formatted class.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <param name="offset">The number of bytes to skip before reading the element.</param>
		/// <returns>A managed object that contains the data that the <paramref name="ptr"/> parameter points to.</returns>
		public static void ToStructure<T>(this IntPtr ptr, T instance, SizeT allocatedBytes = default, int offset = 0) where T : class
		{
			if (ptr == IntPtr.Zero) throw new NullReferenceException();
			var t = TrueType(typeof(T), out var stSize);
			if (allocatedBytes > 0 && allocatedBytes < stSize + offset)
				throw new InsufficientMemoryException();
			if (t == typeof(T))
				Marshal.PtrToStructure(ptr, instance);
			else
				using (var pin = new PinnedObject(instance))
					((IntPtr)pin).Write(Marshal.PtrToStructure(ptr.Offset(offset), t));
		}

		/// <summary>Converts a single-dimensional <see cref="Array"/> to an array of <typeparamref name="T"/>.</summary>
		/// <typeparam name="T">
		/// The type of the output array. All elements in the array supplied as <paramref name="input"/> must be of this type.
		/// </typeparam>
		/// <param name="input">The input array.</param>
		/// <returns>An array of <typeparamref name="T"/> elements.</returns>
		public static T[] ToTypedArray<T>(this Array input) => input?.Cast<T>().ToArray();

		/// <summary>Converts a <see cref="IntPtr"/> to a <see cref="UIntPtr"/>.</summary>
		/// <param name="p">The <see cref="IntPtr"/>.</param>
		/// <returns>An equivalent <see cref="UIntPtr"/>.</returns>
		public static UIntPtr ToUIntPtr(this IntPtr p)
		{
			unsafe { return new UIntPtr(p.ToPointer()); }
		}

		/// <summary>Marshals data from a managed list of specified type to a pre-allocated unmanaged block of memory.</summary>
		/// <typeparam name="T">
		/// A type of the enumerated managed object that holds the data to be marshaled. The object must be a structure or an instance of a
		/// formatted class.
		/// </typeparam>
		/// <param name="ptr">
		/// A pointer to a pre-allocated block of memory. The allocated memory must be sufficient to hold the size of
		/// <typeparamref name="T"/> times the number of items in the enumeration plus the number of bytes specified by <paramref name="offset"/>.
		/// </param>
		/// <param name="items">The enumerated list of items to marshal.</param>
		/// <param name="offset">The number of bytes to skip before writing the first element of <paramref name="items"/>.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>The number of bytes written. The offset is not included.</returns>
		/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
		/// <exception cref="InsufficientMemoryException"></exception>
		public static int Write<T>(this IntPtr ptr, IEnumerable<T> items, int offset = 0, SizeT allocatedBytes = default)
		{
			var count = items?.Count() ?? 0;
			if (count == 0) return 0;

			var ttype = TrueType(typeof(T), out var stSize);
			if (!ttype.IsMarshalable())
				throw new ArgumentException(@"Structure layout is not sequential or explicit.");

			var bytesReq = stSize * count + offset;
			if (allocatedBytes > 0 && bytesReq > allocatedBytes)
				throw new InsufficientMemoryException();

			var i = 0;
			foreach (var item in items.Select(v => Convert.ChangeType(v, ttype)).Where(v => v != null))
				WriteNoChecks(ptr, item, offset + i++ * stSize, allocatedBytes);

			return bytesReq - offset;
		}

		/// <summary>Writes the specified value to pre-allocated memory.</summary>
		/// <param name="ptr">The address of the memory where the value is to be written.</param>
		/// <param name="value">The value to write.</param>
		/// <param name="offset">The number of bytes to offset from <paramref name="ptr"/> before writing.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>The number of bytes written. The offset is not included.</returns>
		/// <exception cref="InsufficientMemoryException"></exception>
		public static int Write(this IntPtr ptr, object value, int offset = 0, SizeT allocatedBytes = default)
		{
			if (value is null) return 0;
			if (!value.GetType().IsMarshalable())
				throw new ArgumentException(@"Value cannot be serialized to memory.", nameof(value));
			return WriteNoChecks(ptr, value, offset, allocatedBytes);
		}

		/// <summary>Writes the specified value to pre-allocated memory.</summary>
		/// <typeparam name="T">The type of the value to write.</typeparam>
		/// <param name="ptr">The address of the memory where the value is to be written.</param>
		/// <param name="value">The value to write.</param>
		/// <param name="offset">The number of bytes to offset from <paramref name="ptr"/> before writing.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <returns>The number of bytes written. The offset is not included.</returns>
		/// <exception cref="InsufficientMemoryException"></exception>
		public static int Write<T>(this IntPtr ptr, in T value, int offset = 0, SizeT allocatedBytes = default) where T : struct =>
			WriteNoChecks(ptr, value, offset, allocatedBytes);

		internal static Type TrueType(Type type, out int size)
		{
			var ttype = type.IsEnum ? Enum.GetUnderlyingType(type) : type == typeof(bool) ? typeof(uint) : type;
			try { size = Marshal.SizeOf(ttype); } catch { size = 0; }
			return ttype;
		}

		internal static T GetValueType<T>(IntPtr ptr, Type trueType = null, int offset = 0, SizeT allocatedBytes = default) =>
			(T)GetValueType(ptr, typeof(T), trueType, offset, allocatedBytes);

		internal static object GetValueType(IntPtr ptr, Type type, Type trueType = null, int offset = 0, SizeT allocatedBytes = default)
		{
			if (allocatedBytes == 0)
				allocatedBytes = SizeT.MaxValue;
			trueType ??= type.IsEnum ? Enum.GetUnderlyingType(type) : type;
			var obj = VanaraMarshaler.CanMarshal(trueType, out var marshaler) ?
				marshaler.MarshalNativeToManaged(ptr.Offset(offset), allocatedBytes) :
				Marshal.SizeOf(trueType) <= allocatedBytes ? Marshal.PtrToStructure(ptr.Offset(offset), trueType) : throw new InsufficientMemoryException();
			return type == trueType ? obj : type.IsEnum ? Enum.ToObject(type, obj) : Convert.ChangeType(obj, type);
		}

		private static object TrueValue(object value, out int size) => Convert.ChangeType(value, TrueType(value.GetType(), out size));

		internal static int WriteNoChecks(IntPtr ptr, object value, int offset, SizeT allocatedBytes)
		{
			if (value is IEnumerable<byte> b) value = b.ToArray();
			if (value is byte[] ba)
			{
				if (allocatedBytes > 0 && offset + ba.Length > allocatedBytes)
					throw new InsufficientMemoryException();
				Marshal.Copy(ba, 0, ptr, ba.Length);
				return ba.Length;
			}
			if (VanaraMarshaler.CanMarshal(value.GetType(), out var marshaler))
			{
				using var mem = marshaler.MarshalManagedToNative(value);
				if (allocatedBytes > 0 && offset + mem.Size > allocatedBytes)
					throw new InsufficientMemoryException();
				mem.DangerousGetHandle().CopyTo(ptr.Offset(offset), mem.Size);
				return mem.Size;
			}
			if (value.GetType().IsBlittable())
			{
				var newVal = TrueValue(value, out var cbValue);
				if (allocatedBytes > 0 && offset + cbValue > allocatedBytes)
					throw new InsufficientMemoryException();
				Marshal.StructureToPtr(newVal, ptr.Offset(offset), false);
				return cbValue;
			}
			if (value.GetType().IsSerializable)
			{
				using var str = new NativeMemoryStream();
				var bf = new BinaryFormatter();
				bf.Serialize(str, value);
				str.Flush();
				if (allocatedBytes > 0 && offset + str.Length > allocatedBytes)
					throw new InsufficientMemoryException();
				str.Pointer.CopyTo(ptr.Offset(offset), str.Length);
				return (int)str.Length;
			}
			throw new ArgumentException("Unable to convert object to its binary format.");
		}
	}
}
