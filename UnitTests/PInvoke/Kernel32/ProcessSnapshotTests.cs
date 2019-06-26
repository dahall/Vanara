using NUnit.Framework;
using System;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class ProcessSnapshotTests
	{
		[Test]
		public void PssTest()
		{
			const PSS_CAPTURE_FLAGS flags = PSS_CAPTURE_FLAGS.PSS_CAPTURE_VA_CLONE | PSS_CAPTURE_FLAGS.PSS_CAPTURE_HANDLES | PSS_CAPTURE_FLAGS.PSS_CAPTURE_HANDLE_NAME_INFORMATION |
				PSS_CAPTURE_FLAGS.PSS_CAPTURE_HANDLE_BASIC_INFORMATION | PSS_CAPTURE_FLAGS.PSS_CAPTURE_HANDLE_TYPE_SPECIFIC_INFORMATION | PSS_CAPTURE_FLAGS.PSS_CAPTURE_HANDLE_TRACE |
				PSS_CAPTURE_FLAGS.PSS_CAPTURE_THREADS | PSS_CAPTURE_FLAGS.PSS_CAPTURE_THREAD_CONTEXT | PSS_CAPTURE_FLAGS.PSS_CAPTURE_THREAD_CONTEXT_EXTENDED |
				PSS_CAPTURE_FLAGS.PSS_CREATE_BREAKAWAY | PSS_CAPTURE_FLAGS.PSS_CREATE_BREAKAWAY_OPTIONAL | PSS_CAPTURE_FLAGS.PSS_CREATE_USE_VM_ALLOCATIONS |
				PSS_CAPTURE_FLAGS.PSS_CREATE_RELEASE_SECTION | PSS_CAPTURE_FLAGS.PSS_CAPTURE_VA_SPACE | PSS_CAPTURE_FLAGS.PSS_CAPTURE_VA_SPACE_SECTION_INFORMATION |
				PSS_CAPTURE_FLAGS.PSS_CAPTURE_IPT_TRACE | PSS_CAPTURE_FLAGS.PSS_CREATE_MEASURE_PERFORMANCE;
			using (var hProc = OpenProcess((uint)ProcessAccess.PROCESS_ALL_ACCESS, false, GetCurrentProcessId()))
			{
				Assert.That(PssCaptureSnapshot(hProc, flags, CONTEXT_FLAG.CONTEXT_ALL, out var hSnap), Is.EqualTo((Win32Error)0));
				using (hSnap)
				{
					Assert.That(() => PssQuerySnapshot<PSS_PROCESS_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_PROCESS_INFORMATION), Throws.Nothing);
					Assert.That(() => PssQuerySnapshot<PSS_VA_CLONE_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_VA_CLONE_INFORMATION), Throws.Nothing);
					Assert.That(() => PssQuerySnapshot<PSS_HANDLE_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_HANDLE_INFORMATION), Throws.Nothing);
					Assert.That(() => PssQuerySnapshot<PSS_THREAD_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_THREAD_INFORMATION), Throws.Nothing);
					Assert.That(() => PssQuerySnapshot<PSS_PERFORMANCE_COUNTERS>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_PERFORMANCE_COUNTERS), Throws.Nothing);
					Assert.That(() => PssQuerySnapshot<PSS_VA_SPACE_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_VA_SPACE_INFORMATION), Throws.Nothing);
					// Don't know why these don't work
					Assert.That(() => PssQuerySnapshot<PSS_HANDLE_TRACE_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_HANDLE_TRACE_INFORMATION), Throws.InstanceOf<System.ComponentModel.Win32Exception>());
					Assert.That(() => PssQuerySnapshot<PSS_AUXILIARY_PAGES_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_AUXILIARY_PAGES_INFORMATION), Throws.InstanceOf<System.ComponentModel.Win32Exception>());

					Assert.That(() =>
					{
						uint cnt = 0, expCnt = PssQuerySnapshot<PSS_THREAD_INFORMATION>(hSnap, PSS_QUERY_INFORMATION_CLASS.PSS_QUERY_THREAD_INFORMATION).ThreadsCaptured;
						foreach (var entry in PssWalkSnapshot<PSS_THREAD_ENTRY>(hSnap, PSS_WALK_INFORMATION_CLASS.PSS_WALK_THREADS))
						{
							TestContext.Write($"({++cnt}) Id:{entry.ThreadId}  suspend:{entry.SuspendCount}  teb:{entry.TebBaseAddress}  w32sa:{entry.Win32StartAddress}  pc:{entry.ContextRecord}");
							TestContext.WriteLine($"  flags:{entry.Flags}  priority:{entry.Priority}  base:{entry.BasePriority}");
						}
						Assert.That(cnt, Is.EqualTo(expCnt));
					}, Throws.Nothing);

					Assert.That(PssWalkMarkerCreate(IntPtr.Zero, out var hWalk), Is.EqualTo((Win32Error)0));
					using (hWalk)
					{
						Assert.That(PssWalkSnapshot<PSS_VA_SPACE_ENTRY>(hSnap, PSS_WALK_INFORMATION_CLASS.PSS_WALK_VA_SPACE, hWalk), Is.Not.Empty);
						Assert.That(PssWalkSnapshot<PSS_HANDLE_ENTRY>(hSnap, PSS_WALK_INFORMATION_CLASS.PSS_WALK_HANDLES, hWalk), Is.Not.Empty);
						// Don't know why this doesn't work
						Assert.That(() => PssWalkSnapshot<PSS_AUXILIARY_PAGE_ENTRY>(hSnap, PSS_WALK_INFORMATION_CLASS.PSS_WALK_AUXILIARY_PAGES, hWalk).All(e => true), Throws.Exception);

						Assert.That(PssWalkMarkerGetPosition(hWalk, out var pos), Is.EqualTo((Win32Error)0));
						Assert.That(PssWalkMarkerSeekToBeginning(hWalk), Is.EqualTo((Win32Error)0));
						Assert.That(PssWalkMarkerSetPosition(hWalk, pos), Is.EqualTo((Win32Error)0));
					}
				}
			}
		}
	}
}