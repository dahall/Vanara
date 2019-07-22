using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinBaseTests
	{
		[Test]
		public void BackupImportTest()
		{
			// No tape drives to test against, so just checking each method runs.
			Assert.That(() =>
			{
				BackupRead(HFILE.NULL, default, 0, out _, false, false, out var ctx);
				BackupSeek(HFILE.NULL, 0, 0, out _, out _, ref ctx);
				BackupWrite(HFILE.NULL, default, 0, out _, false, false, out ctx);
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
	}
}