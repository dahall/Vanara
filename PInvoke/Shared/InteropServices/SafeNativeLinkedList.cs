using System;
using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions;
using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>A safe unmanaged linked list of structures allocated on the global heap.</summary>
/// <typeparam name="TElem">The type of the list elements.</typeparam>
/// <typeparam name="TMem">The type of memory allocation to use.</typeparam>
public class SafeNativeLinkedList<TElem, TMem> : SafeNativeListBase<TElem, TMem> where TElem : struct where TMem : IMemoryMethods, new()
{
	/// <summary>Initializes a new instance of the <see cref="SafeNativeLinkedList{TElem, TMem}"/> class.</summary>
	/// <param name="ptr">The handle.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	/// <param name="getNextMethod">The method to use to get the next item in the list.</param>
	public SafeNativeLinkedList(IntPtr ptr, SizeT size, bool ownsHandle, Func<TElem, IntPtr> getNextMethod) : base(ptr, size, ownsHandle) => GetNextMethod = getNextMethod;

	/// <summary>Initializes a new instance of the <see cref="SafeNativeLinkedList{TElem, TMem}"/> class.</summary>
	/// <param name="byteCount">The number of bytes to allocate for this new array.</param>
	/// <param name="getNextMethod">The method to use to get the next item in the list.</param>
	public SafeNativeLinkedList(SizeT byteCount, Func<TElem, IntPtr> getNextMethod) : base(byteCount) => GetNextMethod = getNextMethod;

	/// <summary>Initializes a new instance of the <see cref="SafeNativeLinkedList{TElem, TMem}"/> class.</summary>
	/// <param name="ptr">The handle.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	public SafeNativeLinkedList(IntPtr ptr, SizeT size, bool ownsHandle) : base(ptr, size, ownsHandle) { }

	/// <summary>Initializes a new instance of the <see cref="SafeNativeLinkedList{TElem, TMem}"/> class.</summary>
	/// <param name="byteCount">The number of bytes to allocate for this new array.</param>
	public SafeNativeLinkedList(SizeT byteCount) : base(byteCount) { }

	/// <summary>Gets or sets the method to use to get the next item in the list.</summary>
	/// <value>The method to get the next value. It should return <see cref="IntPtr.Zero"/> if there are no more items.</value>
	public Func<TElem, IntPtr>? GetNextMethod { get; set; }

	/// <summary>Gets or sets the method to use to get the next item in the list.</summary>
	/// <value>The method to get the next value. It should return <see cref="IntPtr.Zero"/> if there are no more items.</value>
	public Func<TElem, long>? GetNextSizeMethod { get; set; }

	/// <summary>Enumerates the elements.</summary>
	/// <returns>An enumeration of values from the pointer.</returns>
	protected override IEnumerable<TElem> Items => GetNextMethod != null ? handle.LinkedListToIEnum(GetNextMethod) : (GetNextSizeMethod != null ? handle.LinkedListToIEnum(GetNextSizeMethod, Size) : Enumerable.Empty<TElem>());

	/*
	/// <summary>
	/// Gets the pointers to the items in the linked list. This is useful when marshaling those values may invalidate internal pointers.
	/// </summary>
	/// <returns>An array of pointers to the items.</returns>
	public unsafe TElem*[] GetUnsafeItems()
	{
		var ret = new List<IntPtr>();
		for (byte* pCurrent = (byte*)handle, pEnd = pCurrent + Size; pCurrent < pEnd && pCurrent != null;)
		{
			ret.Add((IntPtr)pCurrent);
			pCurrent = GetNextMethod != null ? (byte*)GetNextMethod(*(TElem*)pCurrent) : (GetNextSizeMethod != null ? pCurrent + GetNextSizeMethod(*(TElem*)pCurrent) : null);
		}

		var arr = new TElem*[ret.Count];
		for (int i = 0; i < ret.Count; i++)
			arr[i] = (TElem*)ret[i];
		return arr;
	}
	*/
}