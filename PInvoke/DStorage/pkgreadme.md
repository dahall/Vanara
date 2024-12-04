![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.DStorage NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.DStorage?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows DStorage.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.DStorage**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
DStorageCreateCompressionCodec DStorageGetFactory DStorageSetConfiguration DStorageSetConfiguration1                           | DSTORAGE_COMMAND_TYPE DSTORAGE_COMPRESSION DSTORAGE_COMPRESSION_FORMAT DSTORAGE_COMPRESSION_SUPPORT DSTORAGE_CUSTOM_DECOMPRESSION_FLAGS DSTORAGE_DEBUG DSTORAGE_ERROR DSTORAGE_GET_REQUEST_FLAGS DSTORAGE_PRIORITY DSTORAGE_REQUEST_DESTINATION_TYPE DSTORAGE_REQUEST_SOURCE_TYPE DSTORAGE_STAGING_BUFFER_SIZE                   | DSTORAGE_CONFIGURATION DSTORAGE_CONFIGURATION1 DSTORAGE_CUSTOM_DECOMPRESSION_REQUEST DSTORAGE_CUSTOM_DECOMPRESSION_RESULT DSTORAGE_DESTINATION DSTORAGE_DESTINATION_BUFFER DSTORAGE_DESTINATION_MEMORY DSTORAGE_DESTINATION_MULTIPLE_SUBRESOURCES DSTORAGE_DESTINATION_TEXTURE_REGION DSTORAGE_DESTINATION_TILES DSTORAGE_ERROR_FIRST_FAILURE DSTORAGE_ERROR_PARAMETERS_EVENT DSTORAGE_ERROR_PARAMETERS_REQUEST DSTORAGE_ERROR_PARAMETERS_SIGNAL DSTORAGE_ERROR_PARAMETERS_STATUS DSTORAGE_ERROR_RECORD DSTORAGE_QUEUE_DESC DSTORAGE_QUEUE_INFO DSTORAGE_REQUEST DSTORAGE_REQUEST_OPTIONS DSTORAGE_SOURCE DSTORAGE_SOURCE_FILE DSTORAGE_SOURCE_MEMORY <Reserved>e__FixedBuffer UNION <_Filename>e__FixedBuffer <_RequestName>e__FixedBuffer <Reserved1>e__FixedBuffer <Reserved>e__FixedBuffer  | IDStorageCompressionCodec IDStorageCustomDecompressionQueue IDStorageCustomDecompressionQueue1 IDStorageFactory IDStorageFile IDStorageQueue IDStorageQueue1 IDStorageQueue2 IDStorageStatusArray                     
