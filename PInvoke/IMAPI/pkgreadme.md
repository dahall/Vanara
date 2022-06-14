![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.IMAPI NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.IMAPI?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (interfaces and constants) imported from Windows Image Mastering API.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.IMAPI**

Enumerations | Interfaces
--- | ---
IMAPI_BURN_VERIFICATION_LEVEL IMAPI_CD_SECTOR_TYPE IMAPI_CD_TRACK_DIGITAL_COPY_SETTING IMAPI_FEATURE_PAGE_TYPE IMAPI_FORMAT2_DATA_MEDIA_STATE IMAPI_FORMAT2_DATA_WRITE_ACTION IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE IMAPI_FORMAT2_RAW_CD_WRITE_ACTION IMAPI_FORMAT2_TAO_WRITE_ACTION IMAPI_MEDIA_PHYSICAL_TYPE IMAPI_MEDIA_WRITE_PROTECT_STATE IMAPI_MODE_PAGE_REQUEST_TYPE IMAPI_MODE_PAGE_TYPE IMAPI_PROFILE_TYPE IMAPI_READ_TRACK_ADDRESS_TYPE EmulationType FsiFileSystems FsiItemType PlatformId                               | DDiscFormat2DataEvents DDiscFormat2EraseEvents DDiscFormat2RawCDEvents DDiscFormat2TrackAtOnceEvents DDiscMaster2Events DWriteEngine2Events IBlockRange IBlockRangeList IBurnVerification IDiscFormat2Data IDiscFormat2DataEventArgs IDiscFormat2Erase IDiscFormat2RawCD IDiscFormat2RawCDEventArgs IDiscFormat2TrackAtOnce IDiscFormat2TrackAtOnceEventArgs IDiscMaster2 IDiscRecorder2 IDiscRecorder2Ex IDiscFormat2 IMultisession IMultisessionRandomWrite IMultisessionSequential IMultisessionSequential2 IRawCDImageCreator IRawCDImageTrackInfo IWriteEngine2 IWriteEngine2EventArgs IWriteSpeedDescriptor DFileSystemImageEvents DFileSystemImageImportEvents IBootOptions IEnumFsiItems IEnumProgressItems IFileSystemImage IFileSystemImage2 IFileSystemImage3 IFileSystemImageResult IFileSystemImageResult2 IFsiDirectoryItem IFsiDirectoryItem2 IFsiFileItem IFsiFileItem2 IFsiItem IFsiNamedStreams IIsoImageManager IProgressItem IProgressItems 
