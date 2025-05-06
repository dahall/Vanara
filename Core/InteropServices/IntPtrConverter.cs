namespace Vanara.InteropServices;

/// <summary>Functions to safely convert a memory pointer to a type.</summary>
public static class IntPtrConverter
{
	/// <summary>Converts the specified pointer to <typeparamref name="T"/>.</summary>
	/// <typeparam name="T">The destination type.</typeparam>
	/// <param name="ptr">The pointer to a block of memory.</param>
	/// <param name="sz">The size of the allocated memory block.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>A value of the type specified.</returns>
	public static T? Convert<T>(this IntPtr ptr, uint sz, CharSet charSet = CharSet.Auto) => Convert<T>(ptr, sz, charSet.ToEncoding());

	/// <summary>Converts the specified pointer to <typeparamref name="T"/>.</summary>
	/// <typeparam name="T">The destination type.</typeparam>
	/// <param name="ptr">The pointer to a block of memory.</param>
	/// <param name="sz">The size of the allocated memory block.</param>
	/// <param name="encoding">The character encoding.</param>
	/// <returns>A value of the type specified.</returns>
	public static T? Convert<T>(this IntPtr ptr, uint sz, Encoding encoding) => (T?)Convert(ptr, sz, typeof(T), encoding);

	/// <summary>Converts the specified pointer to <typeparamref name="T"/>.</summary>
	/// <typeparam name="T">The destination type.</typeparam>
	/// <param name="hMem">A block of allocated memory.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>A value of the type specified.</returns>
	public static T? ToType<T>(this SafeAllocatedMemoryHandle hMem, CharSet charSet = CharSet.Auto) =>
		ToType<T>(hMem, charSet.ToEncoding());

	/// <summary>Converts the specified pointer to <typeparamref name="T"/>.</summary>
	/// <typeparam name="T">The destination type.</typeparam>
	/// <param name="hMem">A block of allocated memory.</param>
	/// <param name="encoding">The character encoding.</param>
	/// <returns>A value of the type specified.</returns>
	public static T? ToType<T>(this SafeAllocatedMemoryHandle hMem, Encoding encoding)
	{
		if (hMem is null) throw new ArgumentNullException(nameof(hMem));
		hMem.Lock();
		try { return Convert<T>(hMem.DangerousGetHandle(), hMem.Size, encoding); }
		finally { hMem.Unlock(); }
	}

	/// <summary>Converts the specified pointer to type specified in <paramref name="destType"/>.</summary>
	/// <param name="ptr">The pointer to a block of memory.</param>
	/// <param name="sz">The size of the allocated memory block.</param>
	/// <param name="destType">The destination type.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>A value of the type specified.</returns>
	/// <exception cref="ArgumentException">Cannot convert a null pointer. - ptr or Cannot convert a pointer with no Size. - sz</exception>
	/// <exception cref="NotSupportedException">Thrown if type cannot be converted from memory.</exception>
	/// <exception cref="OutOfMemoryException"></exception>
	public static object? Convert(this IntPtr ptr, uint sz, Type destType, CharSet charSet = CharSet.Auto) => Convert(ptr, sz, destType, charSet.ToEncoding());

	/// <summary>Converts the specified pointer to type specified in <paramref name="destType"/>.</summary>
	/// <param name="ptr">The pointer to a block of memory.</param>
	/// <param name="sz">The size of the allocated memory block.</param>
	/// <param name="destType">The destination type.</param>
	/// <param name="encoding">The character encoding.</param>
	/// <returns>A value of the type specified.</returns>
	/// <exception cref="ArgumentException">Cannot convert a null pointer. - ptr or Cannot convert a pointer with no Size. - sz</exception>
	/// <exception cref="NotSupportedException">Thrown if type cannot be converted from memory.</exception>
	/// <exception cref="OutOfMemoryException"></exception>
	public static object? Convert(this IntPtr ptr, uint sz, Type destType, Encoding encoding)
	{
		if (ptr == IntPtr.Zero)
		{
			if (!destType.IsValueType) return null;
			throw new NullReferenceException();
		}
		if (sz == 0) throw new ArgumentException("Cannot convert a pointer with no Size.", nameof(sz));

		// Handle array and string as special cases
		if (destType.IsArray)
		{
			Type elemType = destType.GetElementType()!;
			if (elemType == typeof(byte))
				return ptr.ToByteArray((int)sz, 0, sz);
			int elemSz = Marshal.SizeOf(elemType);
			return ptr.ToArray(elemType, (int)sz / elemSz, 0, sz);
		}
		if (destType == typeof(string))
			return StringHelper.GetString(ptr, encoding, out _, sz);
		if (destType.IsCOMObject)
			return Marshal.GetObjectForIUnknown(ptr);
		return ptr.ToStructure(destType, sz, 0, out _);
	}
}