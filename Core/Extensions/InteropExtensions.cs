#pragma warning disable IDE0058 // Expression value is never used
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using Vanara.PInvoke;
using Vanara.PInvoke.Collections;

namespace Vanara.Extensions;

/// <summary>Extension methods for System.Runtime.InteropServices.</summary>
public static partial class InteropExtensions
{
	/// <summary>
	/// Aligns the specified pointer to an adjacent memory location that can be accessed by a adding a constant and its multiples.
	/// </summary>
	/// <param name="ptr">The pointer to align.</param>
	/// <returns>The aligned pointer. This value may be the same as <paramref name="ptr"/>.</returns>
	public static IntPtr Align(this IntPtr ptr) => new((ptr.ToInt64() + IntPtr.Size - 1) & (~(((long)IntPtr.Size) - 1)));

#if ALLOWSPAN
	/// <summary>Returns the pointer as a <see cref="ReadOnlySpan{T}"/>.</summary>
	/// <typeparam name="T">The type of items in the <see cref="ReadOnlySpan{T}"/>.</typeparam>
	/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
	/// <param name="length">The number of <typeparamref name="T"/> elements to be included in the <see cref="ReadOnlySpan{T}"/>.</param>
	/// <param name="prefixBytes">Bytes to skip before starting the span.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>A <see cref="ReadOnlySpan{T}"/> that represents the memory.</returns>
	/// <exception cref="InsufficientMemoryException"></exception>
	public static unsafe ReadOnlySpan<T> AsReadOnlySpan<T>(this IntPtr ptr, SizeT length, SizeT prefixBytes = default, SizeT allocatedBytes = default)
	{
		if (ptr == IntPtr.Zero) return null;
		if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
		if (allocatedBytes < 0) throw new ArgumentOutOfRangeException(nameof(allocatedBytes));
		if (allocatedBytes > 0 && SizeOf<T>() * length + prefixBytes > allocatedBytes)
			throw new InsufficientMemoryException();

		return new ReadOnlySpan<T>((ptr + (int)prefixBytes).ToPointer(), length);
	}

	/// <summary>Gets a reference to a structure based on this allocated memory.</summary>
	/// <typeparam name="T">The type of items in the <see cref="Span{T}"/>.</typeparam>
	/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
	/// <param name="prefixBytes">Bytes to skip before starting the span.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>A referenced structure.</returns>
	public static ref T AsRef<T>(this IntPtr ptr, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
		ref MemoryMarshal.GetReference(AsSpan<T>(ptr, 1, prefixBytes, allocatedBytes));

	/// <summary>Returns the pointer as a <see cref="Span{T}"/>.</summary>
	/// <typeparam name="T">The type of items in the <see cref="Span{T}"/>.</typeparam>
	/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
	/// <param name="length">The number of <typeparamref name="T"/> elements to be included in the <see cref="Span{T}"/>.</param>
	/// <param name="prefixBytes">Bytes to skip before starting the span.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>A <see cref="Span{T}"/> that represents the memory.</returns>
	/// <exception cref="InsufficientMemoryException"></exception>
	public static unsafe Span<T> AsSpan<T>(this IntPtr ptr, SizeT length, SizeT prefixBytes = default, SizeT allocatedBytes = default)
	{
		if (ptr == IntPtr.Zero) return null;
		if (allocatedBytes < 0) throw new ArgumentOutOfRangeException(nameof(allocatedBytes));
		if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
		if (allocatedBytes > 0 && SizeOf<T>() * length + prefixBytes > allocatedBytes)
			throw new InsufficientMemoryException();

		return new Span<T>((ptr + (int)prefixBytes).ToPointer(), length);
	}
#endif

	/// <summary>Returns the pointer.</summary>
	/// <typeparam name="T">The type of items.</typeparam>
	/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
	/// <param name="length">The number of <typeparamref name="T"/> elements to be included in the pointer.</param>
	/// <param name="prefixBytes">Bytes to skip before starting the span.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>A pointer that represents the memory.</returns>
	/// <exception cref="InsufficientMemoryException"></exception>
	public static unsafe T* AsUnmanagedArrayPointer<T>(this IntPtr ptr, SizeT length, SizeT prefixBytes = default, SizeT allocatedBytes = default) where T : unmanaged
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
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
#if !NET45
			Buffer.MemoryCopy((void*)(source.Offset(start)), (void*)dest, length, length);
#else
			byte* psrc = (byte*)source + start, pdest = (byte*)dest;
			for (long i = 0; i < length; i++, psrc++, pdest++)
				*pdest = *psrc;
#endif
		}
	}

	/// <summary>
	/// Fills the memory with a particular byte value. <note type="warning">This is a very dangerous function that can cause memory
	/// access errors if the provided <paramref name="length"/> is bigger than allocated memory of if the <paramref name="ptr"/> is not
	/// a valid memory pointer.</note>
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
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerator<T?> GetEnumerator<T>(this IntPtr ptr, SizeT count, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
		new NativeMemoryEnumerator<T>(ptr, count, prefixBytes, allocatedBytes);

	/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="System.Collections.IEnumerator"/>.</summary>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="type">Type of native structure used by the C-style array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static System.Collections.IEnumerator GetEnumerator(this IntPtr ptr, Type type, SizeT count, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
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

		// Need to find a way to exclude jagged arrays
		Type? t = T;
		while (t is not null && t.IsArray)
			t = t.GetElementType();

		if (t!.IsEnum) return true;
		try { Marshal.SizeOf(t); return true; } catch { return false; }
	}

	/// <summary>Determines whether this type is marshalable.</summary>
	/// <param name="type">The type to check.</param>
	/// <returns><see langword="true"/> if the specified type is marshalable; otherwise, <see langword="false"/>.</returns>
	public static bool IsMarshalable(this Type type)
	{
		Type t = type.IsNullable() ? type.GetGenericArguments()[0] : type;
#pragma warning disable SYSLIB0050 // Type or member is obsolete
		return t.IsSerializable || VanaraMarshaler.CanMarshal(t, out _) || t.IsBlittable();
#pragma warning restore SYSLIB0050 // Type or member is obsolete
	}

	/// <summary>Determines whether this type is nullable (derived from <see cref="Nullable{T}"/>).</summary>
	/// <param name="type">The type to check.</param>
	/// <returns><see langword="true"/> if the specified type is nullable; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNullable(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

	/// <summary>Marshals an unmanaged linked list of structures to an <see cref="IEnumerable{T}"/> of that structure.</summary>
	/// <typeparam name="T">Type of native structure used by the unmanaged linked list.</typeparam>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="next">The expression to be used to fetch the pointer to the next item in the list.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the linked list.</returns>
	public static IEnumerable<T?> LinkedListToIEnum<T>(this IntPtr ptr, Func<T?, IntPtr> next)
	{
		for (IntPtr pCurrent = ptr; pCurrent != IntPtr.Zero;)
		{
			T? ret = (T?)pCurrent.ToStructure(typeof(T), bytesRead: out _);
			yield return ret;
			pCurrent = next(ret);
		}
	}

	/// <summary>Marshals an unmanaged linked list of structures to an <see cref="IEnumerable{T}"/> of that structure.</summary>
	/// <typeparam name="T">Type of native structure used by the unmanaged linked list.</typeparam>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="nextOffset">The expression to be used to fetch the offset from the current pointer to the next item in the list.</param>
	/// <param name="allocatedBytes">
	/// The number of allocated bytes behind <paramref name="ptr"/>. This value is used to determine when to stop enumerating.
	/// </param>
	/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the linked list.</returns>
	public static IEnumerable<T?> LinkedListToIEnum<T>(this IntPtr ptr, Func<T?, long> nextOffset, SizeT allocatedBytes)
	{
		IntPtr pEnd = ptr.Offset(allocatedBytes);
		for (IntPtr pCurrent = ptr; pCurrent.ToInt64() < pEnd.ToInt64();)
		{
			T? ret = (T?)pCurrent.ToStructure(typeof(T), bytesRead: out _);
			yield return ret;
			var offset = nextOffset(ret);
			if (offset == 0) break;
			pCurrent = pCurrent.Offset(offset);
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
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>
	/// Pointer to the allocated native (unmanaged) array of objects stored using the character set defined by <paramref name="charSet"/>.
	/// </returns>
	public static IntPtr MarshalObjectsToPtr(this IEnumerable<object>? values, Func<int, IntPtr> memAlloc, out int bytesAllocated, bool referencePointers = false, CharSet charSet = CharSet.Auto, SizeT prefixBytes = default,
		Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null)
	{
		// Bail early if empty
		if (values is null || !values.Any())
		{
			bytesAllocated = prefixBytes + IntPtr.Size;
			return AllocWrite(bytesAllocated, null, memAlloc);
		}

		// Write to memory stream
		using var ms = new NativeMemoryStream(1024, 1024) { CharSet = charSet };
		ms.SetLength(ms.Position = prefixBytes);
		foreach (var o in values)
		{
			if (referencePointers)
				ms.WriteReferenceObject(o);
			else
				ms.WriteObject(o);
		}
		if (referencePointers)
			ms.WriteReference((int?)null);
		ms.Flush();

		// Copy to newly allocated memory using memAlloc
		bytesAllocated = (int)ms.Length;
		return AllocWrite(bytesAllocated, (p, c) => ms.Pointer.CopyTo(p, c), memAlloc, memLock, memUnlock);
	}

	/// <summary>Marshals data from a managed list of specified type to a pre-allocated unmanaged block of memory.</summary>
	/// <typeparam name="T">
	/// A type of the enumerated managed object that holds the data to be marshaled. The object must be a structure or an instance of a
	/// formatted class.
	/// </typeparam>
	/// <param name="items">The enumerated list of items to marshal.</param>
	/// <param name="ptr">
	/// A pointer to a pre-allocated block of memory. The allocated memory must be sufficient to hold the size of <typeparamref
	/// name="T"/> times the number of items in the enumeration plus the number of bytes specified by <paramref name="prefixBytes"/>.
	/// </param>
	/// <param name="prefixBytes">The number of bytes to skip before writing the first element of <paramref name="items"/>.</param>
	[Obsolete("Please use the Vanara.Extensions.InteropExtensions.Write method instead. This will be removed from the library shortly as it performs no allocation.", true)]
	public static void MarshalToPtr<T>(this IEnumerable<T> items, IntPtr ptr, SizeT prefixBytes = default) => Write(ptr, items, prefixBytes);

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
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>A pointer to the memory allocated by <paramref name="memAlloc"/>.</returns>
	public static IntPtr MarshalToPtr<T>(this T value, Func<int, IntPtr> memAlloc, out int bytesAllocated, SizeT prefixBytes = default,
		Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null)
	{
		if (VanaraMarshaler.CanMarshal(typeof(T), out IVanaraMarshaler? marshaler))
		{
			using SafeAllocatedMemoryHandle mem = marshaler.MarshalManagedToNative(value);
			return AllocWrite(bytesAllocated = mem.Size + prefixBytes, (p, c) => Marshal.Copy(mem.GetBytes(), 0, p.Offset(prefixBytes), mem.Size), memAlloc, memLock, memUnlock);
		}
		else
		{
			var newVal = TrueValue(value, out bytesAllocated);
			bytesAllocated += prefixBytes;
			return AllocWrite(bytesAllocated, (p, c) => Write(p, newVal, prefixBytes, c), memAlloc, memLock, memUnlock);
		}
	}

	/// <summary>
	/// Marshals data from a managed list of specified type to an unmanaged block of memory allocated by the <paramref name="memAlloc"/> method.
	/// </summary>
	/// <param name="items">
	/// The array of items to marshal. If this is an array of strings, it will be marshaled as a concatenated list with default character encoding.
	/// </param>
	/// <param name="memAlloc">
	/// The function that allocates the memory for the block of items (typically <see cref="Marshal.AllocCoTaskMem(int)"/> or <see cref="Marshal.AllocHGlobal(int)"/>.
	/// </param>
	/// <param name="bytesAllocated">The bytes allocated by the <paramref name="memAlloc"/> method.</param>
	/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>Pointer to the allocated native (unmanaged) array of items stored.</returns>
	/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
	public static IntPtr MarshalToPtr(this Array items, Func<int, IntPtr> memAlloc, out int bytesAllocated, SizeT prefixBytes = default, Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null)
	{
		if (items.Rank != 1)
			throw new ArgumentException("Only single dimension arrays are supported.", nameof(items));
		if (items.GetType().GetElementType() == typeof(string))
			return items.Cast<string?>().MarshalToPtr(StringListPackMethod.Concatenated, memAlloc, out bytesAllocated, CharSet.Auto, prefixBytes, memLock, memUnlock);
		bytesAllocated = 0;
#pragma warning disable IL2060
		return (IntPtr)typeof(InteropExtensions).GetMethods()
			.First(static m => m.Name == "MarshalToPtr" && m.GetParameters()[0].ParameterType.Name == "T[]")
			.MakeGenericMethod(items.GetType().GetElementType()!)
			.Invoke(null, new object?[] { items, memAlloc, bytesAllocated, prefixBytes, memLock, memUnlock }!)!;
#pragma warning restore IL2060
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
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will
	/// be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>Pointer to the allocated native (unmanaged) array of items stored.</returns>
	/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
	public static IntPtr MarshalToPtr<T>(this IEnumerable<T> items, Func<int, IntPtr> memAlloc, out int bytesAllocated, SizeT prefixBytes = default, Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null)
	{
		if (!typeof(T).IsMarshalable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");

		bytesAllocated = prefixBytes;
		var count = items?.Count() ?? 0;
		if (count == 0)
			return AllocWrite(bytesAllocated, null, memAlloc, memLock, memUnlock);

		bytesAllocated += SizeOf<T>() * count;
		return AllocWrite(bytesAllocated, (p, c) => Write(p, items!, prefixBytes, c), memAlloc, memLock, memUnlock);
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
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will
	/// be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>Pointer to the allocated native (unmanaged) array of items stored.</returns>
	/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IntPtr MarshalToPtr<T>(this T[] items, Func<int, IntPtr> memAlloc, out int bytesAllocated, SizeT prefixBytes = default, Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null) =>
		MarshalToPtr(items.Cast<T>(), memAlloc, out bytesAllocated, prefixBytes, memLock, memUnlock);

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
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will
	/// be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>
	/// Pointer to the allocated native (unmanaged) array of strings stored using the <paramref name="packing"/> model and the character
	/// set defined by <paramref name="charSet"/>.
	/// </returns>
	public static IntPtr MarshalToPtr(this IEnumerable<string?> values, StringListPackMethod packing, Func<int, IntPtr> memAlloc, out int bytesAllocated, CharSet charSet = CharSet.Auto, SizeT prefixBytes = default, Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null)
	{
		// Get size
		bytesAllocated = Math.Abs(GetStrListSize(values, packing, charSet)) + prefixBytes;

		return AllocWrite(bytesAllocated, (p, c) => Write(p, values, packing, charSet, prefixBytes, c), memAlloc, memLock, memUnlock);
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
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will
	/// be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>
	/// Pointer to the allocated native (unmanaged) array of strings stored using the <paramref name="packing"/> model and the character
	/// set defined by <paramref name="charSet"/>.
	/// </returns>
	public static IntPtr MarshalToPtr(this string?[] values, StringListPackMethod packing, Func<int, IntPtr> memAlloc, out int bytesAllocated,
		CharSet charSet = CharSet.Auto, SizeT prefixBytes = default, Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null) =>
		MarshalToPtr((IEnumerable<string?>)values, packing, memAlloc, out bytesAllocated, charSet, prefixBytes, memLock, memUnlock);

	/// <summary>Adds an offset to the value of a pointer.</summary>
	/// <param name="pointer">The pointer to add the offset to.</param>
	/// <param name="offset">The offset to add.</param>
	/// <returns>A new pointer that reflects the addition of <paramref name="offset"/> to <paramref name="pointer"/>.</returns>
	public static IntPtr Offset(this IntPtr pointer, long offset) => new(pointer.ToInt64() + offset);

	/// <summary>Queries the object for a COM interface and returns it, if found, in <paramref name="ppv"/>.</summary>
	/// <param name="iUnk">The object to query.</param>
	/// <param name="iid">The interface identifier (IID) of the requested interface.</param>
	/// <param name="ppv">When this method returns, contains a reference to the returned interface.</param>
	/// <returns>An HRESULT that indicates the success or failure of the call.</returns>
	public static int QueryInterface(this object iUnk, Guid iid, out object? ppv)
	{
#if NET9_0_OR_GREATER
		var hr = Marshal.QueryInterface(Marshal.GetIUnknownForObject(iUnk), in iid, out IntPtr ippv);
#else
		var hr = Marshal.QueryInterface(Marshal.GetIUnknownForObject(iUnk), ref iid, out IntPtr ippv);
#endif
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

	/// <summary>Returns the native memory size of a value, if possible.</summary>
	/// <param name="value">The value whose native size is to be returned.</param>
	/// <param name="charSet">The character set to use for the strings.</param>
	/// <returns>The size, in bytes, of the value that is specified by the <paramref name="value"/> parameter.</returns>
	/// <exception cref="ArgumentException">Unable to get the size of the value.</exception>
	public static SizeT SizeOf(object? value, CharSet charSet = CharSet.Auto)
	{
		if (value is null) return 0;
		if (value is string s) return StringHelper.GetByteCount(s, true, charSet);
		var valType = value.GetType();
		var elemType = valType.FindElementType();
		if (elemType is null)
			return SizeOf(valType);
		if (elemType == typeof(string))
			return GetStrListSize(((System.Collections.IEnumerable)value).Cast<string>(), StringListPackMethod.Concatenated, charSet);
		if (valType.IsArray)
			return ((Array)value).Length * SizeOf(elemType);
		if (value is System.Collections.ICollection ic)
			return ic.Count * SizeOf(elemType);
		if (value is System.Collections.IEnumerable ie)
			return ie.Cast<object>().Count() * SizeOf(elemType);

		throw new ArgumentException("Unable to get the size of the value.");
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
	/// <param name="memLock">
	/// The function used to lock memory before assignment. If <see langword="null"/>, the result from <paramref name="memAlloc"/> will be used.
	/// </param>
	/// <param name="memUnlock">The optional function to unlock memory after assignment.</param>
	/// <returns>A pointer to the memory allocated by <paramref name="memAlloc"/>.</returns>
	[Obsolete("This function has been renamed MarshalToPtr for consistency. Please migrate your usage as this method will be removed in subsequent releases.")]
	public static IntPtr StructureToPtr<T>(this T value, Func<int, IntPtr> memAlloc, out int bytesAllocated, Func<IntPtr, IntPtr>? memLock = null,
		Func<IntPtr, bool>? memUnlock = null) where T : notnull => MarshalToPtr(value, memAlloc, out bytesAllocated, 0, memLock, memUnlock);

	/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.</summary>
	/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>An array of type <typeparamref name="T"/> containing the elements of the native array.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[]? ToArray<T>(this IntPtr ptr, SizeT count, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
		ToArray(ptr, typeof(T), count, prefixBytes, allocatedBytes)?.ToTypedArray<T>();

	/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.</summary>
	/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <param name="bytesRead">The number of bytes read during the conversion.</param>
	/// <returns>An array of type <typeparamref name="T"/> containing the elements of the native array.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[]? ToArray<T>(this IntPtr ptr, SizeT count, [Optional] SizeT prefixBytes, [Optional] SizeT allocatedBytes, out int bytesRead) =>
		ToArray(ptr, typeof(T), count, prefixBytes, allocatedBytes, out bytesRead)?.ToTypedArray<T>();

	/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.</summary>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="type">Type of native structure used by the C-style array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>An array of type <paramref name="type"/> containing the elements of the native array.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Array? ToArray(this IntPtr ptr, Type type, SizeT count, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
		ToArray(ptr, type, count, prefixBytes, allocatedBytes, out _);

	/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.</summary>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="type">Type of native structure used by the C-style array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <param name="bytesRead">The number of bytes read during the conversion.</param>
	/// <returns>An array of type <paramref name="type"/> containing the elements of the native array.</returns>
	/// <exception cref="ArgumentNullException">type</exception>
	/// <exception cref="InsufficientMemoryException"></exception>
	public static Array? ToArray(this IntPtr ptr, Type type, SizeT count, [Optional] SizeT prefixBytes, [Optional] SizeT allocatedBytes, out int bytesRead)
	{
		if (type is null) throw new ArgumentNullException(nameof(type));
		if (type == typeof(byte))
		{
			bytesRead = count;
			return ToByteArray(ptr, count, prefixBytes, allocatedBytes);
		}
		bytesRead = 0;
		if (ptr == IntPtr.Zero) return null;
		var ret = Array.CreateInstance(type, count); // new object[count];
		SizeT stSize = SizeOf(type);
		if (allocatedBytes > 0 && stSize * count + prefixBytes > allocatedBytes)
			throw new InsufficientMemoryException();
		if (allocatedBytes == default) allocatedBytes = uint.MaxValue;
		for (var i = 0; i < count; i++)
		{
			var offset = prefixBytes + i * stSize;
			ret.SetValue(ptr.ToStructure(type, allocatedBytes, offset, out _), i);
		}
		bytesRead = count * stSize;
		return ret;
	}

	/// <summary>Converts an <see cref="IntPtr"/> that points to allocated memory into an array of bytes.</summary>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native memory.</param>
	/// <param name="count">The number of bytes to extract.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>An array of <see cref="byte"/> of length <paramref name="count"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[]? ToByteArray(this IntPtr ptr, SizeT count, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
		ptr.AsReadOnlySpan<byte>(count, prefixBytes, allocatedBytes).ToArray();

	/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="IEnumerable{T}"/>.</summary>
	/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerable<T?> ToIEnum<T>(this IntPtr ptr, SizeT count, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
		new NativeMemoryEnumerator<T>(ptr, count, prefixBytes, allocatedBytes);

	/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into an <see cref="IEnumerable{T}"/>.</summary>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="type">Type of native structure used by the C-style array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="prefixBytes">Bytes to skip before reading the array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> exposing the elements of the native array.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static System.Collections.IEnumerable ToIEnum(this IntPtr ptr, Type type, SizeT count, SizeT prefixBytes = default, SizeT allocatedBytes = default) =>
		new UntypedNativeMemoryEnumerator(ptr, type, count, prefixBytes, allocatedBytes);

	/// <summary>Converts a <see cref="SecureString"/> to a string.</summary>
	/// <param name="s">The <see cref="SecureString"/> value.</param>
	/// <returns>The extracted string.</returns>
	public static string? ToInsecureString(this SecureString s)
	{
		if (s == null) return null;
		IntPtr p = IntPtr.Zero;
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
	public static T? ToNullableStructure<T>(this IntPtr ptr) where T : struct => ptr != IntPtr.Zero ? ptr.ToStructure<T>() : null;

	/// <summary>Converts an <see cref="IntPtr"/> to a structure. If pointer has no value, <c>null</c> is returned.</summary>
	/// <typeparam name="T">Type of the structure.</typeparam>
	/// <param name="ptr">The <see cref="IntPtr"/> that points to allocated memory holding a structure or <see cref="IntPtr.Zero"/>.</param>
	/// <param name="bytesRead">The number of bytes read during the conversion.</param>
	/// <returns>The converted structure or <c>null</c>.</returns>
	public static T? ToNullableStructure<T>(this IntPtr ptr, out int bytesRead) where T : struct
	{
		bytesRead = 0;
		return ptr != IntPtr.Zero ? ptr.ToStructure<T>(bytesRead: out bytesRead) : null;
	}

	/// <summary>Converts a pointer to an unmanaged Unicode string to a <see cref="SecureString"/>.</summary>
	/// <param name="p">A pointer to an unmanaged Unicode string.</param>
	/// <returns>A <see cref="SecureString"/> with the contents of the in memory string.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SecureString? ToSecureString(this IntPtr p) => ToSecureString(p, out _);

	/// <summary>Converts a pointer to an unmanaged Unicode string to a <see cref="SecureString"/>.</summary>
	/// <param name="p">A pointer to an unmanaged Unicode string.</param>
	/// <param name="bytesRead">The number of bytes read during the conversion.</param>
	/// <returns>A <see cref="SecureString"/> with the contents of the in memory string.</returns>
	public static SecureString? ToSecureString(this IntPtr p, out int bytesRead)
	{
		bytesRead = 0;
		if (p == IntPtr.Zero) return null;
		var s = new SecureString();
		var i = 0;
		while (true)
		{
			var c = (char)Marshal.ReadInt16(p, i++ * sizeof(short));
			if (c == '\u0000')
				break;
			s.AppendChar(c);
		}
		s.MakeReadOnly();
		bytesRead = (i - 1) * 2;
		return s;
	}

	/// <summary>Converts a pointer to an unmanaged Unicode string of a specified length to a <see cref="SecureString"/>.</summary>
	/// <param name="p">A pointer to an unmanaged Unicode string.</param>
	/// <param name="length">The number of Unicode characters in the unmanaged string, excluding any terminating null values.</param>
	/// <returns>A <see cref="SecureString"/> with the contents of the in memory string.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SecureString? ToSecureString(this IntPtr p, SizeT length) => ToSecureString(p, length, out _);

	/// <summary>Converts a pointer to an unmanaged Unicode string of a specified length to a <see cref="SecureString"/>.</summary>
	/// <param name="p">A pointer to an unmanaged Unicode string.</param>
	/// <param name="length">The number of Unicode characters in the unmanaged string, excluding any terminating null values.</param>
	/// <param name="bytesRead">The number of bytes read during the conversion.</param>
	/// <returns>A <see cref="SecureString"/> with the contents of the in memory string.</returns>
	public static SecureString? ToSecureString(this IntPtr p, SizeT length, out int bytesRead)
	{
		bytesRead = length * 2;
		if (p == IntPtr.Zero) return null;
		SecureString s = new();
		for (int i = 0; i < length; i++)
			s.AppendChar((char)Marshal.ReadInt16(p, i * sizeof(short)));
		s.MakeReadOnly();
		return s;
	}

	/// <summary>Converts a string to a <see cref="SecureString"/>.</summary>
	/// <param name="s">A string.</param>
	/// <returns>A <see cref="SecureString"/> with the contents of the string.</returns>
	public static SecureString ToSecureString(this string s)
	{
		var ss = new SecureString();
		foreach (var c in s)
			ss.AppendChar(c);
		ss.MakeReadOnly();
		return ss;
	}

	/// <summary>
	/// Returns an enumeration of strings from memory where each string is pointed to by a preceding list of pointers of length
	/// <paramref name="count"/>.
	/// </summary>
	/// <param name="ptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="count">The count of expected strings.</param>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>Enumeration of strings.</returns>
	public static IEnumerable<string?> ToStringEnum(this IntPtr ptr, SizeT count, CharSet charSet = CharSet.Auto, SizeT prefixBytes = default, SizeT allocatedBytes = default)
	{
		if (ptr == IntPtr.Zero || count == 0) yield break;
		if (allocatedBytes > 0 && count * IntPtr.Size + prefixBytes > allocatedBytes)
			throw new InsufficientMemoryException();
		for (var i = 0; i < count; i++)
		{
			IntPtr sptr = Marshal.ReadIntPtr(ptr.Offset(prefixBytes + i * IntPtr.Size));
			yield return StringHelper.GetString(sptr, charSet);
		}
	}

	/// <summary>
	/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character
	/// and is terminated by two '\0' characters.
	/// </summary>
	/// <param name="lptr">The <see cref="IntPtr"/> pointing to the native array.</param>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="lptr"/>.</param>
	/// <returns>An enumerated list of strings.</returns>
	public static IEnumerable<string> ToStringEnum(this IntPtr lptr, CharSet charSet = CharSet.Auto, SizeT prefixBytes = default, SizeT allocatedBytes = default)
	{
		if (lptr == IntPtr.Zero) yield break;
		var charLength = StringHelper.GetCharSize(charSet);
		var i = prefixBytes;
		if (allocatedBytes == 0)
			allocatedBytes = SizeT.MaxValue;
		else if (allocatedBytes - prefixBytes - charLength < 0)
			throw new InsufficientMemoryException();
		// handle condition where there is just the null terminator
		else if (allocatedBytes - prefixBytes - charLength == 0 && GetCh(lptr.Offset(prefixBytes)) == 0)
			yield break;
		for (IntPtr ptr = lptr.Offset(i); i + charLength <= allocatedBytes && GetCh(ptr) != 0; i += charLength, ptr = lptr.Offset(i))
		{
			for (IntPtr cptr = ptr; i + charLength <= allocatedBytes && GetCh(cptr) != 0; cptr = cptr.Offset(charLength), i += charLength) { }
			if (i + charLength > allocatedBytes)
				throw new InsufficientMemoryException();
			yield return StringHelper.GetString(ptr, charSet)!;
		}
		if (i + charLength > allocatedBytes) throw new InsufficientMemoryException();

		int GetCh(IntPtr p) => charLength == 1 ? Marshal.ReadByte(p) : Marshal.ReadInt16(p);
	}

	/// <summary>
	/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character and is
	/// terminated by two '\0' characters.
	/// </summary>
	/// <param name="lptr">The <see cref="IntPtr" /> pointing to the native array.</param>
	/// <param name="encoder">The character encoding of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="lptr" />.</param>
	/// <returns>An enumerated list of strings.</returns>
	/// <exception cref="System.InsufficientMemoryException"></exception>
	public static IEnumerable<string> ToStringEnum(this IntPtr lptr, Encoding encoder, [Optional] SizeT prefixBytes, [Optional] SizeT allocatedBytes)
	{
		int bytesread = 0, c = 0;
		if (lptr == IntPtr.Zero) yield break;
		bytesread = prefixBytes;
		for (IntPtr ptr = lptr.Offset(prefixBytes); bytesread <= allocatedBytes && encoder.GetChar(ptr).GetValueOrDefault('\0') != '\0'; bytesread += c, ptr = lptr.Offset(bytesread))
			yield return StringHelper.GetString(ptr, encoder, out c, allocatedBytes - bytesread)!;
		bytesread += encoder.GetCharSize();
		if (bytesread > allocatedBytes) throw new InsufficientMemoryException();
	}

	/// <summary>
	/// Marshals data from an unmanaged block of memory to a newly allocated managed object of the type specified by <paramref name="destType"/>.
	/// </summary>
	/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
	/// <param name="destType">The type of the object to which the data is to be copied. This must be a structure.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <param name="offset">The number of bytes to skip before reading the element.</param>
	/// <returns>A managed object that contains the data that the <paramref name="ptr"/> parameter points to.</returns>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="allocatedBytes"/> cannot be negative.</exception>
	/// <exception cref="NotSupportedException">Type specified by <paramref name="destType"/> cannot be marshaled.</exception>
	/// <exception cref="InsufficientMemoryException">The amount of allocated memory specified is insufficient to marshal the type specified.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static object? ToStructure(this IntPtr ptr, Type destType, [Optional] SizeT allocatedBytes, [Optional] SizeT offset) =>
		ToStructure(ptr, destType, allocatedBytes, offset, out _);

	/// <summary>
	/// Marshals data from an unmanaged block of memory to a newly allocated managed object of the type specified by <paramref name="destType"/>.
	/// </summary>
	/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
	/// <param name="destType">The type of the object to which the data is to be copied. This must be a structure.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <param name="offset">The number of bytes to skip before reading the element.</param>
	/// <param name="bytesRead">The number of bytes read during the conversion.</param>
	/// <returns>A managed object that contains the data that the <paramref name="ptr"/> parameter points to.</returns>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="allocatedBytes"/> cannot be negative.</exception>
	/// <exception cref="NotSupportedException">Type specified by <paramref name="destType"/> cannot be marshaled.</exception>
	/// <exception cref="InsufficientMemoryException">The amount of allocated memory specified is insufficient to marshal the type specified.</exception>
	public static object? ToStructure(this IntPtr ptr, Type destType, [Optional] SizeT allocatedBytes, [Optional] SizeT offset, out int bytesRead)
	{
		bytesRead = 0;
		if (ptr == IntPtr.Zero) return null;
		if (allocatedBytes < 0) throw new ArgumentOutOfRangeException(nameof(allocatedBytes));
		if (allocatedBytes == default) allocatedBytes = uint.MaxValue;

		// Handle pointer as special case
		if (destType == typeof(IntPtr))
		{
			bytesRead = IntPtr.Size;
			if (offset + bytesRead > allocatedBytes) throw new InsufficientMemoryException();
			return Marshal.ReadIntPtr(ptr.Offset(offset));
		}

		var typeCode = Type.GetTypeCode(destType);
		switch (typeCode)
		{
			case TypeCode.Object:
				try
				{
					if (VanaraMarshaler.CanMarshal(destType, out var marshaler))
					{
						bytesRead = marshaler.GetNativeSize();
						return marshaler.MarshalNativeToManaged(ptr.Offset(offset), allocatedBytes)!;
					}
					if (destType.IsBlittable())
					{
						return GetBlittable(destType, out bytesRead);
					}
					if (destType.IsNullable())
					{
						return GetBlittable(Nullable.GetUnderlyingType(destType)!, out bytesRead);
					}
#pragma warning disable SYSLIB0050 // Type or member is obsolete
					if (destType.IsSerializable)
					{
						using var mem = new MemoryStream(ptr.ToByteArray((int)allocatedBytes - offset, offset, allocatedBytes)!);
						var ret = new BinaryFormatter().Deserialize(mem);
						bytesRead = (int)mem.Position;
						return ret;
					}
#pragma warning restore SYSLIB0050 // Type or member is obsolete
				}
				catch (ArgumentOutOfRangeException)
				{
					throw;
				}
				catch { }
				goto default;

			case TypeCode.Boolean:
				return Convert.ChangeType(GetBlittable(typeof(uint), out bytesRead), typeCode);

			case TypeCode.Char:
				return Convert.ChangeType(GetBlittable(typeof(ushort), out bytesRead), typeCode);

			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return GetBlittable(destType, out bytesRead);

			case TypeCode.DateTime:
				return DateTime.FromBinary((long)GetBlittable(typeof(long), out bytesRead)!);

			default:
				throw new NotSupportedException("Unsupported type parameter.");
		}

		object GetBlittable(Type retType, out int read)
		{
			var trueType = TrueType(retType);
			object obj = (read = Marshal.SizeOf(trueType)) <= allocatedBytes - offset ? Marshal.PtrToStructure(ptr.Offset(offset), trueType)! : throw new InsufficientMemoryException();
			return retType == trueType ? obj : retType.IsEnum ? Enum.ToObject(retType, obj) : Convert.ChangeType(obj, retType)!;
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
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="allocatedBytes"/> cannot be negative.</exception>
	/// <exception cref="NotSupportedException">Type specified by <typeparamref name="T"/> cannot be marshaled.</exception>
	/// <exception cref="InsufficientMemoryException">The amount of allocated memory specified is insufficient to marshal the type specified.</exception>
	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? ToStructure<T>(this IntPtr ptr, [Optional] SizeT allocatedBytes, [Optional] SizeT offset) =>
		ToStructure<T>(ptr, allocatedBytes, offset, out _);

	/// <summary>
	/// Marshals data from an unmanaged block of memory to a newly allocated managed object of the type specified by a generic type parameter.
	/// </summary>
	/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
	/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <param name="offset">The number of bytes to skip before reading the element.</param>
	/// <param name="bytesRead">The number of bytes read during the conversion.</param>
	/// <returns>A managed object that contains the data that the <paramref name="ptr"/> parameter points to.</returns>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="allocatedBytes"/> cannot be negative.</exception>
	/// <exception cref="NotSupportedException">Type specified by <typeparamref name="T"/> cannot be marshaled.</exception>
	/// <exception cref="InsufficientMemoryException">The amount of allocated memory specified is insufficient to marshal the type specified.</exception>
	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? ToStructure<T>(this IntPtr ptr, [Optional] SizeT allocatedBytes, [Optional] SizeT offset, out int bytesRead) =>
		(T?)ToStructure(ptr, typeof(T), allocatedBytes, offset, out bytesRead);

	/// <summary>Marshals data from an unmanaged block of memory to a managed object.</summary>
	/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a formatted class.</typeparam>
	/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
	/// <param name="instance">The object to which the data is to be copied. This must be an instance of a formatted class.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <param name="offset">The number of bytes to skip before reading the element.</param>
	/// <returns>A managed object that contains the data that the <paramref name="ptr"/> parameter points to.</returns>
	public static void ToStructure<T>(this IntPtr ptr, T instance, SizeT allocatedBytes = default, SizeT offset = default) where T : class
	{
		if (ptr == IntPtr.Zero) throw new NullReferenceException();
		Type t = TrueType(typeof(T), out var stSize);
		if (allocatedBytes > 0 && allocatedBytes < stSize + offset)
			throw new InsufficientMemoryException();
		if (t == typeof(T))
			Marshal.PtrToStructure(ptr, instance);
		else
		{
			using var pin = new PinnedObject(instance);
			((IntPtr)pin).Write(Marshal.PtrToStructure(ptr.Offset(offset), t)!);
		}
	}

	/// <summary>Converts a single-dimensional <see cref="Array"/> to an array of <typeparamref name="T"/>.</summary>
	/// <typeparam name="T">
	/// The type of the output array. All elements in the array supplied as <paramref name="input"/> must be of this type.
	/// </typeparam>
	/// <param name="input">The input array.</param>
	/// <returns>An array of <typeparamref name="T"/> elements.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T[]? ToTypedArray<T>(this Array input) => input?.Cast<T>().ToArray();

	/// <summary>Converts a <see cref="IntPtr"/> to a <see cref="UIntPtr"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/>.</param>
	/// <returns>An equivalent <see cref="UIntPtr"/>.</returns>
	public static UIntPtr ToUIntPtr(this IntPtr p)
	{
		unsafe { return new UIntPtr(p.ToPointer()); }
	}

	/// <summary>Converts an unsafe structure pointer into a managed array.</summary>
	/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
	/// <param name="ptr">The pointer to the first structure in the native array.</param>
	/// <param name="count">The number of items in the native array.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>An array of type <typeparamref name="T"/> containing the elements of the native array.</returns>
	public static unsafe T[] UnsafePtrToArray<T>(T* ptr, SizeT count, SizeT allocatedBytes = default) where T : unmanaged
	{
		SizeT stSize = SizeOf<T>();
		if (allocatedBytes > 0 && stSize * count > allocatedBytes)
			throw new InsufficientMemoryException();
		if (allocatedBytes == default) allocatedBytes = uint.MaxValue;

		var ret = new T[count];
		for (var i = 0; i < count; i++)
			ret[i] = ptr[i];
		return ret;
	}

	/// <summary>Marshals data from a managed list of specified type to a pre-allocated unmanaged block of memory.</summary>
	/// <typeparam name="T">
	/// A type of the enumerated managed object that holds the data to be marshaled. The object must be a structure or an instance of a
	/// formatted class.
	/// </typeparam>
	/// <param name="ptr">
	/// A pointer to a pre-allocated block of memory. The allocated memory must be sufficient to hold the size of <typeparamref
	/// name="T"/> times the number of items in the enumeration plus the number of bytes specified by <paramref name="offset"/>.
	/// </param>
	/// <param name="items">The enumerated list of items to marshal.</param>
	/// <param name="offset">The number of bytes to skip before writing the first element of <paramref name="items"/>.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>The number of bytes written. The offset is not included.</returns>
	/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
	/// <exception cref="InsufficientMemoryException"></exception>
	public static SizeT Write<T>(this IntPtr ptr, IEnumerable<T> items, SizeT offset = default, SizeT allocatedBytes = default)
	{
		var count = items?.Count() ?? 0;
		if (count == 0) return 0;

		Type ttype = TrueType(typeof(T), out var stSize);
		if (!ttype.IsMarshalable())
			throw new ArgumentException(@"Structure layout is not sequential or explicit.");

		var bytesReq = stSize * count + offset;
		if (allocatedBytes > 0 && bytesReq > allocatedBytes)
			throw new InsufficientMemoryException();

		var i = 0;
		foreach (object? item in items!.Select(v => Convert.ChangeType(v, ttype)).Where(v => v != null))
			WriteNoChecks(ptr, item, offset + i++ * stSize, allocatedBytes);

		return bytesReq - offset;
	}

	/// <summary>Marshals data from a managed list of strings to a pre-allocated unmanaged block of memory.</summary>
	/// <param name="ptr">
	/// A pointer to a pre-allocated block of memory. The allocated memory must be sufficient to hold the size of all the strings in the
	/// enumeration plus pointers or '\0' characters required by <paramref name="packing"/>.
	/// </param>
	/// <param name="items">The enumerated list of items to marshal.</param>
	/// <param name="packing">The packing type for the strings.</param>
	/// <param name="charSet">The character set to use for the strings.</param>
	/// <param name="offset">The number of bytes to skip before writing the first element of <paramref name="items"/>.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>The number of bytes written. The offset is not included.</returns>
	/// <exception cref="InsufficientMemoryException"></exception>
	/// <exception cref="ArgumentException">Concatenated string arrays cannot contain empty or null strings.</exception>
	/// <exception cref="ArgumentException">Structure layout is not sequential or explicit.</exception>
	/// <exception cref="InsufficientMemoryException"></exception>
	public static SizeT Write(this IntPtr ptr, IEnumerable<string?> items, StringListPackMethod packing, CharSet charSet = CharSet.Auto, SizeT offset = default, SizeT allocatedBytes = default)
	{
		// Check size
		int sz = GetStrListSize(items, packing, charSet);
		if (allocatedBytes > 0 && (sz > 0 && sz + offset > allocatedBytes) || (sz < 0 && -sz + offset > allocatedBytes))
			throw new InsufficientMemoryException();

		// Bail early if empty
		if (sz < 0)
			return -sz;

		if (packing == StringListPackMethod.Packed)
		{
			int c = items.Count();
			IntPtr p = ptr.Offset(offset), sp = ptr.Offset((c + 1) * IntPtr.Size + offset);
			foreach (var s in items)
			{
				if (s is null)
					Marshal.WriteIntPtr(p, IntPtr.Zero);
				else
				{
					Marshal.WriteIntPtr(p, sp);
					StringHelper.Write(s, sp, out var b, true, charSet);
					sp = sp.Offset(b);
				}
				p = p.Offset(IntPtr.Size);
			}
			Marshal.WriteIntPtr(p, IntPtr.Zero);
		}
		else
		{
			SizeT poff = offset;
			foreach (var s in items)
			{
				if (string.IsNullOrEmpty(s)) throw new ArgumentException("Concatenated string arrays cannot contain empty or null strings.");
				StringHelper.Write(s, ptr.Offset(poff), out var b, true, charSet);
				poff += b;
			}
			StringHelper.Write("", ptr.Offset(poff), out _, true, charSet);
		}
		return sz;
	}

	/// <summary>Writes the specified value to pre-allocated memory.</summary>
	/// <param name="ptr">The address of the memory where the value is to be written.</param>
	/// <param name="value">The value to write.</param>
	/// <param name="offset">The number of bytes to offset from <paramref name="ptr"/> before writing.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>The number of bytes written. The offset is not included.</returns>
	/// <exception cref="InsufficientMemoryException"></exception>
	public static SizeT Write(this IntPtr ptr, object? value, SizeT offset = default, SizeT allocatedBytes = default)
	{
		if (value is null) return 0;
		//if (!value.GetType().IsMarshalable())
		//	throw new ArgumentException(@"Value cannot be serialized to memory.", nameof(value));
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
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SizeT Write<T>(this IntPtr ptr, in T value, SizeT offset = default, SizeT allocatedBytes = default) where T : struct =>
		WriteNoChecks(ptr, value, offset, allocatedBytes);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Type TrueType(Type type) => type.IsEnum ? Enum.GetUnderlyingType(type) : type == typeof(bool) ? typeof(uint) : type;

	internal static Type TrueType(Type type, out int size)
	{
		Type ttype = TrueType(type);
		try { size = Marshal.SizeOf(ttype); } catch { size = 0; }
		return ttype;
	}

	internal static SizeT WriteNoChecks(IntPtr ptr, object? value, SizeT offset, SizeT allocatedBytes)
	{
		if (value is null) return 0;
		if (value is IntPtr p) { Marshal.WriteIntPtr(ptr.Offset(offset), p); return IntPtr.Size; }
		if (value is IEnumerable<byte> b) value = b.ToArray();
		if (value is byte[] ba)
		{
			if (allocatedBytes > 0 && offset + ba.Length > allocatedBytes)
				throw new InsufficientMemoryException();
			Marshal.Copy(ba, 0, ptr.Offset(offset), ba.Length);
			return ba.Length;
		}

		Type valType = value.GetType();

		// Handle marshaled items
		if (VanaraMarshaler.CanMarshal(valType, out var marshaler))
		{
			using SafeAllocatedMemoryHandle mem = marshaler.MarshalManagedToNative(value);
			if (allocatedBytes > 0 && offset + mem.Size > allocatedBytes)
				throw new InsufficientMemoryException();
			mem.DangerousGetHandle().CopyTo(ptr.Offset(offset), mem.Size);
			return mem.Size;
		}

		// Handle strings (risk is wrong CharSet)
		if (value is string s)
		{
			StringHelper.Write(s, ptr.Offset(offset), out var wrtn, true, CharSet.Auto, allocatedBytes == 0 ? long.MaxValue : allocatedBytes);
			return wrtn;
		}

		// Handle simple types
		if (valType.IsBlittable() && !valType.IsArray)
		{
			var newVal = TrueValue(value, out var cbValue);
			if (allocatedBytes > 0 && offset + cbValue > allocatedBytes)
				throw new InsufficientMemoryException();
			Marshal.StructureToPtr(newVal!, ptr.Offset(offset), false);
			return cbValue;
		}

		// Handle string lists
		if (value is IEnumerable<string> ies)
		{
			return ptr.Write(ies, StringListPackMethod.Concatenated, CharSet.Auto, offset, allocatedBytes);
		}

		// Handle arrays
		if (valType.IsArray && ((Array)value).Rank == 1)
		{
			Type ttype = TrueType(valType.GetElementType()!, out var stSize);
			if (!ttype.IsMarshalable())
				throw new ArgumentException(@"Structure layout is not sequential or explicit.");

			var arr = (Array)value;

			var count = arr.Length;
			if (count == 0) return 0;

			var bytesReq = stSize * count + offset;
			if (allocatedBytes > 0 && bytesReq > allocatedBytes)
				throw new InsufficientMemoryException();

			for (var i = 0; i < count; i++)
			{
				var o = arr.GetValue(i);
				if (o is null) continue;
				var v = Convert.ChangeType(o, ttype);
				WriteNoChecks(ptr, o, offset + i * stSize, allocatedBytes);
			}

			return bytesReq - offset;
		}

		// Handle enumerations
		if (IsGenericEnumerable(valType))
		{
			Type ttype = TrueType(valType.GetGenericArguments()[0], out var stSize);
			if (!ttype.IsMarshalable())
				throw new ArgumentException(@"Structure layout is not sequential or explicit.");

			var items = new List<object>(((System.Collections.IEnumerable)value).Cast<object>());
			var count = items.Count;
			if (count == 0) return 0;

			var bytesReq = stSize * count + offset;
			if (allocatedBytes > 0 && bytesReq > allocatedBytes)
				throw new InsufficientMemoryException();

			var i = 0;
			foreach (var item in items.Select(v => Convert.ChangeType(v, ttype)).Where(v => v != null))
				WriteNoChecks(ptr, item, offset + i++ * stSize, allocatedBytes);

			return bytesReq - offset;
		}

		// Handle binary serialization
#pragma warning disable SYSLIB0050 // Type or member is obsolete
		if (valType.IsSerializable)
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
#pragma warning restore SYSLIB0050 // Type or member is obsolete

		throw new ArgumentException("Unable to convert object to its binary format.");

		static bool IsGenericEnumerable(Type t)
		{
			var genArgs = t.GetGenericArguments();
			if (genArgs.Length == 1 && typeof(IEnumerable<>).MakeGenericType(genArgs).IsAssignableFrom(t))
				return true;
			else
				return t.BaseType != null && IsGenericEnumerable(t.BaseType);
		}
	}

	private static IntPtr AllocWrite(SizeT cnt, Action<IntPtr, int>? writer, Func<int, IntPtr> memAlloc, Func<IntPtr, IntPtr>? memLock = null, Func<IntPtr, bool>? memUnlock = null)
	{
		IntPtr alloc = memAlloc(cnt);
		IntPtr lck = memLock?.Invoke(alloc) ?? alloc;
		try
		{
			FillMemory(lck, 0, cnt);
			writer?.Invoke(lck, cnt);
		}
		finally
		{
			memUnlock?.Invoke(alloc);
		}
		return alloc;
	}

	private static int GetStrListSize(IEnumerable<string?> items, StringListPackMethod packing, CharSet charSet)
	{
		int chSz = StringHelper.GetCharSize(charSet);
		if (items is null || !items.Any())
			return -(packing == StringListPackMethod.Concatenated ? chSz : IntPtr.Size);
		SizeT count = items.Count();
		return items.Sum(i => StringHelper.GetByteCount(i, true, charSet)) + (packing == StringListPackMethod.Concatenated ? chSz : (count + 1) * IntPtr.Size);
	}

	private static object? TrueValue(object? value, out int size)
	{
		size = 0;
		return value is null ? null : Convert.ChangeType(value, TrueType(value.GetType(), out size));
	}
}