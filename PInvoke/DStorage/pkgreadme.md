![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.DStorage NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.DStorage?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows DStorage.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.DStorage**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
DStorageCreateCompressionCodec<br>DStorageGetFactory<br>DStorageSetConfiguration<br>DStorageSetConfiguration1<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | DSTORAGE_COMMAND_TYPE<br>DSTORAGE_COMPRESSION<br>DSTORAGE_COMPRESSION_FORMAT<br>DSTORAGE_COMPRESSION_SUPPORT<br>DSTORAGE_CUSTOM_DECOMPRESSION_FLAGS<br>DSTORAGE_DEBUG<br>DSTORAGE_ERROR<br>DSTORAGE_GET_REQUEST_FLAGS<br>DSTORAGE_PRIORITY<br>DSTORAGE_REQUEST_DESTINATION_TYPE<br>DSTORAGE_REQUEST_SOURCE_TYPE<br>DSTORAGE_STAGING_BUFFER_SIZE<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | DSTORAGE_CONFIGURATION<br>DSTORAGE_CONFIGURATION1<br>DSTORAGE_CUSTOM_DECOMPRESSION_REQUEST<br>DSTORAGE_CUSTOM_DECOMPRESSION_RESULT<br>DSTORAGE_DESTINATION<br>DSTORAGE_DESTINATION_BUFFER<br>DSTORAGE_DESTINATION_MEMORY<br>DSTORAGE_DESTINATION_MULTIPLE_SUBRESOURCES<br>DSTORAGE_DESTINATION_TEXTURE_REGION<br>DSTORAGE_DESTINATION_TILES<br>DSTORAGE_ERROR_FIRST_FAILURE<br>DSTORAGE_ERROR_PARAMETERS_EVENT<br>DSTORAGE_ERROR_PARAMETERS_REQUEST<br>DSTORAGE_ERROR_PARAMETERS_SIGNAL<br>DSTORAGE_ERROR_PARAMETERS_STATUS<br>DSTORAGE_ERROR_RECORD<br>DSTORAGE_QUEUE_DESC<br>DSTORAGE_QUEUE_INFO<br>DSTORAGE_REQUEST<br>DSTORAGE_REQUEST_OPTIONS<br>DSTORAGE_SOURCE<br>DSTORAGE_SOURCE_FILE<br>DSTORAGE_SOURCE_MEMORY<br><Reserved>e__FixedBuffer<br>UNION<br><_Filename>e__FixedBuffer<br><_RequestName>e__FixedBuffer<br><Reserved1>e__FixedBuffer<br><Reserved>e__FixedBuffer<br> | IDStorageCompressionCodec<br>IDStorageCustomDecompressionQueue<br>IDStorageCustomDecompressionQueue1<br>IDStorageFactory<br>IDStorageFile<br>IDStorageQueue<br>IDStorageQueue1<br>IDStorageQueue2<br>IDStorageStatusArray<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
