using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests
{
	[Test]
	public void BackupImportTest()
	{
		// No tape drives to test against, so just checking each method runs.
		Assert.That(() =>
		{
			IntPtr ctx = default;
			Kernel32.BackupRead(HFILE.NULL, default, 0, out _, false, false, ref ctx);
			BackupSeek(HFILE.NULL, 0, 0, out _, out _, ref ctx);
			BackupWrite(HFILE.NULL, default, 0, out _, false, false, ref ctx);
			CreateTapePartition(HFILE.NULL, TAPE_PARTITION_METHOD.TAPE_FIXED_PARTITIONS, 1, 1);
			EraseTape(HFILE.NULL, TAPE_ERASE_TYPE.TAPE_ERASE_SHORT, true);
			uint sz = 0;
			GetTapeParameters(HFILE.NULL, TAPE_PARAM_OP.GET_TAPE_DRIVE_INFORMATION, ref sz, default);
			GetTapePosition(HFILE.NULL, TAPE_POS_TYPE.TAPE_ABSOLUTE_POSITION, out _, out _, out _);
			GetTapeStatus(HFILE.NULL);
			PrepareTape(HFILE.NULL, TAPE_PREP_OP.TAPE_LOAD, true);
			SetTapeParameters(HFILE.NULL, TAPE_PARAM_OP.GET_TAPE_DRIVE_INFORMATION, default);
			SetTapePosition(HFILE.NULL, TAPE_POS_METHOD.TAPE_ABSOLUTE_BLOCK, 0, 0, 0, true);
			WriteTapemark(HFILE.NULL, TAPEMARK_TYPE.TAPE_SHORT_FILEMARKS, 1, true);
		}, Throws.Nothing);
	}

	[Test]
	public static void BackupReadTest()
	{
		using var f = CreateFile(TestCaseSources.LogFile, FileAccess.GENERIC_READ, System.IO.FileShare.Read, null, System.IO.FileMode.Open, FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS);

		Assert.That(BackupRead(f, true, false, out var streams), ResultIs.Successful);
		Assert.That(streams, Is.Not.Empty);
		Assert.That(streams, Has.Exactly(1).Matches<(WIN32_STREAM_ID id, SafeAllocatedMemoryHandle? buffer)>(s => s.id.dwStreamId == BACKUP_STREAM_ID.BACKUP_SECURITY_DATA));
		Assert.That(streams.All(s => s.buffer is null));
		TestContext.WriteLine(string.Join("\n", streams.Select(s => $"{s.id.cStreamName} ({s.id.dwStreamId})")));

		Assert.That(BackupRead(f, false, true, out streams), ResultIs.Successful);
		Assert.That(streams, Is.Not.Empty);
		Assert.That(streams, Has.None.Matches<(WIN32_STREAM_ID id, SafeAllocatedMemoryHandle? buffer)>(s => s.id.dwStreamId == BACKUP_STREAM_ID.BACKUP_SECURITY_DATA));
		Assert.That(streams.All(s => s.buffer is not null));
		TestContext.WriteLine(string.Join("\n", streams.Select(s => $"{s.id.cStreamName} ({s.id.dwStreamId}) = {s.buffer!.Size}")));
	}
}