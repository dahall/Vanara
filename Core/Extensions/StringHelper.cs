#nullable enable

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.Extensions;

/// <summary>A safe class that represents an object that is pinned in memory.</summary>
/// <seealso cref="IDisposable"/>
public static class StringHelper
{
	/// <summary>Allocates a block of memory allocated from the unmanaged COM task allocator sufficient to hold the number of specified characters.</summary>
	/// <param name="count">The number of characters, inclusive of the null terminator.</param>
	/// <param name="memAllocator">The method used to allocate the memory.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The address of the block of memory allocated.</returns>
	public static IntPtr AllocChars(uint count, Func<int, IntPtr> memAllocator, CharSet charSet = CharSet.Auto)
	{
		if (count == 0) return IntPtr.Zero;
		var sz = GetCharSize(charSet);
		var ptr = memAllocator((int)count * sz);
		if (count > 0)
		{
			if (sz == 1)
				Marshal.WriteByte(ptr, 0);
			else
				Marshal.WriteInt16(ptr, 0);
		}
		return ptr;
	}

	/// <summary>Allocates a block of memory allocated from the unmanaged COM task allocator sufficient to hold the number of specified characters.</summary>
	/// <param name="count">The number of characters, inclusive of the null terminator.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The address of the block of memory allocated.</returns>
	public static IntPtr AllocChars(uint count, CharSet charSet = CharSet.Auto) => AllocChars(count, Marshal.AllocCoTaskMem, charSet);

	/// <summary>Copies the contents of a managed <see cref="SecureString"/> object to a block of memory allocated from the unmanaged COM task allocator.</summary>
	/// <param name="s">The managed object to copy.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The address, in unmanaged memory, where the <paramref name="s"/> parameter was copied to, or 0 if a null object was supplied.</returns>
	public static IntPtr AllocSecureString(SecureString? s, CharSet charSet = CharSet.Auto)
	{
		if (s == null) return IntPtr.Zero;
		if (GetCharSize(charSet) == 2)
			return Marshal.SecureStringToCoTaskMemUnicode(s);
		return Marshal.SecureStringToCoTaskMemAnsi(s);
	}

	/// <summary>Copies the contents of a managed <see cref="SecureString"/> object to a block of memory allocated from a supplied allocation method.</summary>
	/// <param name="s">The managed object to copy.</param>
	/// <param name="charSet">The character set.</param>
	/// <param name="memAllocator">The method used to allocate the memory.</param>
	/// <returns>The address, in unmanaged memory, where the <paramref name="s"/> parameter was copied to, or 0 if a null object was supplied.</returns>
	public static IntPtr AllocSecureString(SecureString? s, CharSet charSet, Func<int, IntPtr> memAllocator) => AllocSecureString(s, charSet, memAllocator, out _);

	/// <summary>Copies the contents of a managed <see cref="SecureString"/> object to a block of memory allocated from a supplied allocation method.</summary>
	/// <param name="s">The managed object to copy.</param>
	/// <param name="charSet">The character set.</param>
	/// <param name="memAllocator">The method used to allocate the memory.</param>
	/// <param name="allocatedBytes">Returns the number of allocated bytes for the string.</param>
	/// <returns>The address, in unmanaged memory, where the <paramref name="s"/> parameter was copied to, or 0 if a null object was supplied.</returns>
	public static IntPtr AllocSecureString(SecureString? s, CharSet charSet, Func<int, IntPtr> memAllocator, out int allocatedBytes)
	{
		allocatedBytes = 0;
		if (s == null) return IntPtr.Zero;
		var chSz = GetCharSize(charSet);
		var encoding = chSz == 2 ? Encoding.Unicode : Encoding.UTF8;
		var hMem = AllocSecureString(s, charSet);
		var str = chSz == 2 ? Marshal.PtrToStringUni(hMem) : Marshal.PtrToStringAnsi(hMem);
		Marshal.FreeCoTaskMem(hMem);
		if (str == null) return IntPtr.Zero;
		var b = encoding.GetBytes(str);
		var p = memAllocator(b.Length);
		Marshal.Copy(b, 0, p, b.Length);
		allocatedBytes = b.Length;
		return p;
	}

	/// <summary>Copies the contents of a managed String to a block of memory allocated from the unmanaged COM task allocator.</summary>
	/// <param name="s">A managed string to be copied.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The allocated memory block, or 0 if <paramref name="s"/> is null.</returns>
	public static IntPtr AllocString(string? s, CharSet charSet = CharSet.Auto) => charSet == CharSet.Auto ? Marshal.StringToCoTaskMemAuto(s) : (charSet == CharSet.Unicode ? Marshal.StringToCoTaskMemUni(s) : Marshal.StringToCoTaskMemAnsi(s));

	/// <summary>Copies the contents of a managed String to a block of memory allocated from a supplied allocation method.</summary>
	/// <param name="s">A managed string to be copied.</param>
	/// <param name="charSet">The character set.</param>
	/// <param name="memAllocator">The method used to allocate the memory.</param>
	/// <returns>The allocated memory block, or 0 if <paramref name="s"/> is null.</returns>
	public static IntPtr AllocString(string? s, CharSet charSet, Func<int, IntPtr> memAllocator) => AllocString(s, charSet, memAllocator, out _);

	/// <summary>
	/// Copies the contents of a managed String to a block of memory allocated from a supplied allocation method.
	/// </summary>
	/// <param name="s">A managed string to be copied.</param>
	/// <param name="charSet">The character set.</param>
	/// <param name="memAllocator">The method used to allocate the memory.</param>
	/// <param name="allocatedBytes">Returns the number of allocated bytes for the string.</param>
	/// <returns>The allocated memory block, or 0 if <paramref name="s" /> is null.</returns>
	public static IntPtr AllocString(string? s, CharSet charSet, Func<int, IntPtr> memAllocator, out int allocatedBytes)
	{
		if (s == null) { allocatedBytes = 0; return IntPtr.Zero; }
		var b = s.GetBytes(true, charSet);
		var p = memAllocator(b.Length);
		Marshal.Copy(b, 0, p, allocatedBytes = b.Length);
		return p;
	}

	/// <summary>
	/// Zeros out the allocated memory behind a secure string and then frees that memory.
	/// </summary>
	/// <param name="ptr">The address of the memory to be freed.</param>
	/// <param name="sizeInBytes">The size in bytes of the memory pointed to by <paramref name="ptr"/>.</param>
	/// <param name="memFreer">The memory freer.</param>
	public static void FreeSecureString(IntPtr ptr, int sizeInBytes, Action<IntPtr> memFreer)
	{
		if (IsValue(ptr)) return;
		var b = new byte[sizeInBytes];
		Marshal.Copy(b, 0, ptr, b.Length);
		memFreer(ptr);
	}

	/// <summary>Frees a block of memory allocated by the unmanaged COM task memory allocator for a string.</summary>
	/// <param name="ptr">The address of the memory to be freed.</param>
	/// <param name="charSet">The character set of the string.</param>
	public static void FreeString(IntPtr ptr, CharSet charSet = CharSet.Auto)
	{
		if (IsValue(ptr)) return;
		if (GetCharSize(charSet) == 2)
			Marshal.ZeroFreeCoTaskMemUnicode(ptr);
		else
			Marshal.ZeroFreeCoTaskMemAnsi(ptr);
	}

	/// <summary>Gets the encoded bytes for a string including an optional null terminator.</summary>
	/// <param name="value">The string value to convert.</param>
	/// <param name="nullTerm">if set to <c>true</c> include a null terminator at the end of the string in the resulting byte array.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>A byte array including <paramref name="value"/> encoded as per <paramref name="charSet"/> and the optional null terminator.</returns>
	public static byte[] GetBytes(this string value, bool nullTerm = true, CharSet charSet = CharSet.Auto) =>
		GetBytes(value, GetCharSize(charSet) == 1 ? Encoding.UTF8 : Encoding.Unicode, nullTerm);

	/// <summary>Gets the encoded bytes for a string including an optional null terminator.</summary>
	/// <param name="value">The string value to convert.</param>
	/// <param name="enc">The character encoding.</param>
	/// <param name="nullTerm">if set to <c>true</c> include a null terminator at the end of the string in the resulting byte array.</param>
	/// <returns>A byte array including <paramref name="value"/> encoded as per <paramref name="enc"/> and the optional null terminator.</returns>
	public static byte[] GetBytes(this string value, Encoding enc, bool nullTerm = true)
	{
		var chSz = GetCharSize(enc);
		var ret = new byte[enc.GetByteCount(value) + (nullTerm ? chSz : 0)];
		enc.GetBytes(value, 0, value.Length, ret, 0);
		if (nullTerm)
			enc.GetBytes(new[] { '\0' }, 0, 1, ret, ret.Length - chSz);
		return ret;
	}

	/// <summary>Gets the number of bytes required to store the string.</summary>
	/// <param name="value">The string value.</param>
	/// <param name="nullTerm">if set to <c>true</c> include a null terminator at the end of the string in the count if <paramref name="value"/> does not equal <c>null</c>.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The number of bytes required to store <paramref name="value"/>. Returns 0 if <paramref name="value"/> is <c>null</c>.</returns>
	public static int GetByteCount(this string? value, bool nullTerm = true, CharSet charSet = CharSet.Auto) =>
		GetByteCount(value, GetCharSize(charSet) == 1 ? Encoding.UTF8 : Encoding.Unicode, nullTerm);

	/// <summary>Gets the number of bytes required to store the string.</summary>
	/// <param name="value">The string value.</param>
	/// <param name="enc">The character encoding.</param>
	/// <param name="nullTerm">if set to <c>true</c> include a null terminator at the end of the string in the count if <paramref name="value"/> does not equal <c>null</c>.</param>
	/// <returns>The number of bytes required to store <paramref name="value"/>. Returns 0 if <paramref name="value"/> is <c>null</c>.</returns>
	public static int GetByteCount(this string? value, Encoding enc, bool nullTerm = true) =>
		value is null ? 0 : enc.GetByteCount(value) + (nullTerm ? GetCharSize(enc) : 0);

	/// <summary>Gets the size of a character defined by the supplied <see cref="CharSet"/>.</summary>
	/// <param name="charSet">The character set to size.</param>
	/// <returns>The size of a standard character, in bytes, from <paramref name="charSet"/>.</returns>
	public static int GetCharSize(CharSet charSet = CharSet.Auto) => charSet == CharSet.Auto ? Marshal.SystemDefaultCharSize : (charSet == CharSet.Unicode ? UnicodeEncoding.CharSize : 1);

	/// <summary>Gets the size of a character defined by the supplied <see cref="Encoding"/>.</summary>
	/// <param name="enc">The character encoding type.</param>
	/// <returns>The size of a standard character, in bytes, from <paramref name="enc"/>.</returns>
	public static int GetCharSize(Encoding enc) => enc.GetByteCount(new[] { '\0' });

	/// <summary>
	/// Allocates a managed String and copies all characters up to the first null character or the end of the allocated memory pool from a string stored in unmanaged memory into it.
	/// </summary>
	/// <param name="ptr">The address of the first character.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	/// <returns>
	/// A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr"/> parameter is not null;
	/// otherwise, this method returns null.
	/// </returns>
	public static string? GetString(IntPtr ptr, CharSet charSet = CharSet.Auto, long allocatedBytes = long.MaxValue)
	{
		if (IsValue(ptr)) return null;
		var sb = new StringBuilder();
		unsafe
		{
			var chkLen = 0L;
			if (GetCharSize(charSet) == 1)
			{
				for (var uptr = (byte*)ptr; chkLen < allocatedBytes && *uptr != 0; chkLen++, uptr++)
					sb.Append((char)*uptr);
			}
			else
			{
				for (var uptr = (ushort*)ptr; chkLen + 2 <= allocatedBytes && *uptr != 0; chkLen += 2, uptr++)
					sb.Append((char)*uptr);
			}
		}
		return sb.ToString();
	}

	/// <summary>
	/// Allocates a managed String and copies all characters up to the first null character or at most <paramref name="length"/> characters from a string stored in unmanaged memory into it.
	/// </summary>
	/// <param name="ptr">The address of the first character.</param>
	/// <param name="length">The number of characters to copy.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <returns>
	/// A managed string that holds a copy of the unmanaged string if the value of the <paramref name="ptr"/> parameter is not null;
	/// otherwise, this method returns null.
	/// </returns>
	public static string? GetString(IntPtr ptr, int length, CharSet charSet = CharSet.Auto) => GetString(ptr, charSet, length * GetCharSize(charSet));

	/// <summary>Indicates whether a specified string is <see langword="null"/>, empty, or consists only of white-space characters.</summary>
	/// <param name="value">The string to test.</param>
	/// <returns>
	/// <see langword="true"/> if the <paramref name="value"/> parameter is <see langword="null"/> or <see cref="string.Empty"/>, or if
	/// value consists exclusively of white-space characters.
	/// </returns>
	public static bool IsNullOrWhiteSpace(string? value) => value is null || value.All(char.IsWhiteSpace);

	/// <summary>Refreshes the memory block from the unmanaged COM task allocator and copies the contents of a new managed String.</summary>
	/// <param name="ptr">The address of the first character.</param>
	/// <param name="charLen">Receives the new character length of the allocated memory block.</param>
	/// <param name="s">A managed string to be copied.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <returns><c>true</c> if the memory block was reallocated; <c>false</c> if set to null.</returns>
	public static bool RefreshString(ref IntPtr ptr, out uint charLen, string? s, CharSet charSet = CharSet.Auto)
	{
		FreeString(ptr, charSet);
		ptr = AllocString(s, charSet);
		charLen = s == null ? 0U : (uint)s.Length + 1;
		return s != null;
	}

	/// <summary>Writes the specified string to a pointer to allocated memory.</summary>
	/// <param name="value">The string value.</param>
	/// <param name="ptr">The pointer to the allocated memory.</param>
	/// <param name="byteCnt">The resulting number of bytes written.</param>
	/// <param name="nullTerm">if set to <c>true</c> include a null terminator at the end of the string in the count if <paramref name="value"/> does not equal <c>null</c>.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
	public static void Write(string? value, IntPtr ptr, out int byteCnt, bool nullTerm = true, CharSet charSet = CharSet.Auto, long allocatedBytes = long.MaxValue)
	{
		if (value is null)
		{
			byteCnt = 0;
			return;
		}
		if (ptr == IntPtr.Zero) throw new ArgumentNullException(nameof(ptr));
		var bytes = GetBytes(value, nullTerm, charSet);
		if (bytes.Length > allocatedBytes)
			throw new ArgumentOutOfRangeException(nameof(allocatedBytes));
		byteCnt = bytes.Length;
		Marshal.Copy(bytes, 0, ptr, byteCnt);
	}

	private static bool IsValue(IntPtr ptr) => ptr.ToInt64() >> 16 == 0;
}