![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.VssApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.VssApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows Volume Shadow Copy Service (VssApi.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.VssApi**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
IsVolumeSnapshottedInternal ShouldBlockRevertInternal                                  | VDS_INTERCONNECT_ADDRESS_TYPE VDS_STORAGE_BUS_TYPE VDS_STORAGE_IDENTIFIER_CODE_SET VDS_STORAGE_IDENTIFIER_TYPE VSS_MGMT_OBJECT_TYPE VSS_PROTECTION_FAULT VSS_PROTECTION_LEVEL VSS_APPLICATION_LEVEL VSS_BACKUP_SCHEMA VSS_BACKUP_TYPE VSS_FILE_SPEC_BACKUP_TYPE VSS_HARDWARE_OPTIONS VSS_OBJECT_TYPE VSS_PROVIDER_CAPABILITIES VSS_PROVIDER_TYPE VSS_RECOVERY_OPTIONS VSS_RESTORE_TYPE VSS_ROLLFORWARD_TYPE VSS_SNAPSHOT_COMPATIBILITY VSS_SNAPSHOT_CONTEXT VSS_SNAPSHOT_PROPERTY_ID VSS_SNAPSHOT_STATE VSS_VOLUME_SNAPSHOT_ATTRIBUTES VSS_WRITER_STATE VSS_ALTERNATE_WRITER_STATE VSS_COMPONENT_FLAGS VSS_COMPONENT_TYPE VSS_FILE_RESTORE_STATUS VSS_RESTORE_TARGET VSS_RESTOREMETHOD_ENUM VSS_SOURCE_TYPE VSS_SUBSCRIBE_MASK VSS_USAGE_TYPE VSS_WRITERRESTORE_ENUM  | VDS_INTERCONNECT VDS_LUN_INFORMATION VDS_STORAGE_DEVICE_ID_DESCRIPTOR VDS_STORAGE_IDENTIFIER VSS_COMPONENTINFO VssWriterStatus VSS_DIFF_AREA_PROP VSS_DIFF_VOLUME_PROP VSS_MGMT_OBJECT_PROP VSS_MGMT_OBJECT_UNION VSS_VOLUME_PROP VSS_VOLUME_PROTECTION_INFO VSS_OBJECT_PROP VSS_OBJECT_UNION VSS_PROVIDER_PROP VSS_SNAPSHOT_PROP VssDifferencedFile VssDirectedTarget VssPartialFile VssRestoreSubcomponent                | IVssAdmin IVssAdminEx IVssDifferentialSoftwareSnapshotMgmt IVssDifferentialSoftwareSnapshotMgmt2 IVssDifferentialSoftwareSnapshotMgmt3 IVssEnumMgmtObject IVssSnapshotMgmt IVssSnapshotMgmt2 IVssFileShareSnapshotProvider IVssHardwareSnapshotProvider IVssHardwareSnapshotProviderEx IVssProviderCreateSnapshotSet IVssProviderNotifications IVssSoftwareSnapshotProvider IVssAsync IVssEnumObject IVssCreateExpressWriterMetadata                  
