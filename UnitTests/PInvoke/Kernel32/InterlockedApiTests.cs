using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class InterlockedApiTests
{
	[StructLayout(LayoutKind.Sequential, Size = 32)]
	private struct PROGRAM_ITEM
	{
		public SLIST_ENTRY ItemEntry;
		public uint Signature;
	}

	[Test]
	public unsafe void InterlockedTest()
	{
		const uint max = 10;

		// Initialize the list header to a MEMORY_ALLOCATION_ALIGNMENT boundary.
		InitializeSListHead(out SLIST_HEADER listHead);

		// Insert 10 items into the list.
		for (uint Count = 1U; Count <= max; Count += 1)
		{
			IntPtr pProgramItem = new PROGRAM_ITEM { Signature = Count }.MarshalToPtr(Marshal.AllocHGlobal, out _);
			InterlockedPushEntrySList(listHead, pProgramItem);
		}

		Assert.That(QueryDepthSList(listHead), Is.EqualTo(max));

		// Remove 10 items from the list and display the signature.
		for (uint Count = max; Count >= 1; Count -= 1)
		{
			IntPtr pListEntry = InterlockedPopEntrySList(listHead);

			PROGRAM_ITEM? programItem = pListEntry.ToNullableStructure<PROGRAM_ITEM>();
			if (!programItem.HasValue)
				Assert.Fail("NULL from InterlockedPopEntrySList");
			Assert.That(Count, Is.EqualTo(programItem.Value.Signature));

			Marshal.FreeHGlobal(pListEntry);
		}

		// Flush the list and verify that the items are gone.
		Assert.That(InterlockedFlushSList(listHead), Is.EqualTo(IntPtr.Zero));
		Assert.That(InterlockedPopEntrySList(listHead), Is.EqualTo(IntPtr.Zero));
	}

	[Test]
	public unsafe void InterlockedTest2()
	{
		const uint max = 10;

		// Initialize the list header to a MEMORY_ALLOCATION_ALIGNMENT boundary.
		InitializeSListHead(out SLIST_HEADER listHead);

		// Create 10 item list in memory.
		IntPtr[] items = new IntPtr[max];
		for (uint Count = 0U; Count < max; Count += 1)
		{
			items[Count] = new PROGRAM_ITEM { ItemEntry = new SLIST_ENTRY { Next = Count == 0 ? IntPtr.Zero : items[Count - 1] }, Signature = Count + 1 }.MarshalToPtr(Marshal.AllocHGlobal, out _);
		}

		// Add list and check
		Assert.That(InterlockedPushListSListEx(listHead, items[0], items[max - 1], max), Is.EqualTo(IntPtr.Zero));
		Assert.That(QueryDepthSList(listHead), Is.EqualTo(max));

		// Flush the list and verify that the items are gone.
		Assert.That(InterlockedFlushSList(listHead), Is.EqualTo(items[0]));
		Assert.That(InterlockedPopEntrySList(listHead), Is.EqualTo(IntPtr.Zero));

		// Free items
		for (uint Count = 0U; Count < max; Count += 1)
			Marshal.FreeHGlobal(items[Count]);
	}
}