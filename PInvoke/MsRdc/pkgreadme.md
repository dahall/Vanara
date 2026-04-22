![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.MsRdc NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.MsRdc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows MsRdc.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.MsRdc**

Enumerations | Structures | Interfaces
--- | --- | ---
GeneratorParametersType<br>RDC_ErrorCode<br>RdcCreatedTables<br>RdcMappingAccessMode<br>RdcNeedType<br><br><br><br><br><br><br><br><br><br><br><br><br> | FindSimilarFileIndexResults<br>RdcBufferPointer<br>RdcNeed<br>RdcNeedPointer<br>RdcSignature<br>RdcSignaturePointer<br>SimilarityData<br>SimilarityDumpData<br>SimilarityFileId<br>SimilarityMappedViewInfo<br><br><br><br><br><br><br><br> | IFindSimilarResults<br>IRdcComparator<br>IRdcFileReader<br>IRdcFileWriter<br>IRdcGenerator<br>IRdcGeneratorFilterMaxParameters<br>IRdcGeneratorParameters<br>IRdcLibrary<br>IRdcSignatureReader<br>IRdcSimilarityGenerator<br>ISimilarity<br>ISimilarityFileIdTable<br>ISimilarityReportProgress<br>ISimilarityTableDumpState<br>ISimilarityTraitsMappedView<br>ISimilarityTraitsMapping<br>ISimilarityTraitsTable<br>
