![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.ClfsW32 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.ClfsW32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Common Log File System (ClfsW32.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.ClfsW32**

Functions | Enumerations | Structures
--- | --- | ---
AddLogContainer AddLogContainerSet AdvanceLogBase AlignReservedLog AllocReservedLog CloseAndResetLogFile CreateLogContainerScanContext CreateLogFile CreateLogMarshallingArea DeleteLogByHandle DeleteLogFile DeleteLogMarshallingArea DeregisterManageableLogClient DumpLogRecords FlushLogBuffers FlushLogToLsn FreeReservedLog GetLogContainerName GetLogFileInformation GetLogIoStatistics GetLogReservationInfo GetNextLogArchiveExtent HandleLogFull InstallLogPolicy LogTailAdvanceFailure LsnBlockOffset LsnContainer LsnCreate LsnDecrement LsnEqual LsnGreater LsnIncrement LsnInvalid LsnLess LsnNull LsnRecordSequence PrepareLogArchive QueryLogPolicy ReadLogArchiveMetadata ReadLogNotification ReadLogRecord ReadLogRestartArea ReadNextLogRecord ReadPreviousLogRestartArea RegisterForLogWriteNotification RegisterManageableLogClient RemoveLogContainer RemoveLogContainerSet RemoveLogPolicy ReserveAndAppendLog ReserveAndAppendLogAligned ScanLogContainers SetEndOfLog SetLogArchiveMode SetLogArchiveTail SetLogFileSizeWithPolicy TerminateLogArchive TerminateReadLog TruncateLog ValidateLog WriteLogRestartArea  | CLFS_CONTAINER_STATE CLFS_CONTEXT_MODE CLFS_FLAG CLFS_IOSTATS_CLASS CLFS_LOG_ARCHIVE_MODE CLFS_MARSHALLING_FLAG CLFS_SCAN_MODE CLS_RECORD_TYPE CLFS_MGMT_NOTIFICATION_TYPE CLFS_MGMT_POLICY_TYPE                                                     | CLFS_NODE_ID CLS_ARCHIVE_DESCRIPTOR CLS_CONTAINER_INFORMATION CLS_INFORMATION CLS_IO_STATISTICS CLS_IO_STATISTICS_HEADER CLS_LSN CLS_SCAN_CONTEXT CLS_WRITE_ENTRY CLFS_MGMT_NOTIFICATION CLFS_MGMT_POLICY LOG_MANAGEMENT_CALLBACKS HLOG POLICYPARAMETERS MAXIMUMSIZE MINIMUMSIZE NEWCONTAINERSIZE GROWTHRATE LOGTAIL AUTOSHRINK AUTOGROW NEWCONTAINERPREFIX NEWCONTAINERSUFFIX NEWCONTAINEREXTENSION                                      
