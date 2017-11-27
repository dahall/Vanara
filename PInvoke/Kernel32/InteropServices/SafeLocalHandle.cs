using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.InteropServices
{
	/// <summary>Unmanaged memory methods for local heap.</summary>
	/// <seealso cref="IMemoryMethods"/>
	public sealed class LocalMemoryMethods : IMemoryMethods
	{
		/// <summary>Gets the allocation method.</summary>
		public Func<int, IntPtr> AllocMem => i => { var o = LocalAlloc(LocalMemoryFlags.LPTR, (UIntPtr)i); return o != IntPtr.Zero ? o : throw Win32Error.GetLastError().GetException(); };
		/// <summary>Gets the reallocation method.</summary>
		public Func<IntPtr, int, IntPtr> ReAllocMem => (p, i) => { var o = LocalReAlloc(p, (UIntPtr)i, LocalMemoryFlags.LMEM_MOVEABLE); return o != IntPtr.Zero ? o : throw Win32Error.GetLastError().GetException(); };
		/// <summary>Gets the free method.</summary>
		public Action<IntPtr> FreeMem => p => LocalFree(p);
		/// <summary>Gets the Unicode string allocation method.</summary>
		public Func<string, IntPtr> AllocStringUni => s => MakeString(s, CharSet.Unicode);
		/// <summary>Gets the Ansi string allocation method.</summary>
		public Func<string, IntPtr> AllocStringAnsi => s => MakeString(s, CharSet.Ansi);
		/// <summary>Gets the Unicode <see cref="SecureString"/> allocation method.</summary>
		public Func<SecureString, IntPtr> AllocSecureStringUni => s => MakeSecString(s, CharSet.Unicode);
		/// <summary>Gets the Ansi <see cref="SecureString"/> allocation method.</summary>
		public Func<SecureString, IntPtr> AllocSecureStringAnsi => s => MakeSecString(s, CharSet.Ansi);
		/// <summary>Gets the Unicode <see cref="SecureString"/> free method.</summary>
		public Action<IntPtr> FreeSecureStringUni => FreeSecureString;
		/// <summary>Gets the Ansi <see cref="SecureString"/> free method.</summary>
		public Action<IntPtr> FreeSecureStringAnsi => FreeSecureString;

		private void FreeSecureString(IntPtr p)
		{
			if (p == IntPtr.Zero) return;
			var i = LocalSize(p);
			var b = new byte[i];
			Marshal.Copy(b, 0, p, b.Length);
			FreeMem(p);
		}

		private IntPtr MakeSecString(SecureString s, CharSet charSet)
		{
			if (s == null) return IntPtr.Zero;
			var chSz = StringHelper.GetCharSize(charSet);
			var encoding = chSz == 2 ? System.Text.Encoding.Unicode : System.Text.Encoding.ASCII;
			var hMem = StringHelper.AllocSecureString(s, charSet);
			var str = chSz == 2 ? Marshal.PtrToStringUni(hMem) : Marshal.PtrToStringAnsi(hMem);
			Marshal.FreeCoTaskMem(hMem);
			if (str == null) return IntPtr.Zero;
			var b = encoding.GetBytes(str);
			var p = AllocMem(b.Length);
			Marshal.Copy(b, 0, p, b.Length);
			return p;
		}

		private IntPtr MakeString(string s, CharSet charSet)
		{
			if (s == null) return IntPtr.Zero;
			var b = s.GetBytes(true, charSet);
			var p = AllocMem(b.Length);
			Marshal.Copy(b, 0, p, b.Length);
			return p;
		}
	}

	/// <summary>A <see cref="SafeHandle"/> for memory allocated via LocalAlloc.</summary>
	/// <seealso cref="System.Runtime.InteropServices.SafeHandle"/>
	public class SafeLocalHandle : SafeMemoryHandleExt<LocalMemoryMethods>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeLocalHandle"/> class.</summary>
		/// <param name="handle">The handle.</param>
		/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		public SafeLocalHandle(IntPtr handle, int size, bool ownsHandle = true) : base(handle, size, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeLocalHandle"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		public SafeLocalHandle(int size) : base(size) { }

		/// <summary>Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native array equivalent.</summary>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeLocalHandle object to an native (unmanaged) array of pointers</returns>
		public SafeLocalHandle(byte[] bytes) : base(bytes) { }

		/// <summary>Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native array equivalent.</summary>
		/// <param name="values">Array of unmanaged pointers</param>
		/// <returns>SafeLocalHandle object to an native (unmanaged) array of pointers</returns>
		public SafeLocalHandle(IntPtr[] values) : base(values) { }

		/// <summary>Allocates from unmanaged memory to represent a Unicode string (WSTR) and marshal this to a native PWSTR.</summary>
		/// <param name="s">The string value.</param>
		/// <returns>SafeLocalHandle object to an native (unmanaged) Unicode string</returns>
		public SafeLocalHandle(string s) : base(s) { }

		/// <summary>Initializes a new instance of the <see cref="SafeLocalHandle"/> class.</summary>
		[ExcludeFromCodeCoverage]
		internal SafeLocalHandle() : base(0) { }

		/// <summary>Represents a NULL memory pointer.</summary>
		public static SafeLocalHandle Null { get; } = new SafeLocalHandle(IntPtr.Zero, 0, false);

		/// <summary>Converts an <see cref="IntPtr"/> to a <see cref="SafeLocalHandle"/> where it owns the reference.</summary>
		/// <param name="ptr">The <see cref="IntPtr"/>.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeLocalHandle(IntPtr ptr) => new SafeLocalHandle(ptr, 0, true);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
		/// <typeparam name="T">Native type</typeparam>
		/// <param name="value">The value.</param>
		/// <returns><see cref="SafeLocalHandle"/> object to an native (unmanaged) memory block the size of T.</returns>
		public static SafeLocalHandle CreateFromStructure<T>(T value = default(T)) => new SafeLocalHandle(InteropExtensions.StructureToPtr(value, mm.AllocMem, out int s), s);

		/// <summary>
		/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure elements. It is the
		/// callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY structures with attribute StructLayout of
		/// LayoutKind.Sequential are supported.
		/// </summary>
		/// <typeparam name="T">Type of the trailing array of structures</typeparam>
		/// <param name="values">Collection of structure objects</param>
		/// <param name="count">Number of items in <paramref name="values"/>.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
		/// <returns><see cref="SafeLocalHandle"/> object to an native (unmanaged) structure with a trail array of structures</returns>
		public static SafeLocalHandle CreateFromList<T>(IEnumerable<T> values, int count = -1, int prefixBytes = 0) => new SafeLocalHandle(InteropExtensions.MarshalToPtr(values, mm.AllocMem, out int s, prefixBytes), s);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
		/// <param name="values">The list of strings.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns><see cref="SafeLocalHandle"/> object to an native (unmanaged) array of strings stored using the <paramref name="packing"/> model and the character set defined by <paramref name="charSet"/>.</returns>
		public static SafeLocalHandle CreateFromStringList(IEnumerable<string> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto, int prefixBytes = 0) => new SafeLocalHandle(InteropExtensions.MarshalToPtr(values, packing, mm.AllocMem, out int s, charSet, prefixBytes), s);
	}
}