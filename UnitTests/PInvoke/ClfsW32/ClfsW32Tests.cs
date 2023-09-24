using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;
using static Vanara.PInvoke.ClfsW32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ClfsW32Tests
{
	const string fnbase = @"C:\Temp\testlog";
	const string fn = @"log:" + fnbase;
	private SafeHLOG hLog;

	[OneTimeSetUp]
	public void _Setup()
	{
		System.IO.File.Delete(fnbase + CLFS_BASELOG_EXTENSION);
		hLog = CreateLogFile(fn, ACCESS_MASK.GENERIC_WRITE | ACCESS_MASK.GENERIC_READ | ACCESS_MASK.DELETE, System.IO.FileShare.Read, null, Kernel32.CreationOption.OPEN_ALWAYS, FileFlagsAndAttributes.FILE_ATTRIBUTE_ARCHIVE | FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED);
		Assert.That(hLog, ResultIs.ValidHandle);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		hLog?.Dispose();
		DeleteLogFile(fn);
	}

	[Test]
	public void Test()
	{
		CLS_SCAN_CONTEXT ctx = default;
		string cName = Guid.NewGuid().ToString("N");
		try
		{
			ThreadPool.BindHandle(hLog);

			Assert.That(AddLogContainer(hLog, 512 * 1024, cName), ResultIs.Successful);

			CLS_INFORMATION info = default;
			uint sz = (uint)Marshal.SizeOf(info);
			Assert.That(GetLogFileInformation(hLog, ref info, ref sz), ResultIs.Successful);
			info.WriteValues();
			Assert.That(info.TotalContainers, Is.GreaterThan(0U));

			Assert.That(CreateLogContainerScanContext(hLog, 0, info.TotalContainers, CLFS_SCAN_MODE.CLFS_SCAN_FORWARD, ref ctx), ResultIs.Successful);
			ctx.WriteValues();

			StringBuilder sb = new((int)ctx.pinfoContainer[0].FileNameActualLength + 1);
			Assert.That(GetLogContainerName(hLog, ctx.pinfoContainer[0].LogicalContainerId, sb, sb.Capacity, out _), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}
		finally
		{
			RemoveLogContainer(hLog, cName, true);
			if (ctx.cContainersReturned > 0)
				Assert.That(ScanLogContainers(ref ctx, CLFS_SCAN_MODE.CLFS_SCAN_CLOSE), ResultIs.Successful);
		}
	}

	[Test]
	public void TestLsn()
	{
		var lsn1 = new CLS_LSN(3, 512, 26);
		var lsn2 = LsnDecrement(lsn1);

		Assert.False(lsn1.IsInvalid);
		Assert.False(lsn1.IsNull);
		Assert.That(lsn2, Is.LessThan(lsn1));
		Assert.That(lsn1, Is.GreaterThan(lsn2));
		Assert.That(lsn1, Is.EqualTo(lsn1));

		Assert.That(lsn1.ContainerId, Is.EqualTo(3));
		Assert.That(lsn1.BlockOffset, Is.EqualTo(512));
		Assert.That(lsn1.RecordSequence, Is.Not.Zero);
	}

	[Test]
	public void GetLogIoStatisticsTest()
	{
		SafeCoTaskMemStruct<CLS_IO_STATISTICS> stats = new();
		Assert.That(GetLogIoStatistics(hLog, stats, stats.Size, CLFS_IOSTATS_CLASS.ClfsIoStatsMax, out var written), ResultIs.Successful);
		stats.Value.WriteValues();
	}

	[Test]
	public void AddLogContainerSetTest()
	{
		string[] names = new[] { Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N") };
		Assert.That(AddLogContainerSet(hLog, (ushort)names.Length, 512 * 1024, names), ResultIs.Successful);
		Assert.That(RemoveLogContainerSet(hLog, (ushort)names.Length, names, true), ResultIs.Successful);
	}

	[Test]
	public void LogArchiveTest()
	{
		StringBuilder sb = new(260);
		Assert.That(PrepareLogArchive(hLog, sb, sb.Capacity, IntPtr.Zero, IntPtr.Zero, out var actLen, out var lfOffset, out var lfLen, out var lsnBase, out var ldsLast, out var lsnTail, out var ctx), ResultIs.Successful);
		TestContext.WriteLine($"{actLen}, {lfOffset}, {lfLen}, {lsnBase}, {ldsLast}, {lsnTail}, {sb}");
		using SafeCoTaskMemHandle mem = new(lfLen);
		Assert.That(ReadLogArchiveMetadata(ctx, 0, mem.Size, mem, out var read), ResultIs.Successful);
		TestContext.WriteLine(mem.GetBytes(0, (int)read).ToHexDumpString());
		Assert.That(read, Is.LessThanOrEqualTo((uint)mem.Size));
		CLS_ARCHIVE_DESCRIPTOR[] descriptor = new CLS_ARCHIVE_DESCRIPTOR[1];
		if (GetNextLogArchiveExtent(ctx, descriptor, descriptor.Length, out var dRet) && dRet > 0)
			descriptor[0].WriteValues();
	}
	
	[Test]
	public void QueryLogPolicyTest([Values] CLFS_MGMT_POLICY_TYPE type)
	{
		CLFS_MGMT_POLICY pol = new(type);
		switch (type)
		{
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyMaximumSize:
				pol.PolicyParameters.MaximumSize.Containers = 16;
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyMinimumSize:
				pol.PolicyParameters.MinimumSize.Containers = 2;
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerSize:
				pol.PolicyParameters.NewContainerSize.SizeInBytes = 512 * 1024;
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyGrowthRate:
				pol.PolicyParameters.GrowthRate.AbsoluteGrowthInContainers = 0;
				pol.PolicyParameters.GrowthRate.RelativeGrowthPercentage = 10;
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyLogTail:
				pol.PolicyParameters.LogTail.MinimumAvailableContainers = 2;
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyAutoShrink:
				pol.PolicyParameters.AutoShrink.Percentage = 25;
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyAutoGrow:
				pol.PolicyParameters.AutoGrow.Enabled = true;
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerPrefix:
				pol.PolicyParameters.NewContainerPrefix.PrefixString = @"C:\Temp\Container";
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerSuffix:
				break;
			case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerExtension:
				pol.PolicyParameters.NewContainerExtension.ExtensionString = @"cnt";
				break;
			default:
				return;
		}
		Assert.That(InstallLogPolicy(hLog, pol), ResultIs.Successful);

		try
		{
			Assert.That(QueryLogPolicy(hLog, type, out var mem), ResultIs.Successful);
			switch (type)
			{
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyMaximumSize:
					mem.PolicyParameters.MaximumSize.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyMinimumSize:
					mem.PolicyParameters.MinimumSize.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerSize:
					mem.PolicyParameters.NewContainerSize.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyGrowthRate:
					mem.PolicyParameters.GrowthRate.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyLogTail:
					mem.PolicyParameters.LogTail.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyAutoShrink:
					mem.PolicyParameters.AutoShrink.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyAutoGrow:
					mem.PolicyParameters.AutoGrow.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerPrefix:
					mem.PolicyParameters.NewContainerPrefix.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerSuffix:
					mem.PolicyParameters.NewContainerSuffix.WriteValues();
					break;
				case CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyNewContainerExtension:
					mem.PolicyParameters.NewContainerExtension.WriteValues();
					break;
				default:
					break;
			}
		}
		finally
		{
			Assert.That(RemoveLogPolicy(hLog, type), ResultIs.Successful);
		}
	}
}