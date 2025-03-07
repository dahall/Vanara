![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Cabinet NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Cabinet?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Cabinet.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Cabinet**

Functions | Enumerations | Structures
--- | --- | ---
CloseCompressor CloseDecompressor Compress CreateCompressor CreateDecompressor Decompress FCIAddFile FCICreate FCIDestroy FCIFlushCabinet FCIFlushFolder FDICopy FDICreate FDIDestroy FDIIsCabinet FDITruncateCabinet QueryCompressorInformation QueryDecompressorInformation ResetCompressor ResetDecompressor SetCompressorInformation SetDecompressorInformation  | COMPRESS_ALGORITHM COMPRESS_INFORMATION_CLASS CabinetFileStatus FCIERROR TCOMP FDICPU FDIDECRYPTTYPE FDIERROR FDINOTIFICATIONTYPE               | COMPRESS_ALLOCATION_ROUTINES CCAB FDICABINETINFO FDIDECRYPT FDINOTIFICATION ERF COMPRESSOR_HANDLE DECOMPRESSOR_HANDLE HFCI HFDI Union NEW_CABINET NEW_FOLDER DECRYPT         
