![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.ClfsW32 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.ClfsW32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows Common Log File System (ClfsW32.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.ClfsW32**

Functions | Enumerations | Structures
--- | --- | ---
AddLogContainer<br>AddLogContainerSet<br>AdvanceLogBase<br>AlignReservedLog<br>AllocReservedLog<br>CloseAndResetLogFile<br>CreateLogContainerScanContext<br>CreateLogFile<br>CreateLogMarshallingArea<br>DeleteLogByHandle<br>DeleteLogFile<br>DeleteLogMarshallingArea<br>DeregisterManageableLogClient<br>DumpLogRecords<br>FlushLogBuffers<br>FlushLogToLsn<br>FreeReservedLog<br>GetLogContainerName<br>GetLogFileInformation<br>GetLogIoStatistics<br>GetLogReservationInfo<br>GetNextLogArchiveExtent<br>HandleLogFull<br>InstallLogPolicy<br>LogTailAdvanceFailure<br>LsnBlockOffset<br>LsnContainer<br>LsnCreate<br>LsnDecrement<br>LsnEqual<br>LsnGreater<br>LsnIncrement<br>LsnInvalid<br>LsnLess<br>LsnNull<br>LsnRecordSequence<br>PrepareLogArchive<br>QueryLogPolicy<br>ReadLogArchiveMetadata<br>ReadLogNotification<br>ReadLogRecord<br>ReadLogRestartArea<br>ReadNextLogRecord<br>ReadPreviousLogRestartArea<br>RegisterForLogWriteNotification<br>RegisterManageableLogClient<br>RemoveLogContainer<br>RemoveLogContainerSet<br>RemoveLogPolicy<br>ReserveAndAppendLog<br>ReserveAndAppendLogAligned<br>ScanLogContainers<br>SetEndOfLog<br>SetLogArchiveMode<br>SetLogArchiveTail<br>SetLogFileSizeWithPolicy<br>TerminateLogArchive<br>TerminateReadLog<br>TruncateLog<br>ValidateLog<br>WriteLogRestartArea<br> | CLFS_CONTAINER_STATE<br>CLFS_CONTEXT_MODE<br>CLFS_FLAG<br>CLFS_IOSTATS_CLASS<br>CLFS_LOG_ARCHIVE_MODE<br>CLFS_MARSHALLING_FLAG<br>CLFS_SCAN_MODE<br>CLS_RECORD_TYPE<br>CLFS_MGMT_NOTIFICATION_TYPE<br>CLFS_MGMT_POLICY_TYPE<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | CLFS_NODE_ID<br>CLS_ARCHIVE_DESCRIPTOR<br>CLS_CONTAINER_INFORMATION<br>CLS_INFORMATION<br>CLS_IO_STATISTICS<br>CLS_IO_STATISTICS_HEADER<br>CLS_LSN<br>CLS_SCAN_CONTEXT<br>CLS_WRITE_ENTRY<br>CLFS_MGMT_NOTIFICATION<br>CLFS_MGMT_POLICY<br>LOG_MANAGEMENT_CALLBACKS<br>HLOG<br>POLICYPARAMETERS<br>MAXIMUMSIZE<br>MINIMUMSIZE<br>NEWCONTAINERSIZE<br>GROWTHRATE<br>LOGTAIL<br>AUTOSHRINK<br>AUTOGROW<br>NEWCONTAINERPREFIX<br>NEWCONTAINERSUFFIX<br>NEWCONTAINEREXTENSION<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
