![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.KtmW32 NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.KtmW32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants imported from Windows KtmW32.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.KtmW32

Functions | Enumerations | Structures
--- | --- | ---
CommitComplete<br>CommitEnlistment<br>CommitTransaction<br>CommitTransactionAsync<br>CreateEnlistment<br>CreateResourceManager<br>CreateTransaction<br>CreateTransactionManager<br>GetCurrentClockTransactionManager<br>GetEnlistmentId<br>GetEnlistmentRecoveryInformation<br>GetNotificationResourceManager<br>GetNotificationResourceManagerAsync<br>GetTransactionId<br>GetTransactionInformation<br>GetTransactionManagerId<br>OpenEnlistment<br>OpenResourceManager<br>OpenTransaction<br>OpenTransactionManager<br>OpenTransactionManagerById<br>PrepareComplete<br>PrepareEnlistment<br>PrePrepareComplete<br>PrePrepareEnlistment<br>ReadOnlyEnlistment<br>RecoverEnlistment<br>RecoverResourceManager<br>RecoverTransactionManager<br>RenameTransactionManager<br>RollbackComplete<br>RollbackEnlistment<br>RollbackTransaction<br>RollbackTransactionAsync<br>RollforwardTransactionManager<br>SetEnlistmentRecoveryInformation<br>SetResourceManagerCompletionPort<br>SetTransactionInformation<br>SinglePhaseReject<br> | CreateEnlistmentOptions<br>CreateRMOptions<br>CreateTrxnMgrOptions<br>CreateTrxnOptions<br>EnlistmentAccess<br>NOTIFICATION_MASK<br>ResourceManagerAccess<br>TRANSACTION_OUTCOME<br>TransactionAccess<br>TransactionMgrAccess<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | HENLISTMENT<br>HRESMGR<br>HTRXNMGR<br>TRANSACTION_NOTIFICATION<br>TRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
