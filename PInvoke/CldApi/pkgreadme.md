![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.CldApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.CldApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants imported from Windows CldApi.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.CldApi**

Functions | Enumerations | Structures
--- | --- | ---
CfCloseHandle CfConnectSyncRoot CfConvertToPlaceholder CfCreatePlaceholders CfDehydratePlaceholder CfDisconnectSyncRoot CfExecute CfGetCorrelationVector CfGetPlaceholderInfo CfGetPlaceholderRangeInfo CfGetPlaceholderStateFromAttributeTag CfGetPlaceholderStateFromFileInfo CfGetPlaceholderStateFromFindData CfGetPlatformInfo CfGetSyncRootInfoByHandle CfGetSyncRootInfoByPath CfGetTransferKey CfGetWin32HandleFromProtectedHandle CfHydratePlaceholder CfOpenFileWithOplock CfQuerySyncProviderStatus CfReferenceProtectedHandle CfRegisterSyncRoot CfReleaseProtectedHandle CfReleaseTransferKey CfReportProviderProgress CfReportSyncStatus CfRevertPlaceholder CfSetCorrelationVector CfSetInSyncState CfSetPinState CfUnregisterSyncRoot CfUpdatePlaceholder CfUpdateSyncProviderStatus                | CF_CALLBACK_CANCEL_FLAGS CF_CALLBACK_CLOSE_COMPLETION_FLAGS CF_CALLBACK_DEHYDRATE_COMPLETION_FLAGS CF_CALLBACK_DEHYDRATE_FLAGS CF_CALLBACK_DEHYDRATION_REASON CF_CALLBACK_DELETE_COMPLETION_FLAGS CF_CALLBACK_DELETE_FLAGS CF_CALLBACK_FETCH_DATA_FLAGS CF_CALLBACK_FETCH_PLACEHOLDERS_FLAGS CF_CALLBACK_OPEN_COMPLETION_FLAGS CF_CALLBACK_RENAME_COMPLETION_FLAGS CF_CALLBACK_RENAME_FLAGS CF_CALLBACK_TYPE CF_CALLBACK_VALIDATE_DATA_FLAGS CF_CONNECT_FLAGS CF_CONVERT_FLAGS CF_CREATE_FLAGS CF_DEHYDRATE_FLAGS CF_HARDLINK_POLICY CF_HYDRATE_FLAGS CF_HYDRATION_POLICY_MODIFIER CF_HYDRATION_POLICY_PRIMARY CF_IN_SYNC_STATE CF_INSYNC_POLICY CF_OPEN_FILE_FLAGS CF_OPERATION_ACK_DATA_FLAGS CF_OPERATION_ACK_DEHYDRATE_FLAGS CF_OPERATION_ACK_DELETE_FLAGS CF_OPERATION_ACK_RENAME_FLAGS CF_OPERATION_RESTART_HYDRATION_FLAGS CF_OPERATION_RETRIEVE_DATA_FLAGS CF_OPERATION_TRANSFER_DATA_FLAGS CF_OPERATION_TRANSFER_PLACEHOLDERS_FLAGS CF_OPERATION_TYPE CF_PIN_STATE CF_PLACEHOLDER_CREATE_FLAGS CF_PLACEHOLDER_INFO_CLASS CF_PLACEHOLDER_RANGE_INFO_CLASS CF_PLACEHOLDER_STATE CF_POPULATION_POLICY_MODIFIER CF_POPULATION_POLICY_PRIMARY CF_REGISTER_FLAGS CF_REVERT_FLAGS CF_SET_IN_SYNC_FLAGS CF_SET_PIN_FLAGS CF_SYNC_PROVIDER_STATUS CF_SYNC_ROOT_INFO_CLASS CF_UPDATE_FLAGS  | CF_CALLBACK_INFO CF_CALLBACK_PARAMETERS CF_CALLBACK_REGISTRATION CF_CONNECTION_KEY CF_FILE_RANGE CF_FILE_RANGE_BUFFER CF_FS_METADATA CF_HYDRATION_POLICY CF_OPERATION_INFO CF_OPERATION_PARAMETERS CF_PLACEHOLDER_BASIC_INFO CF_PLACEHOLDER_CREATE_INFO CF_PLACEHOLDER_STANDARD_INFO CF_PLATFORM_INFO CF_POPULATION_POLICY CF_PROCESS_INFO CF_REQUEST_KEY CF_SYNC_POLICIES CF_SYNC_REGISTRATION CF_SYNC_ROOT_BASIC_INFO CF_SYNC_ROOT_PROVIDER_INFO CF_SYNC_ROOT_STANDARD_INFO CF_SYNC_STATUS CF_TRANSFER_KEY HCFFILE CANCEL CLOSECOMPLETION DEHYDRATE DEHYDRATECOMPLETION DELETE DELETECOMPLETION FETCHDATA FETCHPLACEHOLDERS OPENCOMPLETION RENAME RENAMECOMPLETION VALIDATEDATA TRANSFERDATA RETRIEVEDATA ACKDATA RESTARTHYDRATION TRANSFERPLACEHOLDERS ACKDEHYDRATE ACKRENAME ACKDELETE CANCELFETCHDATA   
