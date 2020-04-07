using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;
using Vanara.PInvoke;

namespace Vanara.InteropServices
{
	/// <summary>Method used to pack a list of strings into memory.</summary>
	public enum StringListPackMethod
	{
		/// <summary>Each string is separated by a single '\0' character and is terminated by two '\0' characters.</summary>
		Concatenated,

		/// <summary>
		/// A contiguous block of memory containing an array of pointers to strings followed by a NULL pointer and then followed by the
		/// actual strings.
		/// </summary>
		Packed
	}

	/// <summary>Interface to capture unmanaged memory methods.</summary>
	public interface IMemoryMethods : ISimpleMemoryMethods
	{
		/// <summary>Gets the Ansi <see cref="SecureString"/> allocation method.</summary>
		Func<SecureString, IntPtr> AllocSecureStringAnsi { get; }

		/// <summary>Gets the Unicode <see cref="SecureString"/> allocation method.</summary>
		Func<SecureString, IntPtr> AllocSecureStringUni { get; }

		/// <summary>Gets the Ansi string allocation method.</summary>
		Func<string, IntPtr> AllocStringAnsi { get; }

		/// <summary>Gets the Unicode string allocation method.</summary>
		Func<string, IntPtr> AllocStringUni { get; }

		/// <summary>Gets the Ansi <see cref="SecureString"/> free method.</summary>
		Action<IntPtr> FreeSecureStringAnsi { get; }

		/// <summary>Gets the Unicode <see cref="SecureString"/> free method.</summary>
		Action<IntPtr> FreeSecureStringUni { get; }

		/// <summary>Gets the reallocation method.</summary>
		Func<IntPtr, int, IntPtr> ReAllocMem { get; }
	}

	/// <summary>Interface for classes that support safe memory pointers.</summary>
	public interface ISafeMemoryHandle : IDisposable
	{
		/// <summary>Gets a value indicating whether the handle value is invalid.</summary>
		bool IsInvalid { get; }

		/// <summary>Gets the size of the allocated memory block.</summary>
		/// <value>The size of the allocated memory block.</value>
		SizeT Size { get; set; }

		/// <summary>
		/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
		/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
		/// pointers to other objects
		/// </summary>
		/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
		void AddSubReference(IEnumerable<ISafeMemoryHandle> children);

		/// <summary>Returns the instance as an <see cref="IntPtr"/>. This is a dangerous call as the value is mutable.</summary>
		/// <returns>An <see cref="IntPtr"/> to the internally held memory.</returns>
		IntPtr DangerousGetHandle();

		/// <summary>
		/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
		/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
		/// </summary>
		/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
		/// <param name="count">The number of structures to retrieve.</param>
		/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
		/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
		T[] ToArray<T>(int count, int prefixBytes = 0);

		/// <summary>
		/// Extracts an enumeration of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note
		/// type="note">This call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
		/// </summary>
		/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
		/// <param name="count">The number of structures to retrieve.</param>
		/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
		/// <returns>An enumeration of structures of <typeparamref name="T"/>.</returns>
		IEnumerable<T> ToEnumerable<T>(int count, int prefixBytes = 0);

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <param name="len">The length.</param>
		/// <param name="charSet">The character set of the string.</param>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		string ToString(int len, CharSet charSet = CharSet.Unicode);

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <param name="len">The length.</param>
		/// <param name="prefixBytes">Number of bytes preceding the string pointer.</param>
		/// <param name="charSet">The character set of the string.</param>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		string ToString(int len, int prefixBytes, CharSet charSet = CharSet.Unicode);

		/// <summary>
		/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character
		/// and is terminated by two '\0' characters.
		/// </summary>
		/// <param name="charSet">The character set of the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
		/// <returns>Enumeration of strings.</returns>
		IEnumerable<string> ToStringEnum(CharSet charSet = CharSet.Auto, int prefixBytes = 0);

		/// <summary>
		/// Returns an enumeration of strings from memory where each string is pointed to by a preceding list of pointers of length
		/// <paramref name="count"/>.
		/// </summary>
		/// <param name="count">The count.</param>
		/// <param name="charSet">The character set of the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
		/// <returns>An enumerated list of strings.</returns>
		IEnumerable<string> ToStringEnum(int count, CharSet charSet = CharSet.Auto, int prefixBytes = 0);

		/// <summary>
		/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <param name="prefixBytes">Number of bytes preceding the structure.</param>
		/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
		T ToStructure<T>(int prefixBytes = 0);
	}

	/// <summary>Interface to capture unmanaged simple (alloc/free) memory methods.</summary>
	public interface ISimpleMemoryMethods
	{
		/// <summary>Gets the allocation method.</summary>
		Func<int, IntPtr> AllocMem { get; }

		/// <summary>Gets the free method.</summary>
		Action<IntPtr> FreeMem { get; }
	}

	/// <summary>Implementation of <see cref="IMemoryMethods"/> using just the methods from <see cref="ISimpleMemoryMethods"/>.</summary>
	/// <typeparam name="TSimple">The type of the simple.</typeparam>
	/// <seealso cref="Vanara.InteropServices.IMemoryMethods"/>
	public class MemoryMethodsFromSimple<TSimple> : IMemoryMethods where TSimple : ISimpleMemoryMethods, new()
	{
		/// <summary>A static instance of TSimple.</summary>
		public static TSimple SimpleInstance = new TSimple();

		/// <summary>Gets the Ansi <see cref="SecureString"/> allocation method.</summary>
		public Func<SecureString, IntPtr> AllocSecureStringAnsi => s => StringHelper.AllocSecureString(s, CharSet.Ansi, AllocMem);

		/// <summary>Gets the Unicode <see cref="SecureString"/> allocation method.</summary>
		public Func<SecureString, IntPtr> AllocSecureStringUni => s => StringHelper.AllocSecureString(s, CharSet.Unicode, AllocMem);

		/// <summary>Gets the Ansi string allocation method.</summary>
		public Func<string, IntPtr> AllocStringAnsi => s => StringHelper.AllocString(s, CharSet.Ansi, AllocMem);

		/// <summary>Gets the Unicode string allocation method.</summary>
		public Func<string, IntPtr> AllocStringUni => s => StringHelper.AllocString(s, CharSet.Unicode, AllocMem);

		/// <summary>Gets the Ansi <see cref="SecureString"/> free method.</summary>
		public Action<IntPtr> FreeSecureStringAnsi => FreeMem;

		/// <summary>Gets the Unicode <see cref="SecureString"/> free method.</summary>
		public Action<IntPtr> FreeSecureStringUni => FreeMem;

		/// <summary>Gets the reallocation method.</summary>
		/// <exception cref="System.NotImplementedException"></exception>
		public Func<IntPtr, int, IntPtr> ReAllocMem => throw new NotImplementedException();

		/// <summary>Gets the allocation method.</summary>
		public Func<int, IntPtr> AllocMem => SimpleInstance.AllocMem;

		/// <summary>Gets the free method.</summary>
		public Action<IntPtr> FreeMem => SimpleInstance.FreeMem;
	}

	/// <summary>Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory.</summary>
	/// <seealso cref="System.Runtime.InteropServices.SafeHandle"/>
	public abstract class SafeAllocatedMemoryHandle : SafeHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeAllocatedMemoryHandle"/> class.</summary>
		/// <param name="handle">The handle.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		protected SafeAllocatedMemoryHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle) => SetHandle(handle);

		/// <summary>Dumps memory to byte string.</summary>
		[ExcludeFromCodeCoverage]
		public string Dump => Size == 0 ? "" : string.Join(" ", GetBytes(0, Size).Select(b => b.ToString("X2")).ToArray());

		/// <summary>Gets or sets the size in bytes of the allocated memory block.</summary>
		/// <value>The size in bytes of the allocated memory block.</value>
		public abstract SizeT Size { get; set; }

#if DEBUG
#endif

		/// <summary>Performs an explicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="byte"/> pointer.</summary>
		/// <param name="hMem">The <see cref="SafeAllocatedMemoryHandle"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static unsafe explicit operator byte*(SafeAllocatedMemoryHandle hMem) => (byte*)hMem.handle;

		/// <summary>Performs an explicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="SafeBuffer"/>.</summary>
		/// <param name="hMem">The <see cref="SafeAllocatedMemoryHandle"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator SafeBuffer(SafeAllocatedMemoryHandle hMem) => new SafeBufferImpl(hMem);

		/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="hMem">The <see cref="SafeAllocatedMemoryHandle"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(SafeAllocatedMemoryHandle hMem) => hMem.handle;

		/// <summary>Fills the allocated memory with a specific byte value.</summary>
		/// <param name="value">The byte value.</param>
		public virtual void Fill(byte value) => Fill(value, Size);

		/// <summary>Fills the allocated memory with a specific byte value.</summary>
		/// <param name="value">The byte value.</param>
		/// <param name="length">The number of bytes in the block of memory to be filled.</param>
		public virtual void Fill(byte value, int length)
		{
			if (length > Size) throw new ArgumentOutOfRangeException(nameof(length));
			handle.FillMemory(value, length);
		}

		/// <summary>Releases the owned handle without releasing the allocated memory and returns a pointer to the current memory.</summary>
		/// <returns>A pointer to the currently allocated memory. The caller now has the responsibility to free this memory.</returns>
		public virtual IntPtr TakeOwnership()
		{
			var h = handle;
			SetHandleAsInvalid();
			handle = IntPtr.Zero;
			Size = 0;
			return h;
		}

		/// <summary>Zero out all allocated memory.</summary>
		public virtual void Zero() => Fill(0, Size);

		/// <summary>Gets a copy of bytes from the allocated memory block.</summary>
		/// <param name="startIndex">The start index.</param>
		/// <param name="count">The number of bytes to retrieve.</param>
		/// <returns>A byte array with the copied bytes.</returns>
		protected byte[] GetBytes(int startIndex, int count)
		{
			if (startIndex < 0 || startIndex + count > Size) throw new ArgumentOutOfRangeException();
			var ret = new byte[count];
			Marshal.Copy(handle.Offset(startIndex), ret, 0, count);
			return ret;
		}

		private class SafeBufferImpl : SafeBuffer
		{
			public SafeBufferImpl(SafeAllocatedMemoryHandle hMem) : base(false) => Initialize((ulong)hMem.Size);

			protected override bool ReleaseHandle() => true;
		}
	}

	/// <summary>Abstract base class for all SafeAllocatedMemoryHandle derivatives that apply a specific memory handling routine set.</summary>
	/// <typeparam name="TMem">The <see cref="IMemoryMethods"/> implementation.</typeparam>
	public abstract class SafeMemoryHandle<TMem> : SafeAllocatedMemoryHandle where TMem : IMemoryMethods, new()
	{
		/// <summary>The <see cref="IMemoryMethods"/> implementation instance.</summary>
		protected static readonly TMem mm = new TMem();

		/// <summary>The number of bytes currently allocated.</summary>
		protected SizeT sz;

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		protected SafeMemoryHandle(SizeT size = default) : base(IntPtr.Zero, true)
		{
			if (size == 0) return;
			InitFromSize(size);
			Zero();
		}

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="handle">The handle.</param>
		/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		protected SafeMemoryHandle(IntPtr handle, SizeT size, bool ownsHandle) : base(handle, ownsHandle) => sz = size;

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
		protected SafeMemoryHandle(byte[] bytes) : base(IntPtr.Zero, true)
		{
			if ((bytes?.Length ?? 0) == 0) return;
			InitFromSize(bytes.Length);
			Marshal.Copy(bytes, 0, handle, bytes.Length);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeMemoryHandle{TMem}"/> class from a <see cref="SafeAllocatedMemoryHandle"/>
		/// instance, copying all the memory.
		/// </summary>
		/// <param name="source">The source memory block.</param>
		protected SafeMemoryHandle(SafeAllocatedMemoryHandle source) : base(IntPtr.Zero, true)
		{
			if (source is null) return;
			InitFromSize(source.Size);
			((IntPtr)source).CopyTo(handle, source.Size);
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the handle value is invalid.</summary>
		public override bool IsInvalid => handle == IntPtr.Zero;

		/// <summary>Gets or sets the size in bytes of the allocated memory block.</summary>
		/// <value>The size in bytes of the allocated memory block.</value>
		public override SizeT Size
		{
			get => sz;
			set
			{
				if (value == 0)
				{
					ReleaseHandle();
				}
				else
				{
					RuntimeHelpers.PrepareConstrainedRegions();
					handle = IsInvalid ? mm.AllocMem(value) : mm.ReAllocMem(handle, value);
					if (value > sz)
						handle.Offset(sz).FillMemory(0, value - sz);
					sz = value;
				}
			}
		}

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it
		/// generates a releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			mm.FreeMem(handle);
			sz = 0;
			handle = IntPtr.Zero;
			return true;
		}

		private void InitFromSize(SizeT size)
		{
			RuntimeHelpers.PrepareConstrainedRegions();
			SetHandle(mm.AllocMem(sz = size));
		}
	}

	/// <summary>A <see cref="SafeHandle"/> for memory allocated via COM.</summary>
	/// <seealso cref="System.Runtime.InteropServices.SafeHandle"/>
	public abstract class SafeMemoryHandleExt<TMem> : SafeMemoryHandle<TMem>, ISafeMemoryHandle where TMem : IMemoryMethods, new()
	{
		/// <summary>
		/// Maintains reference to other SafeMemoryHandleExt objects, the pointer to which are referred to by this object. This is to ensure
		/// that such objects being referred to wouldn't be unreferenced until this object is active.
		/// </summary>
		private List<ISafeMemoryHandle> references;

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandleExt{T}"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		protected SafeMemoryHandleExt(SizeT size) : base(size) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandleExt{T}"/> class.</summary>
		/// <param name="handle">The handle.</param>
		/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		protected SafeMemoryHandleExt(IntPtr handle, SizeT size, bool ownsHandle) : base(handle, size, ownsHandle) { }

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
		protected SafeMemoryHandleExt(byte[] bytes) : base(bytes) { }

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="values">Array of unmanaged pointers</param>
		/// <returns>SafeMemoryHandleExt object to an native (unmanaged) array of pointers</returns>
		protected SafeMemoryHandleExt(IntPtr[] values) : this(IntPtr.Size * values.Length) => Marshal.Copy(values, 0, handle, values.Length);

		/// <summary>Allocates from unmanaged memory to represent a Unicode string (WSTR) and marshal this to a native PWSTR.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charSet">The character set of the string.</param>
		/// <returns>SafeMemoryHandleExt object to an native (unmanaged) string</returns>
		protected SafeMemoryHandleExt(string s, CharSet charSet = CharSet.Unicode) : base(IntPtr.Zero, s.GetByteCount(true, charSet), true)
		{
			RuntimeHelpers.PrepareConstrainedRegions();
			SetHandle(StringHelper.GetCharSize(charSet) == 2 ? mm.AllocStringUni(s) : mm.AllocStringAnsi(s));
		}

		/// <summary>
		/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
		/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
		/// pointers to other objects
		/// </summary>
		/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
		public void AddSubReference(IEnumerable<ISafeMemoryHandle> children)
		{
			if (references == null)
				references = new List<ISafeMemoryHandle>();
			references.AddRange(children);
		}

		/// <summary>
		/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
		/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
		/// </summary>
		/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
		/// <param name="count">The number of structures to retrieve.</param>
		/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
		/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
		public T[] ToArray<T>(int count, int prefixBytes = 0)
		{
			if (IsInvalid) return null;
			//if (Size < Marshal.SizeOf(typeof(T)) * count + prefixBytes)
			//	throw new InsufficientMemoryException("Requested array is larger than the memory allocated.");
			//if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
			Debug.Assert(typeof(T).StructLayoutAttribute?.Value == LayoutKind.Sequential);
			return handle.ToArray<T>(count, prefixBytes, sz);
		}

		/// <summary>
		/// Extracts an enumeration of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note
		/// type="note">This call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
		/// </summary>
		/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
		/// <param name="count">The number of structures to retrieve.</param>
		/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
		/// <returns>An enumeration of structures of <typeparamref name="T"/>.</returns>
		public IEnumerable<T> ToEnumerable<T>(int count, int prefixBytes = 0)
		{
			if (IsInvalid) return new T[0];
			//if (Size < Marshal.SizeOf(typeof(T)) * count + prefixBytes)
			//	throw new InsufficientMemoryException("Requested array is larger than the memory allocated.");
			//if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
			Debug.Assert(typeof(T).StructLayoutAttribute?.Value == LayoutKind.Sequential);
			return handle.ToIEnum<T>(count, prefixBytes, sz);
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <param name="len">The length.</param>
		/// <param name="charSet">The character set of the string.</param>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public string ToString(int len, CharSet charSet = CharSet.Unicode) => ToString(len, 0, charSet);

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <param name="len">The length.</param>
		/// <param name="prefixBytes">Number of bytes preceding the string pointer.</param>
		/// <param name="charSet">The character set of the string.</param>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public string ToString(int len, int prefixBytes, CharSet charSet = CharSet.Unicode)
		{
			var str = StringHelper.GetString(handle.Offset(prefixBytes), charSet, sz - prefixBytes);
			return len == -1 ? str : str.Substring(0, len);
		}

		/// <summary>
		/// Returns an enumeration of strings from memory where each string is pointed to by a preceding list of pointers of length
		/// <paramref name="count"/>.
		/// </summary>
		/// <param name="count">The count of expected strings.</param>
		/// <param name="charSet">The character set of the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
		/// <returns>Enumeration of strings.</returns>
		public IEnumerable<string> ToStringEnum(int count, CharSet charSet = CharSet.Auto, int prefixBytes = 0) => IsInvalid ? new string[0] : handle.ToStringEnum(count, charSet, prefixBytes, sz);

		/// <summary>
		/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character
		/// and is terminated by two '\0' characters.
		/// </summary>
		/// <param name="charSet">The character set of the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
		/// <returns>An enumerated list of strings.</returns>
		public IEnumerable<string> ToStringEnum(CharSet charSet = CharSet.Auto, int prefixBytes = 0) => IsInvalid ? new string[0] : handle.ToStringEnum(charSet, prefixBytes, sz);

		/// <summary>
		/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <param name="prefixBytes">Number of bytes preceding the structure.</param>
		/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
		public T ToStructure<T>(int prefixBytes = 0)
		{
			if (IsInvalid) return default;
			return handle.ToStructure<T>(sz, prefixBytes);
		}

		/// <summary>Marshals data from a managed list of specified type to an offset within this allocated memory.</summary>
		/// <typeparam name="T">
		/// A type of the enumerated managed object that holds the data to be marshaled. The object must be a structure or an instance of a
		/// formatted class.
		/// </typeparam>
		/// <param name="items">The enumerated list of items to marshal.</param>
		/// <param name="autoExtend">
		/// if set to <c>true</c> automatically extend the allocated memory to the size required to hold <paramref name="items"/>.
		/// </param>
		/// <param name="offset">The number of bytes to skip before writing the first element of <paramref name="items"/>.</param>
		public void Write<T>(IEnumerable<T> items, bool autoExtend = true, int offset = 0)
		{
			if (IsInvalid) throw new MemberAccessException("Safe memory pointer is not valid.");
			if (autoExtend)
			{
				var count = items?.Count() ?? 0;
				if (count == 0) return;
				InteropExtensions.TrueType(typeof(T), out var iSz);
				var reqSz = iSz * count + offset;
				if (sz < reqSz)
					Size = reqSz;
			}
			handle.Write(items, offset, sz);
		}

		/// <summary>Writes the specified value to an offset within this allocated memory.</summary>
		/// <typeparam name="T">The type of the value to write.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <param name="autoExtend">
		/// if set to <c>true</c> automatically extend the allocated memory to the size required to hold <paramref name="value"/>.
		/// </param>
		/// <param name="offset">The number of bytes to offset from the beginning of this allocated memory before writing.</param>
		public void Write<T>(in T value, bool autoExtend = true, int offset = 0) where T : struct
		{
			if (IsInvalid) throw new MemberAccessException("Safe memory pointer is not valid.");
			if (autoExtend)
			{
				InteropExtensions.TrueType(typeof(T), out var iSz);
				var reqSz = iSz + offset;
				if (sz < reqSz)
					Size = reqSz;
			}
			handle.Write(value, offset, sz);
		}

		/// <summary>Writes the specified value to an offset within this allocated memory.</summary>
		/// <param name="value">The value to write.</param>
		/// <param name="autoExtend">
		/// if set to <c>true</c> automatically extend the allocated memory to the size required to hold <paramref name="value"/>.
		/// </param>
		/// <param name="offset">The number of bytes to offset from the beginning of this allocated memory before writing.</param>
		public void Write(object value, bool autoExtend = true, int offset = 0)
		{
			if (IsInvalid) throw new MemberAccessException("Safe memory pointer is not valid.");
			if (value is null) return;
			if (autoExtend)
			{
				InteropExtensions.TrueType(value.GetType(), out var iSz);
				var reqSz = iSz + offset;
				if (sz < reqSz)
					Size = reqSz;
			}
			handle.Write(value, offset, sz);
		}

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it
		/// generates a releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			var released = base.ReleaseHandle();
			handle = IntPtr.Zero;
			return released;
		}
	}
}