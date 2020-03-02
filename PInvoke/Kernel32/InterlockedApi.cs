using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// <para>Initializes the head of a singly linked list.</para>
		/// </summary>
		/// <param name="ListHead">
		/// <para>
		/// A pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list. This structure is for system use only.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary. Unaligned items can cause unpredictable results.
		/// See <c>_aligned_malloc</c>.
		/// </para>
		/// <para>
		/// To add items to the list, use the InterlockedPushEntrySList function. To remove items from the list, use the
		/// InterlockedPopEntrySList function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Singly Linked Lists.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/interlockedapi/nf-interlockedapi-initializeslisthead void
		// InitializeSListHead( PSLIST_HEADER ListHead );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("interlockedapi.h", MSDNShortId = "4e34f947-1687-4ea9-aaa1-8d8dc11dad70")]
		public static extern void InitializeSListHead(out SLIST_HEADER ListHead);

		/// <summary>
		/// <para>Removes all items from a singly linked list. Access to the list is synchronized on a multiprocessor system.</para>
		/// </summary>
		/// <param name="ListHead">
		/// <para>
		/// Pointer to an <c>SLIST_HEADER</c> structure that represents the head of the singly linked list. This structure is for system use only.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The return value is a pointer to the items removed from the list. If the list is empty, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary; otherwise, this function will behave
		/// unpredictably. See <c>_aligned_malloc</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Singly Linked Lists.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/interlockedapi/nf-interlockedapi-interlockedflushslist PSLIST_ENTRY
		// InterlockedFlushSList( PSLIST_HEADER ListHead );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("interlockedapi.h", MSDNShortId = "3fde3377-8a98-4976-a350-2c173b209e8c")]
		public static extern IntPtr InterlockedFlushSList(in SLIST_HEADER ListHead);

		/// <summary>
		/// <para>Removes an item from the front of a singly linked list. Access to the list is synchronized on a multiprocessor system.</para>
		/// </summary>
		/// <param name="ListHead">
		/// <para>Pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list.</para>
		/// </param>
		/// <returns>
		/// <para>The return value is a pointer to the item removed from the list. If the list is empty, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary; otherwise, this function will behave
		/// unpredictably. See <c>_aligned_malloc</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Singly Linked Lists.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/interlockedapi/nf-interlockedapi-interlockedpopentryslist PSLIST_ENTRY
		// InterlockedPopEntrySList( PSLIST_HEADER ListHead );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("interlockedapi.h", MSDNShortId = "10760fd4-5973-4ab0-991c-7a5951c798a4")]
		public static extern IntPtr InterlockedPopEntrySList(in SLIST_HEADER ListHead);

		/// <summary>
		/// <para>Inserts an item at the front of a singly linked list. Access to the list is synchronized on a multiprocessor system.</para>
		/// </summary>
		/// <param name="ListHead">
		/// <para>Pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list.</para>
		/// </param>
		/// <param name="ListEntry">
		/// <para>Pointer to an SLIST_ENTRY structure that represents an item in a singly linked list.</para>
		/// </param>
		/// <returns>
		/// <para>The return value is the previous first item in the list. If the list was previously empty, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary; otherwise, this function will behave
		/// unpredictably. See <c>_aligned_malloc</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Singly Linked Lists.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/interlockedapi/nf-interlockedapi-interlockedpushentryslist PSLIST_ENTRY
		// InterlockedPushEntrySList( PSLIST_HEADER ListHead, __drv_aliasesMem PSLIST_ENTRY ListEntry );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("interlockedapi.h", MSDNShortId = "60e3b6f7-f556-4699-be90-db7330cfb8ca")]
		public static extern IntPtr InterlockedPushEntrySList(in SLIST_HEADER ListHead, IntPtr ListEntry);

		/// <summary>
		/// Inserts a singly-linked list at the front of another singly linked list. Access to the lists is synchronized on a multiprocessor system.
		/// </summary>
		/// <param name="ListHead">
		/// Pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list. The list specified by the List and
		/// ListEnd parameters is inserted at the front of this list.
		/// </param>
		/// <param name="List">Pointer to an <c>SLIST_ENTRY</c> structure that represents the first item in the list to be inserted.</param>
		/// <param name="ListEnd">Pointer to an <c>SLIST_ENTRY</c> structure that represents the last item in the list to be inserted.</param>
		/// <param name="Count">The number of items in the list to be inserted.</param>
		/// <returns>
		/// The return value is the previous first item in the list specified by the ListHead parameter. If the list was previously empty,
		/// the return value is <c>NULL</c>.
		/// </returns>
		// PSLIST_ENTRY FASTCALL InterlockedPushListSList( _Inout_ PSLIST_HEADER ListHead, _Inout_ PSLIST_ENTRY List, _Inout_ PSLIST_ENTRY
		// ListEnd, _In_ ULONG Count); https://msdn.microsoft.com/en-us/library/windows/desktop/hh448545(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "hh448545")]
		public static extern IntPtr InterlockedPushListSList(in SLIST_HEADER ListHead, IntPtr List, IntPtr ListEnd, uint Count);

		/// <summary>
		/// <para>
		/// Inserts a singly-linked list at the front of another singly linked list. Access to the lists is synchronized on a multiprocessor
		/// system. This version of the method does not use the __fastcall calling convention.
		/// </para>
		/// </summary>
		/// <param name="ListHead">
		/// <para>
		/// Pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list. The list specified by the List and
		/// ListEnd parameters is inserted at the front of this list.
		/// </para>
		/// </param>
		/// <param name="List">
		/// <para>Pointer to an SLIST_ENTRY structure that represents the first item in the list to be inserted.</para>
		/// </param>
		/// <param name="ListEnd">
		/// <para>Pointer to an SLIST_ENTRY structure that represents the last item in the list to be inserted.</para>
		/// </param>
		/// <param name="Count">
		/// <para>The number of items in the list to be inserted.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// The return value is the previous first item in the list specified by the ListHead parameter. If the list was previously empty,
		/// the return value is <c>NULL</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary; otherwise, this function will behave
		/// unpredictably. See <c>_aligned_malloc</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/interlockedapi/nf-interlockedapi-interlockedpushlistslistex PSLIST_ENTRY
		// InterlockedPushListSListEx( PSLIST_HEADER ListHead, PSLIST_ENTRY List, PSLIST_ENTRY ListEnd, ULONG Count );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("interlockedapi.h", MSDNShortId = "f4f334c6-fda8-4c5f-9177-b672c8aed6b3")]
		public static extern IntPtr InterlockedPushListSListEx(in SLIST_HEADER ListHead, IntPtr List, IntPtr ListEnd, uint Count);

		/// <summary>
		/// <para>Retrieves the number of entries in the specified singly linked list.</para>
		/// </summary>
		/// <param name="ListHead">
		/// <para>
		/// A pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list. This structure is for system use only.
		/// </para>
		/// <para>The list must be previously initialized with the InitializeSListHead function.</para>
		/// </param>
		/// <returns>
		/// <para>The function returns the number of entries in the list, up to a maximum value of 65535.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system does not limit the number of entries in a singly linked list. However, the return value of <c>QueryDepthSList</c> is
		/// truncated to 16 bits, so the maximum value it can return is 65535. If the specified singly linked list contains more than 65535
		/// entries, <c>QueryDepthSList</c> returns the number of entries in the list modulo 65535. For example, if the specified list
		/// contains 65536 entries, <c>QueryDepthSList</c> returns zero.
		/// </para>
		/// <para>
		/// The return value of <c>QueryDepthSList</c> should not be relied upon in multithreaded applications because the item count can be
		/// changed at any time by another thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/interlockedapi/nf-interlockedapi-querydepthslist USHORT QueryDepthSList(
		// PSLIST_HEADER ListHead );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("interlockedapi.h", MSDNShortId = "3f9b4481-647f-457f-bdfb-62e6ae4198e5")]
		public static extern ushort QueryDepthSList(in SLIST_HEADER ListHead);

		/// <summary>An <c>SLIST_ENTRY</c> structure describes an entry in a sequenced singly linked list.</summary>
		// typedef struct _SLIST_ENTRY { struct _SLIST_ENTRY *Next;} SLIST_ENTRY, *PSLIST_ENTRY; https://msdn.microsoft.com/en-us/library/windows/hardware/ff563805(v=vs.85).aspx
		[PInvokeData("winnt.h")]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct SLIST_ENTRY
		{
			/// <summary>Pointer to the next entry in the list, or <c>NULL</c> if there is no next entry in the list.</summary>
			public IntPtr Next;

			/// <summary>The next entry in the list, or <see langword="null"/> if there is no next entry in the list.</summary>
			public SLIST_ENTRY? NextEntry => Next.ToNullableStructure<SLIST_ENTRY>();
		}

		/// <summary>
		/// <para>
		/// An <c>SLIST_HEADER</c> structure is an opaque structure that serves as the header for a sequenced singly linked list. For more
		/// information, see Singly and Doubly Linked Lists.
		/// </para>
		/// <para>On 64-bit platforms, <c>SLIST_HEADER</c> structures must be 16-byte aligned.</para>
		/// </summary>
		[PInvokeData("winnt.h")]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct SLIST_HEADER
		{
			/// <summary/>
			public ulong Alignment;
			/// <summary/>
			public ulong Region;
		}
	}
}