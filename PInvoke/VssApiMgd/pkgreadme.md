![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.VssApiMgd NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.VssApiMgd?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Volume Shadow Copy Service (VssApi.dll).

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.VssApiMgd

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
IsVolumeSnapshotted<br>IsVolumeSnapshottedInternal<br>ShouldBlockRevert<br>ShouldBlockRevertInternal<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | VDS_INTERCONNECT_ADDRESS_TYPE<br>VDS_STORAGE_BUS_TYPE<br>VDS_STORAGE_IDENTIFIER_CODE_SET<br>VDS_STORAGE_IDENTIFIER_TYPE<br>VSS_MGMT_OBJECT_TYPE<br>VSS_PROTECTION_FAULT<br>VSS_PROTECTION_LEVEL<br>VSS_APPLICATION_LEVEL<br>VSS_BACKUP_SCHEMA<br>VSS_BACKUP_TYPE<br>VSS_FILE_SPEC_BACKUP_TYPE<br>VSS_HARDWARE_OPTIONS<br>VSS_OBJECT_TYPE<br>VSS_PROVIDER_CAPABILITIES<br>VSS_PROVIDER_TYPE<br>VSS_RECOVERY_OPTIONS<br>VSS_RESTORE_TYPE<br>VSS_ROLLFORWARD_TYPE<br>VSS_SNAPSHOT_COMPATIBILITY<br>VSS_SNAPSHOT_CONTEXT<br>VSS_SNAPSHOT_PROPERTY_ID<br>VSS_SNAPSHOT_STATE<br>VSS_VOLUME_SNAPSHOT_ATTRIBUTES<br>VSS_WRITER_STATE<br>VSS_ALTERNATE_WRITER_STATE<br>VSS_COMPONENT_FLAGS<br>VSS_COMPONENT_TYPE<br>VSS_FILE_RESTORE_STATUS<br>VSS_RESTORE_TARGET<br>VSS_RESTOREMETHOD_ENUM<br>VSS_SOURCE_TYPE<br>VSS_SUBSCRIBE_MASK<br>VSS_USAGE_TYPE<br>VSS_WRITERRESTORE_ENUM<br> | VDS_INTERCONNECT<br>VDS_LUN_INFORMATION<br>VDS_STORAGE_DEVICE_ID_DESCRIPTOR<br>VDS_STORAGE_IDENTIFIER<br>VSS_COMPONENTINFO<br>VssWriterStatus<br>VSS_DIFF_AREA_PROP<br>VSS_DIFF_VOLUME_PROP<br>VSS_MGMT_OBJECT_PROP<br>VSS_MGMT_OBJECT_UNION<br>VSS_VOLUME_PROP<br>VSS_VOLUME_PROTECTION_INFO<br>VSS_OBJECT_PROP<br>VSS_OBJECT_UNION<br>VSS_PROVIDER_PROP<br>VSS_SNAPSHOT_PROP<br>VssDifferencedFile<br>VssDirectedTarget<br>VssPartialFile<br>VssRestoreSubcomponent<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | IVssAdmin<br>IVssAdminEx<br>IVssDifferentialSoftwareSnapshotMgmt<br>IVssDifferentialSoftwareSnapshotMgmt2<br>IVssDifferentialSoftwareSnapshotMgmt3<br>IVssEnumMgmtObject<br>IVssSnapshotMgmt<br>IVssSnapshotMgmt2<br>IVssFileShareSnapshotProvider<br>IVssHardwareSnapshotProvider<br>IVssHardwareSnapshotProviderEx<br>IVssProviderCreateSnapshotSet<br>IVssProviderNotifications<br>IVssSoftwareSnapshotProvider<br>IVssAsync<br>IVssEnumObject<br>IVssCreateExpressWriterMetadata<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
