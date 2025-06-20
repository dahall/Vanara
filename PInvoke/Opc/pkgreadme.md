![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Opc NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Opc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from opcservices.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Opc**

Enumerations | Interfaces
--- | ---
OPC_CANONICALIZATION_METHOD OPC_CERTIFICATE_EMBEDDING_OPTION OPC_COMPRESSION_OPTIONS OPC_READ_FLAGS OPC_RELATIONSHIP_SELECTOR OPC_RELATIONSHIPS_SIGNING_OPTION OPC_SIGNATURE_TIME_FORMAT OPC_SIGNATURE_VALIDATION_RESULT OPC_STREAM_IO_MODE OPC_URI_TARGET_MODE OPC_WRITE_FLAGS                      | IOpcCertificateEnumerator IOpcCertificateSet IOpcDigitalSignature IOpcDigitalSignatureEnumerator IOpcDigitalSignatureManager IOpcFactory IOpcPackage IOpcPart IOpcPartEnumerator IOpcPartSet IOpcPartUri IOpcRelationship IOpcRelationshipEnumerator IOpcRelationshipSelector IOpcRelationshipSelectorEnumerator IOpcRelationshipSelectorSet IOpcRelationshipSet IOpcSignatureCustomObject IOpcSignatureCustomObjectEnumerator IOpcSignatureCustomObjectSet IOpcSignaturePartReference IOpcSignaturePartReferenceEnumerator IOpcSignaturePartReferenceSet IOpcSignatureReference IOpcSignatureReferenceEnumerator IOpcSignatureReferenceSet IOpcSignatureRelationshipReference IOpcSignatureRelationshipReferenceEnumerator IOpcSignatureRelationshipReferenceSet IOpcSigningOptions IOpcUri 
