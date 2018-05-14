using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Initializes the head of a singly linked list.</summary>
		/// <param name="ListHead">
		/// A pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list. This structure is for system use only.
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI InitializeSListHead( _Inout_ PSLIST_HEADER ListHead); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683482(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683482")]
		public static extern void InitializeSListHead(IntPtr ListHead);

		/// <summary>Removes all items from a singly linked list. Access to the list is synchronized on a multiprocessor system.</summary>
		/// <param name="ListHead">
		/// Pointer to an <c>SLIST_HEADER</c> structure that represents the head of the singly linked list. This structure is for system use only.
		/// </param>
		/// <returns>The return value is a pointer to the items removed from the list. If the list is empty, the return value is <c>NULL</c>.</returns>
		// PSLIST_ENTRY WINAPI InterlockedFlushSList( _Inout_ PSLIST_HEADER ListHead); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683612(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683612")]
		public static extern IntPtr InterlockedFlushSList(IntPtr ListHead);

		/// <summary>Removes an item from the front of a singly linked list. Access to the list is synchronized on a multiprocessor system.</summary>
		/// <param name="ListHead">Pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list.</param>
		/// <returns>The return value is a pointer to the item removed from the list. If the list is empty, the return value is <c>NULL</c>.</returns>
		// PSLIST_ENTRY WINAPI InterlockedPopEntrySList( _Inout_ PSLIST_HEADER ListHead); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683648(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683648")]
		public static extern IntPtr InterlockedPopEntrySList(IntPtr ListHead);

		/// <summary>Inserts an item at the front of a singly linked list. Access to the list is synchronized on a multiprocessor system.</summary>
		/// <param name="ListHead">Pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list.</param>
		/// <param name="ListEntry">Pointer to an <c>SLIST_ENTRY</c> structure that represents an item in a singly linked list.</param>
		/// <returns>The return value is the previous first item in the list. If the list was previously empty, the return value is <c>NULL</c>.</returns>
		// PSLIST_ENTRY WINAPI InterlockedPushEntrySList( _Inout_ PSLIST_HEADER ListHead, _Inout_ PSLIST_ENTRY ListEntry); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684020(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684020")]
		public static extern IntPtr InterlockedPushEntrySList(IntPtr ListHead, IntPtr ListEntry);

		/// <summary>
		/// Inserts a singly-linked list at the front of another singly linked list. Access to the lists is synchronized on a multiprocessor system. This version
		/// of the method does not use the __fastcall calling convention.
		/// </summary>
		/// <param name="ListHead">
		/// Pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list. The list specified by the List and ListEnd parameters
		/// is inserted at the front of this list.
		/// </param>
		/// <param name="List">Pointer to an <c>SLIST_ENTRY</c> structure that represents the first item in the list to be inserted.</param>
		/// <param name="ListEnd">Pointer to an <c>SLIST_ENTRY</c> structure that represents the last item in the list to be inserted.</param>
		/// <param name="Count">The number of items in the list to be inserted.</param>
		/// <returns>
		/// The return value is the previous first item in the list specified by the ListHead parameter. If the list was previously empty, the return value is <c>NULL</c>.
		/// </returns>
		// PSLIST_ENTRY WINAPI InterlockedPushListSListEx( _Inout_ PSLIST_HEADER ListHead, _Inout_ PSLIST_ENTRY List, _Inout_ PSLIST_ENTRY ListEnd, _In_ ULONG
		// Count); https://msdn.microsoft.com/en-us/library/windows/desktop/hh972673(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Interlockedapi.h", MSDNShortId = "hh972673")]
		public static extern IntPtr InterlockedPushListSListEx(IntPtr ListHead, IntPtr List, IntPtr ListEnd, uint Count);

		/// <summary>Retrieves the number of entries in the specified singly linked list.</summary>
		/// <param name="ListHead">
		/// <para>A pointer to an <c>SLIST_HEADER</c> structure that represents the head of a singly linked list. This structure is for system use only.</para>
		/// <para>The list must be previously initialized with the <c>InitializeSListHead</c> function.</para>
		/// </param>
		/// <returns>The function returns the number of entries in the list, up to a maximum value of 65535.</returns>
		// USHORT WINAPI QueryDepthSList( _In_ PSLIST_HEADER ListHead);// https://msdn.microsoft.com/en-us/library/windows/desktop/ms684916(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684916")]
		public static extern ushort QueryDepthSList(IntPtr ListHead);

		/*[StructLayout(LayoutKind.Sequential)]
		public struct SLIST_HEADER
		{
			private IntPtr Alignment;
			private IntPtr Next;
		}*/
	}
}