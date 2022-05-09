![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Cabinet NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Cabinet?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Cabinet.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Cabinet

Functions | Enumerations | Structures
--- | --- | ---
CloseCompressor<br>CloseDecompressor<br>Compress<br>CreateCompressor<br>CreateDecompressor<br>Decompress<br>FCIAddFile<br>FCICreate<br>FCIDestroy<br>FCIFlushCabinet<br>FCIFlushFolder<br>FDICopy<br>FDICreate<br>FDIDestroy<br>FDIIsCabinet<br>FDITruncateCabinet<br>QueryCompressorInformation<br>QueryDecompressorInformation<br>ResetCompressor<br>ResetDecompressor<br>SetCompressorInformation<br>SetDecompressorInformation<br> | COMPRESS_ALGORITHM<br>COMPRESS_INFORMATION_CLASS<br>CabinetFileStatus<br>FCIERROR<br>TCOMP<br>FDICPU<br>FDIDECRYPTTYPE<br>FDIERROR<br>FDINOTIFICATIONTYPE<br><br><br><br><br><br><br><br><br><br><br><br><br><br> | COMPRESS_ALLOCATION_ROUTINES<br>COMPRESSOR_HANDLE<br>DECOMPRESSOR_HANDLE<br>CCAB<br>HFCI<br>FDICABINETINFO<br>FDIDECRYPT<br>FDINOTIFICATION<br>HFDI<br>ERF<br>Union<br>NEW_CABINET<br>NEW_FOLDER<br>DECRYPT<br><br><br><br><br><br><br><br><br>
