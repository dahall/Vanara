![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.MsRdc NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.MsRdc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows MsRdc.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.MsRdc**

Enumerations | Structures | Interfaces
--- | --- | ---
GeneratorParametersType RDC_ErrorCode RdcCreatedTables RdcMappingAccessMode RdcNeedType              | FindSimilarFileIndexResults RdcBufferPointer RdcNeed RdcNeedPointer RdcSignature RdcSignaturePointer SimilarityData SimilarityDumpData SimilarityFileId SimilarityMappedViewInfo         | IFindSimilarResults IRdcComparator IRdcFileReader IRdcFileWriter IRdcGenerator IRdcGeneratorFilterMaxParameters IRdcGeneratorParameters IRdcLibrary IRdcSignatureReader IRdcSimilarityGenerator ISimilarity ISimilarityFileIdTable ISimilarityReportProgress ISimilarityTableDumpState ISimilarityTraitsMappedView ISimilarityTraitsMapping ISimilarityTraitsTable 
