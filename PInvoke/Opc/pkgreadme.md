![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Opc NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Opc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from opcservices.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Opc

Enumerations | Interfaces
--- | ---
OPC_CANONICALIZATION_METHOD<br>OPC_CERTIFICATE_EMBEDDING_OPTION<br>OPC_COMPRESSION_OPTIONS<br>OPC_READ_FLAGS<br>OPC_RELATIONSHIP_SELECTOR<br>OPC_RELATIONSHIPS_SIGNING_OPTION<br>OPC_SIGNATURE_TIME_FORMAT<br>OPC_SIGNATURE_VALIDATION_RESULT<br>OPC_STREAM_IO_MODE<br>OPC_URI_TARGET_MODE<br>OPC_WRITE_FLAGS<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | IOpcCertificateEnumerator<br>IOpcCertificateSet<br>IOpcDigitalSignature<br>IOpcDigitalSignatureEnumerator<br>IOpcDigitalSignatureManager<br>IOpcFactory<br>IOpcPackage<br>IOpcPart<br>IOpcPartEnumerator<br>IOpcPartSet<br>IOpcPartUri<br>IOpcRelationship<br>IOpcRelationshipEnumerator<br>IOpcRelationshipSelector<br>IOpcRelationshipSelectorEnumerator<br>IOpcRelationshipSelectorSet<br>IOpcRelationshipSet<br>IOpcSignatureCustomObject<br>IOpcSignatureCustomObjectEnumerator<br>IOpcSignatureCustomObjectSet<br>IOpcSignaturePartReference<br>IOpcSignaturePartReferenceEnumerator<br>IOpcSignaturePartReferenceSet<br>IOpcSignatureReference<br>IOpcSignatureReferenceEnumerator<br>IOpcSignatureReferenceSet<br>IOpcSignatureRelationshipReference<br>IOpcSignatureRelationshipReferenceEnumerator<br>IOpcSignatureRelationshipReferenceSet<br>IOpcSigningOptions<br>IOpcUri<br>
