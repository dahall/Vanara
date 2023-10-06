using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.KtmW32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class KtmW32Tests
{
	private const string txnDesc = "MyTransaction";

	[Test]
	public void CommitTransactionAsyncTest()
	{
		using var hTR = CreateTransaction(null, default, 0, 0, 0, 0, txnDesc);
		Assert.That(hTR, ResultIs.ValidHandle);
		Assert.That(CommitTransactionAsync(hTR), ResultIs.Successful);
	}

	[Test]
	public void CommitTransactionTest()
	{
		using var hTR = CreateTransaction(null, default, 0, 0, 0, 0, txnDesc);
		Assert.That(hTR, ResultIs.ValidHandle);
		Assert.That(CommitTransaction(hTR), ResultIs.Successful);
	}

	[Test]
	public unsafe void CreateTMNVTest()
	{
		using var tmp = new TempFile(null);
		using var hTM = CreateTransactionManager(null, tmp.FullName);
		Assert.That(hTM, ResultIs.ValidHandle);

		Assert.That(RenameTransactionManager(tmp.FullName, Guid.NewGuid()), ResultIs.Failure);

		Assert.That(RecoverTransactionManager(hTM), ResultIs.Successful);

		using (var hTM2 = OpenTransactionManager(tmp.FullName, TransactionMgrAccess.TRANSACTIONMANAGER_ALL_ACCESS))
			Assert.That(hTM2, ResultIs.ValidHandle);

		var rmId = Guid.NewGuid();
		using (var hRM = CreateResourceManager(null, rmId, 0, hTM, "MyRM"))
		{
			Assert.That(hRM, ResultIs.ValidHandle);

			Assert.That(RecoverResourceManager(hRM), ResultIs.Successful);

			using (var pTn = new SafeHGlobalHandle(4096))
				Assert.That(GetNotificationResourceManagerAsync(hRM, pTn, pTn.Size, out _, null), ResultIs.Failure);

			using var hRM2 = OpenResourceManager(ResourceManagerAccess.RESOURCEMANAGER_ALL_ACCESS, hTM, rmId);
			Assert.That(hRM2, ResultIs.ValidHandle);
		}

		Assert.That(RollforwardTransactionManager(hTM, 255L), ResultIs.Successful);
	}

	[Test]
	public void CreateTMRMGetInfoTest()
	{
		using var hTM = CreateTransactionManager(CreateOptions: CreateTrxnMgrOptions.TRANSACTION_MANAGER_VOLATILE);
		Assert.That(hTM, ResultIs.ValidHandle);

		Assert.That(GetCurrentClockTransactionManager(hTM, out var clock), ResultIs.Successful);
		TestContext.WriteLine($"TMClock=0x{clock:X}");

		Assert.That(GetTransactionManagerId(hTM, out var tmguid), ResultIs.Successful);
		TestContext.WriteLine($"TMID={tmguid}");

		using (var hTM2 = OpenTransactionManagerById(tmguid, TransactionMgrAccess.TRANSACTIONMANAGER_ALL_ACCESS))
			Assert.That(hTM2, ResultIs.ValidHandle);

		Assert.That(RecoverTransactionManager(hTM), ResultIs.FailureCode(Win32Error.ERROR_TM_VOLATILE));

		using var hRM = CreateResourceManager(null, Guid.Empty, CreateRMOptions.RESOURCE_MANAGER_VOLATILE, hTM, null);
		Assert.That(hRM, ResultIs.ValidHandle);

		using (var pTn = new SafeHGlobalHandle(4096))
			Assert.That(GetNotificationResourceManager(hRM, pTn, pTn.Size, 10, out var req), ResultIs.FailureCode(Win32Error.WAIT_TIMEOUT));

		Assert.That(RecoverResourceManager(hRM), ResultIs.FailureCode(Win32Error.ERROR_TM_VOLATILE));
	}

	[Test]
	public void GetSetTransactionInformationTest()
	{
		using var hTR = CreateTransaction(null, default, 0, 0, 0, 0, txnDesc);
		Assert.That(hTR, ResultIs.ValidHandle);

		Assert.That(GetTransactionId(hTR, out var trguid), ResultIs.Successful);
		TestContext.WriteLine($"TrID={trguid}");

		using (var hTR2 = OpenTransaction(TransactionAccess.TRANSACTION_ALL_ACCESS, trguid))
			Assert.That(hTR2, ResultIs.ValidHandle);

		var sb = new StringBuilder(255);
		Assert.That(GetTransactionInformation(hTR, out var troutcome, default, default, out var trTO, 255, sb), ResultIs.Successful);
		TestContext.WriteLine($"TrInf={troutcome}, {trTO}, {sb}");

		sb.Append('2');
		Assert.That(SetTransactionInformation(hTR, 0, 0, 5000, sb.ToString()), ResultIs.Successful);
	}

	// Despite hours of trying, I cannot successfully create an enlistment nor find working code on the internet. So, I'm punting and
	// just doing non-functional testing for all enlistment functions. -- Sigh --
	[Test]
	public void NonFunctionalTest()
	{
		Assert.That(CommitComplete(HENLISTMENT.NULL), ResultIs.Failure);
		Assert.That(CommitEnlistment(HENLISTMENT.NULL), ResultIs.Failure);
		Assert.That(CreateEnlistment(null, HRESMGR.NULL, HTRXN.NULL, 0).DangerousGetHandle(), Is.EqualTo((IntPtr)HFILE.INVALID_HANDLE_VALUE));
		Assert.That(GetEnlistmentId(HENLISTMENT.NULL, out _), ResultIs.Failure);
		Assert.That(GetEnlistmentRecoveryInformation(HENLISTMENT.NULL, 0, default, out _), ResultIs.Failure);
		Assert.That(OpenEnlistment(EnlistmentAccess.ENLISTMENT_ALL_ACCESS, HRESMGR.NULL, Guid.NewGuid()).DangerousGetHandle(), Is.EqualTo((IntPtr)HFILE.INVALID_HANDLE_VALUE));
		Assert.That(PrepareComplete(HENLISTMENT.NULL), ResultIs.Failure);
		Assert.That(PrepareEnlistment(HENLISTMENT.NULL, 0L), ResultIs.Failure);
		Assert.That(PrePrepareComplete(HENLISTMENT.NULL), ResultIs.Failure);
		Assert.That(PrePrepareEnlistment(HENLISTMENT.NULL, 0L), ResultIs.Failure);
		Assert.That(ReadOnlyEnlistment(HENLISTMENT.NULL), ResultIs.Failure);
		Assert.That(RecoverEnlistment(HENLISTMENT.NULL), ResultIs.Failure);
		Assert.That(RollbackComplete(HENLISTMENT.NULL, 0L), ResultIs.Failure);
		Assert.That(RollbackEnlistment(HENLISTMENT.NULL, 0L), ResultIs.Failure);
		Assert.That(SetEnlistmentRecoveryInformation(HENLISTMENT.NULL, 0, default), ResultIs.Failure);
		Assert.That(SinglePhaseReject(HENLISTMENT.NULL), ResultIs.Failure);
	}

	[Test]
	public void RollbackTransactionAsyncTest()
	{
		using var hTR = CreateTransaction(null, default, 0, 0, 0, 0, txnDesc);
		Assert.That(hTR, ResultIs.ValidHandle);
		Assert.That(RollbackTransactionAsync(hTR), ResultIs.Successful);
	}

	[Test]
	public void RollbackTransactionTest()
	{
		using var hTR = CreateTransaction(null, default, 0, 0, 0, 0, txnDesc);
		Assert.That(hTR, ResultIs.ValidHandle);
		Assert.That(RollbackTransaction(hTR), ResultIs.Successful);
	}
}